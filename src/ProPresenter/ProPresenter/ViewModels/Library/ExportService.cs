using System.Collections.Generic;
using System.Linq;
using Pro.Common.FileSystem;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Export;
using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Library;

public class ExportService : IExportService
{
	private readonly IExportProcessFactory _exportProcessFactory;

	public ExportService(IExportProcessFactory exportProcessFactory)
	{
		_exportProcessFactory = exportProcessFactory;
	}

	public void Playlists(IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		if (playlists != null && playlists.Any())
		{
			DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EXPORT_PLAYLISTS_INCLUDE_MEDIA_BUTTON_title"), DefaultButtons.YES | DefaultButtons.NO, DefaultButtons.YES);
			string filename = GetExportName(LocalizedStrings.Get("LIBRARY_PLAYLIST_EXPORT_MULTIPLE_PLAYLISTS_SAVE_NAME_title"), playlists) + ".proPlaylist";
			if (defaultButtons.HasValue && DialogHelper.SaveFile(FileFilters.ProPlaylistFilter, filename, out string selectedFilename))
			{
				_exportProcessFactory.Create(playlists, defaultButtons == DefaultButtons.YES, selectedFilename).StartExport();
			}
		}
	}

	public void ToText(IEnumerable<IDocumentCue> presentations)
	{
		if (tryGetDesintation(out var destination2))
		{
			_exportProcessFactory.Create(presentations, DocumentExportOption.PlainText, destination2).StartExport();
		}
		bool tryGetDesintation(out string destination)
		{
			if (presentations.Count() <= 1)
			{
				return DialogHelper.SaveFile(FileFilters.AllTextFilter, ((Pro.DO.Triggering.Cue)presentations.First()).Name, out destination);
			}
			return DialogHelper.SelectFolderPath(out destination);
		}
	}

	public void Presentations(IEnumerable<IDocumentCue> presentations)
	{
		if (DialogHelper.SelectFolderPath(out string selectedPath))
		{
			_exportProcessFactory.Create(presentations, DocumentExportOption.Document, selectedPath).StartExport();
		}
	}

	public void ToBundle(IEnumerable<IDocumentCue> presentations)
	{
		if (DialogHelper.SaveFile(FileFilters.ProPresentationBundleFilter, ((Pro.DO.Triggering.Cue)presentations.First()).Name, out string selectedFilename))
		{
			_exportProcessFactory.Create(presentations, DocumentExportOption.Bundle, selectedFilename).StartExport();
		}
	}

	private static string GetExportName(string nameForMultipleCues, IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		if (playlists.Count() != 1)
		{
			return nameForMultipleCues;
		}
		return playlists.First().Name.SanitizeFilename();
	}
}
