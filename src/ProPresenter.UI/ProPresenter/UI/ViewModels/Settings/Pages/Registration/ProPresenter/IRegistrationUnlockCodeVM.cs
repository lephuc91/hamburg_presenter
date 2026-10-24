using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface IRegistrationUnlockCodeVM : INotifyPropertyChanged
{
	string RegistrationName { get; set; }

	string UnlockCode { get; set; }

	string DeviceName { get; set; }

	bool IsVisible { get; set; }

	IAsyncRelayCommand RegisterCommand { get; }

	IRelayCommand CancelCommand { get; }
}
