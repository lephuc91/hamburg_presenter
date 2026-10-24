using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility.Zip;
using Pro.DO.Storage;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class BundledThemeHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	private readonly IZipService _zipService;

	public BundledThemeHandler(IFileSystem fileSystem, IFileService fileService, IZipService zipService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
		_zipService = zipService;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsProThemeFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			try
			{
				updateStatus(item, ImportStatus.Importing);
				string tempDirectory = _fileService.GetTempDirectory();
				_zipService.UnzipFile(item.FullName, tempDirectory);
				foreach (RelativePath item2 in from d in _fileSystem.Directory.GetDirectories(tempDirectory)
					select new RelativePath(d))
				{
					_fileService.GetTempFile(".proTheme");
					string tempDirectory2 = _fileService.GetTempDirectory();
					string text = _fileSystem.Path.Combine(tempDirectory2, item2.Name);
					_fileSystem.Directory.CreateDirectory(text);
					_fileService.CopyFiles(item2, text, overwrite: true);
					addRequest(item, new FileImportRequest(text)
					{
						Source = item.Source,
						ParentRequest = item,
						OverWriteOnConflict = item.OverWriteOnConflict
					});
				}
				handlingComplete(item, RequestHandlerType.Unknown, new NOPResult());
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
