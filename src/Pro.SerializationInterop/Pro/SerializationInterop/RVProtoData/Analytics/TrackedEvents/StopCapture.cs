using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class StopCapture : IMessage<StopCapture>, IMessage, IEquatable<StopCapture>, IDeepCloneable<StopCapture>
{
	private static readonly MessageParser<StopCapture> _parser = new MessageParser<StopCapture>(() => new StopCapture());

	private UnknownFieldSet _unknownFields;

	public const int DurationFieldNumber = 1;

	private double duration_;

	public const int DroppedFramesFieldNumber = 2;

	private int droppedFrames_;

	public const int PercentDroppedFramesFieldNumber = 3;

	private double percentDroppedFrames_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<StopCapture> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[22];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Duration
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
	public int DroppedFrames
	{
		get
		{
			return droppedFrames_;
		}
		set
		{
			droppedFrames_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double PercentDroppedFrames
	{
		get
		{
			return percentDroppedFrames_;
		}
		set
		{
			percentDroppedFrames_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StopCapture()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StopCapture(StopCapture other)
		: this()
	{
		duration_ = other.duration_;
		droppedFrames_ = other.droppedFrames_;
		percentDroppedFrames_ = other.percentDroppedFrames_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StopCapture Clone()
	{
		return new StopCapture(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as StopCapture);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(StopCapture other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
		{
			return false;
		}
		if (DroppedFrames != other.DroppedFrames)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PercentDroppedFrames, other.PercentDroppedFrames))
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
		if (Duration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
		}
		if (DroppedFrames != 0)
		{
			num ^= DroppedFrames.GetHashCode();
		}
		if (PercentDroppedFrames != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PercentDroppedFrames);
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
		if (Duration != 0.0)
		{
			output.WriteRawTag(9);
			output.WriteDouble(Duration);
		}
		if (DroppedFrames != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(DroppedFrames);
		}
		if (PercentDroppedFrames != 0.0)
		{
			output.WriteRawTag(25);
			output.WriteDouble(PercentDroppedFrames);
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
		if (Duration != 0.0)
		{
			num += 9;
		}
		if (DroppedFrames != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(DroppedFrames);
		}
		if (PercentDroppedFrames != 0.0)
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
	public void MergeFrom(StopCapture other)
	{
		if (other != null)
		{
			if (other.Duration != 0.0)
			{
				Duration = other.Duration;
			}
			if (other.DroppedFrames != 0)
			{
				DroppedFrames = other.DroppedFrames;
			}
			if (other.PercentDroppedFrames != 0.0)
			{
				PercentDroppedFrames = other.PercentDroppedFrames;
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
			case 9u:
				Duration = input.ReadDouble();
				break;
			case 16u:
				DroppedFrames = input.ReadInt32();
				break;
			case 25u:
				PercentDroppedFrames = input.ReadDouble();
				break;
			}
		}
	}
}
