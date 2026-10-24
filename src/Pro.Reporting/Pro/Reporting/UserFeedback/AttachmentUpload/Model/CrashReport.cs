using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record CrashReport([property: JsonPropertyName("email")] string Email, [property: JsonPropertyName("hardwareId")] string HardwareId, [property: JsonPropertyName("activationKey")] string ActivationKey, [property: JsonPropertyName("ticketId")] string TicketId, [property: JsonPropertyName("description")] string Description, [property: JsonPropertyName("externalAttachments")] List<Attachment> ExternalAttachments, [property: JsonPropertyName("name")] string Name);
