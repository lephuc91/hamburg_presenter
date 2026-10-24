namespace CoreRegistrationClient;

public class RegistrationInteractorFactory : IRegistrationInteractorFactory
{
	public virtual IRegistrationInteractor Create(IRegistrationInteractorCallbackReceiver callbacks)
	{
		return new RegistrationInteractor(callbacks);
	}
}
