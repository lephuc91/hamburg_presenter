using Pro.Localization;

namespace ProPresenter.DO.Timecode;

public enum TimecodeFormat
{
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_24FPS_title")]
	_24Fps,
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_25FPS_title")]
	_25Fps,
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_2997FPS_title")]
	_2997Fps,
	[LocalizedString("RECORDING_WINDOW_FRAMERATE_30FPS_title")]
	_30Fps
}
