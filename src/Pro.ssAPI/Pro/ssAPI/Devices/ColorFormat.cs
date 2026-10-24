using Pro.Localization;

namespace Pro.ssAPI.Devices;

public enum ColorFormat
{
	[LocalizedString("SETTINGS_SCREENS_RENDER_FORMAT_REC_709")]
	Sdr,
	[LocalizedString("SETTINGS_SCREENS_RENDER_FORMAT_REC_2100_PQ")]
	HdrRec2100PQ,
	[LocalizedString("SETTINGS_SCREENS_RENDER_FORMAT_REC_2100_HLG")]
	HdrRec2100HLG
}
