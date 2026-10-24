using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Timer;
using ProPresenter.UI;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.TransportStatus;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.TransportStatus;
using ProPresenter.ViewModels.ActionsMenu;
using ProPresenter.ViewModels.CueInspector;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.ViewModels.TransportStatus;

public class PlaybackStatusVM : LinkedNotifyPropertyChangedBase, IPlaybackStatusVM, INotifyPropertyChanged, IAddActionInteractor
{
	private readonly ICoreManager _manager;

	private readonly IPlaybackMarkerAnalyticsEvents _playbackMarkerAnalyticsEvents;

	private readonly IInputActions _inputActions;

	private readonly TransportStatusView _view;

	private bool _isEnabled;

	private TimeSlice _currentTime;

	private string _currentTimeStr = string.Empty;

	private string _previousMarkerTimeStr = string.Empty;

	private Color _previousMarkerColor;

	private TimeSlice _remainingTime;

	private string _remainingTimeStr = string.Empty;

	private string _nextMarkerTimeStr = string.Empty;

	private Color _nextMarkerColor;

	private TimeSlice _duration;

	private MediaStatus _playbackStatus = MediaStatus.Pause;

	private MediaCue? _triggeredCue;

	private MediaAction? _triggeredAction;

	private FileMediaBase? _triggeredMedia;

	private PlaybackMarkerCollection? _playbackMarkersSource;

	private readonly DragDropPairedCollection<IPlaybackMarker, IPlaybackMarkerItemVM> _playbackMarkers;

	private IPlaybackMarkerItemVM? _selectedPlaybackMarker;

	private TimeSlice? _contextMenuPosition;

	private bool _willAutoAdvance;

	private double _autoAdvanceProgress;

	private double _stepForwardPosition = 10.0;

	private TimerFormatData FormatData { get; }

	public MediaCue? TriggeredCue
	{
		get
		{
			return _triggeredCue;
		}
		set
		{
			SetValue("TriggeredCue", ref _triggeredCue, value);
		}
	}

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		private set
		{
			SetValue("IsEnabled", ref _isEnabled, value, delegate(bool o, bool n)
			{
				if (!n)
				{
					ResetStatus();
				}
			});
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
		private set
		{
			SetValue("CurrentTimeStr", ref _currentTimeStr, value);
		}
	}

	public string PreviousMarkerTimeStr
	{
		get
		{
			return _previousMarkerTimeStr;
		}
		private set
		{
			SetValue("PreviousMarkerTimeStr", ref _previousMarkerTimeStr, value);
		}
	}

	public Color PreviousMarkerColor
	{
		get
		{
			return _previousMarkerColor;
		}
		private set
		{
			SetValue("PreviousMarkerColor", ref _previousMarkerColor, value);
		}
	}

	public TimeSlice RemainingTime
	{
		get
		{
			return _remainingTime;
		}
		private set
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
		private set
		{
			SetValue("RemainingTimeStr", ref _remainingTimeStr, value);
		}
	}

	public string NextMarkerTimeStr
	{
		get
		{
			return _nextMarkerTimeStr;
		}
		private set
		{
			SetValue("NextMarkerTimeStr", ref _nextMarkerTimeStr, value);
		}
	}

