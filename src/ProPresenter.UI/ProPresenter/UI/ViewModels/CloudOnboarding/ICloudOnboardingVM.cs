using System.ComponentModel;
using ProPresenter.DO.CloudOnboarding;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingVM : INotifyPropertyChanged
{
	OnboardingUserState UserState { get; }

	WorkspaceIssueFlags Issues { get; set; }

	OnboardingStep Step { get; }

	void Initialize();
}
