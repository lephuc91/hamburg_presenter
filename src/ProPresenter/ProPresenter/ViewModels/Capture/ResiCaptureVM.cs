using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.OAuth;
using Pro.DO.Audio;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Resi;
using ProPresenter.UI.Capture;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Capture;

public class ResiCaptureVM : LinkedNotifyPropertyChangedBase, IResiCaptureVM, INotifyPropertyChanged
{
	private readonly ICaptureService _captureService;

	private readonly IResiService _resiService;

	private readonly IResiAuthorizationInteractor _resiLogin;

	private readonly Lazy<ResiUploadStatusWindow> _resiUploadStatusWindow;

	private readonly Lazy<ResiAbortUploadWindow> _resiAbortUploadWindow;

	private bool _fetchingDestinationGroups;

	private bool _quitImmediately;

	private IStream? Stream => _captureService.Stream;

	private ResiDestination? ResiDestination => Stream?.OfType<ResiDestination>().FirstOrDefault();

	private DestinationType Destination => Stream?.DestinationType ?? DestinationType.Disk;

	public string ResiEventName
	{
		get
		{
			return _resiService.EventName;
		}
		set
		{
			_resiService.EventName = value;
		}
	}

	public string ResiSocialDescription
	{
		get
		{
			return _resiService.SocialDescription;
		}
		set
		{
			_resiService.SocialDescription = value;
		}
	}

	public Guid SelectedResiDestinationGroup
	{
		get
		{
			return ResiDestination?.Group ?? Guid.Empty;
		}
		set
		{
			if (ResiDestination != null)
			{
				ResiDestination.Group = value;
			}
		}
	}

	public IEnumerable<IDestinationGroup> ResiDestinationGroups => _resiService.ResiDestinationGroups;

	public bool FetchingDestinationGroups
	{
		get
		{
			return _fetchingDestinationGroups;
		}
		private set
		{
			SetValue("FetchingDestinationGroups", ref _fetchingDestinationGroups, value);
		}
	}

	public Guid SelectedResiEncoderProfile
	{
		get
		{
			return ResiDestination?.Profile ?? Guid.Empty;
		}
		set
		{
			if (ResiDestination != null)
			{
				ResiDestination.Profile = value;
			}
		}
	}

	public IEnumerable<IEncoderProfile> ResiEncoderProfiles => _resiService.ResiEncoderProfiles;

	public AudioMap<Bus, StreamAudioChannel>? AudioOutputMap => Stream?.AudioOutputMap;

	public bool CanResiStartStream
	{
		get
		{
			if (Destination == DestinationType.Resi && ResiLoggedIn && ResiPluginInstalled)
			{
				return ResiPluginStarted;
			}
			return false;
		}
	}

	public bool ResiLoggedIn => _resiService.AuthorizationState == CredentialState.Authorized;

	public string ResiAccountName => LocalizedStrings.Get("RECORDING_WINDOW_RESI_ACCOUNT_label", new object[1] { _resiService.CustomerName });

	public string ResiEncoderID => LocalizedStrings.Get("RECORDING_WINDOW_RESI_ENCODER_label", new object[1] { _resiService.EncoderName });

	public bool ResiPluginInstalled => _resiService.PluginInstalled;

	public bool ResiPluginStarted => _resiService.PluginStarted;

	public UpdateStatus ResiUpdateStatus => _resiService.UpdateStatus;

	public double ResiDownloadProgress => _resiService.DownloadProgress;

	public bool ResiStreaming => _resiService.IsResiBusy();

	public UploadInfo? UploadInfo => _resiService.UploadInfo;

	public ICommand<IEncoderProfile> ResiSelectEncoderProfileCommand => new RelayCommand<IEncoderProfile>(OnResiSelectEncoderProfileCommand, (IEncoderProfile p) => p != null && ResiDestination != null);

	public ICommand<IDestinationGroup> ResiSelectDestinationGroupCommand => new RelayCommand<IDestinationGroup>(OnResiSelectDestinationGroupCommand, (IDestinationGroup g) => g != null && ResiDestination != null);

