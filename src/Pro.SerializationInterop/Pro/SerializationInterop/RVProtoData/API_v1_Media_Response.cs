using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Media_Response : IMessage<API_v1_Media_Response>, IMessage, IEquatable<API_v1_Media_Response>, IDeepCloneable<API_v1_Media_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Playlists,
		GetPlaylist,
		GetPlaylistUpdates,
		GetThumbnail,
		PlaylistFocused,
		PlaylistActive,
		Focus,
		Trigger
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
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[0];

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
		public sealed class GetPlaylist : IMessage<GetPlaylist>, IMessage, IEquatable<GetPlaylist>, IDeepCloneable<GetPlaylist>
		{
			private static readonly MessageParser<GetPlaylist> _parser = new MessageParser<GetPlaylist>(() => new GetPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			public const int ItemsFieldNumber = 2;

			private static readonly FieldCodec<API_v1_MediaPlaylistItem> _repeated_items_codec = FieldCodec.ForMessage(18u, API_v1_MediaPlaylistItem.Parser);

			private readonly RepeatedField<API_v1_MediaPlaylistItem> items_ = new RepeatedField<API_v1_MediaPlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[1];

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
		public sealed class GetPlaylistUpdates : IMessage<GetPlaylistUpdates>, IMessage, IEquatable<GetPlaylistUpdates>, IDeepCloneable<GetPlaylistUpdates>
		{
			private static readonly MessageParser<GetPlaylistUpdates> _parser = new MessageParser<GetPlaylistUpdates>(() => new GetPlaylistUpdates());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylistUpdates> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[2];

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
			public GetPlaylistUpdates()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylistUpdates(GetPlaylistUpdates other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylistUpdates Clone()
			{
				return new GetPlaylistUpdates(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPlaylistUpdates);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPlaylistUpdates other)
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
			public void MergeFrom(GetPlaylistUpdates other)
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
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int ThumbnailDataFieldNumber = 2;

			private ByteString thumbnailData_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[3];

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
			public ByteString ThumbnailData
			{
				get
				{
					return thumbnailData_;
				}
				set
				{
					thumbnailData_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail(GetThumbnail other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				thumbnailData_ = other.thumbnailData_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail Clone()
			{
				return new GetThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThumbnail other)
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
				if (ThumbnailData != other.ThumbnailData)
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
				if (ThumbnailData.Length != 0)
				{
					num ^= ThumbnailData.GetHashCode();
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
				if (ThumbnailData.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteBytes(ThumbnailData);
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
				if (ThumbnailData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(ThumbnailData);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThumbnail other)
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
				if (other.ThumbnailData.Length != 0)
				{
					ThumbnailData = other.ThumbnailData;
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
						ThumbnailData = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetFocusedPlaylist : IMessage<GetFocusedPlaylist>, IMessage, IEquatable<GetFocusedPlaylist>, IDeepCloneable<GetFocusedPlaylist>
		{
			private static readonly MessageParser<GetFocusedPlaylist> _parser = new MessageParser<GetFocusedPlaylist>(() => new GetFocusedPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetFocusedPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[4];

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
			public GetFocusedPlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetFocusedPlaylist(GetFocusedPlaylist other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
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
			public void MergeFrom(GetFocusedPlaylist other)
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
		public sealed class GetActivePlaylist : IMessage<GetActivePlaylist>, IMessage, IEquatable<GetActivePlaylist>, IDeepCloneable<GetActivePlaylist>
		{
			private static readonly MessageParser<GetActivePlaylist> _parser = new MessageParser<GetActivePlaylist>(() => new GetActivePlaylist());

			private UnknownFieldSet _unknownFields;

			public const int PlaylistFieldNumber = 1;

			private API_v1_Identifier playlist_;

			public const int ItemFieldNumber = 2;

			private API_v1_Identifier item_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetActivePlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[5];

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
			public GetActivePlaylist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetActivePlaylist(GetActivePlaylist other)
				: this()
			{
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
				item_ = ((other.item_ != null) ? other.item_.Clone() : null);
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
			public void MergeFrom(GetActivePlaylist other)
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
			public static MessageDescriptor Descriptor => API_v1_Media_Response.Descriptor.NestedTypes[6];

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
	}

	private static readonly MessageParser<API_v1_Media_Response> _parser = new MessageParser<API_v1_Media_Response>(() => new API_v1_Media_Response());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	public const int GetPlaylistFieldNumber = 2;

	public const int GetPlaylistUpdatesFieldNumber = 3;

	public const int GetThumbnailFieldNumber = 4;

	public const int PlaylistFocusedFieldNumber = 5;

	public const int PlaylistActiveFieldNumber = 6;

	public const int FocusFieldNumber = 7;

	public const int TriggerFieldNumber = 8;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Media_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MediaReflection.Descriptor.MessageTypes[1];

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
	public Types.GetPlaylistUpdates GetPlaylistUpdates
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetPlaylistUpdates)
			{
				return null;
			}
			return (Types.GetPlaylistUpdates)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetPlaylistUpdates : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetFocusedPlaylist PlaylistFocused
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistFocused)
			{
				return null;
			}
			return (Types.GetFocusedPlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistFocused : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetActivePlaylist PlaylistActive
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PlaylistActive)
			{
				return null;
			}
			return (Types.GetActivePlaylist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistActive : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage Focus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Focus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Focus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage Trigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Trigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Trigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Response(API_v1_Media_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case ResponseOneofCase.GetPlaylist:
			GetPlaylist = other.GetPlaylist.Clone();
			break;
		case ResponseOneofCase.GetPlaylistUpdates:
			GetPlaylistUpdates = other.GetPlaylistUpdates.Clone();
			break;
		case ResponseOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		case ResponseOneofCase.PlaylistFocused:
			PlaylistFocused = other.PlaylistFocused.Clone();
			break;
		case ResponseOneofCase.PlaylistActive:
			PlaylistActive = other.PlaylistActive.Clone();
			break;
		case ResponseOneofCase.Focus:
			Focus = other.Focus.Clone();
			break;
		case ResponseOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Response Clone()
	{
		return new API_v1_Media_Response(this);
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
		return Equals(other as API_v1_Media_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Media_Response other)
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
		if (!object.Equals(GetPlaylist, other.GetPlaylist))
		{
			return false;
		}
		if (!object.Equals(GetPlaylistUpdates, other.GetPlaylistUpdates))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
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
		if (!object.Equals(Focus, other.Focus))
		{
			return false;
		}
		if (!object.Equals(Trigger, other.Trigger))
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
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			num ^= GetPlaylist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylistUpdates)
		{
			num ^= GetPlaylistUpdates.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			num ^= PlaylistFocused.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			num ^= PlaylistActive.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			num ^= Focus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylistUpdates)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetPlaylistUpdates);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PlaylistFocused);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PlaylistActive);
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Focus);
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Trigger);
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
		if (responseCase_ == ResponseOneofCase.GetPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylist);
		}
		if (responseCase_ == ResponseOneofCase.GetPlaylistUpdates)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylistUpdates);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistFocused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocused);
		}
		if (responseCase_ == ResponseOneofCase.PlaylistActive)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActive);
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focus);
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Media_Response other)
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
		case ResponseOneofCase.GetPlaylist:
			if (GetPlaylist == null)
			{
				GetPlaylist = new Types.GetPlaylist();
			}
			GetPlaylist.MergeFrom(other.GetPlaylist);
			break;
		case ResponseOneofCase.GetPlaylistUpdates:
			if (GetPlaylistUpdates == null)
			{
				GetPlaylistUpdates = new Types.GetPlaylistUpdates();
			}
			GetPlaylistUpdates.MergeFrom(other.GetPlaylistUpdates);
			break;
		case ResponseOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
			break;
		case ResponseOneofCase.PlaylistFocused:
			if (PlaylistFocused == null)
			{
				PlaylistFocused = new Types.GetFocusedPlaylist();
			}
			PlaylistFocused.MergeFrom(other.PlaylistFocused);
			break;
		case ResponseOneofCase.PlaylistActive:
			if (PlaylistActive == null)
			{
				PlaylistActive = new Types.GetActivePlaylist();
			}
			PlaylistActive.MergeFrom(other.PlaylistActive);
			break;
		case ResponseOneofCase.Focus:
			if (Focus == null)
			{
				Focus = new Types.EmptyMessage();
			}
			Focus.MergeFrom(other.Focus);
			break;
		case ResponseOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.EmptyMessage();
			}
			Trigger.MergeFrom(other.Trigger);
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
				Types.GetPlaylist getPlaylist = new Types.GetPlaylist();
				if (responseCase_ == ResponseOneofCase.GetPlaylist)
				{
					getPlaylist.MergeFrom(GetPlaylist);
				}
				input.ReadMessage(getPlaylist);
				GetPlaylist = getPlaylist;
				break;
			}
			case 26u:
			{
				Types.GetPlaylistUpdates getPlaylistUpdates = new Types.GetPlaylistUpdates();
				if (responseCase_ == ResponseOneofCase.GetPlaylistUpdates)
				{
					getPlaylistUpdates.MergeFrom(GetPlaylistUpdates);
				}
				input.ReadMessage(getPlaylistUpdates);
				GetPlaylistUpdates = getPlaylistUpdates;
				break;
			}
			case 34u:
			{
				Types.GetThumbnail getThumbnail = new Types.GetThumbnail();
				if (responseCase_ == ResponseOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			case 42u:
			{
				Types.GetFocusedPlaylist getFocusedPlaylist = new Types.GetFocusedPlaylist();
				if (responseCase_ == ResponseOneofCase.PlaylistFocused)
				{
					getFocusedPlaylist.MergeFrom(PlaylistFocused);
				}
				input.ReadMessage(getFocusedPlaylist);
				PlaylistFocused = getFocusedPlaylist;
				break;
			}
			case 50u:
			{
				Types.GetActivePlaylist getActivePlaylist = new Types.GetActivePlaylist();
				if (responseCase_ == ResponseOneofCase.PlaylistActive)
				{
					getActivePlaylist.MergeFrom(PlaylistActive);
				}
				input.ReadMessage(getActivePlaylist);
				PlaylistActive = getActivePlaylist;
				break;
			}
			case 58u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.Focus)
				{
					emptyMessage2.MergeFrom(Focus);
				}
				input.ReadMessage(emptyMessage2);
				Focus = emptyMessage2;
				break;
			}
			case 66u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.Trigger)
				{
					emptyMessage.MergeFrom(Trigger);
				}
				input.ReadMessage(emptyMessage);
				Trigger = emptyMessage;
				break;
			}
			}
		}
	}
}
