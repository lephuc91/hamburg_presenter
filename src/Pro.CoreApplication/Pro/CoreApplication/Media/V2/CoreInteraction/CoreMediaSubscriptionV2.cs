using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using CoreApplication.Media;
using Pro.Common.Logging;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public class CoreMediaSubscriptionV2 : CoreMediaServiceSubscriberV2, ICoreMediaSubscriptionV2, IAsyncDisposable
{
	private readonly TaskCompletionSource _completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

	private readonly Subject<MediaReference> _mediaReferenceSubject = new Subject<MediaReference>();

	private readonly Subject<ImportMediaV2> _importMediaSubject = new Subject<ImportMediaV2>();

	private readonly Subject<ConnectionStatus> _connectionStatusSubject = new Subject<ConnectionStatus>();

	private readonly BehaviorSubject<MediaManagementStatus> _mediaManagementStatusSubject = new BehaviorSubject<MediaManagementStatus>(new MediaManagementStatus(Idle: false, Paused: false, null, 0u, 0u));

	private readonly ILogger _logger;

	public IObservable<MediaReference> WhenMediaReferenceChanged => _mediaReferenceSubject;

	public IObservable<ImportMediaV2> WhenMediaImported => _importMediaSubject;

	public IObservable<ConnectionStatus> WhenConnectionStatusChanged => _connectionStatusSubject;

	public IObservable<MediaManagementStatus> WhenMediaManagementStatusUpdated => _mediaManagementStatusSubject;

	public CoreMediaSubscriptionV2(nint _coreMediaService, ILogger logger)
		: base(_coreMediaService)
	{
		_logger = logger;
	}

	public async ValueTask DisposeAsync()
	{
		CoreUnsubscribe();
		await _completion.Task;
		Cleanup();
		_mediaReferenceSubject.Dispose();
		_importMediaSubject.Dispose();
		_connectionStatusSubject.Dispose();
		_mediaManagementStatusSubject.Dispose();
	}

	public override void NativeCallback(nint instancePointer)
	{
		_logger.Error(new MediaApplicationException(instancePointer));
	}

	public override void NativeCallback(byte[] protoData)
	{
		try
		{
			Notification notification = Notification.Parser.ParseFrom(protoData);
			switch (notification.NotificationCase)
			{
			case Notification.NotificationOneofCase.MediaReference:
				if (notification.MediaReference.Success?.MediaInfo?.Url?.StartsWith("\\\\?\\") == true)
				{
					notification.MediaReference.Success.MediaInfo.Url = notification.MediaReference.Success.MediaInfo.Url.Substring("\\\\?\\".Length);
				}
				_mediaReferenceSubject.OnNext(notification.MediaReference);
				break;
			case Notification.NotificationOneofCase.AssetImported:
			{
				AssetImported assetImported = notification.AssetImported;
				if (assetImported.Success?.Url?.StartsWith("\\\\?\\") == true)
				{
					assetImported.Success.Url = assetImported.Success.Url.Substring("\\\\?\\".Length);
				}
				_importMediaSubject.OnNext(new ImportMediaV2(assetImported.Id.ContainerId, Guid.Parse(assetImported.Id.Uuid), assetImported.Success?.Url ?? "", (assetImported.StateCase == AssetImported.StateOneofCase.Error) ? new AssetImported.Types.Error?(assetImported.Error) : ((AssetImported.Types.Error?)null)));
				break;
			}
			case Notification.NotificationOneofCase.Connected:
				_connectionStatusSubject.OnNext(ConnectionStatus.Connected);
				break;
			case Notification.NotificationOneofCase.Disconnected:
				_connectionStatusSubject.OnNext(ConnectionStatus.Disconected);
				break;
			case Notification.NotificationOneofCase.UnsubscribeComplete:
				_completion.SetResult();
				break;
			case Notification.NotificationOneofCase.Unresponsive:
				_connectionStatusSubject.OnNext(ConnectionStatus.Unresponsive);
				break;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public override void NativeErrorCallback()
	{
		_logger.Error(new MediaApplicationException());
	}
}
