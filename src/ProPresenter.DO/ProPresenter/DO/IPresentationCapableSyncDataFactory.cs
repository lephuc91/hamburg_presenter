using Pro.DO;
using Pro.Serialization.DataManagement;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO;

public interface IPresentationCapableSyncDataFactory : ISyncDataFactory
{
	ISyncedPresentationFileData GetSyncedPresentationFileData(IPresentationMetadataCache metadataCache, string targetExtension, string targetDirectory, SyncedFileDeserializeDelegate<IPresentationLoadData, IPresentation?> deserializeFile, SyncedFileLoadedDelegate<IPresentation> fileLoaded, SyncedFileDeletedDelegate<IPresentation> fileDeleted, SyncedFileRenamedDelegate<IPresentation> fileRenamed, SyncedFileUpdatedDelegate<IPresentationLoadData, IPresentation> fileUpdated, SyncedFileValidateParseDelegate<IPresentationLoadData?>? validateParse = null, SyncedFilePrefixFileDelegate? prefixFile = null);
}
