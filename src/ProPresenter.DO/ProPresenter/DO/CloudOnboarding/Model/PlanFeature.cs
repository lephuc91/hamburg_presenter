using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PlanFeature
{
	[JsonPropertyName("key")]
	public string Key { get; init; } = string.Empty;

	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("value")]
	public int Value { get; init; }
}