	public Color NextMarkerColor
	{
		get
		{
			return _nextMarkerColor;
		}
		private set
		{
			SetValue("NextMarkerColor", ref _nextMarkerColor, value);
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

	public MediaStatus PlaybackStatus
	{
		get
		{
			return _playbackStatus;
		}
		private set
		{
			SetValue("PlaybackStatus", ref _playbackStatus, value);
		}
	}

	public FileMediaBase? TriggeredMedia
	{
		get
		{
			return _triggeredMedia;
		}
		private set
		{
			SetValue<FileMediaBase>("TriggeredMedia", ref _triggeredMedia, value, delegate(FileMediaBase o, FileMediaBase n)
			{
				IsEnabled = n is ITransportMedia;
				OnPropertyChanged("MediaName");
			});
		}
	}

	public string MediaName => TriggeredMedia?.SourceFile.Filename ?? string.Empty;

	public INotifyEnumerableChanged<IPlaybackMarkerItemVM> PlaybackMarkers => _playbackMarkers;

	public bool WillAutoAdvance
	{
		get
		{
			return _willAutoAdvance;
		}
		private set
		{
			SetValue("WillAutoAdvance", ref _willAutoAdvance, value);
		}
	}

	public double AutoAdvanceProgress
	{
		get
		{
			return _autoAdvanceProgress;
		}
		private set
		{
			SetValue("AutoAdvanceProgress", ref _autoAdvanceProgress, value);
		}
	}

	public double StepForwardPosition
	{
		get
		{
			return _stepForwardPosition;
		}
		private set
		{
			SetValue("StepForwardPosition", ref _stepForwardPosition, value);
		}
	}

	public IEnumerable<double> StepPositionIntervals => new double[9] { 0.0, 5.0, 10.0, 15.0, 20.0, 25.0, 30.0, 60.0, 90.0 };

	private TimeSlice EndTime => RemainingTime + CurrentTime;

	public IActionsMenuVM ActionsMenuVM { get; }

	public FrameworkElement? ContextMenuTarget { get; set; }

	public Color SelectedMarkerColor
	{
		get
		{
			return _selectedPlaybackMarker?.Color ?? default(Color);
		}
		set
		{
			if (_selectedPlaybackMarker != null)
			{
				_selectedPlaybackMarker.Color = value;
			}
			OnPropertyChanged("SelectedMarkerColor");
		}
	}

	public string SelectedMarkerName
	{
		get
		{
			return _selectedPlaybackMarker?.Name ?? string.Empty;
		}
		set
		{
			if (_selectedPlaybackMarker != null)
			{
				_selectedPlaybackMarker.Name = value;
			}
			OnPropertyChanged("SelectedMarkerName");
		}
	}

	public ICommand<IPlaybackMarkerItemVM> SelectMarkerCommand => new RelayCommand<IPlaybackMarkerItemVM>(delegate(IPlaybackMarkerItemVM m)
	{
		_selectedPlaybackMarker = m;
		if (m != null)
		{
			ActionsMenuVM.SelectedItem = m.Marker;
			ActionsMenuVM.SelectedItems.Clear();
			ActionsMenuVM.SelectedItems.Add(m.Marker);
		}
		OnPropertyChanged("SelectedMarkerColor");
		OnPropertyChanged("SelectedMarkerName");
	});

	public ICommand<TimeSlice?> SetContextMenuPositionCommand => new RelayCommand<TimeSlice?>(delegate(TimeSlice? t)
	{
		_contextMenuPosition = t;
	});

	public ICommand MoveToPlayheadCommand => new RelayCommand(delegate
	{
		if (_selectedPlaybackMarker != null)
		{
			_selectedPlaybackMarker.StartDragCommand?.Invoke();
			_selectedPlaybackMarker.Timestamp = CurrentTime + ((TriggeredMedia as ITransportMedia)?.Transport?.InPoint ?? TimeSlice.Zero);
			_selectedPlaybackMarker.StopDragCommand?.Invoke();
		}
	});

	public ICommand PlayCommand => new RelayCommand(OnPlayCommand);

	public ICommand PauseCommand => new RelayCommand(OnPauseCommand);

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
		OnEndScrubCommand(pos);
	});

	public ICommand JumpBack15SecondsCommand => new RelayCommand(OnJumpBack15SecondsCommand);

	public ICommand JumpForward15SecondsCommand => new RelayCommand(OnJumpForward15SecondsCommand);

	public ICommand<double> SetStepForwardPositionCommand => new RelayCommand<double>(OnSetStepForwardPositionCommand);

	public ICommand GotoPositionCommand => new RelayCommand(delegate
	{
		OnGotoPositionCommand(StepForwardPosition);
	});

	public ICommand<IPlaybackMarkerItemVM> JumpToPlaybackMarkerCommand => new RelayCommand<IPlaybackMarkerItemVM>(JumpToPlaybackMarkerExecute, (IPlaybackMarkerItemVM m) => m != null);

