using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.UI;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.ViewModels.Actions;
using ProPresenter.ViewModels.ActionsMenu;
using ProPresenter.ViewModels.Props;

namespace ProPresenter.ViewModels.CueInspector;

public class PlaybackMarkersVM : NotifyPropertyChangedBase, IPlaybackMarkersVM, INotifyPropertyChanged, IAddActionInteractor
{
	private readonly ICoreManager _manager;

	private readonly IPlaybackMarkerAnalyticsEvents _playbackMarkerAnalyticsEvents;

	private readonly ICIMediaControlVM _ciMediaControlVM;

	private readonly IEntityFactory _entityFactory;

	private MediaCue? _activeMediaCue;

	private readonly DragDropPairedCollection<IPlaybackMarker, IPlaybackMarkerItemVM> _playbackMarkers;

	private IPlaybackMarkerItemVM? _selectedMarker;

	private TimeSlice? _contextMenuPosition;

	private readonly ActionDropOperation _dropOperation;

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
				_playbackMarkers.ChangeSource(n?.MediaAction?.PlaybackMarkers);
			});
		}
	}

	public INotifyEnumerableChanged<IPlaybackMarkerItemVM> PlaybackMarkers => _playbackMarkers;

	public IPlaybackMarkerItemVM? SelectedPlaybackMarker
	{
		get
		{
			return _selectedMarker;
		}
		set
		{
			SetValue<IPlaybackMarkerItemVM>("SelectedPlaybackMarker", ref _selectedMarker, value, delegate(IPlaybackMarkerItemVM o, IPlaybackMarkerItemVM n)
			{
				ActionsMenuVM.SelectedItem = n?.Marker;
				OnPropertyChanged("MarkerColor");
				OnPropertyChanged("MarkerName");
			});
		}
	}

	public ObservableCollection<IPlaybackMarkerItemVM> SelectedPlaybackMarkers { get; } = new ObservableCollection<IPlaybackMarkerItemVM>();

	public IActionsMenuVM ActionsMenuVM { get; }

	public System.Windows.Media.Color MarkerColor
	{
		get
		{
			return SelectedPlaybackMarker?.Color ?? default(System.Windows.Media.Color);
		}
		set
		{
			SelectedPlaybackMarkers.ForEach(delegate(IPlaybackMarkerItemVM m)
			{
				m.Color = value;
			});
			OnPropertyChanged("MarkerColor");
		}
	}

	public string MarkerName
	{
		get
		{
			return SelectedPlaybackMarker?.Name ?? string.Empty;
		}
		set
		{
			SelectedPlaybackMarkers.ForEach(delegate(IPlaybackMarkerItemVM m)
			{
				m.Name = value;
			});
			OnPropertyChanged("MarkerName");
		}
	}

	private TimeSlice SelectedTimestamp => _contextMenuPosition ?? _ciMediaControlVM.CurrentTime;

	public FrameworkElement? ContextMenuTarget { get; set; }

	public ICommand AddMarkerCommand => new RelayCommand(AddMarkerExecute, () => _activeMediaCue?.SupportsPlaybackMarkers ?? false);

	public ICommand MoveToPlayheadCommand => new RelayCommand(MoveToPlayheadExecute);

	public ICommand CopyCommand => new RelayCommand(CopyExecute, () => SelectedPlaybackMarkers.Any());

	public ICommand CutCommand => new RelayCommand(CutExecute, () => SelectedPlaybackMarkers.Any());

	public ICommand PasteCommand => new RelayCommand(PasteExecute, () => ClipboardManagerHelper.CanPasteIntoCollection<IPlaybackMarker>());

	public ICommand DuplicateCommand => new RelayCommand(DuplicateExecute, () => SelectedPlaybackMarkers.Any());

	public ICommand DeleteCommand => new RelayCommand(DeleteExecute, () => SelectedPlaybackMarkers.Any());

	public ICommand<IPlaybackMarkerItemVM> SelectMarkerCommand => new RelayCommand<IPlaybackMarkerItemVM>(SelectMarkerExecute, (IPlaybackMarkerItemVM m) => m != null);

	public ICommand<IPlaybackMarkerItemVM> MovePlayheadToMarkerCommand => new RelayCommand<IPlaybackMarkerItemVM>(MovePlayheadToMarkerExecute, (IPlaybackMarkerItemVM m) => m != null);

	public ICommand<TimeSlice?> SetContextMenuPositionCommand => new RelayCommand<TimeSlice?>(delegate(TimeSlice? t)
	{
		_contextMenuPosition = t;
	});

	public ICommand<PlaybackMarkerDropParameter> DropActionCommand => new RelayCommand<PlaybackMarkerDropParameter>(DropActionExecute);

	public ICommand<FrameworkElement> UpdateDialogPlacementCommand => new RelayCommand<FrameworkElement>(UpdateDialogPlacementExecute);

	public event Action<FrameworkElement?, Pro.DO.Triggering.IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public event Action<FrameworkElement>? UpdateDialogPlacement;

	public PlaybackMarkersVM(ICIMediaControlVM ciMediaControlVM, ICoreManager manager, IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents, IApp app, IActionsMenuVMFactory actionsMenuVMFactory, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, IEntityFactory entityFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_manager = manager;
		_ciMediaControlVM = ciMediaControlVM;
		_playbackMarkerAnalyticsEvents = playbackMarkerAnalyticsEvents;
		_entityFactory = entityFactory;
		_playbackMarkers = new DragDropPairedCollection<IPlaybackMarker, IPlaybackMarkerItemVM>(null, (IPlaybackMarker m) => new PlaybackMarkerItemVM(m), delegate(IPlaybackMarkerItemVM t)
		{
			((PlaybackMarkerItemVM)t).Dispose();
		});
		ActionsMenuVM = actionsMenuVMFactory.Create(this);
		ActionsMenuVM.ShowActionDialog += delegate(Pro.DO.Triggering.IAction? a, IActionRepository? i, IEnumerable<IActionRepository> c)
		{
			this.ShowActionDialog?.Invoke(ContextMenuTarget, a, i, c);
		};
		SelectedPlaybackMarkers.CollectionChanged += delegate
		{
			ActionsMenuVM.SelectedItems.Clear();
			ActionsMenuVM.SelectedItems.AddRange(SelectedPlaybackMarkers.Select((IPlaybackMarkerItemVM t) => t.Marker).ToArray());
		};
		PlaybackMarkerActionRepositoryProvider provider = new PlaybackMarkerActionRepositoryProvider(() => _ciMediaControlVM.CurrentTime);
		_dropOperation = new ActionDropOperation(new MediaActionHandler(provider, null), new PlaylistActionHandler(provider), new ActionHandler(provider), app, importProcessFactory, mediaFactory, transitionDescriptions);
	}

	private void AddMarkerExecute()
	{
		PlaybackMarkerCollection playbackMarkerCollection = ActiveMediaCue?.MediaAction?.PlaybackMarkers;
		if (playbackMarkerCollection != null)
		{
			TimeSlice timestamp = SelectedTimestamp;
			_playbackMarkerAnalyticsEvents.Create(PlaybackMarkerCreateLocation.Inspector);
			playbackMarkerCollection.InsertMarker(new PlaybackMarker
			{
				Timestamp = timestamp
			}, playbackMarkerCollection.Count((IPlaybackMarker m) => m.Timestamp < timestamp));
		}
	}

	private void MoveToPlayheadExecute()
	{
		if (SelectedPlaybackMarker != null)
		{
			SelectedPlaybackMarker.StartDragCommand?.Invoke();
			SelectedPlaybackMarker.Timestamp = _ciMediaControlVM.CurrentTime;
			SelectedPlaybackMarker.StopDragCommand?.Invoke();
		}
	}

	private void CopyExecute()
	{
		IOrderedEnumerable<IPlaybackMarker> orderedEnumerable = from s in SelectedPlaybackMarkers.Select((IPlaybackMarkerItemVM t) => t.Marker).ToArray()
			orderby PlaybackMarkers.IndexOf(s)
			select s;
		if (orderedEnumerable.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(orderedEnumerable);
		}
	}

	private void CutExecute()
	{
		CopyExecute();
		DeleteExecute();
	}

	private void PasteExecute()
	{
		PlaybackMarkerCollection playbackMarkerCollection = ActiveMediaCue?.MediaAction?.PlaybackMarkers;
		if (playbackMarkerCollection != null)
		{
			playbackMarkerCollection.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddPlaybackMarker));
			IEnumerable<IPlaybackMarker> pastedMarkers = ClipboardManagerHelper.PasteIntoCollection<PlaybackMarkerCollection, IPlaybackMarker>(playbackMarkerCollection, 0);
			TimeSlice insertTimestamp = SelectedTimestamp;
			TimeSlice timestampOfFirstCopiedMarker = pastedMarkers.Min((IPlaybackMarker m) => m.Timestamp);
			TimeSlice maximumMarkerTime = _ciMediaControlVM.Duration;
			pastedMarkers.ForEach(delegate(IPlaybackMarker m)
			{
				m.Timestamp = MathHelper.Min(maximumMarkerTime, m.Timestamp - timestampOfFirstCopiedMarker + insertTimestamp);
			});
			playbackMarkerCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
			SelectedPlaybackMarkers.Clear();
			SelectedPlaybackMarkers.AddRange(PlaybackMarkers.Where((IPlaybackMarkerItemVM t) => pastedMarkers.Contains(t.Marker)));
		}
	}

	private void DuplicateExecute()
	{
		PlaybackMarkerCollection playbackMarkerCollection = ActiveMediaCue?.MediaAction?.PlaybackMarkers;
		if (SelectedPlaybackMarkers.Any() && SelectedPlaybackMarker != null && playbackMarkerCollection != null)
		{
			playbackMarkerCollection.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddPlaybackMarker));
			IPlaybackMarker[] array = SelectedPlaybackMarkers.Select((IPlaybackMarkerItemVM t) => t.Marker.Clone()).ToArray();
			foreach (IPlaybackMarker playbackMarker in array)
			{
				playbackMarkerCollection.InsertMarker(playbackMarker, 0);
				playbackMarker.Timestamp = SelectedTimestamp;
			}
			playbackMarkerCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private void DeleteExecute()
	{
		ActiveMediaCue?.MediaAction?.PlaybackMarkers.RemoveMarkers(SelectedPlaybackMarkers.Select((IPlaybackMarkerItemVM t) => t.Marker).ToArray());
		SelectedPlaybackMarkers.Clear();
	}

	public Pro.DO.Triggering.IAction? Execute(Pro.DO.Triggering.IAction? action)
	{
		if (action == null)
		{
			return action;
		}
		Pro.DO.Triggering.IAction actionToEdit = null;
		SelectedPlaybackMarkers.ForEach(delegate(IPlaybackMarkerItemVM t)
		{
			Pro.DO.Triggering.IAction action2 = action.Clone();
			t.Marker.AddAction(action2);
			actionToEdit = action2;
		});
		return actionToEdit;
	}

	private void SelectMarkerExecute(IPlaybackMarkerItemVM markerItemVM)
	{
		SelectedPlaybackMarkers.Clear();
		SelectedPlaybackMarkers.Add(markerItemVM);
		SelectedPlaybackMarker = markerItemVM;
	}

	private void MovePlayheadToMarkerExecute(IPlaybackMarkerItemVM markerItemVM)
	{
		if (markerItemVM != null)
		{
			_ciMediaControlVM.JumpToCommand.Invoke(markerItemVM.Timestamp);
		}
	}

	private void DropActionExecute(PlaybackMarkerDropParameter? parameter)
	{
		_activeMediaCue.ThrowWhenNull("_activeMediaCue");
		parameter.ThrowWhenNull("parameter");
		PlaybackMarkerCollection playbackMarkerCollection = ActiveMediaCue?.MediaAction?.PlaybackMarkers;
		if (playbackMarkerCollection == null)
		{
			return;
		}
		bool dropBefore = parameter.DropBefore;
		bool droppedOutside = parameter.DropOutside;
		IPlaybackMarker playbackMarker = null;
		if (parameter.Target?.DataContext is IPlaybackMarkerItemVM playbackMarkerItemVM)
		{
			playbackMarker = playbackMarkerItemVM.Marker;
		}
		if (playbackMarker == null)
		{
			droppedOutside = false;
		}
		IActionRepository placement = playbackMarker;
		Pro.DO.Triggering.IAction action = null;
		if (parameter.DroppedItems.AllOf<MediaCue>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<MediaCue>(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside);
		}
		else if (parameter.DroppedItems.AllOf<ClearType>())
		{
			_dropOperation.Execute(from ClearType c in parameter.DroppedItems
				select c.ToAction(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside);
		}
		else if (parameter.DroppedItems.AllOf<ActionType>())
		{
			action = _dropOperation.Execute(from ActionType a in parameter.DroppedItems
				select a.ConstructAction(null, _activeMediaCue.ContainerId), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<MediaType>())
		{
			(Pro.DO.Triggering.IAction? FirstAction, IActionRepository? Placement) tuple = _dropOperation.Execute(parameter.DroppedItems.Cast<MediaType>().FirstOrDefault(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, _activeMediaCue.ContainerId);
			placement = tuple.Placement;
			(action, _) = tuple;
		}
		else if (parameter.DroppedItems.AllOf<FileInfo>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<FileInfo>(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, _activeMediaCue.ContainerId);
		}
		else if (parameter.DroppedItems.AllOf<IPlaylist<MediaCue>>())
		{
			action = _dropOperation.Execute(parameter.DroppedItems.Cast<IPlaylist<MediaCue>>(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out IActionRepository _);
		}
		else if (parameter.DroppedItems.AllOf<ScreenArrangementBase>())
		{
			StageAction[] array = (from ScreenArrangementBase s in parameter.DroppedItems
				select s.ToAction()).OfType<StageAction>().ToArray();
			foreach (StageScreenAssignment assignment in from a in array.SelectMany(delegate(StageAction a)
				{
					IEnumerable<StageScreenAssignment> screenAssignments = a.ScreenAssignments;
					return screenAssignments ?? Enumerable.Empty<StageScreenAssignment>();
				})
				where (object)a.Layout != null
				select a)
			{
				KeyValuePair<ScreenArrangementBase, SlideCue> keyValuePair = _manager.OutputConfiguration.StageScreenLayoutMap.FirstOrDefault<KeyValuePair<ScreenArrangementBase, SlideCue>>((KeyValuePair<ScreenArrangementBase, SlideCue> kp) => kp.Key.ID == assignment.Screen.ID);
				assignment.Layout = new Identifier(keyValuePair.Value.ID, keyValuePair.Value.Name);
			}
			action = _dropOperation.Execute(array, playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<ITimerVM>())
		{
			action = _dropOperation.Execute(from ITimerVM t in parameter.DroppedItems
				select new TimerAction(t.ID), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<Message>())
		{
			action = _dropOperation.Execute((from Message m in parameter.DroppedItems
				select m.ToAction()).NotNull(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IPropCue>())
		{
			_dropOperation.Execute(from IPropCue s in parameter.DroppedItems
				select s.ToAction(null), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IMacroItemVM>())
		{
			_dropOperation.Execute((from IMacroItemVM vm in parameter.DroppedItems
				select vm.Macro.ToAction()).NotNull(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<ActionBase>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<Pro.DO.Triggering.IAction>().CloneItems(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IClearGroupItemVM>())
		{
			_dropOperation.Execute((from IClearGroupItemVM vm in parameter.DroppedItems
				select vm.Item.ToAction()).NotNull(), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IPropCueVMInternal>())
		{
			_dropOperation.Execute(from IPropCueVMInternal vm in parameter.DroppedItems
				select vm.Source.ToAction(null), playbackMarkerCollection, playbackMarker, dropBefore, droppedOutside, out placement);
		}
		if (action != null && action.CanShowDialogOnDrop(parameter.DroppedItems))
		{
			OnShowDialog(parameter.Target, action, placement);
		}
	}

	private void OnShowDialog(FrameworkElement? placement, Pro.DO.Triggering.IAction action, IActionRepository? target)
	{
		this.ShowActionDialog?.Invoke(placement, action, target, SelectedPlaybackMarkers.Select((IPlaybackMarkerItemVM m) => m.Marker));
	}

	private void UpdateDialogPlacementExecute(FrameworkElement placement)
	{
		this.UpdateDialogPlacement?.Invoke(placement);
	}
}
