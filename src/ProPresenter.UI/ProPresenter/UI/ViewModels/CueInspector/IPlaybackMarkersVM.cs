using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.UI.CueInspector;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IPlaybackMarkersVM : INotifyPropertyChanged
{
	MediaCue? ActiveMediaCue { get; set; }

	INotifyEnumerableChanged<IPlaybackMarkerItemVM> PlaybackMarkers { get; }

	IPlaybackMarkerItemVM? SelectedPlaybackMarker { get; set; }

	ObservableCollection<IPlaybackMarkerItemVM> SelectedPlaybackMarkers { get; }

	IActionsMenuVM ActionsMenuVM { get; }

	Color MarkerColor { get; set; }

	string MarkerName { get; set; }

	FrameworkElement? ContextMenuTarget { get; set; }

	ICommand AddMarkerCommand { get; }

	ICommand MoveToPlayheadCommand { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand<IPlaybackMarkerItemVM> SelectMarkerCommand { get; }

	ICommand<IPlaybackMarkerItemVM> MovePlayheadToMarkerCommand { get; }

	ICommand<TimeSlice?> SetContextMenuPositionCommand { get; }

	ICommand<PlaybackMarkerDropParameter> DropActionCommand { get; }

	ICommand<FrameworkElement> UpdateDialogPlacementCommand { get; }

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	event Action<FrameworkElement>? UpdateDialogPlacement;
}
