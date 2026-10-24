using System;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.CoreApplication.Workspace;

public static class ISyncStatusExtensions
{
	public static ISyncStatus ToSyncStatus(this Notification.Types.Syncing proto)
	{
		if (proto.Paused == null)
		{
			return new ActiveSync();
		}
		return new PausedSync(DateTimeOffset.FromUnixTimeSeconds((long)proto.Paused.UntilTimeUtc), DateTimeOffset.FromUnixTimeSeconds((long)proto.Paused.AtTimeUtc));
	}
}
