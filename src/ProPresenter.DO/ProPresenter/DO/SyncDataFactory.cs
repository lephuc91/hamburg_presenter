using System;
using Google.Protobuf;
using Pro.Common.ErrorReporting;
using Pro.Common.MessageService;
using Pro.DO;
using Pro.Serialization.DataManagement;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO;

public class SyncDataFactory : IPresentationCapableSyncDataFactory, ISyncDataFactory
{
	private readonly IMessageService _messageService;

	private readonly IErrorReporter _errorReporter;

	public SyncDataFactory(IMessageService messageService, IErrorReporter errorReporter)
	{
		_messageService = messageService;
		_errorReporter = errorReporter;
	}

	public IProtoSyncedData<T> GetSyncedData<T>(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<ProtoSyncedData<T>, T?>? validateParse = null) where T : class, IMessage<T>, new()
	{
		return new ProtoSyncedData<T>(targetDirectory, targetFilename, dataUpdated, dataCleared, validateParse);
	}

	public IProtoSyncedFileData<K, T> GetSyncedFileData<K, T>(string? targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<ProtoSyncedFileData<K, T>, K, T?> deserializeFile, SyncedFileLoadedDelegate<ProtoSyncedFileData<K, T>, T> fileLoaded, SyncedFileDeletedDelegate<ProtoSyncedFileData<K, T>, T> fileDeleted, SyncedFileRenamedDelegate<ProtoSyncedFileData<K, T>, T> fileRenamed, SyncedFileUpdatedDelegate<ProtoSyncedFileData<K, T>, K, T> fileUpdated, SyncedFileValidateParseDelegate<ProtoSyncedFileData<K, T>, K?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null) where K : class, IMessage<K>, new() where T : class
	{
		return new ProtoSyncedFileData<K, T>(_errorReporter, targetExtension, targetDirectory, deserializeFile, fileLoaded, fileDeleted, fileRenamed, fileUpdated, validateParse, prefixFile);
	}

	public ISyncedPresentationFileData GetSyncedPresentationFileData(IPresentationMetadataCache metadataCache, string targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<IPresentationLoadData, IPresentation?> deserializeFile, SyncedFileLoadedDelegate<IPresentation> fileLoaded, SyncedFileDeletedDelegate<IPresentation> fileDeleted, SyncedFileRenamedDelegate<IPresentation> fileRenamed, SyncedFileUpdatedDelegate<IPresentationLoadData, IPresentation> fileUpdated, SyncedFileValidateParseDelegate<IPresentationLoadData?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null)
	{
		return new SyncedPresentationFileData(_errorReporter, metadataCache, _messageService, targetExtension, targetDirectory, deserializeFile, fileLoaded, fileDeleted, fileRenamed, fileUpdated, validateParse, prefixFile);
	}
}
