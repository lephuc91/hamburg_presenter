using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.CoreApplication.Workspace;
using Pro.Localization.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Web;
using ProPresenter.Registration.Services;
using ProPresenter.UI.ViewModels.AccountCenter;
using ProPresenter.ViewModels.DispatchingExtensions;
using ProPresenter.ViewModels.Extensions;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.AccountCenter;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cloudSyncSubscription" })]
public class AccountCenterVM : ObservableObject, IAccountCenterVM, IDisposable
{
	private readonly IMediaServiceV1? _mediaServiceV1;

	private readonly ICloudWorkspaceService? _cloudWorkspaceService;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSource;

	private readonly IDisposable? _cloudSyncSubscription;

	private int _pausedSyncCountdownTimer;

	private DispatcherTimer? _pauseCountdownDispatcherTimer;

	private ILocalization _localization;

	private readonly ILogger _logger;

	private readonly ICurrentTimeOffset _currentTime;

	private readonly Subject<SyncStatus> _syncStatus = new Subject<SyncStatus>();

	private readonly Subject<bool> _isCloudSyncPaused = new Subject<bool>();

	private readonly Subject<string> _pausedSyncCountdown = new Subject<string>();

	private readonly Subject<string> _lastActiveSync = new Subject<string>();

	[ObservableProperty]
	private bool _isPopUpOpen;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? resumeThumbnailGenerationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<PauseGenerationOptions>? pauseThumbnailGenerationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? resumeCloudSyncCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<PauseGenerationOptions>? pauseCloudSyncCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cloudTroubleShootingLinkCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cloudTeaseSignUpForEarlyAccessCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cloudTeaseLearnMoreCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IReadOnlyReactiveProperty<ImageSource?> Icon { get; }

	public IReadOnlyReactiveProperty<string> ListItemTitle { get; }

	public IReadOnlyReactiveProperty<string> ListItemSubscript { get; }

	public IReadOnlyReactiveProperty<bool> IsRegistered { get; }

	public IReadOnlyReactiveProperty<string> MediaManagementProgressStatus { get; }

	public IReadOnlyReactiveProperty<SyncStatus> CloudSyncStatus { get; }

	public IReadOnlyReactiveProperty<bool> IsMediaManagementPaused { get; }

	public IReadOnlyReactiveProperty<bool> IsCloudSyncPaused { get; }

	public IReadOnlyReactiveProperty<string> PausedSyncCountdown { get; }

