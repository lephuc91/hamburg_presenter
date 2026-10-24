namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;

public interface IMediaCleanupSizeEventPublisher
{
	void Publish(ulong bytesOfUnlinkedMediaFilesDeleted);
}
