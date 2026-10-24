using System;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.DO.Utility;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class ProPresentationHandler : IRequestHandler
{
	private readonly IImportLocationSelectionDialogService _importLocationSelectionDialogService;

	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public ProPresentationHandler(IImportLocationSelectionDialogService importLocationSelectionDialogService, IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_importLocationSelectionDialogService = importLocationSelectionDialogService;
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsProPresentationFile() ?? false;
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
			updateStatus(item, ImportStatus.Importing);
			try
			{
				if (item.Filename.HasExtension(".proBundle"))
				{
					throw new NotImplementedException();
				}
				string fullName = item.FullName;
				if ((bool)ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(fullName, out Pro.SerializationInterop.RVProtoData.Presentation data))
				{
					if ((item.ForceManageMedia || Advanced.Settings.ManageMediaAutomatically) && process.FileChangedLibrary != null)
					{
						data?.Relink(process.FileChangedLibrary.GetNewName);
					}
					else
					{
						data?.ReGuidMedia();
					}
					if (data != null)
					{
						data.Uuid = Guid.NewGuid().ToUUID();
					}
					if ((bool)FileHelper.WaitForFileAccess(fullName, enforceFileExists: false, null))
					{
						ProtoHelper.WriteFile(fullName, data);
					}
				}
				if (process.SelectedLibrary == null)
				{
					process.Dispatcher?.Invoke(delegate
					{
						ILibraryAndPlaylistDestinationSelection libraryAndPlaylistDestinationSelection = _importLocationSelectionDialogService.ShowImportLocationSelectionDialog(process);
						if (libraryAndPlaylistDestinationSelection.IsCancel)
						{
							process.CancelImport();
						}
						else
						{
							process.SelectedLibrary = libraryAndPlaylistDestinationSelection.Library;
							if (process.AllowSelectPlaylist)
							{
								process.SelectedPlaylist = libraryAndPlaylistDestinationSelection.Playlist;
							}
						}
					});
				}
				if (process.ImportCanceled)
				{
					break;
				}
				string target = item.TargetFolder ?? string.Empty;
				if (string.IsNullOrWhiteSpace(target) && (object)process.SelectedLibrary?.Location != null)
				{
					process.Dispatcher?.Invoke(() => target = process.SelectedLibrary.Location);
				}
				if (process.ImportCanceled)
				{
					break;
				}
				handlingComplete(item, RequestHandlerType.Presentation, new FileImportResult(item.FullName, target, _fileCreator, _collectionStorage));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
