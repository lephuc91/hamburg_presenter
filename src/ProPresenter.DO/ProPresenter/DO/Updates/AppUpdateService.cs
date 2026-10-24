using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Background;
using Pro.Common.Internet;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Updates;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_periodicUpdatePoll" })]
public class AppUpdateService : ObservableObject, IAppUpdateService, INotifyPropertyChanged, IDisposable
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("UpdateChannel", "InitiateCheckForUpgradesAfterChannelChange")]
	private readonly IApp _app;

	private readonly IAppDownloadFactory _appDownloadFactory;

	private readonly IAppUpdateUserDialogService _appUpdateUserDialogService;

	private readonly IInternetAccessCheck _internetAccessCheck;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IPeriodicTimer _periodicUpdatePoll;

	private bool _isNonProductionActive;

	private int _unavailableCount;

	private int _numberOfUpdatesAvailableIncludingPurchase;

	[ObservableProperty]
	private BuildInformation? _buildAvailable;

	[ObservableProperty]
	private BuildInformation? _betaBuildAvailable;

	[ObservableProperty]
	private BuildInformation? _releaseBuildAvailable;

	[ObservableProperty]
	private BuildInformation? _betaBuildAvailableForPurchase;

	[ObservableProperty]
	private BuildInformation? _releaseBuildAvailableForPurchase;

	[ObservableProperty]
	private string _releaseNotes = string.Empty;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private bool IsUsingBetaChannel => _app.UpdateChannel == UpdateChannel.Beta;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BuildInformation? BuildAvailable
	{
		get
		{
			return _buildAvailable;
		}
		set
		{
			if (!EqualityComparer<BuildInformation>.Default.Equals(_buildAvailable, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BuildAvailable);
				_buildAvailable = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BuildAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BuildInformation? BetaBuildAvailable
	{
		get
		{
			return _betaBuildAvailable;
		}
		set
		{
			if (!EqualityComparer<BuildInformation>.Default.Equals(_betaBuildAvailable, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BetaBuildAvailable);
				_betaBuildAvailable = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BetaBuildAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BuildInformation? ReleaseBuildAvailable
	{
		get
		{
			return _releaseBuildAvailable;
		}
		set
		{
			if (!EqualityComparer<BuildInformation>.Default.Equals(_releaseBuildAvailable, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ReleaseBuildAvailable);
				_releaseBuildAvailable = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ReleaseBuildAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BuildInformation? BetaBuildAvailableForPurchase
	{
		get
		{
			return _betaBuildAvailableForPurchase;
		}
		set
		{
			if (!EqualityComparer<BuildInformation>.Default.Equals(_betaBuildAvailableForPurchase, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BetaBuildAvailableForPurchase);
				_betaBuildAvailableForPurchase = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BetaBuildAvailableForPurchase);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BuildInformation? ReleaseBuildAvailableForPurchase
	{
		get
		{
			return _releaseBuildAvailableForPurchase;
		}
		set
		{
			if (!EqualityComparer<BuildInformation>.Default.Equals(_releaseBuildAvailableForPurchase, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ReleaseBuildAvailableForPurchase);
				_releaseBuildAvailableForPurchase = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ReleaseBuildAvailableForPurchase);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ReleaseNotes
	{
		get
		{
			return _releaseNotes;
		}
		[MemberNotNull("_releaseNotes")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_releaseNotes, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ReleaseNotes);
				_releaseNotes = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ReleaseNotes);
			}
		}
	}

	public AppUpdateService(IRegistrationOperationFactory registrationOperationFactory, IApp app, IAppDownloadFactory appDownloadFactory, ITimerFactory timerFactory, IAppUpdateUserDialogService appUpdateUserDialogService, IInternetAccessCheck internetAccessCheck, IRegistrationStateProvider registrationStateProvider, IAsyncExecutor asyncExecutor)
	{
		_registrationOperationFactory = registrationOperationFactory;
		_app = app;
		_appDownloadFactory = appDownloadFactory;
		_appUpdateUserDialogService = appUpdateUserDialogService;
		_internetAccessCheck = internetAccessCheck;
		_registrationStateProvider = registrationStateProvider;
		_asyncExecutor = asyncExecutor;
		_registrationStateProvider.PerformUpdateCheck += InitiateCheckForUpgradesAfterRegistrationChange;
		_periodicUpdatePoll = timerFactory.CreatePeriodic(TimeSlice.FromDays(1.0), delegate
		{
			_asyncExecutor.ExecuteAsync(async delegate
			{
				bool updateInformationChanged = await RefetchAvailableSoftwareAsync();
				if (_app.NotifyUpdates)
				{
					ShowUpdatesWhenAvailable(updateInformationChanged);
				}
			});
		});
		AddPropertyLinks();
	}

	public void Start()
	{
		_periodicUpdatePoll.Start();
	}

	public void ShowUpdateViewer()
	{
		ShowAllUpdatesAvailable();
	}

	public void SkipVersion(BuildInformation build)
	{
		_app.SkippedVersion = build.Version;
	}

	public void InstallVersion(BuildInformation build)
	{
		if (!_internetAccessCheck.Available())
		{
			_appUpdateUserDialogService.ShowInternetUnavailable();
		}
		else
		{
			_appUpdateUserDialogService.ShowUpdateProgress(_appDownloadFactory.Create(build));
		}
	}

	public void InitiateCheckForUpgrades()
	{
		if (!_internetAccessCheck.Available())
		{
			_appUpdateUserDialogService.ShowInternetUnavailable();
			return;
		}
		_asyncExecutor.ExecuteAsync(async delegate
		{
			await RefetchAvailableSoftwareWithUpdateCheckUiAsync();
			ShowAllUpdatesAvailable();
		});
	}

	private bool ShowUpdatesWhenAvailable(bool updateInformationChanged)
	{
		if (updateInformationChanged)
		{
			BuildInformation buildAvailable = BuildAvailable;
			if ((object)buildAvailable != null && buildAvailable.Version != _app.SkippedVersion)
			{
				_appUpdateUserDialogService.EnsureUpdateViewerIsShown(this);
				return true;
			}
		}
		return false;
	}

	private void InitiateCheckForUpgradesAfterChannelChange()
	{
		_asyncExecutor.ExecuteAsync(async delegate
		{
			if (!ShowUpdatesWhenAvailable(await RefetchAvailableSoftwareWithUpdateCheckUiAsync()))
			{
				RevertToProduction();
			}
		});
	}

	private void InitiateCheckForUpgradesAfterRegistrationChange()
	{
		_asyncExecutor.ExecuteAsync(async delegate
		{
			bool updateInformationChanged = await RefetchAvailableSoftwareAsync();
			if (!AskUserToDowngradeWhenLicenseDoesNotSupportCurrentVersion() && _app.NotifyUpdates)
			{
				ShowUpdatesWhenAvailable(updateInformationChanged);
			}
		});
	}

	private async Task<bool> RefetchAvailableSoftwareWithUpdateCheckUiAsync()
	{
		using (_appUpdateUserDialogService.ShowCheckingForUpdates())
		{
			return await RefetchAvailableSoftwareAsync();
		}
	}

	private async Task<bool> RefetchAvailableSoftwareAsync()
	{
		return SetAvailableSoftware(await _registrationOperationFactory.GetAvailableUpgrades(IsUsingBetaChannel));
	}

	private bool RevertToProduction()
	{
		if (_isNonProductionActive && !IsUsingBetaChannel)
		{
			_appUpdateUserDialogService.ShowRevertToProduction();
			return true;
		}
		return false;
	}

	private bool AskUserToDowngradeWhenLicenseDoesNotSupportCurrentVersion()
	{
		if (_registrationStateProvider.Registration.ProPresenter is CodeState { IsCurrentBuildCoveredByLicense: false })
		{
			_appUpdateUserDialogService.ShowLicenseDoesNotCoverCurrentVersion();
			return true;
		}
		return false;
	}

	private void ShowAllUpdatesAvailable()
	{
		if (AskUserToDowngradeWhenLicenseDoesNotSupportCurrentVersion())
		{
			return;
		}
		if (_numberOfUpdatesAvailableIncludingPurchase == 0)
		{
			if (!RevertToProduction())
			{
				_appUpdateUserDialogService.ShowNoUpdatesAvailable();
			}
			return;
		}
		if (_unavailableCount > 0)
		{
			if ((object)BuildAvailable == null)
			{
				HandleOnlyPurchasedUpdatesAvailable();
				return;
			}
			if (PromptUserToPurchaseOrInstallLatestAvailable(_unavailableCount, BuildAvailable))
			{
				return;
			}
		}
		_appUpdateUserDialogService.EnsureUpdateViewerIsShown(this);
	}

	private bool PromptUserToPurchaseOrInstallLatestAvailable(int unavailableCount, BuildInformation latestAvailableBuild)
	{
		int availableUpdates = _numberOfUpdatesAvailableIncludingPurchase - unavailableCount;
		return !_appUpdateUserDialogService.ShowNotAllLicesnesAvailableForLicense(latestAvailableBuild.Version, availableUpdates);
	}

	private void HandleOnlyPurchasedUpdatesAvailable()
	{
		if (!RevertToProduction())
		{
			_appUpdateUserDialogService.ShowOnlyLicensesNotCoveredByLicenseAvailable();
		}
	}

	private bool SetAvailableSoftware(AvailableSoftware availableSoftware)
	{
		BuildInformation buildInformation = Array.Find(availableSoftware.BuildInformation, (BuildInformation b) => b.IsAvailable && b.IsBeta && !b.IsDowngrade);
		bool num = buildInformation != BetaBuildAvailable;
		BetaBuildAvailable = buildInformation;
		buildInformation = Array.Find(availableSoftware.BuildInformation, (BuildInformation b) => b.IsAvailable && !b.IsBeta && !b.IsDowngrade);
		bool num2 = num | (buildInformation != ReleaseBuildAvailable);
		ReleaseBuildAvailable = buildInformation;
		BuildAvailable = BetaBuildAvailable ?? ReleaseBuildAvailable;
		buildInformation = Array.Find(availableSoftware.BuildInformation, (BuildInformation b) => !b.IsAvailable && b.IsBeta && !b.IsDowngrade);
		bool num3 = num2 | (buildInformation != BetaBuildAvailableForPurchase);
		BetaBuildAvailableForPurchase = buildInformation;
		buildInformation = Array.Find(availableSoftware.BuildInformation, (BuildInformation b) => !b.IsAvailable && !b.IsBeta && !b.IsDowngrade);
		bool result = num3 | (buildInformation != ReleaseBuildAvailableForPurchase);
		ReleaseBuildAvailableForPurchase = buildInformation;
		ReleaseNotes = availableSoftware.ReleaseNotes;
		_numberOfUpdatesAvailableIncludingPurchase = availableSoftware.BuildInformation.Count((BuildInformation b) => !b.IsDowngrade);
		_isNonProductionActive = availableSoftware.IsNonProductionActive;
		_unavailableCount = availableSoftware.BuildInformation.Count((BuildInformation b) => !b.IsAvailable && !b.IsDowngrade);
		return result;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_periodicUpdatePoll.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_periodicUpdatePoll.Stop();
		_registrationStateProvider.PerformUpdateCheck -= InitiateCheckForUpgradesAfterRegistrationChange;
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "UpdateChannel")
		{
			InitiateCheckForUpgradesAfterChannelChange();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_app.PropertyChanged += _app_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_app.PropertyChanged -= _app_PropertyChanged;
	}
}
