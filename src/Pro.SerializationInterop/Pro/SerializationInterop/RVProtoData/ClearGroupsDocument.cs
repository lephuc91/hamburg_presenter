using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClearGroupsDocument : IMessage<ClearGroupsDocument>, IMessage, IEquatable<ClearGroupsDocument>, IDeepCloneable<ClearGroupsDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearGroup : IMessage<ClearGroup>, IMessage, IEquatable<ClearGroup>, IDeepCloneable<ClearGroup>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ImageType
				{
					[OriginalName("ImageTypeCustom")]
					Custom,
					[OriginalName("ImageTypeOne")]
					One,
					[OriginalName("ImageTypeTwo")]
					Two,
					[OriginalName("ImageTypeThree")]
					Three,
					[OriginalName("ImageTypeFour")]
					Four,
					[OriginalName("ImageTypeFive")]
					Five,
					[OriginalName("ImageTypeSix")]
					Six,
					[OriginalName("ImageTypeSeven")]
					Seven,
					[OriginalName("ImageTypeEight")]
					Eight,
					[OriginalName("ImageTypeNine")]
					Nine,
					[OriginalName("ImageTypeZero")]
					Zero,
					[OriginalName("ImageTypeAll")]
					All,
					[OriginalName("ImageTypeMegahorn")]
					Megahorn,
					[OriginalName("ImageTypePlay")]
					Play,
					[OriginalName("ImageTypeBulb")]
					Bulb,
					[OriginalName("ImageTypeSunglasses")]
					Sunglasses,
					[OriginalName("ImageTypeArrow")]
					Arrow,
					[OriginalName("ImageTypeTarget")]
					Target,
					[OriginalName("ImageTypeStar")]
					Star,
					[OriginalName("ImageTypeSun")]
					Sun,
					[OriginalName("ImageTypeBell")]
					Bell,
					[OriginalName("ImageTypePaperclip")]
					Paperclip,
					[OriginalName("ImageTypeFlask")]
					Flask,
					[OriginalName("ImageTypeEyeglasses")]
					Eyeglasses,
					[OriginalName("ImageTypeCupcake")]
					Cupcake,
					[OriginalName("ImageTypeSlide")]
					Slide,
					[OriginalName("ImageTypeHat")]
					Hat,
					[OriginalName("ImageTypeFlower")]
					Flower,
					[OriginalName("ImageTypeHeart")]
					Heart,
					[OriginalName("ImageTypeMessage")]
					Message,
					[OriginalName("ImageTypeAudio")]
					Audio,
					[OriginalName("ImageTypeCloud")]
					Cloud,
					[OriginalName("ImageTypeExclamation")]
					Exclamation
				}
			}

			private static readonly MessageParser<ClearGroup> _parser = new MessageParser<ClearGroup>(() => new ClearGroup());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int LayerTargetsFieldNumber = 3;

			private static readonly FieldCodec<Action.Types.ClearType> _repeated_layerTargets_codec = FieldCodec.ForMessage(26u, Action.Types.ClearType.Parser);

			private readonly RepeatedField<Action.Types.ClearType> layerTargets_ = new RepeatedField<Action.Types.ClearType>();

			public const int IsHiddenInPreviewFieldNumber = 4;

			private bool isHiddenInPreview_;

			public const int ImageDataFieldNumber = 5;

			private ByteString imageData_ = ByteString.Empty;

			public const int ImageTypeFieldNumber = 6;

			private Types.ImageType imageType_;

			public const int IsIconTintedFieldNumber = 7;

			private bool isIconTinted_;

			public const int IconTintColorFieldNumber = 8;

			private Color iconTintColor_;

			public const int TimelineTargetsFieldNumber = 9;

			private static readonly FieldCodec<Action.Types.ContentDestination> _repeated_timelineTargets_codec = FieldCodec.ForEnum(74u, (Action.Types.ContentDestination x) => (int)x, (int x) => (Action.Types.ContentDestination)x);

			private readonly RepeatedField<Action.Types.ContentDestination> timelineTargets_ = new RepeatedField<Action.Types.ContentDestination>();

			public const int ClearPresentationNextSlideFieldNumber = 10;

			private bool clearPresentationNextSlide_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ClearGroupsDocument.Descriptor.NestedTypes[0];

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
			public RepeatedField<Action.Types.ClearType> LayerTargets => layerTargets_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsHiddenInPreview
			{
				get
				{
					return isHiddenInPreview_;
				}
				set
				{
					isHiddenInPreview_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString ImageData
			{
				get
				{
					return imageData_;
				}
				set
				{
					imageData_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ImageType ImageType
			{
				get
				{
					return imageType_;
				}
				set
				{
					imageType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsIconTinted
			{
				get
				{
					return isIconTinted_;
				}
				set
				{
					isIconTinted_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color IconTintColor
			{
				get
				{
					return iconTintColor_;
				}
				set
				{
					iconTintColor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Action.Types.ContentDestination> TimelineTargets => timelineTargets_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ClearPresentationNextSlide
			{
				get
				{
					return clearPresentationNextSlide_;
				}
				set
				{
					clearPresentationNextSlide_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroup(ClearGroup other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				layerTargets_ = other.layerTargets_.Clone();
				isHiddenInPreview_ = other.isHiddenInPreview_;
				imageData_ = other.imageData_;
				imageType_ = other.imageType_;
				isIconTinted_ = other.isIconTinted_;
				iconTintColor_ = ((other.iconTintColor_ != null) ? other.iconTintColor_.Clone() : null);
				timelineTargets_ = other.timelineTargets_.Clone();
				clearPresentationNextSlide_ = other.clearPresentationNextSlide_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroup Clone()
			{
				return new ClearGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearGroup other)
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
				if (Name != other.Name)
				{
					return false;
				}
				if (!layerTargets_.Equals(other.layerTargets_))
				{
					return false;
				}
				if (IsHiddenInPreview != other.IsHiddenInPreview)
				{
					return false;
				}
				if (ImageData != other.ImageData)
				{
					return false;
				}
				if (ImageType != other.ImageType)
				{
					return false;
				}
				if (IsIconTinted != other.IsIconTinted)
				{
					return false;
				}
				if (!object.Equals(IconTintColor, other.IconTintColor))
				{
					return false;
				}
				if (!timelineTargets_.Equals(other.timelineTargets_))
				{
					return false;
				}
				if (ClearPresentationNextSlide != other.ClearPresentationNextSlide)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= layerTargets_.GetHashCode();
				if (IsHiddenInPreview)
				{
					num ^= IsHiddenInPreview.GetHashCode();
				}
				if (ImageData.Length != 0)
				{
					num ^= ImageData.GetHashCode();
				}
				if (ImageType != 0)
				{
					num ^= ImageType.GetHashCode();
				}
				if (IsIconTinted)
				{
					num ^= IsIconTinted.GetHashCode();
				}
				if (iconTintColor_ != null)
				{
					num ^= IconTintColor.GetHashCode();
				}
				num ^= timelineTargets_.GetHashCode();
				if (ClearPresentationNextSlide)
				{
					num ^= ClearPresentationNextSlide.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				layerTargets_.WriteTo(output, _repeated_layerTargets_codec);
				if (IsHiddenInPreview)
				{
					output.WriteRawTag(32);
					output.WriteBool(IsHiddenInPreview);
				}
				if (ImageData.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteBytes(ImageData);
				}
				if (ImageType != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)ImageType);
				}
				if (IsIconTinted)
				{
					output.WriteRawTag(56);
					output.WriteBool(IsIconTinted);
				}
				if (iconTintColor_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(IconTintColor);
				}
				timelineTargets_.WriteTo(output, _repeated_timelineTargets_codec);
				if (ClearPresentationNextSlide)
				{
					output.WriteRawTag(80);
					output.WriteBool(ClearPresentationNextSlide);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += layerTargets_.CalculateSize(_repeated_layerTargets_codec);
				if (IsHiddenInPreview)
				{
					num += 2;
				}
				if (ImageData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(ImageData);
				}
				if (ImageType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ImageType);
				}
				if (IsIconTinted)
				{
					num += 2;
				}
				if (iconTintColor_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(IconTintColor);
				}
				num += timelineTargets_.CalculateSize(_repeated_timelineTargets_codec);
				if (ClearPresentationNextSlide)
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
			public void MergeFrom(ClearGroup other)
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
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				layerTargets_.Add(other.layerTargets_);
				if (other.IsHiddenInPreview)
				{
					IsHiddenInPreview = other.IsHiddenInPreview;
				}
				if (other.ImageData.Length != 0)
				{
					ImageData = other.ImageData;
				}
				if (other.ImageType != 0)
				{
					ImageType = other.ImageType;
				}
				if (other.IsIconTinted)
				{
					IsIconTinted = other.IsIconTinted;
				}
				if (other.iconTintColor_ != null)
				{
					if (iconTintColor_ == null)
					{
						IconTintColor = new Color();
					}
					IconTintColor.MergeFrom(other.IconTintColor);
				}
				timelineTargets_.Add(other.timelineTargets_);
				if (other.ClearPresentationNextSlide)
				{
					ClearPresentationNextSlide = other.ClearPresentationNextSlide;
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
						Name = input.ReadString();
						break;
					case 26u:
						layerTargets_.AddEntriesFrom(input, _repeated_layerTargets_codec);
						break;
					case 32u:
						IsHiddenInPreview = input.ReadBool();
						break;
					case 42u:
						ImageData = input.ReadBytes();
						break;
					case 48u:
						ImageType = (Types.ImageType)input.ReadEnum();
						break;
					case 56u:
						IsIconTinted = input.ReadBool();
						break;
					case 66u:
						if (iconTintColor_ == null)
						{
							IconTintColor = new Color();
						}
						input.ReadMessage(IconTintColor);
						break;
					case 72u:
					case 74u:
						timelineTargets_.AddEntriesFrom(input, _repeated_timelineTargets_codec);
						break;
					case 80u:
						ClearPresentationNextSlide = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<ClearGroupsDocument> _parser = new MessageParser<ClearGroupsDocument>(() => new ClearGroupsDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int GroupsFieldNumber = 2;

	private static readonly FieldCodec<Types.ClearGroup> _repeated_groups_codec = FieldCodec.ForMessage(18u, Types.ClearGroup.Parser);

	private readonly RepeatedField<Types.ClearGroup> groups_ = new RepeatedField<Types.ClearGroup>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ClearGroupsDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ClearGroupsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.ClearGroup> Groups => groups_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsDocument(ClearGroupsDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		groups_ = other.groups_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsDocument Clone()
	{
		return new ClearGroupsDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ClearGroupsDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ClearGroupsDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!groups_.Equals(other.groups_))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		num ^= groups_.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		groups_.WriteTo(output, _repeated_groups_codec);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		num += groups_.CalculateSize(_repeated_groups_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ClearGroupsDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		groups_.Add(other.groups_);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				groups_.AddEntriesFrom(input, _repeated_groups_codec);
				break;
			}
		}
	}
}
