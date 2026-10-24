using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI;

internal class LibraryPlaylistActiveItemEventHandler : IApplicationEventHandler
{
	private readonly IAPIv1Service _service;

	private API_v1_Playlist_Response.Types.GetActivePlaylist _current;

	private List<(Playlist<ProPresenterCue>? playlist, ProPresenterCue? item, LayerStatus layers)> _activePlaylistsAndItemsPresentation;

	private List<(Playlist<ProPresenterCue>? playlist, ProPresenterCue? item, LayerStatus layers)> _activePlaylistsAndItemsAnnouncements;

	public LibraryPlaylistActiveItemEventHandler(IAPIv1Service service)
	{
		_service = service;
		_current = new API_v1_Playlist_Response.Types.GetActivePlaylist
		{
			Presentation = new API_v1_PlaylistAndItem(),
			Announcements = new API_v1_PlaylistAndItem()
		};
		_activePlaylistsAndItemsPresentation = new List<(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus)>();
		_activePlaylistsAndItemsAnnouncements = new List<(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus)>();
		ApplicationEventPublisher.AddHandler(this);
	}

	public API_v1_Playlist_Response.Types.GetActivePlaylist ActivePlaylist()
	{
		return _current;
	}

	public void Handle(IApplicationEvent @event)
	{
		ProPresenterCue playlistItem;
		Playlist<ProPresenterCue> playlist;
		ProLayerIndex layer;
		ProResourceState state;
		if (@event is LibraryPlaylistActiveItemUpdated libraryPlaylistActiveItemUpdated)
		{
			libraryPlaylistActiveItemUpdated.Deconstruct(out OutputDestination Destination, out playlistItem, out playlist, out layer, out state);
			if ((playlistItem != null && playlist == null) || (state != ProResourceState.Activated && state != ProResourceState.Deactivated))
			{
				return;
			}
			API_v1_Playlist_Response.Types.GetActivePlaylist getActivePlaylist = _current.Clone();
			uint index = (uint)(playlist?.PlaylistParent?.Children ?? _service.LibraryPlaylists.Children).IndexOf(playlist);
			uint? num = (uint?)((playlistItem == null) ? new int?(-1) : playlist?.IndexOf(playlistItem));
			switch (Destination)
			{
			case OutputDestination.Presentation:
				processUpdate(ref _activePlaylistsAndItemsPresentation);
				getActivePlaylist.Presentation = new API_v1_PlaylistAndItem
				{
					Playlist = Common.NullableID(_activePlaylistsAndItemsPresentation.LastOrDefault().playlist, index),
					Item = Common.NullableID(_activePlaylistsAndItemsPresentation.LastOrDefault().item, num.GetValueOrDefault())
				};
				if (playlistItem != null && playlist != null)
				{
					getActivePlaylist.Presentation.PlaylistItem = playlistItem.ToPlaylistItem(playlist);
				}
				break;
			case OutputDestination.Announcement:
				processUpdate(ref _activePlaylistsAndItemsAnnouncements);
				getActivePlaylist.Announcements = new API_v1_PlaylistAndItem
				{
					Playlist = Common.NullableID(_activePlaylistsAndItemsAnnouncements.LastOrDefault().playlist, index),
					Item = Common.NullableID(_activePlaylistsAndItemsAnnouncements.LastOrDefault().item, num.GetValueOrDefault())
				};
				if (playlistItem != null && playlist != null)
				{
					getActivePlaylist.Announcements.PlaylistItem = playlistItem.ToPlaylistItem(playlist);
				}
				break;
			}
			_current = getActivePlaylist;
		}
		else if (@event is LibraryPlaylistActivePresentationRequest libraryPlaylistActivePresentationRequest)
		{
			libraryPlaylistActivePresentationRequest.Deconstruct(out Action<Playlist<ProPresenterCue>, ProPresenterCue> Callback);
			(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus) tuple = _activePlaylistsAndItemsPresentation.LastOrDefault();
			Callback(tuple.Item1, tuple.Item2);
		}
		else if (@event is LibraryPlaylistActiveAnnouncementRequest libraryPlaylistActiveAnnouncementRequest)
		{
			libraryPlaylistActiveAnnouncementRequest.Deconstruct(out Action<Playlist<ProPresenterCue>, ProPresenterCue> Callback2);
			(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus) tuple2 = _activePlaylistsAndItemsAnnouncements.LastOrDefault();
			Callback2(tuple2.Item1, tuple2.Item2);
		}
		void processUpdate(ref List<(Playlist<ProPresenterCue>? playlist, ProPresenterCue? item, LayerStatus layers)> active)
		{
			if (state == ProResourceState.Activated)
			{
				int num2 = active.FindIndex(((Playlist<ProPresenterCue>? playlist, ProPresenterCue? item, LayerStatus layers) x) => x.playlist == playlist && x.item == playlistItem);
				if (num2 >= 0)
				{
					(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus) item = active[num2];
					active.RemoveAt(num2);
					item.Item3 |= layer.ToLayerStatus();
					active.Add(item);
				}
				else
				{
					active.Add((playlist, playlistItem, layer.ToLayerStatus()));
				}
			}
			else
			{
				int num3 = active.FindIndex(((Playlist<ProPresenterCue>? playlist, ProPresenterCue? item, LayerStatus layers) x) => x.playlist == playlist && x.item == playlistItem);
				if (num3 >= 0)
				{
					(Playlist<ProPresenterCue>, ProPresenterCue, LayerStatus) item2 = active[num3];
					item2.Item3 &= ~layer.ToLayerStatus();
					active.RemoveAt(num3);
					if (item2.Item3 != 0)
					{
						active.Insert(num3, item2);
					}
				}
			}
		}
	}
}
