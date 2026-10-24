using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PricingOptionsData
{
	[JsonPropertyName("action")]
	public string Action { get; init; } = string.Empty;

	[JsonPropertyName("reason")]
	public string Reason { get; init; } = string.Empty;

	[JsonPropertyName("messages")]
	public required PricingMessages Messages { get; init; }

	[JsonPropertyName("currentPlan")]
	public required PlanDetails CurrentPlan { get; init; }

	[JsonPropertyName("recommendedPlan")]
	public required PlanDetails RecommendedPlan { get; init; }

	[JsonPropertyName("periodUnit")]
	public string PeriodUnit { get; init; } = string.Empty;
}
