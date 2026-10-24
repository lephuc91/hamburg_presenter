using System;
using System.IO;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Strings;

namespace Pro.Serialization.DataManagement;

public class SyncedFolder
{
	private IFileWatcher? _watcher;

	private string _targetFolder = string.Empty;

	private readonly IFileWatcherFactory _fileWatcherFactory;

	private readonly SyncedFolderCreatedDelegate<SyncedFolder>? _folderCreated;

	private readonly SyncedSubFolderCreatedDelegate<SyncedFolder>? _subFolderCreated;

	private readonly SyncedFolderDeletedDelegate<SyncedFolder>? _folderDeleted;

	private readonly SyncedSubFolderDeletedDelegate<SyncedFolder>? _subFolderDeleted;

	private readonly SyncedFolderRenamedDelegate<SyncedFolder>? _folderRenamed;

	private readonly SyncedSubFolderRenamedDelegate<SyncedFolder>? _subFolderRenamed;

	private readonly SyncedFolderChangedDelegate<SyncedFolder>? _folderChanged;

	private readonly SyncedSubFolderChangedDelegate<SyncedFolder>? _subFolderChanged;

	public SyncedFolder(string folderPath, IFileWatcherFactory fileWatcherFactory, SyncedFolderCreatedDelegate<SyncedFolder>? folderCreated = null, SyncedSubFolderCreatedDelegate<SyncedFolder>? subFolderCreated = null, SyncedFolderDeletedDelegate<SyncedFolder>? folderDeleted = null, SyncedSubFolderDeletedDelegate<SyncedFolder>? subFolderDeleted = null, SyncedFolderRenamedDelegate<SyncedFolder>? folderRenamed = null, SyncedSubFolderRenamedDelegate<SyncedFolder>? subFolderRenamed = null, SyncedFolderChangedDelegate<SyncedFolder>? folderChanged = null, SyncedSubFolderChangedDelegate<SyncedFolder>? subFolderChanged = null, bool includeSubdirectories = true)
	{
		_fileWatcherFactory = fileWatcherFactory;
		_folderCreated = folderCreated;
		_subFolderCreated = subFolderCreated;
		_folderDeleted = folderDeleted;
		_subFolderDeleted = subFolderDeleted;
		_folderRenamed = folderRenamed;
		_subFolderRenamed = subFolderRenamed;
		_folderChanged = folderChanged;
		_subFolderChanged = subFolderChanged;
		InitializeWatcher(folderPath, includeSubdirectories);
	}

	private void InitializeWatcher(string folderPath, bool includeSubdirectories)
	{
		if (_watcher != null)
		{
			_watcher.EnableRaisingEvents = false;
			_watcher.Created -= Folder_Created;
			_watcher.Deleted -= Folder_Deleted;
			_watcher.Renamed -= Folder_Renamed;
			_watcher.Changed -= Folder_Changed;
		}
		string directoryName = Path.GetDirectoryName(folderPath);
		directoryName.ThrowWhenNull("directory");
		_targetFolder = folderPath;
		_watcher = _fileWatcherFactory.Create(directoryName);
		if (_watcher != null)
		{
			_watcher.IncludeSubdirectories = includeSubdirectories;
			_watcher.Created += Folder_Created;
			_watcher.Deleted += Folder_Deleted;
			_watcher.Renamed += Folder_Renamed;
			_watcher.Changed += Folder_Changed;
			_watcher.EnableRaisingEvents = true;
		}
	}

	private void Folder_Created(object sender, FileSystemEventArgs e)
	{
		FilterFolderOperation(e, TargetFolder_Created, SubFolder_Created);
	}

	private void TargetFolder_Created(string fullPath)
	{
		_folderCreated?.Invoke(this, fullPath);
		OnTargetFolder_Created(fullPath);
	}

	protected virtual void OnTargetFolder_Created(string fullPath)
	{
	}

	private void SubFolder_Created(string fullPath)
	{
		_subFolderCreated?.Invoke(this, fullPath);
		OnSubFolder_Created(fullPath);
	}

	protected virtual void OnSubFolder_Created(string fullPath)
	{
	}

	private void Folder_Deleted(object sender, FileSystemEventArgs e)
	{
		FilterFolderOperation(e, TargetFolder_Deleted, SubFolder_Deleted);
	}

	private void TargetFolder_Deleted(string fullPath)
	{
		_folderDeleted?.Invoke(this, fullPath);
		OnTargetFolder_Deleted(fullPath);
	}

	protected virtual void OnTargetFolder_Deleted(string fullPath)
	{
	}

	private void SubFolder_Deleted(string fullPath)
	{
		_subFolderDeleted?.Invoke(this, fullPath);
		OnSubFolder_Deleted(fullPath);
	}

	protected virtual void OnSubFolder_Deleted(string fullPath)
	{
	}

	private void Folder_Renamed(object sender, RenamedEventArgs e)
	{
		if (e.OldFullPath == _targetFolder || e.FullPath == _targetFolder)
		{
			TargetFolder_Renamed(e);
		}
		else if (e.OldFullPath.IsSubPath(_targetFolder) || e.FullPath.IsSubPath(_targetFolder))
		{
			SubFolder_Renamed(e);
		}
	}

	private void TargetFolder_Renamed(RenamedEventArgs e)
	{
		_folderRenamed?.Invoke(this, e.OldFullPath, e.FullPath);
		OnTargetFolder_Renamed(e);
	}

	protected virtual void OnTargetFolder_Renamed(RenamedEventArgs e)
	{
	}

	private void SubFolder_Renamed(RenamedEventArgs e)
	{
		_subFolderRenamed?.Invoke(this, e.OldFullPath, e.FullPath);
		OnSubFolder_Renamed(e);
	}

	protected virtual void OnSubFolder_Renamed(RenamedEventArgs e)
	{
	}

	private void Folder_Changed(object sender, FileSystemEventArgs e)
	{
		FilterFolderOperation(e, TargetFolder_Changed, SubFolder_Changed);
	}

	private void TargetFolder_Changed(string fullPath)
	{
		_folderChanged?.Invoke(this, fullPath);
		OnTargetFolder_Changed(fullPath);
	}

	protected virtual void OnTargetFolder_Changed(string fullPath)
	{
	}

	private void SubFolder_Changed(string fullPath)
	{
		_subFolderChanged?.Invoke(this, fullPath);
		OnSubFolder_Changed(fullPath);
	}

	protected virtual void OnSubFolder_Changed(string fullPath)
	{
	}

	private void FilterFolderOperation(FileSystemEventArgs e, Action<string> targetFolderAction, Action<string> subFolderAction)
	{
		if (e.FullPath.IsSubPath(_targetFolder))
		{
			if (e.FullPath == _targetFolder)
			{
				targetFolderAction(e.FullPath);
			}
			else
			{
				subFolderAction(e.FullPath);
			}
		}
	}
}