	public IReadOnlyReactiveProperty<string> LastActiveSync { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPopUpOpen
	{
		get
		{
			return _isPopUpOpen;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPopUpOpen, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPopUpOpen);
				_isPopUpOpen = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPopUpOpen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ResumeThumbnailGenerationCommand => resumeThumbnailGenerationCommand ?? (resumeThumbnailGenerationCommand = new AsyncRelayCommand(ResumeThumbnailGeneration));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<PauseGenerationOptions> PauseThumbnailGenerationCommand => pauseThumbnailGenerationCommand ?? (pauseThumbnailGenerationCommand = new AsyncRelayCommand<PauseGenerationOptions>(PauseThumbnailGeneration));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ResumeCloudSyncCommand => resumeCloudSyncCommand ?? (resumeCloudSyncCommand = new AsyncRelayCommand(ResumeCloudSync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<PauseGenerationOptions> PauseCloudSyncCommand => pauseCloudSyncCommand ?? (pauseCloudSyncCommand = new AsyncRelayCommand<PauseGenerationOptions>(PauseCloudSync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloudTroubleShootingLinkCommand => cloudTroubleShootingLinkCommand ?? (cloudTroubleShootingLinkCommand = new RelayCommand(CloudTroubleShootingLink));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloudTeaseSignUpForEarlyAccessCommand => cloudTeaseSignUpForEarlyAccessCommand ?? (cloudTeaseSignUpForEarlyAccessCommand = new RelayCommand(CloudTeaseSignUpForEarlyAccess));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloudTeaseLearnMoreCommand => cloudTeaseLearnMoreCommand ?? (cloudTeaseLearnMoreCommand = new RelayCommand(CloudTeaseLearnMore));

	public AccountCenterVM(IRegistrationStateProvider registrationStateProvider, ILocalization localization, IMediaService mediaService, IUiScheduler scheduler, IHyperlinkService hyperlinkService, IWebSourceProvider webSource, ICloudWorkspaceService? cloudWorkspaceService, ILogger logger, ICurrentTimeOffset currentTime, IUserAvatarProvider userAvatarProvider)
	{
		AccountCenterVM accountCenterVM = this;
		_mediaServiceV1 = mediaService as IMediaServiceV1;
		_cloudWorkspaceService = cloudWorkspaceService;
		_hyperlinkService = hyperlinkService;
		_webSource = webSource;
		_localization = localization;
		_logger = logger;
		_currentTime = currentTime;
		IObservable<PropertyChangedEventArgs> source = registrationStateProvider.WhenPropertyChanges(new global::_003C_003Ez__ReadOnlySingleElementList<string>("Registration"));
		Icon = userAvatarProvider.ToReadOnlyReactivePropertySlim(scheduler, null).DisposeWith(_disposables);
		ListItemTitle = source.Select((PropertyChangedEventArgs _) => registrationStateProvider.ToItemTitle(localization)).ToReadOnlyReactivePropertySlim(scheduler, registrationStateProvider.ToItemTitle(localization)).DisposeWith(_disposables);
		ListItemSubscript = source.Select((PropertyChangedEventArgs _) => registrationStateProvider.ToItemSubtitle(localization)).ToReadOnlyReactivePropertySlim(scheduler, registrationStateProvider.ToItemSubtitle(localization)).DisposeWith(_disposables);
		IsRegistered = source.Select((Func<PropertyChangedEventArgs, bool>)delegate
		{
			return GetIsRegistered(registrationStateProvider);
			static bool GetIsRegistered(IRegistrationStateProvider registrationStateProvider)
			{
				return registrationStateProvider.Registration.ProPresenter.IsRegistered;
			}
		}).ToReadOnlyReactivePropertySlim(scheduler, AccountCenterVM._003C_002Ector_003Eg__GetIsRegistered_007C46_5(registrationStateProvider)).DisposeWith(_disposables);
		CloudSyncStatus = _syncStatus.ToReadOnlyReactivePropertySlim(scheduler, SyncStatus.Active).DisposeWith(_disposables);
		IsCloudSyncPaused = _isCloudSyncPaused.ToReadOnlyReactivePropertySlim(scheduler, initialValue: false).DisposeWith(_disposables);
		PausedSyncCountdown = _pausedSyncCountdown.ToReadOnlyReactivePropertySlim(scheduler, string.Empty).DisposeWith(_disposables);
		LastActiveSync = _lastActiveSync.ToReadOnlyReactivePropertySlim(scheduler, string.Empty).DisposeWith(_disposables);
		if (_cloudWorkspaceService != null)
		{
			_cloudSyncSubscription = _cloudWorkspaceService.WhenSyncingChanged.ObserveOn(scheduler.Scheduler).Subscribe(HandleSyncStatus);
		}
		MediaManagementProgressStatus = mediaService.WhenMediaManagementStatusChanged.Select(delegate(MediaManagementStatus x)
		{
			if (x.Idle)
			{
				return localization.Get("MEDIA_MANAGEMENT_STATUS_IDLE_message");
			}
			if (x.Paused)
			{
				DateTimeOffset dateTimeOffset = x.PausedUntil.Value.ToLocalTime();
				if (dateTimeOffset.Date == accountCenterVM._currentTime.Now.Date)
				{
					return string.Format(localization.Get("MEDIA_MANAGEMENT_STATUS_PAUSED_message"), dateTimeOffset.ToString("h:mm tt"));
				}
				return string.Format(localization.Get("MEDIA_MANAGEMENT_STATUS_PAUSED_WITH_DATE_message"), dateTimeOffset.ToString("M/d"), dateTimeOffset.ToString("h:mm tt"));
			}
			return string.Format(localization.Get("MEDIA_MANAGEMENT_STATUS_PROCESSING_message"), x.Count, x.Total);
		}).ToReadOnlyReactivePropertySlim(scheduler, localization.Get("MEDIA_MANAGEMENT_STATUS_IDLE_message")).DisposeWith(_disposables);
		IsMediaManagementPaused = mediaService.WhenMediaManagementStatusChanged.Select((MediaManagementStatus x) => x.Paused).ToReadOnlyReactivePropertySlim(scheduler, initialValue: false).DisposeWith(_disposables);
	}

	private void HandleSyncStatus(ISyncStatus syncStatus)
	{
		if (syncStatus.IsPaused && syncStatus is PausedSync pausedSync)
		{
			_lastActiveSync.OnNext(FormatLastActiveMessage(pausedSync.At));
			int remainingSeconds = (int)Math.Max(0.0, (pausedSync.Until - _currentTime.UtcNow).TotalSeconds);
			HandleSyncCountdownTimer(remainingSeconds);
			_syncStatus.OnNext(SyncStatus.Paused);
			_isCloudSyncPaused.OnNext(value: true);
		}
		else
		{
			ResetSyncToActiveState();
		}
	}

	private string FormatLastActiveMessage(DateTimeOffset timestamp)
	{
		DateTimeOffset dateTimeOffset = timestamp.ToLocalTime();
		string arg = dateTimeOffset.ToString("MMMM d, yyyy", CultureInfo.CurrentCulture);
		string arg2 = dateTimeOffset.ToString("h:mmtt", CultureInfo.CurrentCulture).ToLowerInvariant();
		return string.Format(_localization.Get("CLOUDWORKSPACE_SYNC_STATUS_LAST_ACTIVE_message"), arg, arg2);
	}

	private void ResetSyncToActiveState()
	{
		_syncStatus.OnNext(SyncStatus.Active);
		_isCloudSyncPaused.OnNext(value: false);
		StopCountdownTimer();
		_pausedSyncCountdown.OnNext(string.Empty);
		_lastActiveSync.OnNext(string.Empty);
	}

	[RelayCommand]
	private async Task ResumeThumbnailGeneration()
	{
		if (_mediaServiceV1 != null)
		{
			await _mediaServiceV1.ResumeThumbnailGeneration();
		}
	}

	[RelayCommand]
	private async Task PauseThumbnailGeneration(PauseGenerationOptions options)
	{
		if (_mediaServiceV1 != null)
		{
			await _mediaServiceV1.PauseThumbnailGeneration(options);
		}
	}

	[RelayCommand]
	private async Task ResumeCloudSync()
	{
		if (_cloudWorkspaceService != null)
		{
			await _cloudWorkspaceService.ResumeSyncAsync();
			StopCountdownTimer();
		}
	}

	[RelayCommand]
	private async Task PauseCloudSync(PauseGenerationOptions options)
	{
		if (_cloudWorkspaceService != null)
		{
			long untilTimeUtc = options switch
			{
				PauseGenerationOptions.ONE_HOUR => _currentTime.UtcNow.AddHours(1.0).ToUnixTimeSeconds(), 
				PauseGenerationOptions.EOD => GetEndOfDay().ToUnixTimeSeconds(), 
				PauseGenerationOptions.TWENTY_FOUR_HOURS => _currentTime.UtcNow.AddHours(24.0).ToUnixTimeSeconds(), 
				_ => throw new ArgumentException($"Unexpected value for {"options"} provided - {options}"), 
			};
			await _cloudWorkspaceService.PauseSyncAsync((ulong)untilTimeUtc);
		}
		else if (_mediaServiceV1 != null)
		{
			await _mediaServiceV1.PauseThumbnailGeneration(options);
			_isCloudSyncPaused.OnNext(value: true);
			_syncStatus.OnNext(SyncStatus.Paused);
		}
	}

	private DateTimeOffset GetEndOfDay()
	{
		DateTimeOffset now = _currentTime.Now;
		return new DateTimeOffset(now.Date.AddDays(1.0), now.Offset);
	}

	private void StopCountdownTimer()
	{
		DispatcherTimer? pauseCountdownDispatcherTimer = _pauseCountdownDispatcherTimer;
		if (pauseCountdownDispatcherTimer != null)
		{
			pauseCountdownDispatcherTimer.Stop();
		}
		_pauseCountdownDispatcherTimer = null;
	}

	private void HandleSyncCountdownTimer(int remainingSeconds)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		StopCountdownTimer();
		_pausedSyncCountdownTimer = remainingSeconds;
		UpdateDisplay(_pausedSyncCountdownTimer);
		if (_pausedSyncCountdownTimer <= 0)
		{
			return;
		}
		_pauseCountdownDispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1L), (DispatcherPriority)9, (EventHandler)delegate
		{
			if (_pausedSyncCountdownTimer <= 0)
			{
				_pausedSyncCountdown.OnNext("00:00:00");
				DispatcherTimer? pauseCountdownDispatcherTimer = _pauseCountdownDispatcherTimer;
				if (pauseCountdownDispatcherTimer != null)
				{
					pauseCountdownDispatcherTimer.Stop();
				}
				_pauseCountdownDispatcherTimer = null;
			}
			else
			{
				_pausedSyncCountdownTimer--;
				UpdateDisplay(_pausedSyncCountdownTimer);
			}
		}, Dispatcher.CurrentDispatcher);
		_pauseCountdownDispatcherTimer.Start();
		void UpdateDisplay(int secondsLeft)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Max(0, secondsLeft));
			int num = (int)timeSpan.TotalHours;
			_pausedSyncCountdown.OnNext($"{num:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}");
		}
	}

	[RelayCommand]
	private void CloudTroubleShootingLink()
	{
		_hyperlinkService.Open(_webSource.CloudTroubleShooting);
	}

	[RelayCommand]
	private void CloudTeaseSignUpForEarlyAccess()
	{
		try
		{
			_hyperlinkService.Open(_webSource.CloudEarlyAccess);
			IsPopUpOpen = false;
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to open Cloud Early Access link: " + ex.Message);
		}
	}

	[RelayCommand]
	private void CloudTeaseLearnMore()
	{
		try
		{
			_hyperlinkService.Open(_webSource.DiscoverCloud);
			IsPopUpOpen = false;
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to open Discover Cloud link: " + ex.Message);
		}
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
			_cloudSyncSubscription?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		DispatcherTimer? pauseCountdownDispatcherTimer = _pauseCountdownDispatcherTimer;
		if (pauseCountdownDispatcherTimer != null)
		{
			pauseCountdownDispatcherTimer.Stop();
		}
		_pauseCountdownDispatcherTimer = null;
		_disposables.Dispose();
	}
}
