using System;
using System.IO.Abstractions;
using Pro.Common.Logging;
using Pro.Entity.Factory;

namespace Pro.Entity.Persistence;

public class EntityDocumentSyncerFactory : EntityDocumentSyncerFactoryBase
{
	private readonly IFileSystem _fileSystem;

	private readonly ILogger _logger;

	private readonly IEntityDocumentRegistry _documentRegistry;

	private readonly ICollaborationPeerIdProvider _peerIdProvider;

	private readonly IEntityFileLockFactory _fileLockFactory;

	public EntityDocumentSyncerFactory(IFileSystem fileSystem, ILogger logger, IDocumentFactory factory, IEntityDocumentRegistry documentRegistry, ICollaborationPeerIdProvider peerIdProvider, IEntityFileLockFactory fileLockFactory)
		: base(factory)
	{
		_fileSystem = fileSystem;
		_logger = logger;
		_documentRegistry = documentRegistry;
		_peerIdProvider = peerIdProvider;
		_fileLockFactory = fileLockFactory;
	}

	protected override IEntityDocumentSyncer<TDoc> CreateSyncerFromCrdt<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Action<TDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return new EntityDocumentSyncer<TDoc>(containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults, documentFactory, _fileSystem, _logger, _documentRegistry, _peerIdProvider.CollaborationPeerId, _fileLockFactory);
	}

	protected override IEntityDocumentSyncer<TDoc> CreateSyncerFromLegacy<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Action<TDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return new EntityDocumentSyncer<TDoc>(containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults, documentFactory, _fileSystem, _logger, _documentRegistry, _peerIdProvider.CollaborationPeerId, _fileLockFactory);
	}

	protected override IEntityDocumentSyncer<TDoc> CreateSyncerFromModel<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<TDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return new EntityDocumentSyncer<TDoc>(containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType, documentFactory, _fileSystem, _logger, _documentRegistry, _peerIdProvider.CollaborationPeerId, _fileLockFactory);
	}
}
