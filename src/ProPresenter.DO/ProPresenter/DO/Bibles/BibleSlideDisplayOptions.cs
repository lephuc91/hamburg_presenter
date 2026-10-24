using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Bibles;

public class BibleSlideDisplayOptions
{
	public ReferenceType ReferenceType { get; }

	public bool SplitOnVerse { get; }

	public bool ShowTranslation { get; }

	public bool HighlightText { get; }

	public bool DisplayNumbers { get; }

	public bool GroupMixedRangeVerses { get; }

	public static BibleSlideDisplayOptions Current => new BibleSlideDisplayOptions(BibleSettings.Settings.ReferenceType, BibleSettings.Settings.BreakOnNewVerse, BibleSettings.Settings.DisplayTranslation, BibleSettings.Settings.PreserveFontColor, BibleSettings.Settings.ShowVerseNumbers, BibleSettings.Settings.GroupMixedRangeVerses);

	public BibleSlideDisplayOptions(ReferenceType referenceType, bool splitOnVerse, bool showTranslation, bool highlightText, bool displayNumbers, bool groupMixedRangeVerses)
	{
		ReferenceType = referenceType;
		SplitOnVerse = splitOnVerse;
		ShowTranslation = showTranslation;
		HighlightText = highlightText;
		DisplayNumbers = displayNumbers;
		GroupMixedRangeVerses = groupMixedRangeVerses;
	}
}
