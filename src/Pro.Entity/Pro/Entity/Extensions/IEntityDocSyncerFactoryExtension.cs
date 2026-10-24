using System;
using Pro.Entity.Persistence;

namespace Pro.Entity.Extensions;

public static class IEntityDocSyncerFactoryExtension
{
	public static IEntityDocumentSyncer<T> CreateFromLegacy<T>(this IEntityDocSyncerFactory<T> factory, string containingFolder, string baseFileName, string legacyExtension, Action<T> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults) where T : IEntityDocument
	{
		return factory.CreateSyncerFromLegacy(containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	public static IEntityDocumentSyncer<T> CreateFromCrdt<T>(this IEntityDocSyncerFactory<T> factory, string containingFolder, string baseFileName, string legacyExtension, Action<T, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults) where T : IEntityDocument
	{
		return factory.CreateSyncerFromCrdt(containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	public static IEntityDocumentSyncer<T> CreateFromModel<T>(this IEntityDocSyncerFactory<T> factory, string containingFolder, string baseFileName, string legacyExtension, Guid id, Action<T> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType) where T : IEntityDocument
	{
		return factory.CreateSyncerFromModel(containingFolder, baseFileName, legacyExtension, id, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}
}
