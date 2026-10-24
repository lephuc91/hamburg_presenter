using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record QuickSearchImportEvent(int Count, QuickSearchType Source, QuickSearchStyle Style) : IAnalyticEvent
{
	public static void Publish(int count, QuickSearchType source, QuickSearchStyle style)
	{
		EventPublisher.Publish(new QuickSearchImportEvent(count, source, style));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiQuicksearchOpenitems = new QuickSearchOpenItems
			{
				Source = Source.ToOpenItemSource(),
				Style = Style.ToSearchStyle(),
				Count = Count
			};
		});
	}
}
