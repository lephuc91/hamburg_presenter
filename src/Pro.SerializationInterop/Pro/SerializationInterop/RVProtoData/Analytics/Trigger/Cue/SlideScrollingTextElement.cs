using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideScrollingTextElement : IMessage<SlideScrollingTextElement>, IMessage, IEquatable<SlideScrollingTextElement>, IDeepCloneable<SlideScrollingTextElement>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Direction
		{
			[OriginalName("DIRECTION_UNKNOWN")]
			Unknown,
			[OriginalName("LEFT")]
			Left,
			[OriginalName("RIGHT")]
			Right,
			[OriginalName("UP")]
			Up,
			[OriginalName("DOWN")]
			Down
		}

		public enum StartPosition
		{
			[OriginalName("START_POSITION_UNKNOWN")]
			Unknown,
			[OriginalName("AUTOMATIC")]
			Automatic,
			[OriginalName("OFF_SCREEN")]
			OffScreen
		}

		public enum Speed
		{
			[OriginalName("SPEED_UNKNOWN")]
			Unknown,
			[OriginalName("VERY_SLOW")]
			VerySlow,
			[OriginalName("SLOW")]
			Slow,
			[OriginalName("MEDIUM")]
			Medium,
			[OriginalName("FAST")]
			Fast,
			[OriginalName("VERY_FAST")]
			VeryFast
		}
	}

	private static readonly MessageParser<SlideScrollingTextElement> _parser = new MessageParser<SlideScrollingTextElement>(() => new SlideScrollingTextElement());

	private UnknownFieldSet _unknownFields;

	public const int DirectionFieldNumber = 1;

	private Types.Direction direction_;

	public const int StartPositionFieldNumber = 2;

	private Types.StartPosition startPosition_;

	public const int IsRepeatEnabledFieldNumber = 3;

	private bool isRepeatEnabled_;

	public const int SpeedFieldNumber = 4;

	private Types.Speed speed_;

	public const int DestinationLayerFieldNumber = 5;

	private DestinationLayer destinationLayer_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideScrollingTextElement> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerCueReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Direction Direction
	{
		get
		{
			return direction_;
		}
		set
		{
			direction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StartPosition StartPosition
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
	public bool IsRepeatEnabled
	{
		get
		{
			return isRepeatEnabled_;
		}
		set
		{
			isRepeatEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Speed Speed
	{
		get
		{
			return speed_;
		}
		set
		{
			speed_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DestinationLayer DestinationLayer
	{
		get
		{
			return destinationLayer_;
		}
		set
		{
			destinationLayer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideScrollingTextElement()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideScrollingTextElement(SlideScrollingTextElement other)
		: this()
	{
		direction_ = other.direction_;
		startPosition_ = other.startPosition_;
		isRepeatEnabled_ = other.isRepeatEnabled_;
		speed_ = other.speed_;
		destinationLayer_ = other.destinationLayer_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideScrollingTextElement Clone()
	{
		return new SlideScrollingTextElement(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideScrollingTextElement);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideScrollingTextElement other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Direction != other.Direction)
		{
			return false;
		}
		if (StartPosition != other.StartPosition)
		{
			return false;
		}
		if (IsRepeatEnabled != other.IsRepeatEnabled)
		{
			return false;
		}
		if (Speed != other.Speed)
		{
			return false;
		}
		if (DestinationLayer != other.DestinationLayer)
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
		if (Direction != 0)
		{
			num ^= Direction.GetHashCode();
		}
		if (StartPosition != 0)
		{
			num ^= StartPosition.GetHashCode();
		}
		if (IsRepeatEnabled)
		{
			num ^= IsRepeatEnabled.GetHashCode();
		}
		if (Speed != 0)
		{
			num ^= Speed.GetHashCode();
		}
		if (DestinationLayer != 0)
		{
			num ^= DestinationLayer.GetHashCode();
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
		if (Direction != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Direction);
		}
		if (StartPosition != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)StartPosition);
		}
		if (IsRepeatEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsRepeatEnabled);
		}
		if (Speed != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Speed);
		}
		if (DestinationLayer != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)DestinationLayer);
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
		if (Direction != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Direction);
		}
		if (StartPosition != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)StartPosition);
		}
		if (IsRepeatEnabled)
		{
			num += 2;
		}
		if (Speed != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Speed);
		}
		if (DestinationLayer != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)DestinationLayer);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SlideScrollingTextElement other)
	{
		if (other != null)
		{
			if (other.Direction != 0)
			{
				Direction = other.Direction;
			}
			if (other.StartPosition != 0)
			{
				StartPosition = other.StartPosition;
			}
			if (other.IsRepeatEnabled)
			{
				IsRepeatEnabled = other.IsRepeatEnabled;
			}
			if (other.Speed != 0)
			{
				Speed = other.Speed;
			}
			if (other.DestinationLayer != 0)
			{
				DestinationLayer = other.DestinationLayer;
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
				Direction = (Types.Direction)input.ReadEnum();
				break;
			case 16u:
				StartPosition = (Types.StartPosition)input.ReadEnum();
				break;
			case 24u:
				IsRepeatEnabled = input.ReadBool();
				break;
			case 32u:
				Speed = (Types.Speed)input.ReadEnum();
				break;
			case 40u:
				DestinationLayer = (DestinationLayer)input.ReadEnum();
				break;
			}
		}
	}
}
