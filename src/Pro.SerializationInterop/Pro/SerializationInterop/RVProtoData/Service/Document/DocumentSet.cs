using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DocumentSet : IMessage<DocumentSet>, IMessage, IEquatable<DocumentSet>, IDeepCloneable<DocumentSet>
{
	private static readonly MessageParser<DocumentSet> _parser = new MessageParser<DocumentSet>(() => new DocumentSet());

	private UnknownFieldSet _unknownFields;

	public const int IntrinsicsFieldNumber = 1;

	private static readonly FieldCodec<Intrinsic> _repeated_intrinsics_codec = FieldCodec.ForMessage(10u, Intrinsic.Parser);

	private readonly RepeatedField<Intrinsic> intrinsics_ = new RepeatedField<Intrinsic>();

	public const int PresentationsFieldNumber = 2;

	private static readonly FieldCodec<Document> _repeated_presentations_codec = FieldCodec.ForMessage(18u, Document.Parser);

	private readonly RepeatedField<Document> presentations_ = new RepeatedField<Document>();

	public const int ThemesFieldNumber = 3;

	private static readonly FieldCodec<Document> _repeated_themes_codec = FieldCodec.ForMessage(26u, Document.Parser);

	private readonly RepeatedField<Document> themes_ = new RepeatedField<Document>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DocumentSet> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DocumentEntitiesReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Intrinsic> Intrinsics => intrinsics_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Document> Presentations => presentations_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Document> Themes => themes_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DocumentSet()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DocumentSet(DocumentSet other)
		: this()
	{
		intrinsics_ = other.intrinsics_.Clone();
		presentations_ = other.presentations_.Clone();
		themes_ = other.themes_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DocumentSet Clone()
	{
		return new DocumentSet(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DocumentSet);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DocumentSet other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!intrinsics_.Equals(other.intrinsics_))
		{
			return false;
		}
		if (!presentations_.Equals(other.presentations_))
		{
			return false;
		}
		if (!themes_.Equals(other.themes_))
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
		num ^= intrinsics_.GetHashCode();
		num ^= presentations_.GetHashCode();
		num ^= themes_.GetHashCode();
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
		intrinsics_.WriteTo(output, _repeated_intrinsics_codec);
		presentations_.WriteTo(output, _repeated_presentations_codec);
		themes_.WriteTo(output, _repeated_themes_codec);
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
		num += intrinsics_.CalculateSize(_repeated_intrinsics_codec);
		num += presentations_.CalculateSize(_repeated_presentations_codec);
		num += themes_.CalculateSize(_repeated_themes_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DocumentSet other)
	{
		if (other != null)
		{
			intrinsics_.Add(other.intrinsics_);
			presentations_.Add(other.presentations_);
			themes_.Add(other.themes_);
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
				intrinsics_.AddEntriesFrom(input, _repeated_intrinsics_codec);
				break;
			case 18u:
				presentations_.AddEntriesFrom(input, _repeated_presentations_codec);
				break;
			case 26u:
				themes_.AddEntriesFrom(input, _repeated_themes_codec);
				break;
			}
		}
	}
}
