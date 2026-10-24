using System;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Time;

namespace Pro.Common.OAuth.Authenticator;

public class AuthenticatorFactory : IAuthenticatorFactory
{
	private readonly IRestClientFactory _restClientFactory;

	private readonly ICurrentTimeOffset _currentTimeOffset;

	private readonly ILogger _logger;

	public AuthenticatorFactory(IRestClientFactory restClientFactory, ICurrentTimeOffset currentTimeOffset, ILogger logger)
	{
		_restClientFactory = restClientFactory;
		_currentTimeOffset = currentTimeOffset;
		_logger = logger;
	}

	[Obsolete("Please use IAuthenticatingApiConsumerFactory instead")]
	public IAuthenticator CreateOAuth2Authenticator(IOAuth2AuthorizationStore authorizationStore, string clientId, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string clientSecret, string? subscriptionKey = null, string? scope = null)
	{
		return new OAuth2Authenticator(_logger, _restClientFactory, authorizationStore, _currentTimeOffset, clientId, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, clientSecret, subscriptionKey, scope);
	}
}
