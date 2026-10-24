using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ShowSlideLabelChange : IMessage<ShowSlideLabelChange>, IMessage, IEquatable<ShowSlideLabelChange>, IDeepCloneable<ShowSlideLabelChange>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Source
		{
			[OriginalName("SOURCE_UNKNOWN")]
			Unknown,
			[OriginalName("CONTEXT_MENU")]
			ContextMenu,
			[OriginalName("POPOVER")]
			Popover
		}
	}

	private static readonly MessageParser<ShowSlideLabelChange> _parser = new MessageParser<ShowSlideLabelChange>(() => new ShowSlideLabelChange());

	private UnknownFieldSet _unknownFields;

	public const int NumberOfSlidesFieldNumber = 1;

	private int numberOfSlides_;

	public const int SourceFieldNumber = 2;

	private Types.Source source_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ShowSlideLabelChange> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[55];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int NumberOfSlides
	{
		get
		{
			return numberOfSlides_;
		}
		set
		{
			numberOfSlides_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Source Source
	{
		get
		{
			return source_;
		}
		set
		{
			source_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowSlideLabelChange()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowSlideLabelChange(ShowSlideLabelChange other)
		: this()
	{
		numberOfSlides_ = other.numberOfSlides_;
		source_ = other.source_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowSlideLabelChange Clone()
	{
		return new ShowSlideLabelChange(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ShowSlideLabelChange);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ShowSlideLabelChange other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (NumberOfSlides != other.NumberOfSlides)
		{
			return false;
		}
		if (Source != other.Source)
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
		if (NumberOfSlides != 0)
		{
			num ^= NumberOfSlides.GetHashCode();
		}
		if (Source != 0)
		{
			num ^= Source.GetHashCode();
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
		if (NumberOfSlides != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(NumberOfSlides);
		}
		if (Source != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Source);
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
		if (NumberOfSlides != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(NumberOfSlides);
		}
		if (Source != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Source);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ShowSlideLabelChange other)
	{
		if (other != null)
		{
			if (other.NumberOfSlides != 0)
			{
				NumberOfSlides = other.NumberOfSlides;
			}
			if (other.Source != 0)
			{
				Source = other.Source;
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
				NumberOfSlides = input.ReadInt32();
				break;
			case 16u:
				Source = (Types.Source)input.ReadEnum();
				break;
			}
		}
	}
}
