using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;

namespace ProPresenter.DO.Analytics.Events.Sync;

public record SyncLocalEvent(SyncType Type, bool IncludeLibrary, bool IncludeMedia, bool IncludePlaylists, bool IncludeThemes, bool IncludeSupportFiles, bool ReplaceFiles) : IAnalyticEvent
{
	public static void Publish(SyncType type, bool includeLibrary, bool includeMedia, bool includePlaylists, bool includeThemes, bool includeSupportFiles, bool replaceFiles)
	{
		EventPublisher.Publish(new SyncLocalEvent(type, includeLibrary, includeMedia, includePlaylists, includeThemes, includeSupportFiles, replaceFiles));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.Sync().Trigger(this);
		});
	}
}
