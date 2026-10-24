using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record DiskUsageEvent(ulong NumberOfMediaAssetFiles, ulong BytesOfMediaAssetFiles, ulong BytesOfShowFiles, ulong BytesOfUnmanagedMediaAssetFiles) : IAnalyticEvent
{
	public static void Publish(ulong numberOfMediaAssetFiles, ulong bytesOfMediaAssetFiles, ulong bytesOfShowFiles, ulong bytesOfUnmanagedMediaAssetFiles)
	{
		EventPublisher.Publish(new DiskUsageEvent(numberOfMediaAssetFiles, bytesOfMediaAssetFiles, bytesOfShowFiles, bytesOfUnmanagedMediaAssetFiles));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupDiskUsage = new DiskUsage
			{
				NumberOfMediaAssetFiles = NumberOfMediaAssetFiles,
				BytesOfMediaAssetFiles = BytesOfMediaAssetFiles,
				BytesOfShowFiles = BytesOfShowFiles,
				BytesOfUnmanagedMediaAssetFiles = BytesOfUnmanagedMediaAssetFiles
			};
		});
	}
}
