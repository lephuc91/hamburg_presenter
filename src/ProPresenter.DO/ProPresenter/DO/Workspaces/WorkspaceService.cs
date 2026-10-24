using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility.Zip;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.CoreApplication.Media.V2;
using ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.DO.Workspaces;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class WorkspaceService : IWorkspaceService, IDisposable
{
	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IMediaService _mediaService;

	private readonly IFileSystem _fileSystem;

	private readonly IZipHelper _zipHelper;

	private int _workspaceSwitchCount;

	private const long MaxFileSize500Mb = 524288000L;

	private readonly SemaphoreSlim _updateWorkspacesSemaphore = new SemaphoreSlim(1, 1);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IWorkspaceCollection Workspaces { get; }

	public WorkspaceService(ICommonPathsWrapper commonPathsWrapper, IMediaService mediaService, ILocalWorkspaceStatsEventPublisher localStatsEventPuplisher, IMessageService messageService, IFileSystem fileSystem, IZipHelper zipHelper)
	{
		WorkspaceService workspaceService = this;
		_commonPathsWrapper = commonPathsWrapper;
		_mediaService = mediaService;
		_fileSystem = fileSystem;
		_zipHelper = zipHelper;
		Workspaces = _commonPathsWrapper.Workspaces;
		messageService.SubscribeToMessage<MainWindowClosingMessage>(delegate
		{
			localStatsEventPuplisher.Publish(workspaceService.Workspaces.Count, workspaceService._workspaceSwitchCount);
		});
		string showDir = _commonPathsWrapper.Base;
		string normalized = _fileSystem.Path.GetFullPath(showDir).TrimEnd(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar);
		string fileName = _fileSystem.Path.GetFileName(normalized);
		if (string.IsNullOrEmpty(fileName))
		{
			fileName = _fileSystem.Path.GetFileName(_fileSystem.Path.TrimEndingDirectorySeparator(showDir));
		}
		IWorkspace workspace = Workspaces.FirstOrDefault((IWorkspace p) => !string.IsNullOrEmpty(p.Path) && (p.Path == showDir || workspaceService._fileSystem.Path.GetFullPath(p.Path.TrimEnd(workspaceService._fileSystem.Path.DirectorySeparatorChar, workspaceService._fileSystem.Path.AltDirectorySeparatorChar)) == normalized));
		if (workspace == null)
		{
			Workspaces.Add(fileName, showDir, WorkspaceType.Local, makeActive: true);
		}
		else
		{
			workspace.Active = true;
		}
		Workspaces.CollectionChanged += UpdateLocalWorkspaces;
		Workspaces.DataModified += OnWorkspacesDataModified;
		UpdateMediaManagementWithWorkspacesAsync();
	}

	public bool DoesWorkspacePathExist(string? path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return false;
		}
		string normalizedPath = _fileSystem.Path.GetFullPath(path.TrimEnd(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar));
		return Workspaces.Any((IWorkspace p) => !string.IsNullOrEmpty(p.Path) && _fileSystem.Path.GetFullPath(p.Path.TrimEnd(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar)) == normalizedPath);
	}

	public bool DoesWorkspaceNameExist(string? workspaceName)
	{
		if (string.IsNullOrEmpty(workspaceName))
		{
			return false;
		}
		return Workspaces.Any((IWorkspace workspace) => !string.IsNullOrEmpty(workspace.Name) && string.Equals(workspace.Name, workspaceName, StringComparison.OrdinalIgnoreCase));
	}

	public async Task RemoveWorkspaceAsync(IWorkspace workspace)
	{
		await _updateWorkspacesSemaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			Workspaces.Remove(workspace);
			await UpdateMediaManagementWithWorkspacesInternalAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			_updateWorkspacesSemaphore.Release();
		}
	}

	private void UpdateLocalWorkspaces(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action != NotifyCollectionChangedAction.Remove)
		{
			UpdateMediaManagementWithWorkspacesAsync();
		}
	}

	private void OnWorkspacesDataModified(IWorkspaceCollection workspaces)
	{
		UpdateMediaManagementWithWorkspacesAsync();
	}

	private async Task UpdateMediaManagementWithWorkspacesAsync()
	{
		await _updateWorkspacesSemaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			await UpdateMediaManagementWithWorkspacesInternalAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			_updateWorkspacesSemaphore.Release();
		}
	}

	private async Task UpdateMediaManagementWithWorkspacesInternalAsync()
	{
		if (_mediaService is IMediaServiceV2 mediaServiceV)
		{
			List<(Guid?, string)> list = new List<(Guid?, string)>();
			list.AddRange(Workspaces.Select((IWorkspace x) => (CloudId: x.CloudId, Path: x.Path)));
			await mediaServiceV.UpdateWorkspacesAsync(new _003C_003Ez__ReadOnlyList<(Guid?, string)>(list)).ConfigureAwait(continueOnCapturedContext: false);
		}
		else if (_mediaService is IMediaServiceV1 mediaServiceV2)
		{
			List<string> list2 = new List<string>();
			list2.AddRange(Workspaces.Select((IWorkspace x) => x.Path));
			await mediaServiceV2.UpdateWorkspacesAsync(new _003C_003Ez__ReadOnlyList<string>(list2)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void OnWorkspaceSwitch()
	{
		_workspaceSwitchCount++;
	}

	public Task<long> GetWorkspaceSizeBytesAsync(IWorkspace workspace, CancellationToken ct = default(CancellationToken))
	{
		return Task.Run(() => GetWorkspaceSizeBytesInternal(workspace), ct);
	}

	private long GetWorkspaceSizeBytesInternal(IWorkspace workspace)
	{
		if (string.IsNullOrWhiteSpace(workspace.Path))
		{
			return 0L;
		}
		return _fileSystem.Directory.EnumerateFiles(workspace.Path, "*", SearchOption.AllDirectories).Sum((string f) => _fileSystem.FileInfo.New(f).Length);
	}

	public async Task<string> ZipWorkspaceAsync(IWorkspace workspace)
	{
		string text = _fileSystem.Path.Combine(_fileSystem.Path.GetTempPath(), _fileSystem.Path.GetRandomFileName());
		_fileSystem.Directory.CreateDirectory(text);
		string tempZip = _fileSystem.Path.Combine(text, workspace.Name + ".zip");
		long workspaceSize = GetWorkspaceSizeBytesInternal(workspace);
		await Task.Run(delegate
		{
			if (workspaceSize > 524288000)
			{
				_zipHelper.ZipFolderExcluding(workspace.Path, tempZip, new global::_003C_003Ez__ReadOnlySingleElementList<string>(_commonPathsWrapper.MediaAssets));
			}
			else
			{
				_zipHelper.ZipFolder(workspace.Path, tempZip);
			}
		});
		return tempZip;
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
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Workspaces.CollectionChanged -= UpdateLocalWorkspaces;
		Workspaces.DataModified -= OnWorkspacesDataModified;
		_updateWorkspacesSemaphore.Dispose();
	}
}
