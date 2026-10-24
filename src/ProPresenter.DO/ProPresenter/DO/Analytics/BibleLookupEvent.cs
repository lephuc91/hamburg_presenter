using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BibleLookupEvent(BibleLookupLocation Location) : IAnalyticEvent
{
	public static void Publish(BibleLookupLocation location)
	{
		EventPublisher.Publish(new BibleLookupEvent(location));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleLookup = new BibleLookup
			{
				Location = Location.ToProtoBibleLookupLocation()
			};
		});
	}
}
