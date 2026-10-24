using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Timer;

public record TimersStateEvent(TimerEventState State) : IAnalyticEvent
{
	public static void Publish(TimerEventState state)
	{
		EventPublisher.Publish(new TimersStateEvent(state));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightTimersState = new LowerRightTimersState
			{
				State = State.ToProtoState()
			};
		});
	}
}
