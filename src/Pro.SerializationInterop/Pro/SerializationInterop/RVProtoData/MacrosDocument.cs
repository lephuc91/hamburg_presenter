using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MacrosDocument : IMessage<MacrosDocument>, IMessage, IEquatable<MacrosDocument>, IDeepCloneable<MacrosDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Macro : IMessage<Macro>, IMessage, IEquatable<Macro>, IDeepCloneable<Macro>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ImageType
				{
					[OriginalName("ImageTypeDefault")]
					Default,
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
					[OriginalName("ImageTypeArrow")]
					Arrow,
					[OriginalName("ImageTypeAudio")]
					Audio,
					[OriginalName("ImageTypeBell")]
					Bell,
					[OriginalName("ImageTypeBulb")]
					Bulb,
					[OriginalName("ImageTypeCloud")]
					Cloud,
					[OriginalName("ImageTypeCupcake")]
					Cupcake,
					[OriginalName("ImageTypeExclamation")]
					Exclamation,
					[OriginalName("ImageTypeFlask")]
					Flask,
					[OriginalName("ImageTypeFlower")]
					Flower,
					[OriginalName("ImageTypeGlasses")]
					Glasses,
					[OriginalName("ImageTypeHashtag")]
					Hashtag,
					[OriginalName("ImageTypeHat")]
					Hat,
					[OriginalName("ImageTypeHeart")]
					Heart,
					[OriginalName("ImageTypeMegaphone")]
					Megaphone,
					[OriginalName("ImageTypeMessage")]
					Message,
					[OriginalName("ImageTypePaperclip")]
					Paperclip,
					[OriginalName("ImageTypePlay")]
					Play,
					[OriginalName("ImageTypeSlide")]
					Slide,
					[OriginalName("ImageTypeStar")]
					Star,
					[OriginalName("ImageTypeSun")]
					Sun,
					[OriginalName("ImageTypeSunglasses")]
					Sunglasses,
					[OriginalName("ImageTypeTarget")]
					Target,
					[OriginalName("ImageTypeTimer")]
					Timer,
					[OriginalName("ImageTypeVideoInput")]
					VideoInput,
					[OriginalName("ImageTypeXClear")]
					Xclear,
					[OriginalName("ImageTypeLetterA")]
					LetterA,
					[OriginalName("ImageTypeLetterB")]
					LetterB,
					[OriginalName("ImageTypeLetterC")]
					LetterC,
					[OriginalName("ImageTypeLetterD")]
					LetterD,
					[OriginalName("ImageTypeLetterE")]
					LetterE,
					[OriginalName("ImageTypeLetterF")]
					LetterF,
					[OriginalName("ImageTypeLetterG")]
					LetterG,
					[OriginalName("ImageTypeLetterH")]
					LetterH,
					[OriginalName("ImageTypeLetterI")]
					LetterI,
					[OriginalName("ImageTypeLetterJ")]
					LetterJ,
					[OriginalName("ImageTypeLetterK")]
					LetterK,
					[OriginalName("ImageTypeLetterL")]
					LetterL,
					[OriginalName("ImageTypeLetterM")]
					LetterM,
					[OriginalName("ImageTypeLetterN")]
					LetterN,
					[OriginalName("ImageTypeLetterO")]
					LetterO,
					[OriginalName("ImageTypeLetterP")]
					LetterP,
					[OriginalName("ImageTypeLetterQ")]
					LetterQ,
					[OriginalName("ImageTypeLetterR")]
					LetterR,
					[OriginalName("ImageTypeLetterS")]
					LetterS,
					[OriginalName("ImageTypeLetterT")]
					LetterT,
					[OriginalName("ImageTypeLetterU")]
					LetterU,
					[OriginalName("ImageTypeLetterV")]
					LetterV,
					[OriginalName("ImageTypeLetterW")]
					LetterW,
					[OriginalName("ImageTypeLetterX")]
					LetterX,
					[OriginalName("ImageTypeLetterY")]
					LetterY,
					[OriginalName("ImageTypeLetterZ")]
					LetterZ,
					[OriginalName("ImageTypeCustom")]
					Custom
				}
			}

			private static readonly MessageParser<Macro> _parser = new MessageParser<Macro>(() => new Macro());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int ColorFieldNumber = 3;

			private Color color_;

			public const int ActionsFieldNumber = 4;

			private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(34u, Action.Parser);

			private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

			public const int TriggerOnStartupFieldNumber = 5;

			private bool triggerOnStartup_;

			public const int ImageTypeFieldNumber = 6;

			private Types.ImageType imageType_;

			public const int ImageDataFieldNumber = 7;

			private ByteString imageData_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Macro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MacrosDocument.Descriptor.NestedTypes[0];

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
			public Color Color
			{
				get
				{
					return color_;
				}
				set
				{
					color_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Action> Actions => actions_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool TriggerOnStartup
			{
				get
				{
					return triggerOnStartup_;
				}
				set
				{
					triggerOnStartup_ = value;
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
			public Macro()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Macro(Macro other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				actions_ = other.actions_.Clone();
				triggerOnStartup_ = other.triggerOnStartup_;
				imageType_ = other.imageType_;
				imageData_ = other.imageData_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Macro Clone()
			{
				return new Macro(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Macro);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Macro other)
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
				if (!object.Equals(Color, other.Color))
				{
					return false;
				}
				if (!actions_.Equals(other.actions_))
				{
					return false;
				}
				if (TriggerOnStartup != other.TriggerOnStartup)
				{
					return false;
				}
				if (ImageType != other.ImageType)
				{
					return false;
				}
				if (ImageData != other.ImageData)
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
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
				}
				num ^= actions_.GetHashCode();
				if (TriggerOnStartup)
				{
					num ^= TriggerOnStartup.GetHashCode();
				}
				if (ImageType != 0)
				{
					num ^= ImageType.GetHashCode();
				}
				if (ImageData.Length != 0)
				{
					num ^= ImageData.GetHashCode();
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
				if (color_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Color);
				}
				actions_.WriteTo(output, _repeated_actions_codec);
				if (TriggerOnStartup)
				{
					output.WriteRawTag(40);
					output.WriteBool(TriggerOnStartup);
				}
				if (ImageType != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)ImageType);
				}
				if (ImageData.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteBytes(ImageData);
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
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				num += actions_.CalculateSize(_repeated_actions_codec);
				if (TriggerOnStartup)
				{
					num += 2;
				}
				if (ImageType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ImageType);
				}
				if (ImageData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(ImageData);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Macro other)
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
				if (other.color_ != null)
				{
					if (color_ == null)
					{
						Color = new Color();
					}
					Color.MergeFrom(other.Color);
				}
				actions_.Add(other.actions_);
				if (other.TriggerOnStartup)
				{
					TriggerOnStartup = other.TriggerOnStartup;
				}
				if (other.ImageType != 0)
				{
					ImageType = other.ImageType;
				}
				if (other.ImageData.Length != 0)
				{
					ImageData = other.ImageData;
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
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					case 34u:
						actions_.AddEntriesFrom(input, _repeated_actions_codec);
						break;
					case 40u:
						TriggerOnStartup = input.ReadBool();
						break;
					case 48u:
						ImageType = (Types.ImageType)input.ReadEnum();
						break;
					case 58u:
						ImageData = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MacroCollection : IMessage<MacroCollection>, IMessage, IEquatable<MacroCollection>, IDeepCloneable<MacroCollection>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Item : IMessage<Item>, IMessage, IEquatable<Item>, IDeepCloneable<Item>
				{
					public enum ItemTypeOneofCase
					{
						None,
						MacroId
					}

					private static readonly MessageParser<Item> _parser = new MessageParser<Item>(() => new Item());

					private UnknownFieldSet _unknownFields;

					public const int MacroIdFieldNumber = 1;

					private object itemType_;

					private ItemTypeOneofCase itemTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Item> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MacroCollection.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UUID MacroId
					{
						get
						{
							if (itemTypeCase_ != ItemTypeOneofCase.MacroId)
							{
								return null;
							}
							return (UUID)itemType_;
						}
						set
						{
							itemType_ = value;
							itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.MacroId : ItemTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ItemTypeOneofCase ItemTypeCase => itemTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item(Item other)
						: this()
					{
						if (other.ItemTypeCase == ItemTypeOneofCase.MacroId)
						{
							MacroId = other.MacroId.Clone();
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item Clone()
					{
						return new Item(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearItemType()
					{
						itemTypeCase_ = ItemTypeOneofCase.None;
						itemType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Item);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Item other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(MacroId, other.MacroId))
						{
							return false;
						}
						if (ItemTypeCase != other.ItemTypeCase)
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
						if (itemTypeCase_ == ItemTypeOneofCase.MacroId)
						{
							num ^= MacroId.GetHashCode();
						}
						num ^= (int)itemTypeCase_;
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
						if (itemTypeCase_ == ItemTypeOneofCase.MacroId)
						{
							output.WriteRawTag(10);
							output.WriteMessage(MacroId);
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
						if (itemTypeCase_ == ItemTypeOneofCase.MacroId)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(MacroId);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Item other)
					{
						if (other == null)
						{
							return;
						}
						if (other.ItemTypeCase == ItemTypeOneofCase.MacroId)
						{
							if (MacroId == null)
							{
								MacroId = new UUID();
							}
							MacroId.MergeFrom(other.MacroId);
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								continue;
							}
							UUID uUID = new UUID();
							if (itemTypeCase_ == ItemTypeOneofCase.MacroId)
							{
								uUID.MergeFrom(MacroId);
							}
							input.ReadMessage(uUID);
							MacroId = uUID;
						}
					}
				}
			}

			private static readonly MessageParser<MacroCollection> _parser = new MessageParser<MacroCollection>(() => new MacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int ItemsFieldNumber = 3;

			private static readonly FieldCodec<Types.Item> _repeated_items_codec = FieldCodec.ForMessage(26u, Types.Item.Parser);

			private readonly RepeatedField<Types.Item> items_ = new RepeatedField<Types.Item>();

			public const int MacrosFieldNumber = 4;

			private static readonly FieldCodec<Macro> _repeated_macros_codec = FieldCodec.ForMessage(34u, Macro.Parser);

			private readonly RepeatedField<Macro> macros_ = new RepeatedField<Macro>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MacrosDocument.Descriptor.NestedTypes[1];

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
			public RepeatedField<Types.Item> Items => items_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Macro> Macros => macros_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollection(MacroCollection other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				items_ = other.items_.Clone();
				macros_ = other.macros_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollection Clone()
			{
				return new MacroCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MacroCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MacroCollection other)
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
				if (!items_.Equals(other.items_))
				{
					return false;
				}
				if (!macros_.Equals(other.macros_))
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
				num ^= items_.GetHashCode();
				num ^= macros_.GetHashCode();
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
				items_.WriteTo(output, _repeated_items_codec);
				macros_.WriteTo(output, _repeated_macros_codec);
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
				num += items_.CalculateSize(_repeated_items_codec);
				num += macros_.CalculateSize(_repeated_macros_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MacroCollection other)
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
				items_.Add(other.items_);
				macros_.Add(other.macros_);
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
						items_.AddEntriesFrom(input, _repeated_items_codec);
						break;
					case 34u:
						macros_.AddEntriesFrom(input, _repeated_macros_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<MacrosDocument> _parser = new MessageParser<MacrosDocument>(() => new MacrosDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int MacrosFieldNumber = 2;

	private static readonly FieldCodec<Types.Macro> _repeated_macros_codec = FieldCodec.ForMessage(18u, Types.Macro.Parser);

	private readonly RepeatedField<Types.Macro> macros_ = new RepeatedField<Types.Macro>();

	public const int MacroCollectionsFieldNumber = 3;

	private static readonly FieldCodec<Types.MacroCollection> _repeated_macroCollections_codec = FieldCodec.ForMessage(26u, Types.MacroCollection.Parser);

	private readonly RepeatedField<Types.MacroCollection> macroCollections_ = new RepeatedField<Types.MacroCollection>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MacrosDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MacrosReflection.Descriptor.MessageTypes[0];

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
	public RepeatedField<Types.Macro> Macros => macros_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.MacroCollection> MacroCollections => macroCollections_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacrosDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacrosDocument(MacrosDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		macros_ = other.macros_.Clone();
		macroCollections_ = other.macroCollections_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacrosDocument Clone()
	{
		return new MacrosDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MacrosDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MacrosDocument other)
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
		if (!macros_.Equals(other.macros_))
		{
			return false;
		}
		if (!macroCollections_.Equals(other.macroCollections_))
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
		num ^= macros_.GetHashCode();
		num ^= macroCollections_.GetHashCode();
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
		macros_.WriteTo(output, _repeated_macros_codec);
		macroCollections_.WriteTo(output, _repeated_macroCollections_codec);
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
		num += macros_.CalculateSize(_repeated_macros_codec);
		num += macroCollections_.CalculateSize(_repeated_macroCollections_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MacrosDocument other)
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
		macros_.Add(other.macros_);
		macroCollections_.Add(other.macroCollections_);
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
				macros_.AddEntriesFrom(input, _repeated_macros_codec);
				break;
			case 26u:
				macroCollections_.AddEntriesFrom(input, _repeated_macroCollections_codec);
				break;
			}
		}
	}
}
