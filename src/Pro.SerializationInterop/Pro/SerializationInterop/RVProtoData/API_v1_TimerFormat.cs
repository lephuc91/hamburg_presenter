using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_TimerFormat : IMessage<API_v1_TimerFormat>, IMessage, IEquatable<API_v1_TimerFormat>, IDeepCloneable<API_v1_TimerFormat>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_TimerUnitDisplayFormat
		{
			[OriginalName("none")]
			None,
			[OriginalName("short")]
			Short,
			[OriginalName("long")]
			Long,
			[OriginalName("remove_short")]
			RemoveShort,
			[OriginalName("remove_long")]
			RemoveLong
		}
	}

	private static readonly MessageParser<API_v1_TimerFormat> _parser = new MessageParser<API_v1_TimerFormat>(() => new API_v1_TimerFormat());

	private UnknownFieldSet _unknownFields;

	public const int HourFieldNumber = 6;

	private Types.API_v1_TimerUnitDisplayFormat hour_;

	public const int MinuteFieldNumber = 7;

	private Types.API_v1_TimerUnitDisplayFormat minute_;

	public const int SecondFieldNumber = 8;

	private Types.API_v1_TimerUnitDisplayFormat second_;

	public const int MillisecondFieldNumber = 9;

	private Types.API_v1_TimerUnitDisplayFormat millisecond_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_TimerFormat> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TimerReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_TimerUnitDisplayFormat Hour
	{
		get
		{
			return hour_;
		}
		set
		{
			hour_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_TimerUnitDisplayFormat Minute
	{
		get
		{
			return minute_;
		}
		set
		{
			minute_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_TimerUnitDisplayFormat Second
	{
		get
		{
			return second_;
		}
		set
		{
			second_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_TimerUnitDisplayFormat Millisecond
	{
		get
		{
			return millisecond_;
		}
		set
		{
			millisecond_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerFormat()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerFormat(API_v1_TimerFormat other)
		: this()
	{
		hour_ = other.hour_;
		minute_ = other.minute_;
		second_ = other.second_;
		millisecond_ = other.millisecond_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_TimerFormat Clone()
	{
		return new API_v1_TimerFormat(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_TimerFormat);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_TimerFormat other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Hour != other.Hour)
		{
			return false;
		}
		if (Minute != other.Minute)
		{
			return false;
		}
		if (Second != other.Second)
		{
			return false;
		}
		if (Millisecond != other.Millisecond)
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
		if (Hour != 0)
		{
			num ^= Hour.GetHashCode();
		}
		if (Minute != 0)
		{
			num ^= Minute.GetHashCode();
		}
		if (Second != 0)
		{
			num ^= Second.GetHashCode();
		}
		if (Millisecond != 0)
		{
			num ^= Millisecond.GetHashCode();
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
		if (Hour != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)Hour);
		}
		if (Minute != 0)
		{
			output.WriteRawTag(56);
			output.WriteEnum((int)Minute);
		}
		if (Second != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)Second);
		}
		if (Millisecond != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)Millisecond);
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
		if (Hour != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Hour);
		}
		if (Minute != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Minute);
		}
		if (Second != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Second);
		}
		if (Millisecond != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Millisecond);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_TimerFormat other)
	{
		if (other != null)
		{
			if (other.Hour != 0)
			{
				Hour = other.Hour;
			}
			if (other.Minute != 0)
			{
				Minute = other.Minute;
			}
			if (other.Second != 0)
			{
				Second = other.Second;
			}
			if (other.Millisecond != 0)
			{
				Millisecond = other.Millisecond;
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
			case 48u:
				Hour = (Types.API_v1_TimerUnitDisplayFormat)input.ReadEnum();
				break;
			case 56u:
				Minute = (Types.API_v1_TimerUnitDisplayFormat)input.ReadEnum();
				break;
			case 64u:
				Second = (Types.API_v1_TimerUnitDisplayFormat)input.ReadEnum();
				break;
			case 72u:
				Millisecond = (Types.API_v1_TimerUnitDisplayFormat)input.ReadEnum();
				break;
			}
		}
	}
}
