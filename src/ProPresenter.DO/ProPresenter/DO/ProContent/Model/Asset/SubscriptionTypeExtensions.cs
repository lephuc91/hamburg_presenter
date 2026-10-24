using ProPresenter.DO.ProContent.Consumer.Model.Content;

namespace ProPresenter.DO.ProContent.Model.Asset;

public static class SubscriptionTypeExtensions
{
	public static SubscriptionType ToModelSubscriptionType(this ProPresenter.DO.ProContent.Consumer.Model.Content.SubscriptionType subscriptionType)
	{
		return subscriptionType switch
		{
			ProPresenter.DO.ProContent.Consumer.Model.Content.SubscriptionType.Free => SubscriptionType.Free, 
			ProPresenter.DO.ProContent.Consumer.Model.Content.SubscriptionType.Premium => SubscriptionType.Premium, 
			_ => SubscriptionType.Premium, 
		};
	}
}
