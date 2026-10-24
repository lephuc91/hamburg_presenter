using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

namespace ProPresenter.DO.Analytics;

public record TimelineActionEvent(TimelineActionType Type) : IAnalyticEvent
{
	public static void Publish(TimelineActionType type)
	{
		EventPublisher.Publish(new TimelineActionEvent(type));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			Action action = new Action();
			Action action2 = action;
			action2.ActionType = Type switch
			{
				TimelineActionType.Play => Action.Types.ActionType.Play, 
				TimelineActionType.Stop => Action.Types.ActionType.Stop, 
				TimelineActionType.Reset => Action.Types.ActionType.Reset, 
				_ => Action.Types.ActionType.Reset, 
			};
			e.TimelineAction = action;
		});
	}
}
