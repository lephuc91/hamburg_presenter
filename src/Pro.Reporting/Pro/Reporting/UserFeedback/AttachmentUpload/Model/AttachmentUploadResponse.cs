using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record AttachmentUploadResponse([property: JsonPropertyName("identifier")] string Identifier, [property: JsonPropertyName("upload_url")] string UploadUrl, [property: JsonPropertyName("view_url")] string ViewUrl, [property: JsonPropertyName("upload_headers")] List<UploadHeader> UploadHeaders);
