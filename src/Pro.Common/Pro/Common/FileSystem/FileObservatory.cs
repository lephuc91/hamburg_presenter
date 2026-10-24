using System;
using System.Collections.Generic;
using System.IO;
using Pro.Common.Cache;
using Pro.Common.Collections;

namespace Pro.Common.FileSystem;

public class FileObservatory : IFileObservatory
{
	private sealed class FileWatcherCache : Cache<string, FileWatcher>
	{
		protected override FileWatcher GenerateValue(string target)
		{
			return new FileWatcher(target);
		}
	}

	private readonly FileWatcherCache _cache = new FileWatcherCache();

	private readonly Dictionary<string, List<IDisposable>> _referenceCounts = new Dictionary<string, List<IDisposable>>();

	public WatcherReference? StartWatching(string file)
	{
		if (!TryGetDirectory(file, out string directory) || directory == null)
		{
			return null;
		}
		FileWatcher watcher = _cache.Get(directory);
		if (!_referenceCounts.TryGetValue(directory, out List<IDisposable> value))
		{
			value = new List<IDisposable>();
			_referenceCounts.Add(directory, value);
		}
		WatcherReference watcherReference = new WatcherReference(file.NormalizePath(isDirectory: false), watcher);
		watcherReference.Disposed += StopWatching;
		value.Add(watcherReference);
		return watcherReference;
	}

	private void StopWatching(WatcherReference reference, string file)
	{
		if (TryGetDirectory(file, out string directory) && directory != null && _referenceCounts.TryGetValue(directory, out List<IDisposable> value))
		{
			value.Remove(reference);
			if (value.Empty())
			{
				_referenceCounts.Remove(directory);
				_cache.Remove(directory);
			}
		}
	}

	private bool TryGetDirectory(string path, out string? directory)
	{
		if (!path.TryNormalizePath(out string normalizedPath, isDirectory: false))
		{
			directory = null;
			return false;
		}
		directory = Path.GetDirectoryName(normalizedPath);
		return Directory.Exists(directory);
	}
}
