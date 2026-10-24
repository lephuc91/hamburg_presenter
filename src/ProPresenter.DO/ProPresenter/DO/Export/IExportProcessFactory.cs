using System.Collections.Generic;
using System.Windows.Threading;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Export;

public interface IExportProcessFactory
{
	IExportProcess Create(IEnumerable<IDocumentCue> documents, DocumentExportOption exportOption, string destination, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<IDocumentCue> documents, IExportImageSettings imageOptions, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<IExportRequest> requests, string destination, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<IPlaylist<ProPresenterCue>> playlists, bool includeMedia, string destination, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<IPresentation> documents, DocumentExportOption exportOption, string destination, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<IPresentation> documents, IExportImageSettings imageOptions, Dispatcher? dispatcher = null);

	IExportProcess Create(IEnumerable<Theme> themes, string destination, Dispatcher? dispatcher = null);
}
