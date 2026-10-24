using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TimerRuntimeState : IMessage<TimerRuntimeState>, IMessage, IEquatable<TimerRuntimeState>, IDeepCloneable<TimerRuntimeState>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ResourceState
		{
			[OriginalName("PREROLLING")]
			Prerolling,
			[OriginalName("ACTIVATED")]
			Activated,
			[OriginalName("UPDATED")]
			Updated,
			[OriginalName("DEACTIVATED")]
			Deactivated,
			[OriginalName("RELEASED")]
			Released
		}
	}

	private static readonly MessageParser<TimerRuntimeState> _parser = new MessageParser<TimerRuntimeState>(() => new TimerRuntimeState());

	private UnknownFieldSet _unknownFields;

	public const int TimerUuidFieldNumber = 1;

	private UUID timerUuid_;

	public const int TimerNameFieldNumber = 2;

	private string timerName_ = "";

	public const int ActionTypeFieldNumber = 3;

	private Action.Types.TimerType actionType_;

	public const int IsRunningFieldNumber = 4;

	private bool isRunning_;

	public const int HasOverrunFieldNumber = 5;

	private bool hasOverrun_;

	public const int StateFieldNumber = 6;

	private Types.ResourceState state_;

	public const int CurrentTimeFieldNumber = 7;

	private double currentTime_;

	public const int HasStartedFieldNumber = 8;

	private bool hasStarted_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TimerRuntimeState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[23];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID TimerUuid
	{
		get
		{
			return timerUuid_;
		}
		set
		{
			timerUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string TimerName
	{
		get
		{
			return timerName_;
		}
		set
		{
			timerName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action.Types.TimerType ActionType
	{
		get
		{
			return actionType_;
		}
		set
		{
			actionType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsRunning
	{
		get
		{
			return isRunning_;
		}
		set
		{
			isRunning_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasOverrun
	{
		get
		{
			return hasOverrun_;
		}
		set
		{
			hasOverrun_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ResourceState State
	{
		get
		{
			return state_;
		}
		set
		{
			state_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double CurrentTime
	{
		get
		{
			return currentTime_;
		}
		set
		{
			currentTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasStarted
	{
		get
		{
			return hasStarted_;
		}
		set
		{
			hasStarted_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerRuntimeState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerRuntimeState(TimerRuntimeState other)
		: this()
	{
		timerUuid_ = ((other.timerUuid_ != null) ? other.timerUuid_.Clone() : null);
		timerName_ = other.timerName_;
		actionType_ = ((other.actionType_ != null) ? other.actionType_.Clone() : null);
		isRunning_ = other.isRunning_;
		hasOverrun_ = other.hasOverrun_;
		state_ = other.state_;
		currentTime_ = other.currentTime_;
		hasStarted_ = other.hasStarted_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerRuntimeState Clone()
	{
		return new TimerRuntimeState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TimerRuntimeState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TimerRuntimeState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(TimerUuid, other.TimerUuid))
		{
			return false;
		}
		if (TimerName != other.TimerName)
		{
			return false;
		}
		if (!object.Equals(ActionType, other.ActionType))
		{
			return false;
		}
		if (IsRunning != other.IsRunning)
		{
			return false;
		}
		if (HasOverrun != other.HasOverrun)
		{
			return false;
		}
		if (State != other.State)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
		{
			return false;
		}
		if (HasStarted != other.HasStarted)
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
		if (timerUuid_ != null)
		{
			num ^= TimerUuid.GetHashCode();
		}
		if (TimerName.Length != 0)
		{
			num ^= TimerName.GetHashCode();
		}
		if (actionType_ != null)
		{
			num ^= ActionType.GetHashCode();
		}
		if (IsRunning)
		{
			num ^= IsRunning.GetHashCode();
		}
		if (HasOverrun)
		{
			num ^= HasOverrun.GetHashCode();
		}
		if (State != 0)
		{
			num ^= State.GetHashCode();
		}
		if (CurrentTime != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CurrentTime);
		}
		if (HasStarted)
		{
			num ^= HasStarted.GetHashCode();
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
		if (timerUuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(TimerUuid);
		}
		if (TimerName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(TimerName);
		}
		if (actionType_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ActionType);
		}
		if (IsRunning)
		{
			output.WriteRawTag(32);
			output.WriteBool(IsRunning);
		}
		if (HasOverrun)
		{
			output.WriteRawTag(40);
			output.WriteBool(HasOverrun);
		}
		if (State != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)State);
		}
		if (CurrentTime != 0.0)
		{
			output.WriteRawTag(57);
			output.WriteDouble(CurrentTime);
		}
		if (HasStarted)
		{
			output.WriteRawTag(64);
			output.WriteBool(HasStarted);
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
		if (timerUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerUuid);
		}
		if (TimerName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(TimerName);
		}
		if (actionType_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActionType);
		}
		if (IsRunning)
		{
			num += 2;
		}
		if (HasOverrun)
		{
			num += 2;
		}
		if (State != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)State);
		}
		if (CurrentTime != 0.0)
		{
			num += 9;
		}
		if (HasStarted)
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
	public void MergeFrom(TimerRuntimeState other)
	{
		if (other == null)
		{
			return;
		}
		if (other.timerUuid_ != null)
		{
			if (timerUuid_ == null)
			{
				TimerUuid = new UUID();
			}
			TimerUuid.MergeFrom(other.TimerUuid);
		}
		if (other.TimerName.Length != 0)
		{
			TimerName = other.TimerName;
		}
		if (other.actionType_ != null)
		{
			if (actionType_ == null)
			{
				ActionType = new Action.Types.TimerType();
			}
			ActionType.MergeFrom(other.ActionType);
		}
		if (other.IsRunning)
		{
			IsRunning = other.IsRunning;
		}
		if (other.HasOverrun)
		{
			HasOverrun = other.HasOverrun;
		}
		if (other.State != 0)
		{
			State = other.State;
		}
		if (other.CurrentTime != 0.0)
		{
			CurrentTime = other.CurrentTime;
		}
		if (other.HasStarted)
		{
			HasStarted = other.HasStarted;
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
				if (timerUuid_ == null)
				{
					TimerUuid = new UUID();
				}
				input.ReadMessage(TimerUuid);
				break;
			case 18u:
				TimerName = input.ReadString();
				break;
			case 26u:
				if (actionType_ == null)
				{
					ActionType = new Action.Types.TimerType();
				}
				input.ReadMessage(ActionType);
				break;
			case 32u:
				IsRunning = input.ReadBool();
				break;
			case 40u:
				HasOverrun = input.ReadBool();
				break;
			case 48u:
				State = (Types.ResourceState)input.ReadEnum();
				break;
			case 57u:
				CurrentTime = input.ReadDouble();
				break;
			case 64u:
				HasStarted = input.ReadBool();
				break;
			}
		}
	}
}
