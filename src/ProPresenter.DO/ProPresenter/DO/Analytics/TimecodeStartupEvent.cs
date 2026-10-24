using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Timecode;

namespace ProPresenter.DO.Analytics;

public record TimecodeStartupEvent(bool IsInputConfigured, bool IsEnabled, bool IsPlaylistSelected) : IAnalyticEvent
{
	public static void Publish(bool isConfigured, bool isEnabled, bool isPlaylistSelected)
	{
		EventPublisher.Publish(new TimecodeStartupEvent(isConfigured, isEnabled, isPlaylistSelected));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.TimecodeStartup = new Startup
			{
				IsEnabled = IsEnabled,
				IsInputConfigured = IsInputConfigured,
				IsPlaylistSelected = IsPlaylistSelected
			};
		});
	}
}
