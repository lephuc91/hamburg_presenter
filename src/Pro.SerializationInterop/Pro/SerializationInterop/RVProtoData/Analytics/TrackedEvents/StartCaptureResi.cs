using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class StartCaptureResi : IMessage<StartCaptureResi>, IMessage, IEquatable<StartCaptureResi>, IDeepCloneable<StartCaptureResi>
{
	private static readonly MessageParser<StartCaptureResi> _parser = new MessageParser<StartCaptureResi>(() => new StartCaptureResi());

	private UnknownFieldSet _unknownFields;

	public const int CodecFieldNumber = 1;

	private Codec codec_;

	public const int ResolutionWidthFieldNumber = 2;

	private uint resolutionWidth_;

	public const int ResolutionHeightFieldNumber = 3;

	private uint resolutionHeight_;

	public const int FrameRateFieldNumber = 4;

	private FrameRate frameRate_;

	public const int StreamStartedFieldNumber = 5;

	private bool streamStarted_;

	public const int VideoBitrateFieldNumber = 6;

	private uint videoBitrate_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<StartCaptureResi> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[21];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Codec Codec
	{
		get
		{
			return codec_;
		}
		set
		{
			codec_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint ResolutionWidth
	{
		get
		{
			return resolutionWidth_;
		}
		set
		{
			resolutionWidth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint ResolutionHeight
	{
		get
		{
			return resolutionHeight_;
		}
		set
		{
			resolutionHeight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FrameRate FrameRate
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
	public bool StreamStarted
	{
		get
		{
			return streamStarted_;
		}
		set
		{
			streamStarted_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint VideoBitrate
	{
		get
		{
			return videoBitrate_;
		}
		set
		{
			videoBitrate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureResi()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureResi(StartCaptureResi other)
		: this()
	{
		codec_ = other.codec_;
		resolutionWidth_ = other.resolutionWidth_;
		resolutionHeight_ = other.resolutionHeight_;
		frameRate_ = other.frameRate_;
		streamStarted_ = other.streamStarted_;
		videoBitrate_ = other.videoBitrate_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureResi Clone()
	{
		return new StartCaptureResi(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as StartCaptureResi);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(StartCaptureResi other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Codec != other.Codec)
		{
			return false;
		}
		if (ResolutionWidth != other.ResolutionWidth)
		{
			return false;
		}
		if (ResolutionHeight != other.ResolutionHeight)
		{
			return false;
		}
		if (FrameRate != other.FrameRate)
		{
			return false;
		}
		if (StreamStarted != other.StreamStarted)
		{
			return false;
		}
		if (VideoBitrate != other.VideoBitrate)
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
		if (Codec != 0)
		{
			num ^= Codec.GetHashCode();
		}
		if (ResolutionWidth != 0)
		{
			num ^= ResolutionWidth.GetHashCode();
		}
		if (ResolutionHeight != 0)
		{
			num ^= ResolutionHeight.GetHashCode();
		}
		if (FrameRate != 0)
		{
			num ^= FrameRate.GetHashCode();
		}
		if (StreamStarted)
		{
			num ^= StreamStarted.GetHashCode();
		}
		if (VideoBitrate != 0)
		{
			num ^= VideoBitrate.GetHashCode();
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
		if (Codec != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Codec);
		}
		if (ResolutionWidth != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(ResolutionWidth);
		}
		if (ResolutionHeight != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(ResolutionHeight);
		}
		if (FrameRate != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)FrameRate);
		}
		if (StreamStarted)
		{
			output.WriteRawTag(40);
			output.WriteBool(StreamStarted);
		}
		if (VideoBitrate != 0)
		{
			output.WriteRawTag(48);
			output.WriteUInt32(VideoBitrate);
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
		if (Codec != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Codec);
		}
		if (ResolutionWidth != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(ResolutionWidth);
		}
		if (ResolutionHeight != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(ResolutionHeight);
		}
		if (FrameRate != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FrameRate);
		}
		if (StreamStarted)
		{
			num += 2;
		}
		if (VideoBitrate != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(VideoBitrate);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(StartCaptureResi other)
	{
		if (other != null)
		{
			if (other.Codec != 0)
			{
				Codec = other.Codec;
			}
			if (other.ResolutionWidth != 0)
			{
				ResolutionWidth = other.ResolutionWidth;
			}
			if (other.ResolutionHeight != 0)
			{
				ResolutionHeight = other.ResolutionHeight;
			}
			if (other.FrameRate != 0)
			{
				FrameRate = other.FrameRate;
			}
			if (other.StreamStarted)
			{
				StreamStarted = other.StreamStarted;
			}
			if (other.VideoBitrate != 0)
			{
				VideoBitrate = other.VideoBitrate;
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
				Codec = (Codec)input.ReadEnum();
				break;
			case 16u:
				ResolutionWidth = input.ReadUInt32();
				break;
			case 24u:
				ResolutionHeight = input.ReadUInt32();
				break;
			case 32u:
				FrameRate = (FrameRate)input.ReadEnum();
				break;
			case 40u:
				StreamStarted = input.ReadBool();
				break;
			case 48u:
				VideoBitrate = input.ReadUInt32();
				break;
			}
		}
	}
}
