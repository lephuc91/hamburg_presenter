using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Behavior
		{
			[OriginalName("TUNE")]
			Tune,
			[OriginalName("SOUND")]
			Sound
		}

		public enum PlaybackBehavior
		{
			[OriginalName("STOP")]
			Stop,
			[OriginalName("LOOP")]
			Loop,
			[OriginalName("NEXT")]
			Next
		}
	}

	private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

	private UnknownFieldSet _unknownFields;

	public const int BehaviorFieldNumber = 1;

	private Types.Behavior behavior_;

	public const int PlaybackBehaviorFieldNumber = 2;

	private Types.PlaybackBehavior playbackBehavior_;

	public const int TransitionFieldNumber = 3;

	private Transition transition_;

	public const int AudioChannelCountFieldNumber = 4;

	private uint audioChannelCount_;

	public const int TransportFieldNumber = 5;

	private Transport transport_;

	public const int SourceTypeFieldNumber = 6;

	private SourceType sourceType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Audio> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Behavior Behavior
	{
		get
		{
			return behavior_;
		}
		set
		{
			behavior_ = value;
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
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
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
	public Audio()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio(Audio other)
		: this()
	{
		behavior_ = other.behavior_;
		playbackBehavior_ = other.playbackBehavior_;
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		audioChannelCount_ = other.audioChannelCount_;
		transport_ = ((other.transport_ != null) ? other.transport_.Clone() : null);
		sourceType_ = other.sourceType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio Clone()
	{
		return new Audio(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Audio);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Audio other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Behavior != other.Behavior)
		{
			return false;
		}
		if (PlaybackBehavior != other.PlaybackBehavior)
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
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
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (Behavior != 0)
		{
			num ^= Behavior.GetHashCode();
		}
		if (PlaybackBehavior != 0)
		{
			num ^= PlaybackBehavior.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
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
		if (Behavior != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Behavior);
		}
		if (PlaybackBehavior != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)PlaybackBehavior);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Transition);
		}
		if (AudioChannelCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(AudioChannelCount);
		}
		if (transport_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Transport);
		}
		if (SourceType != 0)
		{
			output.WriteRawTag(48);
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
		if (Behavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Behavior);
		}
		if (PlaybackBehavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
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
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Audio other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Behavior != 0)
		{
			Behavior = other.Behavior;
		}
		if (other.PlaybackBehavior != 0)
		{
			PlaybackBehavior = other.PlaybackBehavior;
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
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
				Behavior = (Types.Behavior)input.ReadEnum();
				break;
			case 16u:
				PlaybackBehavior = (Types.PlaybackBehavior)input.ReadEnum();
				break;
			case 26u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 32u:
				AudioChannelCount = input.ReadUInt32();
				break;
			case 42u:
				if (transport_ == null)
				{
					Transport = new Transport();
				}
				input.ReadMessage(Transport);
				break;
			case 48u:
				SourceType = (SourceType)input.ReadEnum();
				break;
			}
		}
	}
}
