using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using Microsoft.CSharp.RuntimeBinder;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Internet;
using Pro.Common.Nullability;
using Pro.Common.OAuth;
using Pro.Common.Time;
using Pro.DO.Storage;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Timer;
using ProPresenter.UI.Theming;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Capture;

public class CaptureController : LinkedNotifyPropertyChangedBase, ICaptureController, ICaptureService, INotifyPropertyChanged, IResiService, IResiRemote
{
	[CompilerGenerated]
	private static class _003C_003Eo__172
	{
		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, SolidColorBrush>> _003C_003Ep__3;
	}

	private readonly ICapturePrompt _capturePrompt;

	private readonly IResiController _resiController;

	private readonly ICrashRecovery _crashRecovery;

	private readonly TimerFormatData _formatter;

	private TimeSlice _captureTimeLapse;

	private int _droppedFrames;

	private double _percentDroppedFrames;

	private double _bitRate;

	private State _captureState;

	private State _state;

	private StreamStatus _streamStatus;

	private DiskStatus _diskStatus;

	private RelativePath _captureFile = RelativePath.Empty();

	private double _captureRecordTime;

	private CaptureStatus _captureStatus = CaptureStatus.Stopped;

	private string _eventName = string.Empty;

	private string _socialDescription = string.Empty;

	private bool _checkResiResume;

	private SolidColorBrush _stateColor = new SolidColorBrush();

	private ICapturePreset? _activePreset;

	private readonly IProCoreInstance _proCore;

	private readonly IOutputService _outputService;

	public CaptureStatus CaptureStatus
	{
		get
		{
			return _captureStatus;
		}
		private set
		{
			SetValue("CaptureStatus", ref _captureStatus, value, null, false, StartStopButtonLabel);
		}
	}

	public AudienceScreenArrangementCollection AudienceScreens => _outputService.OutputConfiguration.AudienceArrangementScreens;

	public StageScreenArrangementCollection StageScreens => _outputService.OutputConfiguration.StageArrangementScreens;

	public IStream? Stream => _activePreset?.DefaultStream;

	public ICaptureSettingsDocument CaptureSettings => _outputService.OutputConfiguration.CaptureSettings;

	public IDiskDestination? DiskDestination => _activePreset?.DiskDestination;

	public IRtmpDestination? RTMPDestination => _activePreset?.RTMPDestination;

	public IResiDestination? ResiDestination => _activePreset?.ResiDestination;

	public string CaptureTimeLapse
	{
		get
		{
			TimerFormatData formatter = _formatter;
			TimerFormatData formatter2 = _formatter;
			if (_captureTimeLapse.Hours <= 0)
			{
				formatter.HourFormat = TimerFormatStyle.ShortTruncated;
				formatter2.MinuteFormat = TimerFormatStyle.Short;
			}
			else
			{
				formatter.HourFormat = TimerFormatStyle.Short;
				formatter2.MinuteFormat = TimerFormatStyle.Long;
			}
			return _formatter.FormatTime(_captureTimeLapse);
		}
	}

	public bool IsLive => CaptureState != State.Inactive;

	private State CaptureState
	{
		get
		{
			return _captureState;
		}
		set
		{
			SetValue("CaptureState", ref _captureState, value, (Action<State, State>?)delegate
			{
				CheckLive();
				UpdateFinalState();
			}, (Predicate<State>?)null, referenceComparison: false);
		}
	}

	public string StreamStatusText => GetCaptureStreamStatusText();

	public string ResiStreamStatusText => GetResiStreamStatusText();

	public string StatusText
	{
		get
		{
			if (!IsLive)
			{
				return string.Empty;
			}
			return StreamStatusText + (ResiStreamStatusText.NullableIsNullOrEmpty() ? string.Empty : (Environment.NewLine + ResiStreamStatusText));
		}
	}

	public State State
	{
		get
		{
			return _state;
		}
		private set
		{
			SetValue("State", ref _state, value, delegate(State o, State n)
			{
				StateColor = StateToColor(n);
			});
		}
	}

	public SolidColorBrush StateColor
	{
		get
		{
			return _stateColor;
		}
		private set
		{
			SetValue("StateColor", ref _stateColor, value);
		}
	}

