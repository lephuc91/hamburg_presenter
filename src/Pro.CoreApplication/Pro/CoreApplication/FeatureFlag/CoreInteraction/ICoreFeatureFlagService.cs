using Pro.Common.Logging;

namespace Pro.CoreApplication.FeatureFlag.CoreInteraction;

public interface ICoreFeatureFlagService
{
	ICoreFeatureFlagSubscription Subscribe(ILogger logger);
}
