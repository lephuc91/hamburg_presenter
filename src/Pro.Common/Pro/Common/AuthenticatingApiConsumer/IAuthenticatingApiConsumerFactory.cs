using System;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.OAuth.Authenticator;

namespace Pro.Common.AuthenticatingApiConsumer;

public interface IAuthenticatingApiConsumerFactory
{
	IAuthenticatingApiConsumer CreateOAuth2ConsumerWithPkceFlow(IOAuth2AuthorizationStore authorizationStore, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null);

	IAuthenticatingApiConsumer CreateOAuth2ConsumerWithCredentialsFlow(IOAuth2AuthorizationStore authorizationStore, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null);
}
