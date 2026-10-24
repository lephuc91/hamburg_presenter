using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.ChordPro;

public class SongChordPro
{
	public const string TYPE_DISCRIMINATOR = "songChordPro";

	[JsonPropertyName("songID")]
	public string songID { get; init; } = string.Empty;

	[JsonPropertyName("songNumber")]
	public int songNumber { get; init; }

	[JsonPropertyName("title")]
	public string title { get; init; } = string.Empty;

	[JsonPropertyName("cclid")]
	public string cclid { get; init; } = string.Empty;

	[JsonPropertyName("chordStyle")]
	public string chordStyle { get; init; } = string.Empty;

	[JsonPropertyName("copyright")]
	public string[] copyright { get; init; } = Array.Empty<string>();

	[JsonPropertyName("disclaimer")]
	public string disclaimer { get; init; } = string.Empty;

	[JsonPropertyName("chordPro")]
	public string chordPro { get; init; } = string.Empty;
}
