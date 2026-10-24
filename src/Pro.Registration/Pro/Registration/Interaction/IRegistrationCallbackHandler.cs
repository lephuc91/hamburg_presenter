using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.Registration.Interaction;

public interface IRegistrationCallbackHandler
{
	bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);
}
