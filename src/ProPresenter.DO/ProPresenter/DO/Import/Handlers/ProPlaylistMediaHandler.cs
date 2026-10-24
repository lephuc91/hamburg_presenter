using System;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.DO.Storage;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class ProPlaylistMediaHandler(bool ImportMediaWithMediaManagement) : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.IsPlaylist ?? false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (FileImportRequest request in requests.OfType<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(request, ImportStatus.Importing);
			try
			{
				if (!ProtoHelper.TryReadFile<PlaylistDocument>(request.FullName, out PlaylistDocument data))
				{
					continue;
				}
				data?.RootNode.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media m)
				{
					RelativePath relativePath = new RelativePath(m.Url);
					if (relativePath.IsValid && (request.ForceManageMedia || Advanced.Settings.ManageMediaAutomatically))
					{
						string text = relativePath.FullPath ?? string.Empty;
						FileImportRequest newRequest = new FileImportRequest(text)
						{
							TargetFolder = (ImportMediaWithMediaManagement ? null : ((text.IsMediaFile() || text.IsPDFFile()) ? CommonPaths.MediaAssets : null)),
							ForceManageMedia = true,
							ParentRequest = request,
							OverWriteOnConflict = request.OverWriteOnConflict
						};
						addRequest(request, newRequest);
					}
				}, null);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(request, RequestHandlerType.Unknown, null);
			}
		}
	}
}