	public ICommand ResiRefreshDestinationGroupCommand => new RelayCommand(OnResiRefreshDestinationGroupCommand);

	public ICommand ResiPreferencesCommand => new RelayCommand(OnShowResiPreferencesCommand);

	public ICommand ResiMoreInfoCommand => new RelayCommand(delegate
	{
		_resiService.ShowMoreInfo();
	}, () => _resiService?.CanShowMoreInfo() ?? false);

	public ICommand ResiLoginCommand => new AsyncRelayCommand(_resiLogin.ExecuteLoginAsync, () => _resiLogin?.CanExecute ?? false);

	public ICommand ResiInstallPluginCommand => new RelayCommand(_resiService.Download, () => _resiService != null);

	public ICommand AbortUploadCommand => new RelayCommand(OnAbortUploadCommand);

	public ICommand ResiCancelDownloadCommand => new RelayCommand(_resiService.CancelDownload);

	public event Action? ShowResiPreferences;

	public event Action? QuitImmediately;

	public ResiCaptureVM(ICaptureService captureService, IResiService resiService, IResiAuthorizationInteractor resiLogin)
	{
		_captureService = captureService;
		_resiService = resiService;
		_resiLogin = resiLogin;
		_resiUploadStatusWindow = new Lazy<ResiUploadStatusWindow>(() => new ResiUploadStatusWindow().WithDataContext(this));
		_resiAbortUploadWindow = new Lazy<ResiAbortUploadWindow>(() => new ResiAbortUploadWindow());
		LinkAction("Stream", NotifyPropertyChanged);
		LinkProperties("CustomerName", "ResiAccountName");
		LinkProperties("EncoderName", "ResiEncoderID");
		LinkProperties("AuthorizationState", "ResiLoggedIn");
		LinkProperties("PluginInstalled", "ResiPluginInstalled");
		LinkAction("ResiDestinationGroups", delegate
		{
			FetchingDestinationGroups = false;
			OnPropertyChanged("ResiDestinationGroups");
		});
		LinkProperties("ResiEncoderProfiles", "ResiEncoderProfiles");
		LinkProperties("UpdateStatus", "ResiUpdateStatus");
		LinkProperties("DownloadProgress", "ResiDownloadProgress");
		LinkProperties("EventName", "ResiEventName");
		LinkProperties("SocialDescription", "ResiSocialDescription");
		LinkProperties("PluginStarted", "ResiPluginStarted");
		LinkProperties("UploadInfo", "UploadInfo");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "DestinationType", "AuthorizationState", "PluginInstalled", "PluginStarted" }), "CanResiStartStream");
		LinkAction("ResiStreamStatus", OnResiStreamStatusChanged);
		_captureService.StreamPropertyChanged += NotifyPropertyChanged;
		_resiService.PropertyChanged += base.RaiseLinkedValues;
		if (_captureService.Stream != null)
		{
			_captureService.Stream.DestinationChanged += OnDestinationTypeChanged;
		}
		if (Stream != null)
		{
			Stream.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private void OnDestinationTypeChanged(DestinationType destinationType)
	{
		IStream? stream = Stream;
		if (stream != null && stream.DestinationType == DestinationType.Resi)
		{
			ResiDestination.Group = ResiDestinationGroups.FirstOrDefault()?.ID ?? Guid.Empty;
			ResiDestination.Profile = ResiEncoderProfiles.FirstOrDefault()?.ID ?? Guid.Empty;
			Stream.Encoder.Codec = Codec.Automatic;
			IEncoderProfile encoderProfile = ResiEncoderProfiles.FirstOrDefault((IEncoderProfile p) => p.ID == ResiDestination.Profile);
			if (encoderProfile != null)
			{
				OnResiSelectEncoderProfileCommand(encoderProfile);
			}
		}
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("Destination");
		OnPropertyChanged("CanResiStartStream");
		OnPropertyChanged("ResiPluginInstalled");
		OnPropertyChanged("ResiPluginStarted");
		OnPropertyChanged("ResiUpdateStatus");
		OnPropertyChanged("ResiDownloadProgress");
		OnPropertyChanged("ResiLoggedIn");
		OnPropertyChanged("ResiAccountName");
		OnPropertyChanged("ResiEncoderID");
		OnPropertyChanged("SelectedResiEncoderProfile");
		OnPropertyChanged("SelectedResiDestinationGroup");
	}

	private void OnResiRefreshDestinationGroupCommand()
	{
		FetchingDestinationGroups = true;
		_resiService.RefreshDestinationGroups();
	}

	private void OnResiSelectEncoderProfileCommand(IEncoderProfile profile)
	{
		if (profile != null && ResiDestination != null)
		{
			ResiDestination.Profile = profile.ID;
			Stream.Encoder.Encoding = Encoder.FromEncoderProfile(profile);
		}
	}

	private void OnResiSelectDestinationGroupCommand(IDestinationGroup group)
	{
		if (group != null && ResiDestination != null)
		{
			ResiDestination.Group = group.ID;
		}
	}

	private void OnShowResiPreferencesCommand()
	{
		this.ShowResiPreferences?.Invoke();
	}

	private void OnResiStreamStatusChanged()
	{
		if (_resiService.ResiStreamStatus == ResiStreamStatus.Stopped)
		{
			if (_resiAbortUploadWindow.Value.IsVisible)
			{
				_resiAbortUploadWindow.Value.Close();
			}
			if (_resiUploadStatusWindow.Value.IsVisible)
			{
				_resiUploadStatusWindow.Value.Close();
			}
			if (_quitImmediately)
			{
				this.QuitImmediately?.Invoke();
			}
		}
	}

	public bool QuitResiStreaming()
	{
		string header = LocalizedStrings.Get("APP_QUIT_CONFIRMATION_title");
		string message = (_captureService.IsLive ? LocalizedStrings.Get("APP_QUIT_RESI_STREAM_ACTIVE_ALERT_title") : LocalizedStrings.Get("APP_QUIT_RESI_FILES_PENDING_ALERT_title"));
		ForceQuitButton buttons = (_captureService.IsLive ? (ForceQuitButton.Cancel | ForceQuitButton.QuitImmediately | ForceQuitButton.StopStreamCompleteUpload) : (ForceQuitButton.Cancel | ForceQuitButton.QuitImmediately | ForceQuitButton.QuitAfterUploadCompletes));
		ForceQuitButton defaultButton = (_captureService.IsLive ? ForceQuitButton.StopStreamCompleteUpload : ForceQuitButton.QuitAfterUploadCompletes);
		ForceQuitButton? forceQuitButton = MessageDialogService.ShowDialog(header, message, buttons, defaultButton);
		if (forceQuitButton.HasValue)
		{
			if (forceQuitButton.Value == ForceQuitButton.Cancel)
			{
				return false;
			}
			if (forceQuitButton.Value == ForceQuitButton.StopStreamCompleteUpload || forceQuitButton.Value == ForceQuitButton.QuitAfterUploadCompletes)
			{
				if (_resiService.ResiStreamStatus == ResiStreamStatus.Stopped)
				{
					return true;
				}
				_captureService.StopScreenCapture();
				_resiService.PrepareForShutdown();
				_resiUploadStatusWindow.Value.ShowDialog();
				return true;
			}
			if (forceQuitButton.Value == ForceQuitButton.QuitImmediately)
			{
				_quitImmediately = true;
				_captureService.StopScreenCapture();
				return true;
			}
		}
		return false;
	}

	private void OnAbortUploadCommand()
	{
		_resiAbortUploadWindow.Value.ShowDialog();
		ForceQuitButton? result = _resiAbortUploadWindow.Value.Result;
		if (result.HasValue)
		{
			if (result.Value == ForceQuitButton.Continue)
			{
				_resiService.AbortFileUpload();
			}
			if (_resiService.ResiStreamStatus == ResiStreamStatus.Stopped)
			{
				_resiUploadStatusWindow.Value.Close();
			}
		}
	}
}
