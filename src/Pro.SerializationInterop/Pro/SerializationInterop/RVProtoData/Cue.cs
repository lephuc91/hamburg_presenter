using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Cue : IMessage<Cue>, IMessage, IEquatable<Cue>, IDeepCloneable<Cue>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum CompletionTargetType
		{
			[OriginalName("COMPLETION_TARGET_TYPE_NONE")]
			None,
			[OriginalName("COMPLETION_TARGET_TYPE_NEXT")]
			Next,
			[OriginalName("COMPLETION_TARGET_TYPE_RANDOM")]
			Random,
			[OriginalName("COMPLETION_TARGET_TYPE_CUE")]
			Cue,
			[OriginalName("COMPLETION_TARGET_TYPE_FIRST")]
			First
		}

		public enum CompletionActionType
		{
			[OriginalName("COMPLETION_ACTION_TYPE_FIRST")]
			First,
			[OriginalName("COMPLETION_ACTION_TYPE_LAST")]
			Last,
			[OriginalName("COMPLETION_ACTION_TYPE_AFTER_ACTION")]
			AfterAction,
			[OriginalName("COMPLETION_ACTION_TYPE_AFTER_TIME")]
			AfterTime
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimecodeTime : IMessage<TimecodeTime>, IMessage, IEquatable<TimecodeTime>, IDeepCloneable<TimecodeTime>
		{
			private static readonly MessageParser<TimecodeTime> _parser = new MessageParser<TimecodeTime>(() => new TimecodeTime());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimecodeTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Cue.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeTime(TimecodeTime other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeTime Clone()
			{
				return new TimecodeTime(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimecodeTime);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimecodeTime other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
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
			public void MergeFrom(TimecodeTime other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}
	}

	private static readonly MessageParser<Cue> _parser = new MessageParser<Cue>(() => new Cue());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int CompletionTargetTypeFieldNumber = 3;

	private Types.CompletionTargetType completionTargetType_;

	public const int CompletionTargetUuidFieldNumber = 4;

	private UUID completionTargetUuid_;

	public const int CompletionActionTypeFieldNumber = 5;

	private Types.CompletionActionType completionActionType_;

	public const int CompletionActionUuidFieldNumber = 6;

	private UUID completionActionUuid_;

	public const int TriggerTimeFieldNumber = 7;

	private Types.TimecodeTime triggerTime_;

	public const int HotKeyFieldNumber = 8;

	private HotKey hotKey_;

	public const int ActionsFieldNumber = 10;

	private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(82u, Action.Parser);

	private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

	public const int PendingImportsFieldNumber = 11;

	private static readonly MapField<string, URLs>.Codec _map_pendingImports_codec = new MapField<string, URLs>.Codec(FieldCodec.ForString(10u, ""), FieldCodec.ForMessage(18u, URLs.Parser), 90u);

	private readonly MapField<string, URLs> pendingImports_ = new MapField<string, URLs>();

	public const int IsEnabledFieldNumber = 12;

	private bool isEnabled_;

	public const int CompletionTimeFieldNumber = 13;

	private double completionTime_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Cue> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CueReflection.Descriptor.MessageTypes[0];

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
	public Types.CompletionTargetType CompletionTargetType
	{
		get
		{
			return completionTargetType_;
		}
		set
		{
			completionTargetType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID CompletionTargetUuid
	{
		get
		{
			return completionTargetUuid_;
		}
		set
		{
			completionTargetUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CompletionActionType CompletionActionType
	{
		get
		{
			return completionActionType_;
		}
		set
		{
			completionActionType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID CompletionActionUuid
	{
		get
		{
			return completionActionUuid_;
		}
		set
		{
			completionActionUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimecodeTime TriggerTime
	{
		get
		{
			return triggerTime_;
		}
		set
		{
			triggerTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HotKey HotKey
	{
		get
		{
			return hotKey_;
		}
		set
		{
			hotKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Action> Actions => actions_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MapField<string, URLs> PendingImports => pendingImports_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsEnabled
	{
		get
		{
			return isEnabled_;
		}
		set
		{
			isEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double CompletionTime
	{
		get
		{
			return completionTime_;
		}
		set
		{
			completionTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue(Cue other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		completionTargetType_ = other.completionTargetType_;
		completionTargetUuid_ = ((other.completionTargetUuid_ != null) ? other.completionTargetUuid_.Clone() : null);
		completionActionType_ = other.completionActionType_;
		completionActionUuid_ = ((other.completionActionUuid_ != null) ? other.completionActionUuid_.Clone() : null);
		triggerTime_ = ((other.triggerTime_ != null) ? other.triggerTime_.Clone() : null);
		hotKey_ = ((other.hotKey_ != null) ? other.hotKey_.Clone() : null);
		actions_ = other.actions_.Clone();
		pendingImports_ = other.pendingImports_.Clone();
		isEnabled_ = other.isEnabled_;
		completionTime_ = other.completionTime_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue Clone()
	{
		return new Cue(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Cue);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Cue other)
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
		if (CompletionTargetType != other.CompletionTargetType)
		{
			return false;
		}
		if (!object.Equals(CompletionTargetUuid, other.CompletionTargetUuid))
		{
			return false;
		}
		if (CompletionActionType != other.CompletionActionType)
		{
			return false;
		}
		if (!object.Equals(CompletionActionUuid, other.CompletionActionUuid))
		{
			return false;
		}
		if (!object.Equals(TriggerTime, other.TriggerTime))
		{
			return false;
		}
		if (!object.Equals(HotKey, other.HotKey))
		{
			return false;
		}
		if (!actions_.Equals(other.actions_))
		{
			return false;
		}
		if (!PendingImports.Equals(other.PendingImports))
		{
			return false;
		}
		if (IsEnabled != other.IsEnabled)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CompletionTime, other.CompletionTime))
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
		if (CompletionTargetType != 0)
		{
			num ^= CompletionTargetType.GetHashCode();
		}
		if (completionTargetUuid_ != null)
		{
			num ^= CompletionTargetUuid.GetHashCode();
		}
		if (CompletionActionType != 0)
		{
			num ^= CompletionActionType.GetHashCode();
		}
		if (completionActionUuid_ != null)
		{
			num ^= CompletionActionUuid.GetHashCode();
		}
		if (triggerTime_ != null)
		{
			num ^= TriggerTime.GetHashCode();
		}
		if (hotKey_ != null)
		{
			num ^= HotKey.GetHashCode();
		}
		num ^= actions_.GetHashCode();
		num ^= PendingImports.GetHashCode();
		if (IsEnabled)
		{
			num ^= IsEnabled.GetHashCode();
		}
		if (CompletionTime != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CompletionTime);
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
		if (CompletionTargetType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)CompletionTargetType);
		}
		if (completionTargetUuid_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(CompletionTargetUuid);
		}
		if (CompletionActionType != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)CompletionActionType);
		}
		if (completionActionUuid_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(CompletionActionUuid);
		}
		if (triggerTime_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(TriggerTime);
		}
		if (hotKey_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(HotKey);
		}
		actions_.WriteTo(output, _repeated_actions_codec);
		pendingImports_.WriteTo(output, _map_pendingImports_codec);
		if (IsEnabled)
		{
			output.WriteRawTag(96);
			output.WriteBool(IsEnabled);
		}
		if (CompletionTime != 0.0)
		{
			output.WriteRawTag(105);
			output.WriteDouble(CompletionTime);
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
		if (CompletionTargetType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)CompletionTargetType);
		}
		if (completionTargetUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CompletionTargetUuid);
		}
		if (CompletionActionType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)CompletionActionType);
		}
		if (completionActionUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CompletionActionUuid);
		}
		if (triggerTime_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerTime);
		}
		if (hotKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HotKey);
		}
		num += actions_.CalculateSize(_repeated_actions_codec);
		num += pendingImports_.CalculateSize(_map_pendingImports_codec);
		if (IsEnabled)
		{
			num += 2;
		}
		if (CompletionTime != 0.0)
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
	public void MergeFrom(Cue other)
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
		if (other.CompletionTargetType != 0)
		{
			CompletionTargetType = other.CompletionTargetType;
		}
		if (other.completionTargetUuid_ != null)
		{
			if (completionTargetUuid_ == null)
			{
				CompletionTargetUuid = new UUID();
			}
			CompletionTargetUuid.MergeFrom(other.CompletionTargetUuid);
		}
		if (other.CompletionActionType != 0)
		{
			CompletionActionType = other.CompletionActionType;
		}
		if (other.completionActionUuid_ != null)
		{
			if (completionActionUuid_ == null)
			{
				CompletionActionUuid = new UUID();
			}
			CompletionActionUuid.MergeFrom(other.CompletionActionUuid);
		}
		if (other.triggerTime_ != null)
		{
			if (triggerTime_ == null)
			{
				TriggerTime = new Types.TimecodeTime();
			}
			TriggerTime.MergeFrom(other.TriggerTime);
		}
		if (other.hotKey_ != null)
		{
			if (hotKey_ == null)
			{
				HotKey = new HotKey();
			}
			HotKey.MergeFrom(other.HotKey);
		}
		actions_.Add(other.actions_);
		pendingImports_.MergeFrom(other.pendingImports_);
		if (other.IsEnabled)
		{
			IsEnabled = other.IsEnabled;
		}
		if (other.CompletionTime != 0.0)
		{
			CompletionTime = other.CompletionTime;
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
				CompletionTargetType = (Types.CompletionTargetType)input.ReadEnum();
				break;
			case 34u:
				if (completionTargetUuid_ == null)
				{
					CompletionTargetUuid = new UUID();
				}
				input.ReadMessage(CompletionTargetUuid);
				break;
			case 40u:
				CompletionActionType = (Types.CompletionActionType)input.ReadEnum();
				break;
			case 50u:
				if (completionActionUuid_ == null)
				{
					CompletionActionUuid = new UUID();
				}
				input.ReadMessage(CompletionActionUuid);
				break;
			case 58u:
				if (triggerTime_ == null)
				{
					TriggerTime = new Types.TimecodeTime();
				}
				input.ReadMessage(TriggerTime);
				break;
			case 66u:
				if (hotKey_ == null)
				{
					HotKey = new HotKey();
				}
				input.ReadMessage(HotKey);
				break;
			case 82u:
				actions_.AddEntriesFrom(input, _repeated_actions_codec);
				break;
			case 90u:
				pendingImports_.AddEntriesFrom(input, _map_pendingImports_codec);
				break;
			case 96u:
				IsEnabled = input.ReadBool();
				break;
			case 105u:
				CompletionTime = input.ReadDouble();
				break;
			}
		}
	}
}
