using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum SlideTextSourceMode
{
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_title")]
	TextOnly,
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_NOTES_title")]
	Notes,
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_ELEMENT_MATCHING_NAME_title")]
	ElementMatch
}