	public ICommand AddPlaybackMarkerCommand => new RelayCommand(AddPlaybackMarkerExecute);

	public ICommand OpenPlaybackMarkersCommand => new RelayCommand(OpenPlaybackMarkersExecute);

	public ICommand CopyMarkersCommand => new RelayCommand(CopyMarkersExecute, () => _triggeredAction != null && _selectedPlaybackMarker != null);

	public ICommand CutMarkersCommand => new RelayCommand(CutMarkersExecute, () => _triggeredAction != null && _selectedPlaybackMarker != null);

	public ICommand PasteMarkersCommand => new RelayCommand(PasteMarkersExecute, () => _triggeredAction != null && ClipboardManagerHelper.CanPasteIntoCollection<IPlaybackMarker>());

	public ICommand DuplicateMarkersCommand => new RelayCommand(DuplicateMarkersExecute, () => _triggeredAction != null && _selectedPlaybackMarker != null);

	public ICommand DeleteMarkersCommand => new RelayCommand(DeleteMarkersExecute, () => _triggeredAction != null && _selectedPlaybackMarker != null);

	public ICommand GotFocusCommand => new RelayCommand(GotFocusExecute);

	public event Action<UndoStack?>? StackChanged;

	public event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public PlaybackStatusVM(ICoreManager manager, TransportStatusView view, ITransportMediaProvider mediaProvider, IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents, IActionsMenuVMFactory actionsMenuVMFactory, IInputActions inputActions)
	{
		_manager = manager;
		_playbackMarkerAnalyticsEvents = playbackMarkerAnalyticsEvents;
		_inputActions = inputActions;
		FormatData = new TimerFormatData
		{
			HourFormat = TimerFormatStyle.LongTruncated,
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.Long,
			MillisecondFormat = TimerFormatStyle.None
		};
		_manager.TransportStatusChanged += CoreManager_TransportStatusChanged;
		_manager.WillGotoNextUpdated += CoreManager_WillGotoNextUpdated;
		_view = view;
		_playbackMarkers = new DragDropPairedCollection<IPlaybackMarker, IPlaybackMarkerItemVM>(null, (IPlaybackMarker m) => new PlaybackMarkerItemVM(m), delegate(IPlaybackMarkerItemVM t)
		{
			((PlaybackMarkerItemVM)t).Dispose();
		});
		if (mediaProvider != null)
		{
			mediaProvider.MediaTriggered += delegate(MediaCue? c, MediaAction? m, PlaybackMarkerCollection? p)
			{
				TriggeredCue = c;
				_triggeredAction = m;
				TriggeredMedia = m?.FileMedia;
				_playbackMarkersSource = p;
				_playbackMarkers.ChangeSource(p);
			};
		}
		ActionsMenuVM = actionsMenuVMFactory.Create(this);
		ActionsMenuVM.ShowActionDialog += delegate(IAction? a, IActionRepository? i, IEnumerable<IActionRepository> c)
		{
			this.ShowActionDialog?.Invoke(ContextMenuTarget, a, i, c);
		};
		CurrentTimeStr = TimeSlice.Zero.FormatTime(0.0, _view != TransportStatusView.Audio, FormatData);
		RemainingTimeStr = TimeSlice.Zero.FormatTime(0.0, _view != TransportStatusView.Audio, FormatData);
	}

