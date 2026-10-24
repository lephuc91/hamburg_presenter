using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Time;

namespace Pro.Common.FileSystem;

public class FileWatcher : DisposableBase, IFileWatcher, IDisposableObject, IDisposable
{
	private sealed class FileSystemEvent
	{
		public FileSystemEventArgs Event { get; }

		public Clock WaitTimer { get; } = new Clock(autoStart: true);

		public FileSystemEvent(FileSystemEventArgs e)
		{
			Event = e;
		}
	}

	private static readonly TimeSlice EventWaitTime = TimeSlice.FromSeconds(1.5);

	private FileSystemWatcher? _watcher;

	private readonly List<FileSystemEvent> _events = new List<FileSystemEvent>();

	private readonly DispatcherTimer _eventTimer;

	private string _path;

	private string? _filter;

	private bool _includeSubdirectories;

	private NotifyFilters? _notifyFilter;

	private int _internalBufferSize = 16384;

	private bool _enableRaisingEvents;

	public string TargetPath
	{
		get
		{
			return _watcher?.Path ?? _path;
		}
		set
		{
			if (_watcher != null)
			{
				_watcher.Path = value;
			}
			else
			{
				_path = value;
			}
		}
	}

	public string Filter
	{
		get
		{
			return _watcher?.Filter ?? _filter ?? string.Empty;
		}
		set
		{
			if (_watcher != null)
			{
				_watcher.Filter = value;
			}
			else
			{
				_filter = value;
			}
		}
	}

	public bool IncludeSubdirectories
	{
		get
		{
			return _watcher?.IncludeSubdirectories ?? _includeSubdirectories;
		}
		set
		{
			if (_watcher != null)
			{
				_watcher.IncludeSubdirectories = value;
			}
			else
			{
				_includeSubdirectories = value;
			}
		}
	}

	public NotifyFilters NotifyFilter
	{
		get
		{
			return _watcher?.NotifyFilter ?? _notifyFilter.GetValueOrDefault();
		}
		set
		{
			if (_watcher != null)
			{
				_watcher.NotifyFilter = value;
			}
			else
			{
				_notifyFilter = value;
			}
		}
	}

	public int InternalBufferSize
	{
		get
		{
			return _watcher?.InternalBufferSize ?? _internalBufferSize;
		}
		set
		{
			if (_watcher != null)
			{
				_watcher.InternalBufferSize = value;
			}
			else
			{
				_internalBufferSize = value;
			}
		}
	}

	public bool EnableRaisingEvents
	{
		get
		{
			return _watcher?.EnableRaisingEvents ?? _enableRaisingEvents;
		}
		set
		{
			if (_watcher == null)
			{
				_enableRaisingEvents = value;
				return;
			}
			try
			{
				_watcher.EnableRaisingEvents = value;
			}
			catch (Exception ex)
			{
				_watcher.EnableRaisingEvents = !value;
				Log.Warning("[{0}] Failed to enable/disable watching. DesiredState:{1}, Exception:{2}", "FileWatcher", EnableRaisingEvents, ex);
			}
		}
	}

	public event FileSystemEventHandler? Changed;

	public event FileSystemEventHandler? Created;

	public event FileSystemEventHandler? Deleted;

	public event RenamedEventHandler? Renamed;

	public FileWatcher(string path, string? filter = null, Dispatcher? dispatcher = null)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		_path = path;
		_filter = filter;
		if (TryCreateWatcher(out _watcher))
		{
			SetupWatcher();
		}
		_eventTimer = new DispatcherTimer(TimeSpan.FromSeconds(0.1), (DispatcherPriority)9, (EventHandler)EventTimer_Tick, dispatcher ?? Dispatcher.CurrentDispatcher);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_eventTimer.Stop();
			_watcher?.Dispose();
		}
	}

	private bool TryCreateWatcher(out FileSystemWatcher? watcher)
	{
		if (Directory.Exists(_path))
		{
			watcher = ((_filter == null) ? new FileSystemWatcher(_path) : new FileSystemWatcher(_path, _filter));
			return true;
		}
		watcher = null;
		return false;
	}

	private void SetupWatcher()
	{
		_watcher.ThrowWhenNull("_watcher");
		_watcher.InternalBufferSize = _internalBufferSize;
		_watcher.IncludeSubdirectories = _includeSubdirectories;
		if (_notifyFilter.HasValue)
		{
			_watcher.NotifyFilter = _notifyFilter.Value;
		}
		_watcher.Changed += OnChanged;
		_watcher.Created += OnCreated;
		_watcher.Deleted += OnDeleted;
		_watcher.Renamed += OnRenamed;
		_watcher.EnableRaisingEvents = _enableRaisingEvents;
	}

	private void OnChanged(object sender, FileSystemEventArgs e)
	{
		StageEvent(e);
	}

	private void OnCreated(object sender, FileSystemEventArgs e)
	{
		StageEvent(e);
	}

	private void OnDeleted(object sender, FileSystemEventArgs e)
	{
		StageEvent(e);
	}

	private void OnRenamed(object sender, RenamedEventArgs e)
	{
		StageEvent(e);
	}

	private void StageEvent(FileSystemEventArgs args)
	{
		lock (_events)
		{
			FileSystemEvent fileSystemEvent = _events.FirstOrDefault((FileSystemEvent e) => e.Event.ChangeType == args.ChangeType && Path.GetFullPath(e.Event.FullPath).Equals(Path.GetFullPath(args.FullPath)));
			if (fileSystemEvent == null)
			{
				_events.Add(new FileSystemEvent(args));
			}
			else
			{
				fileSystemEvent.WaitTimer.Restart();
			}
		}
	}

	private void EventTimer_Tick(object? sender, EventArgs e)
	{
		lock (_events)
		{
			FileSystemEvent[] array = _events.Where((FileSystemEvent f) => f.WaitTimer.ElapsedTime >= EventWaitTime).ToArray();
			foreach (FileSystemEvent fileSystemEvent in array)
			{
				if ((bool)FileHelper.WaitForFileAccess(fileSystemEvent.Event.FullPath, enforceFileExists: false, TimeSlice.Zero, FileAccess.Read))
				{
					_events.Remove(fileSystemEvent);
					switch (fileSystemEvent.Event.ChangeType)
					{
					case WatcherChangeTypes.Created:
						this.Created?.Invoke(this, fileSystemEvent.Event);
						break;
					case WatcherChangeTypes.Deleted:
						this.Deleted?.Invoke(this, fileSystemEvent.Event);
						break;
					case WatcherChangeTypes.Changed:
						this.Changed?.Invoke(this, fileSystemEvent.Event);
						break;
					case WatcherChangeTypes.Renamed:
						this.Renamed?.Invoke(this, (RenamedEventArgs)fileSystemEvent.Event);
						break;
					}
				}
				else
				{
					fileSystemEvent.WaitTimer.Restart();
				}
			}
		}
		if (_watcher == null && TryCreateWatcher(out _watcher))
		{
			SetupWatcher();
		}
	}
}
