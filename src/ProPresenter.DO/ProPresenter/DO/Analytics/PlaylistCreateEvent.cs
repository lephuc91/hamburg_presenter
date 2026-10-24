using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public record PlaylistCreateEvent(PlaylistCreateSource Source, PlaylistCreateType Type) : IAnalyticEvent
{
	public static void Publish(PlaylistCreateSource source, PlaylistCreateType type)
	{
		EventPublisher.Publish(new PlaylistCreateEvent(source, type));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.CreatePlaylist = new Playlist
			{
				Source = Source.ToProto(),
				Type = Type.ToProto()
			};
		});
	}
}
