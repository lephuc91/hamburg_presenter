using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Bibles : IMessage<Bibles>, IMessage, IEquatable<Bibles>, IDeepCloneable<Bibles>
{
	private static readonly MessageParser<Bibles> _parser = new MessageParser<Bibles>(() => new Bibles());

	private UnknownFieldSet _unknownFields;

	public const int FreeBiblesFieldNumber = 1;

	private static readonly FieldCodec<Bible> _repeated_freeBibles_codec = FieldCodec.ForMessage(10u, Bible.Parser);

	private readonly RepeatedField<Bible> freeBibles_ = new RepeatedField<Bible>();

	public const int PurchasedBiblesFieldNumber = 2;

	private static readonly FieldCodec<PurchasedBible> _repeated_purchasedBibles_codec = FieldCodec.ForMessage(18u, PurchasedBible.Parser);

	private readonly RepeatedField<PurchasedBible> purchasedBibles_ = new RepeatedField<PurchasedBible>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Bibles> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[58];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Bible> FreeBibles => freeBibles_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<PurchasedBible> PurchasedBibles => purchasedBibles_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bibles()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bibles(Bibles other)
		: this()
	{
		freeBibles_ = other.freeBibles_.Clone();
		purchasedBibles_ = other.purchasedBibles_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bibles Clone()
	{
		return new Bibles(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Bibles);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Bibles other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!freeBibles_.Equals(other.freeBibles_))
		{
			return false;
		}
		if (!purchasedBibles_.Equals(other.purchasedBibles_))
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
		num ^= freeBibles_.GetHashCode();
		num ^= purchasedBibles_.GetHashCode();
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
		freeBibles_.WriteTo(output, _repeated_freeBibles_codec);
		purchasedBibles_.WriteTo(output, _repeated_purchasedBibles_codec);
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
		num += freeBibles_.CalculateSize(_repeated_freeBibles_codec);
		num += purchasedBibles_.CalculateSize(_repeated_purchasedBibles_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Bibles other)
	{
		if (other != null)
		{
			freeBibles_.Add(other.freeBibles_);
			purchasedBibles_.Add(other.purchasedBibles_);
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
				freeBibles_.AddEntriesFrom(input, _repeated_freeBibles_codec);
				break;
			case 18u:
				purchasedBibles_.AddEntriesFrom(input, _repeated_purchasedBibles_codec);
				break;
			}
		}
	}
}
