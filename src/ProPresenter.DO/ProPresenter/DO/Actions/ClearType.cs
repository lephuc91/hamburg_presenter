using Pro.Localization;

namespace ProPresenter.DO.Actions;

public enum ClearType
{
	[LocalizedString("ACTION_TYPE_CLEAR_ALL_title")]
	All,
	[LocalizedString("ACTION_TYPE_CLEAR_AUDIO_title")]
	Audio,
	[LocalizedString("ACTION_TYPE_CLEAR_AUDIO_EFFECTS_title")]
	AudioEffects,
	[LocalizedString("ACTION_TYPE_CLEAR_MEDIA_title")]
	Background,
	[LocalizedString("ACTION_TYPE_CLEAR_VIDEO_INPUT_title")]
	LiveVideo,
	[LocalizedString("ACTION_TYPE_CLEAR_PROPS_title")]
	Props,
	[LocalizedString("ACTION_TYPE_CLEAR_MESSAGES_title")]
	Messages,
	[LocalizedString("ACTION_TYPE_CLEAR_SLIDE_title")]
	Slide,
	[LocalizedString("ACTION_TYPE_CLEAR_TO_LOGO_title")]
	ToLogo,
	[LocalizedString("ACTION_TYPE_CLEAR_ANNOUNCEMENT_title")]
	Announcement
}
