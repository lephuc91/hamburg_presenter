using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.CoreApplication.Media.V2.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2;

public sealed class MediaServiceV2 : IMediaServiceV2, IMediaService, IAsyncDisposable
{
	private sealed record StartUpProperties(ICoreMediaServiceV2 Service, ICoreMediaSubscriptionV2 Subscription);

	private readonly ILogger _logger;

	private readonly IMediaAnalyticsSender _analyticsSender;

	private readonly Task<StartUpProperties> _startupTask;

	private readonly Subject<IMediaServiceResponse> _whenMediaReferenceChanged = new Subject<IMediaServiceResponse>();

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public Task StartupTask => _startupTask;

	public IObservable<IMediaServiceResponse> WhenMediaReferenceChanged => _whenMediaReferenceChanged;

	public IObservable<MediaManagementStatus> WhenMediaManagementStatusChanged { get; }

	public MediaServiceV2(ICoreApplication coreApplication, ILogger logger, IMediaAnalyticsSender analyticsSender, IFlagService flagService, IManageMediaAutoMaticallyProvider manageAutomaticallyProvider, IEnableAnalyticsProvider enableAnalyticsProvider, IAsyncExecutor asyncExecutor)
	{
		_logger = logger;
		_analyticsSender = analyticsSender;
		if (!flagService.IsFlagEnabled(Flag.Cloud))
		{
			throw new InvalidOperationException("MediaService V2 Constructed when only V1 should be used.");
		}
		_startupTask = StartupAsync(coreApplication, logger);
		WhenMediaManagementStatusChanged = (from t in _startupTask.ToObservable()
			select t.Subscription.WhenMediaManagementStatusUpdated).Switch();
		_disposables.Add(_whenMediaReferenceChanged);
		(from x in Observable.CombineLatest<bool>(manageAutomaticallyProvider.WhenManageMediaAutomaticallyChanged, enableAnalyticsProvider.WhenEnableAnalyticsChanged)
			select Observable.FromAsync(() => UpdatePreferences(x[0], x[1])).Catch((Exception ex) => Observable.Empty<Unit>())).Concat().Subscribe().DisposeWith(_disposables);
	}

	private async Task UpdatePreferences(bool manageMediaAutomatically, bool shareAnalytics)
	{
		await ProcessRequestAsync(new RequestEnvelope
		{
			UpdatePrefs = new UpdatePrefs
			{
				Preferences = new Preferences
				{
					ManageMedia = manageMediaAutomatically,
					ShareAnalytics = shareAnalytics
				}
			}
		}, (ResponseEnvelope.Types.Response x) => x.UpdatePrefs, null, null, "UpdatePreferences");
	}

	public async Task<IMediaServiceResponse> UpdateWorkspacesAsync(IReadOnlyList<(Guid? Id, string Path)> workspaceInfos)
	{
		UpdateWorkspaces updateWorkspaces = new UpdateWorkspaces();
		foreach (var workspaceInfo in workspaceInfos)
		{
			Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Workspace workspace = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Workspace
			{
				Path = workspaceInfo.Path
			};
			if (workspaceInfo.Id.HasValue)
			{
				Guid? item = workspaceInfo.Id;
				workspace.Id = item.ToString();
			}
			updateWorkspaces.Workspaces.Add(workspace);
		}
		return await ProcessRequestAsync(new RequestEnvelope
		{
			UpdateWorkspaces = updateWorkspaces
		}, (ResponseEnvelope.Types.Response x) => x.Update, null, null, "UpdateWorkspacesAsync");
	}

