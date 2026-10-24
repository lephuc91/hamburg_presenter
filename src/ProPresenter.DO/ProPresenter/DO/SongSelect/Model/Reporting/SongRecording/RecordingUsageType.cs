using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongRecording;

public class RecordingUsageType
{
	[JsonPropertyName("stream")]
	public bool Stream { get; init; }

	[JsonPropertyName("rehearse")]
	public bool Rehearse { get; init; }
}
