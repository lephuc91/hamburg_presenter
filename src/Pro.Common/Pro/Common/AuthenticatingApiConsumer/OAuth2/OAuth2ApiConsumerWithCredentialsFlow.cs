using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.Time;

namespace Pro.Common.AuthenticatingApiConsumer.OAuth2;

public class OAuth2ApiConsumerWithCredentialsFlow : OAuth2ApiConsumerBase
{
	public OAuth2ApiConsumerWithCredentialsFlow(ILogger logger, IRestClientFactory restClientFactory, IOAuth2AuthorizationStore authorizationStore, ICurrentTimeOffset currentTime, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null)
		: base(logger, restClientFactory, authorizationStore, currentTime, clientInfoProvider, communicationBaseUrl, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, subscriptionKey, scope)
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
