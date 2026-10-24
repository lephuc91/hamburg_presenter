using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record VideoInputCustomMapEvent(bool IsCustomMap) : IAnalyticEvent
{
	public static void Publish(bool IsCustomMap)
	{
		EventPublisher.Publish(new VideoInputCustomMapEvent(IsCustomMap));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.VideoInputCustomMap = new VideoInputCustomMap
			{
				Value = IsCustomMap
			};
		});
	}
}
