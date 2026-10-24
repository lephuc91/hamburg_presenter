using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using CoreApplication.Media;
using Pro.Common.Logging;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1.CoreInteraction;

public class CoreMediaSubscriptionV1 : CoreMediaServiceSubscriberV1, ICoreMediaSubscriptionV1, IAsyncDisposable
{
	private readonly TaskCompletionSource _completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

	private readonly Subject<MediaReference> _mediaReferenceSubject = new Subject<MediaReference>();

	private readonly Subject<ConnectionStatus> _connectionStatusSubject = new Subject<ConnectionStatus>();

	private readonly BehaviorSubject<MediaManagementStatus> _mediaManagementStatusSubject = new BehaviorSubject<MediaManagementStatus>(new MediaManagementStatus(Idle: false, Paused: false, null, 0u, 0u));

	private readonly ILogger _logger;

	public IObservable<MediaReference> WhenMediaReferenceChanged => _mediaReferenceSubject;

	public IObservable<ConnectionStatus> WhenConnectionStatusChanged => _connectionStatusSubject;

	public IObservable<MediaManagementStatus> WhenMediaManagementStatusUpdated => _mediaManagementStatusSubject;

	public CoreMediaSubscriptionV1(nint _coreMediaService, ILogger logger)
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
				_mediaReferenceSubject.OnNext(notification.MediaReference);
				break;
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
			case Notification.NotificationOneofCase.GenerationStatus:
				_mediaManagementStatusSubject.OnNext(new MediaManagementStatus(notification.GenerationStatus.StatusCase == GenerationStatus.StatusOneofCase.Idle, notification.GenerationStatus.StatusCase == GenerationStatus.StatusOneofCase.Paused, (notification.GenerationStatus.StatusCase == GenerationStatus.StatusOneofCase.Paused) ? new DateTimeOffset?(DateTimeOffset.FromUnixTimeSeconds((long)notification.GenerationStatus.Paused.UntilTimeUtc)) : ((DateTimeOffset?)null), notification.GenerationStatus.Processing?.Count ?? 0, notification.GenerationStatus.Processing?.Total ?? 0));
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
