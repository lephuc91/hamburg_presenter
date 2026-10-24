using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public enum SubrectTargetMode
{
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_TARGET_FULL_title")]
	Full,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_TARGET_TWO_BY_ONE_title")]
	TwoByOne,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_TARGET_TWO_BY_TWO_title")]
	TwoByTwo,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_TARGET_THREE_BY_ONE_title")]
	ThreeByOne,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_TARGET_CUSTOM_title")]
	Custom
}
