using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record PlaceholderLinkEvent(PlaceholderLinkType Type, PlaceholderLinkSource Source) : IAnalyticEvent
{
	public static void Publish(PlaceholderLinkType type, PlaceholderLinkSource source)
	{
		EventPublisher.Publish(new PlaceholderLinkEvent(type, source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiPlaceholderLink = new PlaceholderLink
			{
				LinkType = Type.ToProto(),
				LinkSource = Source.ToProto()
			};
		});
	}
}
