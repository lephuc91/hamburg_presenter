using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.State;

public class RefreshBibleStateRegistrationOperation : AwaitableRegistrationOperation
{
	public override Request Start()
	{
		return new Request
		{
			GetBibles = new GetBibles()
		};
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete);
	}
}
