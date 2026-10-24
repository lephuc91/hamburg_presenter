using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Entity.Persistence;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class LegacyMediaImportHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public LegacyMediaImportHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsMediaFile() ?? false;
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
				string text = item.TargetFolder ?? (Advanced.Settings.ManageMediaAutomatically ? CommonPaths.MediaAssets : Path.GetDirectoryName(item.FullName));
				text.ThrowWhenNull("targetFolder");
				handlingComplete(item, RequestHandlerType.Media, new FileImportResult(item.FullName, text, _fileCreator, _collectionStorage));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
