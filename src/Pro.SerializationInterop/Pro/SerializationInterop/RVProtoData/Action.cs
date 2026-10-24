using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Action : IMessage<Action>, IMessage, IEquatable<Action>, IDeepCloneable<Action>
{
	public enum ActionTypeDataOneofCase
	{
		None = 0,
		CollectionElement = 16,
		PlaylistItem = 17,
		BlendMode = 18,
		Transition = 19,
		Media = 20,
		DoubleItem = 21,
		Effects = 22,
		Slide = 23,
		Background = 24,
		Timer = 25,
		Clear = 26,
		Stage = 27,
		Prop = 28,
		Mask = 29,
		Message = 30,
		Communication = 32,
		MultiScreen = 33,
		PresentationDocument = 34,
		ExternalPresentation = 36,
		AudienceLook = 37,
		AudioInput = 38,
		SlideDestination = 39,
		Macro = 40,
		ClearGroup = 41,
		TransportControl = 42,
		Capture = 43
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ContentDestination
		{
			[OriginalName("CONTENT_DESTINATION_GLOBAL")]
			Global,
			[OriginalName("CONTENT_DESTINATION_ANNOUNCEMENTS")]
			Announcements
		}

		public enum LayerType
		{
			[OriginalName("LAYER_TYPE_BACKGROUND")]
			Background,
			[OriginalName("LAYER_TYPE_FOREGROUND")]
			Foreground,
			[OriginalName("LAYER_TYPE_FILL")]
			Fill,
			[OriginalName("LAYER_TYPE_INPUT")]
			Input
		}

		public enum ActionType
		{
			[OriginalName("ACTION_TYPE_UNKNOWN")]
			Unknown = 0,
			[OriginalName("ACTION_TYPE_STAGE_LAYOUT")]
			StageLayout = 1,
			[OriginalName("ACTION_TYPE_MEDIA")]
			Media = 2,
			[OriginalName("ACTION_TYPE_TIMER")]
			Timer = 3,
			[OriginalName("ACTION_TYPE_COMMUNICATION")]
			Communication = 4,
			[OriginalName("ACTION_TYPE_CLEAR")]
			Clear = 5,
			[OriginalName("ACTION_TYPE_PROP")]
			Prop = 6,
			[Obsolete]
			[OriginalName("ACTION_TYPE_MASK")]
			Mask = 7,
			[OriginalName("ACTION_TYPE_MESSAGE")]
			Message = 8,
			[OriginalName("ACTION_TYPE_SOCIAL_MEDIA")]
			SocialMedia = 9,
			[Obsolete]
			[OriginalName("ACTION_TYPE_MULTISCREEN")]
			Multiscreen = 10,
			[OriginalName("ACTION_TYPE_PRESENTATION_SLIDE")]
			PresentationSlide = 11,
			[Obsolete]
			[OriginalName("ACTION_TYPE_FOREGROUND_MEDIA")]
			ForegroundMedia = 12,
			[Obsolete]
			[OriginalName("ACTION_TYPE_BACKGROUND_MEDIA")]
			BackgroundMedia = 13,
			[OriginalName("ACTION_TYPE_PRESENTATION_DOCUMENT")]
			PresentationDocument = 14,
			[OriginalName("ACTION_TYPE_PROP_SLIDE")]
			PropSlide = 15,
			[OriginalName("ACTION_TYPE_EXTERNAL_PRESENTATION")]
			ExternalPresentation = 17,
			[OriginalName("ACTION_TYPE_AUDIENCE_LOOK")]
			AudienceLook = 18,
			[OriginalName("ACTION_TYPE_AUDIO_INPUT")]
			AudioInput = 19,
			[OriginalName("ACTION_TYPE_AUDIO_BIN_PLAYLIST")]
			AudioBinPlaylist = 20,
			[OriginalName("ACTION_TYPE_MEDIA_BIN_PLAYLIST")]
			MediaBinPlaylist = 21,
			[OriginalName("ACTION_TYPE_SLIDE_DESTINATION")]
			SlideDestination = 22,
			[OriginalName("ACTION_TYPE_MACRO")]
			Macro = 23,
			[OriginalName("ACTION_TYPE_CLEAR_GROUP")]
			ClearGroup = 24,
			[OriginalName("ACTION_TYPE_CAPTURE")]
			Capture = 25,
			[OriginalName("ACTION_TYPE_LIBRARY_PLAYLIST")]
			LibraryPlaylist = 26
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class OldType : IMessage<OldType>, IMessage, IEquatable<OldType>, IDeepCloneable<OldType>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Category
				{
					[OriginalName("CATEGORY_UNKNOWN")]
					Unknown,
					[OriginalName("CATEGORY_MEDIA")]
					Media,
					[OriginalName("CATEGORY_APPLICATION")]
					Application
				}
			}

			private static readonly MessageParser<OldType> _parser = new MessageParser<OldType>(() => new OldType());

			private UnknownFieldSet _unknownFields;

			public const int CategoryFieldNumber = 1;

			private Types.Category category_;

			public const int ApplicationTypeFieldNumber = 2;

			private int applicationType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<OldType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Category Category
			{
				get
				{
					return category_;
				}
				set
				{
					category_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int ApplicationType
			{
				get
				{
					return applicationType_;
				}
				set
				{
					applicationType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OldType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OldType(OldType other)
				: this()
			{
				category_ = other.category_;
				applicationType_ = other.applicationType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OldType Clone()
			{
				return new OldType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as OldType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(OldType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Category != other.Category)
				{
					return false;
				}
				if (ApplicationType != other.ApplicationType)
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
				if (Category != 0)
				{
					num ^= Category.GetHashCode();
				}
				if (ApplicationType != 0)
				{
					num ^= ApplicationType.GetHashCode();
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
				if (Category != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Category);
				}
				if (ApplicationType != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(ApplicationType);
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
				if (Category != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Category);
				}
				if (ApplicationType != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(ApplicationType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(OldType other)
			{
				if (other != null)
				{
					if (other.Category != 0)
					{
						Category = other.Category;
					}
					if (other.ApplicationType != 0)
					{
						ApplicationType = other.ApplicationType;
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
						Category = (Types.Category)input.ReadEnum();
						break;
					case 16u:
						ApplicationType = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Label : IMessage<Label>, IMessage, IEquatable<Label>, IDeepCloneable<Label>
		{
			private static readonly MessageParser<Label> _parser = new MessageParser<Label>(() => new Label());

			private UnknownFieldSet _unknownFields;

			public const int TextFieldNumber = 2;

			private string text_ = "";

			public const int ColorFieldNumber = 3;

			private Color color_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Label> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Text
			{
				get
				{
					return text_;
				}
				set
				{
					text_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Label()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Label(Label other)
				: this()
			{
				text_ = other.text_;
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Label Clone()
			{
				return new Label(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Label);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Label other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Text != other.Text)
				{
					return false;
				}
				if (!object.Equals(Color, other.Color))
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
				if (Text.Length != 0)
				{
					num ^= Text.GetHashCode();
				}
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
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
				if (Text.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Text);
				}
				if (color_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Color);
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
				if (Text.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Text);
				}
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Label other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Text.Length != 0)
				{
					Text = other.Text;
				}
				if (other.color_ != null)
				{
					if (color_ == null)
					{
						Color = new Color();
					}
					Color.MergeFrom(other.Color);
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
					case 18u:
						Text = input.ReadString();
						break;
					case 26u:
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LayerIdentification : IMessage<LayerIdentification>, IMessage, IEquatable<LayerIdentification>, IDeepCloneable<LayerIdentification>
		{
			private static readonly MessageParser<LayerIdentification> _parser = new MessageParser<LayerIdentification>(() => new LayerIdentification());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LayerIdentification> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[2];

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
			public LayerIdentification()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LayerIdentification(LayerIdentification other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LayerIdentification Clone()
			{
				return new LayerIdentification(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LayerIdentification);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LayerIdentification other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LayerIdentification other)
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
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlaylistItemType : IMessage<PlaylistItemType>, IMessage, IEquatable<PlaylistItemType>, IDeepCloneable<PlaylistItemType>
		{
			private static readonly MessageParser<PlaylistItemType> _parser = new MessageParser<PlaylistItemType>(() => new PlaylistItemType());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistUuidFieldNumber = 1;

			private UUID playlistUuid_;

			public const int PlaylistNameFieldNumber = 2;

			private string playlistName_ = "";

			public const int ItemUuidFieldNumber = 3;

			private UUID itemUuid_;

			public const int ItemNameFieldNumber = 4;

			private string itemName_ = "";

			public const int SelectPlaylistFieldNumber = 5;

			private bool selectPlaylist_;

			public const int AlwaysRetriggerFieldNumber = 6;

			private bool alwaysRetrigger_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistItemType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID PlaylistUuid
			{
				get
				{
					return playlistUuid_;
				}
				set
				{
					playlistUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PlaylistName
			{
				get
				{
					return playlistName_;
				}
				set
				{
					playlistName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID ItemUuid
			{
				get
				{
					return itemUuid_;
				}
				set
				{
					itemUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ItemName
			{
				get
				{
					return itemName_;
				}
				set
				{
					itemName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool SelectPlaylist
			{
				get
				{
					return selectPlaylist_;
				}
				set
				{
					selectPlaylist_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AlwaysRetrigger
			{
				get
				{
					return alwaysRetrigger_;
				}
				set
				{
					alwaysRetrigger_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItemType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItemType(PlaylistItemType other)
				: this()
			{
				playlistUuid_ = ((other.playlistUuid_ != null) ? other.playlistUuid_.Clone() : null);
				playlistName_ = other.playlistName_;
				itemUuid_ = ((other.itemUuid_ != null) ? other.itemUuid_.Clone() : null);
				itemName_ = other.itemName_;
				selectPlaylist_ = other.selectPlaylist_;
				alwaysRetrigger_ = other.alwaysRetrigger_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItemType Clone()
			{
				return new PlaylistItemType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistItemType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistItemType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(PlaylistUuid, other.PlaylistUuid))
				{
					return false;
				}
				if (PlaylistName != other.PlaylistName)
				{
					return false;
				}
				if (!object.Equals(ItemUuid, other.ItemUuid))
				{
					return false;
				}
				if (ItemName != other.ItemName)
				{
					return false;
				}
				if (SelectPlaylist != other.SelectPlaylist)
				{
					return false;
				}
				if (AlwaysRetrigger != other.AlwaysRetrigger)
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
				if (playlistUuid_ != null)
				{
					num ^= PlaylistUuid.GetHashCode();
				}
				if (PlaylistName.Length != 0)
				{
					num ^= PlaylistName.GetHashCode();
				}
				if (itemUuid_ != null)
				{
					num ^= ItemUuid.GetHashCode();
				}
				if (ItemName.Length != 0)
				{
					num ^= ItemName.GetHashCode();
				}
				if (SelectPlaylist)
				{
					num ^= SelectPlaylist.GetHashCode();
				}
				if (AlwaysRetrigger)
				{
					num ^= AlwaysRetrigger.GetHashCode();
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
				if (playlistUuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PlaylistUuid);
				}
				if (PlaylistName.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(PlaylistName);
				}
				if (itemUuid_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ItemUuid);
				}
				if (ItemName.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(ItemName);
				}
				if (SelectPlaylist)
				{
					output.WriteRawTag(40);
					output.WriteBool(SelectPlaylist);
				}
				if (AlwaysRetrigger)
				{
					output.WriteRawTag(48);
					output.WriteBool(AlwaysRetrigger);
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
				if (playlistUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistUuid);
				}
				if (PlaylistName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PlaylistName);
				}
				if (itemUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ItemUuid);
				}
				if (ItemName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ItemName);
				}
				if (SelectPlaylist)
				{
					num += 2;
				}
				if (AlwaysRetrigger)
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
			public void MergeFrom(PlaylistItemType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.playlistUuid_ != null)
				{
					if (playlistUuid_ == null)
					{
						PlaylistUuid = new UUID();
					}
					PlaylistUuid.MergeFrom(other.PlaylistUuid);
				}
				if (other.PlaylistName.Length != 0)
				{
					PlaylistName = other.PlaylistName;
				}
				if (other.itemUuid_ != null)
				{
					if (itemUuid_ == null)
					{
						ItemUuid = new UUID();
					}
					ItemUuid.MergeFrom(other.ItemUuid);
				}
				if (other.ItemName.Length != 0)
				{
					ItemName = other.ItemName;
				}
				if (other.SelectPlaylist)
				{
					SelectPlaylist = other.SelectPlaylist;
				}
				if (other.AlwaysRetrigger)
				{
					AlwaysRetrigger = other.AlwaysRetrigger;
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
						if (playlistUuid_ == null)
						{
							PlaylistUuid = new UUID();
						}
						input.ReadMessage(PlaylistUuid);
						break;
					case 18u:
						PlaylistName = input.ReadString();
						break;
					case 26u:
						if (itemUuid_ == null)
						{
							ItemUuid = new UUID();
						}
						input.ReadMessage(ItemUuid);
						break;
					case 34u:
						ItemName = input.ReadString();
						break;
					case 40u:
						SelectPlaylist = input.ReadBool();
						break;
					case 48u:
						AlwaysRetrigger = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BlendModeType : IMessage<BlendModeType>, IMessage, IEquatable<BlendModeType>, IDeepCloneable<BlendModeType>
		{
			private static readonly MessageParser<BlendModeType> _parser = new MessageParser<BlendModeType>(() => new BlendModeType());

			private UnknownFieldSet _unknownFields;

			public const int BlendModeFieldNumber = 1;

			private Layer.Types.BlendMode blendMode_;

			public const int BlendFieldNumber = 2;

			private Layer.Types.Blending blend_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BlendModeType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[Obsolete]
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layer.Types.BlendMode BlendMode
			{
				get
				{
					return blendMode_;
				}
				set
				{
					blendMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layer.Types.Blending Blend
			{
				get
				{
					return blend_;
				}
				set
				{
					blend_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendModeType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendModeType(BlendModeType other)
				: this()
			{
				blendMode_ = other.blendMode_;
				blend_ = ((other.blend_ != null) ? other.blend_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendModeType Clone()
			{
				return new BlendModeType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BlendModeType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BlendModeType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (BlendMode != other.BlendMode)
				{
					return false;
				}
				if (!object.Equals(Blend, other.Blend))
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
				if (BlendMode != 0)
				{
					num ^= BlendMode.GetHashCode();
				}
				if (blend_ != null)
				{
					num ^= Blend.GetHashCode();
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
				if (BlendMode != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)BlendMode);
				}
				if (blend_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Blend);
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
				if (BlendMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)BlendMode);
				}
				if (blend_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Blend);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BlendModeType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.BlendMode != 0)
				{
					BlendMode = other.BlendMode;
				}
				if (other.blend_ != null)
				{
					if (blend_ == null)
					{
						Blend = new Layer.Types.Blending();
					}
					Blend.MergeFrom(other.Blend);
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
						BlendMode = (Layer.Types.BlendMode)input.ReadEnum();
						break;
					case 18u:
						if (blend_ == null)
						{
							Blend = new Layer.Types.Blending();
						}
						input.ReadMessage(Blend);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TransitionType : IMessage<TransitionType>, IMessage, IEquatable<TransitionType>, IDeepCloneable<TransitionType>
		{
			private static readonly MessageParser<TransitionType> _parser = new MessageParser<TransitionType>(() => new TransitionType());

			private UnknownFieldSet _unknownFields;

			public const int TransitionNameFieldNumber = 1;

			private string transitionName_ = "";

			public const int TransitionFieldNumber = 2;

			private Transition transition_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TransitionType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TransitionName
			{
				get
				{
					return transitionName_;
				}
				set
				{
					transitionName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Transition Transition
			{
				get
				{
					return transition_;
				}
				set
				{
					transition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransitionType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransitionType(TransitionType other)
				: this()
			{
				transitionName_ = other.transitionName_;
				transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransitionType Clone()
			{
				return new TransitionType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TransitionType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TransitionType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (TransitionName != other.TransitionName)
				{
					return false;
				}
				if (!object.Equals(Transition, other.Transition))
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
				if (TransitionName.Length != 0)
				{
					num ^= TransitionName.GetHashCode();
				}
				if (transition_ != null)
				{
					num ^= Transition.GetHashCode();
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
				if (TransitionName.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(TransitionName);
				}
				if (transition_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Transition);
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
				if (TransitionName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TransitionName);
				}
				if (transition_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TransitionType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.TransitionName.Length != 0)
				{
					TransitionName = other.TransitionName;
				}
				if (other.transition_ != null)
				{
					if (transition_ == null)
					{
						Transition = new Transition();
					}
					Transition.MergeFrom(other.Transition);
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
						TransitionName = input.ReadString();
						break;
					case 18u:
						if (transition_ == null)
						{
							Transition = new Transition();
						}
						input.ReadMessage(Transition);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DoubleType : IMessage<DoubleType>, IMessage, IEquatable<DoubleType>, IDeepCloneable<DoubleType>
		{
			private static readonly MessageParser<DoubleType> _parser = new MessageParser<DoubleType>(() => new DoubleType());

			private UnknownFieldSet _unknownFields;

			public const int ValueFieldNumber = 1;

			private double value_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DoubleType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Value
			{
				get
				{
					return value_;
				}
				set
				{
					value_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DoubleType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DoubleType(DoubleType other)
				: this()
			{
				value_ = other.value_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DoubleType Clone()
			{
				return new DoubleType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DoubleType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DoubleType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Value, other.Value))
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
				if (Value != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Value);
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
				if (Value != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Value);
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
				if (Value != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DoubleType other)
			{
				if (other != null)
				{
					if (other.Value != 0.0)
					{
						Value = other.Value;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Value = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EffectsType : IMessage<EffectsType>, IMessage, IEquatable<EffectsType>, IDeepCloneable<EffectsType>
		{
			private static readonly MessageParser<EffectsType> _parser = new MessageParser<EffectsType>(() => new EffectsType());

			private UnknownFieldSet _unknownFields;

			public const int EffectsFieldNumber = 1;

			private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(10u, Effect.Parser);

			private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EffectsType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Effect> Effects => effects_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectsType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectsType(EffectsType other)
				: this()
			{
				effects_ = other.effects_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectsType Clone()
			{
				return new EffectsType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EffectsType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EffectsType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!effects_.Equals(other.effects_))
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
				num ^= effects_.GetHashCode();
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
				effects_.WriteTo(output, _repeated_effects_codec);
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
				num += effects_.CalculateSize(_repeated_effects_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(EffectsType other)
			{
				if (other != null)
				{
					effects_.Add(other.effects_);
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
						effects_.AddEntriesFrom(input, _repeated_effects_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MediaType : IMessage<MediaType>, IMessage, IEquatable<MediaType>, IDeepCloneable<MediaType>
		{
			public enum MediaTypeOneofCase
			{
				None = 0,
				Image = 6,
				Video = 7,
				Audio = 8,
				LiveVideo = 9
			}

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

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Image : IMessage<Image>, IMessage, IEquatable<Image>, IDeepCloneable<Image>
				{
					private static readonly MessageParser<Image> _parser = new MessageParser<Image>(() => new Image());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Image> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MediaType.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image(Image other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image Clone()
					{
						return new Image(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Image);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Image other)
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
					public void MergeFrom(Image other)
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
				public sealed class Video : IMessage<Video>, IMessage, IEquatable<Video>, IDeepCloneable<Video>
				{
					private static readonly MessageParser<Video> _parser = new MessageParser<Video>(() => new Video());

					private UnknownFieldSet _unknownFields;

					public const int PlaybackBehaviorFieldNumber = 1;

					private PlaybackBehavior playbackBehavior_;

					public const int EndBehaviorFieldNumber = 2;

					private EndBehavior endBehavior_;

					public const int LoopTimeFieldNumber = 3;

					private double loopTime_;

					public const int TimesToLoopFieldNumber = 4;

					private uint timesToLoop_;

					public const int SoftLoopFieldNumber = 5;

					private bool softLoop_;

					public const int SoftLoopDurationFieldNumber = 6;

					private double softLoopDuration_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Video> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MediaType.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[Obsolete]
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PlaybackBehavior PlaybackBehavior
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

					[Obsolete]
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EndBehavior EndBehavior
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

					[Obsolete]
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

					[Obsolete]
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

					[Obsolete]
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

					[Obsolete]
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
					public Video()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Video(Video other)
						: this()
					{
						playbackBehavior_ = other.playbackBehavior_;
						endBehavior_ = other.endBehavior_;
						loopTime_ = other.loopTime_;
						timesToLoop_ = other.timesToLoop_;
						softLoop_ = other.softLoop_;
						softLoopDuration_ = other.softLoopDuration_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Video Clone()
					{
						return new Video(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Video);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Video other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (PlaybackBehavior != other.PlaybackBehavior)
						{
							return false;
						}
						if (EndBehavior != other.EndBehavior)
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
						if (SoftLoop != other.SoftLoop)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SoftLoopDuration, other.SoftLoopDuration))
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
						if (PlaybackBehavior != 0)
						{
							num ^= PlaybackBehavior.GetHashCode();
						}
						if (EndBehavior != 0)
						{
							num ^= EndBehavior.GetHashCode();
						}
						if (LoopTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LoopTime);
						}
						if (TimesToLoop != 0)
						{
							num ^= TimesToLoop.GetHashCode();
						}
						if (SoftLoop)
						{
							num ^= SoftLoop.GetHashCode();
						}
						if (SoftLoopDuration != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SoftLoopDuration);
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
						if (PlaybackBehavior != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)PlaybackBehavior);
						}
						if (EndBehavior != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)EndBehavior);
						}
						if (LoopTime != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(LoopTime);
						}
						if (TimesToLoop != 0)
						{
							output.WriteRawTag(32);
							output.WriteUInt32(TimesToLoop);
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
						if (PlaybackBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
						}
						if (EndBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)EndBehavior);
						}
						if (LoopTime != 0.0)
						{
							num += 9;
						}
						if (TimesToLoop != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(TimesToLoop);
						}
						if (SoftLoop)
						{
							num += 2;
						}
						if (SoftLoopDuration != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Video other)
					{
						if (other != null)
						{
							if (other.PlaybackBehavior != 0)
							{
								PlaybackBehavior = other.PlaybackBehavior;
							}
							if (other.EndBehavior != 0)
							{
								EndBehavior = other.EndBehavior;
							}
							if (other.LoopTime != 0.0)
							{
								LoopTime = other.LoopTime;
							}
							if (other.TimesToLoop != 0)
							{
								TimesToLoop = other.TimesToLoop;
							}
							if (other.SoftLoop)
							{
								SoftLoop = other.SoftLoop;
							}
							if (other.SoftLoopDuration != 0.0)
							{
								SoftLoopDuration = other.SoftLoopDuration;
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
								PlaybackBehavior = (PlaybackBehavior)input.ReadEnum();
								break;
							case 16u:
								EndBehavior = (EndBehavior)input.ReadEnum();
								break;
							case 25u:
								LoopTime = input.ReadDouble();
								break;
							case 32u:
								TimesToLoop = input.ReadUInt32();
								break;
							case 40u:
								SoftLoop = input.ReadBool();
								break;
							case 49u:
								SoftLoopDuration = input.ReadDouble();
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
						public enum MediaActionAudioType
						{
							[OriginalName("MEDIA_ACTION_AUDIO_TYPE_TUNE")]
							Tune,
							[OriginalName("MEDIA_ACTION_AUDIO_TYPE_SOUND")]
							Sound
						}
					}

					private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

					private UnknownFieldSet _unknownFields;

					public const int PlaybackBehaviorFieldNumber = 1;

					private PlaybackBehavior playbackBehavior_;

					public const int LoopTimeFieldNumber = 2;

					private double loopTime_;

					public const int TimesToLoopFieldNumber = 3;

					private uint timesToLoop_;

					public const int AudioTypeFieldNumber = 4;

					private Types.MediaActionAudioType audioType_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Audio> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MediaType.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[Obsolete]
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PlaybackBehavior PlaybackBehavior
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

					[Obsolete]
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

					[Obsolete]
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
					public Types.MediaActionAudioType AudioType
					{
						get
						{
							return audioType_;
						}
						set
						{
							audioType_ = value;
						}
					}

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
						playbackBehavior_ = other.playbackBehavior_;
						loopTime_ = other.loopTime_;
						timesToLoop_ = other.timesToLoop_;
						audioType_ = other.audioType_;
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
						if (AudioType != other.AudioType)
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
						if (AudioType != 0)
						{
							num ^= AudioType.GetHashCode();
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
						if (PlaybackBehavior != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)PlaybackBehavior);
						}
						if (LoopTime != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(LoopTime);
						}
						if (TimesToLoop != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(TimesToLoop);
						}
						if (AudioType != 0)
						{
							output.WriteRawTag(32);
							output.WriteEnum((int)AudioType);
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
						if (AudioType != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)AudioType);
						}
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
							if (other.AudioType != 0)
							{
								AudioType = other.AudioType;
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
								PlaybackBehavior = (PlaybackBehavior)input.ReadEnum();
								break;
							case 17u:
								LoopTime = input.ReadDouble();
								break;
							case 24u:
								TimesToLoop = input.ReadUInt32();
								break;
							case 32u:
								AudioType = (Types.MediaActionAudioType)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class LiveVideo : IMessage<LiveVideo>, IMessage, IEquatable<LiveVideo>, IDeepCloneable<LiveVideo>
				{
					private static readonly MessageParser<LiveVideo> _parser = new MessageParser<LiveVideo>(() => new LiveVideo());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<LiveVideo> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MediaType.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LiveVideo()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LiveVideo(LiveVideo other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LiveVideo Clone()
					{
						return new LiveVideo(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as LiveVideo);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(LiveVideo other)
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
					public void MergeFrom(LiveVideo other)
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
				public sealed class PlaybackMarker : IMessage<PlaybackMarker>, IMessage, IEquatable<PlaybackMarker>, IDeepCloneable<PlaybackMarker>
				{
					private static readonly MessageParser<PlaybackMarker> _parser = new MessageParser<PlaybackMarker>(() => new PlaybackMarker());

					private UnknownFieldSet _unknownFields;

					public const int UuidFieldNumber = 1;

					private UUID uuid_;

					public const int TimeFieldNumber = 2;

					private double time_;

					public const int ColorFieldNumber = 3;

					private Color color_;

					public const int NameFieldNumber = 4;

					private string name_ = "";

					public const int ActionsFieldNumber = 5;

					private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(42u, Action.Parser);

					private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<PlaybackMarker> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MediaType.Descriptor.NestedTypes[4];

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
					public double Time
					{
						get
						{
							return time_;
						}
						set
						{
							time_ = value;
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
					public RepeatedField<Action> Actions => actions_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PlaybackMarker()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PlaybackMarker(PlaybackMarker other)
						: this()
					{
						uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
						time_ = other.time_;
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						name_ = other.name_;
						actions_ = other.actions_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PlaybackMarker Clone()
					{
						return new PlaybackMarker(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as PlaybackMarker);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(PlaybackMarker other)
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
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
						{
							return false;
						}
						if (!object.Equals(Color, other.Color))
						{
							return false;
						}
						if (Name != other.Name)
						{
							return false;
						}
						if (!actions_.Equals(other.actions_))
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
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
						}
						if (color_ != null)
						{
							num ^= Color.GetHashCode();
						}
						if (Name.Length != 0)
						{
							num ^= Name.GetHashCode();
						}
						num ^= actions_.GetHashCode();
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
						if (Time != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Time);
						}
						if (color_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Color);
						}
						if (Name.Length != 0)
						{
							output.WriteRawTag(34);
							output.WriteString(Name);
						}
						actions_.WriteTo(output, _repeated_actions_codec);
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
						if (Time != 0.0)
						{
							num += 9;
						}
						if (color_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Color);
						}
						if (Name.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Name);
						}
						num += actions_.CalculateSize(_repeated_actions_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(PlaybackMarker other)
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
						if (other.Time != 0.0)
						{
							Time = other.Time;
						}
						if (other.color_ != null)
						{
							if (color_ == null)
							{
								Color = new Color();
							}
							Color.MergeFrom(other.Color);
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						actions_.Add(other.actions_);
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
							case 17u:
								Time = input.ReadDouble();
								break;
							case 26u:
								if (color_ == null)
								{
									Color = new Color();
								}
								input.ReadMessage(Color);
								break;
							case 34u:
								Name = input.ReadString();
								break;
							case 42u:
								actions_.AddEntriesFrom(input, _repeated_actions_codec);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<MediaType> _parser = new MessageParser<MediaType>(() => new MediaType());

			private UnknownFieldSet _unknownFields;

			public const int TransitionDurationFieldNumber = 1;

			private double transitionDuration_;

			public const int SelectedEffectPresetUuidFieldNumber = 2;

			private UUID selectedEffectPresetUuid_;

			public const int TransitionFieldNumber = 3;

			private Transition transition_;

			public const int EffectsFieldNumber = 4;

			private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(34u, Effect.Parser);

			private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

			public const int ElementFieldNumber = 5;

			private Media element_;

			public const int ImageFieldNumber = 6;

			public const int VideoFieldNumber = 7;

			public const int AudioFieldNumber = 8;

			public const int LiveVideoFieldNumber = 9;

			public const int LayerTypeFieldNumber = 10;

			private LayerType layerType_;

			public const int AlwaysRetriggerFieldNumber = 11;

			private bool alwaysRetrigger_;

			public const int MarkersFieldNumber = 12;

			private static readonly FieldCodec<Types.PlaybackMarker> _repeated_markers_codec = FieldCodec.ForMessage(98u, Types.PlaybackMarker.Parser);

			private readonly RepeatedField<Types.PlaybackMarker> markers_ = new RepeatedField<Types.PlaybackMarker>();

			private object mediaType_;

			private MediaTypeOneofCase mediaTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double TransitionDuration
			{
				get
				{
					return transitionDuration_;
				}
				set
				{
					transitionDuration_ = value;
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
			public Transition Transition
			{
				get
				{
					return transition_;
				}
				set
				{
					transition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Effect> Effects => effects_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media Element
			{
				get
				{
					return element_;
				}
				set
				{
					element_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Image Image
			{
				get
				{
					if (mediaTypeCase_ != MediaTypeOneofCase.Image)
					{
						return null;
					}
					return (Types.Image)mediaType_;
				}
				set
				{
					mediaType_ = value;
					mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.Image : MediaTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Video Video
			{
				get
				{
					if (mediaTypeCase_ != MediaTypeOneofCase.Video)
					{
						return null;
					}
					return (Types.Video)mediaType_;
				}
				set
				{
					mediaType_ = value;
					mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.Video : MediaTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Audio Audio
			{
				get
				{
					if (mediaTypeCase_ != MediaTypeOneofCase.Audio)
					{
						return null;
					}
					return (Types.Audio)mediaType_;
				}
				set
				{
					mediaType_ = value;
					mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.Audio : MediaTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.LiveVideo LiveVideo
			{
				get
				{
					if (mediaTypeCase_ != MediaTypeOneofCase.LiveVideo)
					{
						return null;
					}
					return (Types.LiveVideo)mediaType_;
				}
				set
				{
					mediaType_ = value;
					mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.LiveVideo : MediaTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LayerType LayerType
			{
				get
				{
					return layerType_;
				}
				set
				{
					layerType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AlwaysRetrigger
			{
				get
				{
					return alwaysRetrigger_;
				}
				set
				{
					alwaysRetrigger_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.PlaybackMarker> Markers => markers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaTypeOneofCase MediaTypeCase => mediaTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaType(MediaType other)
				: this()
			{
				transitionDuration_ = other.transitionDuration_;
				selectedEffectPresetUuid_ = ((other.selectedEffectPresetUuid_ != null) ? other.selectedEffectPresetUuid_.Clone() : null);
				transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
				effects_ = other.effects_.Clone();
				element_ = ((other.element_ != null) ? other.element_.Clone() : null);
				layerType_ = other.layerType_;
				alwaysRetrigger_ = other.alwaysRetrigger_;
				markers_ = other.markers_.Clone();
				switch (other.MediaTypeCase)
				{
				case MediaTypeOneofCase.Image:
					Image = other.Image.Clone();
					break;
				case MediaTypeOneofCase.Video:
					Video = other.Video.Clone();
					break;
				case MediaTypeOneofCase.Audio:
					Audio = other.Audio.Clone();
					break;
				case MediaTypeOneofCase.LiveVideo:
					LiveVideo = other.LiveVideo.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaType Clone()
			{
				return new MediaType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearMediaType()
			{
				mediaTypeCase_ = MediaTypeOneofCase.None;
				mediaType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TransitionDuration, other.TransitionDuration))
				{
					return false;
				}
				if (!object.Equals(SelectedEffectPresetUuid, other.SelectedEffectPresetUuid))
				{
					return false;
				}
				if (!object.Equals(Transition, other.Transition))
				{
					return false;
				}
				if (!effects_.Equals(other.effects_))
				{
					return false;
				}
				if (!object.Equals(Element, other.Element))
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
				if (!object.Equals(Audio, other.Audio))
				{
					return false;
				}
				if (!object.Equals(LiveVideo, other.LiveVideo))
				{
					return false;
				}
				if (LayerType != other.LayerType)
				{
					return false;
				}
				if (AlwaysRetrigger != other.AlwaysRetrigger)
				{
					return false;
				}
				if (!markers_.Equals(other.markers_))
				{
					return false;
				}
				if (MediaTypeCase != other.MediaTypeCase)
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
				if (TransitionDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TransitionDuration);
				}
				if (selectedEffectPresetUuid_ != null)
				{
					num ^= SelectedEffectPresetUuid.GetHashCode();
				}
				if (transition_ != null)
				{
					num ^= Transition.GetHashCode();
				}
				num ^= effects_.GetHashCode();
				if (element_ != null)
				{
					num ^= Element.GetHashCode();
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Image)
				{
					num ^= Image.GetHashCode();
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Video)
				{
					num ^= Video.GetHashCode();
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Audio)
				{
					num ^= Audio.GetHashCode();
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.LiveVideo)
				{
					num ^= LiveVideo.GetHashCode();
				}
				if (LayerType != 0)
				{
					num ^= LayerType.GetHashCode();
				}
				if (AlwaysRetrigger)
				{
					num ^= AlwaysRetrigger.GetHashCode();
				}
				num ^= markers_.GetHashCode();
				num ^= (int)mediaTypeCase_;
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
				if (TransitionDuration != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(TransitionDuration);
				}
				if (selectedEffectPresetUuid_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(SelectedEffectPresetUuid);
				}
				if (transition_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Transition);
				}
				effects_.WriteTo(output, _repeated_effects_codec);
				if (element_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Element);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Image)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Image);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Video)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Video);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Audio)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Audio);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.LiveVideo)
				{
					output.WriteRawTag(74);
					output.WriteMessage(LiveVideo);
				}
				if (LayerType != 0)
				{
					output.WriteRawTag(80);
					output.WriteEnum((int)LayerType);
				}
				if (AlwaysRetrigger)
				{
					output.WriteRawTag(88);
					output.WriteBool(AlwaysRetrigger);
				}
				markers_.WriteTo(output, _repeated_markers_codec);
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
				if (TransitionDuration != 0.0)
				{
					num += 9;
				}
				if (selectedEffectPresetUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SelectedEffectPresetUuid);
				}
				if (transition_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
				}
				num += effects_.CalculateSize(_repeated_effects_codec);
				if (element_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Element);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Image)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Image);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Video)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Video);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.Audio)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
				}
				if (mediaTypeCase_ == MediaTypeOneofCase.LiveVideo)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LiveVideo);
				}
				if (LayerType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)LayerType);
				}
				if (AlwaysRetrigger)
				{
					num += 2;
				}
				num += markers_.CalculateSize(_repeated_markers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MediaType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.TransitionDuration != 0.0)
				{
					TransitionDuration = other.TransitionDuration;
				}
				if (other.selectedEffectPresetUuid_ != null)
				{
					if (selectedEffectPresetUuid_ == null)
					{
						SelectedEffectPresetUuid = new UUID();
					}
					SelectedEffectPresetUuid.MergeFrom(other.SelectedEffectPresetUuid);
				}
				if (other.transition_ != null)
				{
					if (transition_ == null)
					{
						Transition = new Transition();
					}
					Transition.MergeFrom(other.Transition);
				}
				effects_.Add(other.effects_);
				if (other.element_ != null)
				{
					if (element_ == null)
					{
						Element = new Media();
					}
					Element.MergeFrom(other.Element);
				}
				if (other.LayerType != 0)
				{
					LayerType = other.LayerType;
				}
				if (other.AlwaysRetrigger)
				{
					AlwaysRetrigger = other.AlwaysRetrigger;
				}
				markers_.Add(other.markers_);
				switch (other.MediaTypeCase)
				{
				case MediaTypeOneofCase.Image:
					if (Image == null)
					{
						Image = new Types.Image();
					}
					Image.MergeFrom(other.Image);
					break;
				case MediaTypeOneofCase.Video:
					if (Video == null)
					{
						Video = new Types.Video();
					}
					Video.MergeFrom(other.Video);
					break;
				case MediaTypeOneofCase.Audio:
					if (Audio == null)
					{
						Audio = new Types.Audio();
					}
					Audio.MergeFrom(other.Audio);
					break;
				case MediaTypeOneofCase.LiveVideo:
					if (LiveVideo == null)
					{
						LiveVideo = new Types.LiveVideo();
					}
					LiveVideo.MergeFrom(other.LiveVideo);
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
					case 9u:
						TransitionDuration = input.ReadDouble();
						break;
					case 18u:
						if (selectedEffectPresetUuid_ == null)
						{
							SelectedEffectPresetUuid = new UUID();
						}
						input.ReadMessage(SelectedEffectPresetUuid);
						break;
					case 26u:
						if (transition_ == null)
						{
							Transition = new Transition();
						}
						input.ReadMessage(Transition);
						break;
					case 34u:
						effects_.AddEntriesFrom(input, _repeated_effects_codec);
						break;
					case 42u:
						if (element_ == null)
						{
							Element = new Media();
						}
						input.ReadMessage(Element);
						break;
					case 50u:
					{
						Types.Image image = new Types.Image();
						if (mediaTypeCase_ == MediaTypeOneofCase.Image)
						{
							image.MergeFrom(Image);
						}
						input.ReadMessage(image);
						Image = image;
						break;
					}
					case 58u:
					{
						Types.Video video = new Types.Video();
						if (mediaTypeCase_ == MediaTypeOneofCase.Video)
						{
							video.MergeFrom(Video);
						}
						input.ReadMessage(video);
						Video = video;
						break;
					}
					case 66u:
					{
						Types.Audio audio = new Types.Audio();
						if (mediaTypeCase_ == MediaTypeOneofCase.Audio)
						{
							audio.MergeFrom(Audio);
						}
						input.ReadMessage(audio);
						Audio = audio;
						break;
					}
					case 74u:
					{
						Types.LiveVideo liveVideo = new Types.LiveVideo();
						if (mediaTypeCase_ == MediaTypeOneofCase.LiveVideo)
						{
							liveVideo.MergeFrom(LiveVideo);
						}
						input.ReadMessage(liveVideo);
						LiveVideo = liveVideo;
						break;
					}
					case 80u:
						LayerType = (LayerType)input.ReadEnum();
						break;
					case 88u:
						AlwaysRetrigger = input.ReadBool();
						break;
					case 98u:
						markers_.AddEntriesFrom(input, _repeated_markers_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideType : IMessage<SlideType>, IMessage, IEquatable<SlideType>, IDeepCloneable<SlideType>
		{
			public enum SlideOneofCase
			{
				None = 0,
				Presentation = 2,
				Prop = 3
			}

			private static readonly MessageParser<SlideType> _parser = new MessageParser<SlideType>(() => new SlideType());

			private UnknownFieldSet _unknownFields;

			public const int PresentationFieldNumber = 2;

			public const int PropFieldNumber = 3;

			private object slide_;

			private SlideOneofCase slideCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PresentationSlide Presentation
			{
				get
				{
					if (slideCase_ != SlideOneofCase.Presentation)
					{
						return null;
					}
					return (PresentationSlide)slide_;
				}
				set
				{
					slide_ = value;
					slideCase_ = ((value != null) ? SlideOneofCase.Presentation : SlideOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropSlide Prop
			{
				get
				{
					if (slideCase_ != SlideOneofCase.Prop)
					{
						return null;
					}
					return (PropSlide)slide_;
				}
				set
				{
					slide_ = value;
					slideCase_ = ((value != null) ? SlideOneofCase.Prop : SlideOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideOneofCase SlideCase => slideCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideType(SlideType other)
				: this()
			{
				switch (other.SlideCase)
				{
				case SlideOneofCase.Presentation:
					Presentation = other.Presentation.Clone();
					break;
				case SlideOneofCase.Prop:
					Prop = other.Prop.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideType Clone()
			{
				return new SlideType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearSlide()
			{
				slideCase_ = SlideOneofCase.None;
				slide_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SlideType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SlideType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Presentation, other.Presentation))
				{
					return false;
				}
				if (!object.Equals(Prop, other.Prop))
				{
					return false;
				}
				if (SlideCase != other.SlideCase)
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
				if (slideCase_ == SlideOneofCase.Presentation)
				{
					num ^= Presentation.GetHashCode();
				}
				if (slideCase_ == SlideOneofCase.Prop)
				{
					num ^= Prop.GetHashCode();
				}
				num ^= (int)slideCase_;
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
				if (slideCase_ == SlideOneofCase.Presentation)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Presentation);
				}
				if (slideCase_ == SlideOneofCase.Prop)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Prop);
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
				if (slideCase_ == SlideOneofCase.Presentation)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
				}
				if (slideCase_ == SlideOneofCase.Prop)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prop);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SlideType other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.SlideCase)
				{
				case SlideOneofCase.Presentation:
					if (Presentation == null)
					{
						Presentation = new PresentationSlide();
					}
					Presentation.MergeFrom(other.Presentation);
					break;
				case SlideOneofCase.Prop:
					if (Prop == null)
					{
						Prop = new PropSlide();
					}
					Prop.MergeFrom(other.Prop);
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
					case 18u:
					{
						PresentationSlide presentationSlide = new PresentationSlide();
						if (slideCase_ == SlideOneofCase.Presentation)
						{
							presentationSlide.MergeFrom(Presentation);
						}
						input.ReadMessage(presentationSlide);
						Presentation = presentationSlide;
						break;
					}
					case 26u:
					{
						PropSlide propSlide = new PropSlide();
						if (slideCase_ == SlideOneofCase.Prop)
						{
							propSlide.MergeFrom(Prop);
						}
						input.ReadMessage(propSlide);
						Prop = propSlide;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BackgroundType : IMessage<BackgroundType>, IMessage, IEquatable<BackgroundType>, IDeepCloneable<BackgroundType>
		{
			private static readonly MessageParser<BackgroundType> _parser = new MessageParser<BackgroundType>(() => new BackgroundType());

			private UnknownFieldSet _unknownFields;

			public const int ElementFieldNumber = 1;

			private Background element_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BackgroundType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Background Element
			{
				get
				{
					return element_;
				}
				set
				{
					element_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundType(BackgroundType other)
				: this()
			{
				element_ = ((other.element_ != null) ? other.element_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundType Clone()
			{
				return new BackgroundType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BackgroundType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BackgroundType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Element, other.Element))
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
				if (element_ != null)
				{
					num ^= Element.GetHashCode();
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
				if (element_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Element);
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
				if (element_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Element);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BackgroundType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.element_ != null)
				{
					if (element_ == null)
					{
						Element = new Background();
					}
					Element.MergeFrom(other.Element);
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
					if (element_ == null)
					{
						Element = new Background();
					}
					input.ReadMessage(Element);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerType : IMessage<TimerType>, IMessage, IEquatable<TimerType>, IDeepCloneable<TimerType>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum TimerAction
				{
					[OriginalName("ACTION_START")]
					ActionStart,
					[OriginalName("ACTION_STOP")]
					ActionStop,
					[OriginalName("ACTION_RESET")]
					ActionReset,
					[OriginalName("ACTION_RESET_AND_START")]
					ActionResetAndStart,
					[OriginalName("ACTION_STOP_AND_RESET")]
					ActionStopAndReset,
					[OriginalName("ACTION_INCREMENT")]
					ActionIncrement
				}
			}

			private static readonly MessageParser<TimerType> _parser = new MessageParser<TimerType>(() => new TimerType());

			private UnknownFieldSet _unknownFields;

			public const int ActionTypeFieldNumber = 2;

			private Types.TimerAction actionType_;

			public const int TimerIdentificationFieldNumber = 4;

			private CollectionElementType timerIdentification_;

			public const int TimerConfigurationFieldNumber = 10;

			private Timer.Types.Configuration timerConfiguration_;

			public const int IncrementAmountFieldNumber = 11;

			private double incrementAmount_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TimerAction ActionType
			{
				get
				{
					return actionType_;
				}
				set
				{
					actionType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType TimerIdentification
			{
				get
				{
					return timerIdentification_;
				}
				set
				{
					timerIdentification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timer.Types.Configuration TimerConfiguration
			{
				get
				{
					return timerConfiguration_;
				}
				set
				{
					timerConfiguration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double IncrementAmount
			{
				get
				{
					return incrementAmount_;
				}
				set
				{
					incrementAmount_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerType(TimerType other)
				: this()
			{
				actionType_ = other.actionType_;
				timerIdentification_ = ((other.timerIdentification_ != null) ? other.timerIdentification_.Clone() : null);
				timerConfiguration_ = ((other.timerConfiguration_ != null) ? other.timerConfiguration_.Clone() : null);
				incrementAmount_ = other.incrementAmount_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerType Clone()
			{
				return new TimerType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimerType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimerType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ActionType != other.ActionType)
				{
					return false;
				}
				if (!object.Equals(TimerIdentification, other.TimerIdentification))
				{
					return false;
				}
				if (!object.Equals(TimerConfiguration, other.TimerConfiguration))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(IncrementAmount, other.IncrementAmount))
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
				if (ActionType != 0)
				{
					num ^= ActionType.GetHashCode();
				}
				if (timerIdentification_ != null)
				{
					num ^= TimerIdentification.GetHashCode();
				}
				if (timerConfiguration_ != null)
				{
					num ^= TimerConfiguration.GetHashCode();
				}
				if (IncrementAmount != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(IncrementAmount);
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
				if (ActionType != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)ActionType);
				}
				if (timerIdentification_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(TimerIdentification);
				}
				if (timerConfiguration_ != null)
				{
					output.WriteRawTag(82);
					output.WriteMessage(TimerConfiguration);
				}
				if (IncrementAmount != 0.0)
				{
					output.WriteRawTag(89);
					output.WriteDouble(IncrementAmount);
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
				if (ActionType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ActionType);
				}
				if (timerIdentification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TimerIdentification);
				}
				if (timerConfiguration_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TimerConfiguration);
				}
				if (IncrementAmount != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimerType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ActionType != 0)
				{
					ActionType = other.ActionType;
				}
				if (other.timerIdentification_ != null)
				{
					if (timerIdentification_ == null)
					{
						TimerIdentification = new CollectionElementType();
					}
					TimerIdentification.MergeFrom(other.TimerIdentification);
				}
				if (other.timerConfiguration_ != null)
				{
					if (timerConfiguration_ == null)
					{
						TimerConfiguration = new Timer.Types.Configuration();
					}
					TimerConfiguration.MergeFrom(other.TimerConfiguration);
				}
				if (other.IncrementAmount != 0.0)
				{
					IncrementAmount = other.IncrementAmount;
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
					case 16u:
						ActionType = (Types.TimerAction)input.ReadEnum();
						break;
					case 34u:
						if (timerIdentification_ == null)
						{
							TimerIdentification = new CollectionElementType();
						}
						input.ReadMessage(TimerIdentification);
						break;
					case 82u:
						if (timerConfiguration_ == null)
						{
							TimerConfiguration = new Timer.Types.Configuration();
						}
						input.ReadMessage(TimerConfiguration);
						break;
					case 89u:
						IncrementAmount = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearType : IMessage<ClearType>, IMessage, IEquatable<ClearType>, IDeepCloneable<ClearType>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ClearTargetLayer
				{
					[OriginalName("CLEAR_TARGET_LAYER_ALL")]
					All,
					[OriginalName("CLEAR_TARGET_LAYER_AUDIO")]
					Audio,
					[OriginalName("CLEAR_TARGET_LAYER_BACKGROUND")]
					Background,
					[OriginalName("CLEAR_TARGET_LAYER_LIVE_VIDEO")]
					LiveVideo,
					[OriginalName("CLEAR_TARGET_LAYER_PROP")]
					Prop,
					[OriginalName("CLEAR_TARGET_LAYER_SLIDE")]
					Slide,
					[OriginalName("CLEAR_TARGET_LAYER_LOGO")]
					Logo,
					[OriginalName("CLEAR_TARGET_LAYER_MESSAGES")]
					Messages,
					[OriginalName("CLEAR_TARGET_LAYER_AUDIO_EFFECTS")]
					AudioEffects
				}
			}

			private static readonly MessageParser<ClearType> _parser = new MessageParser<ClearType>(() => new ClearType());

			private UnknownFieldSet _unknownFields;

			public const int TargetLayerFieldNumber = 2;

			private Types.ClearTargetLayer targetLayer_;

			public const int ContentDestinationFieldNumber = 4;

			private ContentDestination contentDestination_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ClearTargetLayer TargetLayer
			{
				get
				{
					return targetLayer_;
				}
				set
				{
					targetLayer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ContentDestination ContentDestination
			{
				get
				{
					return contentDestination_;
				}
				set
				{
					contentDestination_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearType(ClearType other)
				: this()
			{
				targetLayer_ = other.targetLayer_;
				contentDestination_ = other.contentDestination_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearType Clone()
			{
				return new ClearType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (TargetLayer != other.TargetLayer)
				{
					return false;
				}
				if (ContentDestination != other.ContentDestination)
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
				if (TargetLayer != 0)
				{
					num ^= TargetLayer.GetHashCode();
				}
				if (ContentDestination != 0)
				{
					num ^= ContentDestination.GetHashCode();
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
				if (TargetLayer != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)TargetLayer);
				}
				if (ContentDestination != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)ContentDestination);
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
				if (TargetLayer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)TargetLayer);
				}
				if (ContentDestination != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClearType other)
			{
				if (other != null)
				{
					if (other.TargetLayer != 0)
					{
						TargetLayer = other.TargetLayer;
					}
					if (other.ContentDestination != 0)
					{
						ContentDestination = other.ContentDestination;
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
					case 16u:
						TargetLayer = (Types.ClearTargetLayer)input.ReadEnum();
						break;
					case 32u:
						ContentDestination = (ContentDestination)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearGroupType : IMessage<ClearGroupType>, IMessage, IEquatable<ClearGroupType>, IDeepCloneable<ClearGroupType>
		{
			private static readonly MessageParser<ClearGroupType> _parser = new MessageParser<ClearGroupType>(() => new ClearGroupType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 1;

			private CollectionElementType identification_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearGroupType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroupType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroupType(ClearGroupType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearGroupType Clone()
			{
				return new ClearGroupType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearGroupType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearGroupType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Identification);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClearGroupType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
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
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					input.ReadMessage(Identification);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TransportControlType : IMessage<TransportControlType>, IMessage, IEquatable<TransportControlType>, IDeepCloneable<TransportControlType>
		{
			public enum CommandOneofCase
			{
				None,
				Play,
				Pause,
				JumpToTime
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Play : IMessage<Play>, IMessage, IEquatable<Play>, IDeepCloneable<Play>
				{
					private static readonly MessageParser<Play> _parser = new MessageParser<Play>(() => new Play());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Play> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TransportControlType.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play(Play other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play Clone()
					{
						return new Play(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Play);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Play other)
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
					public void MergeFrom(Play other)
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
				public sealed class Pause : IMessage<Pause>, IMessage, IEquatable<Pause>, IDeepCloneable<Pause>
				{
					private static readonly MessageParser<Pause> _parser = new MessageParser<Pause>(() => new Pause());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Pause> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TransportControlType.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause(Pause other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause Clone()
					{
						return new Pause(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Pause);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Pause other)
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
					public void MergeFrom(Pause other)
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
				public sealed class JumpToTime : IMessage<JumpToTime>, IMessage, IEquatable<JumpToTime>, IDeepCloneable<JumpToTime>
				{
					private static readonly MessageParser<JumpToTime> _parser = new MessageParser<JumpToTime>(() => new JumpToTime());

					private UnknownFieldSet _unknownFields;

					public const int TimeFieldNumber = 1;

					private double time_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<JumpToTime> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TransportControlType.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Time
					{
						get
						{
							return time_;
						}
						set
						{
							time_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public JumpToTime()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public JumpToTime(JumpToTime other)
						: this()
					{
						time_ = other.time_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public JumpToTime Clone()
					{
						return new JumpToTime(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as JumpToTime);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(JumpToTime other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
						if (Time != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Time);
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
						if (Time != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(JumpToTime other)
					{
						if (other != null)
						{
							if (other.Time != 0.0)
							{
								Time = other.Time;
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Time = input.ReadDouble();
							}
						}
					}
				}
			}

			private static readonly MessageParser<TransportControlType> _parser = new MessageParser<TransportControlType>(() => new TransportControlType());

			private UnknownFieldSet _unknownFields;

			public const int PlayFieldNumber = 1;

			public const int PauseFieldNumber = 2;

			public const int JumpToTimeFieldNumber = 3;

			private object command_;

			private CommandOneofCase commandCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TransportControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Play Play
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Play)
					{
						return null;
					}
					return (Types.Play)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Play : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Pause Pause
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Pause)
					{
						return null;
					}
					return (Types.Pause)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Pause : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.JumpToTime JumpToTime
			{
				get
				{
					if (commandCase_ != CommandOneofCase.JumpToTime)
					{
						return null;
					}
					return (Types.JumpToTime)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.JumpToTime : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommandOneofCase CommandCase => commandCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportControlType(TransportControlType other)
				: this()
			{
				switch (other.CommandCase)
				{
				case CommandOneofCase.Play:
					Play = other.Play.Clone();
					break;
				case CommandOneofCase.Pause:
					Pause = other.Pause.Clone();
					break;
				case CommandOneofCase.JumpToTime:
					JumpToTime = other.JumpToTime.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TransportControlType Clone()
			{
				return new TransportControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearCommand()
			{
				commandCase_ = CommandOneofCase.None;
				command_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TransportControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TransportControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Play, other.Play))
				{
					return false;
				}
				if (!object.Equals(Pause, other.Pause))
				{
					return false;
				}
				if (!object.Equals(JumpToTime, other.JumpToTime))
				{
					return false;
				}
				if (CommandCase != other.CommandCase)
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
				if (commandCase_ == CommandOneofCase.Play)
				{
					num ^= Play.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Pause)
				{
					num ^= Pause.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.JumpToTime)
				{
					num ^= JumpToTime.GetHashCode();
				}
				num ^= (int)commandCase_;
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
				if (commandCase_ == CommandOneofCase.Play)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Play);
				}
				if (commandCase_ == CommandOneofCase.Pause)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Pause);
				}
				if (commandCase_ == CommandOneofCase.JumpToTime)
				{
					output.WriteRawTag(26);
					output.WriteMessage(JumpToTime);
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
				if (commandCase_ == CommandOneofCase.Play)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Play);
				}
				if (commandCase_ == CommandOneofCase.Pause)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
				}
				if (commandCase_ == CommandOneofCase.JumpToTime)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(JumpToTime);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TransportControlType other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.CommandCase)
				{
				case CommandOneofCase.Play:
					if (Play == null)
					{
						Play = new Types.Play();
					}
					Play.MergeFrom(other.Play);
					break;
				case CommandOneofCase.Pause:
					if (Pause == null)
					{
						Pause = new Types.Pause();
					}
					Pause.MergeFrom(other.Pause);
					break;
				case CommandOneofCase.JumpToTime:
					if (JumpToTime == null)
					{
						JumpToTime = new Types.JumpToTime();
					}
					JumpToTime.MergeFrom(other.JumpToTime);
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
						Types.Play play = new Types.Play();
						if (commandCase_ == CommandOneofCase.Play)
						{
							play.MergeFrom(Play);
						}
						input.ReadMessage(play);
						Play = play;
						break;
					}
					case 18u:
					{
						Types.Pause pause = new Types.Pause();
						if (commandCase_ == CommandOneofCase.Pause)
						{
							pause.MergeFrom(Pause);
						}
						input.ReadMessage(pause);
						Pause = pause;
						break;
					}
					case 26u:
					{
						Types.JumpToTime jumpToTime = new Types.JumpToTime();
						if (commandCase_ == CommandOneofCase.JumpToTime)
						{
							jumpToTime.MergeFrom(JumpToTime);
						}
						input.ReadMessage(jumpToTime);
						JumpToTime = jumpToTime;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StageLayoutType : IMessage<StageLayoutType>, IMessage, IEquatable<StageLayoutType>, IDeepCloneable<StageLayoutType>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum SlideTarget
				{
					[OriginalName("SLIDE_TARGET_NO_CHANGE")]
					NoChange,
					[OriginalName("SLIDE_TARGET_STAGE_ONLY")]
					StageOnly,
					[OriginalName("SLIDE_TARGET_ALL")]
					All
				}
			}

			private static readonly MessageParser<StageLayoutType> _parser = new MessageParser<StageLayoutType>(() => new StageLayoutType());

			private UnknownFieldSet _unknownFields;

			public const int StageScreenAssignmentsFieldNumber = 4;

			private static readonly FieldCodec<Stage.Types.ScreenAssignment> _repeated_stageScreenAssignments_codec = FieldCodec.ForMessage(34u, Pro.SerializationInterop.RVProtoData.Stage.Types.ScreenAssignment.Parser);

			private readonly RepeatedField<Stage.Types.ScreenAssignment> stageScreenAssignments_ = new RepeatedField<Stage.Types.ScreenAssignment>();

			public const int SlideTargetFieldNumber = 5;

			private Types.SlideTarget slideTarget_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StageLayoutType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[15];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Stage.Types.ScreenAssignment> StageScreenAssignments => stageScreenAssignments_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SlideTarget SlideTarget
			{
				get
				{
					return slideTarget_;
				}
				set
				{
					slideTarget_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StageLayoutType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StageLayoutType(StageLayoutType other)
				: this()
			{
				stageScreenAssignments_ = other.stageScreenAssignments_.Clone();
				slideTarget_ = other.slideTarget_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StageLayoutType Clone()
			{
				return new StageLayoutType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StageLayoutType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StageLayoutType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!stageScreenAssignments_.Equals(other.stageScreenAssignments_))
				{
					return false;
				}
				if (SlideTarget != other.SlideTarget)
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
				num ^= stageScreenAssignments_.GetHashCode();
				if (SlideTarget != 0)
				{
					num ^= SlideTarget.GetHashCode();
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
				stageScreenAssignments_.WriteTo(output, _repeated_stageScreenAssignments_codec);
				if (SlideTarget != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)SlideTarget);
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
				num += stageScreenAssignments_.CalculateSize(_repeated_stageScreenAssignments_codec);
				if (SlideTarget != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)SlideTarget);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(StageLayoutType other)
			{
				if (other != null)
				{
					stageScreenAssignments_.Add(other.stageScreenAssignments_);
					if (other.SlideTarget != 0)
					{
						SlideTarget = other.SlideTarget;
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
					case 34u:
						stageScreenAssignments_.AddEntriesFrom(input, _repeated_stageScreenAssignments_codec);
						break;
					case 40u:
						SlideTarget = (Types.SlideTarget)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideDestinationType : IMessage<SlideDestinationType>, IMessage, IEquatable<SlideDestinationType>, IDeepCloneable<SlideDestinationType>
		{
			private static readonly MessageParser<SlideDestinationType> _parser = new MessageParser<SlideDestinationType>(() => new SlideDestinationType());

			private UnknownFieldSet _unknownFields;

			public const int SlideTargetFieldNumber = 1;

			private StageLayoutType.Types.SlideTarget slideTarget_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideDestinationType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[16];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StageLayoutType.Types.SlideTarget SlideTarget
			{
				get
				{
					return slideTarget_;
				}
				set
				{
					slideTarget_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideDestinationType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideDestinationType(SlideDestinationType other)
				: this()
			{
				slideTarget_ = other.slideTarget_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideDestinationType Clone()
			{
				return new SlideDestinationType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SlideDestinationType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SlideDestinationType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (SlideTarget != other.SlideTarget)
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
				if (SlideTarget != 0)
				{
					num ^= SlideTarget.GetHashCode();
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
				if (SlideTarget != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)SlideTarget);
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
				if (SlideTarget != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)SlideTarget);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SlideDestinationType other)
			{
				if (other != null)
				{
					if (other.SlideTarget != 0)
					{
						SlideTarget = other.SlideTarget;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						SlideTarget = (StageLayoutType.Types.SlideTarget)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PropType : IMessage<PropType>, IMessage, IEquatable<PropType>, IDeepCloneable<PropType>
		{
			public enum TriggerTypeOneofCase
			{
				None = 0,
				Trigger = 4,
				Clear = 5
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class PropTrigger : IMessage<PropTrigger>, IMessage, IEquatable<PropTrigger>, IDeepCloneable<PropTrigger>
				{
					private static readonly MessageParser<PropTrigger> _parser = new MessageParser<PropTrigger>(() => new PropTrigger());

					private UnknownFieldSet _unknownFields;

					public const int AutoClearEnabledFieldNumber = 1;

					private bool autoClearEnabled_;

					public const int AutoClearFollowsPropDurationFieldNumber = 2;

					private bool autoClearFollowsPropDuration_;

					public const int AutoClearDurationFieldNumber = 3;

					private double autoClearDuration_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<PropTrigger> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PropType.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool AutoClearEnabled
					{
						get
						{
							return autoClearEnabled_;
						}
						set
						{
							autoClearEnabled_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool AutoClearFollowsPropDuration
					{
						get
						{
							return autoClearFollowsPropDuration_;
						}
						set
						{
							autoClearFollowsPropDuration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double AutoClearDuration
					{
						get
						{
							return autoClearDuration_;
						}
						set
						{
							autoClearDuration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropTrigger()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropTrigger(PropTrigger other)
						: this()
					{
						autoClearEnabled_ = other.autoClearEnabled_;
						autoClearFollowsPropDuration_ = other.autoClearFollowsPropDuration_;
						autoClearDuration_ = other.autoClearDuration_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropTrigger Clone()
					{
						return new PropTrigger(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as PropTrigger);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(PropTrigger other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (AutoClearEnabled != other.AutoClearEnabled)
						{
							return false;
						}
						if (AutoClearFollowsPropDuration != other.AutoClearFollowsPropDuration)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AutoClearDuration, other.AutoClearDuration))
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
						if (AutoClearEnabled)
						{
							num ^= AutoClearEnabled.GetHashCode();
						}
						if (AutoClearFollowsPropDuration)
						{
							num ^= AutoClearFollowsPropDuration.GetHashCode();
						}
						if (AutoClearDuration != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AutoClearDuration);
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
						if (AutoClearEnabled)
						{
							output.WriteRawTag(8);
							output.WriteBool(AutoClearEnabled);
						}
						if (AutoClearFollowsPropDuration)
						{
							output.WriteRawTag(16);
							output.WriteBool(AutoClearFollowsPropDuration);
						}
						if (AutoClearDuration != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(AutoClearDuration);
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
						if (AutoClearEnabled)
						{
							num += 2;
						}
						if (AutoClearFollowsPropDuration)
						{
							num += 2;
						}
						if (AutoClearDuration != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(PropTrigger other)
					{
						if (other != null)
						{
							if (other.AutoClearEnabled)
							{
								AutoClearEnabled = other.AutoClearEnabled;
							}
							if (other.AutoClearFollowsPropDuration)
							{
								AutoClearFollowsPropDuration = other.AutoClearFollowsPropDuration;
							}
							if (other.AutoClearDuration != 0.0)
							{
								AutoClearDuration = other.AutoClearDuration;
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
								AutoClearEnabled = input.ReadBool();
								break;
							case 16u:
								AutoClearFollowsPropDuration = input.ReadBool();
								break;
							case 25u:
								AutoClearDuration = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class PropClear : IMessage<PropClear>, IMessage, IEquatable<PropClear>, IDeepCloneable<PropClear>
				{
					private static readonly MessageParser<PropClear> _parser = new MessageParser<PropClear>(() => new PropClear());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<PropClear> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PropType.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropClear()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropClear(PropClear other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropClear Clone()
					{
						return new PropClear(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as PropClear);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(PropClear other)
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
					public void MergeFrom(PropClear other)
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

			private static readonly MessageParser<PropType> _parser = new MessageParser<PropType>(() => new PropType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 3;

			private CollectionElementType identification_;

			public const int TriggerFieldNumber = 4;

			public const int ClearFieldNumber = 5;

			private object triggerType_;

			private TriggerTypeOneofCase triggerTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PropType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[17];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.PropTrigger Trigger
			{
				get
				{
					if (triggerTypeCase_ != TriggerTypeOneofCase.Trigger)
					{
						return null;
					}
					return (Types.PropTrigger)triggerType_;
				}
				set
				{
					triggerType_ = value;
					triggerTypeCase_ = ((value != null) ? TriggerTypeOneofCase.Trigger : TriggerTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.PropClear Clear
			{
				get
				{
					if (triggerTypeCase_ != TriggerTypeOneofCase.Clear)
					{
						return null;
					}
					return (Types.PropClear)triggerType_;
				}
				set
				{
					triggerType_ = value;
					triggerTypeCase_ = ((value != null) ? TriggerTypeOneofCase.Clear : TriggerTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerTypeOneofCase TriggerTypeCase => triggerTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropType(PropType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				switch (other.TriggerTypeCase)
				{
				case TriggerTypeOneofCase.Trigger:
					Trigger = other.Trigger.Clone();
					break;
				case TriggerTypeOneofCase.Clear:
					Clear = other.Clear.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropType Clone()
			{
				return new PropType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearTriggerType()
			{
				triggerTypeCase_ = TriggerTypeOneofCase.None;
				triggerType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PropType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PropType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
				{
					return false;
				}
				if (!object.Equals(Trigger, other.Trigger))
				{
					return false;
				}
				if (!object.Equals(Clear, other.Clear))
				{
					return false;
				}
				if (TriggerTypeCase != other.TriggerTypeCase)
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Trigger)
				{
					num ^= Trigger.GetHashCode();
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Clear)
				{
					num ^= Clear.GetHashCode();
				}
				num ^= (int)triggerTypeCase_;
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
				if (identification_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Identification);
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Trigger)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Trigger);
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Clear)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Clear);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Trigger)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
				}
				if (triggerTypeCase_ == TriggerTypeOneofCase.Clear)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Clear);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PropType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
				}
				switch (other.TriggerTypeCase)
				{
				case TriggerTypeOneofCase.Trigger:
					if (Trigger == null)
					{
						Trigger = new Types.PropTrigger();
					}
					Trigger.MergeFrom(other.Trigger);
					break;
				case TriggerTypeOneofCase.Clear:
					if (Clear == null)
					{
						Clear = new Types.PropClear();
					}
					Clear.MergeFrom(other.Clear);
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
					case 26u:
						if (identification_ == null)
						{
							Identification = new CollectionElementType();
						}
						input.ReadMessage(Identification);
						break;
					case 34u:
					{
						Types.PropTrigger propTrigger = new Types.PropTrigger();
						if (triggerTypeCase_ == TriggerTypeOneofCase.Trigger)
						{
							propTrigger.MergeFrom(Trigger);
						}
						input.ReadMessage(propTrigger);
						Trigger = propTrigger;
						break;
					}
					case 42u:
					{
						Types.PropClear propClear = new Types.PropClear();
						if (triggerTypeCase_ == TriggerTypeOneofCase.Clear)
						{
							propClear.MergeFrom(Clear);
						}
						input.ReadMessage(propClear);
						Clear = propClear;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MaskType : IMessage<MaskType>, IMessage, IEquatable<MaskType>, IDeepCloneable<MaskType>
		{
			private static readonly MessageParser<MaskType> _parser = new MessageParser<MaskType>(() => new MaskType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 3;

			private CollectionElementType identification_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MaskType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[18];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MaskType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MaskType(MaskType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MaskType Clone()
			{
				return new MaskType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MaskType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MaskType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Identification);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MaskType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
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
					if (num != 26)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					input.ReadMessage(Identification);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MessageType : IMessage<MessageType>, IMessage, IEquatable<MessageType>, IDeepCloneable<MessageType>
		{
			private static readonly MessageParser<MessageType> _parser = new MessageParser<MessageType>(() => new MessageType());

			private UnknownFieldSet _unknownFields;

			public const int MessageIdentificatonFieldNumber = 1;

			private CollectionElementType messageIdentificaton_;

			public const int ContentFieldNumber = 3;

			private static readonly FieldCodec<Message.Types.TokenValue> _repeated_content_codec = FieldCodec.ForMessage(26u, Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Parser);

			private readonly RepeatedField<Message.Types.TokenValue> content_ = new RepeatedField<Message.Types.TokenValue>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MessageType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[19];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType MessageIdentificaton
			{
				get
				{
					return messageIdentificaton_;
				}
				set
				{
					messageIdentificaton_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Message.Types.TokenValue> Content => content_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MessageType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MessageType(MessageType other)
				: this()
			{
				messageIdentificaton_ = ((other.messageIdentificaton_ != null) ? other.messageIdentificaton_.Clone() : null);
				content_ = other.content_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MessageType Clone()
			{
				return new MessageType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MessageType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MessageType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(MessageIdentificaton, other.MessageIdentificaton))
				{
					return false;
				}
				if (!content_.Equals(other.content_))
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
				if (messageIdentificaton_ != null)
				{
					num ^= MessageIdentificaton.GetHashCode();
				}
				num ^= content_.GetHashCode();
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
				if (messageIdentificaton_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MessageIdentificaton);
				}
				content_.WriteTo(output, _repeated_content_codec);
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
				if (messageIdentificaton_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MessageIdentificaton);
				}
				num += content_.CalculateSize(_repeated_content_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MessageType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.messageIdentificaton_ != null)
				{
					if (messageIdentificaton_ == null)
					{
						MessageIdentificaton = new CollectionElementType();
					}
					MessageIdentificaton.MergeFrom(other.MessageIdentificaton);
				}
				content_.Add(other.content_);
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
						if (messageIdentificaton_ == null)
						{
							MessageIdentificaton = new CollectionElementType();
						}
						input.ReadMessage(MessageIdentificaton);
						break;
					case 26u:
						content_.AddEntriesFrom(input, _repeated_content_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CommunicationType : IMessage<CommunicationType>, IMessage, IEquatable<CommunicationType>, IDeepCloneable<CommunicationType>
		{
			public enum CommandTypeDataOneofCase
			{
				None = 0,
				MidiCommand = 5,
				GlobalCacheCommand = 6,
				Gvg100Command = 7,
				SonyBVSCommand = 8
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Command : IMessage<Command>, IMessage, IEquatable<Command>, IDeepCloneable<Command>
				{
					private static readonly MessageParser<Command> _parser = new MessageParser<Command>(() => new Command());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					public const int ValueFieldNumber = 2;

					private string value_ = "";

					public const int ReplacementRangeFieldNumber = 3;

					private IntRange replacementRange_;

					public const int PossibleValuesFieldNumber = 4;

					private static readonly FieldCodec<string> _repeated_possibleValues_codec = FieldCodec.ForString(34u);

					private readonly RepeatedField<string> possibleValues_ = new RepeatedField<string>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Command> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CommunicationType.Descriptor.NestedTypes[0];

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
					public string Value
					{
						get
						{
							return value_;
						}
						set
						{
							value_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IntRange ReplacementRange
					{
						get
						{
							return replacementRange_;
						}
						set
						{
							replacementRange_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<string> PossibleValues => possibleValues_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Command()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Command(Command other)
						: this()
					{
						name_ = other.name_;
						value_ = other.value_;
						replacementRange_ = ((other.replacementRange_ != null) ? other.replacementRange_.Clone() : null);
						possibleValues_ = other.possibleValues_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Command Clone()
					{
						return new Command(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Command);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Command other)
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
						if (Value != other.Value)
						{
							return false;
						}
						if (!object.Equals(ReplacementRange, other.ReplacementRange))
						{
							return false;
						}
						if (!possibleValues_.Equals(other.possibleValues_))
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
						if (Value.Length != 0)
						{
							num ^= Value.GetHashCode();
						}
						if (replacementRange_ != null)
						{
							num ^= ReplacementRange.GetHashCode();
						}
						num ^= possibleValues_.GetHashCode();
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
						if (Value.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Value);
						}
						if (replacementRange_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(ReplacementRange);
						}
						possibleValues_.WriteTo(output, _repeated_possibleValues_codec);
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
						if (Value.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Value);
						}
						if (replacementRange_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ReplacementRange);
						}
						num += possibleValues_.CalculateSize(_repeated_possibleValues_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Command other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						if (other.Value.Length != 0)
						{
							Value = other.Value;
						}
						if (other.replacementRange_ != null)
						{
							if (replacementRange_ == null)
							{
								ReplacementRange = new IntRange();
							}
							ReplacementRange.MergeFrom(other.ReplacementRange);
						}
						possibleValues_.Add(other.possibleValues_);
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
								Name = input.ReadString();
								break;
							case 18u:
								Value = input.ReadString();
								break;
							case 26u:
								if (replacementRange_ == null)
								{
									ReplacementRange = new IntRange();
								}
								input.ReadMessage(ReplacementRange);
								break;
							case 34u:
								possibleValues_.AddEntriesFrom(input, _repeated_possibleValues_codec);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class MIDICommand : IMessage<MIDICommand>, IMessage, IEquatable<MIDICommand>, IDeepCloneable<MIDICommand>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum State
						{
							[OriginalName("STATE_ON")]
							On,
							[OriginalName("STATE_OFF")]
							Off
						}
					}

					private static readonly MessageParser<MIDICommand> _parser = new MessageParser<MIDICommand>(() => new MIDICommand());

					private UnknownFieldSet _unknownFields;

					public const int StateFieldNumber = 1;

					private Types.State state_;

					public const int ChannelFieldNumber = 2;

					private uint channel_;

					public const int NoteFieldNumber = 3;

					private uint note_;

					public const int IntensityFieldNumber = 4;

					private uint intensity_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MIDICommand> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CommunicationType.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.State State
					{
						get
						{
							return state_;
						}
						set
						{
							state_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Channel
					{
						get
						{
							return channel_;
						}
						set
						{
							channel_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Note
					{
						get
						{
							return note_;
						}
						set
						{
							note_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Intensity
					{
						get
						{
							return intensity_;
						}
						set
						{
							intensity_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MIDICommand()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MIDICommand(MIDICommand other)
						: this()
					{
						state_ = other.state_;
						channel_ = other.channel_;
						note_ = other.note_;
						intensity_ = other.intensity_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MIDICommand Clone()
					{
						return new MIDICommand(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as MIDICommand);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(MIDICommand other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (State != other.State)
						{
							return false;
						}
						if (Channel != other.Channel)
						{
							return false;
						}
						if (Note != other.Note)
						{
							return false;
						}
						if (Intensity != other.Intensity)
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
						if (State != 0)
						{
							num ^= State.GetHashCode();
						}
						if (Channel != 0)
						{
							num ^= Channel.GetHashCode();
						}
						if (Note != 0)
						{
							num ^= Note.GetHashCode();
						}
						if (Intensity != 0)
						{
							num ^= Intensity.GetHashCode();
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
						if (State != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)State);
						}
						if (Channel != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(Channel);
						}
						if (Note != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(Note);
						}
						if (Intensity != 0)
						{
							output.WriteRawTag(32);
							output.WriteUInt32(Intensity);
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
						if (State != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)State);
						}
						if (Channel != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Channel);
						}
						if (Note != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Note);
						}
						if (Intensity != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Intensity);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(MIDICommand other)
					{
						if (other != null)
						{
							if (other.State != 0)
							{
								State = other.State;
							}
							if (other.Channel != 0)
							{
								Channel = other.Channel;
							}
							if (other.Note != 0)
							{
								Note = other.Note;
							}
							if (other.Intensity != 0)
							{
								Intensity = other.Intensity;
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
								State = (Types.State)input.ReadEnum();
								break;
							case 16u:
								Channel = input.ReadUInt32();
								break;
							case 24u:
								Note = input.ReadUInt32();
								break;
							case 32u:
								Intensity = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GlobalCacheCommand : IMessage<GlobalCacheCommand>, IMessage, IEquatable<GlobalCacheCommand>, IDeepCloneable<GlobalCacheCommand>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum CommandAction
						{
							[OriginalName("COMMAND_ACTION_ON")]
							On,
							[OriginalName("COMMAND_ACTION_OFF")]
							Off,
							[OriginalName("COMMAND_ACTION_ON_OFF_WITH_INTERVAL")]
							OnOffWithInterval,
							[OriginalName("COMMAND_ACTION_OFF_ON_WITH_INTERVAL")]
							OffOnWithInterval
						}
					}

					private static readonly MessageParser<GlobalCacheCommand> _parser = new MessageParser<GlobalCacheCommand>(() => new GlobalCacheCommand());

					private UnknownFieldSet _unknownFields;

					public const int CommandActionFieldNumber = 1;

					private Types.CommandAction commandAction_;

					public const int OutputFieldNumber = 2;

					private uint output_;

					public const int IntervalFieldNumber = 3;

					private uint interval_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GlobalCacheCommand> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CommunicationType.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CommandAction CommandAction
					{
						get
						{
							return commandAction_;
						}
						set
						{
							commandAction_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Output
					{
						get
						{
							return output_;
						}
						set
						{
							output_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Interval
					{
						get
						{
							return interval_;
						}
						set
						{
							interval_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GlobalCacheCommand()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GlobalCacheCommand(GlobalCacheCommand other)
						: this()
					{
						commandAction_ = other.commandAction_;
						output_ = other.output_;
						interval_ = other.interval_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GlobalCacheCommand Clone()
					{
						return new GlobalCacheCommand(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GlobalCacheCommand);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GlobalCacheCommand other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (CommandAction != other.CommandAction)
						{
							return false;
						}
						if (Output != other.Output)
						{
							return false;
						}
						if (Interval != other.Interval)
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
						if (CommandAction != 0)
						{
							num ^= CommandAction.GetHashCode();
						}
						if (Output != 0)
						{
							num ^= Output.GetHashCode();
						}
						if (Interval != 0)
						{
							num ^= Interval.GetHashCode();
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
						if (CommandAction != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)CommandAction);
						}
						if (Output != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(Output);
						}
						if (Interval != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(Interval);
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
						if (CommandAction != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)CommandAction);
						}
						if (Output != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Output);
						}
						if (Interval != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Interval);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GlobalCacheCommand other)
					{
						if (other != null)
						{
							if (other.CommandAction != 0)
							{
								CommandAction = other.CommandAction;
							}
							if (other.Output != 0)
							{
								Output = other.Output;
							}
							if (other.Interval != 0)
							{
								Interval = other.Interval;
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
								CommandAction = (Types.CommandAction)input.ReadEnum();
								break;
							case 16u:
								Output = input.ReadUInt32();
								break;
							case 24u:
								Interval = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GVG100Command : IMessage<GVG100Command>, IMessage, IEquatable<GVG100Command>, IDeepCloneable<GVG100Command>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum CommandAction
						{
							[OriginalName("COMMAND_ACTION_FADE_TO_BLACK")]
							FadeToBlack,
							[OriginalName("COMMAND_ACTION_DSK_TOGGLE")]
							DskToggle
						}
					}

					private static readonly MessageParser<GVG100Command> _parser = new MessageParser<GVG100Command>(() => new GVG100Command());

					private UnknownFieldSet _unknownFields;

					public const int CommandActionFieldNumber = 1;

					private Types.CommandAction commandAction_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GVG100Command> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CommunicationType.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CommandAction CommandAction
					{
						get
						{
							return commandAction_;
						}
						set
						{
							commandAction_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GVG100Command()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GVG100Command(GVG100Command other)
						: this()
					{
						commandAction_ = other.commandAction_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GVG100Command Clone()
					{
						return new GVG100Command(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GVG100Command);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GVG100Command other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (CommandAction != other.CommandAction)
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
						if (CommandAction != 0)
						{
							num ^= CommandAction.GetHashCode();
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
						if (CommandAction != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)CommandAction);
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
						if (CommandAction != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)CommandAction);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GVG100Command other)
					{
						if (other != null)
						{
							if (other.CommandAction != 0)
							{
								CommandAction = other.CommandAction;
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
							if (num != 8)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								CommandAction = (Types.CommandAction)input.ReadEnum();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SonyBVSCommand : IMessage<SonyBVSCommand>, IMessage, IEquatable<SonyBVSCommand>, IDeepCloneable<SonyBVSCommand>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum CommandAction
						{
							[OriginalName("COMMAND_ACTION_FADE_TO_BLACK")]
							FadeToBlack,
							[OriginalName("COMMAND_ACTION_KEY_ON")]
							KeyOn,
							[OriginalName("COMMAND_ACTION_KEY_OFF")]
							KeyOff,
							[OriginalName("COMMAND_ACTION_DSK_ON")]
							DskOn,
							[OriginalName("COMMAND_ACTION_DSK_OFF")]
							DskOff
						}
					}

					private static readonly MessageParser<SonyBVSCommand> _parser = new MessageParser<SonyBVSCommand>(() => new SonyBVSCommand());

					private UnknownFieldSet _unknownFields;

					public const int CommandActionFieldNumber = 1;

					private Types.CommandAction commandAction_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SonyBVSCommand> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CommunicationType.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CommandAction CommandAction
					{
						get
						{
							return commandAction_;
						}
						set
						{
							commandAction_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SonyBVSCommand()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SonyBVSCommand(SonyBVSCommand other)
						: this()
					{
						commandAction_ = other.commandAction_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SonyBVSCommand Clone()
					{
						return new SonyBVSCommand(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SonyBVSCommand);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SonyBVSCommand other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (CommandAction != other.CommandAction)
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
						if (CommandAction != 0)
						{
							num ^= CommandAction.GetHashCode();
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
						if (CommandAction != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)CommandAction);
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
						if (CommandAction != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)CommandAction);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SonyBVSCommand other)
					{
						if (other != null)
						{
							if (other.CommandAction != 0)
							{
								CommandAction = other.CommandAction;
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
							if (num != 8)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								CommandAction = (Types.CommandAction)input.ReadEnum();
							}
						}
					}
				}
			}

			private static readonly MessageParser<CommunicationType> _parser = new MessageParser<CommunicationType>(() => new CommunicationType());

			private UnknownFieldSet _unknownFields;

			public const int DeviceIdentificationFieldNumber = 1;

			private CollectionElementType deviceIdentification_;

			public const int FormatFieldNumber = 2;

			private string format_ = "";

			public const int DescriptionFieldNumber = 3;

			private string description_ = "";

			public const int CommandsFieldNumber = 4;

			private static readonly FieldCodec<Types.Command> _repeated_commands_codec = FieldCodec.ForMessage(34u, Types.Command.Parser);

			private readonly RepeatedField<Types.Command> commands_ = new RepeatedField<Types.Command>();

			public const int MidiCommandFieldNumber = 5;

			public const int GlobalCacheCommandFieldNumber = 6;

			public const int Gvg100CommandFieldNumber = 7;

			public const int SonyBVSCommandFieldNumber = 8;

			private object commandTypeData_;

			private CommandTypeDataOneofCase commandTypeDataCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CommunicationType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[20];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType DeviceIdentification
			{
				get
				{
					return deviceIdentification_;
				}
				set
				{
					deviceIdentification_ = value;
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
			public string Description
			{
				get
				{
					return description_;
				}
				set
				{
					description_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Command> Commands => commands_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.MIDICommand MidiCommand
			{
				get
				{
					if (commandTypeDataCase_ != CommandTypeDataOneofCase.MidiCommand)
					{
						return null;
					}
					return (Types.MIDICommand)commandTypeData_;
				}
				set
				{
					commandTypeData_ = value;
					commandTypeDataCase_ = ((value != null) ? CommandTypeDataOneofCase.MidiCommand : CommandTypeDataOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GlobalCacheCommand GlobalCacheCommand
			{
				get
				{
					if (commandTypeDataCase_ != CommandTypeDataOneofCase.GlobalCacheCommand)
					{
						return null;
					}
					return (Types.GlobalCacheCommand)commandTypeData_;
				}
				set
				{
					commandTypeData_ = value;
					commandTypeDataCase_ = ((value != null) ? CommandTypeDataOneofCase.GlobalCacheCommand : CommandTypeDataOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GVG100Command Gvg100Command
			{
				get
				{
					if (commandTypeDataCase_ != CommandTypeDataOneofCase.Gvg100Command)
					{
						return null;
					}
					return (Types.GVG100Command)commandTypeData_;
				}
				set
				{
					commandTypeData_ = value;
					commandTypeDataCase_ = ((value != null) ? CommandTypeDataOneofCase.Gvg100Command : CommandTypeDataOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SonyBVSCommand SonyBVSCommand
			{
				get
				{
					if (commandTypeDataCase_ != CommandTypeDataOneofCase.SonyBVSCommand)
					{
						return null;
					}
					return (Types.SonyBVSCommand)commandTypeData_;
				}
				set
				{
					commandTypeData_ = value;
					commandTypeDataCase_ = ((value != null) ? CommandTypeDataOneofCase.SonyBVSCommand : CommandTypeDataOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommandTypeDataOneofCase CommandTypeDataCase => commandTypeDataCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommunicationType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommunicationType(CommunicationType other)
				: this()
			{
				deviceIdentification_ = ((other.deviceIdentification_ != null) ? other.deviceIdentification_.Clone() : null);
				format_ = other.format_;
				description_ = other.description_;
				commands_ = other.commands_.Clone();
				switch (other.CommandTypeDataCase)
				{
				case CommandTypeDataOneofCase.MidiCommand:
					MidiCommand = other.MidiCommand.Clone();
					break;
				case CommandTypeDataOneofCase.GlobalCacheCommand:
					GlobalCacheCommand = other.GlobalCacheCommand.Clone();
					break;
				case CommandTypeDataOneofCase.Gvg100Command:
					Gvg100Command = other.Gvg100Command.Clone();
					break;
				case CommandTypeDataOneofCase.SonyBVSCommand:
					SonyBVSCommand = other.SonyBVSCommand.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommunicationType Clone()
			{
				return new CommunicationType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearCommandTypeData()
			{
				commandTypeDataCase_ = CommandTypeDataOneofCase.None;
				commandTypeData_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CommunicationType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CommunicationType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(DeviceIdentification, other.DeviceIdentification))
				{
					return false;
				}
				if (Format != other.Format)
				{
					return false;
				}
				if (Description != other.Description)
				{
					return false;
				}
				if (!commands_.Equals(other.commands_))
				{
					return false;
				}
				if (!object.Equals(MidiCommand, other.MidiCommand))
				{
					return false;
				}
				if (!object.Equals(GlobalCacheCommand, other.GlobalCacheCommand))
				{
					return false;
				}
				if (!object.Equals(Gvg100Command, other.Gvg100Command))
				{
					return false;
				}
				if (!object.Equals(SonyBVSCommand, other.SonyBVSCommand))
				{
					return false;
				}
				if (CommandTypeDataCase != other.CommandTypeDataCase)
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
				if (deviceIdentification_ != null)
				{
					num ^= DeviceIdentification.GetHashCode();
				}
				if (Format.Length != 0)
				{
					num ^= Format.GetHashCode();
				}
				if (Description.Length != 0)
				{
					num ^= Description.GetHashCode();
				}
				num ^= commands_.GetHashCode();
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.MidiCommand)
				{
					num ^= MidiCommand.GetHashCode();
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.GlobalCacheCommand)
				{
					num ^= GlobalCacheCommand.GetHashCode();
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.Gvg100Command)
				{
					num ^= Gvg100Command.GetHashCode();
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.SonyBVSCommand)
				{
					num ^= SonyBVSCommand.GetHashCode();
				}
				num ^= (int)commandTypeDataCase_;
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
				if (deviceIdentification_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(DeviceIdentification);
				}
				if (Format.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Format);
				}
				if (Description.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Description);
				}
				commands_.WriteTo(output, _repeated_commands_codec);
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.MidiCommand)
				{
					output.WriteRawTag(42);
					output.WriteMessage(MidiCommand);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.GlobalCacheCommand)
				{
					output.WriteRawTag(50);
					output.WriteMessage(GlobalCacheCommand);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.Gvg100Command)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Gvg100Command);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.SonyBVSCommand)
				{
					output.WriteRawTag(66);
					output.WriteMessage(SonyBVSCommand);
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
				if (deviceIdentification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(DeviceIdentification);
				}
				if (Format.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Format);
				}
				if (Description.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Description);
				}
				num += commands_.CalculateSize(_repeated_commands_codec);
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.MidiCommand)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MidiCommand);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.GlobalCacheCommand)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GlobalCacheCommand);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.Gvg100Command)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Gvg100Command);
				}
				if (commandTypeDataCase_ == CommandTypeDataOneofCase.SonyBVSCommand)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SonyBVSCommand);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CommunicationType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.deviceIdentification_ != null)
				{
					if (deviceIdentification_ == null)
					{
						DeviceIdentification = new CollectionElementType();
					}
					DeviceIdentification.MergeFrom(other.DeviceIdentification);
				}
				if (other.Format.Length != 0)
				{
					Format = other.Format;
				}
				if (other.Description.Length != 0)
				{
					Description = other.Description;
				}
				commands_.Add(other.commands_);
				switch (other.CommandTypeDataCase)
				{
				case CommandTypeDataOneofCase.MidiCommand:
					if (MidiCommand == null)
					{
						MidiCommand = new Types.MIDICommand();
					}
					MidiCommand.MergeFrom(other.MidiCommand);
					break;
				case CommandTypeDataOneofCase.GlobalCacheCommand:
					if (GlobalCacheCommand == null)
					{
						GlobalCacheCommand = new Types.GlobalCacheCommand();
					}
					GlobalCacheCommand.MergeFrom(other.GlobalCacheCommand);
					break;
				case CommandTypeDataOneofCase.Gvg100Command:
					if (Gvg100Command == null)
					{
						Gvg100Command = new Types.GVG100Command();
					}
					Gvg100Command.MergeFrom(other.Gvg100Command);
					break;
				case CommandTypeDataOneofCase.SonyBVSCommand:
					if (SonyBVSCommand == null)
					{
						SonyBVSCommand = new Types.SonyBVSCommand();
					}
					SonyBVSCommand.MergeFrom(other.SonyBVSCommand);
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
						if (deviceIdentification_ == null)
						{
							DeviceIdentification = new CollectionElementType();
						}
						input.ReadMessage(DeviceIdentification);
						break;
					case 18u:
						Format = input.ReadString();
						break;
					case 26u:
						Description = input.ReadString();
						break;
					case 34u:
						commands_.AddEntriesFrom(input, _repeated_commands_codec);
						break;
					case 42u:
					{
						Types.MIDICommand mIDICommand = new Types.MIDICommand();
						if (commandTypeDataCase_ == CommandTypeDataOneofCase.MidiCommand)
						{
							mIDICommand.MergeFrom(MidiCommand);
						}
						input.ReadMessage(mIDICommand);
						MidiCommand = mIDICommand;
						break;
					}
					case 50u:
					{
						Types.GlobalCacheCommand globalCacheCommand = new Types.GlobalCacheCommand();
						if (commandTypeDataCase_ == CommandTypeDataOneofCase.GlobalCacheCommand)
						{
							globalCacheCommand.MergeFrom(GlobalCacheCommand);
						}
						input.ReadMessage(globalCacheCommand);
						GlobalCacheCommand = globalCacheCommand;
						break;
					}
					case 58u:
					{
						Types.GVG100Command gVG100Command = new Types.GVG100Command();
						if (commandTypeDataCase_ == CommandTypeDataOneofCase.Gvg100Command)
						{
							gVG100Command.MergeFrom(Gvg100Command);
						}
						input.ReadMessage(gVG100Command);
						Gvg100Command = gVG100Command;
						break;
					}
					case 66u:
					{
						Types.SonyBVSCommand sonyBVSCommand = new Types.SonyBVSCommand();
						if (commandTypeDataCase_ == CommandTypeDataOneofCase.SonyBVSCommand)
						{
							sonyBVSCommand.MergeFrom(SonyBVSCommand);
						}
						input.ReadMessage(sonyBVSCommand);
						SonyBVSCommand = sonyBVSCommand;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MultiScreenType : IMessage<MultiScreenType>, IMessage, IEquatable<MultiScreenType>, IDeepCloneable<MultiScreenType>
		{
			private static readonly MessageParser<MultiScreenType> _parser = new MessageParser<MultiScreenType>(() => new MultiScreenType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 3;

			private CollectionElementType identification_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MultiScreenType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[21];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiScreenType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiScreenType(MultiScreenType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiScreenType Clone()
			{
				return new MultiScreenType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MultiScreenType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MultiScreenType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Identification);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MultiScreenType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
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
					if (num != 26)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					input.ReadMessage(Identification);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DocumentType : IMessage<DocumentType>, IMessage, IEquatable<DocumentType>, IDeepCloneable<DocumentType>
		{
			private static readonly MessageParser<DocumentType> _parser = new MessageParser<DocumentType>(() => new DocumentType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 1;

			private CollectionElementType identification_;

			public const int SelectedArrangementFieldNumber = 2;

			private UUID selectedArrangement_;

			public const int ContentDestinationFieldNumber = 3;

			private ContentDestination contentDestination_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DocumentType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[22];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID SelectedArrangement
			{
				get
				{
					return selectedArrangement_;
				}
				set
				{
					selectedArrangement_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ContentDestination ContentDestination
			{
				get
				{
					return contentDestination_;
				}
				set
				{
					contentDestination_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentType(DocumentType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				selectedArrangement_ = ((other.selectedArrangement_ != null) ? other.selectedArrangement_.Clone() : null);
				contentDestination_ = other.contentDestination_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentType Clone()
			{
				return new DocumentType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DocumentType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DocumentType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
				{
					return false;
				}
				if (!object.Equals(SelectedArrangement, other.SelectedArrangement))
				{
					return false;
				}
				if (ContentDestination != other.ContentDestination)
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
				}
				if (selectedArrangement_ != null)
				{
					num ^= SelectedArrangement.GetHashCode();
				}
				if (ContentDestination != 0)
				{
					num ^= ContentDestination.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Identification);
				}
				if (selectedArrangement_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(SelectedArrangement);
				}
				if (ContentDestination != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)ContentDestination);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (selectedArrangement_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SelectedArrangement);
				}
				if (ContentDestination != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DocumentType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
				}
				if (other.selectedArrangement_ != null)
				{
					if (selectedArrangement_ == null)
					{
						SelectedArrangement = new UUID();
					}
					SelectedArrangement.MergeFrom(other.SelectedArrangement);
				}
				if (other.ContentDestination != 0)
				{
					ContentDestination = other.ContentDestination;
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
						if (identification_ == null)
						{
							Identification = new CollectionElementType();
						}
						input.ReadMessage(Identification);
						break;
					case 18u:
						if (selectedArrangement_ == null)
						{
							SelectedArrangement = new UUID();
						}
						input.ReadMessage(SelectedArrangement);
						break;
					case 24u:
						ContentDestination = (ContentDestination)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ExternalPresentationType : IMessage<ExternalPresentationType>, IMessage, IEquatable<ExternalPresentationType>, IDeepCloneable<ExternalPresentationType>
		{
			private static readonly MessageParser<ExternalPresentationType> _parser = new MessageParser<ExternalPresentationType>(() => new ExternalPresentationType());

			private UnknownFieldSet _unknownFields;

			public const int UrlFieldNumber = 1;

			private URL url_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ExternalPresentationType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[23];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public ExternalPresentationType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ExternalPresentationType(ExternalPresentationType other)
				: this()
			{
				url_ = ((other.url_ != null) ? other.url_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ExternalPresentationType Clone()
			{
				return new ExternalPresentationType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ExternalPresentationType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ExternalPresentationType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
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
				if (url_ != null)
				{
					output.WriteRawTag(10);
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
			public void MergeFrom(ExternalPresentationType other)
			{
				if (other == null)
				{
					return;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (url_ == null)
					{
						Url = new URL();
					}
					input.ReadMessage(Url);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AudienceLookType : IMessage<AudienceLookType>, IMessage, IEquatable<AudienceLookType>, IDeepCloneable<AudienceLookType>
		{
			private static readonly MessageParser<AudienceLookType> _parser = new MessageParser<AudienceLookType>(() => new AudienceLookType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 1;

			private CollectionElementType identification_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudienceLookType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[24];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudienceLookType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudienceLookType(AudienceLookType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudienceLookType Clone()
			{
				return new AudienceLookType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudienceLookType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudienceLookType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Identification);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AudienceLookType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
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
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					input.ReadMessage(Identification);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AudioInputType : IMessage<AudioInputType>, IMessage, IEquatable<AudioInputType>, IDeepCloneable<AudioInputType>
		{
			private static readonly MessageParser<AudioInputType> _parser = new MessageParser<AudioInputType>(() => new AudioInputType());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private int index_;

			public const int OverrideModeFieldNumber = 2;

			private bool overrideMode_;

			public const int BehaviorModeFieldNumber = 3;

			private AudioInput.Types.BehaviorMode behaviorMode_;

			public const int OverrideVolumeFieldNumber = 4;

			private bool overrideVolume_;

			public const int VolumeFieldNumber = 5;

			private double volume_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioInputType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[25];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Index
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
			public bool OverrideMode
			{
				get
				{
					return overrideMode_;
				}
				set
				{
					overrideMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioInput.Types.BehaviorMode BehaviorMode
			{
				get
				{
					return behaviorMode_;
				}
				set
				{
					behaviorMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool OverrideVolume
			{
				get
				{
					return overrideVolume_;
				}
				set
				{
					overrideVolume_ = value;
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
			public AudioInputType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioInputType(AudioInputType other)
				: this()
			{
				index_ = other.index_;
				overrideMode_ = other.overrideMode_;
				behaviorMode_ = ((other.behaviorMode_ != null) ? other.behaviorMode_.Clone() : null);
				overrideVolume_ = other.overrideVolume_;
				volume_ = other.volume_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioInputType Clone()
			{
				return new AudioInputType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioInputType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioInputType other)
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
				if (OverrideMode != other.OverrideMode)
				{
					return false;
				}
				if (!object.Equals(BehaviorMode, other.BehaviorMode))
				{
					return false;
				}
				if (OverrideVolume != other.OverrideVolume)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Volume, other.Volume))
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
				if (OverrideMode)
				{
					num ^= OverrideMode.GetHashCode();
				}
				if (behaviorMode_ != null)
				{
					num ^= BehaviorMode.GetHashCode();
				}
				if (OverrideVolume)
				{
					num ^= OverrideVolume.GetHashCode();
				}
				if (Volume != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Volume);
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
				if (Index != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Index);
				}
				if (OverrideMode)
				{
					output.WriteRawTag(16);
					output.WriteBool(OverrideMode);
				}
				if (behaviorMode_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(BehaviorMode);
				}
				if (OverrideVolume)
				{
					output.WriteRawTag(32);
					output.WriteBool(OverrideVolume);
				}
				if (Volume != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(Volume);
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
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Index);
				}
				if (OverrideMode)
				{
					num += 2;
				}
				if (behaviorMode_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BehaviorMode);
				}
				if (OverrideVolume)
				{
					num += 2;
				}
				if (Volume != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AudioInputType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Index != 0)
				{
					Index = other.Index;
				}
				if (other.OverrideMode)
				{
					OverrideMode = other.OverrideMode;
				}
				if (other.behaviorMode_ != null)
				{
					if (behaviorMode_ == null)
					{
						BehaviorMode = new AudioInput.Types.BehaviorMode();
					}
					BehaviorMode.MergeFrom(other.BehaviorMode);
				}
				if (other.OverrideVolume)
				{
					OverrideVolume = other.OverrideVolume;
				}
				if (other.Volume != 0.0)
				{
					Volume = other.Volume;
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
						Index = input.ReadInt32();
						break;
					case 16u:
						OverrideMode = input.ReadBool();
						break;
					case 26u:
						if (behaviorMode_ == null)
						{
							BehaviorMode = new AudioInput.Types.BehaviorMode();
						}
						input.ReadMessage(BehaviorMode);
						break;
					case 32u:
						OverrideVolume = input.ReadBool();
						break;
					case 41u:
						Volume = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MacroType : IMessage<MacroType>, IMessage, IEquatable<MacroType>, IDeepCloneable<MacroType>
		{
			private static readonly MessageParser<MacroType> _parser = new MessageParser<MacroType>(() => new MacroType());

			private UnknownFieldSet _unknownFields;

			public const int IdentificationFieldNumber = 1;

			private CollectionElementType identification_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[26];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Identification
			{
				get
				{
					return identification_;
				}
				set
				{
					identification_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroType(MacroType other)
				: this()
			{
				identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroType Clone()
			{
				return new MacroType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MacroType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MacroType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Identification, other.Identification))
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
				if (identification_ != null)
				{
					num ^= Identification.GetHashCode();
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
				if (identification_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Identification);
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
				if (identification_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MacroType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.identification_ != null)
				{
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					Identification.MergeFrom(other.Identification);
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
					if (identification_ == null)
					{
						Identification = new CollectionElementType();
					}
					input.ReadMessage(Identification);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CaptureType : IMessage<CaptureType>, IMessage, IEquatable<CaptureType>, IDeepCloneable<CaptureType>
		{
			public enum CaptureActionOneofCase
			{
				None,
				Start,
				Stop
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class CaptureStart : IMessage<CaptureStart>, IMessage, IEquatable<CaptureStart>, IDeepCloneable<CaptureStart>
				{
					private static readonly MessageParser<CaptureStart> _parser = new MessageParser<CaptureStart>(() => new CaptureStart());

					private UnknownFieldSet _unknownFields;

					public const int PresetIdentificationFieldNumber = 1;

					private CollectionElementType presetIdentification_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<CaptureStart> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CaptureType.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CollectionElementType PresetIdentification
					{
						get
						{
							return presetIdentification_;
						}
						set
						{
							presetIdentification_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStart()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStart(CaptureStart other)
						: this()
					{
						presetIdentification_ = ((other.presetIdentification_ != null) ? other.presetIdentification_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStart Clone()
					{
						return new CaptureStart(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as CaptureStart);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(CaptureStart other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(PresetIdentification, other.PresetIdentification))
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
						if (presetIdentification_ != null)
						{
							num ^= PresetIdentification.GetHashCode();
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
						if (presetIdentification_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(PresetIdentification);
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
						if (presetIdentification_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(PresetIdentification);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(CaptureStart other)
					{
						if (other == null)
						{
							return;
						}
						if (other.presetIdentification_ != null)
						{
							if (presetIdentification_ == null)
							{
								PresetIdentification = new CollectionElementType();
							}
							PresetIdentification.MergeFrom(other.PresetIdentification);
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
							if (presetIdentification_ == null)
							{
								PresetIdentification = new CollectionElementType();
							}
							input.ReadMessage(PresetIdentification);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class CaptureStop : IMessage<CaptureStop>, IMessage, IEquatable<CaptureStop>, IDeepCloneable<CaptureStop>
				{
					private static readonly MessageParser<CaptureStop> _parser = new MessageParser<CaptureStop>(() => new CaptureStop());

					private UnknownFieldSet _unknownFields;

					public const int ShowsAlertBeforeStoppingFieldNumber = 1;

					private bool showsAlertBeforeStopping_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<CaptureStop> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => CaptureType.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ShowsAlertBeforeStopping
					{
						get
						{
							return showsAlertBeforeStopping_;
						}
						set
						{
							showsAlertBeforeStopping_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStop()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStop(CaptureStop other)
						: this()
					{
						showsAlertBeforeStopping_ = other.showsAlertBeforeStopping_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CaptureStop Clone()
					{
						return new CaptureStop(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as CaptureStop);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(CaptureStop other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ShowsAlertBeforeStopping != other.ShowsAlertBeforeStopping)
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
						if (ShowsAlertBeforeStopping)
						{
							num ^= ShowsAlertBeforeStopping.GetHashCode();
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
						if (ShowsAlertBeforeStopping)
						{
							output.WriteRawTag(8);
							output.WriteBool(ShowsAlertBeforeStopping);
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
						if (ShowsAlertBeforeStopping)
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
					public void MergeFrom(CaptureStop other)
					{
						if (other != null)
						{
							if (other.ShowsAlertBeforeStopping)
							{
								ShowsAlertBeforeStopping = other.ShowsAlertBeforeStopping;
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
							if (num != 8)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								ShowsAlertBeforeStopping = input.ReadBool();
							}
						}
					}
				}
			}

			private static readonly MessageParser<CaptureType> _parser = new MessageParser<CaptureType>(() => new CaptureType());

			private UnknownFieldSet _unknownFields;

			public const int StartFieldNumber = 1;

			public const int StopFieldNumber = 2;

			private object captureAction_;

			private CaptureActionOneofCase captureActionCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CaptureType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[27];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CaptureStart Start
			{
				get
				{
					if (captureActionCase_ != CaptureActionOneofCase.Start)
					{
						return null;
					}
					return (Types.CaptureStart)captureAction_;
				}
				set
				{
					captureAction_ = value;
					captureActionCase_ = ((value != null) ? CaptureActionOneofCase.Start : CaptureActionOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CaptureStop Stop
			{
				get
				{
					if (captureActionCase_ != CaptureActionOneofCase.Stop)
					{
						return null;
					}
					return (Types.CaptureStop)captureAction_;
				}
				set
				{
					captureAction_ = value;
					captureActionCase_ = ((value != null) ? CaptureActionOneofCase.Stop : CaptureActionOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureActionOneofCase CaptureActionCase => captureActionCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureType(CaptureType other)
				: this()
			{
				switch (other.CaptureActionCase)
				{
				case CaptureActionOneofCase.Start:
					Start = other.Start.Clone();
					break;
				case CaptureActionOneofCase.Stop:
					Stop = other.Stop.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureType Clone()
			{
				return new CaptureType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearCaptureAction()
			{
				captureActionCase_ = CaptureActionOneofCase.None;
				captureAction_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CaptureType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CaptureType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Start, other.Start))
				{
					return false;
				}
				if (!object.Equals(Stop, other.Stop))
				{
					return false;
				}
				if (CaptureActionCase != other.CaptureActionCase)
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
				if (captureActionCase_ == CaptureActionOneofCase.Start)
				{
					num ^= Start.GetHashCode();
				}
				if (captureActionCase_ == CaptureActionOneofCase.Stop)
				{
					num ^= Stop.GetHashCode();
				}
				num ^= (int)captureActionCase_;
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
				if (captureActionCase_ == CaptureActionOneofCase.Start)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Start);
				}
				if (captureActionCase_ == CaptureActionOneofCase.Stop)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Stop);
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
				if (captureActionCase_ == CaptureActionOneofCase.Start)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Start);
				}
				if (captureActionCase_ == CaptureActionOneofCase.Stop)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Stop);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CaptureType other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.CaptureActionCase)
				{
				case CaptureActionOneofCase.Start:
					if (Start == null)
					{
						Start = new Types.CaptureStart();
					}
					Start.MergeFrom(other.Start);
					break;
				case CaptureActionOneofCase.Stop:
					if (Stop == null)
					{
						Stop = new Types.CaptureStop();
					}
					Stop.MergeFrom(other.Stop);
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
						Types.CaptureStart captureStart = new Types.CaptureStart();
						if (captureActionCase_ == CaptureActionOneofCase.Start)
						{
							captureStart.MergeFrom(Start);
						}
						input.ReadMessage(captureStart);
						Start = captureStart;
						break;
					}
					case 18u:
					{
						Types.CaptureStop captureStop = new Types.CaptureStop();
						if (captureActionCase_ == CaptureActionOneofCase.Stop)
						{
							captureStop.MergeFrom(Stop);
						}
						input.ReadMessage(captureStop);
						Stop = captureStop;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<Action> _parser = new MessageParser<Action>(() => new Action());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int LabelFieldNumber = 3;

	private Types.Label label_;

	public const int DelayTimeFieldNumber = 4;

	private double delayTime_;

	public const int OldTypeFieldNumber = 5;

	private Types.OldType oldType_;

	public const int IsEnabledFieldNumber = 6;

	private bool isEnabled_;

	public const int LayerIdentificationFieldNumber = 7;

	private Types.LayerIdentification layerIdentification_;

	public const int DurationFieldNumber = 8;

	private double duration_;

	public const int TypeFieldNumber = 9;

	private Types.ActionType type_;

	public const int CollectionElementFieldNumber = 16;

	public const int PlaylistItemFieldNumber = 17;

	public const int BlendModeFieldNumber = 18;

	public const int TransitionFieldNumber = 19;

	public const int MediaFieldNumber = 20;

	public const int DoubleItemFieldNumber = 21;

	public const int EffectsFieldNumber = 22;

	public const int SlideFieldNumber = 23;

	public const int BackgroundFieldNumber = 24;

	public const int TimerFieldNumber = 25;

	public const int ClearFieldNumber = 26;

	public const int StageFieldNumber = 27;

	public const int PropFieldNumber = 28;

	public const int MaskFieldNumber = 29;

	public const int MessageFieldNumber = 30;

	public const int CommunicationFieldNumber = 32;

	public const int MultiScreenFieldNumber = 33;

	public const int PresentationDocumentFieldNumber = 34;

	public const int ExternalPresentationFieldNumber = 36;

	public const int AudienceLookFieldNumber = 37;

	public const int AudioInputFieldNumber = 38;

	public const int SlideDestinationFieldNumber = 39;

	public const int MacroFieldNumber = 40;

	public const int ClearGroupFieldNumber = 41;

	public const int TransportControlFieldNumber = 42;

	public const int CaptureFieldNumber = 43;

	private object actionTypeData_;

	private ActionTypeDataOneofCase actionTypeDataCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Action> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ActionReflection.Descriptor.MessageTypes[0];

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
	public Types.Label Label
	{
		get
		{
			return label_;
		}
		set
		{
			label_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double DelayTime
	{
		get
		{
			return delayTime_;
		}
		set
		{
			delayTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.OldType OldType
	{
		get
		{
			return oldType_;
		}
		set
		{
			oldType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsEnabled
	{
		get
		{
			return isEnabled_;
		}
		set
		{
			isEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.LayerIdentification LayerIdentification
	{
		get
		{
			return layerIdentification_;
		}
		set
		{
			layerIdentification_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Duration
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
	public Types.ActionType Type
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
	public CollectionElementType CollectionElement
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.CollectionElement)
			{
				return null;
			}
			return (CollectionElementType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.CollectionElement : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistItemType PlaylistItem
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.PlaylistItem)
			{
				return null;
			}
			return (Types.PlaylistItemType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.PlaylistItem : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BlendModeType BlendMode
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.BlendMode)
			{
				return null;
			}
			return (Types.BlendModeType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.BlendMode : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TransitionType Transition
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Transition)
			{
				return null;
			}
			return (Types.TransitionType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Transition : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaType Media
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Media)
			{
				return null;
			}
			return (Types.MediaType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Media : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DoubleType DoubleItem
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.DoubleItem)
			{
				return null;
			}
			return (Types.DoubleType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.DoubleItem : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EffectsType Effects
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Effects)
			{
				return null;
			}
			return (Types.EffectsType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Effects : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideType Slide
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Slide)
			{
				return null;
			}
			return (Types.SlideType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Slide : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BackgroundType Background
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Background)
			{
				return null;
			}
			return (Types.BackgroundType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Background : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimerType Timer
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Timer)
			{
				return null;
			}
			return (Types.TimerType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Timer : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearType Clear
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Clear)
			{
				return null;
			}
			return (Types.ClearType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Clear : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StageLayoutType Stage
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Stage)
			{
				return null;
			}
			return (Types.StageLayoutType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Stage : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PropType Prop
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Prop)
			{
				return null;
			}
			return (Types.PropType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Prop : ActionTypeDataOneofCase.None);
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MaskType Mask
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Mask)
			{
				return null;
			}
			return (Types.MaskType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Mask : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MessageType Message
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Message)
			{
				return null;
			}
			return (Types.MessageType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Message : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CommunicationType Communication
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Communication)
			{
				return null;
			}
			return (Types.CommunicationType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Communication : ActionTypeDataOneofCase.None);
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MultiScreenType MultiScreen
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.MultiScreen)
			{
				return null;
			}
			return (Types.MultiScreenType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.MultiScreen : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DocumentType PresentationDocument
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.PresentationDocument)
			{
				return null;
			}
			return (Types.DocumentType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.PresentationDocument : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ExternalPresentationType ExternalPresentation
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.ExternalPresentation)
			{
				return null;
			}
			return (Types.ExternalPresentationType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.ExternalPresentation : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudienceLookType AudienceLook
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.AudienceLook)
			{
				return null;
			}
			return (Types.AudienceLookType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.AudienceLook : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudioInputType AudioInput
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.AudioInput)
			{
				return null;
			}
			return (Types.AudioInputType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.AudioInput : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideDestinationType SlideDestination
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.SlideDestination)
			{
				return null;
			}
			return (Types.SlideDestinationType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.SlideDestination : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MacroType Macro
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Macro)
			{
				return null;
			}
			return (Types.MacroType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Macro : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearGroupType ClearGroup
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.ClearGroup)
			{
				return null;
			}
			return (Types.ClearGroupType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.ClearGroup : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TransportControlType TransportControl
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.TransportControl)
			{
				return null;
			}
			return (Types.TransportControlType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.TransportControl : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CaptureType Capture
	{
		get
		{
			if (actionTypeDataCase_ != ActionTypeDataOneofCase.Capture)
			{
				return null;
			}
			return (Types.CaptureType)actionTypeData_;
		}
		set
		{
			actionTypeData_ = value;
			actionTypeDataCase_ = ((value != null) ? ActionTypeDataOneofCase.Capture : ActionTypeDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionTypeDataOneofCase ActionTypeDataCase => actionTypeDataCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action(Action other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		label_ = ((other.label_ != null) ? other.label_.Clone() : null);
		delayTime_ = other.delayTime_;
		oldType_ = ((other.oldType_ != null) ? other.oldType_.Clone() : null);
		isEnabled_ = other.isEnabled_;
		layerIdentification_ = ((other.layerIdentification_ != null) ? other.layerIdentification_.Clone() : null);
		duration_ = other.duration_;
		type_ = other.type_;
		switch (other.ActionTypeDataCase)
		{
		case ActionTypeDataOneofCase.CollectionElement:
			CollectionElement = other.CollectionElement.Clone();
			break;
		case ActionTypeDataOneofCase.PlaylistItem:
			PlaylistItem = other.PlaylistItem.Clone();
			break;
		case ActionTypeDataOneofCase.BlendMode:
			BlendMode = other.BlendMode.Clone();
			break;
		case ActionTypeDataOneofCase.Transition:
			Transition = other.Transition.Clone();
			break;
		case ActionTypeDataOneofCase.Media:
			Media = other.Media.Clone();
			break;
		case ActionTypeDataOneofCase.DoubleItem:
			DoubleItem = other.DoubleItem.Clone();
			break;
		case ActionTypeDataOneofCase.Effects:
			Effects = other.Effects.Clone();
			break;
		case ActionTypeDataOneofCase.Slide:
			Slide = other.Slide.Clone();
			break;
		case ActionTypeDataOneofCase.Background:
			Background = other.Background.Clone();
			break;
		case ActionTypeDataOneofCase.Timer:
			Timer = other.Timer.Clone();
			break;
		case ActionTypeDataOneofCase.Clear:
			Clear = other.Clear.Clone();
			break;
		case ActionTypeDataOneofCase.Stage:
			Stage = other.Stage.Clone();
			break;
		case ActionTypeDataOneofCase.Prop:
			Prop = other.Prop.Clone();
			break;
		case ActionTypeDataOneofCase.Mask:
			Mask = other.Mask.Clone();
			break;
		case ActionTypeDataOneofCase.Message:
			Message = other.Message.Clone();
			break;
		case ActionTypeDataOneofCase.Communication:
			Communication = other.Communication.Clone();
			break;
		case ActionTypeDataOneofCase.MultiScreen:
			MultiScreen = other.MultiScreen.Clone();
			break;
		case ActionTypeDataOneofCase.PresentationDocument:
			PresentationDocument = other.PresentationDocument.Clone();
			break;
		case ActionTypeDataOneofCase.ExternalPresentation:
			ExternalPresentation = other.ExternalPresentation.Clone();
			break;
		case ActionTypeDataOneofCase.AudienceLook:
			AudienceLook = other.AudienceLook.Clone();
			break;
		case ActionTypeDataOneofCase.AudioInput:
			AudioInput = other.AudioInput.Clone();
			break;
		case ActionTypeDataOneofCase.SlideDestination:
			SlideDestination = other.SlideDestination.Clone();
			break;
		case ActionTypeDataOneofCase.Macro:
			Macro = other.Macro.Clone();
			break;
		case ActionTypeDataOneofCase.ClearGroup:
			ClearGroup = other.ClearGroup.Clone();
			break;
		case ActionTypeDataOneofCase.TransportControl:
			TransportControl = other.TransportControl.Clone();
			break;
		case ActionTypeDataOneofCase.Capture:
			Capture = other.Capture.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action Clone()
	{
		return new Action(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearActionTypeData()
	{
		actionTypeDataCase_ = ActionTypeDataOneofCase.None;
		actionTypeData_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Action);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Action other)
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
		if (!object.Equals(Label, other.Label))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DelayTime, other.DelayTime))
		{
			return false;
		}
		if (!object.Equals(OldType, other.OldType))
		{
			return false;
		}
		if (IsEnabled != other.IsEnabled)
		{
			return false;
		}
		if (!object.Equals(LayerIdentification, other.LayerIdentification))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (!object.Equals(CollectionElement, other.CollectionElement))
		{
			return false;
		}
		if (!object.Equals(PlaylistItem, other.PlaylistItem))
		{
			return false;
		}
		if (!object.Equals(BlendMode, other.BlendMode))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (!object.Equals(Media, other.Media))
		{
			return false;
		}
		if (!object.Equals(DoubleItem, other.DoubleItem))
		{
			return false;
		}
		if (!object.Equals(Effects, other.Effects))
		{
			return false;
		}
		if (!object.Equals(Slide, other.Slide))
		{
			return false;
		}
		if (!object.Equals(Background, other.Background))
		{
			return false;
		}
		if (!object.Equals(Timer, other.Timer))
		{
			return false;
		}
		if (!object.Equals(Clear, other.Clear))
		{
			return false;
		}
		if (!object.Equals(Stage, other.Stage))
		{
			return false;
		}
		if (!object.Equals(Prop, other.Prop))
		{
			return false;
		}
		if (!object.Equals(Mask, other.Mask))
		{
			return false;
		}
		if (!object.Equals(Message, other.Message))
		{
			return false;
		}
		if (!object.Equals(Communication, other.Communication))
		{
			return false;
		}
		if (!object.Equals(MultiScreen, other.MultiScreen))
		{
			return false;
		}
		if (!object.Equals(PresentationDocument, other.PresentationDocument))
		{
			return false;
		}
		if (!object.Equals(ExternalPresentation, other.ExternalPresentation))
		{
			return false;
		}
		if (!object.Equals(AudienceLook, other.AudienceLook))
		{
			return false;
		}
		if (!object.Equals(AudioInput, other.AudioInput))
		{
			return false;
		}
		if (!object.Equals(SlideDestination, other.SlideDestination))
		{
			return false;
		}
		if (!object.Equals(Macro, other.Macro))
		{
			return false;
		}
		if (!object.Equals(ClearGroup, other.ClearGroup))
		{
			return false;
		}
		if (!object.Equals(TransportControl, other.TransportControl))
		{
			return false;
		}
		if (!object.Equals(Capture, other.Capture))
		{
			return false;
		}
		if (ActionTypeDataCase != other.ActionTypeDataCase)
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
		if (label_ != null)
		{
			num ^= Label.GetHashCode();
		}
		if (DelayTime != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DelayTime);
		}
		if (oldType_ != null)
		{
			num ^= OldType.GetHashCode();
		}
		if (IsEnabled)
		{
			num ^= IsEnabled.GetHashCode();
		}
		if (layerIdentification_ != null)
		{
			num ^= LayerIdentification.GetHashCode();
		}
		if (Duration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
		}
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.CollectionElement)
		{
			num ^= CollectionElement.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PlaylistItem)
		{
			num ^= PlaylistItem.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.BlendMode)
		{
			num ^= BlendMode.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Transition)
		{
			num ^= Transition.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Media)
		{
			num ^= Media.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.DoubleItem)
		{
			num ^= DoubleItem.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Effects)
		{
			num ^= Effects.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Slide)
		{
			num ^= Slide.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Background)
		{
			num ^= Background.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Timer)
		{
			num ^= Timer.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Clear)
		{
			num ^= Clear.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Stage)
		{
			num ^= Stage.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Prop)
		{
			num ^= Prop.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Mask)
		{
			num ^= Mask.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Message)
		{
			num ^= Message.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Communication)
		{
			num ^= Communication.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.MultiScreen)
		{
			num ^= MultiScreen.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PresentationDocument)
		{
			num ^= PresentationDocument.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ExternalPresentation)
		{
			num ^= ExternalPresentation.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudienceLook)
		{
			num ^= AudienceLook.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudioInput)
		{
			num ^= AudioInput.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.SlideDestination)
		{
			num ^= SlideDestination.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Macro)
		{
			num ^= Macro.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ClearGroup)
		{
			num ^= ClearGroup.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.TransportControl)
		{
			num ^= TransportControl.GetHashCode();
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Capture)
		{
			num ^= Capture.GetHashCode();
		}
		num ^= (int)actionTypeDataCase_;
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
		if (label_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Label);
		}
		if (DelayTime != 0.0)
		{
			output.WriteRawTag(33);
			output.WriteDouble(DelayTime);
		}
		if (oldType_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(OldType);
		}
		if (IsEnabled)
		{
			output.WriteRawTag(48);
			output.WriteBool(IsEnabled);
		}
		if (layerIdentification_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(LayerIdentification);
		}
		if (Duration != 0.0)
		{
			output.WriteRawTag(65);
			output.WriteDouble(Duration);
		}
		if (Type != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)Type);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.CollectionElement)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(CollectionElement);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PlaylistItem)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(PlaylistItem);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.BlendMode)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(BlendMode);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Transition)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(Transition);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Media)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(Media);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.DoubleItem)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(DoubleItem);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Effects)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(Effects);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Slide)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(Slide);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Background)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(Background);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Timer)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(Timer);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Clear)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(Clear);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Stage)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(Stage);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Prop)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(Prop);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Mask)
		{
			output.WriteRawTag(234, 1);
			output.WriteMessage(Mask);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Message)
		{
			output.WriteRawTag(242, 1);
			output.WriteMessage(Message);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Communication)
		{
			output.WriteRawTag(130, 2);
			output.WriteMessage(Communication);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.MultiScreen)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(MultiScreen);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PresentationDocument)
		{
			output.WriteRawTag(146, 2);
			output.WriteMessage(PresentationDocument);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ExternalPresentation)
		{
			output.WriteRawTag(162, 2);
			output.WriteMessage(ExternalPresentation);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudienceLook)
		{
			output.WriteRawTag(170, 2);
			output.WriteMessage(AudienceLook);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudioInput)
		{
			output.WriteRawTag(178, 2);
			output.WriteMessage(AudioInput);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.SlideDestination)
		{
			output.WriteRawTag(186, 2);
			output.WriteMessage(SlideDestination);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Macro)
		{
			output.WriteRawTag(194, 2);
			output.WriteMessage(Macro);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ClearGroup)
		{
			output.WriteRawTag(202, 2);
			output.WriteMessage(ClearGroup);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.TransportControl)
		{
			output.WriteRawTag(210, 2);
			output.WriteMessage(TransportControl);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Capture)
		{
			output.WriteRawTag(218, 2);
			output.WriteMessage(Capture);
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
		if (label_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Label);
		}
		if (DelayTime != 0.0)
		{
			num += 9;
		}
		if (oldType_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OldType);
		}
		if (IsEnabled)
		{
			num += 2;
		}
		if (layerIdentification_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LayerIdentification);
		}
		if (Duration != 0.0)
		{
			num += 9;
		}
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.CollectionElement)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CollectionElement);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PlaylistItem)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistItem);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.BlendMode)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BlendMode);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Transition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Media)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.DoubleItem)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(DoubleItem);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Effects)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Effects);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Slide)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Slide);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Background)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Background);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Timer)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Timer);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Clear)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Clear);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Stage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Stage);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Prop)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Prop);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Mask)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Mask);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Message)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Message);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Communication)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Communication);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.MultiScreen)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MultiScreen);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.PresentationDocument)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PresentationDocument);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ExternalPresentation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ExternalPresentation);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudienceLook)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudienceLook);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudioInput)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioInput);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.SlideDestination)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SlideDestination);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Macro)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Macro);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.ClearGroup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ClearGroup);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.TransportControl)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TransportControl);
		}
		if (actionTypeDataCase_ == ActionTypeDataOneofCase.Capture)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Capture);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Action other)
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
		if (other.label_ != null)
		{
			if (label_ == null)
			{
				Label = new Types.Label();
			}
			Label.MergeFrom(other.Label);
		}
		if (other.DelayTime != 0.0)
		{
			DelayTime = other.DelayTime;
		}
		if (other.oldType_ != null)
		{
			if (oldType_ == null)
			{
				OldType = new Types.OldType();
			}
			OldType.MergeFrom(other.OldType);
		}
		if (other.IsEnabled)
		{
			IsEnabled = other.IsEnabled;
		}
		if (other.layerIdentification_ != null)
		{
			if (layerIdentification_ == null)
			{
				LayerIdentification = new Types.LayerIdentification();
			}
			LayerIdentification.MergeFrom(other.LayerIdentification);
		}
		if (other.Duration != 0.0)
		{
			Duration = other.Duration;
		}
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		switch (other.ActionTypeDataCase)
		{
		case ActionTypeDataOneofCase.CollectionElement:
			if (CollectionElement == null)
			{
				CollectionElement = new CollectionElementType();
			}
			CollectionElement.MergeFrom(other.CollectionElement);
			break;
		case ActionTypeDataOneofCase.PlaylistItem:
			if (PlaylistItem == null)
			{
				PlaylistItem = new Types.PlaylistItemType();
			}
			PlaylistItem.MergeFrom(other.PlaylistItem);
			break;
		case ActionTypeDataOneofCase.BlendMode:
			if (BlendMode == null)
			{
				BlendMode = new Types.BlendModeType();
			}
			BlendMode.MergeFrom(other.BlendMode);
			break;
		case ActionTypeDataOneofCase.Transition:
			if (Transition == null)
			{
				Transition = new Types.TransitionType();
			}
			Transition.MergeFrom(other.Transition);
			break;
		case ActionTypeDataOneofCase.Media:
			if (Media == null)
			{
				Media = new Types.MediaType();
			}
			Media.MergeFrom(other.Media);
			break;
		case ActionTypeDataOneofCase.DoubleItem:
			if (DoubleItem == null)
			{
				DoubleItem = new Types.DoubleType();
			}
			DoubleItem.MergeFrom(other.DoubleItem);
			break;
		case ActionTypeDataOneofCase.Effects:
			if (Effects == null)
			{
				Effects = new Types.EffectsType();
			}
			Effects.MergeFrom(other.Effects);
			break;
		case ActionTypeDataOneofCase.Slide:
			if (Slide == null)
			{
				Slide = new Types.SlideType();
			}
			Slide.MergeFrom(other.Slide);
			break;
		case ActionTypeDataOneofCase.Background:
			if (Background == null)
			{
				Background = new Types.BackgroundType();
			}
			Background.MergeFrom(other.Background);
			break;
		case ActionTypeDataOneofCase.Timer:
			if (Timer == null)
			{
				Timer = new Types.TimerType();
			}
			Timer.MergeFrom(other.Timer);
			break;
		case ActionTypeDataOneofCase.Clear:
			if (Clear == null)
			{
				Clear = new Types.ClearType();
			}
			Clear.MergeFrom(other.Clear);
			break;
		case ActionTypeDataOneofCase.Stage:
			if (Stage == null)
			{
				Stage = new Types.StageLayoutType();
			}
			Stage.MergeFrom(other.Stage);
			break;
		case ActionTypeDataOneofCase.Prop:
			if (Prop == null)
			{
				Prop = new Types.PropType();
			}
			Prop.MergeFrom(other.Prop);
			break;
		case ActionTypeDataOneofCase.Mask:
			if (Mask == null)
			{
				Mask = new Types.MaskType();
			}
			Mask.MergeFrom(other.Mask);
			break;
		case ActionTypeDataOneofCase.Message:
			if (Message == null)
			{
				Message = new Types.MessageType();
			}
			Message.MergeFrom(other.Message);
			break;
		case ActionTypeDataOneofCase.Communication:
			if (Communication == null)
			{
				Communication = new Types.CommunicationType();
			}
			Communication.MergeFrom(other.Communication);
			break;
		case ActionTypeDataOneofCase.MultiScreen:
			if (MultiScreen == null)
			{
				MultiScreen = new Types.MultiScreenType();
			}
			MultiScreen.MergeFrom(other.MultiScreen);
			break;
		case ActionTypeDataOneofCase.PresentationDocument:
			if (PresentationDocument == null)
			{
				PresentationDocument = new Types.DocumentType();
			}
			PresentationDocument.MergeFrom(other.PresentationDocument);
			break;
		case ActionTypeDataOneofCase.ExternalPresentation:
			if (ExternalPresentation == null)
			{
				ExternalPresentation = new Types.ExternalPresentationType();
			}
			ExternalPresentation.MergeFrom(other.ExternalPresentation);
			break;
		case ActionTypeDataOneofCase.AudienceLook:
			if (AudienceLook == null)
			{
				AudienceLook = new Types.AudienceLookType();
			}
			AudienceLook.MergeFrom(other.AudienceLook);
			break;
		case ActionTypeDataOneofCase.AudioInput:
			if (AudioInput == null)
			{
				AudioInput = new Types.AudioInputType();
			}
			AudioInput.MergeFrom(other.AudioInput);
			break;
		case ActionTypeDataOneofCase.SlideDestination:
			if (SlideDestination == null)
			{
				SlideDestination = new Types.SlideDestinationType();
			}
			SlideDestination.MergeFrom(other.SlideDestination);
			break;
		case ActionTypeDataOneofCase.Macro:
			if (Macro == null)
			{
				Macro = new Types.MacroType();
			}
			Macro.MergeFrom(other.Macro);
			break;
		case ActionTypeDataOneofCase.ClearGroup:
			if (ClearGroup == null)
			{
				ClearGroup = new Types.ClearGroupType();
			}
			ClearGroup.MergeFrom(other.ClearGroup);
			break;
		case ActionTypeDataOneofCase.TransportControl:
			if (TransportControl == null)
			{
				TransportControl = new Types.TransportControlType();
			}
			TransportControl.MergeFrom(other.TransportControl);
			break;
		case ActionTypeDataOneofCase.Capture:
			if (Capture == null)
			{
				Capture = new Types.CaptureType();
			}
			Capture.MergeFrom(other.Capture);
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
				Name = input.ReadString();
				break;
			case 26u:
				if (label_ == null)
				{
					Label = new Types.Label();
				}
				input.ReadMessage(Label);
				break;
			case 33u:
				DelayTime = input.ReadDouble();
				break;
			case 42u:
				if (oldType_ == null)
				{
					OldType = new Types.OldType();
				}
				input.ReadMessage(OldType);
				break;
			case 48u:
				IsEnabled = input.ReadBool();
				break;
			case 58u:
				if (layerIdentification_ == null)
				{
					LayerIdentification = new Types.LayerIdentification();
				}
				input.ReadMessage(LayerIdentification);
				break;
			case 65u:
				Duration = input.ReadDouble();
				break;
			case 72u:
				Type = (Types.ActionType)input.ReadEnum();
				break;
			case 130u:
			{
				CollectionElementType collectionElementType = new CollectionElementType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.CollectionElement)
				{
					collectionElementType.MergeFrom(CollectionElement);
				}
				input.ReadMessage(collectionElementType);
				CollectionElement = collectionElementType;
				break;
			}
			case 138u:
			{
				Types.PlaylistItemType playlistItemType = new Types.PlaylistItemType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.PlaylistItem)
				{
					playlistItemType.MergeFrom(PlaylistItem);
				}
				input.ReadMessage(playlistItemType);
				PlaylistItem = playlistItemType;
				break;
			}
			case 146u:
			{
				Types.BlendModeType blendModeType = new Types.BlendModeType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.BlendMode)
				{
					blendModeType.MergeFrom(BlendMode);
				}
				input.ReadMessage(blendModeType);
				BlendMode = blendModeType;
				break;
			}
			case 154u:
			{
				Types.TransitionType transitionType = new Types.TransitionType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Transition)
				{
					transitionType.MergeFrom(Transition);
				}
				input.ReadMessage(transitionType);
				Transition = transitionType;
				break;
			}
			case 162u:
			{
				Types.MediaType mediaType = new Types.MediaType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Media)
				{
					mediaType.MergeFrom(Media);
				}
				input.ReadMessage(mediaType);
				Media = mediaType;
				break;
			}
			case 170u:
			{
				Types.DoubleType doubleType = new Types.DoubleType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.DoubleItem)
				{
					doubleType.MergeFrom(DoubleItem);
				}
				input.ReadMessage(doubleType);
				DoubleItem = doubleType;
				break;
			}
			case 178u:
			{
				Types.EffectsType effectsType = new Types.EffectsType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Effects)
				{
					effectsType.MergeFrom(Effects);
				}
				input.ReadMessage(effectsType);
				Effects = effectsType;
				break;
			}
			case 186u:
			{
				Types.SlideType slideType = new Types.SlideType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Slide)
				{
					slideType.MergeFrom(Slide);
				}
				input.ReadMessage(slideType);
				Slide = slideType;
				break;
			}
			case 194u:
			{
				Types.BackgroundType backgroundType = new Types.BackgroundType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Background)
				{
					backgroundType.MergeFrom(Background);
				}
				input.ReadMessage(backgroundType);
				Background = backgroundType;
				break;
			}
			case 202u:
			{
				Types.TimerType timerType = new Types.TimerType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Timer)
				{
					timerType.MergeFrom(Timer);
				}
				input.ReadMessage(timerType);
				Timer = timerType;
				break;
			}
			case 210u:
			{
				Types.ClearType clearType = new Types.ClearType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Clear)
				{
					clearType.MergeFrom(Clear);
				}
				input.ReadMessage(clearType);
				Clear = clearType;
				break;
			}
			case 218u:
			{
				Types.StageLayoutType stageLayoutType = new Types.StageLayoutType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Stage)
				{
					stageLayoutType.MergeFrom(Stage);
				}
				input.ReadMessage(stageLayoutType);
				Stage = stageLayoutType;
				break;
			}
			case 226u:
			{
				Types.PropType propType = new Types.PropType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Prop)
				{
					propType.MergeFrom(Prop);
				}
				input.ReadMessage(propType);
				Prop = propType;
				break;
			}
			case 234u:
			{
				Types.MaskType maskType = new Types.MaskType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Mask)
				{
					maskType.MergeFrom(Mask);
				}
				input.ReadMessage(maskType);
				Mask = maskType;
				break;
			}
			case 242u:
			{
				Types.MessageType messageType = new Types.MessageType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Message)
				{
					messageType.MergeFrom(Message);
				}
				input.ReadMessage(messageType);
				Message = messageType;
				break;
			}
			case 258u:
			{
				Types.CommunicationType communicationType = new Types.CommunicationType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Communication)
				{
					communicationType.MergeFrom(Communication);
				}
				input.ReadMessage(communicationType);
				Communication = communicationType;
				break;
			}
			case 266u:
			{
				Types.MultiScreenType multiScreenType = new Types.MultiScreenType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.MultiScreen)
				{
					multiScreenType.MergeFrom(MultiScreen);
				}
				input.ReadMessage(multiScreenType);
				MultiScreen = multiScreenType;
				break;
			}
			case 274u:
			{
				Types.DocumentType documentType = new Types.DocumentType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.PresentationDocument)
				{
					documentType.MergeFrom(PresentationDocument);
				}
				input.ReadMessage(documentType);
				PresentationDocument = documentType;
				break;
			}
			case 290u:
			{
				Types.ExternalPresentationType externalPresentationType = new Types.ExternalPresentationType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.ExternalPresentation)
				{
					externalPresentationType.MergeFrom(ExternalPresentation);
				}
				input.ReadMessage(externalPresentationType);
				ExternalPresentation = externalPresentationType;
				break;
			}
			case 298u:
			{
				Types.AudienceLookType audienceLookType = new Types.AudienceLookType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudienceLook)
				{
					audienceLookType.MergeFrom(AudienceLook);
				}
				input.ReadMessage(audienceLookType);
				AudienceLook = audienceLookType;
				break;
			}
			case 306u:
			{
				Types.AudioInputType audioInputType = new Types.AudioInputType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.AudioInput)
				{
					audioInputType.MergeFrom(AudioInput);
				}
				input.ReadMessage(audioInputType);
				AudioInput = audioInputType;
				break;
			}
			case 314u:
			{
				Types.SlideDestinationType slideDestinationType = new Types.SlideDestinationType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.SlideDestination)
				{
					slideDestinationType.MergeFrom(SlideDestination);
				}
				input.ReadMessage(slideDestinationType);
				SlideDestination = slideDestinationType;
				break;
			}
			case 322u:
			{
				Types.MacroType macroType = new Types.MacroType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Macro)
				{
					macroType.MergeFrom(Macro);
				}
				input.ReadMessage(macroType);
				Macro = macroType;
				break;
			}
			case 330u:
			{
				Types.ClearGroupType clearGroupType = new Types.ClearGroupType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.ClearGroup)
				{
					clearGroupType.MergeFrom(ClearGroup);
				}
				input.ReadMessage(clearGroupType);
				ClearGroup = clearGroupType;
				break;
			}
			case 338u:
			{
				Types.TransportControlType transportControlType = new Types.TransportControlType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.TransportControl)
				{
					transportControlType.MergeFrom(TransportControl);
				}
				input.ReadMessage(transportControlType);
				TransportControl = transportControlType;
				break;
			}
			case 346u:
			{
				Types.CaptureType captureType = new Types.CaptureType();
				if (actionTypeDataCase_ == ActionTypeDataOneofCase.Capture)
				{
					captureType.MergeFrom(Capture);
				}
				input.ReadMessage(captureType);
				Capture = captureType;
				break;
			}
			}
		}
	}
}
