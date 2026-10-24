using Pro.Localization;

namespace Pro.DO.Triggering;

public enum ActionType
{
	[LocalizedString("ACTION_TYPE_STAGE_title")]
	StageLayout,
	[LocalizedString("ACTION_TYPE_MEDIA_title")]
	Media,
	[LocalizedString("ACTION_TYPE_TIMER_title")]
	Timer,
	[LocalizedString("ACTION_TYPE_COMMUNICATION_title")]
	Communication,
	[LocalizedString("ACTION_TYPE_CLEAR_title")]
	Clear,
	[LocalizedString("ACTION_TYPE_PROP_title")]
	Prop,
	[LocalizedString("ACTION_TYPE_MESSAGE_title")]
	Message,
	Slide,
	[LocalizedString("ACTION_TYPE_DOCUMENT_title")]
	Document,
	Header,
	[LocalizedString("ACTION_TYPE_LIVE_VIDEO_MEDIA_title")]
	LiveVideo,
	[LocalizedString("ACTION_TYPE_PROP_SLIDE_title")]
	PropSlide,
	[LocalizedString("ACTION_TYPE_AUDIENCE_LOOK_title")]
	AudienceLook,
	[LocalizedString("ACTION_TYPE_GO_TO_NEXT_TIMER_title")]
	GoToNext,
	[LocalizedString("AUDIO_INPUT_ACTION_DISPLAY_NAME_title")]
	AudioInput,
	[LocalizedString("PLAYLIST_ACTION_MEDIA_PLAYLIST_title")]
	VisualPlaylist,
	[LocalizedString("PLAYLIST_ACTION_AUDIO_PLAYLIST_title")]
	AudioPlaylist,
	[LocalizedString("ACTION_TYPE_SLIDE_DESTINATION_title")]
	SlideDestination,
	[LocalizedString("ACTION_TYPE_MACRO_title")]
	Macro,
	[LocalizedString("ACTION_TYPE_CLEAR_GROUP_title")]
	ClearGroup,
	Placeholder,
	[LocalizedString("ACTION_TYPE_CAPTURE_title")]
	Capture,
	LibraryPlaylist
}
