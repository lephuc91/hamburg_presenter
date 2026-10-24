namespace ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;

public interface ICloudOnboardingAnalyticsEventPublisher
{
	void OnboardingFlowOutcome(OnboardingType onboardingType, OnboardingOutcome outcome);
}
