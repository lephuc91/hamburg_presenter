using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Interceptors;

namespace Pro.Common.AuthenticatingApiConsumer.OAuth2;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_renewTokensSemaphore" })]
public abstract class OAuth2ApiConsumerBase : IAuthenticatingApiConsumer, IDisposable
{
	private sealed class Authenticator : RestSharp.Authenticators.IAuthenticator
	{
		private readonly IOAuth2AuthorizationStore _authorizationStore;

		private readonly string? _subscriptionKey;

		public Authenticator(IOAuth2AuthorizationStore authorizationStore, string? subscriptionKey = null)
		{
			_authorizationStore = authorizationStore;
			_subscriptionKey = subscriptionKey;
		}

		public ValueTask Authenticate(IRestClient client, RestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			OAuth2AuthorizationDataStored authorization = _authorizationStore.GetAuthorization();
			if (!authorization.AccessToken.NullableIsNullOrWhiteSpace())
			{
				request.AddHeader("Authorization", "Bearer " + authorization.AccessToken);
			}
			if (_subscriptionKey != null)
			{
				request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
			}
			return default(ValueTask);
		}
	}

	private sealed class GetAuthorizationResult
	{
		public bool Successful { get; }

		public OAuth2AuthorizationDataStored Authorization { get; }

		public GetAuthorizationResult(bool successful, OAuth2AuthorizationDataStored? authorization = null)
		{
			Successful = successful;
			Authorization = authorization ?? new OAuth2AuthorizationDataStored(string.Empty, string.Empty, null);
		}
	}

	private sealed class ResultCodeInterceptor : Interceptor
	{
		public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.NoContent;

		public override async ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
		{
			await base.AfterHttpRequest(responseMessage, cancellationToken);
			StatusCode = responseMessage.StatusCode;
		}
	}

	private readonly ILogger _logger;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IOAuth2AuthorizationStore _authorizationStore;

	private readonly ICurrentTimeOffset _currentTime;

	private readonly Uri _communicationBaseUrl;

	private readonly Uri _authorizationBaseUrl;

	private readonly string _authorizePath;

	private readonly string _getTokenPath;

	private readonly string _authorizeCallbackUrl;

	private readonly string? _scope;

	private readonly SemaphoreSlim _renewTokensSemaphore = new SemaphoreSlim(1);

	private readonly Authenticator _authenticator;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected IOAuth2ClientInfoProvider ClientInfoProvider { get; }

	protected OAuth2ApiConsumerBase(ILogger logger, IRestClientFactory restClientFactory, IOAuth2AuthorizationStore authorizationStore, ICurrentTimeOffset currentTime, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null)
	{
		_authenticator = new Authenticator(authorizationStore, subscriptionKey);
		_logger = logger;
		_restClientFactory = restClientFactory;
		_authorizationStore = authorizationStore;
		_currentTime = currentTime;
		ClientInfoProvider = clientInfoProvider;
		_communicationBaseUrl = communicationBaseUrl;
		_authorizationBaseUrl = authorizationBaseUrl;
		_authorizePath = authorizePath;
		_getTokenPath = getTokenPath;
		_authorizeCallbackUrl = authorizeCallbackUrl;
		_scope = scope;
	}

