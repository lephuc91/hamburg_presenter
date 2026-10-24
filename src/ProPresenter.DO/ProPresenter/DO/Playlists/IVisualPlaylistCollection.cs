using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public interface IVisualPlaylistCollection : INotifyEnumerableChanged<IPlaylist<MediaCue>>, IEnumerable<IPlaylist<MediaCue>>, IEnumerable, INotifyCollectionChanged
{
	LiveVideoPlaylist LiveVideoPlaylist { get; }

	UndoStack? UndoStack { get; }

	event Action<string> LocationChanged;

	VisualPlaylist AddNewHotPlaylist(RelativePath targetFolder, VisualGroupPlaylist? parent = null, int index = -1);

	VisualPlaylist AddNewPlaylist(string name = "", VisualGroupPlaylist? parent = null, int index = -1);

	VisualGroupPlaylist AddNewVisualGroupPlaylist(VisualGroupPlaylist? parent = null, int index = -1);

	void Deserialize(PlaylistDocument? document, bool removeExisting = true);

	void RemovePlaylist(IPlaylist<MediaCue> playlist);

	PlaylistDocument Serialize();

	VisualPlaylist? GetTargetPlaylist(VisualPlaylist? playlist);

	void Duplicate(IEnumerable<IPlaylist<MediaCue>> playlists);

	void AddPlaylist(IPlaylist<MediaCue> playlist, GroupPlaylist<MediaCue>? parent = null, int index = -1);

	Task ConvertAllSmartPlaylistsToVisualPlaylistsAsync();
}
