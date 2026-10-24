using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongLinks
{
	[JsonPropertyName("self")]
	public string Self { get; init; } = string.Empty;

	[JsonPropertyName("lyrics")]
	public string Lyrics { get; init; } = string.Empty;

	[JsonPropertyName("lyricsPreview")]
	public string LyricsPreview { get; init; } = string.Empty;

	[JsonPropertyName("getChordSheetPdf")]
	public string ChordSheetPdf { get; init; } = string.Empty;
}
