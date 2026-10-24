using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record VideoInputStartUpEvent(uint InputCount) : IAnalyticEvent
{
	public static void Publish(uint inputCount)
	{
		EventPublisher.Publish(new VideoInputStartUpEvent(inputCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.VideoInputStartUp = new VideoInputStartUp
			{
				InputCount = InputCount
			};
		});
	}
}
