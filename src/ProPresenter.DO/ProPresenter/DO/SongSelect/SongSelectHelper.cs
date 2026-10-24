using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.SongSelect;

public static class SongSelectHelper
{
	public static void Import(this ISongSelectConsumer consumer, IImportProcessFactory importProcessFactory, SongSelectSearchResult result, Action<string, IImportProcess>? completeCallback = null)
	{
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		consumer.GetSongDetailsAsync(result.SongNumber).ContinueWith(delegate(Task<SongSelectSongInfo?> getLyricsResult)
		{
			SongSelectSongInfo result2 = getLyricsResult.Result;
			if (result2 != null)
			{
				string text = string.Join(LineBreaks.NewLine + LineBreaks.NewLine, result2.Lyrics.Select((SongSelectSongPart part) => $"({part.PartLabel}){LineBreaks.NewLine}{part.LyricText}"));
				MemoryImportRequest memoryImportRequest = new MemoryImportRequest(result2.Title, text, null, new CCLIData
				{
					Title = result2.Title,
					Display = true,
					Author = result2.Author,
					Copyright = result2.Copyright,
					Publisher = result2.Publisher,
					SongNumber = result2.SongId.ToString()
				}, null, ImportSource.SongSelect);
				IImportProcess importProcess = importProcessFactory.Create(memoryImportRequest);
				if (completeCallback != null)
				{
					memoryImportRequest.CompleteCallback = delegate(string filename)
					{
						completeCallback(filename, importProcess);
					};
				}
				importProcess.StartImport();
			}
			else
			{
				Log.Warning("[{1}] Importing a song failed.", "SongSelectHelper");
				dispatcher.Invoke((Action)delegate
				{
					MessageDialogService.ShowAlert(LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_SONGSELECT_NO_LYRICS_ALERT_title"));
				});
			}
		}).ExecuteAsync();
	}
}
