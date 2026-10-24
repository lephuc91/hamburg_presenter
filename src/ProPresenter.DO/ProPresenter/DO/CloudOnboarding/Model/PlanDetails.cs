using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PlanDetails
{
	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("pricing")]
	public required PlanPricing Pricing { get; init; }

	[JsonPropertyName("isFree")]
	public bool IsFree { get; init; }

	[JsonPropertyName("features")]
	public List<PlanFeature> Features { get; init; } = new List<PlanFeature>();

	[JsonIgnore]
	public int StorageGb => (Features?.FirstOrDefault((PlanFeature f) => f.Key == "storageGb")?.Value).GetValueOrDefault();
}
