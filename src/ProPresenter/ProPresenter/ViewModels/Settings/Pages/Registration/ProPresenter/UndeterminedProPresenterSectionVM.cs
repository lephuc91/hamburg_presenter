using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class UndeterminedProPresenterSectionVM : ObservableObject, IUndeterminedProPresenterSectionVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	public IRegistrationUnlockCodeVM? UnlockCodeVM => null;
}
