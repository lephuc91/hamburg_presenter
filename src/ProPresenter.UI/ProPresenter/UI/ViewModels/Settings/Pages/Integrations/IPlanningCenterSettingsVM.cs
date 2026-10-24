using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public interface IPlanningCenterSettingsVM : IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool AutoPlanUpdate { get; set; }

	bool MatchSongs { get; set; }

	bool ShowHistoricalPlans { get; set; }

	bool ArrangementFromSequences { get; set; }

	bool AutoUpload { get; set; }

	bool AutoDownload { get; set; }

	string TargetLibrary { get; set; }

	IEnumerable<IIdentifiable> LibraryCollection { get; }

	ICommand<IIdentifiable> SelectLibraryCommand { get; }

	ICommand HelpCommand { get; }

	ICommand OpenSupportCommand { get; }
}
