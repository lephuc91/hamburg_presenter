using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Media_Request : IMessage<API_v1_Media_Request>, IMessage, IEquatable<API_v1_Media_Request>, IDeepCloneable<API_v1_Media_Request>
{
	public enum RequestOneofCase
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlists> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[0];

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
		public sealed class GetPlaylist : IMessage<GetPlaylist>, IMessage, IEquatable<GetPlaylist>, IDeepCloneable<GetPlaylist>
		{
			private static readonly MessageParser<GetPlaylist> _parser = new MessageParser<GetPlaylist>(() => new GetPlaylist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int StartFieldNumber = 4;

			private uint start_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[1];

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
			public uint Start
			{
				get
				{
					return start_;
				}
				set
				{
					start_ = value;
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
				start_ = other.start_;
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
				if (Start != other.Start)
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
				if (Start != 0)
				{
					num ^= Start.GetHashCode();
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
				if (Start != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(Start);
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
				if (Start != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Start);
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
					if (other.Start != 0)
					{
						Start = other.Start;
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
					case 32u:
						Start = input.ReadUInt32();
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

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPlaylistUpdates> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[2];

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
			public GetPlaylistUpdates()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPlaylistUpdates(GetPlaylistUpdates other)
				: this()
			{
				id_ = other.id_;
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
			public void MergeFrom(GetPlaylistUpdates other)
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
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int QualityFieldNumber = 2;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[3];

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
			public GetThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail(GetThumbnail other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				quality_ = other.quality_;
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
				if (Quality != other.Quality)
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
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (Quality != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Quality);
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
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
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
				if (other.Quality != 0)
				{
					Quality = other.Quality;
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
					case 16u:
						Quality = input.ReadInt32();
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
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[4];

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
		public sealed class FocusMessage : IMessage<FocusMessage>, IMessage, IEquatable<FocusMessage>, IDeepCloneable<FocusMessage>
		{
			public enum PlaylistOneofCase
			{
				None,
				Next,
				Previous,
				Active,
				Id
			}

			private static readonly MessageParser<FocusMessage> _parser = new MessageParser<FocusMessage>(() => new FocusMessage());

			private UnknownFieldSet _unknownFields;

			public const int NextFieldNumber = 1;

			public const int PreviousFieldNumber = 2;

			public const int ActiveFieldNumber = 3;

			public const int IdFieldNumber = 4;

			private static readonly FieldCodec<string> _oneof_id_codec = FieldCodec.ForClassWrapper<string>(34u);

			private object playlist_;

			private PlaylistOneofCase playlistCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Next
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Next)
					{
						return null;
					}
					return (EmptyMessage)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Next : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Previous
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Previous)
					{
						return null;
					}
					return (EmptyMessage)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Previous : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Active
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Active)
					{
						return null;
					}
					return (EmptyMessage)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Active : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Id)
					{
						return null;
					}
					return (string)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Id : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistOneofCase PlaylistCase => playlistCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage(FocusMessage other)
				: this()
			{
				switch (other.PlaylistCase)
				{
				case PlaylistOneofCase.Next:
					Next = other.Next.Clone();
					break;
				case PlaylistOneofCase.Previous:
					Previous = other.Previous.Clone();
					break;
				case PlaylistOneofCase.Active:
					Active = other.Active.Clone();
					break;
				case PlaylistOneofCase.Id:
					Id = other.Id;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage Clone()
			{
				return new FocusMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearPlaylist()
			{
				playlistCase_ = PlaylistOneofCase.None;
				playlist_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Next, other.Next))
				{
					return false;
				}
				if (!object.Equals(Previous, other.Previous))
				{
					return false;
				}
				if (!object.Equals(Active, other.Active))
				{
					return false;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (PlaylistCase != other.PlaylistCase)
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
				if (playlistCase_ == PlaylistOneofCase.Next)
				{
					num ^= Next.GetHashCode();
				}
				if (playlistCase_ == PlaylistOneofCase.Previous)
				{
					num ^= Previous.GetHashCode();
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					num ^= Active.GetHashCode();
				}
				if (playlistCase_ == PlaylistOneofCase.Id)
				{
					num ^= Id.GetHashCode();
				}
				num ^= (int)playlistCase_;
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
				if (playlistCase_ == PlaylistOneofCase.Next)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Next);
				}
				if (playlistCase_ == PlaylistOneofCase.Previous)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Previous);
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Active);
				}
				if (playlistCase_ == PlaylistOneofCase.Id)
				{
					_oneof_id_codec.WriteTagAndValue(output, (string)playlist_);
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
				if (playlistCase_ == PlaylistOneofCase.Next)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Next);
				}
				if (playlistCase_ == PlaylistOneofCase.Previous)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Previous);
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Active);
				}
				if (playlistCase_ == PlaylistOneofCase.Id)
				{
					num += _oneof_id_codec.CalculateSizeWithTag(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusMessage other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.PlaylistCase)
				{
				case PlaylistOneofCase.Next:
					if (Next == null)
					{
						Next = new EmptyMessage();
					}
					Next.MergeFrom(other.Next);
					break;
				case PlaylistOneofCase.Previous:
					if (Previous == null)
					{
						Previous = new EmptyMessage();
					}
					Previous.MergeFrom(other.Previous);
					break;
				case PlaylistOneofCase.Active:
					if (Active == null)
					{
						Active = new EmptyMessage();
					}
					Active.MergeFrom(other.Active);
					break;
				case PlaylistOneofCase.Id:
					Id = other.Id;
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
						EmptyMessage emptyMessage2 = new EmptyMessage();
						if (playlistCase_ == PlaylistOneofCase.Next)
						{
							emptyMessage2.MergeFrom(Next);
						}
						input.ReadMessage(emptyMessage2);
						Next = emptyMessage2;
						break;
					}
					case 18u:
					{
						EmptyMessage emptyMessage3 = new EmptyMessage();
						if (playlistCase_ == PlaylistOneofCase.Previous)
						{
							emptyMessage3.MergeFrom(Previous);
						}
						input.ReadMessage(emptyMessage3);
						Previous = emptyMessage3;
						break;
					}
					case 26u:
					{
						EmptyMessage emptyMessage = new EmptyMessage();
						if (playlistCase_ == PlaylistOneofCase.Active)
						{
							emptyMessage.MergeFrom(Active);
						}
						input.ReadMessage(emptyMessage);
						Active = emptyMessage;
						break;
					}
					case 34u:
						Id = _oneof_id_codec.Read(input);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TriggerMessage : IMessage<TriggerMessage>, IMessage, IEquatable<TriggerMessage>, IDeepCloneable<TriggerMessage>
		{
			public enum PlaylistOneofCase
			{
				None,
				Focused,
				Active,
				PlaylistId
			}

			public enum ItemOneofCase
			{
				None = 0,
				Start = 4,
				Next = 5,
				Previous = 6,
				MediaId = 7
			}

			private static readonly MessageParser<TriggerMessage> _parser = new MessageParser<TriggerMessage>(() => new TriggerMessage());

			private UnknownFieldSet _unknownFields;

			public const int FocusedFieldNumber = 1;

			public const int ActiveFieldNumber = 2;

			public const int PlaylistIdFieldNumber = 3;

			private static readonly FieldCodec<string> _oneof_playlistId_codec = FieldCodec.ForClassWrapper<string>(26u);

			public const int StartFieldNumber = 4;

			public const int NextFieldNumber = 5;

			public const int PreviousFieldNumber = 6;

			public const int MediaIdFieldNumber = 7;

			private static readonly FieldCodec<string> _oneof_mediaId_codec = FieldCodec.ForClassWrapper<string>(58u);

			private object playlist_;

			private PlaylistOneofCase playlistCase_;

			private object item_;

			private ItemOneofCase itemCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Media_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Focused
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Focused)
					{
						return null;
					}
					return (EmptyMessage)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Focused : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Active
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.Active)
					{
						return null;
					}
					return (EmptyMessage)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.Active : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PlaylistId
			{
				get
				{
					if (playlistCase_ != PlaylistOneofCase.PlaylistId)
					{
						return null;
					}
					return (string)playlist_;
				}
				set
				{
					playlist_ = value;
					playlistCase_ = ((value != null) ? PlaylistOneofCase.PlaylistId : PlaylistOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Start
			{
				get
				{
					if (itemCase_ != ItemOneofCase.Start)
					{
						return null;
					}
					return (EmptyMessage)item_;
				}
				set
				{
					item_ = value;
					itemCase_ = ((value != null) ? ItemOneofCase.Start : ItemOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Next
			{
				get
				{
					if (itemCase_ != ItemOneofCase.Next)
					{
						return null;
					}
					return (EmptyMessage)item_;
				}
				set
				{
					item_ = value;
					itemCase_ = ((value != null) ? ItemOneofCase.Next : ItemOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Previous
			{
				get
				{
					if (itemCase_ != ItemOneofCase.Previous)
					{
						return null;
					}
					return (EmptyMessage)item_;
				}
				set
				{
					item_ = value;
					itemCase_ = ((value != null) ? ItemOneofCase.Previous : ItemOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string MediaId
			{
				get
				{
					if (itemCase_ != ItemOneofCase.MediaId)
					{
						return null;
					}
					return (string)item_;
				}
				set
				{
					item_ = value;
					itemCase_ = ((value != null) ? ItemOneofCase.MediaId : ItemOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistOneofCase PlaylistCase => playlistCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ItemOneofCase ItemCase => itemCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage(TriggerMessage other)
				: this()
			{
				switch (other.PlaylistCase)
				{
				case PlaylistOneofCase.Focused:
					Focused = other.Focused.Clone();
					break;
				case PlaylistOneofCase.Active:
					Active = other.Active.Clone();
					break;
				case PlaylistOneofCase.PlaylistId:
					PlaylistId = other.PlaylistId;
					break;
				}
				switch (other.ItemCase)
				{
				case ItemOneofCase.Start:
					Start = other.Start.Clone();
					break;
				case ItemOneofCase.Next:
					Next = other.Next.Clone();
					break;
				case ItemOneofCase.Previous:
					Previous = other.Previous.Clone();
					break;
				case ItemOneofCase.MediaId:
					MediaId = other.MediaId;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage Clone()
			{
				return new TriggerMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearPlaylist()
			{
				playlistCase_ = PlaylistOneofCase.None;
				playlist_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearItem()
			{
				itemCase_ = ItemOneofCase.None;
				item_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Focused, other.Focused))
				{
					return false;
				}
				if (!object.Equals(Active, other.Active))
				{
					return false;
				}
				if (PlaylistId != other.PlaylistId)
				{
					return false;
				}
				if (!object.Equals(Start, other.Start))
				{
					return false;
				}
				if (!object.Equals(Next, other.Next))
				{
					return false;
				}
				if (!object.Equals(Previous, other.Previous))
				{
					return false;
				}
				if (MediaId != other.MediaId)
				{
					return false;
				}
				if (PlaylistCase != other.PlaylistCase)
				{
					return false;
				}
				if (ItemCase != other.ItemCase)
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
				if (playlistCase_ == PlaylistOneofCase.Focused)
				{
					num ^= Focused.GetHashCode();
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					num ^= Active.GetHashCode();
				}
				if (playlistCase_ == PlaylistOneofCase.PlaylistId)
				{
					num ^= PlaylistId.GetHashCode();
				}
				if (itemCase_ == ItemOneofCase.Start)
				{
					num ^= Start.GetHashCode();
				}
				if (itemCase_ == ItemOneofCase.Next)
				{
					num ^= Next.GetHashCode();
				}
				if (itemCase_ == ItemOneofCase.Previous)
				{
					num ^= Previous.GetHashCode();
				}
				if (itemCase_ == ItemOneofCase.MediaId)
				{
					num ^= MediaId.GetHashCode();
				}
				num ^= (int)playlistCase_;
				num ^= (int)itemCase_;
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
				if (playlistCase_ == PlaylistOneofCase.Focused)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Focused);
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Active);
				}
				if (playlistCase_ == PlaylistOneofCase.PlaylistId)
				{
					_oneof_playlistId_codec.WriteTagAndValue(output, (string)playlist_);
				}
				if (itemCase_ == ItemOneofCase.Start)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Start);
				}
				if (itemCase_ == ItemOneofCase.Next)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Next);
				}
				if (itemCase_ == ItemOneofCase.Previous)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Previous);
				}
				if (itemCase_ == ItemOneofCase.MediaId)
				{
					_oneof_mediaId_codec.WriteTagAndValue(output, (string)item_);
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
				if (playlistCase_ == PlaylistOneofCase.Focused)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
				}
				if (playlistCase_ == PlaylistOneofCase.Active)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Active);
				}
				if (playlistCase_ == PlaylistOneofCase.PlaylistId)
				{
					num += _oneof_playlistId_codec.CalculateSizeWithTag(PlaylistId);
				}
				if (itemCase_ == ItemOneofCase.Start)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Start);
				}
				if (itemCase_ == ItemOneofCase.Next)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Next);
				}
				if (itemCase_ == ItemOneofCase.Previous)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Previous);
				}
				if (itemCase_ == ItemOneofCase.MediaId)
				{
					num += _oneof_mediaId_codec.CalculateSizeWithTag(MediaId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TriggerMessage other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.PlaylistCase)
				{
				case PlaylistOneofCase.Focused:
					if (Focused == null)
					{
						Focused = new EmptyMessage();
					}
					Focused.MergeFrom(other.Focused);
					break;
				case PlaylistOneofCase.Active:
					if (Active == null)
					{
						Active = new EmptyMessage();
					}
					Active.MergeFrom(other.Active);
					break;
				case PlaylistOneofCase.PlaylistId:
					PlaylistId = other.PlaylistId;
					break;
				}
				switch (other.ItemCase)
				{
				case ItemOneofCase.Start:
					if (Start == null)
					{
						Start = new EmptyMessage();
					}
					Start.MergeFrom(other.Start);
					break;
				case ItemOneofCase.Next:
					if (Next == null)
					{
						Next = new EmptyMessage();
					}
					Next.MergeFrom(other.Next);
					break;
				case ItemOneofCase.Previous:
					if (Previous == null)
					{
						Previous = new EmptyMessage();
					}
					Previous.MergeFrom(other.Previous);
					break;
				case ItemOneofCase.MediaId:
					MediaId = other.MediaId;
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
						EmptyMessage emptyMessage2 = new EmptyMessage();
						if (playlistCase_ == PlaylistOneofCase.Focused)
						{
							emptyMessage2.MergeFrom(Focused);
						}
						input.ReadMessage(emptyMessage2);
						Focused = emptyMessage2;
						break;
					}
					case 18u:
					{
						EmptyMessage emptyMessage4 = new EmptyMessage();
						if (playlistCase_ == PlaylistOneofCase.Active)
						{
							emptyMessage4.MergeFrom(Active);
						}
						input.ReadMessage(emptyMessage4);
						Active = emptyMessage4;
						break;
					}
					case 26u:
						PlaylistId = _oneof_playlistId_codec.Read(input);
						break;
					case 34u:
					{
						EmptyMessage emptyMessage5 = new EmptyMessage();
						if (itemCase_ == ItemOneofCase.Start)
						{
							emptyMessage5.MergeFrom(Start);
						}
						input.ReadMessage(emptyMessage5);
						Start = emptyMessage5;
						break;
					}
					case 42u:
					{
						EmptyMessage emptyMessage3 = new EmptyMessage();
						if (itemCase_ == ItemOneofCase.Next)
						{
							emptyMessage3.MergeFrom(Next);
						}
						input.ReadMessage(emptyMessage3);
						Next = emptyMessage3;
						break;
					}
					case 50u:
					{
						EmptyMessage emptyMessage = new EmptyMessage();
						if (itemCase_ == ItemOneofCase.Previous)
						{
							emptyMessage.MergeFrom(Previous);
						}
						input.ReadMessage(emptyMessage);
						Previous = emptyMessage;
						break;
					}
					case 58u:
						MediaId = _oneof_mediaId_codec.Read(input);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Media_Request> _parser = new MessageParser<API_v1_Media_Request>(() => new API_v1_Media_Request());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	public const int GetPlaylistFieldNumber = 2;

	public const int GetPlaylistUpdatesFieldNumber = 3;

	public const int GetThumbnailFieldNumber = 4;

	public const int PlaylistFocusedFieldNumber = 5;

	public const int PlaylistActiveFieldNumber = 6;

	public const int FocusFieldNumber = 7;

	public const int TriggerFieldNumber = 8;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Media_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MediaReflection.Descriptor.MessageTypes[0];

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
	public Types.GetPlaylistUpdates GetPlaylistUpdates
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetPlaylistUpdates)
			{
				return null;
			}
			return (Types.GetPlaylistUpdates)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetPlaylistUpdates : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocused
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistFocused)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistFocused : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActive
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActive)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActive : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusMessage Focus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Focus)
			{
				return null;
			}
			return (Types.FocusMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Focus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMessage Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (Types.TriggerMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Trigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Request(API_v1_Media_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case RequestOneofCase.GetPlaylist:
			GetPlaylist = other.GetPlaylist.Clone();
			break;
		case RequestOneofCase.GetPlaylistUpdates:
			GetPlaylistUpdates = other.GetPlaylistUpdates.Clone();
			break;
		case RequestOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		case RequestOneofCase.PlaylistFocused:
			PlaylistFocused = other.PlaylistFocused.Clone();
			break;
		case RequestOneofCase.PlaylistActive:
			PlaylistActive = other.PlaylistActive.Clone();
			break;
		case RequestOneofCase.Focus:
			Focus = other.Focus.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Media_Request Clone()
	{
		return new API_v1_Media_Request(this);
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
		return Equals(other as API_v1_Media_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Media_Request other)
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
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			num ^= GetPlaylist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetPlaylistUpdates)
		{
			num ^= GetPlaylistUpdates.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			num ^= PlaylistFocused.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			num ^= PlaylistActive.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			num ^= Focus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetPlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetPlaylistUpdates)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetPlaylistUpdates);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetThumbnail);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PlaylistFocused);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PlaylistActive);
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Focus);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
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
		if (requestCase_ == RequestOneofCase.Playlists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlists);
		}
		if (requestCase_ == RequestOneofCase.GetPlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylist);
		}
		if (requestCase_ == RequestOneofCase.GetPlaylistUpdates)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPlaylistUpdates);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocused);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActive);
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focus);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
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
	public void MergeFrom(API_v1_Media_Request other)
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
		case RequestOneofCase.GetPlaylist:
			if (GetPlaylist == null)
			{
				GetPlaylist = new Types.GetPlaylist();
			}
			GetPlaylist.MergeFrom(other.GetPlaylist);
			break;
		case RequestOneofCase.GetPlaylistUpdates:
			if (GetPlaylistUpdates == null)
			{
				GetPlaylistUpdates = new Types.GetPlaylistUpdates();
			}
			GetPlaylistUpdates.MergeFrom(other.GetPlaylistUpdates);
			break;
		case RequestOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
			break;
		case RequestOneofCase.PlaylistFocused:
			if (PlaylistFocused == null)
			{
				PlaylistFocused = new Types.EmptyMessage();
			}
			PlaylistFocused.MergeFrom(other.PlaylistFocused);
			break;
		case RequestOneofCase.PlaylistActive:
			if (PlaylistActive == null)
			{
				PlaylistActive = new Types.EmptyMessage();
			}
			PlaylistActive.MergeFrom(other.PlaylistActive);
			break;
		case RequestOneofCase.Focus:
			if (Focus == null)
			{
				Focus = new Types.FocusMessage();
			}
			Focus.MergeFrom(other.Focus);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.TriggerMessage();
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
				Types.GetPlaylist getPlaylist = new Types.GetPlaylist();
				if (requestCase_ == RequestOneofCase.GetPlaylist)
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
				if (requestCase_ == RequestOneofCase.GetPlaylistUpdates)
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
				if (requestCase_ == RequestOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			case 42u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocused)
				{
					emptyMessage.MergeFrom(PlaylistFocused);
				}
				input.ReadMessage(emptyMessage);
				PlaylistFocused = emptyMessage;
				break;
			}
			case 50u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActive)
				{
					emptyMessage2.MergeFrom(PlaylistActive);
				}
				input.ReadMessage(emptyMessage2);
				PlaylistActive = emptyMessage2;
				break;
			}
			case 58u:
			{
				Types.FocusMessage focusMessage = new Types.FocusMessage();
				if (requestCase_ == RequestOneofCase.Focus)
				{
					focusMessage.MergeFrom(Focus);
				}
				input.ReadMessage(focusMessage);
				Focus = focusMessage;
				break;
			}
			case 66u:
			{
				Types.TriggerMessage triggerMessage = new Types.TriggerMessage();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					triggerMessage.MergeFrom(Trigger);
				}
				input.ReadMessage(triggerMessage);
				Trigger = triggerMessage;
				break;
			}
			}
		}
	}
}
