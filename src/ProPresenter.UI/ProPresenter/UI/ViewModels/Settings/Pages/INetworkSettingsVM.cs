using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public interface INetworkSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool EnableNetwork { get; set; }

	string NetworkName { get; set; }

	int? Port { get; set; }

	int AutoPort { get; }

	string IpAddress { get; }

	bool EnableMasterControl { get; set; }

	ObservableCollection<string> MasterControlNodeType { get; }

	bool EnableProRemoteV2 { get; set; }

	bool EnableStageApp { get; set; }

	string ProRemoteV2Password { get; set; }

	string StageAppPassword { get; set; }

	INetworkLinkVM NetworkLinkVM { get; }

	IRelayCommand ApiDocumentationCommand { get; }

	bool EnableTcpConnection { get; set; }

	int? TcpConnectionPort { get; set; }

	int TcpConnectionAutoPort { get; }

	IRelayCommand TcpIpHelpCommand { get; }

	IRelayCommand ProremoteHelpCommand { get; }

	IRelayCommand ProremoteLegacyHelpCommand { get; }

	Preferences.Types.Network Serialize();
}
