using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.Registration.UserInteraction;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.ViewModels.Settings.Pages.Registration.Footer;
using ProPresenter.ViewModels.Settings.Pages.Registration.Header;
using ProPresenter.ViewModels.Settings.Pages.Registration.ProContent;
using ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration;

public class RegistrationSubpageVMFactory : IRegistrationSubpageVMFactory
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IRegistrationUnlockCodeVM _registrationUnlockCodeVM;

	private readonly IRegistrationUserDialogService _registrationUserDialogService;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	public RegistrationSubpageVMFactory(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IRegistrationOperationFactory registrationOperationFactory, IRegistrationUnlockCodeVM registrationUnlockCodeVM, IRegistrationUserDialogService registrationUserDialogService, IRegistrationStateProvider registrationStateProvider)
	{
		_hyperlinkService = hyperlinkService;
		_registrationWebResourceService = registrationWebResourceService;
		_registrationOperationFactory = registrationOperationFactory;
		_registrationUnlockCodeVM = registrationUnlockCodeVM;
		_registrationUserDialogService = registrationUserDialogService;
		_registrationStateProvider = registrationStateProvider;
	}

	public IFooterVM GetFooter_SignedIn(global::ProPresenter.DO.Registration.State.Subscription.SubscribedState state, RegistrationState registrationState, bool isProPresenterRegisteredWithSubscription)
	{
		return new SignedInFooterVM(_registrationOperationFactory, _hyperlinkService, _registrationWebResourceService, _registrationUserDialogService, state, registrationState, isProPresenterRegisteredWithSubscription);
	}

	public IFooterVM GetFooter_SignedOut(bool isRegistered)
	{
		return new SignedOutFooterVM(_hyperlinkService, _registrationWebResourceService, new EnterConfirmationCodeVM(_registrationOperationFactory), isRegistered);
	}

	public IFooterVM GetFooter_Undetermined()
	{
		return new UndeterminedFooterVM(_hyperlinkService, _registrationWebResourceService);
	}

	public IHeaderVM GetHeader_RegisteredWithCode()
	{
		return new RegisteredWithCodeHeaderVM(_hyperlinkService, _registrationWebResourceService);
	}

	public IHeaderVM GetHeader_SignedIn(global::ProPresenter.DO.Registration.State.Subscription.SubscribedState state, IProvideOrganizationIcon organizationIconProvider)
	{
		return new SignedInHeaderVM(state, _registrationStateProvider, organizationIconProvider);
	}

	public IHeaderVM GetHeader_SignedOut()
	{
		return new SignedOutHeaderVM(_hyperlinkService, _registrationWebResourceService);
	}

	public IHeaderVM GetHeader_Undetermined()
	{
		return new UndeterminedHeaderVM();
	}

	public IProContentSectionVM GetProContent(ProContentRegistrationState state, bool isRegistered)
	{
		return new ProContentSectionVM(state, isRegistered, _hyperlinkService, _registrationWebResourceService);
	}

	public IProPresenterSectionVM GetProPresenter_RegistrationCode(CodeState state)
	{
		return state.LicenseType switch
		{
			LicenseType.Trial => new LegacyTrialProPresenterSectionVM(_registrationOperationFactory, state, _registrationUnlockCodeVM), 
			LicenseType.Rental => new LegacyRentalProPresenterSectionVM(_registrationOperationFactory, _hyperlinkService, _registrationWebResourceService, state, _registrationUnlockCodeVM), 
			_ => new ProPresenterPlusProPresenterSectionVM(_registrationOperationFactory, state, _registrationUnlockCodeVM, _hyperlinkService, _registrationWebResourceService), 
		};
	}

	public IProPresenterSectionVM GetProPresenter_Subscribed(global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState state)
	{
		if (state.IsTryoutLicense)
		{
			return new TryoutLicenseProPresenterSectionVM(state, _registrationOperationFactory, _hyperlinkService, _registrationWebResourceService);
		}
		return new SubscribedProPresenterSectionVM(_registrationOperationFactory, _hyperlinkService, _registrationWebResourceService, state);
	}

	public IProPresenterSectionVM GetProPresenter_Unregistered(bool isSubscribed)
	{
		return new UnregisteredProPresenterSectionVM(_hyperlinkService, _registrationWebResourceService, _registrationUnlockCodeVM, isSubscribed);
	}

	public IProPresenterSectionVM GetProPresenter_Undetermined()
	{
		return new UndeterminedProPresenterSectionVM();
	}
}
