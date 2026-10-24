using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.CoreApplication.Media.V1.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1;

public sealed class MediaServiceV1 : IMediaServiceV1, IMediaService, IAsyncDisposable
{
	private sealed record StartUpProperties(ICoreMediaServiceV1 Service, ICoreMediaSubscriptionV1 Subscription);

	private readonly ILogger _logger;

	private readonly IMediaAnalyticsSender _analyticsSender;

	private readonly Task<StartUpProperties> _startupTask;

	private readonly Subject<IMediaServiceResponse> _whenMediaReferenceChanged = new Subject<IMediaServiceResponse>();

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public Task StartupTask => _startupTask;

	public IObservable<IMediaServiceResponse> WhenMediaReferenceChanged => _whenMediaReferenceChanged;

	public IObservable<MediaManagementStatus> WhenMediaManagementStatusChanged { get; }

	public MediaServiceV1(ICoreApplication coreApplication, ILogger logger, IMediaAnalyticsSender analyticsSender, IFlagService flagService)
	{
		_logger = logger;
		_analyticsSender = analyticsSender;
		if (flagService.IsFlagEnabled(Flag.Cloud))
		{
			throw new InvalidOperationException("MediaService V1 Constructed when only V2 should be used.");
		}
		_startupTask = StartupAsync(coreApplication, logger);
		WhenMediaManagementStatusChanged = (from t in _startupTask.ToObservable()
			select t.Subscription.WhenMediaManagementStatusUpdated).Switch();
		_disposables.Add(_whenMediaReferenceChanged);
	}

