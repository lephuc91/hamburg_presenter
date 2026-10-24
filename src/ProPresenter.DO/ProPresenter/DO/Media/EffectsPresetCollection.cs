using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Effects.Descriptions;
using Pro.Entity.Persistence;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer" })]
public class EffectsPresetCollection : ImmutableObservableCollection<EffectsCollection>, IDisposable
{
	private IDataSyncer<EffectsCollection>? _syncer;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IFlagService _featureFlags;

	private readonly IUiScheduler _uiScheduler;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IReadOnlyList<EffectDescription> _availableEffects;

	private readonly ICollectionStorage _collectionStorage;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public EffectsPresetCollection(ISyncDataFactory syncDataFactory, IFlagService featureFlags, IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, IReadOnlyList<EffectDescription> availableEffects, ICollectionStorage collectionStorage, ICommonPathsWrapper commonPathsWrapper, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_featureFlags = featureFlags;
		_uiScheduler = uiScheduler;
		_factoryProvider = factoryProvider;
		_availableEffects = availableEffects;
		_collectionStorage = collectionStorage;
		_commonPathsWrapper = commonPathsWrapper;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncer = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		IDataSyncer<EffectsCollection> syncer;
		if (!_featureFlags.IsFlagEnabled(Flag.Cloud))
		{
			IDataSyncer<EffectsCollection> dataSyncer = new EffectsProtoSyncer(_syncDataFactory, _availableEffects, _commonPathsWrapper, delegate(EffectsCollection e)
			{
				base.Collection.Add(e);
			}, delegate(EffectsCollection e)
			{
				base.Collection.Remove(e);
			});
			syncer = dataSyncer;
		}
		else
		{
			IDataSyncer<EffectsCollection> dataSyncer = new EffectsEntitySyncer(_collectionStorage, _factoryProvider, _uiScheduler, _availableEffects, _commonPathsWrapper, delegate(EffectsCollection e)
			{
				base.Collection.Add(e);
			}, loadLegacy, delegate(EffectsCollection e)
			{
				base.Collection.Remove(e);
			});
			syncer = dataSyncer;
		}
		_syncer = syncer;
	}

	public void AddNewEffectsPreset(EffectsCollection newPreset)
	{
		OnAddEffectsPreset(newPreset, null);
	}

	public void InsertNewEffectsPreset(int index, EffectsCollection newPreset)
	{
		OnAddEffectsPreset(newPreset, index);
	}

	private void OnAddEffectsPreset(EffectsCollection preset, int? index = null)
	{
		_syncer?.Add(preset);
		if (!index.HasValue)
		{
			base.Collection.Add(preset);
		}
		else
		{
			base.Collection.Insert(index.Value, preset);
		}
	}

	public void RemoveEffectsPreset(EffectsCollection preset)
	{
		_syncer?.Remove(preset);
		base.Collection.Remove(preset);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
