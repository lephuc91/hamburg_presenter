using Pro.Localization;

namespace ProPresenter.DO.Slide.Links.Text.Slide;

public enum SlideMenuTextMode
{
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_title")]
	TextOnly,
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_NOTES_title")]
	Notes,
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_ELEMENT_MATCHING_NAME_title")]
	ElementMatch,
	[LocalizedString("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_AND_CHORDS_title")]
	TextAndChords
}
