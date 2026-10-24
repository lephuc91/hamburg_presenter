using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Pro.Common.Background;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_uploadQueueSubject", "_cancellationTokenSource", "_uploadQueue" })]
public sealed class AttachmentsUploader : IAttachmentsUploader, IBackgroundProcess, IDisposable
{
	private readonly LockingList<IAttachmentUploadJob> _uploadQueue = new LockingList<IAttachmentUploadJob>();

	private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

	private readonly BehaviorSubject<IReadOnlyList<IAttachmentUploadJob>> _uploadQueueSubject = new BehaviorSubject<IReadOnlyList<IAttachmentUploadJob>>(Array.Empty<IAttachmentUploadJob>());

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string InProgressMessageTitleStringKey => "USER_FEEDBACK_UPLOADS_IN_PROGRESS_ALERT_message";

	public string InProgressMessageMessageStringKey => "USER_FEEDBACK_UPLOADS_IN_PROGRESS_ALERT_info";

	public bool IsBusy => _uploadQueue.Count > 0;

	public IObservable<UploadProgress> WhenUploadProgressChanges { get; }

	public AttachmentsUploader()
	{
		WhenUploadProgressChanges = _uploadQueueSubject.Select(CalculateTotalProgress).Switch();
	}

	public void Enqueue(IAttachmentUploadJob job)
	{
		_uploadQueue.Add(job);
		_uploadQueueSubject.OnNext(_uploadQueue);
		job.StartUploading(_cancellationTokenSource.Token);
		job.WhenUploadFinished.Subscribe(CleanupJob);
	}

	private void CleanupJob(UploadCompletionResult result)
	{
		_uploadQueue.Remove(result.Job);
		_uploadQueueSubject.OnNext(_uploadQueue);
		result.Job.Dispose();
	}

	public void Stop()
	{
		Dispose();
	}

	private static IObservable<UploadProgress> CalculateTotalProgress(IReadOnlyList<IAttachmentUploadJob> uploadJobs)
	{
		if (uploadJobs.Count == 0)
		{
			return Observable.Return(UploadProgress.Empty);
		}
		return uploadJobs.Select((IAttachmentUploadJob j) => j.WhenUploadProgressChanged).CombineLatest((IList<UploadProgress> items) => items.Aggregate(UploadProgress.Empty, (UploadProgress accumulated, UploadProgress newValue) => accumulated + newValue));
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_uploadQueueSubject.Dispose();
			_cancellationTokenSource.Dispose();
			_uploadQueue.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_cancellationTokenSource.Cancel();
		foreach (IAttachmentUploadJob item in _uploadQueue)
		{
			item.Dispose();
		}
	}
}
