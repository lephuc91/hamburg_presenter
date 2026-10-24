using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Workspace.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Local;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.CoreApplication.Workspace;

public class CloudWorkspaceService : ICloudWorkspaceService, IAsyncDisposable
{
	private readonly Task<ICoreCloudWorkspaceService?> _startupTask;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	private readonly ReplaySubject<IReadOnlyList<string>> _collaboratorsSubject = new ReplaySubject<IReadOnlyList<string>>(1);

	private readonly ReplaySubject<IAvailableWorkspaces> _workspacesSubject = new ReplaySubject<IAvailableWorkspaces>(1);

	private readonly ReplaySubject<ISyncStatus> _syncingSubject = new ReplaySubject<ISyncStatus>(1);

	private IReadOnlyList<RemoteWorkspace> _remoteWorkspaces = Array.Empty<RemoteWorkspace>();

	public IObservable<IReadOnlyList<string>> WhenCollaboratorsChanged => _collaboratorsSubject;

	public IObservable<IAvailableWorkspaces> WhenWorkspacesChanged => _workspacesSubject;

	public IObservable<ISyncStatus> WhenSyncingChanged => _syncingSubject;

	public IReadOnlyList<RemoteWorkspace> RemoteWorkspaces => _remoteWorkspaces;

	public CloudWorkspaceService(ICoreApplication coreApplication, ILogger logger)
	{
		_collaboratorsSubject.DisposeWith(_disposables);
		_workspacesSubject.DisposeWith(_disposables);
		_syncingSubject.DisposeWith(_disposables);
		_workspacesSubject.Subscribe(delegate(IAvailableWorkspaces w)
		{
			_remoteWorkspaces = w.Workspaces;
		}).DisposeWith(_disposables);
		_startupTask = StartupAsync(coreApplication, logger);
	}

	private async Task<ICoreCloudWorkspaceService?> StartupAsync(ICoreApplication coreApplication, ILogger logger)
	{
		ServiceResult<ICoreCloudWorkspaceService> serviceResult = await coreApplication.GetCoreCloudWorkspaceServiceAsync();
		if (!serviceResult.IsSuccess)
		{
			return null;
		}
		logger.Info("Subscribing to Cloud Workspace Service notifications");
		ICoreCloudWorkspaceSubscription coreCloudWorkspaceSubscription = serviceResult.Instance.Subscribe(logger);
		coreCloudWorkspaceSubscription.WhenCollaboratorsChanged.Select((Pro.SerializationInterop.RVProtoData.Service.Workspace.Notification.Types.Collaborators p) => p.Online).Subscribe(_collaboratorsSubject).DisposeWith(_disposables);
		(from w in coreCloudWorkspaceSubscription.WhenWorkspacesChanged
			where w.StateCase != Pro.SerializationInterop.RVProtoData.Service.Workspace.Notification.Types.Workspaces.StateOneofCase.Uninitialized
			select w.StateCase switch
			{
				Pro.SerializationInterop.RVProtoData.Service.Workspace.Notification.Types.Workspaces.StateOneofCase.Error => AvailableWorkspacesError.FromProto(w.Error), 
				Pro.SerializationInterop.RVProtoData.Service.Workspace.Notification.Types.Workspaces.StateOneofCase.Initialized => AvailableWorkspaces.FromProto(w.Initialized), 
				_ => throw new InvalidOperationException($"Received workspace case: {w.StateCase} which is not currently supported"), 
			}).Subscribe(_workspacesSubject).DisposeWith(_disposables);
		coreCloudWorkspaceSubscription.WhenSyncingChanged.Select((Pro.SerializationInterop.RVProtoData.Service.Workspace.Notification.Types.Syncing proto) => proto.ToSyncStatus()).Subscribe(_syncingSubject).DisposeWith(_disposables);
		return serviceResult.Instance;
	}

