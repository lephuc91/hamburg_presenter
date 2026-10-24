using System;
using System.IO.Abstractions;
using Pro.DO.Transitions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Downloads;

public class FileDownloadObserverFactory : IFileDownloadObserverFactory
{
	private readonly IFileSystem _fileSystem;

	private readonly IImport _import;

	private readonly IApp _app;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public FileDownloadObserverFactory(IFileSystem fileSystem, IImport import, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_fileSystem = fileSystem;
		_import = import;
		_app = app;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	public IFileDownloadObserver? CreateForProContent(ProContentFileDownload? fileDownload, VisualPlaylist playlist, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		if (fileDownload == null)
		{
			return null;
		}
		return new ProContentFileDownloadObserver(fileDownload, playlist, importCallback, _fileSystem, _import, _app, _mediaFactory, _transitionDescriptions);
	}
}
