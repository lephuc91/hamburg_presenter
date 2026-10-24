using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Media : IMessage<Media>, IMessage, IEquatable<Media>, IDeepCloneable<Media>
{
	public enum TypePropertiesOneofCase
	{
		None = 0,
		Audio = 4,
		Image = 5,
		Video = 6,
		LiveVideo = 7,
		WebContent = 8
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ScaleBehavior
		{
			[OriginalName("SCALE_BEHAVIOR_FIT")]
			Fit,
			[OriginalName("SCALE_BEHAVIOR_FILL")]
			Fill,
			[OriginalName("SCALE_BEHAVIOR_STRETCH")]
			Stretch,
			[OriginalName("SCALE_BEHAVIOR_CUSTOM")]
			Custom
		}

		public enum ScaleAlignment
		{
			[OriginalName("SCALE_ALIGNMENT_MIDDLE_CENTER")]
			MiddleCenter,
			[OriginalName("SCALE_ALIGNMENT_TOP_LEFT")]
			TopLeft,
			[OriginalName("SCALE_ALIGNMENT_TOP_CENTER")]
			TopCenter,
			[OriginalName("SCALE_ALIGNMENT_TOP_RIGHT")]
			TopRight,
			[OriginalName("SCALE_ALIGNMENT_MIDDLE_RIGHT")]
			MiddleRight,
			[OriginalName("SCALE_ALIGNMENT_BOTTOM_RIGHT")]
			BottomRight,
			[OriginalName("SCALE_ALIGNMENT_BOTTOM_CENTER")]
			BottomCenter,
			[OriginalName("SCALE_ALIGNMENT_BOTTOM_LEFT")]
			BottomLeft,
			[OriginalName("SCALE_ALIGNMENT_MIDDLE_LEFT")]
			MiddleLeft
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Metadata : IMessage<Metadata>, IMessage, IEquatable<Metadata>, IDeepCloneable<Metadata>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ColorFormat
				{
					[OriginalName("COLOR_FORMAT_UNKNOWN")]
					Unknown,
					[OriginalName("COLOR_FORMAT_SDR")]
					Sdr,
					[OriginalName("COLOR_FORMAT_HDR_REC_2100_HLG")]
					HdrRec2100Hlg,
					[OriginalName("COLOR_FORMAT_HDR_REC_2100_PQ")]
					HdrRec2100Pq
				}
			}

			private static readonly MessageParser<Metadata> _parser = new MessageParser<Metadata>(() => new Metadata());

			private UnknownFieldSet _unknownFields;

			public const int ManufactureNameFieldNumber = 1;

			private string manufactureName_ = "";

			public const int ManufactureUrlFieldNumber = 2;

			private URL manufactureUrl_;

			public const int InformationFieldNumber = 3;

			private string information_ = "";

			public const int ArtistFieldNumber = 4;

			private string artist_ = "";

			public const int FormatFieldNumber = 5;

			private string format_ = "";

			public const int ColorFormatFieldNumber = 6;

			private Types.ColorFormat colorFormat_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Metadata> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ManufactureName
			{
				get
				{
					return manufactureName_;
				}
				set
				{
					manufactureName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL ManufactureUrl
			{
				get
				{
					return manufactureUrl_;
				}
				set
				{
					manufactureUrl_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Information
			{
				get
				{
					return information_;
				}
				set
				{
					information_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public string Format
			{
				get
				{
					return format_;
				}
				set
				{
					format_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Metadata()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Metadata(Metadata other)
				: this()
			{
				manufactureName_ = other.manufactureName_;
				manufactureUrl_ = ((other.manufactureUrl_ != null) ? other.manufactureUrl_.Clone() : null);
				information_ = other.information_;
				artist_ = other.artist_;
				format_ = other.format_;
				colorFormat_ = other.colorFormat_;
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
				if (ManufactureName != other.ManufactureName)
				{
					return false;
				}
				if (!object.Equals(ManufactureUrl, other.ManufactureUrl))
				{
					return false;
				}
				if (Information != other.Information)
				{
					return false;
				}
				if (Artist != other.Artist)
				{
					return false;
				}
				if (Format != other.Format)
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
				if (ManufactureName.Length != 0)
				{
					num ^= ManufactureName.GetHashCode();
				}
				if (manufactureUrl_ != null)
				{
					num ^= ManufactureUrl.GetHashCode();
				}
				if (Information.Length != 0)
				{
					num ^= Information.GetHashCode();
				}
				if (Artist.Length != 0)
				{
					num ^= Artist.GetHashCode();
				}
				if (Format.Length != 0)
				{
					num ^= Format.GetHashCode();
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
				if (ManufactureName.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(ManufactureName);
				}
				if (manufactureUrl_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(ManufactureUrl);
				}
				if (Information.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Information);
				}
				if (Artist.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(Artist);
				}
				if (Format.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Format);
				}
				if (ColorFormat != 0)
				{
					output.WriteRawTag(48);
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
				if (ManufactureName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ManufactureName);
				}
				if (manufactureUrl_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ManufactureUrl);
				}
				if (Information.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Information);
				}
				if (Artist.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Artist);
				}
				if (Format.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Format);
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
			public void MergeFrom(Metadata other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ManufactureName.Length != 0)
				{
					ManufactureName = other.ManufactureName;
				}
				if (other.manufactureUrl_ != null)
				{
					if (manufactureUrl_ == null)
					{
						ManufactureUrl = new URL();
					}
					ManufactureUrl.MergeFrom(other.ManufactureUrl);
				}
				if (other.Information.Length != 0)
				{
					Information = other.Information;
				}
				if (other.Artist.Length != 0)
				{
					Artist = other.Artist;
				}
				if (other.Format.Length != 0)
				{
					Format = other.Format;
				}
				if (other.ColorFormat != 0)
				{
					ColorFormat = other.ColorFormat;
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
						ManufactureName = input.ReadString();
						break;
					case 18u:
						if (manufactureUrl_ == null)
						{
							ManufactureUrl = new URL();
						}
						input.ReadMessage(ManufactureUrl);
						break;
					case 26u:
						Information = input.ReadString();
						break;
					case 34u:
						Artist = input.ReadString();
						break;
					case 42u:
						Format = input.ReadString();
						break;
					case 48u:
						ColorFormat = (Types.ColorFormat)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class VideoDevice : IMessage<VideoDevice>, IMessage, IEquatable<VideoDevice>, IDeepCloneable<VideoDevice>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Type
				{
					[OriginalName("TYPE_GENERIC")]
					Generic,
					[OriginalName("TYPE_DIRECTSHOW")]
					Directshow,
					[OriginalName("TYPE_BLACKMAGIC")]
					Blackmagic,
					[OriginalName("TYPE_AJA")]
					Aja,
					[OriginalName("TYPE_AV")]
					Av,
					[OriginalName("TYPE_SYPHON")]
					Syphon,
					[OriginalName("TYPE_NDI")]
					Ndi,
					[OriginalName("TYPE_BLUEFISH")]
					Bluefish,
					[OriginalName("TYPE_AIRCAST")]
					Aircast
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AirCast : IMessage<AirCast>, IMessage, IEquatable<AirCast>, IDeepCloneable<AirCast>
				{
					private static readonly MessageParser<AirCast> _parser = new MessageParser<AirCast>(() => new AirCast());

					private UnknownFieldSet _unknownFields;

					public const int ServiceNameFieldNumber = 1;

					private string serviceName_ = "";

					public const int PasswordFieldNumber = 2;

					private string password_ = "";

					public const int PasswordEnabledFieldNumber = 3;

					private bool passwordEnabled_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AirCast> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => VideoDevice.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string ServiceName
					{
						get
						{
							return serviceName_;
						}
						set
						{
							serviceName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Password
					{
						get
						{
							return password_;
						}
						set
						{
							password_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool PasswordEnabled
					{
						get
						{
							return passwordEnabled_;
						}
						set
						{
							passwordEnabled_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AirCast()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AirCast(AirCast other)
						: this()
					{
						serviceName_ = other.serviceName_;
						password_ = other.password_;
						passwordEnabled_ = other.passwordEnabled_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AirCast Clone()
					{
						return new AirCast(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AirCast);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AirCast other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ServiceName != other.ServiceName)
						{
							return false;
						}
						if (Password != other.Password)
						{
							return false;
						}
						if (PasswordEnabled != other.PasswordEnabled)
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
						if (ServiceName.Length != 0)
						{
							num ^= ServiceName.GetHashCode();
						}
						if (Password.Length != 0)
						{
							num ^= Password.GetHashCode();
						}
						if (PasswordEnabled)
						{
							num ^= PasswordEnabled.GetHashCode();
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
						if (ServiceName.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(ServiceName);
						}
						if (Password.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Password);
						}
						if (PasswordEnabled)
						{
							output.WriteRawTag(24);
							output.WriteBool(PasswordEnabled);
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
						if (ServiceName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(ServiceName);
						}
						if (Password.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Password);
						}
						if (PasswordEnabled)
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
					public void MergeFrom(AirCast other)
					{
						if (other != null)
						{
							if (other.ServiceName.Length != 0)
							{
								ServiceName = other.ServiceName;
							}
							if (other.Password.Length != 0)
							{
								Password = other.Password;
							}
							if (other.PasswordEnabled)
							{
								PasswordEnabled = other.PasswordEnabled;
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
								ServiceName = input.ReadString();
								break;
							case 18u:
								Password = input.ReadString();
								break;
							case 24u:
								PasswordEnabled = input.ReadBool();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<VideoDevice> _parser = new MessageParser<VideoDevice>(() => new VideoDevice());

			private UnknownFieldSet _unknownFields;

			public const int TypeFieldNumber = 1;

			private Types.Type type_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int UniqueIdFieldNumber = 3;

			private string uniqueId_ = "";

			public const int ModelIdFieldNumber = 4;

			private string modelId_ = "";

			public const int FormatIndexFieldNumber = 5;

			private uint formatIndex_;

			public const int AudioRoutingFieldNumber = 6;

			private DigitalAudio.Types.Device.Types.Routing audioRouting_;

			public const int AircastFieldNumber = 7;

			private Types.AirCast aircast_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoDevice> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Type Type
			{
				get
				{
					return type_;
				}
				set
				{
					type_ = value;
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
			public string UniqueId
			{
				get
				{
					return uniqueId_;
				}
				set
				{
					uniqueId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ModelId
			{
				get
				{
					return modelId_;
				}
				set
				{
					modelId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint FormatIndex
			{
				get
				{
					return formatIndex_;
				}
				set
				{
					formatIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DigitalAudio.Types.Device.Types.Routing AudioRouting
			{
				get
				{
					return audioRouting_;
				}
				set
				{
					audioRouting_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AirCast Aircast
			{
				get
				{
					return aircast_;
				}
				set
				{
					aircast_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoDevice()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoDevice(VideoDevice other)
				: this()
			{
				type_ = other.type_;
				name_ = other.name_;
				uniqueId_ = other.uniqueId_;
				modelId_ = other.modelId_;
				formatIndex_ = other.formatIndex_;
				audioRouting_ = ((other.audioRouting_ != null) ? other.audioRouting_.Clone() : null);
				aircast_ = ((other.aircast_ != null) ? other.aircast_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoDevice Clone()
			{
				return new VideoDevice(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as VideoDevice);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(VideoDevice other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Type != other.Type)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (UniqueId != other.UniqueId)
				{
					return false;
				}
				if (ModelId != other.ModelId)
				{
					return false;
				}
				if (FormatIndex != other.FormatIndex)
				{
					return false;
				}
				if (!object.Equals(AudioRouting, other.AudioRouting))
				{
					return false;
				}
				if (!object.Equals(Aircast, other.Aircast))
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
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (UniqueId.Length != 0)
				{
					num ^= UniqueId.GetHashCode();
				}
				if (ModelId.Length != 0)
				{
					num ^= ModelId.GetHashCode();
				}
				if (FormatIndex != 0)
				{
					num ^= FormatIndex.GetHashCode();
				}
				if (audioRouting_ != null)
				{
					num ^= AudioRouting.GetHashCode();
				}
				if (aircast_ != null)
				{
					num ^= Aircast.GetHashCode();
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
				if (Type != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Type);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (UniqueId.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(UniqueId);
				}
				if (ModelId.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(ModelId);
				}
				if (FormatIndex != 0)
				{
					output.WriteRawTag(40);
					output.WriteUInt32(FormatIndex);
				}
				if (audioRouting_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(AudioRouting);
				}
				if (aircast_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Aircast);
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
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (UniqueId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(UniqueId);
				}
				if (ModelId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ModelId);
				}
				if (FormatIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(FormatIndex);
				}
				if (audioRouting_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioRouting);
				}
				if (aircast_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Aircast);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(VideoDevice other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Type != 0)
				{
					Type = other.Type;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.UniqueId.Length != 0)
				{
					UniqueId = other.UniqueId;
				}
				if (other.ModelId.Length != 0)
				{
					ModelId = other.ModelId;
				}
				if (other.FormatIndex != 0)
				{
					FormatIndex = other.FormatIndex;
				}
				if (other.audioRouting_ != null)
				{
					if (audioRouting_ == null)
					{
						AudioRouting = new DigitalAudio.Types.Device.Types.Routing();
					}
					AudioRouting.MergeFrom(other.AudioRouting);
				}
				if (other.aircast_ != null)
				{
					if (aircast_ == null)
					{
						Aircast = new Types.AirCast();
					}
					Aircast.MergeFrom(other.Aircast);
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
					case 8u:
						Type = (Types.Type)input.ReadEnum();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						UniqueId = input.ReadString();
						break;
					case 34u:
						ModelId = input.ReadString();
						break;
					case 40u:
						FormatIndex = input.ReadUInt32();
						break;
					case 50u:
						if (audioRouting_ == null)
						{
							AudioRouting = new DigitalAudio.Types.Device.Types.Routing();
						}
						input.ReadMessage(AudioRouting);
						break;
					case 58u:
						if (aircast_ == null)
						{
							Aircast = new Types.AirCast();
						}
						input.ReadMessage(Aircast);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AudioDevice : IMessage<AudioDevice>, IMessage, IEquatable<AudioDevice>, IDeepCloneable<AudioDevice>
		{
			private static readonly MessageParser<AudioDevice> _parser = new MessageParser<AudioDevice>(() => new AudioDevice());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int UniqueIdFieldNumber = 2;

			private string uniqueId_ = "";

			public const int ModelIdFieldNumber = 3;

			private string modelId_ = "";

			public const int ChannelCountFieldNumber = 4;

			private uint channelCount_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioDevice> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public string UniqueId
			{
				get
				{
					return uniqueId_;
				}
				set
				{
					uniqueId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ModelId
			{
				get
				{
					return modelId_;
				}
				set
				{
					modelId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint ChannelCount
			{
				get
				{
					return channelCount_;
				}
				set
				{
					channelCount_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioDevice()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioDevice(AudioDevice other)
				: this()
			{
				name_ = other.name_;
				uniqueId_ = other.uniqueId_;
				modelId_ = other.modelId_;
				channelCount_ = other.channelCount_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioDevice Clone()
			{
				return new AudioDevice(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioDevice);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioDevice other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (UniqueId != other.UniqueId)
				{
					return false;
				}
				if (ModelId != other.ModelId)
				{
					return false;
				}
				if (ChannelCount != other.ChannelCount)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (UniqueId.Length != 0)
				{
					num ^= UniqueId.GetHashCode();
				}
				if (ModelId.Length != 0)
				{
					num ^= ModelId.GetHashCode();
				}
				if (ChannelCount != 0)
				{
					num ^= ChannelCount.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (UniqueId.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(UniqueId);
				}
				if (ModelId.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(ModelId);
				}
				if (ChannelCount != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(ChannelCount);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (UniqueId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(UniqueId);
				}
				if (ModelId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ModelId);
				}
				if (ChannelCount != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(ChannelCount);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AudioDevice other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.UniqueId.Length != 0)
					{
						UniqueId = other.UniqueId;
					}
					if (other.ModelId.Length != 0)
					{
						ModelId = other.ModelId;
					}
					if (other.ChannelCount != 0)
					{
						ChannelCount = other.ChannelCount;
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
						Name = input.ReadString();
						break;
					case 18u:
						UniqueId = input.ReadString();
						break;
					case 26u:
						ModelId = input.ReadString();
						break;
					case 32u:
						ChannelCount = input.ReadUInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Channel : IMessage<Channel>, IMessage, IEquatable<Channel>, IDeepCloneable<Channel>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Output : IMessage<Output>, IMessage, IEquatable<Output>, IDeepCloneable<Output>
						{
							private static readonly MessageParser<Output> _parser = new MessageParser<Output>(() => new Output());

							private UnknownFieldSet _unknownFields;

							public const int ChannelIndexFieldNumber = 2;

							private int channelIndex_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Output> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Channel.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public int ChannelIndex
							{
								get
								{
									return channelIndex_;
								}
								set
								{
									channelIndex_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Output()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Output(Output other)
								: this()
							{
								channelIndex_ = other.channelIndex_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Output Clone()
							{
								return new Output(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Output);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Output other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (ChannelIndex != other.ChannelIndex)
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
								if (ChannelIndex != 0)
								{
									num ^= ChannelIndex.GetHashCode();
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
								if (ChannelIndex != 0)
								{
									output.WriteRawTag(16);
									output.WriteInt32(ChannelIndex);
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
								if (ChannelIndex != 0)
								{
									num += 1 + CodedOutputStream.ComputeInt32Size(ChannelIndex);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Output other)
							{
								if (other != null)
								{
									if (other.ChannelIndex != 0)
									{
										ChannelIndex = other.ChannelIndex;
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
									if (num != 16)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
									}
									else
									{
										ChannelIndex = input.ReadInt32();
									}
								}
							}
						}
					}

					private static readonly MessageParser<Channel> _parser = new MessageParser<Channel>(() => new Channel());

					private UnknownFieldSet _unknownFields;

					public const int IndexFieldNumber = 1;

					private uint index_;

					public const int MutedFieldNumber = 2;

					private bool muted_;

					public const int VolumeFieldNumber = 3;

					private double volume_;

					public const int CompressLimitFieldNumber = 4;

					private bool compressLimit_;

					public const int OutputsFieldNumber = 5;

					private static readonly FieldCodec<Types.Output> _repeated_outputs_codec = FieldCodec.ForMessage(42u, Types.Output.Parser);

					private readonly RepeatedField<Types.Output> outputs_ = new RepeatedField<Types.Output>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Channel> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Audio.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Index
					{
						get
						{
							return index_;
						}
						set
						{
							index_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Muted
					{
						get
						{
							return muted_;
						}
						set
						{
							muted_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Volume
					{
						get
						{
							return volume_;
						}
						set
						{
							volume_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool CompressLimit
					{
						get
						{
							return compressLimit_;
						}
						set
						{
							compressLimit_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Types.Output> Outputs => outputs_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel(Channel other)
						: this()
					{
						index_ = other.index_;
						muted_ = other.muted_;
						volume_ = other.volume_;
						compressLimit_ = other.compressLimit_;
						outputs_ = other.outputs_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Channel Clone()
					{
						return new Channel(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Channel);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Channel other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Index != other.Index)
						{
							return false;
						}
						if (Muted != other.Muted)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Volume, other.Volume))
						{
							return false;
						}
						if (CompressLimit != other.CompressLimit)
						{
							return false;
						}
						if (!outputs_.Equals(other.outputs_))
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
						if (Index != 0)
						{
							num ^= Index.GetHashCode();
						}
						if (Muted)
						{
							num ^= Muted.GetHashCode();
						}
						if (Volume != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Volume);
						}
						if (CompressLimit)
						{
							num ^= CompressLimit.GetHashCode();
						}
						num ^= outputs_.GetHashCode();
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
						if (Index != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(Index);
						}
						if (Muted)
						{
							output.WriteRawTag(16);
							output.WriteBool(Muted);
						}
						if (Volume != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(Volume);
						}
						if (CompressLimit)
						{
							output.WriteRawTag(32);
							output.WriteBool(CompressLimit);
						}
						outputs_.WriteTo(output, _repeated_outputs_codec);
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
						if (Index != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
						}
						if (Muted)
						{
							num += 2;
						}
						if (Volume != 0.0)
						{
							num += 9;
						}
						if (CompressLimit)
						{
							num += 2;
						}
						num += outputs_.CalculateSize(_repeated_outputs_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Channel other)
					{
						if (other != null)
						{
							if (other.Index != 0)
							{
								Index = other.Index;
							}
							if (other.Muted)
							{
								Muted = other.Muted;
							}
							if (other.Volume != 0.0)
							{
								Volume = other.Volume;
							}
							if (other.CompressLimit)
							{
								CompressLimit = other.CompressLimit;
							}
							outputs_.Add(other.outputs_);
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
								Index = input.ReadUInt32();
								break;
							case 16u:
								Muted = input.ReadBool();
								break;
							case 25u:
								Volume = input.ReadDouble();
								break;
							case 32u:
								CompressLimit = input.ReadBool();
								break;
							case 42u:
								outputs_.AddEntriesFrom(input, _repeated_outputs_codec);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Audio> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio(Audio other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio Clone()
			{
				return new Audio(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Audio);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Audio other)
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
			public void MergeFrom(Audio other)
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
		public sealed class AudioProperties : IMessage<AudioProperties>, IMessage, IEquatable<AudioProperties>, IDeepCloneable<AudioProperties>
		{
			private static readonly MessageParser<AudioProperties> _parser = new MessageParser<AudioProperties>(() => new AudioProperties());

			private UnknownFieldSet _unknownFields;

			public const int VolumeFieldNumber = 1;

			private double volume_;

			public const int AudioChannelsFieldNumber = 2;

			private static readonly FieldCodec<Audio.Types.Channel> _repeated_audioChannels_codec = FieldCodec.ForMessage(18u, Audio.Types.Channel.Parser);

			private readonly RepeatedField<Audio.Types.Channel> audioChannels_ = new RepeatedField<Audio.Types.Channel>();

			public const int IsCustomMappingFieldNumber = 3;

			private bool isCustomMapping_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Volume
			{
				get
				{
					return volume_;
				}
				set
				{
					volume_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Audio.Types.Channel> AudioChannels => audioChannels_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsCustomMapping
			{
				get
				{
					return isCustomMapping_;
				}
				set
				{
					isCustomMapping_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties(AudioProperties other)
				: this()
			{
				volume_ = other.volume_;
				audioChannels_ = other.audioChannels_.Clone();
				isCustomMapping_ = other.isCustomMapping_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties Clone()
			{
				return new AudioProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Volume, other.Volume))
				{
					return false;
				}
				if (!audioChannels_.Equals(other.audioChannels_))
				{
					return false;
				}
				if (IsCustomMapping != other.IsCustomMapping)
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
				if (Volume != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Volume);
				}
				num ^= audioChannels_.GetHashCode();
				if (IsCustomMapping)
				{
					num ^= IsCustomMapping.GetHashCode();
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
				if (Volume != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Volume);
				}
				audioChannels_.WriteTo(output, _repeated_audioChannels_codec);
				if (IsCustomMapping)
				{
					output.WriteRawTag(24);
					output.WriteBool(IsCustomMapping);
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
				if (Volume != 0.0)
				{
					num += 9;
				}
				num += audioChannels_.CalculateSize(_repeated_audioChannels_codec);
				if (IsCustomMapping)
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
			public void MergeFrom(AudioProperties other)
			{
				if (other != null)
				{
					if (other.Volume != 0.0)
					{
						Volume = other.Volume;
					}
					audioChannels_.Add(other.audioChannels_);
					if (other.IsCustomMapping)
					{
						IsCustomMapping = other.IsCustomMapping;
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
					case 9u:
						Volume = input.ReadDouble();
						break;
					case 18u:
						audioChannels_.AddEntriesFrom(input, _repeated_audioChannels_codec);
						break;
					case 24u:
						IsCustomMapping = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TransportProperties : IMessage<TransportProperties>, IMessage, IEquatable<TransportProperties>, IDeepCloneable<TransportProperties>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum PlaybackBehavior
				{
					[OriginalName("PLAYBACK_BEHAVIOR_STOP")]
					Stop,
					[OriginalName("PLAYBACK_BEHAVIOR_LOOP")]
					Loop,
					[OriginalName("PLAYBACK_BEHAVIOR_LOOP_FOR_COUNT")]
					LoopForCount,
					[OriginalName("PLAYBACK_BEHAVIOR_LOOP_FOR_TIME")]
					LoopForTime
				}

				public enum RetriggerSetting
				{
					[OriginalName("RETRIGGER_SETTING_UNSET")]
					Unset,
					[OriginalName("RETRIGGER_SETTING_ALWAYS")]
					Always,
					[OriginalName("RETRIGGER_SETTING_NEVER")]
					Never,
					[OriginalName("RETRIGGER_SETTING_AUTOMATIC")]
					Automatic
				}
			}

			private static readonly MessageParser<TransportProperties> _parser = new MessageParser<TransportProperties>(() => new TransportProperties());

			private UnknownFieldSet _unknownFields;

			public const int PlayRateFieldNumber = 1;

			private double playRate_;

			public const int InPointFieldNumber = 2;

			private double inPoint_;

			public const int OutPointFieldNumber = 3;

			private double outPoint_;

			public const int FadeInDurationFieldNumber = 7;

			private double fadeInDuration_;

			public const int FadeOutDurationFieldNumber = 8;

			private double fadeOutDuration_;

			public const int ShouldFadeInFieldNumber = 9;

			private bool shouldFadeIn_;

			public const int ShouldFadeOutFieldNumber = 10;

			private bool shouldFadeOut_;

			public const int EndPointFieldNumber = 11;

			private double endPoint_;

			public const int PlaybackBehaviorFieldNumber = 12;

			private Types.PlaybackBehavior playbackBehavior_;

			public const int LoopTimeFieldNumber = 13;

			private double loopTime_;

			public const int TimesToLoopFieldNumber = 14;

			private uint timesToLoop_;

			public const int RetriggerFieldNumber = 15;

			private Types.RetriggerSetting retrigger_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TransportProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double PlayRate
			{
				get
				{
					return playRate_;
				}
				set
				{
					playRate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double InPoint
			{
				get
				{
					return inPoint_;
				}
				set
				{
					inPoint_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double OutPoint
			{
				get
				{
					return outPoint_;
				}
				set
				{
					outPoint_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FadeInDuration
			{
				get
				{
					return fadeInDuration_;
				}
				set
				{
					fadeInDuration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FadeOutDuration
			{
				get
				{
					return fadeOutDuration_;
				}
				set
				{
					fadeOutDuration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShouldFadeIn
			{
				get
				{
					return shouldFadeIn_;
				}
				set
				{
					shouldFadeIn_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShouldFadeOut
			{
				get
				{
					return shouldFadeOut_;
				}
				set
				{
					shouldFadeOut_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double EndPoint
			{
				get
				{
					return endPoint_;
				}
				set
				{
					endPoint_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.PlaybackBehavior PlaybackBehavior
			{
				get
				{
					return playbackBehavior_;
				}
				set
				{
					playbackBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double LoopTime
			{
				get
				{
					return loopTime_;
				}
				set
				{
					loopTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint TimesToLoop
			{
				get
				{
					return timesToLoop_;
				}
				set
				{
					timesToLoop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.RetriggerSetting Retrigger
			{
				get
				{
					return retrigger_;
				}
				set
				{
					retrigger_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportProperties(TransportProperties other)
				: this()
			{
				playRate_ = other.playRate_;
				inPoint_ = other.inPoint_;
				outPoint_ = other.outPoint_;
				fadeInDuration_ = other.fadeInDuration_;
				fadeOutDuration_ = other.fadeOutDuration_;
				shouldFadeIn_ = other.shouldFadeIn_;
				shouldFadeOut_ = other.shouldFadeOut_;
				endPoint_ = other.endPoint_;
				playbackBehavior_ = other.playbackBehavior_;
				loopTime_ = other.loopTime_;
				timesToLoop_ = other.timesToLoop_;
				retrigger_ = other.retrigger_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportProperties Clone()
			{
				return new TransportProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TransportProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TransportProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PlayRate, other.PlayRate))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(InPoint, other.InPoint))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(OutPoint, other.OutPoint))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeInDuration, other.FadeInDuration))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeOutDuration, other.FadeOutDuration))
				{
					return false;
				}
				if (ShouldFadeIn != other.ShouldFadeIn)
				{
					return false;
				}
				if (ShouldFadeOut != other.ShouldFadeOut)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(EndPoint, other.EndPoint))
				{
					return false;
				}
				if (PlaybackBehavior != other.PlaybackBehavior)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LoopTime, other.LoopTime))
				{
					return false;
				}
				if (TimesToLoop != other.TimesToLoop)
				{
					return false;
				}
				if (Retrigger != other.Retrigger)
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
				if (PlayRate != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PlayRate);
				}
				if (InPoint != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(InPoint);
				}
				if (OutPoint != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(OutPoint);
				}
				if (FadeInDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeInDuration);
				}
				if (FadeOutDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeOutDuration);
				}
				if (ShouldFadeIn)
				{
					num ^= ShouldFadeIn.GetHashCode();
				}
				if (ShouldFadeOut)
				{
					num ^= ShouldFadeOut.GetHashCode();
				}
				if (EndPoint != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(EndPoint);
				}
				if (PlaybackBehavior != 0)
				{
					num ^= PlaybackBehavior.GetHashCode();
				}
				if (LoopTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LoopTime);
				}
				if (TimesToLoop != 0)
				{
					num ^= TimesToLoop.GetHashCode();
				}
				if (Retrigger != 0)
				{
					num ^= Retrigger.GetHashCode();
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
				if (PlayRate != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(PlayRate);
				}
				if (InPoint != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(InPoint);
				}
				if (OutPoint != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(OutPoint);
				}
				if (FadeInDuration != 0.0)
				{
					output.WriteRawTag(57);
					output.WriteDouble(FadeInDuration);
				}
				if (FadeOutDuration != 0.0)
				{
					output.WriteRawTag(65);
					output.WriteDouble(FadeOutDuration);
				}
				if (ShouldFadeIn)
				{
					output.WriteRawTag(72);
					output.WriteBool(ShouldFadeIn);
				}
				if (ShouldFadeOut)
				{
					output.WriteRawTag(80);
					output.WriteBool(ShouldFadeOut);
				}
				if (EndPoint != 0.0)
				{
					output.WriteRawTag(89);
					output.WriteDouble(EndPoint);
				}
				if (PlaybackBehavior != 0)
				{
					output.WriteRawTag(96);
					output.WriteEnum((int)PlaybackBehavior);
				}
				if (LoopTime != 0.0)
				{
					output.WriteRawTag(105);
					output.WriteDouble(LoopTime);
				}
				if (TimesToLoop != 0)
				{
					output.WriteRawTag(112);
					output.WriteUInt32(TimesToLoop);
				}
				if (Retrigger != 0)
				{
					output.WriteRawTag(120);
					output.WriteEnum((int)Retrigger);
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
				if (PlayRate != 0.0)
				{
					num += 9;
				}
				if (InPoint != 0.0)
				{
					num += 9;
				}
				if (OutPoint != 0.0)
				{
					num += 9;
				}
				if (FadeInDuration != 0.0)
				{
					num += 9;
				}
				if (FadeOutDuration != 0.0)
				{
					num += 9;
				}
				if (ShouldFadeIn)
				{
					num += 2;
				}
				if (ShouldFadeOut)
				{
					num += 2;
				}
				if (EndPoint != 0.0)
				{
					num += 9;
				}
				if (PlaybackBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
				}
				if (LoopTime != 0.0)
				{
					num += 9;
				}
				if (TimesToLoop != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(TimesToLoop);
				}
				if (Retrigger != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Retrigger);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TransportProperties other)
			{
				if (other != null)
				{
					if (other.PlayRate != 0.0)
					{
						PlayRate = other.PlayRate;
					}
					if (other.InPoint != 0.0)
					{
						InPoint = other.InPoint;
					}
					if (other.OutPoint != 0.0)
					{
						OutPoint = other.OutPoint;
					}
					if (other.FadeInDuration != 0.0)
					{
						FadeInDuration = other.FadeInDuration;
					}
					if (other.FadeOutDuration != 0.0)
					{
						FadeOutDuration = other.FadeOutDuration;
					}
					if (other.ShouldFadeIn)
					{
						ShouldFadeIn = other.ShouldFadeIn;
					}
					if (other.ShouldFadeOut)
					{
						ShouldFadeOut = other.ShouldFadeOut;
					}
					if (other.EndPoint != 0.0)
					{
						EndPoint = other.EndPoint;
					}
					if (other.PlaybackBehavior != 0)
					{
						PlaybackBehavior = other.PlaybackBehavior;
					}
					if (other.LoopTime != 0.0)
					{
						LoopTime = other.LoopTime;
					}
					if (other.TimesToLoop != 0)
					{
						TimesToLoop = other.TimesToLoop;
					}
					if (other.Retrigger != 0)
					{
						Retrigger = other.Retrigger;
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
					case 9u:
						PlayRate = input.ReadDouble();
						break;
					case 17u:
						InPoint = input.ReadDouble();
						break;
					case 25u:
						OutPoint = input.ReadDouble();
						break;
					case 57u:
						FadeInDuration = input.ReadDouble();
						break;
					case 65u:
						FadeOutDuration = input.ReadDouble();
						break;
					case 72u:
						ShouldFadeIn = input.ReadBool();
						break;
					case 80u:
						ShouldFadeOut = input.ReadBool();
						break;
					case 89u:
						EndPoint = input.ReadDouble();
						break;
					case 96u:
						PlaybackBehavior = (Types.PlaybackBehavior)input.ReadEnum();
						break;
					case 105u:
						LoopTime = input.ReadDouble();
						break;
					case 112u:
						TimesToLoop = input.ReadUInt32();
						break;
					case 120u:
						Retrigger = (Types.RetriggerSetting)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DrawingProperties : IMessage<DrawingProperties>, IMessage, IEquatable<DrawingProperties>, IDeepCloneable<DrawingProperties>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum NativeRotationType
				{
					[OriginalName("NATIVE_ROTATION_TYPE_ROTATE_STANDARD")]
					RotateStandard = 0,
					[OriginalName("NATIVE_ROTATION_TYPE_ROTATE_90")]
					Rotate90 = 90,
					[OriginalName("NATIVE_ROTATION_TYPE_ROTATE_180")]
					Rotate180 = 180,
					[OriginalName("NATIVE_ROTATION_TYPE_ROTATE_270")]
					Rotate270 = 270
				}
			}

			private static readonly MessageParser<DrawingProperties> _parser = new MessageParser<DrawingProperties>(() => new DrawingProperties());

			private UnknownFieldSet _unknownFields;

			public const int ScaleBehaviorFieldNumber = 1;

			private ScaleBehavior scaleBehavior_;

			public const int IsBlurredFieldNumber = 16;

			private bool isBlurred_;

			public const int ScaleAlignmentFieldNumber = 2;

			private ScaleAlignment scaleAlignment_;

			public const int FlippedHorizontallyFieldNumber = 3;

			private bool flippedHorizontally_;

			public const int FlippedVerticallyFieldNumber = 4;

			private bool flippedVertically_;

			public const int NaturalSizeFieldNumber = 5;

			private Graphics.Types.Size naturalSize_;

			public const int CustomImageRotationFieldNumber = 6;

			private double customImageRotation_;

			public const int CustomImageBoundsFieldNumber = 7;

			private Graphics.Types.Rect customImageBounds_;

			public const int CustomImageAspectLockedFieldNumber = 8;

			private bool customImageAspectLocked_;

			public const int AlphaInvertedFieldNumber = 9;

			private bool alphaInverted_;

			public const int NativeRotationFieldNumber = 10;

			private Types.NativeRotationType nativeRotation_;

			public const int SelectedEffectPresetUuidFieldNumber = 11;

			private UUID selectedEffectPresetUuid_;

			public const int EffectsFieldNumber = 12;

			private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(98u, Effect.Parser);

			private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

			public const int CropEnableFieldNumber = 13;

			private bool cropEnable_;

			public const int CropInsetsFieldNumber = 14;

			private Graphics.Types.EdgeInsets cropInsets_;

			public const int AlphaTypeFieldNumber = 15;

			private AlphaType alphaType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DrawingProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScaleBehavior ScaleBehavior
			{
				get
				{
					return scaleBehavior_;
				}
				set
				{
					scaleBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsBlurred
			{
				get
				{
					return isBlurred_;
				}
				set
				{
					isBlurred_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScaleAlignment ScaleAlignment
			{
				get
				{
					return scaleAlignment_;
				}
				set
				{
					scaleAlignment_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool FlippedHorizontally
			{
				get
				{
					return flippedHorizontally_;
				}
				set
				{
					flippedHorizontally_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool FlippedVertically
			{
				get
				{
					return flippedVertically_;
				}
				set
				{
					flippedVertically_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Size NaturalSize
			{
				get
				{
					return naturalSize_;
				}
				set
				{
					naturalSize_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CustomImageRotation
			{
				get
				{
					return customImageRotation_;
				}
				set
				{
					customImageRotation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Rect CustomImageBounds
			{
				get
				{
					return customImageBounds_;
				}
				set
				{
					customImageBounds_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool CustomImageAspectLocked
			{
				get
				{
					return customImageAspectLocked_;
				}
				set
				{
					customImageAspectLocked_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AlphaInverted
			{
				get
				{
					return alphaInverted_;
				}
				set
				{
					alphaInverted_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.NativeRotationType NativeRotation
			{
				get
				{
					return nativeRotation_;
				}
				set
				{
					nativeRotation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID SelectedEffectPresetUuid
			{
				get
				{
					return selectedEffectPresetUuid_;
				}
				set
				{
					selectedEffectPresetUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Effect> Effects => effects_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool CropEnable
			{
				get
				{
					return cropEnable_;
				}
				set
				{
					cropEnable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.EdgeInsets CropInsets
			{
				get
				{
					return cropInsets_;
				}
				set
				{
					cropInsets_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AlphaType AlphaType
			{
				get
				{
					return alphaType_;
				}
				set
				{
					alphaType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties(DrawingProperties other)
				: this()
			{
				scaleBehavior_ = other.scaleBehavior_;
				isBlurred_ = other.isBlurred_;
				scaleAlignment_ = other.scaleAlignment_;
				flippedHorizontally_ = other.flippedHorizontally_;
				flippedVertically_ = other.flippedVertically_;
				naturalSize_ = ((other.naturalSize_ != null) ? other.naturalSize_.Clone() : null);
				customImageRotation_ = other.customImageRotation_;
				customImageBounds_ = ((other.customImageBounds_ != null) ? other.customImageBounds_.Clone() : null);
				customImageAspectLocked_ = other.customImageAspectLocked_;
				alphaInverted_ = other.alphaInverted_;
				nativeRotation_ = other.nativeRotation_;
				selectedEffectPresetUuid_ = ((other.selectedEffectPresetUuid_ != null) ? other.selectedEffectPresetUuid_.Clone() : null);
				effects_ = other.effects_.Clone();
				cropEnable_ = other.cropEnable_;
				cropInsets_ = ((other.cropInsets_ != null) ? other.cropInsets_.Clone() : null);
				alphaType_ = other.alphaType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties Clone()
			{
				return new DrawingProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DrawingProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DrawingProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ScaleBehavior != other.ScaleBehavior)
				{
					return false;
				}
				if (IsBlurred != other.IsBlurred)
				{
					return false;
				}
				if (ScaleAlignment != other.ScaleAlignment)
				{
					return false;
				}
				if (FlippedHorizontally != other.FlippedHorizontally)
				{
					return false;
				}
				if (FlippedVertically != other.FlippedVertically)
				{
					return false;
				}
				if (!object.Equals(NaturalSize, other.NaturalSize))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CustomImageRotation, other.CustomImageRotation))
				{
					return false;
				}
				if (!object.Equals(CustomImageBounds, other.CustomImageBounds))
				{
					return false;
				}
				if (CustomImageAspectLocked != other.CustomImageAspectLocked)
				{
					return false;
				}
				if (AlphaInverted != other.AlphaInverted)
				{
					return false;
				}
				if (NativeRotation != other.NativeRotation)
				{
					return false;
				}
				if (!object.Equals(SelectedEffectPresetUuid, other.SelectedEffectPresetUuid))
				{
					return false;
				}
				if (!effects_.Equals(other.effects_))
				{
					return false;
				}
				if (CropEnable != other.CropEnable)
				{
					return false;
				}
				if (!object.Equals(CropInsets, other.CropInsets))
				{
					return false;
				}
				if (AlphaType != other.AlphaType)
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
				if (ScaleBehavior != 0)
				{
					num ^= ScaleBehavior.GetHashCode();
				}
				if (IsBlurred)
				{
					num ^= IsBlurred.GetHashCode();
				}
				if (ScaleAlignment != 0)
				{
					num ^= ScaleAlignment.GetHashCode();
				}
				if (FlippedHorizontally)
				{
					num ^= FlippedHorizontally.GetHashCode();
				}
				if (FlippedVertically)
				{
					num ^= FlippedVertically.GetHashCode();
				}
				if (naturalSize_ != null)
				{
					num ^= NaturalSize.GetHashCode();
				}
				if (CustomImageRotation != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CustomImageRotation);
				}
				if (customImageBounds_ != null)
				{
					num ^= CustomImageBounds.GetHashCode();
				}
				if (CustomImageAspectLocked)
				{
					num ^= CustomImageAspectLocked.GetHashCode();
				}
				if (AlphaInverted)
				{
					num ^= AlphaInverted.GetHashCode();
				}
				if (NativeRotation != 0)
				{
					num ^= NativeRotation.GetHashCode();
				}
				if (selectedEffectPresetUuid_ != null)
				{
					num ^= SelectedEffectPresetUuid.GetHashCode();
				}
				num ^= effects_.GetHashCode();
				if (CropEnable)
				{
					num ^= CropEnable.GetHashCode();
				}
				if (cropInsets_ != null)
				{
					num ^= CropInsets.GetHashCode();
				}
				if (AlphaType != 0)
				{
					num ^= AlphaType.GetHashCode();
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
				if (ScaleBehavior != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)ScaleBehavior);
				}
				if (ScaleAlignment != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)ScaleAlignment);
				}
				if (FlippedHorizontally)
				{
					output.WriteRawTag(24);
					output.WriteBool(FlippedHorizontally);
				}
				if (FlippedVertically)
				{
					output.WriteRawTag(32);
					output.WriteBool(FlippedVertically);
				}
				if (naturalSize_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(NaturalSize);
				}
				if (CustomImageRotation != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(CustomImageRotation);
				}
				if (customImageBounds_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(CustomImageBounds);
				}
				if (CustomImageAspectLocked)
				{
					output.WriteRawTag(64);
					output.WriteBool(CustomImageAspectLocked);
				}
				if (AlphaInverted)
				{
					output.WriteRawTag(72);
					output.WriteBool(AlphaInverted);
				}
				if (NativeRotation != 0)
				{
					output.WriteRawTag(80);
					output.WriteEnum((int)NativeRotation);
				}
				if (selectedEffectPresetUuid_ != null)
				{
					output.WriteRawTag(90);
					output.WriteMessage(SelectedEffectPresetUuid);
				}
				effects_.WriteTo(output, _repeated_effects_codec);
				if (CropEnable)
				{
					output.WriteRawTag(104);
					output.WriteBool(CropEnable);
				}
				if (cropInsets_ != null)
				{
					output.WriteRawTag(114);
					output.WriteMessage(CropInsets);
				}
				if (AlphaType != 0)
				{
					output.WriteRawTag(120);
					output.WriteEnum((int)AlphaType);
				}
				if (IsBlurred)
				{
					output.WriteRawTag(128, 1);
					output.WriteBool(IsBlurred);
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
				if (ScaleBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ScaleBehavior);
				}
				if (IsBlurred)
				{
					num += 3;
				}
				if (ScaleAlignment != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ScaleAlignment);
				}
				if (FlippedHorizontally)
				{
					num += 2;
				}
				if (FlippedVertically)
				{
					num += 2;
				}
				if (naturalSize_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(NaturalSize);
				}
				if (CustomImageRotation != 0.0)
				{
					num += 9;
				}
				if (customImageBounds_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CustomImageBounds);
				}
				if (CustomImageAspectLocked)
				{
					num += 2;
				}
				if (AlphaInverted)
				{
					num += 2;
				}
				if (NativeRotation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)NativeRotation);
				}
				if (selectedEffectPresetUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SelectedEffectPresetUuid);
				}
				num += effects_.CalculateSize(_repeated_effects_codec);
				if (CropEnable)
				{
					num += 2;
				}
				if (cropInsets_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CropInsets);
				}
				if (AlphaType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DrawingProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ScaleBehavior != 0)
				{
					ScaleBehavior = other.ScaleBehavior;
				}
				if (other.IsBlurred)
				{
					IsBlurred = other.IsBlurred;
				}
				if (other.ScaleAlignment != 0)
				{
					ScaleAlignment = other.ScaleAlignment;
				}
				if (other.FlippedHorizontally)
				{
					FlippedHorizontally = other.FlippedHorizontally;
				}
				if (other.FlippedVertically)
				{
					FlippedVertically = other.FlippedVertically;
				}
				if (other.naturalSize_ != null)
				{
					if (naturalSize_ == null)
					{
						NaturalSize = new Graphics.Types.Size();
					}
					NaturalSize.MergeFrom(other.NaturalSize);
				}
				if (other.CustomImageRotation != 0.0)
				{
					CustomImageRotation = other.CustomImageRotation;
				}
				if (other.customImageBounds_ != null)
				{
					if (customImageBounds_ == null)
					{
						CustomImageBounds = new Graphics.Types.Rect();
					}
					CustomImageBounds.MergeFrom(other.CustomImageBounds);
				}
				if (other.CustomImageAspectLocked)
				{
					CustomImageAspectLocked = other.CustomImageAspectLocked;
				}
				if (other.AlphaInverted)
				{
					AlphaInverted = other.AlphaInverted;
				}
				if (other.NativeRotation != 0)
				{
					NativeRotation = other.NativeRotation;
				}
				if (other.selectedEffectPresetUuid_ != null)
				{
					if (selectedEffectPresetUuid_ == null)
					{
						SelectedEffectPresetUuid = new UUID();
					}
					SelectedEffectPresetUuid.MergeFrom(other.SelectedEffectPresetUuid);
				}
				effects_.Add(other.effects_);
				if (other.CropEnable)
				{
					CropEnable = other.CropEnable;
				}
				if (other.cropInsets_ != null)
				{
					if (cropInsets_ == null)
					{
						CropInsets = new Graphics.Types.EdgeInsets();
					}
					CropInsets.MergeFrom(other.CropInsets);
				}
				if (other.AlphaType != 0)
				{
					AlphaType = other.AlphaType;
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
					case 8u:
						ScaleBehavior = (ScaleBehavior)input.ReadEnum();
						break;
					case 16u:
						ScaleAlignment = (ScaleAlignment)input.ReadEnum();
						break;
					case 24u:
						FlippedHorizontally = input.ReadBool();
						break;
					case 32u:
						FlippedVertically = input.ReadBool();
						break;
					case 42u:
						if (naturalSize_ == null)
						{
							NaturalSize = new Graphics.Types.Size();
						}
						input.ReadMessage(NaturalSize);
						break;
					case 49u:
						CustomImageRotation = input.ReadDouble();
						break;
					case 58u:
						if (customImageBounds_ == null)
						{
							CustomImageBounds = new Graphics.Types.Rect();
						}
						input.ReadMessage(CustomImageBounds);
						break;
					case 64u:
						CustomImageAspectLocked = input.ReadBool();
						break;
					case 72u:
						AlphaInverted = input.ReadBool();
						break;
					case 80u:
						NativeRotation = (Types.NativeRotationType)input.ReadEnum();
						break;
					case 90u:
						if (selectedEffectPresetUuid_ == null)
						{
							SelectedEffectPresetUuid = new UUID();
						}
						input.ReadMessage(SelectedEffectPresetUuid);
						break;
					case 98u:
						effects_.AddEntriesFrom(input, _repeated_effects_codec);
						break;
					case 104u:
						CropEnable = input.ReadBool();
						break;
					case 114u:
						if (cropInsets_ == null)
						{
							CropInsets = new Graphics.Types.EdgeInsets();
						}
						input.ReadMessage(CropInsets);
						break;
					case 120u:
						AlphaType = (AlphaType)input.ReadEnum();
						break;
					case 128u:
						IsBlurred = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class VideoProperties : IMessage<VideoProperties>, IMessage, IEquatable<VideoProperties>, IDeepCloneable<VideoProperties>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum EndBehavior
				{
					[OriginalName("END_BEHAVIOR_STOP")]
					Stop,
					[OriginalName("END_BEHAVIOR_STOP_ON_BLACK")]
					StopOnBlack,
					[OriginalName("END_BEHAVIOR_STOP_ON_CLEAR")]
					StopOnClear,
					[OriginalName("END_BEHAVIOR_FADE_TO_BLACK")]
					FadeToBlack,
					[OriginalName("END_BEHAVIOR_FADE_TO_CLEAR")]
					FadeToClear
				}

				public enum FieldType
				{
					[OriginalName("FIELD_TYPE_UNKNOWN")]
					Unknown,
					[OriginalName("FIELD_TYPE_PROGRESSIVE")]
					Progressive,
					[OriginalName("FIELD_TYPE_INTERLACED_UPPER_FIRST")]
					InterlacedUpperFirst,
					[OriginalName("FIELD_TYPE_INTERLACED_LOWER_FIRST")]
					InterlacedLowerFirst
				}

				public enum HardwareDecodingType
				{
					[OriginalName("HARDWARE_DECODING_TYPE_AUTOMATIC")]
					Automatic = 0,
					[OriginalName("HARDWARE_DECODING_TYPE_DISABLED")]
					Disabled = 2
				}
			}

			private static readonly MessageParser<VideoProperties> _parser = new MessageParser<VideoProperties>(() => new VideoProperties());

			private UnknownFieldSet _unknownFields;

			public const int FrameRateFieldNumber = 1;

			private double frameRate_;

			public const int FieldTypeFieldNumber = 2;

			private Types.FieldType fieldType_;

			public const int ThumbnailPositionFieldNumber = 3;

			private double thumbnailPosition_;

			public const int EndBehaviorFieldNumber = 4;

			private Types.EndBehavior endBehavior_;

			public const int SoftLoopFieldNumber = 5;

			private bool softLoop_;

			public const int SoftLoopDurationFieldNumber = 6;

			private double softLoopDuration_;

			public const int HardwareDecodingFieldNumber = 7;

			private Types.HardwareDecodingType hardwareDecoding_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FrameRate
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
			public Types.FieldType FieldType
			{
				get
				{
					return fieldType_;
				}
				set
				{
					fieldType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double ThumbnailPosition
			{
				get
				{
					return thumbnailPosition_;
				}
				set
				{
					thumbnailPosition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EndBehavior EndBehavior
			{
				get
				{
					return endBehavior_;
				}
				set
				{
					endBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool SoftLoop
			{
				get
				{
					return softLoop_;
				}
				set
				{
					softLoop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double SoftLoopDuration
			{
				get
				{
					return softLoopDuration_;
				}
				set
				{
					softLoopDuration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.HardwareDecodingType HardwareDecoding
			{
				get
				{
					return hardwareDecoding_;
				}
				set
				{
					hardwareDecoding_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoProperties(VideoProperties other)
				: this()
			{
				frameRate_ = other.frameRate_;
				fieldType_ = other.fieldType_;
				thumbnailPosition_ = other.thumbnailPosition_;
				endBehavior_ = other.endBehavior_;
				softLoop_ = other.softLoop_;
				softLoopDuration_ = other.softLoopDuration_;
				hardwareDecoding_ = other.hardwareDecoding_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoProperties Clone()
			{
				return new VideoProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as VideoProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(VideoProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FrameRate, other.FrameRate))
				{
					return false;
				}
				if (FieldType != other.FieldType)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ThumbnailPosition, other.ThumbnailPosition))
				{
					return false;
				}
				if (EndBehavior != other.EndBehavior)
				{
					return false;
				}
				if (SoftLoop != other.SoftLoop)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SoftLoopDuration, other.SoftLoopDuration))
				{
					return false;
				}
				if (HardwareDecoding != other.HardwareDecoding)
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
				if (FrameRate != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FrameRate);
				}
				if (FieldType != 0)
				{
					num ^= FieldType.GetHashCode();
				}
				if (ThumbnailPosition != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ThumbnailPosition);
				}
				if (EndBehavior != 0)
				{
					num ^= EndBehavior.GetHashCode();
				}
				if (SoftLoop)
				{
					num ^= SoftLoop.GetHashCode();
				}
				if (SoftLoopDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SoftLoopDuration);
				}
				if (HardwareDecoding != 0)
				{
					num ^= HardwareDecoding.GetHashCode();
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
				if (FrameRate != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(FrameRate);
				}
				if (FieldType != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)FieldType);
				}
				if (ThumbnailPosition != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(ThumbnailPosition);
				}
				if (EndBehavior != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)EndBehavior);
				}
				if (SoftLoop)
				{
					output.WriteRawTag(40);
					output.WriteBool(SoftLoop);
				}
				if (SoftLoopDuration != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(SoftLoopDuration);
				}
				if (HardwareDecoding != 0)
				{
					output.WriteRawTag(56);
					output.WriteEnum((int)HardwareDecoding);
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
				if (FrameRate != 0.0)
				{
					num += 9;
				}
				if (FieldType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)FieldType);
				}
				if (ThumbnailPosition != 0.0)
				{
					num += 9;
				}
				if (EndBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)EndBehavior);
				}
				if (SoftLoop)
				{
					num += 2;
				}
				if (SoftLoopDuration != 0.0)
				{
					num += 9;
				}
				if (HardwareDecoding != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)HardwareDecoding);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(VideoProperties other)
			{
				if (other != null)
				{
					if (other.FrameRate != 0.0)
					{
						FrameRate = other.FrameRate;
					}
					if (other.FieldType != 0)
					{
						FieldType = other.FieldType;
					}
					if (other.ThumbnailPosition != 0.0)
					{
						ThumbnailPosition = other.ThumbnailPosition;
					}
					if (other.EndBehavior != 0)
					{
						EndBehavior = other.EndBehavior;
					}
					if (other.SoftLoop)
					{
						SoftLoop = other.SoftLoop;
					}
					if (other.SoftLoopDuration != 0.0)
					{
						SoftLoopDuration = other.SoftLoopDuration;
					}
					if (other.HardwareDecoding != 0)
					{
						HardwareDecoding = other.HardwareDecoding;
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
					case 9u:
						FrameRate = input.ReadDouble();
						break;
					case 16u:
						FieldType = (Types.FieldType)input.ReadEnum();
						break;
					case 25u:
						ThumbnailPosition = input.ReadDouble();
						break;
					case 32u:
						EndBehavior = (Types.EndBehavior)input.ReadEnum();
						break;
					case 40u:
						SoftLoop = input.ReadBool();
						break;
					case 49u:
						SoftLoopDuration = input.ReadDouble();
						break;
					case 56u:
						HardwareDecoding = (Types.HardwareDecodingType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LiveVideoProperties : IMessage<LiveVideoProperties>, IMessage, IEquatable<LiveVideoProperties>, IDeepCloneable<LiveVideoProperties>
		{
			private static readonly MessageParser<LiveVideoProperties> _parser = new MessageParser<LiveVideoProperties>(() => new LiveVideoProperties());

			private UnknownFieldSet _unknownFields;

			public const int VideoDeviceFieldNumber = 1;

			private VideoDevice videoDevice_;

			public const int AudioDeviceFieldNumber = 2;

			private AudioDevice audioDevice_;

			public const int LiveVideoIndexFieldNumber = 3;

			private int liveVideoIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LiveVideoProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoDevice VideoDevice
			{
				get
				{
					return videoDevice_;
				}
				set
				{
					videoDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioDevice AudioDevice
			{
				get
				{
					return audioDevice_;
				}
				set
				{
					audioDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int LiveVideoIndex
			{
				get
				{
					return liveVideoIndex_;
				}
				set
				{
					liveVideoIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoProperties(LiveVideoProperties other)
				: this()
			{
				videoDevice_ = ((other.videoDevice_ != null) ? other.videoDevice_.Clone() : null);
				audioDevice_ = ((other.audioDevice_ != null) ? other.audioDevice_.Clone() : null);
				liveVideoIndex_ = other.liveVideoIndex_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoProperties Clone()
			{
				return new LiveVideoProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LiveVideoProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LiveVideoProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(VideoDevice, other.VideoDevice))
				{
					return false;
				}
				if (!object.Equals(AudioDevice, other.AudioDevice))
				{
					return false;
				}
				if (LiveVideoIndex != other.LiveVideoIndex)
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
				if (videoDevice_ != null)
				{
					num ^= VideoDevice.GetHashCode();
				}
				if (audioDevice_ != null)
				{
					num ^= AudioDevice.GetHashCode();
				}
				if (LiveVideoIndex != 0)
				{
					num ^= LiveVideoIndex.GetHashCode();
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
				if (videoDevice_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(VideoDevice);
				}
				if (audioDevice_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(AudioDevice);
				}
				if (LiveVideoIndex != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(LiveVideoIndex);
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
				if (videoDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(VideoDevice);
				}
				if (audioDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioDevice);
				}
				if (LiveVideoIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(LiveVideoIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LiveVideoProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.videoDevice_ != null)
				{
					if (videoDevice_ == null)
					{
						VideoDevice = new VideoDevice();
					}
					VideoDevice.MergeFrom(other.VideoDevice);
				}
				if (other.audioDevice_ != null)
				{
					if (audioDevice_ == null)
					{
						AudioDevice = new AudioDevice();
					}
					AudioDevice.MergeFrom(other.AudioDevice);
				}
				if (other.LiveVideoIndex != 0)
				{
					LiveVideoIndex = other.LiveVideoIndex;
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
						if (videoDevice_ == null)
						{
							VideoDevice = new VideoDevice();
						}
						input.ReadMessage(VideoDevice);
						break;
					case 18u:
						if (audioDevice_ == null)
						{
							AudioDevice = new AudioDevice();
						}
						input.ReadMessage(AudioDevice);
						break;
					case 24u:
						LiveVideoIndex = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AudioTypeProperties : IMessage<AudioTypeProperties>, IMessage, IEquatable<AudioTypeProperties>, IDeepCloneable<AudioTypeProperties>
		{
			private static readonly MessageParser<AudioTypeProperties> _parser = new MessageParser<AudioTypeProperties>(() => new AudioTypeProperties());

			private UnknownFieldSet _unknownFields;

			public const int AudioFieldNumber = 1;

			private AudioProperties audio_;

			public const int TransportFieldNumber = 2;

			private TransportProperties transport_;

			public const int FileFieldNumber = 3;

			private FileProperties file_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioTypeProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties Audio
			{
				get
				{
					return audio_;
				}
				set
				{
					audio_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportProperties Transport
			{
				get
				{
					return transport_;
				}
				set
				{
					transport_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FileProperties File
			{
				get
				{
					return file_;
				}
				set
				{
					file_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioTypeProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioTypeProperties(AudioTypeProperties other)
				: this()
			{
				audio_ = ((other.audio_ != null) ? other.audio_.Clone() : null);
				transport_ = ((other.transport_ != null) ? other.transport_.Clone() : null);
				file_ = ((other.file_ != null) ? other.file_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioTypeProperties Clone()
			{
				return new AudioTypeProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioTypeProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioTypeProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Audio, other.Audio))
				{
					return false;
				}
				if (!object.Equals(Transport, other.Transport))
				{
					return false;
				}
				if (!object.Equals(File, other.File))
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
				if (audio_ != null)
				{
					num ^= Audio.GetHashCode();
				}
				if (transport_ != null)
				{
					num ^= Transport.GetHashCode();
				}
				if (file_ != null)
				{
					num ^= File.GetHashCode();
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
				if (audio_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Audio);
				}
				if (transport_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Transport);
				}
				if (file_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(File);
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
				if (audio_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
				}
				if (transport_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transport);
				}
				if (file_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(File);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AudioTypeProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.audio_ != null)
				{
					if (audio_ == null)
					{
						Audio = new AudioProperties();
					}
					Audio.MergeFrom(other.Audio);
				}
				if (other.transport_ != null)
				{
					if (transport_ == null)
					{
						Transport = new TransportProperties();
					}
					Transport.MergeFrom(other.Transport);
				}
				if (other.file_ != null)
				{
					if (file_ == null)
					{
						File = new FileProperties();
					}
					File.MergeFrom(other.File);
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
						if (audio_ == null)
						{
							Audio = new AudioProperties();
						}
						input.ReadMessage(Audio);
						break;
					case 18u:
						if (transport_ == null)
						{
							Transport = new TransportProperties();
						}
						input.ReadMessage(Transport);
						break;
					case 26u:
						if (file_ == null)
						{
							File = new FileProperties();
						}
						input.ReadMessage(File);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ImageTypeProperties : IMessage<ImageTypeProperties>, IMessage, IEquatable<ImageTypeProperties>, IDeepCloneable<ImageTypeProperties>
		{
			private static readonly MessageParser<ImageTypeProperties> _parser = new MessageParser<ImageTypeProperties>(() => new ImageTypeProperties());

			private UnknownFieldSet _unknownFields;

			public const int DrawingFieldNumber = 1;

			private DrawingProperties drawing_;

			public const int FileFieldNumber = 2;

			private FileProperties file_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ImageTypeProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties Drawing
			{
				get
				{
					return drawing_;
				}
				set
				{
					drawing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FileProperties File
			{
				get
				{
					return file_;
				}
				set
				{
					file_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ImageTypeProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ImageTypeProperties(ImageTypeProperties other)
				: this()
			{
				drawing_ = ((other.drawing_ != null) ? other.drawing_.Clone() : null);
				file_ = ((other.file_ != null) ? other.file_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ImageTypeProperties Clone()
			{
				return new ImageTypeProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ImageTypeProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ImageTypeProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Drawing, other.Drawing))
				{
					return false;
				}
				if (!object.Equals(File, other.File))
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
				if (drawing_ != null)
				{
					num ^= Drawing.GetHashCode();
				}
				if (file_ != null)
				{
					num ^= File.GetHashCode();
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
				if (drawing_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Drawing);
				}
				if (file_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(File);
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
				if (drawing_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Drawing);
				}
				if (file_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(File);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ImageTypeProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.drawing_ != null)
				{
					if (drawing_ == null)
					{
						Drawing = new DrawingProperties();
					}
					Drawing.MergeFrom(other.Drawing);
				}
				if (other.file_ != null)
				{
					if (file_ == null)
					{
						File = new FileProperties();
					}
					File.MergeFrom(other.File);
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
						if (drawing_ == null)
						{
							Drawing = new DrawingProperties();
						}
						input.ReadMessage(Drawing);
						break;
					case 18u:
						if (file_ == null)
						{
							File = new FileProperties();
						}
						input.ReadMessage(File);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class VideoTypeProperties : IMessage<VideoTypeProperties>, IMessage, IEquatable<VideoTypeProperties>, IDeepCloneable<VideoTypeProperties>
		{
			private static readonly MessageParser<VideoTypeProperties> _parser = new MessageParser<VideoTypeProperties>(() => new VideoTypeProperties());

			private UnknownFieldSet _unknownFields;

			public const int DrawingFieldNumber = 1;

			private DrawingProperties drawing_;

			public const int AudioFieldNumber = 2;

			private AudioProperties audio_;

			public const int TransportFieldNumber = 3;

			private TransportProperties transport_;

			public const int VideoFieldNumber = 4;

			private VideoProperties video_;

			public const int FileFieldNumber = 5;

			private FileProperties file_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoTypeProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties Drawing
			{
				get
				{
					return drawing_;
				}
				set
				{
					drawing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties Audio
			{
				get
				{
					return audio_;
				}
				set
				{
					audio_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportProperties Transport
			{
				get
				{
					return transport_;
				}
				set
				{
					transport_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoProperties Video
			{
				get
				{
					return video_;
				}
				set
				{
					video_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FileProperties File
			{
				get
				{
					return file_;
				}
				set
				{
					file_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoTypeProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoTypeProperties(VideoTypeProperties other)
				: this()
			{
				drawing_ = ((other.drawing_ != null) ? other.drawing_.Clone() : null);
				audio_ = ((other.audio_ != null) ? other.audio_.Clone() : null);
				transport_ = ((other.transport_ != null) ? other.transport_.Clone() : null);
				video_ = ((other.video_ != null) ? other.video_.Clone() : null);
				file_ = ((other.file_ != null) ? other.file_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoTypeProperties Clone()
			{
				return new VideoTypeProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as VideoTypeProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(VideoTypeProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Drawing, other.Drawing))
				{
					return false;
				}
				if (!object.Equals(Audio, other.Audio))
				{
					return false;
				}
				if (!object.Equals(Transport, other.Transport))
				{
					return false;
				}
				if (!object.Equals(Video, other.Video))
				{
					return false;
				}
				if (!object.Equals(File, other.File))
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
				if (drawing_ != null)
				{
					num ^= Drawing.GetHashCode();
				}
				if (audio_ != null)
				{
					num ^= Audio.GetHashCode();
				}
				if (transport_ != null)
				{
					num ^= Transport.GetHashCode();
				}
				if (video_ != null)
				{
					num ^= Video.GetHashCode();
				}
				if (file_ != null)
				{
					num ^= File.GetHashCode();
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
				if (drawing_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Drawing);
				}
				if (audio_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Audio);
				}
				if (transport_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Transport);
				}
				if (video_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Video);
				}
				if (file_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(File);
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
				if (drawing_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Drawing);
				}
				if (audio_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
				}
				if (transport_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transport);
				}
				if (video_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Video);
				}
				if (file_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(File);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(VideoTypeProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.drawing_ != null)
				{
					if (drawing_ == null)
					{
						Drawing = new DrawingProperties();
					}
					Drawing.MergeFrom(other.Drawing);
				}
				if (other.audio_ != null)
				{
					if (audio_ == null)
					{
						Audio = new AudioProperties();
					}
					Audio.MergeFrom(other.Audio);
				}
				if (other.transport_ != null)
				{
					if (transport_ == null)
					{
						Transport = new TransportProperties();
					}
					Transport.MergeFrom(other.Transport);
				}
				if (other.video_ != null)
				{
					if (video_ == null)
					{
						Video = new VideoProperties();
					}
					Video.MergeFrom(other.Video);
				}
				if (other.file_ != null)
				{
					if (file_ == null)
					{
						File = new FileProperties();
					}
					File.MergeFrom(other.File);
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
						if (drawing_ == null)
						{
							Drawing = new DrawingProperties();
						}
						input.ReadMessage(Drawing);
						break;
					case 18u:
						if (audio_ == null)
						{
							Audio = new AudioProperties();
						}
						input.ReadMessage(Audio);
						break;
					case 26u:
						if (transport_ == null)
						{
							Transport = new TransportProperties();
						}
						input.ReadMessage(Transport);
						break;
					case 34u:
						if (video_ == null)
						{
							Video = new VideoProperties();
						}
						input.ReadMessage(Video);
						break;
					case 42u:
						if (file_ == null)
						{
							File = new FileProperties();
						}
						input.ReadMessage(File);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LiveVideoTypeProperties : IMessage<LiveVideoTypeProperties>, IMessage, IEquatable<LiveVideoTypeProperties>, IDeepCloneable<LiveVideoTypeProperties>
		{
			private static readonly MessageParser<LiveVideoTypeProperties> _parser = new MessageParser<LiveVideoTypeProperties>(() => new LiveVideoTypeProperties());

			private UnknownFieldSet _unknownFields;

			public const int DrawingFieldNumber = 1;

			private DrawingProperties drawing_;

			public const int AudioFieldNumber = 2;

			private AudioProperties audio_;

			public const int LiveVideoFieldNumber = 3;

			private LiveVideoProperties liveVideo_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LiveVideoTypeProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties Drawing
			{
				get
				{
					return drawing_;
				}
				set
				{
					drawing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioProperties Audio
			{
				get
				{
					return audio_;
				}
				set
				{
					audio_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoProperties LiveVideo
			{
				get
				{
					return liveVideo_;
				}
				set
				{
					liveVideo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoTypeProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoTypeProperties(LiveVideoTypeProperties other)
				: this()
			{
				drawing_ = ((other.drawing_ != null) ? other.drawing_.Clone() : null);
				audio_ = ((other.audio_ != null) ? other.audio_.Clone() : null);
				liveVideo_ = ((other.liveVideo_ != null) ? other.liveVideo_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LiveVideoTypeProperties Clone()
			{
				return new LiveVideoTypeProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LiveVideoTypeProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LiveVideoTypeProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Drawing, other.Drawing))
				{
					return false;
				}
				if (!object.Equals(Audio, other.Audio))
				{
					return false;
				}
				if (!object.Equals(LiveVideo, other.LiveVideo))
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
				if (drawing_ != null)
				{
					num ^= Drawing.GetHashCode();
				}
				if (audio_ != null)
				{
					num ^= Audio.GetHashCode();
				}
				if (liveVideo_ != null)
				{
					num ^= LiveVideo.GetHashCode();
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
				if (drawing_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Drawing);
				}
				if (audio_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Audio);
				}
				if (liveVideo_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(LiveVideo);
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
				if (drawing_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Drawing);
				}
				if (audio_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
				}
				if (liveVideo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LiveVideo);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LiveVideoTypeProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.drawing_ != null)
				{
					if (drawing_ == null)
					{
						Drawing = new DrawingProperties();
					}
					Drawing.MergeFrom(other.Drawing);
				}
				if (other.audio_ != null)
				{
					if (audio_ == null)
					{
						Audio = new AudioProperties();
					}
					Audio.MergeFrom(other.Audio);
				}
				if (other.liveVideo_ != null)
				{
					if (liveVideo_ == null)
					{
						LiveVideo = new LiveVideoProperties();
					}
					LiveVideo.MergeFrom(other.LiveVideo);
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
						if (drawing_ == null)
						{
							Drawing = new DrawingProperties();
						}
						input.ReadMessage(Drawing);
						break;
					case 18u:
						if (audio_ == null)
						{
							Audio = new AudioProperties();
						}
						input.ReadMessage(Audio);
						break;
					case 26u:
						if (liveVideo_ == null)
						{
							LiveVideo = new LiveVideoProperties();
						}
						input.ReadMessage(LiveVideo);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class WebContentTypeProperties : IMessage<WebContentTypeProperties>, IMessage, IEquatable<WebContentTypeProperties>, IDeepCloneable<WebContentTypeProperties>
		{
			private static readonly MessageParser<WebContentTypeProperties> _parser = new MessageParser<WebContentTypeProperties>(() => new WebContentTypeProperties());

			private UnknownFieldSet _unknownFields;

			public const int DrawingFieldNumber = 1;

			private DrawingProperties drawing_;

			public const int UrlFieldNumber = 2;

			private URL url_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<WebContentTypeProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Media.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DrawingProperties Drawing
			{
				get
				{
					return drawing_;
				}
				set
				{
					drawing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL Url
			{
				get
				{
					return url_;
				}
				set
				{
					url_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public WebContentTypeProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public WebContentTypeProperties(WebContentTypeProperties other)
				: this()
			{
				drawing_ = ((other.drawing_ != null) ? other.drawing_.Clone() : null);
				url_ = ((other.url_ != null) ? other.url_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public WebContentTypeProperties Clone()
			{
				return new WebContentTypeProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as WebContentTypeProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(WebContentTypeProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Drawing, other.Drawing))
				{
					return false;
				}
				if (!object.Equals(Url, other.Url))
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
				if (drawing_ != null)
				{
					num ^= Drawing.GetHashCode();
				}
				if (url_ != null)
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
				if (drawing_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Drawing);
				}
				if (url_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Url);
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
				if (drawing_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Drawing);
				}
				if (url_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Url);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(WebContentTypeProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.drawing_ != null)
				{
					if (drawing_ == null)
					{
						Drawing = new DrawingProperties();
					}
					Drawing.MergeFrom(other.Drawing);
				}
				if (other.url_ != null)
				{
					if (url_ == null)
					{
						Url = new URL();
					}
					Url.MergeFrom(other.Url);
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
						if (drawing_ == null)
						{
							Drawing = new DrawingProperties();
						}
						input.ReadMessage(Drawing);
						break;
					case 18u:
						if (url_ == null)
						{
							Url = new URL();
						}
						input.ReadMessage(Url);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Media> _parser = new MessageParser<Media>(() => new Media());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int UrlFieldNumber = 2;

	private URL url_;

	public const int MetadataFieldNumber = 3;

	private Types.Metadata metadata_;

	public const int AudioFieldNumber = 4;

	public const int ImageFieldNumber = 5;

	public const int VideoFieldNumber = 6;

	public const int LiveVideoFieldNumber = 7;

	public const int WebContentFieldNumber = 8;

	private object typeProperties_;

	private TypePropertiesOneofCase typePropertiesCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Media> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => GraphicsDataReflection.Descriptor.MessageTypes[1];

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
	public URL Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = value;
		}
	}

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
	public Types.AudioTypeProperties Audio
	{
		get
		{
			if (typePropertiesCase_ != TypePropertiesOneofCase.Audio)
			{
				return null;
			}
			return (Types.AudioTypeProperties)typeProperties_;
		}
		set
		{
			typeProperties_ = value;
			typePropertiesCase_ = ((value != null) ? TypePropertiesOneofCase.Audio : TypePropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ImageTypeProperties Image
	{
		get
		{
			if (typePropertiesCase_ != TypePropertiesOneofCase.Image)
			{
				return null;
			}
			return (Types.ImageTypeProperties)typeProperties_;
		}
		set
		{
			typeProperties_ = value;
			typePropertiesCase_ = ((value != null) ? TypePropertiesOneofCase.Image : TypePropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.VideoTypeProperties Video
	{
		get
		{
			if (typePropertiesCase_ != TypePropertiesOneofCase.Video)
			{
				return null;
			}
			return (Types.VideoTypeProperties)typeProperties_;
		}
		set
		{
			typeProperties_ = value;
			typePropertiesCase_ = ((value != null) ? TypePropertiesOneofCase.Video : TypePropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.LiveVideoTypeProperties LiveVideo
	{
		get
		{
			if (typePropertiesCase_ != TypePropertiesOneofCase.LiveVideo)
			{
				return null;
			}
			return (Types.LiveVideoTypeProperties)typeProperties_;
		}
		set
		{
			typeProperties_ = value;
			typePropertiesCase_ = ((value != null) ? TypePropertiesOneofCase.LiveVideo : TypePropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.WebContentTypeProperties WebContent
	{
		get
		{
			if (typePropertiesCase_ != TypePropertiesOneofCase.WebContent)
			{
				return null;
			}
			return (Types.WebContentTypeProperties)typeProperties_;
		}
		set
		{
			typeProperties_ = value;
			typePropertiesCase_ = ((value != null) ? TypePropertiesOneofCase.WebContent : TypePropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TypePropertiesOneofCase TypePropertiesCase => typePropertiesCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media(Media other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		url_ = ((other.url_ != null) ? other.url_.Clone() : null);
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		switch (other.TypePropertiesCase)
		{
		case TypePropertiesOneofCase.Audio:
			Audio = other.Audio.Clone();
			break;
		case TypePropertiesOneofCase.Image:
			Image = other.Image.Clone();
			break;
		case TypePropertiesOneofCase.Video:
			Video = other.Video.Clone();
			break;
		case TypePropertiesOneofCase.LiveVideo:
			LiveVideo = other.LiveVideo.Clone();
			break;
		case TypePropertiesOneofCase.WebContent:
			WebContent = other.WebContent.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media Clone()
	{
		return new Media(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearTypeProperties()
	{
		typePropertiesCase_ = TypePropertiesOneofCase.None;
		typeProperties_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Media);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Media other)
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
		if (!object.Equals(Url, other.Url))
		{
			return false;
		}
		if (!object.Equals(Metadata, other.Metadata))
		{
			return false;
		}
		if (!object.Equals(Audio, other.Audio))
		{
			return false;
		}
		if (!object.Equals(Image, other.Image))
		{
			return false;
		}
		if (!object.Equals(Video, other.Video))
		{
			return false;
		}
		if (!object.Equals(LiveVideo, other.LiveVideo))
		{
			return false;
		}
		if (!object.Equals(WebContent, other.WebContent))
		{
			return false;
		}
		if (TypePropertiesCase != other.TypePropertiesCase)
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
		if (url_ != null)
		{
			num ^= Url.GetHashCode();
		}
		if (metadata_ != null)
		{
			num ^= Metadata.GetHashCode();
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Audio)
		{
			num ^= Audio.GetHashCode();
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Image)
		{
			num ^= Image.GetHashCode();
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Video)
		{
			num ^= Video.GetHashCode();
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.LiveVideo)
		{
			num ^= LiveVideo.GetHashCode();
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.WebContent)
		{
			num ^= WebContent.GetHashCode();
		}
		num ^= (int)typePropertiesCase_;
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
		if (url_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Url);
		}
		if (metadata_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Metadata);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Audio)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Audio);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Image)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Image);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Video)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Video);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.LiveVideo)
		{
			output.WriteRawTag(58);
			output.WriteMessage(LiveVideo);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.WebContent)
		{
			output.WriteRawTag(66);
			output.WriteMessage(WebContent);
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
		if (url_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Url);
		}
		if (metadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Metadata);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Audio)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Image)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Image);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.Video)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Video);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.LiveVideo)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveVideo);
		}
		if (typePropertiesCase_ == TypePropertiesOneofCase.WebContent)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(WebContent);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Media other)
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
		if (other.url_ != null)
		{
			if (url_ == null)
			{
				Url = new URL();
			}
			Url.MergeFrom(other.Url);
		}
		if (other.metadata_ != null)
		{
			if (metadata_ == null)
			{
				Metadata = new Types.Metadata();
			}
			Metadata.MergeFrom(other.Metadata);
		}
		switch (other.TypePropertiesCase)
		{
		case TypePropertiesOneofCase.Audio:
			if (Audio == null)
			{
				Audio = new Types.AudioTypeProperties();
			}
			Audio.MergeFrom(other.Audio);
			break;
		case TypePropertiesOneofCase.Image:
			if (Image == null)
			{
				Image = new Types.ImageTypeProperties();
			}
			Image.MergeFrom(other.Image);
			break;
		case TypePropertiesOneofCase.Video:
			if (Video == null)
			{
				Video = new Types.VideoTypeProperties();
			}
			Video.MergeFrom(other.Video);
			break;
		case TypePropertiesOneofCase.LiveVideo:
			if (LiveVideo == null)
			{
				LiveVideo = new Types.LiveVideoTypeProperties();
			}
			LiveVideo.MergeFrom(other.LiveVideo);
			break;
		case TypePropertiesOneofCase.WebContent:
			if (WebContent == null)
			{
				WebContent = new Types.WebContentTypeProperties();
			}
			WebContent.MergeFrom(other.WebContent);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				if (url_ == null)
				{
					Url = new URL();
				}
				input.ReadMessage(Url);
				break;
			case 26u:
				if (metadata_ == null)
				{
					Metadata = new Types.Metadata();
				}
				input.ReadMessage(Metadata);
				break;
			case 34u:
			{
				Types.AudioTypeProperties audioTypeProperties = new Types.AudioTypeProperties();
				if (typePropertiesCase_ == TypePropertiesOneofCase.Audio)
				{
					audioTypeProperties.MergeFrom(Audio);
				}
				input.ReadMessage(audioTypeProperties);
				Audio = audioTypeProperties;
				break;
			}
			case 42u:
			{
				Types.ImageTypeProperties imageTypeProperties = new Types.ImageTypeProperties();
				if (typePropertiesCase_ == TypePropertiesOneofCase.Image)
				{
					imageTypeProperties.MergeFrom(Image);
				}
				input.ReadMessage(imageTypeProperties);
				Image = imageTypeProperties;
				break;
			}
			case 50u:
			{
				Types.VideoTypeProperties videoTypeProperties = new Types.VideoTypeProperties();
				if (typePropertiesCase_ == TypePropertiesOneofCase.Video)
				{
					videoTypeProperties.MergeFrom(Video);
				}
				input.ReadMessage(videoTypeProperties);
				Video = videoTypeProperties;
				break;
			}
			case 58u:
			{
				Types.LiveVideoTypeProperties liveVideoTypeProperties = new Types.LiveVideoTypeProperties();
				if (typePropertiesCase_ == TypePropertiesOneofCase.LiveVideo)
				{
					liveVideoTypeProperties.MergeFrom(LiveVideo);
				}
				input.ReadMessage(liveVideoTypeProperties);
				LiveVideo = liveVideoTypeProperties;
				break;
			}
			case 66u:
			{
				Types.WebContentTypeProperties webContentTypeProperties = new Types.WebContentTypeProperties();
				if (typePropertiesCase_ == TypePropertiesOneofCase.WebContent)
				{
					webContentTypeProperties.MergeFrom(WebContent);
				}
				input.ReadMessage(webContentTypeProperties);
				WebContent = webContentTypeProperties;
				break;
			}
			}
		}
	}
}
