using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Lyrics;

public class SongLyrics
{
	public const string TYPE_DISCRIMINATOR = "songLyrics";

	[JsonPropertyName("songID")]
	public string SongId { get; init; } = string.Empty;

	[JsonPropertyName("songNumber")]
	public int SongNumber { get; init; }

	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("cclid")]
	public string Cclid { get; init; } = string.Empty;

	[JsonPropertyName("authors")]
	public string[] Authors { get; init; } = Array.Empty<string>();

	[JsonPropertyName("copyrights")]
	public string[] Copyrights { get; init; } = Array.Empty<string>();

	[JsonPropertyName("disclaimer")]
	public string Disclaimer { get; init; } = string.Empty;

	[JsonPropertyName("lyricParts")]
	public LyricPart[] LyricParts { get; init; } = Array.Empty<LyricPart>();
}
