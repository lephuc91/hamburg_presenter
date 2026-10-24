using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using CoreApplication.Workspace;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.CoreApplication.Workspace.CoreInteraction;

public class CoreCloudWorkspaceSubscription : CoreWorkspaceServiceSubscriber, ICoreCloudWorkspaceSubscription, IAsyncDisposable
{
	private readonly TaskCompletionSource _unsubscribeCompletion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

	private readonly ReplaySubject<Notification.Types.Collaborators> _collaboratorsChangedSubject = new ReplaySubject<Notification.Types.Collaborators>(1);

	private readonly ReplaySubject<Notification.Types.Workspaces> _workspacesChangedSubject = new ReplaySubject<Notification.Types.Workspaces>(1);

	private readonly ReplaySubject<Notification.Types.Syncing> _syncingChangedSubject = new ReplaySubject<Notification.Types.Syncing>(1);

	private readonly ILogger _logger;

	public IObservable<Notification.Types.Workspaces> WhenWorkspacesChanged => _workspacesChangedSubject;

	public IObservable<Notification.Types.Collaborators> WhenCollaboratorsChanged => _collaboratorsChangedSubject;

	public IObservable<Notification.Types.Syncing> WhenSyncingChanged => _syncingChangedSubject;

	public CoreCloudWorkspaceSubscription(nint cloudWorkspaceService, ILogger logger)
		: base(cloudWorkspaceService)
	{
		_logger = logger;
	}

	public override void NativeErrorCallback()
	{
		_logger.Error(new WorkspaceApplicationException());
	}

	public override void NativeCallback(nint instancePointer)
	{
		_logger.Error(new WorkspaceApplicationException(instancePointer));
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
			case Notification.NotificationOneofCase.Workspaces:
				_workspacesChangedSubject.OnNext(notification.Workspaces);
				break;
			case Notification.NotificationOneofCase.Collaborators:
				_collaboratorsChangedSubject.OnNext(notification.Collaborators);
				break;
			case Notification.NotificationOneofCase.Syncing:
				_syncingChangedSubject.OnNext(notification.Syncing);
				break;
			default:
				_logger.Error("Unexpected Notification Case for CoreCloudWorkspaceSubscription");
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
		_collaboratorsChangedSubject.Dispose();
		_workspacesChangedSubject.Dispose();
		_syncingChangedSubject.Dispose();
	}
}
