using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;
using ProPresenter.DO.MultiTracks;

namespace ProPresenter.DO.Analytics.Events.Startup;

public static class ProtoStartupEventExtensions
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
