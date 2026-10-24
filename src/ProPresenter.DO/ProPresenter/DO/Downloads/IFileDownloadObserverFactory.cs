using System;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.Downloads;

public interface IFileDownloadObserverFactory
{
	IFileDownloadObserver? CreateForProContent(ProContentFileDownload fileDownload, VisualPlaylist playlist, Action<IDownloadObserverCallbackData>? importCallback = null);
}
