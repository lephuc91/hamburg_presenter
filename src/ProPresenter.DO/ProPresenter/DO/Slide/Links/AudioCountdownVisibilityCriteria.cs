using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum AudioCountdownVisibilityCriteria
{
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_HAS_TIME_REMAINING_title")]
	HasTimeRemaining,
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_HAS_FINISHED_title")]
	HasExpired,
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_IS_PLAYING_title")]
	IsRunning,
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_IS_NOT_PLAYING_title")]
	NotRunning,
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_IS_LOOPING_title")]
	IsLooping,
	[LocalizedString("VISIBILITY_LINK_CONDITION_AUDIO_COUNTDOWN_IS_NOT_LOOPING_title")]
	IsNotLooping
}
