using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record AttachmentMetadata([property: JsonPropertyName("filename")] string Filename, [property: JsonPropertyName("sha256Hash")] string sha256Hash, [property: JsonPropertyName("filesize")] long Filesize);
