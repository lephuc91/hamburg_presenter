using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Resi.Types;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop;

public interface IProCoreInstance
{
	Func<ProLink.Types.HandlerIn, ProApiOut?>? LinkCallback { get; set; }

	Action<NetworkAPI>? NetworkAPICallback { get; set; }

	Func<ulong, ProNetworkEndpointType, bool>? ConnectedWSCallback { get; set; }

	ResiTransferDelegate? ResiTransferHandler { get; set; }

	SendCommunicationDelegate? SendCommunication { get; set; }

	TransportStatusChangedDelegate? TransportStatusChanged { get; set; }

	TriggerTransferDelegate? TriggerTransferHandler { get; set; }

	AsyncTriggerTransferDelegate? AsyncTriggerTransferHandler { get; set; }

	AudioInputStatusChangedDelegate? AudioInputStatusChanged { get; set; }

	OperationStateChangedDelegate? OperationHandler { get; set; }

	ResourceStateChangedDelegate? ResourceHandler { get; set; }

	CloseDisplayButtonClickedDelegate? CloseDisplayButtonClicked { get; set; }

	VideoInputStatusChangedDelegate? VideoInputStatusChanged { get; set; }

	UpdateAudioInputDelegate? UpdateAudioInput { get; set; }

	ImageRequestTransferDelegate? ImageRequestTransferHandler { get; set; }

	Func<NetworkAPI_v1, ProApiOut?>? APIV1Callback { get; set; }

	Action<ulong>? DisconnectedWSCallback { get; set; }

	Func<ulong, string, string>? MessagesWSCallback { get; set; }

	event EventHandler<SendDataResponseEventArgs>? SendDataResponseReceived;

	event EventHandler<ScreenCaptureStatusEventArgs>? ScreenCaptureStatusChanged;

	TriggerHandle AcquireTriggerHandle();

	ProResult AddClockSourceChangedCallback(System.Action action);

	ProResult AddDeviceChangedCallback(ProDeviceType deviceType, System.Action action);

	ProResult AddDeviceChangedCallback(ProDeviceType deviceType, Action<object, ProDeviceAction> action);

	ProResult ControlTransport(ProLayerIndex layer, ControlTransport controlTransport);

	TriggerHandle CreateTimedPlaybackSession(TimedPlayback timedPlayback);

	ProResult DestroyTimedPlaybackSession(TriggerHandle handle);

	ProResult EnableWatermark(BitmapSource logoBitmap, BitmapSource textBitmap);

	ProResult EnumerateAudioInputs(Action<ProAudioDevice> deviceAction);

	ProResult EnumerateAudioOutputs(Action<ProAudioDevice> deviceAction);

	ProResult EnumerateAvailableEffects(Action<Effect> effectAction);

	ProResult EnumerateAvailableNDIModes(Action<ProVideoMode> modeAction);

	ProResult EnumerateAvailableTransitions(Action<Transition> effectTransition);

	ProResult EnumerateClockSources(Action<ProClockSource> clockSourceAction);

	ProResult EnumerateVideoInputs(Action<ProVideoInputDevice> deviceAction);

	ProResult EnumerateVideoOutputs(Action<ProVideoOutputDevice> deviceAction);

	ProResult GenerateTransitionImages(Transition transition, BitmapSource srcImageA, BitmapSource srcImageB, int width, int height, int frameCount, out BitmapSource[] renderedBitmaps);

	ProResult GetAvailableCodecs(Action<ProScreenCaptureCodec[]> callback);

	BitmapSource? GetCIMediaSnapshot(int width, int height, double cropTop, double cropLeft, double cropRight, double cropBottom, Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation);

	MediaMetadataRequestResponse? GetMediaMetadata(string filename, int width, int height, double insetLeft, double insetTop, double insetRight, double insetBottom, TimeSlice time, bool flipVertically, bool flipHorizontally, Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation, IEnumerable<Effect> effects, bool isImport, bool useDefaultNativeRotation, AlphaType alphaType, out BitmapSource? thumbnail);

	TimedPlaybackStatus GetTimedPlaybackSessionStatus(TriggerHandle? handle);

	BitmapSource? GetVideoInputPreviewSnapshot(int width, int height);

	void InitializeWSCallbacks();

	ProResult InspectAction(Pro.SerializationInterop.RVProtoData.Action action);

	ProResult MigrateDocument(string oldFilePath, string newFilePath, ProMigrationType migrationType);

	ProResult NetSendConfigurationMessage(ProNetworkConfigurationMessage config);

	ProResult NetSetNetworkMessageData(MessageDocument messageDocument);

	ProResult NetWSSendClient(ulong clientHandle, string message);

	ProResult RefreshDestinationGroups();

	ProResult RemoveDeviceChangedCallback(ProDeviceType deviceType);

	ProResult ResiEnumerateDestinationGroups(Action<DestinationGroup> callback);

	ProResult ResiEnumerateEncoderProfiles(Action<EncoderProfile> callback);

	ProResult ResiSetAccessToken(string accessToken);

