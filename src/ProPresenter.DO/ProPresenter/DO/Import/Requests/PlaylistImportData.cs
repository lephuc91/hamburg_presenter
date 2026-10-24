using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Import.Requests;

public class PlaylistImportData
{
	public PlaylistLocation PlaylistLocation { get; }

	public bool OverWritePlaylist { get; }

	public IPlaylist<ProPresenterCue>? TargetPlaylist { get; }

	public int InsertIndex { get; }

	public PlaylistImportData(PlaylistLocation playlistLocation, bool overWritePlaylist = false, IPlaylist<ProPresenterCue>? targetPlaylist = null, int insertIndex = -1)
	{
		PlaylistLocation = playlistLocation;
		OverWritePlaylist = overWritePlaylist;
		TargetPlaylist = targetPlaylist;
		InsertIndex = insertIndex;
	}
}
