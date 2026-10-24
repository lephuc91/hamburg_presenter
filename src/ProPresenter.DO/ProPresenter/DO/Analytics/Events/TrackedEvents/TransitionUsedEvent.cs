using System;
using Google.Protobuf;
using Pro.Common.Mathematics;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record TransitionUsedEvent(TimeSpan Duration) : IAnalyticEvent
{
	public static void Publish(TimeSpan duration)
	{
		EventPublisher.Publish(new TransitionUsedEvent(duration));
	}

	public IMessage Serialize()
	{
		uint totalSeconds = (uint)Math.Round(Duration.TotalSeconds.Clamp(0.0, 4294967295.0));
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.TransitionWindow = new TransitionWindow
			{
				DurationSeconds = totalSeconds
			};
		});
	}
}
