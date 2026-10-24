using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaImportDownloadDialogResult : IMediaImportDownloadDialogResult
{
	public VisualPlaylist SelectedPlaylist { get; }

	public MediaImportDownloadDialogResult(VisualPlaylist selectedPlaylist)
	{
		SelectedPlaylist = selectedPlaylist;
	}
}
