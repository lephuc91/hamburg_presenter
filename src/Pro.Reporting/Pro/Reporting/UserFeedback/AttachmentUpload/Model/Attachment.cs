using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record Attachment([property: JsonPropertyName("metadata")] AttachmentMetadata metadata, [property: JsonPropertyName("identifier")] string identifier);
