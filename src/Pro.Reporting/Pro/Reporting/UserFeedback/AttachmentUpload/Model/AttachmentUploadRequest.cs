using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record AttachmentUploadRequest([property: JsonPropertyName("metadata")] AttachmentMetadata Metadata, [property: JsonPropertyName("skipTicketAssociation")] bool SkipTicketAssociation = false);
