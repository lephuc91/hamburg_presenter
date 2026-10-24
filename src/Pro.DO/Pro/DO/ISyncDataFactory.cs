using System;
using Google.Protobuf;
using Pro.Serialization.DataManagement;

namespace Pro.DO;

public interface ISyncDataFactory
{
	IProtoSyncedData<T> GetSyncedData<T>(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<ProtoSyncedData<T>, T?>? validateParse = null) where T : class, IMessage<T>, new();

	IProtoSyncedFileData<K, T> GetSyncedFileData<K, T>(string? targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<ProtoSyncedFileData<K, T>, K, T?> deserializeFile, SyncedFileLoadedDelegate<ProtoSyncedFileData<K, T>, T> fileLoaded, SyncedFileDeletedDelegate<ProtoSyncedFileData<K, T>, T> fileDeleted, SyncedFileRenamedDelegate<ProtoSyncedFileData<K, T>, T> fileRenamed, SyncedFileUpdatedDelegate<ProtoSyncedFileData<K, T>, K, T> fileUpdated, SyncedFileValidateParseDelegate<ProtoSyncedFileData<K, T>, K?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null) where K : class, IMessage<K>, new() where T : class;
}
