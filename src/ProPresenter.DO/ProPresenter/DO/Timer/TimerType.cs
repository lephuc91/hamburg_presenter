using Pro.Localization;

namespace ProPresenter.DO.Timer;

public enum TimerType
{
	[LocalizedString("TIMERS_WINDOW_TIMER_TYPE_COUNTDOWN_title")]
	Countdown,
	[LocalizedString("TIMERS_WINDOW_TIMER_TYPE_COUNTDOWN_TO_TIME_title")]
	CountdownToTime,
	[LocalizedString("TIMERS_WINDOW_TIMER_TYPE_ELAPSED_TIME_title")]
	ElapsedTime
}
