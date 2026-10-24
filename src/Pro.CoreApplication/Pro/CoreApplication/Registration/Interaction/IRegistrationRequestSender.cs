using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration.Interaction;

public interface IRegistrationRequestSender
{
	bool Send(Request request);
}
