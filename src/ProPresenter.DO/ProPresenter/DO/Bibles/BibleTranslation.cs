using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Bibles;

public class BibleTranslation : NotifyPropertyChangedBase, ICloneable<BibleTranslation>
{
	private string? _abbreviation;

	private SlideElementBase? _verseElement;

	private SlideElementBase? _referenceElement;

	private bool _includeReferenceWithVerse;

	public string? Abbreviation
	{
		get
		{
			return _abbreviation;
		}
		set
		{
			SetValue("Abbreviation", ref _abbreviation, value);
		}
	}

	public SlideElementBase? VerseElement
	{
		get
		{
			return _verseElement;
		}
		set
		{
			SetValue("VerseElement", ref _verseElement, value);
		}
	}

	public SlideElementBase? ReferenceElement
	{
		get
		{
			return _referenceElement;
		}
		set
		{
			SetValue("ReferenceElement", ref _referenceElement, value);
		}
	}

	public bool IncludeReferenceWithVerse
	{
		get
		{
			return _includeReferenceWithVerse;
		}
		set
		{
			SetValue("IncludeReferenceWithVerse", ref _includeReferenceWithVerse, value);
		}
	}

	public BibleTranslation(string? abbreviation)
	{
		_abbreviation = abbreviation;
	}

	public BibleTranslation Clone()
	{
		return new BibleTranslation(_abbreviation)
		{
			_verseElement = _verseElement,
			_referenceElement = _referenceElement,
			_includeReferenceWithVerse = _includeReferenceWithVerse
		};
	}
}
