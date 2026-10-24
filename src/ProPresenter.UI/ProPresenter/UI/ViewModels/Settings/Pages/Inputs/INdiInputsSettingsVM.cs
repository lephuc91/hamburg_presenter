using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

public interface INdiInputsSettingsVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool ShowSources { get; set; }

	string ReceiveGroups { get; set; }

	string AdditionalSearchIPs { get; set; }

	ICommand HelpCommand { get; }

	ICommand UpdateNdiFinderSettingsCommand { get; }
}
