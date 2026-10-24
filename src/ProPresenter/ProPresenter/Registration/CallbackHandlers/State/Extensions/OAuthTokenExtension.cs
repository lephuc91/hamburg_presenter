using System;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions;

public static class OAuthTokenExtension
{
	public static OAuthToken? ToOAuthToken(this TokenMetadata token)
	{
		if (token != null)
		{
			return new OAuthToken(token.AccessToken, token.RefreshToken, DateTimeOffset.FromUnixTimeSeconds(token.ExpiresAt));
		}
		return null;
	}
}
