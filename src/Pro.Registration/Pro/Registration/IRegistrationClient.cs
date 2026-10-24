using Pro.Registration.Interaction;

namespace Pro.Registration;

public interface IRegistrationClient : IRegistrationRequestSender
{
	void Start();

	void Add(IRegistrationOperation operation);

	void Add(IRegistrationCallbackHandler callbackHandler);
}
