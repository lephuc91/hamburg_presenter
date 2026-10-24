using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Playlist_Response : IMessage<API_v1_Playlist_Response>, IMessage, IEquatable<API_v1_Playlist_Response>, IDeepCloneable<API_v1_Playlist_Response>
{
	public enum ResponseOneofCase
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

			public const int Playlists_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Playlist> _repeated_playlists_codec = FieldCodec.ForMessage(10u, API_v1_Playlist.Parser);

			private readonly RepeatedField<API_v1_Playlist> playlists_ = new RepeatedField<API_v1_Playlist>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlists> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Playlist> Playlists_ => playlists_;

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
				playlists_ = other.playlists_.Clone();
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
			public void MergeFrom(Playlists other)
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
		public sealed class CreatePlaylist : IMessage<CreatePlaylist>, IMessage, IEquatable<CreatePlaylist>, IDeepCloneable<CreatePlaylist>
		{
			private static readonly MessageParser<CreatePlaylist> _parser = new MessageParser<CreatePlaylist>(() => new CreatePlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistFieldNumber = 1;

			private API_v1_Playlist playlist_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreatePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Playlist Playlist
			{
				get
				{
					return playlist_;
				}
				set
				{
					playlist_ = value;
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
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
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
				if (!object.Equals(Playlist, other.Playlist))
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
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
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
				if (playlist_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Playlist);
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
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
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
				if (other == null)
				{
					return;
				}
				if (other.playlist_ != null)
				{
					if (playlist_ == null)
					{
						Playlist = new API_v1_Playlist();
					}
					Playlist.MergeFrom(other.Playlist);
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
					if (playlist_ == null)
					{
						Playlist = new API_v1_Playlist();
					}
					input.ReadMessage(Playlist);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetActivePlaylist : IMessage<GetActivePlaylist>, IMessage, IEquatable<GetActivePlaylist>, IDeepCloneable<GetActivePlaylist>
		{
			private static readonly MessageParser<GetActivePlaylist> _parser = new MessageParser<GetActivePlaylist>(() => new GetActivePlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PresentationFieldNumber = 1;

			private API_v1_PlaylistAndItem presentation_;

			public const int AnnouncementsFieldNumber = 2;

			private API_v1_PlaylistAndItem announcements_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetActivePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PlaylistAndItem Presentation
			{
				get
				{
					return presentation_;
				}
				set
				{
					presentation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PlaylistAndItem Announcements
			{
				get
				{
					return announcements_;
				}
				set
				{
					announcements_ = value;
				}
			}

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
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
				announcements_ = ((other.announcements_ != null) ? other.announcements_.Clone() : null);
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
				if (!object.Equals(Presentation, other.Presentation))
				{
					return false;
				}
				if (!object.Equals(Announcements, other.Announcements))
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
				if (presentation_ != null)
				{
					num ^= Presentation.GetHashCode();
				}
				if (announcements_ != null)
				{
					num ^= Announcements.GetHashCode();
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
				if (presentation_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Presentation);
				}
				if (announcements_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Announcements);
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
				if (presentation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
				}
				if (announcements_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Announcements);
				}
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
				if (other == null)
				{
					return;
				}
				if (other.presentation_ != null)
				{
					if (presentation_ == null)
					{
						Presentation = new API_v1_PlaylistAndItem();
					}
					Presentation.MergeFrom(other.Presentation);
				}
				if (other.announcements_ != null)
				{
					if (announcements_ == null)
					{
						Announcements = new API_v1_PlaylistAndItem();
					}
					Announcements.MergeFrom(other.Announcements);
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
						if (presentation_ == null)
						{
							Presentation = new API_v1_PlaylistAndItem();
						}
						input.ReadMessage(Presentation);
						break;
					case 18u:
						if (announcements_ == null)
						{
							Announcements = new API_v1_PlaylistAndItem();
						}
						input.ReadMessage(Announcements);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetPlaylist : IMessage<GetPlaylist>, IMessage, IEquatable<GetPlaylist>, IDeepCloneable<GetPlaylist>
		{
			private static readonly MessageParser<GetPlaylist> _parser = new MessageParser<GetPlaylist>(() => new GetPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			public const int ItemsFieldNumber = 2;

			private static readonly FieldCodec<API_v1_PlaylistItem> _repeated_items_codec = FieldCodec.ForMessage(18u, API_v1_PlaylistItem.Parser);

			private readonly RepeatedField<API_v1_PlaylistItem> items_ = new RepeatedField<API_v1_PlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Id
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
			public RepeatedField<API_v1_PlaylistItem> Items => items_;

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
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				items_ = other.items_.Clone();
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
				if (!object.Equals(Id, other.Id))
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
				if (id_ != null)
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
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
			public void MergeFrom(GetPlaylist other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					Id.MergeFrom(other.Id);
				}
				items_.Add(other.items_);
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
							Id = new API_v1_Identifier();
						}
						input.ReadMessage(Id);
						break;
					case 18u:
						items_.AddEntriesFrom(input, _repeated_items_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutPlaylist : IMessage<PutPlaylist>, IMessage, IEquatable<PutPlaylist>, IDeepCloneable<PutPlaylist>
		{
			private static readonly MessageParser<PutPlaylist> _parser = new MessageParser<PutPlaylist>(() => new PutPlaylist());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutPlaylist other)
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
		public sealed class PostPlaylist : IMessage<PostPlaylist>, IMessage, IEquatable<PostPlaylist>, IDeepCloneable<PostPlaylist>
		{
			private static readonly MessageParser<PostPlaylist> _parser = new MessageParser<PostPlaylist>(() => new PostPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistFieldNumber = 1;

			private API_v1_Playlist playlist_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Playlist Playlist
			{
				get
				{
					return playlist_;
				}
				set
				{
					playlist_ = value;
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
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
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
				if (!object.Equals(Playlist, other.Playlist))
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
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
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
				if (playlist_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Playlist);
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
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
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
				if (other == null)
				{
					return;
				}
				if (other.playlist_ != null)
				{
					if (playlist_ == null)
					{
						Playlist = new API_v1_Playlist();
					}
					Playlist.MergeFrom(other.Playlist);
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
					if (playlist_ == null)
					{
						Playlist = new API_v1_Playlist();
					}
					input.ReadMessage(Playlist);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetFocusedPlaylist : IMessage<GetFocusedPlaylist>, IMessage, IEquatable<GetFocusedPlaylist>, IDeepCloneable<GetFocusedPlaylist>
		{
			private static readonly MessageParser<GetFocusedPlaylist> _parser = new MessageParser<GetFocusedPlaylist>(() => new GetFocusedPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistFieldNumber = 1;

			private API_v1_PlaylistAndItem playlist_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetFocusedPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PlaylistAndItem Playlist
			{
				get
				{
					return playlist_;
				}
				set
				{
					playlist_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetFocusedPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetFocusedPlaylist(GetFocusedPlaylist other)
				: this()
			{
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetFocusedPlaylist Clone()
			{
				return new GetFocusedPlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetFocusedPlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetFocusedPlaylist other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Playlist, other.Playlist))
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
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
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
				if (playlist_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Playlist);
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
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetFocusedPlaylist other)
			{
				if (other == null)
				{
					return;
				}
				if (other.playlist_ != null)
				{
					if (playlist_ == null)
					{
						Playlist = new API_v1_PlaylistAndItem();
					}
					Playlist.MergeFrom(other.Playlist);
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
					if (playlist_ == null)
					{
						Playlist = new API_v1_PlaylistAndItem();
					}
					input.ReadMessage(Playlist);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetProximalPlaylistItem : IMessage<GetProximalPlaylistItem>, IMessage, IEquatable<GetProximalPlaylistItem>, IDeepCloneable<GetProximalPlaylistItem>
		{
			private static readonly MessageParser<GetProximalPlaylistItem> _parser = new MessageParser<GetProximalPlaylistItem>(() => new GetProximalPlaylistItem());

			private UnknownFieldSet _unknownFields;

			public const int ItemFieldNumber = 1;

			private API_v1_Identifier item_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetProximalPlaylistItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Item
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
			public GetProximalPlaylistItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProximalPlaylistItem(GetProximalPlaylistItem other)
				: this()
			{
				item_ = ((other.item_ != null) ? other.item_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProximalPlaylistItem Clone()
			{
				return new GetProximalPlaylistItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetProximalPlaylistItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetProximalPlaylistItem other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetProximalPlaylistItem other)
			{
				if (other == null)
				{
					return;
				}
				if (other.item_ != null)
				{
					if (item_ == null)
					{
						Item = new API_v1_Identifier();
					}
					Item.MergeFrom(other.Item);
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
					if (item_ == null)
					{
						Item = new API_v1_Identifier();
					}
					input.ReadMessage(Item);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Thumbnail : IMessage<Thumbnail>, IMessage, IEquatable<Thumbnail>, IDeepCloneable<Thumbnail>
		{
			private static readonly MessageParser<Thumbnail> _parser = new MessageParser<Thumbnail>(() => new Thumbnail());

			private UnknownFieldSet _unknownFields;

			public const int DataFieldNumber = 1;

			private ByteString data_ = ByteString.Empty;

			public const int ContentTypeFieldNumber = 2;

			private API_v1_ContentType contentType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Thumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Data
			{
				get
				{
					return data_;
				}
				set
				{
					data_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				data_ = other.data_;
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
				if (Data != other.Data)
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
				if (Data.Length != 0)
				{
					num ^= Data.GetHashCode();
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
				if (Data.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(Data);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(16);
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
				if (Data.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
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
					if (other.Data.Length != 0)
					{
						Data = other.Data;
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
						Data = input.ReadBytes();
						break;
					case 16u:
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
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[9];

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
		public sealed class TimelineOperation : IMessage<TimelineOperation>, IMessage, IEquatable<TimelineOperation>, IDeepCloneable<TimelineOperation>
		{
			private static readonly MessageParser<TimelineOperation> _parser = new MessageParser<TimelineOperation>(() => new TimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(TimelineOperation other)
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
		public sealed class ActivePlaylistTimelineOperation : IMessage<ActivePlaylistTimelineOperation>, IMessage, IEquatable<ActivePlaylistTimelineOperation>, IDeepCloneable<ActivePlaylistTimelineOperation>
		{
			private static readonly MessageParser<ActivePlaylistTimelineOperation> _parser = new MessageParser<ActivePlaylistTimelineOperation>(() => new ActivePlaylistTimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePlaylistTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(ActivePlaylistTimelineOperation other)
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
		public sealed class FocusedPlaylistTimelineOperation : IMessage<FocusedPlaylistTimelineOperation>, IMessage, IEquatable<FocusedPlaylistTimelineOperation>, IDeepCloneable<FocusedPlaylistTimelineOperation>
		{
			private static readonly MessageParser<FocusedPlaylistTimelineOperation> _parser = new MessageParser<FocusedPlaylistTimelineOperation>(() => new FocusedPlaylistTimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPlaylistTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(FocusedPlaylistTimelineOperation other)
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
		public sealed class ActivePlaylistTimelineStatus : IMessage<ActivePlaylistTimelineStatus>, IMessage, IEquatable<ActivePlaylistTimelineStatus>, IDeepCloneable<ActivePlaylistTimelineStatus>
		{
			private static readonly MessageParser<ActivePlaylistTimelineStatus> _parser = new MessageParser<ActivePlaylistTimelineStatus>(() => new ActivePlaylistTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IsRunningFieldNumber = 1;

			private bool isRunning_;

			public const int CurrentTimeFieldNumber = 2;

			private double currentTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePlaylistTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsRunning
			{
				get
				{
					return isRunning_;
				}
				set
				{
					isRunning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
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
				isRunning_ = other.isRunning_;
				currentTime_ = other.currentTime_;
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
				if (IsRunning != other.IsRunning)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
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
				if (IsRunning)
				{
					num ^= IsRunning.GetHashCode();
				}
				if (CurrentTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CurrentTime);
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
				if (IsRunning)
				{
					output.WriteRawTag(8);
					output.WriteBool(IsRunning);
				}
				if (CurrentTime != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(CurrentTime);
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
				if (IsRunning)
				{
					num += 2;
				}
				if (CurrentTime != 0.0)
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
			public void MergeFrom(ActivePlaylistTimelineStatus other)
			{
				if (other != null)
				{
					if (other.IsRunning)
					{
						IsRunning = other.IsRunning;
					}
					if (other.CurrentTime != 0.0)
					{
						CurrentTime = other.CurrentTime;
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
						IsRunning = input.ReadBool();
						break;
					case 17u:
						CurrentTime = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPlaylistTimelineStatus : IMessage<FocusedPlaylistTimelineStatus>, IMessage, IEquatable<FocusedPlaylistTimelineStatus>, IDeepCloneable<FocusedPlaylistTimelineStatus>
		{
			private static readonly MessageParser<FocusedPlaylistTimelineStatus> _parser = new MessageParser<FocusedPlaylistTimelineStatus>(() => new FocusedPlaylistTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IsRunningFieldNumber = 1;

			private bool isRunning_;

			public const int CurrentTimeFieldNumber = 2;

			private double currentTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPlaylistTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Playlist_Response.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsRunning
			{
				get
				{
					return isRunning_;
				}
				set
				{
					isRunning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
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
				isRunning_ = other.isRunning_;
				currentTime_ = other.currentTime_;
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
				if (IsRunning != other.IsRunning)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
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
				if (IsRunning)
				{
					num ^= IsRunning.GetHashCode();
				}
				if (CurrentTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CurrentTime);
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
				if (IsRunning)
				{
					output.WriteRawTag(8);
					output.WriteBool(IsRunning);
				}
				if (CurrentTime != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(CurrentTime);
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
				if (IsRunning)
				{
					num += 2;
				}
				if (CurrentTime != 0.0)
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
			public void MergeFrom(FocusedPlaylistTimelineStatus other)
			{
				if (other != null)
				{
					if (other.IsRunning)
					{
						IsRunning = other.IsRunning;
					}
					if (other.CurrentTime != 0.0)
					{
						CurrentTime = other.CurrentTime;
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
						IsRunning = input.ReadBool();
						break;
					case 17u:
						CurrentTime = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Playlist_Response> _parser = new MessageParser<API_v1_Playlist_Response>(() => new API_v1_Playlist_Response());

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

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Playlist_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PlaylistReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlists Playlists
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Playlists)
			{
				return null;
			}
			return (Types.Playlists)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Playlists : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreatePlaylist CreatePlaylist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CreatePlaylist)
			{
				return null;
			}
			return (Types.CreatePlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CreatePlaylist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPlaylist GetPlaylist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetPlaylist)
			{
				return null;
			}
			return (Types.GetPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetPlaylist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutPlaylist PutPlaylist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutPlaylist)
			{
				return null;
			}
			return (Types.PutPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutPlaylist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostPlaylist PostPlaylist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PostPlaylist)
			{
				return null;
			}
			return (Types.PostPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PostPlaylist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetActivePlaylist GetActivePlaylist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetActivePlaylist)
			{
				return null;
			}
			return (Types.GetActivePlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetActivePlaylist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetFocusedPlaylist Focused
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Focused)
			{
				return null;
			}
			return (Types.GetFocusedPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Focused : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage NextFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.NextFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.NextFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PreviousFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PreviousFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PreviousFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage IdFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage IdTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage IdNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage IdPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage FocusedIndexTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedIndexTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedIndexTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActivePresentationIndexTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationIndexTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationIndexTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage ActiveAnnouncementIndexTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementIndexTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementIndexTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage IdUpdates
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdUpdates)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdUpdates : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail ActivePresentationThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationThumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail ActiveAnnouncementThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActiveAnnouncementThumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActiveAnnouncementThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetProximalPlaylistItem FocusedNext
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedNext)
			{
				return null;
			}
			return (Types.GetProximalPlaylistItem)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedNext : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetProximalPlaylistItem FocusedPrevious
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPrevious)
			{
				return null;
			}
			return (Types.GetProximalPlaylistItem)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPrevious : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail IdThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.IdThumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.IdThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimelineOperation TimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TimelineOperation)
			{
				return null;
			}
			return (Types.TimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineOperation ActivePlaylistPresentationTimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePlaylistPresentationTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePlaylistPresentationTimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineOperation ActivePlaylistAnnouncementTimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPlaylistTimelineOperation FocusedPlaylistTimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPlaylistTimelineOperation)
			{
				return null;
			}
			return (Types.FocusedPlaylistTimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPlaylistTimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineStatus ActivePlaylistPresentationTimelineStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePlaylistPresentationTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePlaylistPresentationTimelineStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylistTimelineStatus ActivePlaylistAnnouncementTimelineStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePlaylistTimelineStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPlaylistTimelineStatus FocusedPlaylistTimelineStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPlaylistTimelineStatus)
			{
				return null;
			}
			return (Types.FocusedPlaylistTimelineStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPlaylistTimelineStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Response(API_v1_Playlist_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case ResponseOneofCase.CreatePlaylist:
			CreatePlaylist = other.CreatePlaylist.Clone();
			break;
		case ResponseOneofCase.GetPlaylist:
			GetPlaylist = other.GetPlaylist.Clone();
			break;
		case ResponseOneofCase.PutPlaylist:
			PutPlaylist = other.PutPlaylist.Clone();
			break;
		case ResponseOneofCase.PostPlaylist:
			PostPlaylist = other.PostPlaylist.Clone();
			break;
		case ResponseOneofCase.GetActivePlaylist:
			GetActivePlaylist = other.GetActivePlaylist.Clone();
			break;
		case ResponseOneofCase.Focused:
			Focused = other.Focused.Clone();
			break;
		case ResponseOneofCase.NextFocus:
			NextFocus = other.NextFocus.Clone();
			break;
		case ResponseOneofCase.PreviousFocus:
			PreviousFocus = other.PreviousFocus.Clone();
			break;
		case ResponseOneofCase.ActivePresentationFocus:
			ActivePresentationFocus = other.ActivePresentationFocus.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementFocus:
			ActiveAnnouncementFocus = other.ActiveAnnouncementFocus.Clone();
			break;
		case ResponseOneofCase.FocusedTrigger:
			FocusedTrigger = other.FocusedTrigger.Clone();
			break;
		case ResponseOneofCase.ActivePresentationTrigger:
			ActivePresentationTrigger = other.ActivePresentationTrigger.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementTrigger:
			ActiveAnnouncementTrigger = other.ActiveAnnouncementTrigger.Clone();
			break;
		case ResponseOneofCase.FocusedNextTrigger:
			FocusedNextTrigger = other.FocusedNextTrigger.Clone();
			break;
		case ResponseOneofCase.FocusedPreviousTrigger:
			FocusedPreviousTrigger = other.FocusedPreviousTrigger.Clone();
			break;
		case ResponseOneofCase.ActivePresentationNextTrigger:
			ActivePresentationNextTrigger = other.ActivePresentationNextTrigger.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementNextTrigger:
			ActiveAnnouncementNextTrigger = other.ActiveAnnouncementNextTrigger.Clone();
			break;
		case ResponseOneofCase.ActivePresentationPreviousTrigger:
			ActivePresentationPreviousTrigger = other.ActivePresentationPreviousTrigger.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementPreviousTrigger:
			ActiveAnnouncementPreviousTrigger = other.ActiveAnnouncementPreviousTrigger.Clone();
			break;
		case ResponseOneofCase.IdFocus:
			IdFocus = other.IdFocus.Clone();
			break;
		case ResponseOneofCase.IdTrigger:
			IdTrigger = other.IdTrigger.Clone();
			break;
		case ResponseOneofCase.IdNextTrigger:
			IdNextTrigger = other.IdNextTrigger.Clone();
			break;
		case ResponseOneofCase.IdPreviousTrigger:
			IdPreviousTrigger = other.IdPreviousTrigger.Clone();
			break;
		case ResponseOneofCase.FocusedIndexTrigger:
			FocusedIndexTrigger = other.FocusedIndexTrigger.Clone();
			break;
		case ResponseOneofCase.ActivePresentationIndexTrigger:
			ActivePresentationIndexTrigger = other.ActivePresentationIndexTrigger.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementIndexTrigger:
			ActiveAnnouncementIndexTrigger = other.ActiveAnnouncementIndexTrigger.Clone();
			break;
		case ResponseOneofCase.IdUpdates:
			IdUpdates = other.IdUpdates.Clone();
			break;
		case ResponseOneofCase.ActivePresentationThumbnail:
			ActivePresentationThumbnail = other.ActivePresentationThumbnail.Clone();
			break;
		case ResponseOneofCase.ActiveAnnouncementThumbnail:
			ActiveAnnouncementThumbnail = other.ActiveAnnouncementThumbnail.Clone();
			break;
		case ResponseOneofCase.FocusedNext:
			FocusedNext = other.FocusedNext.Clone();
			break;
		case ResponseOneofCase.FocusedPrevious:
			FocusedPrevious = other.FocusedPrevious.Clone();
			break;
		case ResponseOneofCase.IdThumbnail:
			IdThumbnail = other.IdThumbnail.Clone();
			break;
		case ResponseOneofCase.TimelineOperation:
			TimelineOperation = other.TimelineOperation.Clone();
			break;
		case ResponseOneofCase.ActivePlaylistPresentationTimelineOperation:
			ActivePlaylistPresentationTimelineOperation = other.ActivePlaylistPresentationTimelineOperation.Clone();
			break;
		case ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation:
			ActivePlaylistAnnouncementTimelineOperation = other.ActivePlaylistAnnouncementTimelineOperation.Clone();
			break;
		case ResponseOneofCase.FocusedPlaylistTimelineOperation:
			FocusedPlaylistTimelineOperation = other.FocusedPlaylistTimelineOperation.Clone();
			break;
		case ResponseOneofCase.ActivePlaylistPresentationTimelineStatus:
			ActivePlaylistPresentationTimelineStatus = other.ActivePlaylistPresentationTimelineStatus.Clone();
			break;
		case ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus:
			ActivePlaylistAnnouncementTimelineStatus = other.ActivePlaylistAnnouncementTimelineStatus.Clone();
			break;
		case ResponseOneofCase.FocusedPlaylistTimelineStatus:
			FocusedPlaylistTimelineStatus = other.FocusedPlaylistTimelineStatus.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Playlist_Response Clone()
	{
		return new API_v1_Playlist_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Playlist_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Playlist_Response other)
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
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.Playlists)
		{
			num ^= Playlists.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CreatePlaylist)
		{
			num ^= CreatePlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			num ^= GetPlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutPlaylist)
		{
			num ^= PutPlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PostPlaylist)
		{
			num ^= PostPlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetActivePlaylist)
		{
			num ^= GetActivePlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			num ^= Focused.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.NextFocus)
		{
			num ^= NextFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PreviousFocus)
		{
			num ^= PreviousFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationFocus)
		{
			num ^= ActivePresentationFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementFocus)
		{
			num ^= ActiveAnnouncementFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedTrigger)
		{
			num ^= FocusedTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTrigger)
		{
			num ^= ActivePresentationTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementTrigger)
		{
			num ^= ActiveAnnouncementTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedNextTrigger)
		{
			num ^= FocusedNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPreviousTrigger)
		{
			num ^= FocusedPreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationNextTrigger)
		{
			num ^= ActivePresentationNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementNextTrigger)
		{
			num ^= ActiveAnnouncementNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationPreviousTrigger)
		{
			num ^= ActivePresentationPreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			num ^= ActiveAnnouncementPreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdFocus)
		{
			num ^= IdFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdTrigger)
		{
			num ^= IdTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdNextTrigger)
		{
			num ^= IdNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdPreviousTrigger)
		{
			num ^= IdPreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedIndexTrigger)
		{
			num ^= FocusedIndexTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationIndexTrigger)
		{
			num ^= ActivePresentationIndexTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementIndexTrigger)
		{
			num ^= ActiveAnnouncementIndexTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdUpdates)
		{
			num ^= IdUpdates.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationThumbnail)
		{
			num ^= ActivePresentationThumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementThumbnail)
		{
			num ^= ActiveAnnouncementThumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedNext)
		{
			num ^= FocusedNext.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPrevious)
		{
			num ^= FocusedPrevious.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.IdThumbnail)
		{
			num ^= IdThumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			num ^= TimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			num ^= ActivePlaylistPresentationTimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			num ^= ActivePlaylistAnnouncementTimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineOperation)
		{
			num ^= FocusedPlaylistTimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			num ^= ActivePlaylistPresentationTimelineStatus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			num ^= ActivePlaylistAnnouncementTimelineStatus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineStatus)
		{
			num ^= FocusedPlaylistTimelineStatus.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.Playlists)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Playlists);
		}
		if (responseCase_ == ResponseOneofCase.CreatePlaylist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreatePlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.PutPlaylist)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.PostPlaylist)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PostPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetActivePlaylist)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetActivePlaylist);
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Focused);
		}
		if (responseCase_ == ResponseOneofCase.NextFocus)
		{
			output.WriteRawTag(66);
			output.WriteMessage(NextFocus);
		}
		if (responseCase_ == ResponseOneofCase.PreviousFocus)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PreviousFocus);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationFocus)
		{
			output.WriteRawTag(82);
			output.WriteMessage(ActivePresentationFocus);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementFocus)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ActiveAnnouncementFocus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedTrigger)
		{
			output.WriteRawTag(98);
			output.WriteMessage(FocusedTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTrigger)
		{
			output.WriteRawTag(106);
			output.WriteMessage(ActivePresentationTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementTrigger)
		{
			output.WriteRawTag(114);
			output.WriteMessage(ActiveAnnouncementTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedNextTrigger)
		{
			output.WriteRawTag(122);
			output.WriteMessage(FocusedNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPreviousTrigger)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(FocusedPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationNextTrigger)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(ActivePresentationNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementNextTrigger)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(ActiveAnnouncementNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationPreviousTrigger)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(ActivePresentationPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(ActiveAnnouncementPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdFocus)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(IdFocus);
		}
		if (responseCase_ == ResponseOneofCase.IdTrigger)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(IdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdNextTrigger)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(IdNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdPreviousTrigger)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(IdPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedIndexTrigger)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(FocusedIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationIndexTrigger)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(ActivePresentationIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementIndexTrigger)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(ActiveAnnouncementIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdUpdates)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(IdUpdates);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationThumbnail)
		{
			output.WriteRawTag(234, 1);
			output.WriteMessage(ActivePresentationThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementThumbnail)
		{
			output.WriteRawTag(242, 1);
			output.WriteMessage(ActiveAnnouncementThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.FocusedNext)
		{
			output.WriteRawTag(250, 1);
			output.WriteMessage(FocusedNext);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPrevious)
		{
			output.WriteRawTag(130, 2);
			output.WriteMessage(FocusedPrevious);
		}
		if (responseCase_ == ResponseOneofCase.IdThumbnail)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(IdThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			output.WriteRawTag(146, 2);
			output.WriteMessage(TimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			output.WriteRawTag(154, 2);
			output.WriteMessage(ActivePlaylistPresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			output.WriteRawTag(162, 2);
			output.WriteMessage(ActivePlaylistAnnouncementTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineOperation)
		{
			output.WriteRawTag(170, 2);
			output.WriteMessage(FocusedPlaylistTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			output.WriteRawTag(178, 2);
			output.WriteMessage(ActivePlaylistPresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			output.WriteRawTag(186, 2);
			output.WriteMessage(ActivePlaylistAnnouncementTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineStatus)
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
		if (responseCase_ == ResponseOneofCase.Playlists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlists);
		}
		if (responseCase_ == ResponseOneofCase.CreatePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreatePlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.PutPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.PostPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetActivePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetActivePlaylist);
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
		}
		if (responseCase_ == ResponseOneofCase.NextFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(NextFocus);
		}
		if (responseCase_ == ResponseOneofCase.PreviousFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PreviousFocus);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationFocus);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementFocus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedNextTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdFocus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdFocus);
		}
		if (responseCase_ == ResponseOneofCase.IdTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.FocusedIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementIndexTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementIndexTrigger);
		}
		if (responseCase_ == ResponseOneofCase.IdUpdates)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdUpdates);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePresentationThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.ActiveAnnouncementThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActiveAnnouncementThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.FocusedNext)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedNext);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPrevious)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPrevious);
		}
		if (responseCase_ == ResponseOneofCase.IdThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(IdThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistPresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistAnnouncementTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineOperation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FocusedPlaylistTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineStatus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistPresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ActivePlaylistAnnouncementTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineStatus)
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
	public void MergeFrom(API_v1_Playlist_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Playlists:
			if (Playlists == null)
			{
				Playlists = new Types.Playlists();
			}
			Playlists.MergeFrom(other.Playlists);
			break;
		case ResponseOneofCase.CreatePlaylist:
			if (CreatePlaylist == null)
			{
				CreatePlaylist = new Types.CreatePlaylist();
			}
			CreatePlaylist.MergeFrom(other.CreatePlaylist);
			break;
		case ResponseOneofCase.GetPlaylist:
			if (GetPlaylist == null)
			{
				GetPlaylist = new Types.GetPlaylist();
			}
			GetPlaylist.MergeFrom(other.GetPlaylist);
			break;
		case ResponseOneofCase.PutPlaylist:
			if (PutPlaylist == null)
			{
				PutPlaylist = new Types.PutPlaylist();
			}
			PutPlaylist.MergeFrom(other.PutPlaylist);
			break;
		case ResponseOneofCase.PostPlaylist:
			if (PostPlaylist == null)
			{
				PostPlaylist = new Types.PostPlaylist();
			}
			PostPlaylist.MergeFrom(other.PostPlaylist);
			break;
		case ResponseOneofCase.GetActivePlaylist:
			if (GetActivePlaylist == null)
			{
				GetActivePlaylist = new Types.GetActivePlaylist();
			}
			GetActivePlaylist.MergeFrom(other.GetActivePlaylist);
			break;
		case ResponseOneofCase.Focused:
			if (Focused == null)
			{
				Focused = new Types.GetFocusedPlaylist();
			}
			Focused.MergeFrom(other.Focused);
			break;
		case ResponseOneofCase.NextFocus:
			if (NextFocus == null)
			{
				NextFocus = new Types.EmptyMessage();
			}
			NextFocus.MergeFrom(other.NextFocus);
			break;
		case ResponseOneofCase.PreviousFocus:
			if (PreviousFocus == null)
			{
				PreviousFocus = new Types.EmptyMessage();
			}
			PreviousFocus.MergeFrom(other.PreviousFocus);
			break;
		case ResponseOneofCase.ActivePresentationFocus:
			if (ActivePresentationFocus == null)
			{
				ActivePresentationFocus = new Types.EmptyMessage();
			}
			ActivePresentationFocus.MergeFrom(other.ActivePresentationFocus);
			break;
		case ResponseOneofCase.ActiveAnnouncementFocus:
			if (ActiveAnnouncementFocus == null)
			{
				ActiveAnnouncementFocus = new Types.EmptyMessage();
			}
			ActiveAnnouncementFocus.MergeFrom(other.ActiveAnnouncementFocus);
			break;
		case ResponseOneofCase.FocusedTrigger:
			if (FocusedTrigger == null)
			{
				FocusedTrigger = new Types.EmptyMessage();
			}
			FocusedTrigger.MergeFrom(other.FocusedTrigger);
			break;
		case ResponseOneofCase.ActivePresentationTrigger:
			if (ActivePresentationTrigger == null)
			{
				ActivePresentationTrigger = new Types.EmptyMessage();
			}
			ActivePresentationTrigger.MergeFrom(other.ActivePresentationTrigger);
			break;
		case ResponseOneofCase.ActiveAnnouncementTrigger:
			if (ActiveAnnouncementTrigger == null)
			{
				ActiveAnnouncementTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementTrigger.MergeFrom(other.ActiveAnnouncementTrigger);
			break;
		case ResponseOneofCase.FocusedNextTrigger:
			if (FocusedNextTrigger == null)
			{
				FocusedNextTrigger = new Types.EmptyMessage();
			}
			FocusedNextTrigger.MergeFrom(other.FocusedNextTrigger);
			break;
		case ResponseOneofCase.FocusedPreviousTrigger:
			if (FocusedPreviousTrigger == null)
			{
				FocusedPreviousTrigger = new Types.EmptyMessage();
			}
			FocusedPreviousTrigger.MergeFrom(other.FocusedPreviousTrigger);
			break;
		case ResponseOneofCase.ActivePresentationNextTrigger:
			if (ActivePresentationNextTrigger == null)
			{
				ActivePresentationNextTrigger = new Types.EmptyMessage();
			}
			ActivePresentationNextTrigger.MergeFrom(other.ActivePresentationNextTrigger);
			break;
		case ResponseOneofCase.ActiveAnnouncementNextTrigger:
			if (ActiveAnnouncementNextTrigger == null)
			{
				ActiveAnnouncementNextTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementNextTrigger.MergeFrom(other.ActiveAnnouncementNextTrigger);
			break;
		case ResponseOneofCase.ActivePresentationPreviousTrigger:
			if (ActivePresentationPreviousTrigger == null)
			{
				ActivePresentationPreviousTrigger = new Types.EmptyMessage();
			}
			ActivePresentationPreviousTrigger.MergeFrom(other.ActivePresentationPreviousTrigger);
			break;
		case ResponseOneofCase.ActiveAnnouncementPreviousTrigger:
			if (ActiveAnnouncementPreviousTrigger == null)
			{
				ActiveAnnouncementPreviousTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementPreviousTrigger.MergeFrom(other.ActiveAnnouncementPreviousTrigger);
			break;
		case ResponseOneofCase.IdFocus:
			if (IdFocus == null)
			{
				IdFocus = new Types.EmptyMessage();
			}
			IdFocus.MergeFrom(other.IdFocus);
			break;
		case ResponseOneofCase.IdTrigger:
			if (IdTrigger == null)
			{
				IdTrigger = new Types.EmptyMessage();
			}
			IdTrigger.MergeFrom(other.IdTrigger);
			break;
		case ResponseOneofCase.IdNextTrigger:
			if (IdNextTrigger == null)
			{
				IdNextTrigger = new Types.EmptyMessage();
			}
			IdNextTrigger.MergeFrom(other.IdNextTrigger);
			break;
		case ResponseOneofCase.IdPreviousTrigger:
			if (IdPreviousTrigger == null)
			{
				IdPreviousTrigger = new Types.EmptyMessage();
			}
			IdPreviousTrigger.MergeFrom(other.IdPreviousTrigger);
			break;
		case ResponseOneofCase.FocusedIndexTrigger:
			if (FocusedIndexTrigger == null)
			{
				FocusedIndexTrigger = new Types.EmptyMessage();
			}
			FocusedIndexTrigger.MergeFrom(other.FocusedIndexTrigger);
			break;
		case ResponseOneofCase.ActivePresentationIndexTrigger:
			if (ActivePresentationIndexTrigger == null)
			{
				ActivePresentationIndexTrigger = new Types.EmptyMessage();
			}
			ActivePresentationIndexTrigger.MergeFrom(other.ActivePresentationIndexTrigger);
			break;
		case ResponseOneofCase.ActiveAnnouncementIndexTrigger:
			if (ActiveAnnouncementIndexTrigger == null)
			{
				ActiveAnnouncementIndexTrigger = new Types.EmptyMessage();
			}
			ActiveAnnouncementIndexTrigger.MergeFrom(other.ActiveAnnouncementIndexTrigger);
			break;
		case ResponseOneofCase.IdUpdates:
			if (IdUpdates == null)
			{
				IdUpdates = new Types.EmptyMessage();
			}
			IdUpdates.MergeFrom(other.IdUpdates);
			break;
		case ResponseOneofCase.ActivePresentationThumbnail:
			if (ActivePresentationThumbnail == null)
			{
				ActivePresentationThumbnail = new Types.Thumbnail();
			}
			ActivePresentationThumbnail.MergeFrom(other.ActivePresentationThumbnail);
			break;
		case ResponseOneofCase.ActiveAnnouncementThumbnail:
			if (ActiveAnnouncementThumbnail == null)
			{
				ActiveAnnouncementThumbnail = new Types.Thumbnail();
			}
			ActiveAnnouncementThumbnail.MergeFrom(other.ActiveAnnouncementThumbnail);
			break;
		case ResponseOneofCase.FocusedNext:
			if (FocusedNext == null)
			{
				FocusedNext = new Types.GetProximalPlaylistItem();
			}
			FocusedNext.MergeFrom(other.FocusedNext);
			break;
		case ResponseOneofCase.FocusedPrevious:
			if (FocusedPrevious == null)
			{
				FocusedPrevious = new Types.GetProximalPlaylistItem();
			}
			FocusedPrevious.MergeFrom(other.FocusedPrevious);
			break;
		case ResponseOneofCase.IdThumbnail:
			if (IdThumbnail == null)
			{
				IdThumbnail = new Types.Thumbnail();
			}
			IdThumbnail.MergeFrom(other.IdThumbnail);
			break;
		case ResponseOneofCase.TimelineOperation:
			if (TimelineOperation == null)
			{
				TimelineOperation = new Types.TimelineOperation();
			}
			TimelineOperation.MergeFrom(other.TimelineOperation);
			break;
		case ResponseOneofCase.ActivePlaylistPresentationTimelineOperation:
			if (ActivePlaylistPresentationTimelineOperation == null)
			{
				ActivePlaylistPresentationTimelineOperation = new Types.ActivePlaylistTimelineOperation();
			}
			ActivePlaylistPresentationTimelineOperation.MergeFrom(other.ActivePlaylistPresentationTimelineOperation);
			break;
		case ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation:
			if (ActivePlaylistAnnouncementTimelineOperation == null)
			{
				ActivePlaylistAnnouncementTimelineOperation = new Types.ActivePlaylistTimelineOperation();
			}
			ActivePlaylistAnnouncementTimelineOperation.MergeFrom(other.ActivePlaylistAnnouncementTimelineOperation);
			break;
		case ResponseOneofCase.FocusedPlaylistTimelineOperation:
			if (FocusedPlaylistTimelineOperation == null)
			{
				FocusedPlaylistTimelineOperation = new Types.FocusedPlaylistTimelineOperation();
			}
			FocusedPlaylistTimelineOperation.MergeFrom(other.FocusedPlaylistTimelineOperation);
			break;
		case ResponseOneofCase.ActivePlaylistPresentationTimelineStatus:
			if (ActivePlaylistPresentationTimelineStatus == null)
			{
				ActivePlaylistPresentationTimelineStatus = new Types.ActivePlaylistTimelineStatus();
			}
			ActivePlaylistPresentationTimelineStatus.MergeFrom(other.ActivePlaylistPresentationTimelineStatus);
			break;
		case ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus:
			if (ActivePlaylistAnnouncementTimelineStatus == null)
			{
				ActivePlaylistAnnouncementTimelineStatus = new Types.ActivePlaylistTimelineStatus();
			}
			ActivePlaylistAnnouncementTimelineStatus.MergeFrom(other.ActivePlaylistAnnouncementTimelineStatus);
			break;
		case ResponseOneofCase.FocusedPlaylistTimelineStatus:
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
				if (responseCase_ == ResponseOneofCase.Playlists)
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
				if (responseCase_ == ResponseOneofCase.CreatePlaylist)
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
				if (responseCase_ == ResponseOneofCase.GetPlaylist)
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
				if (responseCase_ == ResponseOneofCase.PutPlaylist)
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
				if (responseCase_ == ResponseOneofCase.PostPlaylist)
				{
					postPlaylist.MergeFrom(PostPlaylist);
				}
				input.ReadMessage(postPlaylist);
				PostPlaylist = postPlaylist;
				break;
			}
			case 50u:
			{
				Types.GetActivePlaylist getActivePlaylist = new Types.GetActivePlaylist();
				if (responseCase_ == ResponseOneofCase.GetActivePlaylist)
				{
					getActivePlaylist.MergeFrom(GetActivePlaylist);
				}
				input.ReadMessage(getActivePlaylist);
				GetActivePlaylist = getActivePlaylist;
				break;
			}
			case 58u:
			{
				Types.GetFocusedPlaylist getFocusedPlaylist = new Types.GetFocusedPlaylist();
				if (responseCase_ == ResponseOneofCase.Focused)
				{
					getFocusedPlaylist.MergeFrom(Focused);
				}
				input.ReadMessage(getFocusedPlaylist);
				Focused = getFocusedPlaylist;
				break;
			}
			case 66u:
			{
				Types.EmptyMessage emptyMessage16 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.NextFocus)
				{
					emptyMessage16.MergeFrom(NextFocus);
				}
				input.ReadMessage(emptyMessage16);
				NextFocus = emptyMessage16;
				break;
			}
			case 74u:
			{
				Types.EmptyMessage emptyMessage12 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PreviousFocus)
				{
					emptyMessage12.MergeFrom(PreviousFocus);
				}
				input.ReadMessage(emptyMessage12);
				PreviousFocus = emptyMessage12;
				break;
			}
			case 82u:
			{
				Types.EmptyMessage emptyMessage7 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActivePresentationFocus)
				{
					emptyMessage7.MergeFrom(ActivePresentationFocus);
				}
				input.ReadMessage(emptyMessage7);
				ActivePresentationFocus = emptyMessage7;
				break;
			}
			case 90u:
			{
				Types.EmptyMessage emptyMessage6 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementFocus)
				{
					emptyMessage6.MergeFrom(ActiveAnnouncementFocus);
				}
				input.ReadMessage(emptyMessage6);
				ActiveAnnouncementFocus = emptyMessage6;
				break;
			}
			case 98u:
			{
				Types.EmptyMessage emptyMessage17 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.FocusedTrigger)
				{
					emptyMessage17.MergeFrom(FocusedTrigger);
				}
				input.ReadMessage(emptyMessage17);
				FocusedTrigger = emptyMessage17;
				break;
			}
			case 106u:
			{
				Types.EmptyMessage emptyMessage15 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActivePresentationTrigger)
				{
					emptyMessage15.MergeFrom(ActivePresentationTrigger);
				}
				input.ReadMessage(emptyMessage15);
				ActivePresentationTrigger = emptyMessage15;
				break;
			}
			case 114u:
			{
				Types.EmptyMessage emptyMessage11 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementTrigger)
				{
					emptyMessage11.MergeFrom(ActiveAnnouncementTrigger);
				}
				input.ReadMessage(emptyMessage11);
				ActiveAnnouncementTrigger = emptyMessage11;
				break;
			}
			case 122u:
			{
				Types.EmptyMessage emptyMessage10 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.FocusedNextTrigger)
				{
					emptyMessage10.MergeFrom(FocusedNextTrigger);
				}
				input.ReadMessage(emptyMessage10);
				FocusedNextTrigger = emptyMessage10;
				break;
			}
			case 130u:
			{
				Types.EmptyMessage emptyMessage3 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.FocusedPreviousTrigger)
				{
					emptyMessage3.MergeFrom(FocusedPreviousTrigger);
				}
				input.ReadMessage(emptyMessage3);
				FocusedPreviousTrigger = emptyMessage3;
				break;
			}
			case 138u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActivePresentationNextTrigger)
				{
					emptyMessage2.MergeFrom(ActivePresentationNextTrigger);
				}
				input.ReadMessage(emptyMessage2);
				ActivePresentationNextTrigger = emptyMessage2;
				break;
			}
			case 146u:
			{
				Types.EmptyMessage emptyMessage20 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementNextTrigger)
				{
					emptyMessage20.MergeFrom(ActiveAnnouncementNextTrigger);
				}
				input.ReadMessage(emptyMessage20);
				ActiveAnnouncementNextTrigger = emptyMessage20;
				break;
			}
			case 154u:
			{
				Types.EmptyMessage emptyMessage18 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActivePresentationPreviousTrigger)
				{
					emptyMessage18.MergeFrom(ActivePresentationPreviousTrigger);
				}
				input.ReadMessage(emptyMessage18);
				ActivePresentationPreviousTrigger = emptyMessage18;
				break;
			}
			case 162u:
			{
				Types.EmptyMessage emptyMessage14 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementPreviousTrigger)
				{
					emptyMessage14.MergeFrom(ActiveAnnouncementPreviousTrigger);
				}
				input.ReadMessage(emptyMessage14);
				ActiveAnnouncementPreviousTrigger = emptyMessage14;
				break;
			}
			case 170u:
			{
				Types.EmptyMessage emptyMessage13 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.IdFocus)
				{
					emptyMessage13.MergeFrom(IdFocus);
				}
				input.ReadMessage(emptyMessage13);
				IdFocus = emptyMessage13;
				break;
			}
			case 178u:
			{
				Types.EmptyMessage emptyMessage9 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.IdTrigger)
				{
					emptyMessage9.MergeFrom(IdTrigger);
				}
				input.ReadMessage(emptyMessage9);
				IdTrigger = emptyMessage9;
				break;
			}
			case 186u:
			{
				Types.EmptyMessage emptyMessage8 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.IdNextTrigger)
				{
					emptyMessage8.MergeFrom(IdNextTrigger);
				}
				input.ReadMessage(emptyMessage8);
				IdNextTrigger = emptyMessage8;
				break;
			}
			case 194u:
			{
				Types.EmptyMessage emptyMessage5 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.IdPreviousTrigger)
				{
					emptyMessage5.MergeFrom(IdPreviousTrigger);
				}
				input.ReadMessage(emptyMessage5);
				IdPreviousTrigger = emptyMessage5;
				break;
			}
			case 202u:
			{
				Types.EmptyMessage emptyMessage4 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.FocusedIndexTrigger)
				{
					emptyMessage4.MergeFrom(FocusedIndexTrigger);
				}
				input.ReadMessage(emptyMessage4);
				FocusedIndexTrigger = emptyMessage4;
				break;
			}
			case 210u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActivePresentationIndexTrigger)
				{
					emptyMessage.MergeFrom(ActivePresentationIndexTrigger);
				}
				input.ReadMessage(emptyMessage);
				ActivePresentationIndexTrigger = emptyMessage;
				break;
			}
			case 218u:
			{
				Types.EmptyMessage emptyMessage21 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementIndexTrigger)
				{
					emptyMessage21.MergeFrom(ActiveAnnouncementIndexTrigger);
				}
				input.ReadMessage(emptyMessage21);
				ActiveAnnouncementIndexTrigger = emptyMessage21;
				break;
			}
			case 226u:
			{
				Types.EmptyMessage emptyMessage19 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.IdUpdates)
				{
					emptyMessage19.MergeFrom(IdUpdates);
				}
				input.ReadMessage(emptyMessage19);
				IdUpdates = emptyMessage19;
				break;
			}
			case 234u:
			{
				Types.Thumbnail thumbnail3 = new Types.Thumbnail();
				if (responseCase_ == ResponseOneofCase.ActivePresentationThumbnail)
				{
					thumbnail3.MergeFrom(ActivePresentationThumbnail);
				}
				input.ReadMessage(thumbnail3);
				ActivePresentationThumbnail = thumbnail3;
				break;
			}
			case 242u:
			{
				Types.Thumbnail thumbnail2 = new Types.Thumbnail();
				if (responseCase_ == ResponseOneofCase.ActiveAnnouncementThumbnail)
				{
					thumbnail2.MergeFrom(ActiveAnnouncementThumbnail);
				}
				input.ReadMessage(thumbnail2);
				ActiveAnnouncementThumbnail = thumbnail2;
				break;
			}
			case 250u:
			{
				Types.GetProximalPlaylistItem getProximalPlaylistItem2 = new Types.GetProximalPlaylistItem();
				if (responseCase_ == ResponseOneofCase.FocusedNext)
				{
					getProximalPlaylistItem2.MergeFrom(FocusedNext);
				}
				input.ReadMessage(getProximalPlaylistItem2);
				FocusedNext = getProximalPlaylistItem2;
				break;
			}
			case 258u:
			{
				Types.GetProximalPlaylistItem getProximalPlaylistItem = new Types.GetProximalPlaylistItem();
				if (responseCase_ == ResponseOneofCase.FocusedPrevious)
				{
					getProximalPlaylistItem.MergeFrom(FocusedPrevious);
				}
				input.ReadMessage(getProximalPlaylistItem);
				FocusedPrevious = getProximalPlaylistItem;
				break;
			}
			case 266u:
			{
				Types.Thumbnail thumbnail = new Types.Thumbnail();
				if (responseCase_ == ResponseOneofCase.IdThumbnail)
				{
					thumbnail.MergeFrom(IdThumbnail);
				}
				input.ReadMessage(thumbnail);
				IdThumbnail = thumbnail;
				break;
			}
			case 274u:
			{
				Types.TimelineOperation timelineOperation = new Types.TimelineOperation();
				if (responseCase_ == ResponseOneofCase.TimelineOperation)
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
				if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineOperation)
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
				if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineOperation)
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
				if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineOperation)
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
				if (responseCase_ == ResponseOneofCase.ActivePlaylistPresentationTimelineStatus)
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
				if (responseCase_ == ResponseOneofCase.ActivePlaylistAnnouncementTimelineStatus)
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
				if (responseCase_ == ResponseOneofCase.FocusedPlaylistTimelineStatus)
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
