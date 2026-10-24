using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration;

public interface IRegistrationSubpageVMFactory
{
	IFooterVM GetFooter_SignedIn(global::ProPresenter.DO.Registration.State.Subscription.SubscribedState state, RegistrationState registrationState, bool isProPresenterRegisteredWithSubscription);

	IFooterVM GetFooter_SignedOut(bool isRegistered);

	IHeaderVM GetHeader_RegisteredWithCode();

	IHeaderVM GetHeader_SignedIn(global::ProPresenter.DO.Registration.State.Subscription.SubscribedState state, IProvideOrganizationIcon organizationIconProvider);

	IHeaderVM GetHeader_SignedOut();

	IHeaderVM GetHeader_Undetermined();

	IProContentSectionVM GetProContent(ProContentRegistrationState state, bool isRegistered);

	IProPresenterSectionVM GetProPresenter_Unregistered(bool isSubscribed);

	IProPresenterSectionVM GetProPresenter_RegistrationCode(CodeState state);

	IProPresenterSectionVM GetProPresenter_Subscribed(global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState state);

	IProPresenterSectionVM GetProPresenter_Undetermined();

	IFooterVM GetFooter_Undetermined();
}
