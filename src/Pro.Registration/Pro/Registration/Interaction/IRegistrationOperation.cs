using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.Registration.Interaction;

public interface IRegistrationOperation
{
	Request Start();

	RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);
}
