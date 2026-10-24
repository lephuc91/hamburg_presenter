using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum PlaybackMarkerIdentifierType
{
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_TYPE_FIRST")]
	First,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_TYPE_PREVIOUS")]
	Previous,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_TYPE_NEXT")]
	Next,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_TYPE_LAST")]
	Last,
	[LocalizedString("PLAYBACK_MARKER_DATA_LINK_TYPE_NAME")]
	Name
}
