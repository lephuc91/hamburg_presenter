using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels;

public interface INetworkLinkVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool Enabled { get; set; }

	string GroupName { get; }

	INotifyEnumerableChanged<IGroupMemberVM> GroupMembers { get; }

	IGroupMemberVM? SelectedMember { get; set; }

	ICommand RemoveMemberCommand { get; }

	ICommand LeaveGroupCommand { get; }

	ICommand ConnectCommand { get; }

	ICommand CancelPendingCommand { get; }

	ICommand RefreshEnvironmentCommand { get; }

	ICommand HelpCommand { get; }
}
