using System.ComponentModel;
using Pro.Localization;

namespace ProPresenter.DO.Capture;

public enum FrameRate
{
	[Description("Unknown")]
	Unknown,
	[Description("24 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_24FPS_title")]
	_24,
	[Description("25 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_25FPS_title")]
	_25,
	[Description("29.97 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_2997FPS_title")]
	_2997,
	[Description("30 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_30FPS_title")]
	_30,
	[Description("50 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_50FPS_title")]
	_50,
	[Description("59.94 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_5994FPS_title")]
	_5994,
	[Description("60 fps")]
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_60FPS_title")]
	_60
}
