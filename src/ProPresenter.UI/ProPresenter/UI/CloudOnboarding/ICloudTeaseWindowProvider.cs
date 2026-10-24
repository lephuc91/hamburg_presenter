using System.Windows;

namespace ProPresenter.UI.CloudOnboarding;

public interface ICloudTeaseWindowProvider
{
	void Show(Window? owner = null);
}
