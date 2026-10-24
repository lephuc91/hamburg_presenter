using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class Response
{
	[JsonPropertyName("source")]
	public UsageSource? Source { get; init; }

	[JsonPropertyName("links")]
	public Dictionary<string, string> Links { get; init; } = new Dictionary<string, string>();

	[JsonPropertyName("usage")]
	public RecordingUsageReportResponse[] Usage { get; init; } = Array.Empty<RecordingUsageReportResponse>();
}
