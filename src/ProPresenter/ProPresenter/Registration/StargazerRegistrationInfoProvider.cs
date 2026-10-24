using Pro.Reporting;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;

namespace ProPresenter.Registration;

public class StargazerRegistrationInfoProvider : IRegistrationInformationProvider
{
	private readonly IRegistrationStateProvider _registrationStateProvider;

	public StargazerRegistrationInfoProvider(IRegistrationStateProvider registrationStateProvider)
	{
		_registrationStateProvider = registrationStateProvider;
	}

	public RegistrationInfo Get()
	{
		IRegistrationState proPresenter = _registrationStateProvider.Registration.ProPresenter;
		HardwareInfo hardwareInformation = _registrationStateProvider.HardwareInformation;
		return new RegistrationInfo(proPresenter.DeviceName, (proPresenter as IRegisteredState)?.ActivationKey ?? string.Empty, hardwareInformation.HardwareFingerprint, hardwareInformation.HardwareIdentifier, GetRegistrationName(_registrationStateProvider.Registration), GetRegistrationCode(proPresenter));
	}

	private static string GetRegistrationName(RegistrationState registrationState)
	{
		if (registrationState.SubscriptionState is ProPresenter.DO.Registration.State.Subscription.SubscribedState subscribedState)
		{
			return subscribedState.OrganizationName;
		}
		if (registrationState.ProPresenter is CodeState codeState)
		{
			return codeState.UserName;
		}
		return string.Empty;
	}

	private static string GetRegistrationCode(IRegistrationState proPresenter)
	{
		if (proPresenter is CodeState codeState)
		{
			return codeState.RegistrationKey;
		}
		return string.Empty;
	}
}
