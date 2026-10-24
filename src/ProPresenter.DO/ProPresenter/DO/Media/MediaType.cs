using Pro.Localization;

namespace ProPresenter.DO.Media;

public enum MediaType
{
	[LocalizedString("ACTION_TYPE_MEDIA_title")]
	Image,
	Video,
	[LocalizedString("ACTION_TYPE_AUDIO_MEDIA_title")]
	Audio,
	[LocalizedString("ACTION_TYPE_LIVE_VIDEO_MEDIA_title")]
	LiveVideo,
	Web,
	Unsupported
}
