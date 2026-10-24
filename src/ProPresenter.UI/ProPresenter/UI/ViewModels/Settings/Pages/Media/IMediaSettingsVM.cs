using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

public interface IMediaSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool ManageMediaAutomatically { get; set; }

	bool AutoRelink { get; set; }

	IMediaSearchPathsSettingsVM SearchPathsSettingsVM { get; }

	bool SuppressVideoStart { get; set; }

	ForegroundMediaAudioBehaviorInternal PresentationForegroundMediaAudioBehavior { get; set; }

	ForegroundMediaAudioBehaviorInternal AnnouncementForegroundMediaAudioBehavior { get; set; }

	ICommand HelpCommand { get; }
}
