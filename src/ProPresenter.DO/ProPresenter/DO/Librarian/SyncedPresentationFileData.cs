using System;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.MessageService;
using Pro.Serialization.DataManagement;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Sync;

namespace ProPresenter.DO.Librarian;

public class SyncedPresentationFileData : SyncedFileData<SyncedPresentationFileData, IPresentationLoadData, IPresentation>, ISyncedPresentationFileData, ISyncedFileData<IPresentationLoadData, IPresentation>, IDisposable
{
	private readonly IPresentationMetadataCache _metadataCache;

	private readonly IMessageService _messageService;

	public SyncedPresentationFileData(IErrorReporter errorReporter, IPresentationMetadataCache metadataCache, IMessageService messageService, string targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<IPresentationLoadData, IPresentation?> deserializeFile, SyncedFileLoadedDelegate<IPresentation> fileLoaded, SyncedFileDeletedDelegate<IPresentation> fileDeleted, SyncedFileRenamedDelegate<IPresentation> fileRenamed, SyncedFileUpdatedDelegate<IPresentationLoadData, IPresentation> fileUpdated, SyncedFileValidateParseDelegate<IPresentationLoadData?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null)
		: base(errorReporter, targetExtension, targetDirectory, (SyncedFileDeserializeDelegate<SyncedPresentationFileData, IPresentationLoadData, IPresentation?>)((SyncedPresentationFileData s, string k, IPresentationLoadData t) => deserializeFile(k, t)), (SyncedFileLoadedDelegate<SyncedPresentationFileData, IPresentation>)delegate(SyncedPresentationFileData k, IPresentation t)
		{
			fileLoaded(t);
		}, (SyncedFileDeletedDelegate<SyncedPresentationFileData, IPresentation>)delegate(SyncedPresentationFileData s, string f, IPresentation t)
		{
			fileDeleted(f, t);
		}, (SyncedFileRenamedDelegate<SyncedPresentationFileData, IPresentation>)delegate(SyncedPresentationFileData s, string o, string n, IPresentation t)
		{
			fileRenamed(o, n, t);
		}, (SyncedFileUpdatedDelegate<SyncedPresentationFileData, IPresentationLoadData, IPresentation>)delegate(SyncedPresentationFileData s, string f, IPresentationLoadData k, IPresentation t)
		{
			fileUpdated(f, k, t);
		}, (SyncedFileValidateParseDelegate<SyncedPresentationFileData, IPresentationLoadData?>?)((SyncedPresentationFileData s, string f, IPresentationLoadData? k) => validateParse?.Invoke(f, k) ?? true), prefixFile)
	{
		_metadataCache = metadataCache;
		_messageService = messageService;
		ParseAllFiles();
	}

	protected override bool OnTryParseFile(string filename, string fullPath, out IPresentationLoadData data)
	{
		data = new PresentationLoadData(_metadataCache, fullPath);
		return true;
	}

	protected override bool OnWriteFile(string filename, string fullPath, IPresentationLoadData data)
	{
		FileIOResult fileIOResult = data.WriteProtoData(fullPath);
		_messageService.PublishMessage(new SyncMessage(fileIOResult));
		return fileIOResult;
	}

	string ISyncedPresentationFileData.GenerateFullPath(string name)
	{
		return GenerateFullPath(name);
	}

	bool ISyncedPresentationFileData.TryGetParsedData(IPresentation model, out IPresentationLoadData? data)
	{
		return TryGetParsedData(model, out data);
	}

	void ISyncedPresentationFileData.CommitAllInWriteQueue()
	{
		CommitAllInWriteQueue();
	}

	void ISyncedPresentationFileData.Move(string newPath)
	{
		Move(newPath);
	}
}
