using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Playlists;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer", "_syncedData" })]
public class PlaylistTemplateCollection : PlaylistCollectionBase<ProPresenterCue>, INotifyEnumerableChanged<IPlaylist<ProPresenterCue>>, IEnumerable<IPlaylist<ProPresenterCue>>, IEnumerable, INotifyCollectionChanged, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<PlaylistTemplate>? _syncedData;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IFlagService _flagService;

	private readonly IUiScheduler _scheduler;

	private readonly ILogger _logger;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly IActionBinderFactory _actionBinderFactory;

	private IEntityDocumentSyncer<IPlaylistTemplateDoc>? _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public ObjectBinder<ObservableCollection<IPlaylist<ProPresenterCue>>, IPlaylistTemplate> Bind(IPlaylistTemplate entity)
	{
		ObjectBinder<ObservableCollection<IPlaylist<ProPresenterCue>>, IPlaylistTemplate> objectBinder = new ObjectBinder<ObservableCollection<IPlaylist<ProPresenterCue>>, IPlaylistTemplate>(base.Collection, entity);
		objectBinder.Bind((ObservableCollection<IPlaylist<ProPresenterCue>> m) => m.WhenCollectionChanges(), (IPlaylistTemplate e) => e.Templates.WhenCollectionChanges, delegate(ObservableCollection<IPlaylist<ProPresenterCue>> model, IPlaylistTemplate entity)
		{
			entity.Templates.SynchronizeFrom(model, Equal, delegate(IPlaylist<ProPresenterCue> model)
			{
				IPlaylistTemplate.Types.ITemplate template = _factoryProvider.EntityFactory.Create<IPlaylistTemplate.Types.ITemplate>();
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> readOnlyObjectBinder = model.BindItems(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, template.PlaylistItems);
				ObjectBinder<IPlaylist<ProPresenterCue>, IPlaylistTemplate.Types.ITemplate> objectBinder2 = new ObjectBinder<IPlaylist<ProPresenterCue>, IPlaylistTemplate.Types.ITemplate>(model, template).Bind((IPlaylist<ProPresenterCue> m) => m.WhenPropertyChanges("Name"), (IPlaylistTemplate.Types.ITemplate e) => e.Name.WhenValueChanges, delegate(IPlaylist<ProPresenterCue> model, IPlaylistTemplate.Types.ITemplate entity)
				{
					entity.Name.Set(model.Name);
				}, delegate(IPlaylistTemplate.Types.ITemplate entity, IPlaylist<ProPresenterCue> model)
				{
					model.Name = entity.Name.Value;
				});
				readOnlyObjectBinder.InitializeRightFromLeft();
				objectBinder2.InitializeRightFromLeft();
				template.RegisterLinkedDisposable(readOnlyObjectBinder);
				template.RegisterLinkedDisposable(objectBinder2);
				return template;
			});
		}, delegate(IPlaylistTemplate entity, ObservableCollection<IPlaylist<ProPresenterCue>> model)
		{
			entity.Templates.Items.SynchronizeTo(model, Equal, delegate(IPlaylistTemplate.Types.ITemplate e, int index)
			{
				GeneralPlaylist generalPlaylist = new GeneralPlaylist(_logger, _cueFactory, base.UndoStack, e.Name.Value);
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> readOnlyObjectBinder2 = generalPlaylist.BindItems(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, e.PlaylistItems);
				ObjectBinder<IPlaylist<ProPresenterCue>, IPlaylistTemplate.Types.ITemplate> objectBinder3 = new ObjectBinder<IPlaylist<ProPresenterCue>, IPlaylistTemplate.Types.ITemplate>(generalPlaylist, e).Bind((IPlaylist<ProPresenterCue> m) => m.WhenPropertyChanges("Name"), (IPlaylistTemplate.Types.ITemplate e) => e.Name.WhenValueChanges, delegate(IPlaylist<ProPresenterCue> model, IPlaylistTemplate.Types.ITemplate entity)
				{
					entity.Name.Set(model.Name);
				}, delegate(IPlaylistTemplate.Types.ITemplate entity, IPlaylist<ProPresenterCue> model)
				{
					model.Name = entity.Name.Value;
				});
				readOnlyObjectBinder2.InitializeLeftFromRight();
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				e.RegisterLinkedDisposable(objectBinder3);
				model.Insert(index, generalPlaylist);
			}, model.Move, model.RemoveAt);
		}, null, _scheduler.Scheduler);
		return objectBinder;
	}

	private static bool Equal(IPlaylist<ProPresenterCue> model, IPlaylistTemplate.Types.ITemplate entity)
	{
		return model.Name == entity.Name.Value;
	}

	private static bool Equal(IPlaylistTemplate.Types.ITemplate entity, IPlaylist<ProPresenterCue> model)
	{
		return model.Name == entity.Name.Value;
	}

	public PlaylistTemplateCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IFlagService flagService, IUiScheduler scheduler, ILogger logger, IProPresenterCueFactory cueFactory, IActionBinderFactory actionBinderFactory)
		: base(new UndoStack())
	{
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_flagService = flagService;
		_scheduler = scheduler;
		_logger = logger;
		_cueFactory = cueFactory;
		_actionBinderFactory = actionBinderFactory;
		SetupDocumentSyncer(loadLegacy: true);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncer = null;
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFileSyncer<IPlaylistTemplateDoc>(CommonPaths.PlaylistTemplates, "PlaylistTemplates", Bind, () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(PlaylistTemplate.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<PlaylistTemplate>(CommonPaths.PlaylistTemplates, "PlaylistTemplates", Deserialize, SyncedDataCleared);
		}
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	private void SyncedDataCleared(DataClearSource source)
	{
		if (source == DataClearSource.FileRemoved)
		{
			RemovePlaylists(base.Collection.ToArray());
		}
	}

	private PlaylistTemplate Serialize()
	{
		return new PlaylistTemplate
		{
			Templates = { base.Collection.Select((IPlaylist<ProPresenterCue> p) => new PlaylistTemplate.Types.Template
			{
				Name = p.Name,
				PlaylistItems = { (p as GeneralPlaylist)?.Select((ProPresenterCue i) => i.ProtoSerializePlaylistItem()) ?? Array.Empty<PlaylistItem>() }
			}) }
		};
	}

	private void Deserialize(PlaylistTemplate template)
	{
		base.UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(template.Templates, (IPlaylist<ProPresenterCue> p, PlaylistTemplate.Types.Template d) => p.Name == d.Name, (PlaylistTemplate.Types.Template d) => new GeneralPlaylist(_logger, _cueFactory, base.UndoStack, d.Name, isTemplate: true), delegate(IPlaylist<ProPresenterCue> p)
		{
			AddPlaylist(p);
		}, delegate(IPlaylist<ProPresenterCue> p)
		{
			RemovePlaylists(new global::_003C_003Ez__ReadOnlySingleElementList<IPlaylist<ProPresenterCue>>(p));
		}, delegate(IPlaylist<ProPresenterCue> p, PlaylistTemplate.Types.Template d)
		{
			p.DataModified -= base.OnDataModified;
			(p as GeneralPlaylist)?.ProtoDeserializePlaylistItems(d.PlaylistItems, new ApplicationData(ApplicationType.ProPresenter));
			p.DataModified += base.OnDataModified;
		});
		base.UndoStack?.StopIgnoring();
	}

	protected override void DataModifiedHook()
	{
		_syncedData?.UpdateData(Serialize());
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new PlaylistTemplatesDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncedData?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
