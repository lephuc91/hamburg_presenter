using System.Collections;
using System.Collections.Generic;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public interface ILibraryPlaylist<T> : IEnumerable<T>, IEnumerable where T : ProPresenterCue
{
	void AddPresentationItem(IEnumerable<T> cues, int pos);
}
