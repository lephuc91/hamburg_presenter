using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Google.Protobuf;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Effects.Descriptions;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_fileSubscription" })]
public sealed class EffectsEntitySyncer : IDataSyncer<EffectsCollection>, IDisposable
{
	private readonly ConcurrentDictionary<Guid, (IEntityDocumentSyncer<IEffect.Types.IPresetDoc> Syncer, EffectsCollection Model)> _syncers = new ConcurrentDictionary<Guid, (IEntityDocumentSyncer<IEffect.Types.IPresetDoc>, EffectsCollection)>();

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IReadOnlyList<EffectDescription> _availableEffects;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IDisposable _fileSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public EffectsEntitySyncer(ICollectionStorage collectionStorage, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IReadOnlyList<EffectDescription> availableEffects, ICommonPathsWrapper commonPathsWrapper, Action<EffectsCollection> onAdd, bool initialLoadLegacy, Action<EffectsCollection> onRemove)
	{
		EffectsEntitySyncer effectsEntitySyncer = this;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_availableEffects = availableEffects;
		_commonPathsWrapper = commonPathsWrapper;
		_fileSubscription = collectionStorage.SubscribeForFiles(new ICollectionStorage.ObservationDetails
		{
			ContainingFolder = _commonPathsWrapper.EffectsPresets,
			LegacyFileExtension = ".effectPreset",
			LoadInitialFilesFromLegacy = initialLoadLegacy
		}, delegate(string path, bool loadLegacy, Guid? _)
		{
			EffectsCollection effectsCollection = new EffectsCollection(path);
			effectsEntitySyncer.InitialAdd(effectsCollection, loadLegacy);
			onAdd(effectsCollection);
		}, delegate(Guid id)
		{
			if (effectsEntitySyncer._syncers.TryRemove(id, out (IEntityDocumentSyncer<IEffect.Types.IPresetDoc>, EffectsCollection) value))
			{
				value.Item1.Dispose();
				onRemove(value.Item2);
			}
		}, delegate(Guid id, string path)
		{
			if (effectsEntitySyncer._syncers.TryGetValue(id, out (IEntityDocumentSyncer<IEffect.Types.IPresetDoc>, EffectsCollection) value2))
			{
				value2.Item1.FileRenamed(path);
			}
		});
	}

	public void Remove(EffectsCollection model)
	{
		if (_syncers.TryRemove(model.ID, out (IEntityDocumentSyncer<IEffect.Types.IPresetDoc>, EffectsCollection) value))
		{
			value.Item1.Delete();
		}
	}

	public void Add(EffectsCollection model)
	{
		IEntityDocumentSyncer<IEffect.Types.IPresetDoc> syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFromModel(_commonPathsWrapper.EffectsPresets, model.Name, ".effectPreset", model.ID, delegate(IEffect.Types.IPresetDoc doc)
		{
			ObjectBinder<EffectsCollection, IComplexCollection<IEffect>> objectBinder = EffectsCollection.CreateBinder(_scheduler, _factoryProvider.EntityFactory, _availableEffects, model, doc.Effects);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.SerializePreset().ToByteArray(), string.Empty, DocumentType.Effect);
		model.FilenameModified += delegate(EffectsCollection _, string newName)
		{
			syncer.RenameFile(newName);
		};
		_syncers[model.ID] = (syncer, model);
	}

	private void InitialAdd(EffectsCollection model, bool loadLegacy)
	{
		IEntityDocumentSyncer<IEffect.Types.IPresetDoc> syncer = (loadLegacy ? _factoryProvider.EntityDocumentSyncerFactory.CreateFromLegacy(_commonPathsWrapper.EffectsPresets, model.Name, ".effectPreset", delegate(IEffect.Types.IPresetDoc doc)
		{
			ObjectBinder<EffectsCollection, IComplexCollection<IEffect>> objectBinder = EffectsCollection.CreateBinder(_scheduler, _factoryProvider.EntityFactory, _availableEffects, model, doc.Effects);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.SerializePreset().ToByteArray(), delegate(byte[] data)
		{
			model.DeserializePreset(model.Name, Effect.Types.Preset.Parser.ParseFrom(data), _availableEffects);
			return model.ID;
		}, delegate
		{
		}) : _factoryProvider.EntityDocumentSyncerFactory.CreateFromCrdt(_commonPathsWrapper.EffectsPresets, model.Name, ".effectPreset", delegate(IEffect.Types.IPresetDoc doc, bool fromModel)
		{
			ObjectBinder<EffectsCollection, IComplexCollection<IEffect>> objectBinder2 = EffectsCollection.CreateBinder(_scheduler, _factoryProvider.EntityFactory, _availableEffects, model, doc.Effects);
			doc.RegisterLinkedDisposable(objectBinder2);
			if (fromModel)
			{
				objectBinder2.InitializeRightFromLeft();
			}
			else
			{
				objectBinder2.InitializeLeftFromRight();
			}
		}, () => model.SerializePreset().ToByteArray(), delegate
		{
		}));
		model.FilenameModified += delegate(EffectsCollection _, string newName)
		{
			syncer.RenameFile(newName);
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
