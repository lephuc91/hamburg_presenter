using Pro.Localization;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public enum CopyrightDisplayType
{
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_FIRST_SLIDE_BUTTON_title")]
	First,
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_LAST_SLIDE_BUTTON_title")]
	Last,
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_FIRST_AND_LAST_SLIDE_BUTTON_title")]
	FirstAndLast,
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_ALL_SLIDES_BUTTON_title")]
	AllSlides
}
