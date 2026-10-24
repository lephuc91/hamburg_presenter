using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Import;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.NetworkAPI;

public static class LibraryPlaylistHandler
{
	[CompilerGenerated]
	private sealed class _003CToPlaylistItems_003Ed__16 : IEnumerable<API_v1_PlaylistItem>, IEnumerable, IEnumerator<API_v1_PlaylistItem>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_PlaylistItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Playlist<ProPresenterCue> playlist;

		public Playlist<ProPresenterCue> _003C_003E3__playlist;

		private IEnumerator<ProPresenterCue> _003C_003E7__wrap1;

		API_v1_PlaylistItem IEnumerator<API_v1_PlaylistItem>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CToPlaylistItems_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = playlist.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					ProPresenterCue current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current.ToPlaylistItem(playlist);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<API_v1_PlaylistItem> IEnumerable<API_v1_PlaylistItem>.GetEnumerator()
		{
			_003CToPlaylistItems_003Ed__16 _003CToPlaylistItems_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToPlaylistItems_003Ed__ = this;
			}
			else
			{
				_003CToPlaylistItems_003Ed__ = new _003CToPlaylistItems_003Ed__16(0);
			}
			_003CToPlaylistItems_003Ed__.playlist = _003C_003E3__playlist;
			return _003CToPlaylistItems_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_PlaylistItem>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CToPlaylists_003Ed__11 : IEnumerable<API_v1_Playlist>, IEnumerable, IEnumerator<API_v1_Playlist>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_Playlist _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<IPlaylist<ProPresenterCue>> playlists;

		public IEnumerable<IPlaylist<ProPresenterCue>> _003C_003E3__playlists;

		private IEnumerator<IPlaylist<ProPresenterCue>> _003C_003E7__wrap1;

