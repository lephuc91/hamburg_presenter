using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Playlists;

public class GeneralPlaylist : Playlist<ProPresenterCue>, ILibraryPlaylist<ProPresenterCue>, IEnumerable<ProPresenterCue>, IEnumerable
{
	private readonly Dictionary<Guid, List<DocumentCue>> _documentCuesMap = new Dictionary<Guid, List<DocumentCue>>();

	private readonly ILogger _logger;

	private readonly IProPresenterCueFactory _cueFactory;

	private bool _isDeserializing;

	private bool _removeExistingOnDeserialization;

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		ObjectBinder<GeneralPlaylist, IPlaylist> objectBinder = new ObjectBinder<GeneralPlaylist, IPlaylist>(this, playlist);
		Playlist<ProPresenterCue>.Bind(objectBinder);
		IPlaylist.Types.IChildrenType.IItems currentItems = null;
		objectBinder.Bind((GeneralPlaylist l) => l.WhenCollectionChanges(), (IPlaylist r) => r.ChildrenType.WhenValueChanges, delegate(GeneralPlaylist l, IPlaylist r)
		{
			IPlaylist.Types.IChildrenType.IItems items = r.ChildrenType.Value as IPlaylist.Types.IChildrenType.IItems;
			if (items == null)
			{
				items = entityFactory.Create<IPlaylist.Types.IChildrenType.IItems>();
				r.ChildrenType.Set(items);
			}
			if (currentItems != items)
			{
				currentItems = items;
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> readOnlyObjectBinder = l.BindItems(scheduler, entityFactory, actionBinderFactory, items.Value.Items);
				items.RegisterLinkedDisposable(readOnlyObjectBinder);
				readOnlyObjectBinder.InitializeRightFromLeft();
			}
		}, delegate(IPlaylist r, GeneralPlaylist l)
		{
			if (!(r.ChildrenType.Value is IPlaylist.Types.IChildrenType.IItems items2))
			{
				currentItems = null;
				l.RemoveItems(l.Items, isReversible: false);
			}
			else if (currentItems != items2)
			{
				currentItems = items2;
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> readOnlyObjectBinder2 = l.BindItems(scheduler, entityFactory, actionBinderFactory, items2.Value.Items);
				items2.RegisterLinkedDisposable(readOnlyObjectBinder2);
				readOnlyObjectBinder2.InitializeLeftFromRight();
			}
		});
		return objectBinder;
	}

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		ObjectBinder<GeneralPlaylist, IComplexCollection<IPlaylistItem>> objectBinder = new ObjectBinder<GeneralPlaylist, IComplexCollection<IPlaylistItem>>(this, items);
		Subject<Unit> resyncTrigger = new Subject<Unit>();
		objectBinder.Bind((GeneralPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylistItem> r) => r.WhenCollectionChanges.Select((IReadOnlyList<IPlaylistItem> _) => Unit.Default).Merge(resyncTrigger), delegate(GeneralPlaylist l, IComplexCollection<IPlaylistItem> r)
		{
			r.SynchronizeFrom(l.Items, (ProPresenterCue m, IPlaylistItem e) => m.ID == e.Uuid.Value, delegate(ProPresenterCue m)
			{
				IPlaylistItem playlistItem = entityFactory.Create<IPlaylistItem>();
				IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlistItem);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlistItem;
			});
		}, delegate(IComplexCollection<IPlaylistItem> r, GeneralPlaylist l)
		{
			r.Items.SynchronizeTo(l, (IPlaylistItem e, ProPresenterCue m) => m?.ID == e.Uuid.Value, delegate(IPlaylistItem e, int i)
			{
				ProPresenterCue proPresenterCue = _cueFactory.CreateCue(e, l.ContainerId);
				if (proPresenterCue != null)
				{
					IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder2 = proPresenterCue.Bind(scheduler, entityFactory, actionBinderFactory, e);
					readOnlyObjectBinder2.InitializeLeftFromRight();
					e.RegisterLinkedDisposable(readOnlyObjectBinder2);
					l.InsertItem(proPresenterCue, null, i, isReversible: false);
				}
				else
				{
					IDisposable disposable = e.ItemType.WhenValueChanges.Where((IPlaylistItem.Types.IItemType t) => t != null).Take(1).Subscribe(delegate
					{
						resyncTrigger.OnNext(Unit.Default);
					});
					e.RegisterLinkedDisposable(disposable);
				}
			}, l.Collection.Move, delegate(int i)
			{
				ProPresenterCue proPresenterCue2 = l.ElementAtOrDefault(i);
				if (proPresenterCue2 != null)
				{
					l.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>(proPresenterCue2), isReversible: false);
				}
			});
		}, null, scheduler.Scheduler);
		objectBinder.RegisterChildDisposable(() => resyncTrigger);
		return objectBinder;
	}

	public GeneralPlaylist(ILogger logger, IProPresenterCueFactory cueFactory, UndoStack? undoStack = null, string name = "", bool isTemplate = false)
		: base(undoStack, name, isTemplate)
	{
		base.CollectionChanged += GeneralPlaylist_CollectionChanged;
		_logger = logger;
		_cueFactory = cueFactory;
	}

	private void GeneralPlaylist_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		MediaCue[] source = Array.Empty<MediaCue>();
		if (!_isDeserializing)
		{
			source = e.OldItems?.OfType<MediaCue>().Except(e.NewItems?.OfType<MediaCue>() ?? Array.Empty<MediaCue>()).ToArray() ?? Array.Empty<MediaCue>();
		}
		if (_isDeserializing && _removeExistingOnDeserialization)
		{
			source = e.OldItems?.OfType<MediaCue>().ToArray() ?? Array.Empty<MediaCue>();
		}
		source.Select((MediaCue x) => x.MediaAction?.Media).OfType<ITrackedMedia>().ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		e.OldItems?.OfType<IDocumentCue>().ForEach(delegate(IDocumentCue d)
		{
			d.PlaylistParent = null;
		});
		e.NewItems?.OfType<IDocumentCue>().ForEach(delegate(IDocumentCue d)
		{
			d.PlaylistParent = this;
		});
	}

	public override IPlaylist<ProPresenterCue> Clone()
	{
		return CopyProperties(new GeneralPlaylist(_logger, _cueFactory, base.UndoStack, Name));
	}

	public ProPresenterCue AddHeaderPlaylistItem(string name, int index = -1)
	{
		ProPresenterCue proPresenterCue = _cueFactory.CreateHeader(name);
		InsertItem(proPresenterCue, UndoActionTypes.AddHeaderPlaylistItem.ToAction(), index);
		return proPresenterCue;
	}

	public ProPresenterCue AddPlaceholderPlaylistItem(string name, int index = -1)
	{
		ProPresenterCue proPresenterCue = _cueFactory.CreatePlaceholder(name);
		InsertItem(proPresenterCue, UndoActionTypes.AddPlaceholderPlaylistItem.ToAction(), index);
		return proPresenterCue;
	}

	public void AddPresentationItem(IDocumentAction action)
	{
		AddPresentationItem(_cueFactory.CreateDocumentCue(action, clone: true));
	}

	public void AddPresentationItem(ProPresenterCue cue, int index = -1)
	{
		InsertItem(cue, UndoActionTypes.AddPresentationPlaylistItem.ToAction(), index);
	}

	public void AddPresentationItem(IEnumerable<ProPresenterCue> cues, int pos)
	{
		InsertItems(cues, null, pos);
	}

	public void InsertMediaItem(string file, int index)
	{
		TaggedUndoAction<UndoActionTypes> taggedUndoAction = new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddMediaItem);
		ProPresenterCue cue = _cueFactory.CreateMediaCue(file, _isTemplate ? "PlaylistTemplate" : MediaContainerIds.Playlist(base.ID));
		InsertItem(cue, taggedUndoAction, index);
	}

	public void InsertMediaItem(MediaBase media, int index)
	{
		TaggedUndoAction<UndoActionTypes> taggedUndoAction = new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddMediaItem);
		ProPresenterCue cue = _cueFactory.CreateMediaCue(media);
		InsertItem(cue, taggedUndoAction, index);
	}

	public void ResolveMissingDocuments(ILibraryCollection libraries)
	{
		(from c in base.Collection.OfType<IMaybeUnresolvedCue>()
			where c.NeedsResolve()
			select c).ForEach(delegate(IMaybeUnresolvedCue cue)
		{
			cue.Resolve(libraries);
			if (cue is DocumentCue cue2)
			{
				TrackDocumentCues(cue2);
			}
		});
	}

	internal void ResolveDeletedDocuments(IEnumerable<DocumentCue>? cues)
	{
		if (cues == null)
		{
			return;
		}
		foreach (DocumentCue item in cues.Where((DocumentCue c) => c.DocumentAction.Presentation != null))
		{
			if (!_documentCuesMap.TryGetValue(item.DocumentAction.Presentation.ID, out List<DocumentCue> value))
			{
				continue;
			}
			List<DocumentCue> obj = value;
			int num = 0;
			ProPresenterCue[] array = new ProPresenterCue[obj.Count];
			foreach (DocumentCue item2 in obj)
			{
				array[num] = item2;
				num++;
			}
			RemoveItems(new global::_003C_003Ez__ReadOnlyArray<ProPresenterCue>(array));
			_documentCuesMap.Remove(item.DocumentAction.Presentation.ID);
		}
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		ProtoDeserializePlaylistItems(data.Items.Items, applicationData, removeExisting);
	}

	public void ProtoDeserializePlaylistItems(IEnumerable<PlaylistItem> protoItems, ApplicationData? applicationData, bool removeExisting = true)
	{
		_isDeserializing = true;
		_removeExistingOnDeserialization = removeExisting;
		try
		{
			_cueFactory.Deserialize(base.Collection, protoItems, applicationData, removeExisting, _isTemplate ? "PlaylistTemplate" : MediaContainerIds.Playlist(base.ID));
		}
		finally
		{
			_isDeserializing = false;
			_removeExistingOnDeserialization = false;
		}
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnCollectionChanged(e);
		(from c in e.OldItems?.OfType<DocumentCue>()
			where c.DocumentAction.Presentation != null
			select c.DocumentAction.Presentation.ID).Distinct().ForEach(delegate(Guid i)
		{
			_documentCuesMap.Remove(i);
		});
		e.NewItems?.OfType<DocumentCue>().ForEach(TrackDocumentCues);
	}

	private void TrackDocumentCues(DocumentCue cue)
	{
		if (cue.DocumentAction.Presentation != null)
		{
			if (!_documentCuesMap.TryGetValue(cue.DocumentAction.Presentation.ID, out List<DocumentCue> value))
			{
				value = new List<DocumentCue>();
				_documentCuesMap.Add(cue.DocumentAction.Presentation.ID, value);
			}
			if (!value.Contains(cue))
			{
				value.Add(cue);
			}
		}
	}
}
