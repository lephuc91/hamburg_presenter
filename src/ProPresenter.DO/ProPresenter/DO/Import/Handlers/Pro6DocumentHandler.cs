using System;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6DocumentHandler : IRequestHandler
{
	protected virtual ProMigrationType MigrationType => ProMigrationType.Presentation;

	protected virtual string FileExtension => ".pro";

	public bool CanHandle(IImportRequest request)
	{
		return CanHandleDocument(request);
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
			updateStatus(importRequest, ImportStatus.Migrating);
			try
			{
				FileImportRequest fileImportRequest = (FileImportRequest)importRequest;
				if (fileImportRequest.Filename.HasExtension(".pro6x"))
				{
					throw new NotImplementedException();
				}
				string tempFile = ImportHelper.GetTempFile(FileExtension);
				if (proCore == null || proCore.MigrateDocument(fileImportRequest.FullName, tempFile, MigrationType) != 0)
				{
					throw new Exception("Failed to migrate Pro6 to Pro7 document");
				}
				fileImportRequest.ChangeFile(tempFile);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(importRequest, RequestHandlerType.Unknown, null);
			}
		}
	}

	protected virtual bool CanHandleDocument(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsPro6DocumentFile() ?? false;
	}
}
