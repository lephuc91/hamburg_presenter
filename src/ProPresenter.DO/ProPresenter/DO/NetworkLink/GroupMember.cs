using System;
using Pro.Common.Components;
using Pro.DO.Application;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.NetworkLink;

public class GroupMember : NotifyPropertyChangedBase
{
	private string _ip = string.Empty;

	private uint? _port;

	private string _name = string.Empty;

	private PlatformType _platform;

	private string _osVersion = string.Empty;

	private string _hostDescription = string.Empty;

	private string _apiVersion = string.Empty;

	private ConnectionStatus _connectionStatus = ConnectionStatus.Disconnected;

	public string Ip
	{
		get
		{
			return _ip;
		}
		internal set
		{
			SetValue("Ip", ref _ip, value, OnDataModified);
		}
	}

	public uint? Port
	{
		get
		{
			return _port;
		}
		internal set
		{
			SetValue("Port", ref _port, value, OnDataModified);
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		private set
		{
			SetValue("Name", ref _name, value, OnDataModified);
		}
	}

	public PlatformType Platform
	{
		get
		{
			return _platform;
		}
		private set
		{
			SetValue("Platform", ref _platform, value, OnDataModified);
		}
	}

	public string OsVersion
	{
		get
		{
			return _osVersion;
		}
		private set
		{
			SetValue("OsVersion", ref _osVersion, value, OnDataModified);
		}
	}

	public string HostDescription
	{
		get
		{
			return _hostDescription;
		}
		private set
		{
			SetValue("HostDescription", ref _hostDescription, value, OnDataModified);
		}
	}

	public string ApiVersion
	{
		get
		{
			return _apiVersion;
		}
		private set
		{
			SetValue("ApiVersion", ref _apiVersion, value, OnDataModified);
		}
	}

	public ConnectionStatus ConnectionStatus
	{
		get
		{
			return _connectionStatus;
		}
		private set
		{
			SetValue("ConnectionStatus", ref _connectionStatus, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public GroupMember(ProLink.Types.GroupDefinition.Types.Member p)
	{
		Update(p);
	}

	public void Update(ProLink.Types.GroupDefinition.Types.Member protoMember)
	{
		Ip = protoMember.Ip;
		Port = protoMember.Port;
	}

	public void Update(ProLink.Types.MemberStatus protoMemberStatus)
	{
		Ip = protoMemberStatus.Ip;
		Port = protoMemberStatus.Port;
		Name = protoMemberStatus.Name;
		Platform = ApplicationData.GetPlatformType(protoMemberStatus.Platform);
		OsVersion = protoMemberStatus.OsVersion;
		HostDescription = protoMemberStatus.HostDescription;
		ApiVersion = protoMemberStatus.ApiVersion;
		ConnectionStatus = protoMemberStatus.ConnectionStatus.ToConnectionStatus();
	}

	public ProLink.Types.GroupDefinition.Types.Member Serialize()
	{
		return new ProLink.Types.GroupDefinition.Types.Member
		{
			Ip = (Ip ?? string.Empty),
			Port = Port.GetValueOrDefault()
		};
	}

	public ProLink.Types.MemberStatus SerializeStatus()
	{
		return new ProLink.Types.MemberStatus
		{
			Name = (Name ?? string.Empty),
			Ip = (Ip ?? string.Empty),
			Port = Port.GetValueOrDefault(),
			ApiVersion = (ApiVersion ?? string.Empty),
			ConnectionStatus = ProLink.Types.MemberStatus.Types.ConnectionStatus.Disconnected,
			HostDescription = (HostDescription ?? string.Empty),
			OsVersion = (OsVersion ?? string.Empty),
			Platform = ApplicationData.GetProtoPlatformType(Platform)
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
