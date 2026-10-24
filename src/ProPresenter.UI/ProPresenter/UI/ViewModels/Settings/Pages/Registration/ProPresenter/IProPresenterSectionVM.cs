using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface IProPresenterSectionVM : INotifyPropertyChanged
{
	IRegistrationUnlockCodeVM? UnlockCodeVM { get; }
}
