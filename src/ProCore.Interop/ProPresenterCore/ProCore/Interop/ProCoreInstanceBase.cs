using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProCoreInstanceBase : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 336)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProCoreInstanceCreateInfo.__Internal createInfo;

		[FieldOffset(328)]
		internal nint impl;

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proCreateInstance")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult CreateInstance(nint createInfo, nint installPath, nint proCore);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDestroyInstance")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void DestroyInstance(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateDevices")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateDevices(nint __instance, ProDeviceType deviceType, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proAddDeviceChangedCallback")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult AddDeviceChangedCallback(nint __instance, ProDeviceType deviceType, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proRemoveDeviceChangedCallback")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult RemoveDeviceChangedCallback(nint __instance, ProDeviceType deviceType, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateClockSources")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateClockSources(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSetClockSource")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SetClockSource(nint __instance, nint clockSourceData, int clockSourceDataSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proAddClockSourceChangedCallback")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult AddClockSourceChangedCallback(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proRemoveClockSourceChangedCallback")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult RemoveClockSourceChangedCallback(nint __instance, nint userData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerWorkspace")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerWorkspace(nint __instance, ulong handle, nint serializedWorkspace, int serializedWorkspaceSize, nint clientData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proShowOutputs")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ShowOutputs(nint __instance, ProScreenType screenTypes);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proHideOutputs")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult HideOutputs(nint __instance, ProScreenType screenTypes);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proShowIdentificationOverlay")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ShowIdentificationOverlay(nint __instance, nint renderID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proHideIdentificationOverlays")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult HideIdentificationOverlays(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proIdentifyScreens")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult IdentifyScreens(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proIdentifyLook")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult IdentifyLook(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDisableLookIdentification")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult DisableLookIdentification(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDisableScreenIdentification")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult DisableScreenIdentification(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSendStageMessage")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SendStageMessage(nint __instance, nint stageMessage);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proHideStageMessage")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult HideStageMessage(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proCreateRenderView")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern nint CreateRenderView(nint __instance, ProRenderViewType type, nint parentView);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDestroyRenderView")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult DestroyRenderView(nint __instance, nint view);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSetSidebarPreviewScreenID")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SetSidebarPreviewScreenID(nint __instance, nint screenID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSetForegroundMediaAudioBehavior")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SetForegroundMediaAudioBehavior(nint __instance, ProContentDestination contentDestination, ProForegroundMediaAudioBehavior foregroundMediaAudioBehavior);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateAvailableCodecs")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateAvailableCodecs(nint __instance, nint callback, nint userData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStartScreenCapture")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe static extern ProResult StartScreenCapture(nint __instance, nint serializedStream, int serializedSize, int* errorCode);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStopScreenCapture")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StopScreenCapture(nint __instance, nint streamID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStopLocalScreenCapture")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StopLocalScreenCapture(nint __instance, nint streamID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiSetPreserveFiles")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiSetPreserveFiles(nint __instance, uint shouldPreserve);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiSetProcessLocation")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiSetProcessLocation(nint __instance, nint location);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiSetAccessToken")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiSetAccessToken(nint __instance, nint token);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiBeginPluginRemoval")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiBeginPluginRemoval(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiBeginUpdate")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiBeginUpdate(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiEndUpdate")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiEndUpdate(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiRefreshDestinationGroups")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiRefreshDestinationGroups(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiAbortRemoteStream")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiAbortRemoteStream(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiPrepareForShutdown")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiPrepareForShutdown(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiAbortFileUpload")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiAbortFileUpload(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiEnumerateEncoderProfiles")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiEnumerateEncoderProfiles(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proResiEnumerateDestinationGroups")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ResiEnumerateDestinationGroups(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateAudioInputs")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateAudioInputs(nint __instance, nint serializedInputsDocument, int serializedSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStartMonitoringAudioInput")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StartMonitoringAudioInput(nint __instance, int inputIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStopMonitoringAudioInput")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StopMonitoringAudioInput(nint __instance, int inputIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateClearGroups")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateClearGroups(nint __instance, nint serializedClearGroupsDocument, int serializedSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStartMonitoringVideoInputAudio")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StartMonitoringVideoInputAudio(nint __instance, int inputIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStopMonitoringVideoInputAudio")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult StopMonitoringVideoInputAudio(nint __instance, int inputIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proPreviewVideoInput")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult PreviewVideoInput(nint __instance, int inputIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateVideoInputs")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateVideoInputs(nint __instance, nint serializedInputsDocument, int serializedSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateNDIFinderSettings")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateNDIFinderSettings(nint __instance, nint settings);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proLinkAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult LinkAction(nint __instance, nint protoDataIn, int bytesIn);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proLinkActionRegisterCallback")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult LinkActionRegisterCallback(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proAcquireTriggerHandle")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ulong AcquireTriggerHandle(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerActivateWithHandle")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerActivateWithHandle(nint __instance, ulong handle);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerPrerollAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerPrerollAction(nint __instance, ulong handle, nint actionBuffer, int actionSize, nint triggerOptionsBuffer, int triggerOptionsSize, nint clientData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerPrerollCue")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerPrerollCue(nint __instance, ulong handle, nint cueBuffer, int cueSize, nint triggerOptionsBuffer, int triggerOptionsSize, nint clientData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerTestPattern")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerTestPattern(nint __instance, ulong handle, nint clientData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerClearLayerAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerClearLayerAction(nint __instance, ProContentDestination contentDestination, ProLayerIndex layerIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerClearSlotAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerClearSlotAction(nint __instance, ProContentDestination contentDestination, ProLayerIndex layerIndex, nint slotID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerClearAllAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerClearAllAction(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerBuildIndex")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerBuildIndex(nint __instance, ulong trigger, nint slideID, int buildIndex);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerSlideElementUpdate")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerSlideElementUpdate(nint __instance, ulong trigger, nint slideID, nint elementID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerSlideOnStageOnlyAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerSlideOnStageOnlyAction(nint __instance, uint stageOnly);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proTriggerLogo")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult TriggerLogo(nint __instance, ulong handle, nint actionBuffer, int actionSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateMediaPlaybackMarkers")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateMediaPlaybackMarkers(nint __instance, ulong triggerHandle, ProLayerIndex layer, nint markerUpdateData, int markerUpdateDataSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetStartListener")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe static extern ProResult NetStartListener(nint __instance, ushort* port);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetStopListener")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetStopListener(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetSetServiceConfig")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetSetServiceConfig(nint __instance, nint config);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetSetWSCallbacks")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetSetWSCallbacks(nint __instance, nint userData, nint connectedCallback, nint disconnectedCallback, nint messageCallback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetWSCloseClient")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetWSCloseClient(nint __instance, ulong clientHandle);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetWSSendClient")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetWSSendClient(nint __instance, ulong clientHandle, nint messageData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetSendNetworkAPIMessage")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetSendNetworkAPIMessage(nint __instance, nint messageData);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetSetNetworkMessageData")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetSetNetworkMessageData(nint __instance, nint messageData, int packetSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proNetSendConfigurationMessage")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult NetSendConfigurationMessage(nint __instance, nint messageData, int messageDataSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proMigrateDocument")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult MigrateDocument(nint __instance, nint oldFilePath, nint newFilePath, ProMigrationType migrationType);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proGetMediaMetadata")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult GetMediaMetadata(nint __instance, nint metadataRequestInfo, int metadataRequestInfoSize, uint isImport, uint useDefaultNativeRotation, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proGetPreviewSnapshot")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult GetPreviewSnapshot(nint __instance, ProRenderViewType previewType, int thumbnailWidth, int thumbnailHeight, nint cropInsets, int rotation, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateAvailableNDIModes")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateAvailableNDIModes(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateAvailableTransitions")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateAvailableTransitions(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnumerateAvailableEffects")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnumerateAvailableEffects(nint __instance, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proGenerateTransitionImages")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult GenerateTransitionImages(nint __instance, nint transitionData, int packetSize, nint srcImageA, nint srcImageB, int width, int height, int frameCount, nint userData, nint callback);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proEnableWatermark")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult EnableWatermark(nint __instance, nint imageData, int imageWidth, int imageHeight, nint textData, int textWidth, int textHeight);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDisableWatermark")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult DisableWatermark(nint __instance);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSetOnScreenStatsVisible")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SetOnScreenStatsVisible(nint __instance, uint isVisible);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proInspectAction")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult InspectAction(nint __instance, nint actionBuffer, int actionBufferSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proControlTransport")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult ControlTransport(nint __instance, ProLayerIndex layerIndex, nint actionBuffer, int actionBufferSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proCancelAutoAdvance")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult CancelAutoAdvance(nint __instance, ProLayerIndex layer);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proCreateTimedPlaybackSession")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ulong CreateTimedPlaybackSession(nint __instance, nint sessionInfoData, int sessionInfoDataSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDestroyTimedPlaybackSession")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult DestroyTimedPlaybackSession(nint __instance, ulong sessionHandle);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proUpdateTimedPlaybackSession")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult UpdateTimedPlaybackSession(nint __instance, ulong sessionHandle, nint sessionUpdateData, int sessionUpdateDataSize);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proGetTimedPlaybackSessionStatus")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult GetTimedPlaybackSessionStatus(nint __instance, ulong sessionHandle, nint status);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proSendData")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult SendData(nint __instance, nint data, int size);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proRenderTestPatternPreview")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult RenderTestPatternPreview(nint __instance, nint data, int size, nint texture, int width, int height);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proRenderPreview")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult RenderPreview(nint __instance, ProRenderViewType previewType, nint texture, int width, int height);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proCreateOutputWindow")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern ProResult CreateOutputWindow(nint __instance, nint screenID);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proGpuMeetsMinRequirement")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe static extern ProResult GpuMeetsMinRequirement(nint __instance, int* meetsMinReq);
	}

	internal static readonly ConcurrentDictionary<nint, ProCoreInstanceBase> NativeToManagedMap = new ConcurrentDictionary<nint, ProCoreInstanceBase>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProCoreInstanceCreateInfo CreateInfo
	{
		get
		{
			return ProCoreInstanceCreateInfo.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->createInfo));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->createInfo = *(ProCoreInstanceCreateInfo.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProCoreInstanceBase __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProCoreInstanceBase(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProCoreInstanceBase __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProCoreInstanceBase(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProCoreInstanceBase(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProCoreInstanceBase(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	~ProCoreInstanceBase()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void Dispose(bool disposing)
	{
		if (__Instance != IntPtr.Zero)
		{
			NativeToManagedMap.TryRemove(__Instance, out var _);
			if (__ownsNativeInstance)
			{
				Marshal.FreeHGlobal(__Instance);
			}
			__Instance = IntPtr.Zero;
		}
	}

	protected void DestroyInstance()
	{
		__Internal.DestroyInstance(__Instance);
	}

	public ProResult EnumerateDevices(ProDeviceType deviceType, nint userData, ProEnumerateDevicesCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateDevices(__Instance, deviceType, userData, callback2);
	}

	public ProResult AddDeviceChangedCallback(ProDeviceType deviceType, nint userData, ProDeviceChangedCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.AddDeviceChangedCallback(__Instance, deviceType, userData, callback2);
	}

	public ProResult RemoveDeviceChangedCallback(ProDeviceType deviceType, nint userData, ProDeviceChangedCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.RemoveDeviceChangedCallback(__Instance, deviceType, userData, callback2);
	}

	public ProResult EnumerateClockSources(nint userData, ProEnumerateClockSourcesCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateClockSources(__Instance, userData, callback2);
	}

	public ProResult SetClockSource(nint clockSourceData, int clockSourceDataSize)
	{
		return __Internal.SetClockSource(__Instance, clockSourceData, clockSourceDataSize);
	}

	public ProResult AddClockSourceChangedCallback(nint userData, ProClockSourceChangedCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.AddClockSourceChangedCallback(__Instance, userData, callback2);
	}

	public ProResult RemoveClockSourceChangedCallback(nint userData)
	{
		return __Internal.RemoveClockSourceChangedCallback(__Instance, userData);
	}

	public ProResult TriggerWorkspace(ulong handle, nint serializedWorkspace, int serializedWorkspaceSize, nint clientData)
	{
		return __Internal.TriggerWorkspace(__Instance, handle, serializedWorkspace, serializedWorkspaceSize, clientData);
	}

	public ProResult ShowOutputs(ProScreenType screenTypes)
	{
		return __Internal.ShowOutputs(__Instance, screenTypes);
	}

	public ProResult HideOutputs(ProScreenType screenTypes)
	{
		return __Internal.HideOutputs(__Instance, screenTypes);
	}

	public ProResult ShowIdentificationOverlay(nint renderID)
	{
		return __Internal.ShowIdentificationOverlay(__Instance, renderID);
	}

	public ProResult HideIdentificationOverlays()
	{
		return __Internal.HideIdentificationOverlays(__Instance);
	}

	public ProResult IdentifyScreens()
	{
		return __Internal.IdentifyScreens(__Instance);
	}

	public ProResult IdentifyLook()
	{
		return __Internal.IdentifyLook(__Instance);
	}

	public ProResult DisableLookIdentification()
	{
		return __Internal.DisableLookIdentification(__Instance);
	}

	public ProResult DisableScreenIdentification()
	{
		return __Internal.DisableScreenIdentification(__Instance);
	}

	public ProResult SendStageMessage(nint stageMessage)
	{
		return __Internal.SendStageMessage(__Instance, stageMessage);
	}

	public ProResult HideStageMessage()
	{
		return __Internal.HideStageMessage(__Instance);
	}

	public nint CreateRenderView(ProRenderViewType type, nint parentView)
	{
		return __Internal.CreateRenderView(__Instance, type, parentView);
	}

	public ProResult DestroyRenderView(nint view)
	{
		return __Internal.DestroyRenderView(__Instance, view);
	}

	public ProResult SetSidebarPreviewScreenID(ProUUID screenID)
	{
		nint screenID2 = screenID?.__Instance ?? IntPtr.Zero;
		return __Internal.SetSidebarPreviewScreenID(__Instance, screenID2);
	}

	public ProResult SetForegroundMediaAudioBehavior(ProContentDestination contentDestination, ProForegroundMediaAudioBehavior foregroundMediaAudioBehavior)
	{
		return __Internal.SetForegroundMediaAudioBehavior(__Instance, contentDestination, foregroundMediaAudioBehavior);
	}

	public ProResult EnumerateAvailableCodecs(ProScreenCaptureCodecCallback callback, nint userData)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateAvailableCodecs(__Instance, callback2, userData);
	}

	public unsafe ProResult StartScreenCapture(nint serializedStream, int serializedSize, ref int errorCode)
	{
		fixed (int* errorCode2 = &errorCode)
		{
			return __Internal.StartScreenCapture(__Instance, serializedStream, serializedSize, errorCode2);
		}
	}

	public ProResult StopScreenCapture(ProUUID streamID)
	{
		nint streamID2 = streamID?.__Instance ?? IntPtr.Zero;
		return __Internal.StopScreenCapture(__Instance, streamID2);
	}

	public ProResult StopLocalScreenCapture(ProUUID streamID)
	{
		nint streamID2 = streamID?.__Instance ?? IntPtr.Zero;
		return __Internal.StopLocalScreenCapture(__Instance, streamID2);
	}

	public ProResult ResiSetPreserveFiles(bool shouldPreserve)
	{
		uint shouldPreserve2 = (shouldPreserve ? 1u : 0u);
		return __Internal.ResiSetPreserveFiles(__Instance, shouldPreserve2);
	}

	public ProResult ResiSetProcessLocation(nint location)
	{
		return __Internal.ResiSetProcessLocation(__Instance, location);
	}

	public ProResult ResiSetAccessToken(nint token)
	{
		return __Internal.ResiSetAccessToken(__Instance, token);
	}

	public ProResult ResiBeginPluginRemoval()
	{
		return __Internal.ResiBeginPluginRemoval(__Instance);
	}

	public ProResult ResiBeginUpdate()
	{
		return __Internal.ResiBeginUpdate(__Instance);
	}

	public ProResult ResiEndUpdate()
	{
		return __Internal.ResiEndUpdate(__Instance);
	}

	public ProResult ResiRefreshDestinationGroups()
	{
		return __Internal.ResiRefreshDestinationGroups(__Instance);
	}

	public ProResult ResiAbortRemoteStream()
	{
		return __Internal.ResiAbortRemoteStream(__Instance);
	}

	public ProResult ResiPrepareForShutdown()
	{
		return __Internal.ResiPrepareForShutdown(__Instance);
	}

	public ProResult ResiAbortFileUpload()
	{
		return __Internal.ResiAbortFileUpload(__Instance);
	}

	public ProResult ResiEnumerateEncoderProfiles(nint userData, ProEnumerateResiEncoderProfiles callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.ResiEnumerateEncoderProfiles(__Instance, userData, callback2);
	}

	public ProResult ResiEnumerateDestinationGroups(nint userData, ProEnumerateResiDestinationGroups callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.ResiEnumerateDestinationGroups(__Instance, userData, callback2);
	}

	public ProResult UpdateAudioInputs(nint serializedInputsDocument, int serializedSize)
	{
		return __Internal.UpdateAudioInputs(__Instance, serializedInputsDocument, serializedSize);
	}

	public ProResult StartMonitoringAudioInput(int inputIndex)
	{
		return __Internal.StartMonitoringAudioInput(__Instance, inputIndex);
	}

	public ProResult StopMonitoringAudioInput(int inputIndex)
	{
		return __Internal.StopMonitoringAudioInput(__Instance, inputIndex);
	}

	public ProResult UpdateClearGroups(nint serializedClearGroupsDocument, int serializedSize)
	{
		return __Internal.UpdateClearGroups(__Instance, serializedClearGroupsDocument, serializedSize);
	}

	public ProResult StartMonitoringVideoInputAudio(int inputIndex)
	{
		return __Internal.StartMonitoringVideoInputAudio(__Instance, inputIndex);
	}

	public ProResult StopMonitoringVideoInputAudio(int inputIndex)
	{
		return __Internal.StopMonitoringVideoInputAudio(__Instance, inputIndex);
	}

	public ProResult PreviewVideoInput(int inputIndex)
	{
		return __Internal.PreviewVideoInput(__Instance, inputIndex);
	}

	public ProResult UpdateVideoInputs(nint serializedInputsDocument, int serializedSize)
	{
		return __Internal.UpdateVideoInputs(__Instance, serializedInputsDocument, serializedSize);
	}

	public ProResult UpdateNDIFinderSettings(ProNDIFinderSettings settings)
	{
		nint settings2 = settings?.__Instance ?? IntPtr.Zero;
		return __Internal.UpdateNDIFinderSettings(__Instance, settings2);
	}

	public ProResult LinkAction(nint protoDataIn, int bytesIn)
	{
		return __Internal.LinkAction(__Instance, protoDataIn, bytesIn);
	}

	public ProResult LinkActionRegisterCallback(nint userData, ProLinkCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.LinkActionRegisterCallback(__Instance, userData, callback2);
	}

	public ulong AcquireTriggerHandle()
	{
		return __Internal.AcquireTriggerHandle(__Instance);
	}

	public ProResult TriggerActivateWithHandle(ulong handle)
	{
		return __Internal.TriggerActivateWithHandle(__Instance, handle);
	}

	public ProResult TriggerPrerollAction(ulong handle, nint actionBuffer, int actionSize, nint triggerOptionsBuffer, int triggerOptionsSize, nint clientData)
	{
		return __Internal.TriggerPrerollAction(__Instance, handle, actionBuffer, actionSize, triggerOptionsBuffer, triggerOptionsSize, clientData);
	}

	public ProResult TriggerPrerollCue(ulong handle, nint cueBuffer, int cueSize, nint triggerOptionsBuffer, int triggerOptionsSize, nint clientData)
	{
		return __Internal.TriggerPrerollCue(__Instance, handle, cueBuffer, cueSize, triggerOptionsBuffer, triggerOptionsSize, clientData);
	}

	public ProResult TriggerTestPattern(ulong handle, nint clientData)
	{
		return __Internal.TriggerTestPattern(__Instance, handle, clientData);
	}

	public ProResult TriggerClearLayerAction(ProContentDestination contentDestination, ProLayerIndex layerIndex)
	{
		return __Internal.TriggerClearLayerAction(__Instance, contentDestination, layerIndex);
	}

	public ProResult TriggerClearSlotAction(ProContentDestination contentDestination, ProLayerIndex layerIndex, ProUUID slotID)
	{
		nint slotID2 = slotID?.__Instance ?? IntPtr.Zero;
		return __Internal.TriggerClearSlotAction(__Instance, contentDestination, layerIndex, slotID2);
	}

	public ProResult TriggerClearAllAction()
	{
		return __Internal.TriggerClearAllAction(__Instance);
	}

	public ProResult TriggerBuildIndex(ulong trigger, ProUUID slideID, int buildIndex)
	{
		nint slideID2 = slideID?.__Instance ?? IntPtr.Zero;
		return __Internal.TriggerBuildIndex(__Instance, trigger, slideID2, buildIndex);
	}

	public ProResult TriggerSlideElementUpdate(ulong trigger, ProUUID slideID, ProUUID elementID)
	{
		nint slideID2 = slideID?.__Instance ?? IntPtr.Zero;
		nint elementID2 = elementID?.__Instance ?? IntPtr.Zero;
		return __Internal.TriggerSlideElementUpdate(__Instance, trigger, slideID2, elementID2);
	}

	public ProResult TriggerSlideOnStageOnlyAction(bool stageOnly)
	{
		uint stageOnly2 = (stageOnly ? 1u : 0u);
		return __Internal.TriggerSlideOnStageOnlyAction(__Instance, stageOnly2);
	}

	public ProResult TriggerLogo(ulong handle, nint actionBuffer, int actionSize)
	{
		return __Internal.TriggerLogo(__Instance, handle, actionBuffer, actionSize);
	}

	public ProResult UpdateMediaPlaybackMarkers(ulong triggerHandle, ProLayerIndex layer, nint markerUpdateData, int markerUpdateDataSize)
	{
		return __Internal.UpdateMediaPlaybackMarkers(__Instance, triggerHandle, layer, markerUpdateData, markerUpdateDataSize);
	}

	public unsafe ProResult NetStartListener(ref ushort port)
	{
		fixed (ushort* port2 = &port)
		{
			return __Internal.NetStartListener(__Instance, port2);
		}
	}

	public ProResult NetStopListener()
	{
		return __Internal.NetStopListener(__Instance);
	}

	public ProResult NetSetServiceConfig(ProNetServiceConfig config)
	{
		nint config2 = config?.__Instance ?? IntPtr.Zero;
		return __Internal.NetSetServiceConfig(__Instance, config2);
	}

	public ProResult NetSetWSCallbacks(nint userData, ProWSConnectedCallback connectedCallback, ProWSDisconnectedCallback disconnectedCallback, ProWSMessageCallback messageCallback)
	{
		nint connectedCallback2 = ((connectedCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(connectedCallback));
		nint disconnectedCallback2 = ((disconnectedCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(disconnectedCallback));
		nint messageCallback2 = ((messageCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(messageCallback));
		return __Internal.NetSetWSCallbacks(__Instance, userData, connectedCallback2, disconnectedCallback2, messageCallback2);
	}

	public ProResult NetWSCloseClient(ulong clientHandle)
	{
		return __Internal.NetWSCloseClient(__Instance, clientHandle);
	}

	public ProResult NetWSSendClient(ulong clientHandle, ProWSMessageData messageData)
	{
		nint messageData2 = messageData?.__Instance ?? IntPtr.Zero;
		return __Internal.NetWSSendClient(__Instance, clientHandle, messageData2);
	}

	public ProResult NetSendNetworkAPIMessage(ProWSMessageData messageData)
	{
		nint messageData2 = messageData?.__Instance ?? IntPtr.Zero;
		return __Internal.NetSendNetworkAPIMessage(__Instance, messageData2);
	}

	public ProResult NetSetNetworkMessageData(nint messageData, int packetSize)
	{
		return __Internal.NetSetNetworkMessageData(__Instance, messageData, packetSize);
	}

	public ProResult NetSendConfigurationMessage(nint messageData, int messageDataSize)
	{
		return __Internal.NetSendConfigurationMessage(__Instance, messageData, messageDataSize);
	}

	public ProResult MigrateDocument(nint oldFilePath, nint newFilePath, ProMigrationType migrationType)
	{
		return __Internal.MigrateDocument(__Instance, oldFilePath, newFilePath, migrationType);
	}

	public ProResult GetMediaMetadata(nint metadataRequestInfo, int metadataRequestInfoSize, bool isImport, bool useDefaultNativeRotation, nint userData, ProMediaMetadataRequestCallback callback)
	{
		uint isImport2 = (isImport ? 1u : 0u);
		uint useDefaultNativeRotation2 = (useDefaultNativeRotation ? 1u : 0u);
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.GetMediaMetadata(__Instance, metadataRequestInfo, metadataRequestInfoSize, isImport2, useDefaultNativeRotation2, userData, callback2);
	}

	public ProResult GetPreviewSnapshot(ProRenderViewType previewType, int thumbnailWidth, int thumbnailHeight, ProInsets cropInsets, int rotation, nint userData, ProMediaSnapshotRequestCallback callback)
	{
		nint cropInsets2 = cropInsets?.__Instance ?? IntPtr.Zero;
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.GetPreviewSnapshot(__Instance, previewType, thumbnailWidth, thumbnailHeight, cropInsets2, rotation, userData, callback2);
	}

	public ProResult EnumerateAvailableNDIModes(nint userData, ProEnumerateNDIModesCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateAvailableNDIModes(__Instance, userData, callback2);
	}

	public ProResult EnumerateAvailableTransitions(nint userData, ProEnumerateTransitionsCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateAvailableTransitions(__Instance, userData, callback2);
	}

	public ProResult EnumerateAvailableEffects(nint userData, ProEnumerateEffectsCallback callback)
	{
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.EnumerateAvailableEffects(__Instance, userData, callback2);
	}

	public ProResult GenerateTransitionImages(nint transitionData, int packetSize, ProClientImageTransfer srcImageA, ProClientImageTransfer srcImageB, int width, int height, int frameCount, nint userData, ProTransitionImagesCallback callback)
	{
		nint srcImageA2 = srcImageA?.__Instance ?? IntPtr.Zero;
		nint srcImageB2 = srcImageB?.__Instance ?? IntPtr.Zero;
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		return __Internal.GenerateTransitionImages(__Instance, transitionData, packetSize, srcImageA2, srcImageB2, width, height, frameCount, userData, callback2);
	}

	public ProResult EnableWatermark(nint imageData, int imageWidth, int imageHeight, nint textData, int textWidth, int textHeight)
	{
		return __Internal.EnableWatermark(__Instance, imageData, imageWidth, imageHeight, textData, textWidth, textHeight);
	}

	public ProResult DisableWatermark()
	{
		return __Internal.DisableWatermark(__Instance);
	}

	public ProResult SetOnScreenStatsVisible(bool isVisible)
	{
		uint isVisible2 = (isVisible ? 1u : 0u);
		return __Internal.SetOnScreenStatsVisible(__Instance, isVisible2);
	}

	public ProResult InspectAction(nint actionBuffer, int actionBufferSize)
	{
		return __Internal.InspectAction(__Instance, actionBuffer, actionBufferSize);
	}

	public ProResult ControlTransport(ProLayerIndex layerIndex, nint actionBuffer, int actionBufferSize)
	{
		return __Internal.ControlTransport(__Instance, layerIndex, actionBuffer, actionBufferSize);
	}

	public ProResult CancelAutoAdvance(ProLayerIndex layer)
	{
		return __Internal.CancelAutoAdvance(__Instance, layer);
	}

	public ulong CreateTimedPlaybackSession(nint sessionInfoData, int sessionInfoDataSize)
	{
		return __Internal.CreateTimedPlaybackSession(__Instance, sessionInfoData, sessionInfoDataSize);
	}

	public ProResult DestroyTimedPlaybackSession(ulong sessionHandle)
	{
		return __Internal.DestroyTimedPlaybackSession(__Instance, sessionHandle);
	}

	public ProResult UpdateTimedPlaybackSession(ulong sessionHandle, nint sessionUpdateData, int sessionUpdateDataSize)
	{
		return __Internal.UpdateTimedPlaybackSession(__Instance, sessionHandle, sessionUpdateData, sessionUpdateDataSize);
	}

	public ProResult GetTimedPlaybackSessionStatus(ulong sessionHandle, TimedPlaybackStatus status)
	{
		nint status2 = status?.__Instance ?? IntPtr.Zero;
		return __Internal.GetTimedPlaybackSessionStatus(__Instance, sessionHandle, status2);
	}

	public ProResult SendData(nint data, int size)
	{
		return __Internal.SendData(__Instance, data, size);
	}

	public ProResult RenderTestPatternPreview(nint data, int size, nint texture, int width, int height)
	{
		return __Internal.RenderTestPatternPreview(__Instance, data, size, texture, width, height);
	}

	public ProResult RenderPreview(ProRenderViewType previewType, nint texture, int width, int height)
	{
		return __Internal.RenderPreview(__Instance, previewType, texture, width, height);
	}

	public ProResult CreateOutputWindow(ProUUID screenID)
	{
		nint screenID2 = screenID?.__Instance ?? IntPtr.Zero;
		return __Internal.CreateOutputWindow(__Instance, screenID2);
	}

	public unsafe ProResult GpuMeetsMinRequirement(ref int meetsMinReq)
	{
		fixed (int* meetsMinReq2 = &meetsMinReq)
		{
			return __Internal.GpuMeetsMinRequirement(__Instance, meetsMinReq2);
		}
	}

	protected unsafe static ProResult CreateInstance(ProCoreInstanceCreateInfo createInfo, nint installPath, ProCoreInstanceBase proCore)
	{
		nint createInfo2 = createInfo?.__Instance ?? IntPtr.Zero;
		nint num = proCore?.__Instance ?? IntPtr.Zero;
		nint proCore2 = new IntPtr(&num);
		return __Internal.CreateInstance(createInfo2, installPath, proCore2);
	}
}
