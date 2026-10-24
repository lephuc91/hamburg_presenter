using Pro.Localization;

namespace Pro.ssAPI.Devices;

public enum ClockSourceType
{
	Unknown,
	[LocalizedString("SETTINGS_SCREENS_TIMING_SOURCE_INPUT_PREFIX_label")]
	Input,
	[LocalizedString("SETTINGS_SCREENS_TIMING_SOURCE_OUTPUT_PREFIX_label")]
	Output
}
