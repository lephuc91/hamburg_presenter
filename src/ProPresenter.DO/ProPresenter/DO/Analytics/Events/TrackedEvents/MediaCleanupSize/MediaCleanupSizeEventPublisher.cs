using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;

public class MediaCleanupSizeEventPublisher : IMediaCleanupSizeEventPublisher
{
	public void Publish(ulong bytesOfUnlinkedMediaFilesDeleted)
	{
		EventPublisher.Publish(new MediaCleanupSizeEvent(bytesOfUnlinkedMediaFilesDeleted));
	}
}
