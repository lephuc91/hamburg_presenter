using System;
using System.Text.Json.Serialization;
using Pro.Common.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Media;

public class MediaAttributes
{
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; init; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }

	[JsonPropertyName("themes")]
	public string? Themes { get; init; }

	[JsonPropertyName("title")]
	public string? Title { get; init; }

	[JsonPropertyName("thumbnail_file_name")]
	public string? ThumbnailFileName { get; init; }

	[JsonPropertyName("thumbnail_content_type")]
	public string? ThumbnailContentType { get; init; }

	[JsonPropertyName("thumbnail_file_size")]
	[JsonConverter(typeof(MayBeNullValueConverter<long>))]
	public long ThumbnailFileSize { get; init; }

	[JsonPropertyName("thumbnail_updated_at")]
	public DateTime? ThumbnailUpdatedAt { get; init; }

	[JsonPropertyName("preview_file_name")]
	public string? PreviewFileName { get; init; }

	[JsonPropertyName("preview_content_type")]
	public string? PreviewContentType { get; init; }

	[JsonPropertyName("preview_file_size")]
	[JsonConverter(typeof(MayBeNullValueConverter<long>))]
	public long PreviewFileSize { get; init; }

	[JsonPropertyName("preview_updated_at")]
	public DateTime? PreviewUpdatedAt { get; init; }

	[JsonPropertyName("length")]
	[JsonConverter(typeof(MayBeNullValueConverter<long>))]
	public long Length { get; init; }

	[JsonPropertyName("media_type")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public MediaType MediaType { get; init; }

	[JsonPropertyName("media_type_name")]
	public string? MediaTypeName { get; init; }

	[JsonPropertyName("thumbnail_url")]
	public string? ThumbnailUrl { get; init; }

	[JsonPropertyName("creator_name")]
	public string? CreatorName { get; init; }

	[JsonPropertyName("preview_url")]
	public string? PreviewUrl { get; init; }

	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; init; }
}
