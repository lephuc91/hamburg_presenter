using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProApiNetworkConfiguration : IMessage<ProApiNetworkConfiguration>, IMessage, IEquatable<ProApiNetworkConfiguration>, IDeepCloneable<ProApiNetworkConfiguration>
{
	private static readonly MessageParser<ProApiNetworkConfiguration> _parser = new MessageParser<ProApiNetworkConfiguration>(() => new ProApiNetworkConfiguration());

	private UnknownFieldSet _unknownFields;

	public const int EnableNetworkFieldNumber = 1;

	private bool enableNetwork_;

	public const int PortFieldNumber = 2;

	private uint port_;

	public const int NetworkNameFieldNumber = 3;

	private string networkName_ = "";

	public const int RemoteEnableFieldNumber = 4;

	private bool remoteEnable_;

	public const int RemoteControlEnableFieldNumber = 5;

	private bool remoteControlEnable_;

	public const int RemoteControlPasswordFieldNumber = 6;

	private string remoteControlPassword_ = "";

	public const int RemoteObserveEnableFieldNumber = 7;

	private bool remoteObserveEnable_;

	public const int RemoteObservePasswordFieldNumber = 8;

	private string remoteObservePassword_ = "";

	public const int StageEnableFieldNumber = 9;

	private bool stageEnable_;

	public const int StagePasswordFieldNumber = 10;

	private string stagePassword_ = "";

	public const int LinkEnableFieldNumber = 11;

	private bool linkEnable_;

	public const int WebResourceRootFieldNumber = 12;

	private string webResourceRoot_ = "";

	public const int TcpStreamPortFieldNumber = 13;

	private uint tcpStreamPort_;

	public const int TcpStreamEnableFieldNumber = 14;

	private bool tcpStreamEnable_;

	public const int AirplayFieldNumber = 15;

	private AirplayConfiguration airplay_;

	public const int ProremoteWebsocketEnableFieldNumber = 16;

	private bool proremoteWebsocketEnable_;

	public const int ProremoteWebsocketPasswordFieldNumber = 17;

	private string proremoteWebsocketPassword_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProApiNetworkConfiguration> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool EnableNetwork
	{
		get
		{
			return enableNetwork_;
		}
		set
		{
			enableNetwork_ = value;
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
	public string NetworkName
	{
		get
		{
			return networkName_;
		}
		set
		{
			networkName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RemoteEnable
	{
		get
		{
			return remoteEnable_;
		}
		set
		{
			remoteEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RemoteControlEnable
	{
		get
		{
			return remoteControlEnable_;
		}
		set
		{
			remoteControlEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RemoteControlPassword
	{
		get
		{
			return remoteControlPassword_;
		}
		set
		{
			remoteControlPassword_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RemoteObserveEnable
	{
		get
		{
			return remoteObserveEnable_;
		}
		set
		{
			remoteObserveEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RemoteObservePassword
	{
		get
		{
			return remoteObservePassword_;
		}
		set
		{
			remoteObservePassword_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool StageEnable
	{
		get
		{
			return stageEnable_;
		}
		set
		{
			stageEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string StagePassword
	{
		get
		{
			return stagePassword_;
		}
		set
		{
			stagePassword_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LinkEnable
	{
		get
		{
			return linkEnable_;
		}
		set
		{
			linkEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string WebResourceRoot
	{
		get
		{
			return webResourceRoot_;
		}
		set
		{
			webResourceRoot_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint TcpStreamPort
	{
		get
		{
			return tcpStreamPort_;
		}
		set
		{
			tcpStreamPort_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool TcpStreamEnable
	{
		get
		{
			return tcpStreamEnable_;
		}
		set
		{
			tcpStreamEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirplayConfiguration Airplay
	{
		get
		{
			return airplay_;
		}
		set
		{
			airplay_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ProremoteWebsocketEnable
	{
		get
		{
			return proremoteWebsocketEnable_;
		}
		set
		{
			proremoteWebsocketEnable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ProremoteWebsocketPassword
	{
		get
		{
			return proremoteWebsocketPassword_;
		}
		set
		{
			proremoteWebsocketPassword_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiNetworkConfiguration()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiNetworkConfiguration(ProApiNetworkConfiguration other)
		: this()
	{
		enableNetwork_ = other.enableNetwork_;
		port_ = other.port_;
		networkName_ = other.networkName_;
		remoteEnable_ = other.remoteEnable_;
		remoteControlEnable_ = other.remoteControlEnable_;
		remoteControlPassword_ = other.remoteControlPassword_;
		remoteObserveEnable_ = other.remoteObserveEnable_;
		remoteObservePassword_ = other.remoteObservePassword_;
		stageEnable_ = other.stageEnable_;
		stagePassword_ = other.stagePassword_;
		linkEnable_ = other.linkEnable_;
		webResourceRoot_ = other.webResourceRoot_;
		tcpStreamPort_ = other.tcpStreamPort_;
		tcpStreamEnable_ = other.tcpStreamEnable_;
		airplay_ = ((other.airplay_ != null) ? other.airplay_.Clone() : null);
		proremoteWebsocketEnable_ = other.proremoteWebsocketEnable_;
		proremoteWebsocketPassword_ = other.proremoteWebsocketPassword_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiNetworkConfiguration Clone()
	{
		return new ProApiNetworkConfiguration(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProApiNetworkConfiguration);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProApiNetworkConfiguration other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (EnableNetwork != other.EnableNetwork)
		{
			return false;
		}
		if (Port != other.Port)
		{
			return false;
		}
		if (NetworkName != other.NetworkName)
		{
			return false;
		}
		if (RemoteEnable != other.RemoteEnable)
		{
			return false;
		}
		if (RemoteControlEnable != other.RemoteControlEnable)
		{
			return false;
		}
		if (RemoteControlPassword != other.RemoteControlPassword)
		{
			return false;
		}
		if (RemoteObserveEnable != other.RemoteObserveEnable)
		{
			return false;
		}
		if (RemoteObservePassword != other.RemoteObservePassword)
		{
			return false;
		}
		if (StageEnable != other.StageEnable)
		{
			return false;
		}
		if (StagePassword != other.StagePassword)
		{
			return false;
		}
		if (LinkEnable != other.LinkEnable)
		{
			return false;
		}
		if (WebResourceRoot != other.WebResourceRoot)
		{
			return false;
		}
		if (TcpStreamPort != other.TcpStreamPort)
		{
			return false;
		}
		if (TcpStreamEnable != other.TcpStreamEnable)
		{
			return false;
		}
		if (!object.Equals(Airplay, other.Airplay))
		{
			return false;
		}
		if (ProremoteWebsocketEnable != other.ProremoteWebsocketEnable)
		{
			return false;
		}
		if (ProremoteWebsocketPassword != other.ProremoteWebsocketPassword)
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
		if (EnableNetwork)
		{
			num ^= EnableNetwork.GetHashCode();
		}
		if (Port != 0)
		{
			num ^= Port.GetHashCode();
		}
		if (NetworkName.Length != 0)
		{
			num ^= NetworkName.GetHashCode();
		}
		if (RemoteEnable)
		{
			num ^= RemoteEnable.GetHashCode();
		}
		if (RemoteControlEnable)
		{
			num ^= RemoteControlEnable.GetHashCode();
		}
		if (RemoteControlPassword.Length != 0)
		{
			num ^= RemoteControlPassword.GetHashCode();
		}
		if (RemoteObserveEnable)
		{
			num ^= RemoteObserveEnable.GetHashCode();
		}
		if (RemoteObservePassword.Length != 0)
		{
			num ^= RemoteObservePassword.GetHashCode();
		}
		if (StageEnable)
		{
			num ^= StageEnable.GetHashCode();
		}
		if (StagePassword.Length != 0)
		{
			num ^= StagePassword.GetHashCode();
		}
		if (LinkEnable)
		{
			num ^= LinkEnable.GetHashCode();
		}
		if (WebResourceRoot.Length != 0)
		{
			num ^= WebResourceRoot.GetHashCode();
		}
		if (TcpStreamPort != 0)
		{
			num ^= TcpStreamPort.GetHashCode();
		}
		if (TcpStreamEnable)
		{
			num ^= TcpStreamEnable.GetHashCode();
		}
		if (airplay_ != null)
		{
			num ^= Airplay.GetHashCode();
		}
		if (ProremoteWebsocketEnable)
		{
			num ^= ProremoteWebsocketEnable.GetHashCode();
		}
		if (ProremoteWebsocketPassword.Length != 0)
		{
			num ^= ProremoteWebsocketPassword.GetHashCode();
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
		if (EnableNetwork)
		{
			output.WriteRawTag(8);
			output.WriteBool(EnableNetwork);
		}
		if (Port != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(Port);
		}
		if (NetworkName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(NetworkName);
		}
		if (RemoteEnable)
		{
			output.WriteRawTag(32);
			output.WriteBool(RemoteEnable);
		}
		if (RemoteControlEnable)
		{
			output.WriteRawTag(40);
			output.WriteBool(RemoteControlEnable);
		}
		if (RemoteControlPassword.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(RemoteControlPassword);
		}
		if (RemoteObserveEnable)
		{
			output.WriteRawTag(56);
			output.WriteBool(RemoteObserveEnable);
		}
		if (RemoteObservePassword.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(RemoteObservePassword);
		}
		if (StageEnable)
		{
			output.WriteRawTag(72);
			output.WriteBool(StageEnable);
		}
		if (StagePassword.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(StagePassword);
		}
		if (LinkEnable)
		{
			output.WriteRawTag(88);
			output.WriteBool(LinkEnable);
		}
		if (WebResourceRoot.Length != 0)
		{
			output.WriteRawTag(98);
			output.WriteString(WebResourceRoot);
		}
		if (TcpStreamPort != 0)
		{
			output.WriteRawTag(104);
			output.WriteUInt32(TcpStreamPort);
		}
		if (TcpStreamEnable)
		{
			output.WriteRawTag(112);
			output.WriteBool(TcpStreamEnable);
		}
		if (airplay_ != null)
		{
			output.WriteRawTag(122);
			output.WriteMessage(Airplay);
		}
		if (ProremoteWebsocketEnable)
		{
			output.WriteRawTag(128, 1);
			output.WriteBool(ProremoteWebsocketEnable);
		}
		if (ProremoteWebsocketPassword.Length != 0)
		{
			output.WriteRawTag(138, 1);
			output.WriteString(ProremoteWebsocketPassword);
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
		if (EnableNetwork)
		{
			num += 2;
		}
		if (Port != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
		}
		if (NetworkName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(NetworkName);
		}
		if (RemoteEnable)
		{
			num += 2;
		}
		if (RemoteControlEnable)
		{
			num += 2;
		}
		if (RemoteControlPassword.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RemoteControlPassword);
		}
		if (RemoteObserveEnable)
		{
			num += 2;
		}
		if (RemoteObservePassword.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RemoteObservePassword);
		}
		if (StageEnable)
		{
			num += 2;
		}
		if (StagePassword.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(StagePassword);
		}
		if (LinkEnable)
		{
			num += 2;
		}
		if (WebResourceRoot.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WebResourceRoot);
		}
		if (TcpStreamPort != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(TcpStreamPort);
		}
		if (TcpStreamEnable)
		{
			num += 2;
		}
		if (airplay_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Airplay);
		}
		if (ProremoteWebsocketEnable)
		{
			num += 3;
		}
		if (ProremoteWebsocketPassword.Length != 0)
		{
			num += 2 + CodedOutputStream.ComputeStringSize(ProremoteWebsocketPassword);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProApiNetworkConfiguration other)
	{
		if (other == null)
		{
			return;
		}
		if (other.EnableNetwork)
		{
			EnableNetwork = other.EnableNetwork;
		}
		if (other.Port != 0)
		{
			Port = other.Port;
		}
		if (other.NetworkName.Length != 0)
		{
			NetworkName = other.NetworkName;
		}
		if (other.RemoteEnable)
		{
			RemoteEnable = other.RemoteEnable;
		}
		if (other.RemoteControlEnable)
		{
			RemoteControlEnable = other.RemoteControlEnable;
		}
		if (other.RemoteControlPassword.Length != 0)
		{
			RemoteControlPassword = other.RemoteControlPassword;
		}
		if (other.RemoteObserveEnable)
		{
			RemoteObserveEnable = other.RemoteObserveEnable;
		}
		if (other.RemoteObservePassword.Length != 0)
		{
			RemoteObservePassword = other.RemoteObservePassword;
		}
		if (other.StageEnable)
		{
			StageEnable = other.StageEnable;
		}
		if (other.StagePassword.Length != 0)
		{
			StagePassword = other.StagePassword;
		}
		if (other.LinkEnable)
		{
			LinkEnable = other.LinkEnable;
		}
		if (other.WebResourceRoot.Length != 0)
		{
			WebResourceRoot = other.WebResourceRoot;
		}
		if (other.TcpStreamPort != 0)
		{
			TcpStreamPort = other.TcpStreamPort;
		}
		if (other.TcpStreamEnable)
		{
			TcpStreamEnable = other.TcpStreamEnable;
		}
		if (other.airplay_ != null)
		{
			if (airplay_ == null)
			{
				Airplay = new AirplayConfiguration();
			}
			Airplay.MergeFrom(other.Airplay);
		}
		if (other.ProremoteWebsocketEnable)
		{
			ProremoteWebsocketEnable = other.ProremoteWebsocketEnable;
		}
		if (other.ProremoteWebsocketPassword.Length != 0)
		{
			ProremoteWebsocketPassword = other.ProremoteWebsocketPassword;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
			case 8u:
				EnableNetwork = input.ReadBool();
				break;
			case 16u:
				Port = input.ReadUInt32();
				break;
			case 26u:
				NetworkName = input.ReadString();
				break;
			case 32u:
				RemoteEnable = input.ReadBool();
				break;
			case 40u:
				RemoteControlEnable = input.ReadBool();
				break;
			case 50u:
				RemoteControlPassword = input.ReadString();
				break;
			case 56u:
				RemoteObserveEnable = input.ReadBool();
				break;
			case 66u:
				RemoteObservePassword = input.ReadString();
				break;
			case 72u:
				StageEnable = input.ReadBool();
				break;
			case 82u:
				StagePassword = input.ReadString();
				break;
			case 88u:
				LinkEnable = input.ReadBool();
				break;
			case 98u:
				WebResourceRoot = input.ReadString();
				break;
			case 104u:
				TcpStreamPort = input.ReadUInt32();
				break;
			case 112u:
				TcpStreamEnable = input.ReadBool();
				break;
			case 122u:
				if (airplay_ == null)
				{
					Airplay = new AirplayConfiguration();
				}
				input.ReadMessage(Airplay);
				break;
			case 128u:
				ProremoteWebsocketEnable = input.ReadBool();
				break;
			case 138u:
				ProremoteWebsocketPassword = input.ReadString();
				break;
			}
		}
	}
}
