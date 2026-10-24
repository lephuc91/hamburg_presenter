using System.ComponentModel;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public interface IChildPageSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	void SetParent(ISettingsItemVM parent);
}
