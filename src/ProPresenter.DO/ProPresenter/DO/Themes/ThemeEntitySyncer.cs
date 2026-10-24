using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.IO.Abstractions;
using Google.Protobuf;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Themes;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_fileSubscription" })]
public sealed class ThemeEntitySyncer : IDataSyncer<Theme>, IDisposable
{
	private readonly ConcurrentDictionary<Guid, (IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> Syncer, Theme Theme)> _syncers = new ConcurrentDictionary<Guid, (IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc>, Theme)>();

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IFlagService _flagService;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IFileSystem _fileSystem;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly IDisposable _fileSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ThemeEntitySyncer(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, ICommonPathsWrapper commonPathsWrapper, IFileSystem fileSystem, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, ICollectionStorage storage, Action<Theme> onAdd, Action<Theme> onRemove, bool initialLoadLegacy)
	{
		ThemeEntitySyncer themeEntitySyncer = this;
		_factoryProvider = factoryProvider;
		_flagService = flagService;
		_commonPathsWrapper = commonPathsWrapper;
		_fileSystem = fileSystem;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		_fileSubscription = storage.SubscribeForFiles(new ICollectionStorage.ObservationDetails
		{
			ContainingFolder = commonPathsWrapper.Themes,
			FileName = "Theme",
			AllowNesting = true,
			LoadInitialFilesFromLegacy = initialLoadLegacy
		}, delegate(string path, bool loadLegacy, Guid? id)
		{
			IDirectoryInfo directory = fileSystem.FileInfo.New(fileSystem.Path.Combine(commonPathsWrapper.Themes, path)).Directory;
			directory.ThrowWhenNull("themeFolder");
			string directoryName = themeEntitySyncer._fileSystem.Path.GetDirectoryName(path);
			directoryName.ThrowWhenNull("relativeThemePath");
			Theme theme = new Theme(factoryProvider, transitionDescriptions, flagService, directory.Name, directoryName, id);
			themeEntitySyncer.InitialAdd(directory.FullName, theme, loadLegacy);
			onAdd(theme);
		}, delegate(Guid id)
		{
			if (themeEntitySyncer._syncers.TryRemove(id, out (IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc>, Theme) value))
			{
				value.Item1.Dispose();
				onRemove(value.Item2);
			}
		}, delegate
		{
		});
	}

	private void InitialAdd(string themeFolder, Theme model, bool loadLegacy)
	{
		IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> item = (loadLegacy ? _factoryProvider.EntityDocumentSyncerFactory.CreateFromLegacy(themeFolder, "Theme", string.Empty, delegate(ITemplate.Types.IDocumentDoc doc)
		{
			ObjectBinder<Theme, ITemplate.Types.IDocument> objectBinder = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, _flagService, doc);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.Serialize().ToByteArray(), delegate(byte[] data)
		{
			model.Deserialize(Template.Types.Document.Parser.ParseFrom(data));
			return model.ID;
		}, delegate
		{
		}) : _factoryProvider.EntityDocumentSyncerFactory.CreateFromCrdt(themeFolder, "Theme", string.Empty, delegate(ITemplate.Types.IDocumentDoc doc, bool fromModel)
		{
			ObjectBinder<Theme, ITemplate.Types.IDocument> objectBinder2 = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, _flagService, doc);
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
		model.Renamed += delegate
		{
		};
		_syncers[model.ID] = (item, model);
	}

	public void Add(Theme model)
	{
		IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc> item = _factoryProvider.EntityDocumentSyncerFactory.CreateFromModel(_fileSystem.Path.Combine(_commonPathsWrapper.Themes, model.Path), "Theme", string.Empty, model.ID, delegate(ITemplate.Types.IDocumentDoc doc)
		{
			ObjectBinder<Theme, ITemplate.Types.IDocument> objectBinder = model.Bind(_scheduler, _factoryProvider, _actionBinderFactory, _flagService, doc);
			doc.RegisterLinkedDisposable(objectBinder);
			objectBinder.InitializeRightFromLeft();
		}, () => model.Serialize().ToByteArray(), model.Path, DocumentType.Theme);
		model.Renamed += delegate
		{
		};
		_syncers[model.ID] = (item, model);
	}

	public void Remove(Theme model)
	{
		if (_syncers.TryRemove(model.ID, out (IEntityDocumentSyncer<ITemplate.Types.IDocumentDoc>, Theme) value))
		{
			value.Item1.Delete();
		}
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
