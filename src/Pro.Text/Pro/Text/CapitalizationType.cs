using Pro.Localization;

namespace Pro.Text;

public enum CapitalizationType
{
	[LocalizedString("EDITOR_PRESENTATION_TEXT_POPOVER_CAPITALIZATION_NONE_title")]
	None,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_POPOVER_CAPITALIZATION_ALL_CAPS_title")]
	AllCaps,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_POPOVER_CAPITALIZATION_SMALL_CAPS_title")]
	SmallCaps,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_POPOVER_CAPITALIZATION_TITLE_CASE_title")]
	TitleCase,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_POPOVER_CAPITALIZATION_START_CASE_title")]
	StartCase
}
