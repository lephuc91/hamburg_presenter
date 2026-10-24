using System;
using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public interface IServiceIntegrationVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	string Username { get; }

	string OrganizationName { get; }

	bool IsLoggedIn { get; }

	string StatusText { get; }

	ICommand LoginLogoutCommand { get; }

	event Action? ToggleAuthorization;
}
