using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RemoveMediaReferences : IMessage<RemoveMediaReferences>, IMessage, IEquatable<RemoveMediaReferences>, IDeepCloneable<RemoveMediaReferences>
{
	private static readonly MessageParser<RemoveMediaReferences> _parser = new MessageParser<RemoveMediaReferences>(() => new RemoveMediaReferences());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private static readonly FieldCodec<string> _repeated_uuid_codec = FieldCodec.ForString(10u);

	private readonly RepeatedField<string> uuid_ = new RepeatedField<string>();

	public const int PurgeAssetFieldNumber = 2;

	private bool purgeAsset_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RemoveMediaReferences> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[16];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> Uuid => uuid_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool PurgeAsset
	{
		get
		{
			return purgeAsset_;
		}
		set
		{
			purgeAsset_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences(RemoveMediaReferences other)
		: this()
	{
		uuid_ = other.uuid_.Clone();
		purgeAsset_ = other.purgeAsset_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences Clone()
	{
		return new RemoveMediaReferences(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RemoveMediaReferences);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RemoveMediaReferences other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!uuid_.Equals(other.uuid_))
		{
			return false;
		}
		if (PurgeAsset != other.PurgeAsset)
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
		num ^= uuid_.GetHashCode();
		if (PurgeAsset)
		{
			num ^= PurgeAsset.GetHashCode();
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
		uuid_.WriteTo(output, _repeated_uuid_codec);
		if (PurgeAsset)
		{
			output.WriteRawTag(16);
			output.WriteBool(PurgeAsset);
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
		num += uuid_.CalculateSize(_repeated_uuid_codec);
		if (PurgeAsset)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RemoveMediaReferences other)
	{
		if (other != null)
		{
			uuid_.Add(other.uuid_);
			if (other.PurgeAsset)
			{
				PurgeAsset = other.PurgeAsset;
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
			case 10u:
				uuid_.AddEntriesFrom(input, _repeated_uuid_codec);
				break;
			case 16u:
				PurgeAsset = input.ReadBool();
				break;
			}
		}
	}
}
