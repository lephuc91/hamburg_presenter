using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProPresenter.Controller.Remote.Apps;

public class Playlist
{
	[JsonProperty(PropertyName = "playlistLocation")]
	public string? Location { get; set; }

	[JsonProperty(PropertyName = "playlistType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public PlaylistType Type { get; set; }

	[JsonProperty(PropertyName = "playlistName")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "playlist")]
	public object[]? Children { get; set; }
}
