using System;
using Pro.Entity.Factory;
using Pro.Entity.Persistence;

namespace Pro.Entity;

public abstract class EntityDocumentSyncerFactoryBase : IEntityDocumentSyncerFactory, IEntityDocSyncerFactory<ICcliDocumentDoc>, IEntityDocSyncerFactory<ICalendarDoc>, IEntityDocSyncerFactory<IClearGroupsDocumentDoc>, IEntityDocSyncerFactory<IEffect.Types.IPresetDoc>, IEntityDocSyncerFactory<IKeyMappingDocumentDoc>, IEntityDocSyncerFactory<ILibraryDoc>, IEntityDocSyncerFactory<IMacrosDocumentDoc>, IEntityDocSyncerFactory<IMessageDocumentDoc>, IEntityDocSyncerFactory<IMessageLocalDocumentDoc>, IEntityDocSyncerFactory<IPlaylistDocumentDoc>, IEntityDocSyncerFactory<IPlaylistTemplateDoc>, IEntityDocSyncerFactory<IPresentationDoc>, IEntityDocSyncerFactory<IProGroupsDocumentDoc>, IEntityDocSyncerFactory<IProLabelsDocumentDoc>, IEntityDocSyncerFactory<IProPresenterCommunicationsDoc>, IEntityDocSyncerFactory<IProPresenterLocalCommunicationsDoc>, IEntityDocSyncerFactory<IProPresenterLocalWorkspaceDoc>, IEntityDocSyncerFactory<IProPresenterWorkspaceDoc>, IEntityDocSyncerFactory<IPropDocumentDoc>, IEntityDocSyncerFactory<IStage.Types.IDocumentDoc>, IEntityDocSyncerFactory<ITemplate.Types.IDocumentDoc>, IEntityDocSyncerFactory<ITestPatternDocumentDoc>, IEntityDocSyncerFactory<ITimersDocumentDoc>, IEntityDocSyncerFactory<ITimersLocalDocumentDoc>, IEntityDocSyncerFactory<ITransition.Types.IPresetDoc>
{
	private readonly IDocumentFactory _documentFactory;

	protected EntityDocumentSyncerFactoryBase(IDocumentFactory documentFactory)
	{
		_documentFactory = documentFactory;
	}

