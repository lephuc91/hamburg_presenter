using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TriggerSource : IMessage<TriggerSource>, IMessage, IEquatable<TriggerSource>, IDeepCloneable<TriggerSource>
{
	public enum LocationOneofCase
	{
		None,
		LibraryLocation,
		PlaylistLocation,
		MediaPlaylistLocation,
		AudioPlaylistLocation
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Library : IMessage<Library>, IMessage, IEquatable<Library>, IDeepCloneable<Library>
		{
			private static readonly MessageParser<Library> _parser = new MessageParser<Library>(() => new Library());

			private UnknownFieldSet _unknownFields;

			public const int PathFieldNumber = 1;

			private string path_ = "";

			public const int PresentationNameFieldNumber = 2;

			private string presentationName_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Library> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerSource.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PresentationName
			{
				get
				{
					return presentationName_;
				}
				set
				{
					presentationName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library(Library other)
				: this()
			{
				path_ = other.path_;
				presentationName_ = other.presentationName_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library Clone()
			{
				return new Library(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Library);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Library other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Path != other.Path)
				{
					return false;
				}
				if (PresentationName != other.PresentationName)
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
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
				}
				if (PresentationName.Length != 0)
				{
					num ^= PresentationName.GetHashCode();
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
				if (Path.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Path);
				}
				if (PresentationName.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(PresentationName);
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
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (PresentationName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PresentationName);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Library other)
			{
				if (other != null)
				{
					if (other.Path.Length != 0)
					{
						Path = other.Path;
					}
					if (other.PresentationName.Length != 0)
					{
						PresentationName = other.PresentationName;
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
						Path = input.ReadString();
						break;
					case 18u:
						PresentationName = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
		{
			private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

			private UnknownFieldSet _unknownFields;

			public const int IdentifierFieldNumber = 1;

			private UUID identifier_;

			public const int ItemIdentifierFieldNumber = 2;

			private UUID itemIdentifier_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerSource.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Identifier
			{
				get
				{
					return identifier_;
				}
				set
				{
					identifier_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID ItemIdentifier
			{
				get
				{
					return itemIdentifier_;
				}
				set
				{
					itemIdentifier_ = value;
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
				identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
				itemIdentifier_ = ((other.itemIdentifier_ != null) ? other.itemIdentifier_.Clone() : null);
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
				if (!object.Equals(Identifier, other.Identifier))
				{
					return false;
				}
				if (!object.Equals(ItemIdentifier, other.ItemIdentifier))
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
				if (identifier_ != null)
				{
					num ^= Identifier.GetHashCode();
				}
				if (itemIdentifier_ != null)
				{
					num ^= ItemIdentifier.GetHashCode();
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
				if (identifier_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Identifier);
				}
				if (itemIdentifier_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(ItemIdentifier);
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
				if (identifier_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
				}
				if (itemIdentifier_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ItemIdentifier);
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
				if (other.identifier_ != null)
				{
					if (identifier_ == null)
					{
						Identifier = new UUID();
					}
					Identifier.MergeFrom(other.Identifier);
				}
				if (other.itemIdentifier_ != null)
				{
					if (itemIdentifier_ == null)
					{
						ItemIdentifier = new UUID();
					}
					ItemIdentifier.MergeFrom(other.ItemIdentifier);
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
						if (identifier_ == null)
						{
							Identifier = new UUID();
						}
						input.ReadMessage(Identifier);
						break;
					case 18u:
						if (itemIdentifier_ == null)
						{
							ItemIdentifier = new UUID();
						}
						input.ReadMessage(ItemIdentifier);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TriggerSource> _parser = new MessageParser<TriggerSource>(() => new TriggerSource());

	private UnknownFieldSet _unknownFields;

	public const int LibraryLocationFieldNumber = 1;

	public const int PlaylistLocationFieldNumber = 2;

	public const int MediaPlaylistLocationFieldNumber = 3;

	public const int AudioPlaylistLocationFieldNumber = 4;

	private object location_;

	private LocationOneofCase locationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TriggerSource> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TimedPlaybackReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Library LibraryLocation
	{
		get
		{
			if (locationCase_ != LocationOneofCase.LibraryLocation)
			{
				return null;
			}
			return (Types.Library)location_;
		}
		set
		{
			location_ = value;
			locationCase_ = ((value != null) ? LocationOneofCase.LibraryLocation : LocationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlist PlaylistLocation
	{
		get
		{
			if (locationCase_ != LocationOneofCase.PlaylistLocation)
			{
				return null;
			}
			return (Types.Playlist)location_;
		}
		set
		{
			location_ = value;
			locationCase_ = ((value != null) ? LocationOneofCase.PlaylistLocation : LocationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlist MediaPlaylistLocation
	{
		get
		{
			if (locationCase_ != LocationOneofCase.MediaPlaylistLocation)
			{
				return null;
			}
			return (Types.Playlist)location_;
		}
		set
		{
			location_ = value;
			locationCase_ = ((value != null) ? LocationOneofCase.MediaPlaylistLocation : LocationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlist AudioPlaylistLocation
	{
		get
		{
			if (locationCase_ != LocationOneofCase.AudioPlaylistLocation)
			{
				return null;
			}
			return (Types.Playlist)location_;
		}
		set
		{
			location_ = value;
			locationCase_ = ((value != null) ? LocationOneofCase.AudioPlaylistLocation : LocationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LocationOneofCase LocationCase => locationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerSource()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerSource(TriggerSource other)
		: this()
	{
		switch (other.LocationCase)
		{
		case LocationOneofCase.LibraryLocation:
			LibraryLocation = other.LibraryLocation.Clone();
			break;
		case LocationOneofCase.PlaylistLocation:
			PlaylistLocation = other.PlaylistLocation.Clone();
			break;
		case LocationOneofCase.MediaPlaylistLocation:
			MediaPlaylistLocation = other.MediaPlaylistLocation.Clone();
			break;
		case LocationOneofCase.AudioPlaylistLocation:
			AudioPlaylistLocation = other.AudioPlaylistLocation.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerSource Clone()
	{
		return new TriggerSource(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearLocation()
	{
		locationCase_ = LocationOneofCase.None;
		location_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TriggerSource);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TriggerSource other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(LibraryLocation, other.LibraryLocation))
		{
			return false;
		}
		if (!object.Equals(PlaylistLocation, other.PlaylistLocation))
		{
			return false;
		}
		if (!object.Equals(MediaPlaylistLocation, other.MediaPlaylistLocation))
		{
			return false;
		}
		if (!object.Equals(AudioPlaylistLocation, other.AudioPlaylistLocation))
		{
			return false;
		}
		if (LocationCase != other.LocationCase)
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
		if (locationCase_ == LocationOneofCase.LibraryLocation)
		{
			num ^= LibraryLocation.GetHashCode();
		}
		if (locationCase_ == LocationOneofCase.PlaylistLocation)
		{
			num ^= PlaylistLocation.GetHashCode();
		}
		if (locationCase_ == LocationOneofCase.MediaPlaylistLocation)
		{
			num ^= MediaPlaylistLocation.GetHashCode();
		}
		if (locationCase_ == LocationOneofCase.AudioPlaylistLocation)
		{
			num ^= AudioPlaylistLocation.GetHashCode();
		}
		num ^= (int)locationCase_;
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
		if (locationCase_ == LocationOneofCase.LibraryLocation)
		{
			output.WriteRawTag(10);
			output.WriteMessage(LibraryLocation);
		}
		if (locationCase_ == LocationOneofCase.PlaylistLocation)
		{
			output.WriteRawTag(18);
			output.WriteMessage(PlaylistLocation);
		}
		if (locationCase_ == LocationOneofCase.MediaPlaylistLocation)
		{
			output.WriteRawTag(26);
			output.WriteMessage(MediaPlaylistLocation);
		}
		if (locationCase_ == LocationOneofCase.AudioPlaylistLocation)
		{
			output.WriteRawTag(34);
			output.WriteMessage(AudioPlaylistLocation);
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
		if (locationCase_ == LocationOneofCase.LibraryLocation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LibraryLocation);
		}
		if (locationCase_ == LocationOneofCase.PlaylistLocation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistLocation);
		}
		if (locationCase_ == LocationOneofCase.MediaPlaylistLocation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaPlaylistLocation);
		}
		if (locationCase_ == LocationOneofCase.AudioPlaylistLocation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioPlaylistLocation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TriggerSource other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.LocationCase)
		{
		case LocationOneofCase.LibraryLocation:
			if (LibraryLocation == null)
			{
				LibraryLocation = new Types.Library();
			}
			LibraryLocation.MergeFrom(other.LibraryLocation);
			break;
		case LocationOneofCase.PlaylistLocation:
			if (PlaylistLocation == null)
			{
				PlaylistLocation = new Types.Playlist();
			}
			PlaylistLocation.MergeFrom(other.PlaylistLocation);
			break;
		case LocationOneofCase.MediaPlaylistLocation:
			if (MediaPlaylistLocation == null)
			{
				MediaPlaylistLocation = new Types.Playlist();
			}
			MediaPlaylistLocation.MergeFrom(other.MediaPlaylistLocation);
			break;
		case LocationOneofCase.AudioPlaylistLocation:
			if (AudioPlaylistLocation == null)
			{
				AudioPlaylistLocation = new Types.Playlist();
			}
			AudioPlaylistLocation.MergeFrom(other.AudioPlaylistLocation);
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
				Types.Library library = new Types.Library();
				if (locationCase_ == LocationOneofCase.LibraryLocation)
				{
					library.MergeFrom(LibraryLocation);
				}
				input.ReadMessage(library);
				LibraryLocation = library;
				break;
			}
			case 18u:
			{
				Types.Playlist playlist2 = new Types.Playlist();
				if (locationCase_ == LocationOneofCase.PlaylistLocation)
				{
					playlist2.MergeFrom(PlaylistLocation);
				}
				input.ReadMessage(playlist2);
				PlaylistLocation = playlist2;
				break;
			}
			case 26u:
			{
				Types.Playlist playlist3 = new Types.Playlist();
				if (locationCase_ == LocationOneofCase.MediaPlaylistLocation)
				{
					playlist3.MergeFrom(MediaPlaylistLocation);
				}
				input.ReadMessage(playlist3);
				MediaPlaylistLocation = playlist3;
				break;
			}
			case 34u:
			{
				Types.Playlist playlist = new Types.Playlist();
				if (locationCase_ == LocationOneofCase.AudioPlaylistLocation)
				{
					playlist.MergeFrom(AudioPlaylistLocation);
				}
				input.ReadMessage(playlist);
				AudioPlaylistLocation = playlist;
				break;
			}
			}
		}
	}
}
