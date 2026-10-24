using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class KeyMapping : IMessage<KeyMapping>, IMessage, IEquatable<KeyMapping>, IDeepCloneable<KeyMapping>
{
	public enum TargetIdentifierOneofCase
	{
		None = 0,
		MenuItem = 100,
		ClearGroupIdentifier = 101,
		CueIdentifier = 102,
		GroupIdentifier = 103,
		MacroIdentifier = 104,
		PropIdentifier = 105,
		TimerIdentifier = 106
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ComputerKeyboard : IMessage<ComputerKeyboard>, IMessage, IEquatable<ComputerKeyboard>, IDeepCloneable<ComputerKeyboard>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ModifierFlags
				{
					[OriginalName("MODIFIERFLAGS_COMMAND_KEY")]
					CommandKey,
					[OriginalName("MODIFIERFLAGS_SHIFT_KEY")]
					ShiftKey,
					[OriginalName("MODIFIERFLAGS_OPTION_KEY")]
					OptionKey,
					[OriginalName("MODIFIERFLAGS_CONTROL_KEY")]
					ControlKey,
					[OriginalName("MODIFIERFLAGS_FUNCTION_KEY")]
					FunctionKey
				}
			}

			private static readonly MessageParser<ComputerKeyboard> _parser = new MessageParser<ComputerKeyboard>(() => new ComputerKeyboard());

			private UnknownFieldSet _unknownFields;

			public const int KeyEquivalentFieldNumber = 1;

			private string keyEquivalent_ = "";

			public const int KeyEquivalentModifierFlagsFieldNumber = 2;

			private static readonly FieldCodec<Types.ModifierFlags> _repeated_keyEquivalentModifierFlags_codec = FieldCodec.ForEnum(18u, (Types.ModifierFlags x) => (int)x, (int x) => (Types.ModifierFlags)x);

			private readonly RepeatedField<Types.ModifierFlags> keyEquivalentModifierFlags_ = new RepeatedField<Types.ModifierFlags>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ComputerKeyboard> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => KeyMapping.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string KeyEquivalent
			{
				get
				{
					return keyEquivalent_;
				}
				set
				{
					keyEquivalent_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ModifierFlags> KeyEquivalentModifierFlags => keyEquivalentModifierFlags_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ComputerKeyboard()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ComputerKeyboard(ComputerKeyboard other)
				: this()
			{
				keyEquivalent_ = other.keyEquivalent_;
				keyEquivalentModifierFlags_ = other.keyEquivalentModifierFlags_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ComputerKeyboard Clone()
			{
				return new ComputerKeyboard(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ComputerKeyboard);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ComputerKeyboard other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (KeyEquivalent != other.KeyEquivalent)
				{
					return false;
				}
				if (!keyEquivalentModifierFlags_.Equals(other.keyEquivalentModifierFlags_))
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
				if (KeyEquivalent.Length != 0)
				{
					num ^= KeyEquivalent.GetHashCode();
				}
				num ^= keyEquivalentModifierFlags_.GetHashCode();
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
				if (KeyEquivalent.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(KeyEquivalent);
				}
				keyEquivalentModifierFlags_.WriteTo(output, _repeated_keyEquivalentModifierFlags_codec);
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
				if (KeyEquivalent.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(KeyEquivalent);
				}
				num += keyEquivalentModifierFlags_.CalculateSize(_repeated_keyEquivalentModifierFlags_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ComputerKeyboard other)
			{
				if (other != null)
				{
					if (other.KeyEquivalent.Length != 0)
					{
						KeyEquivalent = other.KeyEquivalent;
					}
					keyEquivalentModifierFlags_.Add(other.keyEquivalentModifierFlags_);
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
						KeyEquivalent = input.ReadString();
						break;
					case 16u:
					case 18u:
						keyEquivalentModifierFlags_.AddEntriesFrom(input, _repeated_keyEquivalentModifierFlags_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MIDIKeyboard : IMessage<MIDIKeyboard>, IMessage, IEquatable<MIDIKeyboard>, IDeepCloneable<MIDIKeyboard>
		{
			private static readonly MessageParser<MIDIKeyboard> _parser = new MessageParser<MIDIKeyboard>(() => new MIDIKeyboard());

			private UnknownFieldSet _unknownFields;

			public const int ChannelFieldNumber = 1;

			private int channel_;

			public const int PitchFieldNumber = 2;

			private int pitch_;

			public const int VelocityFieldNumber = 3;

			private int velocity_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MIDIKeyboard> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => KeyMapping.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Channel
			{
				get
				{
					return channel_;
				}
				set
				{
					channel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Pitch
			{
				get
				{
					return pitch_;
				}
				set
				{
					pitch_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Velocity
			{
				get
				{
					return velocity_;
				}
				set
				{
					velocity_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIKeyboard()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIKeyboard(MIDIKeyboard other)
				: this()
			{
				channel_ = other.channel_;
				pitch_ = other.pitch_;
				velocity_ = other.velocity_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MIDIKeyboard Clone()
			{
				return new MIDIKeyboard(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MIDIKeyboard);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MIDIKeyboard other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Channel != other.Channel)
				{
					return false;
				}
				if (Pitch != other.Pitch)
				{
					return false;
				}
				if (Velocity != other.Velocity)
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
				if (Channel != 0)
				{
					num ^= Channel.GetHashCode();
				}
				if (Pitch != 0)
				{
					num ^= Pitch.GetHashCode();
				}
				if (Velocity != 0)
				{
					num ^= Velocity.GetHashCode();
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
				if (Channel != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Channel);
				}
				if (Pitch != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Pitch);
				}
				if (Velocity != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Velocity);
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
				if (Channel != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Channel);
				}
				if (Pitch != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Pitch);
				}
				if (Velocity != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Velocity);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MIDIKeyboard other)
			{
				if (other != null)
				{
					if (other.Channel != 0)
					{
						Channel = other.Channel;
					}
					if (other.Pitch != 0)
					{
						Pitch = other.Pitch;
					}
					if (other.Velocity != 0)
					{
						Velocity = other.Velocity;
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
						Channel = input.ReadInt32();
						break;
					case 16u:
						Pitch = input.ReadInt32();
						break;
					case 24u:
						Velocity = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<KeyMapping> _parser = new MessageParser<KeyMapping>(() => new KeyMapping());

	private UnknownFieldSet _unknownFields;

	public const int KeyboardFieldNumber = 1;

	private Types.ComputerKeyboard keyboard_;

	public const int MidiFieldNumber = 2;

	private Types.MIDIKeyboard midi_;

	public const int MenuItemFieldNumber = 100;

	public const int ClearGroupIdentifierFieldNumber = 101;

	public const int CueIdentifierFieldNumber = 102;

	public const int GroupIdentifierFieldNumber = 103;

	public const int MacroIdentifierFieldNumber = 104;

	public const int PropIdentifierFieldNumber = 105;

	public const int TimerIdentifierFieldNumber = 106;

	private object targetIdentifier_;

	private TargetIdentifierOneofCase targetIdentifierCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<KeyMapping> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => KeymappingReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ComputerKeyboard Keyboard
	{
		get
		{
			return keyboard_;
		}
		set
		{
			keyboard_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MIDIKeyboard Midi
	{
		get
		{
			return midi_;
		}
		set
		{
			midi_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MenuItem
	{
		get
		{
			if (!HasMenuItem)
			{
				return "";
			}
			return (string)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
			targetIdentifierCase_ = TargetIdentifierOneofCase.MenuItem;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasMenuItem => targetIdentifierCase_ == TargetIdentifierOneofCase.MenuItem;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType ClearGroupIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.ClearGroupIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.ClearGroupIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType CueIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.CueIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.CueIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType GroupIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.GroupIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.GroupIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType MacroIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.MacroIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.MacroIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType PropIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.PropIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.PropIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType TimerIdentifier
	{
		get
		{
			if (targetIdentifierCase_ != TargetIdentifierOneofCase.TimerIdentifier)
			{
				return null;
			}
			return (CollectionElementType)targetIdentifier_;
		}
		set
		{
			targetIdentifier_ = value;
			targetIdentifierCase_ = ((value != null) ? TargetIdentifierOneofCase.TimerIdentifier : TargetIdentifierOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TargetIdentifierOneofCase TargetIdentifierCase => targetIdentifierCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping(KeyMapping other)
		: this()
	{
		keyboard_ = ((other.keyboard_ != null) ? other.keyboard_.Clone() : null);
		midi_ = ((other.midi_ != null) ? other.midi_.Clone() : null);
		switch (other.TargetIdentifierCase)
		{
		case TargetIdentifierOneofCase.MenuItem:
			MenuItem = other.MenuItem;
			break;
		case TargetIdentifierOneofCase.ClearGroupIdentifier:
			ClearGroupIdentifier = other.ClearGroupIdentifier.Clone();
			break;
		case TargetIdentifierOneofCase.CueIdentifier:
			CueIdentifier = other.CueIdentifier.Clone();
			break;
		case TargetIdentifierOneofCase.GroupIdentifier:
			GroupIdentifier = other.GroupIdentifier.Clone();
			break;
		case TargetIdentifierOneofCase.MacroIdentifier:
			MacroIdentifier = other.MacroIdentifier.Clone();
			break;
		case TargetIdentifierOneofCase.PropIdentifier:
			PropIdentifier = other.PropIdentifier.Clone();
			break;
		case TargetIdentifierOneofCase.TimerIdentifier:
			TimerIdentifier = other.TimerIdentifier.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping Clone()
	{
		return new KeyMapping(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearMenuItem()
	{
		if (HasMenuItem)
		{
			ClearTargetIdentifier();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearTargetIdentifier()
	{
		targetIdentifierCase_ = TargetIdentifierOneofCase.None;
		targetIdentifier_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as KeyMapping);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(KeyMapping other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Keyboard, other.Keyboard))
		{
			return false;
		}
		if (!object.Equals(Midi, other.Midi))
		{
			return false;
		}
		if (MenuItem != other.MenuItem)
		{
			return false;
		}
		if (!object.Equals(ClearGroupIdentifier, other.ClearGroupIdentifier))
		{
			return false;
		}
		if (!object.Equals(CueIdentifier, other.CueIdentifier))
		{
			return false;
		}
		if (!object.Equals(GroupIdentifier, other.GroupIdentifier))
		{
			return false;
		}
		if (!object.Equals(MacroIdentifier, other.MacroIdentifier))
		{
			return false;
		}
		if (!object.Equals(PropIdentifier, other.PropIdentifier))
		{
			return false;
		}
		if (!object.Equals(TimerIdentifier, other.TimerIdentifier))
		{
			return false;
		}
		if (TargetIdentifierCase != other.TargetIdentifierCase)
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
		if (keyboard_ != null)
		{
			num ^= Keyboard.GetHashCode();
		}
		if (midi_ != null)
		{
			num ^= Midi.GetHashCode();
		}
		if (HasMenuItem)
		{
			num ^= MenuItem.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.ClearGroupIdentifier)
		{
			num ^= ClearGroupIdentifier.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.CueIdentifier)
		{
			num ^= CueIdentifier.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.GroupIdentifier)
		{
			num ^= GroupIdentifier.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.MacroIdentifier)
		{
			num ^= MacroIdentifier.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.PropIdentifier)
		{
			num ^= PropIdentifier.GetHashCode();
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.TimerIdentifier)
		{
			num ^= TimerIdentifier.GetHashCode();
		}
		num ^= (int)targetIdentifierCase_;
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
		if (keyboard_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Keyboard);
		}
		if (midi_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Midi);
		}
		if (HasMenuItem)
		{
			output.WriteRawTag(162, 6);
			output.WriteString(MenuItem);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.ClearGroupIdentifier)
		{
			output.WriteRawTag(170, 6);
			output.WriteMessage(ClearGroupIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.CueIdentifier)
		{
			output.WriteRawTag(178, 6);
			output.WriteMessage(CueIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.GroupIdentifier)
		{
			output.WriteRawTag(186, 6);
			output.WriteMessage(GroupIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.MacroIdentifier)
		{
			output.WriteRawTag(194, 6);
			output.WriteMessage(MacroIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.PropIdentifier)
		{
			output.WriteRawTag(202, 6);
			output.WriteMessage(PropIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.TimerIdentifier)
		{
			output.WriteRawTag(210, 6);
			output.WriteMessage(TimerIdentifier);
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
		if (keyboard_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Keyboard);
		}
		if (midi_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Midi);
		}
		if (HasMenuItem)
		{
			num += 2 + CodedOutputStream.ComputeStringSize(MenuItem);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.ClearGroupIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ClearGroupIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.CueIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CueIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.GroupIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GroupIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.MacroIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MacroIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.PropIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PropIdentifier);
		}
		if (targetIdentifierCase_ == TargetIdentifierOneofCase.TimerIdentifier)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimerIdentifier);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(KeyMapping other)
	{
		if (other == null)
		{
			return;
		}
		if (other.keyboard_ != null)
		{
			if (keyboard_ == null)
			{
				Keyboard = new Types.ComputerKeyboard();
			}
			Keyboard.MergeFrom(other.Keyboard);
		}
		if (other.midi_ != null)
		{
			if (midi_ == null)
			{
				Midi = new Types.MIDIKeyboard();
			}
			Midi.MergeFrom(other.Midi);
		}
		switch (other.TargetIdentifierCase)
		{
		case TargetIdentifierOneofCase.MenuItem:
			MenuItem = other.MenuItem;
			break;
		case TargetIdentifierOneofCase.ClearGroupIdentifier:
			if (ClearGroupIdentifier == null)
			{
				ClearGroupIdentifier = new CollectionElementType();
			}
			ClearGroupIdentifier.MergeFrom(other.ClearGroupIdentifier);
			break;
		case TargetIdentifierOneofCase.CueIdentifier:
			if (CueIdentifier == null)
			{
				CueIdentifier = new CollectionElementType();
			}
			CueIdentifier.MergeFrom(other.CueIdentifier);
			break;
		case TargetIdentifierOneofCase.GroupIdentifier:
			if (GroupIdentifier == null)
			{
				GroupIdentifier = new CollectionElementType();
			}
			GroupIdentifier.MergeFrom(other.GroupIdentifier);
			break;
		case TargetIdentifierOneofCase.MacroIdentifier:
			if (MacroIdentifier == null)
			{
				MacroIdentifier = new CollectionElementType();
			}
			MacroIdentifier.MergeFrom(other.MacroIdentifier);
			break;
		case TargetIdentifierOneofCase.PropIdentifier:
			if (PropIdentifier == null)
			{
				PropIdentifier = new CollectionElementType();
			}
			PropIdentifier.MergeFrom(other.PropIdentifier);
			break;
		case TargetIdentifierOneofCase.TimerIdentifier:
			if (TimerIdentifier == null)
			{
				TimerIdentifier = new CollectionElementType();
			}
			TimerIdentifier.MergeFrom(other.TimerIdentifier);
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
				if (keyboard_ == null)
				{
					Keyboard = new Types.ComputerKeyboard();
				}
				input.ReadMessage(Keyboard);
				break;
			case 18u:
				if (midi_ == null)
				{
					Midi = new Types.MIDIKeyboard();
				}
				input.ReadMessage(Midi);
				break;
			case 802u:
				MenuItem = input.ReadString();
				break;
			case 810u:
			{
				CollectionElementType collectionElementType5 = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.ClearGroupIdentifier)
				{
					collectionElementType5.MergeFrom(ClearGroupIdentifier);
				}
				input.ReadMessage(collectionElementType5);
				ClearGroupIdentifier = collectionElementType5;
				break;
			}
			case 818u:
			{
				CollectionElementType collectionElementType3 = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.CueIdentifier)
				{
					collectionElementType3.MergeFrom(CueIdentifier);
				}
				input.ReadMessage(collectionElementType3);
				CueIdentifier = collectionElementType3;
				break;
			}
			case 826u:
			{
				CollectionElementType collectionElementType6 = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.GroupIdentifier)
				{
					collectionElementType6.MergeFrom(GroupIdentifier);
				}
				input.ReadMessage(collectionElementType6);
				GroupIdentifier = collectionElementType6;
				break;
			}
			case 834u:
			{
				CollectionElementType collectionElementType4 = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.MacroIdentifier)
				{
					collectionElementType4.MergeFrom(MacroIdentifier);
				}
				input.ReadMessage(collectionElementType4);
				MacroIdentifier = collectionElementType4;
				break;
			}
			case 842u:
			{
				CollectionElementType collectionElementType2 = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.PropIdentifier)
				{
					collectionElementType2.MergeFrom(PropIdentifier);
				}
				input.ReadMessage(collectionElementType2);
				PropIdentifier = collectionElementType2;
				break;
			}
			case 850u:
			{
				CollectionElementType collectionElementType = new CollectionElementType();
				if (targetIdentifierCase_ == TargetIdentifierOneofCase.TimerIdentifier)
				{
					collectionElementType.MergeFrom(TimerIdentifier);
				}
				input.ReadMessage(collectionElementType);
				TimerIdentifier = collectionElementType;
				break;
			}
			}
		}
	}
}
