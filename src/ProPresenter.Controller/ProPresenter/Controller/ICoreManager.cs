using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Effects;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Messages;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Transfers;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public interface ICoreManager : INotifyPropertyChanged
{
	ProPresenterCue? ActiveAnnouncementParent { get; }

	MediaCue? ActiveAudio { get; }

	ObservableCollection<MediaCue> ActiveAudioItems { get; }

	AudioPlaylist? ActiveAudioPlaylist { get; set; }

	ILibrary? ActiveLibrary { get; set; }

	MediaCue? ActiveLibraryMedia { get; }

	Playlist<ProPresenterCue>? ActiveLibraryPlaylist { get; set; }

	MediaCue? ActiveLiveVideo { get; }

	MediaCue? ActiveMediaBinBackground { get; }

	ImmutableObservableCollection<ProPresenter.DO.Messages.Message> ActiveMessages { get; }

	ProPresenterCue? ActivePlaylistItem { get; set; }

	ProPresenterCue? ActivePresentationParent { get; }

	ArrangedCue? ActivePresentationSlide { get; }

	ImmutableObservableCollection<IPropCue> ActiveProps { get; }

	MacroGroup? ActiveMacroGroup { get; set; }

	ArrangedCue? ActiveSlide { get; }

	ProPresenterCue? ActiveSlideParent { get; }

	ActiveCueCollection ActiveSlides { get; }

	VisualPlaylist? ActiveVisualPlaylist { get; set; }

	bool AudienceEnable { get; }

	TransitionParameters? AudioTransition { get; set; }

	TransitionParameters? BackgroundTransition { get; set; }

	TransitionParameters? BibleTransition { get; set; }

	ICaptureSettingsDocument? CaptureSettings { get; }

	TransitionParameters? ForegroundTransition { get; set; }

	bool IsContiguousActive { get; set; }

	MediaAction? Logo { get; set; }

	TransitionParameters? MessagesTransition { get; set; }

	MediaCue? MostRecentActiveAudio { get; }

	MediaCue? MostRecentActiveMedia { get; }

	IMultiTracksConsumer MultiTracksConsumer { get; }

	INetworkCommandTrigger NetworkCommandTrigger { get; }

	ProPresenterCue? NextPresentation { get; }

	ArrangedCue? NextPresentationSlide { get; }

	IOutputConfiguration OutputConfiguration { get; }

	IPCOConsumer PCOConsumer { get; }

	ProPresenterCue? PreviousPresentation { get; }

	IProCoreInstance ProCore { get; }

	TransitionParameters? PropsTransition { get; set; }

	BuildPositionCollection SlideBuildPositions { get; }

	bool SlideOnStageDisplayOnly { get; }

	ISongSelectConsumer SongSelectConsumer { get; }

	bool StageEnable { get; }

	ITransportStatus TransportStatus { get; }

	IPropGroup? ActivePropGroup { get; set; }

	event Action<Playlist<MediaCue>>? ActiveAudioPlaylistChanged;

	event Action<ILibrary, ILibrary>? ActiveLibraryChanged;

	event Action<Playlist<ProPresenterCue>, Playlist<ProPresenterCue>>? ActivePlaylistChanged;

	event Action<ProPresenterCue?, ProPresenterCue?>? ActivePlaylistItemChanged;

	event Action<Playlist<MediaCue>>? ActiveVisualPlaylistChanged;

	event ClearAllAction? AllCleared;

	event AudioClearedAction? AudioCleared;

	event AudioTriggeredAction? AudioTriggered;

	event BackgroundClearedAction? BackgroundCleared;

	event Action<ProLayerIndex, ProResourceState>? LayerTriggered;

	event Action<LiveAudienceLook>? LiveLookChanged;

	event Action<ProPresenterMacro>? MacroTriggerCompleted;

	event Action<ProPresenterMacro>? MacroTriggerStarted;

	event Action<MediaTriggeredParameters>? MediaTriggered;

	event MessageClearedAction? MessageCleared;

	event MessageTriggeredAction? MessageTriggered;

	event PresentationCueFocusChangedAction? PresentationCueFocusChanged;

	event PropClearedAction? PropCleared;

	event SendCommunicationDelegate? SendCommunication;

	event SlideClearedAction? SlideCleared;

	event SlideTriggeredAction? SlideTriggered;

	event TestPatternClearedAction? TestPatternCleared;

	event TransportStatusChangedDelegate? TransportStatusChanged;

	event Action<ProLayerIndex, bool, double>? WillGotoNextUpdated;

	void BeginAnnouncementBackgroundScrub(TimeSlice time);

	void BeginAudioScrub(AudioType audioType, TimeSlice time);

	void BeginCIScrub(TimeSlice time);

	void BeginPresentationBackgroundScrub(TimeSlice time);

	void CancelAnnouncementGotoNext();

	void CancelAudioGotoNext();

	void CancelAutoAdvance(ProLayerIndex proLayerIndex);

	void CancelPresentationGotoNext();

	void ClearAll();

	void ClearAnnouncement(TriggerSource triggerSource);

	void ClearAudio(TriggerSource triggerSource);

	void ClearBackground(TriggerSource triggerSource);

	void ClearCI();

	void ClearMessage(ProPresenter.DO.Messages.Message message, TriggerSource triggerSource);

	void ClearMessages(TriggerSource triggerSource);

	void ClearProp(IPropCue prop, TriggerSource triggerSource);

	void ClearProps(TriggerSource triggerSource);

	void ClearSlide(TriggerSource triggerSource);

	void ClearTelestrator();

	void ClearTestPattern();

	void ClearTimer(TimerData timerData);

	void ClearVideoInput(TriggerSource triggerSource);

	void ClearVideoInputPreview();

	void ChangeActiveMacroGroup(int index);

	void ChangeActivePropGroup(int index);

	void CreateRenderView(CreateRenderViewParameters createParams);

	ITriggerOperation CreateTriggerOperation(TriggerHandle handle);

	void DestroyRenderView(DestroyRenderViewParameters destroyParams);

	void EndAnnouncementBackgroundScrub(TimeSlice time);

	void EndAudioScrub(AudioType audioType, TimeSlice time);

	void EndCIScrub(TimeSlice time);

	void EndPresentationBackgroundScrub(TimeSlice time);

	bool GetAutoAdvance(ProLayerIndex proLayerIndex);

	void GotoAnnouncementBackgroundEnd();

	void GotoAnnouncementBackgroundStart();

	void GotoAudioEnd(AudioType audioType);

	void GotoAudioStart(AudioType audioType);

	void GoToEndCI();

	void GoToPosCI(TimeSlice time);

	void GotoPresentationBackgroundEnd();

	void GotoPresentationBackgroundStart();

	void GoToStartCI();

	void HideAllMonitorIdentificationOverlays();

	void HideAudienceScreens();

	void HideStageScreens();

	void InspectAction(ActionBase action);

	void MarkCIInPoint(TimeSlice inPoint);

	void MarkCIOutPoint(TimeSlice outPoint);

	void Pause(ProLayerIndex layer, bool sendToNetwork = true);

	void PauseAnnouncementBackground();

	void PauseAudio(AudioType audioType);

	void PauseCI();

	void PausePresentationBackground();

	void Play(ProLayerIndex layer, bool sendToNetwork = true);

	void PlayAnnouncementBackground();

	void PlayAudio(AudioType audioType);

	void PlayCI();

	void PlayPresentationBackground();

	void RefreshAudioInputDevices();

	void RefreshVideoInputDevices();

	void ResetActiveSlide(IDocumentCue documentCue, ArrangedCue slide);

	void ResolvePath(BezierPath path, TriggerOperation currOp, ILinkedTextTransfer elementTransfer);

	void ScrubAnnouncementBackground(TimeSlice time);

	void ScrubAudio(AudioType audioType, TimeSlice position);

	void ScrubCIPos(TimeSlice time);

	void ScrubPresentationBackground(TimeSlice time);

	void SendPreferencesData(Preferences proto);

	void SendMacroIcons(Func<ImageType, string?> getSvgImageString);

	ProResult SendWebFillTokenAndCookies(int messageId, WebFillTokenAndCookies token);

	ProResult SendPCOData(PCOData pCOData);

	void SetAnnouncementBackgroundPos(TimeSlice pos);

	void SetAudioPos(AudioType audioType, TimeSlice position);

	void SetCIEffects(EffectsCollection effects);

	void SetPresentationBackgroundPos(TimeSlice pos);

	void SetPreviewScreenID(Guid id);

	void ShowAudienceScreens(bool persistState = true);

	void ShowMonitorIdentificationOverlay(PhysicalDevice device);

	void ShowOnScreenStats(bool showOnScreenStats);

	void ShowStageScreens(bool persistState = true);

	void Shutdown();

	void SkipToTime(ProLayerIndex proLayerIndex, int seconds);

	void StartMonitoringAudioInput(int index);

	void StartMonitoringVideoInputAudio(int index);

	void StepBackwardCI();

	void StepForwardCI();

	void StopMonitoringAudioInput(int index);

	void StopMonitoringVideoInputAudio(int index);

	bool SetupSlideTrigger(ArrangedCue slide, TriggerSource triggerSource, bool allowBuildSteps = true, ITriggerOperation? triggerOp = null, SlideTriggerOptions? options = null, Action<TriggerHandle, Guid, int>? handleBuildTrigger = null, Action<Pro.SerializationInterop.RVProtoData.Action, ITriggerOperation, TriggerOptions>? handleActionTrigger = null, Action<Pro.SerializationInterop.RVProtoData.Cue, ITriggerOperation, TriggerOptions, LibraryCollection>? handleCueTrigger = null);

	void ToggleInputStatus(bool enable);

	void TriggerHeaderAction(HeaderAction headerAction);

	void TriggerCapture(CaptureAction captureAction);

	void TriggerLogo();

	void TriggerSlideOnStageDisplayOnly(bool stageOnly);

	void UpdateCIAudioFades(bool shouldFadeIn, TimeSlice fadeIn, bool shouldFadeOut, TimeSlice fadeOut);

	void UpdateCIAudioProperties(AudioProperties audioProps);

	void UpdateCIEffect(EffectParameters effect);

	void UpdateCIFlipMode(bool flipHorizontally, bool flipVertically);

	void UpdateCINativeRotation(NativeRotation nativeRotation);

	void UpdateCIPremultipliedAlpha(ProPresenter.DO.Media.AlphaType alphaType);

	void UpdateCIPlayRate(double playRate);

	void UpdateCIScaleMode(ScaleBehavior scaleBehavior, ScaleAlignment alignment);

	void UpdateNDIFinderSettings(bool nDIShowSources, string nDIReceiveGroups, string nDIAdditionalSearchIPs);

	bool TryGetAutoAdvanceTimeRemaining(ProLayerIndex layer, out TimeSlice? time);

	void HandleTimerStateUpdate(TimerStateUpdate message);

	void SendStartupComplete();

	void MacroTriggerOPCreated(ITriggerOperation operation, ProPresenterMacro macro);

	void AudioPlaylistItemTriggered(MediaCue mediaCue, Playlist<MediaCue>? playlist);

	void SendDocumentsToCore();
}
