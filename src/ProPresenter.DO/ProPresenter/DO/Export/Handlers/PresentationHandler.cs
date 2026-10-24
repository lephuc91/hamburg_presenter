using System.IO.Abstractions;
using Pro.Common.Strings;
using Pro.DO.Storage;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export.Handlers;

public class PresentationHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	public PresentationHandler(IFileSystem fileSystem, IFileService fileService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
	}

	public bool CanHandle(IExportRequest request)
	{
		if (request is DocumentExportRequest documentExportRequest)
		{
			return documentExportRequest.DocumentExportOption == DocumentExportOption.Document;
		}
		return false;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		if (!(request is DocumentExportRequest documentExportRequest))
		{
			return;
		}
		foreach (IPresentation document in documentExportRequest.Documents)
		{
			if (process.ExportCanceled)
			{
				break;
			}
			request.CurrentItemName = document.Name;
			string destination = process.Destination;
			RelativePath sourceFile = document.SourceFile;
			string text = document.Name + ".pro";
			string text2 = _fileSystem.Path.Combine(destination, text);
			if (_fileSystem.File.Exists(sourceFile))
			{
				if (_fileSystem.File.Exists(text2))
				{
					ConflictResolveResult conflictResolveResult = resolveConflict(text, destination);
					if (conflictResolveResult == ConflictResolveResult.Abort)
					{
						break;
					}
					string[] files = _fileSystem.Directory.GetFiles(destination);
					string fileNameWithoutExtension = _fileSystem.Path.GetFileNameWithoutExtension(text2);
					string text3 = ((conflictResolveResult == ConflictResolveResult.NewVersion) ? fileNameWithoutExtension.DuplicateName(files, _fileSystem.Path.GetFileNameWithoutExtension) : fileNameWithoutExtension);
					text2 = _fileSystem.Path.Combine(destination, text3 + ".pro");
				}
				if ((bool)_fileService.WaitForFileAccess(text2, enforceFileExists: false, null))
				{
					_fileSystem.File.Copy(sourceFile, text2, overwrite: true);
				}
			}
			updateStatus(request);
		}
	}
}
