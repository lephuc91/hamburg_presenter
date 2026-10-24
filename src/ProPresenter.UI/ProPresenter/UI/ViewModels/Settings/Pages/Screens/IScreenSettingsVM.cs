using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Screens;

public interface IScreenSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool ShowOutputAtLaunch { get; set; }

	bool ShowScreenStats { get; set; }

	bool IgnoreBackgroundColors { get; set; }

	IClockSourceVM ClockSourceVM { get; }

	IReadOnlyCollection<BitDepths> BitDepths { get; }

	BitDepths SelectedBitDepth { get; set; }

	bool BitDepthChanged { get; }

	void RefreshClockSource();
}
