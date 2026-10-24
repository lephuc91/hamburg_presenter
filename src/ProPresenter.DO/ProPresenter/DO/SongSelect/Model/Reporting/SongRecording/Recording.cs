using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class Recording
{
	[JsonPropertyName("isrc")]
	public string? Isrc { get; init; }

	[JsonPropertyName("albumTitle")]
	public string? AlbumTitle { get; init; }

	[JsonPropertyName("appleAlbumId")]
	public string? AppleAlbumId { get; init; }

	[JsonPropertyName("useType")]
	public RecordingUsageType? UseType { get; init; }

	[JsonPropertyName("songIds")]
	public string[] SongIds { get; init; } = Array.Empty<string>();
}
