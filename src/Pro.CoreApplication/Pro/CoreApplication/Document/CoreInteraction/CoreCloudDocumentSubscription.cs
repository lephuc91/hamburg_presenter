using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using CoreApplication.Document;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CoreInteraction;

public class CoreCloudDocumentSubscription : CoreDocumentServiceSubscriber, ICoreCloudDocumentSubscription, IAsyncDisposable
{
	private readonly TaskCompletionSource _unsubscribeCompletion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

	private readonly ReplaySubject<Notification.Types.Patch> _patchSubject = new ReplaySubject<Notification.Types.Patch>(1);

	private readonly ReplaySubject<Notification.Types.Required> _requiredSubject = new ReplaySubject<Notification.Types.Required>(1);

	private readonly Subject<Notification.Types.Added> _addedSubject = new Subject<Notification.Types.Added>();

	private readonly Subject<Notification.Types.Available> _availableSubject = new Subject<Notification.Types.Available>();

	private readonly Subject<Notification.Types.Removed> _removedSubject = new Subject<Notification.Types.Removed>();

	private readonly Subject<Notification.Types.Moved> _relocatedSubject = new Subject<Notification.Types.Moved>();

	private readonly ILogger _logger;

	public IObservable<Notification.Types.Patch> WhenPatchReceived => _patchSubject;

	public IObservable<Notification.Types.Required> WhenDocumentRequired => _requiredSubject;

	public IObservable<Notification.Types.Added> WhenDocumentAdded => _addedSubject;

	public IObservable<Notification.Types.Available> WhenDocumentAvailable => _availableSubject;

	public IObservable<Notification.Types.Removed> WhenDocumentRemoved => _removedSubject;

	public IObservable<Notification.Types.Moved> WhenDocumentRelocated => _relocatedSubject;

	public CoreCloudDocumentSubscription(nint cloudDocumentService, ILogger logger)
		: base(cloudDocumentService)
	{
		_logger = logger;
	}

	public override void NativeErrorCallback()
	{
		_logger.Error(new DocumentApplicationException());
	}

	public override void NativeCallback(nint instancePointer)
	{
		_logger.Error(new DocumentApplicationException(instancePointer));
	}

	public override void NativeCallback(byte[] protoData)
	{
		try
		{
			Notification notification = Notification.Parser.ParseFrom(protoData);
			switch (notification.NotificationCase)
			{
			case Notification.NotificationOneofCase.Unsubscribe:
				_unsubscribeCompletion.TrySetResult();
				break;
			case Notification.NotificationOneofCase.Patch:
				_patchSubject.OnNext(notification.Patch);
				break;
			case Notification.NotificationOneofCase.Required:
				_requiredSubject.OnNext(notification.Required);
				break;
			case Notification.NotificationOneofCase.Added:
				_addedSubject.OnNext(notification.Added);
				break;
			case Notification.NotificationOneofCase.Available:
				_availableSubject.OnNext(notification.Available);
				break;
			case Notification.NotificationOneofCase.Removed:
				_removedSubject.OnNext(notification.Removed);
				break;
			case Notification.NotificationOneofCase.Moved:
				_relocatedSubject.OnNext(notification.Moved);
				break;
			default:
				_logger.Error("Unexpected Notification Case for CoreCloudDocumentSubscription");
				break;
			case Notification.NotificationOneofCase.None:
				break;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public async ValueTask DisposeAsync()
	{
		if (!_unsubscribeCompletion.Task.IsCompleted)
		{
			CoreUnsubscribe();
		}
		await _unsubscribeCompletion.Task;
		Cleanup();
		_patchSubject.Dispose();
		_requiredSubject.Dispose();
		_addedSubject.Dispose();
		_availableSubject.Dispose();
		_removedSubject.Dispose();
		_relocatedSubject.Dispose();
	}
}
