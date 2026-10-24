using System.ComponentModel;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings;

public interface ISettingsItemVM : ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	ISettingsItemVM? Parent { get; }
}