	public StreamStatus StreamStatus
	{
		get
		{
			return _streamStatus;
		}
		private set
		{
			SetValue("StreamStatus", ref _streamStatus, value, (System.Action)delegate
			{
				CheckLive();
				OnPropertyChanged("StreamStatusText");
				OnPropertyChanged("ResiStreamStatusText");
			}, (Predicate<StreamStatus>?)null, referenceComparison: false);
		}
	}

	public int DroppedFrames
	{
		get
		{
			return _droppedFrames;
		}
		private set
		{
			SetValue("DroppedFrames", ref _droppedFrames, value);
		}
	}

	public double PercentDroppedFrames
	{
		get
		{
			return _percentDroppedFrames;
		}
		private set
		{
			SetValue("PercentDroppedFrames", ref _percentDroppedFrames, value);
		}
	}

	public double BitRate
	{
		get
		{
			return _bitRate;
		}
		private set
		{
			SetValue("BitRate", ref _bitRate, value);
		}
	}

	public DiskStatus DiskStatus
	{
		get
		{
			return _diskStatus;
		}
		private set
		{
			SetValue("DiskStatus", ref _diskStatus, value, delegate(DiskStatus o, DiskStatus n)
			{
				CheckDiskStatus(n);
			});
		}
	}

	public RelativePath CaptureFile
	{
		get
		{
			return _captureFile;
		}
		set
		{
			SetValue("CaptureFile", ref _captureFile, value);
		}
	}

	public string StartStopButtonLabel => GetStartStopButtonLabel();

	private DestinationType Destination => Stream?.DestinationType ?? DestinationType.Disk;

	public bool PluginStarted => _resiController.PluginStarted;

	public CredentialState AuthorizationState => _resiController.AuthorizationState;

	public AccountStatus AccountStatus => _resiController.AccountStatus;

	public UpdateStatus UpdateStatus => _resiController.UpdateStatus;

	public ResiStreamStatus ResiStreamStatus => _resiController.CurrentStatus;

	public UploadHealth UploadHealth => _resiController.UploadHealth;

	public ErrorCode ErrorCodes => _resiController.ErrorCodes;

	public UploadInfo? UploadInfo => _resiController.UploadInfo;

	public double DownloadProgress => _resiController.DownloadProgress;

	public string CustomerName => _resiController.UserName;

	public string EncoderName => _resiController.EncoderName;

	public System.Version? PluginVersion => _resiController.PluginVersion;

	public bool PluginInstalled => _resiController.PluginInstalled;

	public bool UpdateAvailable => _resiController.UpdateAvailable;

	public string Schedule => _resiController.Schedule;

	public IEnumerable<IDestinationGroup> ResiDestinationGroups => _resiController.DestinationGroups;

	public IEnumerable<IEncoderProfile> ResiEncoderProfiles => _resiController.EncoderProfiles;

	public string EventName
	{
		get
		{
			return _eventName;
		}
		set
		{
			SetValue("EventName", ref _eventName, value);
		}
	}

	public string SocialDescription
	{
		get
		{
			return _socialDescription;
		}
		set
		{
			SetValue("SocialDescription", ref _socialDescription, value);
		}
	}

	public bool IsInternetAccessAvailable { get; private set; }

	public event System.Action? StreamPropertyChanged;

	public event EventHandler<ScreenCaptureStatusEventArgs>? ScreenCaptureStatusChanged
	{
		add
		{
			_proCore.ScreenCaptureStatusChanged += value;
		}
		remove
		{
			_proCore.ScreenCaptureStatusChanged -= value;
		}
	}

	public event Action<(TimeSlice? elapsedTime, string statusText, System.Windows.Media.Color statusColor)>? CaptureInformationUpdated;

