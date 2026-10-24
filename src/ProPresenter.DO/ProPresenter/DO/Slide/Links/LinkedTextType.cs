using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum LinkedTextType
{
	[LocalizedString("TEXT_LINK_CCLI_title")]
	CCLITemplate,
	[LocalizedString("TEXT_LINK_CURRENT_SLIDE_title")]
	CurrentSlide,
	[LocalizedString("TEXT_LINK_NEXT_SLIDE_title")]
	NextSlide,
	[LocalizedString("TEXT_LINK_STAGE_MESSAGE_title")]
	StageMessage,
	[LocalizedString("TEXT_LINK_VIDEO_COUNTDOWN_title")]
	VideoCountdown,
	[LocalizedString("TEXT_LINK_AUDIO_COUNTDOWN_title")]
	AudioCountdown,
	[LocalizedString("TEXT_LINK_SLIDE_OBJECT_title")]
	Element,
	[LocalizedString("TEXT_LINK_COUNTDOWN_TIMER_title")]
	Timer,
	[LocalizedString("TEXT_LINK_SYSTEM_CLOCK_title")]
	Clock,
	[LocalizedString("TEXT_LINK_TEXT_TICKER_title")]
	Ticker,
	[LocalizedString("TEXT_LINK_GROUP_NAME_title")]
	GroupName,
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_title")]
	PlaylistItem,
	[LocalizedString("TEXT_LINK_AUTO_ADVANCE_TIME_REMAINING_title")]
	AutoAdvanceTimeRemaing,
	[LocalizedString("TEXT_LINK_PRESENTATION_NOTES_title")]
	PresentationNotes,
	[LocalizedString("TEXT_LINK_CAPTURE_title")]
	Capture,
	[LocalizedString("TEXT_LINK_SLIDE_COUNT_title")]
	SlideCount,
	[LocalizedString("TEXT_LINK_SLIDE_LABEL_title")]
	SlideLabel,
	[LocalizedString("TEXT_LINK_PRESENTATION_title")]
	PresentationName,
	[LocalizedString("TEXT_LINK_FILE_FEED_title")]
	FileFeed,
	[LocalizedString("TEXT_LINK_RSS_FEED_title")]
	RssFeed,
	[LocalizedString("TEXT_LINK_PLAYBACK_MARKER_title")]
	PlaybackMarkerText,
	[LocalizedString("TEXT_LINK_TIMECODE_TEXT_title")]
	TimecodeText,
	None
}
