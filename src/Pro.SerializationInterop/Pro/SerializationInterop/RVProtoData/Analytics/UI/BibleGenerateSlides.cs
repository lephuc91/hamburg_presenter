using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BibleGenerateSlides : IMessage<BibleGenerateSlides>, IMessage, IEquatable<BibleGenerateSlides>, IDeepCloneable<BibleGenerateSlides>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum TextBoxLocation
		{
			[OriginalName("TEXT_BOX_LOCATION_UNKNOWN")]
			Unknown,
			[OriginalName("LOCATION_NONE")]
			LocationNone,
			[OriginalName("LOCATION_TEXT_BOX")]
			LocationTextBox,
			[OriginalName("LOCATION_WITH_VERSE")]
			LocationWithVerse
		}

		public enum ReferenceType
		{
			[OriginalName("REFERENCE_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("PASSAGE_NONE")]
			PassageNone,
			[OriginalName("PASSAGE_EACH")]
			PassageEach,
			[OriginalName("PASSAGE_LAST")]
			PassageLast,
			[OriginalName("VERSE")]
			Verse
		}
	}

	private static readonly MessageParser<BibleGenerateSlides> _parser = new MessageParser<BibleGenerateSlides>(() => new BibleGenerateSlides());

	private UnknownFieldSet _unknownFields;

	public const int TranslationCountFieldNumber = 1;

	private int translationCount_;

	public const int SlideCountFieldNumber = 2;

	private int slideCount_;

	public const int VerseLocationFieldNumber = 3;

	private Types.TextBoxLocation verseLocation_;

	public const int ReferenceLocationFieldNumber = 4;

	private Types.TextBoxLocation referenceLocation_;

	public const int ShowVerseNumbersFieldNumber = 5;

	private bool showVerseNumbers_;

	public const int BreakNewVerseFieldNumber = 6;

	private bool breakNewVerse_;

	public const int DisplayTranslationFieldNumber = 7;

	private bool displayTranslation_;

	public const int PreserveFontColorFieldNumber = 8;

	private bool preserveFontColor_;

	public const int ReferenceStyleFieldNumber = 9;

	private Types.ReferenceType referenceStyle_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BibleGenerateSlides> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TranslationCount
	{
		get
		{
			return translationCount_;
		}
		set
		{
			translationCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int SlideCount
	{
		get
		{
			return slideCount_;
		}
		set
		{
			slideCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TextBoxLocation VerseLocation
	{
		get
		{
			return verseLocation_;
		}
		set
		{
			verseLocation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TextBoxLocation ReferenceLocation
	{
		get
		{
			return referenceLocation_;
		}
		set
		{
			referenceLocation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShowVerseNumbers
	{
		get
		{
			return showVerseNumbers_;
		}
		set
		{
			showVerseNumbers_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool BreakNewVerse
	{
		get
		{
			return breakNewVerse_;
		}
		set
		{
			breakNewVerse_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool DisplayTranslation
	{
		get
		{
			return displayTranslation_;
		}
		set
		{
			displayTranslation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool PreserveFontColor
	{
		get
		{
			return preserveFontColor_;
		}
		set
		{
			preserveFontColor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ReferenceType ReferenceStyle
	{
		get
		{
			return referenceStyle_;
		}
		set
		{
			referenceStyle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateSlides()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateSlides(BibleGenerateSlides other)
		: this()
	{
		translationCount_ = other.translationCount_;
		slideCount_ = other.slideCount_;
		verseLocation_ = other.verseLocation_;
		referenceLocation_ = other.referenceLocation_;
		showVerseNumbers_ = other.showVerseNumbers_;
		breakNewVerse_ = other.breakNewVerse_;
		displayTranslation_ = other.displayTranslation_;
		preserveFontColor_ = other.preserveFontColor_;
		referenceStyle_ = other.referenceStyle_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateSlides Clone()
	{
		return new BibleGenerateSlides(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BibleGenerateSlides);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BibleGenerateSlides other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TranslationCount != other.TranslationCount)
		{
			return false;
		}
		if (SlideCount != other.SlideCount)
		{
			return false;
		}
		if (VerseLocation != other.VerseLocation)
		{
			return false;
		}
		if (ReferenceLocation != other.ReferenceLocation)
		{
			return false;
		}
		if (ShowVerseNumbers != other.ShowVerseNumbers)
		{
			return false;
		}
		if (BreakNewVerse != other.BreakNewVerse)
		{
			return false;
		}
		if (DisplayTranslation != other.DisplayTranslation)
		{
			return false;
		}
		if (PreserveFontColor != other.PreserveFontColor)
		{
			return false;
		}
		if (ReferenceStyle != other.ReferenceStyle)
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
		if (TranslationCount != 0)
		{
			num ^= TranslationCount.GetHashCode();
		}
		if (SlideCount != 0)
		{
			num ^= SlideCount.GetHashCode();
		}
		if (VerseLocation != 0)
		{
			num ^= VerseLocation.GetHashCode();
		}
		if (ReferenceLocation != 0)
		{
			num ^= ReferenceLocation.GetHashCode();
		}
		if (ShowVerseNumbers)
		{
			num ^= ShowVerseNumbers.GetHashCode();
		}
		if (BreakNewVerse)
		{
			num ^= BreakNewVerse.GetHashCode();
		}
		if (DisplayTranslation)
		{
			num ^= DisplayTranslation.GetHashCode();
		}
		if (PreserveFontColor)
		{
			num ^= PreserveFontColor.GetHashCode();
		}
		if (ReferenceStyle != 0)
		{
			num ^= ReferenceStyle.GetHashCode();
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
		if (TranslationCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TranslationCount);
		}
		if (SlideCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(SlideCount);
		}
		if (VerseLocation != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)VerseLocation);
		}
		if (ReferenceLocation != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)ReferenceLocation);
		}
		if (ShowVerseNumbers)
		{
			output.WriteRawTag(40);
			output.WriteBool(ShowVerseNumbers);
		}
		if (BreakNewVerse)
		{
			output.WriteRawTag(48);
			output.WriteBool(BreakNewVerse);
		}
		if (DisplayTranslation)
		{
			output.WriteRawTag(56);
			output.WriteBool(DisplayTranslation);
		}
		if (PreserveFontColor)
		{
			output.WriteRawTag(64);
			output.WriteBool(PreserveFontColor);
		}
		if (ReferenceStyle != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)ReferenceStyle);
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
		if (TranslationCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TranslationCount);
		}
		if (SlideCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(SlideCount);
		}
		if (VerseLocation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)VerseLocation);
		}
		if (ReferenceLocation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ReferenceLocation);
		}
		if (ShowVerseNumbers)
		{
			num += 2;
		}
		if (BreakNewVerse)
		{
			num += 2;
		}
		if (DisplayTranslation)
		{
			num += 2;
		}
		if (PreserveFontColor)
		{
			num += 2;
		}
		if (ReferenceStyle != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ReferenceStyle);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(BibleGenerateSlides other)
	{
		if (other != null)
		{
			if (other.TranslationCount != 0)
			{
				TranslationCount = other.TranslationCount;
			}
			if (other.SlideCount != 0)
			{
				SlideCount = other.SlideCount;
			}
			if (other.VerseLocation != 0)
			{
				VerseLocation = other.VerseLocation;
			}
			if (other.ReferenceLocation != 0)
			{
				ReferenceLocation = other.ReferenceLocation;
			}
			if (other.ShowVerseNumbers)
			{
				ShowVerseNumbers = other.ShowVerseNumbers;
			}
			if (other.BreakNewVerse)
			{
				BreakNewVerse = other.BreakNewVerse;
			}
			if (other.DisplayTranslation)
			{
				DisplayTranslation = other.DisplayTranslation;
			}
			if (other.PreserveFontColor)
			{
				PreserveFontColor = other.PreserveFontColor;
			}
			if (other.ReferenceStyle != 0)
			{
				ReferenceStyle = other.ReferenceStyle;
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
				TranslationCount = input.ReadInt32();
				break;
			case 16u:
				SlideCount = input.ReadInt32();
				break;
			case 24u:
				VerseLocation = (Types.TextBoxLocation)input.ReadEnum();
				break;
			case 32u:
				ReferenceLocation = (Types.TextBoxLocation)input.ReadEnum();
				break;
			case 40u:
				ShowVerseNumbers = input.ReadBool();
				break;
			case 48u:
				BreakNewVerse = input.ReadBool();
				break;
			case 56u:
				DisplayTranslation = input.ReadBool();
				break;
			case 64u:
				PreserveFontColor = input.ReadBool();
				break;
			case 72u:
				ReferenceStyle = (Types.ReferenceType)input.ReadEnum();
				break;
			}
		}
	}
}
