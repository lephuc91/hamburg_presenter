using Pro.Localization;

namespace Pro.ssAPI;

public enum EndBehaviorType
{
	[LocalizedString("MEDIA_END_BEHAVIOR_HOLD_LAST_title")]
	HoldLastFrame,
	[LocalizedString("MEDIA_END_BEHAVIOR_BLACK_title")]
	BlackAfterLastFrame,
	[LocalizedString("MEDIA_END_BEHAVIOR_CLEAR_title")]
	ClearAfterLastFrame,
	[LocalizedString("MEDIA_END_BEHAVIOR_FADE_BLACK_title")]
	FadeToBlack,
	[LocalizedString("MEDIA_END_BEHAVIOR_FADE_CLEAR_title")]
	FadeToClear
}
