using System.Collections.Generic;
using Pro.Text;

namespace ProPresenter.DO.Import;

public interface IMissingFontWindowProvider
{
	Dictionary<FontInfo, FontInfo>? ShowMissingFontDialog(IEnumerable<MissingFontInfo> missingFonts, MissingFontContext context);

	void HandleImportProcess(ImportProcess importProcess);
}
