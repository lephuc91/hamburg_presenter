using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations;

public abstract class FireAndForgetRegistrationOperation : IRegistrationOperation
{
	public RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, OperationCompleted: true);
	}

	public abstract Request Start();
}
