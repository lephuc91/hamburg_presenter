using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.UI.ViewModels.TransportStatus;

public interface IPlaybackStatusVM : INotifyPropertyChanged
{
	bool IsEnabled { get; }

	TimeSlice CurrentTime { get; set; }

	string CurrentTimeStr { get; }

	string PreviousMarkerTimeStr { get; }

	Color PreviousMarkerColor { get; }

	TimeSlice RemainingTime { get; }

	string RemainingTimeStr { get; }

	string NextMarkerTimeStr { get; }

	Color NextMarkerColor { get; }

	TimeSlice Duration { get; }

	MediaStatus PlaybackStatus { get; }

	FileMediaBase? TriggeredMedia { get; }

	string MediaName { get; }

	INotifyEnumerableChanged<IPlaybackMarkerItemVM> PlaybackMarkers { get; }

	bool WillAutoAdvance { get; }

	double AutoAdvanceProgress { get; }

	double StepForwardPosition { get; }

	IEnumerable<double> StepPositionIntervals { get; }

	IActionsMenuVM ActionsMenuVM { get; }

	FrameworkElement? ContextMenuTarget { get; set; }

	Color SelectedMarkerColor { get; set; }

	string SelectedMarkerName { get; set; }

	ICommand<IPlaybackMarkerItemVM> SelectMarkerCommand { get; }

	ICommand<TimeSlice?> SetContextMenuPositionCommand { get; }

	ICommand MoveToPlayheadCommand { get; }

	ICommand GotoPositionCommand { get; }

	ICommand PlayCommand { get; }

	ICommand PauseCommand { get; }

	ICommand<TimeSlice> BeginScrubCommand { get; }

	ICommand<TimeSlice> ScrubCommand { get; }

	ICommand<TimeSlice> EndScrubCommand { get; }

	ICommand JumpBack15SecondsCommand { get; }

	ICommand JumpForward15SecondsCommand { get; }

	ICommand<double> SetStepForwardPositionCommand { get; }

	ICommand<IPlaybackMarkerItemVM> JumpToPlaybackMarkerCommand { get; }

	ICommand AddPlaybackMarkerCommand { get; }

	ICommand OpenPlaybackMarkersCommand { get; }

	ICommand CopyMarkersCommand { get; }

	ICommand CutMarkersCommand { get; }

	ICommand PasteMarkersCommand { get; }

	ICommand DuplicateMarkersCommand { get; }

	ICommand DeleteMarkersCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack?>? StackChanged;

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;
}
