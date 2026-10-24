using Pro.CoreApplication.Registration.Interaction;

namespace Pro.CoreApplication.Registration;

public interface IRegistrationClient
{
	void Add(IRegistrationOperation operation);
}
