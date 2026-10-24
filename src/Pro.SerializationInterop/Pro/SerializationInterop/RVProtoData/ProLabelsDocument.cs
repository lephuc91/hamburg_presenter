using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProLabelsDocument : IMessage<ProLabelsDocument>, IMessage, IEquatable<ProLabelsDocument>, IDeepCloneable<ProLabelsDocument>
{
	private static readonly MessageParser<ProLabelsDocument> _parser = new MessageParser<ProLabelsDocument>(() => new ProLabelsDocument());

	private UnknownFieldSet _unknownFields;

	public const int LabelsFieldNumber = 1;

	private static readonly FieldCodec<Action.Types.Label> _repeated_labels_codec = FieldCodec.ForMessage(10u, Action.Types.Label.Parser);

	private readonly RepeatedField<Action.Types.Label> labels_ = new RepeatedField<Action.Types.Label>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProLabelsDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => LabelsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Action.Types.Label> Labels => labels_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLabelsDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLabelsDocument(ProLabelsDocument other)
		: this()
	{
		labels_ = other.labels_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLabelsDocument Clone()
	{
		return new ProLabelsDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProLabelsDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProLabelsDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!labels_.Equals(other.labels_))
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
		num ^= labels_.GetHashCode();
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
		labels_.WriteTo(output, _repeated_labels_codec);
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
		num += labels_.CalculateSize(_repeated_labels_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProLabelsDocument other)
	{
		if (other != null)
		{
			labels_.Add(other.labels_);
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
				labels_.AddEntriesFrom(input, _repeated_labels_codec);
			}
		}
	}
}
