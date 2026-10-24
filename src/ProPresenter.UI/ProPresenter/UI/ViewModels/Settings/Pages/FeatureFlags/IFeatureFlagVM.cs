using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings.Pages.FeatureFlags;

public interface IFeatureFlagVM : INotifyPropertyChanged
{
	string Name { get; }

	string Description { get; }

	bool IsEnabled { get; set; }

	bool CanSetFlag { get; }

	void ResetToDefault();
}
