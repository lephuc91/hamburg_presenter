using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Playlists;

public static class PlaylistHelper
{
	public static bool TryFindPlaylistItem<T>(this IEnumerable<IPlaylist<T>> playlists, Predicate<T> predicate, out T? cue) where T : ProPresenterCue
	{
		IPlaylist<T> playlist;
		return playlists.TryFindPlaylistItem(predicate, out cue, out playlist);
	}

	public static bool TryFindPlaylistItem<T>(this IEnumerable<IPlaylist<T>> playlists, Predicate<T> predicate, out T? cue, out IPlaylist<T>? playlist) where T : ProPresenterCue
	{
		cue = null;
		playlist = null;
		foreach (IPlaylist<T> playlist2 in playlists)
		{
			if (playlist2 is GroupPlaylist<T> groupPlaylist && groupPlaylist.Children.TryFindPlaylistItem(predicate, out cue, out playlist))
			{
				return true;
			}
			T val = ((playlist2 != null) ? playlist2.FirstOrDefault((T p) => predicate?.Invoke(p) ?? true) : null);
			if (val != null)
			{
				cue = val;
				playlist = playlist2;
				return true;
			}
		}
		return false;
	}

	public static void IteratePlaylists<T>(this IEnumerable<IPlaylist<T>> playlists, Action<IPlaylist<T>, int> callback, int depth = 1) where T : ProPresenterCue
	{
		playlists.IteratePlaylists(null, callback, depth);
	}

	public static void IteratePlaylists<T>(this IEnumerable<IPlaylist<T>> playlists, Predicate<IPlaylist<T>>? predicate, Action<IPlaylist<T>, int> callback, int depth = 1) where T : ProPresenterCue
	{
		foreach (IPlaylist<T> playlist in playlists)
		{
			if (predicate == null || predicate(playlist))
			{
				callback(playlist, depth);
			}
			if (playlist.Type == PlaylistType.Group)
			{
				((GroupPlaylist<T>)playlist).IteratePlaylists(predicate, callback, depth + 1);
			}
		}
	}

	public static IReadOnlyCollection<IPlaylist<T>> GetPlaylists<T>(this IEnumerable<IPlaylist<T>> playlists) where T : ProPresenterCue
	{
		return playlists.GetPlaylists(null);
	}

	public static IReadOnlyCollection<IPlaylist<T>> GetPlaylists<T>(this IEnumerable<IPlaylist<T>> playlists, Predicate<IPlaylist<T>>? predicate) where T : ProPresenterCue
	{
		List<IPlaylist<T>> foundPlaylists = new List<IPlaylist<T>>();
		playlists.IteratePlaylists(predicate, delegate(IPlaylist<T> playlist, int depth)
		{
			foundPlaylists.Add(playlist);
		});
		return foundPlaylists;
	}

	public static void FindMedia<T>(this IEnumerable<IPlaylist<T>> playlists, Action<string> callback, bool includePresentationMedia) where T : ProPresenterCue
	{
		foreach (IPlaylist<T> playlist in playlists)
		{
			if (playlist.Type == PlaylistType.Group)
			{
				((GroupPlaylist<T>)playlist).Children.FindMedia(callback, includePresentationMedia);
				continue;
			}
			foreach (T item in (Playlist<T>)playlist)
			{
				if (item is IDocumentCue documentCue)
				{
					documentCue.DocumentAction?.Presentation?.FindMedia(callback, includePresentationMedia);
				}
				if (item is IMediaCue mediaCue)
				{
					mediaCue.MediaAction?.Media?.FindMedia(callback);
				}
			}
		}
	}

