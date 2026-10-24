namespace ProPresenter.DO.Slide.Links;

public interface IPlaylistItemInfo
{
	string CurrentPlaylistItem { get; }

	string CurrentPlaylistItemArrangement { get; }

	string NextPlaylistItem { get; }

	string NextPlaylistItemArrangement { get; }

	string CurrentHeader { get; }

	string NextHeader { get; }

	string Playlist { get; }
}
