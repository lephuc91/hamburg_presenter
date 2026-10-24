using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.Registration;

public class UnregisterRegistrationOperation : AwaitableRegistrationOperation
{
	public override Request Start()
	{
		return new Request
		{
			Unregister = new Unregister()
		};
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete);
	}
}
