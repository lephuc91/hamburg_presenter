using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Remote.Apps;

public static class PlaylistTypeExtensions
{
	public static PlaylistType ToInteropType(this ProPresenter.DO.Playlists.PlaylistType type)
	{
		if (type == ProPresenter.DO.Playlists.PlaylistType.Group)
		{
			return PlaylistType.Group;
		}
		return PlaylistType.Playlist;
	}
}
