using System;
using System.Linq;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.ViewModels.FeedbackCrash;

internal static class AttachmentsExtensions
{
	public static void Upload(this IUserAttachmentCollectionVM attachments, IAttachmentsUploader attachmentsUploader, IAttachmentUploadJobFactory attachmentUploadJobFactory)
	{
		foreach (IUserAttachment attachment in attachments)
		{
			IAttachmentUploadJob job = attachmentUploadJobFactory.CreateAttachmentUploadJob(new AttachmentUploadDefinition(attachment.FileName, new Uri(attachment.UploadUrl), attachment.FileSize, attachment.UploadHeaders.ToDictionary((UploadHeader t) => t.Key, (UploadHeader t) => t.Value)));
			attachmentsUploader.Enqueue(job);
		}
	}
}
