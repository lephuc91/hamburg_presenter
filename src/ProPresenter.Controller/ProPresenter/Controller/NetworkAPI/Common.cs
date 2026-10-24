using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.NetworkAPI;

internal static class Common
{
	internal record ProtoMediaPlaylistResponse(API_v1_Identifier ID, IEnumerable<API_v1_MediaPlaylistItem> Items);

	[CompilerGenerated]
	private sealed class _003CGetPlaylists_003Ed__26<T> : IEnumerable<API_v1_Playlist>, IEnumerable, IEnumerator<API_v1_Playlist>, IEnumerator, IDisposable where T : notnull, ProPresenterCue
	{
		private int _003C_003E1__state;

		private API_v1_Playlist _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<IPlaylist<T>> playlists;

		public IEnumerable<IPlaylist<T>> _003C_003E3__playlists;

		private uint _003Cindex_003E5__2;

		private IEnumerator<IPlaylist<T>> _003C_003E7__wrap2;

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
		public _003CGetPlaylists_003Ed__26(int _003C_003E1__state)
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
			_003C_003E7__wrap2 = null;
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
					if (playlists == null)
					{
						return false;
					}
					_003Cindex_003E5__2 = 0u;
					_003C_003E7__wrap2 = playlists.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					IPlaylist<T> current = _003C_003E7__wrap2.Current;
					_003C_003E2__current = new API_v1_Playlist
					{
						Id = ID(current, _003Cindex_003E5__2++),
						Type = ((current.Type != PlaylistType.Group) ? API_v1_Playlist.Types.API_v1_PlaylistType.Playlist : API_v1_Playlist.Types.API_v1_PlaylistType.Group),
						Children = { GetPlaylists(current.Children ?? Enumerable.Empty<IPlaylist<T>>()) }
					};
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap2 = null;
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
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
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
			_003CGetPlaylists_003Ed__26<T> _003CGetPlaylists_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetPlaylists_003Ed__ = this;
			}
			else
			{
				_003CGetPlaylists_003Ed__ = new _003CGetPlaylists_003Ed__26<T>(0);
			}
			_003CGetPlaylists_003Ed__.playlists = _003C_003E3__playlists;
			return _003CGetPlaylists_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Playlist>)this).GetEnumerator();
		}
	}

	public static bool TryFindItem<T>(IEnumerable<T> collection, string identifier, [NotNullWhen(true)] out ItemPacket<T>? packet) where T : IIdentifiable
	{
		packet = null;
		T val = byID();
		object obj;
		if (val == null)
		{
			T val2 = byName();
			obj = ((val2 != null) ? ((IIdentifiable)val2) : ((IIdentifiable)byIndex()));
		}
		else
		{
			obj = val;
		}
		T val3 = (T)obj;
		if (val3 != null)
		{
			packet = new ItemPacket<T>(val3, val3.ID, val3.Name ?? string.Empty, (uint)collection.IndexOf(val3));
		}
		return val3 != null;
		T? byID()
		{
			Guid id;
			return Guid.TryParse(identifier, out id).Then(() => collection.FirstOrDefault((T p) => p.ID == id));
		}
		T? byIndex()
		{
			uint index;
			return uint.TryParse(identifier, out index).Then(() => collection.ElementAtOrDefault((int)index));
		}
		T? byName()
		{
			return collection.FirstOrDefault((T p) => p.Name == identifier);
		}
	}

	public static bool TryFindItem<T>(IEnumerable<T> collection, API_v1_Identifier identifier, [NotNullWhen(true)] out ItemPacket<T>? packet) where T : IIdentifiable
	{
		packet = null;
		Guid id2;
		T val = (isID(out id2) ? byID(id2) : (isName() ? byName() : byIndex()));
		if (val != null)
		{
			packet = new ItemPacket<T>(val, val.ID, val.Name ?? string.Empty, (uint)collection.IndexOf(val));
		}
		return val != null;
		T? byID(Guid id)
		{
			return collection.FirstOrDefault((T p) => p.ID == id);
		}
		T? byIndex()
		{
			return collection.ElementAtOrDefault((int)identifier.Index);
		}
		T? byName()
		{
			return collection.FirstOrDefault((T p) => p.Name == identifier.Name);
		}
		bool isID(out Guid id)
		{
			return Guid.TryParse(identifier.Uuid, out id);
		}
		bool isName()
		{
			return !string.IsNullOrEmpty(identifier.Name);
		}
	}

	public static bool TryFindPlaylistFromIDPath<T>(ref IEnumerable<string> identifiers, IEnumerable<IPlaylist<T>> node, [NotNullWhen(true)] out IPlaylist<T>? playlist) where T : ProPresenterCue
	{
		string identifier = identifiers.First();
		playlist = byID() ?? byName() ?? byIndex();
		if (playlist != null)
		{
			identifiers = identifiers.Skip(1);
		}
		if (playlist == null || playlist.Type != PlaylistType.Group || identifiers.Empty())
		{
			return playlist != null;
		}
		return TryFindPlaylistFromIDPath(ref identifiers, playlist.Children ?? Enumerable.Empty<IPlaylist<T>>(), out playlist);
		IPlaylist<T>? byID()
		{
			Guid id;
			return Guid.TryParse(identifier, out id).Then(() => node.GetPlaylists().FirstOrDefault((IPlaylist<T> p) => p.ID == id));
		}
		IPlaylist<T>? byIndex()
		{
			uint index;
			return uint.TryParse(identifier, out index).Then(() => node.ElementAtOrDefault((int)index));
		}
		IPlaylist<T>? byName()
		{
			return node.GetPlaylists().FirstOrDefault((IPlaylist<T> p) => p.Name == identifier);
		}
	}

	public static bool TryFindPlaylistItem<T>(ref IEnumerable<string> identifiers, IPlaylist<T> iPlaylist, [NotNullWhen(true)] out T? item) where T : ProPresenterCue
	{
		item = null;
		if (iPlaylist is Playlist<T> collection && !identifiers.Empty() && TryFindItem(collection, identifiers.First(), out ItemPacket<T> packet))
		{
			item = packet.Item;
			identifiers = identifiers.Skip(1);
		}
		return item != null;
	}

	public static NetworkAPI_v1 Build(Action<NetworkAPI_v1> action)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		action(networkAPI_v);
		return networkAPI_v;
	}

	public static NetworkAPI_v1.Types.Action Action(this NetworkAPI_v1 v1)
	{
		return v1.Action ?? (v1.Action = new NetworkAPI_v1.Types.Action());
	}

	public static NetworkAPI_v1.Types.Action StreamingAction(this NetworkAPI_v1 v1, string identifier)
	{
		NetworkAPI_v1.Types.Action action = v1.Action;
		if (action == null)
		{
			NetworkAPI_v1.Types.Action obj = new NetworkAPI_v1.Types.Action
			{
				UpdateIdentifier = identifier
			};
			NetworkAPI_v1.Types.Action action2 = obj;
			v1.Action = obj;
			action = action2;
		}
		return action;
	}

	public static void NotFound(this NetworkAPI_v1.Types.Action action)
	{
		action.ErrorResponse(API_v1_Error_Response.Types.API_v1_Error_Type.NotFound);
	}

	public static void InternalError(this NetworkAPI_v1.Types.Action action)
	{
		action.ErrorResponse(API_v1_Error_Response.Types.API_v1_Error_Type.InternalError);
	}

	public static void BadRequest(this NetworkAPI_v1.Types.Action action)
	{
		action.ErrorResponse(API_v1_Error_Response.Types.API_v1_Error_Type.BadRequest);
	}

	public static void Unauthorized(this NetworkAPI_v1.Types.Action action)
	{
		action.ErrorResponse(API_v1_Error_Response.Types.API_v1_Error_Type.Unauthorized);
	}

	public static void ErrorResponse(this NetworkAPI_v1.Types.Action action, API_v1_Error_Response.Types.API_v1_Error_Type error)
	{
		action.ErrorResponse = new API_v1_Error_Response
		{
			Error = error
		};
	}

	public static API_v1_Identifier ID(Guid id, string name, uint index)
	{
		return new API_v1_Identifier
		{
			Uuid = id.ToString(),
			Name = (name ?? string.Empty),
			Index = index
		};
	}

	public static API_v1_Identifier ID(Identification identification)
	{
		return ID(identification.ID, identification.Name, identification.Index);
	}

	public static API_v1_Identifier ID(IIdentifiable identifiable, uint index)
	{
		return ID(identifiable.ID, identifiable.Name, index);
	}

	public static API_v1_Identifier? NullableID(IIdentifiable? item, uint index)
	{
		if (item == null)
		{
			return null;
		}
		return ID(item, index);
	}

	public static IEnumerable<API_v1_Identifier> ToIdentifiers(this IEnumerable<IIdentifiable> source)
	{
		uint index = 0u;
		return source.Select((IIdentifiable c) => ID(c.ID, c.Name, index++)).ToArray();
	}

	public static System.Windows.Media.Color ToColor(this API_v1_Color? color)
	{
		if (color == null)
		{
			return Colors.Black;
		}
		return ColorExtensions.FromNormalizedRGBA(color.Red, color.Green, color.Blue, color.Alpha);
	}

	public static API_v1_Color ToProtoColor(this System.Windows.Media.Color color)
	{
		return new API_v1_Color
		{
			Alpha = ColorExtensions.NormalizeComponent(color.A),
			Blue = ColorExtensions.NormalizeComponent(color.B),
			Green = ColorExtensions.NormalizeComponent(color.G),
			Red = ColorExtensions.NormalizeComponent(color.R)
		};
	}

	public static ByteString? GetThumbnail(this SlideCue slideCue, System.Windows.Media.Color? presentationColor, int quality, API_v1_ContentType contentType = API_v1_ContentType.Png)
	{
		return (slideCue?.SlideAction).GetThumbnail(presentationColor, quality, slideCue?.GetIncludeBackground() ?? false, contentType);
	}

	public static ByteString? GetThumbnail(this SlideAction? slideAction, System.Windows.Media.Color? presentationColor, int quality, bool includeBackground = false, API_v1_ContentType contentType = API_v1_ContentType.Png)
	{
		SlideBase slideBase = slideAction?.Slide;
		if (!(slideBase is CustomSlide slide))
		{
			return ByteString.Empty;
		}
		Vector2<int> previewSize = (slideBase.Size * GetScaleDownRatio(new Vector2<double>(slideBase.Size.X, slideBase.Size.Y), quality)).Cast<int>();
		if (previewSize.X != 0 && previewSize.Y != 0)
		{
			return SlidePreviewRenderer.RenderSlidePreview(slide, new SlidePreviewRenderParams(previewSize, includeBackground, IncludeBackgroundMedia: true, presentationColor ?? Colors.Transparent, ElementsRenderOption.BlackBackground, null, IncludeTextPlaceholder: false, UseFullSizeMedia: false, UseScreenScalar: false))?.BitmapSource?.ToByteString(contentType);
		}
		return ByteString.Empty;
	}

	public static ByteString ScaleBitmap(this BitmapSource fullSizeBitmap, int quality)
	{
		double scaleDownRatio = GetScaleDownRatio(new Vector2<double>(fullSizeBitmap.PixelWidth, fullSizeBitmap.PixelHeight), quality);
		return new TransformedBitmap(fullSizeBitmap, new ScaleTransform(scaleDownRatio, scaleDownRatio)).ToByteString();
	}

	public static double GetScaleDownRatio(Vector2<double> original, int quality)
	{
		double num = Math.Max(original.X, original.Y);
		return ((double)quality / num).Clamp(0.0, 1.0);
	}

	public static Vector2<double> ToVector(this API_v1_Size size)
	{
		return new Vector2<double>(size.Width, size.Height);
	}

	public static API_v1_Size ToSize(this Vector2<double> vec)
	{
		return new API_v1_Size
		{
			Width = (uint)vec.X,
			Height = (uint)vec.Y
		};
	}

	public static int PlaylistIndexInParent<T>(IPlaylist<T>? playlist, PlaylistCollectionBase<T> collection) where T : ProPresenterCue
	{
		return (playlist?.PlaylistParent?.Children ?? collection).IndexOf<IPlaylist<T>>(playlist);
	}

	[IteratorStateMachine(typeof(_003CGetPlaylists_003Ed__26<>))]
	public static IEnumerable<API_v1_Playlist> GetPlaylists<T>(IEnumerable<IPlaylist<T>> playlists) where T : ProPresenterCue
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetPlaylists_003Ed__26<T>(-2)
		{
			_003C_003E3__playlists = playlists
		};
	}

	public static ProtoMediaPlaylistResponse MediaPlaylistResponseProto<T>(IPlaylist<T> playlist, int start, PlaylistCollectionBase<T> rootCollection) where T : MediaCue
	{
		IEnumerable<T> items = playlist ?? Enumerable.Empty<T>();
		IEnumerable<T> source = items.Skip(start);
		return new ProtoMediaPlaylistResponse(ID(playlist.ID, playlist.Name, (uint)PlaylistIndexInParent(playlist, rootCollection)), source.Select((T i) => Serialize(i, (uint)items.IndexOf(i))));
	}

	public static NetworkAPI_v1 TryFindPlaylistAndDo<T>(PlaylistCollectionBase<T> playlistCollection, string idPath, Func<Playlist<T>, NetworkAPI_v1> success, params object[] objectsToNullCheckBeforeSuccess) where T : ProPresenterCue
	{
		if (playlistCollection == null || objectsToNullCheckBeforeSuccess.Contains(null))
		{
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (TryFindPlaylistFromIDPath(ref identifiers, playlistCollection, out IPlaylist<T> playlist) && identifiers.Empty() && playlist is Playlist<T> arg)
		{
			return success(arg);
		}
		return Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	public static PlaylistType GetProximalPlaylist<T, PlaylistType>(PlaylistType playlist, PlaylistCollectionBase<T>? playlistCollection, int inc) where T : ProPresenterCue
	{
		List<IPlaylist<T>> list = playlistCollection?.GetPlaylists().ToList();
		int num = ((playlist == null) ? (-1) : (list?.IndexOf(playlist) ?? (-1)));
		if (list != null)
		{
			for (int i = num + inc; 0 <= i && i < list.Count; i += inc)
			{
				IPlaylist<T> playlist2 = list[i];
				if (playlist2 is PlaylistType)
				{
					return (PlaylistType)playlist2;
				}
			}
		}
		return playlist;
	}

	public static NetworkAPI_v1 TriggerPlaylistID<T, PlaylistType>(ITriggering triggering, PlaylistCollectionBase<T> playlistCollection, string idPath, Func<T, PlaylistType, NetworkAPI_v1> trigger) where T : ProPresenterCue where PlaylistType : IEnumerable<T>
	{
		if (playlistCollection == null || triggering == null)
		{
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = idPath.Split('/').AsEnumerable();
		if (!TryFindPlaylistFromIDPath(ref identifiers, playlistCollection, out IPlaylist<T> playlist) || !(playlist is PlaylistType val))
		{
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		TryFindPlaylistItem(ref identifiers, playlist, out T item);
		if (item == null && identifiers.Empty())
		{
			item = val.FirstOrDefault();
		}
		if (item == null || !identifiers.Empty())
		{
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return trigger(item, val);
	}

	public static NetworkAPI_v1 TriggerPlaylistItemID<T>(ITriggering triggering, Playlist<T>? playlist, string id, Func<T, Playlist<T>, NetworkAPI_v1> trigger) where T : ProPresenterCue
	{
		if (triggering == null)
		{
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		IEnumerable<string> identifiers = id.ToEnumerable();
		if (playlist != null && TryFindPlaylistItem(ref identifiers, playlist, out T item))
		{
			return trigger(item, playlist);
		}
		return Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	public static NetworkAPI_v1 TriggerProximal<PlaylistType>(ITriggering? triggering, PlaylistType? playlist, Func<PlaylistType, NetworkAPI_v1> triggerProximal)
	{
		if (triggering != null)
		{
			if (playlist != null)
			{
				return triggerProximal(playlist);
			}
			return Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().InternalError();
		});
	}

	private static API_v1_MediaPlaylistItem Serialize(MediaCue i, uint index)
	{
		API_v1_MediaPlaylistItem aPI_v1_MediaPlaylistItem = new API_v1_MediaPlaylistItem();
		aPI_v1_MediaPlaylistItem.Id = ID(i, index);
		API_v1_MediaPlaylistItem aPI_v1_MediaPlaylistItem2 = aPI_v1_MediaPlaylistItem;
		aPI_v1_MediaPlaylistItem2.Type = i.MediaAction?.Media.MediaType switch
		{
			MediaType.Image => API_v1_MediaPlaylistItem.Types.API_v1_MediaPlaylistItemType.Image, 
			MediaType.Video => API_v1_MediaPlaylistItem.Types.API_v1_MediaPlaylistItemType.Video, 
			MediaType.Audio => API_v1_MediaPlaylistItem.Types.API_v1_MediaPlaylistItemType.Audio, 
			_ => API_v1_MediaPlaylistItem.Types.API_v1_MediaPlaylistItemType.Audio, 
		};
		aPI_v1_MediaPlaylistItem.Artist = i.MediaAction?.AudioMedia?.Metadata?.Artist ?? string.Empty;
		aPI_v1_MediaPlaylistItem.Duration = (uint)(i.MediaAction?.MediaDuration ?? TimeSlice.Zero).TotalSeconds;
		return aPI_v1_MediaPlaylistItem;
	}

	public static bool TryFindNode<T>(string path, IEnumerable<T> nodes, [NotNullWhen(true)] out ItemPacket<T>? packet) where T : ITreeNode<T>, IIdentifiable
	{
		IEnumerable<string> identifiers = path.Split('/');
		return TryFindNode(ref identifiers, nodes, out packet);
	}

	public static bool TryFindNode<T>(ref IEnumerable<string> identifiers, IEnumerable<T> nodes, [NotNullWhen(true)] out ItemPacket<T>? packet) where T : ITreeNode<T>, IIdentifiable
	{
		string identifier = identifiers.First();
		if (!TryFindItem(nodes, identifier, out packet))
		{
			return false;
		}
		identifiers = identifiers.Skip(1);
		T item = packet.Item;
		if (item.Children == null || item.Children.Empty() || identifiers.Empty())
		{
			return item != null;
		}
		return TryFindNode(ref identifiers, item.Children, out packet);
	}
}
