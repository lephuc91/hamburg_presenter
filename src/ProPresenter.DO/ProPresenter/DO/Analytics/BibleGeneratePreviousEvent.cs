using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BibleGeneratePreviousEvent(BibleLocation Location) : IAnalyticEvent
{
	public static void Publish(BibleLocation location)
	{
		EventPublisher.Publish(new BibleGeneratePreviousEvent(location));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleGeneratePrevious = new BibleGenerateNext
			{
				Location = Location.ToProtoLocation()
			};
		});
	}
}
