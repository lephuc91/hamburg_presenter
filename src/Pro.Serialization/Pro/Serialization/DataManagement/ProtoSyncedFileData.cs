using System;
using Google.Protobuf;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Serialization.Utility;

namespace Pro.Serialization.DataManagement;

public class ProtoSyncedFileData<K, T> : SyncedFileData<ProtoSyncedFileData<K, T>, K, T>, IProtoSyncedFileData<K, T>, ISyncedFileData<K, T>, IDisposable where K : class, IMessage<K>, new() where T : class
{
	public ProtoSyncedFileData(IErrorReporter errorReporter, string? targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<ProtoSyncedFileData<K, T>, K, T?> deserializeFile, SyncedFileLoadedDelegate<ProtoSyncedFileData<K, T>, T> fileLoaded, SyncedFileDeletedDelegate<ProtoSyncedFileData<K, T>, T> fileDeleted, SyncedFileRenamedDelegate<ProtoSyncedFileData<K, T>, T> fileRenamed, SyncedFileUpdatedDelegate<ProtoSyncedFileData<K, T>, K, T> fileUpdated, SyncedFileValidateParseDelegate<ProtoSyncedFileData<K, T>, K?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null)
		: base(errorReporter, targetExtension, targetDirectory, deserializeFile, fileLoaded, fileDeleted, fileRenamed, fileUpdated, validateParse, prefixFile)
	{
		ParseAllFiles();
	}

	protected override bool OnTryParseFile(string name, string fullPath, out K? data)
	{
		if (!ProtoHelper.TryReadFile<K>(fullPath, out data))
		{
			Log.Warning("ProtoHelper was unable to parse the file " + fullPath + ". Skipping.");
		}
		return true;
	}

	protected override bool OnWriteFile(string name, string fullPath, K data)
	{
		FileIOResult fileIOResult = ProtoHelper.WriteFile(fullPath, data);
		if (!fileIOResult)
		{
			throw FileIOException.Create(fileIOResult);
		}
		return fileIOResult;
	}
}
