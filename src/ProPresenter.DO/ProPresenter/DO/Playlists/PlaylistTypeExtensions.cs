namespace ProPresenter.DO.Playlists;

public static class PlaylistTypeExtensions
{
	public static bool CanGotoNext(this PlaylistType type)
	{
		if (type != 0 && type != PlaylistType.Smart)
		{
			return type == PlaylistType.Download;
		}
		return true;
	}
}
