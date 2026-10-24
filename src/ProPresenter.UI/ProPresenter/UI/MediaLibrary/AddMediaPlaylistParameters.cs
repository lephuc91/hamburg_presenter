using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.MediaLibrary;

public class AddMediaPlaylistParameters : DragDropCommandParameters<SlideCue?, CustomPresentation>
{
	public IEnumerable<IPlaylist<MediaCue>> Playlists { get; }

	public AddMediaPlaylistParameters(CustomPresentation? targetPresentation, SlideCue? targetCue, IEnumerable<IPlaylist<MediaCue>> playlists, bool droppedBefore, bool droppedOutside)
		: base(targetPresentation, Enumerable.Empty<SlideCue>(), targetCue, -1, droppedBefore, droppedOutside, copy: false)
	{
		Playlists = playlists;
	}
}
