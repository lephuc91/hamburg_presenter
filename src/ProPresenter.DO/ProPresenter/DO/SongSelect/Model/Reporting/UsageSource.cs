using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting;

public class UsageSource
{
	[JsonPropertyName("name")]
	public string Name { get; init; } = string.Empty;
}
