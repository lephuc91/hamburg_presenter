using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum TimerVisibilityCriteria
{
	[LocalizedString("VISIBILITY_LINK_CONDITION_TIMER_HAS_TIME_REMAINING_title")]
	HasTimeRemaining,
	[LocalizedString("VISIBILITY_LINK_CONDITION_TIMER_HAS_EXPIRED_title")]
	HasExpired,
	[LocalizedString("VISIBILITY_LINK_CONDITION_TIMER_IS_RUNNING_title")]
	IsRunning,
	[LocalizedString("VISIBILITY_LINK_CONDITION_TIMER_IS_NOT_RUNNING_title")]
	NotRunning
}
