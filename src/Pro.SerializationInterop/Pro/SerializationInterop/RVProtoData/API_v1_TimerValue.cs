using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_TimerValue : IMessage<API_v1_TimerValue>, IMessage, IEquatable<API_v1_TimerValue>, IDeepCloneable<API_v1_TimerValue>
{
	private static readonly MessageParser<API_v1_TimerValue> _parser = new MessageParser<API_v1_TimerValue>(() => new API_v1_TimerValue());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int TimeFieldNumber = 2;

	private string time_ = "";

	public const int StateFieldNumber = 3;

	private API_v1_TimerState state_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_TimerValue> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TimerReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
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
	public string Time
	{
		get
		{
			return time_;
		}
		set
		{
			time_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerState State
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
	public API_v1_TimerValue()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerValue(API_v1_TimerValue other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		time_ = other.time_;
		state_ = other.state_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerValue Clone()
	{
		return new API_v1_TimerValue(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_TimerValue);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_TimerValue other)
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
		if (Time != other.Time)
		{
			return false;
		}
		if (State != other.State)
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
		if (Time.Length != 0)
		{
			num ^= Time.GetHashCode();
		}
		if (State != 0)
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (Time.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Time);
		}
		if (State != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)State);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (Time.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Time);
		}
		if (State != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)State);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_TimerValue other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Time.Length != 0)
		{
			Time = other.Time;
		}
		if (other.State != 0)
		{
			State = other.State;
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
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				Time = input.ReadString();
				break;
			case 24u:
				State = (API_v1_TimerState)input.ReadEnum();
				break;
			}
		}
	}
}
