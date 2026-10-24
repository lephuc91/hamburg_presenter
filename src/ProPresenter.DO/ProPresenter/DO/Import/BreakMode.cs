using Pro.Localization;

namespace ProPresenter.DO.Import;

public enum BreakMode
{
	[LocalizedString("IMPORT_TEXT_BREAK_MODE_BLANK_LINE_label")]
	BlankLine,
	[LocalizedString("IMPORT_TEXT_BREAK_MODE_NEW_LINE_label")]
	NewLine,
	Custom
}
