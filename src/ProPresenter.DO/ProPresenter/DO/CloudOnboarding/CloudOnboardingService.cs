using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.FeatureFlag;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using ProPresenter.DO.CloudOnboarding.Model;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.CloudOnboarding;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public sealed class CloudOnboardingService : ICloudOnboardingService, IDisposable
{
	private readonly IFlagService _flagService;

	private readonly IApp _app;

	private readonly IRegistrationStateProvider _registration;

	private readonly IInternetAccessCheck _internet;

	private readonly IWorkspaceService _workspaces;

	private readonly IWorkspaceInspectionService _inspection;

	private readonly IProContentConsumer _proContentConsumer;

	private readonly ICloudConversionService _conversion;

	private readonly ILocalization _localization;

	private readonly ILogger _logger;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<OnboardingUserState> WhenUserStateChanges { get; }

	public bool IsOnboardingInProgress { get; set; }

	public PricingOptionsResponse? CachedPricingOptions { get; set; }

	public CloudOnboardingService(IFlagService flagService, IApp app, IRegistrationStateProvider registration, IInternetAccessCheck internet, IWorkspaceService workspaces, IWorkspaceInspectionService inspection, IProContentConsumer proContentConsumer, ICloudConversionService conversion, ILocalization localization, ILogger logger)
	{
		_flagService = flagService;
		_app = app;
		_registration = registration;
		_internet = internet;
		_workspaces = workspaces;
		_inspection = inspection;
		_proContentConsumer = proContentConsumer;
		_conversion = conversion;
		_localization = localization;
		_logger = logger;
		IObservable<OnboardingUserState> first = from e in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler h)
			{
				_registration.PropertyChanged += h;
			}, delegate(PropertyChangedEventHandler h)
			{
				_registration.PropertyChanged -= h;
			})
			where e.EventArgs.PropertyName == "Registration"
			select e into _
			select GetUserState();
		IObservable<OnboardingUserState> second = _internet.WhenIsAvailableChanged.Select((bool _) => GetUserState());
		WhenUserStateChanges = first.Merge(second).StartWith(GetUserState()).DistinctUntilChanged();
	}

	public bool ShouldShow()
	{
		if (!_flagService.IsFlagEnabled(Flag.Cloud))
		{
			return false;
		}
		if (_app.IsFirstLaunch)
		{
			return false;
		}
		if (_app.HasSeenOnboarding)
		{
			return false;
		}
		_app.HasSeenOnboarding = true;
		return true;
	}

	public bool ShouldShowCloudTease()
	{
		if (_flagService.IsFlagEnabled(Flag.CloudComingSoon))
		{
			return !_app.CloudTeaseDismissed;
		}
		return false;
	}

	public void HandleCloudTeaseDismissal(bool remindLater)
	{
		if (remindLater)
		{
			_app.CloudTeaseDismissed = false;
			_logger.Info("Cloud tease dismissed with 'Remind Me Later' - will show again on next launch");
		}
		else
		{
			_app.CloudTeaseDismissed = true;
			_logger.Info("Cloud tease dismissed permanently");
		}
	}

	public OnboardingUserState GetUserState()
	{
		if (!_internet.Available())
		{
			return OnboardingUserState.NoNetwork;
		}
		ISubscriptionState subscriptionState = _registration.Registration?.SubscriptionState;
		if (!(subscriptionState is UnsubscribedState))
		{
			if (subscriptionState is SubscribedState)
			{
				return OnboardingUserState.SignedInWithActiveSubscription;
			}
			return OnboardingUserState.SignedOut;
		}
		return OnboardingUserState.SignedOut;
	}

	public void HandleDismissal(OnboardingUserState currentState, bool skipForNow)
	{
		bool num = currentState == OnboardingUserState.NoNetwork || skipForNow;
		if (num)
		{
			_app.HasSeenOnboarding = false;
		}
		CachedPricingOptions = null;
		string text = ((currentState == OnboardingUserState.NoNetwork) ? "no network" : (skipForNow ? $"skip for now (state {currentState})" : $"completed (state {currentState})"));
		string text2 = (num ? " - HasSeenOnboarding reset to false" : "");
		_logger.Info("Cloud onboarding dismissed due to " + text + text2);
	}

	public async Task<(long workspaceSizeBytes, WorkspaceIssueFlags issues)> InspectWorkspaceAsync()
	{
		IWorkspace workspace = _workspaces.Workspaces.First((IWorkspace w) => w.Active);
		long size = await _workspaces.GetWorkspaceSizeBytesAsync(workspace).ConfigureAwait(continueOnCapturedContext: false);
		WorkspaceIssueFlags workspaceIssueFlags = await _inspection.DetectIssuesAsync().ConfigureAwait(continueOnCapturedContext: false);
		_logger.Info($"Inspected workspace : size={size} bytes, issues={workspaceIssueFlags}");
		return (workspaceSizeBytes: size, issues: workspaceIssueFlags);
	}

	public async Task<(bool success, PricingOptionsResponse? pricingOptions)> GetPricingOptionsAsync()
	{
		_ = 1;
		try
		{
			bool result = true;
			if (CachedPricingOptions != null)
			{
				_logger.Info("Returning cached pricing options");
				return (success: true, pricingOptions: CachedPricingOptions);
			}
			_logger.Info("Fetching pricing options from API");
			long item = (await InspectWorkspaceAsync().ConfigureAwait(continueOnCapturedContext: false)).Item1;
			string twoLetterISOLanguageName = _localization.LoadedCulture.TwoLetterISOLanguageName;
			PricingOptionsResponse pricingOptionsResponse2 = (CachedPricingOptions = await _proContentConsumer.GetPricingOptionsAsync(item, twoLetterISOLanguageName).ConfigureAwait(continueOnCapturedContext: false));
			if (pricingOptionsResponse2 == null)
			{
				result = false;
			}
			return (success: result, pricingOptions: pricingOptionsResponse2);
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to fetch pricing options", ex);
			return (success: false, pricingOptions: null);
		}
	}

	public Task<Guid?> ConvertToCloudAsync(WorkspaceIssueFlags remediation)
	{
		return _conversion.ConvertToCloudAsync(remediation);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
		}
	}
}
