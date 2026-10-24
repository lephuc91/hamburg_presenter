using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IScreenSetupVM : INotifyPropertyChanged
{
	IScreenConfigVM ScreenConfigVM { get; }

	ISimpleScreenConfiguration AudienceScreen { get; }

	ISimpleScreenConfiguration StageScreen { get; }

	IRelayCommand OpenScreenConfigurationHelpCommand { get; }
}
