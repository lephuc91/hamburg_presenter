using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Pro.Common.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public class Collection
{
	[JsonPropertyName("id")]
	[JsonRequired]
	public string Id { get; init; } = string.Empty;

	[JsonPropertyName("display_name")]
	public string DisplayName { get; init; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; init; } = string.Empty;

	[JsonPropertyName("external_url")]
	[JsonConverter(typeof(EmptyStringToNullUriConvrter))]
	public Uri? ExternalUrl { get; init; }

	[JsonPropertyName("layout_type")]
	public CollectionLayoutType LayoutType { get; init; }

	[JsonPropertyName("assets")]
	public Asset[] Assets { get; init; } = Array.Empty<Asset>();

	[JsonPropertyName("is_downloadable")]
	[MemberNotNullWhen(true, "ExternalUrl")]
	public bool IsDownloadable
	{
		[MemberNotNullWhen(true, "ExternalUrl")]
		get;
		[MemberNotNullWhen(true, "ExternalUrl")]
		init;
	}

	[JsonPropertyName("formats")]
	public Format[] Formats { get; init; } = Array.Empty<Format>();
}
