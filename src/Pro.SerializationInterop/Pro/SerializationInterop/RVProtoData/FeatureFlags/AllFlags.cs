using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.FeatureFlags;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AllFlags : IMessage<AllFlags>, IMessage, IEquatable<AllFlags>, IDeepCloneable<AllFlags>
{
	private static readonly MessageParser<AllFlags> _parser = new MessageParser<AllFlags>(() => new AllFlags());

	private UnknownFieldSet _unknownFields;

	public const int FlagsFieldNumber = 1;

	private static readonly FieldCodec<Flag> _repeated_flags_codec = FieldCodec.ForMessage(10u, Flag.Parser);

	private readonly RepeatedField<Flag> flags_ = new RepeatedField<Flag>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AllFlags> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => FeatureFlagsReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Flag> Flags => flags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AllFlags()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AllFlags(AllFlags other)
		: this()
	{
		flags_ = other.flags_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AllFlags Clone()
	{
		return new AllFlags(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AllFlags);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AllFlags other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!flags_.Equals(other.flags_))
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
		num ^= flags_.GetHashCode();
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
		flags_.WriteTo(output, _repeated_flags_codec);
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
		num += flags_.CalculateSize(_repeated_flags_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AllFlags other)
	{
		if (other != null)
		{
			flags_.Add(other.flags_);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				flags_.AddEntriesFrom(input, _repeated_flags_codec);
			}
		}
	}
}
