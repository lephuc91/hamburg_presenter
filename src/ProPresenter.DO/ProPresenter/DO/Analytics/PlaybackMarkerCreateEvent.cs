using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.PlaybackMarker;

namespace ProPresenter.DO.Analytics;

public record PlaybackMarkerCreateEvent(PlaybackMarkerCreateLocation Location) : IAnalyticEvent
{
	public static void Publish(PlaybackMarkerCreateLocation location)
	{
		EventPublisher.Publish(new PlaybackMarkerCreateEvent(location));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.PlaybackMarker = new CreateMarker
			{
				Location = Location.ToProtoPlaybackMarkerCreateLocation()
			};
		});
	}
}
