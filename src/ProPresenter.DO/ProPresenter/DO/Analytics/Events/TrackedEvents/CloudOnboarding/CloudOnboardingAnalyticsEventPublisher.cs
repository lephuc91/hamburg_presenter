using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;

public class CloudOnboardingAnalyticsEventPublisher : ICloudOnboardingAnalyticsEventPublisher
{
	public void OnboardingFlowOutcome(OnboardingType onboardingType, OnboardingOutcome outcome)
	{
		EventPublisher.Publish(new OnboardingFlowOutcomeEvent(onboardingType, outcome));
	}
}
