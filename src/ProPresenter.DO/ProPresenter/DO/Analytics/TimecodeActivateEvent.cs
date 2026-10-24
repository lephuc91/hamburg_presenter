using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Timecode;

namespace ProPresenter.DO.Analytics;

public record TimecodeActivateEvent(int PlaylistItemCount, int CueCount, bool IsStartup) : IAnalyticEvent
{
	public static void Publish(int playlistItemCount, int cueCount, bool isStartup)
	{
		EventPublisher.Publish(new TimecodeActivateEvent(playlistItemCount, cueCount, isStartup));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.TimecodeActivate = new Activate
			{
				PlaylistItemCount = PlaylistItemCount,
				CueCount = CueCount,
				IsStartup = IsStartup
			};
		});
	}
}
