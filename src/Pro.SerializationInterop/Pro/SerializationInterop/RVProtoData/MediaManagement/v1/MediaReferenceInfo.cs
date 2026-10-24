using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaReferenceInfo : IMessage<MediaReferenceInfo>, IMessage, IEquatable<MediaReferenceInfo>, IDeepCloneable<MediaReferenceInfo>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MediaInfo : IMessage<MediaInfo>, IMessage, IEquatable<MediaInfo>, IDeepCloneable<MediaInfo>
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

				public enum ColorFormat
				{
					[OriginalName("SDR")]
					Sdr,
					[OriginalName("HDR_REC2100_HLG")]
					HdrRec2100Hlg,
					[OriginalName("HDR_REC2100_PQ")]
					HdrRec2100Pq
				}
			}

			private static readonly MessageParser<MediaInfo> _parser = new MessageParser<MediaInfo>(() => new MediaInfo());

			private UnknownFieldSet _unknownFields;

			public const int UrlFieldNumber = 1;

			private string url_ = "";

			public const int WidthFieldNumber = 2;

			private uint width_;

			public const int HeightFieldNumber = 3;

			private uint height_;

			public const int FpsFieldNumber = 4;

			private float fps_;

			public const int DurationFieldNumber = 5;

			private float duration_;

			public const int NumAudioChannelsFieldNumber = 6;

			private uint numAudioChannels_;

			public const int CodecFieldNumber = 7;

			private string codec_ = "";

			public const int ArtistFieldNumber = 8;

			private string artist_ = "";

			public const int TitleFieldNumber = 9;

			private string title_ = "";

			public const int RotationFieldNumber = 10;

			private int rotation_;

			public const int ContentTypeFieldNumber = 11;

			private Types.ContentType contentType_;

			public const int HasAlphaChannelFieldNumber = 12;

			private bool hasAlphaChannel_;

			public const int SupportsHwDecodeFieldNumber = 13;

			private bool supportsHwDecode_;

			public const int ColorFormatFieldNumber = 14;

			private Types.ColorFormat colorFormat_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReferenceInfo.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Url
			{
				get
				{
					return url_;
				}
				set
				{
					url_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
			public uint NumAudioChannels
			{
				get
				{
					return numAudioChannels_;
				}
				set
				{
					numAudioChannels_ = value;
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
			public int Rotation
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
			public bool SupportsHwDecode
			{
				get
				{
					return supportsHwDecode_;
				}
				set
				{
					supportsHwDecode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ColorFormat ColorFormat
			{
				get
				{
					return colorFormat_;
				}
				set
				{
					colorFormat_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaInfo(MediaInfo other)
				: this()
			{
				url_ = other.url_;
				width_ = other.width_;
				height_ = other.height_;
				fps_ = other.fps_;
				duration_ = other.duration_;
				numAudioChannels_ = other.numAudioChannels_;
				codec_ = other.codec_;
				artist_ = other.artist_;
				title_ = other.title_;
				rotation_ = other.rotation_;
				contentType_ = other.contentType_;
				hasAlphaChannel_ = other.hasAlphaChannel_;
				supportsHwDecode_ = other.supportsHwDecode_;
				colorFormat_ = other.colorFormat_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaInfo Clone()
			{
				return new MediaInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Url != other.Url)
				{
					return false;
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
				if (NumAudioChannels != other.NumAudioChannels)
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
				if (Rotation != other.Rotation)
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
				if (SupportsHwDecode != other.SupportsHwDecode)
				{
					return false;
				}
				if (ColorFormat != other.ColorFormat)
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
				if (Url.Length != 0)
				{
					num ^= Url.GetHashCode();
				}
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
				if (NumAudioChannels != 0)
				{
					num ^= NumAudioChannels.GetHashCode();
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
				if (Rotation != 0)
				{
					num ^= Rotation.GetHashCode();
				}
				if (ContentType != 0)
				{
					num ^= ContentType.GetHashCode();
				}
				if (HasAlphaChannel)
				{
					num ^= HasAlphaChannel.GetHashCode();
				}
				if (SupportsHwDecode)
				{
					num ^= SupportsHwDecode.GetHashCode();
				}
				if (ColorFormat != 0)
				{
					num ^= ColorFormat.GetHashCode();
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
				if (Url.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Url);
				}
				if (Width != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(Height);
				}
				if (Fps != 0f)
				{
					output.WriteRawTag(37);
					output.WriteFloat(Fps);
				}
				if (Duration != 0f)
				{
					output.WriteRawTag(45);
					output.WriteFloat(Duration);
				}
				if (NumAudioChannels != 0)
				{
					output.WriteRawTag(48);
					output.WriteUInt32(NumAudioChannels);
				}
				if (Codec.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(Codec);
				}
				if (Artist.Length != 0)
				{
					output.WriteRawTag(66);
					output.WriteString(Artist);
				}
				if (Title.Length != 0)
				{
					output.WriteRawTag(74);
					output.WriteString(Title);
				}
				if (Rotation != 0)
				{
					output.WriteRawTag(80);
					output.WriteInt32(Rotation);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(88);
					output.WriteEnum((int)ContentType);
				}
				if (HasAlphaChannel)
				{
					output.WriteRawTag(96);
					output.WriteBool(HasAlphaChannel);
				}
				if (SupportsHwDecode)
				{
					output.WriteRawTag(104);
					output.WriteBool(SupportsHwDecode);
				}
				if (ColorFormat != 0)
				{
					output.WriteRawTag(112);
					output.WriteEnum((int)ColorFormat);
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
				if (Url.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Url);
				}
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
				if (NumAudioChannels != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(NumAudioChannels);
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
				if (Rotation != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Rotation);
				}
				if (ContentType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
				}
				if (HasAlphaChannel)
				{
					num += 2;
				}
				if (SupportsHwDecode)
				{
					num += 2;
				}
				if (ColorFormat != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ColorFormat);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MediaInfo other)
			{
				if (other != null)
				{
					if (other.Url.Length != 0)
					{
						Url = other.Url;
					}
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
					if (other.NumAudioChannels != 0)
					{
						NumAudioChannels = other.NumAudioChannels;
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
					if (other.Rotation != 0)
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
					if (other.SupportsHwDecode)
					{
						SupportsHwDecode = other.SupportsHwDecode;
					}
					if (other.ColorFormat != 0)
					{
						ColorFormat = other.ColorFormat;
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
						Url = input.ReadString();
						break;
					case 16u:
						Width = input.ReadUInt32();
						break;
					case 24u:
						Height = input.ReadUInt32();
						break;
					case 37u:
						Fps = input.ReadFloat();
						break;
					case 45u:
						Duration = input.ReadFloat();
						break;
					case 48u:
						NumAudioChannels = input.ReadUInt32();
						break;
					case 58u:
						Codec = input.ReadString();
						break;
					case 66u:
						Artist = input.ReadString();
						break;
					case 74u:
						Title = input.ReadString();
						break;
					case 80u:
						Rotation = input.ReadInt32();
						break;
					case 88u:
						ContentType = (Types.ContentType)input.ReadEnum();
						break;
					case 96u:
						HasAlphaChannel = input.ReadBool();
						break;
					case 104u:
						SupportsHwDecode = input.ReadBool();
						break;
					case 112u:
						ColorFormat = (Types.ColorFormat)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ThumbnailInfo : IMessage<ThumbnailInfo>, IMessage, IEquatable<ThumbnailInfo>, IDeepCloneable<ThumbnailInfo>
		{
			private static readonly MessageParser<ThumbnailInfo> _parser = new MessageParser<ThumbnailInfo>(() => new ThumbnailInfo());

			private UnknownFieldSet _unknownFields;

			public const int UrlFieldNumber = 1;

			private string url_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ThumbnailInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReferenceInfo.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Url
			{
				get
				{
					return url_;
				}
				set
				{
					url_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ThumbnailInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ThumbnailInfo(ThumbnailInfo other)
				: this()
			{
				url_ = other.url_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ThumbnailInfo Clone()
			{
				return new ThumbnailInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ThumbnailInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ThumbnailInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Url != other.Url)
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
				if (Url.Length != 0)
				{
					num ^= Url.GetHashCode();
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
				if (Url.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Url);
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
				if (Url.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Url);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ThumbnailInfo other)
			{
				if (other != null)
				{
					if (other.Url.Length != 0)
					{
						Url = other.Url;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Url = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<MediaReferenceInfo> _parser = new MessageParser<MediaReferenceInfo>(() => new MediaReferenceInfo());

	private UnknownFieldSet _unknownFields;

	public const int MediaInfoFieldNumber = 1;

	private Types.MediaInfo mediaInfo_;

	public const int ThumbnailInfoFieldNumber = 2;

	private Types.ThumbnailInfo thumbnailInfo_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaReferenceInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaInfo MediaInfo
	{
		get
		{
			return mediaInfo_;
		}
		set
		{
			mediaInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ThumbnailInfo ThumbnailInfo
	{
		get
		{
			return thumbnailInfo_;
		}
		set
		{
			thumbnailInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReferenceInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReferenceInfo(MediaReferenceInfo other)
		: this()
	{
		mediaInfo_ = ((other.mediaInfo_ != null) ? other.mediaInfo_.Clone() : null);
		thumbnailInfo_ = ((other.thumbnailInfo_ != null) ? other.thumbnailInfo_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReferenceInfo Clone()
	{
		return new MediaReferenceInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaReferenceInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaReferenceInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(MediaInfo, other.MediaInfo))
		{
			return false;
		}
		if (!object.Equals(ThumbnailInfo, other.ThumbnailInfo))
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
		if (mediaInfo_ != null)
		{
			num ^= MediaInfo.GetHashCode();
		}
		if (thumbnailInfo_ != null)
		{
			num ^= ThumbnailInfo.GetHashCode();
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
		if (mediaInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(MediaInfo);
		}
		if (thumbnailInfo_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ThumbnailInfo);
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
		if (mediaInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaInfo);
		}
		if (thumbnailInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ThumbnailInfo);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaReferenceInfo other)
	{
		if (other == null)
		{
			return;
		}
		if (other.mediaInfo_ != null)
		{
			if (mediaInfo_ == null)
			{
				MediaInfo = new Types.MediaInfo();
			}
			MediaInfo.MergeFrom(other.MediaInfo);
		}
		if (other.thumbnailInfo_ != null)
		{
			if (thumbnailInfo_ == null)
			{
				ThumbnailInfo = new Types.ThumbnailInfo();
			}
			ThumbnailInfo.MergeFrom(other.ThumbnailInfo);
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
				if (mediaInfo_ == null)
				{
					MediaInfo = new Types.MediaInfo();
				}
				input.ReadMessage(MediaInfo);
				break;
			case 18u:
				if (thumbnailInfo_ == null)
				{
					ThumbnailInfo = new Types.ThumbnailInfo();
				}
				input.ReadMessage(ThumbnailInfo);
				break;
			}
		}
	}
}
