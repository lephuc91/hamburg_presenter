using System;

namespace Pro.Serialization.DataManagement;

public interface ISyncedFileData<in K, in T> : IDisposable where K : class where T : class
{
	void AddSyncedFile(string name, K? data, T model);

	void AddSyncedFile(string fullPath);

	void RenameSyncedFile(T model, string newFilename);

	void UpdateSyncedFile(K? data, T model);

	void UpdateSyncedFile(string newKey, T model);

	void DeleteSyncedFile(T model);
}
