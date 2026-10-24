using System;
using System.IO;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class PlainTextHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsTextFile() ?? false;
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
			updateStatus(importRequest, ImportStatus.Converting);
			try
			{
				FileImportRequest obj = (FileImportRequest)importRequest;
				obj.SetPlainText(File.ReadAllText(obj.FullName));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
		}
	}
}
