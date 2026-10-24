using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record AttachmentLimit([property: JsonPropertyName("extension")] string Extension, [property: JsonPropertyName("sizeLimit")] int SizeLimit, [property: JsonPropertyName("maxQuantity")] int MaxQuantity);
