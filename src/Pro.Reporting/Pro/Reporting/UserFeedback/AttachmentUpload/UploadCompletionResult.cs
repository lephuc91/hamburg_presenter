namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public record UploadCompletionResult(IAttachmentUploadJob Job, bool Successful);
