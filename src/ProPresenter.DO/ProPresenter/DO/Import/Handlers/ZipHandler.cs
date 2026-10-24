using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility.Zip;
using Pro.Localization.Services;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class ZipHandler : IRequestHandler
{
	private readonly IZipService _zipService;

	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly ILocalization _localization;

	public ZipHandler(IZipService zipService, IFileSystem fileSystem, ILogger logger, ILocalization localization)
	{
		_zipService = zipService;
		_fileSystem = fileSystem;
		_logger = logger;
		_localization = localization;
	}

	public bool CanHandle(IImportRequest request)
	{
		if (request is FileImportRequest fileImportRequest)
		{
			return fileImportRequest.FullName.IsZipFile();
		}
		return false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest request in from FileImportRequest r in requests
			where _fileSystem.File.Exists(r.FullName)
			select r)
		{
			try
			{
				updateStatus(request, ImportStatus.Extracting);
				string fullName = request.FullName;
				string fileNameWithoutExtension = _fileSystem.Path.GetFileNameWithoutExtension(fullName);
				string directoryName = _fileSystem.Path.GetDirectoryName(fullName);
				directoryName = _fileSystem.Path.Combine(directoryName, fileNameWithoutExtension);
				_zipService.UnzipFile(fullName, directoryName);
				string[] files = _fileSystem.Directory.GetFiles(directoryName, "*.*", SearchOption.AllDirectories);
				if (files.Any())
				{
					files.ForEach(delegate(string f)
					{
						FileImportRequest newRequest = new FileImportRequest(f)
						{
							TargetFolder = request.TargetFolder,
							CompleteCallback = request.CompleteCallback,
							ParentRequest = request,
							OverWriteOnConflict = request.OverWriteOnConflict
						};
						addRequest(request, newRequest);
					});
					handlingComplete(request, RequestHandlerType.Unknown, new NOPResult());
				}
				else
				{
					handlingComplete(request, RequestHandlerType.Unknown, new ErrorResult(_localization.Get("IMPORT_ERROR_BUNDLE_NO_FILES_FOUND_description"), string.Format(_localization.Get("IMPORT_ERROR_BUNDLE_NO_FILES_FOUND_info"), request.FullName)));
				}
			}
			catch (Exception ex)
			{
				_logger.Error("[{0}] Failed to extract zip file:\n{1}", GetType().Name, ex);
				handlingComplete(request, RequestHandlerType.Unknown, new ErrorResult(_localization.Get("IMPORT_ERROR_UNZIP_description"), string.Format(_localization.Get("IMPORT_ERROR_UNZIP_info"), request.FullName)));
			}
		}
	}
}
