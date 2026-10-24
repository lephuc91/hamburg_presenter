using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongSearchResults
{
	public const string TYPE_DISCRIMINATOR = "searchResults";

	[JsonPropertyName("links")]
	public SearchResultsLinks Links { get; init; } = new SearchResultsLinks();

	[JsonPropertyName("results")]
	public SongSearchInfo[] Results { get; init; } = Array.Empty<SongSearchInfo>();
}
