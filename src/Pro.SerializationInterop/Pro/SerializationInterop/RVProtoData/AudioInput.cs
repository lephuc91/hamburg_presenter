using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AudioInput : IMessage<AudioInput>, IMessage, IEquatable<AudioInput>, IDeepCloneable<AudioInput>
{
	public enum SourceOneofCase
	{
		None = 0,
		AudioDevice = 3,
		VideoDevice = 4
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BehaviorMode : IMessage<BehaviorMode>, IMessage, IEquatable<BehaviorMode>, IDeepCloneable<BehaviorMode>
		{
			public enum ModeOneofCase
			{
				None,
				On,
				Off,
				AutoOn,
				AutoOff
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class On : IMessage<On>, IMessage, IEquatable<On>, IDeepCloneable<On>
				{
					private static readonly MessageParser<On> _parser = new MessageParser<On>(() => new On());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<On> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BehaviorMode.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public On()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public On(On other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public On Clone()
					{
						return new On(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as On);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(On other)
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
					public void MergeFrom(On other)
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
				public sealed class Off : IMessage<Off>, IMessage, IEquatable<Off>, IDeepCloneable<Off>
				{
					private static readonly MessageParser<Off> _parser = new MessageParser<Off>(() => new Off());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Off> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BehaviorMode.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Off()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Off(Off other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Off Clone()
					{
						return new Off(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Off);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Off other)
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
					public void MergeFrom(Off other)
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
				public sealed class AutoOff : IMessage<AutoOff>, IMessage, IEquatable<AutoOff>, IDeepCloneable<AutoOff>
				{
					private static readonly MessageParser<AutoOff> _parser = new MessageParser<AutoOff>(() => new AutoOff());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AutoOff> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BehaviorMode.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOff()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOff(AutoOff other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOff Clone()
					{
						return new AutoOff(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AutoOff);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AutoOff other)
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
					public void MergeFrom(AutoOff other)
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
				public sealed class AutoOn : IMessage<AutoOn>, IMessage, IEquatable<AutoOn>, IDeepCloneable<AutoOn>
				{
					private static readonly MessageParser<AutoOn> _parser = new MessageParser<AutoOn>(() => new AutoOn());

					private UnknownFieldSet _unknownFields;

					public const int LinkedVideoInputsFieldNumber = 1;

					private static readonly FieldCodec<uint> _repeated_linkedVideoInputs_codec = FieldCodec.ForUInt32(10u);

					private readonly RepeatedField<uint> linkedVideoInputs_ = new RepeatedField<uint>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AutoOn> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BehaviorMode.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<uint> LinkedVideoInputs => linkedVideoInputs_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOn()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOn(AutoOn other)
						: this()
					{
						linkedVideoInputs_ = other.linkedVideoInputs_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoOn Clone()
					{
						return new AutoOn(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AutoOn);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AutoOn other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!linkedVideoInputs_.Equals(other.linkedVideoInputs_))
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
						num ^= linkedVideoInputs_.GetHashCode();
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
						linkedVideoInputs_.WriteTo(output, _repeated_linkedVideoInputs_codec);
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
						num += linkedVideoInputs_.CalculateSize(_repeated_linkedVideoInputs_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(AutoOn other)
					{
						if (other != null)
						{
							linkedVideoInputs_.Add(other.linkedVideoInputs_);
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
							if (num != 8 && num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								linkedVideoInputs_.AddEntriesFrom(input, _repeated_linkedVideoInputs_codec);
							}
						}
					}
				}
			}

			private static readonly MessageParser<BehaviorMode> _parser = new MessageParser<BehaviorMode>(() => new BehaviorMode());

			private UnknownFieldSet _unknownFields;

			public const int OnFieldNumber = 1;

			public const int OffFieldNumber = 2;

			public const int AutoOnFieldNumber = 3;

			public const int AutoOffFieldNumber = 4;

			private object mode_;

			private ModeOneofCase modeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BehaviorMode> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => AudioInput.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.On On
			{
				get
				{
					if (modeCase_ != ModeOneofCase.On)
					{
						return null;
					}
					return (Types.On)mode_;
				}
				set
				{
					mode_ = value;
					modeCase_ = ((value != null) ? ModeOneofCase.On : ModeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Off Off
			{
				get
				{
					if (modeCase_ != ModeOneofCase.Off)
					{
						return null;
					}
					return (Types.Off)mode_;
				}
				set
				{
					mode_ = value;
					modeCase_ = ((value != null) ? ModeOneofCase.Off : ModeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AutoOn AutoOn
			{
				get
				{
					if (modeCase_ != ModeOneofCase.AutoOn)
					{
						return null;
					}
					return (Types.AutoOn)mode_;
				}
				set
				{
					mode_ = value;
					modeCase_ = ((value != null) ? ModeOneofCase.AutoOn : ModeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AutoOff AutoOff
			{
				get
				{
					if (modeCase_ != ModeOneofCase.AutoOff)
					{
						return null;
					}
					return (Types.AutoOff)mode_;
				}
				set
				{
					mode_ = value;
					modeCase_ = ((value != null) ? ModeOneofCase.AutoOff : ModeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ModeOneofCase ModeCase => modeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BehaviorMode()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BehaviorMode(BehaviorMode other)
				: this()
			{
				switch (other.ModeCase)
				{
				case ModeOneofCase.On:
					On = other.On.Clone();
					break;
				case ModeOneofCase.Off:
					Off = other.Off.Clone();
					break;
				case ModeOneofCase.AutoOn:
					AutoOn = other.AutoOn.Clone();
					break;
				case ModeOneofCase.AutoOff:
					AutoOff = other.AutoOff.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BehaviorMode Clone()
			{
				return new BehaviorMode(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearMode()
			{
				modeCase_ = ModeOneofCase.None;
				mode_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BehaviorMode);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BehaviorMode other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(On, other.On))
				{
					return false;
				}
				if (!object.Equals(Off, other.Off))
				{
					return false;
				}
				if (!object.Equals(AutoOn, other.AutoOn))
				{
					return false;
				}
				if (!object.Equals(AutoOff, other.AutoOff))
				{
					return false;
				}
				if (ModeCase != other.ModeCase)
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
				if (modeCase_ == ModeOneofCase.On)
				{
					num ^= On.GetHashCode();
				}
				if (modeCase_ == ModeOneofCase.Off)
				{
					num ^= Off.GetHashCode();
				}
				if (modeCase_ == ModeOneofCase.AutoOn)
				{
					num ^= AutoOn.GetHashCode();
				}
				if (modeCase_ == ModeOneofCase.AutoOff)
				{
					num ^= AutoOff.GetHashCode();
				}
				num ^= (int)modeCase_;
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
				if (modeCase_ == ModeOneofCase.On)
				{
					output.WriteRawTag(10);
					output.WriteMessage(On);
				}
				if (modeCase_ == ModeOneofCase.Off)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Off);
				}
				if (modeCase_ == ModeOneofCase.AutoOn)
				{
					output.WriteRawTag(26);
					output.WriteMessage(AutoOn);
				}
				if (modeCase_ == ModeOneofCase.AutoOff)
				{
					output.WriteRawTag(34);
					output.WriteMessage(AutoOff);
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
				if (modeCase_ == ModeOneofCase.On)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(On);
				}
				if (modeCase_ == ModeOneofCase.Off)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Off);
				}
				if (modeCase_ == ModeOneofCase.AutoOn)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AutoOn);
				}
				if (modeCase_ == ModeOneofCase.AutoOff)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AutoOff);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BehaviorMode other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ModeCase)
				{
				case ModeOneofCase.On:
					if (On == null)
					{
						On = new Types.On();
					}
					On.MergeFrom(other.On);
					break;
				case ModeOneofCase.Off:
					if (Off == null)
					{
						Off = new Types.Off();
					}
					Off.MergeFrom(other.Off);
					break;
				case ModeOneofCase.AutoOn:
					if (AutoOn == null)
					{
						AutoOn = new Types.AutoOn();
					}
					AutoOn.MergeFrom(other.AutoOn);
					break;
				case ModeOneofCase.AutoOff:
					if (AutoOff == null)
					{
						AutoOff = new Types.AutoOff();
					}
					AutoOff.MergeFrom(other.AutoOff);
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
					{
						Types.On on = new Types.On();
						if (modeCase_ == ModeOneofCase.On)
						{
							on.MergeFrom(On);
						}
						input.ReadMessage(on);
						On = on;
						break;
					}
					case 18u:
					{
						Types.Off off = new Types.Off();
						if (modeCase_ == ModeOneofCase.Off)
						{
							off.MergeFrom(Off);
						}
						input.ReadMessage(off);
						Off = off;
						break;
					}
					case 26u:
					{
						Types.AutoOn autoOn = new Types.AutoOn();
						if (modeCase_ == ModeOneofCase.AutoOn)
						{
							autoOn.MergeFrom(AutoOn);
						}
						input.ReadMessage(autoOn);
						AutoOn = autoOn;
						break;
					}
					case 34u:
					{
						Types.AutoOff autoOff = new Types.AutoOff();
						if (modeCase_ == ModeOneofCase.AutoOff)
						{
							autoOff.MergeFrom(AutoOff);
						}
						input.ReadMessage(autoOff);
						AutoOff = autoOff;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<AudioInput> _parser = new MessageParser<AudioInput>(() => new AudioInput());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int UserDescriptionFieldNumber = 2;

	private string userDescription_ = "";

	public const int AudioDeviceFieldNumber = 3;

	public const int VideoDeviceFieldNumber = 4;

	public const int BehaviorModeFieldNumber = 5;

	private Types.BehaviorMode behaviorMode_;

	private object source_;

	private SourceOneofCase sourceCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AudioInput> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => InputReflection.Descriptor.MessageTypes[1];

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
	public string UserDescription
	{
		get
		{
			return userDescription_;
		}
		set
		{
			userDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio.Types.Device AudioDevice
	{
		get
		{
			if (sourceCase_ != SourceOneofCase.AudioDevice)
			{
				return null;
			}
			return (DigitalAudio.Types.Device)source_;
		}
		set
		{
			source_ = value;
			sourceCase_ = ((value != null) ? SourceOneofCase.AudioDevice : SourceOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media.Types.VideoDevice VideoDevice
	{
		get
		{
			if (sourceCase_ != SourceOneofCase.VideoDevice)
			{
				return null;
			}
			return (Media.Types.VideoDevice)source_;
		}
		set
		{
			source_ = value;
			sourceCase_ = ((value != null) ? SourceOneofCase.VideoDevice : SourceOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BehaviorMode BehaviorMode
	{
		get
		{
			return behaviorMode_;
		}
		set
		{
			behaviorMode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SourceOneofCase SourceCase => sourceCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInput()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInput(AudioInput other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		userDescription_ = other.userDescription_;
		behaviorMode_ = ((other.behaviorMode_ != null) ? other.behaviorMode_.Clone() : null);
		switch (other.SourceCase)
		{
		case SourceOneofCase.AudioDevice:
			AudioDevice = other.AudioDevice.Clone();
			break;
		case SourceOneofCase.VideoDevice:
			VideoDevice = other.VideoDevice.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInput Clone()
	{
		return new AudioInput(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearSource()
	{
		sourceCase_ = SourceOneofCase.None;
		source_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AudioInput);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AudioInput other)
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
		if (UserDescription != other.UserDescription)
		{
			return false;
		}
		if (!object.Equals(AudioDevice, other.AudioDevice))
		{
			return false;
		}
		if (!object.Equals(VideoDevice, other.VideoDevice))
		{
			return false;
		}
		if (!object.Equals(BehaviorMode, other.BehaviorMode))
		{
			return false;
		}
		if (SourceCase != other.SourceCase)
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
		if (UserDescription.Length != 0)
		{
			num ^= UserDescription.GetHashCode();
		}
		if (sourceCase_ == SourceOneofCase.AudioDevice)
		{
			num ^= AudioDevice.GetHashCode();
		}
		if (sourceCase_ == SourceOneofCase.VideoDevice)
		{
			num ^= VideoDevice.GetHashCode();
		}
		if (behaviorMode_ != null)
		{
			num ^= BehaviorMode.GetHashCode();
		}
		num ^= (int)sourceCase_;
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
		if (UserDescription.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(UserDescription);
		}
		if (sourceCase_ == SourceOneofCase.AudioDevice)
		{
			output.WriteRawTag(26);
			output.WriteMessage(AudioDevice);
		}
		if (sourceCase_ == SourceOneofCase.VideoDevice)
		{
			output.WriteRawTag(34);
			output.WriteMessage(VideoDevice);
		}
		if (behaviorMode_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(BehaviorMode);
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
		if (UserDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UserDescription);
		}
		if (sourceCase_ == SourceOneofCase.AudioDevice)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioDevice);
		}
		if (sourceCase_ == SourceOneofCase.VideoDevice)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VideoDevice);
		}
		if (behaviorMode_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BehaviorMode);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AudioInput other)
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
		if (other.UserDescription.Length != 0)
		{
			UserDescription = other.UserDescription;
		}
		if (other.behaviorMode_ != null)
		{
			if (behaviorMode_ == null)
			{
				BehaviorMode = new Types.BehaviorMode();
			}
			BehaviorMode.MergeFrom(other.BehaviorMode);
		}
		switch (other.SourceCase)
		{
		case SourceOneofCase.AudioDevice:
			if (AudioDevice == null)
			{
				AudioDevice = new DigitalAudio.Types.Device();
			}
			AudioDevice.MergeFrom(other.AudioDevice);
			break;
		case SourceOneofCase.VideoDevice:
			if (VideoDevice == null)
			{
				VideoDevice = new Media.Types.VideoDevice();
			}
			VideoDevice.MergeFrom(other.VideoDevice);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				UserDescription = input.ReadString();
				break;
			case 26u:
			{
				DigitalAudio.Types.Device device = new DigitalAudio.Types.Device();
				if (sourceCase_ == SourceOneofCase.AudioDevice)
				{
					device.MergeFrom(AudioDevice);
				}
				input.ReadMessage(device);
				AudioDevice = device;
				break;
			}
			case 34u:
			{
				Media.Types.VideoDevice videoDevice = new Media.Types.VideoDevice();
				if (sourceCase_ == SourceOneofCase.VideoDevice)
				{
					videoDevice.MergeFrom(VideoDevice);
				}
				input.ReadMessage(videoDevice);
				VideoDevice = videoDevice;
				break;
			}
			case 42u:
				if (behaviorMode_ == null)
				{
					BehaviorMode = new Types.BehaviorMode();
				}
				input.ReadMessage(BehaviorMode);
				break;
			}
		}
	}
}
