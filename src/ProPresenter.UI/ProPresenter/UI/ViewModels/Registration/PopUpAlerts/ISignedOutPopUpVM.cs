using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public interface ISignedOutPopUpVM
{
	IRelayCommand HelpCommand { get; }

	IRelayCommand SignInCommand { get; }

	IRelayCommand SignUpCommand { get; }
}
