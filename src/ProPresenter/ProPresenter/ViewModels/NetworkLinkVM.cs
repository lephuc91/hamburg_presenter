using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Common.Nullability;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.NetworkLink;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Pages;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels;

public class NetworkLinkVM : LinkedNotifyPropertyChangedBase, INetworkLinkVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly FilteredObservableCollection<IGroupMemberVM> _filteredMembers;

	private readonly INetworkLinkService _service;

	private readonly INetworkLinkPrompt _prompt;

	private IGroupMemberVM? _selectedMember;

	private string _newConnectionIp = string.Empty;

	private int _newConnectionPort;

	private ISettingsItemVM? _parent;

	private readonly INetwork _network;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public bool Enabled
	{
		get
		{
			return _network.EnableLink;
		}
		set
		{
			_network.EnableLink = value;
		}
	}

	public IEnumerable<INetworkEntity> AvailableConnections => _service.Environment;

	public IEnumerable<INetworkEntity> Groups => AvailableConnections.OfType<AvailableGroup>();

	public IEnumerable<INetworkEntity> Devices => AvailableConnections.OfType<AvailableDevice>();

	private IGroupDefinition Group => _service.GroupDefinition;

	public string GroupName => Group?.Name ?? string.Empty;

	public INotifyEnumerableChanged<IGroupMemberVM> GroupMembers => _filteredMembers;

	public IGroupMemberVM? SelectedMember
	{
		get
		{
			return _selectedMember;
		}
		set
		{
			SetValue("SelectedMember", ref _selectedMember, value);
		}
	}

	public ICommand ConnectCommand => new RelayCommand(OnConnectCommand);

	public ICommand<INetworkEntity> ConnectToCommand => new RelayCommand<INetworkEntity>(OnConnectToCommand, (INetworkEntity e) => !(e is AvailableGroup) || string.IsNullOrEmpty(Group.Name));

	public ICommand RemoveMemberCommand => new RelayCommand(OnRemoveCommand, () => SelectedMember != null);

	public ICommand LeaveGroupCommand => new RelayCommand(OnLeaveGroupCommand, () => !string.IsNullOrEmpty(Group.Name));

	public ICommand CancelPendingCommand => new RelayCommand(_service.Cancel);

	public ICommand RefreshEnvironmentCommand => new RelayCommand(OnRefreshEnvironmentCommand);

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpNetworkLink));
	});

	public ISettingsItemVM? Parent => _parent;

	public string Name { get; }

	public Brush Background => SettingsListItemConstants.Gray;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsNetworkLinkSearchIcon);

	public bool IsNavigable => _network.EnableNetwork;

	public bool CanExit => true;

	public NetworkLinkVM(INetworkLinkService networkLinkService, INetworkLinkPrompt prompt, INetwork network, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		NetworkLinkVM networkLinkVM = this;
		_service = networkLinkService;
		_prompt = prompt;
		_network = network;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		PairedCollection<GroupMember, IGroupMemberVM> collection = new PairedCollection<GroupMember, IGroupMemberVM>(Group, (GroupMember m) => new GroupMemberVM(m, network));
		_filteredMembers = new FilteredObservableCollection<IGroupMemberVM>(collection, Filter);
		LinkProperties("EnableLink", "Enabled");
		LinkProperties("EnableNetwork", "IsNavigable");
		LinkProperties("Name", "GroupName");
		Name = localization.Get("SETTINGS_PAGE_NETWORK_LINK_title");
		_network.PropertyChanged += base.RaiseLinkedValues;
		if (_service.GroupDefinition != null)
		{
			Group.PropertyChanged += base.RaiseLinkedValues;
			Group.CollectionChanged += delegate
			{
				networkLinkVM._filteredMembers.Refresh();
				networkLinkVM.SelectedMember = ((networkLinkVM.SelectedMember == null) ? networkLinkVM.GroupMembers.FirstOrDefault() : networkLinkVM.GroupMembers.FirstOrDefault((IGroupMemberVM g) => g.Ip == networkLinkVM.SelectedMember.Ip));
			};
		}
		_filteredMembers.Refresh();
		_service.AddRequestHandler(OnRequestReceived);
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_ENABLE_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_GROUP_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_MEMBER_NAME_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_MEMBER_VERSION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_MEMBER_IPADDRESS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_PAGE_NETWORK_LINK_MEMBER_PORT_title", this, isComponent: true));
	}

	private bool Filter(IGroupMemberVM member)
	{
		return member.Ip != _network.LocalIPAddress;
	}

	private ILinkResponse? OnRequestReceived(ILinkRequest? request)
	{
		if (!(request is AddConnectionSuccess) && !(request is GroupUpdateRequest))
		{
			if (request is GroupNameRequest)
			{
				_prompt.HidePending();
				return HandleGroupNameRequest();
			}
			if (!(request is AddConnectionFailure failure))
			{
				if (request is GroupJoinConfirmationRequest groupJoinConfirmationRequest)
				{
					_prompt.HidePending();
					return HandleGroupJoinConfirmationRequest(groupJoinConfirmationRequest.GroupName);
				}
				if (request is GroupJoinPasswordRequest)
				{
					_prompt.HidePending();
				}
			}
			else
			{
				_prompt.HidePending();
				HandleAddConnectionFailure(failure);
			}
		}
		else
		{
			_prompt.HidePending();
		}
		return null;
	}

	private ILinkResponse HandleGroupNameRequest()
	{
		if (_prompt.CreateGroup(out string name))
		{
			_prompt.ShowPending(_localization.Get("SETTINGS_PAGE_NETWORK_LINK_CREATING_GROUP_message"), this);
			return new GroupNameResponse
			{
				GroupName = name
			};
		}
		var (success, ipAddress, port) = _prompt.AddConnection(_newConnectionIp, _newConnectionPort);
		AddConnection(success, ipAddress, port);
		return new GroupNameResponse
		{
			GroupName = string.Empty
		};
	}

	private ILinkResponse HandleGroupJoinConfirmationRequest(string name)
	{
		bool flag = _prompt.GroupJoinConfirm(name);
		if (flag)
		{
			_prompt.ShowPending(_localization.Get("SETTINGS_PAGE_NETWORK_LINK_JOINING_GROUP_message"), this);
		}
		return new GroupJoinResponse
		{
			DidAccept = flag
		};
	}

	private void HandleAddConnectionFailure(AddConnectionFailure failure)
	{
		bool flag = false;
		switch (failure.Type)
		{
		case FailureResultType.Unexpected:
			_prompt.ShowUnexpectedError(_newConnectionIp, _newConnectionPort);
			break;
		case FailureResultType.Declined:
			return;
		case FailureResultType.InOtherGroup:
			_prompt.ShowInOtherGroupError(failure.MemberName, failure.GroupName);
			break;
		case FailureResultType.Timeout:
			_prompt.ShowTimeoutError(_newConnectionIp, _newConnectionPort);
			break;
		case FailureResultType.InvalidIpAddress:
			_prompt.ShowInvalidIpError();
			break;
		case FailureResultType.AlreadyInGroup:
			_prompt.ShowAlreadyInGroupError(failure.MemberName, failure.GroupName);
			break;
		case FailureResultType.LinkDisabled:
			_prompt.ShowLinkDisabledError(_newConnectionIp);
			break;
		case FailureResultType.CouldNotAdd:
			_prompt.ShowCouldNotAddMemberError(failure.MemberName);
			break;
		case FailureResultType.CouldNotJoin:
			flag = _prompt.ShowCouldNotJoinGroupError(failure.GroupName);
			break;
		}
		if (flag)
		{
			_service.AddConnection(_newConnectionIp, _newConnectionPort, Group.Name);
			return;
		}
		var (success, ipAddress, port) = _prompt.AddConnection(_newConnectionIp, _newConnectionPort);
		AddConnection(success, ipAddress, port);
	}

	private void OnRemoveCommand()
	{
		SelectedMember.ThrowWhenNull("SelectedMember");
		if (_prompt.RemoveConnection(SelectedMember.Name, Group.Name))
		{
			NetworkGroupRemoveEvent.Publish();
			_service.RemoveConnection(SelectedMember.Ip, int.TryParse(SelectedMember.Port, out var result) ? result : 0);
			SelectedMember = null;
		}
	}

	private void OnConnectCommand()
	{
		var (success, ipAddress, port) = _prompt.AddConnection();
		AddConnection(success, ipAddress, port);
	}

	private void OnConnectToCommand(INetworkEntity entity)
	{
		var (ipAddress, port) = entity.GetConnectionInfo();
		AddConnection(success: true, ipAddress, port);
	}

	private void AddConnection(bool success, string? ipAddress, int port)
	{
		if (success)
		{
			_newConnectionIp = ipAddress ?? string.Empty;
			_newConnectionPort = port;
			NetworkGroupAddEvent.Publish();
			_service.AddConnection(_newConnectionIp, port, string.Empty);
			_prompt.ShowPending(_localization.Get("SETTINGS_PAGE_NETWORK_LINK_ESTABLISHING_CONNECTION_message"), this);
		}
	}

	private void OnLeaveGroupCommand()
	{
		if (_prompt.LeaveGroup(Group.Name))
		{
			NetworkGroupLeaveEvent.Publish();
			_service.RemoveConnection(string.Empty, 0);
		}
	}

	private void OnRefreshEnvironmentCommand()
	{
		OnPropertyChanged("Groups");
		OnPropertyChanged("Devices");
	}

	public void SetParent(ISettingsItemVM parent)
	{
		_parent = parent;
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
