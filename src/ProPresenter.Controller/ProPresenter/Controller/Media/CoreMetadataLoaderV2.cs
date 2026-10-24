using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;
using ProPresenter.DO;
using ProPresenter.DO.Media;

namespace ProPresenter.Controller.Media;

public class CoreMetadataLoaderV2 : IMetadataLoader
{
	private readonly IMediaServiceV2 _mediaService;

	private readonly IImageLoader _imageLoader;

	private readonly IMediaMetadataCacheService _metadataCache;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IFileService _fileService;

	private readonly ILogger _logger;

	public IObservable<IMetadataLoader.IIdentifiedResult> WhenMediaReferenceChanged { get; }

	public CoreMetadataLoaderV2(IMediaServiceV2 mediaService, IImageLoader imageLoader, IMediaMetadataCacheService metadataCache, IAsyncExecutor asyncExecutor, IFileService fileService, ILogger logger, IUiScheduler uiScheduler)
	{
		_mediaService = mediaService;
		_imageLoader = imageLoader;
		_metadataCache = metadataCache;
		_asyncExecutor = asyncExecutor;
		_fileService = fileService;
		_logger = logger;
		WhenMediaReferenceChanged = mediaService.WhenMediaReferenceChanged.Select((Func<IMediaServiceResponse, IMetadataLoader.IIdentifiedResult>)delegate(IMediaServiceResponse r)
		{
			if (r is MediaServiceOkResponse<MediaReference> mediaServiceOkResponse)
			{
				IMetadataLoader.IResult result2;
				if (mediaServiceOkResponse.Data.Success == null)
				{
					IMetadataLoader.IResult result = new IMetadataLoader.FailedResult();
					result2 = result;
				}
				else
				{
					IMetadataLoader.IResult result = mediaServiceOkResponse.Data.Success.ToSuccessfulResult(imageLoader);
					result2 = result;
				}
				IMetadataLoader.IResult result3 = result2;
				return new IMetadataLoader.UuidIdentifiedResult(mediaServiceOkResponse.Data.Id.ContainerId, Guid.Parse(mediaServiceOkResponse.Data.Id.Uuid), result3);
			}
			if (r is MediaServiceOkResponse<ImportSuccessData> mediaServiceOkResponse2)
			{
				IMetadataLoader.IResult result4;
				if (mediaServiceOkResponse2.Data.FinalUrl == null)
				{
					IMetadataLoader.IResult result = new IMetadataLoader.FailedResult();
					result4 = result;
				}
				else
				{
					IMetadataLoader.IResult result = new IMetadataLoader.ImportedResult(mediaServiceOkResponse2.Data.ContainerId, mediaServiceOkResponse2.Data.MediaReferenceId, mediaServiceOkResponse2.Data.FinalUrl);
					result4 = result;
				}
				IMetadataLoader.IResult result5 = result4;
				return new IMetadataLoader.UuidIdentifiedResult(mediaServiceOkResponse2.Data.ContainerId, mediaServiceOkResponse2.Data.MediaReferenceId, result5);
			}
			if (r is IMediaServiceErrorResponse { MediaReferenceId: not null } mediaServiceErrorResponse)
			{
				return new IMetadataLoader.UuidIdentifiedResult(mediaServiceErrorResponse.ContainerId, mediaServiceErrorResponse.MediaReferenceId.Value, new IMetadataLoader.FailedResult());
			}
			throw new NotSupportedException("Unsupported Media Service Response encountered \"" + r.GetType().Name + "\"");
		}).ObserveOn(uiScheduler.Scheduler);
	}

	public WatcherReference? StartWatchingMediaFile(string path)
	{
		return null;
	}

