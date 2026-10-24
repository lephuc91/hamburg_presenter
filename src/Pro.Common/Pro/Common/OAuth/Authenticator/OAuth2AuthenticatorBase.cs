using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using RestSharp;
using RestSharp.Authenticators;

namespace Pro.Common.OAuth.Authenticator;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_renewTokensSemaphore" })]
public abstract class OAuth2AuthenticatorBase : IAuthenticator, RestSharp.Authenticators.IAuthenticator, IDisposable
{
	private sealed class GetAuthorizationResult
	{
		public bool Successful { get; }

		public OAuth2AuthorizationDataStored Authorization { get; }

		public GetAuthorizationResult(bool successful, OAuth2AuthorizationDataStored? authorization = null)
		{
			Successful = successful;
			Authorization = authorization ?? new OAuth2AuthorizationDataStored(string.Empty, string.Empty, null);
		}

		public void Deconstruct(out bool successful, out OAuth2AuthorizationDataStored authorization)
		{
			successful = Successful;
			authorization = Authorization;
		}
	}

	private const int TOKEN_EXPIRATION_MARGIN_IN_SECONDS = 300;

	private readonly ILogger _logger;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IOAuth2AuthorizationStore _authorizationStore;

	private readonly ICurrentTimeOffset _currentTime;

	private readonly string _clientId;

	private readonly string? _clientSecret;

	private readonly Uri _authorizationBaseUrl;

	private readonly string _authorizePath;

	private readonly string _getTokenPath;

	private readonly string _authorizeCallbackUrl;

	private readonly string? _subscriptionKey;

	private readonly string? _scope;

	private readonly SemaphoreSlim _renewTokensSemaphore = new SemaphoreSlim(1);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected OAuth2AuthenticatorBase(ILogger logger, IRestClientFactory restClientFactory, IOAuth2AuthorizationStore authorizationStore, ICurrentTimeOffset currentTime, string clientId, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? clientSecret = null, string? subscriptionKey = null, string? scope = null)
	{
		_logger = logger;
		_restClientFactory = restClientFactory;
		_authorizationStore = authorizationStore;
		_currentTime = currentTime;
		_clientId = clientId;
		_clientSecret = clientSecret;
		_authorizationBaseUrl = authorizationBaseUrl;
		_authorizePath = authorizePath;
		_getTokenPath = getTokenPath;
		_authorizeCallbackUrl = authorizeCallbackUrl;
		_subscriptionKey = subscriptionKey;
		_scope = scope;
	}

	public async ValueTask Authenticate(IRestClient client, RestRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		var (flag2, oAuth2AuthorizationDataStored2) = await GetAuthorizationAndRefreshIfRequiredAsync(forceRefresh: false, cancellationToken);
		if (flag2)
		{
			request.AddHeader("Authorization", "Bearer " + oAuth2AuthorizationDataStored2.AccessToken);
			request.AddHeader("Accept", "application/json");
			if (_subscriptionKey != null)
			{
				request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
			}
		}
	}

