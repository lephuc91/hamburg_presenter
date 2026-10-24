using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration;

public interface IRegistrationMainPageVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	IHeaderVM Header { get; }

	IProPresenterSectionVM ProPresenter { get; }

	IProContentSectionVM ProContent { get; }

	IFooterVM Footer { get; }

	string ListItemTitle { get; }

	string ListItemSubscript { get; }

	IRelayCommand RefreshCommand { get; }
}
