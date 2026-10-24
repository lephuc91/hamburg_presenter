using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.CoreApplication.Workspace;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;
using Semver;

namespace ProPresenter.ViewModels.Workspaces;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cloudWorkspacesSubscription", "_workspaceCollectionChangeSubscription" })]
public class WorkspaceCollectionVM : IWorkspaceCollectionVM, IDisposable
{
	private sealed class MergedWorkspaceCollection : ImmutableObservableCollection<IWorkspace>
	{
		public void Add(IWorkspace workspace)
		{
			base.Collection.Add(workspace);
		}

		public void RemoveAt(int index)
		{
			base.Collection.RemoveAt(index);
		}

		public void Clear()
		{
			base.Collection.Clear();
		}

		public void Insert(int index, IWorkspace workspace)
		{
			base.Collection.Insert(index, workspace);
		}

		public void Move(int oldIndex, int newIndex)
		{
			base.Collection.Move(oldIndex, newIndex);
		}
	}

	private readonly PairedCollection<IWorkspace, IWorkspaceItemVM> _workspaces;

	private readonly IDisposable? _cloudWorkspacesSubscription;

	private readonly IDisposable _workspaceCollectionChangeSubscription;

	private readonly ICloudWorkspaceService? _cloudWorkspaceService;

	private readonly IWorkspaceService _workspaceService;

	private readonly IFileSystem _fileSystem;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IWorkspaceDeletedPrompt _workspaceDeletedPrompt;

	private readonly MergedWorkspaceCollection _mergedWorkspaces = new MergedWorkspaceCollection();

	private bool _ignoreWorkspaceChangedEvent;

	private readonly object _workspaceChangedLock = new object();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public INotifyEnumerableChanged<IWorkspaceItemVM> Workspaces => _workspaces;

	public WorkspaceCollectionVM(ICloudWorkspaceService? cloudWorkspaceService, IWorkspaceService workspaceService, IWorkspaceItemVMFactory itemVMFactory, IUiScheduler uiScheduler, IFileSystem fileSystem, ICommonPathsWrapper commonPathsWrapper, IWorkspaceDeletedPrompt workspaceDeletedPrompt, IAsyncExecutor asyncExecutor)
	{
		WorkspaceCollectionVM workspaceCollectionVM = this;
		_cloudWorkspaceService = cloudWorkspaceService;
		_workspaceService = workspaceService;
		_fileSystem = fileSystem;
		_commonPathsWrapper = commonPathsWrapper;
		_workspaceDeletedPrompt = workspaceDeletedPrompt;
		_workspaces = new PairedCollection<IWorkspace, IWorkspaceItemVM>(_mergedWorkspaces, itemVMFactory.Create);
		if (cloudWorkspaceService != null)
		{
			_cloudWorkspacesSubscription = cloudWorkspaceService.WhenWorkspacesChanged.ObserveOn(uiScheduler.Scheduler).Subscribe(delegate
			{
				asyncExecutor.ExecuteAsync(workspaceCollectionVM.OnWhenWorkspacesChanged);
			});
		}
		_workspaceCollectionChangeSubscription = _workspaceService.Workspaces.WhenCollectionChanges().Subscribe(delegate
		{
			workspaceCollectionVM.MergeAndUpdate();
		});
		MergeAndUpdate();
	}

