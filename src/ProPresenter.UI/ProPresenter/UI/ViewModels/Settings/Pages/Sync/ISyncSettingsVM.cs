using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Sync.Local;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Sync;

public interface ISyncSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	ISyncController SyncController { get; }

	string Source { get; set; }

	SyncDirection Direction { get; set; }

	bool IncludeLibraries { get; set; }

	bool IncludePlaylists { get; set; }

	bool IncludeThemes { get; set; }

	bool IncludeMedia { get; set; }

	bool IncludeConfiguration { get; set; }

	bool ReplaceFiles { get; set; }

	string ReadySyncTitle { get; }

	IRelayCommand AddSourceCommand { get; }

	IRelayCommand SyncCommand { get; }

	ICommand HelpCommand { get; }
}
