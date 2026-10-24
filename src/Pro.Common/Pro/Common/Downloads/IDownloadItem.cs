using System;
using System.Threading.Tasks;

namespace Pro.Common.Downloads;

public interface IDownloadItem : IDisposable
{
	IObservable<string> WhenNameChanged { get; }

	IObservable<Uri> WhenThumbnailUrlChanged { get; }

	IObservable<DownloadProgress> WhenDownloadProgressChanged { get; }

	IObservable<string> WhenFileDestinationChanged { get; }

	DownloadStatus Status { get; }

	void Download();

	void Cancel();

	Task CompleteAndCleanupAsync(bool requestCleanup);

	void Retry();

	bool CanRetry();
}
