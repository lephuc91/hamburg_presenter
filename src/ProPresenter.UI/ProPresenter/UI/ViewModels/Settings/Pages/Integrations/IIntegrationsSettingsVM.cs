using System.ComponentModel;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public interface IIntegrationsSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	IPlanningCenterSettingsVM PlanningCenter { get; }

	ISongSelectSettingsVM SongSelect { get; }

	IMultiTracksSettingsVM MultiTracks { get; }

	IResiSettingsVM Resi { get; }

	bool ShowHoW { get; }
}
