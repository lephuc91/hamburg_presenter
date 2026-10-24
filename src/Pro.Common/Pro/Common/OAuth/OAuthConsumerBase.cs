using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;

namespace Pro.Common.OAuth;

public abstract class OAuthConsumerBase : IConsumer
{
	private const int ExpirationPadding = 300;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly Lock _authorizationLock = new Lock();

	private string? _authorizationURL;

	protected IRestClientFactory RestClientFactory { get; }

	public CredentialState AuthorizationState { get; private set; }

	public bool IsAuthorized
	{
		get
		{
			if (AuthorizationState != CredentialState.AwaitingRefresh)
			{
				return AuthorizationState == CredentialState.Authorized;
			}
			return true;
		}
	}

	public bool IsReady => AuthorizationState == CredentialState.Authorized;

	public string? AccessToken { get; private set; }

	public string? RefreshToken { get; private set; }

	public DateTime? AccessTokenExpiration { get; private set; }

	public DateTime? RefreshTokenExpiration { get; private set; }

	public event Action? AuthorizationStateUpdated;

	protected OAuthConsumerBase(IUiDispatcher uiDispatcher, IRestClientFactory restClientFactory)
	{
		_uiDispatcher = uiDispatcher;
		RestClientFactory = restClientFactory;
	}

	protected abstract string GetAuthorizationURL();

	public string BeginAuthorization()
	{
		using (_authorizationLock.EnterScope())
		{
			if (AuthorizationState != 0 && AuthorizationState != CredentialState.AwaitingAuthorization)
			{
				throw new InvalidOperationException();
			}
			if (AuthorizationState == CredentialState.AwaitingAuthorization)
			{
				if (_authorizationURL == null)
				{
					throw new InvalidOperationException();
				}
				return _authorizationURL;
			}
			_authorizationURL = GetAuthorizationURL();
			AuthorizationState = CredentialState.AwaitingAuthorization;
			return _authorizationURL;
		}
	}

	public abstract bool TryCompleteAuthorization(string url);

	protected void Authorize(string accessToken, string refreshToken, DateTime? accessTokenExpiration, DateTime? refreshTokenExpiration)
	{
		using (_authorizationLock.EnterScope())
		{
			if (AuthorizationState != 0 && AuthorizationState != CredentialState.AwaitingAuthorization && AuthorizationState != CredentialState.AwaitingRefresh)
			{
				throw new InvalidOperationException();
			}
			AccessToken = accessToken;
			RefreshToken = refreshToken;
			AccessTokenExpiration = accessTokenExpiration;
			RefreshTokenExpiration = refreshTokenExpiration;
			AuthorizationState = CredentialState.Authorized;
		}
		this.AuthorizationStateUpdated?.Invoke();
	}

	public void Reauthorize(string accessToken, string refreshToken, DateTime? accessTokenExpiration, DateTime? refreshTokenExpiration)
	{
		using (_authorizationLock.EnterScope())
		{
			if (AuthorizationState != 0)
			{
				throw new InvalidOperationException();
			}
			AccessToken = accessToken;
			RefreshToken = refreshToken;
			AccessTokenExpiration = accessTokenExpiration;
			RefreshTokenExpiration = refreshTokenExpiration;
			AuthorizationState = CredentialState.Authorized;
		}
		this.AuthorizationStateUpdated?.Invoke();
	}

	protected abstract bool RefreshAccessToken();

	public void Deauthorize()
	{
		using (_authorizationLock.EnterScope())
		{
			AccessToken = null;
			RefreshToken = null;
			AccessTokenExpiration = null;
			RefreshTokenExpiration = null;
			AuthorizationState = CredentialState.Unauthorized;
		}
		this.AuthorizationStateUpdated?.Invoke();
	}

	protected abstract Request<T> PrepareRequest<T>(string resource) where T : class?;

	private bool ValidateAccessToken()
	{
		if (!AccessTokenExpiration.HasValue)
		{
			return true;
		}
		DateTime value = DateTime.Now.AddSeconds(300.0);
		DateTime? accessTokenExpiration = AccessTokenExpiration;
		if (value >= accessTokenExpiration)
		{
			using (_authorizationLock.EnterScope())
			{
				value = DateTime.Now.AddSeconds(300.0);
				accessTokenExpiration = AccessTokenExpiration;
				if (value >= accessTokenExpiration)
				{
					AuthorizationState = CredentialState.AwaitingRefresh;
					return RefreshAccessToken();
				}
			}
		}
		else if (AuthorizationState != CredentialState.Authorized && AuthorizationState != CredentialState.AwaitingRefresh)
		{
			throw new InvalidOperationException();
		}
		return true;
	}

	private void SetupRequest<T>(Request<T> request, Method method, Dictionary<string, string>? headers) where T : class?
	{
		request.Method = method;
		if (headers == null || !headers.Any())
		{
			return;
		}
		if (request.Headers == null)
		{
			request.Headers = new Dictionary<string, string>();
		}
		foreach (KeyValuePair<string, string> header in request.Headers)
		{
			if (!request.Headers.ContainsKey(header.Key))
			{
				request.Headers.Add(header.Key, header.Value);
			}
		}
	}

	protected void SendRequestAsync(string resource, Method method = Method.GET, Dictionary<string, string>? headers = null, object? body = null, Action<Response<dynamic>>? responseHandler = null)
	{
		OnSendRequestAsync(resource, method, headers, body, responseHandler);
	}

	protected void SendRequestAsync<T>(string resource, Method method = Method.GET, Dictionary<string, string>? headers = null, T? body = null, Action<Response<dynamic>>? responseHandler = null) where T : class
	{
		OnSendRequestAsync(resource, method, headers, body, responseHandler);
	}

	private void OnSendRequestAsync<I, O>(string resource, Method method, Dictionary<string, string>? headers, I body, Action<Response<O>>? responseHandler) where I : class? where O : class
	{
		if (!ValidateAccessToken())
		{
			responseHandler?.Invoke(GetFailedAccessResponse<O>());
			return;
		}
		Request<I> request = PrepareRequest<I>(resource);
		SetupRequest(request, method, headers);
		request.Body = body;
		SendRequestAsync(request, responseHandler).ExecuteAsync();
	}

	private async Task SendRequestAsync<I, O>(Request<I> request, Action<Response<O>>? responseHandler) where I : class? where O : class
	{
		Response<O> response = await new Client(RestClientFactory).SendRequestAsync<I, O>(request);
		Task task = _uiDispatcher.InvokeAsync(delegate
		{
			responseHandler?.Invoke(response);
		});
		if (task != null)
		{
			await task;
		}
	}

	private Response<O> GetFailedAccessResponse<O>() where O : class
	{
		return new Response<O>(isSuccessful: false, 401, null, null);
	}
}
