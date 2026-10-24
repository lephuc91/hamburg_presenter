using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingShellNavigator
{
	void HandleNavigationIntent(OnboardingIntent intent, ICloseable closeable);
}