	public CaptureController(IProCoreInstance proCore, IOutputService outputService, IResiController resiController, ICrashRecovery crashRecovery, ICapturePrompt capturePrompt, IInternetAccessCheck internetAccessCheck)
	{
		_proCore = proCore;
		_outputService = outputService;
		_resiController = resiController;
		_capturePrompt = capturePrompt;
		_crashRecovery = crashRecovery;
		_formatter = new TimerFormatData(TimerFormatStyle.ShortTruncated, TimerFormatStyle.Short, TimerFormatStyle.Long, TimerFormatStyle.None);
		if (proCore != null)
		{
			_proCore.ScreenCaptureStatusChanged += CoreManager_ScreenCaptureStatusChanged;
		}
		internetAccessCheck.WhenIsAvailableChanged.Subscribe(OnInternetAccessChanged);
		IsInternetAccessAvailable = internetAccessCheck.Available();
		LinkAction("AuthorizationState", OnAuthorizationChanged);
		LinkProperties("AccountStatus", "AccountStatus");
		LinkProperties("UpdateStatus", "UpdateStatus");
		LinkProperties("UserName", "CustomerName");
		LinkProperties("EncoderName", "EncoderName");
		LinkProperties("PluginVersion", "PluginVersion");
		LinkProperties("PluginInstalled", "PluginInstalled");
		LinkProperties("UpdateAvailable", "UpdateAvailable");
		LinkProperties("Schedule", "Schedule");
		LinkProperties("DownloadProgress", "DownloadProgress");
		LinkProperties("DestinationGroups", "ResiDestinationGroups");
		LinkProperties("EncoderProfiles", "ResiEncoderProfiles");
		LinkAction("CurrentStatus", delegate
		{
			if (ResiDestination != null)
			{
				CaptureStatus = _resiController.CurrentStatus switch
				{
					ResiStreamStatus.Starting => CaptureStatus.Starting, 
					ResiStreamStatus.Started => CaptureStatus.Started, 
					ResiStreamStatus.Stopping => CaptureStatus.Stopping, 
					_ => CaptureStatus.Stopped, 
				};
				OnPropertyChanged("StartStopButtonLabel");
				OnPropertyChanged("ResiStreamStatus");
			}
		});
		LinkAction("PluginStarted", delegate
		{
			OnPropertyChanged("PluginStarted");
			OnCheckResiResumeStream();
		});
		LinkAction("RequestedStatus", OnCheckResiResumeStream);
		LinkProperties("UploadInfo", "UploadInfo");
		LinkAction("UploadHealth", delegate
		{
			OnPropertyChanged("UploadHealth");
			UpdateFinalState();
			OnPropertyChanged("StreamStatusText");
			OnPropertyChanged("ResiStreamStatusText");
		});
		LinkAction("ErrorCodes", delegate
		{
			OnPropertyChanged("ErrorCodes");
			UpdateFinalState();
			OnPropertyChanged("StreamStatusText");
			OnPropertyChanged("ResiStreamStatusText");
		});
		_resiController.PropertyChanged += base.RaiseLinkedValues;
		_resiController.ErrorIssued += delegate
		{
			if (Destination == DestinationType.Resi && (_resiController.ErrorCodes.HasFlag(ErrorCode.DestinationGroupInUse) || _resiController.ErrorCodes.HasFlag(ErrorCode.DestinationGroupDeleted)))
			{
				if (IsLive)
				{
					OnStopScreenCapture(userAction: false);
				}
				_crashRecovery.RemoveLastCaptureInfo();
				CaptureStatus = CaptureStatus.Stopped;
			}
		};
		LinkProperties("DestinationType", "StartStopButtonLabel");
		LinkAction(new string[10] { "ScreenID", "ScreenName", "DestinationType", "Location", "Address", "Key", "Codec", "Encoding", "Profile", "Group" }, NotifyPropertyChanged);
		LinkAction("ActivePreset", delegate
		{
			TeadownPreset(_activePreset);
			SetupPreset(CaptureSettings.ActivePreset);
			NotifyPropertyChanged();
		});
		CaptureSettings.PropertyChanged += base.RaiseLinkedValues;
		SetupPreset(CaptureSettings.ActivePreset);
	}

	private void OnInternetAccessChanged(bool hasInternet)
	{
		IsInternetAccessAvailable = hasInternet;
	}

	private void OnCheckResiResumeStream()
	{
		if (PluginStarted && _checkResiResume)
		{
			if (_resiController.RequestedStatus == ResiStreamStatus.Stopped)
			{
				_crashRecovery.CheckResumeCapture();
			}
			_checkResiResume = false;
		}
	}

