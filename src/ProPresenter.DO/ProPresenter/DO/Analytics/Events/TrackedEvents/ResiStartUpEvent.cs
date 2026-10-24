using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record ResiStartUpEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new ResiStartUpEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ResiStartUp = new ResiStartUp();
		});
	}
}
