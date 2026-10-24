using System.Text.Json.Serialization;

namespace ProPresenter.DO.WhatsNew.Model;

public record FeatureItem : IFeatureItem
{
	[JsonPropertyName("imageName")]
	public string ImageName { get; set; } = string.Empty;

	[JsonPropertyName("titleKey")]
	public string Title { get; set; } = string.Empty;

	[JsonPropertyName("descriptionKey")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("link")]
	public FeatureLink? FeatureLink { get; set; }
}
