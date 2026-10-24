using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

namespace ProPresenter.DO.Analytics;

public record TimelineRecordCueEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new TimelineRecordCueEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.TimelineRecordCue = new RecordCue();
		});
	}
}
