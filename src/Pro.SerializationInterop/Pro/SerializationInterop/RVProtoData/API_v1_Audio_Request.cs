using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Audio_Request : IMessage<API_v1_Audio_Request>, IMessage, IEquatable<API_v1_Audio_Request>, IDeepCloneable<API_v1_Audio_Request>
{
	public enum RequestOneofCase
	{
		None,
		Playlists,
		Playlist,
		PlaylistUpdates,
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlists> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Request.Descriptor.NestedTypes[0];

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
		public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
		{
			private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int StartFieldNumber = 2;

			private uint start_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Request.Descriptor.NestedTypes[1];

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
			public Playlist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlist(Playlist other)
				: this()
			{
				id_ = other.id_;
				start_ = other.start_;
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
					output.WriteRawTag(16);
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
			public void MergeFrom(Playlist other)
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
					case 16u:
						Start = input.ReadUInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlaylistUpdates : IMessage<PlaylistUpdates>, IMessage, IEquatable<PlaylistUpdates>, IDeepCloneable<PlaylistUpdates>
		{
			private static readonly MessageParser<PlaylistUpdates> _parser = new MessageParser<PlaylistUpdates>(() => new PlaylistUpdates());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistUpdates> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Request.Descriptor.NestedTypes[2];

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
			public PlaylistUpdates()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistUpdates(PlaylistUpdates other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistUpdates Clone()
			{
				return new PlaylistUpdates(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistUpdates);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistUpdates other)
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
			public void MergeFrom(PlaylistUpdates other)
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
		public sealed class EmptyMessage : IMessage<EmptyMessage>, IMessage, IEquatable<EmptyMessage>, IDeepCloneable<EmptyMessage>
		{
			private static readonly MessageParser<EmptyMessage> _parser = new MessageParser<EmptyMessage>(() => new EmptyMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EmptyMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Request.Descriptor.NestedTypes[3];

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
		public sealed class IdentifierMessage : IMessage<IdentifierMessage>, IMessage, IEquatable<IdentifierMessage>, IDeepCloneable<IdentifierMessage>
		{
			private static readonly MessageParser<IdentifierMessage> _parser = new MessageParser<IdentifierMessage>(() => new IdentifierMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IdentifierMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Audio_Request.Descriptor.NestedTypes[4];

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
			public IdentifierMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdentifierMessage(IdentifierMessage other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IdentifierMessage Clone()
			{
				return new IdentifierMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IdentifierMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IdentifierMessage other)
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
			public void MergeFrom(IdentifierMessage other)
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
	}

	private static readonly MessageParser<API_v1_Audio_Request> _parser = new MessageParser<API_v1_Audio_Request>(() => new API_v1_Audio_Request());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	public const int PlaylistFieldNumber = 2;

	public const int PlaylistUpdatesFieldNumber = 3;

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

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Audio_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1AudioReflection.Descriptor.MessageTypes[0];

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
	public Types.Playlist Playlist
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Playlist)
			{
				return null;
			}
			return (Types.Playlist)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Playlist : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistUpdates PlaylistUpdates
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistUpdates)
			{
				return null;
			}
			return (Types.PlaylistUpdates)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistUpdates : RequestOneofCase.None);
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
	public Types.EmptyMessage PlaylistNextFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistNextFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistNextFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistPreviousFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistPreviousFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistPreviousFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActiveFocus)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActiveFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistIdFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistIdFocus)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistIdFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistFocusedTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistFocusedTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActiveTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActiveTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistIdTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistIdTrigger)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistIdTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistFocusedNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistFocusedNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistFocusedPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistFocusedPreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistFocusedPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistFocusedIdTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistFocusedIdTrigger)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistFocusedIdTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActiveNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActiveNextTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActiveNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage PlaylistActivePreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActivePreviousTrigger)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActivePreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistActiveIdTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistActiveIdTrigger)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistActiveIdTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistIdNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistIdNextTrigger)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistIdNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IdentifierMessage PlaylistIdPreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PlaylistIdPreviousTrigger)
			{
				return null;
			}
			return (Types.IdentifierMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PlaylistIdPreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Request(API_v1_Audio_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Playlists:
			Playlists = other.Playlists.Clone();
			break;
		case RequestOneofCase.Playlist:
			Playlist = other.Playlist.Clone();
			break;
		case RequestOneofCase.PlaylistUpdates:
			PlaylistUpdates = other.PlaylistUpdates.Clone();
			break;
		case RequestOneofCase.PlaylistFocused:
			PlaylistFocused = other.PlaylistFocused.Clone();
			break;
		case RequestOneofCase.PlaylistActive:
			PlaylistActive = other.PlaylistActive.Clone();
			break;
		case RequestOneofCase.PlaylistNextFocus:
			PlaylistNextFocus = other.PlaylistNextFocus.Clone();
			break;
		case RequestOneofCase.PlaylistPreviousFocus:
			PlaylistPreviousFocus = other.PlaylistPreviousFocus.Clone();
			break;
		case RequestOneofCase.PlaylistActiveFocus:
			PlaylistActiveFocus = other.PlaylistActiveFocus.Clone();
			break;
		case RequestOneofCase.PlaylistIdFocus:
			PlaylistIdFocus = other.PlaylistIdFocus.Clone();
			break;
		case RequestOneofCase.PlaylistFocusedTrigger:
			PlaylistFocusedTrigger = other.PlaylistFocusedTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistActiveTrigger:
			PlaylistActiveTrigger = other.PlaylistActiveTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistIdTrigger:
			PlaylistIdTrigger = other.PlaylistIdTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistFocusedNextTrigger:
			PlaylistFocusedNextTrigger = other.PlaylistFocusedNextTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistFocusedPreviousTrigger:
			PlaylistFocusedPreviousTrigger = other.PlaylistFocusedPreviousTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistFocusedIdTrigger:
			PlaylistFocusedIdTrigger = other.PlaylistFocusedIdTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistActiveNextTrigger:
			PlaylistActiveNextTrigger = other.PlaylistActiveNextTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistActivePreviousTrigger:
			PlaylistActivePreviousTrigger = other.PlaylistActivePreviousTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistActiveIdTrigger:
			PlaylistActiveIdTrigger = other.PlaylistActiveIdTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistIdNextTrigger:
			PlaylistIdNextTrigger = other.PlaylistIdNextTrigger.Clone();
			break;
		case RequestOneofCase.PlaylistIdPreviousTrigger:
			PlaylistIdPreviousTrigger = other.PlaylistIdPreviousTrigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Audio_Request Clone()
	{
		return new API_v1_Audio_Request(this);
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
		return Equals(other as API_v1_Audio_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Audio_Request other)
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
		if (!object.Equals(PlaylistUpdates, other.PlaylistUpdates))
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
		if (requestCase_ == RequestOneofCase.Playlist)
		{
			num ^= Playlist.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistUpdates)
		{
			num ^= PlaylistUpdates.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			num ^= PlaylistFocused.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			num ^= PlaylistActive.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistNextFocus)
		{
			num ^= PlaylistNextFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistPreviousFocus)
		{
			num ^= PlaylistPreviousFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveFocus)
		{
			num ^= PlaylistActiveFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdFocus)
		{
			num ^= PlaylistIdFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedTrigger)
		{
			num ^= PlaylistFocusedTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveTrigger)
		{
			num ^= PlaylistActiveTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdTrigger)
		{
			num ^= PlaylistIdTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedNextTrigger)
		{
			num ^= PlaylistFocusedNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedPreviousTrigger)
		{
			num ^= PlaylistFocusedPreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedIdTrigger)
		{
			num ^= PlaylistFocusedIdTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveNextTrigger)
		{
			num ^= PlaylistActiveNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActivePreviousTrigger)
		{
			num ^= PlaylistActivePreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveIdTrigger)
		{
			num ^= PlaylistActiveIdTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdNextTrigger)
		{
			num ^= PlaylistIdNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdPreviousTrigger)
		{
			num ^= PlaylistIdPreviousTrigger.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.Playlist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Playlist);
		}
		if (requestCase_ == RequestOneofCase.PlaylistUpdates)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PlaylistUpdates);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PlaylistFocused);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PlaylistActive);
		}
		if (requestCase_ == RequestOneofCase.PlaylistNextFocus)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PlaylistNextFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistPreviousFocus)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PlaylistPreviousFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveFocus)
		{
			output.WriteRawTag(66);
			output.WriteMessage(PlaylistActiveFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdFocus)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PlaylistIdFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedTrigger)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PlaylistFocusedTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveTrigger)
		{
			output.WriteRawTag(90);
			output.WriteMessage(PlaylistActiveTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdTrigger)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PlaylistIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedNextTrigger)
		{
			output.WriteRawTag(106);
			output.WriteMessage(PlaylistFocusedNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedPreviousTrigger)
		{
			output.WriteRawTag(114);
			output.WriteMessage(PlaylistFocusedPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedIdTrigger)
		{
			output.WriteRawTag(122);
			output.WriteMessage(PlaylistFocusedIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveNextTrigger)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(PlaylistActiveNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActivePreviousTrigger)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(PlaylistActivePreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveIdTrigger)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(PlaylistActiveIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdNextTrigger)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(PlaylistIdNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdPreviousTrigger)
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
		if (requestCase_ == RequestOneofCase.Playlists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlists);
		}
		if (requestCase_ == RequestOneofCase.Playlist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
		}
		if (requestCase_ == RequestOneofCase.PlaylistUpdates)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistUpdates);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocused);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActive)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActive);
		}
		if (requestCase_ == RequestOneofCase.PlaylistNextFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistNextFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistPreviousFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistPreviousFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActiveFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIdFocus);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistActiveTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedNextTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedPreviousTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedPreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistFocusedIdTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistFocusedIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActiveNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActivePreviousTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActivePreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistActiveIdTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistActiveIdTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdNextTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistIdNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.PlaylistIdPreviousTrigger)
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
	public void MergeFrom(API_v1_Audio_Request other)
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
		case RequestOneofCase.Playlist:
			if (Playlist == null)
			{
				Playlist = new Types.Playlist();
			}
			Playlist.MergeFrom(other.Playlist);
			break;
		case RequestOneofCase.PlaylistUpdates:
			if (PlaylistUpdates == null)
			{
				PlaylistUpdates = new Types.PlaylistUpdates();
			}
			PlaylistUpdates.MergeFrom(other.PlaylistUpdates);
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
		case RequestOneofCase.PlaylistNextFocus:
			if (PlaylistNextFocus == null)
			{
				PlaylistNextFocus = new Types.EmptyMessage();
			}
			PlaylistNextFocus.MergeFrom(other.PlaylistNextFocus);
			break;
		case RequestOneofCase.PlaylistPreviousFocus:
			if (PlaylistPreviousFocus == null)
			{
				PlaylistPreviousFocus = new Types.EmptyMessage();
			}
			PlaylistPreviousFocus.MergeFrom(other.PlaylistPreviousFocus);
			break;
		case RequestOneofCase.PlaylistActiveFocus:
			if (PlaylistActiveFocus == null)
			{
				PlaylistActiveFocus = new Types.EmptyMessage();
			}
			PlaylistActiveFocus.MergeFrom(other.PlaylistActiveFocus);
			break;
		case RequestOneofCase.PlaylistIdFocus:
			if (PlaylistIdFocus == null)
			{
				PlaylistIdFocus = new Types.IdentifierMessage();
			}
			PlaylistIdFocus.MergeFrom(other.PlaylistIdFocus);
			break;
		case RequestOneofCase.PlaylistFocusedTrigger:
			if (PlaylistFocusedTrigger == null)
			{
				PlaylistFocusedTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedTrigger.MergeFrom(other.PlaylistFocusedTrigger);
			break;
		case RequestOneofCase.PlaylistActiveTrigger:
			if (PlaylistActiveTrigger == null)
			{
				PlaylistActiveTrigger = new Types.EmptyMessage();
			}
			PlaylistActiveTrigger.MergeFrom(other.PlaylistActiveTrigger);
			break;
		case RequestOneofCase.PlaylistIdTrigger:
			if (PlaylistIdTrigger == null)
			{
				PlaylistIdTrigger = new Types.IdentifierMessage();
			}
			PlaylistIdTrigger.MergeFrom(other.PlaylistIdTrigger);
			break;
		case RequestOneofCase.PlaylistFocusedNextTrigger:
			if (PlaylistFocusedNextTrigger == null)
			{
				PlaylistFocusedNextTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedNextTrigger.MergeFrom(other.PlaylistFocusedNextTrigger);
			break;
		case RequestOneofCase.PlaylistFocusedPreviousTrigger:
			if (PlaylistFocusedPreviousTrigger == null)
			{
				PlaylistFocusedPreviousTrigger = new Types.EmptyMessage();
			}
			PlaylistFocusedPreviousTrigger.MergeFrom(other.PlaylistFocusedPreviousTrigger);
			break;
		case RequestOneofCase.PlaylistFocusedIdTrigger:
			if (PlaylistFocusedIdTrigger == null)
			{
				PlaylistFocusedIdTrigger = new Types.IdentifierMessage();
			}
			PlaylistFocusedIdTrigger.MergeFrom(other.PlaylistFocusedIdTrigger);
			break;
		case RequestOneofCase.PlaylistActiveNextTrigger:
			if (PlaylistActiveNextTrigger == null)
			{
				PlaylistActiveNextTrigger = new Types.EmptyMessage();
			}
			PlaylistActiveNextTrigger.MergeFrom(other.PlaylistActiveNextTrigger);
			break;
		case RequestOneofCase.PlaylistActivePreviousTrigger:
			if (PlaylistActivePreviousTrigger == null)
			{
				PlaylistActivePreviousTrigger = new Types.EmptyMessage();
			}
			PlaylistActivePreviousTrigger.MergeFrom(other.PlaylistActivePreviousTrigger);
			break;
		case RequestOneofCase.PlaylistActiveIdTrigger:
			if (PlaylistActiveIdTrigger == null)
			{
				PlaylistActiveIdTrigger = new Types.IdentifierMessage();
			}
			PlaylistActiveIdTrigger.MergeFrom(other.PlaylistActiveIdTrigger);
			break;
		case RequestOneofCase.PlaylistIdNextTrigger:
			if (PlaylistIdNextTrigger == null)
			{
				PlaylistIdNextTrigger = new Types.IdentifierMessage();
			}
			PlaylistIdNextTrigger.MergeFrom(other.PlaylistIdNextTrigger);
			break;
		case RequestOneofCase.PlaylistIdPreviousTrigger:
			if (PlaylistIdPreviousTrigger == null)
			{
				PlaylistIdPreviousTrigger = new Types.IdentifierMessage();
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
				Types.Playlist playlist = new Types.Playlist();
				if (requestCase_ == RequestOneofCase.Playlist)
				{
					playlist.MergeFrom(Playlist);
				}
				input.ReadMessage(playlist);
				Playlist = playlist;
				break;
			}
			case 26u:
			{
				Types.PlaylistUpdates playlistUpdates = new Types.PlaylistUpdates();
				if (requestCase_ == RequestOneofCase.PlaylistUpdates)
				{
					playlistUpdates.MergeFrom(PlaylistUpdates);
				}
				input.ReadMessage(playlistUpdates);
				PlaylistUpdates = playlistUpdates;
				break;
			}
			case 34u:
			{
				Types.EmptyMessage emptyMessage5 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocused)
				{
					emptyMessage5.MergeFrom(PlaylistFocused);
				}
				input.ReadMessage(emptyMessage5);
				PlaylistFocused = emptyMessage5;
				break;
			}
			case 42u:
			{
				Types.EmptyMessage emptyMessage3 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActive)
				{
					emptyMessage3.MergeFrom(PlaylistActive);
				}
				input.ReadMessage(emptyMessage3);
				PlaylistActive = emptyMessage3;
				break;
			}
			case 50u:
			{
				Types.EmptyMessage emptyMessage10 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistNextFocus)
				{
					emptyMessage10.MergeFrom(PlaylistNextFocus);
				}
				input.ReadMessage(emptyMessage10);
				PlaylistNextFocus = emptyMessage10;
				break;
			}
			case 58u:
			{
				Types.EmptyMessage emptyMessage9 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistPreviousFocus)
				{
					emptyMessage9.MergeFrom(PlaylistPreviousFocus);
				}
				input.ReadMessage(emptyMessage9);
				PlaylistPreviousFocus = emptyMessage9;
				break;
			}
			case 66u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActiveFocus)
				{
					emptyMessage.MergeFrom(PlaylistActiveFocus);
				}
				input.ReadMessage(emptyMessage);
				PlaylistActiveFocus = emptyMessage;
				break;
			}
			case 74u:
			{
				Types.IdentifierMessage identifierMessage6 = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistIdFocus)
				{
					identifierMessage6.MergeFrom(PlaylistIdFocus);
				}
				input.ReadMessage(identifierMessage6);
				PlaylistIdFocus = identifierMessage6;
				break;
			}
			case 82u:
			{
				Types.EmptyMessage emptyMessage8 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocusedTrigger)
				{
					emptyMessage8.MergeFrom(PlaylistFocusedTrigger);
				}
				input.ReadMessage(emptyMessage8);
				PlaylistFocusedTrigger = emptyMessage8;
				break;
			}
			case 90u:
			{
				Types.EmptyMessage emptyMessage6 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActiveTrigger)
				{
					emptyMessage6.MergeFrom(PlaylistActiveTrigger);
				}
				input.ReadMessage(emptyMessage6);
				PlaylistActiveTrigger = emptyMessage6;
				break;
			}
			case 98u:
			{
				Types.IdentifierMessage identifierMessage3 = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistIdTrigger)
				{
					identifierMessage3.MergeFrom(PlaylistIdTrigger);
				}
				input.ReadMessage(identifierMessage3);
				PlaylistIdTrigger = identifierMessage3;
				break;
			}
			case 106u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocusedNextTrigger)
				{
					emptyMessage2.MergeFrom(PlaylistFocusedNextTrigger);
				}
				input.ReadMessage(emptyMessage2);
				PlaylistFocusedNextTrigger = emptyMessage2;
				break;
			}
			case 114u:
			{
				Types.EmptyMessage emptyMessage11 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocusedPreviousTrigger)
				{
					emptyMessage11.MergeFrom(PlaylistFocusedPreviousTrigger);
				}
				input.ReadMessage(emptyMessage11);
				PlaylistFocusedPreviousTrigger = emptyMessage11;
				break;
			}
			case 122u:
			{
				Types.IdentifierMessage identifierMessage5 = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistFocusedIdTrigger)
				{
					identifierMessage5.MergeFrom(PlaylistFocusedIdTrigger);
				}
				input.ReadMessage(identifierMessage5);
				PlaylistFocusedIdTrigger = identifierMessage5;
				break;
			}
			case 130u:
			{
				Types.EmptyMessage emptyMessage7 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActiveNextTrigger)
				{
					emptyMessage7.MergeFrom(PlaylistActiveNextTrigger);
				}
				input.ReadMessage(emptyMessage7);
				PlaylistActiveNextTrigger = emptyMessage7;
				break;
			}
			case 138u:
			{
				Types.EmptyMessage emptyMessage4 = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActivePreviousTrigger)
				{
					emptyMessage4.MergeFrom(PlaylistActivePreviousTrigger);
				}
				input.ReadMessage(emptyMessage4);
				PlaylistActivePreviousTrigger = emptyMessage4;
				break;
			}
			case 146u:
			{
				Types.IdentifierMessage identifierMessage4 = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistActiveIdTrigger)
				{
					identifierMessage4.MergeFrom(PlaylistActiveIdTrigger);
				}
				input.ReadMessage(identifierMessage4);
				PlaylistActiveIdTrigger = identifierMessage4;
				break;
			}
			case 154u:
			{
				Types.IdentifierMessage identifierMessage2 = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistIdNextTrigger)
				{
					identifierMessage2.MergeFrom(PlaylistIdNextTrigger);
				}
				input.ReadMessage(identifierMessage2);
				PlaylistIdNextTrigger = identifierMessage2;
				break;
			}
			case 162u:
			{
				Types.IdentifierMessage identifierMessage = new Types.IdentifierMessage();
				if (requestCase_ == RequestOneofCase.PlaylistIdPreviousTrigger)
				{
					identifierMessage.MergeFrom(PlaylistIdPreviousTrigger);
				}
				input.ReadMessage(identifierMessage);
				PlaylistIdPreviousTrigger = identifierMessage;
				break;
			}
			}
		}
	}
}
