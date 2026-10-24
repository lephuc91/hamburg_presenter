namespace ProPresenter.Registration.CallbackHandlers.PopUpAlert;

public interface IPopUpAlertFactory
{
	void ShowSeatActivated(string organizationName);

	void ShowNoLicenseActivated(string organizationName);

	void ShowFullySignedOut();

	void ShowLegacyLicenseProContentActivated(string organizationName);

	void ShowNoSeatActivated(string organizationName);

	void ShowFirstLaunchLegacyLicense();

	void ShowFirstLaunchSignedInNoSubscriptionNoLicense();

	void ShowFirstLaunchSignedInNoSubscriptionLegacyLicense();
}
