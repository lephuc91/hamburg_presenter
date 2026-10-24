using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class SongsUsageResponse
{
	[JsonPropertyName("status")]
	public string Status { get; init; } = string.Empty;

	[JsonPropertyName("message")]
	public string Message { get; init; } = string.Empty;

	[JsonPropertyName("reported")]
	public string[] Reported { get; init; } = Array.Empty<string>();

	[JsonPropertyName("publicDomain")]
	public string[] PublicDomain { get; init; } = Array.Empty<string>();

	[JsonPropertyName("unrecognized")]
	public string[] Unrecognized { get; init; } = Array.Empty<string>();
}
