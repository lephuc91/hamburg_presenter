using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller;

internal static class ProtoNetworkIdentifierExtensions
{
	public static NetworkIdentifier ToNetworkIdentifier(this int index)
	{
		return index.ToEnumerable().ToNetworkIdentifier();
	}

	public static NetworkIdentifier ToNetworkIdentifier(this IEnumerable<int> indexPath)
	{
		NetworkIdentifier networkIdentifier = new NetworkIdentifier();
		networkIdentifier.AddIndexPath(indexPath);
		return networkIdentifier;
	}

	public static NetworkIdentifier AddIndex(this NetworkIdentifier id, int index)
	{
		return id.AddIndexPath(index.ToEnumerable());
	}

	public static NetworkIdentifier AddIndexPath(this NetworkIdentifier id, IEnumerable<int> indexPath)
	{
		id.Identifiers.AddRange(indexPath.Select((int index) => new NetworkIdentifier.Types.IndexOrName
		{
			Index = index
		}));
		return id;
	}

	public static T? FindItem<T>(this NetworkIdentifier.Types.IndexOrName level, IEnumerable<T> source) where T : class, IIdentifiable
	{
		return level.FindItem(source, (T i) => i.Name);
	}

	public static T? FindItem<T>(this NetworkIdentifier.Types.IndexOrName? level, IEnumerable<T>? source, Func<T, string?> nameProvider) where T : class
	{
		if (level == null || source == null)
		{
			return null;
		}
		return level.ComponentCase switch
		{
			NetworkIdentifier.Types.IndexOrName.ComponentOneofCase.Index => source.ElementAtOrDefault(level.Index), 
			NetworkIdentifier.Types.IndexOrName.ComponentOneofCase.Name => source.FirstOrDefaultOf((T i) => nameProvider(i) == level.Name), 
			_ => null, 
		};
	}

	public static T? FindItem<T>(this NetworkIdentifier id, IEnumerable<T> source) where T : class, IIdentifiable
	{
		return id.FindItem(source, (T i) => i.Name);
	}

	public static T? FindItem<T>(this NetworkIdentifier id, IEnumerable<T>? source, Func<T, string?> nameProvider) where T : class
	{
		return id.Identifiers.FirstOrDefault().FindItem(source, nameProvider);
	}

	public static T? FindPlaylistItem<T>(this NetworkIdentifier id, PlaylistCollectionBase<T> source, out Playlist<T>? matchPlaylist, out int nextLevel) where T : ProPresenterCue
	{
		matchPlaylist = null;
		nextLevel = 0;
		if (id.Identifiers.Empty())
		{
			return null;
		}
		int count = id.Identifiers.Count;
		IPlaylist<T> playlist = findPlaylist(id, source, nextLevel++);
		while (playlist != null && playlist.Type == PlaylistType.Group && nextLevel < count - 1)
		{
			playlist = findPlaylist(id, playlist.Children ?? Enumerable.Empty<IPlaylist<T>>(), nextLevel++);
		}
		matchPlaylist = playlist as Playlist<T>;
		if (matchPlaylist != null && nextLevel < count)
		{
			return id.Identifiers[nextLevel++].FindItem(matchPlaylist, (T i) => i.Name);
		}
		return null;
		static IPlaylist<T>? findPlaylist(NetworkIdentifier id, IEnumerable<IPlaylist<T>> root, int level)
		{
			return id.Identifiers[level].FindItem(root, (IPlaylist<T> p) => p.Name);
		}
	}
}
