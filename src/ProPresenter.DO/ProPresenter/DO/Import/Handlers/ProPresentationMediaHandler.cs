using System;
using System.Collections.Generic;
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

internal class ProPresentationMediaHandler(bool ImportMediaWithMediaManagement) : IRequestHandler
{
	private class MediaFileComparer : IEqualityComparer<FileImportRequest>
	{
		public bool Equals(FileImportRequest? x, FileImportRequest? y)
		{
			if (x == null || y == null)
			{
				return false;
			}
			return string.Equals(x.FullName, y.FullName, StringComparison.OrdinalIgnoreCase);
		}

		public int GetHashCode(FileImportRequest obj)
		{
			return obj.FullName?.ToLower().GetHashCode() ?? 0;
		}
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
		foreach (FileImportRequest request in requests.OfType<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(request, ImportStatus.Importing);
			try
			{
				if (!ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(request.FullName, out Pro.SerializationInterop.RVProtoData.Presentation data))
				{
					continue;
				}
				List<FileImportRequest> mediaToAdd = new List<FileImportRequest>();
				data?.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media m)
				{
					RelativePath relativePath = new RelativePath(m.Url);
					if (relativePath.IsValid && (request.ForceManageMedia || Advanced.Settings.ManageMediaAutomatically))
					{
						string text = relativePath.FullPath ?? string.Empty;
						FileImportRequest item = new FileImportRequest(text)
						{
							TargetFolder = (ImportMediaWithMediaManagement ? null : ((text.IsMediaFile() || text.IsPDFFile()) ? CommonPaths.MediaAssets : null)),
							ForceManageMedia = true,
							ParentRequest = request.ParentRequest,
							OverWriteOnConflict = request.OverWriteOnConflict
						};
						mediaToAdd.Add(item);
					}
				});
				foreach (FileImportRequest item2 in mediaToAdd.Distinct(new MediaFileComparer()))
				{
					addRequest(request, item2);
				}
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(request, RequestHandlerType.Unknown, null);
			}
		}
	}
}
