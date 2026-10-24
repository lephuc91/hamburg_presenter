using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace ProPresenter.DO.Media.Services;

public class MediaManagementV1TrackedMediaHelpers : ITrackedMediaHelpers
{
	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IMediaServiceV1 _mediaService;

	public MediaManagementV1TrackedMediaHelpers(IAsyncExecutor asyncExecutor, IMediaServiceV1 mediaService)
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
				Uuid = media.ID.ToString()
			}) is MediaServiceOkResponse<ResponseEnvelope.Types.GetMediaReferenceResponse> mediaServiceOkResponse && mediaServiceOkResponse.Data?.State?.Progress == null && mediaServiceOkResponse.Data?.State?.Success == null)
			{
				addList.Add(_mediaService.AddMediaReference(media.GenerateMetadataRequest(useUserInitiatedPriority).ToAddMediaRequestV1(applyTransform)));
			}
		}
		return await Task.WhenAll(addList);
	}

	public void RemoveFromMediaService(IReadOnlyList<ITrackedMedia> mediaToRemove, bool _)
	{
		if (mediaToRemove.Count == 0)
		{
			return;
		}
		_asyncExecutor.ExecuteAsync(async delegate
		{
			RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
			removeMediaReferences.Uuid.AddRange(mediaToRemove.Select((ITrackedMedia x) => x.ID.ToString()));
			await _mediaService.RemoveMediaReference(removeMediaReferences);
		});
	}

	public async Task<IMediaServiceResponse> RemoveFromMediaServiceAsync(IReadOnlyList<ITrackedMedia> mediaToRemove, bool _)
	{
		if (mediaToRemove.Count == 0)
		{
			return new MediaServiceOkResponse<RemoveMediaReferenceResponse>(new RemoveMediaReferenceResponse());
		}
		RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
		removeMediaReferences.Uuid.AddRange(mediaToRemove.Select((ITrackedMedia x) => x.ID.ToString()));
		return await _mediaService.RemoveMediaReference(removeMediaReferences);
	}
}