	public static void DraggedFrom<T>(this ObservableCollection<IPlaylist<T>> collection, IEnumerable<IPlaylist<T>> items, UndoStack? undoStack, Action<IPlaylist<T>> remove, Action<IPlaylist<T>> removeFromRoot, Action<int, IPlaylist<T>> insert) where T : ProPresenterCue
	{
		KeyValuePair<IPlaylist<T>, int>[] itemsToUndo = collection.GetIndexMap(items);
		undoStack?.BeginCommit(UndoActionTypes.MovePlaylist.ToAction());
		undoStack?.CommitUndo(delegate
		{
			KeyValuePair<IPlaylist<T>, int>[] array = itemsToUndo;
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<IPlaylist<T>, int> keyValuePair = array[i];
				var (playlist2, arg) = (KeyValuePair<IPlaylist<T>, int>)(ref keyValuePair);
				if (playlist2.PlaylistParent is GroupPlaylist<T> groupPlaylist)
				{
					groupPlaylist.RemoveChild(playlist2);
				}
				else
				{
					removeFromRoot(playlist2);
				}
				insert(arg, playlist2);
			}
		});
		items.ForEach<IPlaylist<T>>(remove);
	}

	public static void DroppedInto<T>(this ObservableCollection<IPlaylist<T>> collection, int index, IEnumerable<IPlaylist<T>> items, UndoStack? undoStack, IPlaylist<T>? playlistParent, Action<IPlaylist<T>> remove, System.Action onDataModified) where T : ProPresenterCue
	{
		items.ForEach(delegate(IPlaylist<T> i)
		{
			i.PlaylistParent = playlistParent;
		});
		KeyValuePair<IPlaylist<T>, int>[] itemsToRedo = collection.GetIndexMap(items);
		if (undoStack != null && undoStack.IsRecording)
		{
			undoStack.CommitRedo(delegate
			{
				KeyValuePair<IPlaylist<T>, int>[] array = itemsToRedo;
				for (int j = 0; j < array.Length; j++)
				{
					KeyValuePair<IPlaylist<T>, int> keyValuePair = array[j];
					var (playlist2, _) = (KeyValuePair<IPlaylist<T>, int>)(ref keyValuePair);
					if (playlist2.PlaylistParent is GroupPlaylist<T> groupPlaylist)
					{
						groupPlaylist.RemoveChild(playlist2);
					}
					else
					{
						remove(playlist2);
					}
				}
				items.ForEach(delegate(IPlaylist<T> i)
				{
					i.PlaylistParent = playlistParent;
				});
				collection.InsertRange(index, itemsToRedo.Select((KeyValuePair<IPlaylist<T>, int> k) => k.Key), ignoreDuplicates: true, capIndex: true);
			});
		}
		collection.InsertRange(index, items, ignoreDuplicates: true, capIndex: true);
		onDataModified();
		if (undoStack != null && undoStack.IsRecording)
		{
			undoStack.EndCommit(null, onDataModified, autoFinalize: true);
		}
	}

	public static void MoveTo<T>(this ObservableCollection<IPlaylist<T>> collection, int index, IEnumerable<IPlaylist<T>> items, UndoStack? undoStack, System.Action onDataModified) where T : ProPresenterCue
	{
		undoStack?.BeginCommit(UndoActionTypes.MovePlaylist.ToAction());
		collection.MoveTo(items, index, undoStack);
		onDataModified();
		undoStack?.EndCommit(null, onDataModified, autoFinalize: true);
	}

	public static void Duplicate<T>(this PlaylistCollectionBase<T> collection, IEnumerable<IPlaylist<T>> items) where T : ProPresenterCue
	{
		collection.UndoStack?.BeginCommit(UndoActionTypes.DuplicatePlaylists.ToAction());
		IPlaylist<T>[] array = items.ToArray();
		foreach (IPlaylist<T> playlist in array)
		{
			IPlaylist<T> playlist2 = playlist.Clone();
			if (playlist2 is IPlaylist<MediaCue> item)
			{
				IReadOnlyList<ITrackedMedia> mediaToAdd = GetTrackedMediaFromPlaylists(new global::_003C_003Ez__ReadOnlySingleElementList<IPlaylist<MediaCue>>(item));
				mediaToAdd.ForEach(delegate(ITrackedMedia x)
				{
					x.AddToMediaServiceAndApplyTransform(userInitiated: true);
				});
				collection.UndoStack?.Commit(delegate
				{
					mediaToAdd.ForEach(delegate(ITrackedMedia x)
					{
						x.RemoveFromMediaService(deleteAssets: false);
					});
				}, delegate
				{
					mediaToAdd.ForEach(delegate(ITrackedMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				});
			}
			if (playlist.Parent == null)
			{
				collection.AddPlaylist(playlist2, null, collection.IndexOf(playlist) + 1);
			}
			else if (playlist.Parent is GroupPlaylist<T> groupPlaylist)
			{
				groupPlaylist.AddChild(groupPlaylist.IndexOf(playlist) + 1, playlist2);
			}
		}
		collection.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public static bool IsPlaylistRelevantProperty(this string? propertyName)
	{
		switch (propertyName)
		{
		case "ActiveArrangement":
		case "TargetKey":
		case "Destination":
		case "Name":
		case "IsHidden":
			return true;
		default:
			return false;
		}
	}

	private static KeyValuePair<IPlaylist<T>, int>[] GetIndexMap<T>(this ObservableCollection<IPlaylist<T>> collection, IEnumerable<IPlaylist<T>> playlists) where T : ProPresenterCue
	{
		return (from i in playlists.ToDictionary((IPlaylist<T> i) => i, (IPlaylist<T> i) => collection.IndexOf(i))
			orderby i.Value
			select i).ToArray();
	}

	internal static MediaCue? ToMediaCue(this PlaylistItem protoPlaylistItem, string containerId)
	{
		if (protoPlaylistItem?.Cue == null || !protoPlaylistItem.Cue.Actions.Any())
		{
			return null;
		}
		return new MediaCue(containerId);
	}

	public static bool TryFindPlaylistItem<T>(this IEnumerable<string> path, IPlaylist<T>[] playlists, out IPlaylist<T>? playlist, out T? playlistItem) where T : ProPresenterCue
	{
		playlistItem = null;
		playlist = null;
		bool flag = false;
		string[] array = path.ToArray();
		for (int j = 0; j < array.Length; j++)
		{
			string id = array[j];
			if (!flag)
			{
				playlist = (int.TryParse(id, out var result) ? playlists.ElementAtOrDefault(result) : playlists.FirstOrDefault((IPlaylist<T> p) => p.Name == id));
				if (playlist == null)
				{
					break;
				}
				if (playlist.Type != PlaylistType.Group)
				{
					flag = true;
					continue;
				}
				if (!(playlist is GroupPlaylist<T> groupPlaylist))
				{
					break;
				}
				playlists = groupPlaylist.Children.ToArray();
				continue;
			}
			if ((j == array.Length - 1 || j == array.Length - 2) && playlist is Playlist<T> source)
			{
				playlistItem = (int.TryParse(id, out var result2) ? source.ElementAtOrDefault(result2) : source.FirstOrDefault((T i) => i.Name == id));
			}
			break;
		}
		return playlistItem != null;
	}

	public static bool TryFindPlaylistItemPath<T>(this IEnumerable<IPlaylist<T>> playlists, T item, out int[]? finalPath, Func<Playlist<T>, T, int>? getItemIndex = null) where T : ProPresenterCue
	{
		return playlists.TryFindPlaylistItemPath(item, new List<int>(), out finalPath, getItemIndex);
	}

	public static bool TryFindPlaylistItemPath<T>(this IEnumerable<IPlaylist<T>> playlists, T item, List<int> track, out int[]? path, Func<Playlist<T>, T, int>? getItemIndex = null) where T : ProPresenterCue
	{
		path = null;
		foreach (IPlaylist<T> playlist2 in playlists)
		{
			if (playlist2 is GroupPlaylist<T> groupPlaylist)
			{
				if (groupPlaylist.Children.TryFindPlaylistItemPath(item, track, out path, getItemIndex))
				{
					track.Insert(0, playlists.IndexOf<IPlaylist<T>>(playlist2));
					path = track.ToArray();
					return true;
				}
			}
			else if (playlist2 is Playlist<T> playlist)
			{
				int num = getItemIndex?.Invoke(playlist, item) ?? playlist.IndexOf(item);
				if (num >= 0)
				{
					track.Insert(0, num);
					track.Insert(0, playlists.IndexOf(playlist));
					path = track.ToArray();
					return true;
				}
			}
		}
		return false;
	}

	public static IReadOnlyList<ITrackedMedia> GetTrackedMediaFromPlaylists(IReadOnlyList<IPlaylist<MediaCue>> playlists)
	{
		return playlists.SelectMany((IPlaylist<MediaCue> x) => x.SelectMany((MediaCue y) => from y in y.Actions.OfType<MediaAction>()
			select y.Media)).OfType<ITrackedMedia>().ToArray();
	}
}
