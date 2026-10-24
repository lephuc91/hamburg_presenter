using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.ComponentModel;
using Google.Protobuf;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Favorite;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_fileSubscription" })]
public sealed class EntityDataSyncer : IDataSyncer<FavoriteTransition>, IDisposable
{
	private readonly ConcurrentDictionary<Guid, (IEntityDocumentSyncer<ITransition.Types.IPresetDoc> Syncer, TransitionPreset Model)> _syncers = new ConcurrentDictionary<Guid, (IEntityDocumentSyncer<ITransition.Types.IPresetDoc>, TransitionPreset)>();

	private readonly string _containingFolder;

	private readonly IEntityDocumentSyncerFactory _entityDocumentSyncerFactory;

	private readonly IEntityFactory _entityFactory;

	private readonly ITransitionDescriptionCollection _descriptions;

	private readonly IDisposable _fileSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public EntityDataSyncer(ICollectionStorage collectionStorage, string containingFolder, IEntityDocumentSyncerFactory entityDocumentSyncerFactory, IEntityFactory entityFactory, ITransitionDescriptionCollection transitionDescriptions, Action<TransitionPreset> onAdd, Action<TransitionPreset> onRemove, bool initialLoadLegacy)
	{
		EntityDataSyncer entityDataSyncer = this;
		_containingFolder = containingFolder;
		_entityDocumentSyncerFactory = entityDocumentSyncerFactory;
		_entityFactory = entityFactory;
		_descriptions = transitionDescriptions;
		_fileSubscription = collectionStorage.SubscribeForFiles(new ICollectionStorage.ObservationDetails
		{
			ContainingFolder = containingFolder,
			LegacyFileExtension = ".transitionPreset",
			LoadInitialFilesFromLegacy = initialLoadLegacy
		}, delegate(string path, bool loadLegacy, Guid? _)
		{
			TransitionPreset transitionPreset = new TransitionPreset(null, canRename: true)
			{
				Name = path
			};
			entityDataSyncer.InitialAdd(transitionPreset, loadLegacy);
			onAdd(transitionPreset);
		}, delegate(Guid id)
		{
			if (entityDataSyncer._syncers.TryRemove(id, out (IEntityDocumentSyncer<ITransition.Types.IPresetDoc>, TransitionPreset) value))
			{
				value.Item1.Dispose();
				onRemove(value.Item2);
			}
		}, delegate(Guid id, string newPath)
		{
			if (entityDataSyncer._syncers.TryGetValue(id, out (IEntityDocumentSyncer<ITransition.Types.IPresetDoc>, TransitionPreset) value2))
			{
				value2.Item1.FileRenamed(newPath);
			}
		});
	}

	public void Remove(FavoriteTransition model)
	{
		Remove(model.Preset);
	}

	private void Remove(TransitionPreset model)
	{
		if (_syncers.TryRemove(model.ID, out (IEntityDocumentSyncer<ITransition.Types.IPresetDoc>, TransitionPreset) value))
		{
			value.Item1.Delete();
		}
	}

	public void Add(FavoriteTransition model)
	{
		IEntityDocumentSyncer<ITransition.Types.IPresetDoc> syncer = _entityDocumentSyncerFactory.CreateFromModel(_containingFolder, model.Preset.Name, ".transitionPreset", model.Preset.ID, delegate(ITransition.Types.IPresetDoc doc)
		{
			IReadOnlyObjectBinder readOnlyObjectBinder = TransitionPreset.CreateBinder(_entityFactory, model.Preset, doc);
			doc.RegisterLinkedDisposable(readOnlyObjectBinder);
			readOnlyObjectBinder.InitializeRightFromLeft();
		}, () => model.Preset.Serialize().ToByteArray(), string.Empty, DocumentType.Transition);
		model.Preset.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name")
			{
				syncer.RenameFile(model.Preset.Name);
			}
		};
		_syncers[model.Preset.ID] = (syncer, model.Preset);
	}

	private void InitialAdd(TransitionPreset model, bool loadLegacy)
	{
		IEntityDocumentSyncer<ITransition.Types.IPresetDoc> syncer = (loadLegacy ? _entityDocumentSyncerFactory.CreateFromLegacy(_containingFolder, model.Name, ".transitionPreset", delegate(ITransition.Types.IPresetDoc doc)
		{
			IReadOnlyObjectBinder readOnlyObjectBinder = TransitionPreset.CreateBinder(_entityFactory, model, doc);
			doc.RegisterLinkedDisposable(readOnlyObjectBinder);
			readOnlyObjectBinder.InitializeRightFromLeft();
		}, () => model.Serialize().ToByteArray(), delegate(byte[] data)
		{
			Transition.Types.Preset preset = Transition.Types.Preset.Parser.ParseFrom(data);
			model.ID = preset.Uuid.ToGuid();
			model.Name = preset.Name;
			model.UpdateParameters(new TransitionParameters(_descriptions, preset.Transition));
			return model.ID;
		}, delegate
		{
		}) : _entityDocumentSyncerFactory.CreateFromCrdt(_containingFolder, model.Name, ".transitionPreset", delegate(ITransition.Types.IPresetDoc doc, bool fromModel)
		{
			IReadOnlyObjectBinder readOnlyObjectBinder2 = TransitionPreset.CreateBinder(_entityFactory, model, doc);
			doc.RegisterLinkedDisposable(readOnlyObjectBinder2);
			if (fromModel)
			{
				readOnlyObjectBinder2.InitializeRightFromLeft();
			}
			else
			{
				readOnlyObjectBinder2.InitializeLeftFromRight();
			}
		}, () => model.Serialize().ToByteArray(), delegate
		{
		}));
		model.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name")
			{
				syncer.RenameFile(model.Name);
			}
		};
		_syncers[model.ID] = (syncer, model);
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
		foreach (var value in _syncers.Values)
		{
			value.Syncer.Dispose();
		}
		_syncers.Clear();
	}
}
