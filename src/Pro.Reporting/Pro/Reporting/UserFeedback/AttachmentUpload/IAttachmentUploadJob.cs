using System;
using System.Threading;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public interface IAttachmentUploadJob : IDisposable
{
	IObservable<UploadProgress> WhenUploadProgressChanged { get; }

	IObservable<UploadCompletionResult> WhenUploadFinished { get; }

	void StartUploading(CancellationToken cancellation = default(CancellationToken));

	UploadCompletionResult Upload();
}
