using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Media;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

public class CoreMediaImportHandler(IMediaFactory MediaFactory, IMediaServiceV2 MediaService, IUiDispatcher Dispatcher, IFileSystem FileSystem, IFileCreator FileCreator) : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return (request as FileImportRequest)?.Filename.IsMediaFile() ?? false;
	}

	public async ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		IMediaServiceV2 mediaServiceV2 = MediaService;
		if (mediaServiceV2 == null)
		{
			throw new InvalidOperationException("CoreMediaImportHandler must be provided with a IMediaServiceV2 instance.");
		}
		foreach (FileImportRequest request in requests.Cast<FileImportRequest>().NotNull())
		{
			try
			{
				if (process.ImportCanceled)
				{
					return;
				}
				if (request.IsChordChartImport)
				{
					string mediaImported = CommonPaths.MediaImported;
					string extension = FileSystem.Path.GetExtension(request.Filename);
					string text = FileSystem.Path.GetFileNameWithoutExtension(request.Filename).DuplicateName(FileSystem.Directory.GetFiles(mediaImported), FileSystem.Path.GetFileNameWithoutExtension);
					RelativePath relativePath = (RelativePath)FileSystem.Path.Combine(mediaImported, text + extension);
					request.FinalName = relativePath;
					FileCreator.Copy(request.FullName, relativePath);
					handlingComplete(request, RequestHandlerType.Media, new MediaManagementFileImportResult(null));
					continue;
				}
				FileMediaBase createdMedia = null;
				request.FinalName = request.FullName;
				if (!request.ForceManageMedia)
				{
					if (request.ExistingMedia != null)
					{
						Dispatcher.Invoke(delegate
						{
							request.ExistingMedia.UpdateSource(userInitiated: true, (RelativePath)request.FullName);
						});
					}
					createdMedia = request.ExistingMedia ?? MediaFactory.CreateMedia(request.FullName, request.ContainerId, request.OverrideMediaId);
				}
				else
				{
					createdMedia = request.ExistingMedia ?? MediaFactory.CreateEmptyFileMedia(request.FullName, request.ContainerId, request.OverrideMediaId);
					if (await mediaServiceV2.AddMediaReference(new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.AddMediaReference
					{
						Id = new ReferenceIdentifier
						{
							ContainerId = createdMedia.ContainerId,
							Uuid = createdMedia.ID.ToString()
						},
						Priority = Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.UserInitiated,
						ManageMedia = true,
						Url = request.FullName
					}) is MediaServiceV2ErrorResponse<Pro.SerializationInterop.RVProtoData.MediaManagement.v1.RequestError> mediaServiceV2ErrorResponse)
					{
						throw new InvalidOperationException($"Error importing media \"{request.FullName}\" with ID {createdMedia.ID} and error {mediaServiceV2ErrorResponse.Error.Description}");
					}
					Dispatcher.Invoke(delegate
					{
						createdMedia.UpdateSource(userInitiated: true, (RelativePath)request.FullName);
					});
				}
				handlingComplete(request, RequestHandlerType.Media, new MediaManagementFileImportResult(createdMedia));
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				handlingComplete(request, RequestHandlerType.Media, new ErrorResult("", ex.Message));
			}
		}
	}
}
