using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.UI.Registration.PopUpAlerts;
using ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

namespace ProPresenter.Registration.CallbackHandlers.PopUpAlert;

public class PopUpAlertFactory : IPopUpAlertFactory
{
	private readonly IUiDispatcher _uiDispatcher;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	public PopUpAlertFactory(IUiDispatcher uiDispatcher, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_uiDispatcher = uiDispatcher;
		_hyperlinkService = hyperlinkService;
		_registrationWebResourceService = registrationWebResourceService;
	}

	public void ShowSeatActivated(string organizationName)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			SeatActivated seatActivated = new SeatActivated();
			seatActivated.DataContext = new SubscribedSuccessfullyPopUpVM(organizationName);
			seatActivated.ShowDialog();
		});
	}

	public void ShowLegacyLicenseProContentActivated(string organizationName)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			LegacyLicenseProContentActivated legacyLicenseProContentActivated = new LegacyLicenseProContentActivated();
			legacyLicenseProContentActivated.DataContext = new SubscribedSuccessfullyPopUpVM(organizationName);
			legacyLicenseProContentActivated.ShowDialog();
		});
	}

	public void ShowNoLicenseActivated(string organizationName)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			NoLicenseActivated noLicenseActivated = new NoLicenseActivated();
			noLicenseActivated.DataContext = new SubscribedSuccessfullyPopUpVM(organizationName);
			noLicenseActivated.ShowDialog();
		});
	}

	public void ShowNoSeatActivated(string organizationName)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			NoSeatActivated noSeatActivated = new NoSeatActivated();
			noSeatActivated.DataContext = new SubscribedSuccessfullyPopUpVM(organizationName);
			noSeatActivated.ShowDialog();
		});
	}

	public void ShowFullySignedOut()
	{
		_uiDispatcher.Invoke(delegate
		{
			FullySignedOut fullySignedOut = new FullySignedOut();
			fullySignedOut.DataContext = new FullySignedOutPopUpVM(_registrationWebResourceService, _hyperlinkService);
			fullySignedOut.ShowDialog();
		});
	}

	public void ShowFirstLaunchLegacyLicense()
	{
		_uiDispatcher.Invoke(delegate
		{
			FirstLaunchLegacyLicense firstLaunchLegacyLicense = new FirstLaunchLegacyLicense();
			firstLaunchLegacyLicense.DataContext = new RegisteredWithLegacyLicensePopUpVM(_registrationWebResourceService, _hyperlinkService, isSignedIn: false);
			firstLaunchLegacyLicense.ShowDialog();
		});
	}

	public void ShowFirstLaunchSignedInNoSubscriptionNoLicense()
	{
		_uiDispatcher.Invoke(delegate
		{
			FirstLaunchSignedInNoSubscriptionNoLicense firstLaunchSignedInNoSubscriptionNoLicense = new FirstLaunchSignedInNoSubscriptionNoLicense();
			firstLaunchSignedInNoSubscriptionNoLicense.DataContext = new SignedInNotSubscribedPopUpVM(_registrationWebResourceService, _hyperlinkService);
			firstLaunchSignedInNoSubscriptionNoLicense.ShowDialog();
		});
	}

	public void ShowFirstLaunchSignedInNoSubscriptionLegacyLicense()
	{
		_uiDispatcher.Invoke(delegate
		{
			FirstLaunchSignedInNoSubscriptionLegacyLicense firstLaunchSignedInNoSubscriptionLegacyLicense = new FirstLaunchSignedInNoSubscriptionLegacyLicense();
			firstLaunchSignedInNoSubscriptionLegacyLicense.DataContext = new RegisteredWithLegacyLicensePopUpVM(_registrationWebResourceService, _hyperlinkService, isSignedIn: true);
			firstLaunchSignedInNoSubscriptionLegacyLicense.ShowDialog();
		});
	}
}
