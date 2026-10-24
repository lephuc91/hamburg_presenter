using CoreApplication.Registration;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration.CoreInteraction;

public class CoreRegistrationService : global::CoreApplication.Registration.CoreRegistrationService, ICoreRegistrationService
{
	private readonly nint _registrationService;

	public CoreRegistrationService(nint registrationService)
	{
		_registrationService = registrationService;
	}

	public void Send(Request request)
	{
		byte[] @params = request.ToByteArray();
		SendMessage(_registrationService, @params);
	}
}
