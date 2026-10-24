using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TriggerOptions : IMessage<TriggerOptions>, IMessage, IEquatable<TriggerOptions>, IDeepCloneable<TriggerOptions>
{
	private static readonly MessageParser<TriggerOptions> _parser = new MessageParser<TriggerOptions>(() => new TriggerOptions());

	private UnknownFieldSet _unknownFields;

	public const int ContentDestinationFieldNumber = 1;

	private Action.Types.ContentDestination contentDestination_;

	public const int SuppressAutoStartVideoFieldNumber = 2;

	private bool suppressAutoStartVideo_;

	public const int SuppressMediaBackgroundFieldNumber = 3;

	private bool suppressMediaBackground_;

	public const int ForceRetriggerFieldNumber = 4;

	private bool forceRetrigger_;

	public const int ResetChordChartFieldNumber = 5;

	private bool resetChordChart_;

	public const int FromPlaylistLibraryFieldNumber = 6;

	private bool fromPlaylistLibrary_;

	public const int FromTimelineFieldNumber = 7;

	private bool fromTimeline_;

	public const int IgnoreAnalyticsFieldNumber = 8;

	private bool ignoreAnalytics_;

	public const int StartPositionFieldNumber = 9;

	private double startPosition_;

	public const int TriggerSourceFieldNumber = 10;

	private TriggerSource triggerSource_;

	public const int NetworkIdentifierFieldNumber = 11;

	private NetworkIdentifier networkIdentifier_;

	public const int RequestClientContextFieldNumber = 12;

	private bool requestClientContext_;

	public const int FollowTimecodeFieldNumber = 13;

	private bool followTimecode_;

	public const int TimecodeOffsetFieldNumber = 14;

	private double timecodeOffset_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TriggerOptions> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action.Types.ContentDestination ContentDestination
	{
		get
		{
			return contentDestination_;
		}
		set
		{
			contentDestination_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SuppressAutoStartVideo
	{
		get
		{
			return suppressAutoStartVideo_;
		}
		set
		{
			suppressAutoStartVideo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SuppressMediaBackground
	{
		get
		{
			return suppressMediaBackground_;
		}
		set
		{
			suppressMediaBackground_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ForceRetrigger
	{
		get
		{
			return forceRetrigger_;
		}
		set
		{
			forceRetrigger_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ResetChordChart
	{
		get
		{
			return resetChordChart_;
		}
		set
		{
			resetChordChart_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FromPlaylistLibrary
	{
		get
		{
			return fromPlaylistLibrary_;
		}
		set
		{
			fromPlaylistLibrary_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FromTimeline
	{
		get
		{
			return fromTimeline_;
		}
		set
		{
			fromTimeline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IgnoreAnalytics
	{
		get
		{
			return ignoreAnalytics_;
		}
		set
		{
			ignoreAnalytics_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double StartPosition
	{
		get
		{
			return startPosition_;
		}
		set
		{
			startPosition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerSource TriggerSource
	{
		get
		{
			return triggerSource_;
		}
		set
		{
			triggerSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkIdentifier NetworkIdentifier
	{
		get
		{
			return networkIdentifier_;
		}
		set
		{
			networkIdentifier_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RequestClientContext
	{
		get
		{
			return requestClientContext_;
		}
		set
		{
			requestClientContext_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FollowTimecode
	{
		get
		{
			return followTimecode_;
		}
		set
		{
			followTimecode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double TimecodeOffset
	{
		get
		{
			return timecodeOffset_;
		}
		set
		{
			timecodeOffset_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerOptions()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerOptions(TriggerOptions other)
		: this()
	{
		contentDestination_ = other.contentDestination_;
		suppressAutoStartVideo_ = other.suppressAutoStartVideo_;
		suppressMediaBackground_ = other.suppressMediaBackground_;
		forceRetrigger_ = other.forceRetrigger_;
		resetChordChart_ = other.resetChordChart_;
		fromPlaylistLibrary_ = other.fromPlaylistLibrary_;
		fromTimeline_ = other.fromTimeline_;
		ignoreAnalytics_ = other.ignoreAnalytics_;
		startPosition_ = other.startPosition_;
		triggerSource_ = ((other.triggerSource_ != null) ? other.triggerSource_.Clone() : null);
		networkIdentifier_ = ((other.networkIdentifier_ != null) ? other.networkIdentifier_.Clone() : null);
		requestClientContext_ = other.requestClientContext_;
		followTimecode_ = other.followTimecode_;
		timecodeOffset_ = other.timecodeOffset_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerOptions Clone()
	{
		return new TriggerOptions(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TriggerOptions);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TriggerOptions other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ContentDestination != other.ContentDestination)
		{
			return false;
		}
		if (SuppressAutoStartVideo != other.SuppressAutoStartVideo)
		{
			return false;
		}
		if (SuppressMediaBackground != other.SuppressMediaBackground)
		{
			return false;
		}
		if (ForceRetrigger != other.ForceRetrigger)
		{
			return false;
		}
		if (ResetChordChart != other.ResetChordChart)
		{
			return false;
		}
		if (FromPlaylistLibrary != other.FromPlaylistLibrary)
		{
			return false;
		}
		if (FromTimeline != other.FromTimeline)
		{
			return false;
		}
		if (IgnoreAnalytics != other.IgnoreAnalytics)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(StartPosition, other.StartPosition))
		{
			return false;
		}
		if (!object.Equals(TriggerSource, other.TriggerSource))
		{
			return false;
		}
		if (!object.Equals(NetworkIdentifier, other.NetworkIdentifier))
		{
			return false;
		}
		if (RequestClientContext != other.RequestClientContext)
		{
			return false;
		}
		if (FollowTimecode != other.FollowTimecode)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimecodeOffset, other.TimecodeOffset))
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
		if (ContentDestination != 0)
		{
			num ^= ContentDestination.GetHashCode();
		}
		if (SuppressAutoStartVideo)
		{
			num ^= SuppressAutoStartVideo.GetHashCode();
		}
		if (SuppressMediaBackground)
		{
			num ^= SuppressMediaBackground.GetHashCode();
		}
		if (ForceRetrigger)
		{
			num ^= ForceRetrigger.GetHashCode();
		}
		if (ResetChordChart)
		{
			num ^= ResetChordChart.GetHashCode();
		}
		if (FromPlaylistLibrary)
		{
			num ^= FromPlaylistLibrary.GetHashCode();
		}
		if (FromTimeline)
		{
			num ^= FromTimeline.GetHashCode();
		}
		if (IgnoreAnalytics)
		{
			num ^= IgnoreAnalytics.GetHashCode();
		}
		if (StartPosition != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(StartPosition);
		}
		if (triggerSource_ != null)
		{
			num ^= TriggerSource.GetHashCode();
		}
		if (networkIdentifier_ != null)
		{
			num ^= NetworkIdentifier.GetHashCode();
		}
		if (RequestClientContext)
		{
			num ^= RequestClientContext.GetHashCode();
		}
		if (FollowTimecode)
		{
			num ^= FollowTimecode.GetHashCode();
		}
		if (TimecodeOffset != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimecodeOffset);
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
		if (ContentDestination != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ContentDestination);
		}
		if (SuppressAutoStartVideo)
		{
			output.WriteRawTag(16);
			output.WriteBool(SuppressAutoStartVideo);
		}
		if (SuppressMediaBackground)
		{
			output.WriteRawTag(24);
			output.WriteBool(SuppressMediaBackground);
		}
		if (ForceRetrigger)
		{
			output.WriteRawTag(32);
			output.WriteBool(ForceRetrigger);
		}
		if (ResetChordChart)
		{
			output.WriteRawTag(40);
			output.WriteBool(ResetChordChart);
		}
		if (FromPlaylistLibrary)
		{
			output.WriteRawTag(48);
			output.WriteBool(FromPlaylistLibrary);
		}
		if (FromTimeline)
		{
			output.WriteRawTag(56);
			output.WriteBool(FromTimeline);
		}
		if (IgnoreAnalytics)
		{
			output.WriteRawTag(64);
			output.WriteBool(IgnoreAnalytics);
		}
		if (StartPosition != 0.0)
		{
			output.WriteRawTag(73);
			output.WriteDouble(StartPosition);
		}
		if (triggerSource_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(TriggerSource);
		}
		if (networkIdentifier_ != null)
		{
			output.WriteRawTag(90);
			output.WriteMessage(NetworkIdentifier);
		}
		if (RequestClientContext)
		{
			output.WriteRawTag(96);
			output.WriteBool(RequestClientContext);
		}
		if (FollowTimecode)
		{
			output.WriteRawTag(104);
			output.WriteBool(FollowTimecode);
		}
		if (TimecodeOffset != 0.0)
		{
			output.WriteRawTag(113);
			output.WriteDouble(TimecodeOffset);
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
		if (ContentDestination != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
		}
		if (SuppressAutoStartVideo)
		{
			num += 2;
		}
		if (SuppressMediaBackground)
		{
			num += 2;
		}
		if (ForceRetrigger)
		{
			num += 2;
		}
		if (ResetChordChart)
		{
			num += 2;
		}
		if (FromPlaylistLibrary)
		{
			num += 2;
		}
		if (FromTimeline)
		{
			num += 2;
		}
		if (IgnoreAnalytics)
		{
			num += 2;
		}
		if (StartPosition != 0.0)
		{
			num += 9;
		}
		if (triggerSource_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerSource);
		}
		if (networkIdentifier_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(NetworkIdentifier);
		}
		if (RequestClientContext)
		{
			num += 2;
		}
		if (FollowTimecode)
		{
			num += 2;
		}
		if (TimecodeOffset != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TriggerOptions other)
	{
		if (other == null)
		{
			return;
		}
		if (other.ContentDestination != 0)
		{
			ContentDestination = other.ContentDestination;
		}
		if (other.SuppressAutoStartVideo)
		{
			SuppressAutoStartVideo = other.SuppressAutoStartVideo;
		}
		if (other.SuppressMediaBackground)
		{
			SuppressMediaBackground = other.SuppressMediaBackground;
		}
		if (other.ForceRetrigger)
		{
			ForceRetrigger = other.ForceRetrigger;
		}
		if (other.ResetChordChart)
		{
			ResetChordChart = other.ResetChordChart;
		}
		if (other.FromPlaylistLibrary)
		{
			FromPlaylistLibrary = other.FromPlaylistLibrary;
		}
		if (other.FromTimeline)
		{
			FromTimeline = other.FromTimeline;
		}
		if (other.IgnoreAnalytics)
		{
			IgnoreAnalytics = other.IgnoreAnalytics;
		}
		if (other.StartPosition != 0.0)
		{
			StartPosition = other.StartPosition;
		}
		if (other.triggerSource_ != null)
		{
			if (triggerSource_ == null)
			{
				TriggerSource = new TriggerSource();
			}
			TriggerSource.MergeFrom(other.TriggerSource);
		}
		if (other.networkIdentifier_ != null)
		{
			if (networkIdentifier_ == null)
			{
				NetworkIdentifier = new NetworkIdentifier();
			}
			NetworkIdentifier.MergeFrom(other.NetworkIdentifier);
		}
		if (other.RequestClientContext)
		{
			RequestClientContext = other.RequestClientContext;
		}
		if (other.FollowTimecode)
		{
			FollowTimecode = other.FollowTimecode;
		}
		if (other.TimecodeOffset != 0.0)
		{
			TimecodeOffset = other.TimecodeOffset;
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
			case 8u:
				ContentDestination = (Action.Types.ContentDestination)input.ReadEnum();
				break;
			case 16u:
				SuppressAutoStartVideo = input.ReadBool();
				break;
			case 24u:
				SuppressMediaBackground = input.ReadBool();
				break;
			case 32u:
				ForceRetrigger = input.ReadBool();
				break;
			case 40u:
				ResetChordChart = input.ReadBool();
				break;
			case 48u:
				FromPlaylistLibrary = input.ReadBool();
				break;
			case 56u:
				FromTimeline = input.ReadBool();
				break;
			case 64u:
				IgnoreAnalytics = input.ReadBool();
				break;
			case 73u:
				StartPosition = input.ReadDouble();
				break;
			case 82u:
				if (triggerSource_ == null)
				{
					TriggerSource = new TriggerSource();
				}
				input.ReadMessage(TriggerSource);
				break;
			case 90u:
				if (networkIdentifier_ == null)
				{
					NetworkIdentifier = new NetworkIdentifier();
				}
				input.ReadMessage(NetworkIdentifier);
				break;
			case 96u:
				RequestClientContext = input.ReadBool();
				break;
			case 104u:
				FollowTimecode = input.ReadBool();
				break;
			case 113u:
				TimecodeOffset = input.ReadDouble();
				break;
			}
		}
	}
}
