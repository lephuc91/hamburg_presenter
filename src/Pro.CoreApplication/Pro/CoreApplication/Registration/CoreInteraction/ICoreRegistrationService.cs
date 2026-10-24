using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration.CoreInteraction;

public interface ICoreRegistrationService
{
	void Send(Request request);
}
