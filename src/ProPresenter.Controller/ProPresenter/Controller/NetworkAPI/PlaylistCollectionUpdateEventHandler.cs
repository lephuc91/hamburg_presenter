using System;
using System.Collections.Generic;
using System.Linq;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class PlaylistCollectionUpdateEventHandler<T> : DebouncedEventSender where T : ProPresenterCue
{
	private class PlaylistData
	{
		public Guid Id { get; }

		public string Name { get; }

		public IEnumerable<PlaylistData> Children { get; }

		public PlaylistData(Guid id, string name, IEnumerable<PlaylistData> children)
		{
			Id = id;
			Name = name;
			Children = children;
		}
	}

	private IEnumerable<PlaylistData> _previous = Array.Empty<PlaylistData>();

	private IEnumerable<PlaylistData> _current = Array.Empty<PlaylistData>();

	private readonly PlaylistCollectionBase<T> _playlists;

	public PlaylistCollectionUpdateEventHandler(PlaylistCollectionBase<T> playlists)
	{
		_playlists = playlists;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		EventResult result = EventResult.Continue;
		if (@event is PlaylistCollectionUpdated<T> playlistCollectionUpdated)
		{
			IEnumerable<PlaylistData> enumerable = ToPlaylistData(playlistCollectionUpdated.Playlists);
			if (!TreeContentsMatchExactly(_current, enumerable))
			{
				_current = enumerable;
				result = EventResult.Debounce;
			}
		}
		return result;
	}

	protected override void Publish()
	{
		if (!TreeContentsMatchExactly(_previous, _current))
		{
			OnSend(GetProto(_playlists));
		}
		_previous = _current;
	}

	protected virtual NetworkAPI_v1? GetProto(PlaylistCollectionBase<T> playlists)
	{
		return null;
	}

	private static IEnumerable<PlaylistData> ToPlaylistData(IEnumerable<IPlaylist<T>> playlists)
	{
		if (playlists == null)
		{
			return Enumerable.Empty<PlaylistData>();
		}
		List<PlaylistData> list = new List<PlaylistData>();
		foreach (IPlaylist<T> playlist in playlists)
		{
			list.Add(new PlaylistData(playlist.ID, playlist.Name, ToPlaylistData(playlist.Children ?? Enumerable.Empty<IPlaylist<T>>())));
		}
		return list;
	}

	private static bool TreeContentsMatchExactly(IEnumerable<PlaylistData> lh, IEnumerable<PlaylistData> rh)
	{
		if (lh == rh)
		{
			return true;
		}
		if (lh == null || rh == null)
		{
			return false;
		}
		if (lh.Count() != rh.Count())
		{
			return false;
		}
		PlaylistData[] array = lh.ToArray();
		PlaylistData[] array2 = rh.ToArray();
		bool flag = true;
		for (int i = 0; i < lh.Count(); i++)
		{
			flag = flag && array[i].Id == array2[i].Id && array[i].Name == array2[i].Name && TreeContentsMatchExactly(array[i].Children, array2[i].Children);
		}
		return flag;
	}
}
