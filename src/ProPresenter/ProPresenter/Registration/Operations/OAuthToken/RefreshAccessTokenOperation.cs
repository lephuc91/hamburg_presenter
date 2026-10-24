using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.OAuthToken;

public class RefreshAccessTokenOperation : AwaitableRegistrationOperation
{
	public override Request Start()
	{
		return new Request
		{
			RefreshAccessToken = new RefreshAccessToken()
		};
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete);
	}
}
