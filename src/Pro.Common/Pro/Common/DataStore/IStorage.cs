using System.Diagnostics.CodeAnalysis;

namespace Pro.Common.DataStore;

public interface IStorage
{
	bool TryReadValue(string key, [NotNullWhen(true)] out string? value);

	void WriteValue(string key, string value);

	void RemoveValue(string key);

	void Reload();

	void UpdateSettingsFile();
}
