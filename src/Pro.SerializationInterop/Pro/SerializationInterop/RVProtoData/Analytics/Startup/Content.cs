using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Content : IMessage<Content>, IMessage, IEquatable<Content>, IDeepCloneable<Content>
{
	private static readonly MessageParser<Content> _parser = new MessageParser<Content>(() => new Content());

	private UnknownFieldSet _unknownFields;

	public const int LibraryCountFieldNumber = 1;

	private int libraryCount_;

	public const int LibraryPlaylistCountFieldNumber = 2;

	private int libraryPlaylistCount_;

	public const int LibraryPlaylistFolderCountFieldNumber = 3;

	private int libraryPlaylistFolderCount_;

	public const int LibraryPlaylistMaxDepthFieldNumber = 4;

	private int libraryPlaylistMaxDepth_;

	public const int MediaBinTotalPlaylistCountFieldNumber = 5;

	private int mediaBinTotalPlaylistCount_;

	public const int MediaBinPlaylistFolderCountFieldNumber = 6;

	private int mediaBinPlaylistFolderCount_;

	public const int MediaBinPlaylistMaxDepthFieldNumber = 7;

	private int mediaBinPlaylistMaxDepth_;

	public const int MediaBinNormalPlaylistCountFieldNumber = 8;

	private int mediaBinNormalPlaylistCount_;

	public const int MediaBinSmartPlaylistCountFieldNumber = 9;

	private int mediaBinSmartPlaylistCount_;

	public const int MediaBinVideoInputCountFieldNumber = 10;

	private int mediaBinVideoInputCount_;

	public const int AudioBinPlaylistCountFieldNumber = 11;

	private int audioBinPlaylistCount_;

	public const int AudioBinPlaylistFolderCountFieldNumber = 12;

	private int audioBinPlaylistFolderCount_;

	public const int AudioBinPlaylistMaxDepthFieldNumber = 13;

	private int audioBinPlaylistMaxDepth_;

	public const int TimerCountFieldNumber = 14;

	private int timerCount_;

	public const int MessagesCountFieldNumber = 15;

	private int messagesCount_;

	public const int PropsCountFieldNumber = 16;

	private int propsCount_;

	public const int PropsAutoClearCountFieldNumber = 17;

	private int propsAutoClearCount_;

	public const int PropCollectionsCountFieldNumber = 18;

	private int propCollectionsCount_;

	public const int PropCollectionsSinglePropEnabledCountFieldNumber = 19;

	private int propCollectionsSinglePropEnabledCount_;

	public const int StageLayoutCountFieldNumber = 20;

	private int stageLayoutCount_;

	public const int MacrosCountFieldNumber = 21;

	private int macrosCount_;

	public const int MacrosCollectionsCountFieldNumber = 22;

	private int macrosCollectionsCount_;

	public const int MacrosCustomIconsFieldNumber = 23;

	private int macrosCustomIcons_;

	public const int UbiquitousShowDirectoryFieldNumber = 24;

	private bool ubiquitousShowDirectory_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Content> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LibraryCount
	{
		get
		{
			return libraryCount_;
		}
		set
		{
			libraryCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LibraryPlaylistCount
	{
		get
		{
			return libraryPlaylistCount_;
		}
		set
		{
			libraryPlaylistCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LibraryPlaylistFolderCount
	{
		get
		{
			return libraryPlaylistFolderCount_;
		}
		set
		{
			libraryPlaylistFolderCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LibraryPlaylistMaxDepth
	{
		get
		{
			return libraryPlaylistMaxDepth_;
		}
		set
		{
			libraryPlaylistMaxDepth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinTotalPlaylistCount
	{
		get
		{
			return mediaBinTotalPlaylistCount_;
		}
		set
		{
			mediaBinTotalPlaylistCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinPlaylistFolderCount
	{
		get
		{
			return mediaBinPlaylistFolderCount_;
		}
		set
		{
			mediaBinPlaylistFolderCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinPlaylistMaxDepth
	{
		get
		{
			return mediaBinPlaylistMaxDepth_;
		}
		set
		{
			mediaBinPlaylistMaxDepth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinNormalPlaylistCount
	{
		get
		{
			return mediaBinNormalPlaylistCount_;
		}
		set
		{
			mediaBinNormalPlaylistCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinSmartPlaylistCount
	{
		get
		{
			return mediaBinSmartPlaylistCount_;
		}
		set
		{
			mediaBinSmartPlaylistCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinVideoInputCount
	{
		get
		{
			return mediaBinVideoInputCount_;
		}
		set
		{
			mediaBinVideoInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int AudioBinPlaylistCount
	{
		get
		{
			return audioBinPlaylistCount_;
		}
		set
		{
			audioBinPlaylistCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int AudioBinPlaylistFolderCount
	{
		get
		{
			return audioBinPlaylistFolderCount_;
		}
		set
		{
			audioBinPlaylistFolderCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int AudioBinPlaylistMaxDepth
	{
		get
		{
			return audioBinPlaylistMaxDepth_;
		}
		set
		{
			audioBinPlaylistMaxDepth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TimerCount
	{
		get
		{
			return timerCount_;
		}
		set
		{
			timerCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MessagesCount
	{
		get
		{
			return messagesCount_;
		}
		set
		{
			messagesCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PropsCount
	{
		get
		{
			return propsCount_;
		}
		set
		{
			propsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PropsAutoClearCount
	{
		get
		{
			return propsAutoClearCount_;
		}
		set
		{
			propsAutoClearCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PropCollectionsCount
	{
		get
		{
			return propCollectionsCount_;
		}
		set
		{
			propCollectionsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PropCollectionsSinglePropEnabledCount
	{
		get
		{
			return propCollectionsSinglePropEnabledCount_;
		}
		set
		{
			propCollectionsSinglePropEnabledCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int StageLayoutCount
	{
		get
		{
			return stageLayoutCount_;
		}
		set
		{
			stageLayoutCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MacrosCount
	{
		get
		{
			return macrosCount_;
		}
		set
		{
			macrosCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MacrosCollectionsCount
	{
		get
		{
			return macrosCollectionsCount_;
		}
		set
		{
			macrosCollectionsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MacrosCustomIcons
	{
		get
		{
			return macrosCustomIcons_;
		}
		set
		{
			macrosCustomIcons_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UbiquitousShowDirectory
	{
		get
		{
			return ubiquitousShowDirectory_;
		}
		set
		{
			ubiquitousShowDirectory_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Content()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Content(Content other)
		: this()
	{
		libraryCount_ = other.libraryCount_;
		libraryPlaylistCount_ = other.libraryPlaylistCount_;
		libraryPlaylistFolderCount_ = other.libraryPlaylistFolderCount_;
		libraryPlaylistMaxDepth_ = other.libraryPlaylistMaxDepth_;
		mediaBinTotalPlaylistCount_ = other.mediaBinTotalPlaylistCount_;
		mediaBinPlaylistFolderCount_ = other.mediaBinPlaylistFolderCount_;
		mediaBinPlaylistMaxDepth_ = other.mediaBinPlaylistMaxDepth_;
		mediaBinNormalPlaylistCount_ = other.mediaBinNormalPlaylistCount_;
		mediaBinSmartPlaylistCount_ = other.mediaBinSmartPlaylistCount_;
		mediaBinVideoInputCount_ = other.mediaBinVideoInputCount_;
		audioBinPlaylistCount_ = other.audioBinPlaylistCount_;
		audioBinPlaylistFolderCount_ = other.audioBinPlaylistFolderCount_;
		audioBinPlaylistMaxDepth_ = other.audioBinPlaylistMaxDepth_;
		timerCount_ = other.timerCount_;
		messagesCount_ = other.messagesCount_;
		propsCount_ = other.propsCount_;
		propsAutoClearCount_ = other.propsAutoClearCount_;
		propCollectionsCount_ = other.propCollectionsCount_;
		propCollectionsSinglePropEnabledCount_ = other.propCollectionsSinglePropEnabledCount_;
		stageLayoutCount_ = other.stageLayoutCount_;
		macrosCount_ = other.macrosCount_;
		macrosCollectionsCount_ = other.macrosCollectionsCount_;
		macrosCustomIcons_ = other.macrosCustomIcons_;
		ubiquitousShowDirectory_ = other.ubiquitousShowDirectory_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Content Clone()
	{
		return new Content(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Content);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Content other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (LibraryCount != other.LibraryCount)
		{
			return false;
		}
		if (LibraryPlaylistCount != other.LibraryPlaylistCount)
		{
			return false;
		}
		if (LibraryPlaylistFolderCount != other.LibraryPlaylistFolderCount)
		{
			return false;
		}
		if (LibraryPlaylistMaxDepth != other.LibraryPlaylistMaxDepth)
		{
			return false;
		}
		if (MediaBinTotalPlaylistCount != other.MediaBinTotalPlaylistCount)
		{
			return false;
		}
		if (MediaBinPlaylistFolderCount != other.MediaBinPlaylistFolderCount)
		{
			return false;
		}
		if (MediaBinPlaylistMaxDepth != other.MediaBinPlaylistMaxDepth)
		{
			return false;
		}
		if (MediaBinNormalPlaylistCount != other.MediaBinNormalPlaylistCount)
		{
			return false;
		}
		if (MediaBinSmartPlaylistCount != other.MediaBinSmartPlaylistCount)
		{
			return false;
		}
		if (MediaBinVideoInputCount != other.MediaBinVideoInputCount)
		{
			return false;
		}
		if (AudioBinPlaylistCount != other.AudioBinPlaylistCount)
		{
			return false;
		}
		if (AudioBinPlaylistFolderCount != other.AudioBinPlaylistFolderCount)
		{
			return false;
		}
		if (AudioBinPlaylistMaxDepth != other.AudioBinPlaylistMaxDepth)
		{
			return false;
		}
		if (TimerCount != other.TimerCount)
		{
			return false;
		}
		if (MessagesCount != other.MessagesCount)
		{
			return false;
		}
		if (PropsCount != other.PropsCount)
		{
			return false;
		}
		if (PropsAutoClearCount != other.PropsAutoClearCount)
		{
			return false;
		}
		if (PropCollectionsCount != other.PropCollectionsCount)
		{
			return false;
		}
		if (PropCollectionsSinglePropEnabledCount != other.PropCollectionsSinglePropEnabledCount)
		{
			return false;
		}
		if (StageLayoutCount != other.StageLayoutCount)
		{
			return false;
		}
		if (MacrosCount != other.MacrosCount)
		{
			return false;
		}
		if (MacrosCollectionsCount != other.MacrosCollectionsCount)
		{
			return false;
		}
		if (MacrosCustomIcons != other.MacrosCustomIcons)
		{
			return false;
		}
		if (UbiquitousShowDirectory != other.UbiquitousShowDirectory)
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
		if (LibraryCount != 0)
		{
			num ^= LibraryCount.GetHashCode();
		}
		if (LibraryPlaylistCount != 0)
		{
			num ^= LibraryPlaylistCount.GetHashCode();
		}
		if (LibraryPlaylistFolderCount != 0)
		{
			num ^= LibraryPlaylistFolderCount.GetHashCode();
		}
		if (LibraryPlaylistMaxDepth != 0)
		{
			num ^= LibraryPlaylistMaxDepth.GetHashCode();
		}
		if (MediaBinTotalPlaylistCount != 0)
		{
			num ^= MediaBinTotalPlaylistCount.GetHashCode();
		}
		if (MediaBinPlaylistFolderCount != 0)
		{
			num ^= MediaBinPlaylistFolderCount.GetHashCode();
		}
		if (MediaBinPlaylistMaxDepth != 0)
		{
			num ^= MediaBinPlaylistMaxDepth.GetHashCode();
		}
		if (MediaBinNormalPlaylistCount != 0)
		{
			num ^= MediaBinNormalPlaylistCount.GetHashCode();
		}
		if (MediaBinSmartPlaylistCount != 0)
		{
			num ^= MediaBinSmartPlaylistCount.GetHashCode();
		}
		if (MediaBinVideoInputCount != 0)
		{
			num ^= MediaBinVideoInputCount.GetHashCode();
		}
		if (AudioBinPlaylistCount != 0)
		{
			num ^= AudioBinPlaylistCount.GetHashCode();
		}
		if (AudioBinPlaylistFolderCount != 0)
		{
			num ^= AudioBinPlaylistFolderCount.GetHashCode();
		}
		if (AudioBinPlaylistMaxDepth != 0)
		{
			num ^= AudioBinPlaylistMaxDepth.GetHashCode();
		}
		if (TimerCount != 0)
		{
			num ^= TimerCount.GetHashCode();
		}
		if (MessagesCount != 0)
		{
			num ^= MessagesCount.GetHashCode();
		}
		if (PropsCount != 0)
		{
			num ^= PropsCount.GetHashCode();
		}
		if (PropsAutoClearCount != 0)
		{
			num ^= PropsAutoClearCount.GetHashCode();
		}
		if (PropCollectionsCount != 0)
		{
			num ^= PropCollectionsCount.GetHashCode();
		}
		if (PropCollectionsSinglePropEnabledCount != 0)
		{
			num ^= PropCollectionsSinglePropEnabledCount.GetHashCode();
		}
		if (StageLayoutCount != 0)
		{
			num ^= StageLayoutCount.GetHashCode();
		}
		if (MacrosCount != 0)
		{
			num ^= MacrosCount.GetHashCode();
		}
		if (MacrosCollectionsCount != 0)
		{
			num ^= MacrosCollectionsCount.GetHashCode();
		}
		if (MacrosCustomIcons != 0)
		{
			num ^= MacrosCustomIcons.GetHashCode();
		}
		if (UbiquitousShowDirectory)
		{
			num ^= UbiquitousShowDirectory.GetHashCode();
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
		if (LibraryCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(LibraryCount);
		}
		if (LibraryPlaylistCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(LibraryPlaylistCount);
		}
		if (LibraryPlaylistFolderCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(LibraryPlaylistFolderCount);
		}
		if (LibraryPlaylistMaxDepth != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(LibraryPlaylistMaxDepth);
		}
		if (MediaBinTotalPlaylistCount != 0)
		{
			output.WriteRawTag(40);
			output.WriteInt32(MediaBinTotalPlaylistCount);
		}
		if (MediaBinPlaylistFolderCount != 0)
		{
			output.WriteRawTag(48);
			output.WriteInt32(MediaBinPlaylistFolderCount);
		}
		if (MediaBinPlaylistMaxDepth != 0)
		{
			output.WriteRawTag(56);
			output.WriteInt32(MediaBinPlaylistMaxDepth);
		}
		if (MediaBinNormalPlaylistCount != 0)
		{
			output.WriteRawTag(64);
			output.WriteInt32(MediaBinNormalPlaylistCount);
		}
		if (MediaBinSmartPlaylistCount != 0)
		{
			output.WriteRawTag(72);
			output.WriteInt32(MediaBinSmartPlaylistCount);
		}
		if (MediaBinVideoInputCount != 0)
		{
			output.WriteRawTag(80);
			output.WriteInt32(MediaBinVideoInputCount);
		}
		if (AudioBinPlaylistCount != 0)
		{
			output.WriteRawTag(88);
			output.WriteInt32(AudioBinPlaylistCount);
		}
		if (AudioBinPlaylistFolderCount != 0)
		{
			output.WriteRawTag(96);
			output.WriteInt32(AudioBinPlaylistFolderCount);
		}
		if (AudioBinPlaylistMaxDepth != 0)
		{
			output.WriteRawTag(104);
			output.WriteInt32(AudioBinPlaylistMaxDepth);
		}
		if (TimerCount != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(TimerCount);
		}
		if (MessagesCount != 0)
		{
			output.WriteRawTag(120);
			output.WriteInt32(MessagesCount);
		}
		if (PropsCount != 0)
		{
			output.WriteRawTag(128, 1);
			output.WriteInt32(PropsCount);
		}
		if (PropsAutoClearCount != 0)
		{
			output.WriteRawTag(136, 1);
			output.WriteInt32(PropsAutoClearCount);
		}
		if (PropCollectionsCount != 0)
		{
			output.WriteRawTag(144, 1);
			output.WriteInt32(PropCollectionsCount);
		}
		if (PropCollectionsSinglePropEnabledCount != 0)
		{
			output.WriteRawTag(152, 1);
			output.WriteInt32(PropCollectionsSinglePropEnabledCount);
		}
		if (StageLayoutCount != 0)
		{
			output.WriteRawTag(160, 1);
			output.WriteInt32(StageLayoutCount);
		}
		if (MacrosCount != 0)
		{
			output.WriteRawTag(168, 1);
			output.WriteInt32(MacrosCount);
		}
		if (MacrosCollectionsCount != 0)
		{
			output.WriteRawTag(176, 1);
			output.WriteInt32(MacrosCollectionsCount);
		}
		if (MacrosCustomIcons != 0)
		{
			output.WriteRawTag(184, 1);
			output.WriteInt32(MacrosCustomIcons);
		}
		if (UbiquitousShowDirectory)
		{
			output.WriteRawTag(192, 1);
			output.WriteBool(UbiquitousShowDirectory);
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
		if (LibraryCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(LibraryCount);
		}
		if (LibraryPlaylistCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(LibraryPlaylistCount);
		}
		if (LibraryPlaylistFolderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(LibraryPlaylistFolderCount);
		}
		if (LibraryPlaylistMaxDepth != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(LibraryPlaylistMaxDepth);
		}
		if (MediaBinTotalPlaylistCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinTotalPlaylistCount);
		}
		if (MediaBinPlaylistFolderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinPlaylistFolderCount);
		}
		if (MediaBinPlaylistMaxDepth != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinPlaylistMaxDepth);
		}
		if (MediaBinNormalPlaylistCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinNormalPlaylistCount);
		}
		if (MediaBinSmartPlaylistCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinSmartPlaylistCount);
		}
		if (MediaBinVideoInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinVideoInputCount);
		}
		if (AudioBinPlaylistCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(AudioBinPlaylistCount);
		}
		if (AudioBinPlaylistFolderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(AudioBinPlaylistFolderCount);
		}
		if (AudioBinPlaylistMaxDepth != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(AudioBinPlaylistMaxDepth);
		}
		if (TimerCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TimerCount);
		}
		if (MessagesCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MessagesCount);
		}
		if (PropsCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(PropsCount);
		}
		if (PropsAutoClearCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(PropsAutoClearCount);
		}
		if (PropCollectionsCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(PropCollectionsCount);
		}
		if (PropCollectionsSinglePropEnabledCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(PropCollectionsSinglePropEnabledCount);
		}
		if (StageLayoutCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(StageLayoutCount);
		}
		if (MacrosCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(MacrosCount);
		}
		if (MacrosCollectionsCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(MacrosCollectionsCount);
		}
		if (MacrosCustomIcons != 0)
		{
			num += 2 + CodedOutputStream.ComputeInt32Size(MacrosCustomIcons);
		}
		if (UbiquitousShowDirectory)
		{
			num += 3;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Content other)
	{
		if (other != null)
		{
			if (other.LibraryCount != 0)
			{
				LibraryCount = other.LibraryCount;
			}
			if (other.LibraryPlaylistCount != 0)
			{
				LibraryPlaylistCount = other.LibraryPlaylistCount;
			}
			if (other.LibraryPlaylistFolderCount != 0)
			{
				LibraryPlaylistFolderCount = other.LibraryPlaylistFolderCount;
			}
			if (other.LibraryPlaylistMaxDepth != 0)
			{
				LibraryPlaylistMaxDepth = other.LibraryPlaylistMaxDepth;
			}
			if (other.MediaBinTotalPlaylistCount != 0)
			{
				MediaBinTotalPlaylistCount = other.MediaBinTotalPlaylistCount;
			}
			if (other.MediaBinPlaylistFolderCount != 0)
			{
				MediaBinPlaylistFolderCount = other.MediaBinPlaylistFolderCount;
			}
			if (other.MediaBinPlaylistMaxDepth != 0)
			{
				MediaBinPlaylistMaxDepth = other.MediaBinPlaylistMaxDepth;
			}
			if (other.MediaBinNormalPlaylistCount != 0)
			{
				MediaBinNormalPlaylistCount = other.MediaBinNormalPlaylistCount;
			}
			if (other.MediaBinSmartPlaylistCount != 0)
			{
				MediaBinSmartPlaylistCount = other.MediaBinSmartPlaylistCount;
			}
			if (other.MediaBinVideoInputCount != 0)
			{
				MediaBinVideoInputCount = other.MediaBinVideoInputCount;
			}
			if (other.AudioBinPlaylistCount != 0)
			{
				AudioBinPlaylistCount = other.AudioBinPlaylistCount;
			}
			if (other.AudioBinPlaylistFolderCount != 0)
			{
				AudioBinPlaylistFolderCount = other.AudioBinPlaylistFolderCount;
			}
			if (other.AudioBinPlaylistMaxDepth != 0)
			{
				AudioBinPlaylistMaxDepth = other.AudioBinPlaylistMaxDepth;
			}
			if (other.TimerCount != 0)
			{
				TimerCount = other.TimerCount;
			}
			if (other.MessagesCount != 0)
			{
				MessagesCount = other.MessagesCount;
			}
			if (other.PropsCount != 0)
			{
				PropsCount = other.PropsCount;
			}
			if (other.PropsAutoClearCount != 0)
			{
				PropsAutoClearCount = other.PropsAutoClearCount;
			}
			if (other.PropCollectionsCount != 0)
			{
				PropCollectionsCount = other.PropCollectionsCount;
			}
			if (other.PropCollectionsSinglePropEnabledCount != 0)
			{
				PropCollectionsSinglePropEnabledCount = other.PropCollectionsSinglePropEnabledCount;
			}
			if (other.StageLayoutCount != 0)
			{
				StageLayoutCount = other.StageLayoutCount;
			}
			if (other.MacrosCount != 0)
			{
				MacrosCount = other.MacrosCount;
			}
			if (other.MacrosCollectionsCount != 0)
			{
				MacrosCollectionsCount = other.MacrosCollectionsCount;
			}
			if (other.MacrosCustomIcons != 0)
			{
				MacrosCustomIcons = other.MacrosCustomIcons;
			}
			if (other.UbiquitousShowDirectory)
			{
				UbiquitousShowDirectory = other.UbiquitousShowDirectory;
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
				LibraryCount = input.ReadInt32();
				break;
			case 16u:
				LibraryPlaylistCount = input.ReadInt32();
				break;
			case 24u:
				LibraryPlaylistFolderCount = input.ReadInt32();
				break;
			case 32u:
				LibraryPlaylistMaxDepth = input.ReadInt32();
				break;
			case 40u:
				MediaBinTotalPlaylistCount = input.ReadInt32();
				break;
			case 48u:
				MediaBinPlaylistFolderCount = input.ReadInt32();
				break;
			case 56u:
				MediaBinPlaylistMaxDepth = input.ReadInt32();
				break;
			case 64u:
				MediaBinNormalPlaylistCount = input.ReadInt32();
				break;
			case 72u:
				MediaBinSmartPlaylistCount = input.ReadInt32();
				break;
			case 80u:
				MediaBinVideoInputCount = input.ReadInt32();
				break;
			case 88u:
				AudioBinPlaylistCount = input.ReadInt32();
				break;
			case 96u:
				AudioBinPlaylistFolderCount = input.ReadInt32();
				break;
			case 104u:
				AudioBinPlaylistMaxDepth = input.ReadInt32();
				break;
			case 112u:
				TimerCount = input.ReadInt32();
				break;
			case 120u:
				MessagesCount = input.ReadInt32();
				break;
			case 128u:
				PropsCount = input.ReadInt32();
				break;
			case 136u:
				PropsAutoClearCount = input.ReadInt32();
				break;
			case 144u:
				PropCollectionsCount = input.ReadInt32();
				break;
			case 152u:
				PropCollectionsSinglePropEnabledCount = input.ReadInt32();
				break;
			case 160u:
				StageLayoutCount = input.ReadInt32();
				break;
			case 168u:
				MacrosCount = input.ReadInt32();
				break;
			case 176u:
				MacrosCollectionsCount = input.ReadInt32();
				break;
			case 184u:
				MacrosCustomIcons = input.ReadInt32();
				break;
			case 192u:
				UbiquitousShowDirectory = input.ReadBool();
				break;
			}
		}
	}
}
