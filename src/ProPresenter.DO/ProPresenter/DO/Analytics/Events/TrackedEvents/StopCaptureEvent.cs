using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record StopCaptureEvent(double Duration, int DroppedFrames, double PercentDroppedFrames) : IAnalyticEvent
{
	public static void Publish(double duration, int droppedFrames, double percentDroppedFrames)
	{
		EventPublisher.Publish(new StopCaptureEvent(duration, droppedFrames, percentDroppedFrames));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StopCapture = new StopCapture
			{
				Duration = Duration,
				DroppedFrames = DroppedFrames,
				PercentDroppedFrames = PercentDroppedFrames
			};
		});
	}
}
