using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ActionsMenu;

namespace ProPresenter.UI.ViewModels;

public interface IActionsMenuVM : INotifyPropertyChanged
{
	IActionRepository? SelectedItem { get; set; }

	ObservableCollection<IActionRepository> SelectedItems { get; }

	IImmutableObservableCollection<TimerData> Timers { get; }

	MessageCollection Messages { get; }

	IPropCueCollection Props { get; }

	IPropGroupCollection PropGroups { get; }

	IEnumerable<IPlaylist<MediaCue>> MediaPlaylists { get; }

	IEnumerable<IPlaylist<MediaCue>> AudioPlaylists { get; }

	DeviceCollection Devices { get; }

	IAudioInputCollection AvailableAudioInputs { get; }

	ILiveVideoInputCollection AvailableVideoInputs { get; }

	MacroCollection MacroCollection { get; }

	MacroGroupCollection MacroGroups { get; }

	INotifyEnumerableChanged<ICapturePreset> CapturePresets { get; }

	ClearGroupCollection ClearGroups { get; }

	bool ShowMultiEditAction { get; }

	bool ShowSingleEditAction { get; }

	bool ShowSingleRemoveAction { get; }

	bool ShowMultiRemoveAction { get; }

	bool ShowRemoveAllActions { get; }

	bool ShowEditRemoveActionSeparator { get; }

	bool GraphicMediaActionPresent { get; }

	bool BackgroundGraphicMediaActionPresent { get; }

	bool LiveVideoActionPresent { get; }

	bool MediaActionPresent { get; }

	bool CanConvertMediaToSlideElement { get; }

	bool RefreshActionData { get; }

	IEnumerable<IAction> EditableActions { get; }

	IEnumerable<IAction> RemovableActions { get; }

	IEnumerable<ActionType> RemovableActionTypes { get; }

	IEnumerable<MediaType> RemovableMediaTypes { get; }

	IAction? SingleRemoveAction { get; }

	IAudienceLookCollection AudienceLooks { get; }

	IEnumerable<MediaCue> SelectedMedia { get; }

	TriggerLayer MediaTriggerLayer { get; }

	TriggerLayer LiveVideoTriggerLayer { get; }

	ICommand AddMediaActionCommand { get; }

	ICommand<ClearType> AddClearActionCommand { get; }

	ICommand<AudienceLook> AddAudienceLookCommand { get; }

	ICommand AddStageLayoutActionCommand { get; }

	ICommand<SlideDestinationType> AddSlideDestinationActionCommand { get; }

	ICommand<TimerData> AddTimerActionCommand { get; }

	ICommand<Message> AddMessageActionCommand { get; }

	ICommand<Tuple<IPropCue, PropTriggerType>> AddPropActionCommand { get; }

	ICommand<Tuple<PropAction, PropTriggerType>> PropChangeTriggerTypeCommand { get; }

	ICommand<IPlaylist<MediaCue>> AddPlaylistActionCommand { get; }

	ICommand AddMediaPlaylistActionCommand { get; }

	ICommand AddAudioPlaylistActionCommand { get; }

	ICommand<MIDICommand> AddMIDIActionCommand { get; }

	ICommand<AudioInput> AddAudioInputActionCommand { get; }

	ICommand<LiveVideoInput> AddVideoInputActionCommand { get; }

	ICommand<TriggerLayer> ChangeMediaCueBehaviorCommand { get; }

	ICommand<AlphaType> SetAlphaTypeCommand { get; }

	ICommand<EndBehaviorType> SetEndBehaviorTypeCommand { get; }

	ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand { get; }

	ICommand<PlaybackBehaviorType> SetPlaybackBehaviorCommand { get; }

	ICommand<TimeSlice?> SetSoftLoopDurationCommand { get; }

	ICommand<TriggerLayer> ChangeLiveVideoBehaviorCommand { get; }

	ICommand<IAction> EditActionCommand { get; }

	ICommand<ActionDataParameter> AssignActionDataCommand { get; }

	ICommand<ActionType> RemoveActionTypeCommand { get; }

	ICommand<MediaType> RemoveMediaTypeCommand { get; }

	ICommand RemoveAllActionsCommand { get; }

	ICommand<IAction> RemoveActionCommand { get; }

	ICommand ConvertMediaCueCommand { get; }

	ICommand<ProPresenterMacro> AddMacroActionCommand { get; }

	ICommand<CaptureType> AddCaptureActionCommand { get; }

	ICommand<CapturePreset> AddCaptureActionWithPresetCommand { get; }

	ICommand RelinkCommand { get; }

	ICommand DownloadCommand { get; }

	ICommand CancelDownloadCommand { get; }

	ICommand ReconnectVideoInputCommand { get; }

	ICommand<Tuple<PropAction, IPropCue, PropTriggerType>> EditPropActionTriggerTypeCommand { get; }

	ICommand<MediaAction> ShowInFileExplorerCommand { get; }

	event Action<IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	void Select(IEnumerable<IActionRepository> items);
}
