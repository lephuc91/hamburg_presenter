using System;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Export.Handlers;

internal class PlaylistHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	public PlaylistHandler(IFileSystem fileSystem, IFileService fileService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
	}

	public bool CanHandle(IExportRequest request)
	{
		return request is PlaylistExportRequest;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		string exportPath = _fileSystem.Path.Combine(CommonPaths.Temp, "BundleExport");
		string mediaSub = _fileSystem.Path.Combine(exportPath, "Media");
		string pdfSub = _fileSystem.Path.Combine(exportPath, "PDF");
		_fileService.DeleteDirectory(exportPath);
		_fileSystem.Directory.CreateDirectory(exportPath);
		_fileSystem.Directory.CreateDirectory(mediaSub);
		_fileSystem.Directory.CreateDirectory(pdfSub);
		PlaylistExportRequest playlistExportRequest = (PlaylistExportRequest)request;
		string path = "data";
		IPlaylist<ProPresenterCue>[] array = playlistExportRequest.Playlists.Select((IPlaylist<ProPresenterCue> p) => p.Clone()).ToArray();
		array.FindMedia(copyFile, playlistExportRequest.IncludeMedia);
		PlaylistDocument playlistDocument = new PlaylistDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
			Type = PlaylistDocument.Types.Type.Presentation,
			RootNode = new Playlist
			{
				Uuid = Guid.NewGuid().ToUUID(),
				Type = Playlist.Types.Type.Root,
				Playlists = new Playlist.Types.PlaylistArray()
			}
		};
		playlistDocument.RootNode.Playlists.Playlists.AddRange(array.Select((IPlaylist<ProPresenterCue> p) => p.ProtoSerialize()));
		if (!process.ExportCanceled)
		{
			ProtoHelper.WriteFile(_fileSystem.Path.Combine(exportPath, path), playlistDocument);
			request.CurrentItemName = process.Destination;
			request.Archiving = true;
			updateStatus(request);
			if (_fileSystem.File.Exists(process.Destination) && (bool)_fileService.WaitForFileAccess(process.Destination, enforceFileExists: false, null))
			{
				_fileSystem.File.Delete(process.Destination);
			}
			ZipHelper.ZipFolder(exportPath, process.Destination);
		}
		void copyFile(string file)
		{
			if (!process.ExportCanceled)
			{
				string fileName = _fileSystem.Path.GetFileName(file);
				string text = (fileName.IsMediaFile() ? mediaSub : (fileName.IsPDFFile() ? pdfSub : (fileName.IsProPresentationFile() ? exportPath : string.Empty)));
				if (!string.IsNullOrWhiteSpace(text) && _fileSystem.File.Exists(file))
				{
					string text2 = _fileSystem.Path.Combine(text, fileName);
					if ((bool)FileHelper.WaitForFileAccess(text2, enforceFileExists: false, null))
					{
						request.CurrentItemName = _fileSystem.Path.GetFileName(file);
						updateStatus(request);
						_fileSystem.File.Copy(file, text2, overwrite: true);
					}
				}
			}
		}
	}
}
