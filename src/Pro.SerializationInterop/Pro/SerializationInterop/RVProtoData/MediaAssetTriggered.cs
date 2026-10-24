using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaAssetTriggered : IMessage<MediaAssetTriggered>, IMessage, IEquatable<MediaAssetTriggered>, IDeepCloneable<MediaAssetTriggered>
{
	private static readonly MessageParser<MediaAssetTriggered> _parser = new MessageParser<MediaAssetTriggered>(() => new MediaAssetTriggered());

	private UnknownFieldSet _unknownFields;

	public const int MediaUuidFieldNumber = 1;

	private UUID mediaUuid_;

	public const int ContainerIdFieldNumber = 2;

	private string containerId_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaAssetTriggered> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[31];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID MediaUuid
	{
		get
		{
			return mediaUuid_;
		}
		set
		{
			mediaUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ContainerId
	{
		get
		{
			return containerId_;
		}
		set
		{
			containerId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaAssetTriggered()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaAssetTriggered(MediaAssetTriggered other)
		: this()
	{
		mediaUuid_ = ((other.mediaUuid_ != null) ? other.mediaUuid_.Clone() : null);
		containerId_ = other.containerId_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaAssetTriggered Clone()
	{
		return new MediaAssetTriggered(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaAssetTriggered);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaAssetTriggered other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(MediaUuid, other.MediaUuid))
		{
			return false;
		}
		if (ContainerId != other.ContainerId)
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
		if (mediaUuid_ != null)
		{
			num ^= MediaUuid.GetHashCode();
		}
		if (ContainerId.Length != 0)
		{
			num ^= ContainerId.GetHashCode();
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
		if (mediaUuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(MediaUuid);
		}
		if (ContainerId.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ContainerId);
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
		if (mediaUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaUuid);
		}
		if (ContainerId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ContainerId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaAssetTriggered other)
	{
		if (other == null)
		{
			return;
		}
		if (other.mediaUuid_ != null)
		{
			if (mediaUuid_ == null)
			{
				MediaUuid = new UUID();
			}
			MediaUuid.MergeFrom(other.MediaUuid);
		}
		if (other.ContainerId.Length != 0)
		{
			ContainerId = other.ContainerId;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
				if (mediaUuid_ == null)
				{
					MediaUuid = new UUID();
				}
				input.ReadMessage(MediaUuid);
				break;
			case 18u:
				ContainerId = input.ReadString();
				break;
			}
		}
	}
}
