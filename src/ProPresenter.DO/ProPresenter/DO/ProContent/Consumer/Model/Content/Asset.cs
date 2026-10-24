using System;
using System.Text.Json.Serialization;
using Pro.Common.Serialization;
using Pro.Common.Serialization.Polymorphism;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

[JsonConverter(typeof(PolymorhpicConverter<Asset>))]
[CustomJsonPolymorphic(TypeDiscriminatorPropertyName = "asset_type")]
[CustomJsonDerivedType(typeof(Pack), "Pack")]
[CustomJsonDerivedType(typeof(Image), "Image")]
[CustomJsonDerivedType(typeof(Video), "Video")]
[CustomJsonDerivedType(typeof(Navigation), "Navigation")]
public class Asset
{
	[JsonPropertyName("id")]
	[JsonRequired]
	public string Id { get; init; } = string.Empty;

	[JsonPropertyName("display_name")]
	public string DisplayName { get; init; } = string.Empty;

	[JsonPropertyName("external_url")]
	[JsonRequired]
	public Uri ExternalUrl { get; init; }

	[JsonPropertyName("thumbnail_url")]
	[JsonRequired]
	public Uri ThumbnailUrl { get; init; }

	[JsonPropertyName("preview_url")]
	public Uri? PreviewUrl { get; init; }

	[JsonPropertyName("subscription_type")]
	public SubscriptionType SubscriptionType { get; init; } = SubscriptionType.Premium;
}
