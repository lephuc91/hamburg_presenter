using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Storage;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Capture;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Resi;
using ProPresenter.UI.Capture;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Capture;

public class CaptureVM : LinkedNotifyPropertyChangedBase, ICaptureVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003Cget_Destinations_003Ed__64 : IEnumerable<DestinationType>, IEnumerable, IEnumerator<DestinationType>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private DestinationType _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		DestinationType IEnumerator<DestinationType>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003Cget_Destinations_003Ed__64(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = DestinationType.Disk;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = DestinationType.RTMP;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = DestinationType.Resi;
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<DestinationType> IEnumerable<DestinationType>.GetEnumerator()
		{
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				return this;
			}
			return new _003Cget_Destinations_003Ed__64(0);
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<DestinationType>)this).GetEnumerator();
		}
	}

	private static readonly Codec[] StreamingCodecs = new Codec[4]
	{
		Codec.H264,
		Codec.H264Software,
		Codec.H265,
		Codec.H265Software
	};

	private readonly Lazy<CaptureWindow> _captureWindow;

	private string _liveInfo = string.Empty;

	private readonly ICaptureService _captureService;

	private readonly IResiService _resiService;

	private readonly ICapturePrompt _capturePrompt;

	private readonly ICaptureAnalyticEventsPublisher _analyticEventPublisher;

	private readonly RelayCommand _startCaptureCommand;

	private readonly RelayCommand _stopCaptureCommand;

	private readonly IRTMPPrompt _rtmpPrompt;

	private IStream? Stream => _captureService.Stream;

	public IDiskCaptureVM DiskVM { get; }

	public IRtmpCaptureVM RtmpVM { get; }

	public IResiCaptureVM ResiVM { get; }

	public ICapturePresetVM PresetVM { get; }

	public bool IsLive => _captureService.IsLive;

	public State State => _captureService.State;

	public SolidColorBrush StateColor => _captureService.StateColor;

	public StreamStatus StreamStatus => _captureService.StreamStatus;

	public string CaptureStreamStatusText => _captureService.StreamStatusText;

	public string ResiStreamStatusText => _captureService.ResiStreamStatusText;

	public DiskStatus DiskStatus => _captureService.DiskStatus;

	public Guid ScreenID
	{
		get
		{
			return Stream?.ScreenID ?? Guid.Empty;
		}
		private set
		{
			if (Stream != null)
			{
				Stream.ScreenID = value;
			}
		}
	}

	public string ScreenName
	{
		get
		{
			return Stream?.ScreenName ?? string.Empty;
		}
		private set
		{
			if (Stream != null)
			{
				Stream.ScreenName = value;
			}
		}
	}

	public bool SelectedScreenSupportsHdr => _captureService.AudienceScreens.Concat(_captureService.StageScreens).FirstOrDefaultBy((ScreenArrangementBase s) => s.ID == ScreenID, (ScreenArrangementBase s) => s.Name == ScreenName)?.SupportsHdr ?? false;

	public AudienceScreenArrangementCollection AudienceScreens => _captureService.AudienceScreens;

	public StageScreenArrangementCollection StageScreens => _captureService.StageScreens;

	public string CaptureTimeLapse => _captureService.CaptureTimeLapse;

	public int DroppedFrames => _captureService.DroppedFrames;

	public double PercentDroppedFrames => _captureService.PercentDroppedFrames;

	public double BitRate => _captureService.BitRate;

	public string LiveInfo
	{
		get
		{
			return _liveInfo;
		}
		private set
		{
			SetValue("LiveInfo", ref _liveInfo, value);
		}
	}

	public DestinationType Destination => Stream?.DestinationType ?? DestinationType.Disk;

	public IEnumerable<DestinationType> Destinations
	{
		[IteratorStateMachine(typeof(_003Cget_Destinations_003Ed__64))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_Destinations_003Ed__64(-2);
		}
	}

	public RelativePath CaptureFile => _captureService.CaptureFile;

	public string StartStopButtonLabel => _captureService.StartStopButtonLabel;

	public ResiStreamStatus ResiStreamStatus => _resiService.ResiStreamStatus;

	public UploadHealth UploadHealth => _resiService.UploadHealth;

	public ErrorCode ErrorCodes => _resiService.ErrorCodes;

	public ICommand<ScreenArrangementBase> SelectScreenCommand => new RelayCommand<ScreenArrangementBase>(OnSelectScreenCommand, (ScreenArrangementBase s) => s != null);

	public ICommand StartCaptureCommand => _startCaptureCommand;

	public ICommand StopCaptureCommand => _stopCaptureCommand;

	public ICommand<CaptureShownSource> OpenCaptureSettingsCommand => new RelayCommand<CaptureShownSource>(OnOpenCaptureSettingsCommand);

	public ICommand<DestinationType> ChangeDestinationCommand => new RelayCommand<DestinationType>(OnChangeDestinationCommand);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(_captureService.CaptureSettings.UndoStack);
	});

	public event Action<UndoStack?>? StackChanged;

	public CaptureVM(ICaptureService captureService, IResiService resiService, IResiAuthorizationInteractor resiLogin, ICapturePrompt capturePrompt, IEncoderValidator encoderValidator, ICaptureAnalyticEventsPublisher analyticEventPublisher, IRTMPPrompt rtmpPrompt)
	{
		_captureWindow = new Lazy<CaptureWindow>(() => new CaptureWindow(GotFocusCommand).WithDataContext(this));
		_captureService = captureService;
		_resiService = resiService;
		_capturePrompt = capturePrompt;
		_analyticEventPublisher = analyticEventPublisher;
		_rtmpPrompt = rtmpPrompt;
		_startCaptureCommand = new RelayCommand(StartCapture, _captureService.CanStartCapture);
		_stopCaptureCommand = new RelayCommand(StopCapture, _captureService.CanStopCapture);
		LinkProperties("UploadHealth", "UploadHealth");
		LinkProperties("ResiStreamStatus", "ResiStreamStatus");
		LinkAction("ErrorCodes", delegate
		{
			if (ErrorCodes.HasFlag(ErrorCode.DestinationGroupDeleted))
			{
				ResiVM.SelectedResiDestinationGroup = Guid.Empty;
				ResiVM.ResiRefreshDestinationGroupCommand?.Invoke();
			}
			OnPropertyChanged("ErrorCodes");
		});
		LinkProperties("CaptureTimeLapse", "CaptureTimeLapse");
		LinkProperties("IsLive", "IsLive");
		LinkProperties("StreamStatus", "StreamStatus");
		LinkProperties("DroppedFrames", "DroppedFrames");
		LinkProperties("PercentDroppedFrames", "PercentDroppedFrames");
		LinkProperties("BitRate", "BitRate");
		LinkProperties("DiskStatus", "DiskStatus");
		LinkProperties("CaptureFile", "CaptureFile");
		LinkAction("Stream", NotifyPropertyChanged);
		LinkAction("StartStopButtonLabel", delegate
		{
			OnPropertyChanged("StartStopButtonLabel");
			_startCaptureCommand.NotifyCanExecuteChanged();
			_stopCaptureCommand.NotifyCanExecuteChanged();
		});
		LinkProperties("State", "State");
		LinkProperties("StateColor", "StateColor");
		LinkProperties("StreamStatusText", "CaptureStreamStatusText");
		LinkProperties("ResiStreamStatusText", "ResiStreamStatusText");
		_captureService.PropertyChanged += base.RaiseLinkedValues;
		_resiService.PropertyChanged += base.RaiseLinkedValues;
		_captureService.StreamPropertyChanged += NotifyPropertyChanged;
		if (ScreenID == Guid.Empty)
		{
			OnSelectScreenCommand(AudienceScreens.FirstOrDefault());
		}
		AudienceScreens.CollectionModified += Screens_CollectionModified;
		AudienceScreens.CollectionChanged += Screens_CollectionChanged;
		AudienceScreens.ForEach(delegate(ScreenArrangementBase s)
		{
			s.PropertyChanged += base.RaiseLinkedValues;
		});
		StageScreens.CollectionModified += Screens_CollectionModified;
		StageScreens.CollectionChanged += Screens_CollectionChanged;
		CustomEncoderVM customEncoderVM = new CustomEncoderVM(capturePrompt, encoderValidator);
		CaptureNameVM captureNameVM = new CaptureNameVM(capturePrompt, IsPresetNameUnique);
		DiskVM = new DiskCaptureVM(captureService, customEncoderVM);
		RtmpVM = new RtmpCaptureVM(captureService, customEncoderVM);
		ResiVM = new ResiCaptureVM(captureService, resiService, resiLogin);
		PresetVM = new CapturePresetVM(_captureService, captureNameVM);
		ICapturePresetCollection presets = _captureService.CaptureSettings.Presets;
		int presetCount = presets?.Count() ?? 0;
		int diskPresetCount = presets?.Count((ICapturePreset p) => p.DefaultStream.DestinationType == DestinationType.Disk) ?? 0;
		int rtmpPresetCount = presets?.Count((ICapturePreset p) => p.DefaultStream.DestinationType == DestinationType.RTMP) ?? 0;
		int resiPresetCount = presets?.Count((ICapturePreset p) => p.DefaultStream.DestinationType == DestinationType.Resi) ?? 0;
		_analyticEventPublisher.StartupCapture(presetCount, diskPresetCount, rtmpPresetCount, resiPresetCount);
		NotifySelectedScreenSupportsHdr();
		LinkAction("SupportsHdr", NotifySelectedScreenSupportsHdr);
	}

	private void Screens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase s)
		{
			s.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase s)
		{
			s.PropertyChanged += base.RaiseLinkedValues;
		});
	}

	private bool IsPresetNameUnique(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return false;
		}
		string cleanedName = name.Trim().ToLower();
		if (cleanedName.Length != 0)
		{
			return _captureService.CaptureSettings.Presets.All((ICapturePreset p) => p.Name.ToLower() != cleanedName);
		}
		return false;
	}

	private void OnChangeDestinationCommand(DestinationType value)
	{
		if (value != Destination && Stream != null && Stream.DestinationType != value)
		{
			if (value == DestinationType.RTMP && !DiskVM.Codecs.ContainsAny(StreamingCodecs))
			{
				_rtmpPrompt.ShowNoValidCodecAlert();
			}
			else
			{
				Stream.DestinationType = value;
			}
		}
	}

	private void OnOpenCaptureSettingsCommand(CaptureShownSource source)
	{
		_analyticEventPublisher?.OpenCaptureSettings(source);
		CaptureWindow value = _captureWindow.Value;
		_capturePrompt.SetParentWindow(value);
		value.ShowWindow();
	}

	private void OnSelectScreenCommand(ScreenArrangementBase? screen)
	{
		if (screen != null)
		{
			ScreenID = screen.ID;
			ScreenName = screen.Name;
			NotifySelectedScreenSupportsHdr();
		}
	}

	private void NotifySelectedScreenSupportsHdr()
	{
		OnPropertyChanged("SelectedScreenSupportsHdr");
	}

	private void Screens_CollectionModified(ScreenArrangementCollectionBase screens)
	{
		if (IsLive && AudienceScreens.None((ScreenArrangementBase s) => s.ID == ScreenID) && StageScreens.None((ScreenArrangementBase s) => s.ID == ScreenID))
		{
			StopCapture();
		}
		UpdateScreenName();
	}

	private void UpdateScreenName()
	{
		ScreenArrangementBase screenArrangementBase = AudienceScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == ScreenID) ?? StageScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == ScreenID);
		if (screenArrangementBase != null)
		{
			ScreenName = screenArrangementBase.Name;
		}
	}

	private void StartCapture()
	{
		_captureService.StartScreenCapture();
	}

	private void StopCapture()
	{
		_captureService.StopScreenCapture();
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("ScreenID");
		OnPropertyChanged("ScreenName");
		OnPropertyChanged("Destination");
		OnPropertyChanged("StartStopButtonLabel");
	}

	public void RemoveLastCaptureInfo()
	{
		_captureService.RemoveLastCaptureInfo();
	}

	public void CheckResumeCapture()
	{
		_captureService.CheckResumeCapture();
	}
}
