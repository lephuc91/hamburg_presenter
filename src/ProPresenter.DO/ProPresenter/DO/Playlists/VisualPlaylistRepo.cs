namespace ProPresenter.DO.Playlists;

public class VisualPlaylistRepo : IVisualPlaylistRepo
{
	public VisualPlaylistCollection Playlists => DataVault.VisualPlaylistCollection;
}
