using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum VisibilityLinkType
{
	[LocalizedString("VISIBILITY_LINK_SLIDE_OBJECT_title")]
	SlideObject,
	[LocalizedString("VISIBILITY_LINK_TIMER_title")]
	Timer,
	[LocalizedString("VISIBILITY_LINK_VIDEO_COUNTDOWN_title")]
	VideoCountdown,
	[LocalizedString("VISIBILITY_LINK_AUDIO_COUNTDOWN_title")]
	AudioCountdown,
	[LocalizedString("VISIBILITY_LINK_CAPTURE_SESSION_title")]
	CaptureSession,
	[LocalizedString("VISIBILITY_LINK_VIDEO_INPUT_title")]
	VideoInput
}
