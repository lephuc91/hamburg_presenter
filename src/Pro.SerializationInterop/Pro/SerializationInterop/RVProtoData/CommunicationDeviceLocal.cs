using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CommunicationDeviceLocal : IMessage<CommunicationDeviceLocal>, IMessage, IEquatable<CommunicationDeviceLocal>, IDeepCloneable<CommunicationDeviceLocal>
{
	public enum HardwareTypeOneofCase
	{
		None = 0,
		Serial = 6,
		TcpNetwork = 7,
		UdpNetwork = 8,
		Artnet = 9,
		Midi = 10
	}

	private static readonly MessageParser<CommunicationDeviceLocal> _parser = new MessageParser<CommunicationDeviceLocal>(() => new CommunicationDeviceLocal());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private UUID id_;

	public const int ConnectedFieldNumber = 2;

	private bool connected_;

	public const int AutoReconnectFieldNumber = 3;

	private bool autoReconnect_;

	public const int BundleNameFieldNumber = 4;

	private string bundleName_ = "";

	public const int BundleIdentifierFieldNumber = 5;

	private string bundleIdentifier_ = "";

	public const int SerialFieldNumber = 6;

	public const int TcpNetworkFieldNumber = 7;

	public const int UdpNetworkFieldNumber = 8;

	public const int ArtnetFieldNumber = 9;

	public const int MidiFieldNumber = 10;

	public const int OptionsFieldNumber = 11;

	private static readonly FieldCodec<CommunicationDeviceOption> _repeated_options_codec = FieldCodec.ForMessage(90u, CommunicationDeviceOption.Parser);

	private readonly RepeatedField<CommunicationDeviceOption> options_ = new RepeatedField<CommunicationDeviceOption>();

	private object hardwareType_;

	private HardwareTypeOneofCase hardwareTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CommunicationDeviceLocal> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Connected
	{
		get
		{
			return connected_;
		}
		set
		{
			connected_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AutoReconnect
	{
		get
		{
			return autoReconnect_;
		}
		set
		{
			autoReconnect_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BundleName
	{
		get
		{
			return bundleName_;
		}
		set
		{
			bundleName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BundleIdentifier
	{
		get
		{
			return bundleIdentifier_;
		}
		set
		{
			bundleIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.SerialHardware Serial
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Serial)
			{
				return null;
			}
			return (CommunicationDevice.Types.SerialHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.Serial : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.TCPHardware TcpNetwork
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.TcpNetwork)
			{
				return null;
			}
			return (CommunicationDevice.Types.TCPHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.TcpNetwork : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.UDPHardware UdpNetwork
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.UdpNetwork)
			{
				return null;
			}
			return (CommunicationDevice.Types.UDPHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.UdpNetwork : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.ArtnetHardware Artnet
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Artnet)
			{
				return null;
			}
			return (CommunicationDevice.Types.ArtnetHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.Artnet : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.MIDIHardware Midi
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Midi)
			{
				return null;
			}
			return (CommunicationDevice.Types.MIDIHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.Midi : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CommunicationDeviceOption> Options => options_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HardwareTypeOneofCase HardwareTypeCase => hardwareTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceLocal()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceLocal(CommunicationDeviceLocal other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		connected_ = other.connected_;
		autoReconnect_ = other.autoReconnect_;
		bundleName_ = other.bundleName_;
		bundleIdentifier_ = other.bundleIdentifier_;
		options_ = other.options_.Clone();
		switch (other.HardwareTypeCase)
		{
		case HardwareTypeOneofCase.Serial:
			Serial = other.Serial.Clone();
			break;
		case HardwareTypeOneofCase.TcpNetwork:
			TcpNetwork = other.TcpNetwork.Clone();
			break;
		case HardwareTypeOneofCase.UdpNetwork:
			UdpNetwork = other.UdpNetwork.Clone();
			break;
		case HardwareTypeOneofCase.Artnet:
			Artnet = other.Artnet.Clone();
			break;
		case HardwareTypeOneofCase.Midi:
			Midi = other.Midi.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceLocal Clone()
	{
		return new CommunicationDeviceLocal(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearHardwareType()
	{
		hardwareTypeCase_ = HardwareTypeOneofCase.None;
		hardwareType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CommunicationDeviceLocal);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CommunicationDeviceLocal other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (Connected != other.Connected)
		{
			return false;
		}
		if (AutoReconnect != other.AutoReconnect)
		{
			return false;
		}
		if (BundleName != other.BundleName)
		{
			return false;
		}
		if (BundleIdentifier != other.BundleIdentifier)
		{
			return false;
		}
		if (!object.Equals(Serial, other.Serial))
		{
			return false;
		}
		if (!object.Equals(TcpNetwork, other.TcpNetwork))
		{
			return false;
		}
		if (!object.Equals(UdpNetwork, other.UdpNetwork))
		{
			return false;
		}
		if (!object.Equals(Artnet, other.Artnet))
		{
			return false;
		}
		if (!object.Equals(Midi, other.Midi))
		{
			return false;
		}
		if (!options_.Equals(other.options_))
		{
			return false;
		}
		if (HardwareTypeCase != other.HardwareTypeCase)
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (Connected)
		{
			num ^= Connected.GetHashCode();
		}
		if (AutoReconnect)
		{
			num ^= AutoReconnect.GetHashCode();
		}
		if (BundleName.Length != 0)
		{
			num ^= BundleName.GetHashCode();
		}
		if (BundleIdentifier.Length != 0)
		{
			num ^= BundleIdentifier.GetHashCode();
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
		{
			num ^= Serial.GetHashCode();
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
		{
			num ^= TcpNetwork.GetHashCode();
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
		{
			num ^= UdpNetwork.GetHashCode();
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
		{
			num ^= Artnet.GetHashCode();
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
		{
			num ^= Midi.GetHashCode();
		}
		num ^= options_.GetHashCode();
		num ^= (int)hardwareTypeCase_;
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (Connected)
		{
			output.WriteRawTag(16);
			output.WriteBool(Connected);
		}
		if (AutoReconnect)
		{
			output.WriteRawTag(24);
			output.WriteBool(AutoReconnect);
		}
		if (BundleName.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(BundleName);
		}
		if (BundleIdentifier.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(BundleIdentifier);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Serial);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
		{
			output.WriteRawTag(58);
			output.WriteMessage(TcpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
		{
			output.WriteRawTag(66);
			output.WriteMessage(UdpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Artnet);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Midi);
		}
		options_.WriteTo(output, _repeated_options_codec);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (Connected)
		{
			num += 2;
		}
		if (AutoReconnect)
		{
			num += 2;
		}
		if (BundleName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BundleName);
		}
		if (BundleIdentifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BundleIdentifier);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Serial);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TcpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UdpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Artnet);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Midi);
		}
		num += options_.CalculateSize(_repeated_options_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CommunicationDeviceLocal other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new UUID();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Connected)
		{
			Connected = other.Connected;
		}
		if (other.AutoReconnect)
		{
			AutoReconnect = other.AutoReconnect;
		}
		if (other.BundleName.Length != 0)
		{
			BundleName = other.BundleName;
		}
		if (other.BundleIdentifier.Length != 0)
		{
			BundleIdentifier = other.BundleIdentifier;
		}
		options_.Add(other.options_);
		switch (other.HardwareTypeCase)
		{
		case HardwareTypeOneofCase.Serial:
			if (Serial == null)
			{
				Serial = new CommunicationDevice.Types.SerialHardware();
			}
			Serial.MergeFrom(other.Serial);
			break;
		case HardwareTypeOneofCase.TcpNetwork:
			if (TcpNetwork == null)
			{
				TcpNetwork = new CommunicationDevice.Types.TCPHardware();
			}
			TcpNetwork.MergeFrom(other.TcpNetwork);
			break;
		case HardwareTypeOneofCase.UdpNetwork:
			if (UdpNetwork == null)
			{
				UdpNetwork = new CommunicationDevice.Types.UDPHardware();
			}
			UdpNetwork.MergeFrom(other.UdpNetwork);
			break;
		case HardwareTypeOneofCase.Artnet:
			if (Artnet == null)
			{
				Artnet = new CommunicationDevice.Types.ArtnetHardware();
			}
			Artnet.MergeFrom(other.Artnet);
			break;
		case HardwareTypeOneofCase.Midi:
			if (Midi == null)
			{
				Midi = new CommunicationDevice.Types.MIDIHardware();
			}
			Midi.MergeFrom(other.Midi);
			break;
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
			case 10u:
				if (id_ == null)
				{
					Id = new UUID();
				}
				input.ReadMessage(Id);
				break;
			case 16u:
				Connected = input.ReadBool();
				break;
			case 24u:
				AutoReconnect = input.ReadBool();
				break;
			case 34u:
				BundleName = input.ReadString();
				break;
			case 42u:
				BundleIdentifier = input.ReadString();
				break;
			case 50u:
			{
				CommunicationDevice.Types.SerialHardware serialHardware = new CommunicationDevice.Types.SerialHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
				{
					serialHardware.MergeFrom(Serial);
				}
				input.ReadMessage(serialHardware);
				Serial = serialHardware;
				break;
			}
			case 58u:
			{
				CommunicationDevice.Types.TCPHardware tCPHardware = new CommunicationDevice.Types.TCPHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
				{
					tCPHardware.MergeFrom(TcpNetwork);
				}
				input.ReadMessage(tCPHardware);
				TcpNetwork = tCPHardware;
				break;
			}
			case 66u:
			{
				CommunicationDevice.Types.UDPHardware uDPHardware = new CommunicationDevice.Types.UDPHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
				{
					uDPHardware.MergeFrom(UdpNetwork);
				}
				input.ReadMessage(uDPHardware);
				UdpNetwork = uDPHardware;
				break;
			}
			case 74u:
			{
				CommunicationDevice.Types.ArtnetHardware artnetHardware = new CommunicationDevice.Types.ArtnetHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
				{
					artnetHardware.MergeFrom(Artnet);
				}
				input.ReadMessage(artnetHardware);
				Artnet = artnetHardware;
				break;
			}
			case 82u:
			{
				CommunicationDevice.Types.MIDIHardware mIDIHardware = new CommunicationDevice.Types.MIDIHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
				{
					mIDIHardware.MergeFrom(Midi);
				}
				input.ReadMessage(mIDIHardware);
				Midi = mIDIHardware;
				break;
			}
			case 90u:
				options_.AddEntriesFrom(input, _repeated_options_codec);
				break;
			}
		}
	}
}
