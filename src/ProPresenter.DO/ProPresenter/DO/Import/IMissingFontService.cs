using System.Collections.Generic;
using Pro.Text;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import;

public interface IMissingFontService
{
	IReadOnlyCollection<MissingFontInfo> DetectMissingFonts(params IPresentation[] presentations);

	FontInfo? SuggestReplacement(FontInfo missingFont);

	bool IsFontAvailable(FontInfo fontInfo);

	IFontDetectionSession CreateDetectionSession();

	IReadOnlyCollection<FontInfo> GetAvailableSystemFonts();

	void ApplyFontReplacements(IPresentation presentation, Dictionary<FontInfo, FontInfo> fontReplacements);

	void ApplyFontReplacements(Theme theme, Dictionary<FontInfo, FontInfo> fontReplacements);
}
