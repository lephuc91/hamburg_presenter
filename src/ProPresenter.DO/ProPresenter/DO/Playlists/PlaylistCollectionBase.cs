using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public abstract class PlaylistCollectionBase<T> : ImmutableObservableCollection<IPlaylist<T>>, IDragDropTreeCollection<IPlaylist<T>>, ITreeNode<IPlaylist<T>> where T : ProPresenterCue
{
	public IEnumerable<IPlaylist<T>> Children => this;

	public IPlaylist<T>? Parent => null;

	public UndoStack? UndoStack { get; }

	public event Action<string>? LocationChanged;

	public event Action<PlaylistCollectionBase<T>>? CollectionModified;

	protected PlaylistCollectionBase(UndoStack? undoStack = null)
	{
		UndoStack = undoStack ?? new UndoStack();
	}

	public void DraggedFrom(IEnumerable<IPlaylist<T>> items)
	{
		base.Collection.DraggedFrom(items, UndoStack, OnRemove, OnRemove, OnInsert);
	}

	public void DroppedInto(IEnumerable<IPlaylist<T>> items, int index, bool isCopy)
	{
		base.Collection.DroppedInto(index, items, UndoStack, null, OnRemove, OnDataModified);
	}

	public void MoveTo(IEnumerable<IPlaylist<T>> items, int index)
	{
		base.Collection.MoveTo(index, items, UndoStack, OnDataModified);
	}

	protected void OnDataModified()
	{
		this.CollectionModified?.Invoke(this);
		DataModifiedHook();
	}

	protected virtual void DataModifiedHook()
	{
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

	public void AddPlaylist(IPlaylist<T> playlist, GroupPlaylist<T>? parent = null, int index = -1)
	{
		if (parent == null)
		{
			index = SanitizeInsertionIndex(index);
			OnInsert(index, playlist);
			UndoStack?.Commit(UndoActionTypes.AddNewPlaylist.ToAction(), delegate
			{
				OnRemove(playlist);
			}, delegate
			{
				OnInsert(index, playlist);
			}, null, OnDataModified, autoFinalize: true);
			OnDataModified();
		}
		else
		{
			parent.IsExpanded = true;
			parent.AddChild(index, playlist);
		}
	}

	protected virtual int SanitizeInsertionIndex(int index)
	{
		return base.Collection.ClampIndexToCount(index);
	}

	public void RemovePlaylists(IEnumerable<IPlaylist<T>> playlists)
	{
		KeyValuePair<int, IPlaylist<T>>[] itemIndices = GetIndexMap(playlists);
		remove();
		UndoStack?.Commit(UndoActionTypes.RemovePlaylist.ToAction(), add, remove, null, OnDataModified);
		OnDataModified();
		void add()
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, IPlaylist<T>> i)
			{
				OnInsert(i.Key, i.Value);
			});
		}
		void remove()
		{
			itemIndices.Reverse().ForEach<KeyValuePair<int, IPlaylist<T>>>(delegate(KeyValuePair<int, IPlaylist<T>> i)
			{
				OnRemove(i.Value);
			});
		}
	}

	private KeyValuePair<int, IPlaylist<T>>[] GetIndexMap(IEnumerable<IPlaylist<T>> playlists)
	{
		return (from i in playlists.ToDictionary((IPlaylist<T> i) => base.Collection.IndexOf(i), (IPlaylist<T> i) => i)
			orderby i.Key
			select i).ToArray();
	}

	private void OnInsert(int index, IPlaylist<T> playlist)
	{
		base.Collection.Insert(index, playlist);
	}

	private void OnRemove(IPlaylist<T> playlist)
	{
		base.Collection.Remove(playlist);
	}

	public P? GetTargetPlaylist<P>(P? playlist) where P : Playlist<T>
	{
		return playlist ?? base.Collection.FirstOrDefaultOf<P>() ?? GetNewPlaylist<P>();
	}

	protected virtual P? GetNewPlaylist<P>() where P : Playlist<T>
	{
		return null;
	}

	protected void OnLocationChanged(string configPath)
	{
		this.LocationChanged?.Invoke(configPath);
	}

	internal void Save()
	{
		DataModifiedHook();
	}
}
