using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.IO.Abstractions;
using Google.Protobuf;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_fileSubscription" })]
public sealed class PresentationEntitySyncer : IPresentationDataSyncer, IDataSyncer<ProPresenter.DO.Presentation.IPresentation>, IDisposable
{
	private sealed record SyncerData(ProPresenter.DO.Presentation.IPresentation Model, IEntityDocumentSyncer<IPresentationDoc> Syncer, IPresentationLoadData Data);

	private readonly ConcurrentDictionary<Guid, SyncerData> _syncers = new ConcurrentDictionary<Guid, SyncerData>();

	private string _libraryName;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IFileSystem _fileSystem;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly IPresentationMetadataCache _metadataCache;

	private readonly Action<IPresentationLoadData?> _onPresentationDataChanged;

	private readonly Action<ProPresenter.DO.Presentation.IPresentation, string> _onRename;

	private readonly IDisposable _fileSubscription;

	private bool _ignoreChanges;

	private volatile bool _initialLoadComplete;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private string LibraryPath => _fileSystem.Path.Combine(_commonPathsWrapper.Libraries, _libraryName);

	public PresentationEntitySyncer(string libraryName, ICommonPathsWrapper commonPathsWrapper, ICollectionStorage collectionStorage, IFileSystem fileSystem, IPresentationFactory presentationFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, IPresentationMetadataCache metadataCache, Action<DocumentCue> onAdd, Action<ProPresenter.DO.Presentation.IPresentation> onRemove, Action<ProPresenter.DO.Presentation.IPresentation, string> onRename, Action<IPresentationLoadData?> onPresentationDataChanged, bool initialLoadLegacy)
	{
		PresentationEntitySyncer presentationEntitySyncer = this;
		_libraryName = libraryName;
		_commonPathsWrapper = commonPathsWrapper;
		_fileSystem = fileSystem;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		_metadataCache = metadataCache;
		_onRename = onRename;
		_onPresentationDataChanged = onPresentationDataChanged;
		_fileSubscription = collectionStorage.SubscribeForFiles(new ICollectionStorage.ObservationDetails
		{
			ContainingFolder = LibraryPath,
			LegacyFileExtension = ".pro",
			LoadInitialFilesFromLegacy = initialLoadLegacy
		}, delegate(string path, bool loadLegacy, Guid? _)
		{
			CustomPresentation customPresentation = presentationFactory.CreateCustom();
			presentationEntitySyncer.Add(path, customPresentation, loadLegacy);
			DocumentCue obj = new DocumentCue(customPresentation, supportsArrangement: false, newID: false);
			onAdd(obj);
		}, delegate(Guid id)
		{
			if (presentationEntitySyncer._syncers.TryRemove(id, out SyncerData value))
			{
				value.Model.FileNameModified -= presentationEntitySyncer.Presentation_FileNameModified;
				value.Model.DataModified -= presentationEntitySyncer.Presentation_DataModified;
				value.Syncer.Dispose();
				onRemove(value.Model);
			}
		}, delegate(Guid id, string path)
		{
			if (presentationEntitySyncer._syncers.TryGetValue(id, out SyncerData value2))
			{
				value2.Syncer.FileRenamed(path);
				onRename(value2.Model, path);
			}
		});
		_initialLoadComplete = true;
	}

