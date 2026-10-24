using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record RemoteStreamStopEvent(bool Success) : IAnalyticEvent
{
	public static void Publish(bool result)
	{
		EventPublisher.Publish(new RemoteStreamStopEvent(result));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.RemoteStreamStop = new RemoteStreamStop
			{
				Success = Success
			};
		});
	}
}