	protected abstract IEntityDocumentSyncer<TDoc> CreateSyncerFromLegacy<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Action<TDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults) where TDoc : IEntityDocument;

	protected abstract IEntityDocumentSyncer<TDoc> CreateSyncerFromCrdt<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Action<TDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults) where TDoc : IEntityDocument;

	protected abstract IEntityDocumentSyncer<TDoc> CreateSyncerFromModel<TDoc>(IDocFactory<TDoc> documentFactory, string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<TDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType) where TDoc : IEntityDocument;

	IEntityDocumentSyncer<ICcliDocumentDoc> IEntityDocSyncerFactory<ICcliDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ICcliDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ICcliDocumentDoc> IEntityDocSyncerFactory<ICcliDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ICcliDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ICcliDocumentDoc> IEntityDocSyncerFactory<ICcliDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ICcliDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ICalendarDoc> IEntityDocSyncerFactory<ICalendarDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ICalendarDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ICalendarDoc> IEntityDocSyncerFactory<ICalendarDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ICalendarDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ICalendarDoc> IEntityDocSyncerFactory<ICalendarDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ICalendarDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IClearGroupsDocumentDoc> IEntityDocSyncerFactory<IClearGroupsDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IClearGroupsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IClearGroupsDocumentDoc> IEntityDocSyncerFactory<IClearGroupsDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IClearGroupsDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IClearGroupsDocumentDoc> IEntityDocSyncerFactory<IClearGroupsDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IClearGroupsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IEffect.Types.IPresetDoc> IEntityDocSyncerFactory<IEffect.Types.IPresetDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IEffect.Types.IPresetDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IEffect.Types.IPresetDoc> IEntityDocSyncerFactory<IEffect.Types.IPresetDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IEffect.Types.IPresetDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IEffect.Types.IPresetDoc> IEntityDocSyncerFactory<IEffect.Types.IPresetDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IEffect.Types.IPresetDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IKeyMappingDocumentDoc> IEntityDocSyncerFactory<IKeyMappingDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IKeyMappingDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IKeyMappingDocumentDoc> IEntityDocSyncerFactory<IKeyMappingDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IKeyMappingDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IKeyMappingDocumentDoc> IEntityDocSyncerFactory<IKeyMappingDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IKeyMappingDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ILibraryDoc> IEntityDocSyncerFactory<ILibraryDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ILibraryDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ILibraryDoc> IEntityDocSyncerFactory<ILibraryDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ILibraryDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ILibraryDoc> IEntityDocSyncerFactory<ILibraryDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ILibraryDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IMacrosDocumentDoc> IEntityDocSyncerFactory<IMacrosDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IMacrosDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMacrosDocumentDoc> IEntityDocSyncerFactory<IMacrosDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IMacrosDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMacrosDocumentDoc> IEntityDocSyncerFactory<IMacrosDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IMacrosDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IMessageDocumentDoc> IEntityDocSyncerFactory<IMessageDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IMessageDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMessageDocumentDoc> IEntityDocSyncerFactory<IMessageDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IMessageDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMessageDocumentDoc> IEntityDocSyncerFactory<IMessageDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IMessageDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IMessageLocalDocumentDoc> IEntityDocSyncerFactory<IMessageLocalDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IMessageLocalDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMessageLocalDocumentDoc> IEntityDocSyncerFactory<IMessageLocalDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IMessageLocalDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IMessageLocalDocumentDoc> IEntityDocSyncerFactory<IMessageLocalDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IMessageLocalDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IPlaylistDocumentDoc> IEntityDocSyncerFactory<IPlaylistDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IPlaylistDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPlaylistDocumentDoc> IEntityDocSyncerFactory<IPlaylistDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IPlaylistDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPlaylistDocumentDoc> IEntityDocSyncerFactory<IPlaylistDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IPlaylistDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IPlaylistTemplateDoc> IEntityDocSyncerFactory<IPlaylistTemplateDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IPlaylistTemplateDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPlaylistTemplateDoc> IEntityDocSyncerFactory<IPlaylistTemplateDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IPlaylistTemplateDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPlaylistTemplateDoc> IEntityDocSyncerFactory<IPlaylistTemplateDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IPlaylistTemplateDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IPresentationDoc> IEntityDocSyncerFactory<IPresentationDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IPresentationDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPresentationDoc> IEntityDocSyncerFactory<IPresentationDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IPresentationDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPresentationDoc> IEntityDocSyncerFactory<IPresentationDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IPresentationDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProGroupsDocumentDoc> IEntityDocSyncerFactory<IProGroupsDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProGroupsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProGroupsDocumentDoc> IEntityDocSyncerFactory<IProGroupsDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProGroupsDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProGroupsDocumentDoc> IEntityDocSyncerFactory<IProGroupsDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProGroupsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProLabelsDocumentDoc> IEntityDocSyncerFactory<IProLabelsDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProLabelsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProLabelsDocumentDoc> IEntityDocSyncerFactory<IProLabelsDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProLabelsDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProLabelsDocumentDoc> IEntityDocSyncerFactory<IProLabelsDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProLabelsDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProPresenterCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterCommunicationsDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterCommunicationsDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterCommunicationsDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterCommunicationsDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterCommunicationsDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProPresenterCommunicationsDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProPresenterLocalCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterLocalCommunicationsDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterLocalCommunicationsDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterLocalCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterLocalCommunicationsDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterLocalCommunicationsDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterLocalCommunicationsDoc> IEntityDocSyncerFactory<IProPresenterLocalCommunicationsDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProPresenterLocalCommunicationsDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProPresenterLocalWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterLocalWorkspaceDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterLocalWorkspaceDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterLocalWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterLocalWorkspaceDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterLocalWorkspaceDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterLocalWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterLocalWorkspaceDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProPresenterLocalWorkspaceDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IProPresenterWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterWorkspaceDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterWorkspaceDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterWorkspaceDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IProPresenterWorkspaceDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IProPresenterWorkspaceDoc> IEntityDocSyncerFactory<IProPresenterWorkspaceDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IProPresenterWorkspaceDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IPropDocumentDoc> IEntityDocSyncerFactory<IPropDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IPropDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPropDocumentDoc> IEntityDocSyncerFactory<IPropDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IPropDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IPropDocumentDoc> IEntityDocSyncerFactory<IPropDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IPropDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<IStage.Types.IDocumentDoc> IEntityDocSyncerFactory<IStage.Types.IDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<IStage.Types.IDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IStage.Types.IDocumentDoc> IEntityDocSyncerFactory<IStage.Types.IDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<IStage.Types.IDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<IStage.Types.IDocumentDoc> IEntityDocSyncerFactory<IStage.Types.IDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<IStage.Types.IDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> IEntityDocSyncerFactory<ITemplate.Types.IDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ITemplate.Types.IDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> IEntityDocSyncerFactory<ITemplate.Types.IDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ITemplate.Types.IDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> IEntityDocSyncerFactory<ITemplate.Types.IDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ITemplate.Types.IDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ITestPatternDocumentDoc> IEntityDocSyncerFactory<ITestPatternDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ITestPatternDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITestPatternDocumentDoc> IEntityDocSyncerFactory<ITestPatternDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ITestPatternDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITestPatternDocumentDoc> IEntityDocSyncerFactory<ITestPatternDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ITestPatternDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ITimersDocumentDoc> IEntityDocSyncerFactory<ITimersDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ITimersDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITimersDocumentDoc> IEntityDocSyncerFactory<ITimersDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ITimersDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITimersDocumentDoc> IEntityDocSyncerFactory<ITimersDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ITimersDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ITimersLocalDocumentDoc> IEntityDocSyncerFactory<ITimersLocalDocumentDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ITimersLocalDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITimersLocalDocumentDoc> IEntityDocSyncerFactory<ITimersLocalDocumentDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ITimersLocalDocumentDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITimersLocalDocumentDoc> IEntityDocSyncerFactory<ITimersLocalDocumentDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ITimersLocalDocumentDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}

	IEntityDocumentSyncer<ITransition.Types.IPresetDoc> IEntityDocSyncerFactory<ITransition.Types.IPresetDoc>.CreateSyncerFromLegacy(string containingFolder, string baseFileName, string legacyExtension, Action<ITransition.Types.IPresetDoc> initializeSync, Func<byte[]> serializeLegacyDocument, Func<byte[], Guid?> deserializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromLegacy(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, deserializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITransition.Types.IPresetDoc> IEntityDocSyncerFactory<ITransition.Types.IPresetDoc>.CreateSyncerFromCrdt(string containingFolder, string baseFileName, string legacyExtension, Action<ITransition.Types.IPresetDoc, bool> initializeSync, Func<byte[]> serializeLegacyDocument, System.Action loadDefaults)
	{
		return CreateSyncerFromCrdt(_documentFactory, containingFolder, baseFileName, legacyExtension, initializeSync, serializeLegacyDocument, loadDefaults);
	}

	IEntityDocumentSyncer<ITransition.Types.IPresetDoc> IEntityDocSyncerFactory<ITransition.Types.IPresetDoc>.CreateSyncerFromModel(string containingFolder, string baseFileName, string legacyExtension, Guid documentId, Action<ITransition.Types.IPresetDoc> initializeSync, Func<byte[]> serializeLegacyDocument, string relativeDirectoryPath, DocumentType documentType)
	{
		return CreateSyncerFromModel(_documentFactory, containingFolder, baseFileName, legacyExtension, documentId, initializeSync, serializeLegacyDocument, relativeDirectoryPath, documentType);
	}
}
