using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongSearchInfo
{
	[JsonPropertyName("id")]
	public string Id { get; init; } = string.Empty;

	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("songNumber")]
	public int SongNumber { get; init; }

	[JsonPropertyName("defaultKey")]
	public List<string> DefaultKey { get; init; } = new List<string>();

	[JsonPropertyName("transposeKeyList")]
	public string TransposeKeyList { get; init; } = string.Empty;

	[JsonPropertyName("authors")]
	public string[] Authors { get; init; } = Array.Empty<string>();

	[JsonPropertyName("isPublicDomain")]
	public bool IsPublicDomain { get; init; }

	[JsonPropertyName("lyricsPreview")]
	public string LyricsPreview { get; init; } = string.Empty;

	[JsonPropertyName("content")]
	public SongContent Content { get; init; } = new SongContent();

	[JsonPropertyName("links")]
	public Dictionary<string, string> Links { get; init; } = new Dictionary<string, string>();
}
