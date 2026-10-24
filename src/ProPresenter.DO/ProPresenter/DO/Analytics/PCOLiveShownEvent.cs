using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record PCOLiveShownEvent(PCOLiveShownWindowMode WindowMode) : IAnalyticEvent
{
	public static void Publish(PCOLiveShownWindowMode windowMode)
	{
		EventPublisher.Publish(new PCOLiveShownEvent(windowMode));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiPlanningCenterLive = new PlanningCenterLive
			{
				WindowType = WindowMode.ToProto()
			};
		});
	}
}
