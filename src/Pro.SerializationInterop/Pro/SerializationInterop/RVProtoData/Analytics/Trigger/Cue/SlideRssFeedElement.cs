using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideRssFeedElement : IMessage<SlideRssFeedElement>, IMessage, IEquatable<SlideRssFeedElement>, IDeepCloneable<SlideRssFeedElement>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Content
		{
			[OriginalName("CONTENT_UNKNOWN")]
			Unknown,
			[OriginalName("TITLE")]
			Title,
			[OriginalName("TITLE_AND_DESCRIPTION")]
			TitleAndDescription
		}
	}

	private static readonly MessageParser<SlideRssFeedElement> _parser = new MessageParser<SlideRssFeedElement>(() => new SlideRssFeedElement());

	private UnknownFieldSet _unknownFields;

	public const int ContentFieldNumber = 1;

	private Types.Content content_;

	public const int IsDelimiterEnabledFieldNumber = 2;

	private bool isDelimiterEnabled_;

	public const int DestinationLayerFieldNumber = 3;

	private DestinationLayer destinationLayer_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideRssFeedElement> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerCueReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Content Content
	{
		get
		{
			return content_;
		}
		set
		{
			content_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsDelimiterEnabled
	{
		get
		{
			return isDelimiterEnabled_;
		}
		set
		{
			isDelimiterEnabled_ = value;
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
	public SlideRssFeedElement()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideRssFeedElement(SlideRssFeedElement other)
		: this()
	{
		content_ = other.content_;
		isDelimiterEnabled_ = other.isDelimiterEnabled_;
		destinationLayer_ = other.destinationLayer_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideRssFeedElement Clone()
	{
		return new SlideRssFeedElement(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideRssFeedElement);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideRssFeedElement other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Content != other.Content)
		{
			return false;
		}
		if (IsDelimiterEnabled != other.IsDelimiterEnabled)
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
		if (Content != 0)
		{
			num ^= Content.GetHashCode();
		}
		if (IsDelimiterEnabled)
		{
			num ^= IsDelimiterEnabled.GetHashCode();
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
		if (Content != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Content);
		}
		if (IsDelimiterEnabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(IsDelimiterEnabled);
		}
		if (DestinationLayer != 0)
		{
			output.WriteRawTag(24);
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
		if (Content != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Content);
		}
		if (IsDelimiterEnabled)
		{
			num += 2;
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
	public void MergeFrom(SlideRssFeedElement other)
	{
		if (other != null)
		{
			if (other.Content != 0)
			{
				Content = other.Content;
			}
			if (other.IsDelimiterEnabled)
			{
				IsDelimiterEnabled = other.IsDelimiterEnabled;
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
				Content = (Types.Content)input.ReadEnum();
				break;
			case 16u:
				IsDelimiterEnabled = input.ReadBool();
				break;
			case 24u:
				DestinationLayer = (DestinationLayer)input.ReadEnum();
				break;
			}
		}
	}
}