	public async Task RenameAsync(Guid? id, string newName)
	{
		ICoreCloudWorkspaceService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		Rename rename = new Rename
		{
			Name = newName
		};
		if (id.HasValue)
		{
			rename.Uuid = id.Value.ToString();
		}
		Rename.Types.Result result = await obj.RenameAsync(rename).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case Rename.Types.Result.ResultOneofCase.Ok:
			return;
		case Rename.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		}
		throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task OpenLocalAsync(string path, string name, string minimumVersion, Guid? id, IReadOnlyList<IDocument> documents)
	{
		ICoreCloudWorkspaceService coreCloudWorkspaceService = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		OpenLocal openLocal = new OpenLocal
		{
			Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.Local.Workspace
			{
				Metadata = new Pro.SerializationInterop.RVProtoData.Service.Workspace.Local.Metadata
				{
					Name = name,
					Path = path,
					ProVersion = minimumVersion
				},
				Documents = new DocumentSet()
			}
		};
		if (id.HasValue)
		{
			openLocal.Workspace.Metadata.Uuid = id.Value.ToString();
		}
		foreach (IDocument document in documents)
		{
			document.SerializeTo(openLocal.Workspace.Documents);
		}
		OpenLocal.Types.Result result = await coreCloudWorkspaceService.OpenLocalAsync(openLocal).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case OpenLocal.Types.Result.ResultOneofCase.Ok:
			return;
		case OpenLocal.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		}
		throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task<RemoteWorkspaceDocuments> OpenRemoteAsync(Guid id, string path)
	{
		ICoreCloudWorkspaceService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		OpenRemote request = new OpenRemote
		{
			Uuid = id.ToString(),
			Path = path
		};
		OpenRemote.Types.Result result = await obj.OpenRemoteAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case OpenRemote.Types.Result.ResultOneofCase.Ok:
		{
			Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote.Metadata metadata = result.Ok.Workspace.Metadata;
			DocumentSet documents = result.Ok.Workspace.Documents;
			return RemoteWorkspaceDocuments.FromProto(metadata, documents);
		}
		case OpenRemote.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		default:
			throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
		}
	}

	public async Task ConvertToLocalAsync()
	{
		ConvertToLocal.Types.Result result = await (await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false)).ConvertToLocalAsync().ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case ConvertToLocal.Types.Result.ResultOneofCase.Ok:
			return;
		case ConvertToLocal.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		}
		throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task ResumeSyncAsync()
	{
		ResumeSync.Types.Result result = await (await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false)).ResumeSyncAsync().ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case ResumeSync.Types.Result.ResultOneofCase.Ok:
			return;
		case ResumeSync.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		}
		throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}

	public async Task<Guid> PublishAsync()
	{
		ICoreCloudWorkspaceService obj = await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false);
		Publish request = new Publish();
		Publish.Types.Result result = await obj.PublishAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		return result.ResultCase switch
		{
			Publish.Types.Result.ResultOneofCase.Ok => Guid.Parse(result.Ok.Uuid), 
			Publish.Types.Result.ResultOneofCase.Error => throw new WorkspaceApplicationException(result.Error), 
			_ => throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}."), 
		};
	}

	private async Task<ICoreCloudWorkspaceService> GetServiceAsync()
	{
		return (await _startupTask.ConfigureAwait(continueOnCapturedContext: false)) ?? throw new WorkspaceApplicationException("Cloud Workspace Service is not available.");
	}

	public async ValueTask DisposeAsync()
	{
		await _startupTask.ConfigureAwait(continueOnCapturedContext: false);
		_disposables.Dispose();
	}

	public async Task PauseSyncAsync(ulong untilTimeUtc)
	{
		PauseSync.Types.Result result = await (await GetServiceAsync().ConfigureAwait(continueOnCapturedContext: false)).PauseSyncAsync(new PauseSync
		{
			UntilTimeUtc = untilTimeUtc
		}).ConfigureAwait(continueOnCapturedContext: false);
		switch (result.ResultCase)
		{
		case PauseSync.Types.Result.ResultOneofCase.Ok:
			return;
		case PauseSync.Types.Result.ResultOneofCase.Error:
			throw new WorkspaceApplicationException(result.Error);
		}
		throw new WorkspaceApplicationException($"Unknown result type detected:{result.ResultCase}.");
	}
}
