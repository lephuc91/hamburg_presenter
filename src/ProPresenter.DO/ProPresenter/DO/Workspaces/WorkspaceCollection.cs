using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Semver;

namespace ProPresenter.DO.Workspaces;

public class WorkspaceCollection : ImmutableObservableCollection<IWorkspace>, IWorkspaceCollection, INotifyEnumerableChanged<IWorkspace>, IEnumerable<IWorkspace>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<IWorkspace>
{
	public event Action<IWorkspaceCollection>? DataModified;

	public WorkspaceCollection()
	{
		base.Collection.ForEach(delegate(IWorkspace w)
		{
			w.PropertyChanged += Workspace_PropertyChanged;
		});
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IWorkspace>().ForEach(delegate(IWorkspace w)
		{
			w.PropertyChanged -= Workspace_PropertyChanged;
		});
		e.NewItems?.OfType<IWorkspace>().ForEach(delegate(IWorkspace w)
		{
			w.PropertyChanged += Workspace_PropertyChanged;
		});
		OnDataModified();
	}

	private void Workspace_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is IWorkspace workspace && e.PropertyName == "Active" && workspace.Active)
		{
			base.Collection.Except(new global::_003C_003Ez__ReadOnlySingleElementList<IWorkspace>(workspace)).ForEach(delegate(IWorkspace w)
			{
				w.Active = false;
			});
		}
		OnDataModified();
	}

	public void Add(IWorkspace workspace, bool makeActive)
	{
		OnAddWorkspace(workspace);
		workspace.Active = makeActive;
	}

	public IWorkspace Add(string name, string path, WorkspaceType type = WorkspaceType.Local, bool makeActive = false)
	{
		IWorkspace workspace = Create(name, path, WorkspaceType.Local, null, null, null);
		workspace.WorkspaceType = type;
		Add(workspace, makeActive);
		return workspace;
	}

	public IWorkspace Add(string name, string path, WorkspaceType type, SemVersion minimumRequiredAppVersion, Guid? cloudId, ulong? workspaceSizeInBytes, bool makeActive = false)
	{
		IWorkspace workspace = Create(name, path, WorkspaceType.Local, null, null, null);
		workspace.WorkspaceType = type;
		workspace.MinimumRequiredAppVersion = minimumRequiredAppVersion;
		workspace.CloudId = cloudId;
		workspace.WorkspaceSizeInBytes = workspaceSizeInBytes;
		Add(workspace, makeActive);
		return workspace;
	}

	public IWorkspace Create(string name, string path, WorkspaceType workspaceType = WorkspaceType.Local, Guid? cloudId = null, ulong? workspaceSizeInBytes = null, DateTimeOffset? lastModified = null)
	{
		return new Workspace(name, path, lastModified, cloudId, workspaceSizeInBytes, workspaceType);
	}

	protected internal void Add(IWorkspace workspace)
	{
		OnAddWorkspace(workspace);
	}

	public IWorkspace RenameWorkspace(string oldName, string newName, string newPath)
	{
		IWorkspace workspace = base.Collection.First((IWorkspace n) => string.Equals(oldName, n.Name, StringComparison.CurrentCultureIgnoreCase));
		workspace.Name = newName;
		workspace.Path = newPath;
		OnDataModified();
		return workspace;
	}

	public void Remove(IWorkspace workspace)
	{
		OnRemoveWorkspace(workspace);
	}

	public void Clear()
	{
		base.Collection.Clear();
	}

	private void OnAddWorkspace(IWorkspace workspace)
	{
		if (!base.Collection.Contains(workspace))
		{
			int index = FindInsertionIndex(workspace);
			base.Collection.Insert(index, workspace);
		}
	}

	private int FindInsertionIndex(IWorkspace workspace)
	{
		for (int i = 0; i < base.Collection.Count; i++)
		{
			if (string.Compare(workspace.Name, base.Collection[i].Name, StringComparison.CurrentCultureIgnoreCase) < 0)
			{
				return i;
			}
		}
		return base.Collection.Count;
	}

	private void OnRemoveWorkspace(IWorkspace workspace)
	{
		base.Collection.Remove(workspace);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}
}
