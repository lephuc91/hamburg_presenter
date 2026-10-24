using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BibleSaveSlidesEvent(BibleSlideDestination Destination) : IAnalyticEvent
{
	public static void Publish(BibleSlideDestination destination)
	{
		EventPublisher.Publish(new BibleSaveSlidesEvent(destination));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.BibleSaveSlides = new BibleSaveSlides
			{
				Destination = Destination.ToProtoBibleSlideDestination()
			};
		});
	}
}
