using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_PlaylistAndItem : IMessage<API_v1_PlaylistAndItem>, IMessage, IEquatable<API_v1_PlaylistAndItem>, IDeepCloneable<API_v1_PlaylistAndItem>
{
	private static readonly MessageParser<API_v1_PlaylistAndItem> _parser = new MessageParser<API_v1_PlaylistAndItem>(() => new API_v1_PlaylistAndItem());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistFieldNumber = 1;

	private API_v1_Identifier playlist_;

	public const int ItemFieldNumber = 2;

	private API_v1_Identifier item_;

	public const int PlaylistItemFieldNumber = 3;

	private API_v1_PlaylistItem playlistItem_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_PlaylistAndItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PlaylistReflection.Descriptor.MessageTypes[1];

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
	public API_v1_PlaylistItem PlaylistItem
	{
		get
		{
			return playlistItem_;
		}
		set
		{
			playlistItem_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistAndItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistAndItem(API_v1_PlaylistAndItem other)
		: this()
	{
		playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
		item_ = ((other.item_ != null) ? other.item_.Clone() : null);
		playlistItem_ = ((other.playlistItem_ != null) ? other.playlistItem_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistAndItem Clone()
	{
		return new API_v1_PlaylistAndItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_PlaylistAndItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_PlaylistAndItem other)
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
		if (!object.Equals(PlaylistItem, other.PlaylistItem))
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
		if (playlistItem_ != null)
		{
			num ^= PlaylistItem.GetHashCode();
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
		if (playlistItem_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PlaylistItem);
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
		if (playlistItem_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistItem);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_PlaylistAndItem other)
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
		if (other.playlistItem_ != null)
		{
			if (playlistItem_ == null)
			{
				PlaylistItem = new API_v1_PlaylistItem();
			}
			PlaylistItem.MergeFrom(other.PlaylistItem);
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
			case 26u:
				if (playlistItem_ == null)
				{
					PlaylistItem = new API_v1_PlaylistItem();
				}
				input.ReadMessage(PlaylistItem);
				break;
			}
		}
	}
}