	ProResult ResiSetProcessLocation(string processLocation);

	ProResult SendLinkAction(ProLink.Types.ClientAction protoClientAction);

	void SendLinkActionResponse(ProLink.Types.HandlerOut response);

	ProResult SendNetworkAPICommand(NetworkAPI? command);

	ProResult SendNetworkAPICommand(NetworkAPI_v1? v1);

	ProResult SendStageMessage(string stageMessage);

	ProResult SetClockSource(ProClockSource clockSource);

	ProResult SetSidebarPreviewScreenID(Guid screenID);

	ProResult ShowIdentificationOverlay(string deviceID);

	ProResult StartScreenCapture(RecordRequest protoStream, out int errorCode);

	ProResult StopLocalScreenCapture(Guid streamID);

	ProResult StopScreenCapture(Guid streamID);

	ProResult TriggerAction(TriggerHandle handle, Pro.SerializationInterop.RVProtoData.Action action, TriggerOptions? triggerOptions, object clientObject);

	ProResult TriggerActivate(TriggerHandle handle);

	ProResult TriggerBuildIndex(TriggerHandle handle, Guid slideID, int buildIndex);

	ProResult TriggerClearLayerAction(ProLayerIndex layerIndex, ProContentDestination contentDestination = ProContentDestination.Global);

	ProResult TriggerClearLayerAction(ProContentDestination contentDestination, ProLayerIndex layerIndex);

	ProResult TriggerClearSlotAction(ProLayerIndex layerIndex, Guid slotID, ProContentDestination contentDestination = ProContentDestination.Global);

	ProResult TriggerCue(TriggerHandle handle, Cue cue, object clientObject);

	ProResult TriggerCue(TriggerHandle handle, Cue cue, TriggerOptions triggerOptions, object clientObject);

	ProResult TriggerLogo(TriggerHandle handle, Pro.SerializationInterop.RVProtoData.Action action);

	ProResult TriggerSlideElementUpdate(TriggerHandle trigger, Guid slideID, Guid elementID);

	ProResult TriggerTestPattern(TriggerHandle handle, object clientObject);

	ProResult UpdateAudioInputs(AudioInputSettings settings);

	ProResult UpdateClearGroups(ClearGroupsDocument protoClearGroupsDocument);

	ProResult UpdateDisplaySettings(TriggerHandle handle, ProPresenterWorkspace workspace, object clientObject);

	void UpdateNDIFinderSettings(bool nDIShowSources, string nDIReceiveGroups, string nDIAdditionalSearchIPs);

	ProResult UpdateTimedPlaybackSession(TriggerHandle handle, TimedPlayback.Types.Update update);

	ProResult UpdateVideoInputs(VideoInputSettings settings);

	ProResult SendData(SendData data, out int messageId);

	ProResult IdentifyScreens();

	ProResult DisableScreenIdentification();

	ProResult IdentifyLook();

	ProResult DisableLookIdentification();

	ProResult RenderTestPatternPreview(TestPatternState testPattern, nint texture, int textureWidth, int textureHeight);

	ProResult DisableWatermark();

	ProResult ResiAbortRemoteStream();

	ProResult ResiBeginPluginRemoval();

	ProResult ResiBeginUpdate();

	ProResult ResiEndUpdate();

	ProResult ResiAbortFileUpload();

	ProResult ResiPrepareForShutdown();

	ProResult SetForegroundMediaAudioBehavior(ProContentDestination contentDestination, ProForegroundMediaAudioBehavior foregroundMediaAudioBehavior);

	ProResult SetOnScreenStatsVisible(bool isVisible);

	ProResult UpdateMediaPlaybackMarkers(TriggerHandle handle, ProLayerIndex layer, Pro.SerializationInterop.RVProtoData.Action action);

	ProResult TriggerClearAllAction();

	ProResult CancelAutoAdvance(ProLayerIndex layer);

	ProResult TriggerSlideOnStageOnlyAction(bool stageOnly);

	ProResult ShowOutputs(ProScreenType screenTypes);

	ProResult HideOutputs(ProScreenType screenTypes);

	ProResult HideStageMessage();

	ProResult HideIdentificationOverlays();

	nint CreateRenderView(ProRenderViewType type, nint parentView);

	ProResult DestroyRenderView(nint view);

	ProResult StartMonitoringAudioInput(int inputIndex);

	ProResult StopMonitoringAudioInput(int inputIndex);

	ProResult StartMonitoringVideoInputAudio(int inputIndex);

	ProResult StopMonitoringVideoInputAudio(int inputIndex);

	ProResult NetWSCloseClient(ulong clientHandle);

	ProResult NetSetServiceConfig(ProNetServiceConfig config);

	ProResult NetStartListener(ref ushort port);

	ProResult NetStopListener();

	ProResult PreviewVideoInput(int inputIndex);

	ProResult RenderOutputPreview(ProRenderViewType viewType, nint texture, int textureWidth, int textureHeight);

	bool DirectXVersionMeetsMinimumRequirements();

	void CreateOutputWindow(Guid screenID);
}
