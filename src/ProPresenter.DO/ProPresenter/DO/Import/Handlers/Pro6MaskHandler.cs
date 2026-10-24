using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6MaskHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (text.IsPro6DocumentFile())
			{
				return Path.GetFileNameWithoutExtension(text).Equals("Mask");
			}
			return false;
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
			updateStatus(item, ImportStatus.Migrating);
			try
			{
				string tempFile = ImportHelper.GetTempFile(string.Empty);
				if (proCore == null || proCore.MigrateDocument(item.FullName, tempFile, ProMigrationType.Presentation) != 0)
				{
					throw new Exception("Failed to migrate Pro6 to Pro7 document");
				}
				item.ChangeFile(tempFile);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
