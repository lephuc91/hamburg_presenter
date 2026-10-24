using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Transport : IMessage<Transport>, IMessage, IEquatable<Transport>, IDeepCloneable<Transport>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum DurationRange
		{
			[OriginalName("UNDER_10S")]
			Under10S,
			[OriginalName("_10S_TO_30S")]
			_10STo30S,
			[OriginalName("_30S_TO_60S")]
			_30STo60S,
			[OriginalName("_1M_TO_5M")]
			_1MTo5M,
			[OriginalName("_5M_TO_10M")]
			_5MTo10M,
			[OriginalName("_10M_TO_30M")]
			_10MTo30M,
			[OriginalName("_30M_TO_60M")]
			_30MTo60M,
			[OriginalName("_1H_TO_2H")]
			_1HTo2H,
			[OriginalName("OVER_2H")]
			Over2H
		}
	}

	private static readonly MessageParser<Transport> _parser = new MessageParser<Transport>(() => new Transport());

	private UnknownFieldSet _unknownFields;

	public const int SourceDurationRangeFieldNumber = 1;

	private Types.DurationRange sourceDurationRange_;

	public const int HasAudioRampInFieldNumber = 2;

	private bool hasAudioRampIn_;

	public const int HasAudioRampOutFieldNumber = 3;

	private bool hasAudioRampOut_;

	public const int HasInPointFieldNumber = 4;

	private bool hasInPoint_;

	public const int HasOutPointFieldNumber = 5;

	private bool hasOutPoint_;

	public const int PlayRateFieldNumber = 6;

	private double playRate_;

	public const int PlaybackMarkerCountFieldNumber = 7;

	private uint playbackMarkerCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Transport> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DurationRange SourceDurationRange
	{
		get
		{
			return sourceDurationRange_;
		}
		set
		{
			sourceDurationRange_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasAudioRampIn
	{
		get
		{
			return hasAudioRampIn_;
		}
		set
		{
			hasAudioRampIn_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasAudioRampOut
	{
		get
		{
			return hasAudioRampOut_;
		}
		set
		{
			hasAudioRampOut_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasInPoint
	{
		get
		{
			return hasInPoint_;
		}
		set
		{
			hasInPoint_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasOutPoint
	{
		get
		{
			return hasOutPoint_;
		}
		set
		{
			hasOutPoint_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double PlayRate
	{
		get
		{
			return playRate_;
		}
		set
		{
			playRate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint PlaybackMarkerCount
	{
		get
		{
			return playbackMarkerCount_;
		}
		set
		{
			playbackMarkerCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transport()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transport(Transport other)
		: this()
	{
		sourceDurationRange_ = other.sourceDurationRange_;
		hasAudioRampIn_ = other.hasAudioRampIn_;
		hasAudioRampOut_ = other.hasAudioRampOut_;
		hasInPoint_ = other.hasInPoint_;
		hasOutPoint_ = other.hasOutPoint_;
		playRate_ = other.playRate_;
		playbackMarkerCount_ = other.playbackMarkerCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transport Clone()
	{
		return new Transport(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Transport);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Transport other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (SourceDurationRange != other.SourceDurationRange)
		{
			return false;
		}
		if (HasAudioRampIn != other.HasAudioRampIn)
		{
			return false;
		}
		if (HasAudioRampOut != other.HasAudioRampOut)
		{
			return false;
		}
		if (HasInPoint != other.HasInPoint)
		{
			return false;
		}
		if (HasOutPoint != other.HasOutPoint)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PlayRate, other.PlayRate))
		{
			return false;
		}
		if (PlaybackMarkerCount != other.PlaybackMarkerCount)
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
		if (SourceDurationRange != 0)
		{
			num ^= SourceDurationRange.GetHashCode();
		}
		if (HasAudioRampIn)
		{
			num ^= HasAudioRampIn.GetHashCode();
		}
		if (HasAudioRampOut)
		{
			num ^= HasAudioRampOut.GetHashCode();
		}
		if (HasInPoint)
		{
			num ^= HasInPoint.GetHashCode();
		}
		if (HasOutPoint)
		{
			num ^= HasOutPoint.GetHashCode();
		}
		if (PlayRate != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PlayRate);
		}
		if (PlaybackMarkerCount != 0)
		{
			num ^= PlaybackMarkerCount.GetHashCode();
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
		if (SourceDurationRange != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)SourceDurationRange);
		}
		if (HasAudioRampIn)
		{
			output.WriteRawTag(16);
			output.WriteBool(HasAudioRampIn);
		}
		if (HasAudioRampOut)
		{
			output.WriteRawTag(24);
			output.WriteBool(HasAudioRampOut);
		}
		if (HasInPoint)
		{
			output.WriteRawTag(32);
			output.WriteBool(HasInPoint);
		}
		if (HasOutPoint)
		{
			output.WriteRawTag(40);
			output.WriteBool(HasOutPoint);
		}
		if (PlayRate != 0.0)
		{
			output.WriteRawTag(49);
			output.WriteDouble(PlayRate);
		}
		if (PlaybackMarkerCount != 0)
		{
			output.WriteRawTag(56);
			output.WriteUInt32(PlaybackMarkerCount);
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
		if (SourceDurationRange != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceDurationRange);
		}
		if (HasAudioRampIn)
		{
			num += 2;
		}
		if (HasAudioRampOut)
		{
			num += 2;
		}
		if (HasInPoint)
		{
			num += 2;
		}
		if (HasOutPoint)
		{
			num += 2;
		}
		if (PlayRate != 0.0)
		{
			num += 9;
		}
		if (PlaybackMarkerCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(PlaybackMarkerCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Transport other)
	{
		if (other != null)
		{
			if (other.SourceDurationRange != 0)
			{
				SourceDurationRange = other.SourceDurationRange;
			}
			if (other.HasAudioRampIn)
			{
				HasAudioRampIn = other.HasAudioRampIn;
			}
			if (other.HasAudioRampOut)
			{
				HasAudioRampOut = other.HasAudioRampOut;
			}
			if (other.HasInPoint)
			{
				HasInPoint = other.HasInPoint;
			}
			if (other.HasOutPoint)
			{
				HasOutPoint = other.HasOutPoint;
			}
			if (other.PlayRate != 0.0)
			{
				PlayRate = other.PlayRate;
			}
			if (other.PlaybackMarkerCount != 0)
			{
				PlaybackMarkerCount = other.PlaybackMarkerCount;
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
				SourceDurationRange = (Types.DurationRange)input.ReadEnum();
				break;
			case 16u:
				HasAudioRampIn = input.ReadBool();
				break;
			case 24u:
				HasAudioRampOut = input.ReadBool();
				break;
			case 32u:
				HasInPoint = input.ReadBool();
				break;
			case 40u:
				HasOutPoint = input.ReadBool();
				break;
			case 49u:
				PlayRate = input.ReadDouble();
				break;
			case 56u:
				PlaybackMarkerCount = input.ReadUInt32();
				break;
			}
		}
	}
}
