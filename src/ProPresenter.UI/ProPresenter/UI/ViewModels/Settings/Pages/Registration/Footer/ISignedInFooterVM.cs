using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

public interface ISignedInFooterVM : IFooterVM, INotifyPropertyChanged
{
	IAsyncRelayCommand SignOutCommand { get; }

	IRelayCommand ManageAccountCommand { get; }
}
