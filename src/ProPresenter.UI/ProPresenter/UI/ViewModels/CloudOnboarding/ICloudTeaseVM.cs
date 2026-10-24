using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudTeaseVM
{
	bool ShouldShowCloudTease { get; }

	IRelayCommand LearnMoreCommand { get; }

	IRelayCommand<ICloseable?> SignUpForEarlyAccessCommand { get; }

	IRelayCommand<ICloseable?> RemindMeLaterCommand { get; }

	void OnWindowClosed();
}
