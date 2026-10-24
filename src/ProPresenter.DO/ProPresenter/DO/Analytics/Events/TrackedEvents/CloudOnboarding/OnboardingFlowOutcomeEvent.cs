using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;

public record OnboardingFlowOutcomeEvent(OnboardingType OnboardingType, OnboardingOutcome Outcome) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.OnboardingFlowOutcome = new OnboardingFlowOutcome
			{
				OnboardingType = (OnboardingFlowOutcome.Types.OnboardingType)OnboardingType,
				Result = (OnboardingFlowOutcome.Types.Result)Outcome
			};
		});
	}
}
