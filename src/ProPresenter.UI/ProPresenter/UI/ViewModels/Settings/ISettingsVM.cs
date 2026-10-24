using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.Controller;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings;

public interface ISettingsVM : INotifyPropertyChanged
{
	ISettingsNavigationVM NavigationVM { get; }

	IEnumerable<ISettingsListItem> Items { get; }

	ISettingsListItem ActiveItem { get; set; }

	ISettingsItemVM ActivePage { get; set; }

	ISettingsListItem SelectedItem { get; set; }

	ISettingsSearchVM SearchVM { get; }

	IRelayCommand<ISettingsItemVM> SelectActivePageCommand { get; }

	IRelayCommand<CreateRenderViewParameters> LoadPreviewCommand { get; }

	IRelayCommand<DestroyRenderViewParameters> UnloadPreviewCommand { get; }

	void SetActivePage(SettingsPage page);

	void ToggleInputStatus(bool enable);
}
