using System;
using System.IO;
using System.Linq;
using Pro.Common.DataStore;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Settings;

public class BibleSettings : StoreBase
{
	private const string SettingsFile = "Bible.proPref";

	public static BibleSettings Settings { get; } = new BibleSettings();

	public string ReferenceText
	{
		get
		{
			return GetValue("ReferenceText", string.Empty);
		}
		set
		{
			SetValue("ReferenceText", value);
			OnPropertyChanged("ReferenceText");
		}
	}

	public int PanelRowCapacity
	{
		get
		{
			return GetValue("PanelRowCapacity", 6);
		}
		set
		{
			SetValue("PanelRowCapacity", value);
			OnPropertyChanged("PanelRowCapacity");
		}
	}

	public Guid SelectedTemplateID
	{
		get
		{
			return GetValue("SelectedTemplateID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedTemplateID", value);
			OnPropertyChanged("SelectedTemplateID");
		}
	}

	public string? SelectedImportLibraryName
	{
		get
		{
			return GetValue("SelectedImportLibraryName", string.Empty);
		}
		set
		{
			SetValue("SelectedImportLibraryName", value);
			OnPropertyChanged("SelectedImportLibraryName");
		}
	}

	public bool ShowVerseNumbers
	{
		get
		{
			return GetValue("ShowVerseNumbers", defaultValue: false);
		}
		set
		{
			SetValue("ShowVerseNumbers", value);
			OnPropertyChanged("ShowVerseNumbers");
		}
	}

	public bool BreakOnNewVerse
	{
		get
		{
			return GetValue("BreakOnNewVerse", defaultValue: false);
		}
		set
		{
			SetValue("BreakOnNewVerse", value);
			OnPropertyChanged("BreakOnNewVerse");
		}
	}

	public bool DisplayTranslation
	{
		get
		{
			return GetValue("DisplayTranslation", defaultValue: false);
		}
		set
		{
			SetValue("DisplayTranslation", value);
			OnPropertyChanged("DisplayTranslation");
		}
	}

	public bool PreserveFontColor
	{
		get
		{
			return GetValue("PreserveFontColor", defaultValue: false);
		}
		set
		{
			SetValue("PreserveFontColor", value);
			OnPropertyChanged("PreserveFontColor");
		}
	}

	public ReferenceType ReferenceType
	{
		get
		{
			return GetValue("ReferenceType", ReferenceType.NoReference);
		}
		set
		{
			SetValue("ReferenceType", value);
			OnPropertyChanged("ReferenceType");
		}
	}

	public bool DoNotShowAgainBreakOnVerse
	{
		get
		{
			return GetValue("DoNotShowAgainBreakOnVerse", defaultValue: false);
		}
		set
		{
			SetValue("DoNotShowAgainBreakOnVerse", value);
			OnPropertyChanged("DoNotShowAgainBreakOnVerse");
		}
	}

	public BibleTranslation PrimaryTranslation
	{
		get
		{
			return GetValue("PrimaryTranslation", new BibleTranslation(null));
		}
		set
		{
			SetValue("PrimaryTranslation", value);
			OnPropertyChanged("PrimaryTranslation");
		}
	}

	public BibleTranslationCollection BibleSearchTranslations { get; }

	public string? SearchTargetBible
	{
		get
		{
			return GetValue("SearchTargetBible", BibleSearchTranslations?.PrimaryTranslation?.Abbreviation ?? string.Empty);
		}
		set
		{
			SetValue("SearchTargetBible", value);
			OnPropertyChanged("SearchTargetBible");
		}
	}

	public bool GroupMixedRangeVerses => GetValue("GroupMixedRangeVerses", defaultValue: false);

	private BibleSettings()
		: base(Path.Combine(CommonPaths.Preferences, "Bible.proPref"))
	{
		RegisterEnumType<PanelViewType>();
		RegisterEnumType<ReferenceType>();
		RegisterCustomType(EncodeTranslation, DecodeTranslation);
		RegisterListType(delegate(BibleTranslation bt, BibleTranslationCollection btc)
		{
			btc.AddBibleTranslation(bt);
		});
		BibleSearchTranslations = GetValue("BibleSearchTranslations", new BibleTranslationCollection());
		BibleSearchTranslations.CollectionChanged += delegate
		{
			SetValue("BibleSearchTranslations", BibleSearchTranslations);
		};
		BibleSearchTranslations.TranslationPropertyChanged += delegate
		{
			SetValue("BibleSearchTranslations", BibleSearchTranslations);
		};
	}

	private BibleTranslation DecodeTranslation(string data)
	{
		TemplateSlide templateSlide = DataVault.Themes?.FindTemplate(SelectedTemplateID);
		if (templateSlide == null || !TryDecodeTranslation(data, out string abbreviation, out string verseElementName, out string referenceElementName, out Guid verseElementID, out Guid referenceElementID, out bool includeReferenceWithVerse))
		{
			return new BibleTranslation(string.Empty);
		}
		ClosedBezierPath verseElement = BibleTemplateHelper.FindElement(templateSlide.Slide, verseElementID, verseElementName, reset: false);
		ClosedBezierPath referenceElement = BibleTemplateHelper.FindElement(templateSlide.Slide, referenceElementID, referenceElementName, reset: false);
		return new BibleTranslation(abbreviation)
		{
			VerseElement = verseElement,
			ReferenceElement = referenceElement,
			IncludeReferenceWithVerse = includeReferenceWithVerse
		};
	}

	private static string EncodeTranslation(BibleTranslation translation)
	{
		global::_003C_003Ey__InlineArray6<object> buffer = default(global::_003C_003Ey__InlineArray6<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = translation.Abbreviation;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = translation.VerseElement?.Name;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = translation.ReferenceElement?.Name;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = translation.VerseElement?.ID;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = translation.ReferenceElement?.ID;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = translation.IncludeReferenceWithVerse;
		return string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray6<object>, object>(in buffer, 6));
	}

	private static bool TryDecodeTranslation(string encoded, out string abbreviation, out string verseElementName, out string referenceElementName, out Guid verseElementID, out Guid referenceElementID, out bool includeReferenceWithVerse)
	{
		string[] source = encoded.Split('|');
		abbreviation = source.ElementAtOrDefault(0) ?? string.Empty;
		verseElementName = source.ElementAtOrDefault(1) ?? string.Empty;
		referenceElementName = source.ElementAtOrDefault(2) ?? string.Empty;
		Guid.TryParse(source.ElementAtOrDefault(3), out verseElementID);
		Guid.TryParse(source.ElementAtOrDefault(4), out referenceElementID);
		bool.TryParse(source.ElementAtOrDefault(5), out includeReferenceWithVerse);
		return true;
	}
}
