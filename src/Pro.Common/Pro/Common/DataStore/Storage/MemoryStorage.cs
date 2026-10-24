using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Pro.Common.DataStore.Storage;

internal class MemoryStorage : IStorage
{
	private readonly ConcurrentDictionary<string, string> _memoryCache = new ConcurrentDictionary<string, string>();

	private readonly bool _allowWriting;

	public MemoryStorage(bool allowWriting = true)
	{
		_allowWriting = allowWriting;
	}

	public bool TryReadValue(string key, [NotNullWhen(true)] out string? value)
	{
		return _memoryCache.TryGetValue(key, out value);
	}

	public void WriteValue(string key, string value)
	{
		if (!_allowWriting)
		{
			throw new Exception("Storage is read-only");
		}
		_memoryCache[key] = value;
	}

	public void Reload()
	{
		_memoryCache.Clear();
	}

	public void UpdateSettingsFile()
	{
	}

	public void RemoveValue(string key)
	{
		if (!_allowWriting)
		{
			throw new Exception("Storage is read-only");
		}
		_memoryCache.TryRemove(key, out string _);
	}
}
