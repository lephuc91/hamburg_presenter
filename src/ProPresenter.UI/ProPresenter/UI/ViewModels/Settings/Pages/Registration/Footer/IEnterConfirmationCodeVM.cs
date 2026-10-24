using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

public interface IEnterConfirmationCodeVM : INotifyPropertyChanged
{
	bool IsVisible { get; set; }

	string ConfirmationCode { get; set; }

	IRelayCommand CancelCommand { get; }

	IAsyncRelayCommand SubmitCommand { get; }
}
