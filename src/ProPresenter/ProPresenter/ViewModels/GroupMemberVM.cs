using Pro.Common.Components;
using Pro.DO.Application;
using ProPresenter.DO.NetworkLink;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.NetworkLink;

namespace ProPresenter.ViewModels;

public class GroupMemberVM : LinkedNotifyPropertyChangedBase, IGroupMemberVMInternal, IGroupMemberVM
{
	private readonly INetwork _network;

	public GroupMember Item { get; }

	public string Name => Item.Name;

	public string Version => Item.HostDescription;

	public string Ip => Item.Ip;

	public string Port => Item.Port?.ToString() ?? string.Empty;

	public ConnectionStatus Status => Item.ConnectionStatus;

	public PlatformType Platform => Item.Platform;

	public bool ShowConnectionStatus
	{
		get
		{
			if (_network.EnableNetwork)
			{
				return _network.EnableLink;
			}
			return false;
		}
	}

	public GroupMemberVM(GroupMember item, INetwork network)
	{
		Item = item;
		_network = network;
		LinkProperties("Name", "Name");
		LinkProperties("OsVersion", "Version");
		LinkProperties("HostDescription", "Version");
		LinkProperties("Ip", "Ip");
		LinkProperties("Port", "Port");
		LinkProperties("ConnectionStatus", "Status");
		LinkProperties("Platform", "Platform");
		LinkProperties(new string[2] { "EnableNetwork", "EnableLink" }, "ShowConnectionStatus");
		Item.PropertyChanged += base.RaiseLinkedValues;
		_network.PropertyChanged += base.RaiseLinkedValues;
	}
}
