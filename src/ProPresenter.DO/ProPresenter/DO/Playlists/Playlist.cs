using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public abstract class Playlist<T> : ImmutableObservableCollection<T>, IPlaylist<T>, ITriggerable, IIdentifiable, INotifyPropertyChanged, ICloneable<IPlaylist<T>>, IDragDropTreeCollection<IPlaylist<T>>, ITreeNode<IPlaylist<T>>, IEnumerable<T>, IEnumerable, IDragDropNotifyEnumerableChanged<T>, INotifyEnumerableChanged<T>, INotifyCollectionChanged, IDragDropCollection<T>, ICutPasteCollection<T>, ICutCollection<T> where T : ProPresenterCue
{
	private string _name;

	private IPlaylist<T>? _parent;

	private bool _isExpanded;

	private Guid _id = Guid.NewGuid();

	protected bool _isTemplate;

	public virtual PlaylistType Type => PlaylistType.Custom;

	public virtual string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				if (!Type.IsAnyOf(PlaylistType.LiveVideo, PlaylistType.Download))
				{
					UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RenamePlaylist), this, "Name", o, n, null, null, autoFinalize: true);
				}
				OnDataModified();
			});
		}
	}

	public Guid ID
	{
		get
		{
			return _id;
		}
		protected set
		{
			SetValue("ID", ref _id, value);
		}
	}

	public IPlaylist<T>? PlaylistParent
	{
		get
		{
			return _parent;
		}
		set
		{
			SetValue("PlaylistParent", ref _parent, value);
		}
	}

	public IPlaylist<T>? Parent => _parent;

	public IEnumerable<IPlaylist<T>>? Children => null;

	public virtual IEnumerable<T> FilteredItems => base.Collection;

	public bool IsExpanded
	{
		get
		{
			return _isExpanded;
		}
		set
		{
			SetValue("IsExpanded", ref _isExpanded, value, OnDataModified);
		}
	}

	protected UndoStack? UndoStack { get; }

	public ObservableCollection<Event> Events { get; } = new ObservableCollection<Event>();

	public string ContainerId
	{
		get
		{
			if (!_isTemplate)
			{
				return MediaContainerIds.Playlist(ID);
			}
			return "PlaylistTemplate";
		}
	}

	public event System.Action? DataModified;

	protected static void Bind<TModel>(ObjectBinder<TModel, IPlaylist> binder) where TModel : Playlist<T>
	{
		binder.Bind((TModel model) => model.WhenPropertyChanges("ID"), (IPlaylist entity) => entity.Uuid.WhenValueChanges, delegate(TModel model, IPlaylist entity)
		{
			entity.Uuid.Set(model.ID);
		}, delegate(IPlaylist entity, TModel model)
		{
			model.ID = entity.Uuid.Value;
		}).Bind((TModel model) => model.WhenPropertyChanges("Name"), (IPlaylist entity) => entity.Name.WhenValueChanges, delegate(TModel model, IPlaylist entity)
		{
			entity.Name.Set(model.Name);
		}, delegate(IPlaylist entity, TModel model)
		{
			model.Name = entity.Name.Value;
		}).Bind((TModel model) => model.WhenPropertyChanges("IsExpanded"), (IPlaylist entity) => entity.Expanded.WhenValueChanges, delegate(TModel model, IPlaylist entity)
		{
			entity.Expanded.Set(model.IsExpanded);
		}, delegate(IPlaylist entity, TModel model)
		{
			model.IsExpanded = entity.Expanded.Value;
		});
	}

	public abstract IReadOnlyObjectBinder<IPlaylist<T>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist);

	public abstract IReadOnlyObjectBinder<IPlaylist<T>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items);

	protected Playlist(UndoStack? undoStack = null, string name = "", bool isTemplate = false)
	{
		Playlist<T> playlist = this;
		UndoStack = undoStack;
		_name = ((!string.IsNullOrWhiteSpace(name)) ? name : LocalizedStrings.Get("PLAYLIST_GLOBAL_PLAYLIST_title"));
		_isTemplate = isTemplate;
		base.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.NewItems?.OfType<T>().ForEach(delegate(T i)
			{
				i.UndoStack = undoStack;
				((ICanReceiveMediaContainerIdUpdates)i)?.UpdateContainerId(playlist._isTemplate ? "PlaylistTemplate" : MediaContainerIds.Playlist(playlist.ID));
			});
		};
	}

	public abstract IPlaylist<T> Clone();

	protected IPlaylist<T> CopyProperties(Playlist<T> clone)
	{
		base.Collection.ForEach(delegate(T i)
		{
			clone.AddItem((T)i.Clone());
		});
		return clone;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<T>().ForEach(teardown);
		e.NewItems?.Cast<T>().ForEach(setup);
		OnPropertyChanged("FilteredItems");
		OnDataModified();
		void setup(T item)
		{
			if (item is IDocumentCue { DocumentAction: not null } documentCue2)
			{
				documentCue2.PropertyChanged += Document_PropertyChanged;
				documentCue2.DocumentAction.PropertyChanged += Document_PropertyChanged;
			}
			else
			{
				item.DataModified += CueChanged;
			}
		}
		void teardown(T item)
		{
			if (item is IDocumentCue { DocumentAction: not null } documentCue)
			{
				documentCue.PropertyChanged -= Document_PropertyChanged;
				documentCue.DocumentAction.PropertyChanged -= Document_PropertyChanged;
			}
			else
			{
				item.DataModified -= CueChanged;
			}
		}
	}

	private void Document_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName.IsPlaylistRelevantProperty())
		{
			OnDataModified();
		}
	}

	protected void CueChanged(Pro.DO.Triggering.Cue cue)
	{
		OnDataModified();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	void IDragDropCollection<T>.DraggedFrom(IEnumerable<T> items)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MovePlaylistItems.ToAction());
		RemoveItems(items);
	}

	void IDragDropCollection<T>.DroppedInto(IEnumerable<T> items, int index, bool isCopy)
	{
		IEnumerable<T> enumerable2;
		if (!isCopy)
		{
			IEnumerable<T> enumerable = items;
			enumerable2 = enumerable;
		}
		else
		{
			enumerable2 = items.Select((T i) => (T)i.Clone());
		}
		items = enumerable2;
		index = ((index == -1) ? base.Collection.Count : base.Collection.ClampIndexExclusive(index));
		UndoStack?.Commit(UndoActionTypes.MovePlaylistItems.ToAction(), delegate
		{
			base.Collection.RemoveRange(items);
		}, insert, null, null, autoFinalize: true);
		insert();
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.EndCommit(null, null, autoFinalize: true);
		}
		void insert()
		{
			InsertItems(items, null, index);
		}
	}

	void IDragDropCollection<T>.MoveTo(IEnumerable<T> items, int index)
	{
		UndoStack?.BeginCommit(UndoActionTypes.ArrangePlaylistItems.ToAction());
		int num = base.Collection.ClampIndexExclusive(index);
		int num2 = Math.Max(0, num - 1);
		while (num > 0 && base.Collection[num2].IsHidden)
		{
			num2--;
			num--;
			if (num2 == -1)
			{
				break;
			}
		}
		base.Collection.MoveTo(items, num, UndoStack);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void DraggedFrom(IEnumerable<IPlaylist<T>> items)
	{
		throw new NotSupportedException();
	}

	public void DroppedInto(IEnumerable<IPlaylist<T>> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	public void MoveTo(IEnumerable<IPlaylist<T>> items, int index)
	{
		throw new NotSupportedException();
	}

	public virtual void CutFrom(IEnumerable<T> items)
	{
		throw new NotSupportedException();
	}

	public virtual void PasteInto(IEnumerable<T> items, int index)
	{
		InsertItems(items, null, index);
	}

	public void RemoveItems(IEnumerable<T> items, bool isReversible = true)
	{
		KeyValuePair<int, T>[] indexedItems = (from i in items.Distinct().ToDictionary(base.Collection.IndexOf, (T i) => i)
			orderby i.Key
			select i).ToArray();
		System.Action action = delegate
		{
			indexedItems.Reverse().ForEach(delegate(KeyValuePair<int, T> i)
			{
				base.Collection.Remove(base.Collection[i.Key]);
			});
		};
		action();
		if (!isReversible)
		{
			return;
		}
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemovePlaylistItems), delegate
		{
			indexedItems.ForEach(delegate(KeyValuePair<int, T> i)
			{
				base.Collection.Insert(i.Key, i.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public void AddItem(T item)
	{
		AddItems(new global::_003C_003Ez__ReadOnlySingleElementList<T>(item));
	}

	public void AddItems(IEnumerable<T> items)
	{
		base.Collection.AddRange(items);
		T[] addedItems = items.ToArray();
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddPlaylistItems), delegate
		{
			base.Collection.RemoveRange(addedItems);
		}, delegate
		{
			base.Collection.AddRange(items);
		}, null, null, autoFinalize: true);
	}

	public void ReplaceItem(T oldItem, T newItem)
	{
		if (oldItem != newItem)
		{
			int num = base.Collection.IndexOf(oldItem);
			if (num >= 0 && num < base.Collection.Count)
			{
				base.Collection[num] = newItem;
			}
		}
	}

	protected void InsertItems(IEnumerable<T> items, TaggedUndoAction<UndoActionTypes>? taggedUndoAction = null, int index = -1, bool isReversible = true)
	{
		insertAction();
		if (isReversible)
		{
			UndoStack?.Commit(taggedUndoAction ?? UndoActionTypes.AddPlaylistItems.ToAction(), delegate
			{
				base.Collection.RemoveRange(items);
			}, insertAction, null, null, autoFinalize: true);
		}
		void insertAction()
		{
			base.Collection.InsertRange((index == -1) ? base.Collection.Count : base.Collection.ClampIndexExclusive(index), items);
		}
	}

	protected void InsertItem(T cue, TaggedUndoAction<UndoActionTypes>? taggedUndoAction = null, int index = -1, bool isReversible = true)
	{
		InsertItems(new global::_003C_003Ez__ReadOnlySingleElementList<T>(cue), taggedUndoAction, index, isReversible);
	}

	protected void ReplacePlaylistWith(IEnumerable<T> playlistItems)
	{
		foreach (T playlistItem in playlistItems)
		{
			int num = base.Collection.IndexOf(playlistItem);
			int num2 = playlistItems.IndexOf(playlistItem);
			if (num != num2)
			{
				base.Collection.Move(num, num2);
			}
		}
	}

	public virtual void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		if (data != null)
		{
			ID = data.Uuid.ToGuid();
			Name = data.Name;
			IsExpanded = data.Expanded;
		}
	}

	public virtual Playlist ProtoSerialize()
	{
		Playlist playlist = new Playlist();
		playlist.Uuid = ID.ToUUID();
		playlist.Name = Name;
		playlist.Expanded = IsExpanded;
		playlist.Items = new Playlist.Types.PlaylistItems();
		playlist.Items.Items.AddRange(base.Collection.Select((T mc) => mc.ProtoSerializePlaylistItem()));
		return playlist;
	}

	public virtual void ImportMedia(RelativePath file)
	{
	}

	public T? GetRandomCue(Func<T, bool>? filter = null, IEnumerable<T>? ignoreCues = null)
	{
		T result = null;
		List<T> list = ((filter != null) ? this.Where(filter).ToList() : this.ToList());
		while (list.Count > 0)
		{
			int index = RandomNumber.Generate(0, list.Count);
			T randomCue = list[index];
			if (ignoreCues == null || !ignoreCues.Contains(randomCue))
			{
				return randomCue;
			}
			list.RemoveAll((T item) => item == randomCue);
		}
		return result;
	}
}