	private void OnAuthorizationChanged()
	{
		OnPropertyChanged("AuthorizationState");
		if (Stream != null && _resiController.AuthorizationState == CredentialState.Authorized && !IsLive)
		{
			Stream.DestinationType = DestinationType.Resi;
		}
	}

	private void TeadownPreset(ICapturePreset? preset)
	{
		if (preset != null)
		{
			TeardownStream(preset.DefaultStream);
		}
	}

	private void SetupPreset(ICapturePreset? preset)
	{
		_activePreset = preset;
		if (_activePreset != null)
		{
			SetupStream(_activePreset.DefaultStream);
		}
	}

	private void TeardownStream(IStream stream)
	{
		if (stream != null)
		{
			stream.PropertyChanged -= base.RaiseLinkedValues;
			stream.Encoder.PropertyChanged -= base.RaiseLinkedValues;
			stream.ForEach(delegate(IDestination d)
			{
				d.PropertyChanged -= base.RaiseLinkedValues;
			});
			stream.CollectionChanged -= Stream_CollectionChanged;
		}
	}

	private void SetupStream(IStream stream)
	{
		if (stream != null)
		{
			stream.PropertyChanged += base.RaiseLinkedValues;
			if (stream.Encoder != null)
			{
				stream.Encoder.PropertyChanged += base.RaiseLinkedValues;
			}
			stream.ForEach(delegate(IDestination d)
			{
				d.PropertyChanged += base.RaiseLinkedValues;
			});
			stream.CollectionChanged += Stream_CollectionChanged;
		}
	}

