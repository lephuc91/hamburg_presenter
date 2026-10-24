using System;
using Pro.Common.Background;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public interface IAttachmentsUploader : IBackgroundProcess
{
	IObservable<UploadProgress> WhenUploadProgressChanges { get; }

	void Enqueue(IAttachmentUploadJob job);
}
