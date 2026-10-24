using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class PricingOptionsResponse
{
	[JsonPropertyName("result")]
	public required ResponseResult Result { get; init; }

	[JsonPropertyName("data")]
	public PricingOptionsData? Data { get; init; }

	[JsonPropertyName("timestamp")]
	public long Timestamp { get; init; }
}
