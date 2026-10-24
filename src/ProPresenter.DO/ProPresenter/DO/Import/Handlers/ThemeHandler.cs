using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Entity.Persistence;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class ThemeHandler : IRequestHandler
{
	public static readonly string MEDIABIN_FOLDER = "MediaBin";

	public static readonly string PRESENTATION_FOLDER = "Presentation";

	public static readonly string SAMPLE_LIBRARY_NAME = "Sample";

	private readonly IThemeService _themeService;

	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	private readonly IFlagService _flagService;

	private readonly IAdvanced _advanced;

	private readonly IMediaFactory _mediaFactory;

	private readonly ILogger _logger;

	private readonly IImportHelperServices _importHelpers;

	private readonly ICollectionStorage _collectionStorage;

	public ThemeHandler(IThemeService themeService, IFileSystem fileSystem, IFileService fileService, IFlagService flagService, IAdvanced advanced, IMediaFactory mediaFactory, ILogger logger, IImportHelperServices importHelpers, ICollectionStorage collectionStorage)
	{
		_themeService = themeService;
		_fileSystem = fileSystem;
		_fileService = fileService;
		_flagService = flagService;
		_advanced = advanced;
		_mediaFactory = mediaFactory;
		_logger = logger;
		_importHelpers = importHelpers;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		if (request is FileImportRequest { ParentRequest: FileImportRequest parentRequest })
		{
			return parentRequest.Filename.IsProThemeFile();
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
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			try
			{
				updateStatus(item, ImportStatus.Importing);
				string filename = item.Filename;
				if (!string.IsNullOrEmpty(filename))
				{
					item.ChangeName(filename);
				}
				string unzippedFolder = _fileSystem.Directory.GetParent(item.FullName)?.FullName ?? string.Empty;
				handlingComplete(item, RequestHandlerType.Theme, new ThemeImportResult(unzippedFolder, _themeService, _mediaFactory, _fileSystem, _fileService, _importHelpers, _collectionStorage, _flagService.IsFlagEnabled(Flag.Cloud) && _advanced.ManageMediaAutomatically));
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
