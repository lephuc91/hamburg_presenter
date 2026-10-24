using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Downgrade : IMessage<Downgrade>, IMessage, IEquatable<Downgrade>, IDeepCloneable<Downgrade>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum FromVersionType
		{
			[OriginalName("FROM_VERSION_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("FROM_VERSION_TYPE_BETA")]
			Beta,
			[OriginalName("FROM_VERSION_TYPE_RELEASE")]
			Release
		}
	}

	private static readonly MessageParser<Downgrade> _parser = new MessageParser<Downgrade>(() => new Downgrade());

	private UnknownFieldSet _unknownFields;

	public const int FromVersionTypeFieldNumber = 1;

	private Types.FromVersionType fromVersionType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Downgrade> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[25];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FromVersionType FromVersionType
	{
		get
		{
			return fromVersionType_;
		}
		set
		{
			fromVersionType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Downgrade()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Downgrade(Downgrade other)
		: this()
	{
		fromVersionType_ = other.fromVersionType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Downgrade Clone()
	{
		return new Downgrade(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Downgrade);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Downgrade other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FromVersionType != other.FromVersionType)
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
		if (FromVersionType != 0)
		{
			num ^= FromVersionType.GetHashCode();
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
		if (FromVersionType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)FromVersionType);
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
		if (FromVersionType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FromVersionType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Downgrade other)
	{
		if (other != null)
		{
			if (other.FromVersionType != 0)
			{
				FromVersionType = other.FromVersionType;
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
				FromVersionType = (Types.FromVersionType)input.ReadEnum();
			}
		}
	}
}
