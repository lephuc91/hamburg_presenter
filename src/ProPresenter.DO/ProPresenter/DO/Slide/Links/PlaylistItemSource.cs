using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum PlaylistItemSource
{
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_PARENT_PLAYLIST_title")]
	ParentPlaylist,
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_CURRENT_title")]
	Current,
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_NEXT_title")]
	Next,
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_CURRENT_HEADER_title")]
	CurrentHeader,
	[LocalizedString("TEXT_LINK_PLAYLIST_ITEM_NEXT_HEADER_title")]
	NextHeader
}