	private void CoreManager_TransportStatusChanged(ResourceAddress address, ProTransportStatus transportStatus)
	{
		TimeSlice markerOffset;
		TimeSlice loopDuration;
		int loopCount;
		if (TriggeredMedia is ITransportMedia && address.Layer.ToTransportStatusView() == _view)
		{
			TimeSlice timeSlice = TimeSlice.FromSeconds(Math.Max(0.0, transportStatus.TimeElapsed));
			TimeSlice timeSlice2 = TimeSlice.FromSeconds(Math.Max(0.0, transportStatus.TimeRemaining));
			TimeSlice timeSlice3 = timeSlice + timeSlice2;
			if ((Duration - timeSlice3).Abs() >= TimeSlice.FromMilliseconds(1.0))
			{
				Duration = timeSlice3;
			}
			TransportProperties transportProperties = (TriggeredMedia as ITransportMedia)?.Transport;
			markerOffset = transportProperties?.InPoint ?? TimeSlice.Zero;
			loopDuration = transportProperties?.InOutDuration ?? Duration;
			TimeSlice loopTimeElapsed = ((loopDuration > TimeSlice.Zero) ? (timeSlice % loopDuration) : timeSlice);
			loopCount = ((!(loopDuration > TimeSlice.Zero)) ? 1 : ((int)Math.Floor(timeSlice / loopDuration)));
			IPlaybackMarkerItemVM playbackMarkerItemVM = PlaybackMarkers.LastOrDefault((IPlaybackMarkerItemVM m) => isMarkerRangeValid(m) && m.Timestamp - markerOffset < loopTimeElapsed);
			IPlaybackMarkerItemVM playbackMarkerItemVM2 = PlaybackMarkers.FirstOrDefault((IPlaybackMarkerItemVM m) => isMarkerRangeValid(m) && m.Timestamp - markerOffset >= loopTimeElapsed);
			CurrentTime = timeSlice;
			CurrentTimeStr = CurrentTime.FormatTime(transportStatus.Fps, _view != TransportStatusView.Audio, FormatData);
			PreviousMarkerTimeStr = ((playbackMarkerItemVM != null) ? (loopTimeElapsed - (playbackMarkerItemVM.Timestamp - markerOffset)).FormatTime(transportStatus.Fps, _view != TransportStatusView.Audio, FormatData) : string.Empty);
			PreviousMarkerColor = playbackMarkerItemVM?.Color ?? default(Color);
			RemainingTime = timeSlice2;
			RemainingTimeStr = RemainingTime.FormatTime(transportStatus.Fps, _view != TransportStatusView.Audio, FormatData);
			NextMarkerTimeStr = ((playbackMarkerItemVM2 != null) ? (playbackMarkerItemVM2.Timestamp - markerOffset - loopTimeElapsed).FormatTime(transportStatus.Fps, _view != TransportStatusView.Audio, FormatData) : string.Empty);
			NextMarkerColor = playbackMarkerItemVM2?.Color ?? default(Color);
			PlaybackStatus = ((!transportStatus.IsPlaying) ? MediaStatus.Pause : MediaStatus.Play);
		}
		bool isMarkerRangeValid(IPlaybackMarkerItemVM marker)
		{
			TimeSlice timeSlice4 = marker.Timestamp - markerOffset;
			if (timeSlice4 >= TimeSlice.Zero && timeSlice4 <= loopDuration)
			{
				return timeSlice4 + loopDuration * loopCount <= Duration;
			}
			return false;
		}
	}

	private void CoreManager_WillGotoNextUpdated(ProLayerIndex layer, bool willAutoAdvance, double progress)
	{
		if (layer.ToTransportStatusView() == _view && layer != ProLayerIndex.PresentationBackground)
		{
			WillAutoAdvance = willAutoAdvance;
			AutoAdvanceProgress = progress;
		}
	}

	private void ResetStatus()
	{
		CurrentTime = TimeSlice.Zero;
		RemainingTime = TimeSlice.Zero;
		CurrentTimeStr = TimeSlice.Zero.FormatTime(0.0, _view != TransportStatusView.Audio, FormatData);
		PreviousMarkerTimeStr = string.Empty;
		RemainingTimeStr = TimeSlice.Zero.FormatTime(0.0, _view != TransportStatusView.Audio, FormatData);
		NextMarkerTimeStr = string.Empty;
		Duration = TimeSlice.Zero;
		PlaybackStatus = MediaStatus.Pause;
	}

	private void OnPlayCommand()
	{
		if (_isEnabled)
		{
			_view.ViewAction(delegate
			{
				_manager.PlayPresentationBackground();
			}, delegate
			{
				_manager.PlayAnnouncementBackground();
			}, delegate
			{
				_manager.PlayAudio(AudioType.AudioTrack);
			});
		}
	}

