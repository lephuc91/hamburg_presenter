using Pro.Localization;

namespace ProPresenter.DO.Timer;

public enum TimeFormat
{
	[LocalizedString("TIMERS_WINDOW_COUNTDOWN_TO_TIME_FORMAT_AM_title")]
	AM,
	[LocalizedString("TIMERS_WINDOW_COUNTDOWN_TO_TIME_FORMAT_PM_title")]
	PM,
	[LocalizedString("TIMERS_WINDOW_COUNTDOWN_TO_TIME_FORMAT_24_HOUR_title")]
	TwentyFour
}
