using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;
using ProPresenter.DO.Bibles;

namespace ProPresenter.DO.Analytics;

public record BibleGenerateSlidesEvent(int TranslationCount, int SlideCount, BibleTextBoxLocation VerseLocation, BibleTextBoxLocation ReferenceLocation, bool ShowVerseNumber, bool BreakNewVerse, bool DisplayTranslation, bool PreserveFontColor, ReferenceType ReferenceType) : IAnalyticEvent
{
	public static void Publish(int translationCount, int slideCount, BibleTextBoxLocation verseLocation, BibleTextBoxLocation referenceLocation, bool showVerseNumber, bool breakNewVerse, bool displayTranslation, bool preserveFontColor, ReferenceType referenceType)
	{
		EventPublisher.Publish(new BibleGenerateSlidesEvent(translationCount, slideCount, verseLocation, referenceLocation, showVerseNumber, breakNewVerse, displayTranslation, preserveFontColor, referenceType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleGenerateSlides = new BibleGenerateSlides
			{
				BreakNewVerse = BreakNewVerse,
				DisplayTranslation = DisplayTranslation,
				PreserveFontColor = PreserveFontColor,
				ReferenceLocation = ReferenceLocation.ToProtoTextBoxLocation(),
				ReferenceStyle = ReferenceType.ToProtoReferenceType(),
				ShowVerseNumbers = ShowVerseNumber,
				SlideCount = SlideCount,
				TranslationCount = TranslationCount,
				VerseLocation = VerseLocation.ToProtoTextBoxLocation()
			};
		});
	}
}
