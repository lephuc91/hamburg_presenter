using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Time;
using Pro.UI.Components;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface ICIMediaControlVM : INotifyPropertyChanged
{
	bool IsPlaying { get; set; }

	MediaCue? ActiveMediaCue { get; set; }

	TimeSlice InPoint { get; set; }

	TimeSlice OutPoint { get; set; }

	TimeSlice CurrentTime { get; set; }

	string CurrentTimeStr { get; }

	TimeSlice RemainingTime { get; }

	string RemainingTimeStr { get; }

	TimeSlice Duration { get; }

	IEnumerable<double> StepPositionIntervals { get; }

	double StepBackwardPosition { get; set; }

	double StepForwardPosition { get; set; }

	ICommand GoToCIMediaStartCommand { get; }

	ICommand GoToCIMediaEndCommand { get; }

	ICommand<bool> GoToCIPositionCommand { get; }

	ICommand StepCIMediaBackwardCommand { get; }

	ICommand StepCIMediaForwardCommand { get; }

	ICommand PauseCIMediaCommand { get; }

	ICommand PlayCIMediaCommand { get; }

	ICommand SetMediaInPointCommand { get; }

	ICommand SetMediaOutPointCommand { get; }

	ICommand JumpBack15SecondsCommand { get; }

	ICommand JumpForward15SecondsCommand { get; }

	ICommand<TimeSlice> JumpToCommand { get; }

	ICommand ResetInPointCommand { get; }

	ICommand ResetOutPointCommand { get; }

	ICommand<TimeSlice> BeginScrubCommand { get; }

	ICommand<TimeSlice> ScrubCommand { get; }

	ICommand<TimeSlice> EndScrubCommand { get; }

	ICommand StartDragInPointCommand { get; }

	ICommand StopDragInPointCommand { get; }

	ICommand StartDragOutPointCommand { get; }

	ICommand StopDragOutPointCommand { get; }

	ICommand<double> SetStepBackwardPositionCommand { get; }

	ICommand<double> SetStepForwardPositionCommand { get; }

	void SetToCurrentFrame();
}
