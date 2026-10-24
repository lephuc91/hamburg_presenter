using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller;

public interface IInternalCoreManager : ICoreManager, INotifyPropertyChanged
{
	void TriggerAudio<T>(MediaCue audio, Playlist<T> playlist, TriggerSource triggerSource, CueLocation cueLocation = CueLocation.AudioBin) where T : ProPresenterCue;

	void TriggerBackground<T>(MediaCue media, Playlist<T> playlist, TriggerSource triggerSource, CueLocation cueLocation = CueLocation.MediaBin) where T : ProPresenterCue;

	void TriggerProp(IPropCue prop, TriggerSource triggerSource);

	void TriggerClearGroup(ClearGroup clearGroup, TriggerSource triggerSource);

	void TriggerSlide(ArrangedCue slide, TriggerSource triggerSource, SlideTriggerOptions? options = null);

	void ToggleProp(IPropCue prop, TriggerSource triggerSource);

	void TriggerTimerAction(Guid id, string name, TimerActionType timerActionType, Timer.Types.Configuration protoConfiguration, TimeSlice incrementAmount, NetworkIdentifier? networkIdentifier = null, bool ignoreAnalytics = false);

	void TriggerTimerAction(TimerData timer, TimerActionType timerActionType, TriggerSource triggerSource, TimeSlice incrementAmount, bool ignoreAnalytics = false);

	void TriggerMessage(Guid id, string name, IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> tokenValues, TriggerOptions? triggerOptions = null);

	void TriggerMessage(ProPresenter.DO.Messages.Message message, TriggerSource triggerSource);

	void TriggerMacro(ProPresenterMacro macro, TriggerSource triggerSource);

	void TriggerAudienceLook(AudienceLook audienceLook, TriggerSource triggerSource);

	void TriggerStageAction(IEnumerable<Stage.Types.ScreenAssignment> assignments, bool ignoreAnalytics = false);

	void SendStageMessage(string message, TriggerSource triggerSource);

	void HideStageMessage(TriggerSource triggerSource);

	void TriggerNextSlide(TriggerSource triggerSource);

	void TriggerNextSlide(OutputDestination destination, TriggerSource triggerSource);

	void TriggerPreviousSlide(TriggerSource triggerSource);

	void TriggerPreviousSlide(OutputDestination destination, TriggerSource triggerSource);

	void TriggerNextBackground(VisualPlaylist playlist, TriggerSource triggerSource);

	void TriggerPreviousBackground(VisualPlaylist playlist, TriggerSource triggerSource);

	void TriggerNextAudio(AudioPlaylist playlist, TriggerSource triggerSource);

	void TriggerPreviousAudio(AudioPlaylist playlist, TriggerSource triggerSource);
}
