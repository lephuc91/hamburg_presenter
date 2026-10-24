using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal static class MediaHandler
{
	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Media_Request request)
	{
		if (request != null)
		{
			if (request.Playlists != null)
			{
				return GetPlaylists(service.VisualPlaylists);
			}
			API_v1_Media_Request.Types.GetPlaylist getPlaylist = request.GetPlaylist;
			if (getPlaylist != null)
			{
				return GetPlaylist(service.VisualPlaylists, getPlaylist.Id, (int)getPlaylist.Start);
			}
			API_v1_Media_Request.Types.GetPlaylistUpdates getPlaylistUpdates = request.GetPlaylistUpdates;
			if (getPlaylistUpdates != null)
			{
				return GetPlaylistUpdates(service.VisualPlaylists, getPlaylistUpdates.Id);
			}
			API_v1_Media_Request.Types.GetThumbnail getThumbnail = request.GetThumbnail;
			if (getThumbnail != null)
			{
				return GetThumbnail(service.VisualPlaylists, getThumbnail.Uuid.ToGuid(), getThumbnail.Quality);
			}
			if (request.PlaylistFocused != null)
			{
				return GetPlaylistFocused();
			}
			if (request.PlaylistActive != null)
			{
				return GetPlaylistActive();
			}
			API_v1_Media_Request.Types.FocusMessage focus = request.Focus;
			if (focus != null)
			{
				return HandleFocus(service, focus);
			}
			API_v1_Media_Request.Types.TriggerMessage trigger = request.Trigger;
			if (trigger != null)
			{
				return HandleTrigger(service, trigger);
			}
		}
		return null;
	}

	private static NetworkAPI_v1? HandleFocus(IAPIv1Service service, API_v1_Media_Request.Types.FocusMessage request)
	{
		if (request != null)
		{
			if (request.Next != null)
			{
				return FocusNextPlaylist(service);
			}
			if (request.Previous != null)
			{
				return FocusPreviousPlaylist(service);
			}
			if (request.Active != null)
			{
				return FocusActivePlaylist(service);
			}
			string id = request.Id;
			if (id != null)
			{
				return FocusPlaylistID(service, id);
			}
		}
		return null;
	}

	private static NetworkAPI_v1? HandleTrigger(IAPIv1Service service, API_v1_Media_Request.Types.TriggerMessage r)
	{
		API_v1_Media_Request.Types.TriggerMessage.PlaylistOneofCase playlistCase = r.PlaylistCase;
		API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase itemCase = r.ItemCase;
		switch (playlistCase)
		{
		case API_v1_Media_Request.Types.TriggerMessage.PlaylistOneofCase.Focused:
			switch (itemCase)
			{
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Start:
				return TriggerFocusedPlaylist(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Next:
				return TriggerNextFocused(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Previous:
				return TriggerPreviousFocused(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.MediaId:
				return TriggerFocusedItemID(service, r.MediaId);
			}
			break;
		case API_v1_Media_Request.Types.TriggerMessage.PlaylistOneofCase.Active:
			switch (itemCase)
			{
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Start:
				return TriggerActivePlaylist(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Next:
				return TriggerNextActive(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Previous:
				return TriggerPreviousActive(service);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.MediaId:
				return TriggerActiveItemID(service, r.MediaId);
			}
			break;
		case API_v1_Media_Request.Types.TriggerMessage.PlaylistOneofCase.PlaylistId:
			switch (itemCase)
			{
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Start:
				return TriggerPlaylistID(service, r.PlaylistId);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Next:
				return TriggerNextItemInPlaylistWithID(service, r.PlaylistId);
			case API_v1_Media_Request.Types.TriggerMessage.ItemOneofCase.Previous:
				return TriggerPreviousItemInPlaylistWithID(service, r.PlaylistId);
			}
			break;
		}
		return null;
	}

	internal static NetworkAPI_v1 PlaylistUpdate(Guid id, string name, uint index)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction($"/v1/media/playlist/{id}/updates").MediaResponse().GetPlaylistUpdates = new API_v1_Media_Response.Types.GetPlaylistUpdates
			{
				Id = Common.ID(id, name, index)
			};
		});
	}

	private static NetworkAPI_v1 GetPlaylistUpdates(VisualPlaylistCollection visualPlaylists, string idPath)
	{
		return Common.TryFindPlaylistAndDo(visualPlaylists, idPath, (Playlist<MediaCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction($"/v1/media/playlist/{playlist.ID}/updates");
		}));
	}

	private static NetworkAPI_v1 GetPlaylists(IEnumerable<IPlaylist<MediaCue>> visualPlaylists)
	{
		return UpdatePlaylists(visualPlaylists);
	}

	internal static NetworkAPI_v1 UpdatePlaylists(IEnumerable<IPlaylist<MediaCue>> visualPlaylists)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/media/playlists").MediaResponse().Playlists(Common.GetPlaylists(visualPlaylists));
		});
	}

	private static NetworkAPI_v1 GetPlaylist(VisualPlaylistCollection visualPlaylists, string idPath, int start)
	{
		return Common.TryFindPlaylistAndDo(visualPlaylists, idPath, (Playlist<MediaCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MediaResponse().Playlist(Common.MediaPlaylistResponseProto(playlist, start, visualPlaylists));
		}));
	}

	private static NetworkAPI_v1 GetThumbnail(IEnumerable<IPlaylist<MediaCue>> visualPlaylists, Guid id, int quality)
	{
		if (visualPlaylists.TryFindPlaylistItem((MediaCue c) => c.ID == id, out MediaCue cue))
		{
			MediaAction mediaAction = cue?.MediaAction;
			if (mediaAction != null)
			{
				try
				{
					return response(new BitmapImage(new Uri(mediaAction.VisualMedia?.SourceFile.FullPath ?? string.Empty)));
				}
				catch
				{
					if (mediaAction.VisualMedia?.Drawing.PreviewImage != null)
					{
						return response(mediaAction.VisualMedia.Drawing.PreviewImage);
					}
					BitmapSource bitmapSource = (mediaAction.Media as IDrawMedia)?.Drawing?.PreviewImage;
					if (bitmapSource != null)
					{
						return response(bitmapSource);
					}
				}
			}
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
		NetworkAPI_v1 response(BitmapSource fullSizeBitmap)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().GetThumbnail = new API_v1_Media_Response.Types.GetThumbnail
				{
					ThumbnailData = fullSizeBitmap.ScaleBitmap(quality)
				};
			});
		}
	}

	private static API_v1_Media_Response MediaResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.MediaResponse ?? (action.MediaResponse = new API_v1_Media_Response());
	}

	private static API_v1_Media_Response.Types.Playlists Playlists(this API_v1_Media_Response response, IEnumerable<API_v1_Playlist> playlists)
	{
		API_v1_Media_Response.Types.Playlists obj = new API_v1_Media_Response.Types.Playlists
		{
			Playlists_ = { playlists }
		};
		API_v1_Media_Response.Types.Playlists result = obj;
		response.Playlists = obj;
		return result;
	}

	private static void Playlist(this API_v1_Media_Response response, Common.ProtoMediaPlaylistResponse proto)
	{
		response.GetPlaylist = new API_v1_Media_Response.Types.GetPlaylist
		{
			Id = proto.ID,
			Items = { proto.Items }
		};
	}

	private static NetworkAPI_v1 GetPlaylistFocused()
	{
		API_v1_Media_Response.Types.GetFocusedPlaylist current = null;
		VisualPlaylistFocusedProtoRequest.Publish(delegate(API_v1_Media_Response.Types.GetFocusedPlaylist v)
		{
			current = v;
		});
		return FocusedPlaylistUpdated(current);
	}

	internal static NetworkAPI_v1 FocusedPlaylistUpdated(API_v1_Media_Response.Types.GetFocusedPlaylist? focused)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/media/playlist/focused").MediaResponse().PlaylistFocused = focused;
		});
	}

	private static NetworkAPI_v1 GetPlaylistActive()
	{
		API_v1_Media_Response.Types.GetActivePlaylist current = null;
		VisualPlaylistActiveProtoRequest.Publish(delegate(API_v1_Media_Response.Types.GetActivePlaylist v)
		{
			current = v;
		});
		return ActivePlaylistUpdated(current);
	}

	internal static NetworkAPI_v1 ActivePlaylistUpdated(API_v1_Media_Response.Types.GetActivePlaylist? active)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/media/playlist/active").MediaResponse().PlaylistActive = active;
		});
	}

	private static NetworkAPI_v1 FocusNextPlaylist(IAPIv1Service service)
	{
		if (service.VisualPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		service.Triggering.ActiveVisualPlaylist = Common.GetProximalPlaylist(service.Triggering.ActiveVisualPlaylist, service.VisualPlaylists, 1);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MediaResponse().Focus = new API_v1_Media_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusPreviousPlaylist(IAPIv1Service service)
	{
		if (service.VisualPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		service.Triggering.ActiveVisualPlaylist = Common.GetProximalPlaylist(service.Triggering.ActiveVisualPlaylist, service.VisualPlaylists, -1);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MediaResponse().Focus = new API_v1_Media_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusActivePlaylist(IAPIv1Service service)
	{
		VisualPlaylist activePlaylist = GetActivePlaylist();
		if (activePlaylist != null)
		{
			service.Triggering.ActiveVisualPlaylist = activePlaylist;
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MediaResponse().Focus = new API_v1_Media_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusPlaylistID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.VisualPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.ActiveVisualPlaylist = playlist as VisualPlaylist;
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Focus = new API_v1_Media_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static NetworkAPI_v1 TriggerFocusedPlaylist(IAPIv1Service service)
	{
		return TriggerFirstItemInPlaylist(service, service.Triggering.ActiveVisualPlaylist);
	}

	private static NetworkAPI_v1 TriggerActivePlaylist(IAPIv1Service service)
	{
		return TriggerFirstItemInPlaylist(service, GetActivePlaylist());
	}

	private static VisualPlaylist? GetActivePlaylist()
	{
		VisualPlaylist activePlaylist = null;
		VisualPlaylistActiveRequest.Publish(delegate(Playlist<MediaCue> v)
		{
			activePlaylist = v as VisualPlaylist;
		});
		return activePlaylist;
	}

	private static NetworkAPI_v1 TriggerFirstItemInPlaylist(IAPIv1Service service, VisualPlaylist? p)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, p, "0", delegate(MediaCue firstItem, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerBackground(firstItem, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerPlaylistID(IAPIv1Service service, string idPath)
	{
		return Common.TriggerPlaylistID(service.Triggering, service.VisualPlaylists, idPath, delegate(MediaCue item, VisualPlaylist playlist)
		{
			service.Triggering.TriggerBackground(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerNextFocused(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, service.Triggering.ActiveVisualPlaylist, delegate(VisualPlaylist activePlaylist)
		{
			service.Triggering.TriggerNextBackground(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerPreviousFocused(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, service.Triggering.ActiveVisualPlaylist, delegate(VisualPlaylist activePlaylist)
		{
			service.Triggering.TriggerPreviousBackground(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerFocusedItemID(IAPIv1Service service, string id)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, service.Triggering.ActiveVisualPlaylist, id, delegate(MediaCue item, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerBackground(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerNextActive(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, GetActivePlaylist(), delegate(VisualPlaylist activePlaylist)
		{
			service.Triggering.TriggerNextBackground(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerPreviousActive(IAPIv1Service service)
	{
		return Common.TriggerProximal(service.Triggering, GetActivePlaylist(), delegate(VisualPlaylist activePlaylist)
		{
			service.Triggering.TriggerPreviousBackground(activePlaylist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerActiveItemID(IAPIv1Service service, string id)
	{
		return Common.TriggerPlaylistItemID(service.Triggering, GetActivePlaylist(), id, delegate(MediaCue item, Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerBackground(item, playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		});
	}

	private static NetworkAPI_v1 TriggerNextItemInPlaylistWithID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.VisualPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerNextBackground((VisualPlaylist)playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static NetworkAPI_v1 TriggerPreviousItemInPlaylistWithID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.VisualPlaylists, idPath, delegate(Playlist<MediaCue> playlist)
		{
			service.Triggering.TriggerPreviousBackground((VisualPlaylist)playlist);
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().MediaResponse().Trigger = new API_v1_Media_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	internal static API_v1_Media_Response.Types.GetFocusedPlaylist CreateFocusedPlaylistProto(API_v1_Identifier? playlistID, API_v1_Identifier? _1, API_v1_PlaylistItem? _2)
	{
		return new API_v1_Media_Response.Types.GetFocusedPlaylist
		{
			Id = playlistID
		};
	}

	internal static API_v1_Media_Response.Types.GetActivePlaylist CreateActivePlaylistProto(API_v1_Identifier? playlistID, API_v1_Identifier? itemID)
	{
		return new API_v1_Media_Response.Types.GetActivePlaylist
		{
			Playlist = playlistID,
			Item = itemID
		};
	}

	internal static bool FocusedPlaylistProtoEqual(API_v1_Media_Response.Types.GetFocusedPlaylist a, API_v1_Media_Response.Types.GetFocusedPlaylist b)
	{
		return a.NullableEquals<API_v1_Media_Response.Types.GetFocusedPlaylist>(b);
	}

	internal static bool ActivePlaylistProtoEqual(API_v1_Media_Response.Types.GetActivePlaylist a, API_v1_Media_Response.Types.GetActivePlaylist b)
	{
		return a.NullableEquals<API_v1_Media_Response.Types.GetActivePlaylist>(b);
	}
}
