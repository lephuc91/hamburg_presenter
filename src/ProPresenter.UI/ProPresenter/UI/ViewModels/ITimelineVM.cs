using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.Controls;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.ViewModels;

public interface ITimelineVM : ICutPasteCollection<IAction>, ICutCollection<IAction>
{
	IActionsMenuVM? ActionsMenuVM { get; set; }

	ICollectionView ActionsView { get; }

	ICommand<TimeSlice> AddAudioActionCommand { get; }

	ICommand<TimeSlice> AddMediaActionCommand { get; }

	ICollectionView AudioView { get; }

	bool CanFollowTimecode { get; }

	ICollectionView CuesView { get; }

	TimeSlice CurrentTime { get; set; }

	ICommand DeleteCommand { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DeselectAllCommand { get; }

	IDocumentCue? DocumentCue { get; set; }

	ICommand<IDocumentCue> DocumentCueUpdatedCommand { get; }

	ICommand<TimeSlice> EndScrubCommand { get; }

	Func<ActionBase, FrameworkElement>? FindActionDialogPlacementCallback { get; set; }

	double Fps { get; }

	bool IsPlaying { get; set; }

	bool IsRecording { get; set; }

	bool IsSetToLoop { get; set; }

	bool IsTimecodeEnabled { get; set; }

	ICommand<TimeSlice> JumpToTimeCommand { get; }

	ICollectionView MediaView { get; }

	ICommand<ITimelineItemVM> OpenInspectorCommand { get; }

	ICommand PlayCommand { get; }

	ICommand RecordCommand { get; }

	ICommand ResetCommand { get; }

	ICommand SelectAllCommand { get; }

	ObservableCollection<IActionRepository> SelectedActions { get; }

	AudioBehaviorType SelectedAudioBehaviorType { get; }

	MediaAction? SelectedAudioItem { get; }

	ObservableCollection<ITimelineItemVM> SelectedItems { get; }

	MediaAction? SelectedMediaItem { get; }

	ICommand<EndBehaviorType> SetEndBehaviorTypeCommand { get; }

	ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand { get; }

	ICommand<PlaybackBehaviorType> SetPlaybackCommand { get; }

	ICommand<TimeSlice?> SetSoftLoopDurationCommand { get; }

	ICommand<MediaAction> ShowInFileExplorerCommand { get; }

	ICommand<TimeSlice> StartScrubCommand { get; }

	ProPresenter.DO.Presentation.Timeline? Timeline { get; set; }

	ICommand<ITimelineItemDropArgs> TimelineItemDroppedCommand { get; }

	PairedCollection<TimelineItemInfo, ITimelineItemVM>? TimelineItems { get; }

	ICommand<AudioBehaviorType> UpdateAudioBehaviorCommand { get; }

	double ZoomMinimum { get; }

	double ZoomValue { get; set; }

	void SetTransition(TransitionParameters currentTransition, UIElement placementTarget, Action<TransitionParameters> setTransitionCallback);
}