	public string GetLoginUrl()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["response_type"] = "code",
			["client_id"] = _clientId,
			["redirect_uri"] = _authorizeCallbackUrl
		};
		if (_scope != null)
		{
			dictionary["scope"] = _scope;
		}
		AddAuthorizationBeginQueryParameters(dictionary);
		return _authorizationBaseUrl.AppendPathSegment(_authorizePath).SetQueryParams(dictionary);
	}

	public bool IsAuthorizationCallback(string? url)
	{
		return url?.StartsWith(_authorizeCallbackUrl) ?? false;
	}

	public async Task CompleteAuthorizationWithUrlAsync(string url, CancellationToken token = default(CancellationToken))
	{
		if (IsAuthorizationCallback(url) && new Url(url).QueryParams.TryGetFirst("code", out var value))
		{
			await TradeAuthorizationCodeForAccessTokensAsync(value.ToString(), token);
		}
	}

	public async Task<bool> RefreshAuthorizationAsync(CancellationToken token = default(CancellationToken))
	{
		(await GetAuthorizationAndRefreshIfRequiredAsync(forceRefresh: true, token)).Deconstruct(out bool successful, out OAuth2AuthorizationDataStored _);
		return successful;
	}

	private async ValueTask<GetAuthorizationResult> GetAuthorizationAndRefreshIfRequiredAsync(bool forceRefresh = false, CancellationToken token = default(CancellationToken))
	{
		await _renewTokensSemaphore.WaitAsync(token);
		try
		{
			return await GetAuthorizationAndRefreshIfRequiredUnsafeAsync(forceRefresh, token);
		}
		finally
		{
			_renewTokensSemaphore.Release();
		}
	}

	private async ValueTask<GetAuthorizationResult> GetAuthorizationAndRefreshIfRequiredUnsafeAsync(bool forceRefresh, CancellationToken token = default(CancellationToken))
	{
		OAuth2AuthorizationDataStored authorization = _authorizationStore.GetAuthorization();
		if (string.IsNullOrWhiteSpace(authorization.RefreshToken))
		{
			_logger.Debug("[{0}] Cannot refresh authorization without refresh token", "OAuth2AuthenticatorBase");
			return new GetAuthorizationResult(successful: false);
		}
		if (!IsTokenExpired(authorization.ExpirationDate) && !forceRefresh)
		{
			return new GetAuthorizationResult(successful: true, authorization);
		}
		RestRequest request = new RestRequest(_getTokenPath).AddParameter("grant_type", "refresh_token").AddParameter("refresh_token", authorization.RefreshToken);
		return await GetAndStoreAuthorizationAsync(request, token);
	}

	private bool IsTokenExpired(DateTimeOffset? expirationDate)
	{
		if (expirationDate.HasValue)
		{
			return expirationDate.Value < _currentTime.UtcNow;
		}
		return true;
	}

	private async Task TradeAuthorizationCodeForAccessTokensAsync(string code, CancellationToken token)
	{
		await _renewTokensSemaphore.WaitAsync(token);
		RestRequest request = new RestRequest(_getTokenPath).AddParameter("grant_type", "authorization_code").AddParameter("code", code);
		foreach (KeyValuePair<string, string> authorizationCodeTradeParameter in GetAuthorizationCodeTradeParameters())
		{
			request = request.AddParameter(authorizationCodeTradeParameter.Key, authorizationCodeTradeParameter.Value);
		}
		try
		{
			await GetAndStoreAuthorizationAsync(request);
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}] Failed to complete authorization with exception:\n{1}", "OAuth2AuthenticatorBase", ex);
		}
		finally
		{
			_renewTokensSemaphore.Release();
		}
	}

	private async Task<GetAuthorizationResult> GetAndStoreAuthorizationAsync(RestRequest request, CancellationToken token = default(CancellationToken))
	{
		GetAuthorizationResult getAuthorizationResult = await GetAuthorizationAsync(request, token);
		if (getAuthorizationResult.Successful)
		{
			_authorizationStore.StoreAuthorization(getAuthorizationResult.Authorization);
		}
		return getAuthorizationResult;
	}

	private async Task<GetAuthorizationResult> GetAuthorizationAsync(RestRequest request, CancellationToken token = default(CancellationToken))
	{
		using IRestClient client = _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.BaseUrl = _authorizationBaseUrl;
		});
		request.AddParameter("client_id", _clientId);
		request.AddParameter("redirect_uri", _authorizeCallbackUrl);
		if (_clientSecret != null)
		{
			request.AddParameter("client_secret", _clientSecret);
		}
		RestResponse<OAuth2AuthorizationDataReceived> restResponse = await client.ExecutePostAsync<OAuth2AuthorizationDataReceived>(request, token);
		if (restResponse.IsSuccessful)
		{
			int num = Math.Max(0, (restResponse.Data?.ExpiresIn).GetValueOrDefault() - 300);
			return new GetAuthorizationResult(successful: true, new OAuth2AuthorizationDataStored(restResponse.Data?.AccessToken ?? string.Empty, restResponse.Data?.RefreshToken ?? string.Empty, _currentTime.UtcNow.AddSeconds(num)));
		}
		_logger.Warning("[{0}] Getting Authorization returned status code ({1}) with content: {2}", "OAuth2AuthenticatorBase", restResponse.StatusCode, restResponse.Content);
		HttpStatusCode statusCode = restResponse.StatusCode;
		if (statusCode != HttpStatusCode.NotFound && statusCode != HttpStatusCode.RequestTimeout && (uint)(statusCode - 503) > 1u)
		{
			_logger.Info("[{0}] Clearing authorization", "OAuth2AuthenticatorBase");
			_authorizationStore.ClearAuthorization();
		}
		return new GetAuthorizationResult(successful: false);
	}

	protected abstract IEnumerable<KeyValuePair<string, string>> GetAuthorizationCodeTradeParameters();

	protected abstract void AddAuthorizationBeginQueryParameters(IDictionary<string, string> parameters);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_renewTokensSemaphore.Dispose();
		}
	}
}
