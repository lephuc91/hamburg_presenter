using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public interface ITriggering
{
	bool AudienceEnable { get; }

	bool StageEnable { get; }

	ArrangedCue? ActiveSlide { get; }

	ArrangedCue? ActivePresentationSlide { get; }

	ArrangedCue? NextPresentationSlide { get; }

	Playlist<ProPresenterCue>? ActiveLibraryPlaylist { get; set; }

	VisualPlaylist? ActiveVisualPlaylist { get; set; }

	AudioPlaylist? ActiveAudioPlaylist { get; set; }

	ILibrary? ActiveLibrary { get; set; }

	ProPresenterCue? ActivePlaylistItem { get; set; }

	ProPresenterCue? ActiveSlideParent { get; }

	ProPresenterCue? ActivePresentationParent { get; }

	ProPresenterCue? ActiveAnnouncementParent { get; }

	ITransportStatus TransportStatus { get; }

	INotifyEnumerableChanged<IPropCue> ActiveProps { get; }

	event SlideTriggeredAction SlideTriggered;

	event SlideClearedAction SlideCleared;

	event PresentationCueFocusChangedAction PresentationCueFocusChanged;

	void ClearVideoInput();

	void ClearBackground();

	void ClearSlide();

	void ClearAnnouncement();

	void ClearProps();

	void ClearMessages();

	void ClearAudio();

	void TriggerClearGroup(ClearGroup clearGroup);

	void TriggerSlide(ArrangedCue slide, SlideTriggerOptions? options = null);

	void TriggerBackground<T>(MediaCue media, Playlist<T> playlist, CueLocation cueLocation = CueLocation.MediaBin) where T : ProPresenterCue;

	void TriggerAudio<T>(MediaCue audio, Playlist<T> playlist, CueLocation cueLocation = CueLocation.AudioBin) where T : ProPresenterCue;

	void Play(ProLayerIndex layer, bool sendToNetwork = true);

	void Pause(ProLayerIndex layer, bool sendToNetwork = true);

	void SkipToTime(ProLayerIndex proLayerIndex, int seconds);

	bool GetAutoAdvance(ProLayerIndex proLayerIndex);

	void CancelAutoAdvance(ProLayerIndex proLayerIndex);

	void TriggerProp(IPropCue prop);

	void ClearProp(IPropCue prop);

	void ToggleProp(IPropCue prop, PropTrigger? propTrigger);

	void TriggerTimerAction(Guid id, string name, TimerActionType timerActionType, Timer.Types.Configuration protoConfiguration, bool ignoreAnalytics = false);

	void TriggerTimerAction(TimerData timer, TimerActionType timerActionType, TimeSlice? incrementAmount = null, bool ignoreAnalytics = false);

	void TriggerMessage(Guid id, string name, IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> tokenValues);

	void TriggerMessage(ProPresenter.DO.Messages.Message message);

	void ClearMessage(ProPresenter.DO.Messages.Message message);

	void TriggerMacro(ProPresenterMacro macro);

	void TriggerAudienceLook(AudienceLook audienceLook);

	void TriggerStageAction(IEnumerable<Stage.Types.ScreenAssignment> assignments, bool ignoreAnalytics = false);

	void SendStageMessage(string message);

	void HideStageMessage();

	void TriggerNextSlide();

	void TriggerNextSlide(OutputDestination destination);

	void TriggerPreviousSlide();

	void TriggerPreviousSlide(OutputDestination destination);

	void TriggerNextBackground(VisualPlaylist playlist);

	void TriggerPreviousBackground(VisualPlaylist playlist);

	void TriggerNextAudio(AudioPlaylist playlist);

	void TriggerPreviousAudio(AudioPlaylist playlist);

	void TriggerHeader(HeaderAction header);

	void TriggerCapture(CaptureAction captureAction);

	void ShowAudienceScreens();

	void HideAudienceScreens();

	void ShowStageScreens();

	void HideStageScreens();
}
