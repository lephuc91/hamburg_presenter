using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ProtoPreviewAreaExtensions
{
	public static Event Serialize(this PreviewAreaClearGroupTriggerEvent @event)
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiPreviewAreaClearGroupsTrigger = new PreviewAreaClearGroupsTrigger();
		});
	}

	public static Event Serialize(this PreviewAreaClearGroupChangedEvent @event)
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiPreviewAreaClearGroupsChanged = new PreviewAreaClearGroupsChanged
			{
				Count = @event.Count
			};
		});
	}
}
