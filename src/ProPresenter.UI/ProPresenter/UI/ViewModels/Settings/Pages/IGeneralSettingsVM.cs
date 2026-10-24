using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public interface IGeneralSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool EnableHoW { get; set; }

	bool EnableCrashReporting { get; set; }

	bool EnableAnalytics { get; set; }

	BitmapSource? LogoImageSource { get; }

	CultureInfo SelectedLanguage { get; set; }

	IReadOnlyCollection<CultureInfo> AvailableLanguages { get; }

	ICommand AddLogoCommand { get; }

	ICommand RemoveLogoCommand { get; }

	ICommand OpenFileLocationCommand { get; }

	ICopyrightSettingsVM CopyrightSettingsVM { get; }

	bool ShouldShowCloudTease { get; }

	ICommand LearnMoreCloudCommand { get; }

	ICommand SignUpForEarlyAccessCommand { get; }
}
