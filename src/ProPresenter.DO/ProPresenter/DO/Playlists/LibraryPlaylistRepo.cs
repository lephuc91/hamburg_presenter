namespace ProPresenter.DO.Playlists;

public class LibraryPlaylistRepo : ILibraryPlaylistRepo
{
	public LibraryPlaylistCollection LibraryPlaylists => DataVault.LibraryPlaylistCollection;
}
