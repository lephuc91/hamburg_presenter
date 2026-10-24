using System;
using System.Collections.Generic;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal static class AudioHandler
{
	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Audio_Request r)
	{
		if (r != null)
		{
			API_v1_Audio_Request.Types.Playlist playlist = r.Playlist;
			if (playlist != null)
			{
				return GetPlaylist(service.AudioPlaylists, playlist.Id, (int)playlist.Start);
			}
			if (r.Playlists != null)
			{
				return GetPlaylists(service.AudioPlaylists);
			}
			API_v1_Audio_Request.Types.PlaylistUpdates playlistUpdates = r.PlaylistUpdates;
			if (playlistUpdates != null)
			{
				return GetPlaylistUpdates(service.AudioPlaylists, playlistUpdates.Id);
			}
			if (r.PlaylistFocused != null)
			{
				return GetPlaylistFocused();
			}
			if (r.PlaylistActive != null)
			{
				return GetPlaylistActive();
			}
			if (r.PlaylistNextFocus != null)
			{
				return FocusNextPlaylist(service);
			}
			if (r.PlaylistPreviousFocus != null)
			{
				return FocusPreviousPlaylist(service);
			}
			if (r.PlaylistActiveFocus != null)
			{
				return FocusActivePlaylist(service);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistIdFocus = r.PlaylistIdFocus;
			if (playlistIdFocus != null)
			{
				return FocusPlaylistID(service, playlistIdFocus.Id);
			}
			if (r.PlaylistFocusedTrigger != null)
			{
				return TriggerFocusedPlaylist(service);
			}
			if (r.PlaylistActiveTrigger != null)
			{
				return TriggerActivePlaylist(service);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistIdTrigger = r.PlaylistIdTrigger;
			if (playlistIdTrigger != null)
			{
				return TriggerPlaylistID(service, playlistIdTrigger.Id);
			}
			if (r.PlaylistFocusedNextTrigger != null)
			{
				return TriggerNextFocused(service);
			}
			if (r.PlaylistFocusedPreviousTrigger != null)
			{
				return TriggerPreviousFocused(service);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistFocusedIdTrigger = r.PlaylistFocusedIdTrigger;
			if (playlistFocusedIdTrigger != null)
			{
				return TriggerFocusedItemID(service, playlistFocusedIdTrigger.Id);
			}
			if (r.PlaylistActiveNextTrigger != null)
			{
				return TriggerNextActive(service);
			}
			if (r.PlaylistActivePreviousTrigger != null)
			{
				return TriggerPreviousActive(service);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistActiveIdTrigger = r.PlaylistActiveIdTrigger;
			if (playlistActiveIdTrigger != null)
			{
				return TriggerActiveItemID(service, playlistActiveIdTrigger.Id);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistIdNextTrigger = r.PlaylistIdNextTrigger;
			if (playlistIdNextTrigger != null)
			{
				return TriggerNextItemInPlaylistWithID(service, playlistIdNextTrigger.Id);
			}
			API_v1_Audio_Request.Types.IdentifierMessage playlistIdPreviousTrigger = r.PlaylistIdPreviousTrigger;
			if (playlistIdPreviousTrigger != null)
			{
				return TriggerPreviousItemInPlaylistWithID(service, playlistIdPreviousTrigger.Id);
			}
		}
		return null;
	}

	internal static NetworkAPI_v1 PlaylistUpdate(Guid id, string name, uint index)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction($"/v1/audio/playlist/{id}/updates").AudioResponse().Update = new API_v1_Audio_Response.Types.PlaylistUpdate
			{
				Id = Common.ID(id, name, index)
			};
		});
	}

	private static NetworkAPI_v1 GetPlaylistUpdates(AudioPlaylistCollection audioPlaylists, string idPath)
	{
		return Common.TryFindPlaylistAndDo(audioPlaylists, idPath, (Playlist<MediaCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction($"/v1/audio/playlist/{playlist.ID}/updates");
		}));
	}

	private static NetworkAPI_v1 GetPlaylists(IEnumerable<IPlaylist<MediaCue>> playlists)
	{
		return UpdatePlaylists(playlists);
	}

	internal static NetworkAPI_v1 UpdatePlaylists(IEnumerable<IPlaylist<MediaCue>> playlists)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/audio/playlists").AudioResponse().Playlists(Common.GetPlaylists(playlists));
		});
	}

	private static NetworkAPI_v1 GetPlaylist(AudioPlaylistCollection audioPlaylists, string idPath, int start)
	{
		return Common.TryFindPlaylistAndDo(audioPlaylists, idPath, (Playlist<MediaCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().Playlist(Common.MediaPlaylistResponseProto(playlist, start, audioPlaylists));
		}));
	}

	private static API_v1_Audio_Response.Types.Playlists Playlists(this API_v1_Audio_Response response, IEnumerable<API_v1_Playlist> playlists)
	{
		API_v1_Audio_Response.Types.Playlists obj = new API_v1_Audio_Response.Types.Playlists
		{
			Playlists_ = { playlists }
		};
		API_v1_Audio_Response.Types.Playlists result = obj;
		response.Playlists = obj;
		return result;
	}

	private static void Playlist(this API_v1_Audio_Response response, Common.ProtoMediaPlaylistResponse proto)
	{
		response.Playlist = new API_v1_Audio_Response.Types.Playlist
		{
			Id = proto.ID,
			Items = { proto.Items }
		};
	}

	private static NetworkAPI_v1 GetPlaylistFocused()
	{
		API_v1_Audio_Response.Types.FocusedPlaylist current = null;
		AudioPlaylistFocusedProtoRequest.Publish(delegate(API_v1_Audio_Response.Types.FocusedPlaylist v)
		{
			current = v;
		});
		return FocusedPlaylistUpdated(current);
	}

	internal static NetworkAPI_v1 FocusedPlaylistUpdated(API_v1_Audio_Response.Types.FocusedPlaylist? focused)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/audio/playlist/focused").AudioResponse().PlaylistFocused = focused;
		});
	}

	private static NetworkAPI_v1 GetPlaylistActive()
	{
		API_v1_Audio_Response.Types.ActivePlaylist current = null;
		AudioPlaylistActiveProtoRequest.Publish(delegate(API_v1_Audio_Response.Types.ActivePlaylist v)
		{
			current = v;
		});
		return ActivePlaylistUpdated(current);
	}

	internal static NetworkAPI_v1 ActivePlaylistUpdated(API_v1_Audio_Response.Types.ActivePlaylist? active)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/audio/playlist/active").AudioResponse().PlaylistActive = active;
		});
	}

	private static NetworkAPI_v1 FocusNextPlaylist(IAPIv1Service service)
	{
		if (service.AudioPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		service.Triggering.ActiveAudioPlaylist = Common.GetProximalPlaylist(service.Triggering.ActiveAudioPlaylist, service.AudioPlaylists, 1);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().PlaylistNextFocus = new API_v1_Audio_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusPreviousPlaylist(IAPIv1Service service)
	{
		if (service.AudioPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		service.Triggering.ActiveAudioPlaylist = Common.GetProximalPlaylist(service.Triggering.ActiveAudioPlaylist, service.AudioPlaylists, -1);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().PlaylistPreviousFocus = new API_v1_Audio_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusActivePlaylist(IAPIv1Service service)
	{
		AudioPlaylist activePlaylist = GetActivePlaylist();
		if (activePlaylist != null)
		{
			service.Triggering.ActiveAudioPlaylist = activePlaylist;
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().PlaylistActiveFocus = new API_v1_Audio_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusPlaylistID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.AudioPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.ActiveAudioPlaylist = playlist as AudioPlaylist;
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistIdFocus = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static NetworkAPI_v1 TriggerFocusedPlaylist(IAPIv1Service service)
	{
		return TriggerFirstItemInPlaylist(service, service.Triggering.ActiveAudioPlaylist, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().PlaylistFocusedTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerActivePlaylist(IAPIv1Service service)
	{
		return TriggerFirstItemInPlaylist(service, GetActivePlaylist(), Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AudioResponse().PlaylistActiveTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
		}));
	}

	private static AudioPlaylist? GetActivePlaylist()
	{
		AudioPlaylist activePlaylist = null;
		AudioPlaylistActiveRequest.Publish(delegate(Playlist<MediaCue> v)
		{
			activePlaylist = v as AudioPlaylist;
		});
		return activePlaylist;
	}

	private static NetworkAPI_v1 TriggerFirstItemInPlaylist(IAPIv1Service service, AudioPlaylist? p, NetworkAPI_v1 successResponse)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, p, "0", delegate(MediaCue firstItem, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerAudio(firstItem, playlist);
			return successResponse;
		});
	}

	private static NetworkAPI_v1 TriggerPlaylistID(IAPIv1Service service, string idPath)
	{
		return Common.TriggerPlaylistID(service.Triggering, service.AudioPlaylists, idPath, delegate(MediaCue item, AudioPlaylist playlist)
		{
			service.Triggering.TriggerAudio(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistIdTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1? TriggerNextFocused(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, service.Triggering.ActiveAudioPlaylist, delegate(AudioPlaylist activePlaylist)
		{
			service.Triggering.TriggerNextAudio(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistFocusedNextTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1? TriggerPreviousFocused(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, service.Triggering.ActiveAudioPlaylist, delegate(AudioPlaylist activePlaylist)
		{
			service.Triggering.TriggerPreviousAudio(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistFocusedPreviousTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerFocusedItemID(IAPIv1Service service, string id)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, service.Triggering.ActiveAudioPlaylist, id, delegate(MediaCue item, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerAudio(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistFocusedIdTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1? TriggerNextActive(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, GetActivePlaylist(), delegate(AudioPlaylist activePlaylist)
		{
			service.Triggering.TriggerNextAudio(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistActiveNextTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1? TriggerPreviousActive(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, GetActivePlaylist(), delegate(AudioPlaylist activePlaylist)
		{
			service.Triggering.TriggerPreviousAudio(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistActivePreviousTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerActiveItemID(IAPIv1Service service, string id)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, GetActivePlaylist(), id, delegate(MediaCue item, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerAudio(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistActiveIdTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerNextItemInPlaylistWithID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.AudioPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerNextAudio((AudioPlaylist)playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistIdNextTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static NetworkAPI_v1 TriggerPreviousItemInPlaylistWithID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.AudioPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerPreviousAudio((AudioPlaylist)playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().AudioResponse().PlaylistIdPreviousTrigger = new API_v1_Audio_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static API_v1_Audio_Response AudioResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.AudioResponse ?? (action.AudioResponse = new API_v1_Audio_Response());
	}

	internal static API_v1_Audio_Response.Types.FocusedPlaylist CreateFocusedPlaylistProto(API_v1_Identifier? playlistID, API_v1_Identifier? _1, API_v1_PlaylistItem? _2)
	{
		return new API_v1_Audio_Response.Types.FocusedPlaylist
		{
			Id = playlistID
		};
	}

	internal static API_v1_Audio_Response.Types.ActivePlaylist CreateActivePlaylistProto(API_v1_Identifier? playlistID, API_v1_Identifier? itemID)
	{
		return new API_v1_Audio_Response.Types.ActivePlaylist
		{
			Playlist = playlistID,
			Item = itemID
		};
	}

	internal static bool FocusedPlaylistProtoEqual(API_v1_Audio_Response.Types.FocusedPlaylist a, API_v1_Audio_Response.Types.FocusedPlaylist b)
	{
		return a.NullableEquals<API_v1_Audio_Response.Types.FocusedPlaylist>(b);
	}

	internal static bool ActivePlaylistProtoEqual(API_v1_Audio_Response.Types.ActivePlaylist a, API_v1_Audio_Response.Types.ActivePlaylist b)
	{
		return a.NullableEquals<API_v1_Audio_Response.Types.ActivePlaylist>(b);
	}
}
