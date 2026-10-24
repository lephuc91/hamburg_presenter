using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Grouped : IMessage<Grouped>, IMessage, IEquatable<Grouped>, IDeepCloneable<Grouped>
{
	private static readonly MessageParser<Grouped> _parser = new MessageParser<Grouped>(() => new Grouped());

	private UnknownFieldSet _unknownFields;

	public const int ScreenTypeFieldNumber = 1;

	private ScreenType screenType_;

	public const int ScreenColorEnabledFieldNumber = 2;

	private bool screenColorEnabled_;

	public const int ColumnsFieldNumber = 3;

	private int columns_;

	public const int RowsFieldNumber = 4;

	private int rows_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Grouped> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ScreenType ScreenType
	{
		get
		{
			return screenType_;
		}
		set
		{
			screenType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ScreenColorEnabled
	{
		get
		{
			return screenColorEnabled_;
		}
		set
		{
			screenColorEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Columns
	{
		get
		{
			return columns_;
		}
		set
		{
			columns_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Rows
	{
		get
		{
			return rows_;
		}
		set
		{
			rows_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Grouped()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Grouped(Grouped other)
		: this()
	{
		screenType_ = other.screenType_;
		screenColorEnabled_ = other.screenColorEnabled_;
		columns_ = other.columns_;
		rows_ = other.rows_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Grouped Clone()
	{
		return new Grouped(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Grouped);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Grouped other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ScreenType != other.ScreenType)
		{
			return false;
		}
		if (ScreenColorEnabled != other.ScreenColorEnabled)
		{
			return false;
		}
		if (Columns != other.Columns)
		{
			return false;
		}
		if (Rows != other.Rows)
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
		if (ScreenType != 0)
		{
			num ^= ScreenType.GetHashCode();
		}
		if (ScreenColorEnabled)
		{
			num ^= ScreenColorEnabled.GetHashCode();
		}
		if (Columns != 0)
		{
			num ^= Columns.GetHashCode();
		}
		if (Rows != 0)
		{
			num ^= Rows.GetHashCode();
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
		if (ScreenType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ScreenType);
		}
		if (ScreenColorEnabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(ScreenColorEnabled);
		}
		if (Columns != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Columns);
		}
		if (Rows != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(Rows);
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
		if (ScreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScreenType);
		}
		if (ScreenColorEnabled)
		{
			num += 2;
		}
		if (Columns != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Columns);
		}
		if (Rows != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Rows);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Grouped other)
	{
		if (other != null)
		{
			if (other.ScreenType != 0)
			{
				ScreenType = other.ScreenType;
			}
			if (other.ScreenColorEnabled)
			{
				ScreenColorEnabled = other.ScreenColorEnabled;
			}
			if (other.Columns != 0)
			{
				Columns = other.Columns;
			}
			if (other.Rows != 0)
			{
				Rows = other.Rows;
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
				ScreenType = (ScreenType)input.ReadEnum();
				break;
			case 16u:
				ScreenColorEnabled = input.ReadBool();
				break;
			case 24u:
				Columns = input.ReadInt32();
				break;
			case 32u:
				Rows = input.ReadInt32();
				break;
			}
		}
	}
}