	private IRestClient GetClient()
	{
		return _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.BaseUrl = _communicationBaseUrl;
			options.Authenticator = _authenticator;
			options.ThrowOnAnyError = false;
		});
	}

	public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request, RestSharp.Method method, CancellationToken cancellationToken = default(CancellationToken)) where T : notnull
	{
		IRestClient client = GetClient();
		if (NeedToRefreshToken())
		{
			await TryRefreshOAuthToken(cancellationToken);
			return await client.ExecuteAsync<T>(request, method, cancellationToken);
		}
		RestResponse<T> result = await client.ExecuteAsync<T>(request, method, cancellationToken);
		bool flag = result.StatusCode == HttpStatusCode.Unauthorized;
		if (flag)
		{
			flag = await TryRefreshOAuthToken(cancellationToken);
		}
		if (flag)
		{
			return await client.ExecuteAsync<T>(request, method, cancellationToken);
		}
		return result;
	}

	public async Task<Stream?> DownloadStreamAsync(RestRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		ResultCodeInterceptor headerInterceptor = new ResultCodeInterceptor();
		if (request.Interceptors == null)
		{
			request.Interceptors = new List<Interceptor>(1) { headerInterceptor };
		}
		else
		{
			request.Interceptors.Add(headerInterceptor);
		}
		IRestClient client = GetClient();
		if (NeedToRefreshToken())
		{
			await TryRefreshOAuthToken(cancellationToken);
			return await client.DownloadStreamAsync(request, cancellationToken);
		}
		Stream potentiallyUnauthenticatedStream = await client.DownloadStreamAsync(request, cancellationToken);
		bool flag = headerInterceptor.StatusCode == HttpStatusCode.Unauthorized;
		if (flag)
		{
			flag = await TryRefreshOAuthToken(cancellationToken);
		}
		if (flag)
		{
			if (potentiallyUnauthenticatedStream != null)
			{
				await potentiallyUnauthenticatedStream.DisposeAsync();
			}
			return await client.DownloadStreamAsync(request, cancellationToken);
		}
		return potentiallyUnauthenticatedStream;
	}

	public string GetLoginUrl()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["response_type"] = "code",
			["client_id"] = ClientInfoProvider.ClientId,
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
			await TradeAuthorizationCodeForAccessTokensAsync(value.ToString() ?? string.Empty, token);
		}
	}

	private bool NeedToRefreshToken()
	{
		OAuth2AuthorizationDataStored authorization = _authorizationStore.GetAuthorization();
		if (authorization.ExpirationDate.HasValue)
		{
			return authorization.ExpirationDate.Value < _currentTime.UtcNow;
		}
		return false;
	}

	private async Task<bool> TryRefreshOAuthToken(CancellationToken token)
	{
		await _renewTokensSemaphore.WaitAsync(token);
		try
		{
			return await TryRefreshOAuthTokenUnsafeAsync(token);
		}
		finally
		{
			_renewTokensSemaphore.Release();
		}
	}

	private async Task<bool> TryRefreshOAuthTokenUnsafeAsync(CancellationToken token)
	{
		if (_authorizationStore.OverrideOAuthRefresh())
		{
			await _authorizationStore.RefreshAuthorization();
			return true;
		}
		OAuth2AuthorizationDataStored authorization = _authorizationStore.GetAuthorization();
		if (string.IsNullOrWhiteSpace(authorization.RefreshToken))
		{
			await _authorizationStore.RefreshAuthorization();
			return false;
		}
		RestRequest request = new RestRequest(_getTokenPath).AddParameter("grant_type", "refresh_token").AddParameter("refresh_token", authorization.RefreshToken);
		return await GetAndStoreAuthorizationAsync(request, token);
	}

	private async Task<bool> GetAndStoreAuthorizationAsync(RestRequest request, CancellationToken token)
	{
		GetAuthorizationResult getAuthorizationResult = await GetAuthorizationAsync(request, token);
		if (getAuthorizationResult.Successful)
		{
			_authorizationStore.StoreAuthorization(getAuthorizationResult.Authorization);
		}
		return getAuthorizationResult.Successful;
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
			await GetAndStoreAuthorizationAsync(request, token);
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}] Failed to complete authorization with exception:\n{1}", "OAuth2ApiConsumerBase", ex);
		}
		finally
		{
			_renewTokensSemaphore.Release();
		}
	}

	private async Task<GetAuthorizationResult> GetAuthorizationAsync(RestRequest request, CancellationToken token)
	{
		using IRestClient client = _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.BaseUrl = _authorizationBaseUrl;
		});
		request.AddParameter("client_id", ClientInfoProvider.ClientId);
		request.AddParameter("redirect_uri", _authorizeCallbackUrl);
		if (ClientInfoProvider.ClientSecret != null)
		{
			request.AddParameter("client_secret", ClientInfoProvider.ClientSecret);
		}
		RestResponse<OAuth2AuthorizationDataReceived> restResponse = await client.ExecutePostAsync<OAuth2AuthorizationDataReceived>(request, token);
		if (restResponse.IsSuccessful)
		{
			int valueOrDefault = (restResponse.Data?.ExpiresIn).GetValueOrDefault();
			return new GetAuthorizationResult(successful: true, new OAuth2AuthorizationDataStored(restResponse.Data?.AccessToken ?? string.Empty, restResponse.Data?.RefreshToken ?? string.Empty, _currentTime.UtcNow.AddSeconds(valueOrDefault)));
		}
		_logger.Warning("[{0}] Getting Authorization returned status code ({1}) with content: {2}", "OAuth2ApiConsumerBase", restResponse.StatusCode, restResponse.Content);
		switch (restResponse.StatusCode)
		{
		case HttpStatusCode.Unauthorized:
			_logger.Info("[{0}] Refreshing authorization via storage provider", "OAuth2ApiConsumerBase");
			await _authorizationStore.RefreshAuthorization();
			break;
		default:
			_logger.Info("[{0}] Clearing authorization", "OAuth2ApiConsumerBase");
			_authorizationStore.ClearAuthorization();
			break;
		case HttpStatusCode.NotFound:
		case HttpStatusCode.RequestTimeout:
		case HttpStatusCode.ServiceUnavailable:
		case HttpStatusCode.GatewayTimeout:
			break;
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
