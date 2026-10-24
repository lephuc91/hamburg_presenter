using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum LinkedFillType
{
	[LocalizedString("FILL_LINK_CHORD_CHART_title")]
	ChordChart,
	[LocalizedString("FILL_LINK_SLIDE_OBJECT_title")]
	Element,
	[LocalizedString("FILL_LINK_GROUP_COLOR_title")]
	GroupColor,
	[LocalizedString("FILL_LINK_LABEL_COLOR_title")]
	SlideLabelColor,
	[LocalizedString("FILL_LINK_CAPTURE_STATUS_COLOR_title")]
	CaptureStatusColor,
	[LocalizedString("FILL_LINK_SCREEN_PREVIEW_title")]
	PreviewScreen,
	[LocalizedString("FILL_LINK_PLANNING_CENTER_title")]
	PCOLive,
	SlidePreview,
	[LocalizedString("FILL_LINK_PLAYBACK_MARKER_COLOR_title")]
	PlaybackMarkerColor,
	[LocalizedString("FILL_LINK_TIMECODE_STATUS_title")]
	TimecodeStatusColor,
	None
}
