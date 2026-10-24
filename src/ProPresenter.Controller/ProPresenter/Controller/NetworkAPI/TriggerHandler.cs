using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.NetworkAPI;

public static class TriggerHandler
{
	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Trigger_Request request)
	{
		return service.Dependencies.UiDispatcher.Invoke(delegate
		{
			if (request != null)
			{
				API_v1_Trigger_Request.Types.Cue cue = request.Cue;
				if (cue != null)
				{
					return TriggerCue(service.Triggering, cue.Index);
				}
				API_v1_Trigger_Request.Types.Playlist playlist = request.Playlist;
				if (playlist != null)
				{
					return TriggerPlaylist(service.LibraryPlaylists, service.Triggering, service.LibraryPlaylistNonFocusedIndexTracker, playlist.Id);
				}
				API_v1_Trigger_Request.Types.Media media = request.Media;
				if (media != null)
				{
					return TriggerMedia(service.VisualPlaylists, service.Triggering, media.Id);
				}
				if (request.MediaNext != null)
				{
					return TriggerMediaNext(service.Triggering);
				}
				if (request.MediaPrevious != null)
				{
					return TriggerMediaPrevious(service.Triggering);
				}
				API_v1_Trigger_Request.Types.Audio audio = request.Audio;
				if (audio != null)
				{
					return TriggerAudio(service.AudioPlaylists, service.Triggering, audio.Id);
				}
				if (request.AudioNext != null)
				{
					return TriggerAudioNext(service.Triggering);
				}
				if (request.AudioPrevious != null)
				{
					return TriggerAudioPrevious(service.Triggering);
				}
				API_v1_Trigger_Request.Types.VideoInput videoInput = request.VideoInput;
				if (videoInput != null)
				{
					return TriggerVideoInput(service.LiveVideoPlaylist, service.Triggering, videoInput.Id);
				}
				API_v1_Trigger_Request.Types.Library library = request.Library;
				if (library != null)
				{
					return TriggerLibrary(service.Libraries, service.Triggering, library.Id);
				}
				if (request.Next != null)
				{
					return TriggerNext(service.Triggering);
				}
				if (request.Previous != null)
				{
					return TriggerPrevious(service.Triggering);
				}
			}
			global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
			NetworkAPI_v1 result = default(NetworkAPI_v1);
			return result;
		});
	}

	private static NetworkAPI_v1 TriggerCue(ITriggering triggering, uint cueIndex)
	{
		if (triggering.ActivePlaylistItem is IDocumentCue documentCue)
		{
			if (documentCue.DocumentAction == null)
			{
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().InternalError();
				});
			}
			documentCue.DocumentAction.Presentation?.EnsureLoaded();
			IPresentation? presentation = documentCue.DocumentAction.Presentation;
			if (presentation == null || !presentation.IsAvailable)
			{
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().Unauthorized();
				});
			}
			ArrangedCue arrangedCue = documentCue.DocumentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault((int)cueIndex);
			if (arrangedCue != null)
			{
				triggering.TriggerSlide(arrangedCue);
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().TriggerResponse().Cue = new API_v1_Trigger_Response.Types.Cue();
				});
			}
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	internal static NetworkAPI_v1 TriggerPlaylist(IEnumerable<IPlaylist<ProPresenterCue>> playlists, ITriggering triggering, PlaylistItemIndexTracker nonFocusedIndexTracker, string idPath, bool updateActive = false)
	{
		if (playlists == null || triggering == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!Common.TryFindPlaylistFromIDPath(ref identifiers, playlists, out IPlaylist<ProPresenterCue> playlist) || !Common.TryFindPlaylistItem(ref identifiers, playlist, out ProPresenterCue item))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		if (updateActive)
		{
			triggering.ActiveLibraryPlaylist = playlist as Playlist<ProPresenterCue>;
		}
		return TriggerItemInPlaylist(item, (Playlist<ProPresenterCue>)playlist, identifiers, triggering, nonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().Playlist = new API_v1_Trigger_Response.Types.Playlist();
		}), updateActive);
	}

	internal static NetworkAPI_v1 TriggerItemInPlaylist(ProPresenterCue item, Playlist<ProPresenterCue> playlist, IEnumerable<string> identifiers, ITriggering triggering, PlaylistItemIndexTracker nonFocusedIndexTracker, NetworkAPI_v1 successResponse, bool updateActive = false)
	{
		if (updateActive)
		{
			triggering.ActivePlaylistItem = item;
		}
		else
		{
			nonFocusedIndexTracker?.Update(item, playlist);
		}
		int num = identifiers.Count();
		IDocumentAction documentAction2;
		HeaderAction headerAction2;
		if (item is IMediaCue mediaCue)
		{
			MediaAction mediaAction2 = mediaCue.MediaAction;
			if (mediaAction2 != null)
			{
				if (num != 1)
				{
					if (item is IDocumentCue documentCue)
					{
						documentAction2 = documentCue.DocumentAction;
						if (documentAction2 == null)
						{
							goto IL_017f;
						}
					}
					goto IL_00f4;
				}
				return triggerMedia(mediaAction2);
			}
			if (item is IDocumentCue documentCue2)
			{
				documentAction2 = documentCue2.DocumentAction;
				if (documentAction2 != null)
				{
					if (num == 1)
					{
						goto IL_0169;
					}
					goto IL_017f;
				}
			}
		}
		else
		{
			if (!(item is IDocumentCue documentCue3))
			{
				if (item is IHeaderCue headerCue)
				{
					headerAction2 = headerCue.HeaderAction;
					if (headerAction2 == null)
					{
						goto IL_017f;
					}
					if (num == 1)
					{
						goto IL_0174;
					}
				}
				goto IL_01a7;
			}
			documentAction2 = documentCue3.DocumentAction;
			if (documentAction2 != null)
			{
				if (num != 1)
				{
					goto IL_00f4;
				}
				goto IL_0169;
			}
		}
		if (item is IHeaderCue headerCue2)
		{
			headerAction2 = headerCue2.HeaderAction;
			if (headerAction2 != null && num == 1)
			{
				goto IL_0174;
			}
		}
		goto IL_017f;
		IL_01a7:
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
		IL_0174:
		return triggerHeader(headerAction2);
		IL_017f:
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().BadRequest();
		});
		IL_00f4:
		if (item is IHeaderCue headerCue3)
		{
			headerAction2 = headerCue3.HeaderAction;
			if (headerAction2 == null)
			{
				goto IL_017f;
			}
		}
		goto IL_01a7;
		IL_0169:
		return triggerPresentation(documentAction2);
		NetworkAPI_v1 triggerHeader(HeaderAction headerAction)
		{
			triggering.TriggerHeader(headerAction);
			return successResponse;
		}
		NetworkAPI_v1 triggerMedia(MediaAction mediaAction)
		{
			triggering.TriggerBackground(new MediaCue(mediaAction), playlist, CueLocation.Presentation);
			return successResponse;
		}
		NetworkAPI_v1 triggerPresentation(IDocumentAction documentAction)
		{
			documentAction.Presentation?.EnsureLoaded();
			IPresentation? presentation = documentAction.Presentation;
			if (presentation == null || !presentation.IsAvailable)
			{
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().Unauthorized();
				});
			}
			int result;
			ArrangedCue arrangedCue = ((!int.TryParse(identifiers.Last(), out result)) ? documentAction.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source.Name == identifiers.Last()) : documentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault(result));
			if (arrangedCue != null)
			{
				triggering.TriggerSlide(arrangedCue, new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, item, playlist));
				return successResponse;
			}
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
	}

	private static NetworkAPI_v1 TriggerMedia(IEnumerable<IPlaylist<MediaCue>> visualPlaylists, ITriggering triggering, string idPath, bool updateActive = false)
	{
		if (visualPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!Common.TryFindPlaylistFromIDPath(ref identifiers, visualPlaylists, out IPlaylist<MediaCue> playlist) || !Common.TryFindPlaylistItem(ref identifiers, playlist, out MediaCue item) || !identifiers.Empty())
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		if (!(playlist is VisualPlaylist visualPlaylist))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerBackground(item, visualPlaylist);
		if (updateActive)
		{
			triggering.ActiveVisualPlaylist = visualPlaylist;
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().Media = new API_v1_Trigger_Response.Types.Media();
		});
	}

	private static NetworkAPI_v1 TriggerMediaNext(ITriggering triggering)
	{
		if (triggering.ActiveVisualPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerNextBackground(triggering.ActiveVisualPlaylist);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().MediaNext = new API_v1_Trigger_Response.Types.MediaNext();
		});
	}

	private static NetworkAPI_v1 TriggerMediaPrevious(ITriggering triggering)
	{
		if (triggering.ActiveVisualPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerPreviousBackground(triggering.ActiveVisualPlaylist);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().MediaPrevious = new API_v1_Trigger_Response.Types.MediaPrevious();
		});
	}

	private static NetworkAPI_v1 TriggerAudio(IEnumerable<IPlaylist<MediaCue>> audioPlaylists, ITriggering triggering, string idPath, bool updateActive = false)
	{
		if (audioPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!Common.TryFindPlaylistFromIDPath(ref identifiers, audioPlaylists, out IPlaylist<MediaCue> playlist) || !Common.TryFindPlaylistItem(ref identifiers, playlist, out MediaCue item) || !identifiers.Empty())
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		if (!(playlist is AudioPlaylist audioPlaylist))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerAudio(item, audioPlaylist);
		if (updateActive)
		{
			triggering.ActiveAudioPlaylist = audioPlaylist;
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().Audio = new API_v1_Trigger_Response.Types.Audio();
		});
	}

	private static NetworkAPI_v1 TriggerAudioNext(ITriggering triggering)
	{
		if (triggering.ActiveAudioPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerNextAudio(triggering.ActiveAudioPlaylist);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().AudioNext = new API_v1_Trigger_Response.Types.AudioNext();
		});
	}

	private static NetworkAPI_v1 TriggerAudioPrevious(ITriggering triggering)
	{
		if (triggering.ActiveAudioPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		triggering.TriggerPreviousAudio(triggering.ActiveAudioPlaylist);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().MediaPrevious = new API_v1_Trigger_Response.Types.MediaPrevious();
		});
	}

	private static NetworkAPI_v1 TriggerVideoInput(ProPresenter.DO.Playlists.LiveVideoPlaylist liveVideoPlaylist, ITriggering triggering, string stringID, bool updateActive = false)
	{
		if (liveVideoPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		if (Common.TryFindItem(liveVideoPlaylist, stringID, out ItemPacket<MediaCue> packet))
		{
			triggering.TriggerBackground(packet.Item, liveVideoPlaylist);
			if (updateActive)
			{
				triggering.ActiveVisualPlaylist = liveVideoPlaylist;
			}
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().TriggerResponse().VideoInput = new API_v1_Trigger_Response.Types.VideoInput();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 TriggerLibrary(LibraryCollection libraries, ITriggering triggering, string idPath, bool updateActive = false)
	{
		if (libraries == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (identifiers.Count() != 3)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		if (!Common.TryFindItem(libraries, identifiers.ElementAt(0), out ItemPacket<ILibrary> packet))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		ILibrary item = packet.Item;
		if (!Common.TryFindItem(item, identifiers.ElementAt(1), out ItemPacket<DocumentCue> packet2))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		DocumentCue item2 = packet2.Item;
		if (item2.DocumentAction == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		item2.DocumentAction.Presentation?.EnsureLoaded();
		IPresentation? presentation = item2.DocumentAction.Presentation;
		if (presentation == null || !presentation.IsAvailable)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().Unauthorized();
			});
		}
		int result;
		ArrangedCue arrangedCue = ((!int.TryParse(identifiers.ElementAt(2), out result)) ? item2.DocumentAction.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source.Name == identifiers.Last()) : item2.DocumentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault(result));
		if (arrangedCue != null)
		{
			triggering.TriggerSlide(arrangedCue, new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, item2));
			if (updateActive)
			{
				triggering.ActiveLibrary = item;
				triggering.ActivePlaylistItem = item2;
			}
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().TriggerResponse().Library = new API_v1_Trigger_Response.Types.Library();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 TriggerNext(ITriggering triggering)
	{
		triggering.TriggerNextSlide();
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().Next = new API_v1_Trigger_Response.Types.Next();
		});
	}

	private static NetworkAPI_v1 TriggerPrevious(ITriggering triggering)
	{
		triggering.TriggerPreviousSlide();
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TriggerResponse().Previous = new API_v1_Trigger_Response.Types.Previous();
		});
	}

	private static API_v1_Trigger_Response TriggerResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.TriggerResponse ?? (action.TriggerResponse = new API_v1_Trigger_Response());
	}

	public static IEnumerable<string> ParseIdentifiers(this IEnumerable<API_v1_Identifier> identifiers)
	{
		return identifiers.Select((API_v1_Identifier i) => i.ParseIdentifier()).NonNull();
	}

	public static string ParseIdentifier(this API_v1_Identifier identifier)
	{
		if (string.IsNullOrEmpty(identifier.Name))
		{
			return identifier.Index.ToString();
		}
		return identifier.Name;
	}
}
