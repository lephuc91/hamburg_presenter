using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class AllPlaylistResponse
{
	[JsonProperty(PropertyName = "playlistAll")]
	public Playlist[]? Playlists { get; set; }
}
