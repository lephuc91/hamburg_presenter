using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ViewModels.ProContent;

public interface IProContentVM : INotifyPropertyChanged, INavigationItem
{
	INotifyEnumerableChanged<IProContentGroupVM> Groups { get; }

	IProContentGroupVM? SelectedRootElement { get; set; }

	IProContentGroupVM CurrentGroup { get; set; }

	INotifyEnumerableChanged<IProContentCollectionVM>? Collections { get; }

	bool IsLoggedIn { get; }

	bool IsLoadingData { get; }

	bool FocusSearchBox { get; set; }

	ConnectionState ConnectionState { get; }

	string ContactSupportLinkText { get; }

	string ContactSupportUrl { get; }

	IRelayCommand BrowseMoreCommand { get; }

	IAsyncRelayCommand ToggleLoginLogoutCommand { get; }

	IAsyncRelayCommand ReloadCommand { get; }

	IAsyncRelayCommand<IProContentAssetVM> SelectAssetCommand { get; }

	Task NavigateAsync(IProContentGroupVM group);
}
