using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.CoreApplication.PowerPoint;
using Pro.Localization.Services;
using ProPresenter.DO.Analytics.Events.PowerPoint;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.PowerPoint;
using ProPresenter.DO.Presentation;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class PowerPointHandler : IRequestHandler
{
	private readonly IPresentationFactory _presentationFactory;

	private readonly IPowerPointImageLoader _powerPointImageLoader;

	private readonly IPowerPointEvents _powerPointEvents;

	private readonly IPowerPointImportService _powerPointImportService;

	private readonly IFileSystem _fileSystem;

	private readonly ILocalization _localization;

	private readonly IImportLocationSelectionDialogService _importLocationSelectionDialogService;

	public PowerPointHandler(IPresentationFactory presentationFactory, IPowerPointImageLoader powerPointImageLoader, IPowerPointEvents powerPointEvents, IPowerPointImportService powerPointImportService, IFileSystem fileSystem, ILocalization localization, IImportLocationSelectionDialogService importLocationSelectionDialogService)
	{
		_presentationFactory = presentationFactory;
		_powerPointImageLoader = powerPointImageLoader;
		_powerPointEvents = powerPointEvents;
		_powerPointImportService = powerPointImportService;
		_fileSystem = fileSystem;
		_localization = localization;
		_importLocationSelectionDialogService = importLocationSelectionDialogService;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsPowerPointFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (IImportRequest importRequest in requests)
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(importRequest, ImportStatus.Importing);
			bool flag = true;
			try
			{
				if (!(importRequest is FileImportRequest request2))
				{
					continue;
				}
				Vector2<double> importSize = Vector2<double>.Zero;
				process.Dispatcher.Invoke(delegate
				{
					IPowerpointDestinationSelection powerpointDestinationSelection = _importLocationSelectionDialogService.ShowImportPowerpointSelectionDialog(process);
					if (powerpointDestinationSelection.IsCancel)
					{
						process.CancelImport();
					}
					else
					{
						process.SelectedLibrary = powerpointDestinationSelection.Library;
						process.SelectedPlaylist = powerpointDestinationSelection.Playlist;
						importSize = powerpointDestinationSelection.Size;
					}
				});
				if (process.ImportCanceled)
				{
					break;
				}
				var (flag2, ignoreBackgrounds) = UseCoreImport(process, request2);
				if (flag2)
				{
					if (_powerPointImportService.TryCreatePresentationFromPPTX(GetTargetFilename(request2), importSize, ignoreBackgrounds, out string resultsFolder, out int errorCode))
					{
						string[] files = _fileSystem.Directory.GetFiles(resultsFolder);
						foreach (string fileName in files)
						{
							addRequest(importRequest, BundleImportHelper.CreateImportRequest(request2, fileName));
						}
						flag = false;
						handlingComplete(importRequest, RequestHandlerType.Presentation, new NOPResult());
					}
					else
					{
						handlingComplete(importRequest, RequestHandlerType.Presentation, new ErrorResult(_localization.Get("IMPORT_POWERPOINT_ERROR_LINE1_title"), ErrorCodeToString(errorCode, _localization)));
					}
				}
				else
				{
					handlingComplete(importRequest, RequestHandlerType.Presentation, new PowerPointImportResult(getImages(importRequest, importSize).ToArray(), _presentationFactory, _powerPointImageLoader, importSize));
				}
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
			finally
			{
				_powerPointEvents.ImportFromFile(((FileImportRequest)importRequest).FullName, (!flag) ? PowerPointImportType.CoreOpenXml : PowerPointImportType.SlidesAsImages);
			}
		}
		IEnumerable<PowerPointSlideImportData> getImages(IImportRequest request, Vector2<double> size)
		{
			string fullName = ((FileImportRequest)request).FullName;
			return PowerPointHelper.GetImportData(process.Dispatcher.Invoke(() => (Application.Current.MainWindow == null) ? IntPtr.Zero : new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle()), fullName, size);
		}
	}

	private static (bool useCoreImport, bool ignoreBackgrounds) UseCoreImport(ImportProcess process, FileImportRequest request)
	{
		if (process.PowerPointInfo != null)
		{
			return (useCoreImport: !process.PowerPointInfo.UseLegacyPPTImport && request.Filename.IsOpenXmlPowerPointFile(), ignoreBackgrounds: process.PowerPointInfo.IgnoreBackgrounds);
		}
		return (useCoreImport: false, ignoreBackgrounds: false);
	}

	private static string GetTargetFilename(IImportRequest request)
	{
		if (request is FileImportRequest fileImportRequest)
		{
			return fileImportRequest.FullName;
		}
		return string.Empty;
	}

	private static string ErrorCodeToString(int errorCode, ILocalization localization)
	{
		string key = errorCode switch
		{
			101 => "IMPORT_POWERPOINT_CORE_ERROR_UNKNOWN_FORMULA_title", 
			102 => "IMPORT_POWERPOINT_CORE_ERROR_PARSE_ERROR_title", 
			201 => "IMPORT_POWERPOINT_CORE_ERROR_CALL_title", 
			301 => "IMPORT_POWERPOINT_CORE_ERROR_OUTPUT_ERROR_title", 
			401 => "IMPORT_POWERPOINT_CORE_ERROR_SDK_ERROR_title", 
			501 => "IMPORT_POWERPOINT_ERROR_COULD_NOT_ENCODE_title", 
			_ => "", 
		};
		return $"{localization.Get("IMPORT_POWERPOINT_ERROR_LINE2_title")}\n{localization.Get("IMPORT_POWERPOINT_ERROR_CORE_ERROR_title")}: {localization.Get(key)}";
	}
}
