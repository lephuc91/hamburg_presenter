using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

namespace ProPresenter.DO.Analytics;

public record TimelineTriggerCueEvent(TimelineTriggerCueType Type) : IAnalyticEvent
{
	public static void Publish(TimelineTriggerCueType type)
	{
		EventPublisher.Publish(new TimelineTriggerCueEvent(type));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			CueTrigger cueTrigger = new CueTrigger();
			CueTrigger cueTrigger2 = cueTrigger;
			cueTrigger2.TriggerType = Type switch
			{
				TimelineTriggerCueType.Slide => CueTrigger.Types.TriggerType.Slide, 
				TimelineTriggerCueType.Media => CueTrigger.Types.TriggerType.Media, 
				_ => CueTrigger.Types.TriggerType.Slide, 
			};
			e.TimelineCueTrigger = cueTrigger;
		});
	}
}
