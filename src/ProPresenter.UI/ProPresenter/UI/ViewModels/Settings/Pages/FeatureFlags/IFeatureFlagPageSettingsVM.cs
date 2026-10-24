using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.FeatureFlags;

public interface IFeatureFlagPageSettingsVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	IReadOnlyList<IFeatureFlagVM> FeatureFlags { get; }

	string WarningLabelText { get; }

	ICommand ResetToDefaultsCommand { get; }
}
