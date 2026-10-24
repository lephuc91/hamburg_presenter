using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;

public class AttachmentAttributes
{
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; init; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }

	[JsonPropertyName("filename")]
	public string? Filename { get; init; }

	[JsonPropertyName("file_size")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long FileSize { get; init; }

	[JsonPropertyName("thumbnail_url")]
	public string? ThumbnailUrl { get; init; }

	[JsonPropertyName("file_upload_identifier")]
	public string? FileUploadIdentifier { get; init; }
}
