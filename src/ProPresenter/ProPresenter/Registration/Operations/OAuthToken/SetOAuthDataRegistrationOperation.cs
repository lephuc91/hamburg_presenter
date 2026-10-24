using System;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.OAuthToken;

public class SetOAuthDataRegistrationOperation : FireAndForgetRegistrationOperation
{
	private readonly string _accessToken;

	private readonly string _refreshToken;

	private readonly DateTimeOffset _expiresAt;

	public SetOAuthDataRegistrationOperation(string accessToken, string refreshToken, DateTimeOffset expiresAt)
	{
		_accessToken = accessToken;
		_refreshToken = refreshToken;
		_expiresAt = expiresAt;
	}

	public override Request Start()
	{
		return new Request
		{
			UpdateToken = new UpdateToken
			{
				TokenMetadata = new TokenMetadata
				{
					AccessToken = _accessToken,
					RefreshToken = _refreshToken,
					ExpiresAt = _expiresAt.ToUnixTimeSeconds()
				}
			}
		};
	}
}
