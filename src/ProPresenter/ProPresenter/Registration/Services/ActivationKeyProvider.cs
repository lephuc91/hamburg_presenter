using Pro.Web.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;

namespace ProPresenter.Registration.Services;

public class ActivationKeyProvider : IActivationKeyProvider
{
	private readonly IRegistrationStateProvider _registrationStateProvider;

	public string ActivationKey => (_registrationStateProvider.Registration.ProPresenter as IRegisteredState)?.ActivationKey ?? string.Empty;

	public ActivationKeyProvider(IRegistrationStateProvider registrationStateProvider)
	{
		_registrationStateProvider = registrationStateProvider;
	}
}