	public async Task<IMediaServiceResponse> GetMedia(RequestEnvelope.Types.GetMediaReference request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			GetMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Get, request.Id.ToSimpleDisplayString(), null, "GetMedia").ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<IMediaServiceResponse> AddProContentReference(AddProContentReference request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			AddProContentReference = request
		}, (ResponseEnvelope.Types.Response x) => x.AddProContentReference, request.Id.ToSimpleDisplayString(), null, "AddProContentReference").ConfigureAwait(continueOnCapturedContext: false);
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
		}, (ResponseEnvelope.Types.Response x) => x.Add, request.Id.ToSimpleDisplayString(), request.Url, "AddMediaReference");
		WhenMediaReferenceChanged.Where((IMediaServiceResponse x) => x is MediaServiceOkResponse<MediaReference> mediaServiceOkResponse && mediaServiceOkResponse.Data.Id.ContainerId == request.Id.ContainerId && mediaServiceOkResponse.Data.Id.Uuid == request.Id.Uuid && mediaServiceOkResponse.Data.Success != null).OfType<MediaServiceOkResponse<MediaReference>>().FirstAsync()
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
		}, (ResponseEnvelope.Types.Response x) => x.Duplicate, request.SrcId.ToSimpleDisplayString() + ", " + request.DestId.ToSimpleDisplayString(), null, "DuplicateMediaReference");
	}

	public async Task<IMediaServiceResponse> ApplyTransformation(ApplyTransformation request)
	{
		request.Transformation.Width = (uint)MediaThumbnailSize.FullPreviewSize.X;
		request.Transformation.Height = (uint)MediaThumbnailSize.FullPreviewSize.Y;
		return await ProcessRequestAsync(new RequestEnvelope
		{
			ApplyTransformation = request
		}, (ResponseEnvelope.Types.Response x) => x.Apply, request.Id.ToSimpleDisplayString(), null, "ApplyTransformation");
	}

	public async Task<IMediaServiceResponse> RemoveMediaReference(RemoveMediaReferences request)
	{
		return await ProcessRequestAsync(new RequestEnvelope
		{
			RemoveMediaReference = request
		}, (ResponseEnvelope.Types.Response x) => x.Remove, string.Join(", ", request.Id.Select((ReferenceIdentifier id) => id.ToSimpleDisplayString())), null, "RemoveMediaReference");
	}

	public async Task<IMediaServiceResponse> SendTriggeredMedia(string containerId, string mediaReferenceId)
	{
		RequestEnvelope requestEnvelope = new RequestEnvelope
		{
			TriggerMediaReference = new TriggerMediaReference()
		};
		requestEnvelope.TriggerMediaReference.Id.Add(new ReferenceIdentifier
		{
			ContainerId = containerId,
			Uuid = mediaReferenceId
		});
		return await ProcessRequestAsync(requestEnvelope, (ResponseEnvelope.Types.Response r) => r.Trigger, containerId + " - " + mediaReferenceId, null, "SendTriggeredMedia");
	}

	public async Task<IMediaServiceResponse> UpdateAvailableSmartPlaylists(IReadOnlySet<string> smartPlaylistPaths)
	{
		RequestEnvelope requestEnvelope = new RequestEnvelope
		{
			UpdateSmartPlaylists = new UpdateSmartPlaylists()
		};
		requestEnvelope.UpdateSmartPlaylists.Playlists.AddRange(smartPlaylistPaths.Select((string x) => new SmartPlaylist
		{
			Path = x
		}));
		return await ProcessRequestAsync(requestEnvelope, (ResponseEnvelope.Types.Response x) => x.UpdateSmartPlaylists, string.Join(", ", smartPlaylistPaths), null, "UpdateAvailableSmartPlaylists");
	}

	private async Task<StartUpProperties> StartupAsync(ICoreApplication coreApplication, ILogger logger)
	{
		ServiceResult<ICoreMediaServiceV2> serviceResult = await coreApplication.GetMediaServiceV2Async();
		logger.Info("Subscribing to Media Service notifications");
		ICoreMediaSubscriptionV2 coreMediaSubscriptionV = serviceResult.Instance.Subscribe(logger);
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
				_logger.Warning("Received Error notification from Media Manager for {0} with Code: {1} and Description: {2}", x.Id.ToSimpleDisplayString(), x.Error.Code, x.Error.Description);
				_analyticsSender.RequestError(x.Id.ToSimpleDisplayString(), $"Notification Error - {x.Error.Code} - {x.Error.Description}");
				_whenMediaReferenceChanged.OnNext(new MediaServiceV2ErrorResponse<MediaReference.Types.Error>(x.Id.ContainerId, x.Id.Uuid.ToGuidOrEmpty(), x.Error));
				break;
			case MediaReference.StateOneofCase.Deleted:
				_logger.Info("Received Deleted notification from Media Manager for {0}", x.Id.ToSimpleDisplayString());
				break;
			case MediaReference.StateOneofCase.None:
				_logger.Info("Received unhandled None notification from Media Manager for {0}", x.Id.ToSimpleDisplayString());
				break;
			case (MediaReference.StateOneofCase)1:
			case MediaReference.StateOneofCase.Progress:
				break;
			}
		}).DisposeWith(_disposables);
		coreMediaSubscriptionV.WhenMediaImported.Subscribe(delegate(ImportMediaV2 x)
		{
			if (!x.HasError)
			{
				_whenMediaReferenceChanged.OnNext(new MediaServiceOkResponse<ImportSuccessData>(new ImportSuccessData(x.ContainerId, x.MediaReferenceId, x.TargetUrl)));
			}
			else
			{
				_logger.Warning("Received Import Error {0} notification from Media Manager for {1} - {2}", x.Error, x.ContainerId, x.MediaReferenceId);
				_analyticsSender.RequestError($"{x.ContainerId} - {x.MediaReferenceId}", $"Import Notification Error {x.Error}");
				_whenMediaReferenceChanged.OnNext(new MediaServiceV2ErrorResponse<AssetImported.Types.Error>(x.ContainerId, x.MediaReferenceId, x.Error.Value));
			}
		}).DisposeWith(_disposables);
		coreMediaSubscriptionV.WhenConnectionStatusChanged.Subscribe(delegate(ConnectionStatus x)
		{
			_analyticsSender.ConnectionStateChanged(x);
		}).DisposeWith(_disposables);
		_analyticsSender.BootstrapComplete(serviceResult.Error);
		return new StartUpProperties(serviceResult.Instance, coreMediaSubscriptionV);
	}

	private async Task<IMediaServiceResponse> ProcessRequestAsync<T>(RequestEnvelope request, Func<ResponseEnvelope.Types.Response, T> getResponseObject, string? requestIdentifier, string? errorStringDetails, [CallerMemberName] string? callerName = null)
	{
		StartUpProperties startUpProperties = await _startupTask.ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			ResponseEnvelope responseEnvelope = await startUpProperties.Service.ExecuteAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			if (responseEnvelope.ResultCase != ResponseEnvelope.ResultOneofCase.Ok)
			{
				if (callerName != null)
				{
					_logger.Error("Error executing {0} request with error \"{1}\" for Identifier \"{2}\" and input details: {3}", callerName, $"{responseEnvelope.Error.Code} - {responseEnvelope.Error.Description}", requestIdentifier, errorStringDetails);
				}
				_analyticsSender.RequestError(requestIdentifier ?? "No Identifier", $"Operation {callerName} - {responseEnvelope.Error.Code} - {responseEnvelope.Error.Description} - {errorStringDetails}");
				return new MediaServiceV2ErrorResponse<RequestError>(null, null, responseEnvelope.Error);
			}
			return new MediaServiceOkResponse<T>(getResponseObject(responseEnvelope.Ok));
		}
		catch (Exception ex)
		{
			_analyticsSender.RequestError(requestIdentifier ?? "No UUID", $"Operation {callerName} encountered Exception - {ex.GetType().Name} - {ex.Message} - {errorStringDetails}");
			throw;
		}
	}

	public async ValueTask DisposeAsync()
	{
		await _startupTask;
		_disposables.Dispose();
	}
}
