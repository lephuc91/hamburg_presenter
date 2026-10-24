using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupSongSelectEvent(bool IsLoggedIn) : IAnalyticEvent
{
	public static void Publish(bool isLoggedIn)
	{
		EventPublisher.Publish(new StartupSongSelectEvent(isLoggedIn));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupSongselect = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect
			{
				LoggedIn = IsLoggedIn
			};
		});
	}
}
