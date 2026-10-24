using Pro.Localization;

namespace ProPresenter.DO.TestPattern.State;

public enum DisplayLocation
{
	[LocalizedString("TEST_PATTERN_DISPLAY_LOCATION_ALL_SCREENS_title")]
	AllScreens,
	[LocalizedString("TEST_PATTERN_DISPLAY_LOCATION_AUDIENCE_SCREEN_title")]
	AudienceScreens,
	[LocalizedString("TEST_PATTERN_DISPLAY_LOCATION_STAGE_SCREEN_title")]
	StageScreens,
	SpecificScreen
}
