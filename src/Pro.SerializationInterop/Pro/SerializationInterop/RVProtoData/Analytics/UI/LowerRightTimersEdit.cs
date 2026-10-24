using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LowerRightTimersEdit : IMessage<LowerRightTimersEdit>, IMessage, IEquatable<LowerRightTimersEdit>, IDeepCloneable<LowerRightTimersEdit>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Field
		{
			[OriginalName("FIELD_UNKNOWN")]
			Unknown,
			[OriginalName("TYPE")]
			Type,
			[OriginalName("VALUE")]
			Value,
			[OriginalName("OVERRUN")]
			Overrun,
			[OriginalName("NAME")]
			Name
		}
	}

	private static readonly MessageParser<LowerRightTimersEdit> _parser = new MessageParser<LowerRightTimersEdit>(() => new LowerRightTimersEdit());

	private UnknownFieldSet _unknownFields;

	public const int FieldFieldNumber = 1;

	private Types.Field field_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LowerRightTimersEdit> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[25];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Field Field
	{
		get
		{
			return field_;
		}
		set
		{
			field_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersEdit()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersEdit(LowerRightTimersEdit other)
		: this()
	{
		field_ = other.field_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersEdit Clone()
	{
		return new LowerRightTimersEdit(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LowerRightTimersEdit);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LowerRightTimersEdit other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Field != other.Field)
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
		if (Field != 0)
		{
			num ^= Field.GetHashCode();
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
		if (Field != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Field);
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
		if (Field != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Field);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LowerRightTimersEdit other)
	{
		if (other != null)
		{
			if (other.Field != 0)
			{
				Field = other.Field;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Field = (Types.Field)input.ReadEnum();
			}
		}
	}
}
