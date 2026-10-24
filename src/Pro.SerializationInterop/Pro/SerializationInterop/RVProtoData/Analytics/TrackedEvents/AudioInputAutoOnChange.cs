using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AudioInputAutoOnChange : IMessage<AudioInputAutoOnChange>, IMessage, IEquatable<AudioInputAutoOnChange>, IDeepCloneable<AudioInputAutoOnChange>
{
	private static readonly MessageParser<AudioInputAutoOnChange> _parser = new MessageParser<AudioInputAutoOnChange>(() => new AudioInputAutoOnChange());

	private UnknownFieldSet _unknownFields;

	public const int InputCountFieldNumber = 1;

	private uint inputCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AudioInputAutoOnChange> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint InputCount
	{
		get
		{
			return inputCount_;
		}
		set
		{
			inputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputAutoOnChange()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputAutoOnChange(AudioInputAutoOnChange other)
		: this()
	{
		inputCount_ = other.inputCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputAutoOnChange Clone()
	{
		return new AudioInputAutoOnChange(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AudioInputAutoOnChange);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AudioInputAutoOnChange other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (InputCount != other.InputCount)
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
		if (InputCount != 0)
		{
			num ^= InputCount.GetHashCode();
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
		if (InputCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(InputCount);
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
		if (InputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(InputCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AudioInputAutoOnChange other)
	{
		if (other != null)
		{
			if (other.InputCount != 0)
			{
				InputCount = other.InputCount;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				InputCount = input.ReadUInt32();
			}
		}
	}
}
