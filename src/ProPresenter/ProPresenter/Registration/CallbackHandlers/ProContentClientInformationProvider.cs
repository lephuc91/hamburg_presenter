using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.CallbackHandlers;

public class ProContentClientInformationProvider : IRegistrationCallbackHandler, IOAuth2ClientInfoProvider
{
	public string ClientId { get; private set; } = "5";

	public string? ClientSecret { get; private set; }

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.SetClientInfo)
		{
			ClientId = responseCallback.SetClientInfo.ClientId.ToString();
			ClientSecret = responseCallback.SetClientInfo.ClientSecret;
			return true;
		}
		return false;
	}
}
