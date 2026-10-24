using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Export.Handlers;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Export;

public class ExportProcessFactory : IExportProcessFactory
{
	private readonly IEnumerable<IRequestHandler> _handlers;

	public ExportProcessFactory(IFileSystem fileSystem, IFileService fileService, IFlagService flagService)
	{
		_handlers = new global::_003C_003Ez__ReadOnlyArray<IRequestHandler>(new IRequestHandler[6]
		{
			new PlainTextDocumentHandler(fileSystem, fileService),
			new PresentationHandler(fileSystem, fileService),
			new ThemeHandler(fileSystem, fileService, flagService),
			new PresentationBundleHandler(fileSystem, fileService),
			new SlideImageDocumentHandler(fileSystem),
			new PlaylistHandler(fileSystem, fileService)
		});
	}

	public IExportProcess Create(IEnumerable<IPlaylist<ProPresenterCue>> playlists, bool includeMedia, string destination, Dispatcher? dispatcher = null)
	{
		return Create(new global::_003C_003Ez__ReadOnlySingleElementList<IExportRequest>(new PlaylistExportRequest(playlists, includeMedia)), destination, dispatcher);
	}

	public IExportProcess Create(IEnumerable<Theme> themes, string destination, Dispatcher? dispatcher = null)
	{
		return Create(new global::_003C_003Ez__ReadOnlySingleElementList<IExportRequest>(new ThemeExportRequest(themes)), destination, dispatcher);
	}

	public IExportProcess Create(IEnumerable<IDocumentCue> documents, IExportImageSettings imageOptions, Dispatcher? dispatcher = null)
	{
		return Create(documents.Select((IDocumentCue c) => c.DocumentAction?.Presentation).NotNull(), imageOptions, dispatcher);
	}

	public IExportProcess Create(IEnumerable<IPresentation> documents, IExportImageSettings imageOptions, Dispatcher? dispatcher = null)
	{
		return Create(new global::_003C_003Ez__ReadOnlySingleElementList<IExportRequest>(new SlideImageExportRequest(documents, imageOptions)), imageOptions.ExportName, dispatcher);
	}

	public IExportProcess Create(IEnumerable<IDocumentCue> documents, DocumentExportOption exportOption, string destination, Dispatcher? dispatcher = null)
	{
		return Create(documents.Select((IDocumentCue c) => c.DocumentAction?.Presentation).NotNull(), exportOption, destination, dispatcher);
	}

	public IExportProcess Create(IEnumerable<IPresentation> documents, DocumentExportOption exportOption, string destination, Dispatcher? dispatcher = null)
	{
		return Create(new global::_003C_003Ez__ReadOnlySingleElementList<IExportRequest>(new DocumentExportRequest(documents, exportOption)), destination, dispatcher);
	}

	public IExportProcess Create(IEnumerable<IExportRequest> requests, string destination, Dispatcher? dispatcher = null)
	{
		return new ExportProcess(requests, destination, _handlers, dispatcher);
	}
}
