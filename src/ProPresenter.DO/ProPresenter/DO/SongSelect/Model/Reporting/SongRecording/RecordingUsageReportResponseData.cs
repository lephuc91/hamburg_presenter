using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class RecordingUsageReportResponseData
{
	[JsonPropertyName("status")]
	public string? Status { get; init; }

	[JsonPropertyName("message")]
	public string? Message { get; init; }

	[JsonPropertyName("reported")]
	public Recording[] Reported { get; init; } = Array.Empty<Recording>();
}
