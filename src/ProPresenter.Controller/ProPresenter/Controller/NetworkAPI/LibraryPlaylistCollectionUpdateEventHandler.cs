using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class LibraryPlaylistCollectionUpdateEventHandler : PlaylistCollectionUpdateEventHandler<ProPresenterCue>
{
	private readonly IAPIv1Service _service;

	public LibraryPlaylistCollectionUpdateEventHandler(LibraryPlaylistCollection playlists, IAPIv1Service service)
		: base((PlaylistCollectionBase<ProPresenterCue>)playlists)
	{
		_service = service;
	}

	protected override NetworkAPI_v1 GetProto(PlaylistCollectionBase<ProPresenterCue> playlists)
	{
		return LibraryPlaylistHandler.UpdatePlaylists(playlists, _service);
	}
}
