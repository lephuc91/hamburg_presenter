using System.Collections.Generic;
using Pro.Text;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import;

public sealed class MissingFontService : IMissingFontService
{
	private readonly IFontDetector _fontDetector;

	private readonly IFontDetectionSessionFactory _sessionFactory;

	public MissingFontService(IFontDetector fontDetector, IFontDetectionSessionFactory sessionFactory)
	{
		_fontDetector = fontDetector;
		_sessionFactory = sessionFactory;
	}

	public IReadOnlyCollection<MissingFontInfo> DetectMissingFonts(params IPresentation[] presentations)
	{
		return _fontDetector.DetectMissingFonts(presentations);
	}

	public FontInfo? SuggestReplacement(FontInfo missingFont)
	{
		return _fontDetector.SuggestReplacement(missingFont);
	}

	public bool IsFontAvailable(FontInfo fontInfo)
	{
		return _fontDetector.IsFontAvailable(fontInfo);
	}

	public IFontDetectionSession CreateDetectionSession()
	{
		return _sessionFactory.Create();
	}

	public IReadOnlyCollection<FontInfo> GetAvailableSystemFonts()
	{
		return _fontDetector.GetAvailableSystemFonts();
	}

	public void ApplyFontReplacements(IPresentation presentation, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		if (fontReplacements.Count == 0)
		{
			return;
		}
		foreach (CueGroup arrangementGroup in presentation.ArrangementGroups)
		{
			foreach (SlideCue cue in arrangementGroup.Cues)
			{
				ApplyFontReplacementsToCue(cue, fontReplacements);
			}
		}
	}

	public void ApplyFontReplacements(Theme theme, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		if (fontReplacements.Count == 0)
		{
			return;
		}
		foreach (TemplateSlide item in theme)
		{
			ApplyFontReplacementsToSlide(item.Slide, fontReplacements);
		}
	}

	private void ApplyFontReplacementsToCue(SlideCue cue, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		ApplyFontReplacementsToSlide(cue.SlideAction.Slide, fontReplacements);
	}

	private static void ApplyFontReplacementsToSlide(SlideBase slide, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		if (slide is CustomSlide customSlide)
		{
			ApplyFontReplacementsToCustomSlide(customSlide, fontReplacements);
		}
	}

	private static void ApplyFontReplacementsToCustomSlide(CustomSlide customSlide, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		foreach (SlideElementBase element in customSlide.Elements)
		{
			ApplyFontReplacementsToElement(element, fontReplacements);
		}
		if (customSlide.Note != null)
		{
			ApplyFontReplacementsToTextDocument(customSlide.Note, fontReplacements);
		}
	}

	private static void ApplyFontReplacementsToElement(SlideElementBase element, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		if (element is ClosedBezierPath closedBezierPath)
		{
			ApplyFontReplacementsToTextDocument(closedBezierPath.Text, fontReplacements);
			ApplyFontReplacementsToTextDocument(closedBezierPath.DisplayText, fontReplacements);
		}
	}

	private static void ApplyFontReplacementsToTextDocument(TextDocument textDocument, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		ApplyFontReplacement(textDocument.Attributes.RunSettings, fontReplacements);
		textDocument.IterateRuns(Range.All, splitRuns: false, delegate(RunBase run)
		{
			ApplyFontReplacement(run.Settings, fontReplacements);
		});
	}

	private static void ApplyFontReplacement(RunSettings settings, Dictionary<FontInfo, FontInfo> fontReplacements)
	{
		FontInfo font = settings.Font;
		if (fontReplacements.TryGetValue(font, out var value))
		{
			settings.Font = value;
		}
		if (settings.OriginalFont.HasValue && fontReplacements.TryGetValue(settings.OriginalFont.Value, out var value2))
		{
			settings.Font = value2;
			settings.OriginalFont = value2;
		}
	}
}
