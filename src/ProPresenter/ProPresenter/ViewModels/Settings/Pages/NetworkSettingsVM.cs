using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Themes;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Pages.Network;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class NetworkSettingsVM : ObservableObject, INetworkSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDisposable
{
	private enum ProRemotePasswordValidType
	{
		None,
		Valid,
		PasswordRequired
	}

	private readonly INetworkDialogService _dialogService;

	private readonly ILocalization _localization;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("NetworkName", "NetworkName")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("NetworkPort", "Port")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("EnableMasterControl", "EnableMasterControl")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("EnableRemoteStageDisplay", "EnableStageApp")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("RemoteStageDisplayPassword", "StageAppPassword")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("EnableTcpConnection", "EnableTcpConnection")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("TcpConnectionPort", "TcpConnectionPort")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("EnableProRemoteV2", "EnableProRemoteV2")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ProRemoteV2Password", "ProRemoteV2Password")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("EnableNetwork", "EnableNetwork")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableNetwork", "ApiDocumentationCommand.NotifyCanExecuteChanged")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableNetwork", "ValidateCanExit")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableProRemoteV2", "ValidateCanExit")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("ProRemoteV2Password", "ValidateCanExit")]
	private readonly INetwork _network;

	private readonly IHyperlinkService _hyperlinkService;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("LocalIPAddress", "IpAddress")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ConnectedPort", "AutoPort")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("TcpConnectedPort", "TcpConnectionAutoPort")]
	private readonly ServerState _serverState;

	private readonly IWebSourceProvider _webSourceProvider;

	private ProRemotePasswordValidType _proRemoteV2PasswordValidType = ProRemotePasswordValidType.Valid;

	[ObservableProperty]
	private int? _port;

	[ObservableProperty]
	private bool _proRemoteV2PasswordNeedFocus;

	[ObservableProperty]
	private int? _tcpConnectionPort;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? apiDocumentationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? tcpIpHelpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? proremoteHelpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? proremoteLegacyHelpCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; }

	public string Name { get; }

	public ISettingsItemVM? Parent => null;

	public bool EnableNetwork
	{
		get
		{
			return _network.EnableNetwork;
		}
		set
		{
			_network.EnableNetwork = value;
		}
	}

	public string NetworkName
	{
		get
		{
			return _network.NetworkName;
		}
		set
		{
			_network.NetworkName = value;
		}
	}

	public int AutoPort
	{
		get
		{
			if (_serverState.ConnectedPort != 0)
			{
				return _serverState.ConnectedPort;
			}
			return _network.DefaultPort;
		}
	}

	public string IpAddress => _network.LocalIPAddress;

	public bool EnableMasterControl
	{
		get
		{
			return _network.EnableMasterControl;
		}
		set
		{
			_network.EnableMasterControl = value;
		}
	}

	public ObservableCollection<string> MasterControlNodeType { get; } = new ObservableCollection<string>();

	public bool EnableProRemoteV2
	{
		get
		{
			return _network.EnableProRemoteV2;
		}
		set
		{
			_network.EnableProRemoteV2 = value;
		}
	}

	public bool EnableStageApp
	{
		get
		{
			return _network.EnableRemoteStageDisplay;
		}
		set
		{
			_network.EnableRemoteStageDisplay = value;
		}
	}

	public string ProRemoteV2Password
	{
		get
		{
			return _network.ProRemoteV2Password;
		}
		set
		{
			_network.ProRemoteV2Password = value;
		}
	}

	public string StageAppPassword
	{
		get
		{
			return _network.RemoteStageDisplayPassword;
		}
		set
		{
			_network.RemoteStageDisplayPassword = value;
		}
	}

	public bool EnableTcpConnection
	{
		get
		{
			return _network.EnableTcpConnection;
		}
		set
		{
			_network.EnableTcpConnection = value;
		}
	}

	public int TcpConnectionAutoPort => _serverState.TcpConnectedPort;

	public INetworkLinkVM NetworkLinkVM { get; }

	public Brush Background => SettingsListItemConstants.Blue;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsNetwork);

	public bool IsNavigable => true;

	public bool CanExit
	{
		get
		{
			if (_proRemoteV2PasswordValidType != ProRemotePasswordValidType.Valid)
			{
				return _proRemoteV2PasswordValidType == ProRemotePasswordValidType.None;
			}
			return true;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? Port
	{
		get
		{
			return _port;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_port, value))
			{
				int? port = _port;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Port);
				_port = value;
				OnPortChanged(port, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Port);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ProRemoteV2PasswordNeedFocus
	{
		get
		{
			return _proRemoteV2PasswordNeedFocus;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_proRemoteV2PasswordNeedFocus, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ProRemoteV2PasswordNeedFocus);
				_proRemoteV2PasswordNeedFocus = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ProRemoteV2PasswordNeedFocus);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? TcpConnectionPort
	{
		get
		{
			return _tcpConnectionPort;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_tcpConnectionPort, value))
			{
				int? tcpConnectionPort = _tcpConnectionPort;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TcpConnectionPort);
				_tcpConnectionPort = value;
				OnTcpConnectionPortChanged(tcpConnectionPort, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TcpConnectionPort);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ApiDocumentationCommand => apiDocumentationCommand ?? (apiDocumentationCommand = new RelayCommand(ApiDocumentation, CanOpenApiDocumentation));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand TcpIpHelpCommand => tcpIpHelpCommand ?? (tcpIpHelpCommand = new RelayCommand(TcpIpHelp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ProremoteHelpCommand => proremoteHelpCommand ?? (proremoteHelpCommand = new RelayCommand(ProremoteHelp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ProremoteLegacyHelpCommand => proremoteLegacyHelpCommand ?? (proremoteLegacyHelpCommand = new RelayCommand(ProremoteLegacyHelp));

	[RelayCommand(CanExecute = "CanOpenApiDocumentation")]
	private void ApiDocumentation()
	{
		string text = ((_serverState.ConnectedPort == 0) ? "" : $":{_serverState.ConnectedPort}");
		UriBuilder uriBuilder = new UriBuilder(IpAddress + text + "/v1/doc")
		{
			Scheme = Uri.UriSchemeHttp
		};
		_hyperlinkService.OpenLocal(uriBuilder.Uri);
	}

	private bool CanOpenApiDocumentation()
	{
		return EnableNetwork;
	}

	[RelayCommand]
	private void TcpIpHelp()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpTcpIp));
	}

	[RelayCommand]
	private void ProremoteHelp()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpProRemote));
	}

	[RelayCommand]
	private void ProremoteLegacyHelp()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpProRemoteClassic));
	}

	public NetworkSettingsVM(INetworkLinkVM networkLinkVM, ILocalization localization, INetwork network, IHyperlinkService hyperlinkService, INetworkDialogService dialogService, IServerStateHandler serverStateHandler, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_dialogService = dialogService;
		NetworkLinkVM = networkLinkVM;
		_localization = localization;
		_network = network;
		_hyperlinkService = hyperlinkService;
		_serverState = serverStateHandler.State;
		_webSourceProvider = webSourceProvider;
		NetworkLinkVM.SetParent(this);
		_port = ((_network.NetworkPort == _network.DefaultPort) ? ((int?)null) : new int?(_network.NetworkPort));
		_tcpConnectionPort = ((_network.TcpConnectionPort == _network.DefaultPort) ? ((int?)null) : new int?(_network.TcpConnectionPort));
		Name = _localization.Get("SETTINGS_NETWORK_PAGE_title");
		AddPropertyLinks();
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		SubPages = NetworkLinkVM.ToEnumerable();
		Fields = settingsSearchFactory.GetFields("SETTINGS_NETWORK_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_ENABLE_NETWORK_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_NETWORK_NAME_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_IP_ADDRESS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_PORT_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_PROREMOTE_V2_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_STAGE_APP_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_ENABLE_STAGE_APP_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_TCP_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_ENABLE_TCP_CONNECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_TCP_CONNECTION_PORT_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_NETWORK_API_DOCUMENTATION_BUTTON_title", this, isComponent: true));
	}

	public void PromptUnableToExit()
	{
		ProRemoteV2PasswordNeedFocus = false;
		if (_proRemoteV2PasswordValidType == ProRemotePasswordValidType.PasswordRequired)
		{
			_dialogService.ShowPasswordRequired();
			ProRemoteV2PasswordNeedFocus = true;
		}
	}

	public void ValidateCanExit()
	{
		_proRemoteV2PasswordValidType = GetProRemoteV2PasswordValidType();
		OnPropertyChanged("CanExit");
	}

	private ProRemotePasswordValidType GetProRemoteV2PasswordValidType()
	{
		if (!EnableNetwork)
		{
			return ProRemotePasswordValidType.None;
		}
		if (EnableProRemoteV2 && string.IsNullOrEmpty(ProRemoteV2Password))
		{
			return ProRemotePasswordValidType.PasswordRequired;
		}
		return ProRemotePasswordValidType.Valid;
	}

	public Pro.SerializationInterop.RVProtoData.Preferences.Types.Network Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Preferences.Types.Network
		{
			Network_ = new Pro.SerializationInterop.RVProtoData.Preferences.Types.Network.Types.Network
			{
				Enable = EnableNetwork,
				Name = NetworkName,
				Port = (Port.HasValue ? ((uint)Port.Value) : 0u)
			},
			Remotes = new Pro.SerializationInterop.RVProtoData.Preferences.Types.Network.Types.Remotes
			{
				StageApp = new Pro.SerializationInterop.RVProtoData.Preferences.Types.Network.Types.Remotes.Types.StageApp
				{
					Enable = EnableStageApp,
					Password = StageAppPassword
				}
			},
			Link = new Pro.SerializationInterop.RVProtoData.Preferences.Types.Network.Types.Link
			{
				Enable = NetworkLinkVM.Enabled,
				LinkGroup = NetworkLinkVM.GroupName
			}
		};
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPortChanged(int? oldValue, int? newValue)
	{
		_network.NetworkPort = ((!newValue.HasValue) ? _network.DefaultPort : newValue.Value);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnTcpConnectionPortChanged(int? oldValue, int? newValue)
	{
		_network.TcpConnectionPort = ((!newValue.HasValue) ? _network.DefaultPort : newValue.Value);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _network_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		case 11:
			switch (propertyName[7])
			{
			case 'N':
				if (propertyName == "NetworkName")
				{
					OnPropertyChanged("NetworkName");
				}
				break;
			case 'P':
				if (propertyName == "NetworkPort")
				{
					OnPropertyChanged("Port");
				}
				break;
			}
			break;
		case 19:
			switch (propertyName[6])
			{
			case 'M':
				if (propertyName == "EnableMasterControl")
				{
					OnPropertyChanged("EnableMasterControl");
				}
				break;
			case 'T':
				if (propertyName == "EnableTcpConnection")
				{
					OnPropertyChanged("EnableTcpConnection");
				}
				break;
			case 'o':
				if (propertyName == "ProRemoteV2Password")
				{
					OnPropertyChanged("ProRemoteV2Password");
					ValidateCanExit();
				}
				break;
			}
			break;
		case 17:
			switch (propertyName[0])
			{
			case 'T':
				if (propertyName == "TcpConnectionPort")
				{
					OnPropertyChanged("TcpConnectionPort");
				}
				break;
			case 'E':
				if (propertyName == "EnableProRemoteV2")
				{
					OnPropertyChanged("EnableProRemoteV2");
					ValidateCanExit();
				}
				break;
			}
			break;
		case 24:
			if (propertyName == "EnableRemoteStageDisplay")
			{
				OnPropertyChanged("EnableStageApp");
			}
			break;
		case 26:
			if (propertyName == "RemoteStageDisplayPassword")
			{
				OnPropertyChanged("StageAppPassword");
			}
			break;
		case 13:
			if (propertyName == "EnableNetwork")
			{
				OnPropertyChanged("EnableNetwork");
				ApiDocumentationCommand.NotifyCanExecuteChanged();
				ValidateCanExit();
			}
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _serverState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "LocalIPAddress":
			OnPropertyChanged("IpAddress");
			break;
		case "ConnectedPort":
			OnPropertyChanged("AutoPort");
			break;
		case "TcpConnectedPort":
			OnPropertyChanged("TcpConnectionAutoPort");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_network.PropertyChanged += _network_PropertyChanged;
		_serverState.PropertyChanged += _serverState_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_network.PropertyChanged -= _network_PropertyChanged;
		_serverState.PropertyChanged -= _serverState_PropertyChanged;
	}
}
