using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaMetadataRequestResponse : IMessage<MediaMetadataRequestResponse>, IMessage, IEquatable<MediaMetadataRequestResponse>, IDeepCloneable<MediaMetadataRequestResponse>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Metadata : IMessage<Metadata>, IMessage, IEquatable<Metadata>, IDeepCloneable<Metadata>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ContentType
				{
					[OriginalName("CONTENT_TYPE_UNKNOWN")]
					Unknown,
					[OriginalName("CONTENT_TYPE_AUDIO")]
					Audio,
					[OriginalName("CONTENT_TYPE_IMAGE")]
					Image,
					[OriginalName("CONTENT_TYPE_VIDEO")]
					Video
				}
			}

			private static readonly MessageParser<Metadata> _parser = new MessageParser<Metadata>(() => new Metadata());

			private UnknownFieldSet _unknownFields;

			public const int WidthFieldNumber = 1;

			private uint width_;

			public const int HeightFieldNumber = 2;

			private uint height_;

			public const int FpsFieldNumber = 3;

			private float fps_;

			public const int DurationFieldNumber = 4;

			private float duration_;

			public const int NumberAudioChannelsFieldNumber = 5;

			private uint numberAudioChannels_;

			public const int CodecFieldNumber = 6;

			private string codec_ = "";

			public const int ArtistFieldNumber = 7;

			private string artist_ = "";

			public const int TitleFieldNumber = 8;

			private string title_ = "";

			public const int RotationFieldNumber = 9;

			private float rotation_;

			public const int ContentTypeFieldNumber = 10;

			private Types.ContentType contentType_;

			public const int HasAlphaChannelFieldNumber = 11;

			private bool hasAlphaChannel_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Metadata> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaMetadataRequestResponse.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Width
			{
				get
				{
					return width_;
				}
				set
				{
					width_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Height
			{
				get
				{
					return height_;
				}
				set
				{
					height_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float Fps
			{
				get
				{
					return fps_;
				}
				set
				{
					fps_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float Duration
			{
				get
				{
					return duration_;
				}
				set
				{
					duration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint NumberAudioChannels
			{
				get
				{
					return numberAudioChannels_;
				}
				set
				{
					numberAudioChannels_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Codec
			{
				get
				{
					return codec_;
				}
				set
				{
					codec_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Artist
			{
				get
				{
					return artist_;
				}
				set
				{
					artist_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Title
			{
				get
				{
					return title_;
				}
				set
				{
					title_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float Rotation
			{
				get
				{
					return rotation_;
				}
				set
				{
					rotation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ContentType ContentType
			{
				get
				{
					return contentType_;
				}
				set
				{
					contentType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasAlphaChannel
			{
				get
				{
					return hasAlphaChannel_;
				}
				set
				{
					hasAlphaChannel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Metadata()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Metadata(Metadata other)
				: this()
			{
				width_ = other.width_;
				height_ = other.height_;
				fps_ = other.fps_;
				duration_ = other.duration_;
				numberAudioChannels_ = other.numberAudioChannels_;
				codec_ = other.codec_;
				artist_ = other.artist_;
				title_ = other.title_;
				rotation_ = other.rotation_;
				contentType_ = other.contentType_;
				hasAlphaChannel_ = other.hasAlphaChannel_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Metadata Clone()
			{
				return new Metadata(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Metadata);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Metadata other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Width != other.Width)
				{
					return false;
				}
				if (Height != other.Height)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Fps, other.Fps))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Duration, other.Duration))
				{
					return false;
				}
				if (NumberAudioChannels != other.NumberAudioChannels)
				{
					return false;
				}
				if (Codec != other.Codec)
				{
					return false;
				}
				if (Artist != other.Artist)
				{
					return false;
				}
				if (Title != other.Title)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Rotation, other.Rotation))
				{
					return false;
				}
				if (ContentType != other.ContentType)
				{
					return false;
				}
				if (HasAlphaChannel != other.HasAlphaChannel)
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
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (Height != 0)
				{
					num ^= Height.GetHashCode();
				}
				if (Fps != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Fps);
				}
				if (Duration != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Duration);
				}
				if (NumberAudioChannels != 0)
				{
					num ^= NumberAudioChannels.GetHashCode();
				}
				if (Codec.Length != 0)
				{
					num ^= Codec.GetHashCode();
				}
				if (Artist.Length != 0)
				{
					num ^= Artist.GetHashCode();
				}
				if (Title.Length != 0)
				{
					num ^= Title.GetHashCode();
				}
				if (Rotation != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Rotation);
				}
				if (ContentType != 0)
				{
					num ^= ContentType.GetHashCode();
				}
				if (HasAlphaChannel)
				{
					num ^= HasAlphaChannel.GetHashCode();
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
				if (Width != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Height);
				}
				if (Fps != 0f)
				{
					output.WriteRawTag(29);
					output.WriteFloat(Fps);
				}
				if (Duration != 0f)
				{
					output.WriteRawTag(37);
					output.WriteFloat(Duration);
				}
				if (NumberAudioChannels != 0)
				{
					output.WriteRawTag(40);
					output.WriteUInt32(NumberAudioChannels);
				}
				if (Codec.Length != 0)
				{
					output.WriteRawTag(50);
					output.WriteString(Codec);
				}
				if (Artist.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(Artist);
				}
				if (Title.Length != 0)
				{
					output.WriteRawTag(66);
					output.WriteString(Title);
				}
				if (Rotation != 0f)
				{
					output.WriteRawTag(77);
					output.WriteFloat(Rotation);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(80);
					output.WriteEnum((int)ContentType);
				}
				if (HasAlphaChannel)
				{
					output.WriteRawTag(88);
					output.WriteBool(HasAlphaChannel);
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
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
				}
				if (Height != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
				}
				if (Fps != 0f)
				{
					num += 5;
				}
				if (Duration != 0f)
				{
					num += 5;
				}
				if (NumberAudioChannels != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(NumberAudioChannels);
				}
				if (Codec.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Codec);
				}
				if (Artist.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Artist);
				}
				if (Title.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Title);
				}
				if (Rotation != 0f)
				{
					num += 5;
				}
				if (ContentType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
				}
				if (HasAlphaChannel)
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
			public void MergeFrom(Metadata other)
			{
				if (other != null)
				{
					if (other.Width != 0)
					{
						Width = other.Width;
					}
					if (other.Height != 0)
					{
						Height = other.Height;
					}
					if (other.Fps != 0f)
					{
						Fps = other.Fps;
					}
					if (other.Duration != 0f)
					{
						Duration = other.Duration;
					}
					if (other.NumberAudioChannels != 0)
					{
						NumberAudioChannels = other.NumberAudioChannels;
					}
					if (other.Codec.Length != 0)
					{
						Codec = other.Codec;
					}
					if (other.Artist.Length != 0)
					{
						Artist = other.Artist;
					}
					if (other.Title.Length != 0)
					{
						Title = other.Title;
					}
					if (other.Rotation != 0f)
					{
						Rotation = other.Rotation;
					}
					if (other.ContentType != 0)
					{
						ContentType = other.ContentType;
					}
					if (other.HasAlphaChannel)
					{
						HasAlphaChannel = other.HasAlphaChannel;
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
					case 8u:
						Width = input.ReadUInt32();
						break;
					case 16u:
						Height = input.ReadUInt32();
						break;
					case 29u:
						Fps = input.ReadFloat();
						break;
					case 37u:
						Duration = input.ReadFloat();
						break;
					case 40u:
						NumberAudioChannels = input.ReadUInt32();
						break;
					case 50u:
						Codec = input.ReadString();
						break;
					case 58u:
						Artist = input.ReadString();
						break;
					case 66u:
						Title = input.ReadString();
						break;
					case 77u:
						Rotation = input.ReadFloat();
						break;
					case 80u:
						ContentType = (Types.ContentType)input.ReadEnum();
						break;
					case 88u:
						HasAlphaChannel = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BitmapInfo : IMessage<BitmapInfo>, IMessage, IEquatable<BitmapInfo>, IDeepCloneable<BitmapInfo>
		{
			private static readonly MessageParser<BitmapInfo> _parser = new MessageParser<BitmapInfo>(() => new BitmapInfo());

			private UnknownFieldSet _unknownFields;

			public const int WidthFieldNumber = 1;

			private uint width_;

			public const int HeightFieldNumber = 2;

			private uint height_;

			public const int SizeFieldNumber = 3;

			private ulong size_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BitmapInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaMetadataRequestResponse.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Width
			{
				get
				{
					return width_;
				}
				set
				{
					width_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Height
			{
				get
				{
					return height_;
				}
				set
				{
					height_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Size
			{
				get
				{
					return size_;
				}
				set
				{
					size_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BitmapInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BitmapInfo(BitmapInfo other)
				: this()
			{
				width_ = other.width_;
				height_ = other.height_;
				size_ = other.size_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BitmapInfo Clone()
			{
				return new BitmapInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BitmapInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BitmapInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Width != other.Width)
				{
					return false;
				}
				if (Height != other.Height)
				{
					return false;
				}
				if (Size != other.Size)
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
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (Height != 0)
				{
					num ^= Height.GetHashCode();
				}
				if (Size != 0L)
				{
					num ^= Size.GetHashCode();
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
				if (Width != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Height);
				}
				if (Size != 0L)
				{
					output.WriteRawTag(24);
					output.WriteUInt64(Size);
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
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
				}
				if (Height != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
				}
				if (Size != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Size);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BitmapInfo other)
			{
				if (other != null)
				{
					if (other.Width != 0)
					{
						Width = other.Width;
					}
					if (other.Height != 0)
					{
						Height = other.Height;
					}
					if (other.Size != 0L)
					{
						Size = other.Size;
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
					case 8u:
						Width = input.ReadUInt32();
						break;
					case 16u:
						Height = input.ReadUInt32();
						break;
					case 24u:
						Size = input.ReadUInt64();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<MediaMetadataRequestResponse> _parser = new MessageParser<MediaMetadataRequestResponse>(() => new MediaMetadataRequestResponse());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private Types.Metadata metadata_;

	public const int GeneratedBitmapInfoFieldNumber = 2;

	private Types.BitmapInfo generatedBitmapInfo_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaMetadataRequestResponse> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MediaMetadataReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Metadata Metadata
	{
		get
		{
			return metadata_;
		}
		set
		{
			metadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BitmapInfo GeneratedBitmapInfo
	{
		get
		{
			return generatedBitmapInfo_;
		}
		set
		{
			generatedBitmapInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestResponse()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestResponse(MediaMetadataRequestResponse other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		generatedBitmapInfo_ = ((other.generatedBitmapInfo_ != null) ? other.generatedBitmapInfo_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestResponse Clone()
	{
		return new MediaMetadataRequestResponse(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaMetadataRequestResponse);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaMetadataRequestResponse other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Metadata, other.Metadata))
		{
			return false;
		}
		if (!object.Equals(GeneratedBitmapInfo, other.GeneratedBitmapInfo))
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
		if (metadata_ != null)
		{
			num ^= Metadata.GetHashCode();
		}
		if (generatedBitmapInfo_ != null)
		{
			num ^= GeneratedBitmapInfo.GetHashCode();
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
		if (metadata_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Metadata);
		}
		if (generatedBitmapInfo_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GeneratedBitmapInfo);
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
		if (metadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Metadata);
		}
		if (generatedBitmapInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GeneratedBitmapInfo);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaMetadataRequestResponse other)
	{
		if (other == null)
		{
			return;
		}
		if (other.metadata_ != null)
		{
			if (metadata_ == null)
			{
				Metadata = new Types.Metadata();
			}
			Metadata.MergeFrom(other.Metadata);
		}
		if (other.generatedBitmapInfo_ != null)
		{
			if (generatedBitmapInfo_ == null)
			{
				GeneratedBitmapInfo = new Types.BitmapInfo();
			}
			GeneratedBitmapInfo.MergeFrom(other.GeneratedBitmapInfo);
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
				if (metadata_ == null)
				{
					Metadata = new Types.Metadata();
				}
				input.ReadMessage(Metadata);
				break;
			case 18u:
				if (generatedBitmapInfo_ == null)
				{
					GeneratedBitmapInfo = new Types.BitmapInfo();
				}
				input.ReadMessage(GeneratedBitmapInfo);
				break;
			}
		}
	}
}
