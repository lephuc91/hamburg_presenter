using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.CoreApplication.Document;

namespace Pro.CoreApplication.Workspace;

public interface ICloudWorkspaceService
{
	IReadOnlyList<RemoteWorkspace> RemoteWorkspaces { get; }

	IObservable<IReadOnlyList<string>> WhenCollaboratorsChanged { get; }

	IObservable<IAvailableWorkspaces> WhenWorkspacesChanged { get; }

	IObservable<ISyncStatus> WhenSyncingChanged { get; }

	Task RenameAsync(Guid? id, string newName);

	Task OpenLocalAsync(string path, string name, string minimumVersion, Guid? id, IReadOnlyList<IDocument> documents);

	Task<RemoteWorkspaceDocuments> OpenRemoteAsync(Guid id, string path);

	Task<Guid> PublishAsync();

	Task ConvertToLocalAsync();

	Task PauseSyncAsync(ulong untilTimeUtc);

	Task ResumeSyncAsync();
}
