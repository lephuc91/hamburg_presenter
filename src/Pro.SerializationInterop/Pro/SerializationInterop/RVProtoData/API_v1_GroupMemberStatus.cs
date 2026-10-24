using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_GroupMemberStatus : IMessage<API_v1_GroupMemberStatus>, IMessage, IEquatable<API_v1_GroupMemberStatus>, IDeepCloneable<API_v1_GroupMemberStatus>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_GroupMemberStatus_ConnectionStatus
		{
			[OriginalName("CONNECTION_STATUS_UNKNOWN")]
			ConnectionStatusUnknown,
			[OriginalName("CONNECTION_STATUS_CONNECTED")]
			ConnectionStatusConnected,
			[OriginalName("CONNECTION_STATUS_DISCONNECTED")]
			ConnectionStatusDisconnected
		}

		public enum API_v1_GroupMemberStatus_Platform
		{
			[OriginalName("PLATFORM_UNKNOWN")]
			PlatformUnknown,
			[OriginalName("PLATFORM_MACOS")]
			PlatformMacos,
			[OriginalName("PLATFORM_WIN32")]
			PlatformWin32,
			[OriginalName("PLATFORM_WEB")]
			PlatformWeb
		}
	}

	private static readonly MessageParser<API_v1_GroupMemberStatus> _parser = new MessageParser<API_v1_GroupMemberStatus>(() => new API_v1_GroupMemberStatus());

	private UnknownFieldSet _unknownFields;

	public const int IpFieldNumber = 1;

	private string ip_ = "";

	public const int PortFieldNumber = 2;

	private uint port_;

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int PlatformFieldNumber = 4;

	private Types.API_v1_GroupMemberStatus_Platform platform_;

	public const int OsVersionFieldNumber = 5;

	private string osVersion_ = "";

	public const int HostDescriptionFieldNumber = 6;

	private string hostDescription_ = "";

	public const int ApiVersionFieldNumber = 7;

	private string apiVersion_ = "";

	public const int ConnectionStatusFieldNumber = 8;

	private Types.API_v1_GroupMemberStatus_ConnectionStatus connectionStatus_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_GroupMemberStatus> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LinkReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Ip
	{
		get
		{
			return ip_;
		}
		set
		{
			ip_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Port
	{
		get
		{
			return port_;
		}
		set
		{
			port_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_GroupMemberStatus_Platform Platform
	{
		get
		{
			return platform_;
		}
		set
		{
			platform_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string OsVersion
	{
		get
		{
			return osVersion_;
		}
		set
		{
			osVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string HostDescription
	{
		get
		{
			return hostDescription_;
		}
		set
		{
			hostDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ApiVersion
	{
		get
		{
			return apiVersion_;
		}
		set
		{
			apiVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_GroupMemberStatus_ConnectionStatus ConnectionStatus
	{
		get
		{
			return connectionStatus_;
		}
		set
		{
			connectionStatus_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMemberStatus()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMemberStatus(API_v1_GroupMemberStatus other)
		: this()
	{
		ip_ = other.ip_;
		port_ = other.port_;
		name_ = other.name_;
		platform_ = other.platform_;
		osVersion_ = other.osVersion_;
		hostDescription_ = other.hostDescription_;
		apiVersion_ = other.apiVersion_;
		connectionStatus_ = other.connectionStatus_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMemberStatus Clone()
	{
		return new API_v1_GroupMemberStatus(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_GroupMemberStatus);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_GroupMemberStatus other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Ip != other.Ip)
		{
			return false;
		}
		if (Port != other.Port)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Platform != other.Platform)
		{
			return false;
		}
		if (OsVersion != other.OsVersion)
		{
			return false;
		}
		if (HostDescription != other.HostDescription)
		{
			return false;
		}
		if (ApiVersion != other.ApiVersion)
		{
			return false;
		}
		if (ConnectionStatus != other.ConnectionStatus)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (Ip.Length != 0)
		{
			num ^= Ip.GetHashCode();
		}
		if (Port != 0)
		{
			num ^= Port.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (Platform != 0)
		{
			num ^= Platform.GetHashCode();
		}
		if (OsVersion.Length != 0)
		{
			num ^= OsVersion.GetHashCode();
		}
		if (HostDescription.Length != 0)
		{
			num ^= HostDescription.GetHashCode();
		}
		if (ApiVersion.Length != 0)
		{
			num ^= ApiVersion.GetHashCode();
		}
		if (ConnectionStatus != 0)
		{
			num ^= ConnectionStatus.GetHashCode();
		}
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (Ip.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Ip);
		}
		if (Port != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(Port);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Name);
		}
		if (Platform != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Platform);
		}
		if (OsVersion.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(OsVersion);
		}
		if (HostDescription.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(HostDescription);
		}
		if (ApiVersion.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(ApiVersion);
		}
		if (ConnectionStatus != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)ConnectionStatus);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (Ip.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Ip);
		}
		if (Port != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (Platform != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
		}
		if (OsVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(OsVersion);
		}
		if (HostDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(HostDescription);
		}
		if (ApiVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ApiVersion);
		}
		if (ConnectionStatus != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ConnectionStatus);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_GroupMemberStatus other)
	{
		if (other != null)
		{
			if (other.Ip.Length != 0)
			{
				Ip = other.Ip;
			}
			if (other.Port != 0)
			{
				Port = other.Port;
			}
			if (other.Name.Length != 0)
			{
				Name = other.Name;
			}
			if (other.Platform != 0)
			{
				Platform = other.Platform;
			}
			if (other.OsVersion.Length != 0)
			{
				OsVersion = other.OsVersion;
			}
			if (other.HostDescription.Length != 0)
			{
				HostDescription = other.HostDescription;
			}
			if (other.ApiVersion.Length != 0)
			{
				ApiVersion = other.ApiVersion;
			}
			if (other.ConnectionStatus != 0)
			{
				ConnectionStatus = other.ConnectionStatus;
			}
			_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 10u:
				Ip = input.ReadString();
				break;
			case 16u:
				Port = input.ReadUInt32();
				break;
			case 26u:
				Name = input.ReadString();
				break;
			case 32u:
				Platform = (Types.API_v1_GroupMemberStatus_Platform)input.ReadEnum();
				break;
			case 42u:
				OsVersion = input.ReadString();
				break;
			case 50u:
				HostDescription = input.ReadString();
				break;
			case 58u:
				ApiVersion = input.ReadString();
				break;
			case 64u:
				ConnectionStatus = (Types.API_v1_GroupMemberStatus_ConnectionStatus)input.ReadEnum();
				break;
			}
		}
	}
}
