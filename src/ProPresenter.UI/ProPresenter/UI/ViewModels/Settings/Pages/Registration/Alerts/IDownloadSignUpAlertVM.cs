using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Alerts;

public interface IDownloadSignUpAlertVM
{
	IRelayCommand SignUpCommand { get; }

	string SignInUri { get; }
}
