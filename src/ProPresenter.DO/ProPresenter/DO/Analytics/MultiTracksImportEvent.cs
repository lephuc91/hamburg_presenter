using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;
using ProPresenter.DO.MultiTracks;

namespace ProPresenter.DO.Analytics;

public record MultiTracksImportEvent(MultiTracksSubscriptionStatus ChartProStatus, MultiTracksSubscriptionStatus SlideProStatus, bool UsingChords, int LineCount) : IAnalyticEvent
{
	public static void Publish(MultiTracksSubscriptionStatus chartProStatus, MultiTracksSubscriptionStatus slideProStatus, bool usingChords, int lineCount)
	{
		EventPublisher.Publish(new MultiTracksImportEvent(chartProStatus, slideProStatus, usingChords, lineCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ImportMultitracks = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import
			{
				ChartPro = ChartProStatus.ToMultiTracksAccountStatus(),
				PropresenterAddon = SlideProStatus.ToMultiTracksAccountStatus(),
				ChartsAutomation = UsingChords,
				Lines = LineCount
			};
		});
	}
}
