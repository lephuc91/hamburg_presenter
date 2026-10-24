using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingVM : ObservableObject, ICloudOnboardingVM, INotifyPropertyChanged, ICloudOnboardingShellNavigator
{
	private readonly ICloudOnboardingService _service;

	private readonly ICloudOnboardingAnalyticsEventPublisher _analytics;

	[ObservableProperty]
	private OnboardingUserState _userState;

	[ObservableProperty]
	private WorkspaceIssueFlags _issues;

	[ObservableProperty]
	private OnboardingStep _step;

	public OnboardingStep CurrentPage => Step;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OnboardingUserState UserState
	{
		get
		{
			return _userState;
		}
		set
		{
			if (!EqualityComparer<OnboardingUserState>.Default.Equals(_userState, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UserState);
				_userState = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UserState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public WorkspaceIssueFlags Issues
	{
		get
		{
			return _issues;
		}
		set
		{
			if (!EqualityComparer<WorkspaceIssueFlags>.Default.Equals(_issues, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Issues);
				_issues = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Issues);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OnboardingStep Step
	{
		get
		{
			return _step;
		}
		set
		{
			if (!EqualityComparer<OnboardingStep>.Default.Equals(_step, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Step);
				_step = value;
				OnStepChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Step);
			}
		}
	}

	public CloudOnboardingVM(ICloudOnboardingService service, ICloudOnboardingAnalyticsEventPublisher analytics)
	{
		_service = service;
		_analytics = analytics;
	}

	public void HandleNavigationIntent(OnboardingIntent intent, ICloseable closeable)
	{
		switch (Step)
		{
		case OnboardingStep.Eligibility:
			switch (intent)
			{
			case OnboardingIntent.Continue:
				Step = OnboardingStep.Pricing;
				break;
			case OnboardingIntent.Dismiss:
				PublishOnboardingOutcome(OnboardingOutcome.SkipForNow);
				Dismiss(closeable);
				break;
			}
			break;
		case OnboardingStep.Pricing:
			switch (intent)
			{
			case OnboardingIntent.Back:
				Step = OnboardingStep.Eligibility;
				break;
			case OnboardingIntent.Continue:
				PublishOnboardingOutcome(OnboardingOutcome.ContinueWithLocal);
				Step = OnboardingStep.LocalWorkspaces;
				break;
			case OnboardingIntent.Convert:
			{
				PublishOnboardingOutcome(OnboardingOutcome.CreateCloud);
				OnboardingStep step = ((Issues == WorkspaceIssueFlags.None) ? OnboardingStep.Done : OnboardingStep.ManageMedia);
				Step = step;
				break;
			}
			}
			break;
		case OnboardingStep.LocalWorkspaces:
			switch (intent)
			{
			case OnboardingIntent.Back:
				Step = OnboardingStep.Pricing;
				break;
			case OnboardingIntent.Continue:
				Dismiss(closeable);
				break;
			}
			break;
		case OnboardingStep.ManageMedia:
			switch (intent)
			{
			case OnboardingIntent.Back:
				Step = OnboardingStep.Pricing;
				break;
			case OnboardingIntent.Continue:
				Step = OnboardingStep.Done;
				break;
			}
			break;
		case OnboardingStep.Done:
			if (intent == OnboardingIntent.Dismiss)
			{
				Dismiss(closeable);
			}
			break;
		}
	}

	public void Initialize()
	{
		UserState = _service.GetUserState();
		_service.IsOnboardingInProgress = true;
		Step = OnboardingStep.Eligibility;
	}

	private void Dismiss(ICloseable closeable)
	{
		try
		{
			bool skipForNow = Step == OnboardingStep.Eligibility;
			_service.HandleDismissal(UserState, skipForNow);
		}
		finally
		{
			_service.IsOnboardingInProgress = false;
			closeable?.Close();
		}
	}

	private void PublishOnboardingOutcome(OnboardingOutcome outcome)
	{
		_analytics.OnboardingFlowOutcome(OnboardingType.NewToCloud, outcome);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnStepChanged(OnboardingStep value)
	{
		OnPropertyChanged("CurrentPage");
	}
}