	private void OnPauseCommand()
	{
		if (_isEnabled)
		{
			_view.ViewAction(delegate
			{
				_manager.PausePresentationBackground();
			}, delegate
			{
				_manager.PauseAnnouncementBackground();
			}, delegate
			{
				_manager.PauseAudio(AudioType.AudioTrack);
			});
		}
	}

	private void OnBeginScrubCommand(TimeSlice requestedTime)
	{
		if (_isEnabled)
		{
			_view.ViewAction(delegate
			{
				_manager.BeginPresentationBackgroundScrub(requestedTime);
			}, delegate
			{
				_manager.BeginAnnouncementBackgroundScrub(requestedTime);
			}, delegate
			{
				_manager.BeginAudioScrub(AudioType.AudioTrack, requestedTime);
			});
		}
	}

	private void OnScrubCommand(TimeSlice requestedTime)
	{
		if (_isEnabled)
		{
			_view.ViewAction(delegate
			{
				_manager.ScrubPresentationBackground(requestedTime);
			}, delegate
			{
				_manager.ScrubAnnouncementBackground(requestedTime);
			}, delegate
			{
				_manager.ScrubAudio(AudioType.AudioTrack, requestedTime);
			});
		}
	}

	private void OnEndScrubCommand(TimeSlice requestedTime)
	{
		if (_isEnabled)
		{
			_view.ViewAction(delegate
			{
				_manager.EndPresentationBackgroundScrub(requestedTime);
			}, delegate
			{
				_manager.EndAnnouncementBackgroundScrub(requestedTime);
			}, delegate
			{
				_manager.EndAudioScrub(AudioType.AudioTrack, requestedTime);
			});
		}
	}

	private void OnJumpBack15SecondsCommand()
	{
		TimeSlice position = CurrentTime - TimeSlice.FromSeconds(15.0);
		_view.ViewAction(delegate
		{
			_manager.SetPresentationBackgroundPos(position);
		}, delegate
		{
			_manager.SetAnnouncementBackgroundPos(position);
		}, delegate
		{
			_manager.SetAudioPos(AudioType.AudioTrack, position);
		});
		_manager.NetworkCommandTrigger.OnSkipBackward(_view.ToProLayerIndex(), 15);
	}

	private void OnJumpForward15SecondsCommand()
	{
		TimeSlice position = CurrentTime + TimeSlice.FromSeconds(15.0);
		_view.ViewAction(delegate
		{
			_manager.SetPresentationBackgroundPos(position);
		}, delegate
		{
			_manager.SetAnnouncementBackgroundPos(position);
		}, delegate
		{
			_manager.SetAudioPos(AudioType.AudioTrack, position);
		});
		_manager.NetworkCommandTrigger.OnSkipForward(_view.ToProLayerIndex(), 15);
	}

	private void OnSetStepForwardPositionCommand(double pos)
	{
		StepForwardPosition = pos;
		OnGotoPositionCommand(pos);
	}

	private void OnGotoPositionCommand(double pos)
	{
		TimeSlice position = EndTime - TimeSlice.FromSeconds(pos);
		if (position >= EndTime)
		{
			_view.ViewAction(delegate
			{
				_manager.GotoPresentationBackgroundEnd();
			}, delegate
			{
				_manager.GotoAnnouncementBackgroundEnd();
			}, delegate
			{
				_manager.GotoAudioEnd(AudioType.AudioTrack);
			});
		}
		else if (position == TimeSlice.Zero)
		{
			_view.ViewAction(delegate
			{
				_manager.GotoPresentationBackgroundStart();
			}, delegate
			{
				_manager.GotoAnnouncementBackgroundStart();
			}, delegate
			{
				_manager.GotoAudioStart(AudioType.AudioTrack);
			});
		}
		else
		{
			_view.ViewAction(delegate
			{
				_manager.SetPresentationBackgroundPos(position);
			}, delegate
			{
				_manager.SetAnnouncementBackgroundPos(position);
			}, delegate
			{
				_manager.SetAudioPos(AudioType.AudioTrack, position);
			});
		}
		_manager.NetworkCommandTrigger.OnGotoEnd(_view.ToProLayerIndex(), (int)pos);
	}

