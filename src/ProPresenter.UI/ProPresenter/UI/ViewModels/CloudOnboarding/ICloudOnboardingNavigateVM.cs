using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingNavigateVM : INotifyPropertyChanged
{
	IRelayCommand<ICloseable> ContinueCommand { get; }

	IRelayCommand<ICloseable> BackCommand { get; }
}
