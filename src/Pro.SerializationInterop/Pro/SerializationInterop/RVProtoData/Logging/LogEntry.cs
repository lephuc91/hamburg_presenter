using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Logging;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogEntry : IMessage<LogEntry>, IMessage, IEquatable<LogEntry>, IDeepCloneable<LogEntry>
{
	private static readonly MessageParser<LogEntry> _parser = new MessageParser<LogEntry>(() => new LogEntry());

	private UnknownFieldSet _unknownFields;

	public const int MessageFieldNumber = 1;

	private string message_ = "";

	public const int LevelFieldNumber = 2;

	private LogLevel level_;

	public const int TargetFieldNumber = 3;

	private string target_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogEntry> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => LogReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Message
	{
		get
		{
			return message_;
		}
		set
		{
			message_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogLevel Level
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
	public string Target
	{
		get
		{
			return target_;
		}
		set
		{
			target_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogEntry()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogEntry(LogEntry other)
		: this()
	{
		message_ = other.message_;
		level_ = other.level_;
		target_ = other.target_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogEntry Clone()
	{
		return new LogEntry(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogEntry);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogEntry other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Message != other.Message)
		{
			return false;
		}
		if (Level != other.Level)
		{
			return false;
		}
		if (Target != other.Target)
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
		if (Message.Length != 0)
		{
			num ^= Message.GetHashCode();
		}
		if (Level != 0)
		{
			num ^= Level.GetHashCode();
		}
		if (Target.Length != 0)
		{
			num ^= Target.GetHashCode();
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
		if (Message.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Message);
		}
		if (Level != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Level);
		}
		if (Target.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Target);
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
		if (Message.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Message);
		}
		if (Level != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Level);
		}
		if (Target.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Target);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogEntry other)
	{
		if (other != null)
		{
			if (other.Message.Length != 0)
			{
				Message = other.Message;
			}
			if (other.Level != 0)
			{
				Level = other.Level;
			}
			if (other.Target.Length != 0)
			{
				Target = other.Target;
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
				Message = input.ReadString();
				break;
			case 16u:
				Level = (LogLevel)input.ReadEnum();
				break;
			case 26u:
				Target = input.ReadString();
				break;
			}
		}
	}
}