	private void Stream_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IDestination>().ForEach(delegate(IDestination d)
		{
			d.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<IDestination>().ForEach(delegate(IDestination d)
		{
			d.PropertyChanged += base.RaiseLinkedValues;
		});
		NotifyPropertyChanged();
	}

	private void NotifyPropertyChanged()
	{
		this.StreamPropertyChanged?.Invoke();
	}

	private void CoreManager_ScreenCaptureStatusChanged(object? sender, ScreenCaptureStatusEventArgs e)
	{
		ProScreenCaptureStatus proScreenCaptureStatus = e?.ScreenCaptureStatus;
		if (proScreenCaptureStatus == null)
		{
			return;
		}
		Guid presetId = new Guid(proScreenCaptureStatus.PresetID.Bytes);
		ICapturePreset capturePreset = CaptureSettings.Presets.FirstOrDefaultBy((ICapturePreset p) => p.ID == presetId);
		if (capturePreset != null && CaptureSettings.ActivePreset != capturePreset)
		{
			CaptureSettings.ActivePreset = capturePreset;
		}
		Guid guid = new Guid(proScreenCaptureStatus.StreamID.Bytes);
		if (Stream != null && Stream.ID == guid)
		{
			_captureRecordTime = proScreenCaptureStatus.CurrentRecordTime;
			_captureTimeLapse = TimeSlice.FromSeconds(_captureRecordTime);
			CaptureState = proScreenCaptureStatus.State.ToState();
			StreamStatus = proScreenCaptureStatus.StreamStatus.ToStatus();
			DroppedFrames = proScreenCaptureStatus.DroppedFrames;
			PercentDroppedFrames = proScreenCaptureStatus.PercentDroppedFrames;
			BitRate = proScreenCaptureStatus.BitRate / 1000000.0;
			if (DiskDestination != null)
			{
				DiskStatus = proScreenCaptureStatus.DiskStatus.ToStatus();
			}
			try
			{
				CaptureFile = ((Destination == DestinationType.Resi) ? RelativePath.Empty() : new RelativePath(proScreenCaptureStatus.FileName));
			}
			catch
			{
			}
		}
		OnPropertyChanged("CaptureTimeLapse");
		OnPropertyChanged("StartStopButtonLabel");
		OnCaptureInformationUpdated();
	}

	private void UpdateFinalState()
	{
		State state = CaptureState;
		if (IsLive && DiskStatus == DiskStatus.Low)
		{
			state = State.Caution;
		}
		if (Destination == DestinationType.Resi)
		{
			switch (UploadHealth)
			{
			case UploadHealth.Warning:
				if (state != State.Error)
				{
					state = State.Caution;
				}
				break;
			case UploadHealth.Error:
				state = State.Error;
				break;
			}
			if (ErrorCodes.HasFlag(ErrorCode.NetworkOffline))
			{
				state = State.Error;
			}
		}
		State = state;
		OnCaptureInformationUpdated();
	}

	private string GetCaptureStreamStatusText()
	{
		State captureState = CaptureState;
		StreamStatus streamStatus = StreamStatus;
		switch (captureState)
		{
		case State.Error:
			switch (streamStatus)
			{
			case StreamStatus.ConnectionFailed:
				return LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_CONNECTION_FAILED_title");
			case StreamStatus.Reconnecting:
				return LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_RECONNECTING_title");
			case StreamStatus.ConnectionDropped:
				return LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_CONNECTION_LOST_title");
			}
			break;
		case State.Caution:
			return LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_WARNING_title");
		}
		return LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_ACTIVE_title");
	}

	private string GetResiStreamStatusText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Destination == DestinationType.Resi)
		{
			if (ErrorCodes.HasFlag(ErrorCode.CentralStartError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_CENTRAL_START_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.FolderStartError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_FOLDER_START_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.UnknownStartError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_UNKNOWN_START_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.CentralStopError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_CENTRAL_STOP_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.FolderStopError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_FOLDER_STOP_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.UnknownStopError))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_UNKNOWN_STOP_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.DestinationGroupInUse))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_DESTINATION_GROUP_IN_USE_title"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.NetworkOffline))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"));
			}
			else if (ErrorCodes.HasFlag(ErrorCode.Unknown))
			{
				stringBuilder.AppendLine(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_UNKNOWN_title"));
			}
		}
		string text = stringBuilder.ToString().Trim();
		if (!string.IsNullOrEmpty(text))
		{
			return LocalizedStrings.Get("RESI_STREAM_ERROR_FORMAT_label", new object[1] { text });
		}
		return text;
	}

	public IEnumerable<Codec> GetAvailableCodecs(DestinationType destination)
	{
		Codec[] codecs = Array.Empty<Codec>();
		_proCore.GetAvailableCodecs(delegate(ProScreenCaptureCodec[] result)
		{
			codecs = result.Select((ProScreenCaptureCodec r) => r.ToCodec()).AvailableFor(destination).ToArray();
		});
		return codecs;
	}

	public void StartScreenCapture()
	{
		if (Stream == null)
		{
			return;
		}
		CaptureStatus = CaptureStatus.Starting;
		_checkResiResume = false;
		RelativePath relativePath = RelativePath.Empty();
		IStream stream = Stream;
		uint gop = 0u;
		double segmentSize = 0.0;
		string destinationGroupId = string.Empty;
		uint bufSize = 0u;
		uint maxRate = 0u;
		uint minRate = 0u;
		if (ResiDestination != null)
		{
			destinationGroupId = ResiDestination.Group.ToString();
			IEncoderProfile encoderProfile = ResiEncoderProfiles.FirstOrDefault((IEncoderProfile p) => p.ID == ResiDestination.Profile);
			if (encoderProfile != null)
			{
				gop = encoderProfile.Gop;
				segmentSize = encoderProfile.SegmentSizeUs;
				bufSize = encoderProfile.VideoBufSize;
				maxRate = encoderProfile.VideoMaxRate;
				minRate = encoderProfile.VideoMinRate;
				stream.Encoder.Encoding = ProPresenter.DO.Capture.Encoder.FromEncoderProfile(encoderProfile);
			}
			stream.Encoder.Codec = Codec.Automatic;
			relativePath = new RelativePath(Path.Combine(CommonPaths.DefaultResiTemp, Guid.NewGuid().ToString()));
			Directory.CreateDirectory(relativePath);
		}
		RecordRequest protoStream = new RecordRequest
		{
			Stream = stream.Serialize(),
			WorkingDirectory = relativePath.Serialize(),
			Resi = new RecordRequest.Types.Resi
			{
				Gop = gop,
				SegmentSize = segmentSize,
				DestinationGroupId = destinationGroupId,
				BufSize = bufSize,
				MaxRate = maxRate,
				MinRate = minRate,
				EventName = (EventName ?? string.Empty),
				SocialDescription = (SocialDescription ?? string.Empty)
			}
		};
		_crashRecovery.SaveLastCaptureInfo();
		int errorCode;
		ProResult proResult = _proCore.StartScreenCapture(protoStream, out errorCode);
		bool streamStarted = proResult == ProResult.Success;
		switch (stream.DestinationType)
		{
		case DestinationType.Disk:
			StartCaptureDiskEvent.Publish(stream.Encoder.Codec, stream.Encoder.Encoding.VideoWidth, stream.Encoder.Encoding.VideoHeight, stream.Encoder.Encoding.FrameRate, streamStarted, stream.Encoder.Encoding.VideoBitrate);
			break;
		case DestinationType.RTMP:
			StartCaptureRtmpEvent.Publish(stream.Encoder.Codec, stream.Encoder.Encoding.VideoWidth, stream.Encoder.Encoding.VideoHeight, stream.Encoder.Encoding.FrameRate, streamStarted, stream.Encoder.Encoding.VideoBitrate);
			break;
		case DestinationType.Resi:
			StartCaptureResiEvent.Publish(stream.Encoder.Codec, stream.Encoder.Encoding.VideoWidth, stream.Encoder.Encoding.VideoHeight, stream.Encoder.Encoding.FrameRate, streamStarted, stream.Encoder.Encoding.VideoBitrate);
			break;
		}
		_resiController.ResetErrorCodesShown();
		if (proResult != 0)
		{
			CaptureStatus = CaptureStatus.Stopped;
			_crashRecovery.RemoveLastCaptureInfo();
			_capturePrompt.ShowStartCaptureError(proResult, errorCode);
		}
		OnPropertyChanged("StartStopButtonLabel");
	}

	public void StopScreenCapture()
	{
		OnStopScreenCapture(userAction: true);
	}

	private void OnStopScreenCapture(bool userAction)
	{
		if (Stream != null)
		{
			CaptureStatus = CaptureStatus.Stopping;
			if (!IsLive)
			{
				CaptureStatus = CaptureStatus.Stopped;
			}
			if (userAction)
			{
				EventName = string.Empty;
				SocialDescription = string.Empty;
			}
			_checkResiResume = false;
			Guid iD = Stream.ID;
			_crashRecovery.RemoveLastCaptureInfo();
			_proCore.StopScreenCapture(iD);
			StopCaptureEvent.Publish(Math.Round(_captureRecordTime), DroppedFrames, Math.Round(PercentDroppedFrames * 100.0));
			OnPropertyChanged("StartStopButtonLabel");
		}
	}

	public void StopLocalCapture()
	{
		if (Stream != null)
		{
			CaptureStatus = CaptureStatus.Stopping;
			Guid iD = Stream.ID;
			_crashRecovery.RemoveLastCaptureInfo();
			_proCore.StopLocalScreenCapture(iD);
			StopCaptureEvent.Publish(Math.Round(_captureRecordTime), DroppedFrames, Math.Round(PercentDroppedFrames * 100.0));
		}
	}

	private void CheckDiskStatus(DiskStatus diskStatus)
	{
		switch (diskStatus)
		{
		case DiskStatus.Low:
			HandleLowDiskSpace();
			break;
		case DiskStatus.Critical:
			HandleCriticalDiskSpace();
			break;
		default:
			throw new NotSupportedException();
		case DiskStatus.OK:
			break;
		}
	}

	private void HandleLowDiskSpace()
	{
		switch (_capturePrompt.ShowLowSpace(RTMPDestination != null))
		{
		case DiskWarningButtons.Stop:
			OnStopScreenCapture(userAction: false);
			break;
		case DiskWarningButtons.StopBackupOnly:
			StopLocalCapture();
			break;
		default:
			throw new NotSupportedException();
		case DiskWarningButtons.Continue:
			break;
		}
	}

	private void HandleCriticalDiskSpace()
	{
		_capturePrompt.ShowCritical();
	}

	public bool IsResiBusy()
	{
		if (ResiDestination != null && _resiController.CurrentStatus != ResiStreamStatus.Stopped)
		{
			return _resiController.CurrentStatus != ResiStreamStatus.Unknown;
		}
		return false;
	}

	public void ShowMoreInfo()
	{
		_resiController.ShowMoreInfo();
	}

	public bool CanShowMoreInfo()
	{
		return _resiController.CanShowMoreInfo();
	}

	public void Download()
	{
		_resiController.Download();
	}

	public void StartRemoteCapture()
	{
		if (Stream == null)
		{
			return;
		}
		Stream.DestinationType = DestinationType.Resi;
		if (!ResiDestinationGroups.Any(delegate(IDestinationGroup g)
		{
			Guid iD = g.ID;
			Guid? obj = ResiDestination?.Group;
			return iD == obj;
		}))
		{
			ResiDestination.Group = ResiDestinationGroups.FirstOrDefault()?.ID ?? Guid.Empty;
		}
		if (!ResiEncoderProfiles.Any(delegate(IEncoderProfile p)
		{
			Guid iD2 = p.ID;
			Guid? obj2 = ResiDestination?.Profile;
			return iD2 == obj2;
		}))
		{
			ResiDestination.Profile = ResiEncoderProfiles.FirstOrDefault((IEncoderProfile p) => p.Resolution.Y == 720 && p.FrameRate == FrameRate._30)?.ID ?? ResiEncoderProfiles.FirstOrDefault()?.ID ?? Guid.Empty;
		}
		if (CanStartRemoteCapture())
		{
			StartScreenCapture();
		}
	}

	public void StopRemoteCapture()
	{
		if (IsLive)
		{
			OnStopScreenCapture(userAction: true);
		}
		else
		{
			_resiController.StopStream();
		}
	}

	private bool CanStartRemoteCapture()
	{
		Guid? screenID = Stream?.ScreenID;
		string screenName = Stream?.ScreenName;
		bool valueOrDefault = DiskDestination?.Location?.IsValid == true;
		string url = RTMPDestination?.Address ?? string.Empty;
		bool flag = RTMPDestination != null && DiskDestination != null;
		bool flag2 = CaptureStatus == CaptureStatus.Stopped && !IsLive && (AudienceScreens.FirstOrDefaultBy(delegate(ScreenArrangementBase s)
		{
			Guid iD = s.ID;
			Guid? guid = screenID;
			return iD == guid;
		}, (ScreenArrangementBase s) => s.Name == screenName) != null || StageScreens.FirstOrDefaultBy(delegate(ScreenArrangementBase s)
		{
			Guid iD2 = s.ID;
			Guid? guid2 = screenID;
			return iD2 == guid2;
		}, (ScreenArrangementBase s) => s.Name == screenName) != null);
		switch (Destination)
		{
		case DestinationType.Disk:
			flag2 = flag2 && valueOrDefault;
			break;
		case DestinationType.RTMP:
			flag2 = flag2 && url.IsValidAddress() && IsInternetAccessAvailable;
			if (flag)
			{
				flag2 = flag2 && valueOrDefault;
			}
			break;
		case DestinationType.Resi:
			flag2 = flag2 && IsInternetAccessAvailable && ResiDestination != null && AuthorizationState == CredentialState.Authorized && PluginInstalled && AccountStatus == AccountStatus.Active && ResiEncoderProfiles.Any((IEncoderProfile p) => p.ID == ResiDestination.Profile) && _resiController.CurrentStatus == ResiStreamStatus.Stopped;
			break;
		}
		return flag2;
	}

	public bool CanStartCapture()
	{
		bool flag = CanStartRemoteCapture();
		if (Destination == DestinationType.Resi)
		{
			flag = flag && ResiDestinationGroups.Any(delegate(IDestinationGroup p)
			{
				Guid iD = p.ID;
				Guid? obj = ResiDestination?.Group;
				return iD == obj;
			});
		}
		return flag;
	}

	public bool CanStopCapture()
	{
		switch (Destination)
		{
		case DestinationType.Disk:
		case DestinationType.RTMP:
			return CaptureStatus == CaptureStatus.Started && IsLive;
		case DestinationType.Resi:
			return CaptureStatus == CaptureStatus.Started && IsLive && _resiController.CurrentStatus == ResiStreamStatus.Started;
		default:
			return false;
		}
	}

	public void RemoveLastCaptureInfo()
	{
		_crashRecovery.RemoveLastCaptureInfo();
	}

	public void CheckResumeCapture()
	{
		if (_crashRecovery.CaptureStopped)
		{
			return;
		}
		if (_crashRecovery.LastCaptureDestinationType == DestinationType.Resi)
		{
			if (_resiController.PluginStarted)
			{
				OnCheckResiResumeStream();
			}
			else
			{
				_checkResiResume = true;
			}
		}
		else
		{
			_crashRecovery.CheckResumeCapture();
		}
	}

	public void CancelDownload()
	{
		_resiController.CancelDownload();
	}

	private void CheckLive()
	{
		if (ResiDestination == null)
		{
			CaptureStatus = (IsLive ? CaptureStatus.Started : CaptureStatus.Stopped);
		}
		OnPropertyChanged("IsLive");
	}

	private string GetStartStopButtonLabel()
	{
		string result = string.Empty;
		switch (CaptureStatus)
		{
		case CaptureStatus.Starting:
			result = ((Destination == DestinationType.Disk) ? LocalizedStrings.Get("RECORDING_WINDOW_STARTING_CAPTURE_BUTTON_label") : LocalizedStrings.Get("RECORDING_WINDOW_STARTING_STREAM_BUTTON_label"));
			break;
		case CaptureStatus.Started:
			result = ((Destination == DestinationType.Disk) ? LocalizedStrings.Get("RECORDING_WINDOW_STOP_CAPTURE_BUTTON_label") : LocalizedStrings.Get("RECORDING_WINDOW_STOP_STREAMING_BUTTON_label"));
			break;
		case CaptureStatus.Stopping:
			result = ((Destination == DestinationType.Disk) ? LocalizedStrings.Get("RECORDING_WINDOW_STOPPING_CAPTURE_BUTTON_label") : LocalizedStrings.Get("RECORDING_WINDOW_STOPPING_STREAM_BUTTON_label"));
			break;
		case CaptureStatus.Stopped:
			result = ((Destination == DestinationType.Disk) ? LocalizedStrings.Get("RECORDING_WINDOW_START_CAPTURE_BUTTON_label") : LocalizedStrings.Get("RECORDING_WINDOW_START_STREAMING_BUTTON_label"));
			break;
		}
		return result;
	}

	public void AbortFileUpload()
	{
		_resiController.AbortUpload();
	}

	public void PrepareForShutdown()
	{
		_resiController.PrepareForShutdown();
	}

	public void RefreshDestinationGroups()
	{
		_resiController.RefreshDestinationGroups();
	}

	private static SolidColorBrush StateToColor(State state)
	{
		if (_003C_003Eo__172._003C_003Ep__3 == null)
		{
			_003C_003Eo__172._003C_003Ep__3 = CallSite<Func<CallSite, object, SolidColorBrush>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(SolidColorBrush), typeof(CaptureController)));
		}
		Func<CallSite, object, SolidColorBrush> target = _003C_003Eo__172._003C_003Ep__3.Target;
		CallSite<Func<CallSite, object, SolidColorBrush>> _003C_003Ep__ = _003C_003Eo__172._003C_003Ep__3;
		return target(_003C_003Ep__, state switch
		{
			State.Active => AppTheme.Active.RECORDBUTTONACTIVE, 
			State.Caution => AppTheme.Active.RECORDBUTTONCAUTION, 
			State.Error => AppTheme.Active.RECORDBUTTONERROR, 
			_ => Brushes.Transparent, 
		});
	}

	private void OnCaptureInformationUpdated()
	{
		TimeSlice? item = (IsLive ? new TimeSlice?(TimeSlice.FromSeconds(_captureRecordTime)) : ((TimeSlice?)null));
		string statusText = StatusText;
		System.Windows.Media.Color item2 = StateColor?.Color ?? Colors.Transparent;
		this.CaptureInformationUpdated?.Invoke((item, statusText, item2));
		CaptureStatusUpdated.Publish(State, CaptureTimeLapse, statusText);
	}
}
