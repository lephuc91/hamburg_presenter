using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Export.Requests;

public class PlaylistExportRequest : NotifyPropertyChangedBase, IExportRequest
{
	private string _currentItemName = string.Empty;

	private bool _includeMedia;

	private bool _archiving;

	public IEnumerable<IPlaylist<ProPresenterCue>> Playlists { get; }

	public bool IncludeMedia
	{
		get
		{
			return _includeMedia;
		}
		set
		{
			SetValue("IncludeMedia", ref _includeMedia, value);
		}
	}

	public string CurrentItemName
	{
		get
		{
			return _currentItemName;
		}
		set
		{
			SetValue("CurrentItemName", ref _currentItemName, value);
		}
	}

	public bool Archiving
	{
		get
		{
			return _archiving;
		}
		set
		{
			SetValue("Archiving", ref _archiving, value);
		}
	}

	public int ItemCount { get; private set; }

	public PlaylistExportRequest(IEnumerable<IPlaylist<ProPresenterCue>> playlists, bool includeMedia)
	{
		Playlists = playlists;
		IncludeMedia = includeMedia;
		playlists.FindMedia(delegate
		{
			ItemCount++;
		}, includeMedia);
		ItemCount += playlists.Count();
	}
}
