using System;
using Google.Protobuf;
using Pro.Serialization.Utility;

namespace Pro.Serialization.DataManagement;

public class ProtoSyncedData<T> : SyncedData<ProtoSyncedData<T>, T>, IProtoSyncedData<T>, ISyncedData<IProtoSyncedData<T>, T>, IDisposable where T : class, IMessage<T>, new()
{
	public ProtoSyncedData(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<ProtoSyncedData<T>, T?>? validateParse = null)
		: base(targetDirectory, targetFilename, dataUpdated, dataCleared, validateParse)
	{
		ParseFile();
	}

	protected override bool OnTryParseFile(string filename, string fullPath, out T? data)
	{
		return ProtoHelper.TryReadFile<T>(fullPath, out data);
	}

	protected override void OnWriteFile(string filename, string fullPath, T data)
	{
		ProtoHelper.WriteFile(fullPath, data);
	}
}
