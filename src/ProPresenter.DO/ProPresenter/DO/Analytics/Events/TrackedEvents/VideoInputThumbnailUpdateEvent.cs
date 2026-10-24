using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record VideoInputThumbnailUpdateEvent(ThumbnailUpdateType updateType) : IAnalyticEvent
{
	public enum ThumbnailUpdateType
	{
		Capture,
		Disk,
		Reset
	}

	private static VideoInputThumbnailUpdate.Types.UpdateType TranslateEnumToProtoEnum(ThumbnailUpdateType updateType)
	{
		return updateType switch
		{
			ThumbnailUpdateType.Capture => VideoInputThumbnailUpdate.Types.UpdateType.Capture, 
			ThumbnailUpdateType.Disk => VideoInputThumbnailUpdate.Types.UpdateType.Disk, 
			ThumbnailUpdateType.Reset => VideoInputThumbnailUpdate.Types.UpdateType.Reset, 
			_ => VideoInputThumbnailUpdate.Types.UpdateType.Capture, 
		};
	}

	public static void Publish(ThumbnailUpdateType updateType)
	{
		EventPublisher.Publish(new VideoInputThumbnailUpdateEvent(updateType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.VideoInputThumbnailUpdate = new VideoInputThumbnailUpdate
			{
				Type = TranslateEnumToProtoEnum(updateType)
			};
		});
	}
}
