using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VideoInput : IMessage<VideoInput>, IMessage, IEquatable<VideoInput>, IDeepCloneable<VideoInput>
{
	private static readonly MessageParser<VideoInput> _parser = new MessageParser<VideoInput>(() => new VideoInput());

	private UnknownFieldSet _unknownFields;

	public const int VisualMediaFieldNumber = 1;

	private VisualMedia visualMedia_;

	public const int FrameRateFieldNumber = 2;

	private double frameRate_;

	public const int AudioChannelCountFieldNumber = 3;

	private uint audioChannelCount_;

	public const int SourceTypeFieldNumber = 4;

	private SourceType sourceType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VideoInput> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[6];

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
	public VideoInput()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInput(VideoInput other)
		: this()
	{
		visualMedia_ = ((other.visualMedia_ != null) ? other.visualMedia_.Clone() : null);
		frameRate_ = other.frameRate_;
		audioChannelCount_ = other.audioChannelCount_;
		sourceType_ = other.sourceType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInput Clone()
	{
		return new VideoInput(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VideoInput);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VideoInput other)
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
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FrameRate, other.FrameRate))
		{
			return false;
		}
		if (AudioChannelCount != other.AudioChannelCount)
		{
			return false;
		}
		if (SourceType != other.SourceType)
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
		if (FrameRate != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FrameRate);
		}
		if (AudioChannelCount != 0)
		{
			num ^= AudioChannelCount.GetHashCode();
		}
		if (SourceType != 0)
		{
			num ^= SourceType.GetHashCode();
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
			output.WriteRawTag(10);
			output.WriteMessage(VisualMedia);
		}
		if (FrameRate != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(FrameRate);
		}
		if (AudioChannelCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(AudioChannelCount);
		}
		if (SourceType != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)SourceType);
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
		if (FrameRate != 0.0)
		{
			num += 9;
		}
		if (AudioChannelCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(AudioChannelCount);
		}
		if (SourceType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(VideoInput other)
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
		if (other.FrameRate != 0.0)
		{
			FrameRate = other.FrameRate;
		}
		if (other.AudioChannelCount != 0)
		{
			AudioChannelCount = other.AudioChannelCount;
		}
		if (other.SourceType != 0)
		{
			SourceType = other.SourceType;
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
				if (visualMedia_ == null)
				{
					VisualMedia = new VisualMedia();
				}
				input.ReadMessage(VisualMedia);
				break;
			case 17u:
				FrameRate = input.ReadDouble();
				break;
			case 24u:
				AudioChannelCount = input.ReadUInt32();
				break;
			case 32u:
				SourceType = (SourceType)input.ReadEnum();
				break;
			}
		}
	}
}
