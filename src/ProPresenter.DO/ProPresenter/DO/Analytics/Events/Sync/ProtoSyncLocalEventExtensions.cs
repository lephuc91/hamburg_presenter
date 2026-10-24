using Pro.SerializationInterop.RVProtoData.Analytics.Sync;

namespace ProPresenter.DO.Analytics.Events.Sync;

public static class ProtoSyncLocalEventExtensions
{
	public static void Trigger(this Local sync, SyncLocalEvent @event)
	{
		sync.SyncType = @event.Type.ToSyncType();
		sync.IncludeLibrary = @event.IncludeLibrary;
		sync.IncludeMedia = @event.IncludeMedia;
		sync.IncludePlaylists = @event.IncludePlaylists;
		sync.IncludeThemes = @event.IncludeThemes;
		sync.IncludeSupportFiles = @event.IncludeSupportFiles;
		sync.ReplaceFiles = @event.ReplaceFiles;
	}

	private static Local.Types.Type ToSyncType(this SyncType type)
	{
		return type switch
		{
			SyncType.Up => Local.Types.Type.Up, 
			SyncType.Down => Local.Types.Type.Down, 
			_ => Local.Types.Type.Up, 
		};
	}
}
