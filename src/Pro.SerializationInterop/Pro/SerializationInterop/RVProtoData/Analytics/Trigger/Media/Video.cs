using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Video : IMessage<Video>, IMessage, IEquatable<Video>, IDeepCloneable<Video>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum PlaybackBehavior
		{
			[OriginalName("STOP")]
			Stop,
			[OriginalName("LOOP")]
			Loop,
			[OriginalName("LOOP_FOR_PLAY_COUNT")]
			LoopForPlayCount,
			[OriginalName("LOOP_FOR_TIME")]
			LoopForTime
		}

		public enum HardwareDecodingType
		{
			[OriginalName("AUTOMATIC")]
			Automatic,
			[OriginalName("DISABLED")]
			Disabled
		}
	}

	private static readonly MessageParser<Video> _parser = new MessageParser<Video>(() => new Video());

	private UnknownFieldSet _unknownFields;

	public const int VisualMediaFieldNumber = 7;

	private VisualMedia visualMedia_;

	public const int PlaybackBehaviorFieldNumber = 8;

	private Types.PlaybackBehavior playbackBehavior_;

	public const int CompletionTargetFieldNumber = 9;

	private CompletionTarget completionTarget_;

	public const int SoftLoopEnabledFieldNumber = 10;

	private bool softLoopEnabled_;

	public const int SoftLoopDurationFieldNumber = 11;

	private double softLoopDuration_;

	public const int FrameRateFieldNumber = 12;

	private double frameRate_;

	public const int AudioChannelCountFieldNumber = 13;

	private uint audioChannelCount_;

	public const int TransportFieldNumber = 14;

	private Transport transport_;

	public const int SourceTypeFieldNumber = 15;

	private SourceType sourceType_;

	public const int HardwareDecodingFieldNumber = 16;

	private Types.HardwareDecodingType hardwareDecoding_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Video> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VisualMedia VisualMedia
	{
		get
		{
			return visualMedia_;
		}
		set
		{
			visualMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaybackBehavior PlaybackBehavior
	{
		get
		{
			return playbackBehavior_;
		}
		set
		{
			playbackBehavior_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CompletionTarget CompletionTarget
	{
		get
		{
			return completionTarget_;
		}
		set
		{
			completionTarget_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SoftLoopEnabled
	{
		get
		{
			return softLoopEnabled_;
		}
		set
		{
			softLoopEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double SoftLoopDuration
	{
		get
		{
			return softLoopDuration_;
		}
		set
		{
			softLoopDuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double FrameRate
	{
		get
		{
			return frameRate_;
		}
		set
		{
			frameRate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint AudioChannelCount
	{
		get
		{
			return audioChannelCount_;
		}
		set
		{
			audioChannelCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transport Transport
	{
		get
		{
			return transport_;
		}
		set
		{
			transport_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SourceType SourceType
	{
		get
		{
			return sourceType_;
		}
		set
		{
			sourceType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.HardwareDecodingType HardwareDecoding
	{
		get
		{
			return hardwareDecoding_;
		}
		set
		{
			hardwareDecoding_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Video()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Video(Video other)
		: this()
	{
		visualMedia_ = ((other.visualMedia_ != null) ? other.visualMedia_.Clone() : null);
		playbackBehavior_ = other.playbackBehavior_;
		completionTarget_ = other.completionTarget_;
		softLoopEnabled_ = other.softLoopEnabled_;
		softLoopDuration_ = other.softLoopDuration_;
		frameRate_ = other.frameRate_;
		audioChannelCount_ = other.audioChannelCount_;
		transport_ = ((other.transport_ != null) ? other.transport_.Clone() : null);
		sourceType_ = other.sourceType_;
		hardwareDecoding_ = other.hardwareDecoding_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Video Clone()
	{
		return new Video(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Video);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Video other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(VisualMedia, other.VisualMedia))
		{
			return false;
		}
		if (PlaybackBehavior != other.PlaybackBehavior)
		{
			return false;
		}
		if (CompletionTarget != other.CompletionTarget)
		{
			return false;
		}
		if (SoftLoopEnabled != other.SoftLoopEnabled)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SoftLoopDuration, other.SoftLoopDuration))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FrameRate, other.FrameRate))
		{
			return false;
		}
		if (AudioChannelCount != other.AudioChannelCount)
		{
			return false;
		}
		if (!object.Equals(Transport, other.Transport))
		{
			return false;
		}
		if (SourceType != other.SourceType)
		{
			return false;
		}
		if (HardwareDecoding != other.HardwareDecoding)
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
		if (visualMedia_ != null)
		{
			num ^= VisualMedia.GetHashCode();
		}
		if (PlaybackBehavior != 0)
		{
			num ^= PlaybackBehavior.GetHashCode();
		}
		if (CompletionTarget != 0)
		{
			num ^= CompletionTarget.GetHashCode();
		}
		if (SoftLoopEnabled)
		{
			num ^= SoftLoopEnabled.GetHashCode();
		}
		if (SoftLoopDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SoftLoopDuration);
		}
		if (FrameRate != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FrameRate);
		}
		if (AudioChannelCount != 0)
		{
			num ^= AudioChannelCount.GetHashCode();
		}
		if (transport_ != null)
		{
			num ^= Transport.GetHashCode();
		}
		if (SourceType != 0)
		{
			num ^= SourceType.GetHashCode();
		}
		if (HardwareDecoding != 0)
		{
			num ^= HardwareDecoding.GetHashCode();
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
		if (visualMedia_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(VisualMedia);
		}
		if (PlaybackBehavior != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)PlaybackBehavior);
		}
		if (CompletionTarget != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)CompletionTarget);
		}
		if (SoftLoopEnabled)
		{
			output.WriteRawTag(80);
			output.WriteBool(SoftLoopEnabled);
		}
		if (SoftLoopDuration != 0.0)
		{
			output.WriteRawTag(89);
			output.WriteDouble(SoftLoopDuration);
		}
		if (FrameRate != 0.0)
		{
			output.WriteRawTag(97);
			output.WriteDouble(FrameRate);
		}
		if (AudioChannelCount != 0)
		{
			output.WriteRawTag(104);
			output.WriteUInt32(AudioChannelCount);
		}
		if (transport_ != null)
		{
			output.WriteRawTag(114);
			output.WriteMessage(Transport);
		}
		if (SourceType != 0)
		{
			output.WriteRawTag(120);
			output.WriteEnum((int)SourceType);
		}
		if (HardwareDecoding != 0)
		{
			output.WriteRawTag(128, 1);
			output.WriteEnum((int)HardwareDecoding);
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
		if (visualMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VisualMedia);
		}
		if (PlaybackBehavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
		}
		if (CompletionTarget != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)CompletionTarget);
		}
		if (SoftLoopEnabled)
		{
			num += 2;
		}
		if (SoftLoopDuration != 0.0)
		{
			num += 9;
		}
		if (FrameRate != 0.0)
		{
			num += 9;
		}
		if (AudioChannelCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(AudioChannelCount);
		}
		if (transport_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transport);
		}
		if (SourceType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceType);
		}
		if (HardwareDecoding != 0)
		{
			num += 2 + CodedOutputStream.ComputeEnumSize((int)HardwareDecoding);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Video other)
	{
		if (other == null)
		{
			return;
		}
		if (other.visualMedia_ != null)
		{
			if (visualMedia_ == null)
			{
				VisualMedia = new VisualMedia();
			}
			VisualMedia.MergeFrom(other.VisualMedia);
		}
		if (other.PlaybackBehavior != 0)
		{
			PlaybackBehavior = other.PlaybackBehavior;
		}
		if (other.CompletionTarget != 0)
		{
			CompletionTarget = other.CompletionTarget;
		}
		if (other.SoftLoopEnabled)
		{
			SoftLoopEnabled = other.SoftLoopEnabled;
		}
		if (other.SoftLoopDuration != 0.0)
		{
			SoftLoopDuration = other.SoftLoopDuration;
		}
		if (other.FrameRate != 0.0)
		{
			FrameRate = other.FrameRate;
		}
		if (other.AudioChannelCount != 0)
		{
			AudioChannelCount = other.AudioChannelCount;
		}
		if (other.transport_ != null)
		{
			if (transport_ == null)
			{
				Transport = new Transport();
			}
			Transport.MergeFrom(other.Transport);
		}
		if (other.SourceType != 0)
		{
			SourceType = other.SourceType;
		}
		if (other.HardwareDecoding != 0)
		{
			HardwareDecoding = other.HardwareDecoding;
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
			case 58u:
				if (visualMedia_ == null)
				{
					VisualMedia = new VisualMedia();
				}
				input.ReadMessage(VisualMedia);
				break;
			case 64u:
				PlaybackBehavior = (Types.PlaybackBehavior)input.ReadEnum();
				break;
			case 72u:
				CompletionTarget = (CompletionTarget)input.ReadEnum();
				break;
			case 80u:
				SoftLoopEnabled = input.ReadBool();
				break;
			case 89u:
				SoftLoopDuration = input.ReadDouble();
				break;
			case 97u:
				FrameRate = input.ReadDouble();
				break;
			case 104u:
				AudioChannelCount = input.ReadUInt32();
				break;
			case 114u:
				if (transport_ == null)
				{
					Transport = new Transport();
				}
				input.ReadMessage(Transport);
				break;
			case 120u:
				SourceType = (SourceType)input.ReadEnum();
				break;
			case 128u:
				HardwareDecoding = (Types.HardwareDecodingType)input.ReadEnum();
				break;
			}
		}
	}
}
