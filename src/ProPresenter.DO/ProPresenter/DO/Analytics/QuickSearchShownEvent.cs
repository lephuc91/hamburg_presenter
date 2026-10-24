using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record QuickSearchShownEvent(QuickSearchShownSource Source) : IAnalyticEvent
{
	public static void Publish(QuickSearchShownSource source)
	{
		EventPublisher.Publish(new QuickSearchShownEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiQuicksearch = new QuickSearchShown
			{
				Source = Source.ToProto()
			};
		});
	}
}
