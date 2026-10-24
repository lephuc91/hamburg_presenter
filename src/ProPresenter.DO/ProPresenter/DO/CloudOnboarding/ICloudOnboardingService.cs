using System;
using System.Threading.Tasks;
using ProPresenter.DO.CloudOnboarding.Model;

namespace ProPresenter.DO.CloudOnboarding;

public interface ICloudOnboardingService
{
	bool IsOnboardingInProgress { get; set; }

	IObservable<OnboardingUserState> WhenUserStateChanges { get; }

	PricingOptionsResponse? CachedPricingOptions { get; set; }

	bool ShouldShow();

	bool ShouldShowCloudTease();

	OnboardingUserState GetUserState();

	Task<(long workspaceSizeBytes, WorkspaceIssueFlags issues)> InspectWorkspaceAsync();

	Task<(bool success, PricingOptionsResponse? pricingOptions)> GetPricingOptionsAsync();

	Task<Guid?> ConvertToCloudAsync(WorkspaceIssueFlags remediation);

	void HandleDismissal(OnboardingUserState currentState, bool skipForNow);

	void HandleCloudTeaseDismissal(bool remindLater);
}
