using Pro.Common.Collections;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface IMediaImportDownloadDialogVM
{
	INotifyEnumerableChanged<IPlaylist<MediaCue>> Playlists { get; }

	VisualPlaylist SelectedPlaylist { get; set; }

	string NewPlaylistName { get; set; }

	bool IsDownload { get; }

	bool IsValidLibrarySelected { get; }
}
