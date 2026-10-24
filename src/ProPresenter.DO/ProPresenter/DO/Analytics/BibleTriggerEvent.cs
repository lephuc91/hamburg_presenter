using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BibleTriggerEvent(BibleLocation Location) : IAnalyticEvent
{
	public static void Publish(BibleLocation location)
	{
		EventPublisher.Publish(new BibleTriggerEvent(location));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleTrigger = new BibleTrigger
			{
				Location = Location.ToProtoLocation()
			};
		});
	}
}
