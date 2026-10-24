using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Settings;

namespace ProPresenter.Registration.CallbackHandlers;

public class ProContentTokenReader : IRegistrationCallbackHandler
{
	private readonly IApp _app;

	public ProContentTokenReader(IApp app)
	{
		_app = app;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.ReadOldToken)
		{
			OldTokenData oldTokenData = new OldTokenData
			{
				Status = ReadTokenStatus.TokenNotPresent
			};
			if (_app.ProContentAccessTokenExpiration.HasValue && !string.IsNullOrEmpty(_app.ProContentRefreshToken))
			{
				oldTokenData.Status = ReadTokenStatus.ReadTokenSuccess;
				oldTokenData.Token = new TokenMetadata
				{
					AccessToken = (_app.ProContentAccessToken ?? string.Empty),
					RefreshToken = _app.ProContentRefreshToken,
					ExpiresAt = _app.ProContentAccessTokenExpiration.Value.ToUnixTimeSeconds()
				};
			}
			requestSender.Send(new Request
			{
				OldTokenData = oldTokenData
			});
			return true;
		}
		return false;
	}
}
