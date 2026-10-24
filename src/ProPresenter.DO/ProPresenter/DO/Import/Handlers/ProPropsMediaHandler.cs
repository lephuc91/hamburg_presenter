using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.DO.Storage;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class ProPropsMediaHandler(bool ImportMediaWithMediaManagement) : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Name;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return Path.GetFileNameWithoutExtension(text).Equals("Props");
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
		foreach (FileImportRequest request in requests.OfType<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(request, ImportStatus.Importing);
			try
			{
				if (!ProtoHelper.TryReadFile<PropDocument>(request.FullName, out PropDocument data))
				{
					continue;
				}
				data?.Cues.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media m)
				{
					RelativePath relativePath = new RelativePath(m.Url);
					if (relativePath.IsValid)
					{
						string fullPath = relativePath.FullPath;
						FileImportRequest newRequest = new FileImportRequest(fullPath)
						{
							TargetFolder = (ImportMediaWithMediaManagement ? null : ((fullPath.IsMediaFile() || fullPath.IsPDFFile()) ? CommonPaths.MediaAssets : null)),
							ParentRequest = request,
							ForceManageMedia = ImportMediaWithMediaManagement,
							OverWriteOnConflict = request.OverWriteOnConflict
						};
						addRequest(request, newRequest);
					}
				});
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(request, RequestHandlerType.Unknown, null);
			}
		}
	}
}
