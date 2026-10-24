using Pro.Text;

namespace ProPresenter.DO.Import;

public sealed record MissingFontInfo(FontInfo OriginalFont, FontInfo? SuggestedReplacement, string PresentationOrThemeName, int UsageCount = 1, MissingFontSource Source = MissingFontSource.Presentation);
