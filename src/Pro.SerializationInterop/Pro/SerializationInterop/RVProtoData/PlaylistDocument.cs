using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PlaylistDocument : IMessage<PlaylistDocument>, IMessage, IEquatable<PlaylistDocument>, IDeepCloneable<PlaylistDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("TYPE_PRESENTATION")]
			Presentation,
			[OriginalName("TYPE_MEDIA")]
			Media,
			[OriginalName("TYPE_AUDIO")]
			Audio
		}
	}

	private static readonly MessageParser<PlaylistDocument> _parser = new MessageParser<PlaylistDocument>(() => new PlaylistDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int TypeFieldNumber = 2;

	private Types.Type type_;

	public const int RootNodeFieldNumber = 3;

	private Playlist rootNode_;

	public const int TagsFieldNumber = 4;

	private static readonly FieldCodec<Playlist.Types.Tag> _repeated_tags_codec = FieldCodec.ForMessage(34u, Playlist.Types.Tag.Parser);

	private readonly RepeatedField<Playlist.Types.Tag> tags_ = new RepeatedField<Playlist.Types.Tag>();

	public const int LiveVideoPlaylistFieldNumber = 5;

	private Playlist liveVideoPlaylist_;

	public const int DownloadsPlaylistFieldNumber = 6;

	private Playlist downloadsPlaylist_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PlaylistDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PropresenterReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
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
	public Playlist RootNode
	{
		get
		{
			return rootNode_;
		}
		set
		{
			rootNode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Playlist.Types.Tag> Tags => tags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist LiveVideoPlaylist
	{
		get
		{
			return liveVideoPlaylist_;
		}
		set
		{
			liveVideoPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist DownloadsPlaylist
	{
		get
		{
			return downloadsPlaylist_;
		}
		set
		{
			downloadsPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument(PlaylistDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		type_ = other.type_;
		rootNode_ = ((other.rootNode_ != null) ? other.rootNode_.Clone() : null);
		tags_ = other.tags_.Clone();
		liveVideoPlaylist_ = ((other.liveVideoPlaylist_ != null) ? other.liveVideoPlaylist_.Clone() : null);
		downloadsPlaylist_ = ((other.downloadsPlaylist_ != null) ? other.downloadsPlaylist_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument Clone()
	{
		return new PlaylistDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PlaylistDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PlaylistDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (!object.Equals(RootNode, other.RootNode))
		{
			return false;
		}
		if (!tags_.Equals(other.tags_))
		{
			return false;
		}
		if (!object.Equals(LiveVideoPlaylist, other.LiveVideoPlaylist))
		{
			return false;
		}
		if (!object.Equals(DownloadsPlaylist, other.DownloadsPlaylist))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (rootNode_ != null)
		{
			num ^= RootNode.GetHashCode();
		}
		num ^= tags_.GetHashCode();
		if (liveVideoPlaylist_ != null)
		{
			num ^= LiveVideoPlaylist.GetHashCode();
		}
		if (downloadsPlaylist_ != null)
		{
			num ^= DownloadsPlaylist.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		if (Type != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Type);
		}
		if (rootNode_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(RootNode);
		}
		tags_.WriteTo(output, _repeated_tags_codec);
		if (liveVideoPlaylist_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(LiveVideoPlaylist);
		}
		if (downloadsPlaylist_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(DownloadsPlaylist);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (rootNode_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RootNode);
		}
		num += tags_.CalculateSize(_repeated_tags_codec);
		if (liveVideoPlaylist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveVideoPlaylist);
		}
		if (downloadsPlaylist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DownloadsPlaylist);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PlaylistDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		if (other.rootNode_ != null)
		{
			if (rootNode_ == null)
			{
				RootNode = new Playlist();
			}
			RootNode.MergeFrom(other.RootNode);
		}
		tags_.Add(other.tags_);
		if (other.liveVideoPlaylist_ != null)
		{
			if (liveVideoPlaylist_ == null)
			{
				LiveVideoPlaylist = new Playlist();
			}
			LiveVideoPlaylist.MergeFrom(other.LiveVideoPlaylist);
		}
		if (other.downloadsPlaylist_ != null)
		{
			if (downloadsPlaylist_ == null)
			{
				DownloadsPlaylist = new Playlist();
			}
			DownloadsPlaylist.MergeFrom(other.DownloadsPlaylist);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 16u:
				Type = (Types.Type)input.ReadEnum();
				break;
			case 26u:
				if (rootNode_ == null)
				{
					RootNode = new Playlist();
				}
				input.ReadMessage(RootNode);
				break;
			case 34u:
				tags_.AddEntriesFrom(input, _repeated_tags_codec);
				break;
			case 42u:
				if (liveVideoPlaylist_ == null)
				{
					LiveVideoPlaylist = new Playlist();
				}
				input.ReadMessage(LiveVideoPlaylist);
				break;
			case 50u:
				if (downloadsPlaylist_ == null)
				{
					DownloadsPlaylist = new Playlist();
				}
				input.ReadMessage(DownloadsPlaylist);
				break;
			}
		}
	}
}
