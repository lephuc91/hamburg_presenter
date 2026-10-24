using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Lyrics;

public class SongLyricsPreview
{
	public const string TYPE_DISCRIMINATOR = "songLyricsPreview";

	[JsonPropertyName("lyricsPreview")]
	public string LyricsPreview { get; init; } = string.Empty;

	[JsonPropertyName("songID")]
	public string SongID { get; init; } = string.Empty;

	[JsonPropertyName("songNumber")]
	public int SongNumber { get; init; }
}
