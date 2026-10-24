using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_MediaPlaylistItem : IMessage<API_v1_MediaPlaylistItem>, IMessage, IEquatable<API_v1_MediaPlaylistItem>, IDeepCloneable<API_v1_MediaPlaylistItem>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_MediaPlaylistItemType
		{
			[OriginalName("audio")]
			Audio,
			[OriginalName("image")]
			Image,
			[OriginalName("video")]
			Video
		}
	}

	private static readonly MessageParser<API_v1_MediaPlaylistItem> _parser = new MessageParser<API_v1_MediaPlaylistItem>(() => new API_v1_MediaPlaylistItem());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int TypeFieldNumber = 2;

	private Types.API_v1_MediaPlaylistItemType type_;

	public const int ArtistFieldNumber = 3;

	private string artist_ = "";

	public const int DurationFieldNumber = 4;

	private uint duration_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_MediaPlaylistItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MediaPlaylistItemReflection.Descriptor.MessageTypes[0];

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
	public Types.API_v1_MediaPlaylistItemType Type
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
	public string Artist
	{
		get
		{
			return artist_;
		}
		set
		{
			artist_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Duration
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
	public API_v1_MediaPlaylistItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_MediaPlaylistItem(API_v1_MediaPlaylistItem other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		type_ = other.type_;
		artist_ = other.artist_;
		duration_ = other.duration_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_MediaPlaylistItem Clone()
	{
		return new API_v1_MediaPlaylistItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_MediaPlaylistItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_MediaPlaylistItem other)
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
		if (Type != other.Type)
		{
			return false;
		}
		if (Artist != other.Artist)
		{
			return false;
		}
		if (Duration != other.Duration)
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (Artist.Length != 0)
		{
			num ^= Artist.GetHashCode();
		}
		if (Duration != 0)
		{
			num ^= Duration.GetHashCode();
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
		if (Type != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Type);
		}
		if (Artist.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Artist);
		}
		if (Duration != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(Duration);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (Artist.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Artist);
		}
		if (Duration != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Duration);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_MediaPlaylistItem other)
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
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		if (other.Artist.Length != 0)
		{
			Artist = other.Artist;
		}
		if (other.Duration != 0)
		{
			Duration = other.Duration;
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 16u:
				Type = (Types.API_v1_MediaPlaylistItemType)input.ReadEnum();
				break;
			case 26u:
				Artist = input.ReadString();
				break;
			case 32u:
				Duration = input.ReadUInt32();
				break;
			}
		}
	}
}
