using System.Collections.Generic;
using Pro.Text;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import;

public interface IFontDetector
{
	IReadOnlyCollection<MissingFontInfo> DetectMissingFonts(params IPresentation[] presentations);

	FontInfo? SuggestReplacement(FontInfo missingFont);

	IReadOnlyCollection<FontInfo> GetAvailableSystemFonts();

	bool IsFontAvailable(FontInfo fontInfo);
}
