using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Library;

public interface IExportService
{
	void Presentations(IEnumerable<IDocumentCue> presentations);

	void Playlists(IEnumerable<IPlaylist<ProPresenterCue>> playlists);

	void ToBundle(IEnumerable<IDocumentCue> presentations);

	void ToText(IEnumerable<IDocumentCue> presentations);
}
