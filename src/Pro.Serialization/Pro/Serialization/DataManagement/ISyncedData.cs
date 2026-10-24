using System;

namespace Pro.Serialization.DataManagement;

public interface ISyncedData<S, in T> : IDisposable where S : ISyncedData<S, T>
{
	string TargetFilename { get; }

	string TargetDirectory { get; }

	void ChangeTargetDirectoryFilename(string targetDirectory, string targetFilename);

	void UpdateData(T data);
}
