using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.ProContent;

namespace ProPresenter.DO.Media.Services;

public class MediaManagementV2TrackedMediaHelpers : ITrackedMediaHelpers
{
	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IMediaServiceV2 _mediaService;

	public MediaManagementV2TrackedMediaHelpers(IAsyncExecutor asyncExecutor, IMediaServiceV2 mediaService)
	{
		_asyncExecutor = asyncExecutor;
		_mediaService = mediaService;
	}

	public void AddToMediaService(IReadOnlyList<ITrackedMedia> mediaToAdd, bool useUserInitiatedPriority, bool applyTransform)
	{
		if (mediaToAdd.Count != 0)
		{
			_asyncExecutor.ExecuteAsync(async delegate
			{
				await AddToMediaServiceAsync(mediaToAdd, useUserInitiatedPriority, applyTransform);
			});
		}
	}

	public async Task<IReadOnlyList<IMediaServiceResponse>> AddToMediaServiceAsync(IReadOnlyList<ITrackedMedia> mediaToAdd, bool useUserInitiatedPriority, bool applyTransform)
	{
		if (mediaToAdd.Count == 0)
		{
			return Array.Empty<IMediaServiceResponse>();
		}
		List<Task<IMediaServiceResponse>> addList = new List<Task<IMediaServiceResponse>>();
		foreach (ITrackedMedia media in mediaToAdd)
		{
			if (await _mediaService.GetMedia(new RequestEnvelope.Types.GetMediaReference
			{
				Id = new ReferenceIdentifier
				{
					ContainerId = media.ContainerId,
					Uuid = media.ID.ToString()
				}
			}) is MediaServiceOkResponse<ResponseEnvelope.Types.GetMediaReferenceResponse> mediaServiceOkResponse && mediaServiceOkResponse.Data?.State?.Progress == null && mediaServiceOkResponse.Data?.State?.Success == null)
			{
				if (media is IFileMedia fileMedia && fileMedia.File.RemoteProperties is ProContentFileProperties proContentFileProperties && !string.IsNullOrEmpty(proContentFileProperties.RelativePath))
				{
					addList.Add(_mediaService.AddProContentReference(new AddProContentReference
					{
						Id = new ReferenceIdentifier
						{
							ContainerId = media.ContainerId,
							Uuid = media.ID.ToString()
						},
						Priority = (useUserInitiatedPriority ? Priority.UserInitiated : Priority.Background),
						DownloadDetails = new ProContentDownloadDetails
						{
							AssetIdentifier = proContentFileProperties.DownloadId,
							DisplayName = (proContentFileProperties.DisplayName ?? string.Empty),
							DownloadUrl = (proContentFileProperties.DownloadUrl ?? string.Empty),
							ThumbnailUrl = (proContentFileProperties.ThumbnailUrl ?? string.Empty),
							RelativePath = proContentFileProperties.RelativePath,
							AssetType = proContentFileProperties.AssetType.ToProtoAssetType()
						}
					}));
				}
				else
				{
					addList.Add(_mediaService.AddMediaReference(media.GenerateMetadataRequest(useUserInitiatedPriority).ToAddMediaRequestV2(applyTransform)));
				}
			}
		}
		return await Task.WhenAll(addList);
	}

	public void RemoveFromMediaService(IReadOnlyList<ITrackedMedia> mediaToRemove, bool deleteAssets)
	{
		if (mediaToRemove.Count == 0)
		{
			return;
		}
		_asyncExecutor.ExecuteAsync(async delegate
		{
			RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
			removeMediaReferences.Id.AddRange(mediaToRemove.Select((ITrackedMedia x) => new ReferenceIdentifier
			{
				ContainerId = x.ContainerId,
				Uuid = x.ID.ToString()
			}));
			removeMediaReferences.DeleteAsset = deleteAssets;
			await _mediaService.RemoveMediaReference(removeMediaReferences);
		});
	}

	public async Task<IMediaServiceResponse> RemoveFromMediaServiceAsync(IReadOnlyList<ITrackedMedia> mediaToRemove, bool deleteAssets)
	{
		if (mediaToRemove.Count == 0)
		{
			return new MediaServiceOkResponse<RemoveMediaReferenceResponse>(new RemoveMediaReferenceResponse());
		}
		RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
		removeMediaReferences.Id.AddRange(mediaToRemove.Select((ITrackedMedia x) => new ReferenceIdentifier
		{
			ContainerId = x.ContainerId,
			Uuid = x.ID.ToString()
		}));
		removeMediaReferences.DeleteAsset = deleteAssets;
		return await _mediaService.RemoveMediaReference(removeMediaReferences);
	}
}
