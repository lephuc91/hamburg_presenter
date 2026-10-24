namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public interface IAttachmentUploadJobFactory
{
	IAttachmentUploadJob CreateAttachmentUploadJob(AttachmentUploadDefinition uploadDefinition, int numberOfRetries = 3, int timeoutSeconds = 300);
}
