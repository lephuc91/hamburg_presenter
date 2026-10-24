using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.Time;

namespace Pro.Common.AuthenticatingApiConsumer.OAuth2;

public class OAuth2ApiConsumerWithPkceFlow : OAuth2ApiConsumerBase
{
	private readonly RandomNumberGenerator _randomNumberGenerator = RandomNumberGenerator.Create();

	private readonly ILogger _logger;

	private string? _codeVerifier;

	public OAuth2ApiConsumerWithPkceFlow(ILogger logger, IRestClientFactory restClientFactory, IOAuth2AuthorizationStore authorizationStore, ICurrentTimeOffset currentTime, IOAuth2ClientInfoProvider clientInfoProvider, Uri communicationBaseUrl, Uri authorizationBaseUrl, string authorizePath, string getTokenPath, string authorizeCallbackUrl, string? subscriptionKey = null, string? scope = null)
		: base(logger, restClientFactory, authorizationStore, currentTime, clientInfoProvider, communicationBaseUrl, authorizationBaseUrl, authorizePath, getTokenPath, authorizeCallbackUrl, subscriptionKey, scope)
	{
		_logger = logger;
	}

	protected override IEnumerable<KeyValuePair<string, string>> GetAuthorizationCodeTradeParameters()
	{
		string text = Interlocked.Exchange(ref _codeVerifier, null);
		return new global::_003C_003Ez__ReadOnlySingleElementList<KeyValuePair<string, string>>(new KeyValuePair<string, string>("code_verifier", text ?? string.Empty));
	}

	protected override void AddAuthorizationBeginQueryParameters(IDictionary<string, string> parameters)
	{
		if (Interlocked.CompareExchange(ref _codeVerifier, CreateCodeVerifier(), null) != null)
		{
			_logger.Warning("[{0}] Code verifier was already set. This is unexpected and may indicate that we were somehow able to request authorization twice", "OAuth2ApiConsumerWithPkceFlow");
		}
		string codeChallenge = GetCodeChallenge(_codeVerifier);
		parameters["code_challenge"] = codeChallenge;
		parameters["code_challenge_method"] = "S256";
	}

	private string CreateCodeVerifier()
	{
		byte[] array = new byte[32];
		_randomNumberGenerator.GetBytes(array);
		return ConvertToSanitizedBase64String(array);
	}

	private static string GetCodeChallenge(string verifier)
	{
		return ConvertToSanitizedBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(verifier)));
	}

	private static string ConvertToSanitizedBase64String(byte[] bytes)
	{
		return Convert.ToBase64String(bytes).Replace("+", "-").Replace("/", "_")
			.Replace("=", "");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_randomNumberGenerator.Dispose();
		}
		base.Dispose(disposing);
	}
}
