using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class UsageReport
{
	[JsonPropertyName("usage")]
	public RecordingUsageReport[] usage { get; init; } = Array.Empty<RecordingUsageReport>();
}