	public async Task<IMetadataLoader.IResult> LoadMetadataAsync(MediaMetadataRequest request, bool applyTransform = false)
	{
		RequestEnvelope.Types.GetMediaReference request2 = new RequestEnvelope.Types.GetMediaReference
		{
			Id = new ReferenceIdentifier
			{
				ContainerId = request.ContainerID,
				Uuid = request.TargetID.ToString()
			}
		};
		_logger.Info("Loading Metadata for {0} - {1} - {2}", request.ContainerID, request.TargetID.ToString(), request.Filename);
		try
		{
			if (!(await _mediaService.GetMedia(request2).ConfigureAwait(continueOnCapturedContext: false) is MediaServiceOkResponse<ResponseEnvelope.Types.GetMediaReferenceResponse> mediaServiceOkResponse) || mediaServiceOkResponse.Data?.State?.Error != null)
			{
				return new IMetadataLoader.FailedResult();
			}
			if (mediaServiceOkResponse.Data?.State?.Progress != null)
			{
				return new IMetadataLoader.PendingResult();
			}
			MediaReferenceInfo mediaReferenceInfo = mediaServiceOkResponse.Data?.State?.Success;
			if (mediaReferenceInfo == null)
			{
				if (!_fileService.FileExists(request.Filename))
				{
					_logger.Info("Metadata load failed; Source File does not exist: {0} - {1} - {2}", request.ContainerID, request.TargetID.ToString(), request.Filename);
					return new IMetadataLoader.FailedResult();
				}
				if (!string.IsNullOrEmpty(request.ProContentDownloadId))
				{
					_logger.Info("ProContent media reference should already exist from AddProContentReference; returning Pending result: {0} - {1} - {2} - {3}", request.ContainerID, request.TargetID.ToString(), request.Filename, request.ProContentDownloadId);
					return new IMetadataLoader.PendingResult();
				}
				_logger.Info("Failed fetching metadata due to it not being added; attempting to add it: {0} - {1} - {2}", request.ContainerID, request.TargetID.ToString(), request.Filename);
				Task<IMediaServiceResponse> addTask = AddNewMediaReferenceAsync(request);
				if (_metadataCache.TryGetCachedMetadata(request, out string previewImagePath, out MediaMetadata mediaMetadata))
				{
					_asyncExecutor.ExecuteAsync(async delegate
					{
						if (await addTask.ConfigureAwait(continueOnCapturedContext: false) is MediaServiceV2ErrorResponse<RequestError> mediaServiceV2ErrorResponse)
						{
							if (mediaServiceV2ErrorResponse.Error.Code == RequestError.Types.ErrorCode.Conflict)
							{
								_logger.Warning("Attempted to add the same media reference more than once {0} - {1} - {2} - {3} - {4}", request.ContainerID, request.TargetID.ToString(), request.Filename, mediaServiceV2ErrorResponse.Error.Code, mediaServiceV2ErrorResponse.Error.Description);
							}
							else
							{
								_logger.Error("Error Adding media Reference for for Media {0} - {1} - {2} - {3} - {4}", request.ContainerID, request.TargetID.ToString(), request.Filename, mediaServiceV2ErrorResponse.Error.Code, mediaServiceV2ErrorResponse.Error.Description);
							}
						}
					});
					_logger.Info("Using Legacy cached metadata for {0} - {1}", request.TargetID.ToString(), request.Filename);
					return new IMetadataLoader.SuccessfulResult(mediaMetadata, _imageLoader.LoadImage(previewImagePath));
				}
				if (await addTask.ConfigureAwait(continueOnCapturedContext: false) is MediaServiceV2ErrorResponse<RequestError> mediaServiceV2ErrorResponse2)
				{
					if (mediaServiceV2ErrorResponse2.Error.Code != RequestError.Types.ErrorCode.Conflict)
					{
						_logger.Error("Error Adding media Reference for for Media, returning Failed result {0} - {1} - {2} - {3} - {4}", request.ContainerID, request.TargetID.ToString(), request.Filename, mediaServiceV2ErrorResponse2.Error.Code, mediaServiceV2ErrorResponse2.Error.Description);
						return new IMetadataLoader.FailedResult();
					}
					_logger.Warning("Attempted to add the same media reference more than once, returning Pending result {0} - {1} - {2} - {3} - {4}", request.ContainerID, request.TargetID.ToString(), request.Filename, mediaServiceV2ErrorResponse2.Error.Code, mediaServiceV2ErrorResponse2.Error.Description);
				}
				return new IMetadataLoader.PendingResult();
			}
			if (applyTransform)
			{
				await _mediaService.ApplyTransformation(request.ToApplyTransformRequestV2());
				return new IMetadataLoader.PendingResult();
			}
			return mediaReferenceInfo.ToSuccessfulResult(_imageLoader);
		}
		catch (MediaApplicationException)
		{
			_logger.Warning("Error encountered loading metadata for {0} - {1} - {2}", request.ContainerID, request.TargetID.ToString(), request.Filename);
			return new IMetadataLoader.FailedResult();
		}
	}

	private async Task<IMediaServiceResponse> AddNewMediaReferenceAsync(MediaMetadataRequest request)
	{
		return await _mediaService.AddMediaReference(request.ToAddMediaRequestV2(includeTransformation: true));
	}
}