	private void Workspaces_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		MergeAndUpdate();
	}

	private async Task OnWhenWorkspacesChanged()
	{
		if (_ignoreWorkspaceChangedEvent)
		{
			return;
		}
		_ignoreWorkspaceChangedEvent = true;
		try
		{
			MergeAndUpdate();
			IWorkspace activeWorkspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
			if (activeWorkspace != null && CheckWorkspaceNeedsConvertToLocal(activeWorkspace))
			{
				_workspaceDeletedPrompt.Show();
				await _cloudWorkspaceService.ConvertToLocalAsync();
				activeWorkspace.ConvertToLocalWorkspace();
			}
		}
		finally
		{
			_ignoreWorkspaceChangedEvent = false;
		}
	}

	private void MergeAndUpdate()
	{
		_workspaceService.Workspaces.SynchronizeTo(_mergedWorkspaces, (IWorkspace l, IWorkspace r) => l == r, delegate(IWorkspace l, int i)
		{
			_mergedWorkspaces.Insert(i, l);
		}, _mergedWorkspaces.Move, _mergedWorkspaces.RemoveAt);
		lock (_workspaceChangedLock)
		{
			IEnumerable<RemoteWorkspace> enumerable = _cloudWorkspaceService?.RemoteWorkspaces;
			foreach (RemoteWorkspace remote in enumerable ?? Enumerable.Empty<RemoteWorkspace>())
			{
				IWorkspace workspace = _workspaceService.Workspaces.Where((IWorkspace w) => w.CloudId.HasValue).FirstOrDefault((IWorkspace w) => w.CloudId == remote.Id);
				if (workspace == null)
				{
					IEnumerable<string> second = Enumerable.Empty<string>();
					if (_fileSystem.Directory.Exists(_commonPathsWrapper.DefaultLocalWorkspaces))
					{
						second = _fileSystem.Directory.EnumerateDirectories(_commonPathsWrapper.DefaultLocalWorkspaces).Select(_fileSystem.Path.GetFileName).OfType<string>();
					}
					IEnumerable<string> otherEntries = (from w in _mergedWorkspaces
						select _fileSystem.Path.GetFileName(w.Path) into name
						where !string.IsNullOrEmpty(name)
						select name).Concat(second);
					string path = remote.Name.SanitizeFilename().DuplicateName(otherEntries, (string name) => name);
					string path2 = _fileSystem.Path.Combine(_commonPathsWrapper.DefaultLocalWorkspaces, path);
					IWorkspace workspace2 = _workspaceService.Workspaces.Create(remote.Name, path2, ProPresenter.DO.Workspaces.WorkspaceType.Cloud, remote.Id, remote.WorkspaceSizeInBytes, remote.UpdatedDate);
					_mergedWorkspaces.Add(workspace2);
				}
				else
				{
					workspace.Name = remote.Name;
					workspace.WorkspaceSizeInBytes = remote.WorkspaceSizeInBytes;
					workspace.LastModified = remote.UpdatedDate;
					if (!SemVersion.TryParse(remote.MinimumVersion, SemVersionStyles.Any, out SemVersion semver))
					{
						semver = Workspace.FallbackDataModelVersion;
					}
					workspace.MinimumRequiredAppVersion = semver;
				}
			}
		}
		NaturalStringComparer comparer = new NaturalStringComparer();
		_mergedWorkspaces.SelectionSort((IWorkspace lhs, IWorkspace rhs) => comparer.Compare(lhs.Name, rhs.Name) > 0, _mergedWorkspaces.Move);
	}

	public void EnsureCloudWorkspaceExists(IWorkspace workspace)
	{
		if (CheckWorkspaceNeedsConvertToLocal(workspace))
		{
			_workspaceDeletedPrompt.Show();
			workspace.ConvertToLocalWorkspace();
		}
	}

	private bool CheckWorkspaceNeedsConvertToLocal(IWorkspace workspace)
	{
		IEnumerable<RemoteWorkspace> enumerable = _cloudWorkspaceService?.RemoteWorkspaces;
		HashSet<Guid> hashSet = (enumerable ?? Enumerable.Empty<RemoteWorkspace>()).Select((RemoteWorkspace r) => r.Id).ToHashSet();
		Guid? cloudId = workspace.CloudId;
		if (cloudId.HasValue)
		{
			Guid valueOrDefault = cloudId.GetValueOrDefault();
			return !hashSet.Contains(valueOrDefault);
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_cloudWorkspacesSubscription?.Dispose();
			_workspaceCollectionChangeSubscription.Dispose();
		}
	}
}
