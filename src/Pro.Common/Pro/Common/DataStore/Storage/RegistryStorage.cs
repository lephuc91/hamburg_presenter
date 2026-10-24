using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32;

namespace Pro.Common.DataStore.Storage;

internal class RegistryStorage : IStorage
{
	private readonly string _fullPath;

	public RegistryStorage(string fullPath)
	{
		_fullPath = fullPath;
	}

	public bool TryReadValue(string key, [NotNullWhen(true)] out string? value)
	{
		value = Registry.GetValue(_fullPath, key, null) as string;
		return value != null;
	}

	public void WriteValue(string key, string value)
	{
		Registry.SetValue(_fullPath, key, value);
	}

	public void Reload()
	{
	}

	public void UpdateSettingsFile()
	{
	}

	public void RemoveValue(string key)
	{
	}
}