	private void Add(string fileName, CustomPresentation model, bool loadLegacy)
	{
		_ignoreChanges = true;
		IEntityDocumentSyncer<IPresentationDoc> entityDocumentSyncer = (loadLegacy ? _factoryProvider.EntityDocumentSyncerFactory.CreateFromLegacy(LibraryPath, fileName, ".pro", delegate(IPresentationDoc doc)
		{
			ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, doc);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.Serialize().ToByteArray(), delegate(byte[] data)
		{
			PresentationLoadData data2 = new PresentationLoadData(_metadataCache, Pro.SerializationInterop.RVProtoData.Presentation.Parser.ParseFrom(data));
			model.Deserialize(data2, fileName);
			return model.ID;
		}, delegate
		{
		}) : _factoryProvider.EntityDocumentSyncerFactory.CreateFromCrdt(LibraryPath, fileName, ".pro", delegate(IPresentationDoc doc, bool fromModel)
		{
			ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder2 = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, doc);
			doc.RegisterLinkedDisposable(objectBinder2);
			if (fromModel)
			{
				objectBinder2.InitializeRightFromLeft();
			}
			else
			{
				objectBinder2.InitializeLeftFromRight();
			}
		}, () => model.Serialize().ToByteArray(), delegate
		{
		}));
		model.FileNameModified += Presentation_FileNameModified;
		model.DataModified += Presentation_DataModified;
		_syncers[model.ID] = new SyncerData(model, entityDocumentSyncer, new PresentationLoadData(_metadataCache, model.Serialize()));
		if (_initialLoadComplete)
		{
			entityDocumentSyncer.AddToDocumentRegistry(_libraryName, DocumentType.Presentation);
		}
		_ignoreChanges = false;
	}

	public void Add(ProPresenter.DO.Presentation.IPresentation model)
	{
		IEntityDocumentSyncer<IPresentationDoc> syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFromModel(LibraryPath, model.Name, ".pro", model.ID, delegate(IPresentationDoc doc)
		{
			ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, doc);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.Serialize().ToByteArray(), _libraryName, DocumentType.Presentation);
		model.FileNameModified += Presentation_FileNameModified;
		model.DataModified += Presentation_DataModified;
		_syncers[model.ID] = new SyncerData(model, syncer, new PresentationLoadData(_metadataCache, model.Serialize()));
	}

	public bool TryRenameLibrary(string newName)
	{
		string text = _fileSystem.Path.Combine(_commonPathsWrapper.Libraries, newName);
		if (_fileSystem.Path.Exists(text))
		{
			return false;
		}
		foreach (SyncerData value in _syncers.Values)
		{
			value.Syncer.MoveFile(text);
		}
		_fileSystem.Directory.Delete(LibraryPath, recursive: true);
		_libraryName = newName;
		return true;
	}

	private void Presentation_DataModified(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		if (!_ignoreChanges && _syncers.TryGetValue(presentation.ID, out SyncerData value))
		{
			value.Data.UpdateProtoData(presentation.Serialize());
			_onPresentationDataChanged(value.Data);
		}
	}

	private void Presentation_FileNameModified(ProPresenter.DO.Presentation.IPresentation model, string newName)
	{
		if (!_ignoreChanges && _syncers.TryGetValue(model.ID, out SyncerData value))
		{
			value.Syncer.RenameFile(newName);
			_onRename(model, newName);
		}
	}

	public void Remove(ProPresenter.DO.Presentation.IPresentation model)
	{
		model.FileNameModified -= Presentation_FileNameModified;
		model.DataModified -= Presentation_DataModified;
		if (_syncers.TryRemove(model.ID, out SyncerData value))
		{
			value.Syncer.Delete();
		}
	}

	public void OnRemoved(ProPresenter.DO.Presentation.IPresentation model)
	{
		model.FileNameModified -= Presentation_FileNameModified;
		model.DataModified -= Presentation_DataModified;
		if (_syncers.TryRemove(model.ID, out SyncerData value))
		{
			value.Syncer.Dispose();
		}
	}

	public void UpdateFile(IPresentationLoadData? data, ProPresenter.DO.Presentation.IPresentation model)
	{
		_syncers.TryGetValue(model.ID, out SyncerData _);
	}

	public bool TryGetData(ProPresenter.DO.Presentation.IPresentation model, out IPresentationLoadData? loadData)
	{
		loadData = null;
		if (_syncers.TryGetValue(model.ID, out SyncerData value))
		{
			loadData = value.Data;
			return true;
		}
		return false;
	}

	public void CommitAllInWriteQueue()
	{
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_fileSubscription.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (SyncerData value in _syncers.Values)
		{
			value.Syncer.Dispose();
		}
		_syncers.Clear();
	}
}
