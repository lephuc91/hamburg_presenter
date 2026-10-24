using Pro.Common.MessageService;

namespace Pro.Common.Downloads.CompletedMessages;

public class DownloadCompletedMessage : IMessage
{
	public string FullFilePath { get; }

	public DownloadCompletedMessage(string filename)
	{
		FullFilePath = filename;
	}
}
