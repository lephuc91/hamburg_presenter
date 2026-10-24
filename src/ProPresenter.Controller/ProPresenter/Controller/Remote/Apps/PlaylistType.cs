using System.Runtime.Serialization;

namespace ProPresenter.Controller.Remote.Apps;

public enum PlaylistType
{
	[EnumMember(Value = "playlistTypeGroup")]
	Group,
	[EnumMember(Value = "playlistTypePlaylist")]
	Playlist
}
