using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PauseGeneration : IMessage<PauseGeneration>, IMessage, IEquatable<PauseGeneration>, IDeepCloneable<PauseGeneration>
{
	private static readonly MessageParser<PauseGeneration> _parser = new MessageParser<PauseGeneration>(() => new PauseGeneration());

	private UnknownFieldSet _unknownFields;

	public const int UntilTimeUtcFieldNumber = 1;

	private ulong untilTimeUtc_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PauseGeneration> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong UntilTimeUtc
	{
		get
		{
			return untilTimeUtc_;
		}
		set
		{
			untilTimeUtc_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseGeneration()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseGeneration(PauseGeneration other)
		: this()
	{
		untilTimeUtc_ = other.untilTimeUtc_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseGeneration Clone()
	{
		return new PauseGeneration(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PauseGeneration);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PauseGeneration other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (UntilTimeUtc != other.UntilTimeUtc)
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
		if (UntilTimeUtc != 0L)
		{
			num ^= UntilTimeUtc.GetHashCode();
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
		if (UntilTimeUtc != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(UntilTimeUtc);
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
		if (UntilTimeUtc != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(UntilTimeUtc);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PauseGeneration other)
	{
		if (other != null)
		{
			if (other.UntilTimeUtc != 0L)
			{
				UntilTimeUtc = other.UntilTimeUtc;
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
				UntilTimeUtc = input.ReadUInt64();
			}
		}
	}
}
