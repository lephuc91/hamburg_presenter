using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;

public record MediaCleanupSizeEvent(ulong BytesOfUnlinkedMediaFilesDeleted) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaCleanupSize = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.MediaCleanupSize
			{
				BytesOfMediaFilesCleanedUp = BytesOfUnlinkedMediaFilesDeleted
			};
		});
	}
}
