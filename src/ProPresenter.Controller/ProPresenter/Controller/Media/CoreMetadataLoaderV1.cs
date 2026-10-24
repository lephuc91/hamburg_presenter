using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;
using ProPresenter.DO;
using ProPresenter.DO.Media;

namespace ProPresenter.Controller.Media;

public class CoreMetadataLoaderV1 : IMetadataLoader
{
	private readonly IMediaServiceV1 _mediaService;

	private readonly IImageLoader _imageLoader;

	private readonly IMediaMetadataCacheService _metadataCache;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IFileService _fileService;

	private readonly ILogger _logger;

	private readonly IFileObservatory _fileObservatory;

	public IObservable<IMetadataLoader.IIdentifiedResult> WhenMediaReferenceChanged { get; }

	public CoreMetadataLoaderV1(IMediaServiceV1 mediaService, IImageLoader imageLoader, IMediaMetadataCacheService metadataCache, IAsyncExecutor asyncExecutor, IFileService fileService, ILogger logger, IUiScheduler uiScheduler, IFileObservatory fileObservatory)
	{
		_mediaService = mediaService;
		_imageLoader = imageLoader;
		_metadataCache = metadataCache;
		_asyncExecutor = asyncExecutor;
		_fileService = fileService;
		_logger = logger;
		_fileObservatory = fileObservatory;
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
				return new IMetadataLoader.UuidIdentifiedResult(null, Guid.Parse(mediaServiceOkResponse.Data.Uuid), result3);
			}
			throw new NotSupportedException("Unsupported Media Service Response encountered \"" + r.GetType().Name + "\"");
		}).ObserveOn(uiScheduler.Scheduler);
	}

	public WatcherReference? StartWatchingMediaFile(string path)
	{
		return _fileObservatory.StartWatching(path);
	}

	public async Task<IMetadataLoader.IResult> LoadMetadataAsync(MediaMetadataRequest request, bool applyTransform = false)
	{
		if (!_fileService.FileExists(request.Filename))
		{
			_logger.Info("Metadata load failed; Source File does not exist: {0} - {1}", request.TargetID.ToString(), request.Filename);
			return new IMetadataLoader.FailedResult();
		}
		RequestEnvelope.Types.GetMediaReference request2 = new RequestEnvelope.Types.GetMediaReference
		{
			Uuid = request.TargetID.ToString()
		};
		_logger.Info("Loading Metadata for {0} - {1}", request.TargetID.ToString(), request.Filename);
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
				_logger.Info("Failed fetching metadata due to it not being added; attempting to add it: {0} - {1}", request.TargetID.ToString(), request.Filename);
				Task<IMediaServiceResponse> addTask = AddNewMediaReferenceAsync(request);
				if (_metadataCache.TryGetCachedMetadata(request, out string previewImagePath, out MediaMetadata mediaMetadata))
				{
					_asyncExecutor.ExecuteAsync(async delegate
					{
						if (await addTask.ConfigureAwait(continueOnCapturedContext: false) is MediaServiceV1ErrorResponse mediaServiceV1ErrorResponse)
						{
							if (mediaServiceV1ErrorResponse.Error.Code == RequestError.Types.ErrorCode.Conflict)
							{
								_logger.Warning("Attempted to add the same media reference more than once {0} - {1} - {2} - {3}", request.TargetID.ToString(), request.Filename, mediaServiceV1ErrorResponse.Error.Code, mediaServiceV1ErrorResponse.Error.Description);
							}
							else
							{
								_logger.Error("Error Adding media Reference for for Media {0} - {1} - {2} - {3}", request.TargetID.ToString(), request.Filename, mediaServiceV1ErrorResponse.Error.Code, mediaServiceV1ErrorResponse.Error.Description);
							}
						}
					});
					_logger.Info("Using Legacy cached metadata for {0} - {1}", request.TargetID.ToString(), request.Filename);
					return new IMetadataLoader.SuccessfulResult(mediaMetadata, _imageLoader.LoadImage(previewImagePath));
				}
				if (await addTask.ConfigureAwait(continueOnCapturedContext: false) is MediaServiceV1ErrorResponse mediaServiceV1ErrorResponse2)
				{
					if (mediaServiceV1ErrorResponse2.Error.Code != RequestError.Types.ErrorCode.Conflict)
					{
						_logger.Error("Error Adding media Reference for for Media, returning Failed result {0} - {1} - {2} - {3}", request.TargetID.ToString(), request.Filename, mediaServiceV1ErrorResponse2.Error.Code, mediaServiceV1ErrorResponse2.Error.Description);
						return new IMetadataLoader.FailedResult();
					}
					_logger.Warning("Attempted to add the same media reference more than once, returning Pending result {0} - {1} - {2} - {3}", request.TargetID.ToString(), request.Filename, mediaServiceV1ErrorResponse2.Error.Code, mediaServiceV1ErrorResponse2.Error.Description);
				}
				return new IMetadataLoader.PendingResult();
			}
			if (applyTransform)
			{
				await _mediaService.ApplyTransformation(request.ToApplyTransformRequestV1());
				return new IMetadataLoader.PendingResult();
			}
			return mediaReferenceInfo.ToSuccessfulResult(_imageLoader);
		}
		catch (MediaApplicationException)
		{
			_logger.Warning("Error encountered loading metadata for {0} - {1}", request.TargetID.ToString(), request.Filename);
			return new IMetadataLoader.FailedResult();
		}
	}

	private async Task<IMediaServiceResponse> AddNewMediaReferenceAsync(MediaMetadataRequest request)
	{
		return await _mediaService.AddMediaReference(request.ToAddMediaRequestV1(includeTransformation: true));
	}
}
