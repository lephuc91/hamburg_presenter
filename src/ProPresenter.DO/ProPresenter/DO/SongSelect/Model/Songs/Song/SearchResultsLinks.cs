using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SearchResultsLinks
{
	[JsonPropertyName("first")]
	public string? First { get; init; }

	[JsonPropertyName("last")]
	public string? Last { get; init; }

	[JsonPropertyName("prev")]
	public object? Prev { get; init; }

	[JsonPropertyName("next")]
	public string? Next { get; init; }

	[JsonPropertyName("self")]
	public string? Self { get; init; }
}
