using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Print : IMessage<Print>, IMessage, IEquatable<Print>, IDeepCloneable<Print>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum PrintMode
		{
			[OriginalName("THUMBNAIL")]
			Thumbnail,
			[OriginalName("OUTLINE")]
			Outline
		}
	}

	private static readonly MessageParser<Print> _parser = new MessageParser<Print>(() => new Print());

	private UnknownFieldSet _unknownFields;

	public const int DocumentCountFieldNumber = 1;

	private uint documentCount_;

	public const int ModeFieldNumber = 2;

	private Types.PrintMode mode_;

	public const int IncludeMetadataFieldNumber = 3;

	private bool includeMetadata_;

	public const int IncludePresentationNotesFieldNumber = 4;

	private bool includePresentationNotes_;

	public const int IncludeCurrentDateFieldNumber = 5;

	private bool includeCurrentDate_;

	public const int IncludeSlideLabelsFieldNumber = 6;

	private bool includeSlideLabels_;

	public const int IncludeSlideNotesFieldNumber = 7;

	private bool includeSlideNotes_;

	public const int IncludeDisabledSlidesFieldNumber = 8;

	private bool includeDisabledSlides_;

	public const int NumberColumnsFieldNumber = 9;

	private uint numberColumns_;

	public const int PrintToDeviceFieldNumber = 10;

	private string printToDevice_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Print> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[23];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint DocumentCount
	{
		get
		{
			return documentCount_;
		}
		set
		{
			documentCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrintMode Mode
	{
		get
		{
			return mode_;
		}
		set
		{
			mode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeMetadata
	{
		get
		{
			return includeMetadata_;
		}
		set
		{
			includeMetadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludePresentationNotes
	{
		get
		{
			return includePresentationNotes_;
		}
		set
		{
			includePresentationNotes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeCurrentDate
	{
		get
		{
			return includeCurrentDate_;
		}
		set
		{
			includeCurrentDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeSlideLabels
	{
		get
		{
			return includeSlideLabels_;
		}
		set
		{
			includeSlideLabels_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeSlideNotes
	{
		get
		{
			return includeSlideNotes_;
		}
		set
		{
			includeSlideNotes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeDisabledSlides
	{
		get
		{
			return includeDisabledSlides_;
		}
		set
		{
			includeDisabledSlides_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint NumberColumns
	{
		get
		{
			return numberColumns_;
		}
		set
		{
			numberColumns_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PrintToDevice
	{
		get
		{
			return printToDevice_;
		}
		set
		{
			printToDevice_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Print()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Print(Print other)
		: this()
	{
		documentCount_ = other.documentCount_;
		mode_ = other.mode_;
		includeMetadata_ = other.includeMetadata_;
		includePresentationNotes_ = other.includePresentationNotes_;
		includeCurrentDate_ = other.includeCurrentDate_;
		includeSlideLabels_ = other.includeSlideLabels_;
		includeSlideNotes_ = other.includeSlideNotes_;
		includeDisabledSlides_ = other.includeDisabledSlides_;
		numberColumns_ = other.numberColumns_;
		printToDevice_ = other.printToDevice_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Print Clone()
	{
		return new Print(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Print);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Print other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (DocumentCount != other.DocumentCount)
		{
			return false;
		}
		if (Mode != other.Mode)
		{
			return false;
		}
		if (IncludeMetadata != other.IncludeMetadata)
		{
			return false;
		}
		if (IncludePresentationNotes != other.IncludePresentationNotes)
		{
			return false;
		}
		if (IncludeCurrentDate != other.IncludeCurrentDate)
		{
			return false;
		}
		if (IncludeSlideLabels != other.IncludeSlideLabels)
		{
			return false;
		}
		if (IncludeSlideNotes != other.IncludeSlideNotes)
		{
			return false;
		}
		if (IncludeDisabledSlides != other.IncludeDisabledSlides)
		{
			return false;
		}
		if (NumberColumns != other.NumberColumns)
		{
			return false;
		}
		if (PrintToDevice != other.PrintToDevice)
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
		if (DocumentCount != 0)
		{
			num ^= DocumentCount.GetHashCode();
		}
		if (Mode != 0)
		{
			num ^= Mode.GetHashCode();
		}
		if (IncludeMetadata)
		{
			num ^= IncludeMetadata.GetHashCode();
		}
		if (IncludePresentationNotes)
		{
			num ^= IncludePresentationNotes.GetHashCode();
		}
		if (IncludeCurrentDate)
		{
			num ^= IncludeCurrentDate.GetHashCode();
		}
		if (IncludeSlideLabels)
		{
			num ^= IncludeSlideLabels.GetHashCode();
		}
		if (IncludeSlideNotes)
		{
			num ^= IncludeSlideNotes.GetHashCode();
		}
		if (IncludeDisabledSlides)
		{
			num ^= IncludeDisabledSlides.GetHashCode();
		}
		if (NumberColumns != 0)
		{
			num ^= NumberColumns.GetHashCode();
		}
		if (PrintToDevice.Length != 0)
		{
			num ^= PrintToDevice.GetHashCode();
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
		if (DocumentCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(DocumentCount);
		}
		if (Mode != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Mode);
		}
		if (IncludeMetadata)
		{
			output.WriteRawTag(24);
			output.WriteBool(IncludeMetadata);
		}
		if (IncludePresentationNotes)
		{
			output.WriteRawTag(32);
			output.WriteBool(IncludePresentationNotes);
		}
		if (IncludeCurrentDate)
		{
			output.WriteRawTag(40);
			output.WriteBool(IncludeCurrentDate);
		}
		if (IncludeSlideLabels)
		{
			output.WriteRawTag(48);
			output.WriteBool(IncludeSlideLabels);
		}
		if (IncludeSlideNotes)
		{
			output.WriteRawTag(56);
			output.WriteBool(IncludeSlideNotes);
		}
		if (IncludeDisabledSlides)
		{
			output.WriteRawTag(64);
			output.WriteBool(IncludeDisabledSlides);
		}
		if (NumberColumns != 0)
		{
			output.WriteRawTag(72);
			output.WriteUInt32(NumberColumns);
		}
		if (PrintToDevice.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(PrintToDevice);
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
		if (DocumentCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(DocumentCount);
		}
		if (Mode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
		}
		if (IncludeMetadata)
		{
			num += 2;
		}
		if (IncludePresentationNotes)
		{
			num += 2;
		}
		if (IncludeCurrentDate)
		{
			num += 2;
		}
		if (IncludeSlideLabels)
		{
			num += 2;
		}
		if (IncludeSlideNotes)
		{
			num += 2;
		}
		if (IncludeDisabledSlides)
		{
			num += 2;
		}
		if (NumberColumns != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(NumberColumns);
		}
		if (PrintToDevice.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PrintToDevice);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Print other)
	{
		if (other != null)
		{
			if (other.DocumentCount != 0)
			{
				DocumentCount = other.DocumentCount;
			}
			if (other.Mode != 0)
			{
				Mode = other.Mode;
			}
			if (other.IncludeMetadata)
			{
				IncludeMetadata = other.IncludeMetadata;
			}
			if (other.IncludePresentationNotes)
			{
				IncludePresentationNotes = other.IncludePresentationNotes;
			}
			if (other.IncludeCurrentDate)
			{
				IncludeCurrentDate = other.IncludeCurrentDate;
			}
			if (other.IncludeSlideLabels)
			{
				IncludeSlideLabels = other.IncludeSlideLabels;
			}
			if (other.IncludeSlideNotes)
			{
				IncludeSlideNotes = other.IncludeSlideNotes;
			}
			if (other.IncludeDisabledSlides)
			{
				IncludeDisabledSlides = other.IncludeDisabledSlides;
			}
			if (other.NumberColumns != 0)
			{
				NumberColumns = other.NumberColumns;
			}
			if (other.PrintToDevice.Length != 0)
			{
				PrintToDevice = other.PrintToDevice;
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
				DocumentCount = input.ReadUInt32();
				break;
			case 16u:
				Mode = (Types.PrintMode)input.ReadEnum();
				break;
			case 24u:
				IncludeMetadata = input.ReadBool();
				break;
			case 32u:
				IncludePresentationNotes = input.ReadBool();
				break;
			case 40u:
				IncludeCurrentDate = input.ReadBool();
				break;
			case 48u:
				IncludeSlideLabels = input.ReadBool();
				break;
			case 56u:
				IncludeSlideNotes = input.ReadBool();
				break;
			case 64u:
				IncludeDisabledSlides = input.ReadBool();
				break;
			case 72u:
				NumberColumns = input.ReadUInt32();
				break;
			case 82u:
				PrintToDevice = input.ReadString();
				break;
			}
		}
	}
}
