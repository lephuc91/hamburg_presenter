using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PricingMessages
{
	[JsonPropertyName("intro")]
	public string Intro { get; init; } = string.Empty;

	[JsonPropertyName("pricing")]
	public string Pricing { get; init; } = string.Empty;

	[JsonPropertyName("disclaimer")]
	public string Disclaimer { get; init; } = string.Empty;
}
