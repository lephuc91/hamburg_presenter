using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record FeedbackReport([property: JsonPropertyName("email")] string Email, [property: JsonPropertyName("hardwareId")] string HardwareId, [property: JsonPropertyName("activationKey")] string ActivationKey, [property: JsonPropertyName("description")] string Description, [property: JsonPropertyName("externalAttachments")] List<Attachment> ExternalAttachments, [property: JsonPropertyName("typeOfRequest")] string TypeOfRequest, [property: JsonPropertyName("subject")] string Subject, [property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("ticketId")] string TicketId, [property: JsonPropertyName("isInternal")] bool IsInternal);