		API_v1_Playlist IEnumerator<API_v1_Playlist>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CToPlaylists_003Ed__11(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = playlists.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					IPlaylist<ProPresenterCue> current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current.ToPlaylist((uint)playlists.IndexOf<IPlaylist<ProPresenterCue>>(current));
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<API_v1_Playlist> IEnumerable<API_v1_Playlist>.GetEnumerator()
		{
			_003CToPlaylists_003Ed__11 _003CToPlaylists_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToPlaylists_003Ed__ = this;
			}
			else
			{
				_003CToPlaylists_003Ed__ = new _003CToPlaylists_003Ed__11(0);
			}
			_003CToPlaylists_003Ed__.playlists = _003C_003E3__playlists;
			return _003CToPlaylists_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Playlist>)this).GetEnumerator();
		}
	}

	public static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Playlist_Request request)
	{
		if (request != null)
		{
			if (request.Playlists != null)
			{
				return Playlists(service);
			}
			API_v1_Playlist_Request.Types.CreatePlaylist createPlaylist = request.CreatePlaylist;
			if (createPlaylist != null)
			{
				return CreatePlaylist(service, createPlaylist);
			}
			API_v1_Playlist_Request.Types.GetPlaylist getPlaylist = request.GetPlaylist;
			if (getPlaylist != null)
			{
				return GetPlaylist(service, getPlaylist);
			}
			API_v1_Playlist_Request.Types.IdMessage idUpdates = request.IdUpdates;
			if (idUpdates != null)
			{
				return GetPlaylistUpdates(service.LibraryPlaylists, idUpdates.Id);
			}
			API_v1_Playlist_Request.Types.PutPlaylist putPlaylist = request.PutPlaylist;
			if (putPlaylist != null)
			{
				return UpdatePlaylist(service, putPlaylist);
			}
			API_v1_Playlist_Request.Types.PostPlaylist postPlaylist = request.PostPlaylist;
			if (postPlaylist != null)
			{
				return CreatePlaylist(service, postPlaylist);
			}
			if (request.Focused != null)
			{
				return GetPlaylistFocused(service);
			}
			if (request.NextFocus != null)
			{
				return FocusNextPlaylist(service);
			}
			if (request.PreviousFocus != null)
			{
				return FocusPreviousPlaylist(service);
			}
			if (request.ActivePresentationFocus != null)
			{
				return FocusActivePresentationPlaylist(service.Triggering);
			}
			if (request.ActiveAnnouncementFocus != null)
			{
				return FocusActiveAnnouncementPlaylist(service.Triggering);
			}
			API_v1_Playlist_Request.Types.IdMessage idFocus = request.IdFocus;
			if (idFocus != null)
			{
				return FocusPlaylistID(service, idFocus.Id);
			}
			if (request.FocusedTrigger != null)
			{
				return TriggerFocusedPlaylist(service);
			}
			if (request.ActivePresentationTrigger != null)
			{
				return TriggerActivePresentationPlaylist(service);
			}
			if (request.ActiveAnnouncementTrigger != null)
			{
				return TriggerActiveAnnouncementPlaylist(service);
			}
			if (request.FocusedNext != null)
			{
				return GetFocusedNextItem(service);
			}
			if (request.FocusedPrevious != null)
			{
				return GetFocusedPreviousItem(service);
			}
			if (request.FocusedNextTrigger != null)
			{
				return TriggerNextFocused(service);
			}
			if (request.FocusedPreviousTrigger != null)
			{
				return TriggerPreviousFocused(service);
			}
			API_v1_Playlist_Request.Types.IdMessage idTrigger = request.IdTrigger;
			if (idTrigger != null)
			{
				return TriggerPlaylistID(service, idTrigger.Id);
			}
			API_v1_Playlist_Request.Types.IdMessage idNextTrigger = request.IdNextTrigger;
			if (idNextTrigger != null)
			{
				return TriggerNextPlaylistID(service, idNextTrigger.Id);
			}
			API_v1_Playlist_Request.Types.IdMessage idPreviousTrigger = request.IdPreviousTrigger;
			if (idPreviousTrigger != null)
			{
				return TriggerPreviousPlaylistID(service, idPreviousTrigger.Id);
			}
			API_v1_Playlist_Request.Types.IdThumbnail idThumbnail = request.IdThumbnail;
			if (idThumbnail != null)
			{
				return HandlePlaylistItemThumbnail(service, idThumbnail);
			}
			API_v1_Playlist_Request.Types.IndexMessage focusedIndexTrigger = request.FocusedIndexTrigger;
			if (focusedIndexTrigger != null)
			{
				return TriggerItemAtIndexInFocusedPlaylist(service, (int)focusedIndexTrigger.Index, (int)focusedIndexTrigger.CueIndex);
			}
			API_v1_Playlist_Request.Types.IndexMessage activePresentationIndexTrigger = request.ActivePresentationIndexTrigger;
			if (activePresentationIndexTrigger != null)
			{
				return TriggerItemAtIndexInActivePresentationPlaylist(service, (int)activePresentationIndexTrigger.Index, (int)activePresentationIndexTrigger.CueIndex);
			}
			API_v1_Playlist_Request.Types.IndexMessage activeAnnouncementIndexTrigger = request.ActiveAnnouncementIndexTrigger;
			if (activeAnnouncementIndexTrigger != null)
			{
				return TriggerItemAtIndexInActiveAnnouncementPlaylist(service, (int)activeAnnouncementIndexTrigger.Index, (int)activeAnnouncementIndexTrigger.CueIndex);
			}
			API_v1_Playlist_Request.Types.Thumbnail activePresentationThumbnail = request.ActivePresentationThumbnail;
			if (activePresentationThumbnail != null)
			{
				return HandleActivePresentationPlaylistItemThumbnail(service, activePresentationThumbnail);
			}
			API_v1_Playlist_Request.Types.Thumbnail activeAnnouncementThumbnail = request.ActiveAnnouncementThumbnail;
			if (activeAnnouncementThumbnail != null)
			{
				return HandleActiveAnnouncementPlaylistItemThumbnail(service, activeAnnouncementThumbnail);
			}
			API_v1_Playlist_Request.Types.TimelineOperation timelineOperation = request.TimelineOperation;
			if (timelineOperation != null)
			{
				return HandleTimelineOperation(service, timelineOperation);
			}
			API_v1_Playlist_Request.Types.ActivePlaylistTimelineOperation activePlaylistPresentationTimelineOperation = request.ActivePlaylistPresentationTimelineOperation;
			if (activePlaylistPresentationTimelineOperation != null)
			{
				return HandleActivePlaylistPresentationTimelineOperation(service, activePlaylistPresentationTimelineOperation.Index, activePlaylistPresentationTimelineOperation.Operation);
			}
			API_v1_Playlist_Request.Types.ActivePlaylistTimelineOperation activePlaylistAnnouncementTimelineOperation = request.ActivePlaylistAnnouncementTimelineOperation;
			if (activePlaylistAnnouncementTimelineOperation != null)
			{
				return HandleActivePlaylistAnnouncementTimelineOperation(service, activePlaylistAnnouncementTimelineOperation.Index, activePlaylistAnnouncementTimelineOperation.Operation);
			}
			API_v1_Playlist_Request.Types.FocusedPlaylistTimelineOperation focusedPlaylistTimelineOperation = request.FocusedPlaylistTimelineOperation;
			if (focusedPlaylistTimelineOperation != null)
			{
				return HandleFocusedPlaylistTimelineOperation(service, focusedPlaylistTimelineOperation.Index, focusedPlaylistTimelineOperation.Operation);
			}
			API_v1_Playlist_Request.Types.ActivePlaylistTimelineStatus activePlaylistPresentationTimelineStatus = request.ActivePlaylistPresentationTimelineStatus;
			if (activePlaylistPresentationTimelineStatus != null)
			{
				return HandleActivePlaylistPresentationTimelineStatus(service, activePlaylistPresentationTimelineStatus.Index);
			}
			API_v1_Playlist_Request.Types.ActivePlaylistTimelineStatus activePlaylistAnnouncementTimelineStatus = request.ActivePlaylistAnnouncementTimelineStatus;
			if (activePlaylistAnnouncementTimelineStatus != null)
			{
				return HandleActivePlaylistAnnouncementTimelineStatus(service, activePlaylistAnnouncementTimelineStatus.Index);
			}
			API_v1_Playlist_Request.Types.FocusedPlaylistTimelineStatus focusedPlaylistTimelineStatus = request.FocusedPlaylistTimelineStatus;
			if (focusedPlaylistTimelineStatus != null)
			{
				return HandleFocusedPlaylistTimelineStatus(service, focusedPlaylistTimelineStatus.Index);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 Playlists(IAPIv1Service service)
	{
		return UpdatePlaylists(service.LibraryPlaylists, service);
	}

	internal static NetworkAPI_v1 UpdatePlaylists(PlaylistCollectionBase<ProPresenterCue> playlists, IAPIv1Service service)
	{
		string identifier = "/v1/playlists";
		if (service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPlaylist))
		{
			identifier = "";
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction(identifier).PlaylistResponse().Playlists = new API_v1_Playlist_Response.Types.Playlists
			{
				Playlists_ = { playlists.Select((IPlaylist<ProPresenterCue> p) => p.ToPlaylist((uint)playlists.IndexOf(p))) }
			};
		});
	}

	private static NetworkAPI_v1 CreatePlaylist(IAPIv1Service service, API_v1_Playlist_Request.Types.CreatePlaylist create)
	{
		if (service?.LibraryPlaylists != null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				IPlaylist<ProPresenterCue> playlist = null;
				switch (create.Type)
				{
				case API_v1_Playlist.Types.API_v1_PlaylistType.Group:
					playlist = service.LibraryPlaylists.AddNewGroupPlaylist();
					playlist.Name = create.Name;
					break;
				case API_v1_Playlist.Types.API_v1_PlaylistType.Playlist:
					playlist = service.LibraryPlaylists.AddNewPlaylist(create.Name);
					break;
				default:
					v1.Action().NotFound();
					return;
				}
				int index = service.LibraryPlaylists.Count - 1;
				v1.Action().PlaylistResponse().CreatePlaylist = new API_v1_Playlist_Response.Types.CreatePlaylist
				{
					Playlist = new API_v1_Playlist
					{
						Id = new API_v1_Identifier
						{
							Name = playlist.Name,
							Uuid = playlist.ID.ToString(),
							Index = (uint)index
						},
						Type = create.Type
					}
				};
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().InternalError();
		});
	}

	private static NetworkAPI_v1 GetPlaylist(IAPIv1Service service, API_v1_Playlist_Request.Types.GetPlaylist getPlaylist)
	{
		return Common.TryFindPlaylistAndDo(service.LibraryPlaylists, getPlaylist.Id, (Playlist<ProPresenterCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().GetPlaylist = new API_v1_Playlist_Response.Types.GetPlaylist
			{
				Id = Common.ID(playlist.ID, playlist.Name, (uint)Common.PlaylistIndexInParent(playlist, service.LibraryPlaylists)),
				Items = { playlist.ToPlaylistItems() ?? Array.Empty<API_v1_PlaylistItem>() }
			};
		}));
	}

	private static NetworkAPI_v1 UpdatePlaylist(IAPIv1Service service, API_v1_Playlist_Request.Types.PutPlaylist put)
	{
		LibraryPlaylistCollection playlists = service.LibraryPlaylists;
		LibraryCollection libraries = service.Libraries;
		VisualPlaylistCollection mediaPlaylists = service.VisualPlaylists;
		AudioPlaylistCollection audioPlaylists = service.AudioPlaylists;
		ProPresenter.DO.Playlists.LiveVideoPlaylist liveVideoPlaylist = service.LiveVideoPlaylist;
		IApp app = service.Dependencies.App;
		IProPresenterResourceService resources = service.Dependencies.ProPresenterResourceService;
		ITransitionDescriptionCollection transitionDescriptions = service.Dependencies.TransitionDescriptions;
		if (playlists != null && libraries != null && mediaPlaylists != null && audioPlaylists != null && liveVideoPlaylist != null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				IReadOnlyCollection<IPlaylist<ProPresenterCue>> playlists2 = playlists.GetPlaylists();
				if (TryFindPlaylist(put.Id, playlists2, out ItemPacket<IPlaylist<ProPresenterCue>> playlist))
				{
					IPlaylist<ProPresenterCue> item = playlist.Item;
					if (item.Type == PlaylistType.Group)
					{
						v1.Action().NotFound();
					}
					else if (item is Playlist<ProPresenterCue> playlist2)
					{
						API_v1_Error_Response.Types.API_v1_Error_Type? aPI_v1_Error_Type = null;
						List<ProPresenterCue> list = new List<ProPresenterCue>();
						foreach (API_v1_PlaylistItem item2 in put.Items)
						{
							if (aPI_v1_Error_Type.HasValue)
							{
								break;
							}
							switch (item2.Type)
							{
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Presentation:
							{
								if (Common.TryFindItem(libraries.SelectMany((ILibrary l) => l), item2.Id, out ItemPacket<DocumentCue> packet2))
								{
									list.Add(packet2.Item);
								}
								else
								{
									aPI_v1_Error_Type = API_v1_Error_Response.Types.API_v1_Error_Type.NotFound;
								}
								break;
							}
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Placeholder:
							{
								IMediaFactory mediaFactory = service.Dependencies.FactoryProvider.MediaFactory;
								list.Add(new PlaceholderCue(app, resources, mediaFactory, transitionDescriptions)
								{
									Name = item2.Id.Name
								});
								break;
							}
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Header:
							{
								HeaderAction action = new HeaderAction
								{
									Name = item2.Id.Name,
									Color = item2.HeaderColor.ToColor()
								};
								list.Add(new HeaderCue(action)
								{
									Name = item2.Id.Name
								});
								break;
							}
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Media:
							{
								if (Common.TryFindItem(mediaPlaylists.GetPlaylists().OfType<VisualPlaylist>().SelectMany((VisualPlaylist p) => p), item2.Id, out ItemPacket<MediaCue> packet4))
								{
									list.Add(packet4.Item);
								}
								else
								{
									aPI_v1_Error_Type = API_v1_Error_Response.Types.API_v1_Error_Type.NotFound;
								}
								break;
							}
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Audio:
							{
								if (Common.TryFindItem(audioPlaylists.GetPlaylists().OfType<AudioPlaylist>().SelectMany((AudioPlaylist p) => p), item2.Id, out ItemPacket<MediaCue> packet3))
								{
									list.Add(packet3.Item);
								}
								else
								{
									aPI_v1_Error_Type = API_v1_Error_Response.Types.API_v1_Error_Type.NotFound;
								}
								break;
							}
							case API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Livevideo:
							{
								if (Common.TryFindItem(liveVideoPlaylist, item2.Id, out ItemPacket<MediaCue> packet))
								{
									list.Add(packet.Item);
								}
								else
								{
									aPI_v1_Error_Type = API_v1_Error_Response.Types.API_v1_Error_Type.NotFound;
								}
								break;
							}
							}
						}
						if (!aPI_v1_Error_Type.HasValue)
						{
							playlist2.RemoveItems(playlist2.ToArray());
							list.ForEach(playlist2.AddItem);
							v1.Action().PlaylistResponse().PutPlaylist = new API_v1_Playlist_Response.Types.PutPlaylist();
						}
						else
						{
							v1.Action().ErrorResponse(aPI_v1_Error_Type.Value);
						}
					}
				}
				else
				{
					v1.Action().NotFound();
				}
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().InternalError();
		});
	}

	private static NetworkAPI_v1 CreatePlaylist(IAPIv1Service service, API_v1_Playlist_Request.Types.PostPlaylist post)
	{
		if (service?.LibraryPlaylists != null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				IReadOnlyCollection<IPlaylist<ProPresenterCue>> playlists = service.LibraryPlaylists.GetPlaylists();
				IProPresenterResourceService proPresenterResourceService = service.Dependencies.ProPresenterResourceService;
				IImportProcessFactory importProcessFactory = service.Dependencies.ImportProcessFactory;
				ILogger logger = service.Dependencies.Logger;
				IProPresenterCueFactory cueFactory = service.Dependencies.CueFactory;
				if (TryFindPlaylist(post.Id, playlists, out ItemPacket<IPlaylist<ProPresenterCue>> playlist))
				{
					if (playlist.Item is GeneralGroupPlaylist generalGroupPlaylist)
					{
						IPlaylist<ProPresenterCue> playlist2 = null;
						switch (post.Type)
						{
						case API_v1_Playlist.Types.API_v1_PlaylistType.Group:
							playlist2 = new GeneralGroupPlaylist(proPresenterResourceService, importProcessFactory, logger, cueFactory, service.Dependencies.FactoryProvider.MediaFactory);
							break;
						case API_v1_Playlist.Types.API_v1_PlaylistType.Playlist:
							playlist2 = new GeneralPlaylist(logger, cueFactory, null, post.Name);
							break;
						default:
							v1.Action().NotFound();
							return;
						}
						playlist2.Name = post.Name;
						generalGroupPlaylist.AddChild(playlist2);
						int index = generalGroupPlaylist.Children.Count() - 1;
						v1.Action().PlaylistResponse().PostPlaylist = new API_v1_Playlist_Response.Types.PostPlaylist
						{
							Playlist = new API_v1_Playlist
							{
								Id = Common.ID(playlist2, (uint)index),
								Type = post.Type
							}
						};
					}
					else
					{
						v1.Action().NotFound();
					}
				}
				else
				{
					v1.Action().NotFound();
				}
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().InternalError();
		});
	}

	public static NetworkAPI_v1 PlaylistUpdate(Guid id, string name, uint index, IAPIv1Service service)
	{
		string identifier = $"/v1/playlist/{id}/updates";
		if (service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPlaylist))
		{
			identifier = "";
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction(identifier).PlaylistResponse().IdUpdates = new API_v1_Playlist_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 GetPlaylistUpdates(LibraryPlaylistCollection libraryPlaylists, string idPath)
	{
		return Common.TryFindPlaylistAndDo(libraryPlaylists, idPath, (Playlist<ProPresenterCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction($"/v1/playlist/{playlist.ID}/updates");
		}));
	}

	private static bool TryFindPlaylist(string path, IEnumerable<IPlaylist<ProPresenterCue>> playlists, [NotNullWhen(true)] out ItemPacket<IPlaylist<ProPresenterCue>>? playlist)
	{
		IEnumerable<string> identifiers = path.Split('/').ToArray();
		if (Common.TryFindNode(ref identifiers, playlists, out playlist))
		{
			return identifiers.Empty();
		}
		return false;
	}

	private static API_v1_Playlist ToPlaylist(this IPlaylist<ProPresenterCue> playlist, uint index)
	{
		API_v1_Playlist obj = new API_v1_Playlist
		{
			Id = Common.ID(playlist, index),
			Type = playlist.Type.ToPlaylistType()
		};
		RepeatedField<API_v1_Playlist> children = obj.Children;
		IEnumerable<API_v1_Playlist> values;
		if (!(playlist is GeneralGroupPlaylist generalGroupPlaylist))
		{
			IEnumerable<API_v1_Playlist> enumerable = Array.Empty<API_v1_Playlist>();
			values = enumerable;
		}
		else
		{
			values = generalGroupPlaylist.Children.ToPlaylists();
		}
		children.Add(values);
		return obj;
	}

	[IteratorStateMachine(typeof(_003CToPlaylists_003Ed__11))]
	private static IEnumerable<API_v1_Playlist> ToPlaylists(this IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToPlaylists_003Ed__11(-2)
		{
			_003C_003E3__playlists = playlists
		};
	}

	private static API_v1_Playlist_Response PlaylistResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.PlaylistResponse = new API_v1_Playlist_Response();
	}

	private static API_v1_Playlist.Types.API_v1_PlaylistType ToPlaylistType(this PlaylistType type)
	{
		return type switch
		{
			PlaylistType.Group => API_v1_Playlist.Types.API_v1_PlaylistType.Group, 
			PlaylistType.Custom => API_v1_Playlist.Types.API_v1_PlaylistType.Playlist, 
			PlaylistType.PCO => API_v1_Playlist.Types.API_v1_PlaylistType.Playlist, 
			_ => API_v1_Playlist.Types.API_v1_PlaylistType.Playlist, 
		};
	}

	private static API_v1_Presentation.Types.Destination ToPresentationDestination(this ProPresenterCue item)
	{
		if ((item as DocumentCue)?.DocumentAction.Destination != OutputDestination.Announcement)
		{
			return API_v1_Presentation.Types.Destination.Presentation;
		}
		return API_v1_Presentation.Types.Destination.Announcements;
	}

	internal static API_v1_PlaylistItem ToPlaylistItem<T>(this ProPresenterCue item, IPlaylist<T> containingPlaylist) where T : ProPresenterCue
	{
		API_v1_PlaylistItem aPI_v1_PlaylistItem = new API_v1_PlaylistItem
		{
			Id = Common.ID(getID(item), item.Name, (uint)containingPlaylist.IndexOf(item)),
			Type = getType(item),
			IsHidden = item.IsHidden,
			IsPco = (item.Type == CueType.PCO),
			HeaderColor = (item as IHeaderCue)?.HeaderAction.Color.ToProtoColor(),
			Duration = getDuration(item),
			TargetUuid = getTargetId(item).ToString(),
			Destination = item.ToPresentationDestination()
		};
		if (aPI_v1_PlaylistItem.Type == API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Presentation)
		{
			aPI_v1_PlaylistItem.PresentationInfo = new API_v1_PlaylistPresentationItem
			{
				PresentationUuid = ((item as IDocumentCue)?.DocumentAction?.Presentation?.ID.ToString() ?? string.Empty),
				ArrangementName = ((item as IDocumentCue)?.DocumentAction?.ActiveArrangementName ?? string.Empty),
				ArrangementUuid = ((item as IDocumentCue)?.DocumentAction?.ActiveArrangement?.ID.ToString() ?? string.Empty)
			};
		}
		return aPI_v1_PlaylistItem;
		static uint? getDuration(ProPresenterCue cue)
		{
			if (cue is IDocumentCue documentCue3)
			{
				return (uint?)documentCue3.DocumentAction?.DocumentLoopTime?.TotalSeconds;
			}
			if (cue is IMediaCue mediaCue3)
			{
				MediaAction mediaAction3 = mediaCue3.MediaAction;
				if (mediaAction3 != null && mediaAction3.HasDuration)
				{
					return (uint)mediaCue3.MediaAction.MediaDuration.TotalSeconds;
				}
			}
			return null;
		}
		static Guid getID(ProPresenterCue item)
		{
			if (!(item is IDocumentCue { ID: var iD }))
			{
				if (item is IMediaCue mediaCue)
				{
					MediaAction mediaAction = mediaCue.MediaAction;
					if (mediaAction != null)
					{
						MediaBase media = mediaAction.Media;
						if (media != null)
						{
							return media.ID;
						}
					}
				}
				return item.ID;
			}
			return iD;
		}
		static Guid getTargetId(ProPresenterCue cue)
		{
			IMediaCue mediaCue4;
			if (cue is IDocumentCue documentCue4)
			{
				if (documentCue4.DocumentAction != null)
				{
					return documentCue4.DocumentAction.Presentation?.ID ?? Guid.Empty;
				}
				mediaCue4 = cue as IMediaCue;
				if (mediaCue4 != null)
				{
					if (mediaCue4.MediaAction != null)
					{
						goto IL_0078;
					}
					if (cue is PlaceholderCue placeholderCue)
					{
						if (placeholderCue.DocumentAction != null)
						{
							return placeholderCue.DocumentAction.Presentation?.ID ?? Guid.Empty;
						}
						if (placeholderCue.MediaAction != null)
						{
							return placeholderCue.MediaAction.Media.ID;
						}
					}
				}
			}
			else
			{
				mediaCue4 = cue as IMediaCue;
				if (mediaCue4 != null && mediaCue4.MediaAction != null)
				{
					goto IL_0078;
				}
			}
			return Guid.Empty;
			IL_0078:
			return mediaCue4.MediaAction.Media.ID;
		}
		static API_v1_PlaylistItem.Types.API_v1_PlaylistItemType getType(ProPresenterCue cue)
		{
			if (cue is IDocumentCue { DocumentAction: not null })
			{
				return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Presentation;
			}
			if (cue is IHeaderCue { HeaderAction: not null })
			{
				return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Header;
			}
			if (cue is IMediaCue mediaCue2)
			{
				MediaAction mediaAction2 = mediaCue2.MediaAction;
				if (mediaAction2 != null)
				{
					if (mediaAction2.IsAudioMedia)
					{
						return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Audio;
					}
					if (mediaAction2.IsGraphicMedia)
					{
						return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Media;
					}
					if (mediaAction2.LiveVideo != null)
					{
						return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Livevideo;
					}
				}
			}
			return API_v1_PlaylistItem.Types.API_v1_PlaylistItemType.Placeholder;
		}
	}

	[IteratorStateMachine(typeof(_003CToPlaylistItems_003Ed__16))]
	private static IEnumerable<API_v1_PlaylistItem> ToPlaylistItems(this Playlist<ProPresenterCue> playlist)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToPlaylistItems_003Ed__16(-2)
		{
			_003C_003E3__playlist = playlist
		};
	}

	private static NetworkAPI_v1 GetPlaylistFocused(IAPIv1Service service)
	{
		API_v1_Playlist_Response.Types.GetFocusedPlaylist current = null;
		LibraryPlaylistFocusedProtoRequest.Publish(delegate(API_v1_Playlist_Response.Types.GetFocusedPlaylist v)
		{
			current = v;
		});
		return FocusedPlaylistUpdated(current, service);
	}

	internal static NetworkAPI_v1 FocusedPlaylistUpdated(API_v1_Playlist_Response.Types.GetFocusedPlaylist? focused, IAPIv1Service service)
	{
		string identifier = "/v1/playlist/focused";
		if (service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPlaylist))
		{
			identifier = "";
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction(identifier).PlaylistResponse().Focused = focused;
		});
	}

	internal static API_v1_Playlist_Response.Types.GetFocusedPlaylist CreateFocusedPlaylistProto(API_v1_Identifier? playlistID, API_v1_Identifier? itemID, API_v1_PlaylistItem? item)
	{
		return new API_v1_Playlist_Response.Types.GetFocusedPlaylist
		{
			Playlist = new API_v1_PlaylistAndItem
			{
				Playlist = playlistID,
				Item = itemID,
				PlaylistItem = item
			}
		};
	}

	internal static bool FocusedPlaylistProtoEqual(API_v1_Playlist_Response.Types.GetFocusedPlaylist a, API_v1_Playlist_Response.Types.GetFocusedPlaylist b)
	{
		return a.NullableEquals<API_v1_Playlist_Response.Types.GetFocusedPlaylist>(b);
	}

	private static NetworkAPI_v1 FocusNextPlaylist(IAPIv1Service s)
	{
		return FocusProximalPlaylist(s, 1, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().NextFocus = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 FocusPreviousPlaylist(IAPIv1Service s)
	{
		return FocusProximalPlaylist(s, -1, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().PreviousFocus = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 FocusProximalPlaylist(IAPIv1Service s, int inc, NetworkAPI_v1 successResponse)
	{
		if (s.LibraryPlaylists == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		s.Triggering.ActiveLibraryPlaylist = Common.GetProximalPlaylist(s.Triggering.ActiveLibraryPlaylist, s.LibraryPlaylists, inc);
		return successResponse;
	}

	private static NetworkAPI_v1 FocusActivePresentationPlaylist(ITriggering triggering)
	{
		return FocusActive(triggering, GetActivePresentationPlaylistAndItem(), Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActivePresentationFocus = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static (Playlist<ProPresenterCue>? playlist, ProPresenterCue? item) GetActivePresentationPlaylistAndItem()
	{
		(Playlist<ProPresenterCue>?, ProPresenterCue?) active = (null, null);
		LibraryPlaylistActivePresentationRequest.Publish(delegate(Playlist<ProPresenterCue>? p, ProPresenterCue? i)
		{
			active = (p, i);
		});
		return active;
	}

	private static NetworkAPI_v1 FocusActiveAnnouncementPlaylist(ITriggering triggering)
	{
		return FocusActive(triggering, GetActiveAnnouncementPlaylistAndItem(), Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActiveAnnouncementFocus = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 FocusActive(ITriggering triggering, (Playlist<ProPresenterCue>? playlist, ProPresenterCue? item) active, NetworkAPI_v1 successResponse)
	{
		if (triggering == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		if (active.playlist != null && active.item != null)
		{
			(triggering.ActiveLibraryPlaylist, triggering.ActivePlaylistItem) = active;
		}
		return successResponse;
	}

	private static (Playlist<ProPresenterCue>? playlist, ProPresenterCue? item) GetActiveAnnouncementPlaylistAndItem()
	{
		(Playlist<ProPresenterCue>?, ProPresenterCue?) active = (null, null);
		LibraryPlaylistActiveAnnouncementRequest.Publish(delegate(Playlist<ProPresenterCue>? p, ProPresenterCue? i)
		{
			active = (p, i);
		});
		return active;
	}

	private static NetworkAPI_v1 FocusPlaylistID(IAPIv1Service service, string idPath)
	{
		return Common.TryFindPlaylistAndDo(service.LibraryPlaylists, idPath, delegate(Playlist<ProPresenterCue> playlist)
		{
			service.Triggering.ActiveLibraryPlaylist = playlist;
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PlaylistResponse().IdFocus = new API_v1_Playlist_Response.Types.EmptyMessage();
			});
		}, service.Triggering);
	}

	private static NetworkAPI_v1 TriggerFocusedPlaylist(IAPIv1Service s)
	{
		return TriggerItemAtIndexInPlaylist(0, 0, s.Triggering.ActiveLibraryPlaylist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}), updateActive: true);
	}

	private static NetworkAPI_v1 TriggerActivePresentationPlaylist(IAPIv1Service s)
	{
		return TriggerItemAtIndexInPlaylist(0, 0, GetActivePresentationPlaylistAndItem().playlist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActivePresentationTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerActiveAnnouncementPlaylist(IAPIv1Service s)
	{
		return TriggerItemAtIndexInPlaylist(0, 0, GetActiveAnnouncementPlaylistAndItem().playlist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActiveAnnouncementTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerItemAtIndexInPlaylist(int itemIndex, int cueIndex, Playlist<ProPresenterCue>? playlist, ITriggering triggering, PlaylistItemIndexTracker indexTracker, NetworkAPI_v1 successResponse, bool updateActive = false)
	{
		return Common.TriggerPlaylistItemID(triggering, playlist, itemIndex.ToString(), (ProPresenterCue item, Playlist<ProPresenterCue> plist) => TriggerHandler.TriggerItemInPlaylist(item, plist, cueIndex.ToString().ToEnumerable(), triggering, indexTracker, successResponse, updateActive));
	}

	private static int GetProximalVisiblePlaylistItemIndex<T>(T? item, Playlist<T>? playlist, int inc) where T : ProPresenterCue
	{
		if (item != null && playlist != null)
		{
			return GetProximalVisiblePlaylistItemIndex(playlist.IndexOf(item), playlist, inc);
		}
		return -1;
	}

	internal static int GetProximalVisiblePlaylistItemIndex<T>(int startIndex, Playlist<T> playlist, int inc) where T : ProPresenterCue
	{
		if (playlist == null)
		{
			return -1;
		}
		int i;
		for (i = startIndex + inc; 0 <= i && i < playlist.Count(); i += inc)
		{
			T? val = playlist.ElementAtOrDefault(i);
			if (val != null && !val.IsHidden)
			{
				break;
			}
		}
		T? val2 = playlist.ElementAtOrDefault(i);
		if (val2 != null && !val2.IsHidden)
		{
			return i;
		}
		return playlist.IndexOf(playlist.FirstOrDefaultOf((ProPresenterCue x) => !x.IsHidden));
	}

	private static NetworkAPI_v1 GetFocusedNextItem(IAPIv1Service s)
	{
		int index = GetProximalVisiblePlaylistItemIndex(s.Triggering.ActivePlaylistItem, s.Triggering.ActiveLibraryPlaylist, 1);
		return Common.TriggerPlaylistItemID(s.Triggering, s.Triggering.ActiveLibraryPlaylist, index.ToString(), (ProPresenterCue item, Playlist<ProPresenterCue> playlist) => Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedNext = new API_v1_Playlist_Response.Types.GetProximalPlaylistItem
			{
				Item = Common.NullableID(item, (uint)index)
			};
		}));
	}

	private static NetworkAPI_v1 GetFocusedPreviousItem(IAPIv1Service s)
	{
		int index = GetProximalVisiblePlaylistItemIndex(s.Triggering.ActivePlaylistItem, s.Triggering.ActiveLibraryPlaylist, -1);
		return Common.TriggerPlaylistItemID(s.Triggering, s.Triggering.ActiveLibraryPlaylist, index.ToString(), (ProPresenterCue item, Playlist<ProPresenterCue> playlist) => Common.Build(delegate(NetworkAPI_v1 a)
		{
			a.Action().PlaylistResponse().FocusedPrevious = new API_v1_Playlist_Response.Types.GetProximalPlaylistItem
			{
				Item = Common.NullableID(item, (uint)index)
			};
		}));
	}

	private static NetworkAPI_v1 TriggerNextFocused(IAPIv1Service s)
	{
		return Common.TriggerProximal(s.Triggering, s.Triggering.ActiveLibraryPlaylist, (Playlist<ProPresenterCue> activePlaylist) => TriggerItemAtIndexInPlaylist(GetProximalVisiblePlaylistItemIndex(s.Triggering.ActivePlaylistItem, activePlaylist, 1), 0, activePlaylist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedNextTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}), updateActive: true));
	}

	private static NetworkAPI_v1 TriggerPreviousFocused(IAPIv1Service s)
	{
		return Common.TriggerProximal(s.Triggering, s.Triggering.ActiveLibraryPlaylist, (Playlist<ProPresenterCue> activePlaylist) => TriggerItemAtIndexInPlaylist(GetProximalVisiblePlaylistItemIndex(s.Triggering.ActivePlaylistItem, activePlaylist, -1), 0, activePlaylist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedPreviousTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}), updateActive: true));
	}

	private static NetworkAPI_v1 TriggerPlaylistID(IAPIv1Service s, string idPath)
	{
		return ParseLibraryPlaylistID(s.Triggering, s.LibraryPlaylists, idPath, (ProPresenterCue item, Playlist<ProPresenterCue> playlist, IEnumerable<string> ids) => TriggerHandler.TriggerItemInPlaylist(item, playlist, ids, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().IdTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		})));
	}

	private static NetworkAPI_v1 ParseLibraryPlaylistID<T>(ITriggering triggering, PlaylistCollectionBase<T> playlistCollection, string idPath, Func<T, Playlist<T>, IEnumerable<string>, NetworkAPI_v1> trigger) where T : ProPresenterCue
	{
		if (playlistCollection == null || triggering == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!Common.TryFindPlaylistFromIDPath(ref identifiers, playlistCollection, out IPlaylist<T> playlist) || !(playlist is Playlist<T> playlist2))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		Common.TryFindPlaylistItem(ref identifiers, playlist, out T item);
		if (item == null && identifiers.Empty())
		{
			item = playlist2.FirstOrDefault();
		}
		if (identifiers.Empty())
		{
			identifiers = "0".ToEnumerable();
		}
		if (item != null)
		{
			return trigger(item, playlist2, identifiers);
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 TriggerNextPlaylistID(IAPIv1Service s, string idPath)
	{
		return TriggerProximalPlaylistID(s, idPath, next: true);
	}

	private static NetworkAPI_v1 TriggerPreviousPlaylistID(IAPIv1Service s, string idPath)
	{
		return TriggerProximalPlaylistID(s, idPath, next: false);
	}

	private static NetworkAPI_v1 HandleActivePresentationPlaylistItemThumbnail(IAPIv1Service service, API_v1_Playlist_Request.Types.Thumbnail thumbnail)
	{
		Playlist<ProPresenterCue> item = GetActivePresentationPlaylistAndItem().playlist;
		(ByteString? data, API_v1_ContentType contentType)? result = HandleThumbnail(service, item, (int)thumbnail.Index, (int)thumbnail.CueIndex, thumbnail.Quality, thumbnail.ContentType);
		if (!result.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActivePresentationThumbnail = new API_v1_Playlist_Response.Types.Thumbnail
			{
				ContentType = result.Value.contentType,
				Data = result.Value.data
			};
		});
	}

	private static NetworkAPI_v1 HandleActiveAnnouncementPlaylistItemThumbnail(IAPIv1Service service, API_v1_Playlist_Request.Types.Thumbnail thumbnail)
	{
		Playlist<ProPresenterCue> item = GetActiveAnnouncementPlaylistAndItem().playlist;
		(ByteString? data, API_v1_ContentType contentType)? result = HandleThumbnail(service, item, (int)thumbnail.Index, (int)thumbnail.CueIndex, thumbnail.Quality, thumbnail.ContentType);
		if (!result.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActiveAnnouncementThumbnail = new API_v1_Playlist_Response.Types.Thumbnail
			{
				ContentType = result.Value.contentType,
				Data = result.Value.data
			};
		});
	}

	private static NetworkAPI_v1 HandlePlaylistItemThumbnail(IAPIv1Service service, API_v1_Playlist_Request.Types.IdThumbnail idMessage)
	{
		return Common.TryFindPlaylistAndDo(service.LibraryPlaylists, idMessage.Id, delegate(Playlist<ProPresenterCue> playlist)
		{
			(ByteString? data, API_v1_ContentType contentType)? result = HandleThumbnail(service, playlist, (int)idMessage.Index, (int)idMessage.CueIndex, idMessage.Quality, idMessage.ContentType);
			return (!result.HasValue) ? Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			}) : Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PlaylistResponse().IdThumbnail = new API_v1_Playlist_Response.Types.Thumbnail
				{
					ContentType = result.Value.contentType,
					Data = result.Value.data
				};
			});
		});
	}

	private static (ByteString? data, API_v1_ContentType contentType)? HandleThumbnail(IAPIv1Service service, IPlaylist<ProPresenterCue>? playlist, int itemIndex, int cueIndex, int quality, API_v1_ContentType contentType)
	{
		if (playlist?.ElementAtOrDefault(itemIndex) is IDocumentCue documentCue)
		{
			SlideBase slideBase = (documentCue.DocumentAction?.ActiveArrangement?.ArrangedCues.ElementAtOrDefault(cueIndex))?.Source?.SlideAction?.Slide;
			if (slideBase is CustomSlide slide)
			{
				SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(ScaleHelper.ScaleToFitSize(targetSize: new Vector2<double>((double)(quality * 16) / 9.0, quality), originalSize: slideBase.Size).Cast<int>(), IncludeBackground: true, IncludeBackgroundMedia: true, Colors.Transparent);
				using IBitmapHandle bitmapHandle = service.Dependencies.SlidePreviewRenderer.RenderSlidePreview(slide, renderParams);
				return (bitmapHandle.BitmapSource?.ToByteString(contentType), contentType);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 TriggerProximalPlaylistID(IAPIv1Service s, string idPath, bool next)
	{
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!Common.TryFindPlaylistFromIDPath(ref identifiers, s.LibraryPlaylists, out IPlaylist<ProPresenterCue> playlist) || !(playlist is Playlist<ProPresenterCue> playlist2))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return TriggerItemAtIndexInPlaylist(next ? s.LibraryPlaylistNonFocusedIndexTracker.NextVisibleIndex(playlist2) : s.LibraryPlaylistNonFocusedIndexTracker.PreviousVisibleIndex(playlist2), 0, playlist2, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().IdNextTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerItemAtIndexInFocusedPlaylist(IAPIv1Service s, int index, int cueIndex)
	{
		return TriggerItemAtIndexInPlaylist(index, cueIndex, s.Triggering.ActiveLibraryPlaylist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedIndexTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}), updateActive: true);
	}

	private static NetworkAPI_v1 TriggerItemAtIndexInActivePresentationPlaylist(IAPIv1Service s, int index, int cueIndex)
	{
		return TriggerItemAtIndexInPlaylist(index, cueIndex, GetActivePresentationPlaylistAndItem().playlist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActivePresentationIndexTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerItemAtIndexInActiveAnnouncementPlaylist(IAPIv1Service s, int index, int cueIndex)
	{
		return TriggerItemAtIndexInPlaylist(index, cueIndex, GetActiveAnnouncementPlaylistAndItem().playlist, s.Triggering, s.LibraryPlaylistNonFocusedIndexTracker, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().ActiveAnnouncementIndexTrigger = new API_v1_Playlist_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 HandleTimelineOperation(IAPIv1Service service, API_v1_Playlist_Request.Types.TimelineOperation timelineOperation)
	{
		string id = timelineOperation.Id;
		uint index = timelineOperation.Index;
		API_v1_TimelineOperation operation = timelineOperation.Operation;
		return Common.TryFindPlaylistAndDo(service.LibraryPlaylists, id, (Playlist<ProPresenterCue> playlist) => ExecutePlaylistTimeline(playlist, (int)index, service, operation, delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().TimelineOperation = new API_v1_Playlist_Response.Types.TimelineOperation();
		}), service.Triggering);
	}

	private static NetworkAPI_v1 HandleActivePlaylistPresentationTimelineOperation(IAPIv1Service service, uint index, API_v1_TimelineOperation operation)
	{
		if (service.Triggering.ActivePresentationParent is IDocumentCue documentCue)
		{
			return ExecutePlaylistTimeline(documentCue.PlaylistParent, (int)index, service, operation, delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PlaylistResponse().ActivePlaylistPresentationTimelineOperation = new API_v1_Playlist_Response.Types.ActivePlaylistTimelineOperation();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 HandleActivePlaylistAnnouncementTimelineOperation(IAPIv1Service service, uint index, API_v1_TimelineOperation operation)
	{
		if (service.Triggering.ActiveAnnouncementParent is IDocumentCue documentCue)
		{
			return ExecutePlaylistTimeline(documentCue.PlaylistParent, (int)index, service, operation, delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PlaylistResponse().ActivePlaylistAnnouncementTimelineOperation = new API_v1_Playlist_Response.Types.ActivePlaylistTimelineOperation();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 HandleFocusedPlaylistTimelineOperation(IAPIv1Service service, uint index, API_v1_TimelineOperation operation)
	{
		return ExecutePlaylistTimeline(service.Triggering.ActiveLibraryPlaylist, (int)index, service, operation, delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PlaylistResponse().FocusedPlaylistTimelineOperation = new API_v1_Playlist_Response.Types.FocusedPlaylistTimelineOperation();
		});
	}

	private static NetworkAPI_v1 HandleActivePlaylistPresentationTimelineStatus(IAPIv1Service service, uint index)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePresentationParent is IDocumentCue documentCue && documentCue.PlaylistParent?.ElementAtOrDefault((int)index) is IDocumentCue cue)
			{
				var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(cue);
				v1.StreamingAction($"/playlist/active/presentation/{index}/timeline").PlaylistResponse().ActivePlaylistPresentationTimelineStatus = new API_v1_Playlist_Response.Types.ActivePlaylistTimelineStatus
				{
					CurrentTime = timeSlice.TotalSeconds,
					IsRunning = isRunning
				};
			}
			else
			{
				v1.StreamingAction($"/playlist/active/presentation/{index}/timeline").NotFound();
			}
		});
	}

	private static NetworkAPI_v1 HandleActivePlaylistAnnouncementTimelineStatus(IAPIv1Service service, uint index)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActiveAnnouncementParent is IDocumentCue documentCue && documentCue.PlaylistParent?.ElementAtOrDefault((int)index) is IDocumentCue cue)
			{
				var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(cue);
				v1.StreamingAction($"/playlist/active/announcement/{index}/timeline").PlaylistResponse().ActivePlaylistAnnouncementTimelineStatus = new API_v1_Playlist_Response.Types.ActivePlaylistTimelineStatus
				{
					CurrentTime = timeSlice.TotalSeconds,
					IsRunning = isRunning
				};
			}
			else
			{
				v1.StreamingAction($"/playlist/active/announcement/{index}/timeline").NotFound();
			}
		});
	}

	private static NetworkAPI_v1 HandleFocusedPlaylistTimelineStatus(IAPIv1Service service, uint index)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActiveLibraryPlaylist?.ElementAtOrDefault((int)index) is IDocumentCue cue)
			{
				var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(cue);
				v1.StreamingAction($"/playlist/focused/{index}/timeline").PlaylistResponse().FocusedPlaylistTimelineStatus = new API_v1_Playlist_Response.Types.FocusedPlaylistTimelineStatus
				{
					CurrentTime = timeSlice.TotalSeconds,
					IsRunning = isRunning
				};
			}
			else
			{
				v1.StreamingAction($"/playlist/focused/{index}/timeline").NotFound();
			}
		});
	}

	private static NetworkAPI_v1 ExecutePlaylistTimeline(Playlist<ProPresenterCue>? playlist, int index, IAPIv1Service service, API_v1_TimelineOperation operation, Action<NetworkAPI_v1> createResponseCallback)
	{
		if (playlist?.ElementAtOrDefault(index) is IDocumentCue documentCue)
		{
			if (documentCue.DocumentAction?.Presentation?.IsAvailable == true)
			{
				ExecuteTimeline(service, operation, documentCue);
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					createResponseCallback(v1);
				});
			}
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().Unauthorized();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static void ExecuteTimeline(IAPIv1Service service, API_v1_TimelineOperation operation, IDocumentCue document)
	{
		switch (operation)
		{
		case API_v1_TimelineOperation.Play:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Play(document, null);
			});
			break;
		case API_v1_TimelineOperation.Pause:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Pause(document);
			});
			break;
		case API_v1_TimelineOperation.Rewind:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Reset(document);
			});
			break;
		}
	}
}
