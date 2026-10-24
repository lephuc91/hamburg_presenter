using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TimerStateUpdate : IMessage<TimerStateUpdate>, IMessage, IEquatable<TimerStateUpdate>, IDeepCloneable<TimerStateUpdate>
{
	private static readonly MessageParser<TimerStateUpdate> _parser = new MessageParser<TimerStateUpdate>(() => new TimerStateUpdate());

	private UnknownFieldSet _unknownFields;

	public const int TimerFieldNumber = 1;

	private Timer timer_;

	public const int StateFieldNumber = 2;

	private TimerRuntimeState state_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TimerStateUpdate> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[24];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timer Timer
	{
		get
		{
			return timer_;
		}
		set
		{
			timer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerRuntimeState State
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
	public TimerStateUpdate()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerStateUpdate(TimerStateUpdate other)
		: this()
	{
		timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
		state_ = ((other.state_ != null) ? other.state_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerStateUpdate Clone()
	{
		return new TimerStateUpdate(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TimerStateUpdate);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TimerStateUpdate other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Timer, other.Timer))
		{
			return false;
		}
		if (!object.Equals(State, other.State))
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
		if (timer_ != null)
		{
			num ^= Timer.GetHashCode();
		}
		if (state_ != null)
		{
			num ^= State.GetHashCode();
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
		if (timer_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Timer);
		}
		if (state_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(State);
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
		if (timer_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
		}
		if (state_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(State);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TimerStateUpdate other)
	{
		if (other == null)
		{
			return;
		}
		if (other.timer_ != null)
		{
			if (timer_ == null)
			{
				Timer = new Timer();
			}
			Timer.MergeFrom(other.Timer);
		}
		if (other.state_ != null)
		{
			if (state_ == null)
			{
				State = new TimerRuntimeState();
			}
			State.MergeFrom(other.State);
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
				if (timer_ == null)
				{
					Timer = new Timer();
				}
				input.ReadMessage(Timer);
				break;
			case 18u:
				if (state_ == null)
				{
					State = new TimerRuntimeState();
				}
				input.ReadMessage(State);
				break;
			}
		}
	}
}
