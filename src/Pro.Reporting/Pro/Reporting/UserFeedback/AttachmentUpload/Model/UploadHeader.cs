using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record UploadHeader([property: JsonPropertyName("key")] string Key, [property: JsonPropertyName("value")] string Value);
