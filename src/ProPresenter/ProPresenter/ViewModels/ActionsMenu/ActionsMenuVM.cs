using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.Utility;
using Pro.ssAPI;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.RemoteFile;
using ProPresenter.UI.ActionsMenu;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.ActionsMenu;

public class ActionsMenuVM : LinkedNotifyPropertyChangedBase, IActionsMenuVM, INotifyPropertyChanged
{
	private IActionRepository? _selectedItem;

	private readonly IMediaStrategy _mediaStrategy;

	private readonly IAddActionInteractor? _addActionInteractor;

	private readonly IApp _app;

	private readonly VisualPlaylistCollection _visualPlaylists;

	private readonly AudioPlaylistCollection _audioPlaylists;

	private bool _refreshActionData;

	private readonly IMediaActionService _mediaActionService;

	private readonly IProcessHelper _processHelper;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IOutputService _outputService;

	private readonly IProPresenterResourceService _proPresenterResourceService;

	public IActionRepository? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			SetValue("SelectedItem", ref _selectedItem, value, NotifyPropertyChanges);
		}
	}

	public ObservableCollection<IActionRepository> SelectedItems { get; } = new ObservableCollection<IActionRepository>();

	public IAudienceLookCollection AudienceLooks { get; }

	public IImmutableObservableCollection<TimerData> Timers { get; }

	public MessageCollection Messages { get; }

	public IPropCueCollection Props { get; }

	public IPropGroupCollection PropGroups { get; }

	public IEnumerable<IPlaylist<MediaCue>> MediaPlaylists => _visualPlaylists.GetPlaylists();

	public IEnumerable<IPlaylist<MediaCue>> AudioPlaylists => _audioPlaylists.GetPlaylists();

	public DeviceCollection Devices { get; }

	public IAudioInputCollection AvailableAudioInputs { get; }

	public ILiveVideoInputCollection AvailableVideoInputs { get; }

	public MacroCollection MacroCollection { get; }

	public MacroGroupCollection MacroGroups { get; }

	public ClearGroupCollection ClearGroups { get; }

	public INotifyEnumerableChanged<ICapturePreset> CapturePresets { get; }

	public bool ShowMultiEditAction => EditableActions.Count() > 1;

	public bool ShowSingleEditAction => EditableActions.Count() == 1;

	public bool ShowRemoveAllActions
	{
		get
		{
			if (SelectedItems.Count > 1)
			{
				return SelectedItems.SelectMany((IActionRepository a) => a.Actions).Any((IAction a) => a.IsActionRemoveable());
			}
			return false;
		}
	}

	public bool ShowSingleRemoveAction
	{
		get
		{
			if (SelectedItems.Count == 1)
			{
				return RemovableActions.Count() == 1;
			}
			return false;
		}
	}

	public bool ShowMultiRemoveAction
	{
		get
		{
			if (SelectedItems.Count == 1)
			{
				return RemovableActions.Count() > 1;
			}
			return false;
		}
	}

	public bool ShowEditRemoveActionSeparator
	{
		get
		{
			if (!ShowSingleEditAction && !ShowMultiEditAction && !ShowSingleRemoveAction)
			{
				return ShowMultiRemoveAction;
			}
			return true;
		}
	}

	public bool GraphicMediaActionPresent => GraphicMediaAction != null;

	public bool BackgroundGraphicMediaActionPresent
	{
		get
		{
			if (GraphicMediaAction != null)
			{
				return GraphicMediaAction.TriggerLayer == TriggerLayer.Background;
			}
			return false;
		}
	}

	public bool LiveVideoActionPresent => LiveVideoMediaAction != null;

	public bool MediaActionPresent
	{
		get
		{
			if (!GraphicMediaActionPresent && !LiveVideoActionPresent)
			{
				return AudioMediaAction != null;
			}
			return true;
		}
	}

	public bool CanConvertMediaToSlideElement
	{
		get
		{
			if (_mediaStrategy.CanConvertMediaToSlideElement)
			{
				return SelectedItem?.Actions.FirstOrDefaultOf((MediaAction m) => m.IsGraphicMedia) != null;
			}
			return false;
		}
	}

	public IEnumerable<IAction> EditableActions => SelectedItem?.Actions.Where((IAction a) => a.IsActionEditable()) ?? Array.Empty<IAction>();

	public IEnumerable<IAction> RemovableActions => SelectedItem?.Actions.Where((IAction a) => a.IsActionRemoveable()) ?? Array.Empty<IAction>();

	public IEnumerable<ActionType> RemovableActionTypes => (from a in SelectedItems.SelectMany((IActionRepository c) => c.Actions)
		select a.ActionType into a
		where a != ActionType.Slide && a != ActionType.Media
		select a).Distinct();

	public IEnumerable<MediaType> RemovableMediaTypes => (from m in SelectedItems.SelectMany((IActionRepository c) => c.Actions).OfType<MediaAction>()
		select m.Media.MediaType).Distinct();

	public IAction? SingleRemoveAction => RemovableActions.FirstOrDefault();

	public IEnumerable<MediaCue> SelectedMedia => SelectedMediaActions.Select((MediaAction c) => new MediaCue(c));

	public TriggerLayer MediaTriggerLayer => GraphicMediaAction?.TriggerLayer ?? TriggerLayer.Background;

	public TriggerLayer LiveVideoTriggerLayer => LiveVideoMediaAction?.TriggerLayer ?? TriggerLayer.Input;

	public bool RefreshActionData
	{
		get
		{
			return _refreshActionData;
		}
		set
		{
			SetValue("RefreshActionData", ref _refreshActionData, value);
		}
	}

	public ICommand AddMediaActionCommand => new RelayCommand(OnAddMediaActionCommand);

	public ICommand<ClearType> AddClearActionCommand => new RelayCommand<ClearType>(OnAddClearCommand, CanAddClearAction);

	public ICommand<AudienceLook> AddAudienceLookCommand => new RelayCommand<AudienceLook>(OnAddAudienceLookCommand, (AudienceLook a) => a == null || (SelectedItem?.CanAddAction(ActionType.AudienceLook) ?? false));

	public ICommand AddStageLayoutActionCommand => new RelayCommand(OnAddStageLayoutActionCommand, () => SelectedItem?.CanAddAction(ActionType.StageLayout) ?? false);

	public ICommand<SlideDestinationType> AddSlideDestinationActionCommand => new RelayCommand<SlideDestinationType>(OnAddSlideDestinationActionCommand, (SlideDestinationType t) => SelectedItem?.CanAddAction(ActionType.SlideDestination) ?? false);

	public ICommand<TimerData> AddTimerActionCommand => new RelayCommand<TimerData>(OnAddTimerActionCommand, (TimerData t) => t == null || (SelectedItem?.CanAddAction(t) ?? false));

	public ICommand<Message> AddMessageActionCommand => new RelayCommand<Message>(OnAddMessageActionCommand, (Message m) => m == null || (SelectedItem?.CanAddAction(m) ?? false));

	public ICommand<Tuple<IPropCue, PropTriggerType>> AddPropActionCommand => new RelayCommand<Tuple<IPropCue, PropTriggerType>>(OnAddPropActionCommand, (Tuple<IPropCue, PropTriggerType> a) => a == null || a.Item1 == null || (SelectedItem?.CanAddAction(a.Item1) ?? false));

	public ICommand<Tuple<PropAction, PropTriggerType>> PropChangeTriggerTypeCommand => new RelayCommand<Tuple<PropAction, PropTriggerType>>(OnPropChangeTriggerTypeCommand);

	public ICommand<IPlaylist<MediaCue>> AddPlaylistActionCommand => new RelayCommand<IPlaylist<MediaCue>>(OnAddPlaylistActionCommand, (IPlaylist<MediaCue> p) => p != null && (SelectedItem?.CanAddAction(p) ?? false));

	public ICommand AddMediaPlaylistActionCommand => new RelayCommand(delegate
	{
		OnAddPlaylistActionCommand(MediaPlaylists.FirstOrDefault(AddPlaylistActionCommand.CanExecute));
	});

	public ICommand AddAudioPlaylistActionCommand => new RelayCommand(delegate
	{
		OnAddPlaylistActionCommand(AudioPlaylists.FirstOrDefault(AddPlaylistActionCommand.CanExecute));
	});

	public ICommand<MIDICommand> AddMIDIActionCommand => new RelayCommand<MIDICommand>(OnAddMIDIActionCommand);

	public ICommand<AudioInput> AddAudioInputActionCommand => new RelayCommand<AudioInput>(OnAddAudioInputActionCommand, (AudioInput a) => a == null || (SelectedItem?.CanAddAction(a) ?? false));

	public ICommand<LiveVideoInput> AddVideoInputActionCommand => new RelayCommand<LiveVideoInput>(OnAddVideoInputActionCommand, (LiveVideoInput i) => i == null || (SelectedItem?.CanAddAction(i) ?? false));

	public ICommand<TriggerLayer> ChangeLiveVideoBehaviorCommand => new RelayCommand<TriggerLayer>(OnChangeLiveVideoBehaviorCommand);

	public ICommand<IAction> EditActionCommand => new RelayCommand<IAction>(OnEditActionCommand, (IAction a) => a?.IsActionEditable() ?? false);

	public ICommand<Tuple<PropAction, IPropCue, PropTriggerType>> EditPropActionTriggerTypeCommand => new RelayCommand<Tuple<PropAction, IPropCue, PropTriggerType>>(OnEditPropActionTriggerTypeCommand);

	public ICommand<ActionDataParameter> AssignActionDataCommand => new RelayCommand<ActionDataParameter>(OnAssignActionDataCommand, CanAssignActionData);

	public ICommand<ActionType> RemoveActionTypeCommand => new RelayCommand<ActionType>(OnRemoveActionTypeCommand);

	public ICommand<MediaType> RemoveMediaTypeCommand => new RelayCommand<MediaType>(OnRemoveMediaTypeCommand);

	public ICommand RemoveAllActionsCommand => new RelayCommand(OnRemoveAllActionsCommand);

	public ICommand<IAction> RemoveActionCommand => new RelayCommand<IAction>(OnRemoveActionCommand);

	public ICommand ConvertMediaCueCommand => new RelayCommand(OnConvertMediaCueCommand);

	public ICommand<ProPresenterMacro?> AddMacroActionCommand => new RelayCommand<ProPresenterMacro>(OnAddMacroActionCommand, (ProPresenterMacro? m) => m == null || CanAddMacroAction(m));

	public ICommand<CaptureType> AddCaptureActionCommand => new RelayCommand<CaptureType>(AddCaptureActionCommandExecute, (CaptureType c) => SelectedItem?.CanAddAction(c) ?? false);

	public ICommand<CapturePreset> AddCaptureActionWithPresetCommand => new RelayCommand<CapturePreset>(AddCaptureActionWithPresetCommandExecute, (CapturePreset m) => m == null || (SelectedItem?.CanAddAction(m) ?? false));

	public ICommand<ClearGroup> AddClearGroupActionCommand => new RelayCommand<ClearGroup>(OnAddClearGroupActionCommand, (ClearGroup c) => c == null || (SelectedItem?.CanAddAction(c) ?? false));

	private IEnumerable<MediaAction> SelectedMediaActions => SelectedItems.SelectMany((IActionRepository s) => s.Actions).OfType<MediaAction>();

	private MediaAction? GraphicMediaAction => SelectedItem?.Actions.FirstOrDefaultOf((MediaAction m) => m.IsGraphicMedia);

	private MediaAction? LiveVideoMediaAction => SelectedItem?.Actions.FirstOrDefaultOf((MediaAction m) => m.LiveVideo != null);

	private MediaAction? AudioMediaAction => SelectedItem?.Actions.FirstOrDefaultOf((MediaAction m) => m.AudioMedia != null);

	public ICommand RelinkCommand { get; }

	public ICommand DownloadCommand { get; }

	public ICommand ReconnectVideoInputCommand { get; }

	public ICommand CancelDownloadCommand { get; }

	public ICommand<TriggerLayer> ChangeMediaCueBehaviorCommand => new RelayCommand<TriggerLayer>(OnChangeMediaCueBehaviorCommand);

	public ICommand<AlphaType> SetAlphaTypeCommand => new RelayCommand<AlphaType>(delegate(AlphaType a)
	{
		_mediaActionService.SetAlphaType(SelectedMediaActions, a);
	}, (AlphaType i) => SelectedMediaActions.NonNull().Any());

	public ICommand<EndBehaviorType> SetEndBehaviorTypeCommand => new RelayCommand<EndBehaviorType>(delegate(EndBehaviorType e)
	{
		_mediaActionService.SetEndBehaviorType(SelectedMediaActions, e);
	}, (EndBehaviorType t) => SelectedMediaActions.NonNull().Any());

	public ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand => new RelayCommand<ScaleBehavior>(delegate(ScaleBehavior s)
	{
		_mediaActionService.SetMediaScaleBehavior(SelectedMediaActions, s);
	}, (ScaleBehavior t) => SelectedMediaActions.NonNull().Any());

	public ICommand<PlaybackBehaviorType> SetPlaybackBehaviorCommand => new RelayCommand<PlaybackBehaviorType>(delegate(PlaybackBehaviorType p)
	{
		_mediaActionService.SetPlayback(GraphicMediaAction, SelectedMediaActions, p);
	}, (PlaybackBehaviorType p) => SelectedMediaActions.NonNull().Any((MediaAction a) => a.IsGraphicMedia));

	public ICommand<TimeSlice?> SetSoftLoopDurationCommand => new RelayCommand<TimeSlice?>(delegate(TimeSlice? t)
	{
		_mediaActionService.SetSoftLoopDuration(SelectedMediaActions, t);
	}, (TimeSlice? t) => SelectedMediaActions.NonNull().Any());

	public ICommand<MediaAction> ShowInFileExplorerCommand => new RelayCommand<MediaAction>(ShowInFileExplorerCommandExecuted, (MediaAction m) => m?.VisualMedia?.SourceFile?.FullPath != null);

	public event Action<IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public ActionsMenuVM(IDownloadManager downloadManager, IProPresenterResourceService resourceService, IOutputService outputService, IAddActionInteractor? addActionInteractor, IFileSelectorService fileSelectorService, IRemoteFileLoader remoteFileLoader, IImportProcessFactory importProcessFactory, IUiScheduler uiScheduler, IApp app, IMediaActionService mediaActionService, IProcessHelper processHelper, IMediaFactory mediaFactory, IOutputConfiguration outputConfiguration, ITransitionDescriptionCollection transitionDescriptions, IMediaStrategy? addMediaStategy = null, ICommand? openLiveVideoSetupCommand = null)
	{
		AudienceLooks = outputConfiguration.AudienceLooks;
		Devices = outputService.Devices;
		_addActionInteractor = addActionInteractor;
		_app = app;
		_mediaActionService = mediaActionService;
		_processHelper = processHelper;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_mediaStrategy = addMediaStategy ?? new MediaStrategy(_app, importProcessFactory, mediaFactory, transitionDescriptions, delegate(MediaAction m)
		{
			AddAction(m);
		});
		_outputService = outputService;
		_proPresenterResourceService = resourceService;
		Timers = resourceService.Timers;
		Messages = resourceService.Messages;
		Props = resourceService.PropCueCollection;
		PropGroups = resourceService.PropGroupCollection;
		_visualPlaylists = resourceService.VisualPlaylists;
		_audioPlaylists = resourceService.AudioPlaylists;
		MacroCollection = resourceService.Macros;
		MacroGroups = resourceService.MacroGroups;
		CapturePresets = outputService.OutputConfiguration.CaptureSettings.Presets;
		ClearGroups = resourceService.ClearGroups;
		AvailableAudioInputs = outputService.OutputRepository.AvailableAudioInputs;
		AvailableVideoInputs = outputService.OutputRepository.AvailableLiveVideoInputs;
		_visualPlaylists.CollectionModified += delegate
		{
			OnPropertyChanged("MediaPlaylists");
		};
		_audioPlaylists.CollectionModified += delegate
		{
			OnPropertyChanged("AudioPlaylists");
		};
		SelectedItems.CollectionChanged += delegate
		{
			NotifyPropertyChanges();
		};
		IObservable<IEnumerable<MediaAction>> whenMediaActionListChanges = (from values in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler e)
			{
				base.PropertyChanged += e;
			}, delegate(PropertyChangedEventHandler e)
			{
				base.PropertyChanged -= e;
			})
			where values.EventArgs.PropertyName == "SelectedItem"
			select values into _
			select SelectedItem?.Actions?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>()).StartWith(SelectedItem?.Actions?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>());
		IObservable<IReadOnlyList<ActionDownloadItemMatch>> whenActionDownloadItemMapChanges = downloadManager.WhenActionDownloadItemMapChanges(whenMediaActionListChanges);
		IObservable<IList<MediaAction>> whenMediaValidityUpdates = whenMediaActionListChanges.WhenMediaValidityUpdates();
		DownloadCommand = whenActionDownloadItemMapChanges.ToDownloadCommand(GetSelectedMediaActions, remoteFileLoader, uiScheduler);
		RelinkCommand = whenMediaValidityUpdates.ToRelinkCommand(GetSelectedMediaActions, fileSelectorService, importProcessFactory);
		ReconnectVideoInputCommand = whenMediaValidityUpdates.ToReconnectCommand(openLiveVideoSetupCommand);
		CancelDownloadCommand = whenActionDownloadItemMapChanges.WhenOverallDownloadProgressChanges().ToCancelDownloadCommand(whenActionDownloadItemMapChanges);
	}

	private void NotifyPropertyChanges()
	{
		new string[19]
		{
			"EditableActions", "ShowSingleEditAction", "ShowMultiEditAction", "SingleRemoveAction", "ShowRemoveAllActions", "ShowSingleRemoveAction", "ShowMultiRemoveAction", "GraphicMediaActionPresent", "BackgroundGraphicMediaActionPresent", "LiveVideoActionPresent",
			"MediaActionPresent", "SelectedMedia", "MediaTriggerLayer", "LiveVideoTriggerLayer", "RemovableActionTypes", "RemovableMediaTypes", "RemovableActions", "CanConvertMediaToSlideElement", "ShowEditRemoveActionSeparator"
		}.ForEach(base.OnPropertyChanged);
	}

	private void OnAddMediaActionCommand()
	{
		if (DialogHelper.SelectFile(out string selectedFile, FileFilters.MediaFileFilter))
		{
			AddMediaAction(selectedFile);
		}
	}

	private void AddMediaAction(string fileName)
	{
		_mediaStrategy.AddMediaAction(fileName);
	}

	private void OnAddClearCommand(ClearType clearType)
	{
		AddAction(clearType.ToAction());
	}

	private bool CanAddClearAction(ClearType clearType)
	{
		return !SelectedItems.All((IActionRepository s) => s.Actions.AnyOf((ClearAction a) => a.ClearType == clearType));
	}

	private void OnAddAudienceLookCommand(AudienceLook? look)
	{
		bool flag = look == null;
		if (flag)
		{
			look = AudienceLooks.FirstOrDefault(AddAudienceLookCommand.CanExecute);
		}
		IAction action = look.ToAction(AudienceLooks);
		AddAction(flag, action);
	}

	private void OnAddStageLayoutActionCommand()
	{
		StageAction action = new StageAction(_outputService.OutputRepository.StageScreenArrangementCollection, _proPresenterResourceService.StagePresentation);
		AddAndEditAction(action);
	}

	private void OnAddSlideDestinationActionCommand(SlideDestinationType destinationType)
	{
		bool flag = destinationType == SlideDestinationType.NoChange;
		if (flag)
		{
			destinationType = SlideDestinationType.StageOnly;
		}
		IAction action = destinationType.ToProtoSlideTarget().ToAction();
		AddAction(flag, action);
	}

	private void OnAddTimerActionCommand(TimerData? timer)
	{
		if (timer == null)
		{
			timer = Timers.FirstOrDefault();
		}
		AddAndEditAction(timer?.ToAction());
	}

	private void OnAddMessageActionCommand(Message? message)
	{
		if (message == null)
		{
			message = Messages.FirstOrDefault(AddMessageActionCommand.CanExecute);
		}
		AddAndEditAction(message?.ToAction());
	}

	private void OnAddPropActionCommand(Tuple<IPropCue, PropTriggerType> values)
	{
		if (values == null || values.Item1 == null)
		{
			return;
		}
		IPropCue propCue = values.Item1;
		PropTriggerType item = values.Item2;
		bool flag = propCue == null;
		if (flag)
		{
			propCue = Props.FirstOrDefault(AddPropActionCommand.CanExecute);
		}
		if (propCue != null)
		{
			PropAction propAction = (PropAction)propCue.ToAction(null);
			propAction.ChangeTriggerType(item);
			propAction.AutoClearFollowsPropDuration = true;
			propAction.AutoClearDuration = propCue.SlideAction?.AutoClearDuration ?? 0.0;
			if (flag)
			{
				AddAndEditAction(propAction);
			}
			else
			{
				AddAction(propAction);
			}
		}
	}

	private static void OnPropChangeTriggerTypeCommand(Tuple<PropAction, PropTriggerType> values)
	{
		values?.Item1?.ChangeTriggerType(values.Item2);
	}

	private void OnAddPlaylistActionCommand(IPlaylist<MediaCue>? playlist)
	{
		if (playlist?.ToAction() is PlaylistAction action)
		{
			AddAndEditAction(action);
		}
	}

	private void OnAddMIDIActionCommand(MIDICommand command)
	{
		Guid? deviceID = Devices.FirstOrDefault((ProPresenter.DO.Communication.IDevice d) => d.Type == ProPresenter.DO.Communication.DeviceType.MIDI)?.ID;
		if (deviceID.HasValue)
		{
			AddAndEditAction(new CommunicationAction
			{
				DeviceID = deviceID,
				Command = command
			});
		}
	}

	private void OnAddAudioInputActionCommand(AudioInput? audioInput)
	{
		if (audioInput == null)
		{
			audioInput = AvailableAudioInputs.FirstOrDefault(AddAudioInputActionCommand.CanExecute);
		}
		AddAndEditAction((audioInput == null) ? null : new AudioInputAction(audioInput, AvailableAudioInputs));
	}

	private void OnAddVideoInputActionCommand(LiveVideoInput? videoInput)
	{
		if (videoInput == null)
		{
			videoInput = AvailableVideoInputs.FirstOrDefault(AddVideoInputActionCommand.CanExecute);
		}
		if (videoInput != null)
		{
			LiveVideoMedia liveVideoMedia = _mediaFactory.CreateLiveVideoMedia();
			liveVideoMedia.LiveVideo.Input = videoInput;
			AddAndEditAction(new MediaAction(liveVideoMedia, _app, _transitionDescriptions));
		}
	}

	private void AddAction(bool edit, IAction? action)
	{
		if (edit)
		{
			AddAndEditAction(action);
		}
		else
		{
			AddAction(action);
		}
	}

	private IAction? AddAction(IAction? action)
	{
		if (_addActionInteractor != null)
		{
			IAction? result = _addActionInteractor.Execute(action);
			NotifyPropertyChanges();
			return result;
		}
		IAction actionToEdit = null;
		SelectedItems.ForEach(delegate(IActionRepository m)
		{
			action.ThrowWhenNull("action");
			IAction action2 = action.Clone();
			m.AddAction(action2);
			actionToEdit = action2;
		});
		NotifyPropertyChanges();
		return actionToEdit;
	}

	private void AddAndEditAction(IAction? action)
	{
		if (action != null)
		{
			IAction action2 = AddAction(action);
			OnEditActionCommand(action2);
		}
	}

	private void OnChangeMediaCueBehaviorCommand(TriggerLayer layer)
	{
		SelectedMediaActions?.Where((MediaAction m) => m.IsGraphicMedia).ForEach(delegate(MediaAction a)
		{
			a.TriggerLayer = layer;
		});
		OnPropertyChanged("MediaTriggerLayer");
	}

	private void OnChangeLiveVideoBehaviorCommand(TriggerLayer layer)
	{
		SelectedMediaActions?.Where((MediaAction m) => m.LiveVideo != null).ForEach(delegate(MediaAction a)
		{
			a.TriggerLayer = layer;
		});
		OnPropertyChanged("LiveVideoTriggerLayer");
	}

	private void OnEditPropActionTriggerTypeCommand(Tuple<PropAction, IPropCue, PropTriggerType> values)
	{
		if (values != null)
		{
			AssignActionDataCommand.Invoke(new ActionDataParameter(values.Item1, values.Item2));
			values.Item1.ChangeTriggerType(values.Item3);
		}
	}

	private void OnEditActionCommand(IAction? action)
	{
		this.ShowActionDialog?.Invoke(action, SelectedItem, SelectedItems.ToArray());
	}

	private void OnAssignActionDataCommand(ActionDataParameter param)
	{
		RefreshActionData = true;
		param.Action.AssignData(param.Data, OnEditActionCommand);
		RefreshActionData = false;
	}

	private bool CanAssignActionData(ActionDataParameter param)
	{
		return SelectedItem.CanAssignData(param?.Data, param?.Action);
	}

	private void OnRemoveActionTypeCommand(ActionType actionType)
	{
		RemoveActions((IAction a) => a.ActionType == actionType);
	}

	private void OnRemoveMediaTypeCommand(MediaType mediaType)
	{
		RemoveActions((IAction a) => a is MediaAction mediaAction && mediaAction.Media.MediaType == mediaType);
	}

	private void RemoveActions(Predicate<IAction> predicate)
	{
		foreach (IActionRepository selectedItem in SelectedItems)
		{
			IAction[] actions = selectedItem.Actions.Where((IAction a) => predicate(a)).ToArray();
			selectedItem.RemoveActions(actions);
		}
		NotifyPropertyChanges();
	}

	private void OnRemoveAllActionsCommand()
	{
		foreach (IActionRepository selectedItem in SelectedItems)
		{
			selectedItem.RemoveActions(selectedItem.Actions.ToArray());
		}
		NotifyPropertyChanges();
	}

	private void OnRemoveActionCommand(IAction action)
	{
		SelectedItem?.RemoveAction(action);
		NotifyPropertyChanges();
	}

	private void OnConvertMediaCueCommand()
	{
		_mediaStrategy.ConvertMediaToSlideElement();
	}

	private bool CanAddMacroAction(ProPresenterMacro macro)
	{
		if (!(SelectedItem is ProPresenterMacro proPresenterMacro))
		{
			return SelectedItem?.CanAddAction(macro) ?? false;
		}
		if (proPresenterMacro != macro)
		{
			return SelectedItem.CanAddAction(macro);
		}
		return false;
	}

	private void OnAddMacroActionCommand(ProPresenterMacro? macro)
	{
		bool num = macro == null;
		if (num)
		{
			macro = MacroCollection.FirstOrDefault(AddMacroActionCommand.CanExecute);
		}
		IAction action = macro.ToAction();
		if (num)
		{
			AddAndEditAction(action);
		}
		else
		{
			AddAction(action);
		}
	}

	private void AddCaptureActionCommandExecute(CaptureType captureType)
	{
		IAction action = captureType.ToAction();
		if (action != null)
		{
			AddAndEditAction(action);
		}
	}

	private void AddCaptureActionWithPresetCommandExecute(CapturePreset preset)
	{
		AddAction(preset.ToAction());
	}

	private void OnAddClearGroupActionCommand(ClearGroup? clearGroup)
	{
		bool num = clearGroup == null;
		if (num)
		{
			clearGroup = ClearGroups.FirstOrDefault(AddClearGroupActionCommand.CanExecute);
		}
		IAction action = clearGroup.ToAction();
		if (num)
		{
			AddAndEditAction(action);
		}
		else
		{
			AddAction(action);
		}
	}

	public void Select(IEnumerable<IActionRepository> items)
	{
		SelectedItems.ClearAndNotifyOnCompletion();
		SelectedItem = items?.FirstOrDefault();
		if (items != null && items.All((IActionRepository r) => r != null))
		{
			SelectedItems.AddRangeAndNotifyOnCompletion(items);
		}
	}

	private IEnumerable<MediaAction> GetSelectedMediaActions()
	{
		return SelectedItem?.Actions?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>();
	}

	private void ShowInFileExplorerCommandExecuted(MediaAction mediaAction)
	{
		_processHelper.OpenFileInExplorer(mediaAction?.VisualMedia?.SourceFile.FullPath);
	}
}
