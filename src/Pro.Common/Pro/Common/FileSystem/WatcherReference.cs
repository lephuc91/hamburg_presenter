using System;
using System.IO;
using Pro.Common.Components;

namespace Pro.Common.FileSystem;

public class WatcherReference : DisposableBase
{
	private readonly string _file;

	private readonly FileWatcher _watcher;

	public event Action? Changed;

	public event Action? Created;

	public event Action? Deleted;

	public event Action? Renamed;

	internal event Action<WatcherReference, string>? Disposed;

	public WatcherReference(string file, FileWatcher watcher)
	{
		_file = file;
		_watcher = watcher;
		_watcher.Changed += OnChanged;
		_watcher.Created += OnCreated;
		_watcher.Deleted += OnDeleted;
		_watcher.Renamed += OnRenamed;
		_watcher.EnableRaisingEvents = true;
	}

	private void OnChanged(object sender, FileSystemEventArgs e)
	{
		if (e.FullPath == _file)
		{
			this.Changed?.Invoke();
		}
	}

	private void OnCreated(object sender, FileSystemEventArgs e)
	{
		if (e.FullPath == _file)
		{
			this.Created?.Invoke();
		}
	}

	private void OnDeleted(object sender, FileSystemEventArgs e)
	{
		if (e.FullPath == _file)
		{
			this.Deleted?.Invoke();
		}
	}

	private void OnRenamed(object sender, RenamedEventArgs e)
	{
		if (e.OldFullPath == _file || e.FullPath == _file)
		{
			this.Renamed?.Invoke();
		}
	}

	protected override void OnDispose(bool disposeObjects)
	{
		_watcher.Changed -= OnChanged;
		_watcher.Created -= OnCreated;
		_watcher.Deleted -= OnDeleted;
		_watcher.Renamed -= OnRenamed;
		this.Disposed?.Invoke(this, _file);
	}
}
