using System;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Group;

namespace ProPresenter.DO.ProContent;

public interface IProContentProvider : INotifyPropertyChanged
{
	IAsyncRelayCommand ReloadDataCommand { get; }

	IAsyncRelayCommand LoginLogoutCommand { get; }

	string ContactSupportUrl { get; }

	IRelayCommand<Uri?> BrowseMoreCommand { get; }

	IRelayCommand BrowseThemesCommand { get; }

	bool IsAuthorized { get; }

	INotifyEnumerableChanged<IProContentGroup> Groups { get; }

	ProContentConnectionState ConnectionState { get; }

	string ContactSupportLinkText { get; }

	Uri DefaultBrowseMoreUri { get; }

	string BrowseHomepageCommandText { get; }

	IRelayCommand BrowseHomepageCommand { get; }

	IRelayCommand BrowseSignUpCommand { get; }

	IRelayCommand BrowseManageUserAccountCommand { get; }

	event Action DataReloaded;

	Task<IProContentGroup?> NavigateAsync(IProContentAsset? asset);

	Task RefreshAsync(IProContentGroup? group);
}
