using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration.Interaction;

public interface IRegistrationOperation
{
	Request Start();

	RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);
}
