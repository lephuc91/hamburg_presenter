using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace Pro.DO.Analytics.Events;

public record AudioSettingsSdiNdiStateEvent(uint BusCount) : IAnalyticEvent
{
	public static void Publish(uint busCount)
	{
		EventPublisher.Publish(new AudioSettingsSdiNdiStateEvent(busCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioSettingsSdiNdiState = new AudioSettingsSdiNdiState
			{
				BusCount = BusCount
			};
		});
	}
}