	private void JumpToPlaybackMarkerExecute(IPlaybackMarkerItemVM playbackMarker)
	{
		TimeSlice timestamp = playbackMarker.Timestamp - ((TriggeredMedia as ITransportMedia)?.Transport?.InPoint ?? TimeSlice.Zero);
		_view.ViewAction(delegate
		{
			_manager.SetPresentationBackgroundPos(timestamp);
		}, delegate
		{
			_manager.SetAnnouncementBackgroundPos(timestamp);
		}, delegate
		{
			_manager.SetAudioPos(AudioType.AudioTrack, timestamp);
		});
	}

	private TimeSlice GetNewMarkerTimestamp()
	{
		TransportProperties obj = (TriggeredMedia as ITransportMedia)?.Transport;
		TimeSlice timeSlice = obj?.InOutDuration ?? TimeSlice.MaxValue;
		TimeSlice timeSlice2 = obj?.InPoint ?? TimeSlice.Zero;
		return (_contextMenuPosition ?? (CurrentTime % timeSlice)) + timeSlice2;
	}

	private void AddPlaybackMarkerExecute()
	{
		_playbackMarkerAnalyticsEvents.Create(PlaybackMarkerCreateLocation.Sidebar);
		_playbackMarkersSource?.AddMarker(new PlaybackMarker
		{
			Timestamp = GetNewMarkerTimestamp()
		});
	}

	private void OpenPlaybackMarkersExecute()
	{
		InspectorOptions options = InspectorOptions.Default | InspectorOptions.SwitchToMarkerTab;
		_inputActions.ProCommon.OpenMediaInspector.BindCommand?.Execute(new InspectorParameter((_triggeredCue ?? new MediaCue(_triggeredAction)).ToEnumerable(), options));
	}

	private void CopyMarkersExecute()
	{
		if (_selectedPlaybackMarker != null)
		{
			IEnumerable<IPlaybackMarker> enumerable = _selectedPlaybackMarker.Marker.ToEnumerable();
			if (enumerable.Any())
			{
				ClipboardManagerHelper.CopyFromCollection(enumerable);
			}
		}
	}

	private void CutMarkersExecute()
	{
		CopyMarkersExecute();
		DeleteMarkersExecute();
	}

	private void PasteMarkersExecute()
	{
		PlaybackMarkerCollection playbackMarkerCollection = _triggeredAction?.PlaybackMarkers;
		if (playbackMarkerCollection != null)
		{
			playbackMarkerCollection.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddPlaybackMarker));
			ClipboardManagerHelper.PasteIntoCollection<PlaybackMarkerCollection, IPlaybackMarker>(playbackMarkerCollection, 0).ForEach(delegate(IPlaybackMarker m)
			{
				m.Timestamp = GetNewMarkerTimestamp();
			});
			playbackMarkerCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private void DuplicateMarkersExecute()
	{
		PlaybackMarkerCollection playbackMarkerCollection = _triggeredAction?.PlaybackMarkers;
		if (_selectedPlaybackMarker == null || playbackMarkerCollection == null)
		{
			return;
		}
		playbackMarkerCollection.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddPlaybackMarker));
		foreach (IPlaybackMarker item in _selectedPlaybackMarker.Marker.Clone().ToEnumerable())
		{
			playbackMarkerCollection.InsertMarker(item, 0);
			item.Timestamp = GetNewMarkerTimestamp();
		}
		playbackMarkerCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void DeleteMarkersExecute()
	{
		if (_selectedPlaybackMarker != null)
		{
			_triggeredAction?.PlaybackMarkers.RemoveMarker(_selectedPlaybackMarker.Marker);
		}
	}

	private void GotFocusExecute()
	{
		this.StackChanged?.Invoke(_triggeredAction?.UndoStack);
	}

	public IAction? Execute(IAction? action)
	{
		if (action == null)
		{
			return action;
		}
		IAction result = null;
		if (_selectedPlaybackMarker != null)
		{
			IAction action2 = action.Clone();
			_selectedPlaybackMarker.Marker.AddAction(action2);
			result = action2;
		}
		return result;
	}
}
