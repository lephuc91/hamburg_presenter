using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record WhatsNewViewedEvent(string Version, int ViewTime) : IAnalyticEvent
{
	public static void Publish(string version, int viewTime)
	{
		EventPublisher.Publish(new WhatsNewViewedEvent(version, viewTime));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiWhatsNewViewed = new WhatsNewViewed
			{
				Version = (Version ?? string.Empty),
				ViewTime = ViewTime
			};
		});
	}
}
