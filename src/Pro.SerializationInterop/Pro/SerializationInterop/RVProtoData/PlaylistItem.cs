using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PlaylistItem : IMessage<PlaylistItem>, IMessage, IEquatable<PlaylistItem>, IDeepCloneable<PlaylistItem>
{
	public enum ItemTypeOneofCase
	{
		None = 0,
		Header = 3,
		Presentation = 4,
		Cue = 5,
		PlanningCenter = 6,
		Placeholder = 8
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Header : IMessage<Header>, IMessage, IEquatable<Header>, IDeepCloneable<Header>
		{
			private static readonly MessageParser<Header> _parser = new MessageParser<Header>(() => new Header());

			private UnknownFieldSet _unknownFields;

			public const int ColorFieldNumber = 1;

			private Color color_;

			public const int ActionsFieldNumber = 2;

			private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(18u, Action.Parser);

			private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Header> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlaylistItem.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public Header()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header(Header other)
				: this()
			{
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				actions_ = other.actions_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header Clone()
			{
				return new Header(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Header);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Header other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Color, other.Color))
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
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
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
				if (color_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Color);
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
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
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
			public void MergeFrom(Header other)
			{
				if (other == null)
				{
					return;
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
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					case 18u:
						actions_.AddEntriesFrom(input, _repeated_actions_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
		{
			private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

			private UnknownFieldSet _unknownFields;

			public const int DocumentPathFieldNumber = 1;

			private URL documentPath_;

			public const int ArrangementFieldNumber = 2;

			private UUID arrangement_;

			public const int ContentDestinationFieldNumber = 3;

			private Action.Types.ContentDestination contentDestination_;

			public const int UserMusicKeyFieldNumber = 4;

			private MusicKeyScale userMusicKey_;

			public const int ArrangementNameFieldNumber = 5;

			private string arrangementName_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Presentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlaylistItem.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL DocumentPath
			{
				get
				{
					return documentPath_;
				}
				set
				{
					documentPath_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Arrangement
			{
				get
				{
					return arrangement_;
				}
				set
				{
					arrangement_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action.Types.ContentDestination ContentDestination
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
			public MusicKeyScale UserMusicKey
			{
				get
				{
					return userMusicKey_;
				}
				set
				{
					userMusicKey_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ArrangementName
			{
				get
				{
					return arrangementName_;
				}
				set
				{
					arrangementName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation(Presentation other)
				: this()
			{
				documentPath_ = ((other.documentPath_ != null) ? other.documentPath_.Clone() : null);
				arrangement_ = ((other.arrangement_ != null) ? other.arrangement_.Clone() : null);
				contentDestination_ = other.contentDestination_;
				userMusicKey_ = ((other.userMusicKey_ != null) ? other.userMusicKey_.Clone() : null);
				arrangementName_ = other.arrangementName_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation Clone()
			{
				return new Presentation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Presentation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Presentation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(DocumentPath, other.DocumentPath))
				{
					return false;
				}
				if (!object.Equals(Arrangement, other.Arrangement))
				{
					return false;
				}
				if (ContentDestination != other.ContentDestination)
				{
					return false;
				}
				if (!object.Equals(UserMusicKey, other.UserMusicKey))
				{
					return false;
				}
				if (ArrangementName != other.ArrangementName)
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
				if (documentPath_ != null)
				{
					num ^= DocumentPath.GetHashCode();
				}
				if (arrangement_ != null)
				{
					num ^= Arrangement.GetHashCode();
				}
				if (ContentDestination != 0)
				{
					num ^= ContentDestination.GetHashCode();
				}
				if (userMusicKey_ != null)
				{
					num ^= UserMusicKey.GetHashCode();
				}
				if (ArrangementName.Length != 0)
				{
					num ^= ArrangementName.GetHashCode();
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
				if (documentPath_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(DocumentPath);
				}
				if (arrangement_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Arrangement);
				}
				if (ContentDestination != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)ContentDestination);
				}
				if (userMusicKey_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(UserMusicKey);
				}
				if (ArrangementName.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(ArrangementName);
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
				if (documentPath_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(DocumentPath);
				}
				if (arrangement_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Arrangement);
				}
				if (ContentDestination != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
				}
				if (userMusicKey_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UserMusicKey);
				}
				if (ArrangementName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ArrangementName);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Presentation other)
			{
				if (other == null)
				{
					return;
				}
				if (other.documentPath_ != null)
				{
					if (documentPath_ == null)
					{
						DocumentPath = new URL();
					}
					DocumentPath.MergeFrom(other.DocumentPath);
				}
				if (other.arrangement_ != null)
				{
					if (arrangement_ == null)
					{
						Arrangement = new UUID();
					}
					Arrangement.MergeFrom(other.Arrangement);
				}
				if (other.ContentDestination != 0)
				{
					ContentDestination = other.ContentDestination;
				}
				if (other.userMusicKey_ != null)
				{
					if (userMusicKey_ == null)
					{
						UserMusicKey = new MusicKeyScale();
					}
					UserMusicKey.MergeFrom(other.UserMusicKey);
				}
				if (other.ArrangementName.Length != 0)
				{
					ArrangementName = other.ArrangementName;
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
						if (documentPath_ == null)
						{
							DocumentPath = new URL();
						}
						input.ReadMessage(DocumentPath);
						break;
					case 18u:
						if (arrangement_ == null)
						{
							Arrangement = new UUID();
						}
						input.ReadMessage(Arrangement);
						break;
					case 24u:
						ContentDestination = (Action.Types.ContentDestination)input.ReadEnum();
						break;
					case 34u:
						if (userMusicKey_ == null)
						{
							UserMusicKey = new MusicKeyScale();
						}
						input.ReadMessage(UserMusicKey);
						break;
					case 42u:
						ArrangementName = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlanningCenter : IMessage<PlanningCenter>, IMessage, IEquatable<PlanningCenter>, IDeepCloneable<PlanningCenter>
		{
			private static readonly MessageParser<PlanningCenter> _parser = new MessageParser<PlanningCenter>(() => new PlanningCenter());

			private UnknownFieldSet _unknownFields;

			public const int ItemFieldNumber = 1;

			private PlanningCenterPlan.Types.PlanItem item_;

			public const int LinkedDataFieldNumber = 2;

			private PlaylistItem linkedData_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlanningCenter> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlaylistItem.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanningCenterPlan.Types.PlanItem Item
			{
				get
				{
					return item_;
				}
				set
				{
					item_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItem LinkedData
			{
				get
				{
					return linkedData_;
				}
				set
				{
					linkedData_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanningCenter()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanningCenter(PlanningCenter other)
				: this()
			{
				item_ = ((other.item_ != null) ? other.item_.Clone() : null);
				linkedData_ = ((other.linkedData_ != null) ? other.linkedData_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanningCenter Clone()
			{
				return new PlanningCenter(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlanningCenter);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlanningCenter other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Item, other.Item))
				{
					return false;
				}
				if (!object.Equals(LinkedData, other.LinkedData))
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
				if (item_ != null)
				{
					num ^= Item.GetHashCode();
				}
				if (linkedData_ != null)
				{
					num ^= LinkedData.GetHashCode();
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
				if (item_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Item);
				}
				if (linkedData_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(LinkedData);
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
				if (item_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Item);
				}
				if (linkedData_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LinkedData);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PlanningCenter other)
			{
				if (other == null)
				{
					return;
				}
				if (other.item_ != null)
				{
					if (item_ == null)
					{
						Item = new PlanningCenterPlan.Types.PlanItem();
					}
					Item.MergeFrom(other.Item);
				}
				if (other.linkedData_ != null)
				{
					if (linkedData_ == null)
					{
						LinkedData = new PlaylistItem();
					}
					LinkedData.MergeFrom(other.LinkedData);
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
						if (item_ == null)
						{
							Item = new PlanningCenterPlan.Types.PlanItem();
						}
						input.ReadMessage(Item);
						break;
					case 18u:
						if (linkedData_ == null)
						{
							LinkedData = new PlaylistItem();
						}
						input.ReadMessage(LinkedData);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Placeholder : IMessage<Placeholder>, IMessage, IEquatable<Placeholder>, IDeepCloneable<Placeholder>
		{
			private static readonly MessageParser<Placeholder> _parser = new MessageParser<Placeholder>(() => new Placeholder());

			private UnknownFieldSet _unknownFields;

			public const int LinkedDataFieldNumber = 1;

			private PlaylistItem linkedData_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Placeholder> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlaylistItem.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItem LinkedData
			{
				get
				{
					return linkedData_;
				}
				set
				{
					linkedData_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Placeholder()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Placeholder(Placeholder other)
				: this()
			{
				linkedData_ = ((other.linkedData_ != null) ? other.linkedData_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Placeholder Clone()
			{
				return new Placeholder(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Placeholder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Placeholder other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(LinkedData, other.LinkedData))
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
				if (linkedData_ != null)
				{
					num ^= LinkedData.GetHashCode();
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
				if (linkedData_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(LinkedData);
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
				if (linkedData_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LinkedData);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Placeholder other)
			{
				if (other == null)
				{
					return;
				}
				if (other.linkedData_ != null)
				{
					if (linkedData_ == null)
					{
						LinkedData = new PlaylistItem();
					}
					LinkedData.MergeFrom(other.LinkedData);
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
					if (linkedData_ == null)
					{
						LinkedData = new PlaylistItem();
					}
					input.ReadMessage(LinkedData);
				}
			}
		}
	}

	private static readonly MessageParser<PlaylistItem> _parser = new MessageParser<PlaylistItem>(() => new PlaylistItem());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int HeaderFieldNumber = 3;

	public const int PresentationFieldNumber = 4;

	public const int CueFieldNumber = 5;

	public const int PlanningCenterFieldNumber = 6;

	public const int PlaceholderFieldNumber = 8;

	public const int TagsFieldNumber = 7;

	private static readonly FieldCodec<UUID> _repeated_tags_codec = FieldCodec.ForMessage(58u, UUID.Parser);

	private readonly RepeatedField<UUID> tags_ = new RepeatedField<UUID>();

	public const int IsHiddenFieldNumber = 9;

	private bool isHidden_;

	private object itemType_;

	private ItemTypeOneofCase itemTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PlaylistItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PlaylistReflection.Descriptor.MessageTypes[1];

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
	public Types.Header Header
	{
		get
		{
			if (itemTypeCase_ != ItemTypeOneofCase.Header)
			{
				return null;
			}
			return (Types.Header)itemType_;
		}
		set
		{
			itemType_ = value;
			itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.Header : ItemTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Presentation Presentation
	{
		get
		{
			if (itemTypeCase_ != ItemTypeOneofCase.Presentation)
			{
				return null;
			}
			return (Types.Presentation)itemType_;
		}
		set
		{
			itemType_ = value;
			itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.Presentation : ItemTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue Cue
	{
		get
		{
			if (itemTypeCase_ != ItemTypeOneofCase.Cue)
			{
				return null;
			}
			return (Cue)itemType_;
		}
		set
		{
			itemType_ = value;
			itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.Cue : ItemTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlanningCenter PlanningCenter
	{
		get
		{
			if (itemTypeCase_ != ItemTypeOneofCase.PlanningCenter)
			{
				return null;
			}
			return (Types.PlanningCenter)itemType_;
		}
		set
		{
			itemType_ = value;
			itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.PlanningCenter : ItemTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Placeholder Placeholder
	{
		get
		{
			if (itemTypeCase_ != ItemTypeOneofCase.Placeholder)
			{
				return null;
			}
			return (Types.Placeholder)itemType_;
		}
		set
		{
			itemType_ = value;
			itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.Placeholder : ItemTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<UUID> Tags => tags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsHidden
	{
		get
		{
			return isHidden_;
		}
		set
		{
			isHidden_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ItemTypeOneofCase ItemTypeCase => itemTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistItem(PlaylistItem other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		tags_ = other.tags_.Clone();
		isHidden_ = other.isHidden_;
		switch (other.ItemTypeCase)
		{
		case ItemTypeOneofCase.Header:
			Header = other.Header.Clone();
			break;
		case ItemTypeOneofCase.Presentation:
			Presentation = other.Presentation.Clone();
			break;
		case ItemTypeOneofCase.Cue:
			Cue = other.Cue.Clone();
			break;
		case ItemTypeOneofCase.PlanningCenter:
			PlanningCenter = other.PlanningCenter.Clone();
			break;
		case ItemTypeOneofCase.Placeholder:
			Placeholder = other.Placeholder.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistItem Clone()
	{
		return new PlaylistItem(this);
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
		return Equals(other as PlaylistItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PlaylistItem other)
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
		if (!object.Equals(Header, other.Header))
		{
			return false;
		}
		if (!object.Equals(Presentation, other.Presentation))
		{
			return false;
		}
		if (!object.Equals(Cue, other.Cue))
		{
			return false;
		}
		if (!object.Equals(PlanningCenter, other.PlanningCenter))
		{
			return false;
		}
		if (!object.Equals(Placeholder, other.Placeholder))
		{
			return false;
		}
		if (!tags_.Equals(other.tags_))
		{
			return false;
		}
		if (IsHidden != other.IsHidden)
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Header)
		{
			num ^= Header.GetHashCode();
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Presentation)
		{
			num ^= Presentation.GetHashCode();
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Cue)
		{
			num ^= Cue.GetHashCode();
		}
		if (itemTypeCase_ == ItemTypeOneofCase.PlanningCenter)
		{
			num ^= PlanningCenter.GetHashCode();
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Placeholder)
		{
			num ^= Placeholder.GetHashCode();
		}
		num ^= tags_.GetHashCode();
		if (IsHidden)
		{
			num ^= IsHidden.GetHashCode();
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
		if (itemTypeCase_ == ItemTypeOneofCase.Header)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Header);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Presentation)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Presentation);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Cue)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Cue);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.PlanningCenter)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PlanningCenter);
		}
		tags_.WriteTo(output, _repeated_tags_codec);
		if (itemTypeCase_ == ItemTypeOneofCase.Placeholder)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Placeholder);
		}
		if (IsHidden)
		{
			output.WriteRawTag(72);
			output.WriteBool(IsHidden);
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
		if (itemTypeCase_ == ItemTypeOneofCase.Header)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Header);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Presentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Cue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.PlanningCenter)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlanningCenter);
		}
		if (itemTypeCase_ == ItemTypeOneofCase.Placeholder)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Placeholder);
		}
		num += tags_.CalculateSize(_repeated_tags_codec);
		if (IsHidden)
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
	public void MergeFrom(PlaylistItem other)
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
		tags_.Add(other.tags_);
		if (other.IsHidden)
		{
			IsHidden = other.IsHidden;
		}
		switch (other.ItemTypeCase)
		{
		case ItemTypeOneofCase.Header:
			if (Header == null)
			{
				Header = new Types.Header();
			}
			Header.MergeFrom(other.Header);
			break;
		case ItemTypeOneofCase.Presentation:
			if (Presentation == null)
			{
				Presentation = new Types.Presentation();
			}
			Presentation.MergeFrom(other.Presentation);
			break;
		case ItemTypeOneofCase.Cue:
			if (Cue == null)
			{
				Cue = new Cue();
			}
			Cue.MergeFrom(other.Cue);
			break;
		case ItemTypeOneofCase.PlanningCenter:
			if (PlanningCenter == null)
			{
				PlanningCenter = new Types.PlanningCenter();
			}
			PlanningCenter.MergeFrom(other.PlanningCenter);
			break;
		case ItemTypeOneofCase.Placeholder:
			if (Placeholder == null)
			{
				Placeholder = new Types.Placeholder();
			}
			Placeholder.MergeFrom(other.Placeholder);
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
			{
				Types.Header header = new Types.Header();
				if (itemTypeCase_ == ItemTypeOneofCase.Header)
				{
					header.MergeFrom(Header);
				}
				input.ReadMessage(header);
				Header = header;
				break;
			}
			case 34u:
			{
				Types.Presentation presentation = new Types.Presentation();
				if (itemTypeCase_ == ItemTypeOneofCase.Presentation)
				{
					presentation.MergeFrom(Presentation);
				}
				input.ReadMessage(presentation);
				Presentation = presentation;
				break;
			}
			case 42u:
			{
				Cue cue = new Cue();
				if (itemTypeCase_ == ItemTypeOneofCase.Cue)
				{
					cue.MergeFrom(Cue);
				}
				input.ReadMessage(cue);
				Cue = cue;
				break;
			}
			case 50u:
			{
				Types.PlanningCenter planningCenter = new Types.PlanningCenter();
				if (itemTypeCase_ == ItemTypeOneofCase.PlanningCenter)
				{
					planningCenter.MergeFrom(PlanningCenter);
				}
				input.ReadMessage(planningCenter);
				PlanningCenter = planningCenter;
				break;
			}
			case 58u:
				tags_.AddEntriesFrom(input, _repeated_tags_codec);
				break;
			case 66u:
			{
				Types.Placeholder placeholder = new Types.Placeholder();
				if (itemTypeCase_ == ItemTypeOneofCase.Placeholder)
				{
					placeholder.MergeFrom(Placeholder);
				}
				input.ReadMessage(placeholder);
				Placeholder = placeholder;
				break;
			}
			case 72u:
				IsHidden = input.ReadBool();
				break;
			}
		}
	}
}
