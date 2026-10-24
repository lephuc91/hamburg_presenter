using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;
using ProPresenter.DO.MultiTracks;

namespace ProPresenter.DO.Analytics;

public static class ProtoMultiTracksEventExtensions
{
	public static Status ToMultiTracksAccountStatus(this MultiTracksSubscriptionStatus subscriptionStatus)
	{
		return subscriptionStatus switch
		{
			MultiTracksSubscriptionStatus.Disabled => Status.Disabled, 
			MultiTracksSubscriptionStatus.Canceled => Status.Cancelled, 
			MultiTracksSubscriptionStatus.Active => Status.Active, 
			_ => Status.Cancelled, 
		};
	}
}
