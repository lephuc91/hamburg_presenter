using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Audio_Response : IMessage<API_v1_Audio_Response>, IMessage, IEquatable<API_v1_Audio_Response>, IDeepCloneable<API_v1_Audio_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Playlists,
		Playlist,
		Update,
		PlaylistFocused,
		PlaylistActive,
		PlaylistNextFocus,
		PlaylistPreviousFocus,
		PlaylistActiveFocus,
		PlaylistIdFocus,
		PlaylistFocusedTrigger,
		PlaylistActiveTrigger,
		PlaylistIdTrigger,
		PlaylistFocusedNextTrigger,
		PlaylistFocusedPreviousTrigger,
		PlaylistFocusedIdTrigger,
		PlaylistActiveNextTrigger,
		PlaylistActivePreviousTrigger,
		PlaylistActiveIdTrigger,
		PlaylistIdNextTrigger,
		PlaylistIdPreviousTrigger
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
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[0];

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
		public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
		{
			private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			public const int ItemsFieldNumber = 2;

			private static readonly FieldCodec<API_v1_MediaPlaylistItem> _repeated_items_codec = FieldCodec.ForMessage(18u, API_v1_MediaPlaylistItem.Parser);

			private readonly RepeatedField<API_v1_MediaPlaylistItem> items_ = new RepeatedField<API_v1_MediaPlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[1];

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
			public RepeatedField<API_v1_MediaPlaylistItem> Items => items_;

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
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				items_ = other.items_.Clone();
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
			public void MergeFrom(Playlist other)
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
		public sealed class PlaylistUpdate : IMessage<PlaylistUpdate>, IMessage, IEquatable<PlaylistUpdate>, IDeepCloneable<PlaylistUpdate>
		{
			private static readonly MessageParser<PlaylistUpdate> _parser = new MessageParser<PlaylistUpdate>(() => new PlaylistUpdate());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistUpdate> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[2];

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
			public PlaylistUpdate()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistUpdate(PlaylistUpdate other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistUpdate Clone()
			{
				return new PlaylistUpdate(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistUpdate);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistUpdate other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PlaylistUpdate other)
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
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					input.ReadMessage(Id);
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
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[3];

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
		public sealed class FocusedPlaylist : IMessage<FocusedPlaylist>, IMessage, IEquatable<FocusedPlaylist>, IDeepCloneable<FocusedPlaylist>
		{
			private static readonly MessageParser<FocusedPlaylist> _parser = new MessageParser<FocusedPlaylist>(() => new FocusedPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[4];

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
			public FocusedPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylist(FocusedPlaylist other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPlaylist Clone()
			{
				return new FocusedPlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusedPlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusedPlaylist other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusedPlaylist other)
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
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					input.ReadMessage(Id);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivePlaylist : IMessage<ActivePlaylist>, IMessage, IEquatable<ActivePlaylist>, IDeepCloneable<ActivePlaylist>
		{
			private static readonly MessageParser<ActivePlaylist> _parser = new MessageParser<ActivePlaylist>(() => new ActivePlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistFieldNumber = 1;

			private API_v1_Identifier playlist_;

			public const int ItemFieldNumber = 2;

			private API_v1_Identifier item_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Playlist
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
			public ActivePlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylist(ActivePlaylist other)
				: this()
			{
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
				item_ = ((other.item_ != null) ? other.item_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePlaylist Clone()
			{
				return new ActivePlaylist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePlaylist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePlaylist other)
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
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
				}
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
				if (playlist_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Playlist);
				}
				if (item_ != null)
				{
					output.WriteRawTag(18);
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
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
				}
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
			public void MergeFrom(ActivePlaylist other)
			{
				if (other == null)
				{
					return;
				}
				if (other.playlist_ != null)
				{
					if (playlist_ == null)
					{
						Playlist = new API_v1_Identifier();
					}
					Playlist.MergeFrom(other.Playlist);
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						if (playlist_ == null)
						{
							Playlist = new API_v1_Identifier();
						}
						input.ReadMessage(Playlist);
						break;
					case 18u:
						if (item_ == null)
						{
							Item = new API_v1_Identifier();
						}
						input.ReadMessage(Item);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Audio_Response> _parser = new MessageParser<API_v1_Audio_Response>(() => new API_v1_Audio_Response());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	public const int PlaylistFieldNumber = 2;

	public const int UpdateFieldNumber = 3;

	public const int PlaylistFocusedFieldNumber = 4;

	public const int PlaylistActiveFieldNumber = 5;

	public const int PlaylistNextFocusFieldNumber = 6;

	public const int PlaylistPreviousFocusFieldNumber = 7;

	public const int PlaylistActiveFocusFieldNumber = 8;

	public const int PlaylistIdFocusFieldNumber = 9;

	public const int PlaylistFocusedTriggerFieldNumber = 10;

	public const int PlaylistActiveTriggerFieldNumber = 11;

	public const int PlaylistIdTriggerFieldNumber = 12;

	public const int PlaylistFocusedNextTriggerFieldNumber = 13;

	public const int PlaylistFocusedPreviousTriggerFieldNumber = 14;

	public const int PlaylistFocusedIdTriggerFieldNumber = 15;

	public const int PlaylistActiveNextTriggerFieldNumber = 16;

	public const int PlaylistActivePreviousTriggerFieldNumber = 17;

	public const int PlaylistActiveIdTriggerFieldNumber = 18;

	public const int PlaylistIdNextTriggerFieldNumber = 19;

	public const int PlaylistIdPreviousTriggerFieldNumber = 20;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Audio_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1AudioReflection.Descriptor.MessageTypes[1];

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
	public Types.Playlist Playlist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Playlist)
			{
				return null;
			}
			return (Types.Playlist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Playlist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistUpdate Update
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Update)
			{
				return null;
			}
			return (Types.PlaylistUpdate)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Update : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPlaylist PlaylistFocused
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocused)
			{
				return null;
			}
			return (Types.FocusedPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocused : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePlaylist PlaylistActive
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActive)
			{
				return null;
			}
			return (Types.ActivePlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActive : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistNextFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistNextFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistNextFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistPreviousFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistPreviousFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistPreviousFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActiveFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActiveFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistIdFocus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistIdFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistIdFocus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocusedTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocusedTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActiveTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActiveTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistIdTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistIdTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistIdTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocusedNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocusedNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocusedPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocusedPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedIdTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocusedIdTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocusedIdTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActiveNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActiveNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActivePreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActivePreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActivePreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveIdTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActiveIdTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActiveIdTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistIdNextTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistIdNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistIdNextTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistIdPreviousTrigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistIdPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistIdPreviousTrigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Response(API_v1_Audio_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case ResponseOneofCase.Playlist:
			Playlist = other.Playlist.Clone();
			break;
		case ResponseOneofCase.Update:
			Update = other.Update.Clone();
			break;
		case ResponseOneofCase.PlaylistFocused:
			PlaylistFocused = other.PlaylistFocused.Clone();
			break;
		case ResponseOneofCase.PlaylistActive:
			PlaylistActive = other.PlaylistActive.Clone();
			break;
		case ResponseOneofCase.PlaylistNextFocus:
			PlaylistNextFocus = other.PlaylistNextFocus.Clone();
			break;
		case ResponseOneofCase.PlaylistPreviousFocus:
			PlaylistPreviousFocus = other.PlaylistPreviousFocus.Clone();
			break;
		case ResponseOneofCase.PlaylistActiveFocus:
			PlaylistActiveFocus = other.PlaylistActiveFocus.Clone();
			break;
		case ResponseOneofCase.PlaylistIdFocus:
			PlaylistIdFocus = other.PlaylistIdFocus.Clone();
			break;
		case ResponseOneofCase.PlaylistFocusedTrigger:
			PlaylistFocusedTrigger = other.PlaylistFocusedTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistActiveTrigger:
			PlaylistActiveTrigger = other.PlaylistActiveTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistIdTrigger:
			PlaylistIdTrigger = other.PlaylistIdTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistFocusedNextTrigger:
			PlaylistFocusedNextTrigger = other.PlaylistFocusedNextTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistFocusedPreviousTrigger:
			PlaylistFocusedPreviousTrigger = other.PlaylistFocusedPreviousTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistFocusedIdTrigger:
			PlaylistFocusedIdTrigger = other.PlaylistFocusedIdTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistActiveNextTrigger:
			PlaylistActiveNextTrigger = other.PlaylistActiveNextTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistActivePreviousTrigger:
			PlaylistActivePreviousTrigger = other.PlaylistActivePreviousTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistActiveIdTrigger:
			PlaylistActiveIdTrigger = other.PlaylistActiveIdTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistIdNextTrigger:
			PlaylistIdNextTrigger = other.PlaylistIdNextTrigger.Clone();
			break;
		case ResponseOneofCase.PlaylistIdPreviousTrigger:
			PlaylistIdPreviousTrigger = other.PlaylistIdPreviousTrigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Response Clone()
	{
		return new API_v1_Audio_Response(this);
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
		return Equals(other as API_v1_Audio_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Audio_Response other)
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
		if (!object.Equals(Playlist, other.Playlist))
		{
			return false;
		}
		if (!object.Equals(Update, other.Update))
		{
			return false;
		}
		if (!object.Equals(PlaylistFocused, other.PlaylistFocused))
		{
			return false;
		}
		if (!object.Equals(PlaylistActive, other.PlaylistActive))
		{
			return false;
		}
		if (!object.Equals(PlaylistNextFocus, other.PlaylistNextFocus))
		{
			return false;
		}
		if (!object.Equals(PlaylistPreviousFocus, other.PlaylistPreviousFocus))
		{
			return false;
		}
		if (!object.Equals(PlaylistActiveFocus, other.PlaylistActiveFocus))
		{
			return false;
		}
		if (!object.Equals(PlaylistIdFocus, other.PlaylistIdFocus))
		{
			return false;
		}
		if (!object.Equals(PlaylistFocusedTrigger, other.PlaylistFocusedTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistActiveTrigger, other.PlaylistActiveTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistIdTrigger, other.PlaylistIdTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistFocusedNextTrigger, other.PlaylistFocusedNextTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistFocusedPreviousTrigger, other.PlaylistFocusedPreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistFocusedIdTrigger, other.PlaylistFocusedIdTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistActiveNextTrigger, other.PlaylistActiveNextTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistActivePreviousTrigger, other.PlaylistActivePreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistActiveIdTrigger, other.PlaylistActiveIdTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistIdNextTrigger, other.PlaylistIdNextTrigger))
		{
			return false;
		}
		if (!object.Equals(PlaylistIdPreviousTrigger, other.PlaylistIdPreviousTrigger))
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
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			num ^= Playlist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Update)
		{
			num ^= Update.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			num ^= PlaylistFocused.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			num ^= PlaylistActive.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistNextFocus)
		{
			num ^= PlaylistNextFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistPreviousFocus)
		{
			num ^= PlaylistPreviousFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveFocus)
		{
			num ^= PlaylistActiveFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdFocus)
		{
			num ^= PlaylistIdFocus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedTrigger)
		{
			num ^= PlaylistFocusedTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveTrigger)
		{
			num ^= PlaylistActiveTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdTrigger)
		{
			num ^= PlaylistIdTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedNextTrigger)
		{
			num ^= PlaylistFocusedNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedPreviousTrigger)
		{
			num ^= PlaylistFocusedPreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedIdTrigger)
		{
			num ^= PlaylistFocusedIdTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveNextTrigger)
		{
			num ^= PlaylistActiveNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActivePreviousTrigger)
		{
			num ^= PlaylistActivePreviousTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveIdTrigger)
		{
			num ^= PlaylistActiveIdTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdNextTrigger)
		{
			num ^= PlaylistIdNextTrigger.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdPreviousTrigger)
		{
			num ^= PlaylistIdPreviousTrigger.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Playlist);
		}
		if (responseCase_ == ResponseOneofCase.Update)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Update);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PlaylistFocused);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PlaylistActive);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistNextFocus)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PlaylistNextFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistPreviousFocus)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PlaylistPreviousFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveFocus)
		{
			output.WriteRawTag(66);
			output.WriteMessage(PlaylistActiveFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdFocus)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PlaylistIdFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedTrigger)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PlaylistFocusedTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveTrigger)
		{
			output.WriteRawTag(90);
			output.WriteMessage(PlaylistActiveTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdTrigger)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PlaylistIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedNextTrigger)
		{
			output.WriteRawTag(106);
			output.WriteMessage(PlaylistFocusedNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedPreviousTrigger)
		{
			output.WriteRawTag(114);
			output.WriteMessage(PlaylistFocusedPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedIdTrigger)
		{
			output.WriteRawTag(122);
			output.WriteMessage(PlaylistFocusedIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveNextTrigger)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(PlaylistActiveNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActivePreviousTrigger)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(PlaylistActivePreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveIdTrigger)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(PlaylistActiveIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdNextTrigger)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(PlaylistIdNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdPreviousTrigger)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(PlaylistIdPreviousTrigger);
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
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
		}
		if (responseCase_ == ResponseOneofCase.Update)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Update);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocused);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActive);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistNextFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistNextFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistPreviousFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistPreviousFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActiveFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIdFocus);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActiveTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedNextTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedPreviousTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedPreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocusedIdTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActiveNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActivePreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActivePreviousTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActiveIdTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActiveIdTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistIdNextTrigger);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistIdPreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistIdPreviousTrigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Audio_Response other)
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
		case ResponseOneofCase.Playlist:
			if (Playlist == null)
			{
				Playlist = new Types.Playlist();
			}
			Playlist.MergeFrom(other.Playlist);
			break;
		case ResponseOneofCase.Update:
			if (Update == null)
			{
				Update = new Types.PlaylistUpdate();
			}
			Update.MergeFrom(other.Update);
			break;
		case ResponseOneofCase.PlaylistFocused:
			if (PlaylistFocused == null)
			{
				PlaylistFocused = new Types.FocusedPlaylist();
			}
			PlaylistFocused.MergeFrom(other.PlaylistFocused);
			break;
		case ResponseOneofCase.PlaylistActive:
			if (PlaylistActive == null)
			{
				PlaylistActive = new Types.ActivePlaylist();
			}
			PlaylistActive.MergeFrom(other.PlaylistActive);
			break;
		case ResponseOneofCase.PlaylistNextFocus:
			if (PlaylistNextFocus == null)
			{
				PlaylistNextFocus = new Types.EmptyMessage();
			}
			PlaylistNextFocus.MergeFrom(other.PlaylistNextFocus);
			break;
		case ResponseOneofCase.PlaylistPreviousFocus:
			if (PlaylistPreviousFocus == null)
			{
				PlaylistPreviousFocus = new Types.EmptyMessage();
			}
			PlaylistPreviousFocus.MergeFrom(other.PlaylistPreviousFocus);
			break;
		case ResponseOneofCase.PlaylistActiveFocus:
			if (PlaylistActiveFocus == null)
			{
				PlaylistActiveFocus = new Types.EmptyMessage();
			}
			PlaylistActiveFocus.MergeFrom(other.PlaylistActiveFocus);
			break;
		case ResponseOneofCase.PlaylistIdFocus:
			if (PlaylistIdFocus == null)
			{
				PlaylistIdFocus = new Types.EmptyMessage();
			}
			PlaylistIdFocus.MergeFrom(other.PlaylistIdFocus);
			break;
		case ResponseOneofCase.PlaylistFocusedTrigger:
			if (PlaylistFocusedTrigger == null)
			{
				PlaylistFocusedTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedTrigger.MergeFrom(other.PlaylistFocusedTrigger);
			break;
		case ResponseOneofCase.PlaylistActiveTrigger:
			if (PlaylistActiveTrigger == null)
			{
				PlaylistActiveTrigger = new Types.EmptyMessage();
			}
			PlaylistActiveTrigger.MergeFrom(other.PlaylistActiveTrigger);
			break;
		case ResponseOneofCase.PlaylistIdTrigger:
			if (PlaylistIdTrigger == null)
			{
				PlaylistIdTrigger = new Types.EmptyMessage();
			}
			PlaylistIdTrigger.MergeFrom(other.PlaylistIdTrigger);
			break;
		case ResponseOneofCase.PlaylistFocusedNextTrigger:
			if (PlaylistFocusedNextTrigger == null)
			{
				PlaylistFocusedNextTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedNextTrigger.MergeFrom(other.PlaylistFocusedNextTrigger);
			break;
		case ResponseOneofCase.PlaylistFocusedPreviousTrigger:
			if (PlaylistFocusedPreviousTrigger == null)
			{
				PlaylistFocusedPreviousTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedPreviousTrigger.MergeFrom(other.PlaylistFocusedPreviousTrigger);
			break;
		case ResponseOneofCase.PlaylistFocusedIdTrigger:
			if (PlaylistFocusedIdTrigger == null)
			{
				PlaylistFocusedIdTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedIdTrigger.MergeFrom(other.PlaylistFocusedIdTrigger);
			break;
		case ResponseOneofCase.PlaylistActiveNextTrigger:
			if (PlaylistActiveNextTrigger == null)
			{
				PlaylistActiveNextTrigger = new Types.EmptyMessage();
			}
			PlaylistActiveNextTrigger.MergeFrom(other.PlaylistActiveNextTrigger);
			break;
		case ResponseOneofCase.PlaylistActivePreviousTrigger:
			if (PlaylistActivePreviousTrigger == null)
			{
				PlaylistActivePreviousTrigger = new Types.EmptyMessage();
			}
			PlaylistActivePreviousTrigger.MergeFrom(other.PlaylistActivePreviousTrigger);
			break;
		case ResponseOneofCase.PlaylistActiveIdTrigger:
			if (PlaylistActiveIdTrigger == null)
			{
				PlaylistActiveIdTrigger = new Types.EmptyMessage();
			}
			PlaylistActiveIdTrigger.MergeFrom(other.PlaylistActiveIdTrigger);
			break;
		case ResponseOneofCase.PlaylistIdNextTrigger:
			if (PlaylistIdNextTrigger == null)
			{
				PlaylistIdNextTrigger = new Types.EmptyMessage();
			}
			PlaylistIdNextTrigger.MergeFrom(other.PlaylistIdNextTrigger);
			break;
		case ResponseOneofCase.PlaylistIdPreviousTrigger:
			if (PlaylistIdPreviousTrigger == null)
			{
				PlaylistIdPreviousTrigger = new Types.EmptyMessage();
			}
			PlaylistIdPreviousTrigger.MergeFrom(other.PlaylistIdPreviousTrigger);
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
				Types.Playlist playlist = new Types.Playlist();
				if (responseCase_ == ResponseOneofCase.Playlist)
				{
					playlist.MergeFrom(Playlist);
				}
				input.ReadMessage(playlist);
				Playlist = playlist;
				break;
			}
			case 26u:
			{
				Types.PlaylistUpdate playlistUpdate = new Types.PlaylistUpdate();
				if (responseCase_ == ResponseOneofCase.Update)
				{
					playlistUpdate.MergeFrom(Update);
				}
				input.ReadMessage(playlistUpdate);
				Update = playlistUpdate;
				break;
			}
			case 34u:
			{
				Types.FocusedPlaylist focusedPlaylist = new Types.FocusedPlaylist();
				if (responseCase_ == ResponseOneofCase.PlaylistFocused)
				{
					focusedPlaylist.MergeFrom(PlaylistFocused);
				}
				input.ReadMessage(focusedPlaylist);
				PlaylistFocused = focusedPlaylist;
				break;
			}
			case 42u:
			{
				Types.ActivePlaylist activePlaylist = new Types.ActivePlaylist();
				if (responseCase_ == ResponseOneofCase.PlaylistActive)
				{
					activePlaylist.MergeFrom(PlaylistActive);
				}
				input.ReadMessage(activePlaylist);
				PlaylistActive = activePlaylist;
				break;
			}
			case 50u:
			{
				Types.EmptyMessage emptyMessage13 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistNextFocus)
				{
					emptyMessage13.MergeFrom(PlaylistNextFocus);
				}
				input.ReadMessage(emptyMessage13);
				PlaylistNextFocus = emptyMessage13;
				break;
			}
			case 58u:
			{
				Types.EmptyMessage emptyMessage11 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistPreviousFocus)
				{
					emptyMessage11.MergeFrom(PlaylistPreviousFocus);
				}
				input.ReadMessage(emptyMessage11);
				PlaylistPreviousFocus = emptyMessage11;
				break;
			}
			case 66u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistActiveFocus)
				{
					emptyMessage2.MergeFrom(PlaylistActiveFocus);
				}
				input.ReadMessage(emptyMessage2);
				PlaylistActiveFocus = emptyMessage2;
				break;
			}
			case 74u:
			{
				Types.EmptyMessage emptyMessage15 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistIdFocus)
				{
					emptyMessage15.MergeFrom(PlaylistIdFocus);
				}
				input.ReadMessage(emptyMessage15);
				PlaylistIdFocus = emptyMessage15;
				break;
			}
			case 82u:
			{
				Types.EmptyMessage emptyMessage10 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistFocusedTrigger)
				{
					emptyMessage10.MergeFrom(PlaylistFocusedTrigger);
				}
				input.ReadMessage(emptyMessage10);
				PlaylistFocusedTrigger = emptyMessage10;
				break;
			}
			case 90u:
			{
				Types.EmptyMessage emptyMessage8 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistActiveTrigger)
				{
					emptyMessage8.MergeFrom(PlaylistActiveTrigger);
				}
				input.ReadMessage(emptyMessage8);
				PlaylistActiveTrigger = emptyMessage8;
				break;
			}
			case 98u:
			{
				Types.EmptyMessage emptyMessage5 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistIdTrigger)
				{
					emptyMessage5.MergeFrom(PlaylistIdTrigger);
				}
				input.ReadMessage(emptyMessage5);
				PlaylistIdTrigger = emptyMessage5;
				break;
			}
			case 106u:
			{
				Types.EmptyMessage emptyMessage3 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistFocusedNextTrigger)
				{
					emptyMessage3.MergeFrom(PlaylistFocusedNextTrigger);
				}
				input.ReadMessage(emptyMessage3);
				PlaylistFocusedNextTrigger = emptyMessage3;
				break;
			}
			case 114u:
			{
				Types.EmptyMessage emptyMessage14 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistFocusedPreviousTrigger)
				{
					emptyMessage14.MergeFrom(PlaylistFocusedPreviousTrigger);
				}
				input.ReadMessage(emptyMessage14);
				PlaylistFocusedPreviousTrigger = emptyMessage14;
				break;
			}
			case 122u:
			{
				Types.EmptyMessage emptyMessage12 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistFocusedIdTrigger)
				{
					emptyMessage12.MergeFrom(PlaylistFocusedIdTrigger);
				}
				input.ReadMessage(emptyMessage12);
				PlaylistFocusedIdTrigger = emptyMessage12;
				break;
			}
			case 130u:
			{
				Types.EmptyMessage emptyMessage9 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistActiveNextTrigger)
				{
					emptyMessage9.MergeFrom(PlaylistActiveNextTrigger);
				}
				input.ReadMessage(emptyMessage9);
				PlaylistActiveNextTrigger = emptyMessage9;
				break;
			}
			case 138u:
			{
				Types.EmptyMessage emptyMessage7 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistActivePreviousTrigger)
				{
					emptyMessage7.MergeFrom(PlaylistActivePreviousTrigger);
				}
				input.ReadMessage(emptyMessage7);
				PlaylistActivePreviousTrigger = emptyMessage7;
				break;
			}
			case 146u:
			{
				Types.EmptyMessage emptyMessage6 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistActiveIdTrigger)
				{
					emptyMessage6.MergeFrom(PlaylistActiveIdTrigger);
				}
				input.ReadMessage(emptyMessage6);
				PlaylistActiveIdTrigger = emptyMessage6;
				break;
			}
			case 154u:
			{
				Types.EmptyMessage emptyMessage4 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistIdNextTrigger)
				{
					emptyMessage4.MergeFrom(PlaylistIdNextTrigger);
				}
				input.ReadMessage(emptyMessage4);
				PlaylistIdNextTrigger = emptyMessage4;
				break;
			}
			case 162u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.PlaylistIdPreviousTrigger)
				{
					emptyMessage.MergeFrom(PlaylistIdPreviousTrigger);
				}
				input.ReadMessage(emptyMessage);
				PlaylistIdPreviousTrigger = emptyMessage;
				break;
			}
			}
		}
	}
}
