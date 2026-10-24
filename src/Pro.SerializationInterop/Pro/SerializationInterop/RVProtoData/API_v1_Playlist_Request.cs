using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Playlist_Request : IMessage<API_v1_Playlist_Request>, IMessage, IEquatable<API_v1_Playlist_Request>, IDeepCloneable<API_v1_Playlist_Request>
{
	public enum RequestOneofCase
	{
		None,
		Playlists,
		CreatePlaylist,
		GetPlaylist,
		PutPlaylist,
		PostPlaylist,
		GetActivePlaylist,
		Focused,
		NextFocus,
		PreviousFocus,
		ActivePresentationFocus,
		ActiveAnnouncementFocus,
		FocusedTrigger,
		ActivePresentationTrigger,
		ActiveAnnouncementTrigger,
		FocusedNextTrigger,
		FocusedPreviousTrigger,
		ActivePresentationNextTrigger,
		ActiveAnnouncementNextTrigger,
		ActivePresentationPreviousTrigger,
		ActiveAnnouncementPreviousTrigger,
		IdFocus,
		IdTrigger,
		IdNextTrigger,
		IdPreviousTrigger,
		FocusedIndexTrigger,
		ActivePresentationIndexTrigger,
		ActiveAnnouncementIndexTrigger,
		IdUpdates,
		ActivePresentationThumbnail,
		ActiveAnnouncementThumbnail,
		FocusedNext,
		FocusedPrevious,
		IdThumbnail,
		TimelineOperation,
		ActivePlaylistPresentationTimelineOperation,
		ActivePlaylistAnnouncementTimelineOperation,
		FocusedPlaylistTimelineOperation,
		ActivePlaylistPresentationTimelineStatus,
		ActivePlaylistAnnouncementTimelineStatus,
		FocusedPlaylistTimelineStatus
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Playlists : IMessage<Playlists>, IMessage, IEquatable<Playlists>, IDeepCloneable<Playlists>
		{
			private static readonly MessageParser<Playlists> _parser = new MessageParser<Playlists>(() => new Playlists());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlists> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlists()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlists(Playlists other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlists Clone()
			{
				return new Playlists(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Playlists);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Playlists other)
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
			public void MergeFrom(Playlists other)
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
		public sealed class CreatePlaylist : IMessage<CreatePlaylist>, IMessage, IEquatable<CreatePlaylist>, IDeepCloneable<CreatePlaylist>
		{
			private static readonly MessageParser<CreatePlaylist> _parser = new MessageParser<CreatePlaylist>(() => new CreatePlaylist());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int TypeFieldNumber = 2;

			private API_v1_Playlist.Types.API_v1_PlaylistType type_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreatePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[1];

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
			public API_v1_Playlist.Types.API_v1_PlaylistType Type
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
			public CreatePlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreatePlaylist(CreatePlaylist other)
				: this()
			{
				name_ = other.name_;
				type_ = other.type_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreatePlaylist Clone()
			{
				return new CreatePlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CreatePlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CreatePlaylist other)
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
				if (Type != other.Type)
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
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
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
				if (Type != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Type);
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
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CreatePlaylist other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Type != 0)
					{
						Type = other.Type;
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
					case 16u:
						Type = (API_v1_Playlist.Types.API_v1_PlaylistType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetActivePlaylist : IMessage<GetActivePlaylist>, IMessage, IEquatable<GetActivePlaylist>, IDeepCloneable<GetActivePlaylist>
		{
			private static readonly MessageParser<GetActivePlaylist> _parser = new MessageParser<GetActivePlaylist>(() => new GetActivePlaylist());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetActivePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetActivePlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetActivePlaylist(GetActivePlaylist other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetActivePlaylist Clone()
			{
				return new GetActivePlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetActivePlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetActivePlaylist other)
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
			public void MergeFrom(GetActivePlaylist other)
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
		public sealed class GetPlaylist : IMessage<GetPlaylist>, IMessage, IEquatable<GetPlaylist>, IDeepCloneable<GetPlaylist>
		{
			private static readonly MessageParser<GetPlaylist> _parser = new MessageParser<GetPlaylist>(() => new GetPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylist(GetPlaylist other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylist Clone()
			{
				return new GetPlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPlaylist other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetPlaylist other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutPlaylist : IMessage<PutPlaylist>, IMessage, IEquatable<PutPlaylist>, IDeepCloneable<PutPlaylist>
		{
			private static readonly MessageParser<PutPlaylist> _parser = new MessageParser<PutPlaylist>(() => new PutPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ItemsFieldNumber = 2;

			private static readonly FieldCodec<API_v1_PlaylistItem> _repeated_items_codec = FieldCodec.ForMessage(18u, API_v1_PlaylistItem.Parser);

			private readonly RepeatedField<API_v1_PlaylistItem> items_ = new RepeatedField<API_v1_PlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_PlaylistItem> Items => items_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPlaylist(PutPlaylist other)
				: this()
			{
				id_ = other.id_;
				items_ = other.items_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPlaylist Clone()
			{
				return new PutPlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutPlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutPlaylist other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				num += items_.CalculateSize(_repeated_items_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutPlaylist other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						Id = input.ReadString();
						break;
					case 18u:
						items_.AddEntriesFrom(input, _repeated_items_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PostPlaylist : IMessage<PostPlaylist>, IMessage, IEquatable<PostPlaylist>, IDeepCloneable<PostPlaylist>
		{
			private static readonly MessageParser<PostPlaylist> _parser = new MessageParser<PostPlaylist>(() => new PostPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int TypeFieldNumber = 3;

			private API_v1_Playlist.Types.API_v1_PlaylistType type_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public API_v1_Playlist.Types.API_v1_PlaylistType Type
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
			public PostPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPlaylist(PostPlaylist other)
				: this()
			{
				id_ = other.id_;
				name_ = other.name_;
				type_ = other.type_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPlaylist Clone()
			{
				return new PostPlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PostPlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PostPlaylist other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PostPlaylist other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Type != 0)
					{
						Type = other.Type;
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
						Id = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 24u:
						Type = (API_v1_Playlist.Types.API_v1_PlaylistType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Thumbnail : IMessage<Thumbnail>, IMessage, IEquatable<Thumbnail>, IDeepCloneable<Thumbnail>
		{
			private static readonly MessageParser<Thumbnail> _parser = new MessageParser<Thumbnail>(() => new Thumbnail());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int CueIndexFieldNumber = 2;

			private uint cueIndex_;

			public const int QualityFieldNumber = 3;

			private int quality_;

			public const int ContentTypeFieldNumber = 4;

			private API_v1_ContentType contentType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Thumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[6];

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
			public uint CueIndex
			{
				get
				{
					return cueIndex_;
				}
				set
				{
					cueIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ContentType ContentType
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
			public Thumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Thumbnail(Thumbnail other)
				: this()
			{
				index_ = other.index_;
				cueIndex_ = other.cueIndex_;
				quality_ = other.quality_;
				contentType_ = other.contentType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Thumbnail Clone()
			{
				return new Thumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Thumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Thumbnail other)
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
				if (CueIndex != other.CueIndex)
				{
					return false;
				}
				if (Quality != other.Quality)
				{
					return false;
				}
				if (ContentType != other.ContentType)
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
				if (CueIndex != 0)
				{
					num ^= CueIndex.GetHashCode();
				}
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
				}
				if (ContentType != 0)
				{
					num ^= ContentType.GetHashCode();
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
					output.WriteUInt32(Index);
				}
				if (CueIndex != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(CueIndex);
				}
				if (Quality != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Quality);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)ContentType);
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
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (CueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(CueIndex);
				}
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (ContentType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Thumbnail other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.CueIndex != 0)
					{
						CueIndex = other.CueIndex;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
					}
					if (other.ContentType != 0)
					{
						ContentType = other.ContentType;
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
						Index = input.ReadUInt32();
						break;
					case 16u:
						CueIndex = input.ReadUInt32();
						break;
					case 24u:
						Quality = input.ReadInt32();
						break;
					case 32u:
						ContentType = (API_v1_ContentType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class IdThumbnail : IMessage<IdThumbnail>, IMessage, IEquatable<IdThumbnail>, IDeepCloneable<IdThumbnail>
		{
			private static readonly MessageParser<IdThumbnail> _parser = new MessageParser<IdThumbnail>(() => new IdThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int IndexFieldNumber = 2;

			private uint index_;

			public const int CueIndexFieldNumber = 3;

			private uint cueIndex_;

			public const int QualityFieldNumber = 4;

			private int quality_;

			public const int ContentTypeFieldNumber = 5;

			private API_v1_ContentType contentType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IdThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
			public uint CueIndex
			{
				get
				{
					return cueIndex_;
				}
				set
				{
					cueIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ContentType ContentType
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
			public IdThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdThumbnail(IdThumbnail other)
				: this()
			{
				id_ = other.id_;
				index_ = other.index_;
				cueIndex_ = other.cueIndex_;
				quality_ = other.quality_;
				contentType_ = other.contentType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdThumbnail Clone()
			{
				return new IdThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IdThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IdThumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (CueIndex != other.CueIndex)
				{
					return false;
				}
				if (Quality != other.Quality)
				{
					return false;
				}
				if (ContentType != other.ContentType)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
				}
				if (CueIndex != 0)
				{
					num ^= CueIndex.GetHashCode();
				}
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
				}
				if (ContentType != 0)
				{
					num ^= ContentType.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Index != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Index);
				}
				if (CueIndex != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(CueIndex);
				}
				if (Quality != 0)
				{
					output.WriteRawTag(32);
					output.WriteInt32(Quality);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)ContentType);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (CueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(CueIndex);
				}
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (ContentType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(IdThumbnail other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.CueIndex != 0)
					{
						CueIndex = other.CueIndex;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
					}
					if (other.ContentType != 0)
					{
						ContentType = other.ContentType;
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
						Id = input.ReadString();
						break;
					case 16u:
						Index = input.ReadUInt32();
						break;
					case 24u:
						CueIndex = input.ReadUInt32();
						break;
					case 32u:
						Quality = input.ReadInt32();
						break;
					case 40u:
						ContentType = (API_v1_ContentType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EmptyMessage : IMessage<EmptyMessage>, IMessage, IEquatable<EmptyMessage>, IDeepCloneable<EmptyMessage>
		{
			private static readonly MessageParser<EmptyMessage> _parser = new MessageParser<EmptyMessage>(() => new EmptyMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EmptyMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage(EmptyMessage other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Clone()
			{
				return new EmptyMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EmptyMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EmptyMessage other)
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
			public void MergeFrom(EmptyMessage other)
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
		public sealed class IdMessage : IMessage<IdMessage>, IMessage, IEquatable<IdMessage>, IDeepCloneable<IdMessage>
		{
			private static readonly MessageParser<IdMessage> _parser = new MessageParser<IdMessage>(() => new IdMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IdMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdMessage(IdMessage other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdMessage Clone()
			{
				return new IdMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IdMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IdMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(IdMessage other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class IndexMessage : IMessage<IndexMessage>, IMessage, IEquatable<IndexMessage>, IDeepCloneable<IndexMessage>
		{
			private static readonly MessageParser<IndexMessage> _parser = new MessageParser<IndexMessage>(() => new IndexMessage());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int CueIndexFieldNumber = 2;

			private uint cueIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IndexMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[10];

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
			public uint CueIndex
			{
				get
				{
					return cueIndex_;
				}
				set
				{
					cueIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexMessage(IndexMessage other)
				: this()
			{
				index_ = other.index_;
				cueIndex_ = other.cueIndex_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexMessage Clone()
			{
				return new IndexMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IndexMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IndexMessage other)
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
				if (CueIndex != other.CueIndex)
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
				if (CueIndex != 0)
				{
					num ^= CueIndex.GetHashCode();
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
					output.WriteUInt32(Index);
				}
				if (CueIndex != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(CueIndex);
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
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (CueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(CueIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(IndexMessage other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.CueIndex != 0)
					{
						CueIndex = other.CueIndex;
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
						Index = input.ReadUInt32();
						break;
					case 16u:
						CueIndex = input.ReadUInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimelineOperation : IMessage<TimelineOperation>, IMessage, IEquatable<TimelineOperation>, IDeepCloneable<TimelineOperation>
		{
			private static readonly MessageParser<TimelineOperation> _parser = new MessageParser<TimelineOperation>(() => new TimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int IndexFieldNumber = 2;

			private uint index_;

			public const int OperationFieldNumber = 3;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation(TimelineOperation other)
				: this()
			{
				id_ = other.id_;
				index_ = other.index_;
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation Clone()
			{
				return new TimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimelineOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (Operation != other.Operation)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
				}
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Index != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Index);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)Operation);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimelineOperation other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
						Id = input.ReadString();
						break;
					case 16u:
						Index = input.ReadUInt32();
						break;
					case 24u:
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivePlaylistTimelineOperation : IMessage<ActivePlaylistTimelineOperation>, IMessage, IEquatable<ActivePlaylistTimelineOperation>, IDeepCloneable<ActivePlaylistTimelineOperation>
		{
			private static readonly MessageParser<ActivePlaylistTimelineOperation> _parser = new MessageParser<ActivePlaylistTimelineOperation>(() => new ActivePlaylistTimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int OperationFieldNumber = 2;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePlaylistTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[12];

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
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylistTimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylistTimelineOperation(ActivePlaylistTimelineOperation other)
				: this()
			{
				index_ = other.index_;
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylistTimelineOperation Clone()
			{
				return new ActivePlaylistTimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePlaylistTimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePlaylistTimelineOperation other)
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
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
					output.WriteUInt32(Index);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Operation);
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
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActivePlaylistTimelineOperation other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
						Index = input.ReadUInt32();
						break;
					case 16u:
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPlaylistTimelineOperation : IMessage<FocusedPlaylistTimelineOperation>, IMessage, IEquatable<FocusedPlaylistTimelineOperation>, IDeepCloneable<FocusedPlaylistTimelineOperation>
		{
			private static readonly MessageParser<FocusedPlaylistTimelineOperation> _parser = new MessageParser<FocusedPlaylistTimelineOperation>(() => new FocusedPlaylistTimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int OperationFieldNumber = 2;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPlaylistTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[13];

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
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylistTimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylistTimelineOperation(FocusedPlaylistTimelineOperation other)
				: this()
			{
				index_ = other.index_;
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylistTimelineOperation Clone()
			{
				return new FocusedPlaylistTimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusedPlaylistTimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusedPlaylistTimelineOperation other)
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
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
					output.WriteUInt32(Index);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Operation);
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
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusedPlaylistTimelineOperation other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
						Index = input.ReadUInt32();
						break;
					case 16u:
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivePlaylistTimelineStatus : IMessage<ActivePlaylistTimelineStatus>, IMessage, IEquatable<ActivePlaylistTimelineStatus>, IDeepCloneable<ActivePlaylistTimelineStatus>
		{
			private static readonly MessageParser<ActivePlaylistTimelineStatus> _parser = new MessageParser<ActivePlaylistTimelineStatus>(() => new ActivePlaylistTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePlaylistTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[14];

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
			public ActivePlaylistTimelineStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylistTimelineStatus(ActivePlaylistTimelineStatus other)
				: this()
			{
				index_ = other.index_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylistTimelineStatus Clone()
			{
				return new ActivePlaylistTimelineStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePlaylistTimelineStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePlaylistTimelineStatus other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActivePlaylistTimelineStatus other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
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
						Index = input.ReadUInt32();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPlaylistTimelineStatus : IMessage<FocusedPlaylistTimelineStatus>, IMessage, IEquatable<FocusedPlaylistTimelineStatus>, IDeepCloneable<FocusedPlaylistTimelineStatus>
		{
			private static readonly MessageParser<FocusedPlaylistTimelineStatus> _parser = new MessageParser<FocusedPlaylistTimelineStatus>(() => new FocusedPlaylistTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPlaylistTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Request.Descriptor.NestedTypes[15];

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
			public FocusedPlaylistTimelineStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylistTimelineStatus(FocusedPlaylistTimelineStatus other)
				: this()
			{
				index_ = other.index_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylistTimelineStatus Clone()
			{
				return new FocusedPlaylistTimelineStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusedPlaylistTimelineStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusedPlaylistTimelineStatus other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusedPlaylistTimelineStatus other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
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
						Index = input.ReadUInt32();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Playlist_Request> _parser = new MessageParser<API_v1_Playlist_Request>(() => new API_v1_Playlist_Request());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	public const int CreatePlaylistFieldNumber = 2;

	public const int GetPlaylistFieldNumber = 3;

	public const int PutPlaylistFieldNumber = 4;

	public const int PostPlaylistFieldNumber = 5;

	public const int GetActivePlaylistFieldNumber = 6;

	public const int FocusedFieldNumber = 7;

	public const int NextFocusFieldNumber = 8;

	public const int PreviousFocusFieldNumber = 9;

	public const int ActivePresentationFocusFieldNumber = 10;

	public const int ActiveAnnouncementFocusFieldNumber = 11;

	public const int FocusedTriggerFieldNumber = 12;

	public const int ActivePresentationTriggerFieldNumber = 13;

	public const int ActiveAnnouncementTriggerFieldNumber = 14;

	public const int FocusedNextTriggerFieldNumber = 15;

	public const int FocusedPreviousTriggerFieldNumber = 16;

	public const int ActivePresentationNextTriggerFieldNumber = 17;

	public const int ActiveAnnouncementNextTriggerFieldNumber = 18;

	public const int ActivePresentationPreviousTriggerFieldNumber = 19;

	public const int ActiveAnnouncementPreviousTriggerFieldNumber = 20;

	public const int IdFocusFieldNumber = 21;

	public const int IdTriggerFieldNumber = 22;

	public const int IdNextTriggerFieldNumber = 23;

	public const int IdPreviousTriggerFieldNumber = 24;

	public const int FocusedIndexTriggerFieldNumber = 25;

	public const int ActivePresentationIndexTriggerFieldNumber = 26;

	public const int ActiveAnnouncementIndexTriggerFieldNumber = 27;

	public const int IdUpdatesFieldNumber = 28;

	public const int ActivePresentationThumbnailFieldNumber = 29;

	public const int ActiveAnnouncementThumbnailFieldNumber = 30;

	public const int FocusedNextFieldNumber = 31;

	public const int FocusedPreviousFieldNumber = 32;

	public const int IdThumbnailFieldNumber = 33;

	public const int TimelineOperationFieldNumber = 34;

	public const int ActivePlaylistPresentationTimelineOperationFieldNumber = 35;

	public const int ActivePlaylistAnnouncementTimelineOperationFieldNumber = 36;

	public const int FocusedPlaylistTimelineOperationFieldNumber = 37;

	public const int ActivePlaylistPresentationTimelineStatusFieldNumber = 38;

	public const int ActivePlaylistAnnouncementTimelineStatusFieldNumber = 39;

	public const int FocusedPlaylistTimelineStatusFieldNumber = 40;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Playlist_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PlaylistReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlists Playlists
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Playlists)
			{
				return null;
			}
			return (Types.Playlists)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Playlists : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreatePlaylist CreatePlaylist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CreatePlaylist)
			{
				return null;
			}
			return (Types.CreatePlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CreatePlaylist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPlaylist GetPlaylist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetPlaylist)
			{
				return null;
			}
			return (Types.GetPlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetPlaylist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutPlaylist PutPlaylist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutPlaylist)
			{
				return null;
			}
			return (Types.PutPlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutPlaylist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostPlaylist PostPlaylist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PostPlaylist)
			{
				return null;
			}
			return (Types.PostPlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PostPlaylist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetActivePlaylist GetActivePlaylist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetActivePlaylist)
			{
				return null;
			}
			return (Types.GetActivePlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetActivePlaylist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetActivePlaylist Focused
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Focused)
			{
				return null;
			}
			return (Types.GetActivePlaylist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Focused : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage NextFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.NextFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.NextFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PreviousFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PreviousFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PreviousFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdMessage IdFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdFocus)
			{
				return null;
			}
			return (Types.IdMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdMessage IdTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdTrigger)
			{
				return null;
			}
			return (Types.IdMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdMessage IdNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdNextTrigger)
			{
				return null;
			}
			return (Types.IdMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdMessage IdPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdPreviousTrigger)
			{
				return null;
			}
			return (Types.IdMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IndexMessage FocusedIndexTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedIndexTrigger)
			{
				return null;
			}
			return (Types.IndexMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedIndexTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IndexMessage ActivePresentationIndexTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationIndexTrigger)
			{
				return null;
			}
			return (Types.IndexMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationIndexTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IndexMessage ActiveAnnouncementIndexTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementIndexTrigger)
			{
				return null;
			}
			return (Types.IndexMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementIndexTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdMessage IdUpdates
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdUpdates)
			{
				return null;
			}
			return (Types.IdMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdUpdates : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail ActivePresentationThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationThumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail ActiveAnnouncementThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveAnnouncementThumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveAnnouncementThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedNext
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedNext)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedNext : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedPrevious
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPrevious)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPrevious : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdThumbnail IdThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.IdThumbnail)
			{
				return null;
			}
			return (Types.IdThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.IdThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimelineOperation TimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TimelineOperation)
			{
				return null;
			}
			return (Types.TimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineOperation ActivePlaylistPresentationTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePlaylistPresentationTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePlaylistPresentationTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineOperation ActivePlaylistAnnouncementTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPlaylistTimelineOperation FocusedPlaylistTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPlaylistTimelineOperation)
			{
				return null;
			}
			return (Types.FocusedPlaylistTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPlaylistTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineStatus ActivePlaylistPresentationTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePlaylistPresentationTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePlaylistPresentationTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineStatus ActivePlaylistAnnouncementTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPlaylistTimelineStatus FocusedPlaylistTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPlaylistTimelineStatus)
			{
				return null;
			}
			return (Types.FocusedPlaylistTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPlaylistTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Request(API_v1_Playlist_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case RequestOneofCase.CreatePlaylist:
			CreatePlaylist = other.CreatePlaylist.Clone();
			break;
		case RequestOneofCase.GetPlaylist:
			GetPlaylist = other.GetPlaylist.Clone();
			break;
		case RequestOneofCase.PutPlaylist:
			PutPlaylist = other.PutPlaylist.Clone();
			break;
		case RequestOneofCase.PostPlaylist:
			PostPlaylist = other.PostPlaylist.Clone();
			break;
		case RequestOneofCase.GetActivePlaylist:
			GetActivePlaylist = other.GetActivePlaylist.Clone();
			break;
		case RequestOneofCase.Focused:
			Focused = other.Focused.Clone();
			break;
		case RequestOneofCase.NextFocus:
			NextFocus = other.NextFocus.Clone();
			break;
		case RequestOneofCase.PreviousFocus:
			PreviousFocus = other.PreviousFocus.Clone();
			break;
		case RequestOneofCase.ActivePresentationFocus:
			ActivePresentationFocus = other.ActivePresentationFocus.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementFocus:
			ActiveAnnouncementFocus = other.ActiveAnnouncementFocus.Clone();
			break;
		case RequestOneofCase.FocusedTrigger:
			FocusedTrigger = other.FocusedTrigger.Clone();
			break;
		case RequestOneofCase.ActivePresentationTrigger:
			ActivePresentationTrigger = other.ActivePresentationTrigger.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementTrigger:
			ActiveAnnouncementTrigger = other.ActiveAnnouncementTrigger.Clone();
			break;
		case RequestOneofCase.FocusedNextTrigger:
			FocusedNextTrigger = other.FocusedNextTrigger.Clone();
			break;
		case RequestOneofCase.FocusedPreviousTrigger:
			FocusedPreviousTrigger = other.FocusedPreviousTrigger.Clone();
			break;
		case RequestOneofCase.ActivePresentationNextTrigger:
			ActivePresentationNextTrigger = other.ActivePresentationNextTrigger.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementNextTrigger:
			ActiveAnnouncementNextTrigger = other.ActiveAnnouncementNextTrigger.Clone();
			break;
		case RequestOneofCase.ActivePresentationPreviousTrigger:
			ActivePresentationPreviousTrigger = other.ActivePresentationPreviousTrigger.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementPreviousTrigger:
			ActiveAnnouncementPreviousTrigger = other.ActiveAnnouncementPreviousTrigger.Clone();
			break;
		case RequestOneofCase.IdFocus:
			IdFocus = other.IdFocus.Clone();
			break;
		case RequestOneofCase.IdTrigger:
			IdTrigger = other.IdTrigger.Clone();
			break;
		case RequestOneofCase.IdNextTrigger:
			IdNextTrigger = other.IdNextTrigger.Clone();
			break;
		case RequestOneofCase.IdPreviousTrigger:
			IdPreviousTrigger = other.IdPreviousTrigger.Clone();
			break;
		case RequestOneofCase.FocusedIndexTrigger:
			FocusedIndexTrigger = other.FocusedIndexTrigger.Clone();
			break;
		case RequestOneofCase.ActivePresentationIndexTrigger:
			ActivePresentationIndexTrigger = other.ActivePresentationIndexTrigger.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementIndexTrigger:
			ActiveAnnouncementIndexTrigger = other.ActiveAnnouncementIndexTrigger.Clone();
			break;
		case RequestOneofCase.IdUpdates:
			IdUpdates = other.IdUpdates.Clone();
			break;
		case RequestOneofCase.ActivePresentationThumbnail:
			ActivePresentationThumbnail = other.ActivePresentationThumbnail.Clone();
			break;
		case RequestOneofCase.ActiveAnnouncementThumbnail:
			ActiveAnnouncementThumbnail = other.ActiveAnnouncementThumbnail.Clone();
			break;
		case RequestOneofCase.FocusedNext:
			FocusedNext = other.FocusedNext.Clone();
			break;
		case RequestOneofCase.FocusedPrevious:
			FocusedPrevious = other.FocusedPrevious.Clone();
			break;
		case RequestOneofCase.IdThumbnail:
			IdThumbnail = other.IdThumbnail.Clone();
			break;
		case RequestOneofCase.TimelineOperation:
			TimelineOperation = other.TimelineOperation.Clone();
			break;
		case RequestOneofCase.ActivePlaylistPresentationTimelineOperation:
			ActivePlaylistPresentationTimelineOperation = other.ActivePlaylistPresentationTimelineOperation.Clone();
			break;
		case RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation:
			ActivePlaylistAnnouncementTimelineOperation = other.ActivePlaylistAnnouncementTimelineOperation.Clone();
			break;
		case RequestOneofCase.FocusedPlaylistTimelineOperation:
			FocusedPlaylistTimelineOperation = other.FocusedPlaylistTimelineOperation.Clone();
			break;
		case RequestOneofCase.ActivePlaylistPresentationTimelineStatus:
			ActivePlaylistPresentationTimelineStatus = other.ActivePlaylistPresentationTimelineStatus.Clone();
			break;
		case RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus:
			ActivePlaylistAnnouncementTimelineStatus = other.ActivePlaylistAnnouncementTimelineStatus.Clone();
			break;
		case RequestOneofCase.FocusedPlaylistTimelineStatus:
			FocusedPlaylistTimelineStatus = other.FocusedPlaylistTimelineStatus.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Request Clone()
	{
		return new API_v1_Playlist_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Playlist_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Playlist_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Playlists, other.Playlists))
		{
			return false;
		}
		if (!object.Equals(CreatePlaylist, other.CreatePlaylist))
		{
			return false;
		}
		if (!object.Equals(GetPlaylist, other.GetPlaylist))
		{
			return false;
		}
		if (!object.Equals(PutPlaylist, other.PutPlaylist))
		{
			return false;
		}
		if (!object.Equals(PostPlaylist, other.PostPlaylist))
		{
			return false;
		}
		if (!object.Equals(GetActivePlaylist, other.GetActivePlaylist))
		{
			return false;
		}
		if (!object.Equals(Focused, other.Focused))
		{
			return false;
		}
		if (!object.Equals(NextFocus, other.NextFocus))
		{
			return false;
		}
		if (!object.Equals(PreviousFocus, other.PreviousFocus))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationFocus, other.ActivePresentationFocus))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementFocus, other.ActiveAnnouncementFocus))
		{
			return false;
		}
		if (!object.Equals(FocusedTrigger, other.FocusedTrigger))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationTrigger, other.ActivePresentationTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementTrigger, other.ActiveAnnouncementTrigger))
		{
			return false;
		}
		if (!object.Equals(FocusedNextTrigger, other.FocusedNextTrigger))
		{
			return false;
		}
		if (!object.Equals(FocusedPreviousTrigger, other.FocusedPreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationNextTrigger, other.ActivePresentationNextTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementNextTrigger, other.ActiveAnnouncementNextTrigger))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationPreviousTrigger, other.ActivePresentationPreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementPreviousTrigger, other.ActiveAnnouncementPreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(IdFocus, other.IdFocus))
		{
			return false;
		}
		if (!object.Equals(IdTrigger, other.IdTrigger))
		{
			return false;
		}
		if (!object.Equals(IdNextTrigger, other.IdNextTrigger))
		{
			return false;
		}
		if (!object.Equals(IdPreviousTrigger, other.IdPreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(FocusedIndexTrigger, other.FocusedIndexTrigger))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationIndexTrigger, other.ActivePresentationIndexTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementIndexTrigger, other.ActiveAnnouncementIndexTrigger))
		{
			return false;
		}
		if (!object.Equals(IdUpdates, other.IdUpdates))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationThumbnail, other.ActivePresentationThumbnail))
		{
			return false;
		}
		if (!object.Equals(ActiveAnnouncementThumbnail, other.ActiveAnnouncementThumbnail))
		{
			return false;
		}
		if (!object.Equals(FocusedNext, other.FocusedNext))
		{
			return false;
		}
		if (!object.Equals(FocusedPrevious, other.FocusedPrevious))
		{
			return false;
		}
		if (!object.Equals(IdThumbnail, other.IdThumbnail))
		{
			return false;
		}
		if (!object.Equals(TimelineOperation, other.TimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActivePlaylistPresentationTimelineOperation, other.ActivePlaylistPresentationTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActivePlaylistAnnouncementTimelineOperation, other.ActivePlaylistAnnouncementTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(FocusedPlaylistTimelineOperation, other.FocusedPlaylistTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActivePlaylistPresentationTimelineStatus, other.ActivePlaylistPresentationTimelineStatus))
		{
			return false;
		}
		if (!object.Equals(ActivePlaylistAnnouncementTimelineStatus, other.ActivePlaylistAnnouncementTimelineStatus))
		{
			return false;
		}
		if (!object.Equals(FocusedPlaylistTimelineStatus, other.FocusedPlaylistTimelineStatus))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Playlists)
		{
			num ^= Playlists.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CreatePlaylist)
		{
			num ^= CreatePlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			num ^= GetPlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutPlaylist)
		{
			num ^= PutPlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PostPlaylist)
		{
			num ^= PostPlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetActivePlaylist)
		{
			num ^= GetActivePlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			num ^= Focused.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.NextFocus)
		{
			num ^= NextFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PreviousFocus)
		{
			num ^= PreviousFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationFocus)
		{
			num ^= ActivePresentationFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementFocus)
		{
			num ^= ActiveAnnouncementFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedTrigger)
		{
			num ^= FocusedTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTrigger)
		{
			num ^= ActivePresentationTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementTrigger)
		{
			num ^= ActiveAnnouncementTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedNextTrigger)
		{
			num ^= FocusedNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPreviousTrigger)
		{
			num ^= FocusedPreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationNextTrigger)
		{
			num ^= ActivePresentationNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementNextTrigger)
		{
			num ^= ActiveAnnouncementNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationPreviousTrigger)
		{
			num ^= ActivePresentationPreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			num ^= ActiveAnnouncementPreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdFocus)
		{
			num ^= IdFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdTrigger)
		{
			num ^= IdTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdNextTrigger)
		{
			num ^= IdNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdPreviousTrigger)
		{
			num ^= IdPreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedIndexTrigger)
		{
			num ^= FocusedIndexTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationIndexTrigger)
		{
			num ^= ActivePresentationIndexTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementIndexTrigger)
		{
			num ^= ActiveAnnouncementIndexTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdUpdates)
		{
			num ^= IdUpdates.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationThumbnail)
		{
			num ^= ActivePresentationThumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementThumbnail)
		{
			num ^= ActiveAnnouncementThumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedNext)
		{
			num ^= FocusedNext.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPrevious)
		{
			num ^= FocusedPrevious.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.IdThumbnail)
		{
			num ^= IdThumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			num ^= TimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			num ^= ActivePlaylistPresentationTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			num ^= ActivePlaylistAnnouncementTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineOperation)
		{
			num ^= FocusedPlaylistTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			num ^= ActivePlaylistPresentationTimelineStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			num ^= ActivePlaylistAnnouncementTimelineStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineStatus)
		{
			num ^= FocusedPlaylistTimelineStatus.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Playlists)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Playlists);
		}
		if (requestCase_ == RequestOneofCase.CreatePlaylist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreatePlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetPlaylist);
		}
		if (requestCase_ == RequestOneofCase.PutPlaylist)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutPlaylist);
		}
		if (requestCase_ == RequestOneofCase.PostPlaylist)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PostPlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetActivePlaylist)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetActivePlaylist);
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Focused);
		}
		if (requestCase_ == RequestOneofCase.NextFocus)
		{
			output.WriteRawTag(66);
			output.WriteMessage(NextFocus);
		}
		if (requestCase_ == RequestOneofCase.PreviousFocus)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PreviousFocus);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationFocus)
		{
			output.WriteRawTag(82);
			output.WriteMessage(ActivePresentationFocus);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementFocus)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ActiveAnnouncementFocus);
		}
		if (requestCase_ == RequestOneofCase.FocusedTrigger)
		{
			output.WriteRawTag(98);
			output.WriteMessage(FocusedTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTrigger)
		{
			output.WriteRawTag(106);
			output.WriteMessage(ActivePresentationTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementTrigger)
		{
			output.WriteRawTag(114);
			output.WriteMessage(ActiveAnnouncementTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedNextTrigger)
		{
			output.WriteRawTag(122);
			output.WriteMessage(FocusedNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedPreviousTrigger)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(FocusedPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationNextTrigger)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(ActivePresentationNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementNextTrigger)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(ActiveAnnouncementNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationPreviousTrigger)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(ActivePresentationPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(ActiveAnnouncementPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdFocus)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(IdFocus);
		}
		if (requestCase_ == RequestOneofCase.IdTrigger)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(IdTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdNextTrigger)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(IdNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdPreviousTrigger)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(IdPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedIndexTrigger)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(FocusedIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationIndexTrigger)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(ActivePresentationIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementIndexTrigger)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(ActiveAnnouncementIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdUpdates)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(IdUpdates);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationThumbnail)
		{
			output.WriteRawTag(234, 1);
			output.WriteMessage(ActivePresentationThumbnail);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementThumbnail)
		{
			output.WriteRawTag(242, 1);
			output.WriteMessage(ActiveAnnouncementThumbnail);
		}
		if (requestCase_ == RequestOneofCase.FocusedNext)
		{
			output.WriteRawTag(250, 1);
			output.WriteMessage(FocusedNext);
		}
		if (requestCase_ == RequestOneofCase.FocusedPrevious)
		{
			output.WriteRawTag(130, 2);
			output.WriteMessage(FocusedPrevious);
		}
		if (requestCase_ == RequestOneofCase.IdThumbnail)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(IdThumbnail);
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			output.WriteRawTag(146, 2);
			output.WriteMessage(TimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			output.WriteRawTag(154, 2);
			output.WriteMessage(ActivePlaylistPresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			output.WriteRawTag(162, 2);
			output.WriteMessage(ActivePlaylistAnnouncementTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineOperation)
		{
			output.WriteRawTag(170, 2);
			output.WriteMessage(FocusedPlaylistTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			output.WriteRawTag(178, 2);
			output.WriteMessage(ActivePlaylistPresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			output.WriteRawTag(186, 2);
			output.WriteMessage(ActivePlaylistAnnouncementTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineStatus)
		{
			output.WriteRawTag(194, 2);
			output.WriteMessage(FocusedPlaylistTimelineStatus);
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
		if (requestCase_ == RequestOneofCase.Playlists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlists);
		}
		if (requestCase_ == RequestOneofCase.CreatePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreatePlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylist);
		}
		if (requestCase_ == RequestOneofCase.PutPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutPlaylist);
		}
		if (requestCase_ == RequestOneofCase.PostPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostPlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetActivePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetActivePlaylist);
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
		}
		if (requestCase_ == RequestOneofCase.NextFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(NextFocus);
		}
		if (requestCase_ == RequestOneofCase.PreviousFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PreviousFocus);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationFocus);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementFocus);
		}
		if (requestCase_ == RequestOneofCase.FocusedTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedNextTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdFocus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdFocus);
		}
		if (requestCase_ == RequestOneofCase.IdTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.FocusedIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementIndexTrigger);
		}
		if (requestCase_ == RequestOneofCase.IdUpdates)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdUpdates);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationThumbnail);
		}
		if (requestCase_ == RequestOneofCase.ActiveAnnouncementThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementThumbnail);
		}
		if (requestCase_ == RequestOneofCase.FocusedNext)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedNext);
		}
		if (requestCase_ == RequestOneofCase.FocusedPrevious)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPrevious);
		}
		if (requestCase_ == RequestOneofCase.IdThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdThumbnail);
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistPresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistAnnouncementTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPlaylistTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistPresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistAnnouncementTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineStatus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPlaylistTimelineStatus);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Playlist_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Playlists:
			if (Playlists == null)
			{
				Playlists = new Types.Playlists();
			}
			Playlists.MergeFrom(other.Playlists);
			break;
		case RequestOneofCase.CreatePlaylist:
			if (CreatePlaylist == null)
			{
				CreatePlaylist = new Types.CreatePlaylist();
			}
			CreatePlaylist.MergeFrom(other.CreatePlaylist);
			break;
		case RequestOneofCase.GetPlaylist:
			if (GetPlaylist == null)
			{
				GetPlaylist = new Types.GetPlaylist();
			}
			GetPlaylist.MergeFrom(other.GetPlaylist);
			break;
		case RequestOneofCase.PutPlaylist:
			if (PutPlaylist == null)
			{
				PutPlaylist = new Types.PutPlaylist();
			}
			PutPlaylist.MergeFrom(other.PutPlaylist);
			break;
		case RequestOneofCase.PostPlaylist:
			if (PostPlaylist == null)
			{
				PostPlaylist = new Types.PostPlaylist();
			}
			PostPlaylist.MergeFrom(other.PostPlaylist);
			break;
		case RequestOneofCase.GetActivePlaylist:
			if (GetActivePlaylist == null)
			{
				GetActivePlaylist = new Types.GetActivePlaylist();
			}
			GetActivePlaylist.MergeFrom(other.GetActivePlaylist);
			break;
		case RequestOneofCase.Focused:
			if (Focused == null)
			{
				Focused = new Types.GetActivePlaylist();
			}
			Focused.MergeFrom(other.Focused);
			break;
		case RequestOneofCase.NextFocus:
			if (NextFocus == null)
			{
				NextFocus = new Types.EmptyMessage();
			}
			NextFocus.MergeFrom(other.NextFocus);
			break;
		case RequestOneofCase.PreviousFocus:
			if (PreviousFocus == null)
			{
				PreviousFocus = new Types.EmptyMessage();
			}
			PreviousFocus.MergeFrom(other.PreviousFocus);
			break;
		case RequestOneofCase.ActivePresentationFocus:
			if (ActivePresentationFocus == null)
			{
				ActivePresentationFocus = new Types.EmptyMessage();
			}
			ActivePresentationFocus.MergeFrom(other.ActivePresentationFocus);
			break;
		case RequestOneofCase.ActiveAnnouncementFocus:
			if (ActiveAnnouncementFocus == null)
			{
				ActiveAnnouncementFocus = new Types.EmptyMessage();
			}
			ActiveAnnouncementFocus.MergeFrom(other.ActiveAnnouncementFocus);
			break;
		case RequestOneofCase.FocusedTrigger:
			if (FocusedTrigger == null)
			{
				FocusedTrigger = new Types.EmptyMessage();
			}
			FocusedTrigger.MergeFrom(other.FocusedTrigger);
			break;
		case RequestOneofCase.ActivePresentationTrigger:
			if (ActivePresentationTrigger == null)
			{
				ActivePresentationTrigger = new Types.EmptyMessage();
			}
			ActivePresentationTrigger.MergeFrom(other.ActivePresentationTrigger);
			break;
		case RequestOneofCase.ActiveAnnouncementTrigger:
			if (ActiveAnnouncementTrigger == null)
			{
				ActiveAnnouncementTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementTrigger.MergeFrom(other.ActiveAnnouncementTrigger);
			break;
		case RequestOneofCase.FocusedNextTrigger:
			if (FocusedNextTrigger == null)
			{
				FocusedNextTrigger = new Types.EmptyMessage();
			}
			FocusedNextTrigger.MergeFrom(other.FocusedNextTrigger);
			break;
		case RequestOneofCase.FocusedPreviousTrigger:
			if (FocusedPreviousTrigger == null)
			{
				FocusedPreviousTrigger = new Types.EmptyMessage();
			}
			FocusedPreviousTrigger.MergeFrom(other.FocusedPreviousTrigger);
			break;
		case RequestOneofCase.ActivePresentationNextTrigger:
			if (ActivePresentationNextTrigger == null)
			{
				ActivePresentationNextTrigger = new Types.EmptyMessage();
			}
			ActivePresentationNextTrigger.MergeFrom(other.ActivePresentationNextTrigger);
			break;
		case RequestOneofCase.ActiveAnnouncementNextTrigger:
			if (ActiveAnnouncementNextTrigger == null)
			{
				ActiveAnnouncementNextTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementNextTrigger.MergeFrom(other.ActiveAnnouncementNextTrigger);
			break;
		case RequestOneofCase.ActivePresentationPreviousTrigger:
			if (ActivePresentationPreviousTrigger == null)
			{
				ActivePresentationPreviousTrigger = new Types.EmptyMessage();
			}
			ActivePresentationPreviousTrigger.MergeFrom(other.ActivePresentationPreviousTrigger);
			break;
		case RequestOneofCase.ActiveAnnouncementPreviousTrigger:
			if (ActiveAnnouncementPreviousTrigger == null)
			{
				ActiveAnnouncementPreviousTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementPreviousTrigger.MergeFrom(other.ActiveAnnouncementPreviousTrigger);
			break;
		case RequestOneofCase.IdFocus:
			if (IdFocus == null)
			{
				IdFocus = new Types.IdMessage();
			}
			IdFocus.MergeFrom(other.IdFocus);
			break;
		case RequestOneofCase.IdTrigger:
			if (IdTrigger == null)
			{
				IdTrigger = new Types.IdMessage();
			}
			IdTrigger.MergeFrom(other.IdTrigger);
			break;
		case RequestOneofCase.IdNextTrigger:
			if (IdNextTrigger == null)
			{
				IdNextTrigger = new Types.IdMessage();
			}
			IdNextTrigger.MergeFrom(other.IdNextTrigger);
			break;
		case RequestOneofCase.IdPreviousTrigger:
			if (IdPreviousTrigger == null)
			{
				IdPreviousTrigger = new Types.IdMessage();
			}
			IdPreviousTrigger.MergeFrom(other.IdPreviousTrigger);
			break;
		case RequestOneofCase.FocusedIndexTrigger:
			if (FocusedIndexTrigger == null)
			{
				FocusedIndexTrigger = new Types.IndexMessage();
			}
			FocusedIndexTrigger.MergeFrom(other.FocusedIndexTrigger);
			break;
		case RequestOneofCase.ActivePresentationIndexTrigger:
			if (ActivePresentationIndexTrigger == null)
			{
				ActivePresentationIndexTrigger = new Types.IndexMessage();
			}
			ActivePresentationIndexTrigger.MergeFrom(other.ActivePresentationIndexTrigger);
			break;
		case RequestOneofCase.ActiveAnnouncementIndexTrigger:
			if (ActiveAnnouncementIndexTrigger == null)
			{
				ActiveAnnouncementIndexTrigger = new Types.IndexMessage();
			}
			ActiveAnnouncementIndexTrigger.MergeFrom(other.ActiveAnnouncementIndexTrigger);
			break;
		case RequestOneofCase.IdUpdates:
			if (IdUpdates == null)
			{
				IdUpdates = new Types.IdMessage();
			}
			IdUpdates.MergeFrom(other.IdUpdates);
			break;
		case RequestOneofCase.ActivePresentationThumbnail:
			if (ActivePresentationThumbnail == null)
			{
				ActivePresentationThumbnail = new Types.Thumbnail();
			}
			ActivePresentationThumbnail.MergeFrom(other.ActivePresentationThumbnail);
			break;
		case RequestOneofCase.ActiveAnnouncementThumbnail:
			if (ActiveAnnouncementThumbnail == null)
			{
				ActiveAnnouncementThumbnail = new Types.Thumbnail();
			}
			ActiveAnnouncementThumbnail.MergeFrom(other.ActiveAnnouncementThumbnail);
			break;
		case RequestOneofCase.FocusedNext:
			if (FocusedNext == null)
			{
				FocusedNext = new Types.EmptyMessage();
			}
			FocusedNext.MergeFrom(other.FocusedNext);
			break;
		case RequestOneofCase.FocusedPrevious:
			if (FocusedPrevious == null)
			{
				FocusedPrevious = new Types.EmptyMessage();
			}
			FocusedPrevious.MergeFrom(other.FocusedPrevious);
			break;
		case RequestOneofCase.IdThumbnail:
			if (IdThumbnail == null)
			{
				IdThumbnail = new Types.IdThumbnail();
			}
			IdThumbnail.MergeFrom(other.IdThumbnail);
			break;
		case RequestOneofCase.TimelineOperation:
			if (TimelineOperation == null)
			{
				TimelineOperation = new Types.TimelineOperation();
			}
			TimelineOperation.MergeFrom(other.TimelineOperation);
			break;
		case RequestOneofCase.ActivePlaylistPresentationTimelineOperation:
			if (ActivePlaylistPresentationTimelineOperation == null)
			{
				ActivePlaylistPresentationTimelineOperation = new Types.ActivePlaylistTimelineOperation();
			}
			ActivePlaylistPresentationTimelineOperation.MergeFrom(other.ActivePlaylistPresentationTimelineOperation);
			break;
		case RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation:
			if (ActivePlaylistAnnouncementTimelineOperation == null)
			{
				ActivePlaylistAnnouncementTimelineOperation = new Types.ActivePlaylistTimelineOperation();
			}
			ActivePlaylistAnnouncementTimelineOperation.MergeFrom(other.ActivePlaylistAnnouncementTimelineOperation);
			break;
		case RequestOneofCase.FocusedPlaylistTimelineOperation:
			if (FocusedPlaylistTimelineOperation == null)
			{
				FocusedPlaylistTimelineOperation = new Types.FocusedPlaylistTimelineOperation();
			}
			FocusedPlaylistTimelineOperation.MergeFrom(other.FocusedPlaylistTimelineOperation);
			break;
		case RequestOneofCase.ActivePlaylistPresentationTimelineStatus:
			if (ActivePlaylistPresentationTimelineStatus == null)
			{
				ActivePlaylistPresentationTimelineStatus = new Types.ActivePlaylistTimelineStatus();
			}
			ActivePlaylistPresentationTimelineStatus.MergeFrom(other.ActivePlaylistPresentationTimelineStatus);
			break;
		case RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus:
			if (ActivePlaylistAnnouncementTimelineStatus == null)
			{
				ActivePlaylistAnnouncementTimelineStatus = new Types.ActivePlaylistTimelineStatus();
			}
			ActivePlaylistAnnouncementTimelineStatus.MergeFrom(other.ActivePlaylistAnnouncementTimelineStatus);
			break;
		case RequestOneofCase.FocusedPlaylistTimelineStatus:
			if (FocusedPlaylistTimelineStatus == null)
			{
				FocusedPlaylistTimelineStatus = new Types.FocusedPlaylistTimelineStatus();
			}
			FocusedPlaylistTimelineStatus.MergeFrom(other.FocusedPlaylistTimelineStatus);
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
				Types.Playlists playlists = new Types.Playlists();
				if (requestCase_ == RequestOneofCase.Playlists)
				{
					playlists.MergeFrom(Playlists);
				}
				input.ReadMessage(playlists);
				Playlists = playlists;
				break;
			}
			case 18u:
			{
				Types.CreatePlaylist createPlaylist = new Types.CreatePlaylist();
				if (requestCase_ == RequestOneofCase.CreatePlaylist)
				{
					createPlaylist.MergeFrom(CreatePlaylist);
				}
				input.ReadMessage(createPlaylist);
				CreatePlaylist = createPlaylist;
				break;
			}
			case 26u:
			{
				Types.GetPlaylist getPlaylist = new Types.GetPlaylist();
				if (requestCase_ == RequestOneofCase.GetPlaylist)
				{
					getPlaylist.MergeFrom(GetPlaylist);
				}
				input.ReadMessage(getPlaylist);
				GetPlaylist = getPlaylist;
				break;
			}
			case 34u:
			{
				Types.PutPlaylist putPlaylist = new Types.PutPlaylist();
				if (requestCase_ == RequestOneofCase.PutPlaylist)
				{
					putPlaylist.MergeFrom(PutPlaylist);
				}
				input.ReadMessage(putPlaylist);
				PutPlaylist = putPlaylist;
				break;
			}
			case 42u:
			{
				Types.PostPlaylist postPlaylist = new Types.PostPlaylist();
				if (requestCase_ == RequestOneofCase.PostPlaylist)
				{
					postPlaylist.MergeFrom(PostPlaylist);
				}
				input.ReadMessage(postPlaylist);
				PostPlaylist = postPlaylist;
				break;
			}
			case 50u:
			{
				Types.GetActivePlaylist getActivePlaylist2 = new Types.GetActivePlaylist();
				if (requestCase_ == RequestOneofCase.GetActivePlaylist)
				{
					getActivePlaylist2.MergeFrom(GetActivePlaylist);
				}
				input.ReadMessage(getActivePlaylist2);
				GetActivePlaylist = getActivePlaylist2;
				break;
			}
			case 58u:
			{
				Types.GetActivePlaylist getActivePlaylist = new Types.GetActivePlaylist();
				if (requestCase_ == RequestOneofCase.Focused)
				{
					getActivePlaylist.MergeFrom(Focused);
				}
				input.ReadMessage(getActivePlaylist);
				Focused = getActivePlaylist;
				break;
			}
			case 66u:
			{
				Types.EmptyMessage emptyMessage12 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.NextFocus)
				{
					emptyMessage12.MergeFrom(NextFocus);
				}
				input.ReadMessage(emptyMessage12);
				NextFocus = emptyMessage12;
				break;
			}
			case 74u:
			{
				Types.EmptyMessage emptyMessage8 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PreviousFocus)
				{
					emptyMessage8.MergeFrom(PreviousFocus);
				}
				input.ReadMessage(emptyMessage8);
				PreviousFocus = emptyMessage8;
				break;
			}
			case 82u:
			{
				Types.EmptyMessage emptyMessage4 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActivePresentationFocus)
				{
					emptyMessage4.MergeFrom(ActivePresentationFocus);
				}
				input.ReadMessage(emptyMessage4);
				ActivePresentationFocus = emptyMessage4;
				break;
			}
			case 90u:
			{
				Types.EmptyMessage emptyMessage3 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementFocus)
				{
					emptyMessage3.MergeFrom(ActiveAnnouncementFocus);
				}
				input.ReadMessage(emptyMessage3);
				ActiveAnnouncementFocus = emptyMessage3;
				break;
			}
			case 98u:
			{
				Types.EmptyMessage emptyMessage13 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.FocusedTrigger)
				{
					emptyMessage13.MergeFrom(FocusedTrigger);
				}
				input.ReadMessage(emptyMessage13);
				FocusedTrigger = emptyMessage13;
				break;
			}
			case 106u:
			{
				Types.EmptyMessage emptyMessage11 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActivePresentationTrigger)
				{
					emptyMessage11.MergeFrom(ActivePresentationTrigger);
				}
				input.ReadMessage(emptyMessage11);
				ActivePresentationTrigger = emptyMessage11;
				break;
			}
			case 114u:
			{
				Types.EmptyMessage emptyMessage6 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementTrigger)
				{
					emptyMessage6.MergeFrom(ActiveAnnouncementTrigger);
				}
				input.ReadMessage(emptyMessage6);
				ActiveAnnouncementTrigger = emptyMessage6;
				break;
			}
			case 122u:
			{
				Types.EmptyMessage emptyMessage5 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.FocusedNextTrigger)
				{
					emptyMessage5.MergeFrom(FocusedNextTrigger);
				}
				input.ReadMessage(emptyMessage5);
				FocusedNextTrigger = emptyMessage5;
				break;
			}
			case 130u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.FocusedPreviousTrigger)
				{
					emptyMessage2.MergeFrom(FocusedPreviousTrigger);
				}
				input.ReadMessage(emptyMessage2);
				FocusedPreviousTrigger = emptyMessage2;
				break;
			}
			case 138u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActivePresentationNextTrigger)
				{
					emptyMessage.MergeFrom(ActivePresentationNextTrigger);
				}
				input.ReadMessage(emptyMessage);
				ActivePresentationNextTrigger = emptyMessage;
				break;
			}
			case 146u:
			{
				Types.EmptyMessage emptyMessage15 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementNextTrigger)
				{
					emptyMessage15.MergeFrom(ActiveAnnouncementNextTrigger);
				}
				input.ReadMessage(emptyMessage15);
				ActiveAnnouncementNextTrigger = emptyMessage15;
				break;
			}
			case 154u:
			{
				Types.EmptyMessage emptyMessage14 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActivePresentationPreviousTrigger)
				{
					emptyMessage14.MergeFrom(ActivePresentationPreviousTrigger);
				}
				input.ReadMessage(emptyMessage14);
				ActivePresentationPreviousTrigger = emptyMessage14;
				break;
			}
			case 162u:
			{
				Types.EmptyMessage emptyMessage10 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementPreviousTrigger)
				{
					emptyMessage10.MergeFrom(ActiveAnnouncementPreviousTrigger);
				}
				input.ReadMessage(emptyMessage10);
				ActiveAnnouncementPreviousTrigger = emptyMessage10;
				break;
			}
			case 170u:
			{
				Types.IdMessage idMessage4 = new Types.IdMessage();
				if (requestCase_ == RequestOneofCase.IdFocus)
				{
					idMessage4.MergeFrom(IdFocus);
				}
				input.ReadMessage(idMessage4);
				IdFocus = idMessage4;
				break;
			}
			case 178u:
			{
				Types.IdMessage idMessage3 = new Types.IdMessage();
				if (requestCase_ == RequestOneofCase.IdTrigger)
				{
					idMessage3.MergeFrom(IdTrigger);
				}
				input.ReadMessage(idMessage3);
				IdTrigger = idMessage3;
				break;
			}
			case 186u:
			{
				Types.IdMessage idMessage2 = new Types.IdMessage();
				if (requestCase_ == RequestOneofCase.IdNextTrigger)
				{
					idMessage2.MergeFrom(IdNextTrigger);
				}
				input.ReadMessage(idMessage2);
				IdNextTrigger = idMessage2;
				break;
			}
			case 194u:
			{
				Types.IdMessage idMessage = new Types.IdMessage();
				if (requestCase_ == RequestOneofCase.IdPreviousTrigger)
				{
					idMessage.MergeFrom(IdPreviousTrigger);
				}
				input.ReadMessage(idMessage);
				IdPreviousTrigger = idMessage;
				break;
			}
			case 202u:
			{
				Types.IndexMessage indexMessage2 = new Types.IndexMessage();
				if (requestCase_ == RequestOneofCase.FocusedIndexTrigger)
				{
					indexMessage2.MergeFrom(FocusedIndexTrigger);
				}
				input.ReadMessage(indexMessage2);
				FocusedIndexTrigger = indexMessage2;
				break;
			}
			case 210u:
			{
				Types.IndexMessage indexMessage = new Types.IndexMessage();
				if (requestCase_ == RequestOneofCase.ActivePresentationIndexTrigger)
				{
					indexMessage.MergeFrom(ActivePresentationIndexTrigger);
				}
				input.ReadMessage(indexMessage);
				ActivePresentationIndexTrigger = indexMessage;
				break;
			}
			case 218u:
			{
				Types.IndexMessage indexMessage3 = new Types.IndexMessage();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementIndexTrigger)
				{
					indexMessage3.MergeFrom(ActiveAnnouncementIndexTrigger);
				}
				input.ReadMessage(indexMessage3);
				ActiveAnnouncementIndexTrigger = indexMessage3;
				break;
			}
			case 226u:
			{
				Types.IdMessage idMessage5 = new Types.IdMessage();
				if (requestCase_ == RequestOneofCase.IdUpdates)
				{
					idMessage5.MergeFrom(IdUpdates);
				}
				input.ReadMessage(idMessage5);
				IdUpdates = idMessage5;
				break;
			}
			case 234u:
			{
				Types.Thumbnail thumbnail2 = new Types.Thumbnail();
				if (requestCase_ == RequestOneofCase.ActivePresentationThumbnail)
				{
					thumbnail2.MergeFrom(ActivePresentationThumbnail);
				}
				input.ReadMessage(thumbnail2);
				ActivePresentationThumbnail = thumbnail2;
				break;
			}
			case 242u:
			{
				Types.Thumbnail thumbnail = new Types.Thumbnail();
				if (requestCase_ == RequestOneofCase.ActiveAnnouncementThumbnail)
				{
					thumbnail.MergeFrom(ActiveAnnouncementThumbnail);
				}
				input.ReadMessage(thumbnail);
				ActiveAnnouncementThumbnail = thumbnail;
				break;
			}
			case 250u:
			{
				Types.EmptyMessage emptyMessage9 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.FocusedNext)
				{
					emptyMessage9.MergeFrom(FocusedNext);
				}
				input.ReadMessage(emptyMessage9);
				FocusedNext = emptyMessage9;
				break;
			}
			case 258u:
			{
				Types.EmptyMessage emptyMessage7 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.FocusedPrevious)
				{
					emptyMessage7.MergeFrom(FocusedPrevious);
				}
				input.ReadMessage(emptyMessage7);
				FocusedPrevious = emptyMessage7;
				break;
			}
			case 266u:
			{
				Types.IdThumbnail idThumbnail = new Types.IdThumbnail();
				if (requestCase_ == RequestOneofCase.IdThumbnail)
				{
					idThumbnail.MergeFrom(IdThumbnail);
				}
				input.ReadMessage(idThumbnail);
				IdThumbnail = idThumbnail;
				break;
			}
			case 274u:
			{
				Types.TimelineOperation timelineOperation = new Types.TimelineOperation();
				if (requestCase_ == RequestOneofCase.TimelineOperation)
				{
					timelineOperation.MergeFrom(TimelineOperation);
				}
				input.ReadMessage(timelineOperation);
				TimelineOperation = timelineOperation;
				break;
			}
			case 282u:
			{
				Types.ActivePlaylistTimelineOperation activePlaylistTimelineOperation2 = new Types.ActivePlaylistTimelineOperation();
				if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineOperation)
				{
					activePlaylistTimelineOperation2.MergeFrom(ActivePlaylistPresentationTimelineOperation);
				}
				input.ReadMessage(activePlaylistTimelineOperation2);
				ActivePlaylistPresentationTimelineOperation = activePlaylistTimelineOperation2;
				break;
			}
			case 290u:
			{
				Types.ActivePlaylistTimelineOperation activePlaylistTimelineOperation = new Types.ActivePlaylistTimelineOperation();
				if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineOperation)
				{
					activePlaylistTimelineOperation.MergeFrom(ActivePlaylistAnnouncementTimelineOperation);
				}
				input.ReadMessage(activePlaylistTimelineOperation);
				ActivePlaylistAnnouncementTimelineOperation = activePlaylistTimelineOperation;
				break;
			}
			case 298u:
			{
				Types.FocusedPlaylistTimelineOperation focusedPlaylistTimelineOperation = new Types.FocusedPlaylistTimelineOperation();
				if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineOperation)
				{
					focusedPlaylistTimelineOperation.MergeFrom(FocusedPlaylistTimelineOperation);
				}
				input.ReadMessage(focusedPlaylistTimelineOperation);
				FocusedPlaylistTimelineOperation = focusedPlaylistTimelineOperation;
				break;
			}
			case 306u:
			{
				Types.ActivePlaylistTimelineStatus activePlaylistTimelineStatus2 = new Types.ActivePlaylistTimelineStatus();
				if (requestCase_ == RequestOneofCase.ActivePlaylistPresentationTimelineStatus)
				{
					activePlaylistTimelineStatus2.MergeFrom(ActivePlaylistPresentationTimelineStatus);
				}
				input.ReadMessage(activePlaylistTimelineStatus2);
				ActivePlaylistPresentationTimelineStatus = activePlaylistTimelineStatus2;
				break;
			}
			case 314u:
			{
				Types.ActivePlaylistTimelineStatus activePlaylistTimelineStatus = new Types.ActivePlaylistTimelineStatus();
				if (requestCase_ == RequestOneofCase.ActivePlaylistAnnouncementTimelineStatus)
				{
					activePlaylistTimelineStatus.MergeFrom(ActivePlaylistAnnouncementTimelineStatus);
				}
				input.ReadMessage(activePlaylistTimelineStatus);
				ActivePlaylistAnnouncementTimelineStatus = activePlaylistTimelineStatus;
				break;
			}
			case 322u:
			{
				Types.FocusedPlaylistTimelineStatus focusedPlaylistTimelineStatus = new Types.FocusedPlaylistTimelineStatus();
				if (requestCase_ == RequestOneofCase.FocusedPlaylistTimelineStatus)
				{
					focusedPlaylistTimelineStatus.MergeFrom(FocusedPlaylistTimelineStatus);
				}
				input.ReadMessage(focusedPlaylistTimelineStatus);
				FocusedPlaylistTimelineStatus = focusedPlaylistTimelineStatus;
				break;
			}
			}
		}
	}
}
