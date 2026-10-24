using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Seats : IMessage<Seats>, IMessage, IEquatable<Seats>, IDeepCloneable<Seats>
{
	private static readonly MessageParser<Seats> _parser = new MessageParser<Seats>(() => new Seats());

	private UnknownFieldSet _unknownFields;

	public const int BasicFieldNumber = 1;

	private int basic_;

	public const int AdvancedFieldNumber = 2;

	private int advanced_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Seats> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[45];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Basic
	{
		get
		{
			return basic_;
		}
		set
		{
			basic_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Advanced
	{
		get
		{
			return advanced_;
		}
		set
		{
			advanced_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats(Seats other)
		: this()
	{
		basic_ = other.basic_;
		advanced_ = other.advanced_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats Clone()
	{
		return new Seats(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Seats);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Seats other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Basic != other.Basic)
		{
			return false;
		}
		if (Advanced != other.Advanced)
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
		if (Basic != 0)
		{
			num ^= Basic.GetHashCode();
		}
		if (Advanced != 0)
		{
			num ^= Advanced.GetHashCode();
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
		if (Basic != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Basic);
		}
		if (Advanced != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Advanced);
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
		if (Basic != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Basic);
		}
		if (Advanced != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Advanced);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Seats other)
	{
		if (other != null)
		{
			if (other.Basic != 0)
			{
				Basic = other.Basic;
			}
			if (other.Advanced != 0)
			{
				Advanced = other.Advanced;
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
				Basic = input.ReadInt32();
				break;
			case 16u:
				Advanced = input.ReadInt32();
				break;
			}
		}
	}
}
