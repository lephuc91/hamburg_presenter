using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IPropertiesVM : INotifyPropertyChanged
{
	InlineType ActiveInlineView { get; set; }

	MediaCue? ActiveMediaCue { get; set; }

	bool SupportsScaleAndBlur { get; }

	bool SupportsCustomScale { get; }

	bool SupportsScaleAlignment { get; }

	ScaleBehavior ScaleBehavior { get; set; }

	ScaleAlignment ScaleAlignment { get; set; }

	bool FlipHorizontally { get; set; }

	bool FlipVertically { get; set; }

	Vector2<double> CropPosition { get; set; }

	Vector2<double> CropSize { get; set; }

	bool CropEnable { get; set; }

	double CropLeftMax { get; }

	double CropRightMax { get; }

	double CropTopMax { get; }

	double CropBottomMax { get; }

	double CropTop { get; set; }

	double CropLeft { get; set; }

	double CropRight { get; set; }

	double CropBottom { get; set; }

	NativeRotation Rotation { get; set; }

	MediaType MediaType { get; }

	double PlayRate { get; set; }

	PlaybackBehaviorType PlaybackBehavior { get; set; }

	RetriggerBehavior RetriggerBehavior { get; set; }

	AudioBehaviorType AudioBehaviorType { get; set; }

	int LoopCount { get; set; }

	TimeSlice LoopTime { get; set; }

	bool SoftLoop { get; set; }

	EndBehaviorType EndBehavior { get; set; }

	TimeSlice InPoint { get; set; }

	TimeSlice OutPoint { get; set; }

	TimeSlice Duration { get; set; }

	TimeSlice DelayTime { get; set; }

	TransitionHandler TransitionHandler { get; }

	TransitionParameters? SelectedTransition { get; set; }

	IEnumerable<AudioBehaviorType> AudioBehaviors { get; }

	bool SupportsAudioNextBehavior { get; set; }

	ICommand SetMediaInPointCommand { get; }

	ICommand SetMediaOutPointCommand { get; }

	bool ShowRetriggeringBehaviorField { get; set; }

	AlphaType AlphaType { get; set; }

	double FrameRate { get; }
}
