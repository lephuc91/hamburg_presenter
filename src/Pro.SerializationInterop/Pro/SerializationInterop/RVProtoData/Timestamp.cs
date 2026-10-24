using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Timestamp : IMessage<Timestamp>, IMessage, IEquatable<Timestamp>, IDeepCloneable<Timestamp>
{
	private static readonly MessageParser<Timestamp> _parser = new MessageParser<Timestamp>(() => new Timestamp());

	private UnknownFieldSet _unknownFields;

	public const int SecondsFieldNumber = 1;

	private long seconds_;

	public const int NanosFieldNumber = 2;

	private int nanos_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Timestamp> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RvtimestampReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long Seconds
	{
		get
		{
			return seconds_;
		}
		set
		{
			seconds_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Nanos
	{
		get
		{
			return nanos_;
		}
		set
		{
			nanos_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp(Timestamp other)
		: this()
	{
		seconds_ = other.seconds_;
		nanos_ = other.nanos_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp Clone()
	{
		return new Timestamp(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Timestamp);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Timestamp other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Seconds != other.Seconds)
		{
			return false;
		}
		if (Nanos != other.Nanos)
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
		if (Seconds != 0L)
		{
			num ^= Seconds.GetHashCode();
		}
		if (Nanos != 0)
		{
			num ^= Nanos.GetHashCode();
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
		if (Seconds != 0L)
		{
			output.WriteRawTag(8);
			output.WriteInt64(Seconds);
		}
		if (Nanos != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Nanos);
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
		if (Seconds != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(Seconds);
		}
		if (Nanos != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Nanos);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Timestamp other)
	{
		if (other != null)
		{
			if (other.Seconds != 0L)
			{
				Seconds = other.Seconds;
			}
			if (other.Nanos != 0)
			{
				Nanos = other.Nanos;
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
				Seconds = input.ReadInt64();
				break;
			case 16u:
				Nanos = input.ReadInt32();
				break;
			}
		}
	}
}
