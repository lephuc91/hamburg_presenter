using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DataIdDuplicated : IMessage<DataIdDuplicated>, IMessage, IEquatable<DataIdDuplicated>, IDeepCloneable<DataIdDuplicated>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum DataType
		{
			[OriginalName("DATA_TYPE_PRESENTATION")]
			Presentation,
			[OriginalName("DATA_TYPE_MEDIA")]
			Media
		}
	}

	private static readonly MessageParser<DataIdDuplicated> _parser = new MessageParser<DataIdDuplicated>(() => new DataIdDuplicated());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private Types.DataType type_;

	public const int NumberDuplicatesFieldNumber = 2;

	private int numberDuplicates_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DataIdDuplicated> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[29];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DataType Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int NumberDuplicates
	{
		get
		{
			return numberDuplicates_;
		}
		set
		{
			numberDuplicates_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DataIdDuplicated()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DataIdDuplicated(DataIdDuplicated other)
		: this()
	{
		type_ = other.type_;
		numberDuplicates_ = other.numberDuplicates_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DataIdDuplicated Clone()
	{
		return new DataIdDuplicated(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DataIdDuplicated);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DataIdDuplicated other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (NumberDuplicates != other.NumberDuplicates)
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (NumberDuplicates != 0)
		{
			num ^= NumberDuplicates.GetHashCode();
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
		if (Type != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Type);
		}
		if (NumberDuplicates != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(NumberDuplicates);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (NumberDuplicates != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(NumberDuplicates);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DataIdDuplicated other)
	{
		if (other != null)
		{
			if (other.Type != 0)
			{
				Type = other.Type;
			}
			if (other.NumberDuplicates != 0)
			{
				NumberDuplicates = other.NumberDuplicates;
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
				Type = (Types.DataType)input.ReadEnum();
				break;
			case 16u:
				NumberDuplicates = input.ReadInt32();
				break;
			}
		}
	}
}
