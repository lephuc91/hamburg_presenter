using Pro.Localization;

namespace ProPresenter.DO.Messages;

public enum MessageClearType
{
	[LocalizedString("MESSAGES_WINDOW_DISMISS_OPTION_MANUAL_title")]
	Manual,
	[LocalizedString("MESSAGES_WINDOW_DISMISS_OPTION_AFTER_TIMER_EXPIRES_title")]
	AfterTimers,
	[LocalizedString("MESSAGES_WINDOW_DISMISS_OPTION_AFTER_TIME_title")]
	AfterTime
}
