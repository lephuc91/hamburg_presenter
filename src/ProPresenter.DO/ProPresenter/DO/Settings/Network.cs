using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.NetworkLink;

namespace ProPresenter.DO.Settings;

public class Network : StoreBase, INetwork, INotifyPropertyChanged
{
	private const string SettingsFile = "NetworkPreferences.proPref";

	public const int DEFAULT_PORT = 52273;

	public const string DefaultLocalIPAddress = "0.0.0.0";

	public int DefaultPort => 52273;

	public bool EnableNetwork
	{
		get
		{
			return GetValue("EnableNetwork", defaultValue: false);
		}
		set
		{
			if (!value)
			{
				EnableMasterControl = false;
			}
			SetValue("EnableNetwork", value);
			OnPropertyChanged("EnableNetwork");
		}
	}

	public string NetworkName
	{
		get
		{
			return GetValue("NetworkName", UnitTestDetector.IsInUnitTest ? string.Empty : Dns.GetHostName()) ?? string.Empty;
		}
		set
		{
			SetValue("NetworkName", value);
			OnPropertyChanged("NetworkName");
		}
	}

	public int NetworkPort
	{
		get
		{
			return GetValue("NetworkPort", DefaultPort).Clamp(0, 65535);
		}
		set
		{
			if (value != NetworkPort)
			{
				GroupMember groupMember = LinkGroup?.FirstOrDefault((GroupMember member) => member.Ip == LocalIPAddress);
				if (groupMember != null)
				{
					groupMember.Port = (uint)value;
					LinkGroup.UpdateTimestamp();
				}
			}
			SetValue("NetworkPort", value.Clamp(0, 65535));
			OnPropertyChanged("NetworkPort");
		}
	}

	public string LocalIPAddress
	{
		get
		{
			return GetValue("LocalIPAddress", "0.0.0.0") ?? string.Empty;
		}
		set
		{
			if (value != LocalIPAddress && value != null)
			{
				GroupMember groupMember = LinkGroup?.FirstOrDefault((GroupMember member) => member.Ip == LocalIPAddress);
				if (groupMember != null)
				{
					groupMember.Ip = value;
					LinkGroup.UpdateTimestamp();
				}
			}
			SetValue("LocalIPAddress", value);
			OnPropertyChanged("LocalIPAddress");
		}
	}

	public bool EnableMasterControl
	{
		get
		{
			return GetValue("EnableMasterControl", defaultValue: false);
		}
		set
		{
			SetValue("EnableMasterControl", value);
			OnPropertyChanged("EnableMasterControl");
		}
	}

	public bool EnableProRemoteV2
	{
		get
		{
			return GetValue("EnableProRemoteV2", defaultValue: false);
		}
		set
		{
			SetValue("EnableProRemoteV2", value);
			OnPropertyChanged("EnableProRemoteV2");
		}
	}

	public string ProRemoteV2Password
	{
		get
		{
			return GetValue("ProRemoteV2Password", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ProRemoteV2Password", value);
			OnPropertyChanged("ProRemoteV2Password");
		}
	}

	public bool EnableRemoteStageDisplay
	{
		get
		{
			return GetValue("EnableRemoteStageDisplay", defaultValue: false);
		}
		set
		{
			SetValue("EnableRemoteStageDisplay", value);
			OnPropertyChanged("EnableRemoteStageDisplay");
		}
	}

	public string RemoteStageDisplayPassword
	{
		get
		{
			return GetValue("RemoteStageDisplayPassword", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("RemoteStageDisplayPassword", value);
			OnPropertyChanged("RemoteStageDisplayPassword");
		}
	}

	public bool EnableLink
	{
		get
		{
			return GetValue("EnableLink", defaultValue: false);
		}
		set
		{
			SetValue("EnableLink", value);
			OnPropertyChanged("EnableLink");
		}
	}

	public ProPresenter.DO.NetworkLink.Group LinkGroup => GetValue("LinkGroup", new ProPresenter.DO.NetworkLink.Group()) ?? new ProPresenter.DO.NetworkLink.Group();

	private List<ProLink.Types.MemberStatus>? LinkGroupMemberStatuses => GetValue("LinkGroupMemberStatuses", new List<ProLink.Types.MemberStatus>());

	public bool InEnabledLinkGroup
	{
		get
		{
			if (EnableNetwork && EnableLink)
			{
				return !LinkGroup.Empty();
			}
			return false;
		}
	}

	public bool EnableTcpConnection
	{
		get
		{
			return GetValue("EnableTcpConnection", defaultValue: false);
		}
		set
		{
			SetValue("EnableTcpConnection", value);
			OnPropertyChanged("EnableTcpConnection");
		}
	}

	public int TcpConnectionPort
	{
		get
		{
			return GetValue("TcpConnectionPort", DefaultPort).Clamp(0, 65535);
		}
		set
		{
			SetValue("TcpConnectionPort", value);
			OnPropertyChanged("TcpConnectionPort");
		}
	}

	public Network()
		: base(Path.Combine(CommonPaths.Preferences, "NetworkPreferences.proPref"))
	{
		RegisterCustomType(ProtoHelper.EncodeBase64, ProtoHelper.DecodeBase64<ProLink.Types.MemberStatus>);
		RegisterListType<ProLink.Types.MemberStatus, List<ProLink.Types.MemberStatus>>();
		RegisterCustomType((ProPresenter.DO.NetworkLink.Group g) => g.Serialize().EncodeBase64(), delegate(string s)
		{
			ProPresenter.DO.NetworkLink.Group group = new ProPresenter.DO.NetworkLink.Group();
			ProLink.Types.GroupDefinition protoGroupDefinition = ProtoHelper.DecodeBase64<ProLink.Types.GroupDefinition>(s);
			group.Deserialize(protoGroupDefinition);
			if (LinkGroupMemberStatuses != null)
			{
				group.Deserialize(LinkGroupMemberStatuses);
			}
			return group;
		});
		if (LinkGroup != null)
		{
			LinkGroup.Updated += delegate
			{
				SetValue("LinkGroup", LinkGroup);
			};
			LinkGroup.MembersUpdated += delegate
			{
				SetValue("LinkGroupMemberStatuses", LinkGroup.SerializeStatuses().ToList());
			};
		}
	}

	public int GetPort(int autoPort)
	{
		if (NetworkPort != DefaultPort)
		{
			return NetworkPort;
		}
		return autoPort;
	}

	void INetwork.RemoveValue(string key)
	{
		RemoveValue(key);
	}

	void INetwork.UpdateSettingsFile()
	{
		UpdateSettingsFile();
	}
}
