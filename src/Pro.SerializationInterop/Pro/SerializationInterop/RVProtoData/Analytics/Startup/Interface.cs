using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Interface : IMessage<Interface>, IMessage, IEquatable<Interface>, IDeepCloneable<Interface>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum SplitViewState
		{
			[OriginalName("SPLIT_VIEW_STATE_UNKNOWN")]
			Unknown,
			[OriginalName("SPLIT_VIEW_STATE_COLLAPSED")]
			Collapsed,
			[OriginalName("SPLIT_VIEW_STATE_EXPANDED")]
			Expanded
		}

		public enum PresentationViewStyle
		{
			[OriginalName("PRESENTATION_VIEW_STYLE_UNKNOWN")]
			Unknown,
			[OriginalName("PRESENTATION_VIEW_STYLE_GRID")]
			Grid,
			[OriginalName("PRESENTATION_VIEW_STYLE_EASY")]
			Easy,
			[OriginalName("PRESENTATION_VIEW_STYLE_TABLE")]
			Table
		}

		public enum MediaBinViewStyle
		{
			[OriginalName("MEDIA_BIN_VIEW_STYLE_UNKNOWN")]
			Unknown,
			[OriginalName("MEDIA_BIN_VIEW_STYLE_GRID")]
			Grid,
			[OriginalName("MEDIA_BIN_VIEW_STYLE_TABLE")]
			Table
		}
	}

	private static readonly MessageParser<Interface> _parser = new MessageParser<Interface>(() => new Interface());

	private UnknownFieldSet _unknownFields;

	public const int LibraryOutlineFieldNumber = 1;

	private Types.SplitViewState libraryOutline_;

	public const int MediaOutlineFieldNumber = 2;

	private Types.SplitViewState mediaOutline_;

	public const int AudioOutlineFieldNumber = 3;

	private Types.SplitViewState audioOutline_;

	public const int ContinuousPlaylistFieldNumber = 4;

	private bool continuousPlaylist_;

	public const int MediaBinFieldNumber = 5;

	private Types.SplitViewState mediaBin_;

	public const int PresentationViewStyleFieldNumber = 6;

	private Types.PresentationViewStyle presentationViewStyle_;

	public const int PresentationGridColumnCountFieldNumber = 7;

	private int presentationGridColumnCount_;

	public const int MediaBinViewStyleFieldNumber = 8;

	private Types.MediaBinViewStyle mediaBinViewStyle_;

	public const int MediaBinGridColumnCountFieldNumber = 9;

	private int mediaBinGridColumnCount_;

	public const int MediaBinTableColumnCountFieldNumber = 10;

	private int mediaBinTableColumnCount_;

	public const int PresentationTransitionFieldNumber = 11;

	private string presentationTransition_ = "";

	public const int MediaTransitionFieldNumber = 12;

	private string mediaTransition_ = "";

	public const int AudioShuffleFieldNumber = 13;

	private bool audioShuffle_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Interface> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[20];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SplitViewState LibraryOutline
	{
		get
		{
			return libraryOutline_;
		}
		set
		{
			libraryOutline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SplitViewState MediaOutline
	{
		get
		{
			return mediaOutline_;
		}
		set
		{
			mediaOutline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SplitViewState AudioOutline
	{
		get
		{
			return audioOutline_;
		}
		set
		{
			audioOutline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ContinuousPlaylist
	{
		get
		{
			return continuousPlaylist_;
		}
		set
		{
			continuousPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SplitViewState MediaBin
	{
		get
		{
			return mediaBin_;
		}
		set
		{
			mediaBin_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PresentationViewStyle PresentationViewStyle
	{
		get
		{
			return presentationViewStyle_;
		}
		set
		{
			presentationViewStyle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PresentationGridColumnCount
	{
		get
		{
			return presentationGridColumnCount_;
		}
		set
		{
			presentationGridColumnCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaBinViewStyle MediaBinViewStyle
	{
		get
		{
			return mediaBinViewStyle_;
		}
		set
		{
			mediaBinViewStyle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinGridColumnCount
	{
		get
		{
			return mediaBinGridColumnCount_;
		}
		set
		{
			mediaBinGridColumnCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaBinTableColumnCount
	{
		get
		{
			return mediaBinTableColumnCount_;
		}
		set
		{
			mediaBinTableColumnCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PresentationTransition
	{
		get
		{
			return presentationTransition_;
		}
		set
		{
			presentationTransition_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MediaTransition
	{
		get
		{
			return mediaTransition_;
		}
		set
		{
			mediaTransition_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AudioShuffle
	{
		get
		{
			return audioShuffle_;
		}
		set
		{
			audioShuffle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Interface()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Interface(Interface other)
		: this()
	{
		libraryOutline_ = other.libraryOutline_;
		mediaOutline_ = other.mediaOutline_;
		audioOutline_ = other.audioOutline_;
		continuousPlaylist_ = other.continuousPlaylist_;
		mediaBin_ = other.mediaBin_;
		presentationViewStyle_ = other.presentationViewStyle_;
		presentationGridColumnCount_ = other.presentationGridColumnCount_;
		mediaBinViewStyle_ = other.mediaBinViewStyle_;
		mediaBinGridColumnCount_ = other.mediaBinGridColumnCount_;
		mediaBinTableColumnCount_ = other.mediaBinTableColumnCount_;
		presentationTransition_ = other.presentationTransition_;
		mediaTransition_ = other.mediaTransition_;
		audioShuffle_ = other.audioShuffle_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Interface Clone()
	{
		return new Interface(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Interface);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Interface other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (LibraryOutline != other.LibraryOutline)
		{
			return false;
		}
		if (MediaOutline != other.MediaOutline)
		{
			return false;
		}
		if (AudioOutline != other.AudioOutline)
		{
			return false;
		}
		if (ContinuousPlaylist != other.ContinuousPlaylist)
		{
			return false;
		}
		if (MediaBin != other.MediaBin)
		{
			return false;
		}
		if (PresentationViewStyle != other.PresentationViewStyle)
		{
			return false;
		}
		if (PresentationGridColumnCount != other.PresentationGridColumnCount)
		{
			return false;
		}
		if (MediaBinViewStyle != other.MediaBinViewStyle)
		{
			return false;
		}
		if (MediaBinGridColumnCount != other.MediaBinGridColumnCount)
		{
			return false;
		}
		if (MediaBinTableColumnCount != other.MediaBinTableColumnCount)
		{
			return false;
		}
		if (PresentationTransition != other.PresentationTransition)
		{
			return false;
		}
		if (MediaTransition != other.MediaTransition)
		{
			return false;
		}
		if (AudioShuffle != other.AudioShuffle)
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
		if (LibraryOutline != 0)
		{
			num ^= LibraryOutline.GetHashCode();
		}
		if (MediaOutline != 0)
		{
			num ^= MediaOutline.GetHashCode();
		}
		if (AudioOutline != 0)
		{
			num ^= AudioOutline.GetHashCode();
		}
		if (ContinuousPlaylist)
		{
			num ^= ContinuousPlaylist.GetHashCode();
		}
		if (MediaBin != 0)
		{
			num ^= MediaBin.GetHashCode();
		}
		if (PresentationViewStyle != 0)
		{
			num ^= PresentationViewStyle.GetHashCode();
		}
		if (PresentationGridColumnCount != 0)
		{
			num ^= PresentationGridColumnCount.GetHashCode();
		}
		if (MediaBinViewStyle != 0)
		{
			num ^= MediaBinViewStyle.GetHashCode();
		}
		if (MediaBinGridColumnCount != 0)
		{
			num ^= MediaBinGridColumnCount.GetHashCode();
		}
		if (MediaBinTableColumnCount != 0)
		{
			num ^= MediaBinTableColumnCount.GetHashCode();
		}
		if (PresentationTransition.Length != 0)
		{
			num ^= PresentationTransition.GetHashCode();
		}
		if (MediaTransition.Length != 0)
		{
			num ^= MediaTransition.GetHashCode();
		}
		if (AudioShuffle)
		{
			num ^= AudioShuffle.GetHashCode();
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
		if (LibraryOutline != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)LibraryOutline);
		}
		if (MediaOutline != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)MediaOutline);
		}
		if (AudioOutline != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)AudioOutline);
		}
		if (ContinuousPlaylist)
		{
			output.WriteRawTag(32);
			output.WriteBool(ContinuousPlaylist);
		}
		if (MediaBin != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)MediaBin);
		}
		if (PresentationViewStyle != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)PresentationViewStyle);
		}
		if (PresentationGridColumnCount != 0)
		{
			output.WriteRawTag(56);
			output.WriteInt32(PresentationGridColumnCount);
		}
		if (MediaBinViewStyle != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)MediaBinViewStyle);
		}
		if (MediaBinGridColumnCount != 0)
		{
			output.WriteRawTag(72);
			output.WriteInt32(MediaBinGridColumnCount);
		}
		if (MediaBinTableColumnCount != 0)
		{
			output.WriteRawTag(80);
			output.WriteInt32(MediaBinTableColumnCount);
		}
		if (PresentationTransition.Length != 0)
		{
			output.WriteRawTag(90);
			output.WriteString(PresentationTransition);
		}
		if (MediaTransition.Length != 0)
		{
			output.WriteRawTag(98);
			output.WriteString(MediaTransition);
		}
		if (AudioShuffle)
		{
			output.WriteRawTag(104);
			output.WriteBool(AudioShuffle);
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
		if (LibraryOutline != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LibraryOutline);
		}
		if (MediaOutline != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)MediaOutline);
		}
		if (AudioOutline != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AudioOutline);
		}
		if (ContinuousPlaylist)
		{
			num += 2;
		}
		if (MediaBin != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)MediaBin);
		}
		if (PresentationViewStyle != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PresentationViewStyle);
		}
		if (PresentationGridColumnCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PresentationGridColumnCount);
		}
		if (MediaBinViewStyle != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)MediaBinViewStyle);
		}
		if (MediaBinGridColumnCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinGridColumnCount);
		}
		if (MediaBinTableColumnCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaBinTableColumnCount);
		}
		if (PresentationTransition.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PresentationTransition);
		}
		if (MediaTransition.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MediaTransition);
		}
		if (AudioShuffle)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Interface other)
	{
		if (other != null)
		{
			if (other.LibraryOutline != 0)
			{
				LibraryOutline = other.LibraryOutline;
			}
			if (other.MediaOutline != 0)
			{
				MediaOutline = other.MediaOutline;
			}
			if (other.AudioOutline != 0)
			{
				AudioOutline = other.AudioOutline;
			}
			if (other.ContinuousPlaylist)
			{
				ContinuousPlaylist = other.ContinuousPlaylist;
			}
			if (other.MediaBin != 0)
			{
				MediaBin = other.MediaBin;
			}
			if (other.PresentationViewStyle != 0)
			{
				PresentationViewStyle = other.PresentationViewStyle;
			}
			if (other.PresentationGridColumnCount != 0)
			{
				PresentationGridColumnCount = other.PresentationGridColumnCount;
			}
			if (other.MediaBinViewStyle != 0)
			{
				MediaBinViewStyle = other.MediaBinViewStyle;
			}
			if (other.MediaBinGridColumnCount != 0)
			{
				MediaBinGridColumnCount = other.MediaBinGridColumnCount;
			}
			if (other.MediaBinTableColumnCount != 0)
			{
				MediaBinTableColumnCount = other.MediaBinTableColumnCount;
			}
			if (other.PresentationTransition.Length != 0)
			{
				PresentationTransition = other.PresentationTransition;
			}
			if (other.MediaTransition.Length != 0)
			{
				MediaTransition = other.MediaTransition;
			}
			if (other.AudioShuffle)
			{
				AudioShuffle = other.AudioShuffle;
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
				LibraryOutline = (Types.SplitViewState)input.ReadEnum();
				break;
			case 16u:
				MediaOutline = (Types.SplitViewState)input.ReadEnum();
				break;
			case 24u:
				AudioOutline = (Types.SplitViewState)input.ReadEnum();
				break;
			case 32u:
				ContinuousPlaylist = input.ReadBool();
				break;
			case 40u:
				MediaBin = (Types.SplitViewState)input.ReadEnum();
				break;
			case 48u:
				PresentationViewStyle = (Types.PresentationViewStyle)input.ReadEnum();
				break;
			case 56u:
				PresentationGridColumnCount = input.ReadInt32();
				break;
			case 64u:
				MediaBinViewStyle = (Types.MediaBinViewStyle)input.ReadEnum();
				break;
			case 72u:
				MediaBinGridColumnCount = input.ReadInt32();
				break;
			case 80u:
				MediaBinTableColumnCount = input.ReadInt32();
				break;
			case 90u:
				PresentationTransition = input.ReadString();
				break;
			case 98u:
				MediaTransition = input.ReadString();
				break;
			case 104u:
				AudioShuffle = input.ReadBool();
				break;
			}
		}
	}
}
