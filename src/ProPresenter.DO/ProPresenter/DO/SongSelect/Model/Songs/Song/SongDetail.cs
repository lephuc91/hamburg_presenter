using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongDetail
{
	public const string TYPE_DISCRIMINATOR = "songDetail";

	[JsonPropertyName("id")]
	public Guid Id { get; init; }

	[JsonPropertyName("songNumber")]
	public int SongNumber { get; init; }

	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("alsoKnownAs")]
	public string[] AlsoKnownAs { get; init; } = Array.Empty<string>();

	[JsonPropertyName("authors")]
	public string[] Authors { get; init; } = Array.Empty<string>();

	[JsonPropertyName("catalogs")]
	public string[] Catalogs { get; init; } = Array.Empty<string>();

	[JsonPropertyName("copyrights")]
	public string[] Copyrights { get; init; } = Array.Empty<string>();

	[JsonPropertyName("defaultKey")]
	public string[] DefaultKey { get; init; } = Array.Empty<string>();

	[JsonPropertyName("transposeKeyList")]
	public string TransposeKeyList { get; init; } = string.Empty;

	[JsonPropertyName("themes")]
	public string[] Themes { get; init; } = Array.Empty<string>();

	[JsonPropertyName("content")]
	public SongContent Content { get; init; } = new SongContent();

	[JsonPropertyName("links")]
	public SongLinks Links { get; init; } = new SongLinks();

	[JsonPropertyName("songSelectLinks")]
	public SongContentLinks ContentLinks { get; init; } = new SongContentLinks();
}
