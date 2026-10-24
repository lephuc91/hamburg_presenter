using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RemoveMediaReferences : IMessage<RemoveMediaReferences>, IMessage, IEquatable<RemoveMediaReferences>, IDeepCloneable<RemoveMediaReferences>
{
	private static readonly MessageParser<RemoveMediaReferences> _parser = new MessageParser<RemoveMediaReferences>(() => new RemoveMediaReferences());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int IdFieldNumber = 1;

	private static readonly FieldCodec<ReferenceIdentifier> _repeated_id_codec = FieldCodec.ForMessage(10u, ReferenceIdentifier.Parser);

	private readonly RepeatedField<ReferenceIdentifier> id_ = new RepeatedField<ReferenceIdentifier>();

	public const int PurgeAssetFieldNumber = 2;

	private bool purgeAsset_;

	public const int DeleteAssetFieldNumber = 3;

	private bool deleteAsset_;

	public const int UserInitiatedFieldNumber = 4;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RemoveMediaReferences> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[22];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ReferenceIdentifier> Id => id_;

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
	public bool DeleteAsset
	{
		get
		{
			return deleteAsset_;
		}
		set
		{
			deleteAsset_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UserInitiated
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return userInitiated_;
			}
			return UserInitiatedDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUserInitiated => (_hasBits0 & 1) != 0;

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
		_hasBits0 = other._hasBits0;
		id_ = other.id_.Clone();
		purgeAsset_ = other.purgeAsset_;
		deleteAsset_ = other.deleteAsset_;
		userInitiated_ = other.userInitiated_;
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
	public void ClearUserInitiated()
	{
		_hasBits0 &= -2;
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
		if (!id_.Equals(other.id_))
		{
			return false;
		}
		if (PurgeAsset != other.PurgeAsset)
		{
			return false;
		}
		if (DeleteAsset != other.DeleteAsset)
		{
			return false;
		}
		if (UserInitiated != other.UserInitiated)
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
		num ^= id_.GetHashCode();
		if (PurgeAsset)
		{
			num ^= PurgeAsset.GetHashCode();
		}
		if (DeleteAsset)
		{
			num ^= DeleteAsset.GetHashCode();
		}
		if (HasUserInitiated)
		{
			num ^= UserInitiated.GetHashCode();
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
		id_.WriteTo(output, _repeated_id_codec);
		if (PurgeAsset)
		{
			output.WriteRawTag(16);
			output.WriteBool(PurgeAsset);
		}
		if (DeleteAsset)
		{
			output.WriteRawTag(24);
			output.WriteBool(DeleteAsset);
		}
		if (HasUserInitiated)
		{
			output.WriteRawTag(32);
			output.WriteBool(UserInitiated);
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
		num += id_.CalculateSize(_repeated_id_codec);
		if (PurgeAsset)
		{
			num += 2;
		}
		if (DeleteAsset)
		{
			num += 2;
		}
		if (HasUserInitiated)
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
			id_.Add(other.id_);
			if (other.PurgeAsset)
			{
				PurgeAsset = other.PurgeAsset;
			}
			if (other.DeleteAsset)
			{
				DeleteAsset = other.DeleteAsset;
			}
			if (other.HasUserInitiated)
			{
				UserInitiated = other.UserInitiated;
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
				id_.AddEntriesFrom(input, _repeated_id_codec);
				break;
			case 16u:
				PurgeAsset = input.ReadBool();
				break;
			case 24u:
				DeleteAsset = input.ReadBool();
				break;
			case 32u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
