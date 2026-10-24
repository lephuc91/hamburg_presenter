using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProContentDownloadDetails : IMessage<ProContentDownloadDetails>, IMessage, IEquatable<ProContentDownloadDetails>, IDeepCloneable<ProContentDownloadDetails>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum AssetType
		{
			[OriginalName("ASSET_TYPE_UNSPECIFIED")]
			Unspecified,
			[OriginalName("ASSET_TYPE_LOOP")]
			Loop,
			[OriginalName("ASSET_TYPE_COUNTDOWN")]
			Countdown,
			[OriginalName("ASSET_TYPE_IMAGE")]
			Image,
			[OriginalName("ASSET_TYPE_MOTION_TITLE")]
			MotionTitle,
			[OriginalName("ASSET_TYPE_PACK")]
			Pack,
			[OriginalName("ASSET_TYPE_THEME")]
			Theme
		}
	}

	private static readonly MessageParser<ProContentDownloadDetails> _parser = new MessageParser<ProContentDownloadDetails>(() => new ProContentDownloadDetails());

	private UnknownFieldSet _unknownFields;

	public const int AssetIdentifierFieldNumber = 1;

	private string assetIdentifier_ = "";

	public const int DisplayNameFieldNumber = 2;

	private string displayName_ = "";

	public const int RelativePathFieldNumber = 3;

	private string relativePath_ = "";

	public const int DownloadUrlFieldNumber = 4;

	private string downloadUrl_ = "";

	public const int ThumbnailUrlFieldNumber = 5;

	private string thumbnailUrl_ = "";

	public const int AssetTypeFieldNumber = 6;

	private Types.AssetType assetType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProContentDownloadDetails> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[17];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string AssetIdentifier
	{
		get
		{
			return assetIdentifier_;
		}
		set
		{
			assetIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayName
	{
		get
		{
			return displayName_;
		}
		set
		{
			displayName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RelativePath
	{
		get
		{
			return relativePath_;
		}
		set
		{
			relativePath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DownloadUrl
	{
		get
		{
			return downloadUrl_;
		}
		set
		{
			downloadUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ThumbnailUrl
	{
		get
		{
			return thumbnailUrl_;
		}
		set
		{
			thumbnailUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AssetType AssetType
	{
		get
		{
			return assetType_;
		}
		set
		{
			assetType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentDownloadDetails()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentDownloadDetails(ProContentDownloadDetails other)
		: this()
	{
		assetIdentifier_ = other.assetIdentifier_;
		displayName_ = other.displayName_;
		relativePath_ = other.relativePath_;
		downloadUrl_ = other.downloadUrl_;
		thumbnailUrl_ = other.thumbnailUrl_;
		assetType_ = other.assetType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentDownloadDetails Clone()
	{
		return new ProContentDownloadDetails(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProContentDownloadDetails);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProContentDownloadDetails other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AssetIdentifier != other.AssetIdentifier)
		{
			return false;
		}
		if (DisplayName != other.DisplayName)
		{
			return false;
		}
		if (RelativePath != other.RelativePath)
		{
			return false;
		}
		if (DownloadUrl != other.DownloadUrl)
		{
			return false;
		}
		if (ThumbnailUrl != other.ThumbnailUrl)
		{
			return false;
		}
		if (AssetType != other.AssetType)
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
		if (AssetIdentifier.Length != 0)
		{
			num ^= AssetIdentifier.GetHashCode();
		}
		if (DisplayName.Length != 0)
		{
			num ^= DisplayName.GetHashCode();
		}
		if (RelativePath.Length != 0)
		{
			num ^= RelativePath.GetHashCode();
		}
		if (DownloadUrl.Length != 0)
		{
			num ^= DownloadUrl.GetHashCode();
		}
		if (ThumbnailUrl.Length != 0)
		{
			num ^= ThumbnailUrl.GetHashCode();
		}
		if (AssetType != 0)
		{
			num ^= AssetType.GetHashCode();
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
		if (AssetIdentifier.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(AssetIdentifier);
		}
		if (DisplayName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(DisplayName);
		}
		if (RelativePath.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(RelativePath);
		}
		if (DownloadUrl.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(DownloadUrl);
		}
		if (ThumbnailUrl.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(ThumbnailUrl);
		}
		if (AssetType != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)AssetType);
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
		if (AssetIdentifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(AssetIdentifier);
		}
		if (DisplayName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayName);
		}
		if (RelativePath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RelativePath);
		}
		if (DownloadUrl.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DownloadUrl);
		}
		if (ThumbnailUrl.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ThumbnailUrl);
		}
		if (AssetType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AssetType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProContentDownloadDetails other)
	{
		if (other != null)
		{
			if (other.AssetIdentifier.Length != 0)
			{
				AssetIdentifier = other.AssetIdentifier;
			}
			if (other.DisplayName.Length != 0)
			{
				DisplayName = other.DisplayName;
			}
			if (other.RelativePath.Length != 0)
			{
				RelativePath = other.RelativePath;
			}
			if (other.DownloadUrl.Length != 0)
			{
				DownloadUrl = other.DownloadUrl;
			}
			if (other.ThumbnailUrl.Length != 0)
			{
				ThumbnailUrl = other.ThumbnailUrl;
			}
			if (other.AssetType != 0)
			{
				AssetType = other.AssetType;
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
				AssetIdentifier = input.ReadString();
				break;
			case 18u:
				DisplayName = input.ReadString();
				break;
			case 26u:
				RelativePath = input.ReadString();
				break;
			case 34u:
				DownloadUrl = input.ReadString();
				break;
			case 42u:
				ThumbnailUrl = input.ReadString();
				break;
			case 48u:
				AssetType = (Types.AssetType)input.ReadEnum();
				break;
			}
		}
	}
}
