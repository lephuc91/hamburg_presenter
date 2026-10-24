using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CommunicationDevice : IMessage<CommunicationDevice>, IMessage, IEquatable<CommunicationDevice>, IDeepCloneable<CommunicationDevice>
{
	public enum HardwareTypeOneofCase
	{
		None = 0,
		Serial = 7,
		TcpNetwork = 8,
		UdpNetwork = 9,
		Artnet = 10,
		Midi = 11
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum DeviceType
		{
			[OriginalName("DEVICE_TYPE_DMX")]
			Dmx,
			[OriginalName("DEVICE_TYPE_MIDI")]
			Midi,
			[OriginalName("DEVICE_TYPE_AMP")]
			Amp,
			[OriginalName("DEVICE_TYPE_CITP")]
			Citp,
			[OriginalName("DEVICE_TYPE_GLOBAL_CACHE")]
			GlobalCache,
			[OriginalName("DEVICE_TYPE_GVG100")]
			Gvg100,
			[OriginalName("DEVICE_TYPE_ROSSTALK")]
			Rosstalk,
			[OriginalName("DEVICE_TYPE_SONY_BVS")]
			SonyBvs,
			[OriginalName("DEVICE_TYPE_SONY_BVW")]
			SonyBvw,
			[OriginalName("DEVICE_TYPE_VDCP")]
			Vdcp,
			[OriginalName("DEVICE_TYPE_ALL_AMERICAN_8000")]
			AllAmerican8000,
			[OriginalName("DEVICE_TYPE_ALL_AMERICAN_9000")]
			AllAmerican9000,
			[OriginalName("DEVICE_TYPE_DAKTRONICS")]
			Daktronics,
			[OriginalName("DEVICE_TYPE_DAKTRONICS_TV")]
			DaktronicsTv,
			[OriginalName("DEVICE_TYPE_ELECTRO_MECH")]
			ElectroMech,
			[OriginalName("DEVICE_TYPE_EVERSAN")]
			Eversan,
			[OriginalName("DEVICE_TYPE_FAIR_PLAY_MP70")]
			FairPlayMp70,
			[OriginalName("DEVICE_TYPE_HARRIS")]
			Harris,
			[OriginalName("DEVICE_TYPE_JUGS")]
			Jugs,
			[OriginalName("DEVICE_TYPE_OES")]
			Oes,
			[OriginalName("DEVICE_TYPE_SCOREBIRD")]
			Scorebird,
			[OriginalName("DEVICE_TYPE_SCOREBOT")]
			Scorebot,
			[OriginalName("DEVICE_TYPE_STALKER")]
			Stalker,
			[OriginalName("DEVICE_TYPE_STAT_CREW")]
			StatCrew
		}

		public enum Behavior
		{
			[OriginalName("BEHAVIOR_CONTROLLER")]
			Controller,
			[OriginalName("BEHAVIOR_DEVICE")]
			Device
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SerialHardware : IMessage<SerialHardware>, IMessage, IEquatable<SerialHardware>, IDeepCloneable<SerialHardware>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Speed
				{
					[OriginalName("SPEED_1200")]
					_1200 = 0,
					[OriginalName("SPEED_1800")]
					_1800 = 1,
					[OriginalName("SPEED_2400")]
					_2400 = 2,
					[OriginalName("SPEED_4800")]
					_4800 = 3,
					[OriginalName("SPEED_7200")]
					_7200 = 4,
					[OriginalName("SPEED_9600")]
					_9600 = 5,
					[OriginalName("SPEED_14400")]
					_14400 = 7,
					[OriginalName("SPEED_19200")]
					_19200 = 8,
					[OriginalName("SPEED_28800")]
					_28800 = 9,
					[OriginalName("SPEED_38400")]
					_38400 = 10,
					[OriginalName("SPEED_57600")]
					_57600 = 11,
					[OriginalName("SPEED_62500")]
					_62500 = 12,
					[OriginalName("SPEED_76800")]
					_76800 = 13,
					[OriginalName("SPEED_115200")]
					_115200 = 14,
					[OriginalName("SPEED_230400")]
					_230400 = 15
				}

				public enum DataBits
				{
					[OriginalName("DATA_BITS_5")]
					_5,
					[OriginalName("DATA_BITS_6")]
					_6,
					[OriginalName("DATA_BITS_7")]
					_7,
					[OriginalName("DATA_BITS_8")]
					_8
				}

				public enum Parity
				{
					[OriginalName("PARITY_NONE")]
					None,
					[OriginalName("PARITY_ODD")]
					Odd,
					[OriginalName("PARITY_EVEN")]
					Even
				}

				public enum StopBits
				{
					[OriginalName("STOP_BITS_1")]
					_1,
					[OriginalName("STOP_BITS_2")]
					_2
				}

				public enum HFCI
				{
					[OriginalName("HFCI_NONE")]
					None,
					[OriginalName("HFCI_RTS")]
					Rts,
					[OriginalName("HFCI_DTR")]
					Dtr
				}

				public enum HFCO
				{
					[OriginalName("HFCO_NONE")]
					None,
					[OriginalName("HFCO_CTS")]
					Cts,
					[OriginalName("HFCO_DSR")]
					Dsr,
					[OriginalName("HFCO_CAR")]
					Car
				}
			}

			private static readonly MessageParser<SerialHardware> _parser = new MessageParser<SerialHardware>(() => new SerialHardware());

			private UnknownFieldSet _unknownFields;

			public const int InterfaceIdFieldNumber = 1;

			private string interfaceId_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int SpeedFieldNumber = 3;

			private Types.Speed speed_;

			public const int DataBitsFieldNumber = 4;

			private Types.DataBits dataBits_;

			public const int ParityFieldNumber = 5;

			private Types.Parity parity_;

			public const int StopBitsFieldNumber = 6;

			private Types.StopBits stopBits_;

			public const int HfciFieldNumber = 7;

			private Types.HFCI hfci_;

			public const int HfcoFieldNumber = 8;

			private Types.HFCO hfco_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SerialHardware> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDevice.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string InterfaceId
			{
				get
				{
					return interfaceId_;
				}
				set
				{
					interfaceId_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Types.Speed Speed
			{
				get
				{
					return speed_;
				}
				set
				{
					speed_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.DataBits DataBits
			{
				get
				{
					return dataBits_;
				}
				set
				{
					dataBits_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Parity Parity
			{
				get
				{
					return parity_;
				}
				set
				{
					parity_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.StopBits StopBits
			{
				get
				{
					return stopBits_;
				}
				set
				{
					stopBits_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.HFCI Hfci
			{
				get
				{
					return hfci_;
				}
				set
				{
					hfci_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.HFCO Hfco
			{
				get
				{
					return hfco_;
				}
				set
				{
					hfco_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SerialHardware()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SerialHardware(SerialHardware other)
				: this()
			{
				interfaceId_ = other.interfaceId_;
				name_ = other.name_;
				speed_ = other.speed_;
				dataBits_ = other.dataBits_;
				parity_ = other.parity_;
				stopBits_ = other.stopBits_;
				hfci_ = other.hfci_;
				hfco_ = other.hfco_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SerialHardware Clone()
			{
				return new SerialHardware(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SerialHardware);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SerialHardware other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (InterfaceId != other.InterfaceId)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Speed != other.Speed)
				{
					return false;
				}
				if (DataBits != other.DataBits)
				{
					return false;
				}
				if (Parity != other.Parity)
				{
					return false;
				}
				if (StopBits != other.StopBits)
				{
					return false;
				}
				if (Hfci != other.Hfci)
				{
					return false;
				}
				if (Hfco != other.Hfco)
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
				if (InterfaceId.Length != 0)
				{
					num ^= InterfaceId.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Speed != 0)
				{
					num ^= Speed.GetHashCode();
				}
				if (DataBits != 0)
				{
					num ^= DataBits.GetHashCode();
				}
				if (Parity != 0)
				{
					num ^= Parity.GetHashCode();
				}
				if (StopBits != 0)
				{
					num ^= StopBits.GetHashCode();
				}
				if (Hfci != 0)
				{
					num ^= Hfci.GetHashCode();
				}
				if (Hfco != 0)
				{
					num ^= Hfco.GetHashCode();
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
				if (InterfaceId.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(InterfaceId);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (Speed != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)Speed);
				}
				if (DataBits != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)DataBits);
				}
				if (Parity != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)Parity);
				}
				if (StopBits != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)StopBits);
				}
				if (Hfci != 0)
				{
					output.WriteRawTag(56);
					output.WriteEnum((int)Hfci);
				}
				if (Hfco != 0)
				{
					output.WriteRawTag(64);
					output.WriteEnum((int)Hfco);
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
				if (InterfaceId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(InterfaceId);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Speed != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Speed);
				}
				if (DataBits != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)DataBits);
				}
				if (Parity != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Parity);
				}
				if (StopBits != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)StopBits);
				}
				if (Hfci != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Hfci);
				}
				if (Hfco != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Hfco);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SerialHardware other)
			{
				if (other != null)
				{
					if (other.InterfaceId.Length != 0)
					{
						InterfaceId = other.InterfaceId;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Speed != 0)
					{
						Speed = other.Speed;
					}
					if (other.DataBits != 0)
					{
						DataBits = other.DataBits;
					}
					if (other.Parity != 0)
					{
						Parity = other.Parity;
					}
					if (other.StopBits != 0)
					{
						StopBits = other.StopBits;
					}
					if (other.Hfci != 0)
					{
						Hfci = other.Hfci;
					}
					if (other.Hfco != 0)
					{
						Hfco = other.Hfco;
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
						InterfaceId = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 24u:
						Speed = (Types.Speed)input.ReadEnum();
						break;
					case 32u:
						DataBits = (Types.DataBits)input.ReadEnum();
						break;
					case 40u:
						Parity = (Types.Parity)input.ReadEnum();
						break;
					case 48u:
						StopBits = (Types.StopBits)input.ReadEnum();
						break;
					case 56u:
						Hfci = (Types.HFCI)input.ReadEnum();
						break;
					case 64u:
						Hfco = (Types.HFCO)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TCPHardware : IMessage<TCPHardware>, IMessage, IEquatable<TCPHardware>, IDeepCloneable<TCPHardware>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Mode
				{
					[OriginalName("MODE_CONNECT_TO")]
					ConnectTo,
					[OriginalName("MODE_ACCEPT_ON")]
					AcceptOn
				}
			}

			private static readonly MessageParser<TCPHardware> _parser = new MessageParser<TCPHardware>(() => new TCPHardware());

			private UnknownFieldSet _unknownFields;

			public const int InterfaceIdFieldNumber = 1;

			private string interfaceId_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int AddressFieldNumber = 3;

			private string address_ = "";

			public const int PortFieldNumber = 4;

			private uint port_;

			public const int ModeFieldNumber = 5;

			private Types.Mode mode_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TCPHardware> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDevice.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string InterfaceId
			{
				get
				{
					return interfaceId_;
				}
				set
				{
					interfaceId_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public string Address
			{
				get
				{
					return address_;
				}
				set
				{
					address_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Types.Mode Mode
			{
				get
				{
					return mode_;
				}
				set
				{
					mode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TCPHardware()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TCPHardware(TCPHardware other)
				: this()
			{
				interfaceId_ = other.interfaceId_;
				name_ = other.name_;
				address_ = other.address_;
				port_ = other.port_;
				mode_ = other.mode_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TCPHardware Clone()
			{
				return new TCPHardware(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TCPHardware);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TCPHardware other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (InterfaceId != other.InterfaceId)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Address != other.Address)
				{
					return false;
				}
				if (Port != other.Port)
				{
					return false;
				}
				if (Mode != other.Mode)
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
				if (InterfaceId.Length != 0)
				{
					num ^= InterfaceId.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Address.Length != 0)
				{
					num ^= Address.GetHashCode();
				}
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
				}
				if (Mode != 0)
				{
					num ^= Mode.GetHashCode();
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
				if (InterfaceId.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(InterfaceId);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (Address.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Address);
				}
				if (Port != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(Port);
				}
				if (Mode != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)Mode);
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
				if (InterfaceId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(InterfaceId);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Address.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Address);
				}
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
				}
				if (Mode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TCPHardware other)
			{
				if (other != null)
				{
					if (other.InterfaceId.Length != 0)
					{
						InterfaceId = other.InterfaceId;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Address.Length != 0)
					{
						Address = other.Address;
					}
					if (other.Port != 0)
					{
						Port = other.Port;
					}
					if (other.Mode != 0)
					{
						Mode = other.Mode;
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
						InterfaceId = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						Address = input.ReadString();
						break;
					case 32u:
						Port = input.ReadUInt32();
						break;
					case 40u:
						Mode = (Types.Mode)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UDPHardware : IMessage<UDPHardware>, IMessage, IEquatable<UDPHardware>, IDeepCloneable<UDPHardware>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Mode
				{
					[OriginalName("MODE_CONNECT")]
					Connect,
					[OriginalName("MODE_LISTEN")]
					Listen,
					[OriginalName("MODE_MULTICAST_LISTEN")]
					MulticastListen,
					[OriginalName("MODE_BROADCAST")]
					Broadcast
				}
			}

			private static readonly MessageParser<UDPHardware> _parser = new MessageParser<UDPHardware>(() => new UDPHardware());

			private UnknownFieldSet _unknownFields;

			public const int InterfaceIdFieldNumber = 1;

			private string interfaceId_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int AddressFieldNumber = 3;

			private string address_ = "";

			public const int PortFieldNumber = 4;

			private uint port_;

			public const int ModeFieldNumber = 5;

			private Types.Mode mode_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UDPHardware> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDevice.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string InterfaceId
			{
				get
				{
					return interfaceId_;
				}
				set
				{
					interfaceId_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public string Address
			{
				get
				{
					return address_;
				}
				set
				{
					address_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Types.Mode Mode
			{
				get
				{
					return mode_;
				}
				set
				{
					mode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UDPHardware()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UDPHardware(UDPHardware other)
				: this()
			{
				interfaceId_ = other.interfaceId_;
				name_ = other.name_;
				address_ = other.address_;
				port_ = other.port_;
				mode_ = other.mode_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UDPHardware Clone()
			{
				return new UDPHardware(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UDPHardware);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UDPHardware other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (InterfaceId != other.InterfaceId)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Address != other.Address)
				{
					return false;
				}
				if (Port != other.Port)
				{
					return false;
				}
				if (Mode != other.Mode)
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
				if (InterfaceId.Length != 0)
				{
					num ^= InterfaceId.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Address.Length != 0)
				{
					num ^= Address.GetHashCode();
				}
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
				}
				if (Mode != 0)
				{
					num ^= Mode.GetHashCode();
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
				if (InterfaceId.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(InterfaceId);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (Address.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Address);
				}
				if (Port != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(Port);
				}
				if (Mode != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)Mode);
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
				if (InterfaceId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(InterfaceId);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Address.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Address);
				}
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
				}
				if (Mode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(UDPHardware other)
			{
				if (other != null)
				{
					if (other.InterfaceId.Length != 0)
					{
						InterfaceId = other.InterfaceId;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Address.Length != 0)
					{
						Address = other.Address;
					}
					if (other.Port != 0)
					{
						Port = other.Port;
					}
					if (other.Mode != 0)
					{
						Mode = other.Mode;
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
						InterfaceId = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						Address = input.ReadString();
						break;
					case 32u:
						Port = input.ReadUInt32();
						break;
					case 40u:
						Mode = (Types.Mode)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ArtnetHardware : IMessage<ArtnetHardware>, IMessage, IEquatable<ArtnetHardware>, IDeepCloneable<ArtnetHardware>
		{
			private static readonly MessageParser<ArtnetHardware> _parser = new MessageParser<ArtnetHardware>(() => new ArtnetHardware());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ArtnetHardware> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDevice.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ArtnetHardware()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ArtnetHardware(ArtnetHardware other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ArtnetHardware Clone()
			{
				return new ArtnetHardware(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ArtnetHardware);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ArtnetHardware other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ArtnetHardware other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MIDIHardware : IMessage<MIDIHardware>, IMessage, IEquatable<MIDIHardware>, IDeepCloneable<MIDIHardware>
		{
			private static readonly MessageParser<MIDIHardware> _parser = new MessageParser<MIDIHardware>(() => new MIDIHardware());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MIDIHardware> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDevice.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIHardware()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIHardware(MIDIHardware other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIHardware Clone()
			{
				return new MIDIHardware(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MIDIHardware);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MIDIHardware other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MIDIHardware other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}
	}

	private static readonly MessageParser<CommunicationDevice> _parser = new MessageParser<CommunicationDevice>(() => new CommunicationDevice());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private UUID id_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int DeviceTypeFieldNumber = 3;

	private Types.DeviceType deviceType_;

	public const int BehaviorFieldNumber = 4;

	private Types.Behavior behavior_;

	public const int ConnectedFieldNumber = 5;

	private bool connected_;

	public const int AutoReconnectFieldNumber = 6;

	private bool autoReconnect_;

	public const int SerialFieldNumber = 7;

	public const int TcpNetworkFieldNumber = 8;

	public const int UdpNetworkFieldNumber = 9;

	public const int ArtnetFieldNumber = 10;

	public const int MidiFieldNumber = 11;

	public const int OptionsFieldNumber = 12;

	private static readonly FieldCodec<CommunicationDeviceOption> _repeated_options_codec = FieldCodec.ForMessage(98u, CommunicationDeviceOption.Parser);

	private readonly RepeatedField<CommunicationDeviceOption> options_ = new RepeatedField<CommunicationDeviceOption>();

	private object hardwareType_;

	private HardwareTypeOneofCase hardwareTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CommunicationDevice> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[0];

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
	public Types.DeviceType DeviceType
	{
		get
		{
			return deviceType_;
		}
		set
		{
			deviceType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Behavior Behavior
	{
		get
		{
			return behavior_;
		}
		set
		{
			behavior_ = value;
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
	public Types.SerialHardware Serial
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Serial)
			{
				return null;
			}
			return (Types.SerialHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.Serial : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TCPHardware TcpNetwork
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.TcpNetwork)
			{
				return null;
			}
			return (Types.TCPHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.TcpNetwork : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UDPHardware UdpNetwork
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.UdpNetwork)
			{
				return null;
			}
			return (Types.UDPHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.UdpNetwork : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ArtnetHardware Artnet
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Artnet)
			{
				return null;
			}
			return (Types.ArtnetHardware)hardwareType_;
		}
		set
		{
			hardwareType_ = value;
			hardwareTypeCase_ = ((value != null) ? HardwareTypeOneofCase.Artnet : HardwareTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MIDIHardware Midi
	{
		get
		{
			if (hardwareTypeCase_ != HardwareTypeOneofCase.Midi)
			{
				return null;
			}
			return (Types.MIDIHardware)hardwareType_;
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
	public CommunicationDevice()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice(CommunicationDevice other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		name_ = other.name_;
		deviceType_ = other.deviceType_;
		behavior_ = other.behavior_;
		connected_ = other.connected_;
		autoReconnect_ = other.autoReconnect_;
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
	public CommunicationDevice Clone()
	{
		return new CommunicationDevice(this);
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
		return Equals(other as CommunicationDevice);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CommunicationDevice other)
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
		if (Name != other.Name)
		{
			return false;
		}
		if (DeviceType != other.DeviceType)
		{
			return false;
		}
		if (Behavior != other.Behavior)
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
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (DeviceType != 0)
		{
			num ^= DeviceType.GetHashCode();
		}
		if (Behavior != 0)
		{
			num ^= Behavior.GetHashCode();
		}
		if (Connected)
		{
			num ^= Connected.GetHashCode();
		}
		if (AutoReconnect)
		{
			num ^= AutoReconnect.GetHashCode();
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (DeviceType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)DeviceType);
		}
		if (Behavior != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Behavior);
		}
		if (Connected)
		{
			output.WriteRawTag(40);
			output.WriteBool(Connected);
		}
		if (AutoReconnect)
		{
			output.WriteRawTag(48);
			output.WriteBool(AutoReconnect);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Serial);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TcpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
		{
			output.WriteRawTag(74);
			output.WriteMessage(UdpNetwork);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Artnet);
		}
		if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
		{
			output.WriteRawTag(90);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (DeviceType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)DeviceType);
		}
		if (Behavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Behavior);
		}
		if (Connected)
		{
			num += 2;
		}
		if (AutoReconnect)
		{
			num += 2;
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
	public void MergeFrom(CommunicationDevice other)
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
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.DeviceType != 0)
		{
			DeviceType = other.DeviceType;
		}
		if (other.Behavior != 0)
		{
			Behavior = other.Behavior;
		}
		if (other.Connected)
		{
			Connected = other.Connected;
		}
		if (other.AutoReconnect)
		{
			AutoReconnect = other.AutoReconnect;
		}
		options_.Add(other.options_);
		switch (other.HardwareTypeCase)
		{
		case HardwareTypeOneofCase.Serial:
			if (Serial == null)
			{
				Serial = new Types.SerialHardware();
			}
			Serial.MergeFrom(other.Serial);
			break;
		case HardwareTypeOneofCase.TcpNetwork:
			if (TcpNetwork == null)
			{
				TcpNetwork = new Types.TCPHardware();
			}
			TcpNetwork.MergeFrom(other.TcpNetwork);
			break;
		case HardwareTypeOneofCase.UdpNetwork:
			if (UdpNetwork == null)
			{
				UdpNetwork = new Types.UDPHardware();
			}
			UdpNetwork.MergeFrom(other.UdpNetwork);
			break;
		case HardwareTypeOneofCase.Artnet:
			if (Artnet == null)
			{
				Artnet = new Types.ArtnetHardware();
			}
			Artnet.MergeFrom(other.Artnet);
			break;
		case HardwareTypeOneofCase.Midi:
			if (Midi == null)
			{
				Midi = new Types.MIDIHardware();
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
			case 18u:
				Name = input.ReadString();
				break;
			case 24u:
				DeviceType = (Types.DeviceType)input.ReadEnum();
				break;
			case 32u:
				Behavior = (Types.Behavior)input.ReadEnum();
				break;
			case 40u:
				Connected = input.ReadBool();
				break;
			case 48u:
				AutoReconnect = input.ReadBool();
				break;
			case 58u:
			{
				Types.SerialHardware serialHardware = new Types.SerialHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Serial)
				{
					serialHardware.MergeFrom(Serial);
				}
				input.ReadMessage(serialHardware);
				Serial = serialHardware;
				break;
			}
			case 66u:
			{
				Types.TCPHardware tCPHardware = new Types.TCPHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.TcpNetwork)
				{
					tCPHardware.MergeFrom(TcpNetwork);
				}
				input.ReadMessage(tCPHardware);
				TcpNetwork = tCPHardware;
				break;
			}
			case 74u:
			{
				Types.UDPHardware uDPHardware = new Types.UDPHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.UdpNetwork)
				{
					uDPHardware.MergeFrom(UdpNetwork);
				}
				input.ReadMessage(uDPHardware);
				UdpNetwork = uDPHardware;
				break;
			}
			case 82u:
			{
				Types.ArtnetHardware artnetHardware = new Types.ArtnetHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Artnet)
				{
					artnetHardware.MergeFrom(Artnet);
				}
				input.ReadMessage(artnetHardware);
				Artnet = artnetHardware;
				break;
			}
			case 90u:
			{
				Types.MIDIHardware mIDIHardware = new Types.MIDIHardware();
				if (hardwareTypeCase_ == HardwareTypeOneofCase.Midi)
				{
					mIDIHardware.MergeFrom(Midi);
				}
				input.ReadMessage(mIDIHardware);
				Midi = mIDIHardware;
				break;
			}
			case 98u:
				options_.AddEntriesFrom(input, _repeated_options_codec);
				break;
			}
		}
	}
}
