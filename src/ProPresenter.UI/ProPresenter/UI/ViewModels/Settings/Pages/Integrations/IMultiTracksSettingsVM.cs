using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public interface IMultiTracksSettingsVM : IServiceIntegrationVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	ICommand HelpCommand { get; }

	ICommand OpenSupportCommand { get; }
}
