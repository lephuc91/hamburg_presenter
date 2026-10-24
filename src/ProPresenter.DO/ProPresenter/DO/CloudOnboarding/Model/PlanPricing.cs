using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PlanPricing
{
	[JsonPropertyName("year")]
	public string Year { get; init; } = string.Empty;

	[JsonPropertyName("month")]
	public string Month { get; init; } = string.Empty;
}
