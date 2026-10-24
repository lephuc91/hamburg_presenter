using System;

namespace Pro.Common.OAuth.Authenticator;

public interface IAuthenticatorFactory
{
	[Obsolete("Please use IAuthenticatingApiConsumerFactory instead")]
	IAuthenticator CreateOAuth2Authenticator(IOAuth2AuthorizationStore authorizationStore, string clientId, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string clientSecret, string? subscriptionKey = null, string? scope = null);
}
