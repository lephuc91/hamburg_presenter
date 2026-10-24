using System.ComponentModel;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class LegacyTrialProPresenterSectionVM : LegacyProPresenterSectionVM, ILegacyTrialProPresenterSectionVM, ILegacyProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	public override string LicenseExpiration { get; }

	public LegacyTrialProPresenterSectionVM(IRegistrationOperationFactory registrationOperationFactory, CodeState state, IRegistrationUnlockCodeVM registrationUnlockCodeVM)
		: base(registrationOperationFactory, state, registrationUnlockCodeVM)
	{
		LicenseExpiration = state.ExpirationDate.ToLongDateString();
	}
}
