using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class Request
{
	[JsonPropertyName("source")]
	public UsageSource? Source { get; init; }

	[JsonPropertyName("data")]
	public UsageReport? Data { get; init; }
}
