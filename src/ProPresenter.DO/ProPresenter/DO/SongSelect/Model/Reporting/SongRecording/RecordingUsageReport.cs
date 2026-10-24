using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class RecordingUsageReport
{
	[JsonPropertyName("date")]
	public string? Date { get; init; }

	[JsonPropertyName("recordings")]
	public Recording[] Recordings { get; init; } = Array.Empty<Recording>();
}
