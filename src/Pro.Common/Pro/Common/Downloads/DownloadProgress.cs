namespace Pro.Common.Downloads;

public record struct DownloadProgress(DownloadStatus Status, int PercentComplete = 0, long ReceivedBytes = 0L, long TotalBytes = 0L, long BytesPerSecond = 0L)
{
	public static DownloadProgress Empty => new DownloadProgress(DownloadStatus.Completed, 0, 0L, 0L, 0L);
}
