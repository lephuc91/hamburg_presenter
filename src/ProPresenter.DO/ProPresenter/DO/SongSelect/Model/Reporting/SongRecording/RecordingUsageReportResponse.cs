using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class RecordingUsageReportResponse
{
	[JsonPropertyName("date")]
	public string? Date { get; init; }

	[JsonPropertyName("recordings")]
	public RecordingUsageReportResponseData? Recordings { get; init; }
}
