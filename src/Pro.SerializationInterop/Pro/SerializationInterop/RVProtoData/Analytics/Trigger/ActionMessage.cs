using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionMessage : IMessage<ActionMessage>, IMessage, IEquatable<ActionMessage>, IDeepCloneable<ActionMessage>
{
	private static readonly MessageParser<ActionMessage> _parser = new MessageParser<ActionMessage>(() => new ActionMessage());

	private UnknownFieldSet _unknownFields;

	public const int TokenCountFieldNumber = 1;

	private int tokenCount_;

	public const int TextTokenCountFieldNumber = 2;

	private int textTokenCount_;

	public const int TimerTokenCountFieldNumber = 3;

	private int timerTokenCount_;

	public const int ClockTokenCountFieldNumber = 4;

	private int clockTokenCount_;

	public const int ShowingCountFieldNumber = 5;

	private int showingCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionMessage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[7];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TokenCount
	{
		get
		{
			return tokenCount_;
		}
		set
		{
			tokenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TextTokenCount
	{
		get
		{
			return textTokenCount_;
		}
		set
		{
			textTokenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TimerTokenCount
	{
		get
		{
			return timerTokenCount_;
		}
		set
		{
			timerTokenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ClockTokenCount
	{
		get
		{
			return clockTokenCount_;
		}
		set
		{
			clockTokenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ShowingCount
	{
		get
		{
			return showingCount_;
		}
		set
		{
			showingCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMessage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMessage(ActionMessage other)
		: this()
	{
		tokenCount_ = other.tokenCount_;
		textTokenCount_ = other.textTokenCount_;
		timerTokenCount_ = other.timerTokenCount_;
		clockTokenCount_ = other.clockTokenCount_;
		showingCount_ = other.showingCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMessage Clone()
	{
		return new ActionMessage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionMessage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionMessage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TokenCount != other.TokenCount)
		{
			return false;
		}
		if (TextTokenCount != other.TextTokenCount)
		{
			return false;
		}
		if (TimerTokenCount != other.TimerTokenCount)
		{
			return false;
		}
		if (ClockTokenCount != other.ClockTokenCount)
		{
			return false;
		}
		if (ShowingCount != other.ShowingCount)
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
		if (TokenCount != 0)
		{
			num ^= TokenCount.GetHashCode();
		}
		if (TextTokenCount != 0)
		{
			num ^= TextTokenCount.GetHashCode();
		}
		if (TimerTokenCount != 0)
		{
			num ^= TimerTokenCount.GetHashCode();
		}
		if (ClockTokenCount != 0)
		{
			num ^= ClockTokenCount.GetHashCode();
		}
		if (ShowingCount != 0)
		{
			num ^= ShowingCount.GetHashCode();
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
		if (TokenCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TokenCount);
		}
		if (TextTokenCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(TextTokenCount);
		}
		if (TimerTokenCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(TimerTokenCount);
		}
		if (ClockTokenCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(ClockTokenCount);
		}
		if (ShowingCount != 0)
		{
			output.WriteRawTag(40);
			output.WriteInt32(ShowingCount);
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
		if (TokenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TokenCount);
		}
		if (TextTokenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TextTokenCount);
		}
		if (TimerTokenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TimerTokenCount);
		}
		if (ClockTokenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ClockTokenCount);
		}
		if (ShowingCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ShowingCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionMessage other)
	{
		if (other != null)
		{
			if (other.TokenCount != 0)
			{
				TokenCount = other.TokenCount;
			}
			if (other.TextTokenCount != 0)
			{
				TextTokenCount = other.TextTokenCount;
			}
			if (other.TimerTokenCount != 0)
			{
				TimerTokenCount = other.TimerTokenCount;
			}
			if (other.ClockTokenCount != 0)
			{
				ClockTokenCount = other.ClockTokenCount;
			}
			if (other.ShowingCount != 0)
			{
				ShowingCount = other.ShowingCount;
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
				TokenCount = input.ReadInt32();
				break;
			case 16u:
				TextTokenCount = input.ReadInt32();
				break;
			case 24u:
				TimerTokenCount = input.ReadInt32();
				break;
			case 32u:
				ClockTokenCount = input.ReadInt32();
				break;
			case 40u:
				ShowingCount = input.ReadInt32();
				break;
			}
		}
	}
}
