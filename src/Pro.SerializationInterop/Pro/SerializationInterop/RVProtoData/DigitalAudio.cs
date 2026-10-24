using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DigitalAudio : IMessage<DigitalAudio>, IMessage, IEquatable<DigitalAudio>, IDeepCloneable<DigitalAudio>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Setup : IMessage<Setup>, IMessage, IEquatable<Setup>, IDeepCloneable<Setup>
		{
			private static readonly MessageParser<Setup> _parser = new MessageParser<Setup>(() => new Setup());

			private UnknownFieldSet _unknownFields;

			public const int BusesFieldNumber = 1;

			private static readonly FieldCodec<Bus> _repeated_buses_codec = FieldCodec.ForMessage(10u, Bus.Parser);

			private readonly RepeatedField<Bus> buses_ = new RepeatedField<Bus>();

			public const int MonitorDeviceFieldNumber = 2;

			private Device monitorDevice_;

			public const int MainOutputDeviceFieldNumber = 3;

			private Device mainOutputDevice_;

			public const int EnableSdiNdiDeviceFieldNumber = 4;

			private bool enableSdiNdiDevice_;

			public const int SdiNdiDeviceFieldNumber = 5;

			private Device sdiNdiDevice_;

			public const int MonitorOnMainsFieldNumber = 6;

			private bool monitorOnMains_;

			public const int DisableMainOutputDeviceFieldNumber = 7;

			private bool disableMainOutputDevice_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Setup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => DigitalAudio.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Bus> Buses => buses_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device MonitorDevice
			{
				get
				{
					return monitorDevice_;
				}
				set
				{
					monitorDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device MainOutputDevice
			{
				get
				{
					return mainOutputDevice_;
				}
				set
				{
					mainOutputDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool EnableSdiNdiDevice
			{
				get
				{
					return enableSdiNdiDevice_;
				}
				set
				{
					enableSdiNdiDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device SdiNdiDevice
			{
				get
				{
					return sdiNdiDevice_;
				}
				set
				{
					sdiNdiDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool MonitorOnMains
			{
				get
				{
					return monitorOnMains_;
				}
				set
				{
					monitorOnMains_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool DisableMainOutputDevice
			{
				get
				{
					return disableMainOutputDevice_;
				}
				set
				{
					disableMainOutputDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Setup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Setup(Setup other)
				: this()
			{
				buses_ = other.buses_.Clone();
				monitorDevice_ = ((other.monitorDevice_ != null) ? other.monitorDevice_.Clone() : null);
				mainOutputDevice_ = ((other.mainOutputDevice_ != null) ? other.mainOutputDevice_.Clone() : null);
				enableSdiNdiDevice_ = other.enableSdiNdiDevice_;
				sdiNdiDevice_ = ((other.sdiNdiDevice_ != null) ? other.sdiNdiDevice_.Clone() : null);
				monitorOnMains_ = other.monitorOnMains_;
				disableMainOutputDevice_ = other.disableMainOutputDevice_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Setup Clone()
			{
				return new Setup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Setup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Setup other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!buses_.Equals(other.buses_))
				{
					return false;
				}
				if (!object.Equals(MonitorDevice, other.MonitorDevice))
				{
					return false;
				}
				if (!object.Equals(MainOutputDevice, other.MainOutputDevice))
				{
					return false;
				}
				if (EnableSdiNdiDevice != other.EnableSdiNdiDevice)
				{
					return false;
				}
				if (!object.Equals(SdiNdiDevice, other.SdiNdiDevice))
				{
					return false;
				}
				if (MonitorOnMains != other.MonitorOnMains)
				{
					return false;
				}
				if (DisableMainOutputDevice != other.DisableMainOutputDevice)
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
				num ^= buses_.GetHashCode();
				if (monitorDevice_ != null)
				{
					num ^= MonitorDevice.GetHashCode();
				}
				if (mainOutputDevice_ != null)
				{
					num ^= MainOutputDevice.GetHashCode();
				}
				if (EnableSdiNdiDevice)
				{
					num ^= EnableSdiNdiDevice.GetHashCode();
				}
				if (sdiNdiDevice_ != null)
				{
					num ^= SdiNdiDevice.GetHashCode();
				}
				if (MonitorOnMains)
				{
					num ^= MonitorOnMains.GetHashCode();
				}
				if (DisableMainOutputDevice)
				{
					num ^= DisableMainOutputDevice.GetHashCode();
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
				buses_.WriteTo(output, _repeated_buses_codec);
				if (monitorDevice_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(MonitorDevice);
				}
				if (mainOutputDevice_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(MainOutputDevice);
				}
				if (EnableSdiNdiDevice)
				{
					output.WriteRawTag(32);
					output.WriteBool(EnableSdiNdiDevice);
				}
				if (sdiNdiDevice_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(SdiNdiDevice);
				}
				if (MonitorOnMains)
				{
					output.WriteRawTag(48);
					output.WriteBool(MonitorOnMains);
				}
				if (DisableMainOutputDevice)
				{
					output.WriteRawTag(56);
					output.WriteBool(DisableMainOutputDevice);
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
				num += buses_.CalculateSize(_repeated_buses_codec);
				if (monitorDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MonitorDevice);
				}
				if (mainOutputDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MainOutputDevice);
				}
				if (EnableSdiNdiDevice)
				{
					num += 2;
				}
				if (sdiNdiDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SdiNdiDevice);
				}
				if (MonitorOnMains)
				{
					num += 2;
				}
				if (DisableMainOutputDevice)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Setup other)
			{
				if (other == null)
				{
					return;
				}
				buses_.Add(other.buses_);
				if (other.monitorDevice_ != null)
				{
					if (monitorDevice_ == null)
					{
						MonitorDevice = new Device();
					}
					MonitorDevice.MergeFrom(other.MonitorDevice);
				}
				if (other.mainOutputDevice_ != null)
				{
					if (mainOutputDevice_ == null)
					{
						MainOutputDevice = new Device();
					}
					MainOutputDevice.MergeFrom(other.MainOutputDevice);
				}
				if (other.EnableSdiNdiDevice)
				{
					EnableSdiNdiDevice = other.EnableSdiNdiDevice;
				}
				if (other.sdiNdiDevice_ != null)
				{
					if (sdiNdiDevice_ == null)
					{
						SdiNdiDevice = new Device();
					}
					SdiNdiDevice.MergeFrom(other.SdiNdiDevice);
				}
				if (other.MonitorOnMains)
				{
					MonitorOnMains = other.MonitorOnMains;
				}
				if (other.DisableMainOutputDevice)
				{
					DisableMainOutputDevice = other.DisableMainOutputDevice;
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
						buses_.AddEntriesFrom(input, _repeated_buses_codec);
						break;
					case 18u:
						if (monitorDevice_ == null)
						{
							MonitorDevice = new Device();
						}
						input.ReadMessage(MonitorDevice);
						break;
					case 26u:
						if (mainOutputDevice_ == null)
						{
							MainOutputDevice = new Device();
						}
						input.ReadMessage(MainOutputDevice);
						break;
					case 32u:
						EnableSdiNdiDevice = input.ReadBool();
						break;
					case 42u:
						if (sdiNdiDevice_ == null)
						{
							SdiNdiDevice = new Device();
						}
						input.ReadMessage(SdiNdiDevice);
						break;
					case 48u:
						MonitorOnMains = input.ReadBool();
						break;
					case 56u:
						DisableMainOutputDevice = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Bus : IMessage<Bus>, IMessage, IEquatable<Bus>, IDeepCloneable<Bus>
		{
			private static readonly MessageParser<Bus> _parser = new MessageParser<Bus>(() => new Bus());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int MutedFieldNumber = 2;

			private bool muted_;

			public const int SoloFieldNumber = 3;

			private bool solo_;

			public const int TestToneFieldNumber = 4;

			private bool testTone_;

			public const int MasterLevelFieldNumber = 5;

			private double masterLevel_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Bus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => DigitalAudio.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public bool Muted
			{
				get
				{
					return muted_;
				}
				set
				{
					muted_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Solo
			{
				get
				{
					return solo_;
				}
				set
				{
					solo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool TestTone
			{
				get
				{
					return testTone_;
				}
				set
				{
					testTone_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double MasterLevel
			{
				get
				{
					return masterLevel_;
				}
				set
				{
					masterLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Bus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Bus(Bus other)
				: this()
			{
				name_ = other.name_;
				muted_ = other.muted_;
				solo_ = other.solo_;
				testTone_ = other.testTone_;
				masterLevel_ = other.masterLevel_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Bus Clone()
			{
				return new Bus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Bus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Bus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Muted != other.Muted)
				{
					return false;
				}
				if (Solo != other.Solo)
				{
					return false;
				}
				if (TestTone != other.TestTone)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MasterLevel, other.MasterLevel))
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Muted)
				{
					num ^= Muted.GetHashCode();
				}
				if (Solo)
				{
					num ^= Solo.GetHashCode();
				}
				if (TestTone)
				{
					num ^= TestTone.GetHashCode();
				}
				if (MasterLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MasterLevel);
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (Muted)
				{
					output.WriteRawTag(16);
					output.WriteBool(Muted);
				}
				if (Solo)
				{
					output.WriteRawTag(24);
					output.WriteBool(Solo);
				}
				if (TestTone)
				{
					output.WriteRawTag(32);
					output.WriteBool(TestTone);
				}
				if (MasterLevel != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(MasterLevel);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Muted)
				{
					num += 2;
				}
				if (Solo)
				{
					num += 2;
				}
				if (TestTone)
				{
					num += 2;
				}
				if (MasterLevel != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Bus other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Muted)
					{
						Muted = other.Muted;
					}
					if (other.Solo)
					{
						Solo = other.Solo;
					}
					if (other.TestTone)
					{
						TestTone = other.TestTone;
					}
					if (other.MasterLevel != 0.0)
					{
						MasterLevel = other.MasterLevel;
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
						Name = input.ReadString();
						break;
					case 16u:
						Muted = input.ReadBool();
						break;
					case 24u:
						Solo = input.ReadBool();
						break;
					case 32u:
						TestTone = input.ReadBool();
						break;
					case 41u:
						MasterLevel = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Device : IMessage<Device>, IMessage, IEquatable<Device>, IDeepCloneable<Device>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Format : IMessage<Format>, IMessage, IEquatable<Format>, IDeepCloneable<Format>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Type
						{
							[OriginalName("TYPE_INT")]
							Int,
							[OriginalName("TYPE_FLOAT")]
							Float
						}
					}

					private static readonly MessageParser<Format> _parser = new MessageParser<Format>(() => new Format());

					private UnknownFieldSet _unknownFields;

					public const int SampleRateFieldNumber = 1;

					private uint sampleRate_;

					public const int BitDepthFieldNumber = 2;

					private uint bitDepth_;

					public const int TypeFieldNumber = 3;

					private Types.Type type_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Format> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Device.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint SampleRate
					{
						get
						{
							return sampleRate_;
						}
						set
						{
							sampleRate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint BitDepth
					{
						get
						{
							return bitDepth_;
						}
						set
						{
							bitDepth_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Type Type
					{
						get
						{
							return type_;
						}
						set
						{
							type_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Format()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Format(Format other)
						: this()
					{
						sampleRate_ = other.sampleRate_;
						bitDepth_ = other.bitDepth_;
						type_ = other.type_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Format Clone()
					{
						return new Format(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Format);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Format other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (SampleRate != other.SampleRate)
						{
							return false;
						}
						if (BitDepth != other.BitDepth)
						{
							return false;
						}
						if (Type != other.Type)
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
						if (SampleRate != 0)
						{
							num ^= SampleRate.GetHashCode();
						}
						if (BitDepth != 0)
						{
							num ^= BitDepth.GetHashCode();
						}
						if (Type != 0)
						{
							num ^= Type.GetHashCode();
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
						if (SampleRate != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(SampleRate);
						}
						if (BitDepth != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(BitDepth);
						}
						if (Type != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)Type);
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
						if (SampleRate != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(SampleRate);
						}
						if (BitDepth != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(BitDepth);
						}
						if (Type != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Format other)
					{
						if (other != null)
						{
							if (other.SampleRate != 0)
							{
								SampleRate = other.SampleRate;
							}
							if (other.BitDepth != 0)
							{
								BitDepth = other.BitDepth;
							}
							if (other.Type != 0)
							{
								Type = other.Type;
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
							case 8u:
								SampleRate = input.ReadUInt32();
								break;
							case 16u:
								BitDepth = input.ReadUInt32();
								break;
							case 24u:
								Type = (Types.Type)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Map : IMessage<Map>, IMessage, IEquatable<Map>, IDeepCloneable<Map>
				{
					private static readonly MessageParser<Map> _parser = new MessageParser<Map>(() => new Map());

					private UnknownFieldSet _unknownFields;

					public const int ChannelIndexFieldNumber = 1;

					private uint channelIndex_;

					public const int MappedIndicesFieldNumber = 2;

					private static readonly FieldCodec<uint> _repeated_mappedIndices_codec = FieldCodec.ForUInt32(18u);

					private readonly RepeatedField<uint> mappedIndices_ = new RepeatedField<uint>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Map> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Device.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint ChannelIndex
					{
						get
						{
							return channelIndex_;
						}
						set
						{
							channelIndex_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<uint> MappedIndices => mappedIndices_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Map()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Map(Map other)
						: this()
					{
						channelIndex_ = other.channelIndex_;
						mappedIndices_ = other.mappedIndices_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Map Clone()
					{
						return new Map(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Map);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Map other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ChannelIndex != other.ChannelIndex)
						{
							return false;
						}
						if (!mappedIndices_.Equals(other.mappedIndices_))
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
						if (ChannelIndex != 0)
						{
							num ^= ChannelIndex.GetHashCode();
						}
						num ^= mappedIndices_.GetHashCode();
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
						if (ChannelIndex != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(ChannelIndex);
						}
						mappedIndices_.WriteTo(output, _repeated_mappedIndices_codec);
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
						if (ChannelIndex != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(ChannelIndex);
						}
						num += mappedIndices_.CalculateSize(_repeated_mappedIndices_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Map other)
					{
						if (other != null)
						{
							if (other.ChannelIndex != 0)
							{
								ChannelIndex = other.ChannelIndex;
							}
							mappedIndices_.Add(other.mappedIndices_);
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
							case 8u:
								ChannelIndex = input.ReadUInt32();
								break;
							case 16u:
							case 18u:
								mappedIndices_.AddEntriesFrom(input, _repeated_mappedIndices_codec);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Channel : IMessage<Channel>, IMessage, IEquatable<Channel>, IDeepCloneable<Channel>
				{
					private static readonly MessageParser<Channel> _parser = new MessageParser<Channel>(() => new Channel());

					private UnknownFieldSet _unknownFields;

					public const int MuteEnableFieldNumber = 1;

					private bool muteEnable_;

					public const int SoloEnableFieldNumber = 2;

					private bool soloEnable_;

					public const int ToneEnableFieldNumber = 3;

					private bool toneEnable_;

					public const int AudioDelayFieldNumber = 4;

					private double audioDelay_;

					public const int LevelFieldNumber = 5;

					private double level_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Channel> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Device.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool MuteEnable
					{
						get
						{
							return muteEnable_;
						}
						set
						{
							muteEnable_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool SoloEnable
					{
						get
						{
							return soloEnable_;
						}
						set
						{
							soloEnable_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ToneEnable
					{
						get
						{
							return toneEnable_;
						}
						set
						{
							toneEnable_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double AudioDelay
					{
						get
						{
							return audioDelay_;
						}
						set
						{
							audioDelay_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Level
					{
						get
						{
							return level_;
						}
						set
						{
							level_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel(Channel other)
						: this()
					{
						muteEnable_ = other.muteEnable_;
						soloEnable_ = other.soloEnable_;
						toneEnable_ = other.toneEnable_;
						audioDelay_ = other.audioDelay_;
						level_ = other.level_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel Clone()
					{
						return new Channel(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Channel);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Channel other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (MuteEnable != other.MuteEnable)
						{
							return false;
						}
						if (SoloEnable != other.SoloEnable)
						{
							return false;
						}
						if (ToneEnable != other.ToneEnable)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AudioDelay, other.AudioDelay))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Level, other.Level))
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
						if (MuteEnable)
						{
							num ^= MuteEnable.GetHashCode();
						}
						if (SoloEnable)
						{
							num ^= SoloEnable.GetHashCode();
						}
						if (ToneEnable)
						{
							num ^= ToneEnable.GetHashCode();
						}
						if (AudioDelay != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AudioDelay);
						}
						if (Level != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Level);
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
						if (MuteEnable)
						{
							output.WriteRawTag(8);
							output.WriteBool(MuteEnable);
						}
						if (SoloEnable)
						{
							output.WriteRawTag(16);
							output.WriteBool(SoloEnable);
						}
						if (ToneEnable)
						{
							output.WriteRawTag(24);
							output.WriteBool(ToneEnable);
						}
						if (AudioDelay != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(AudioDelay);
						}
						if (Level != 0.0)
						{
							output.WriteRawTag(41);
							output.WriteDouble(Level);
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
						if (MuteEnable)
						{
							num += 2;
						}
						if (SoloEnable)
						{
							num += 2;
						}
						if (ToneEnable)
						{
							num += 2;
						}
						if (AudioDelay != 0.0)
						{
							num += 9;
						}
						if (Level != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Channel other)
					{
						if (other != null)
						{
							if (other.MuteEnable)
							{
								MuteEnable = other.MuteEnable;
							}
							if (other.SoloEnable)
							{
								SoloEnable = other.SoloEnable;
							}
							if (other.ToneEnable)
							{
								ToneEnable = other.ToneEnable;
							}
							if (other.AudioDelay != 0.0)
							{
								AudioDelay = other.AudioDelay;
							}
							if (other.Level != 0.0)
							{
								Level = other.Level;
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
							case 8u:
								MuteEnable = input.ReadBool();
								break;
							case 16u:
								SoloEnable = input.ReadBool();
								break;
							case 24u:
								ToneEnable = input.ReadBool();
								break;
							case 33u:
								AudioDelay = input.ReadDouble();
								break;
							case 41u:
								Level = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Routing : IMessage<Routing>, IMessage, IEquatable<Routing>, IDeepCloneable<Routing>
				{
					private static readonly MessageParser<Routing> _parser = new MessageParser<Routing>(() => new Routing());

					private UnknownFieldSet _unknownFields;

					public const int ChannelsFieldNumber = 1;

					private static readonly FieldCodec<Channel> _repeated_channels_codec = FieldCodec.ForMessage(10u, Channel.Parser);

					private readonly RepeatedField<Channel> channels_ = new RepeatedField<Channel>();

					public const int MapFieldNumber = 2;

					private static readonly FieldCodec<Map> _repeated_map_codec = FieldCodec.ForMessage(18u, Types.Map.Parser);

					private readonly RepeatedField<Map> map_ = new RepeatedField<Map>();

					public const int IsCustomMapFieldNumber = 3;

					private bool isCustomMap_;

					public const int MasterChannelFieldNumber = 4;

					private Channel masterChannel_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Routing> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Device.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Channel> Channels => channels_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Map> Map => map_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool IsCustomMap
					{
						get
						{
							return isCustomMap_;
						}
						set
						{
							isCustomMap_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel MasterChannel
					{
						get
						{
							return masterChannel_;
						}
						set
						{
							masterChannel_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Routing()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Routing(Routing other)
						: this()
					{
						channels_ = other.channels_.Clone();
						map_ = other.map_.Clone();
						isCustomMap_ = other.isCustomMap_;
						masterChannel_ = ((other.masterChannel_ != null) ? other.masterChannel_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Routing Clone()
					{
						return new Routing(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Routing);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Routing other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!channels_.Equals(other.channels_))
						{
							return false;
						}
						if (!map_.Equals(other.map_))
						{
							return false;
						}
						if (IsCustomMap != other.IsCustomMap)
						{
							return false;
						}
						if (!object.Equals(MasterChannel, other.MasterChannel))
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
						num ^= channels_.GetHashCode();
						num ^= map_.GetHashCode();
						if (IsCustomMap)
						{
							num ^= IsCustomMap.GetHashCode();
						}
						if (masterChannel_ != null)
						{
							num ^= MasterChannel.GetHashCode();
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
						channels_.WriteTo(output, _repeated_channels_codec);
						map_.WriteTo(output, _repeated_map_codec);
						if (IsCustomMap)
						{
							output.WriteRawTag(24);
							output.WriteBool(IsCustomMap);
						}
						if (masterChannel_ != null)
						{
							output.WriteRawTag(34);
							output.WriteMessage(MasterChannel);
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
						num += channels_.CalculateSize(_repeated_channels_codec);
						num += map_.CalculateSize(_repeated_map_codec);
						if (IsCustomMap)
						{
							num += 2;
						}
						if (masterChannel_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(MasterChannel);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Routing other)
					{
						if (other == null)
						{
							return;
						}
						channels_.Add(other.channels_);
						map_.Add(other.map_);
						if (other.IsCustomMap)
						{
							IsCustomMap = other.IsCustomMap;
						}
						if (other.masterChannel_ != null)
						{
							if (masterChannel_ == null)
							{
								MasterChannel = new Channel();
							}
							MasterChannel.MergeFrom(other.MasterChannel);
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
								channels_.AddEntriesFrom(input, _repeated_channels_codec);
								break;
							case 18u:
								map_.AddEntriesFrom(input, _repeated_map_codec);
								break;
							case 24u:
								IsCustomMap = input.ReadBool();
								break;
							case 34u:
								if (masterChannel_ == null)
								{
									MasterChannel = new Channel();
								}
								input.ReadMessage(MasterChannel);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Device> _parser = new MessageParser<Device>(() => new Device());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int RenderIDFieldNumber = 2;

			private string renderID_ = "";

			public const int FormatsFieldNumber = 3;

			private static readonly FieldCodec<Types.Format> _repeated_formats_codec = FieldCodec.ForMessage(26u, Types.Format.Parser);

			private readonly RepeatedField<Types.Format> formats_ = new RepeatedField<Types.Format>();

			public const int RoutingFieldNumber = 4;

			private Types.Routing routing_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Device> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => DigitalAudio.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public string RenderID
			{
				get
				{
					return renderID_;
				}
				set
				{
					renderID_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Format> Formats => formats_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Routing Routing
			{
				get
				{
					return routing_;
				}
				set
				{
					routing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device(Device other)
				: this()
			{
				name_ = other.name_;
				renderID_ = other.renderID_;
				formats_ = other.formats_.Clone();
				routing_ = ((other.routing_ != null) ? other.routing_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device Clone()
			{
				return new Device(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Device);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Device other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (RenderID != other.RenderID)
				{
					return false;
				}
				if (!formats_.Equals(other.formats_))
				{
					return false;
				}
				if (!object.Equals(Routing, other.Routing))
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (RenderID.Length != 0)
				{
					num ^= RenderID.GetHashCode();
				}
				num ^= formats_.GetHashCode();
				if (routing_ != null)
				{
					num ^= Routing.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (RenderID.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(RenderID);
				}
				formats_.WriteTo(output, _repeated_formats_codec);
				if (routing_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Routing);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (RenderID.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(RenderID);
				}
				num += formats_.CalculateSize(_repeated_formats_codec);
				if (routing_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Routing);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Device other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.RenderID.Length != 0)
				{
					RenderID = other.RenderID;
				}
				formats_.Add(other.formats_);
				if (other.routing_ != null)
				{
					if (routing_ == null)
					{
						Routing = new Types.Routing();
					}
					Routing.MergeFrom(other.Routing);
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
						Name = input.ReadString();
						break;
					case 18u:
						RenderID = input.ReadString();
						break;
					case 26u:
						formats_.AddEntriesFrom(input, _repeated_formats_codec);
						break;
					case 34u:
						if (routing_ == null)
						{
							Routing = new Types.Routing();
						}
						input.ReadMessage(Routing);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<DigitalAudio> _parser = new MessageParser<DigitalAudio>(() => new DigitalAudio());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DigitalAudio> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DigitalAudioReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio(DigitalAudio other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio Clone()
	{
		return new DigitalAudio(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DigitalAudio);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DigitalAudio other)
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
	public void MergeFrom(DigitalAudio other)
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
