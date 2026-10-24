using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;
using ProPresenter.DO.MultiTracks;

namespace ProPresenter.DO.Analytics;

public record StartupMultiTracksEvent(MultiTracksSubscriptionStatus ChartProStatus, MultiTracksSubscriptionStatus SlideProStatus) : IAnalyticEvent
{
	public static void Publish(MultiTracksSubscriptionStatus chartProStatus, MultiTracksSubscriptionStatus slideProStatus)
	{
		EventPublisher.Publish(new StartupMultiTracksEvent(chartProStatus, slideProStatus));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupMultitracks = new Startup
			{
				ChartPro = ChartProStatus.ToMultiTracksAccountStatus(),
				PropresenterAddon = SlideProStatus.ToMultiTracksAccountStatus()
			};
		});
	}
}
