using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class Response
{
	[JsonPropertyName("source")]
	public UsageSource? Source { get; init; }

	[JsonPropertyName("links")]
	public Dictionary<string, string> Links { get; init; } = new Dictionary<string, string>();

	[JsonPropertyName("usage")]
	public UsageResponse[] Usage { get; init; } = Array.Empty<UsageResponse>();
}
