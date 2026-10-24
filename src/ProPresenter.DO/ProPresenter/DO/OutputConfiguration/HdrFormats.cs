using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public enum HdrFormats
{
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_REC_709_title")]
	Sdr,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_REC_2100_PQ_title")]
	Rec2100PQ,
	[LocalizedString("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_REC_2100_HLG_title")]
	Rec2100HLG
}
