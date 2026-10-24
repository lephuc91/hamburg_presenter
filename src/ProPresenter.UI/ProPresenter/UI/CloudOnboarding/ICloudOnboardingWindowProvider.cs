using System.Windows;

namespace ProPresenter.UI.CloudOnboarding;

public interface ICloudOnboardingWindowProvider
{
	void Show(Window? owner = null);
}
