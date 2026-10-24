using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration.Interaction;

public interface IRegistrationCallbackHandler
{
	bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);
}
