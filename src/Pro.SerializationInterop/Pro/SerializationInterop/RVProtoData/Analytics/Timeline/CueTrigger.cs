using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CueTrigger : IMessage<CueTrigger>, IMessage, IEquatable<CueTrigger>, IDeepCloneable<CueTrigger>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum TriggerType
		{
			[OriginalName("SLIDE")]
			Slide,
			[OriginalName("MEDIA")]
			Media,
			[OriginalName("AUDIO")]
			Audio,
			[OriginalName("ACTION")]
			Action
		}

		public enum TimingSource
		{
			[OriginalName("INTERNAL")]
			Internal,
			[OriginalName("SMPTE")]
			Smpte
		}
	}

	private static readonly MessageParser<CueTrigger> _parser = new MessageParser<CueTrigger>(() => new CueTrigger());

	private UnknownFieldSet _unknownFields;

	public const int TriggerTypeFieldNumber = 1;

	private Types.TriggerType triggerType_;

	public const int TimingSourceFieldNumber = 2;

	private Types.TimingSource timingSource_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CueTrigger> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTimelineReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerType TriggerType
	{
		get
		{
			return triggerType_;
		}
		set
		{
			triggerType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimingSource TimingSource
	{
		get
		{
			return timingSource_;
		}
		set
		{
			timingSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CueTrigger()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CueTrigger(CueTrigger other)
		: this()
	{
		triggerType_ = other.triggerType_;
		timingSource_ = other.timingSource_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CueTrigger Clone()
	{
		return new CueTrigger(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CueTrigger);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CueTrigger other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TriggerType != other.TriggerType)
		{
			return false;
		}
		if (TimingSource != other.TimingSource)
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
		if (TriggerType != 0)
		{
			num ^= TriggerType.GetHashCode();
		}
		if (TimingSource != 0)
		{
			num ^= TimingSource.GetHashCode();
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
		if (TriggerType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)TriggerType);
		}
		if (TimingSource != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)TimingSource);
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
		if (TriggerType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)TriggerType);
		}
		if (TimingSource != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)TimingSource);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CueTrigger other)
	{
		if (other != null)
		{
			if (other.TriggerType != 0)
			{
				TriggerType = other.TriggerType;
			}
			if (other.TimingSource != 0)
			{
				TimingSource = other.TimingSource;
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
				TriggerType = (Types.TriggerType)input.ReadEnum();
				break;
			case 16u:
				TimingSource = (Types.TimingSource)input.ReadEnum();
				break;
			}
		}
	}
}
