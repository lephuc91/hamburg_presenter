using System;
using System.IO;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Text.RTF;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class RTFHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsRTFFile() ?? false;
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
				string rtfData = File.ReadAllText(obj.FullName);
				PlainTextReader plainTextReader = new PlainTextReader();
				obj.SetPlainText(plainTextReader.ReadText(rtfData));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
		}
	}
}
