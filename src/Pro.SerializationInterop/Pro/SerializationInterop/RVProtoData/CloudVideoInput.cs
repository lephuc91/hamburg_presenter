using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CloudVideoInput : IMessage<CloudVideoInput>, IMessage, IEquatable<CloudVideoInput>, IDeepCloneable<CloudVideoInput>
{
	private static readonly MessageParser<CloudVideoInput> _parser = new MessageParser<CloudVideoInput>(() => new CloudVideoInput());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int UserDescriptionFieldNumber = 2;

	private string userDescription_ = "";

	public const int ThumbnailPathFieldNumber = 3;

	private URL thumbnailPath_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CloudVideoInput> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => InputReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string UserDescription
	{
		get
		{
			return userDescription_;
		}
		set
		{
			userDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL ThumbnailPath
	{
		get
		{
			return thumbnailPath_;
		}
		set
		{
			thumbnailPath_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CloudVideoInput()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CloudVideoInput(CloudVideoInput other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		userDescription_ = other.userDescription_;
		thumbnailPath_ = ((other.thumbnailPath_ != null) ? other.thumbnailPath_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CloudVideoInput Clone()
	{
		return new CloudVideoInput(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CloudVideoInput);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CloudVideoInput other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (UserDescription != other.UserDescription)
		{
			return false;
		}
		if (!object.Equals(ThumbnailPath, other.ThumbnailPath))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (UserDescription.Length != 0)
		{
			num ^= UserDescription.GetHashCode();
		}
		if (thumbnailPath_ != null)
		{
			num ^= ThumbnailPath.GetHashCode();
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (UserDescription.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(UserDescription);
		}
		if (thumbnailPath_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ThumbnailPath);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (UserDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UserDescription);
		}
		if (thumbnailPath_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ThumbnailPath);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CloudVideoInput other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.UserDescription.Length != 0)
		{
			UserDescription = other.UserDescription;
		}
		if (other.thumbnailPath_ != null)
		{
			if (thumbnailPath_ == null)
			{
				ThumbnailPath = new URL();
			}
			ThumbnailPath.MergeFrom(other.ThumbnailPath);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				UserDescription = input.ReadString();
				break;
			case 26u:
				if (thumbnailPath_ == null)
				{
					ThumbnailPath = new URL();
				}
				input.ReadMessage(ThumbnailPath);
				break;
			}
		}
	}
}
