using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.MediaLibrary;

public class MediaCueDragDropSourceCollection : IDragDropCollection<IMediaCueThumbnailVM>
{
	private readonly VisualPlaylist _playlist;

	public MediaCueDragDropSourceCollection(VisualPlaylist playlist)
	{
		_playlist = playlist;
	}

	public int IndexOf(IMediaCueThumbnailVM item)
	{
		return ((IDragDropCollection<MediaCue>)_playlist)?.IndexOf(item.MediaCue) ?? 0;
	}

	public void DraggedFrom(IEnumerable<IMediaCueThumbnailVM> items)
	{
		((IDragDropCollection<MediaCue>)_playlist).DraggedFrom(items.Select((IMediaCueThumbnailVM i) => i.MediaCue));
	}

	public void DroppedInto(IEnumerable<IMediaCueThumbnailVM> items, int index, bool isCopy)
	{
		((IDragDropCollection<MediaCue>)_playlist).DroppedInto(items.Select((IMediaCueThumbnailVM i) => i.MediaCue.Clone() as MediaCue).NotNull(), index, isCopy);
	}

	public void MoveTo(IEnumerable<IMediaCueThumbnailVM> items, int index)
	{
		((IDragDropCollection<MediaCue>)_playlist).MoveTo(items.Select((IMediaCueThumbnailVM i) => i.MediaCue), index);
	}
}
