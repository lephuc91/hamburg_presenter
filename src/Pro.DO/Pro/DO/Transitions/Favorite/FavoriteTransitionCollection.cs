using System;
using System.CodeDom.Compiler;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Persistence;

namespace Pro.DO.Transitions.Favorite;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer", "_changeWorkspaceRegistration" })]
public class FavoriteTransitionCollection : TransitionCollectionBase<FavoriteTransition>, IDisposable
{
	private IDataSyncer<FavoriteTransition>? _syncer;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly ITransitionDescriptionCollection _descriptions;

	private readonly IFlagService _flagService;

	private readonly ICollectionStorage _collectionStorage;

	private readonly IEntityDocumentSyncerFactory _entityDocumentSyncerFactory;

	private readonly IEntityFactory _entityFactory;

	private readonly IDisposable _changeWorkspaceRegistration;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public FavoriteTransitionCollection(ISyncDataFactory syncDataFactory, ITransitionDescriptionCollection transitionDescriptions, IWorkspacePathProvider workspacePathProvider, IFlagService flagService, ICollectionStorage collectionStorage, IEntityDocumentSyncerFactory entityDocumentSyncerFactory, IEntityFactory entityFactory)
	{
		_syncDataFactory = syncDataFactory;
		_descriptions = transitionDescriptions;
		_flagService = flagService;
		_collectionStorage = collectionStorage;
		_entityDocumentSyncerFactory = entityDocumentSyncerFactory;
		_entityFactory = entityFactory;
		SetupSync(workspacePathProvider.Current, workspacePathProvider.LoadLegacy);
		_changeWorkspaceRegistration = workspacePathProvider.RegisterChange(TeardownSync, SetupSync);
	}

	public FavoriteTransition Add(string name, TransitionParameters parameters)
	{
		FavoriteTransition favoriteTransition = new FavoriteTransition(new TransitionPreset(name, parameters, canRename: true));
		base.Collection.Insert(0, favoriteTransition);
		_syncer?.Add(favoriteTransition);
		return favoriteTransition;
	}

	public void Remove(FavoriteTransition transition)
	{
		base.Collection.Remove(transition);
		_syncer?.Remove(transition);
	}

	private void TeardownSync()
	{
		_syncer?.Dispose();
		_syncer = null;
		base.Collection.Clear();
	}

	private void SetupSync(string newDirectory, bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = new EntityDataSyncer(_collectionStorage, newDirectory, _entityDocumentSyncerFactory, _entityFactory, _descriptions, delegate(TransitionPreset model)
			{
				base.Collection.Insert(0, new FavoriteTransition(model));
			}, delegate(TransitionPreset model)
			{
				base.Collection.RemoveIf((FavoriteTransition t) => t.Preset == model);
			}, loadLegacy);
			return;
		}
		_syncer = new ProtoDataSyncer(_syncDataFactory, newDirectory, _descriptions, delegate(TransitionPreset model)
		{
			base.Collection.Insert(0, new FavoriteTransition(model));
		}, delegate(TransitionPreset model)
		{
			base.Collection.RemoveIf((FavoriteTransition t) => t.Preset == model);
		});
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
			_syncer?.Dispose();
			_changeWorkspaceRegistration.Dispose();
		}
	}
}
