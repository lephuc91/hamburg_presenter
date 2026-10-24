using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum PlaybackMarkerIdentifierDestination
{
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_DESTINATION_PRESENTATION")]
	Presentation,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_DESTINATION_ANNOUNCEMENT")]
	Announcement,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_DESTINATION_AUDIO")]
	Audio
}
