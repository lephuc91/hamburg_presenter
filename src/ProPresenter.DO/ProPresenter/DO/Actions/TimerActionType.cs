using Pro.Localization;

namespace ProPresenter.DO.Actions;

public enum TimerActionType
{
	[LocalizedString("ACTION_PALETTE_TIMER_START_title")]
	Start,
	[LocalizedString("ACTION_PALETTE_TIMER_STOP_title")]
	Stop,
	[LocalizedString("ACTION_PALETTE_TIMER_RESET_title")]
	Reset,
	[LocalizedString("ACTION_PALETTE_TIMER_RESET_AND_START_title")]
	ResetAndStart,
	[LocalizedString("ACTION_PALETTE_TIMER_STOP_AND_RESET_title")]
	ResetAndStop,
	[LocalizedString("ACTION_PALETTE_TIMER_INCREMENT_title")]
	Increment
}
