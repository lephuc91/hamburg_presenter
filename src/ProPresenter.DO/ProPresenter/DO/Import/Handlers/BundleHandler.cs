using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Common.Utility.Zip;
using Pro.Localization;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class BundleHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.FullName.IsBundleFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest request in from FileImportRequest r in requests
			where File.Exists(r.FullName)
			select r)
		{
			try
			{
				string tempDirectory = ImportHelper.GetTempDirectory();
				request.FullName.UnzipFile(tempDirectory, new BundlePathStrategy());
				string[] files = Directory.GetFiles(tempDirectory, "*.*", SearchOption.AllDirectories);
				if (files.Any())
				{
					files.ForEach(delegate(string f)
					{
						addRequest(request, BundleImportHelper.CreateImportRequest(request, f));
					});
					handlingComplete(request, RequestHandlerType.Unknown, new NOPResult());
				}
				else
				{
					handlingComplete(request, RequestHandlerType.Unknown, new ErrorResult(LocalizedStrings.Get("IMPORT_ERROR_BUNDLE_NO_FILES_FOUND_description"), string.Format(LocalizedStrings.Get("IMPORT_ERROR_BUNDLE_NO_FILES_FOUND_info"), request.FullName)));
				}
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(request, RequestHandlerType.Unknown, new ErrorResult(LocalizedStrings.Get("IMPORT_ERROR_UNZIP_description"), string.Format(LocalizedStrings.Get("IMPORT_ERROR_UNZIP_info"), request.FullName)));
			}
		}
	}
}
