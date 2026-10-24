using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
{
	public enum ChildrenTypeOneofCase
	{
		None = 0,
		Playlists = 12,
		Items = 13
	}

	public enum LinkDataOneofCase
	{
		None = 0,
		SmartDirectory = 14,
		PcoPlan = 15
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("TYPE_PLAYLIST")]
			Playlist,
			[OriginalName("TYPE_GROUP")]
			Group,
			[OriginalName("TYPE_SMART")]
			Smart,
			[OriginalName("TYPE_ROOT")]
			Root
		}

		public enum TimingType
		{
			[OriginalName("TIMING_TYPE_NONE")]
			None,
			[OriginalName("TIMING_TYPE_TIMECODE")]
			Timecode,
			[OriginalName("TIMING_TYPE_TIME_OF_DAY")]
			TimeOfDay
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlaylistArray : IMessage<PlaylistArray>, IMessage, IEquatable<PlaylistArray>, IDeepCloneable<PlaylistArray>
		{
			private static readonly MessageParser<PlaylistArray> _parser = new MessageParser<PlaylistArray>(() => new PlaylistArray());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistsFieldNumber = 1;

			private static readonly FieldCodec<Playlist> _repeated_playlists_codec = FieldCodec.ForMessage(10u, Playlist.Parser);

			private readonly RepeatedField<Playlist> playlists_ = new RepeatedField<Playlist>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistArray> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Playlist.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Playlist> Playlists => playlists_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistArray()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistArray(PlaylistArray other)
				: this()
			{
				playlists_ = other.playlists_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistArray Clone()
			{
				return new PlaylistArray(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistArray);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistArray other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!playlists_.Equals(other.playlists_))
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
				num ^= playlists_.GetHashCode();
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
				playlists_.WriteTo(output, _repeated_playlists_codec);
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
				num += playlists_.CalculateSize(_repeated_playlists_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PlaylistArray other)
			{
				if (other != null)
				{
					playlists_.Add(other.playlists_);
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
						playlists_.AddEntriesFrom(input, _repeated_playlists_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlaylistItems : IMessage<PlaylistItems>, IMessage, IEquatable<PlaylistItems>, IDeepCloneable<PlaylistItems>
		{
			private static readonly MessageParser<PlaylistItems> _parser = new MessageParser<PlaylistItems>(() => new PlaylistItems());

			private UnknownFieldSet _unknownFields;

			public const int ItemsFieldNumber = 1;

			private static readonly FieldCodec<PlaylistItem> _repeated_items_codec = FieldCodec.ForMessage(10u, PlaylistItem.Parser);

			private readonly RepeatedField<PlaylistItem> items_ = new RepeatedField<PlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistItems> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Playlist.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<PlaylistItem> Items => items_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItems()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItems(PlaylistItems other)
				: this()
			{
				items_ = other.items_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistItems Clone()
			{
				return new PlaylistItems(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistItems);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistItems other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!items_.Equals(other.items_))
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
				num ^= items_.GetHashCode();
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
				items_.WriteTo(output, _repeated_items_codec);
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
				num += items_.CalculateSize(_repeated_items_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PlaylistItems other)
			{
				if (other != null)
				{
					items_.Add(other.items_);
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
						items_.AddEntriesFrom(input, _repeated_items_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FolderDirectory : IMessage<FolderDirectory>, IMessage, IEquatable<FolderDirectory>, IDeepCloneable<FolderDirectory>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ImportBehavior
				{
					[OriginalName("IMPORT_BEHAVIOR_BACKGROUND")]
					Background,
					[OriginalName("IMPORT_BEHAVIOR_FOREGROUND")]
					Foreground
				}
			}

			private static readonly MessageParser<FolderDirectory> _parser = new MessageParser<FolderDirectory>(() => new FolderDirectory());

			private UnknownFieldSet _unknownFields;

			public const int SmartDirectoryFieldNumber = 1;

			private URL smartDirectory_;

			public const int ImportBehaviorFieldNumber = 2;

			private Types.ImportBehavior importBehavior_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FolderDirectory> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Playlist.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL SmartDirectory
			{
				get
				{
					return smartDirectory_;
				}
				set
				{
					smartDirectory_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ImportBehavior ImportBehavior
			{
				get
				{
					return importBehavior_;
				}
				set
				{
					importBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FolderDirectory()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FolderDirectory(FolderDirectory other)
				: this()
			{
				smartDirectory_ = ((other.smartDirectory_ != null) ? other.smartDirectory_.Clone() : null);
				importBehavior_ = other.importBehavior_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FolderDirectory Clone()
			{
				return new FolderDirectory(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FolderDirectory);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FolderDirectory other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(SmartDirectory, other.SmartDirectory))
				{
					return false;
				}
				if (ImportBehavior != other.ImportBehavior)
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
				if (smartDirectory_ != null)
				{
					num ^= SmartDirectory.GetHashCode();
				}
				if (ImportBehavior != 0)
				{
					num ^= ImportBehavior.GetHashCode();
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
				if (smartDirectory_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(SmartDirectory);
				}
				if (ImportBehavior != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)ImportBehavior);
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
				if (smartDirectory_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SmartDirectory);
				}
				if (ImportBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ImportBehavior);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FolderDirectory other)
			{
				if (other == null)
				{
					return;
				}
				if (other.smartDirectory_ != null)
				{
					if (smartDirectory_ == null)
					{
						SmartDirectory = new URL();
					}
					SmartDirectory.MergeFrom(other.SmartDirectory);
				}
				if (other.ImportBehavior != 0)
				{
					ImportBehavior = other.ImportBehavior;
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
						if (smartDirectory_ == null)
						{
							SmartDirectory = new URL();
						}
						input.ReadMessage(SmartDirectory);
						break;
					case 16u:
						ImportBehavior = (Types.ImportBehavior)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Tag : IMessage<Tag>, IMessage, IEquatable<Tag>, IDeepCloneable<Tag>
		{
			private static readonly MessageParser<Tag> _parser = new MessageParser<Tag>(() => new Tag());

			private UnknownFieldSet _unknownFields;

			public const int ColorFieldNumber = 1;

			private Color color_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int UuidFieldNumber = 3;

			private UUID uuid_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Tag> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Playlist.Descriptor.NestedTypes[3];

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
			public Tag()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Tag(Tag other)
				: this()
			{
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				name_ = other.name_;
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Tag Clone()
			{
				return new Tag(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Tag);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Tag other)
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
				if (Name != other.Name)
				{
					return false;
				}
				if (!object.Equals(Uuid, other.Uuid))
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
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
				if (color_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Color);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (uuid_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Uuid);
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
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Tag other)
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
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
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
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StartupInfo : IMessage<StartupInfo>, IMessage, IEquatable<StartupInfo>, IDeepCloneable<StartupInfo>
		{
			private static readonly MessageParser<StartupInfo> _parser = new MessageParser<StartupInfo>(() => new StartupInfo());

			private UnknownFieldSet _unknownFields;

			public const int TriggerOnStartupFieldNumber = 1;

			private bool triggerOnStartup_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StartupInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Playlist.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public StartupInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StartupInfo(StartupInfo other)
				: this()
			{
				triggerOnStartup_ = other.triggerOnStartup_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StartupInfo Clone()
			{
				return new StartupInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StartupInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StartupInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (TriggerOnStartup != other.TriggerOnStartup)
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
				if (TriggerOnStartup)
				{
					num ^= TriggerOnStartup.GetHashCode();
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
				if (TriggerOnStartup)
				{
					output.WriteRawTag(8);
					output.WriteBool(TriggerOnStartup);
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
				if (TriggerOnStartup)
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
			public void MergeFrom(StartupInfo other)
			{
				if (other != null)
				{
					if (other.TriggerOnStartup)
					{
						TriggerOnStartup = other.TriggerOnStartup;
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
						TriggerOnStartup = input.ReadBool();
					}
				}
			}
		}
	}

	private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int TypeFieldNumber = 3;

	private Types.Type type_;

	public const int ExpandedFieldNumber = 4;

	private bool expanded_;

	public const int TargetedLayerUuidFieldNumber = 5;

	private UUID targetedLayerUuid_;

	public const int SmartDirectoryPathFieldNumber = 6;

	private URL smartDirectoryPath_;

	public const int HotKeyFieldNumber = 7;

	private HotKey hotKey_;

	public const int CuesFieldNumber = 8;

	private static readonly FieldCodec<Cue> _repeated_cues_codec = FieldCodec.ForMessage(66u, Cue.Parser);

	private readonly RepeatedField<Cue> cues_ = new RepeatedField<Cue>();

	public const int ChildrenFieldNumber = 9;

	private static readonly FieldCodec<Playlist> _repeated_children_codec = FieldCodec.ForMessage(74u, Parser);

	private readonly RepeatedField<Playlist> children_ = new RepeatedField<Playlist>();

	public const int TimecodeEnabledFieldNumber = 10;

	private bool timecodeEnabled_;

	public const int TimingFieldNumber = 11;

	private Types.TimingType timing_;

	public const int PlaylistsFieldNumber = 12;

	public const int ItemsFieldNumber = 13;

	public const int SmartDirectoryFieldNumber = 14;

	public const int PcoPlanFieldNumber = 15;

	public const int StartupInfoFieldNumber = 16;

	private Types.StartupInfo startupInfo_;

	private object childrenType_;

	private ChildrenTypeOneofCase childrenTypeCase_;

	private object linkData_;

	private LinkDataOneofCase linkDataCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Playlist> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PlaylistReflection.Descriptor.MessageTypes[0];

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
	public bool Expanded
	{
		get
		{
			return expanded_;
		}
		set
		{
			expanded_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID TargetedLayerUuid
	{
		get
		{
			return targetedLayerUuid_;
		}
		set
		{
			targetedLayerUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL SmartDirectoryPath
	{
		get
		{
			return smartDirectoryPath_;
		}
		set
		{
			smartDirectoryPath_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HotKey HotKey
	{
		get
		{
			return hotKey_;
		}
		set
		{
			hotKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Cue> Cues => cues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Playlist> Children => children_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool TimecodeEnabled
	{
		get
		{
			return timecodeEnabled_;
		}
		set
		{
			timecodeEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimingType Timing
	{
		get
		{
			return timing_;
		}
		set
		{
			timing_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistArray Playlists
	{
		get
		{
			if (childrenTypeCase_ != ChildrenTypeOneofCase.Playlists)
			{
				return null;
			}
			return (Types.PlaylistArray)childrenType_;
		}
		set
		{
			childrenType_ = value;
			childrenTypeCase_ = ((value != null) ? ChildrenTypeOneofCase.Playlists : ChildrenTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistItems Items
	{
		get
		{
			if (childrenTypeCase_ != ChildrenTypeOneofCase.Items)
			{
				return null;
			}
			return (Types.PlaylistItems)childrenType_;
		}
		set
		{
			childrenType_ = value;
			childrenTypeCase_ = ((value != null) ? ChildrenTypeOneofCase.Items : ChildrenTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FolderDirectory SmartDirectory
	{
		get
		{
			if (linkDataCase_ != LinkDataOneofCase.SmartDirectory)
			{
				return null;
			}
			return (Types.FolderDirectory)linkData_;
		}
		set
		{
			linkData_ = value;
			linkDataCase_ = ((value != null) ? LinkDataOneofCase.SmartDirectory : LinkDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlanningCenterPlan PcoPlan
	{
		get
		{
			if (linkDataCase_ != LinkDataOneofCase.PcoPlan)
			{
				return null;
			}
			return (PlanningCenterPlan)linkData_;
		}
		set
		{
			linkData_ = value;
			linkDataCase_ = ((value != null) ? LinkDataOneofCase.PcoPlan : LinkDataOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StartupInfo StartupInfo
	{
		get
		{
			return startupInfo_;
		}
		set
		{
			startupInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChildrenTypeOneofCase ChildrenTypeCase => childrenTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LinkDataOneofCase LinkDataCase => linkDataCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist(Playlist other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		type_ = other.type_;
		expanded_ = other.expanded_;
		targetedLayerUuid_ = ((other.targetedLayerUuid_ != null) ? other.targetedLayerUuid_.Clone() : null);
		smartDirectoryPath_ = ((other.smartDirectoryPath_ != null) ? other.smartDirectoryPath_.Clone() : null);
		hotKey_ = ((other.hotKey_ != null) ? other.hotKey_.Clone() : null);
		cues_ = other.cues_.Clone();
		children_ = other.children_.Clone();
		timecodeEnabled_ = other.timecodeEnabled_;
		timing_ = other.timing_;
		startupInfo_ = ((other.startupInfo_ != null) ? other.startupInfo_.Clone() : null);
		switch (other.ChildrenTypeCase)
		{
		case ChildrenTypeOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case ChildrenTypeOneofCase.Items:
			Items = other.Items.Clone();
			break;
		}
		switch (other.LinkDataCase)
		{
		case LinkDataOneofCase.SmartDirectory:
			SmartDirectory = other.SmartDirectory.Clone();
			break;
		case LinkDataOneofCase.PcoPlan:
			PcoPlan = other.PcoPlan.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist Clone()
	{
		return new Playlist(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearChildrenType()
	{
		childrenTypeCase_ = ChildrenTypeOneofCase.None;
		childrenType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearLinkData()
	{
		linkDataCase_ = LinkDataOneofCase.None;
		linkData_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Playlist);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Playlist other)
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
		if (Type != other.Type)
		{
			return false;
		}
		if (Expanded != other.Expanded)
		{
			return false;
		}
		if (!object.Equals(TargetedLayerUuid, other.TargetedLayerUuid))
		{
			return false;
		}
		if (!object.Equals(SmartDirectoryPath, other.SmartDirectoryPath))
		{
			return false;
		}
		if (!object.Equals(HotKey, other.HotKey))
		{
			return false;
		}
		if (!cues_.Equals(other.cues_))
		{
			return false;
		}
		if (!children_.Equals(other.children_))
		{
			return false;
		}
		if (TimecodeEnabled != other.TimecodeEnabled)
		{
			return false;
		}
		if (Timing != other.Timing)
		{
			return false;
		}
		if (!object.Equals(Playlists, other.Playlists))
		{
			return false;
		}
		if (!object.Equals(Items, other.Items))
		{
			return false;
		}
		if (!object.Equals(SmartDirectory, other.SmartDirectory))
		{
			return false;
		}
		if (!object.Equals(PcoPlan, other.PcoPlan))
		{
			return false;
		}
		if (!object.Equals(StartupInfo, other.StartupInfo))
		{
			return false;
		}
		if (ChildrenTypeCase != other.ChildrenTypeCase)
		{
			return false;
		}
		if (LinkDataCase != other.LinkDataCase)
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (Expanded)
		{
			num ^= Expanded.GetHashCode();
		}
		if (targetedLayerUuid_ != null)
		{
			num ^= TargetedLayerUuid.GetHashCode();
		}
		if (smartDirectoryPath_ != null)
		{
			num ^= SmartDirectoryPath.GetHashCode();
		}
		if (hotKey_ != null)
		{
			num ^= HotKey.GetHashCode();
		}
		num ^= cues_.GetHashCode();
		num ^= children_.GetHashCode();
		if (TimecodeEnabled)
		{
			num ^= TimecodeEnabled.GetHashCode();
		}
		if (Timing != 0)
		{
			num ^= Timing.GetHashCode();
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Playlists)
		{
			num ^= Playlists.GetHashCode();
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Items)
		{
			num ^= Items.GetHashCode();
		}
		if (linkDataCase_ == LinkDataOneofCase.SmartDirectory)
		{
			num ^= SmartDirectory.GetHashCode();
		}
		if (linkDataCase_ == LinkDataOneofCase.PcoPlan)
		{
			num ^= PcoPlan.GetHashCode();
		}
		if (startupInfo_ != null)
		{
			num ^= StartupInfo.GetHashCode();
		}
		num ^= (int)childrenTypeCase_;
		num ^= (int)linkDataCase_;
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
		if (Type != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Type);
		}
		if (Expanded)
		{
			output.WriteRawTag(32);
			output.WriteBool(Expanded);
		}
		if (targetedLayerUuid_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TargetedLayerUuid);
		}
		if (smartDirectoryPath_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(SmartDirectoryPath);
		}
		if (hotKey_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(HotKey);
		}
		cues_.WriteTo(output, _repeated_cues_codec);
		children_.WriteTo(output, _repeated_children_codec);
		if (TimecodeEnabled)
		{
			output.WriteRawTag(80);
			output.WriteBool(TimecodeEnabled);
		}
		if (Timing != 0)
		{
			output.WriteRawTag(88);
			output.WriteEnum((int)Timing);
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Playlists)
		{
			output.WriteRawTag(98);
			output.WriteMessage(Playlists);
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Items)
		{
			output.WriteRawTag(106);
			output.WriteMessage(Items);
		}
		if (linkDataCase_ == LinkDataOneofCase.SmartDirectory)
		{
			output.WriteRawTag(114);
			output.WriteMessage(SmartDirectory);
		}
		if (linkDataCase_ == LinkDataOneofCase.PcoPlan)
		{
			output.WriteRawTag(122);
			output.WriteMessage(PcoPlan);
		}
		if (startupInfo_ != null)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(StartupInfo);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (Expanded)
		{
			num += 2;
		}
		if (targetedLayerUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TargetedLayerUuid);
		}
		if (smartDirectoryPath_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SmartDirectoryPath);
		}
		if (hotKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HotKey);
		}
		num += cues_.CalculateSize(_repeated_cues_codec);
		num += children_.CalculateSize(_repeated_children_codec);
		if (TimecodeEnabled)
		{
			num += 2;
		}
		if (Timing != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Timing);
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Playlists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlists);
		}
		if (childrenTypeCase_ == ChildrenTypeOneofCase.Items)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Items);
		}
		if (linkDataCase_ == LinkDataOneofCase.SmartDirectory)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SmartDirectory);
		}
		if (linkDataCase_ == LinkDataOneofCase.PcoPlan)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PcoPlan);
		}
		if (startupInfo_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupInfo);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Playlist other)
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
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		if (other.Expanded)
		{
			Expanded = other.Expanded;
		}
		if (other.targetedLayerUuid_ != null)
		{
			if (targetedLayerUuid_ == null)
			{
				TargetedLayerUuid = new UUID();
			}
			TargetedLayerUuid.MergeFrom(other.TargetedLayerUuid);
		}
		if (other.smartDirectoryPath_ != null)
		{
			if (smartDirectoryPath_ == null)
			{
				SmartDirectoryPath = new URL();
			}
			SmartDirectoryPath.MergeFrom(other.SmartDirectoryPath);
		}
		if (other.hotKey_ != null)
		{
			if (hotKey_ == null)
			{
				HotKey = new HotKey();
			}
			HotKey.MergeFrom(other.HotKey);
		}
		cues_.Add(other.cues_);
		children_.Add(other.children_);
		if (other.TimecodeEnabled)
		{
			TimecodeEnabled = other.TimecodeEnabled;
		}
		if (other.Timing != 0)
		{
			Timing = other.Timing;
		}
		if (other.startupInfo_ != null)
		{
			if (startupInfo_ == null)
			{
				StartupInfo = new Types.StartupInfo();
			}
			StartupInfo.MergeFrom(other.StartupInfo);
		}
		switch (other.ChildrenTypeCase)
		{
		case ChildrenTypeOneofCase.Playlists:
			if (Playlists == null)
			{
				Playlists = new Types.PlaylistArray();
			}
			Playlists.MergeFrom(other.Playlists);
			break;
		case ChildrenTypeOneofCase.Items:
			if (Items == null)
			{
				Items = new Types.PlaylistItems();
			}
			Items.MergeFrom(other.Items);
			break;
		}
		switch (other.LinkDataCase)
		{
		case LinkDataOneofCase.SmartDirectory:
			if (SmartDirectory == null)
			{
				SmartDirectory = new Types.FolderDirectory();
			}
			SmartDirectory.MergeFrom(other.SmartDirectory);
			break;
		case LinkDataOneofCase.PcoPlan:
			if (PcoPlan == null)
			{
				PcoPlan = new PlanningCenterPlan();
			}
			PcoPlan.MergeFrom(other.PcoPlan);
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
			case 24u:
				Type = (Types.Type)input.ReadEnum();
				break;
			case 32u:
				Expanded = input.ReadBool();
				break;
			case 42u:
				if (targetedLayerUuid_ == null)
				{
					TargetedLayerUuid = new UUID();
				}
				input.ReadMessage(TargetedLayerUuid);
				break;
			case 50u:
				if (smartDirectoryPath_ == null)
				{
					SmartDirectoryPath = new URL();
				}
				input.ReadMessage(SmartDirectoryPath);
				break;
			case 58u:
				if (hotKey_ == null)
				{
					HotKey = new HotKey();
				}
				input.ReadMessage(HotKey);
				break;
			case 66u:
				cues_.AddEntriesFrom(input, _repeated_cues_codec);
				break;
			case 74u:
				children_.AddEntriesFrom(input, _repeated_children_codec);
				break;
			case 80u:
				TimecodeEnabled = input.ReadBool();
				break;
			case 88u:
				Timing = (Types.TimingType)input.ReadEnum();
				break;
			case 98u:
			{
				Types.PlaylistArray playlistArray = new Types.PlaylistArray();
				if (childrenTypeCase_ == ChildrenTypeOneofCase.Playlists)
				{
					playlistArray.MergeFrom(Playlists);
				}
				input.ReadMessage(playlistArray);
				Playlists = playlistArray;
				break;
			}
			case 106u:
			{
				Types.PlaylistItems playlistItems = new Types.PlaylistItems();
				if (childrenTypeCase_ == ChildrenTypeOneofCase.Items)
				{
					playlistItems.MergeFrom(Items);
				}
				input.ReadMessage(playlistItems);
				Items = playlistItems;
				break;
			}
			case 114u:
			{
				Types.FolderDirectory folderDirectory = new Types.FolderDirectory();
				if (linkDataCase_ == LinkDataOneofCase.SmartDirectory)
				{
					folderDirectory.MergeFrom(SmartDirectory);
				}
				input.ReadMessage(folderDirectory);
				SmartDirectory = folderDirectory;
				break;
			}
			case 122u:
			{
				PlanningCenterPlan planningCenterPlan = new PlanningCenterPlan();
				if (linkDataCase_ == LinkDataOneofCase.PcoPlan)
				{
					planningCenterPlan.MergeFrom(PcoPlan);
				}
				input.ReadMessage(planningCenterPlan);
				PcoPlan = planningCenterPlan;
				break;
			}
			case 130u:
				if (startupInfo_ == null)
				{
					StartupInfo = new Types.StartupInfo();
				}
				input.ReadMessage(StartupInfo);
				break;
			}
		}
	}
}
