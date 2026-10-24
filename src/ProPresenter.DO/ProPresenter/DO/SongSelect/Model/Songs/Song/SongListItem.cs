using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongListItem
{
	[JsonPropertyName("id")]
	public string Id { get; init; } = string.Empty;

	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("songNumber")]
	public int SongNumber { get; init; }

	[JsonPropertyName("authors")]
	public string[] Authors { get; init; } = Array.Empty<string>();

	[JsonPropertyName("rank")]
	public int Rank { get; init; }

	[JsonPropertyName("songSelectLinks")]
	public SongContentLinks SongSelectLinks { get; init; } = new SongContentLinks();
}
