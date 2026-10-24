using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Localization;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PCO;

public class MatchSongsInteractor : IMatchSongsInteractor
{
	private readonly IPCOConsumer _consumer;

	public MatchSongsInteractor(IPCOConsumer consumer)
	{
		_consumer = consumer;
	}

	public void Execute(PCOPlan plan, PCOPlaylist playlist)
	{
		if (StoredPcoOptions.Settings.AutoDownload)
		{
			Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
			plan.PlanItems.ThrowWhenNull("plan.PlanItems");
			_consumer.DownloadFilesAsync(plan.PlanItems, delegate(string message)
			{
				dispatcher.InvokeAsync<string>((Func<string>)(() => _consumer.PCOBusyMessage = LocalizedStrings.Get("LIBRARY_PLAYLIST_ITEMS_DOWNLOADING_label", new object[1] { message })));
			}).ContinueWith(delegate(Task<IList<PCOAttachmentDetails>> downloadFilesTask)
			{
				IList<PCOAttachmentDetails> downloadedFiles = downloadFilesTask.Result;
				_consumer.IsPCOBusy = false;
				dispatcher.InvokeAsync((Action)delegate
				{
					playlist.HandleDownloadedFiles(downloadedFiles, DataVault.LibraryCollection?.FindLibrary(StoredPcoOptions.Settings.TargetLibrary));
					if (StoredPcoOptions.Settings.MatchSongs)
					{
						matchSongs(from c in playlist.OfType<PCOSongCue>()
							where c.PCOItem?.Attachments.Empty() ?? false
							select c);
					}
				});
			}).ExecuteAsync();
			if (StoredPcoOptions.Settings.MatchSongs)
			{
				matchSongs(playlist.OfType<PCOSongCue>());
			}
			return;
		}
		_consumer.IsPCOBusy = false;
		_consumer.PCOBusyMessage = string.Empty;
		if (StoredPcoOptions.Settings.MatchSongs)
		{
			matchSongs(from p in playlist.OfType<PCOCueBase>()
				where p is PCOSongCue || p is PCOPlanCue
				select p);
		}
		static void matchSongs(IEnumerable<PCOCueBase> pcoCues)
		{
			pcoCues.ForEach(delegate(PCOCueBase s)
			{
				IPresentation presentation = PresentationHelper.FindMatchToItem(s.PCOItem);
				if (presentation != null)
				{
					s.LinkDocument(presentation);
					PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, PlaceholderLinkSource.Automatic);
				}
			});
		}
	}
}
