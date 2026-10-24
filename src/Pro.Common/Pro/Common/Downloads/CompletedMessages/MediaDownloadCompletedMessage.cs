namespace Pro.Common.Downloads.CompletedMessages;

public class MediaDownloadCompletedMessage<T> : DownloadCompletedMessage where T : class
{
	public T? Target { get; }

	public MediaDownloadTarget TargetType { get; }

	public MediaDownloadCompletedMessage(string filename, T? target, MediaDownloadTarget targetType = MediaDownloadTarget.MediaBin)
		: base(filename)
	{
		Target = target;
		TargetType = targetType;
	}
}
