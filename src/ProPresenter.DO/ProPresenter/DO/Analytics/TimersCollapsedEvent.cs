using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record TimersCollapsedEvent(CollapseState State) : IAnalyticEvent
{
	public static void Publish(CollapseState collapsed)
	{
		EventPublisher.Publish(new TimersCollapsedEvent(collapsed));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightTimersCollapse = new LowerRightTimersCollapse
			{
				State = State.ToProtoCollapseState()
			};
		});
	}
}
