using System;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.Time;

namespace Pro.Common.AuthenticatingApiConsumer;

public class AuthenticatingApiConsumerFactory : IAuthenticatingApiConsumerFactory
{
	private readonly IRestClientFactory _restClientFactory;

	private readonly ICurrentTimeOffset _currentTimeOffset;

	private readonly ILogger _logger;

	public AuthenticatingApiConsumerFactory(IRestClientFactory restClientFactory, ICurrentTimeOffset currentTimeOffset, ILogger logger)
	{
		_restClientFactory = restClientFactory;
		_currentTimeOffset = currentTimeOffset;
		_logger = logger;
	}

	public IAuthenticatingApiConsumer CreateOAuth2ConsumerWithPkceFlow(IOAuth2AuthorizationStore authorizationStore, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null)
	{
		return new OAuth2ApiConsumerWithPkceFlow(_logger, _restClientFactory, authorizationStore, _currentTimeOffset, clientInfoProvider, communicationBaseUrl, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, subscriptionKey, scope);
	}

	public IAuthenticatingApiConsumer CreateOAuth2ConsumerWithCredentialsFlow(IOAuth2AuthorizationStore authorizationStore, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null)
	{
		return new OAuth2ApiConsumerWithCredentialsFlow(_logger, _restClientFactory, authorizationStore, _currentTimeOffset, clientInfoProvider, communicationBaseUrl, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, subscriptionKey, scope);
	}
}
