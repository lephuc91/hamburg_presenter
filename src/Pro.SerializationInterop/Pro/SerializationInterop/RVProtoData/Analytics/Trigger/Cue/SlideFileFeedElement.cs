using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideFileFeedElement : IMessage<SlideFileFeedElement>, IMessage, IEquatable<SlideFileFeedElement>, IDeepCloneable<SlideFileFeedElement>
{
	private static readonly MessageParser<SlideFileFeedElement> _parser = new MessageParser<SlideFileFeedElement>(() => new SlideFileFeedElement());

	private UnknownFieldSet _unknownFields;

	public const int DestinationLayerFieldNumber = 1;

	private DestinationLayer destinationLayer_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideFileFeedElement> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerCueReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public SlideFileFeedElement()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideFileFeedElement(SlideFileFeedElement other)
		: this()
	{
		destinationLayer_ = other.destinationLayer_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideFileFeedElement Clone()
	{
		return new SlideFileFeedElement(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideFileFeedElement);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideFileFeedElement other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
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
		if (DestinationLayer != 0)
		{
			output.WriteRawTag(8);
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
	public void MergeFrom(SlideFileFeedElement other)
	{
		if (other != null)
		{
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				DestinationLayer = (DestinationLayer)input.ReadEnum();
			}
		}
	}
}
