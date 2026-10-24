using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SettingsDocument : IMessage<SettingsDocument>, IMessage, IEquatable<SettingsDocument>, IDeepCloneable<SettingsDocument>
		{
			private static readonly MessageParser<SettingsDocument> _parser = new MessageParser<SettingsDocument>(() => new SettingsDocument());

			private UnknownFieldSet _unknownFields;

			public const int OutputSetupFieldNumber = 1;

			private OutputSetup outputSetup_;

			public const int MonitorDeviceFieldNumber = 2;

			private Device monitorDevice_;

			public const int MonitorOnMainsFieldNumber = 3;

			private bool monitorOnMains_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SettingsDocument> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OutputSetup OutputSetup
			{
				get
				{
					return outputSetup_;
				}
				set
				{
					outputSetup_ = value;
				}
			}

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
			public SettingsDocument()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument(SettingsDocument other)
				: this()
			{
				outputSetup_ = ((other.outputSetup_ != null) ? other.outputSetup_.Clone() : null);
				monitorDevice_ = ((other.monitorDevice_ != null) ? other.monitorDevice_.Clone() : null);
				monitorOnMains_ = other.monitorOnMains_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument Clone()
			{
				return new SettingsDocument(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SettingsDocument);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SettingsDocument other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(OutputSetup, other.OutputSetup))
				{
					return false;
				}
				if (!object.Equals(MonitorDevice, other.MonitorDevice))
				{
					return false;
				}
				if (MonitorOnMains != other.MonitorOnMains)
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
				if (outputSetup_ != null)
				{
					num ^= OutputSetup.GetHashCode();
				}
				if (monitorDevice_ != null)
				{
					num ^= MonitorDevice.GetHashCode();
				}
				if (MonitorOnMains)
				{
					num ^= MonitorOnMains.GetHashCode();
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
				if (outputSetup_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(OutputSetup);
				}
				if (monitorDevice_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(MonitorDevice);
				}
				if (MonitorOnMains)
				{
					output.WriteRawTag(24);
					output.WriteBool(MonitorOnMains);
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
				if (outputSetup_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(OutputSetup);
				}
				if (monitorDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MonitorDevice);
				}
				if (MonitorOnMains)
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
			public void MergeFrom(SettingsDocument other)
			{
				if (other == null)
				{
					return;
				}
				if (other.outputSetup_ != null)
				{
					if (outputSetup_ == null)
					{
						OutputSetup = new OutputSetup();
					}
					OutputSetup.MergeFrom(other.OutputSetup);
				}
				if (other.monitorDevice_ != null)
				{
					if (monitorDevice_ == null)
					{
						MonitorDevice = new Device();
					}
					MonitorDevice.MergeFrom(other.MonitorDevice);
				}
				if (other.MonitorOnMains)
				{
					MonitorOnMains = other.MonitorOnMains;
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
						if (outputSetup_ == null)
						{
							OutputSetup = new OutputSetup();
						}
						input.ReadMessage(OutputSetup);
						break;
					case 18u:
						if (monitorDevice_ == null)
						{
							MonitorDevice = new Device();
						}
						input.ReadMessage(MonitorDevice);
						break;
					case 24u:
						MonitorOnMains = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class OutputSetup : IMessage<OutputSetup>, IMessage, IEquatable<OutputSetup>, IDeepCloneable<OutputSetup>
		{
			private static readonly MessageParser<OutputSetup> _parser = new MessageParser<OutputSetup>(() => new OutputSetup());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int AudioDeviceFieldNumber = 2;

			private Device audioDevice_;

			public const int LogicalChannelsFieldNumber = 3;

			private static readonly FieldCodec<LogicalChannel> _repeated_logicalChannels_codec = FieldCodec.ForMessage(26u, LogicalChannel.Parser);

			private readonly RepeatedField<LogicalChannel> logicalChannels_ = new RepeatedField<LogicalChannel>();

			public const int AudioDelayFieldNumber = 4;

			private double audioDelay_;

			public const int MasterLevelFieldNumber = 5;

			private double masterLevel_;

			public const int PhysicalChanelsFieldNumber = 6;

			private static readonly FieldCodec<PhysicalChannel> _repeated_physicalChanels_codec = FieldCodec.ForMessage(50u, PhysicalChannel.Parser);

			private readonly RepeatedField<PhysicalChannel> physicalChanels_ = new RepeatedField<PhysicalChannel>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<OutputSetup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Device AudioDevice
			{
				get
				{
					return audioDevice_;
				}
				set
				{
					audioDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<LogicalChannel> LogicalChannels => logicalChannels_;

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
			public RepeatedField<PhysicalChannel> PhysicalChanels => physicalChanels_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OutputSetup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OutputSetup(OutputSetup other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				audioDevice_ = ((other.audioDevice_ != null) ? other.audioDevice_.Clone() : null);
				logicalChannels_ = other.logicalChannels_.Clone();
				audioDelay_ = other.audioDelay_;
				masterLevel_ = other.masterLevel_;
				physicalChanels_ = other.physicalChanels_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OutputSetup Clone()
			{
				return new OutputSetup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as OutputSetup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(OutputSetup other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (!object.Equals(AudioDevice, other.AudioDevice))
				{
					return false;
				}
				if (!logicalChannels_.Equals(other.logicalChannels_))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AudioDelay, other.AudioDelay))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MasterLevel, other.MasterLevel))
				{
					return false;
				}
				if (!physicalChanels_.Equals(other.physicalChanels_))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (audioDevice_ != null)
				{
					num ^= AudioDevice.GetHashCode();
				}
				num ^= logicalChannels_.GetHashCode();
				if (AudioDelay != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AudioDelay);
				}
				if (MasterLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MasterLevel);
				}
				num ^= physicalChanels_.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (audioDevice_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(AudioDevice);
				}
				logicalChannels_.WriteTo(output, _repeated_logicalChannels_codec);
				if (AudioDelay != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(AudioDelay);
				}
				if (MasterLevel != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(MasterLevel);
				}
				physicalChanels_.WriteTo(output, _repeated_physicalChanels_codec);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (audioDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioDevice);
				}
				num += logicalChannels_.CalculateSize(_repeated_logicalChannels_codec);
				if (AudioDelay != 0.0)
				{
					num += 9;
				}
				if (MasterLevel != 0.0)
				{
					num += 9;
				}
				num += physicalChanels_.CalculateSize(_repeated_physicalChanels_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(OutputSetup other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.audioDevice_ != null)
				{
					if (audioDevice_ == null)
					{
						AudioDevice = new Device();
					}
					AudioDevice.MergeFrom(other.AudioDevice);
				}
				logicalChannels_.Add(other.logicalChannels_);
				if (other.AudioDelay != 0.0)
				{
					AudioDelay = other.AudioDelay;
				}
				if (other.MasterLevel != 0.0)
				{
					MasterLevel = other.MasterLevel;
				}
				physicalChanels_.Add(other.physicalChanels_);
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
						if (audioDevice_ == null)
						{
							AudioDevice = new Device();
						}
						input.ReadMessage(AudioDevice);
						break;
					case 26u:
						logicalChannels_.AddEntriesFrom(input, _repeated_logicalChannels_codec);
						break;
					case 33u:
						AudioDelay = input.ReadDouble();
						break;
					case 41u:
						MasterLevel = input.ReadDouble();
						break;
					case 50u:
						physicalChanels_.AddEntriesFrom(input, _repeated_physicalChanels_codec);
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
			}

			private static readonly MessageParser<Device> _parser = new MessageParser<Device>(() => new Device());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int RenderIDFieldNumber = 2;

			private string renderID_ = "";

			public const int InputChannelCountFieldNumber = 3;

			private uint inputChannelCount_;

			public const int OutputChannelCountFieldNumber = 4;

			private uint outputChannelCount_;

			public const int FormatsFieldNumber = 5;

			private static readonly FieldCodec<Types.Format> _repeated_formats_codec = FieldCodec.ForMessage(42u, Types.Format.Parser);

			private readonly RepeatedField<Types.Format> formats_ = new RepeatedField<Types.Format>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Device> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[2];

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
			public uint InputChannelCount
			{
				get
				{
					return inputChannelCount_;
				}
				set
				{
					inputChannelCount_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint OutputChannelCount
			{
				get
				{
					return outputChannelCount_;
				}
				set
				{
					outputChannelCount_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Format> Formats => formats_;

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
				inputChannelCount_ = other.inputChannelCount_;
				outputChannelCount_ = other.outputChannelCount_;
				formats_ = other.formats_.Clone();
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
				if (InputChannelCount != other.InputChannelCount)
				{
					return false;
				}
				if (OutputChannelCount != other.OutputChannelCount)
				{
					return false;
				}
				if (!formats_.Equals(other.formats_))
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
				if (InputChannelCount != 0)
				{
					num ^= InputChannelCount.GetHashCode();
				}
				if (OutputChannelCount != 0)
				{
					num ^= OutputChannelCount.GetHashCode();
				}
				num ^= formats_.GetHashCode();
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
				if (InputChannelCount != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(InputChannelCount);
				}
				if (OutputChannelCount != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(OutputChannelCount);
				}
				formats_.WriteTo(output, _repeated_formats_codec);
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
				if (InputChannelCount != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(InputChannelCount);
				}
				if (OutputChannelCount != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(OutputChannelCount);
				}
				num += formats_.CalculateSize(_repeated_formats_codec);
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
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.RenderID.Length != 0)
					{
						RenderID = other.RenderID;
					}
					if (other.InputChannelCount != 0)
					{
						InputChannelCount = other.InputChannelCount;
					}
					if (other.OutputChannelCount != 0)
					{
						OutputChannelCount = other.OutputChannelCount;
					}
					formats_.Add(other.formats_);
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
					case 18u:
						RenderID = input.ReadString();
						break;
					case 24u:
						InputChannelCount = input.ReadUInt32();
						break;
					case 32u:
						OutputChannelCount = input.ReadUInt32();
						break;
					case 42u:
						formats_.AddEntriesFrom(input, _repeated_formats_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LogicalChannel : IMessage<LogicalChannel>, IMessage, IEquatable<LogicalChannel>, IDeepCloneable<LogicalChannel>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class OutputChannel : IMessage<OutputChannel>, IMessage, IEquatable<OutputChannel>, IDeepCloneable<OutputChannel>
				{
					private static readonly MessageParser<OutputChannel> _parser = new MessageParser<OutputChannel>(() => new OutputChannel());

					private UnknownFieldSet _unknownFields;

					public const int IndexFieldNumber = 1;

					private uint index_;

					public const int MutedFieldNumber = 2;

					private bool muted_;

					public const int SoloFieldNumber = 3;

					private bool solo_;

					public const int TestToneFieldNumber = 4;

					private bool testTone_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<OutputChannel> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => LogicalChannel.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Index
					{
						get
						{
							return index_;
						}
						set
						{
							index_ = value;
						}
					}

					[Obsolete]
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

					[Obsolete]
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

					[Obsolete]
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
					public OutputChannel()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputChannel(OutputChannel other)
						: this()
					{
						index_ = other.index_;
						muted_ = other.muted_;
						solo_ = other.solo_;
						testTone_ = other.testTone_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputChannel Clone()
					{
						return new OutputChannel(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as OutputChannel);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(OutputChannel other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Index != other.Index)
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
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
						if (Index != 0)
						{
							num ^= Index.GetHashCode();
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
						if (Index != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(Index);
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
						if (Index != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(OutputChannel other)
					{
						if (other != null)
						{
							if (other.Index != 0)
							{
								Index = other.Index;
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
								Index = input.ReadUInt32();
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
							}
						}
					}
				}
			}

			private static readonly MessageParser<LogicalChannel> _parser = new MessageParser<LogicalChannel>(() => new LogicalChannel());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int IndexFieldNumber = 3;

			private uint index_;

			public const int MutedFieldNumber = 4;

			private bool muted_;

			public const int PhysicalAudioChannelsFieldNumber = 5;

			private static readonly FieldCodec<Types.OutputChannel> _repeated_physicalAudioChannels_codec = FieldCodec.ForMessage(42u, Types.OutputChannel.Parser);

			private readonly RepeatedField<Types.OutputChannel> physicalAudioChannels_ = new RepeatedField<Types.OutputChannel>();

			public const int SoloFieldNumber = 6;

			private bool solo_;

			public const int TestToneFieldNumber = 7;

			private bool testTone_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LogicalChannel> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
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
			public uint Index
			{
				get
				{
					return index_;
				}
				set
				{
					index_ = value;
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
			public RepeatedField<Types.OutputChannel> PhysicalAudioChannels => physicalAudioChannels_;

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
			public LogicalChannel()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LogicalChannel(LogicalChannel other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				index_ = other.index_;
				muted_ = other.muted_;
				physicalAudioChannels_ = other.physicalAudioChannels_.Clone();
				solo_ = other.solo_;
				testTone_ = other.testTone_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LogicalChannel Clone()
			{
				return new LogicalChannel(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LogicalChannel);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LogicalChannel other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (Muted != other.Muted)
				{
					return false;
				}
				if (!physicalAudioChannels_.Equals(other.physicalAudioChannels_))
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
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
				}
				if (Muted)
				{
					num ^= Muted.GetHashCode();
				}
				num ^= physicalAudioChannels_.GetHashCode();
				if (Solo)
				{
					num ^= Solo.GetHashCode();
				}
				if (TestTone)
				{
					num ^= TestTone.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (Index != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(Index);
				}
				if (Muted)
				{
					output.WriteRawTag(32);
					output.WriteBool(Muted);
				}
				physicalAudioChannels_.WriteTo(output, _repeated_physicalAudioChannels_codec);
				if (Solo)
				{
					output.WriteRawTag(48);
					output.WriteBool(Solo);
				}
				if (TestTone)
				{
					output.WriteRawTag(56);
					output.WriteBool(TestTone);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (Muted)
				{
					num += 2;
				}
				num += physicalAudioChannels_.CalculateSize(_repeated_physicalAudioChannels_codec);
				if (Solo)
				{
					num += 2;
				}
				if (TestTone)
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
			public void MergeFrom(LogicalChannel other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.Index != 0)
				{
					Index = other.Index;
				}
				if (other.Muted)
				{
					Muted = other.Muted;
				}
				physicalAudioChannels_.Add(other.physicalAudioChannels_);
				if (other.Solo)
				{
					Solo = other.Solo;
				}
				if (other.TestTone)
				{
					TestTone = other.TestTone;
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 24u:
						Index = input.ReadUInt32();
						break;
					case 32u:
						Muted = input.ReadBool();
						break;
					case 42u:
						physicalAudioChannels_.AddEntriesFrom(input, _repeated_physicalAudioChannels_codec);
						break;
					case 48u:
						Solo = input.ReadBool();
						break;
					case 56u:
						TestTone = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PhysicalChannel : IMessage<PhysicalChannel>, IMessage, IEquatable<PhysicalChannel>, IDeepCloneable<PhysicalChannel>
		{
			private static readonly MessageParser<PhysicalChannel> _parser = new MessageParser<PhysicalChannel>(() => new PhysicalChannel());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int MuteEnableFieldNumber = 2;

			private bool muteEnable_;

			public const int SoloEnableFieldNumber = 3;

			private bool soloEnable_;

			public const int ToneEnableFieldNumber = 4;

			private bool toneEnable_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PhysicalChannel> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Index
			{
				get
				{
					return index_;
				}
				set
				{
					index_ = value;
				}
			}

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
			public PhysicalChannel()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PhysicalChannel(PhysicalChannel other)
				: this()
			{
				index_ = other.index_;
				muteEnable_ = other.muteEnable_;
				soloEnable_ = other.soloEnable_;
				toneEnable_ = other.toneEnable_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PhysicalChannel Clone()
			{
				return new PhysicalChannel(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PhysicalChannel);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PhysicalChannel other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Index != other.Index)
				{
					return false;
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
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
				}
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
				if (Index != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Index);
				}
				if (MuteEnable)
				{
					output.WriteRawTag(16);
					output.WriteBool(MuteEnable);
				}
				if (SoloEnable)
				{
					output.WriteRawTag(24);
					output.WriteBool(SoloEnable);
				}
				if (ToneEnable)
				{
					output.WriteRawTag(32);
					output.WriteBool(ToneEnable);
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
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PhysicalChannel other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
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
						Index = input.ReadUInt32();
						break;
					case 16u:
						MuteEnable = input.ReadBool();
						break;
					case 24u:
						SoloEnable = input.ReadBool();
						break;
					case 32u:
						ToneEnable = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Audio> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AudioReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio(Audio other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio Clone()
	{
		return new Audio(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Audio);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Audio other)
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
	public void MergeFrom(Audio other)
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
