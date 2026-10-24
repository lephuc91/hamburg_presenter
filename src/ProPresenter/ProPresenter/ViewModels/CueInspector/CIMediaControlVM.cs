using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.ViewModels.CueInspector;

public class CIMediaControlVM : LinkedNotifyPropertyChangedBase, ICIMediaControlVM, INotifyPropertyChanged
{
	private bool _isPlaying;

	private readonly ICoreManager _manager;

	private MediaCue? _activeMediaCue;

	private TimeSlice _currentTime;

	private string _currentTimeStr = string.Empty;

	private TimeSlice _remainingTime;

	private string _remainingTimeStr = string.Empty;

	private TimeSlice _duration;

	private double _stepBackwardPosition;

	private double _stepForwardPosition;

	private TimerFormatData FormatData { get; }

	public bool IsPlaying
	{
		get
		{
			return _isPlaying;
		}
		set
		{
			SetValue("IsPlaying", ref _isPlaying, value);
		}
	}

	public MediaCue? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<MediaCue>("ActiveMediaCue", ref _activeMediaCue, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null)
				{
					TransportProperties transportProperties = (o.MediaAction?.Media as ITransportMedia)?.Transport;
					if (transportProperties != null)
					{
						transportProperties.PropertyChanged -= base.RaiseLinkedValues;
					}
				}
				if (n != null)
				{
					TransportProperties transportProperties2 = (n.MediaAction?.Media as ITransportMedia)?.Transport;
					if (transportProperties2 != null)
					{
						transportProperties2.PropertyChanged += base.RaiseLinkedValues;
					}
				}
				OnPropertyChanged("InPoint");
				OnPropertyChanged("OutPoint");
			});
		}
	}

	private TransportProperties? Transport => (ActiveMediaCue?.MediaAction?.Media as ITransportMedia)?.Transport;

	private MediaMetadata? Metadata => ActiveMediaCue?.MediaAction?.FileMedia?.Metadata;

	public TimeSlice InPoint
	{
		get
		{
			return Transport?.InPoint ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null)
			{
				Transport.InPoint = value;
			}
		}
	}

	public TimeSlice OutPoint
	{
		get
		{
			return Transport?.OutPoint ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null)
			{
				Transport.OutPoint = value;
			}
		}
	}

	public TimeSlice CurrentTime
	{
		get
		{
			return _currentTime;
		}
		set
		{
			SetValue("CurrentTime", ref _currentTime, value);
		}
	}

	public string CurrentTimeStr
	{
		get
		{
			return _currentTimeStr;
		}
		set
		{
			SetValue("CurrentTimeStr", ref _currentTimeStr, value);
		}
	}

	public TimeSlice RemainingTime
	{
		get
		{
			return _remainingTime;
		}
		set
		{
			SetValue("RemainingTime", ref _remainingTime, value);
		}
	}

	public string RemainingTimeStr
	{
		get
		{
			return _remainingTimeStr;
		}
		set
		{
			SetValue("RemainingTimeStr", ref _remainingTimeStr, value);
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			SetValue("Duration", ref _duration, value);
		}
	}

	public IEnumerable<double> StepPositionIntervals => new double[9] { 0.0, 5.0, 10.0, 15.0, 20.0, 25.0, 30.0, 60.0, 90.0 };

	public double StepBackwardPosition
	{
		get
		{
			return _stepBackwardPosition;
		}
		set
		{
			SetValue("StepBackwardPosition", ref _stepBackwardPosition, value);
		}
	}

	public double StepForwardPosition
	{
		get
		{
			return _stepForwardPosition;
		}
		set
		{
			SetValue("StepForwardPosition", ref _stepForwardPosition, value);
		}
	}

	public ICommand GoToCIMediaStartCommand => new RelayCommand(_manager.GoToStartCI);

	public ICommand GoToCIMediaEndCommand => new RelayCommand(_manager.GoToEndCI);

	public ICommand<bool> GoToCIPositionCommand => new RelayCommand<bool>(OnGoToCIPositionCommand);

	public ICommand StepCIMediaBackwardCommand => new RelayCommand(_manager.StepBackwardCI);

	public ICommand PauseCIMediaCommand => new RelayCommand(_manager.PauseCI);

	public ICommand PlayCIMediaCommand => new RelayCommand(_manager.PlayCI);

	public ICommand StepCIMediaForwardCommand => new RelayCommand(_manager.StepForwardCI);

	public ICommand SetMediaInPointCommand => new RelayCommand(OnSetVideoInPointCommand, () => Transport != null);

	public ICommand SetMediaOutPointCommand => new RelayCommand(OnSetVideoOutPointCommand, () => Transport != null);

	public ICommand JumpBack15SecondsCommand => new RelayCommand(OnJumpBack15SecondsCommand, () => Transport != null);

	public ICommand JumpForward15SecondsCommand => new RelayCommand(OnJumpForward15SecondsCommand, () => Transport != null);

	public ICommand<TimeSlice> JumpToCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice pos)
	{
		OnJumpToCommand(pos);
	}, (TimeSlice pos) => Transport != null);

	public ICommand ResetInPointCommand => new RelayCommand(OnResetInPointCommand, () => Transport != null);

	public ICommand ResetOutPointCommand => new RelayCommand(OnResetOutPointCommand, () => Transport != null);

	public ICommand<TimeSlice> BeginScrubCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice pos)
	{
		OnBeginScrubCommand(pos);
	});

	public ICommand<TimeSlice> ScrubCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice pos)
	{
		OnScrubCommand(pos);
	});

	public ICommand<TimeSlice> EndScrubCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice pos)
	{
		OnEndScrubComand(pos);
	});

	public ICommand StartDragInPointCommand => new RelayCommand(delegate
	{
		Transport?.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaInPoint));
	});

	public ICommand StopDragInPointCommand => new RelayCommand(delegate
	{
		Transport?.UndoStack?.EndCommit(null, null, autoFinalize: true);
	});

	public ICommand StartDragOutPointCommand => new RelayCommand(delegate
	{
		Transport?.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaOutPoint));
	});

	public ICommand StopDragOutPointCommand => new RelayCommand(delegate
	{
		Transport?.UndoStack?.EndCommit(null, null, autoFinalize: true);
	});

	public ICommand<double> SetStepBackwardPositionCommand => new RelayCommand<double>(delegate(double pos)
	{
		StepBackwardPosition = pos;
		OnGoToCIPositionCommand(isBackward: true);
	});

	public ICommand<double> SetStepForwardPositionCommand => new RelayCommand<double>(delegate(double pos)
	{
		StepForwardPosition = pos;
		OnGoToCIPositionCommand(isBackward: false);
	});

	public CIMediaControlVM(ICoreManager coreManager)
	{
		_manager = coreManager;
		FormatData = new TimerFormatData
		{
			HourFormat = TimerFormatStyle.LongTruncated,
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.Long,
			MillisecondFormat = TimerFormatStyle.None
		};
		_manager.TransportStatusChanged += CoreManager_TransportStatusChanged;
		LinkProperties("InPoint", "InPoint");
		LinkProperties("OutPoint", "OutPoint");
	}

	private void CoreManager_TransportStatusChanged(ResourceAddress address, ProTransportStatus transportStatus)
	{
		if (address.Layer == ProLayerIndex.Inspector)
		{
			if (Metadata != null && Transport != null)
			{
				double seconds = Math.Max(0.0, transportStatus.TimeElapsed);
				double seconds2 = Math.Max(0.0, transportStatus.TimeRemaining);
				CurrentTime = TimeSlice.FromSeconds(seconds);
				CurrentTimeStr = CurrentTime.FormatTime(transportStatus.Fps, showSubSeconds: true, FormatData);
				RemainingTime = TimeSlice.FromSeconds(seconds2);
				RemainingTimeStr = RemainingTime.FormatTime(transportStatus.Fps, showSubSeconds: true, FormatData);
				Duration = CurrentTime + RemainingTime;
			}
			IsPlaying = transportStatus.IsPlaying;
		}
	}

	private void OnGoToCIPositionCommand(bool isBackward)
	{
		TimeSlice timeSlice = (isBackward ? (InPoint + TimeSlice.FromSeconds(StepBackwardPosition)) : (OutPoint - TimeSlice.FromSeconds(StepForwardPosition)));
		if (timeSlice >= (Metadata?.Duration ?? ActiveMediaCue?.MediaAction?.MediaDuration ?? TimeSlice.Zero))
		{
			_manager.GoToEndCI();
		}
		else if (timeSlice <= TimeSlice.Zero)
		{
			_manager.GoToStartCI();
		}
		else
		{
			_manager.GoToPosCI(timeSlice);
		}
	}

	private void OnSetVideoInPointCommand()
	{
		if (Transport != null)
		{
			if (CurrentTime > OutPoint)
			{
				OutPoint = Metadata?.Duration ?? CurrentTime;
			}
			InPoint = CurrentTime;
			_manager.MarkCIInPoint(Transport.InPoint);
		}
	}

	private void OnSetVideoOutPointCommand()
	{
		if (Transport != null)
		{
			if (CurrentTime < InPoint)
			{
				InPoint = TimeSlice.Zero;
			}
			OutPoint = CurrentTime;
			_manager.MarkCIOutPoint(Transport.OutPoint);
		}
	}

	private void OnJumpForward15SecondsCommand()
	{
		_manager.GoToPosCI(TimeSlice.FromSeconds(_currentTime.TotalSeconds + 15.0));
	}

	private void OnJumpBack15SecondsCommand()
	{
		_manager.GoToPosCI(TimeSlice.FromSeconds(_currentTime.TotalSeconds - 15.0));
	}

	private void OnJumpToCommand(TimeSlice time)
	{
		_manager.GoToPosCI(time);
	}

	private void OnResetInPointCommand()
	{
		if (Transport != null)
		{
			InPoint = TimeSlice.Zero;
			_manager.MarkCIInPoint(Transport.InPoint);
		}
	}

	private void OnResetOutPointCommand()
	{
		if (Transport != null)
		{
			OutPoint = Transport.EndPoint;
			_manager.MarkCIOutPoint(Transport.OutPoint);
		}
	}

	private void OnBeginScrubCommand(TimeSlice requestedTime)
	{
		_manager.BeginCIScrub(requestedTime);
	}

	private void OnScrubCommand(TimeSlice requestedTime)
	{
		_manager.ScrubCIPos(requestedTime);
	}

	private void OnEndScrubComand(TimeSlice requestedTime)
	{
		_manager.EndCIScrub(requestedTime);
	}

	public void SetToCurrentFrame()
	{
		if (ActiveMediaCue?.MediaAction?.Media is VisualMedia visualMedia)
		{
			if (visualMedia is IVideoMedia videoMedia)
			{
				videoMedia.Video.ThumbnailPosition = CurrentTime.TotalSeconds;
			}
			visualMedia.RefreshThumbnail(userInitiated: true);
		}
	}
}
