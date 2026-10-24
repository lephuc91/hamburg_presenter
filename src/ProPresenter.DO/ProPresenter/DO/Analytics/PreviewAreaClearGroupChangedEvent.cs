using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record PreviewAreaClearGroupChangedEvent(int Count) : IAnalyticEvent
{
	public static void Publish(int count)
	{
		EventPublisher.Publish(new PreviewAreaClearGroupChangedEvent(count));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiPreviewAreaClearGroupsChanged = new PreviewAreaClearGroupsChanged
			{
				Count = Count
			};
		});
	}
}
