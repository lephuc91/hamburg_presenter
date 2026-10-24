using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProPresenter.Controller.Remote.Apps;

public class PlaylistItem
{
	[JsonProperty(PropertyName = "playlistItemName")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "playlistItemType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public PlaylistItemType Type { get; set; }

	[JsonProperty(PropertyName = "playlistItemLocation")]
	public string? Location { get; set; }

	[JsonProperty(PropertyName = "playlistItemThumbnail")]
	public string? Thumbnail { get; set; }

	[JsonProperty(PropertyName = "playlistItemArtist")]
	public string? Artist { get; set; }

	[JsonProperty(PropertyName = "playlistItemDestination")]
	public Destination? Destination { get; set; }
}
