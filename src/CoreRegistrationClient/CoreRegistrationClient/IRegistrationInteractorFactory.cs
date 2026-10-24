namespace CoreRegistrationClient;

public interface IRegistrationInteractorFactory
{
	IRegistrationInteractor Create(IRegistrationInteractorCallbackReceiver callbacks);
}
