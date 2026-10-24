using Pro.Common.FileSystem;
using Pro.Common.MessageService;

namespace ProPresenter.DO.Sync;

public class SyncMessage : IMessage
{
	public FileIOResult FileSyncResult { get; }

	public SyncMessage(FileIOResult result)
	{
		FileSyncResult = result;
	}
}
