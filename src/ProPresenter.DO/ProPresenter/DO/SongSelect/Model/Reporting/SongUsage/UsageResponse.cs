using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class UsageResponse
{
	[JsonPropertyName("date")]
	public string Date { get; init; } = string.Empty;

	[JsonPropertyName("songs")]
	public SongsUsageResponse Songs { get; init; } = new SongsUsageResponse();
}
