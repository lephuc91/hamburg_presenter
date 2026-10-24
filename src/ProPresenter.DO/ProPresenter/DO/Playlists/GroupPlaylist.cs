using System;
using System.Collections;
using System.Collections.Generic;
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
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public abstract class GroupPlaylist<T> : ImmutableObservableCollection<IPlaylist<T>>, IPlaylist<T>, ITriggerable, IIdentifiable, INotifyPropertyChanged, ICloneable<IPlaylist<T>>, IDragDropTreeCollection<IPlaylist<T>>, ITreeNode<IPlaylist<T>>, IEnumerable<T>, IEnumerable where T : ProPresenterCue
{
	private string _name = LocalizedStrings.Get("PLAYLIST_GLOBAL_NEW_PLAYLIST_FOLDER_name");

	private IPlaylist<T>? _parent;

	private bool _isExpanded;

	private Guid _id = Guid.NewGuid();

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

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnDataModified);
		}
	}

	public virtual PlaylistType Type => PlaylistType.Group;

	public IPlaylist<T>? PlaylistParent
	{
		get
		{
			return _parent;
		}
		set
		{
			SetValue("PlaylistParent", ref _parent, value, OnDataModified);
		}
	}

	public IPlaylist<T>? Parent => _parent;

	public IEnumerable<IPlaylist<T>> Children => this;

	public IEnumerable<T>? FilteredItems => null;

	public virtual bool IsExpanded
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

	public UndoStack? UndoStack { get; set; }

	public string ContainerId => MediaContainerIds.Playlist(ID);

	public event System.Action? DataModified;

	protected static void Bind<TModel>(ObjectBinder<TModel, IPlaylist> binder) where TModel : GroupPlaylist<T>
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

	protected GroupPlaylist(UndoStack? undoStack = null)
	{
		UndoStack = undoStack;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IPlaylist<T>>().ForEach(delegate(IPlaylist<T> p)
		{
			p.DataModified -= OnDataModified;
		});
		e.NewItems?.OfType<IPlaylist<T>>().ForEach(delegate(IPlaylist<T> p)
		{
			p.DataModified += OnDataModified;
		});
		OnDataModified();
	}

	public abstract IPlaylist<T> Clone();

	public IPlaylist<T> CopyProperties(GroupPlaylist<T> clone)
	{
		clone.Name = Name;
		clone.IsExpanded = IsExpanded;
		base.Collection.CloneItems().ForEach(clone.AddChild);
		return clone;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void AddChild(IPlaylist<T> child)
	{
		AddChild(-1, child);
	}

	public void AddChild(int index, IPlaylist<T> child)
	{
		AddChildren(new IPlaylist<T>[1] { child }, index);
	}

	public void RemoveChild(IPlaylist<T> playlist)
	{
		RemoveChildren(new IPlaylist<T>[1] { playlist });
	}

	public void AddChildren(IEnumerable<IPlaylist<T>> children, int index)
	{
		IPlaylist<T>[] playlists = children.ToArray();
		if (children.Any((IPlaylist<T> i) => i == this))
		{
			throw new InvalidOperationException("Unable to add a group to itself");
		}
		add();
		UndoStack?.Commit(UndoActionTypes.AddNewPlaylist.ToAction(), remove, add, null, OnDataModified, autoFinalize: true);
		OnDataModified();
		void add()
		{
			OnAddRange(playlists, index);
		}
		void remove()
		{
			OnRemoveRange(playlists);
		}
	}

	public void RemoveChildren(IEnumerable<IPlaylist<T>> children)
	{
		KeyValuePair<int, IPlaylist<T>>[] itemIndices = (from p in children.ToDictionary((IPlaylist<T> p) => base.Collection.IndexOf(p), (IPlaylist<T> p) => p)
			orderby p.Key descending
			select p).ToArray();
		remove();
		UndoStack?.Commit(UndoActionTypes.RemovePlaylist.ToAction(), add, remove, null, OnDataModified, autoFinalize: true);
		OnDataModified();
		void add()
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, IPlaylist<T>> i)
			{
				AddChild(i.Key, i.Value);
			});
		}
		void remove()
		{
			OnRemoveRange(itemIndices.Select((KeyValuePair<int, IPlaylist<T>> i) => i.Value));
		}
	}

	private void OnAddRange(IEnumerable<IPlaylist<T>> playlists, int index)
	{
		playlists.ForEach(delegate(IPlaylist<T> p)
		{
			p.PlaylistParent = this;
		});
		base.Collection.InsertRange(base.Collection.ClampIndexToCount(index), playlists);
	}

	private void OnRemoveRange(IEnumerable<IPlaylist<T>> playlists)
	{
		playlists.ForEach(OnRemove);
	}

	private void OnRemove(IPlaylist<T> playlist)
	{
		playlist.PlaylistParent = null;
		base.Collection.Remove(playlist);
	}

	public bool ContainsChild(IPlaylist<T> playlist)
	{
		if (playlist == null || !Children.Any())
		{
			return false;
		}
		foreach (IPlaylist<T> child in Children)
		{
			if (child == playlist)
			{
				return true;
			}
			if (child is GroupPlaylist<T> groupPlaylist)
			{
				return groupPlaylist.ContainsChild(playlist);
			}
		}
		return false;
	}

	public void DraggedFrom(IEnumerable<IPlaylist<T>> items)
	{
		base.Collection.DraggedFrom(items, UndoStack, OnRemove, RemoveFromRoot, AddChild);
	}

	public void DroppedInto(IEnumerable<IPlaylist<T>> items, int index, bool isCopy)
	{
		base.Collection.DroppedInto(index, items, UndoStack, this, RemoveFromRoot, OnDataModified);
	}

	public void MoveTo(IEnumerable<IPlaylist<T>> items, int index)
	{
		base.Collection.MoveTo(index, items, UndoStack, OnDataModified);
	}

	public virtual void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		Name = data.Name;
		ID = data.Uuid.ToGuid();
		IsExpanded = data.Expanded;
	}

	public virtual Playlist ProtoSerialize()
	{
		Playlist playlist = new Playlist();
		playlist.Uuid = ID.ToUUID();
		playlist.Name = Name;
		playlist.Expanded = IsExpanded;
		playlist.Playlists = new Playlist.Types.PlaylistArray();
		playlist.Playlists.Playlists.AddRange(base.Collection.Select((IPlaylist<T> p) => p.ProtoSerialize()));
		return playlist;
	}

	protected virtual void RemoveFromRoot(IPlaylist<T> playlist)
	{
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return base.Collection.SelectMany((IPlaylist<T> i) => i).GetEnumerator();
	}
}
