using System;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.Controller;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.Calendar;

namespace ProPresenter.ViewModels.Library;

public class CalendarService : ICalendarService
{
	private readonly IProPresenterResourceService _resources;

	private readonly ITriggering _service;

	public ProPresenterCue? TriggeredCue { get; private set; }

	public Playlist<ProPresenterCue>? TriggeredPlaylist { get; private set; }

	public event EventHandler<CalendarCueTriggeredEventArgs>? CueTriggered;

	public CalendarService(ITriggeringFactory triggeringFactory, IProPresenterResourceService resources)
	{
		_resources = resources;
		_service = triggeringFactory.Create();
		_resources.Calendar.EventTriggered += Calendar_EventTriggered;
	}

	public ICalendarService.ActionType GetActionType(LibraryPlaylistAction action)
	{
		if (action.PlaylistItemID == Guid.Empty)
		{
			return ICalendarService.ActionType.Playlist;
		}
		if (_resources.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == action.PlaylistID).FirstOrDefault() is Playlist<ProPresenterCue> collection)
		{
			ProPresenterCue proPresenterCue = collection.FirstOrDefaultBy((ProPresenterCue i) => i.ID == action.PlaylistItemID, (ProPresenterCue i) => i.Name == action.PlaylistItemName);
			if (proPresenterCue != null)
			{
				if (!(proPresenterCue is IDocumentCue))
				{
					return ICalendarService.ActionType.Other;
				}
				return ICalendarService.ActionType.Presentation;
			}
		}
		return ICalendarService.ActionType.Other;
	}

	private void Calendar_EventTriggered(Event calendarEvent)
	{
		IAction eventAction = calendarEvent.EventAction;
		if (!(eventAction is LibraryPlaylistAction action))
		{
			if (!(eventAction is MacroAction macroAction))
			{
				if (eventAction is CaptureAction captureAction)
				{
					_service.TriggerCapture(captureAction);
				}
			}
			else
			{
				TriggerMacro(macroAction);
			}
		}
		else if (CanTriggerLibraryPlaylistAction(action))
		{
			TriggerLibraryPlaylistAction(action);
		}
	}

	private void TriggerLibraryPlaylistAction(LibraryPlaylistAction action)
	{
		if (!(_resources.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == action.PlaylistID).FirstOrDefault() is Playlist<ProPresenterCue> playlist))
		{
			return;
		}
		TriggeredPlaylist = playlist;
		ProPresenterCue proPresenterCue = playlist.FirstOrDefault();
		if ((object)action.PlaylistItemIdentification != null)
		{
			proPresenterCue = playlist.FirstOrDefaultBy((ProPresenterCue i) => i.ID == action.PlaylistItemID, (ProPresenterCue i) => i.Name == action.PlaylistItemName);
		}
		if (proPresenterCue == null)
		{
			return;
		}
		TriggeredCue = proPresenterCue;
		if (proPresenterCue is IDocumentCue { DocumentAction: not null } documentCue)
		{
			ArrangedCue arrangedCue = documentCue.DocumentAction?.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue c) => c.IsEnabled);
			if (arrangedCue != null)
			{
				this.CueTriggered?.Invoke(this, new CalendarCueTriggeredEventArgs(TriggeredPlaylist, TriggeredCue));
				_service.TriggerSlide(arrangedCue);
			}
		}
		else if (proPresenterCue is IMediaCue { MediaAction: not null } mediaCue)
		{
			this.CueTriggered?.Invoke(this, new CalendarCueTriggeredEventArgs(TriggeredPlaylist, TriggeredCue));
			TriggerMedia(mediaCue.MediaAction, playlist);
		}
	}

	private bool CanTriggerLibraryPlaylistAction(LibraryPlaylistAction action)
	{
		if (_resources.LibraryPlaylists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == action.PlaylistID).FirstOrDefault() is GeneralPlaylist generalPlaylist)
		{
			ProPresenterCue proPresenterCue = generalPlaylist.FirstOrDefault();
			if ((object)action.PlaylistItemIdentification != null)
			{
				proPresenterCue = generalPlaylist.FirstOrDefaultBy((ProPresenterCue i) => i.ID == action.PlaylistItemID, (ProPresenterCue i) => i.Name == action.PlaylistItemName);
			}
			if (proPresenterCue is DocumentCue documentCue && documentCue.DocumentAction.PresentationType == PresentationType.MultiTracks)
			{
				IPresentation? presentation = documentCue.DocumentAction.Presentation;
				if (presentation == null || !presentation.IsAvailable)
				{
					return false;
				}
			}
			if (proPresenterCue == null && generalPlaylist != null && generalPlaylist.Any() && generalPlaylist.All(delegate(ProPresenterCue c)
			{
				if (c is DocumentCue documentCue2 && documentCue2.DocumentAction.PresentationType == PresentationType.MultiTracks)
				{
					IPresentation? presentation2 = documentCue2.DocumentAction.Presentation;
					if (presentation2 == null)
					{
						return true;
					}
					return !presentation2.IsAvailable;
				}
				return false;
			}))
			{
				return false;
			}
		}
		return true;
	}

	private void TriggerMedia(MediaAction mediaAction, Playlist<ProPresenterCue> playlist)
	{
		if (mediaAction != null)
		{
			switch (mediaAction.Media.MediaType)
			{
			case MediaType.Image:
			case MediaType.Video:
				_service.TriggerBackground(new MediaCue(mediaAction), playlist, CueLocation.PlaylistLibrary);
				break;
			case MediaType.Audio:
				_service.TriggerAudio(new MediaCue(mediaAction), playlist, CueLocation.PlaylistLibrary);
				break;
			}
		}
	}

	private void TriggerMacro(MacroAction macroAction)
	{
		ProPresenterMacro proPresenterMacro = _resources.MacroSource?.FindMacro(macroAction.MacroID, macroAction.MacroName, macroAction.MacroParentCollectionID, macroAction.MacroParentCollectionName);
		if (proPresenterMacro != null)
		{
			_service.TriggerMacro(proPresenterMacro);
		}
	}
}