	public async Task<IMediaServiceResponse> UpdateWorkspacesAsync(UpdateWorkspaces request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			UpdateWorkspaces = request
		}, (ResponseEnvelope.Types.Response x) => x.Update, null, null, "UpdateWorkspacesAsync");
	}

	public async Task<IMediaServiceResponse> UpdateWorkspacesAsync(IReadOnlyList<string> workspacePaths)
	{
		UpdateWorkspaces updateWorkspaces = new UpdateWorkspaces();
		foreach (string workspacePath in workspacePaths)
		{
			Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Workspace item = new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Workspace
			{
				Path = workspacePath
			};
			updateWorkspaces.Workspaces.Add(item);
		}
		return await ProcessRequestAsync(new RequestEnvelope
		{
			UpdateWorkspaces = updateWorkspaces
		}, (ResponseEnvelope.Types.Response x) => x.Update, null, null, "UpdateWorkspacesAsync");
	}

	public async Task<IMediaServiceResponse> ChangeShowDirectoryAsync(string path)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			ChangeShowDirectory = new ChangeShowDirectory
			{
				Path = path
			}
		}, (ResponseEnvelope.Types.Response x) => x.Change, null, path, "ChangeShowDirectoryAsync");
	}

	public async Task<IMediaServiceResponse> GetMedia(RequestEnvelope.Types.GetMediaReference request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			GetMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Get, null, null, "GetMedia").ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<IMediaServiceResponse> AddMediaReference(AddMediaReference request)
	{
		if (request.Transformation != null)
		{
			request.Transformation.Width = (uint)MediaThumbnailSize.FullPreviewSize.X;
			request.Transformation.Height = (uint)MediaThumbnailSize.FullPreviewSize.Y;
		}
		IMediaServiceResponse result = await ProcessRequestAsync(new RequestEnvelope
		{
			AddMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Add, request.Uuid, request.Url, "AddMediaReference");
		WhenMediaReferenceChanged.Where((IMediaServiceResponse x) => x is MediaServiceOkResponse<MediaReference> mediaServiceOkResponse && mediaServiceOkResponse.Data.Uuid == request.Uuid && mediaServiceOkResponse.Data.Success != null).OfType<MediaServiceOkResponse<MediaReference>>().FirstAsync()
			.Subscribe(delegate(MediaServiceOkResponse<MediaReference> x)
			{
				_analyticsSender.MediaAdded(x.Data.Success.MediaInfo.Width, x.Data.Success.MediaInfo.Height);
			});
		return result;
	}

	public async Task<IMediaServiceResponse> DuplicateMediaReference(DuplicateMediaReference request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			DuplicateMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Duplicate, request.SourceUuid + ", " + request.DestUuid, null, "DuplicateMediaReference");
	}

	public async Task<IMediaServiceResponse> ApplyTransformation(ApplyTransformation request)
	{
		request.Transformation.Width = (uint)MediaThumbnailSize.FullPreviewSize.X;
		request.Transformation.Height = (uint)MediaThumbnailSize.FullPreviewSize.Y;
		return await ProcessRequestAsync(new RequestEnvelope
		{
			ApplyTransformation = request
		}, (ResponseEnvelope.Types.Response x) => x.Apply, request.Uuid, null, "ApplyTransformation");
	}

	public async Task<IMediaServiceResponse> RemoveMediaReference(RemoveMediaReferences request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			RemoveMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Remove, string.Join(", ", request.Uuid), null, "RemoveMediaReference");
	}

	public async Task<IMediaServiceResponse> SendTriggeredMedia(string mediaId)
	{
		RequestEnvelope requestEnvelope = new RequestEnvelope
		{
			TriggerMediaReference = new TriggerMediaReference()
		};
		requestEnvelope.TriggerMediaReference.Uuid.Add(mediaId);
		return await ProcessRequestAsync(requestEnvelope, (ResponseEnvelope.Types.Response r) => r.Trigger, mediaId, null, "SendTriggeredMedia");
	}

	public async Task<IMediaServiceResponse> PauseThumbnailGeneration(PauseGenerationOptions options)
	{
		long untilTimeUtc = options switch
		{
			PauseGenerationOptions.ONE_HOUR => DateTime.Now.AddHours(1.0).ToUniversalTime().ToUnixTimestamp(), 
			PauseGenerationOptions.EOD => DateTime.Today.AddDays(1.0).ToUniversalTime().ToUnixTimestamp(), 
			PauseGenerationOptions.TWENTY_FOUR_HOURS => DateTime.Now.AddHours(24.0).ToUniversalTime().ToUnixTimestamp(), 
			_ => throw new ArgumentException($"Unexpected value for {"options"} provided - {options}"), 
		};
		return await ProcessRequestAsync(new RequestEnvelope
		{
			PauseGeneration = new PauseGeneration
			{
				UntilTimeUtc = (ulong)untilTimeUtc
			}
		}, (ResponseEnvelope.Types.Response x) => x.Pause, null, null, "PauseThumbnailGeneration");
	}

	public async Task<IMediaServiceResponse> ResumeThumbnailGeneration()
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			ResumeGeneration = new ResumeGeneration()
		}, (ResponseEnvelope.Types.Response x) => x.Resume, null, null, "ResumeThumbnailGeneration");
	}

	private async Task<StartUpProperties> StartupAsync(ICoreApplication coreApplication, ILogger logger)
	{
		ServiceResult<ICoreMediaServiceV1> serviceResult = await coreApplication.GetMediaServiceV1Async();
		logger.Info("Subscribing to Media Service notifications");
		ICoreMediaSubscriptionV1 coreMediaSubscriptionV = serviceResult.Instance.Subscribe(logger);
		if (serviceResult.IsFatalError)
		{
			return new StartUpProperties(serviceResult.Instance, coreMediaSubscriptionV);
		}
		coreMediaSubscriptionV.WhenMediaReferenceChanged.Subscribe(delegate(MediaReference x)
		{
			switch (x.StateCase)
			{
			case MediaReference.StateOneofCase.Success:
				_whenMediaReferenceChanged.OnNext(new MediaServiceOkResponse<MediaReference>(x));
				break;
			case MediaReference.StateOneofCase.Error:
				_logger.Warning("Received Error notification from Media Manager for {0} with Code: {1} and Description: {2}", x.Uuid, x.Error.Code, x.Error.Description);
				_analyticsSender.RequestError(x.Uuid, $"Notification Error - {x.Error.Code} - {x.Error.Description}");
				break;
			case MediaReference.StateOneofCase.Deleted:
				_logger.Info("Received Deleted notification from Media Manager for {0}", x.Uuid);
				break;
			case MediaReference.StateOneofCase.None:
				_logger.Info("Received unhandled None notification from Media Manager for {0}", x.Uuid);
				break;
			case (MediaReference.StateOneofCase)1:
			case MediaReference.StateOneofCase.Progress:
				break;
			}
		}).DisposeWith(_disposables);
		coreMediaSubscriptionV.WhenConnectionStatusChanged.Subscribe(delegate(ConnectionStatus x)
		{
			_analyticsSender.ConnectionStateChanged(x);
		}).DisposeWith(_disposables);
		_analyticsSender.BootstrapComplete(serviceResult.Error);
		return new StartUpProperties(serviceResult.Instance, coreMediaSubscriptionV);
	}

	private async Task<IMediaServiceResponse> ProcessRequestAsync<T>(RequestEnvelope request, Func<ResponseEnvelope.Types.Response, T> getResponseObject, string? requestUuids, string? errorStringDetails, [CallerMemberName] string? callerName = null)
	{
		StartUpProperties startUpProperties = await _startupTask.ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			ResponseEnvelope responseEnvelope = await startUpProperties.Service.ExecuteAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			if (responseEnvelope.ResultCase != ResponseEnvelope.ResultOneofCase.Ok)
			{
				if (callerName != null)
				{
					_logger.Error("Error executing {0} request with error \"{1}\" for UUIDs \"{2}\" and input details: {3}", callerName, $"{responseEnvelope.Error.Code} - {responseEnvelope.Error.Description}", requestUuids, errorStringDetails);
				}
				_analyticsSender.RequestError(requestUuids ?? "No UUID", $"Operation {callerName} - {responseEnvelope.Error.Code} - {responseEnvelope.Error.Description} - {errorStringDetails}");
				return new MediaServiceV1ErrorResponse(null, responseEnvelope.Error);
			}
			return new MediaServiceOkResponse<T>(getResponseObject(responseEnvelope.Ok));
		}
		catch (Exception ex)
		{
			_analyticsSender.RequestError(requestUuids ?? "No UUID", $"Operation {callerName} encountered Exception - {ex.GetType().Name} - {ex.Message} - {errorStringDetails}");
			throw;
		}
	}

	public async ValueTask DisposeAsync()
	{
		await _startupTask;
		_disposables.Dispose();
	}
}
