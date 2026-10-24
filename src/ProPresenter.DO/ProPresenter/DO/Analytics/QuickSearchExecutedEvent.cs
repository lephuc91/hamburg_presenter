using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record QuickSearchExecutedEvent(QuickSearchType Type) : IAnalyticEvent
{
	public static void Publish(QuickSearchType type)
	{
		EventPublisher.Publish(new QuickSearchExecutedEvent(type));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiQuicksearchSearch = new QuickSearchSearch
			{
				Source = Type.ToSearchSource()
			};
		});
	}
}
