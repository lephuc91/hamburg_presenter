using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Updates;

public interface IUpdatesSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	string InstalledVersion { get; }

	string UpdateDate { get; }

	bool NotifyUpdatesAvailable { get; set; }

	UpdateChannel ChannelSelected { get; set; }

	bool BetaChannelSelected { get; set; }

	IRelayCommand CheckUpdatesCommand { get; }

	IRelayCommand ShowInstalledReleaseNotesCommand { get; }

	IReadOnlyCollection<IAvailableUpdateVM> AvailableUpdates { get; }

	Preferences.Types.Updates Serialize();
}
