using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Time;

namespace Pro.Common.OAuth.Authenticator;

public class OAuth2Authenticator : OAuth2AuthenticatorBase
{
	public OAuth2Authenticator(ILogger logger, IRestClientFactory restClientFactory, IOAuth2AuthorizationStore authorizationStore, ICurrentTimeOffset currentTime, string clientId, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string clientSecret, string? subscriptionKey = null, string? scope = null)
		: base(logger, restClientFactory, authorizationStore, currentTime, clientId, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, clientSecret, subscriptionKey, scope)
	{
	}

	protected override IEnumerable<KeyValuePair<string, string>> GetAuthorizationCodeTradeParameters()
	{
		return Enumerable.Empty<KeyValuePair<string, string>>();
	}

	protected override void AddAuthorizationBeginQueryParameters(IDictionary<string, string> parameters)
	{
	}
}
