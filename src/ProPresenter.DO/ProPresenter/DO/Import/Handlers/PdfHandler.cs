using System;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Entity.Persistence;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class PdfHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public PdfHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsPDFFile() ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, requests, updateStatus, handlingComplete);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete)
	{
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			try
			{
				if (process.ImportCanceled)
				{
					break;
				}
				updateStatus(item, ImportStatus.Importing);
				handlingComplete(item, RequestHandlerType.Media, new FileImportResult(item.FullName, CommonPaths.MediaAssets, _fileCreator, _collectionStorage));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
