using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaReferenceInfo : IMessage<MediaReferenceInfo>, IMessage, IEquatable<MediaReferenceInfo>, IDeepCloneable<MediaReferenceInfo>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Availability : IMessage<Availability>, IMessage, IEquatable<Availability>, IDeepCloneable<Availability>
		{
			public enum AvailabilityOneofCase
			{
				None,
				Ready,
				Missing,
				Downloading
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Ready : IMessage<Ready>, IMessage, IEquatable<Ready>, IDeepCloneable<Ready>
				{
					private static readonly MessageParser<Ready> _parser = new MessageParser<Ready>(() => new Ready());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Ready> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Availability.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ready()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ready(Ready other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ready Clone()
					{
						return new Ready(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Ready);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Ready other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Ready other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Missing : IMessage<Missing>, IMessage, IEquatable<Missing>, IDeepCloneable<Missing>
				{
					private static readonly MessageParser<Missing> _parser = new MessageParser<Missing>(() => new Missing());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Missing> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Availability.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Missing()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Missing(Missing other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Missing Clone()
					{
						return new Missing(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Missing);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Missing other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Missing other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Downloading : IMessage<Downloading>, IMessage, IEquatable<Downloading>, IDeepCloneable<Downloading>
				{
					private static readonly MessageParser<Downloading> _parser = new MessageParser<Downloading>(() => new Downloading());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Downloading> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Availability.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Downloading()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Downloading(Downloading other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Downloading Clone()
					{
						return new Downloading(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Downloading);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Downloading other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Downloading other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}
			}

			private static readonly MessageParser<Availability> _parser = new MessageParser<Availability>(() => new Availability());

			private UnknownFieldSet _unknownFields;

			public const int ReadyFieldNumber = 1;

			public const int MissingFieldNumber = 2;

			public const int DownloadingFieldNumber = 3;

			private object availability_;

			private AvailabilityOneofCase availabilityCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Availability> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReferenceInfo.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Ready Ready
			{
				get
				{
					if (availabilityCase_ != AvailabilityOneofCase.Ready)
					{
						return null;
					}
					return (Types.Ready)availability_;
				}
				set
				{
					availability_ = value;
					availabilityCase_ = ((value != null) ? AvailabilityOneofCase.Ready : AvailabilityOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Missing Missing
			{
				get
				{
					if (availabilityCase_ != AvailabilityOneofCase.Missing)
					{
						return null;
					}
					return (Types.Missing)availability_;
				}
				set
				{
					availability_ = value;
					availabilityCase_ = ((value != null) ? AvailabilityOneofCase.Missing : AvailabilityOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Downloading Downloading
			{
				get
				{
					if (availabilityCase_ != AvailabilityOneofCase.Downloading)
					{
						return null;
					}
					return (Types.Downloading)availability_;
				}
				set
				{
					availability_ = value;
					availabilityCase_ = ((value != null) ? AvailabilityOneofCase.Downloading : AvailabilityOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AvailabilityOneofCase AvailabilityCase => availabilityCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Availability()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Availability(Availability other)
				: this()
			{
				switch (other.AvailabilityCase)
				{
				case AvailabilityOneofCase.Ready:
					Ready = other.Ready.Clone();
					break;
				case AvailabilityOneofCase.Missing:
					Missing = other.Missing.Clone();
					break;
				case AvailabilityOneofCase.Downloading:
					Downloading = other.Downloading.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Availability Clone()
			{
				return new Availability(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearAvailability()
			{
				availabilityCase_ = AvailabilityOneofCase.None;
				availability_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Availability);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Availability other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Ready, other.Ready))
				{
					return false;
				}
				if (!object.Equals(Missing, other.Missing))
				{
					return false;
				}
				if (!object.Equals(Downloading, other.Downloading))
				{
					return false;
				}
				if (AvailabilityCase != other.AvailabilityCase)
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
				if (availabilityCase_ == AvailabilityOneofCase.Ready)
				{
					num ^= Ready.GetHashCode();
				}
				if (availabilityCase_ == AvailabilityOneofCase.Missing)
				{
					num ^= Missing.GetHashCode();
				}
				if (availabilityCase_ == AvailabilityOneofCase.Downloading)
				{
					num ^= Downloading.GetHashCode();
				}
				num ^= (int)availabilityCase_;
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
				if (availabilityCase_ == AvailabilityOneofCase.Ready)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Ready);
				}
				if (availabilityCase_ == AvailabilityOneofCase.Missing)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Missing);
				}
				if (availabilityCase_ == AvailabilityOneofCase.Downloading)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Downloading);
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
				if (availabilityCase_ == AvailabilityOneofCase.Ready)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Ready);
				}
				if (availabilityCase_ == AvailabilityOneofCase.Missing)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Missing);
				}
				if (availabilityCase_ == AvailabilityOneofCase.Downloading)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Downloading);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Availability other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.AvailabilityCase)
				{
				case AvailabilityOneofCase.Ready:
					if (Ready == null)
					{
						Ready = new Types.Ready();
					}
					Ready.MergeFrom(other.Ready);
					break;
				case AvailabilityOneofCase.Missing:
					if (Missing == null)
					{
						Missing = new Types.Missing();
					}
					Missing.MergeFrom(other.Missing);
					break;
				case AvailabilityOneofCase.Downloading:
					if (Downloading == null)
					{
						Downloading = new Types.Downloading();
					}
					Downloading.MergeFrom(other.Downloading);
					break;
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
					{
						Types.Ready ready = new Types.Ready();
						if (availabilityCase_ == AvailabilityOneofCase.Ready)
						{
							ready.MergeFrom(Ready);
						}
						input.ReadMessage(ready);
						Ready = ready;
						break;
					}
					case 18u:
					{
						Types.Missing missing = new Types.Missing();
						if (availabilityCase_ == AvailabilityOneofCase.Missing)
						{
							missing.MergeFrom(Missing);
						}
						input.ReadMessage(missing);
						Missing = missing;
						break;
					}
					case 26u:
					{
						Types.Downloading downloading = new Types.Downloading();
						if (availabilityCase_ == AvailabilityOneofCase.Downloading)
						{
							downloading.MergeFrom(Downloading);
						}
						input.ReadMessage(downloading);
						Downloading = downloading;
						break;
					}
					}
				}
			}
		}

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

			public const int AvailabilityFieldNumber = 15;

			private Availability availability_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaInfo> Parser => _parser;

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
			public Availability Availability
			{
				get
				{
					return availability_;
				}
				set
				{
					availability_ = value;
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
				availability_ = ((other.availability_ != null) ? other.availability_.Clone() : null);
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
				if (!object.Equals(Availability, other.Availability))
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
				if (availability_ != null)
				{
					num ^= Availability.GetHashCode();
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
				if (availability_ != null)
				{
					output.WriteRawTag(122);
					output.WriteMessage(Availability);
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
				if (availability_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Availability);
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
				if (other == null)
				{
					return;
				}
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
				if (other.availability_ != null)
				{
					if (availability_ == null)
					{
						Availability = new Availability();
					}
					Availability.MergeFrom(other.Availability);
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
					case 122u:
						if (availability_ == null)
						{
							Availability = new Availability();
						}
						input.ReadMessage(Availability);
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

			public const int AvailabilityFieldNumber = 2;

			private Availability availability_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ThumbnailInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReferenceInfo.Descriptor.NestedTypes[2];

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
			public Availability Availability
			{
				get
				{
					return availability_;
				}
				set
				{
					availability_ = value;
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
				availability_ = ((other.availability_ != null) ? other.availability_.Clone() : null);
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
				if (!object.Equals(Availability, other.Availability))
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
				if (availability_ != null)
				{
					num ^= Availability.GetHashCode();
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
				if (availability_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Availability);
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
				if (availability_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Availability);
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
				if (other == null)
				{
					return;
				}
				if (other.Url.Length != 0)
				{
					Url = other.Url;
				}
				if (other.availability_ != null)
				{
					if (availability_ == null)
					{
						Availability = new Availability();
					}
					Availability.MergeFrom(other.Availability);
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
						Url = input.ReadString();
						break;
					case 18u:
						if (availability_ == null)
						{
							Availability = new Availability();
						}
						input.ReadMessage(Availability);
						break;
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
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[6];

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
