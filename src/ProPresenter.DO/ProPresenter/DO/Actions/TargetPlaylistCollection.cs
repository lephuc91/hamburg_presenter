using System;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Actions;

public class TargetPlaylistCollection<T> : ITargetPlaylistCollection where T : ProPresenterCue
{
	private readonly PlaylistCollectionBase<T>? _source;

	public event Action? CollectionModified;

	public TargetPlaylistCollection(PlaylistCollectionBase<T> source)
	{
		if (source != null)
		{
			_source = source;
			_source.CollectionModified += delegate
			{
				this.CollectionModified?.Invoke();
			};
		}
	}

	public IIdentifiable? GetPlaylist(Guid id, string name)
	{
		return _source?.GetPlaylists().FirstOrDefaultBy((IPlaylist<T> p) => p.ID == id, (IPlaylist<T> p) => p.Name == name);
	}
}
