using System;

namespace Pro.Entity.Persistence;

public interface IEntityDocSyncerFactory<out T> where T : IEntityDocument
{
	IEntityDocumentSyncer<T> CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<T> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults);

	IEntityDocumentSyncer<T> CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<T, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults);

	IEntityDocumentSyncer<T> CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid ID, Action<T> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType);
}
