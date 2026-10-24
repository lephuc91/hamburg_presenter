using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record CueTriggeredEvent(double delay) : IAnalyticEvent
{
	public static void Publish(double delay)
	{
		EventPublisher.Publish(new CueTriggeredEvent(delay));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.CueTriggered = new CueTriggered
			{
				TriggerDelay = delay
			};
		});
	}
}
