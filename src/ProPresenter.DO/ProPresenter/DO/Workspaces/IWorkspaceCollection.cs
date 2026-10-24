using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Semver;

namespace ProPresenter.DO.Workspaces;

public interface IWorkspaceCollection : INotifyEnumerableChanged<IWorkspace>, IEnumerable<IWorkspace>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<IWorkspace>
{
	event Action<IWorkspaceCollection>? DataModified;

	IWorkspace Create(string name, string path, WorkspaceType workspaceType = WorkspaceType.Local, Guid? cloudId = null, ulong? workspaceSizeInBytes = null, DateTimeOffset? lastModified = null);

	void Add(IWorkspace newWorkspace, bool makeActive);

	IWorkspace Add(string name, string path, WorkspaceType type = WorkspaceType.Local, bool makeActive = false);

	IWorkspace Add(string name, string path, WorkspaceType type, SemVersion minimumRequiredAppVersion, Guid? cloudId, ulong? workspaceSizeInBytes, bool makeActive = false);

	void Remove(IWorkspace workspace);

	void Clear();

	IWorkspace RenameWorkspace(string oldName, string newName, string newPath);
}
