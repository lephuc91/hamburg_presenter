using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Recording : IMessage<Recording>, IMessage, IEquatable<Recording>, IDeepCloneable<Recording>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SettingsDocument : IMessage<SettingsDocument>, IMessage, IEquatable<SettingsDocument>, IDeepCloneable<SettingsDocument>
		{
			private static readonly MessageParser<SettingsDocument> _parser = new MessageParser<SettingsDocument>(() => new SettingsDocument());

			private UnknownFieldSet _unknownFields;

			public const int StreamsFieldNumber = 1;

			private static readonly FieldCodec<Stream> _repeated_streams_codec = FieldCodec.ForMessage(10u, Stream.Parser);

			private readonly RepeatedField<Stream> streams_ = new RepeatedField<Stream>();

			public const int PresetsFieldNumber = 2;

			private static readonly FieldCodec<Preset> _repeated_presets_codec = FieldCodec.ForMessage(18u, Preset.Parser);

			private readonly RepeatedField<Preset> presets_ = new RepeatedField<Preset>();

			public const int ActivePresetFieldNumber = 3;

			private Preset activePreset_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SettingsDocument> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Recording.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Stream> Streams => streams_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Preset> Presets => presets_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset ActivePreset
			{
				get
				{
					return activePreset_;
				}
				set
				{
					activePreset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument(SettingsDocument other)
				: this()
			{
				streams_ = other.streams_.Clone();
				presets_ = other.presets_.Clone();
				activePreset_ = ((other.activePreset_ != null) ? other.activePreset_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument Clone()
			{
				return new SettingsDocument(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SettingsDocument);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SettingsDocument other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!streams_.Equals(other.streams_))
				{
					return false;
				}
				if (!presets_.Equals(other.presets_))
				{
					return false;
				}
				if (!object.Equals(ActivePreset, other.ActivePreset))
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
				num ^= streams_.GetHashCode();
				num ^= presets_.GetHashCode();
				if (activePreset_ != null)
				{
					num ^= ActivePreset.GetHashCode();
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
				streams_.WriteTo(output, _repeated_streams_codec);
				presets_.WriteTo(output, _repeated_presets_codec);
				if (activePreset_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ActivePreset);
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
				num += streams_.CalculateSize(_repeated_streams_codec);
				num += presets_.CalculateSize(_repeated_presets_codec);
				if (activePreset_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ActivePreset);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SettingsDocument other)
			{
				if (other == null)
				{
					return;
				}
				streams_.Add(other.streams_);
				presets_.Add(other.presets_);
				if (other.activePreset_ != null)
				{
					if (activePreset_ == null)
					{
						ActivePreset = new Preset();
					}
					ActivePreset.MergeFrom(other.ActivePreset);
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
						streams_.AddEntriesFrom(input, _repeated_streams_codec);
						break;
					case 18u:
						presets_.AddEntriesFrom(input, _repeated_presets_codec);
						break;
					case 26u:
						if (activePreset_ == null)
						{
							ActivePreset = new Preset();
						}
						input.ReadMessage(ActivePreset);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Preset : IMessage<Preset>, IMessage, IEquatable<Preset>, IDeepCloneable<Preset>
		{
			private static readonly MessageParser<Preset> _parser = new MessageParser<Preset>(() => new Preset());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private UUID id_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int StreamsFieldNumber = 3;

			private static readonly FieldCodec<Stream> _repeated_streams_codec = FieldCodec.ForMessage(26u, Stream.Parser);

			private readonly RepeatedField<Stream> streams_ = new RepeatedField<Stream>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Preset> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Recording.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Stream> Streams => streams_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset(Preset other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				name_ = other.name_;
				streams_ = other.streams_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset Clone()
			{
				return new Preset(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Preset);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Preset other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Id, other.Id))
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!streams_.Equals(other.streams_))
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
				if (id_ != null)
				{
					num ^= Id.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= streams_.GetHashCode();
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				streams_.WriteTo(output, _repeated_streams_codec);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += streams_.CalculateSize(_repeated_streams_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Preset other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new UUID();
					}
					Id.MergeFrom(other.Id);
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				streams_.Add(other.streams_);
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
						if (id_ == null)
						{
							Id = new UUID();
						}
						input.ReadMessage(Id);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						streams_.AddEntriesFrom(input, _repeated_streams_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Stream : IMessage<Stream>, IMessage, IEquatable<Stream>, IDeepCloneable<Stream>
		{
			public enum SourceOneofCase
			{
				None = 0,
				OutputScreen = 2
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Container
				{
					[OriginalName("CONTAINER_UNKNOWN")]
					Unknown,
					[OriginalName("CONTAINER_MOV")]
					Mov,
					[OriginalName("CONTAINER_MP4")]
					Mp4
				}

				public enum Codec
				{
					[OriginalName("CODEC_AUTOMATIC")]
					Automatic,
					[OriginalName("CODEC_H264")]
					H264,
					[OriginalName("CODEC_H265")]
					H265,
					[OriginalName("CODEC_PRORES_422_PROXY")]
					Prores422Proxy,
					[OriginalName("CODEC_PRORES_422_LT")]
					Prores422Lt,
					[OriginalName("CODEC_PRORES_422")]
					Prores422,
					[OriginalName("CODEC_PRORES_422_HQ")]
					Prores422Hq,
					[OriginalName("CODEC_PRORES_4444")]
					Prores4444,
					[OriginalName("CODEC_PRORES_4444_XQ")]
					Prores4444Xq,
					[OriginalName("CODEC_HAP")]
					Hap,
					[OriginalName("CODEC_HAP_ALPHA")]
					HapAlpha,
					[OriginalName("CODEC_HAP_Q")]
					HapQ,
					[OriginalName("CODEC_HAP_Q_ALPHA")]
					HapQAlpha,
					[OriginalName("CODEC_NOTCH")]
					Notch,
					[OriginalName("CODEC_H264_SOFTWARE")]
					H264Software,
					[OriginalName("CODEC_H265_SOFTWARE")]
					H265Software
				}

				public enum FrameRate
				{
					[OriginalName("FRAME_RATE_UNKNOWN")]
					Unknown,
					[OriginalName("FRAME_RATE_24")]
					_24,
					[OriginalName("FRAME_RATE_25")]
					_25,
					[OriginalName("FRAME_RATE_29_97")]
					_2997,
					[OriginalName("FRAME_RATE_30")]
					_30,
					[OriginalName("FRAME_RATE_50")]
					_50,
					[OriginalName("FRAME_RATE_59_94")]
					_5994,
					[OriginalName("FRAME_RATE_60")]
					_60
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Encoder : IMessage<Encoder>, IMessage, IEquatable<Encoder>, IDeepCloneable<Encoder>
				{
					private static readonly MessageParser<Encoder> _parser = new MessageParser<Encoder>(() => new Encoder());

					private UnknownFieldSet _unknownFields;

					public const int CodecFieldNumber = 1;

					private Codec codec_;

					public const int VideoWidthFieldNumber = 2;

					private uint videoWidth_;

					public const int VideoHeightFieldNumber = 3;

					private uint videoHeight_;

					public const int IsInterlacedFieldNumber = 4;

					private bool isInterlaced_;

					public const int FrameRateFieldNumber = 5;

					private FrameRate frameRate_;

					public const int VideoBitrateFieldNumber = 6;

					private uint videoBitrate_;

					public const int AudioBitrateFieldNumber = 7;

					private uint audioBitrate_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Encoder> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Stream.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Codec Codec
					{
						get
						{
							return codec_;
						}
						set
						{
							codec_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint VideoWidth
					{
						get
						{
							return videoWidth_;
						}
						set
						{
							videoWidth_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint VideoHeight
					{
						get
						{
							return videoHeight_;
						}
						set
						{
							videoHeight_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool IsInterlaced
					{
						get
						{
							return isInterlaced_;
						}
						set
						{
							isInterlaced_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FrameRate FrameRate
					{
						get
						{
							return frameRate_;
						}
						set
						{
							frameRate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint VideoBitrate
					{
						get
						{
							return videoBitrate_;
						}
						set
						{
							videoBitrate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint AudioBitrate
					{
						get
						{
							return audioBitrate_;
						}
						set
						{
							audioBitrate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Encoder()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Encoder(Encoder other)
						: this()
					{
						codec_ = other.codec_;
						videoWidth_ = other.videoWidth_;
						videoHeight_ = other.videoHeight_;
						isInterlaced_ = other.isInterlaced_;
						frameRate_ = other.frameRate_;
						videoBitrate_ = other.videoBitrate_;
						audioBitrate_ = other.audioBitrate_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Encoder Clone()
					{
						return new Encoder(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Encoder);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Encoder other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Codec != other.Codec)
						{
							return false;
						}
						if (VideoWidth != other.VideoWidth)
						{
							return false;
						}
						if (VideoHeight != other.VideoHeight)
						{
							return false;
						}
						if (IsInterlaced != other.IsInterlaced)
						{
							return false;
						}
						if (FrameRate != other.FrameRate)
						{
							return false;
						}
						if (VideoBitrate != other.VideoBitrate)
						{
							return false;
						}
						if (AudioBitrate != other.AudioBitrate)
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
						if (Codec != 0)
						{
							num ^= Codec.GetHashCode();
						}
						if (VideoWidth != 0)
						{
							num ^= VideoWidth.GetHashCode();
						}
						if (VideoHeight != 0)
						{
							num ^= VideoHeight.GetHashCode();
						}
						if (IsInterlaced)
						{
							num ^= IsInterlaced.GetHashCode();
						}
						if (FrameRate != 0)
						{
							num ^= FrameRate.GetHashCode();
						}
						if (VideoBitrate != 0)
						{
							num ^= VideoBitrate.GetHashCode();
						}
						if (AudioBitrate != 0)
						{
							num ^= AudioBitrate.GetHashCode();
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
						if (Codec != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Codec);
						}
						if (VideoWidth != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(VideoWidth);
						}
						if (VideoHeight != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(VideoHeight);
						}
						if (IsInterlaced)
						{
							output.WriteRawTag(32);
							output.WriteBool(IsInterlaced);
						}
						if (FrameRate != 0)
						{
							output.WriteRawTag(40);
							output.WriteEnum((int)FrameRate);
						}
						if (VideoBitrate != 0)
						{
							output.WriteRawTag(48);
							output.WriteUInt32(VideoBitrate);
						}
						if (AudioBitrate != 0)
						{
							output.WriteRawTag(56);
							output.WriteUInt32(AudioBitrate);
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
						if (Codec != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Codec);
						}
						if (VideoWidth != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(VideoWidth);
						}
						if (VideoHeight != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(VideoHeight);
						}
						if (IsInterlaced)
						{
							num += 2;
						}
						if (FrameRate != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)FrameRate);
						}
						if (VideoBitrate != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(VideoBitrate);
						}
						if (AudioBitrate != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(AudioBitrate);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Encoder other)
					{
						if (other != null)
						{
							if (other.Codec != 0)
							{
								Codec = other.Codec;
							}
							if (other.VideoWidth != 0)
							{
								VideoWidth = other.VideoWidth;
							}
							if (other.VideoHeight != 0)
							{
								VideoHeight = other.VideoHeight;
							}
							if (other.IsInterlaced)
							{
								IsInterlaced = other.IsInterlaced;
							}
							if (other.FrameRate != 0)
							{
								FrameRate = other.FrameRate;
							}
							if (other.VideoBitrate != 0)
							{
								VideoBitrate = other.VideoBitrate;
							}
							if (other.AudioBitrate != 0)
							{
								AudioBitrate = other.AudioBitrate;
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
								Codec = (Codec)input.ReadEnum();
								break;
							case 16u:
								VideoWidth = input.ReadUInt32();
								break;
							case 24u:
								VideoHeight = input.ReadUInt32();
								break;
							case 32u:
								IsInterlaced = input.ReadBool();
								break;
							case 40u:
								FrameRate = (FrameRate)input.ReadEnum();
								break;
							case 48u:
								VideoBitrate = input.ReadUInt32();
								break;
							case 56u:
								AudioBitrate = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class OutputScreenSource : IMessage<OutputScreenSource>, IMessage, IEquatable<OutputScreenSource>, IDeepCloneable<OutputScreenSource>
				{
					private static readonly MessageParser<OutputScreenSource> _parser = new MessageParser<OutputScreenSource>(() => new OutputScreenSource());

					private UnknownFieldSet _unknownFields;

					public const int ScreenIdFieldNumber = 1;

					private UUID screenId_;

					public const int ScreenNameFieldNumber = 2;

					private string screenName_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<OutputScreenSource> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Stream.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UUID ScreenId
					{
						get
						{
							return screenId_;
						}
						set
						{
							screenId_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string ScreenName
					{
						get
						{
							return screenName_;
						}
						set
						{
							screenName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputScreenSource()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputScreenSource(OutputScreenSource other)
						: this()
					{
						screenId_ = ((other.screenId_ != null) ? other.screenId_.Clone() : null);
						screenName_ = other.screenName_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputScreenSource Clone()
					{
						return new OutputScreenSource(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as OutputScreenSource);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(OutputScreenSource other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(ScreenId, other.ScreenId))
						{
							return false;
						}
						if (ScreenName != other.ScreenName)
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
						if (screenId_ != null)
						{
							num ^= ScreenId.GetHashCode();
						}
						if (ScreenName.Length != 0)
						{
							num ^= ScreenName.GetHashCode();
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
						if (screenId_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(ScreenId);
						}
						if (ScreenName.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(ScreenName);
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
						if (screenId_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ScreenId);
						}
						if (ScreenName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(ScreenName);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(OutputScreenSource other)
					{
						if (other == null)
						{
							return;
						}
						if (other.screenId_ != null)
						{
							if (screenId_ == null)
							{
								ScreenId = new UUID();
							}
							ScreenId.MergeFrom(other.ScreenId);
						}
						if (other.ScreenName.Length != 0)
						{
							ScreenName = other.ScreenName;
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
								if (screenId_ == null)
								{
									ScreenId = new UUID();
								}
								input.ReadMessage(ScreenId);
								break;
							case 18u:
								ScreenName = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class DiskDestination : IMessage<DiskDestination>, IMessage, IEquatable<DiskDestination>, IDeepCloneable<DiskDestination>
				{
					private static readonly MessageParser<DiskDestination> _parser = new MessageParser<DiskDestination>(() => new DiskDestination());

					private UnknownFieldSet _unknownFields;

					public const int LocationFieldNumber = 1;

					private URL location_;

					public const int ContainerFieldNumber = 2;

					private Container container_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<DiskDestination> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Stream.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public URL Location
					{
						get
						{
							return location_;
						}
						set
						{
							location_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Container Container
					{
						get
						{
							return container_;
						}
						set
						{
							container_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DiskDestination()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DiskDestination(DiskDestination other)
						: this()
					{
						location_ = ((other.location_ != null) ? other.location_.Clone() : null);
						container_ = other.container_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DiskDestination Clone()
					{
						return new DiskDestination(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as DiskDestination);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(DiskDestination other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Location, other.Location))
						{
							return false;
						}
						if (Container != other.Container)
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
						if (location_ != null)
						{
							num ^= Location.GetHashCode();
						}
						if (Container != 0)
						{
							num ^= Container.GetHashCode();
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
						if (location_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Location);
						}
						if (Container != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Container);
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
						if (location_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Location);
						}
						if (Container != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Container);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(DiskDestination other)
					{
						if (other == null)
						{
							return;
						}
						if (other.location_ != null)
						{
							if (location_ == null)
							{
								Location = new URL();
							}
							Location.MergeFrom(other.Location);
						}
						if (other.Container != 0)
						{
							Container = other.Container;
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
								if (location_ == null)
								{
									Location = new URL();
								}
								input.ReadMessage(Location);
								break;
							case 16u:
								Container = (Container)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class RTMPDestination : IMessage<RTMPDestination>, IMessage, IEquatable<RTMPDestination>, IDeepCloneable<RTMPDestination>
				{
					private static readonly MessageParser<RTMPDestination> _parser = new MessageParser<RTMPDestination>(() => new RTMPDestination());

					private UnknownFieldSet _unknownFields;

					public const int AddressFieldNumber = 1;

					private string address_ = "";

					public const int KeyFieldNumber = 2;

					private string key_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<RTMPDestination> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Stream.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Address
					{
						get
						{
							return address_;
						}
						set
						{
							address_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Key
					{
						get
						{
							return key_;
						}
						set
						{
							key_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RTMPDestination()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RTMPDestination(RTMPDestination other)
						: this()
					{
						address_ = other.address_;
						key_ = other.key_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RTMPDestination Clone()
					{
						return new RTMPDestination(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as RTMPDestination);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(RTMPDestination other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Address != other.Address)
						{
							return false;
						}
						if (Key != other.Key)
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
						if (Address.Length != 0)
						{
							num ^= Address.GetHashCode();
						}
						if (Key.Length != 0)
						{
							num ^= Key.GetHashCode();
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
						if (Address.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Address);
						}
						if (Key.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Key);
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
						if (Address.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Address);
						}
						if (Key.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Key);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(RTMPDestination other)
					{
						if (other != null)
						{
							if (other.Address.Length != 0)
							{
								Address = other.Address;
							}
							if (other.Key.Length != 0)
							{
								Key = other.Key;
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
								Address = input.ReadString();
								break;
							case 18u:
								Key = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Destination : IMessage<Destination>, IMessage, IEquatable<Destination>, IDeepCloneable<Destination>
				{
					public enum DestinationOneofCase
					{
						None,
						Disk,
						Rtmp,
						Resi
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Resi : IMessage<Resi>, IMessage, IEquatable<Resi>, IDeepCloneable<Resi>
						{
							private static readonly MessageParser<Resi> _parser = new MessageParser<Resi>(() => new Resi());

							private UnknownFieldSet _unknownFields;

							public const int DestinationGroupIdFieldNumber = 1;

							private UUID destinationGroupId_;

							public const int EncoderProfileIdFieldNumber = 2;

							private UUID encoderProfileId_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Resi> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Destination.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public UUID DestinationGroupId
							{
								get
								{
									return destinationGroupId_;
								}
								set
								{
									destinationGroupId_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public UUID EncoderProfileId
							{
								get
								{
									return encoderProfileId_;
								}
								set
								{
									encoderProfileId_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Resi()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Resi(Resi other)
								: this()
							{
								destinationGroupId_ = ((other.destinationGroupId_ != null) ? other.destinationGroupId_.Clone() : null);
								encoderProfileId_ = ((other.encoderProfileId_ != null) ? other.encoderProfileId_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Resi Clone()
							{
								return new Resi(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Resi);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Resi other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(DestinationGroupId, other.DestinationGroupId))
								{
									return false;
								}
								if (!object.Equals(EncoderProfileId, other.EncoderProfileId))
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
								if (destinationGroupId_ != null)
								{
									num ^= DestinationGroupId.GetHashCode();
								}
								if (encoderProfileId_ != null)
								{
									num ^= EncoderProfileId.GetHashCode();
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
								if (destinationGroupId_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(DestinationGroupId);
								}
								if (encoderProfileId_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(EncoderProfileId);
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
								if (destinationGroupId_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(DestinationGroupId);
								}
								if (encoderProfileId_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(EncoderProfileId);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Resi other)
							{
								if (other == null)
								{
									return;
								}
								if (other.destinationGroupId_ != null)
								{
									if (destinationGroupId_ == null)
									{
										DestinationGroupId = new UUID();
									}
									DestinationGroupId.MergeFrom(other.DestinationGroupId);
								}
								if (other.encoderProfileId_ != null)
								{
									if (encoderProfileId_ == null)
									{
										EncoderProfileId = new UUID();
									}
									EncoderProfileId.MergeFrom(other.EncoderProfileId);
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
										if (destinationGroupId_ == null)
										{
											DestinationGroupId = new UUID();
										}
										input.ReadMessage(DestinationGroupId);
										break;
									case 18u:
										if (encoderProfileId_ == null)
										{
											EncoderProfileId = new UUID();
										}
										input.ReadMessage(EncoderProfileId);
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<Destination> _parser = new MessageParser<Destination>(() => new Destination());

					private UnknownFieldSet _unknownFields;

					public const int DiskFieldNumber = 1;

					public const int RtmpFieldNumber = 2;

					public const int ResiFieldNumber = 3;

					private object destination_;

					private DestinationOneofCase destinationCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Destination> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Stream.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DiskDestination Disk
					{
						get
						{
							if (destinationCase_ != DestinationOneofCase.Disk)
							{
								return null;
							}
							return (DiskDestination)destination_;
						}
						set
						{
							destination_ = value;
							destinationCase_ = ((value != null) ? DestinationOneofCase.Disk : DestinationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RTMPDestination Rtmp
					{
						get
						{
							if (destinationCase_ != DestinationOneofCase.Rtmp)
							{
								return null;
							}
							return (RTMPDestination)destination_;
						}
						set
						{
							destination_ = value;
							destinationCase_ = ((value != null) ? DestinationOneofCase.Rtmp : DestinationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Resi Resi
					{
						get
						{
							if (destinationCase_ != DestinationOneofCase.Resi)
							{
								return null;
							}
							return (Types.Resi)destination_;
						}
						set
						{
							destination_ = value;
							destinationCase_ = ((value != null) ? DestinationOneofCase.Resi : DestinationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DestinationOneofCase DestinationCase => destinationCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Destination()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Destination(Destination other)
						: this()
					{
						switch (other.DestinationCase)
						{
						case DestinationOneofCase.Disk:
							Disk = other.Disk.Clone();
							break;
						case DestinationOneofCase.Rtmp:
							Rtmp = other.Rtmp.Clone();
							break;
						case DestinationOneofCase.Resi:
							Resi = other.Resi.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Destination Clone()
					{
						return new Destination(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearDestination()
					{
						destinationCase_ = DestinationOneofCase.None;
						destination_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Destination);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Destination other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Disk, other.Disk))
						{
							return false;
						}
						if (!object.Equals(Rtmp, other.Rtmp))
						{
							return false;
						}
						if (!object.Equals(Resi, other.Resi))
						{
							return false;
						}
						if (DestinationCase != other.DestinationCase)
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
						if (destinationCase_ == DestinationOneofCase.Disk)
						{
							num ^= Disk.GetHashCode();
						}
						if (destinationCase_ == DestinationOneofCase.Rtmp)
						{
							num ^= Rtmp.GetHashCode();
						}
						if (destinationCase_ == DestinationOneofCase.Resi)
						{
							num ^= Resi.GetHashCode();
						}
						num ^= (int)destinationCase_;
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
						if (destinationCase_ == DestinationOneofCase.Disk)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Disk);
						}
						if (destinationCase_ == DestinationOneofCase.Rtmp)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Rtmp);
						}
						if (destinationCase_ == DestinationOneofCase.Resi)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Resi);
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
						if (destinationCase_ == DestinationOneofCase.Disk)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Disk);
						}
						if (destinationCase_ == DestinationOneofCase.Rtmp)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Rtmp);
						}
						if (destinationCase_ == DestinationOneofCase.Resi)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Resi);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Destination other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.DestinationCase)
						{
						case DestinationOneofCase.Disk:
							if (Disk == null)
							{
								Disk = new DiskDestination();
							}
							Disk.MergeFrom(other.Disk);
							break;
						case DestinationOneofCase.Rtmp:
							if (Rtmp == null)
							{
								Rtmp = new RTMPDestination();
							}
							Rtmp.MergeFrom(other.Rtmp);
							break;
						case DestinationOneofCase.Resi:
							if (Resi == null)
							{
								Resi = new Types.Resi();
							}
							Resi.MergeFrom(other.Resi);
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
								DiskDestination diskDestination = new DiskDestination();
								if (destinationCase_ == DestinationOneofCase.Disk)
								{
									diskDestination.MergeFrom(Disk);
								}
								input.ReadMessage(diskDestination);
								Disk = diskDestination;
								break;
							}
							case 18u:
							{
								RTMPDestination rTMPDestination = new RTMPDestination();
								if (destinationCase_ == DestinationOneofCase.Rtmp)
								{
									rTMPDestination.MergeFrom(Rtmp);
								}
								input.ReadMessage(rTMPDestination);
								Rtmp = rTMPDestination;
								break;
							}
							case 26u:
							{
								Types.Resi resi = new Types.Resi();
								if (destinationCase_ == DestinationOneofCase.Resi)
								{
									resi.MergeFrom(Resi);
								}
								input.ReadMessage(resi);
								Resi = resi;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<Stream> _parser = new MessageParser<Stream>(() => new Stream());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private UUID id_;

			public const int OutputScreenFieldNumber = 2;

			public const int EncoderFieldNumber = 3;

			private Types.Encoder encoder_;

			public const int DestinationsFieldNumber = 4;

			private static readonly FieldCodec<Types.Destination> _repeated_destinations_codec = FieldCodec.ForMessage(34u, Types.Destination.Parser);

			private readonly RepeatedField<Types.Destination> destinations_ = new RepeatedField<Types.Destination>();

			public const int AudioMapFieldNumber = 5;

			private static readonly FieldCodec<DigitalAudio.Types.Device.Types.Map> _repeated_audioMap_codec = FieldCodec.ForMessage(42u, DigitalAudio.Types.Device.Types.Map.Parser);

			private readonly RepeatedField<DigitalAudio.Types.Device.Types.Map> audioMap_ = new RepeatedField<DigitalAudio.Types.Device.Types.Map>();

			public const int IsAudioCustomMappedFieldNumber = 6;

			private bool isAudioCustomMapped_;

			private object source_;

			private SourceOneofCase sourceCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Stream> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Recording.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.OutputScreenSource OutputScreen
			{
				get
				{
					if (sourceCase_ != SourceOneofCase.OutputScreen)
					{
						return null;
					}
					return (Types.OutputScreenSource)source_;
				}
				set
				{
					source_ = value;
					sourceCase_ = ((value != null) ? SourceOneofCase.OutputScreen : SourceOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Encoder Encoder
			{
				get
				{
					return encoder_;
				}
				set
				{
					encoder_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Destination> Destinations => destinations_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<DigitalAudio.Types.Device.Types.Map> AudioMap => audioMap_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsAudioCustomMapped
			{
				get
				{
					return isAudioCustomMapped_;
				}
				set
				{
					isAudioCustomMapped_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SourceOneofCase SourceCase => sourceCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Stream()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Stream(Stream other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				encoder_ = ((other.encoder_ != null) ? other.encoder_.Clone() : null);
				destinations_ = other.destinations_.Clone();
				audioMap_ = other.audioMap_.Clone();
				isAudioCustomMapped_ = other.isAudioCustomMapped_;
				if (other.SourceCase == SourceOneofCase.OutputScreen)
				{
					OutputScreen = other.OutputScreen.Clone();
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Stream Clone()
			{
				return new Stream(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearSource()
			{
				sourceCase_ = SourceOneofCase.None;
				source_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Stream);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Stream other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Id, other.Id))
				{
					return false;
				}
				if (!object.Equals(OutputScreen, other.OutputScreen))
				{
					return false;
				}
				if (!object.Equals(Encoder, other.Encoder))
				{
					return false;
				}
				if (!destinations_.Equals(other.destinations_))
				{
					return false;
				}
				if (!audioMap_.Equals(other.audioMap_))
				{
					return false;
				}
				if (IsAudioCustomMapped != other.IsAudioCustomMapped)
				{
					return false;
				}
				if (SourceCase != other.SourceCase)
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
				if (id_ != null)
				{
					num ^= Id.GetHashCode();
				}
				if (sourceCase_ == SourceOneofCase.OutputScreen)
				{
					num ^= OutputScreen.GetHashCode();
				}
				if (encoder_ != null)
				{
					num ^= Encoder.GetHashCode();
				}
				num ^= destinations_.GetHashCode();
				num ^= audioMap_.GetHashCode();
				if (IsAudioCustomMapped)
				{
					num ^= IsAudioCustomMapped.GetHashCode();
				}
				num ^= (int)sourceCase_;
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
				}
				if (sourceCase_ == SourceOneofCase.OutputScreen)
				{
					output.WriteRawTag(18);
					output.WriteMessage(OutputScreen);
				}
				if (encoder_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Encoder);
				}
				destinations_.WriteTo(output, _repeated_destinations_codec);
				audioMap_.WriteTo(output, _repeated_audioMap_codec);
				if (IsAudioCustomMapped)
				{
					output.WriteRawTag(48);
					output.WriteBool(IsAudioCustomMapped);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
				}
				if (sourceCase_ == SourceOneofCase.OutputScreen)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(OutputScreen);
				}
				if (encoder_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Encoder);
				}
				num += destinations_.CalculateSize(_repeated_destinations_codec);
				num += audioMap_.CalculateSize(_repeated_audioMap_codec);
				if (IsAudioCustomMapped)
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
			public void MergeFrom(Stream other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new UUID();
					}
					Id.MergeFrom(other.Id);
				}
				if (other.encoder_ != null)
				{
					if (encoder_ == null)
					{
						Encoder = new Types.Encoder();
					}
					Encoder.MergeFrom(other.Encoder);
				}
				destinations_.Add(other.destinations_);
				audioMap_.Add(other.audioMap_);
				if (other.IsAudioCustomMapped)
				{
					IsAudioCustomMapped = other.IsAudioCustomMapped;
				}
				if (other.SourceCase == SourceOneofCase.OutputScreen)
				{
					if (OutputScreen == null)
					{
						OutputScreen = new Types.OutputScreenSource();
					}
					OutputScreen.MergeFrom(other.OutputScreen);
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
						if (id_ == null)
						{
							Id = new UUID();
						}
						input.ReadMessage(Id);
						break;
					case 18u:
					{
						Types.OutputScreenSource outputScreenSource = new Types.OutputScreenSource();
						if (sourceCase_ == SourceOneofCase.OutputScreen)
						{
							outputScreenSource.MergeFrom(OutputScreen);
						}
						input.ReadMessage(outputScreenSource);
						OutputScreen = outputScreenSource;
						break;
					}
					case 26u:
						if (encoder_ == null)
						{
							Encoder = new Types.Encoder();
						}
						input.ReadMessage(Encoder);
						break;
					case 34u:
						destinations_.AddEntriesFrom(input, _repeated_destinations_codec);
						break;
					case 42u:
						audioMap_.AddEntriesFrom(input, _repeated_audioMap_codec);
						break;
					case 48u:
						IsAudioCustomMapped = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Recording> _parser = new MessageParser<Recording>(() => new Recording());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Recording> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RecordingReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording(Recording other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording Clone()
	{
		return new Recording(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Recording);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Recording other)
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
	public void MergeFrom(Recording other)
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
