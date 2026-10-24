using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

public interface IMediaSearchPathsSettingsVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	IDragDropNotifyEnumerableChanged<IMediaSearchRootVM> SearchRoots { get; }

	ICommand HelpCommand { get; }
}
