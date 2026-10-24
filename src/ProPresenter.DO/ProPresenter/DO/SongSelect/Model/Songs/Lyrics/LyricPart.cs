using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Lyrics;

public class LyricPart
{
	[JsonPropertyName("partLabel")]
	public string? partLabel { get; init; }

	[JsonPropertyName("partType")]
	public string? partType { get; init; }

	[JsonPropertyName("partTypeNumber")]
	public int partTypeNumber { get; init; }

	[JsonPropertyName("lyrics")]
	public string? lyrics { get; init; }
}
