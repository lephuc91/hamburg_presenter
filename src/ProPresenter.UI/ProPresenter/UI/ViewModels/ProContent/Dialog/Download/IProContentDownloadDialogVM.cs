using System.Collections.Generic;
using Pro.Common.Collections;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

public interface IProContentDownloadDialogVM
{
	IReadOnlyCollection<IProContentFormat> AvailableFormats { get; }

	INotifyEnumerableChanged<IPlaylist<MediaCue>> Playlists { get; }

	bool CanStartDownload { get; }

	IPlaylist<MediaCue>? SelectedPlaylist { get; set; }

	IProContentFormat? SelectedFormat { get; set; }

	string NewPlaylistName { get; set; }
}
