using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;

namespace Pro.CoreApplication.FeatureFlag.CoreInteraction;

public class CoreFeatureFlagService : ICoreFeatureFlagService
{
	private readonly nint _coreInstance;

	private readonly ISubscriptionDisposer _disposer;

	public CoreFeatureFlagService(nint instancePointer, ISubscriptionDisposer subscriptionDisposer)
	{
		_coreInstance = instancePointer;
		_disposer = subscriptionDisposer;
	}

	public ICoreFeatureFlagSubscription Subscribe(ILogger logger)
	{
		CoreFeatureFlagSubscription coreFeatureFlagSubscription = new CoreFeatureFlagSubscription(_coreInstance, logger);
		_disposer.RegisterSubscription(coreFeatureFlagSubscription);
		return coreFeatureFlagSubscription;
	}
}
