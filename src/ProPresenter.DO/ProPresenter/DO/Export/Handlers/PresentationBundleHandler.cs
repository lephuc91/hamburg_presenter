using System.IO.Abstractions;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export.Handlers;

internal class PresentationBundleHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	public PresentationBundleHandler(IFileSystem fileSystem, IFileService fileService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
	}

	public bool CanHandle(IExportRequest request)
	{
		DocumentExportRequest obj = request as DocumentExportRequest;
		if (obj == null)
		{
			return false;
		}
		return obj.DocumentExportOption == DocumentExportOption.Bundle;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		string exportPath = _fileSystem.Path.Combine(CommonPaths.Temp, "BundleExport");
		string mediaSub = _fileSystem.Path.Combine(exportPath, "Media");
		string pdfSub = _fileSystem.Path.Combine(exportPath, "PDF");
		if (_fileSystem.Directory.Exists(exportPath))
		{
			_fileSystem.Directory.Delete(exportPath, recursive: true);
		}
		_fileSystem.Directory.CreateDirectory(exportPath);
		_fileSystem.Directory.CreateDirectory(mediaSub);
		_fileSystem.Directory.CreateDirectory(pdfSub);
		if (request is DocumentExportRequest)
		{
			foreach (IPresentation document in ((DocumentExportRequest)request).Documents)
			{
				if (process.ExportCanceled)
				{
					break;
				}
				request.CurrentItemName = document.Name;
				updateStatus(request);
				document.FindMedia(copyFile);
			}
		}
		request.CurrentItemName = process.Destination;
		request.Archiving = true;
		updateStatus(request);
		if (_fileSystem.File.Exists(process.Destination) && (bool)FileHelper.WaitForFileAccess(process.Destination, enforceFileExists: false, null))
		{
			_fileSystem.File.Delete(process.Destination);
		}
		ZipHelper.ZipFolder(exportPath, process.Destination);
		void copyFile(string file)
		{
			if (!process.ExportCanceled)
			{
				string fileName = _fileSystem.Path.GetFileName(file);
				string text = (fileName.IsMediaFile() ? mediaSub : (fileName.IsPDFFile() ? pdfSub : (fileName.IsProPresentationFile() ? exportPath : string.Empty)));
				if (!string.IsNullOrWhiteSpace(text) && _fileSystem.File.Exists(file))
				{
					string text2 = _fileSystem.Path.Combine(text, fileName);
					if ((bool)_fileService.WaitForFileAccess(text2, enforceFileExists: false, null))
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
