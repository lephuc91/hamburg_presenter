using System;
using Pro.Common.Mathematics;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.MultiTracks;

public static class MultiTracksHelper
{
	public static void Import(this IMultiTracksConsumer consumer, MultiTracksSearchResult searchResult, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, ILibrary library, IPlaylist<ProPresenterCue>? playlist, IApp app, IImportProcessFactory importProcessFactory, Action<string?, IImportProcess>? completeCallback = null, Action<string>? errorCallback = null)
	{
		consumer.GetImportedSong(searchResult, linesPerSlide, templateSlide, documentSize, presentationName, delegate(PresentationBase p)
		{
			HandleImportedSong(p, library, playlist, importProcessFactory, completeCallback);
		}, errorCallback);
		ReportAnalytics(usingChords: false, linesPerSlide, app);
	}

	public static void Import(this IMultiTracksConsumer consumer, MultiTracksSearchResult searchResult, Key baseKey, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, ILibrary library, IPlaylist<ProPresenterCue>? playlist, IApp app, IImportProcessFactory importProcessFactory, Action<string?, IImportProcess>? completeCallback = null, Action<string>? errorCallback = null)
	{
		consumer.GetImportedSong(searchResult, baseKey, linesPerSlide, templateSlide, documentSize, presentationName, delegate(PresentationBase p)
		{
			HandleImportedSong(p, library, playlist, importProcessFactory, completeCallback);
		}, errorCallback);
		ReportAnalytics(usingChords: true, linesPerSlide, app);
	}

	private static void ReportAnalytics(bool usingChords, int linesPerSlide, IApp app)
	{
		MultiTracksImportEvent.Publish(app.MultiTracksChartProStatus, app.MultiTracksSlideProStatus, usingChords, linesPerSlide);
	}

	private static void HandleImportedSong(PresentationBase presentation, ILibrary library, IPlaylist<ProPresenterCue>? playlist, IImportProcessFactory importProcessFactory, Action<string?, IImportProcess>? completeCallback)
	{
		GeneratedPresentationRequest request = new GeneratedPresentationRequest(presentation);
		IImportProcess importProcess = importProcessFactory.Create(request);
		importProcess.SelectedLibrary = library;
		importProcess.SelectedPlaylist = playlist;
		if (completeCallback != null)
		{
			importProcess.ImportComplete += delegate(IImportProcess p)
			{
				completeCallback(presentation.SourceFile, p);
			};
		}
		importProcess.StartImport();
	}
}
