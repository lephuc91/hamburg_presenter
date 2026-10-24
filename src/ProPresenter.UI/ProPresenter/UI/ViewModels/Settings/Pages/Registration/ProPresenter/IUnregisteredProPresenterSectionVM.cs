using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface IUnregisteredProPresenterSectionVM : IProPresenterSectionVM, INotifyPropertyChanged
{
	IRelayCommand ActivateCommand { get; }
}
