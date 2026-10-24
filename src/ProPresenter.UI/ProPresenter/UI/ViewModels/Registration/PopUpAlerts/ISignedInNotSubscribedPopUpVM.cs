using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public interface ISignedInNotSubscribedPopUpVM
{
	IRelayCommand HelpCommand { get; }

	IRelayCommand SubscribeCommand { get; }
}
