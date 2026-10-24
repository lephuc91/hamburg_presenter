using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Entity;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.PCO;

namespace ProPresenter.DO.Playlists;

public static class PCOPlaylistHelper
{
	public static void UploadToPCO(IPCOConsumer consumer, PCOCueBase? pcoCue)
	{
		if (consumer == null)
		{
			return;
		}
		PCOCueBase? pCOCueBase = pcoCue;
		if (pCOCueBase == null || !pCOCueBase.IsLinked)
		{
			return;
		}
		List<PCOUpdateInformation> updateRequests = pcoCue.GetUpdateRequests();
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		consumer.UploadFilesAsync(updateRequests, delegate(string f)
		{
			dispatcher.InvokeAsync((Action)delegate
			{
				if (!string.IsNullOrEmpty(f))
				{
					consumer.IsPCOBusy = true;
				}
				else
				{
					consumer.PCOBusyMessage = string.Empty;
					consumer.IsPCOBusy = false;
				}
			});
		}, delegate(PCOUpdateInformation request, bool successful, PCOItem? result)
		{
			if (!successful)
			{
				dispatcher.InvokeAsync((Action)delegate
				{
					pcoCue.ReEnqueueUpdateRequest(request);
				}, (DispatcherPriority)4);
			}
			else
			{
				pcoCue.PCOItem = result;
			}
		}).ExecuteAsync();
	}

	public static GeneralPlaylist? ConvertToStandardPlaylist(this PCOPlaylist? pcoPlaylist, UndoStack? undoStack, IEntityFactory entityFactory, ILogger logger, IProPresenterCueFactory cueFactory)
	{
		if (pcoPlaylist == null)
		{
			return null;
		}
		undoStack?.StartIgnoring();
		GeneralPlaylist generalPlaylist = new GeneralPlaylist(logger, cueFactory, undoStack, pcoPlaylist.Name);
		foreach (ProPresenterCue item in pcoPlaylist)
		{
			if (item.Type == CueType.PCO)
			{
				PCOCueBase pCOCueBase = (PCOCueBase)item;
				switch (pCOCueBase.PCOItemType)
				{
				case PCOItemType.Header:
					generalPlaylist.AddItem(new HeaderCue((HeaderAction)((PCOHeaderCue)pCOCueBase).HeaderAction.Clone()));
					break;
				case PCOItemType.Plan:
				case PCOItemType.Song:
				case PCOItemType.Media:
					switch (pCOCueBase.PCOAction?.LinkedObjectType)
					{
					case LinkState.Unlinked:
						generalPlaylist.AddPlaceholderPlaylistItem(pCOCueBase.PCOItem?.Name ?? string.Empty);
						break;
					case LinkState.DocumentLinked:
						generalPlaylist.AddPresentationItem(pCOCueBase.DocumentAction);
						break;
					case LinkState.MediaLinked:
						generalPlaylist.AddItem(cueFactory.CreateMediaCue(pCOCueBase.MediaAction.Media.Clone()));
						break;
					}
					break;
				}
			}
			else
			{
				generalPlaylist.AddItem((ProPresenterCue)item.Clone());
			}
		}
		undoStack?.StopIgnoring();
		return generalPlaylist;
	}
}
