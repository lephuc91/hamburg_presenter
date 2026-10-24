using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Analytics.API;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;
using Pro.SerializationInterop.RVProtoData.Analytics.Edit;
using Pro.SerializationInterop.RVProtoData.Analytics.Import;
using Pro.SerializationInterop.RVProtoData.Analytics.Logs;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;
using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;
using Pro.SerializationInterop.RVProtoData.Analytics.PlaybackMarker;
using Pro.SerializationInterop.RVProtoData.Analytics.ProContent;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;
using Pro.SerializationInterop.RVProtoData.Analytics.Sync;
using Pro.SerializationInterop.RVProtoData.Analytics.Timecode;
using Pro.SerializationInterop.RVProtoData.Analytics.Timeline;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using Pro.SerializationInterop.RVProtoData.Analytics.Trigger;
using Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;
using Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;
using Rv.Analytics.Powerpoint;

namespace Pro.SerializationInterop.RVProtoData.Analytics;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Event : IMessage<Event>, IMessage, IEquatable<Event>, IDeepCloneable<Event>
{
	public enum InteractionOneofCase
	{
		None = 0,
		ApiMessageReceived = 1,
		CreateLibrary = 2,
		CreatePlaylist = 3,
		CreatePresentation = 4,
		CreateFromTemplatePlaylist = 5,
		EditPresentation = 6,
		ImportSongselect = 7,
		ImportMultitracks = 8,
		ProcontentMediabinView = 9,
		ProcontentDownload = 10,
		ProcontentDownloadRetry = 11,
		PlaybackMarker = 12,
		StartupLooks = 13,
		StartupScreenConfiguration = 14,
		StartupScreenConfigurationScreen = 15,
		StartupScreenConfigurationSingleScreen = 16,
		StartupScreenConfigurationMirroredScreen = 17,
		StartupScreenConfigurationEdgeBlendScreen = 18,
		StartupScreenConfigurationGroupedScreen = 19,
		StartupPreferences = 20,
		StartupSongselect = 21,
		StartupContent = 22,
		StartupThemes = 23,
		StartupMacro = 24,
		StartupClearGroup = 25,
		StartupKeyMapping = 26,
		StartupMultitracks = 27,
		StartupNetworkLink = 28,
		StartupCapture = 29,
		StartupVersioning = 30,
		StartupDiskUsage = 31,
		StartupInterface = 32,
		SyncLocal = 33,
		TimecodeActivate = 34,
		TimecodeStartup = 35,
		TimelineAction = 36,
		TimelineRecordCue = 37,
		TimelineCueTrigger = 38,
		ApplicationLaunch = 50,
		VideoInputTriggered = 51,
		VideoInputCustomMap = 52,
		VideoInputStartUp = 53,
		VideoInputThumbnailUpdate = 54,
		AudioInputAutoOnChange = 55,
		AudioSettingsSdiNdiActive = 56,
		AudioSettingsCustomMap = 57,
		AudioInputModeSelection = 58,
		AudioInputAutoOnStartup = 59,
		AudioSettingsSdiNdiState = 60,
		AudioInputStartUp = 61,
		CueTriggered = 62,
		InputAudioMonitoring = 63,
		ResiStartUp = 64,
		ResiLoginChange = 65,
		RemoteStreamStart = 66,
		RemoteStreamStop = 67,
		StartCaptureDisk = 68,
		StartCaptureRtmp = 69,
		StartCaptureResi = 70,
		StopCapture = 71,
		AnalyticReset = 72,
		Print = 73,
		Device = 74,
		Downgrade = 75,
		CcliReport = 76,
		TransitionWindow = 77,
		EditorObjectAdded = 78,
		DataIdDuplicated = 79,
		ForceQuit = 80,
		MediaCleanupSize = 81,
		NetworkApp = 82,
		LocalWorkspaceStats = 83,
		SyncingUnpaused = 84,
		TriggerActionCaptureStart = 100,
		TriggerActionCaptureStop = 101,
		TriggerActionClear = 102,
		TriggerActionClearGroup = 103,
		TriggerActionCommunications = 104,
		TriggerActionLook = 105,
		TriggerActionMacro = 106,
		TriggerActionMessage = 107,
		TriggerActionProp = 108,
		TriggerActionSlideDestination = 109,
		TriggerActionStage = 110,
		TriggerActionTimer = 111,
		TriggerMediaAudio = 112,
		TriggerMediaImage = 113,
		TriggerMediaVideoInput = 114,
		TriggerMediaVideo = 115,
		TriggerCueSlide = 116,
		TriggerCueSlideFileFeedElement = 117,
		TriggerCueSlideRssFeedElement = 118,
		TriggerCueSlideScrollingTextElement = 119,
		TriggerTestPattern = 120,
		TriggerMediaAircastVideo = 121,
		TriggerMediaAircastAudio = 122,
		AircastVideoInputConfigured = 123,
		AircastAudioInputConfigured = 124,
		MediaManagementInstallationComplete = 140,
		MediaManagementBootstrappingComplete = 141,
		MediaManagementMessageFailure = 142,
		MediaManagementUnexpectedlyNotRunning = 143,
		MediaManagementConnectionChanged = 144,
		MediaManagementAddedMediaReference = 145,
		MediaManagementNotResponding = 146,
		UiQuicksearch = 200,
		UiQuicksearchSearch = 201,
		UiQuicksearchOpenitems = 202,
		UiToolbarTheme = 203,
		UiToolbarThemeApplication = 204,
		UiMainviewShow = 205,
		UiMainviewPresentationEditor = 206,
		UiMainviewReflow = 207,
		UiMainviewBible = 208,
		BibleTrigger = 209,
		BibleGenerateSlides = 210,
		BibleGenerateNext = 211,
		BibleGeneratePrevious = 212,
		BibleSaveSlides = 213,
		BibleLookup = 214,
		BibleStartup = 215,
		BibleRemove = 216,
		BibleInstall = 217,
		UiMainviewMaskEditor = 218,
		UiMainviewStageEditor = 219,
		UiMainviewThemeEditor = 220,
		UiMainviewCopyrightEditor = 221,
		UiMainviewPropsEditor = 222,
		UiLowerrightTimers = 223,
		UiLowerrightTimersCollapse = 224,
		UiLowerrightTimersEdit = 225,
		UiLowerrightTimersState = 226,
		UiLowerrightTimersCreate = 227,
		UiLowerrightTimersDelete = 228,
		UiLowerrightMessages = 229,
		UiLowerrightMessagesEdit = 230,
		UiLowerrightMessagesState = 231,
		UiLowerrightMessagesCreate = 232,
		UiLowerrightMessagesDelete = 233,
		UiLowerrightProps = 234,
		UiLowerrightPropsTransition = 235,
		UiLowerrightPropsCreate = 236,
		UiLowerrightPropsDelete = 237,
		UiLowerrightPropsState = 238,
		UiLowerrightStage = 239,
		UiLowerrightStageChangelayout = 240,
		UiLowerrightStageMessagestate = 241,
		UiLowerrightStageConfigurescreens = 242,
		UiLowerrightStageEditlayouts = 243,
		UiLowerrightMacros = 244,
		UiLowerrightMacrosTrigger = 245,
		UiLowerrightMacrosCreate = 246,
		UiLowerrightMacrosDelete = 247,
		UiTextinspector = 248,
		UiTextinspectorScrollingText = 249,
		UiTextinspectorForeground = 250,
		UiTextinspectorUnderlineColor = 251,
		UiTextinspectorBackgroundColor = 252,
		UiTextinspectorLineTransform = 253,
		UiShowSlideLabel = 254,
		UiShowSlideLabelChange = 255,
		UiEditorOverlayShown = 258,
		UiEditorOverlayClosed = 259,
		UiWhatsNewViewed = 260,
		UiClearGroups = 261,
		UiClearGroupsCreate = 262,
		UiClearGroupsDelete = 263,
		UiClearGroupsChangeVisibility = 264,
		UiClearGroupsChangeIcon = 265,
		UiPreviewAreaClearGroupsTrigger = 266,
		UiPreviewAreaClearGroupsChanged = 267,
		UiPlaceholderLink = 268,
		UiPlaceholderUnlink = 269,
		UiPlanningCenterLive = 270,
		UiNetworkgroupAdd = 271,
		UiNetworkgroupRemove = 272,
		UiNetworkgroupLeave = 283,
		UiCcliReportReset = 273,
		UiCcliReportShown = 274,
		UiCaptureShown = 275,
		UiWelcome = 276,
		UiWelcomeScreenConfigurationHelp = 277,
		UiWelcomeDownloadSampleContent = 278,
		UiWelcomeUserGroup = 279,
		UiWelcomeTutorials = 280,
		UiWelcomeKnowlegdeBase = 284,
		UiWelcomeBlog = 285,
		UiWelcomeFacebook = 286,
		UiWelcomeInstagram = 287,
		UiWelcomeMigration = 288,
		UiTestPatterns = 281,
		UiSettingsCustomLogo = 282,
		UiWindowedOutputCreated = 289,
		ImportPowerpoint = 290,
		LibraryUsage = 291,
		FontReplacement = 292,
		LogDocumentUploaded = 293,
		LogDocumentDownloaded = 294,
		LogDiffPushed = 295,
		LogDiffReceived = 296,
		TriggerExternalPresentation = 297,
		WorkspaceCreation = 298,
		AvailableWorkspace = 299,
		OnboardingFlowOutcome = 300,
		LogWorkspacesPublished = 301,
		LogCollaboratorsPublished = 302,
		LogConvertToCloud = 303,
		LogConvertToLocal = 304,
		LogSyncingChange = 305,
		LogDocumentStored = 306,
		LogDocumentCreated = 307,
		LogDocumentUpdated = 308,
		LogDocumentDeleted = 309,
		LogDocumentConflict = 310,
		LogWorkspaceResynchronized = 311,
		LogWsConnectionFailed = 312,
		LogError = 313,
		UserWorkspaceTreeModification = 314,
		UiActivationFlowOpened = 315,
		LogOpenedWorkspace = 316
	}

	private static readonly MessageParser<Event> _parser = new MessageParser<Event>(() => new Event());

	private UnknownFieldSet _unknownFields;

	public const int ApiMessageReceivedFieldNumber = 1;

	public const int CreateLibraryFieldNumber = 2;

	public const int CreatePlaylistFieldNumber = 3;

	public const int CreatePresentationFieldNumber = 4;

	public const int CreateFromTemplatePlaylistFieldNumber = 5;

	public const int EditPresentationFieldNumber = 6;

	public const int ImportSongselectFieldNumber = 7;

	public const int ImportMultitracksFieldNumber = 8;

	public const int ProcontentMediabinViewFieldNumber = 9;

	public const int ProcontentDownloadFieldNumber = 10;

	public const int ProcontentDownloadRetryFieldNumber = 11;

	public const int PlaybackMarkerFieldNumber = 12;

	public const int StartupLooksFieldNumber = 13;

	public const int StartupScreenConfigurationFieldNumber = 14;

	public const int StartupScreenConfigurationScreenFieldNumber = 15;

	public const int StartupScreenConfigurationSingleScreenFieldNumber = 16;

	public const int StartupScreenConfigurationMirroredScreenFieldNumber = 17;

	public const int StartupScreenConfigurationEdgeBlendScreenFieldNumber = 18;

	public const int StartupScreenConfigurationGroupedScreenFieldNumber = 19;

	public const int StartupPreferencesFieldNumber = 20;

	public const int StartupSongselectFieldNumber = 21;

	public const int StartupContentFieldNumber = 22;

	public const int StartupThemesFieldNumber = 23;

	public const int StartupMacroFieldNumber = 24;

	public const int StartupClearGroupFieldNumber = 25;

	public const int StartupKeyMappingFieldNumber = 26;

	public const int StartupMultitracksFieldNumber = 27;

	public const int StartupNetworkLinkFieldNumber = 28;

	public const int StartupCaptureFieldNumber = 29;

	public const int StartupVersioningFieldNumber = 30;

	public const int StartupDiskUsageFieldNumber = 31;

	public const int StartupInterfaceFieldNumber = 32;

	public const int SyncLocalFieldNumber = 33;

	public const int TimecodeActivateFieldNumber = 34;

	public const int TimecodeStartupFieldNumber = 35;

	public const int TimelineActionFieldNumber = 36;

	public const int TimelineRecordCueFieldNumber = 37;

	public const int TimelineCueTriggerFieldNumber = 38;

	public const int ApplicationLaunchFieldNumber = 50;

	public const int VideoInputTriggeredFieldNumber = 51;

	public const int VideoInputCustomMapFieldNumber = 52;

	public const int VideoInputStartUpFieldNumber = 53;

	public const int VideoInputThumbnailUpdateFieldNumber = 54;

	public const int AudioInputAutoOnChangeFieldNumber = 55;

	public const int AudioSettingsSdiNdiActiveFieldNumber = 56;

	public const int AudioSettingsCustomMapFieldNumber = 57;

	public const int AudioInputModeSelectionFieldNumber = 58;

	public const int AudioInputAutoOnStartupFieldNumber = 59;

	public const int AudioSettingsSdiNdiStateFieldNumber = 60;

	public const int AudioInputStartUpFieldNumber = 61;

	public const int CueTriggeredFieldNumber = 62;

	public const int InputAudioMonitoringFieldNumber = 63;

	public const int ResiStartUpFieldNumber = 64;

	public const int ResiLoginChangeFieldNumber = 65;

	public const int RemoteStreamStartFieldNumber = 66;

	public const int RemoteStreamStopFieldNumber = 67;

	public const int StartCaptureDiskFieldNumber = 68;

	public const int StartCaptureRtmpFieldNumber = 69;

	public const int StartCaptureResiFieldNumber = 70;

	public const int StopCaptureFieldNumber = 71;

	public const int AnalyticResetFieldNumber = 72;

	public const int PrintFieldNumber = 73;

	public const int DeviceFieldNumber = 74;

	public const int DowngradeFieldNumber = 75;

	public const int CcliReportFieldNumber = 76;

	public const int TransitionWindowFieldNumber = 77;

	public const int EditorObjectAddedFieldNumber = 78;

	public const int DataIdDuplicatedFieldNumber = 79;

	public const int ForceQuitFieldNumber = 80;

	public const int MediaCleanupSizeFieldNumber = 81;

	public const int NetworkAppFieldNumber = 82;

	public const int LocalWorkspaceStatsFieldNumber = 83;

	public const int SyncingUnpausedFieldNumber = 84;

	public const int TriggerActionCaptureStartFieldNumber = 100;

	public const int TriggerActionCaptureStopFieldNumber = 101;

	public const int TriggerActionClearFieldNumber = 102;

	public const int TriggerActionClearGroupFieldNumber = 103;

	public const int TriggerActionCommunicationsFieldNumber = 104;

	public const int TriggerActionLookFieldNumber = 105;

	public const int TriggerActionMacroFieldNumber = 106;

	public const int TriggerActionMessageFieldNumber = 107;

	public const int TriggerActionPropFieldNumber = 108;

	public const int TriggerActionSlideDestinationFieldNumber = 109;

	public const int TriggerActionStageFieldNumber = 110;

	public const int TriggerActionTimerFieldNumber = 111;

	public const int TriggerMediaAudioFieldNumber = 112;

	public const int TriggerMediaImageFieldNumber = 113;

	public const int TriggerMediaVideoInputFieldNumber = 114;

	public const int TriggerMediaVideoFieldNumber = 115;

	public const int TriggerCueSlideFieldNumber = 116;

	public const int TriggerCueSlideFileFeedElementFieldNumber = 117;

	public const int TriggerCueSlideRssFeedElementFieldNumber = 118;

	public const int TriggerCueSlideScrollingTextElementFieldNumber = 119;

	public const int TriggerTestPatternFieldNumber = 120;

	public const int TriggerMediaAircastVideoFieldNumber = 121;

	public const int TriggerMediaAircastAudioFieldNumber = 122;

	public const int AircastVideoInputConfiguredFieldNumber = 123;

	public const int AircastAudioInputConfiguredFieldNumber = 124;

	public const int MediaManagementInstallationCompleteFieldNumber = 140;

	public const int MediaManagementBootstrappingCompleteFieldNumber = 141;

	public const int MediaManagementMessageFailureFieldNumber = 142;

	public const int MediaManagementUnexpectedlyNotRunningFieldNumber = 143;

	public const int MediaManagementConnectionChangedFieldNumber = 144;

	public const int MediaManagementAddedMediaReferenceFieldNumber = 145;

	public const int MediaManagementNotRespondingFieldNumber = 146;

	public const int UiQuicksearchFieldNumber = 200;

	public const int UiQuicksearchSearchFieldNumber = 201;

	public const int UiQuicksearchOpenitemsFieldNumber = 202;

	public const int UiToolbarThemeFieldNumber = 203;

	public const int UiToolbarThemeApplicationFieldNumber = 204;

	public const int UiMainviewShowFieldNumber = 205;

	public const int UiMainviewPresentationEditorFieldNumber = 206;

	public const int UiMainviewReflowFieldNumber = 207;

	public const int UiMainviewBibleFieldNumber = 208;

	public const int BibleTriggerFieldNumber = 209;

	public const int BibleGenerateSlidesFieldNumber = 210;

	public const int BibleGenerateNextFieldNumber = 211;

	public const int BibleGeneratePreviousFieldNumber = 212;

	public const int BibleSaveSlidesFieldNumber = 213;

	public const int BibleLookupFieldNumber = 214;

	public const int BibleStartupFieldNumber = 215;

	public const int BibleRemoveFieldNumber = 216;

	public const int BibleInstallFieldNumber = 217;

	public const int UiMainviewMaskEditorFieldNumber = 218;

	public const int UiMainviewStageEditorFieldNumber = 219;

	public const int UiMainviewThemeEditorFieldNumber = 220;

	public const int UiMainviewCopyrightEditorFieldNumber = 221;

	public const int UiMainviewPropsEditorFieldNumber = 222;

	public const int UiLowerrightTimersFieldNumber = 223;

	public const int UiLowerrightTimersCollapseFieldNumber = 224;

	public const int UiLowerrightTimersEditFieldNumber = 225;

	public const int UiLowerrightTimersStateFieldNumber = 226;

	public const int UiLowerrightTimersCreateFieldNumber = 227;

	public const int UiLowerrightTimersDeleteFieldNumber = 228;

	public const int UiLowerrightMessagesFieldNumber = 229;

	public const int UiLowerrightMessagesEditFieldNumber = 230;

	public const int UiLowerrightMessagesStateFieldNumber = 231;

	public const int UiLowerrightMessagesCreateFieldNumber = 232;

	public const int UiLowerrightMessagesDeleteFieldNumber = 233;

	public const int UiLowerrightPropsFieldNumber = 234;

	public const int UiLowerrightPropsTransitionFieldNumber = 235;

	public const int UiLowerrightPropsCreateFieldNumber = 236;

	public const int UiLowerrightPropsDeleteFieldNumber = 237;

	public const int UiLowerrightPropsStateFieldNumber = 238;

	public const int UiLowerrightStageFieldNumber = 239;

	public const int UiLowerrightStageChangelayoutFieldNumber = 240;

	public const int UiLowerrightStageMessagestateFieldNumber = 241;

	public const int UiLowerrightStageConfigurescreensFieldNumber = 242;

	public const int UiLowerrightStageEditlayoutsFieldNumber = 243;

	public const int UiLowerrightMacrosFieldNumber = 244;

	public const int UiLowerrightMacrosTriggerFieldNumber = 245;

	public const int UiLowerrightMacrosCreateFieldNumber = 246;

	public const int UiLowerrightMacrosDeleteFieldNumber = 247;

	public const int UiTextinspectorFieldNumber = 248;

	public const int UiTextinspectorScrollingTextFieldNumber = 249;

	public const int UiTextinspectorForegroundFieldNumber = 250;

	public const int UiTextinspectorUnderlineColorFieldNumber = 251;

	public const int UiTextinspectorBackgroundColorFieldNumber = 252;

	public const int UiTextinspectorLineTransformFieldNumber = 253;

	public const int UiShowSlideLabelFieldNumber = 254;

	public const int UiShowSlideLabelChangeFieldNumber = 255;

	public const int UiEditorOverlayShownFieldNumber = 258;

	public const int UiEditorOverlayClosedFieldNumber = 259;

	public const int UiWhatsNewViewedFieldNumber = 260;

	public const int UiClearGroupsFieldNumber = 261;

	public const int UiClearGroupsCreateFieldNumber = 262;

	public const int UiClearGroupsDeleteFieldNumber = 263;

	public const int UiClearGroupsChangeVisibilityFieldNumber = 264;

	public const int UiClearGroupsChangeIconFieldNumber = 265;

	public const int UiPreviewAreaClearGroupsTriggerFieldNumber = 266;

	public const int UiPreviewAreaClearGroupsChangedFieldNumber = 267;

	public const int UiPlaceholderLinkFieldNumber = 268;

	public const int UiPlaceholderUnlinkFieldNumber = 269;

	public const int UiPlanningCenterLiveFieldNumber = 270;

	public const int UiNetworkgroupAddFieldNumber = 271;

	public const int UiNetworkgroupRemoveFieldNumber = 272;

	public const int UiNetworkgroupLeaveFieldNumber = 283;

	public const int UiCcliReportResetFieldNumber = 273;

	public const int UiCcliReportShownFieldNumber = 274;

	public const int UiCaptureShownFieldNumber = 275;

	public const int UiWelcomeFieldNumber = 276;

	public const int UiWelcomeScreenConfigurationHelpFieldNumber = 277;

	public const int UiWelcomeDownloadSampleContentFieldNumber = 278;

	public const int UiWelcomeUserGroupFieldNumber = 279;

	public const int UiWelcomeTutorialsFieldNumber = 280;

	public const int UiWelcomeKnowlegdeBaseFieldNumber = 284;

	public const int UiWelcomeBlogFieldNumber = 285;

	public const int UiWelcomeFacebookFieldNumber = 286;

	public const int UiWelcomeInstagramFieldNumber = 287;

	public const int UiWelcomeMigrationFieldNumber = 288;

	public const int UiTestPatternsFieldNumber = 281;

	public const int UiSettingsCustomLogoFieldNumber = 282;

	public const int UiWindowedOutputCreatedFieldNumber = 289;

	public const int ImportPowerpointFieldNumber = 290;

	public const int LibraryUsageFieldNumber = 291;

	public const int FontReplacementFieldNumber = 292;

	public const int LogDocumentUploadedFieldNumber = 293;

	public const int LogDocumentDownloadedFieldNumber = 294;

	public const int LogDiffPushedFieldNumber = 295;

	public const int LogDiffReceivedFieldNumber = 296;

	public const int TriggerExternalPresentationFieldNumber = 297;

	public const int WorkspaceCreationFieldNumber = 298;

	public const int AvailableWorkspaceFieldNumber = 299;

	public const int OnboardingFlowOutcomeFieldNumber = 300;

	public const int LogWorkspacesPublishedFieldNumber = 301;

	public const int LogCollaboratorsPublishedFieldNumber = 302;

	public const int LogConvertToCloudFieldNumber = 303;

	public const int LogConvertToLocalFieldNumber = 304;

	public const int LogSyncingChangeFieldNumber = 305;

	public const int LogDocumentStoredFieldNumber = 306;

	public const int LogDocumentCreatedFieldNumber = 307;

	public const int LogDocumentUpdatedFieldNumber = 308;

	public const int LogDocumentDeletedFieldNumber = 309;

	public const int LogDocumentConflictFieldNumber = 310;

	public const int LogWorkspaceResynchronizedFieldNumber = 311;

	public const int LogWsConnectionFailedFieldNumber = 312;

	public const int LogErrorFieldNumber = 313;

	public const int UserWorkspaceTreeModificationFieldNumber = 314;

	public const int UiActivationFlowOpenedFieldNumber = 315;

	public const int LogOpenedWorkspaceFieldNumber = 316;

	private object interaction_;

	private InteractionOneofCase interactionCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Event> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsEventReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageReceived ApiMessageReceived
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ApiMessageReceived)
			{
				return null;
			}
			return (MessageReceived)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ApiMessageReceived : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Create.Library CreateLibrary
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CreateLibrary)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Create.Library)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CreateLibrary : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Create.Playlist CreatePlaylist
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CreatePlaylist)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Create.Playlist)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CreatePlaylist : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation CreatePresentation
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CreatePresentation)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CreatePresentation : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplatePlaylist CreateFromTemplatePlaylist
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CreateFromTemplatePlaylist)
			{
				return null;
			}
			return (TemplatePlaylist)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CreateFromTemplatePlaylist : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Edit.Presentation EditPresentation
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.EditPresentation)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Edit.Presentation)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.EditPresentation : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect ImportSongselect
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ImportSongselect)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ImportSongselect : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import ImportMultitracks
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ImportMultitracks)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ImportMultitracks : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaBinView ProcontentMediabinView
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ProcontentMediabinView)
			{
				return null;
			}
			return (MediaBinView)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ProcontentMediabinView : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Download ProcontentDownload
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ProcontentDownload)
			{
				return null;
			}
			return (Download)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ProcontentDownload : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadRetry ProcontentDownloadRetry
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ProcontentDownloadRetry)
			{
				return null;
			}
			return (DownloadRetry)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ProcontentDownloadRetry : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CreateMarker PlaybackMarker
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.PlaybackMarker)
			{
				return null;
			}
			return (CreateMarker)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.PlaybackMarker : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Looks StartupLooks
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupLooks)
			{
				return null;
			}
			return (Looks)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupLooks : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Summary StartupScreenConfiguration
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfiguration)
			{
				return null;
			}
			return (Summary)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfiguration : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Output StartupScreenConfigurationScreen
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfigurationScreen)
			{
				return null;
			}
			return (Output)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfigurationScreen : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.Single StartupScreenConfigurationSingleScreen
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfigurationSingleScreen)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.Single)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfigurationSingleScreen : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Mirrored StartupScreenConfigurationMirroredScreen
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfigurationMirroredScreen)
			{
				return null;
			}
			return (Mirrored)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfigurationMirroredScreen : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.EdgeBlend StartupScreenConfigurationEdgeBlendScreen
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.EdgeBlend)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Grouped StartupScreenConfigurationGroupedScreen
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupScreenConfigurationGroupedScreen)
			{
				return null;
			}
			return (Grouped)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupScreenConfigurationGroupedScreen : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.Preferences StartupPreferences
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupPreferences)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.Preferences)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupPreferences : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect StartupSongselect
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupSongselect)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupSongselect : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Content StartupContent
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupContent)
			{
				return null;
			}
			return (Content)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupContent : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Themes StartupThemes
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupThemes)
			{
				return null;
			}
			return (Themes)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupThemes : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Macro StartupMacro
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupMacro)
			{
				return null;
			}
			return (Macro)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupMacro : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroup StartupClearGroup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupClearGroup)
			{
				return null;
			}
			return (ClearGroup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupClearGroup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.KeyMapping StartupKeyMapping
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupKeyMapping)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.KeyMapping)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupKeyMapping : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Startup StartupMultitracks
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupMultitracks)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Startup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupMultitracks : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLink StartupNetworkLink
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupNetworkLink)
			{
				return null;
			}
			return (NetworkLink)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupNetworkLink : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture StartupCapture
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupCapture)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupCapture : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Versioning StartupVersioning
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupVersioning)
			{
				return null;
			}
			return (Versioning)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupVersioning : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiskUsage StartupDiskUsage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupDiskUsage)
			{
				return null;
			}
			return (DiskUsage)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupDiskUsage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Interface StartupInterface
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartupInterface)
			{
				return null;
			}
			return (Interface)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartupInterface : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Local SyncLocal
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.SyncLocal)
			{
				return null;
			}
			return (Local)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.SyncLocal : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Activate TimecodeActivate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TimecodeActivate)
			{
				return null;
			}
			return (Activate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TimecodeActivate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Timecode.Startup TimecodeStartup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TimecodeStartup)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Timecode.Startup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TimecodeStartup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action TimelineAction
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TimelineAction)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TimelineAction : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RecordCue TimelineRecordCue
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TimelineRecordCue)
			{
				return null;
			}
			return (RecordCue)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TimelineRecordCue : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CueTrigger TimelineCueTrigger
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TimelineCueTrigger)
			{
				return null;
			}
			return (CueTrigger)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TimelineCueTrigger : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationLaunch ApplicationLaunch
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ApplicationLaunch)
			{
				return null;
			}
			return (ApplicationLaunch)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ApplicationLaunch : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputTriggered VideoInputTriggered
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.VideoInputTriggered)
			{
				return null;
			}
			return (VideoInputTriggered)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.VideoInputTriggered : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputCustomMap VideoInputCustomMap
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.VideoInputCustomMap)
			{
				return null;
			}
			return (VideoInputCustomMap)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.VideoInputCustomMap : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputStartUp VideoInputStartUp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.VideoInputStartUp)
			{
				return null;
			}
			return (VideoInputStartUp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.VideoInputStartUp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputThumbnailUpdate VideoInputThumbnailUpdate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.VideoInputThumbnailUpdate)
			{
				return null;
			}
			return (VideoInputThumbnailUpdate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.VideoInputThumbnailUpdate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputAutoOnChange AudioInputAutoOnChange
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioInputAutoOnChange)
			{
				return null;
			}
			return (AudioInputAutoOnChange)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioInputAutoOnChange : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioSettingsSdiNdiActive AudioSettingsSdiNdiActive
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioSettingsSdiNdiActive)
			{
				return null;
			}
			return (AudioSettingsSdiNdiActive)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioSettingsSdiNdiActive : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioSettingsCustomMap AudioSettingsCustomMap
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioSettingsCustomMap)
			{
				return null;
			}
			return (AudioSettingsCustomMap)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioSettingsCustomMap : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputModeSelection AudioInputModeSelection
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioInputModeSelection)
			{
				return null;
			}
			return (AudioInputModeSelection)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioInputModeSelection : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputAutoOnStartup AudioInputAutoOnStartup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioInputAutoOnStartup)
			{
				return null;
			}
			return (AudioInputAutoOnStartup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioInputAutoOnStartup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioSettingsSdiNdiState AudioSettingsSdiNdiState
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioSettingsSdiNdiState)
			{
				return null;
			}
			return (AudioSettingsSdiNdiState)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioSettingsSdiNdiState : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputStartUp AudioInputStartUp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AudioInputStartUp)
			{
				return null;
			}
			return (AudioInputStartUp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AudioInputStartUp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CueTriggered CueTriggered
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CueTriggered)
			{
				return null;
			}
			return (CueTriggered)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CueTriggered : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InputAudioMonitoring InputAudioMonitoring
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.InputAudioMonitoring)
			{
				return null;
			}
			return (InputAudioMonitoring)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.InputAudioMonitoring : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResiStartUp ResiStartUp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ResiStartUp)
			{
				return null;
			}
			return (ResiStartUp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ResiStartUp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResiLoginChange ResiLoginChange
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ResiLoginChange)
			{
				return null;
			}
			return (ResiLoginChange)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ResiLoginChange : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoteStreamStart RemoteStreamStart
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.RemoteStreamStart)
			{
				return null;
			}
			return (RemoteStreamStart)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.RemoteStreamStart : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoteStreamStop RemoteStreamStop
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.RemoteStreamStop)
			{
				return null;
			}
			return (RemoteStreamStop)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.RemoteStreamStop : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureDisk StartCaptureDisk
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartCaptureDisk)
			{
				return null;
			}
			return (StartCaptureDisk)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartCaptureDisk : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureRtmp StartCaptureRtmp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartCaptureRtmp)
			{
				return null;
			}
			return (StartCaptureRtmp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartCaptureRtmp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StartCaptureResi StartCaptureResi
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StartCaptureResi)
			{
				return null;
			}
			return (StartCaptureResi)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StartCaptureResi : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StopCapture StopCapture
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.StopCapture)
			{
				return null;
			}
			return (StopCapture)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.StopCapture : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.GenericEvent AnalyticReset
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AnalyticReset)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.GenericEvent)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AnalyticReset : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Print Print
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.Print)
			{
				return null;
			}
			return (Print)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.Print : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Device Device
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.Device)
			{
				return null;
			}
			return (Device)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.Device : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Downgrade Downgrade
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.Downgrade)
			{
				return null;
			}
			return (Downgrade)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.Downgrade : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CCLIReport CcliReport
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.CcliReport)
			{
				return null;
			}
			return (CCLIReport)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.CcliReport : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TransitionWindow TransitionWindow
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TransitionWindow)
			{
				return null;
			}
			return (TransitionWindow)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TransitionWindow : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorObjectAdded EditorObjectAdded
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.EditorObjectAdded)
			{
				return null;
			}
			return (EditorObjectAdded)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.EditorObjectAdded : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DataIdDuplicated DataIdDuplicated
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.DataIdDuplicated)
			{
				return null;
			}
			return (DataIdDuplicated)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.DataIdDuplicated : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ForceQuit ForceQuit
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ForceQuit)
			{
				return null;
			}
			return (ForceQuit)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ForceQuit : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaCleanupSize MediaCleanupSize
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaCleanupSize)
			{
				return null;
			}
			return (MediaCleanupSize)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaCleanupSize : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkApp NetworkApp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.NetworkApp)
			{
				return null;
			}
			return (NetworkApp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.NetworkApp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LocalWorkspaceStats LocalWorkspaceStats
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LocalWorkspaceStats)
			{
				return null;
			}
			return (LocalWorkspaceStats)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LocalWorkspaceStats : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SyncingUnpaused SyncingUnpaused
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.SyncingUnpaused)
			{
				return null;
			}
			return (SyncingUnpaused)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.SyncingUnpaused : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCaptureStart TriggerActionCaptureStart
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionCaptureStart)
			{
				return null;
			}
			return (ActionCaptureStart)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionCaptureStart : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCaptureStop TriggerActionCaptureStop
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionCaptureStop)
			{
				return null;
			}
			return (ActionCaptureStop)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionCaptureStop : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionClear TriggerActionClear
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionClear)
			{
				return null;
			}
			return (ActionClear)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionClear : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionClearGroup TriggerActionClearGroup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionClearGroup)
			{
				return null;
			}
			return (ActionClearGroup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionClearGroup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCommunications TriggerActionCommunications
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionCommunications)
			{
				return null;
			}
			return (ActionCommunications)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionCommunications : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionLook TriggerActionLook
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionLook)
			{
				return null;
			}
			return (ActionLook)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionLook : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMacro TriggerActionMacro
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionMacro)
			{
				return null;
			}
			return (ActionMacro)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionMacro : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMessage TriggerActionMessage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionMessage)
			{
				return null;
			}
			return (ActionMessage)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionMessage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionProp TriggerActionProp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionProp)
			{
				return null;
			}
			return (ActionProp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionProp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionSlideDestination TriggerActionSlideDestination
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionSlideDestination)
			{
				return null;
			}
			return (ActionSlideDestination)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionSlideDestination : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionStage TriggerActionStage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionStage)
			{
				return null;
			}
			return (ActionStage)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionStage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionTimer TriggerActionTimer
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerActionTimer)
			{
				return null;
			}
			return (ActionTimer)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerActionTimer : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.Audio TriggerMediaAudio
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaAudio)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.Audio)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaAudio : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Image TriggerMediaImage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaImage)
			{
				return null;
			}
			return (Image)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaImage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.VideoInput TriggerMediaVideoInput
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaVideoInput)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.VideoInput)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaVideoInput : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Video TriggerMediaVideo
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaVideo)
			{
				return null;
			}
			return (Video)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaVideo : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue.Slide TriggerCueSlide
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerCueSlide)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue.Slide)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerCueSlide : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideFileFeedElement TriggerCueSlideFileFeedElement
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerCueSlideFileFeedElement)
			{
				return null;
			}
			return (SlideFileFeedElement)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerCueSlideFileFeedElement : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideRssFeedElement TriggerCueSlideRssFeedElement
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerCueSlideRssFeedElement)
			{
				return null;
			}
			return (SlideRssFeedElement)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerCueSlideRssFeedElement : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideScrollingTextElement TriggerCueSlideScrollingTextElement
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerCueSlideScrollingTextElement)
			{
				return null;
			}
			return (SlideScrollingTextElement)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerCueSlideScrollingTextElement : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.Trigger.TestPattern TriggerTestPattern
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerTestPattern)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.Trigger.TestPattern)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerTestPattern : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirCastVideo TriggerMediaAircastVideo
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaAircastVideo)
			{
				return null;
			}
			return (AirCastVideo)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaAircastVideo : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirCastAudio TriggerMediaAircastAudio
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerMediaAircastAudio)
			{
				return null;
			}
			return (AirCastAudio)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerMediaAircastAudio : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirCastVideo AircastVideoInputConfigured
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AircastVideoInputConfigured)
			{
				return null;
			}
			return (AirCastVideo)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AircastVideoInputConfigured : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirCastAudio AircastAudioInputConfigured
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AircastAudioInputConfigured)
			{
				return null;
			}
			return (AirCastAudio)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AircastAudioInputConfigured : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstallationComplete MediaManagementInstallationComplete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementInstallationComplete)
			{
				return null;
			}
			return (InstallationComplete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementInstallationComplete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BootstrappingComplete MediaManagementBootstrappingComplete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementBootstrappingComplete)
			{
				return null;
			}
			return (BootstrappingComplete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementBootstrappingComplete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageFailure MediaManagementMessageFailure
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementMessageFailure)
			{
				return null;
			}
			return (MessageFailure)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementMessageFailure : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UnexpectedlyNotRunning MediaManagementUnexpectedlyNotRunning
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementUnexpectedlyNotRunning)
			{
				return null;
			}
			return (UnexpectedlyNotRunning)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementUnexpectedlyNotRunning : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ConnectionChanged MediaManagementConnectionChanged
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementConnectionChanged)
			{
				return null;
			}
			return (ConnectionChanged)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementConnectionChanged : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddedMediaReference MediaManagementAddedMediaReference
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementAddedMediaReference)
			{
				return null;
			}
			return (AddedMediaReference)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementAddedMediaReference : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotResponding MediaManagementNotResponding
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.MediaManagementNotResponding)
			{
				return null;
			}
			return (NotResponding)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.MediaManagementNotResponding : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public QuickSearchShown UiQuicksearch
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiQuicksearch)
			{
				return null;
			}
			return (QuickSearchShown)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiQuicksearch : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public QuickSearchSearch UiQuicksearchSearch
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiQuicksearchSearch)
			{
				return null;
			}
			return (QuickSearchSearch)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiQuicksearchSearch : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public QuickSearchOpenItems UiQuicksearchOpenitems
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiQuicksearchOpenitems)
			{
				return null;
			}
			return (QuickSearchOpenItems)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiQuicksearchOpenitems : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ToolbarThemeShown UiToolbarTheme
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiToolbarTheme)
			{
				return null;
			}
			return (ToolbarThemeShown)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiToolbarTheme : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ToolbarThemeApplication UiToolbarThemeApplication
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiToolbarThemeApplication)
			{
				return null;
			}
			return (ToolbarThemeApplication)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiToolbarThemeApplication : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewShow UiMainviewShow
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewShow)
			{
				return null;
			}
			return (MainViewShow)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewShow : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewPresentationEditor UiMainviewPresentationEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewPresentationEditor)
			{
				return null;
			}
			return (MainViewPresentationEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewPresentationEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewReflowEditor UiMainviewReflow
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewReflow)
			{
				return null;
			}
			return (MainViewReflowEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewReflow : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewBible UiMainviewBible
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewBible)
			{
				return null;
			}
			return (MainViewBible)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewBible : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleTrigger BibleTrigger
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleTrigger)
			{
				return null;
			}
			return (BibleTrigger)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleTrigger : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateSlides BibleGenerateSlides
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleGenerateSlides)
			{
				return null;
			}
			return (BibleGenerateSlides)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleGenerateSlides : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateNext BibleGenerateNext
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleGenerateNext)
			{
				return null;
			}
			return (BibleGenerateNext)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleGenerateNext : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleGenerateNext BibleGeneratePrevious
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleGeneratePrevious)
			{
				return null;
			}
			return (BibleGenerateNext)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleGeneratePrevious : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleSaveSlides BibleSaveSlides
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleSaveSlides)
			{
				return null;
			}
			return (BibleSaveSlides)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleSaveSlides : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleLookup BibleLookup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleLookup)
			{
				return null;
			}
			return (BibleLookup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleLookup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleStartup BibleStartup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleStartup)
			{
				return null;
			}
			return (BibleStartup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleStartup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleRemove BibleRemove
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleRemove)
			{
				return null;
			}
			return (BibleRemove)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleRemove : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleInstall BibleInstall
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.BibleInstall)
			{
				return null;
			}
			return (BibleInstall)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.BibleInstall : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewMaskEditor UiMainviewMaskEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewMaskEditor)
			{
				return null;
			}
			return (MainViewMaskEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewMaskEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewStageEditor UiMainviewStageEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewStageEditor)
			{
				return null;
			}
			return (MainViewStageEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewStageEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewThemeEditor UiMainviewThemeEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewThemeEditor)
			{
				return null;
			}
			return (MainViewThemeEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewThemeEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewCopyrightEditor UiMainviewCopyrightEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewCopyrightEditor)
			{
				return null;
			}
			return (MainViewCopyrightEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewCopyrightEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewPropsEditor UiMainviewPropsEditor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiMainviewPropsEditor)
			{
				return null;
			}
			return (MainViewPropsEditor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiMainviewPropsEditor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimers UiLowerrightTimers
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimers)
			{
				return null;
			}
			return (LowerRightTimers)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimers : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersCollapse UiLowerrightTimersCollapse
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimersCollapse)
			{
				return null;
			}
			return (LowerRightTimersCollapse)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimersCollapse : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersEdit UiLowerrightTimersEdit
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimersEdit)
			{
				return null;
			}
			return (LowerRightTimersEdit)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimersEdit : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersState UiLowerrightTimersState
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimersState)
			{
				return null;
			}
			return (LowerRightTimersState)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimersState : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersCreate UiLowerrightTimersCreate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimersCreate)
			{
				return null;
			}
			return (LowerRightTimersCreate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimersCreate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightTimersDelete UiLowerrightTimersDelete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightTimersDelete)
			{
				return null;
			}
			return (LowerRightTimersDelete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightTimersDelete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessages UiLowerrightMessages
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMessages)
			{
				return null;
			}
			return (LowerRightMessages)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMessages : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesEdit UiLowerrightMessagesEdit
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMessagesEdit)
			{
				return null;
			}
			return (LowerRightMessagesEdit)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMessagesEdit : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesState UiLowerrightMessagesState
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMessagesState)
			{
				return null;
			}
			return (LowerRightMessagesState)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMessagesState : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesCreate UiLowerrightMessagesCreate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMessagesCreate)
			{
				return null;
			}
			return (LowerRightMessagesCreate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMessagesCreate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesDelete UiLowerrightMessagesDelete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMessagesDelete)
			{
				return null;
			}
			return (LowerRightMessagesDelete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMessagesDelete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightProps UiLowerrightProps
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightProps)
			{
				return null;
			}
			return (LowerRightProps)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightProps : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightPropsTransition UiLowerrightPropsTransition
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightPropsTransition)
			{
				return null;
			}
			return (LowerRightPropsTransition)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightPropsTransition : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightPropsCreate UiLowerrightPropsCreate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightPropsCreate)
			{
				return null;
			}
			return (LowerRightPropsCreate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightPropsCreate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightPropsDelete UiLowerrightPropsDelete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightPropsDelete)
			{
				return null;
			}
			return (LowerRightPropsDelete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightPropsDelete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightPropsState UiLowerrightPropsState
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightPropsState)
			{
				return null;
			}
			return (LowerRightPropsState)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightPropsState : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightStage UiLowerrightStage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightStage)
			{
				return null;
			}
			return (LowerRightStage)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightStage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightStageChangeLayout UiLowerrightStageChangelayout
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightStageChangelayout)
			{
				return null;
			}
			return (LowerRightStageChangeLayout)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightStageChangelayout : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightStageMessageState UiLowerrightStageMessagestate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightStageMessagestate)
			{
				return null;
			}
			return (LowerRightStageMessageState)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightStageMessagestate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightStageConfigureScreens UiLowerrightStageConfigurescreens
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightStageConfigurescreens)
			{
				return null;
			}
			return (LowerRightStageConfigureScreens)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightStageConfigurescreens : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightStageEditLayouts UiLowerrightStageEditlayouts
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightStageEditlayouts)
			{
				return null;
			}
			return (LowerRightStageEditLayouts)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightStageEditlayouts : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMacros UiLowerrightMacros
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMacros)
			{
				return null;
			}
			return (LowerRightMacros)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMacros : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMacrosTrigger UiLowerrightMacrosTrigger
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMacrosTrigger)
			{
				return null;
			}
			return (LowerRightMacrosTrigger)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMacrosTrigger : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMacrosCreate UiLowerrightMacrosCreate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMacrosCreate)
			{
				return null;
			}
			return (LowerRightMacrosCreate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMacrosCreate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMacrosDelete UiLowerrightMacrosDelete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiLowerrightMacrosDelete)
			{
				return null;
			}
			return (LowerRightMacrosDelete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiLowerrightMacrosDelete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspector UiTextinspector
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspector)
			{
				return null;
			}
			return (TextInspector)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspector : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorScrollingText UiTextinspectorScrollingText
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspectorScrollingText)
			{
				return null;
			}
			return (TextInspectorScrollingText)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspectorScrollingText : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorForeground UiTextinspectorForeground
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspectorForeground)
			{
				return null;
			}
			return (TextInspectorForeground)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspectorForeground : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorUnderlineColor UiTextinspectorUnderlineColor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspectorUnderlineColor)
			{
				return null;
			}
			return (TextInspectorUnderlineColor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspectorUnderlineColor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorBackgroundColor UiTextinspectorBackgroundColor
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspectorBackgroundColor)
			{
				return null;
			}
			return (TextInspectorBackgroundColor)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspectorBackgroundColor : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorLineTransform UiTextinspectorLineTransform
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTextinspectorLineTransform)
			{
				return null;
			}
			return (TextInspectorLineTransform)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTextinspectorLineTransform : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowSlideLabel UiShowSlideLabel
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiShowSlideLabel)
			{
				return null;
			}
			return (ShowSlideLabel)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiShowSlideLabel : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowSlideLabelChange UiShowSlideLabelChange
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiShowSlideLabelChange)
			{
				return null;
			}
			return (ShowSlideLabelChange)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiShowSlideLabelChange : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorOverlayShown UiEditorOverlayShown
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiEditorOverlayShown)
			{
				return null;
			}
			return (EditorOverlayShown)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiEditorOverlayShown : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorOverlayClosed UiEditorOverlayClosed
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiEditorOverlayClosed)
			{
				return null;
			}
			return (EditorOverlayClosed)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiEditorOverlayClosed : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WhatsNewViewed UiWhatsNewViewed
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWhatsNewViewed)
			{
				return null;
			}
			return (WhatsNewViewed)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWhatsNewViewed : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroups UiClearGroups
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiClearGroups)
			{
				return null;
			}
			return (ClearGroups)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiClearGroups : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsCreate UiClearGroupsCreate
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiClearGroupsCreate)
			{
				return null;
			}
			return (ClearGroupsCreate)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiClearGroupsCreate : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsDelete UiClearGroupsDelete
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiClearGroupsDelete)
			{
				return null;
			}
			return (ClearGroupsDelete)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiClearGroupsDelete : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeVisibility UiClearGroupsChangeVisibility
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiClearGroupsChangeVisibility)
			{
				return null;
			}
			return (ClearGroupsChangeVisibility)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiClearGroupsChangeVisibility : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeIcon UiClearGroupsChangeIcon
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiClearGroupsChangeIcon)
			{
				return null;
			}
			return (ClearGroupsChangeIcon)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiClearGroupsChangeIcon : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PreviewAreaClearGroupsTrigger UiPreviewAreaClearGroupsTrigger
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiPreviewAreaClearGroupsTrigger)
			{
				return null;
			}
			return (PreviewAreaClearGroupsTrigger)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiPreviewAreaClearGroupsTrigger : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PreviewAreaClearGroupsChanged UiPreviewAreaClearGroupsChanged
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiPreviewAreaClearGroupsChanged)
			{
				return null;
			}
			return (PreviewAreaClearGroupsChanged)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiPreviewAreaClearGroupsChanged : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaceholderLink UiPlaceholderLink
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiPlaceholderLink)
			{
				return null;
			}
			return (PlaceholderLink)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiPlaceholderLink : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaceholderUnlink UiPlaceholderUnlink
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiPlaceholderUnlink)
			{
				return null;
			}
			return (PlaceholderUnlink)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiPlaceholderUnlink : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlanningCenterLive UiPlanningCenterLive
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiPlanningCenterLive)
			{
				return null;
			}
			return (PlanningCenterLive)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiPlanningCenterLive : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkGroupAdd UiNetworkgroupAdd
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiNetworkgroupAdd)
			{
				return null;
			}
			return (NetworkGroupAdd)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiNetworkgroupAdd : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkGroupRemove UiNetworkgroupRemove
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiNetworkgroupRemove)
			{
				return null;
			}
			return (NetworkGroupRemove)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiNetworkgroupRemove : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkGroupLeave UiNetworkgroupLeave
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiNetworkgroupLeave)
			{
				return null;
			}
			return (NetworkGroupLeave)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiNetworkgroupLeave : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CcliReportReset UiCcliReportReset
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiCcliReportReset)
			{
				return null;
			}
			return (CcliReportReset)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiCcliReportReset : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CcliReportShown UiCcliReportShown
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiCcliReportShown)
			{
				return null;
			}
			return (CcliReportShown)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiCcliReportShown : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture UiCaptureShown
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiCaptureShown)
			{
				return null;
			}
			return (Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiCaptureShown : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Welcome UiWelcome
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcome)
			{
				return null;
			}
			return (Welcome)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcome : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeScreenConfigurationHelp UiWelcomeScreenConfigurationHelp
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeScreenConfigurationHelp)
			{
				return null;
			}
			return (WelcomeScreenConfigurationHelp)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeScreenConfigurationHelp : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeDownloadSampleContent UiWelcomeDownloadSampleContent
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeDownloadSampleContent)
			{
				return null;
			}
			return (WelcomeDownloadSampleContent)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeDownloadSampleContent : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeUserGroup UiWelcomeUserGroup
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeUserGroup)
			{
				return null;
			}
			return (WelcomeUserGroup)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeUserGroup : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeTutorials UiWelcomeTutorials
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeTutorials)
			{
				return null;
			}
			return (WelcomeTutorials)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeTutorials : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeKnowledgeBase UiWelcomeKnowlegdeBase
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeKnowlegdeBase)
			{
				return null;
			}
			return (WelcomeKnowledgeBase)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeKnowlegdeBase : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeBlog UiWelcomeBlog
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeBlog)
			{
				return null;
			}
			return (WelcomeBlog)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeBlog : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeFacebook UiWelcomeFacebook
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeFacebook)
			{
				return null;
			}
			return (WelcomeFacebook)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeFacebook : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeInstagram UiWelcomeInstagram
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeInstagram)
			{
				return null;
			}
			return (WelcomeInstagram)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeInstagram : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WelcomeMigration UiWelcomeMigration
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWelcomeMigration)
			{
				return null;
			}
			return (WelcomeMigration)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWelcomeMigration : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatterns UiTestPatterns
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiTestPatterns)
			{
				return null;
			}
			return (TestPatterns)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiTestPatterns : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SettingsCustomLogo UiSettingsCustomLogo
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiSettingsCustomLogo)
			{
				return null;
			}
			return (SettingsCustomLogo)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiSettingsCustomLogo : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WindowedOutputCreated UiWindowedOutputCreated
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiWindowedOutputCreated)
			{
				return null;
			}
			return (WindowedOutputCreated)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiWindowedOutputCreated : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ImportPowerPoint ImportPowerpoint
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.ImportPowerpoint)
			{
				return null;
			}
			return (ImportPowerPoint)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.ImportPowerpoint : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LibraryUsage LibraryUsage
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LibraryUsage)
			{
				return null;
			}
			return (LibraryUsage)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LibraryUsage : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FontReplacement FontReplacement
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.FontReplacement)
			{
				return null;
			}
			return (FontReplacement)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.FontReplacement : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentUploaded LogDocumentUploaded
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentUploaded)
			{
				return null;
			}
			return (LogDocumentUploaded)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentUploaded : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentDownloaded LogDocumentDownloaded
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentDownloaded)
			{
				return null;
			}
			return (LogDocumentDownloaded)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentDownloaded : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDiffPushed LogDiffPushed
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDiffPushed)
			{
				return null;
			}
			return (LogDiffPushed)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDiffPushed : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDiffReceived LogDiffReceived
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDiffReceived)
			{
				return null;
			}
			return (LogDiffReceived)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDiffReceived : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerExternalPresentation TriggerExternalPresentation
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.TriggerExternalPresentation)
			{
				return null;
			}
			return (TriggerExternalPresentation)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.TriggerExternalPresentation : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WorkspaceCreation WorkspaceCreation
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.WorkspaceCreation)
			{
				return null;
			}
			return (WorkspaceCreation)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.WorkspaceCreation : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AvailableWorkspace AvailableWorkspace
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.AvailableWorkspace)
			{
				return null;
			}
			return (AvailableWorkspace)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.AvailableWorkspace : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OnboardingFlowOutcome OnboardingFlowOutcome
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.OnboardingFlowOutcome)
			{
				return null;
			}
			return (OnboardingFlowOutcome)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.OnboardingFlowOutcome : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspacesPublished LogWorkspacesPublished
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogWorkspacesPublished)
			{
				return null;
			}
			return (LogWorkspacesPublished)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogWorkspacesPublished : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogCollaboratorsPublished LogCollaboratorsPublished
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogCollaboratorsPublished)
			{
				return null;
			}
			return (LogCollaboratorsPublished)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogCollaboratorsPublished : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogConvertToCloud LogConvertToCloud
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogConvertToCloud)
			{
				return null;
			}
			return (LogConvertToCloud)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogConvertToCloud : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogConvertToLocal LogConvertToLocal
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogConvertToLocal)
			{
				return null;
			}
			return (LogConvertToLocal)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogConvertToLocal : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogSyncingChange LogSyncingChange
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogSyncingChange)
			{
				return null;
			}
			return (LogSyncingChange)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogSyncingChange : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentStored LogDocumentStored
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentStored)
			{
				return null;
			}
			return (LogDocumentStored)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentStored : InteractionOneofCase.None);
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentCreated LogDocumentCreated
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentCreated)
			{
				return null;
			}
			return (LogDocumentCreated)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentCreated : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentUpdated LogDocumentUpdated
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentUpdated)
			{
				return null;
			}
			return (LogDocumentUpdated)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentUpdated : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentDeleted LogDocumentDeleted
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentDeleted)
			{
				return null;
			}
			return (LogDocumentDeleted)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentDeleted : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentConflict LogDocumentConflict
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogDocumentConflict)
			{
				return null;
			}
			return (LogDocumentConflict)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogDocumentConflict : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspaceResynchronized LogWorkspaceResynchronized
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogWorkspaceResynchronized)
			{
				return null;
			}
			return (LogWorkspaceResynchronized)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogWorkspaceResynchronized : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebSocketConnectionFailed LogWsConnectionFailed
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogWsConnectionFailed)
			{
				return null;
			}
			return (WebSocketConnectionFailed)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogWsConnectionFailed : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogError LogError
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogError)
			{
				return null;
			}
			return (LogError)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogError : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserWorkspaceTreeModification UserWorkspaceTreeModification
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UserWorkspaceTreeModification)
			{
				return null;
			}
			return (UserWorkspaceTreeModification)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UserWorkspaceTreeModification : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivationFlowOpened UiActivationFlowOpened
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.UiActivationFlowOpened)
			{
				return null;
			}
			return (ActivationFlowOpened)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.UiActivationFlowOpened : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogOpenedWorkspace LogOpenedWorkspace
	{
		get
		{
			if (interactionCase_ != InteractionOneofCase.LogOpenedWorkspace)
			{
				return null;
			}
			return (LogOpenedWorkspace)interaction_;
		}
		set
		{
			interaction_ = value;
			interactionCase_ = ((value != null) ? InteractionOneofCase.LogOpenedWorkspace : InteractionOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InteractionOneofCase InteractionCase => interactionCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Event()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Event(Event other)
		: this()
	{
		switch (other.InteractionCase)
		{
		case InteractionOneofCase.ApiMessageReceived:
			ApiMessageReceived = other.ApiMessageReceived.Clone();
			break;
		case InteractionOneofCase.CreateLibrary:
			CreateLibrary = other.CreateLibrary.Clone();
			break;
		case InteractionOneofCase.CreatePlaylist:
			CreatePlaylist = other.CreatePlaylist.Clone();
			break;
		case InteractionOneofCase.CreatePresentation:
			CreatePresentation = other.CreatePresentation.Clone();
			break;
		case InteractionOneofCase.CreateFromTemplatePlaylist:
			CreateFromTemplatePlaylist = other.CreateFromTemplatePlaylist.Clone();
			break;
		case InteractionOneofCase.EditPresentation:
			EditPresentation = other.EditPresentation.Clone();
			break;
		case InteractionOneofCase.ImportSongselect:
			ImportSongselect = other.ImportSongselect.Clone();
			break;
		case InteractionOneofCase.ImportMultitracks:
			ImportMultitracks = other.ImportMultitracks.Clone();
			break;
		case InteractionOneofCase.ProcontentMediabinView:
			ProcontentMediabinView = other.ProcontentMediabinView.Clone();
			break;
		case InteractionOneofCase.ProcontentDownload:
			ProcontentDownload = other.ProcontentDownload.Clone();
			break;
		case InteractionOneofCase.ProcontentDownloadRetry:
			ProcontentDownloadRetry = other.ProcontentDownloadRetry.Clone();
			break;
		case InteractionOneofCase.PlaybackMarker:
			PlaybackMarker = other.PlaybackMarker.Clone();
			break;
		case InteractionOneofCase.StartupLooks:
			StartupLooks = other.StartupLooks.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfiguration:
			StartupScreenConfiguration = other.StartupScreenConfiguration.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfigurationScreen:
			StartupScreenConfigurationScreen = other.StartupScreenConfigurationScreen.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfigurationSingleScreen:
			StartupScreenConfigurationSingleScreen = other.StartupScreenConfigurationSingleScreen.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfigurationMirroredScreen:
			StartupScreenConfigurationMirroredScreen = other.StartupScreenConfigurationMirroredScreen.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen:
			StartupScreenConfigurationEdgeBlendScreen = other.StartupScreenConfigurationEdgeBlendScreen.Clone();
			break;
		case InteractionOneofCase.StartupScreenConfigurationGroupedScreen:
			StartupScreenConfigurationGroupedScreen = other.StartupScreenConfigurationGroupedScreen.Clone();
			break;
		case InteractionOneofCase.StartupPreferences:
			StartupPreferences = other.StartupPreferences.Clone();
			break;
		case InteractionOneofCase.StartupSongselect:
			StartupSongselect = other.StartupSongselect.Clone();
			break;
		case InteractionOneofCase.StartupContent:
			StartupContent = other.StartupContent.Clone();
			break;
		case InteractionOneofCase.StartupThemes:
			StartupThemes = other.StartupThemes.Clone();
			break;
		case InteractionOneofCase.StartupMacro:
			StartupMacro = other.StartupMacro.Clone();
			break;
		case InteractionOneofCase.StartupClearGroup:
			StartupClearGroup = other.StartupClearGroup.Clone();
			break;
		case InteractionOneofCase.StartupKeyMapping:
			StartupKeyMapping = other.StartupKeyMapping.Clone();
			break;
		case InteractionOneofCase.StartupMultitracks:
			StartupMultitracks = other.StartupMultitracks.Clone();
			break;
		case InteractionOneofCase.StartupNetworkLink:
			StartupNetworkLink = other.StartupNetworkLink.Clone();
			break;
		case InteractionOneofCase.StartupCapture:
			StartupCapture = other.StartupCapture.Clone();
			break;
		case InteractionOneofCase.StartupVersioning:
			StartupVersioning = other.StartupVersioning.Clone();
			break;
		case InteractionOneofCase.StartupDiskUsage:
			StartupDiskUsage = other.StartupDiskUsage.Clone();
			break;
		case InteractionOneofCase.StartupInterface:
			StartupInterface = other.StartupInterface.Clone();
			break;
		case InteractionOneofCase.SyncLocal:
			SyncLocal = other.SyncLocal.Clone();
			break;
		case InteractionOneofCase.TimecodeActivate:
			TimecodeActivate = other.TimecodeActivate.Clone();
			break;
		case InteractionOneofCase.TimecodeStartup:
			TimecodeStartup = other.TimecodeStartup.Clone();
			break;
		case InteractionOneofCase.TimelineAction:
			TimelineAction = other.TimelineAction.Clone();
			break;
		case InteractionOneofCase.TimelineRecordCue:
			TimelineRecordCue = other.TimelineRecordCue.Clone();
			break;
		case InteractionOneofCase.TimelineCueTrigger:
			TimelineCueTrigger = other.TimelineCueTrigger.Clone();
			break;
		case InteractionOneofCase.ApplicationLaunch:
			ApplicationLaunch = other.ApplicationLaunch.Clone();
			break;
		case InteractionOneofCase.VideoInputTriggered:
			VideoInputTriggered = other.VideoInputTriggered.Clone();
			break;
		case InteractionOneofCase.VideoInputCustomMap:
			VideoInputCustomMap = other.VideoInputCustomMap.Clone();
			break;
		case InteractionOneofCase.VideoInputStartUp:
			VideoInputStartUp = other.VideoInputStartUp.Clone();
			break;
		case InteractionOneofCase.VideoInputThumbnailUpdate:
			VideoInputThumbnailUpdate = other.VideoInputThumbnailUpdate.Clone();
			break;
		case InteractionOneofCase.AudioInputAutoOnChange:
			AudioInputAutoOnChange = other.AudioInputAutoOnChange.Clone();
			break;
		case InteractionOneofCase.AudioSettingsSdiNdiActive:
			AudioSettingsSdiNdiActive = other.AudioSettingsSdiNdiActive.Clone();
			break;
		case InteractionOneofCase.AudioSettingsCustomMap:
			AudioSettingsCustomMap = other.AudioSettingsCustomMap.Clone();
			break;
		case InteractionOneofCase.AudioInputModeSelection:
			AudioInputModeSelection = other.AudioInputModeSelection.Clone();
			break;
		case InteractionOneofCase.AudioInputAutoOnStartup:
			AudioInputAutoOnStartup = other.AudioInputAutoOnStartup.Clone();
			break;
		case InteractionOneofCase.AudioSettingsSdiNdiState:
			AudioSettingsSdiNdiState = other.AudioSettingsSdiNdiState.Clone();
			break;
		case InteractionOneofCase.AudioInputStartUp:
			AudioInputStartUp = other.AudioInputStartUp.Clone();
			break;
		case InteractionOneofCase.CueTriggered:
			CueTriggered = other.CueTriggered.Clone();
			break;
		case InteractionOneofCase.InputAudioMonitoring:
			InputAudioMonitoring = other.InputAudioMonitoring.Clone();
			break;
		case InteractionOneofCase.ResiStartUp:
			ResiStartUp = other.ResiStartUp.Clone();
			break;
		case InteractionOneofCase.ResiLoginChange:
			ResiLoginChange = other.ResiLoginChange.Clone();
			break;
		case InteractionOneofCase.RemoteStreamStart:
			RemoteStreamStart = other.RemoteStreamStart.Clone();
			break;
		case InteractionOneofCase.RemoteStreamStop:
			RemoteStreamStop = other.RemoteStreamStop.Clone();
			break;
		case InteractionOneofCase.StartCaptureDisk:
			StartCaptureDisk = other.StartCaptureDisk.Clone();
			break;
		case InteractionOneofCase.StartCaptureRtmp:
			StartCaptureRtmp = other.StartCaptureRtmp.Clone();
			break;
		case InteractionOneofCase.StartCaptureResi:
			StartCaptureResi = other.StartCaptureResi.Clone();
			break;
		case InteractionOneofCase.StopCapture:
			StopCapture = other.StopCapture.Clone();
			break;
		case InteractionOneofCase.AnalyticReset:
			AnalyticReset = other.AnalyticReset.Clone();
			break;
		case InteractionOneofCase.Print:
			Print = other.Print.Clone();
			break;
		case InteractionOneofCase.Device:
			Device = other.Device.Clone();
			break;
		case InteractionOneofCase.Downgrade:
			Downgrade = other.Downgrade.Clone();
			break;
		case InteractionOneofCase.CcliReport:
			CcliReport = other.CcliReport.Clone();
			break;
		case InteractionOneofCase.TransitionWindow:
			TransitionWindow = other.TransitionWindow.Clone();
			break;
		case InteractionOneofCase.EditorObjectAdded:
			EditorObjectAdded = other.EditorObjectAdded.Clone();
			break;
		case InteractionOneofCase.DataIdDuplicated:
			DataIdDuplicated = other.DataIdDuplicated.Clone();
			break;
		case InteractionOneofCase.ForceQuit:
			ForceQuit = other.ForceQuit.Clone();
			break;
		case InteractionOneofCase.MediaCleanupSize:
			MediaCleanupSize = other.MediaCleanupSize.Clone();
			break;
		case InteractionOneofCase.NetworkApp:
			NetworkApp = other.NetworkApp.Clone();
			break;
		case InteractionOneofCase.LocalWorkspaceStats:
			LocalWorkspaceStats = other.LocalWorkspaceStats.Clone();
			break;
		case InteractionOneofCase.SyncingUnpaused:
			SyncingUnpaused = other.SyncingUnpaused.Clone();
			break;
		case InteractionOneofCase.TriggerActionCaptureStart:
			TriggerActionCaptureStart = other.TriggerActionCaptureStart.Clone();
			break;
		case InteractionOneofCase.TriggerActionCaptureStop:
			TriggerActionCaptureStop = other.TriggerActionCaptureStop.Clone();
			break;
		case InteractionOneofCase.TriggerActionClear:
			TriggerActionClear = other.TriggerActionClear.Clone();
			break;
		case InteractionOneofCase.TriggerActionClearGroup:
			TriggerActionClearGroup = other.TriggerActionClearGroup.Clone();
			break;
		case InteractionOneofCase.TriggerActionCommunications:
			TriggerActionCommunications = other.TriggerActionCommunications.Clone();
			break;
		case InteractionOneofCase.TriggerActionLook:
			TriggerActionLook = other.TriggerActionLook.Clone();
			break;
		case InteractionOneofCase.TriggerActionMacro:
			TriggerActionMacro = other.TriggerActionMacro.Clone();
			break;
		case InteractionOneofCase.TriggerActionMessage:
			TriggerActionMessage = other.TriggerActionMessage.Clone();
			break;
		case InteractionOneofCase.TriggerActionProp:
			TriggerActionProp = other.TriggerActionProp.Clone();
			break;
		case InteractionOneofCase.TriggerActionSlideDestination:
			TriggerActionSlideDestination = other.TriggerActionSlideDestination.Clone();
			break;
		case InteractionOneofCase.TriggerActionStage:
			TriggerActionStage = other.TriggerActionStage.Clone();
			break;
		case InteractionOneofCase.TriggerActionTimer:
			TriggerActionTimer = other.TriggerActionTimer.Clone();
			break;
		case InteractionOneofCase.TriggerMediaAudio:
			TriggerMediaAudio = other.TriggerMediaAudio.Clone();
			break;
		case InteractionOneofCase.TriggerMediaImage:
			TriggerMediaImage = other.TriggerMediaImage.Clone();
			break;
		case InteractionOneofCase.TriggerMediaVideoInput:
			TriggerMediaVideoInput = other.TriggerMediaVideoInput.Clone();
			break;
		case InteractionOneofCase.TriggerMediaVideo:
			TriggerMediaVideo = other.TriggerMediaVideo.Clone();
			break;
		case InteractionOneofCase.TriggerCueSlide:
			TriggerCueSlide = other.TriggerCueSlide.Clone();
			break;
		case InteractionOneofCase.TriggerCueSlideFileFeedElement:
			TriggerCueSlideFileFeedElement = other.TriggerCueSlideFileFeedElement.Clone();
			break;
		case InteractionOneofCase.TriggerCueSlideRssFeedElement:
			TriggerCueSlideRssFeedElement = other.TriggerCueSlideRssFeedElement.Clone();
			break;
		case InteractionOneofCase.TriggerCueSlideScrollingTextElement:
			TriggerCueSlideScrollingTextElement = other.TriggerCueSlideScrollingTextElement.Clone();
			break;
		case InteractionOneofCase.TriggerTestPattern:
			TriggerTestPattern = other.TriggerTestPattern.Clone();
			break;
		case InteractionOneofCase.TriggerMediaAircastVideo:
			TriggerMediaAircastVideo = other.TriggerMediaAircastVideo.Clone();
			break;
		case InteractionOneofCase.TriggerMediaAircastAudio:
			TriggerMediaAircastAudio = other.TriggerMediaAircastAudio.Clone();
			break;
		case InteractionOneofCase.AircastVideoInputConfigured:
			AircastVideoInputConfigured = other.AircastVideoInputConfigured.Clone();
			break;
		case InteractionOneofCase.AircastAudioInputConfigured:
			AircastAudioInputConfigured = other.AircastAudioInputConfigured.Clone();
			break;
		case InteractionOneofCase.MediaManagementInstallationComplete:
			MediaManagementInstallationComplete = other.MediaManagementInstallationComplete.Clone();
			break;
		case InteractionOneofCase.MediaManagementBootstrappingComplete:
			MediaManagementBootstrappingComplete = other.MediaManagementBootstrappingComplete.Clone();
			break;
		case InteractionOneofCase.MediaManagementMessageFailure:
			MediaManagementMessageFailure = other.MediaManagementMessageFailure.Clone();
			break;
		case InteractionOneofCase.MediaManagementUnexpectedlyNotRunning:
			MediaManagementUnexpectedlyNotRunning = other.MediaManagementUnexpectedlyNotRunning.Clone();
			break;
		case InteractionOneofCase.MediaManagementConnectionChanged:
			MediaManagementConnectionChanged = other.MediaManagementConnectionChanged.Clone();
			break;
		case InteractionOneofCase.MediaManagementAddedMediaReference:
			MediaManagementAddedMediaReference = other.MediaManagementAddedMediaReference.Clone();
			break;
		case InteractionOneofCase.MediaManagementNotResponding:
			MediaManagementNotResponding = other.MediaManagementNotResponding.Clone();
			break;
		case InteractionOneofCase.UiQuicksearch:
			UiQuicksearch = other.UiQuicksearch.Clone();
			break;
		case InteractionOneofCase.UiQuicksearchSearch:
			UiQuicksearchSearch = other.UiQuicksearchSearch.Clone();
			break;
		case InteractionOneofCase.UiQuicksearchOpenitems:
			UiQuicksearchOpenitems = other.UiQuicksearchOpenitems.Clone();
			break;
		case InteractionOneofCase.UiToolbarTheme:
			UiToolbarTheme = other.UiToolbarTheme.Clone();
			break;
		case InteractionOneofCase.UiToolbarThemeApplication:
			UiToolbarThemeApplication = other.UiToolbarThemeApplication.Clone();
			break;
		case InteractionOneofCase.UiMainviewShow:
			UiMainviewShow = other.UiMainviewShow.Clone();
			break;
		case InteractionOneofCase.UiMainviewPresentationEditor:
			UiMainviewPresentationEditor = other.UiMainviewPresentationEditor.Clone();
			break;
		case InteractionOneofCase.UiMainviewReflow:
			UiMainviewReflow = other.UiMainviewReflow.Clone();
			break;
		case InteractionOneofCase.UiMainviewBible:
			UiMainviewBible = other.UiMainviewBible.Clone();
			break;
		case InteractionOneofCase.BibleTrigger:
			BibleTrigger = other.BibleTrigger.Clone();
			break;
		case InteractionOneofCase.BibleGenerateSlides:
			BibleGenerateSlides = other.BibleGenerateSlides.Clone();
			break;
		case InteractionOneofCase.BibleGenerateNext:
			BibleGenerateNext = other.BibleGenerateNext.Clone();
			break;
		case InteractionOneofCase.BibleGeneratePrevious:
			BibleGeneratePrevious = other.BibleGeneratePrevious.Clone();
			break;
		case InteractionOneofCase.BibleSaveSlides:
			BibleSaveSlides = other.BibleSaveSlides.Clone();
			break;
		case InteractionOneofCase.BibleLookup:
			BibleLookup = other.BibleLookup.Clone();
			break;
		case InteractionOneofCase.BibleStartup:
			BibleStartup = other.BibleStartup.Clone();
			break;
		case InteractionOneofCase.BibleRemove:
			BibleRemove = other.BibleRemove.Clone();
			break;
		case InteractionOneofCase.BibleInstall:
			BibleInstall = other.BibleInstall.Clone();
			break;
		case InteractionOneofCase.UiMainviewMaskEditor:
			UiMainviewMaskEditor = other.UiMainviewMaskEditor.Clone();
			break;
		case InteractionOneofCase.UiMainviewStageEditor:
			UiMainviewStageEditor = other.UiMainviewStageEditor.Clone();
			break;
		case InteractionOneofCase.UiMainviewThemeEditor:
			UiMainviewThemeEditor = other.UiMainviewThemeEditor.Clone();
			break;
		case InteractionOneofCase.UiMainviewCopyrightEditor:
			UiMainviewCopyrightEditor = other.UiMainviewCopyrightEditor.Clone();
			break;
		case InteractionOneofCase.UiMainviewPropsEditor:
			UiMainviewPropsEditor = other.UiMainviewPropsEditor.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimers:
			UiLowerrightTimers = other.UiLowerrightTimers.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimersCollapse:
			UiLowerrightTimersCollapse = other.UiLowerrightTimersCollapse.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimersEdit:
			UiLowerrightTimersEdit = other.UiLowerrightTimersEdit.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimersState:
			UiLowerrightTimersState = other.UiLowerrightTimersState.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimersCreate:
			UiLowerrightTimersCreate = other.UiLowerrightTimersCreate.Clone();
			break;
		case InteractionOneofCase.UiLowerrightTimersDelete:
			UiLowerrightTimersDelete = other.UiLowerrightTimersDelete.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMessages:
			UiLowerrightMessages = other.UiLowerrightMessages.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMessagesEdit:
			UiLowerrightMessagesEdit = other.UiLowerrightMessagesEdit.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMessagesState:
			UiLowerrightMessagesState = other.UiLowerrightMessagesState.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMessagesCreate:
			UiLowerrightMessagesCreate = other.UiLowerrightMessagesCreate.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMessagesDelete:
			UiLowerrightMessagesDelete = other.UiLowerrightMessagesDelete.Clone();
			break;
		case InteractionOneofCase.UiLowerrightProps:
			UiLowerrightProps = other.UiLowerrightProps.Clone();
			break;
		case InteractionOneofCase.UiLowerrightPropsTransition:
			UiLowerrightPropsTransition = other.UiLowerrightPropsTransition.Clone();
			break;
		case InteractionOneofCase.UiLowerrightPropsCreate:
			UiLowerrightPropsCreate = other.UiLowerrightPropsCreate.Clone();
			break;
		case InteractionOneofCase.UiLowerrightPropsDelete:
			UiLowerrightPropsDelete = other.UiLowerrightPropsDelete.Clone();
			break;
		case InteractionOneofCase.UiLowerrightPropsState:
			UiLowerrightPropsState = other.UiLowerrightPropsState.Clone();
			break;
		case InteractionOneofCase.UiLowerrightStage:
			UiLowerrightStage = other.UiLowerrightStage.Clone();
			break;
		case InteractionOneofCase.UiLowerrightStageChangelayout:
			UiLowerrightStageChangelayout = other.UiLowerrightStageChangelayout.Clone();
			break;
		case InteractionOneofCase.UiLowerrightStageMessagestate:
			UiLowerrightStageMessagestate = other.UiLowerrightStageMessagestate.Clone();
			break;
		case InteractionOneofCase.UiLowerrightStageConfigurescreens:
			UiLowerrightStageConfigurescreens = other.UiLowerrightStageConfigurescreens.Clone();
			break;
		case InteractionOneofCase.UiLowerrightStageEditlayouts:
			UiLowerrightStageEditlayouts = other.UiLowerrightStageEditlayouts.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMacros:
			UiLowerrightMacros = other.UiLowerrightMacros.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMacrosTrigger:
			UiLowerrightMacrosTrigger = other.UiLowerrightMacrosTrigger.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMacrosCreate:
			UiLowerrightMacrosCreate = other.UiLowerrightMacrosCreate.Clone();
			break;
		case InteractionOneofCase.UiLowerrightMacrosDelete:
			UiLowerrightMacrosDelete = other.UiLowerrightMacrosDelete.Clone();
			break;
		case InteractionOneofCase.UiTextinspector:
			UiTextinspector = other.UiTextinspector.Clone();
			break;
		case InteractionOneofCase.UiTextinspectorScrollingText:
			UiTextinspectorScrollingText = other.UiTextinspectorScrollingText.Clone();
			break;
		case InteractionOneofCase.UiTextinspectorForeground:
			UiTextinspectorForeground = other.UiTextinspectorForeground.Clone();
			break;
		case InteractionOneofCase.UiTextinspectorUnderlineColor:
			UiTextinspectorUnderlineColor = other.UiTextinspectorUnderlineColor.Clone();
			break;
		case InteractionOneofCase.UiTextinspectorBackgroundColor:
			UiTextinspectorBackgroundColor = other.UiTextinspectorBackgroundColor.Clone();
			break;
		case InteractionOneofCase.UiTextinspectorLineTransform:
			UiTextinspectorLineTransform = other.UiTextinspectorLineTransform.Clone();
			break;
		case InteractionOneofCase.UiShowSlideLabel:
			UiShowSlideLabel = other.UiShowSlideLabel.Clone();
			break;
		case InteractionOneofCase.UiShowSlideLabelChange:
			UiShowSlideLabelChange = other.UiShowSlideLabelChange.Clone();
			break;
		case InteractionOneofCase.UiEditorOverlayShown:
			UiEditorOverlayShown = other.UiEditorOverlayShown.Clone();
			break;
		case InteractionOneofCase.UiEditorOverlayClosed:
			UiEditorOverlayClosed = other.UiEditorOverlayClosed.Clone();
			break;
		case InteractionOneofCase.UiWhatsNewViewed:
			UiWhatsNewViewed = other.UiWhatsNewViewed.Clone();
			break;
		case InteractionOneofCase.UiClearGroups:
			UiClearGroups = other.UiClearGroups.Clone();
			break;
		case InteractionOneofCase.UiClearGroupsCreate:
			UiClearGroupsCreate = other.UiClearGroupsCreate.Clone();
			break;
		case InteractionOneofCase.UiClearGroupsDelete:
			UiClearGroupsDelete = other.UiClearGroupsDelete.Clone();
			break;
		case InteractionOneofCase.UiClearGroupsChangeVisibility:
			UiClearGroupsChangeVisibility = other.UiClearGroupsChangeVisibility.Clone();
			break;
		case InteractionOneofCase.UiClearGroupsChangeIcon:
			UiClearGroupsChangeIcon = other.UiClearGroupsChangeIcon.Clone();
			break;
		case InteractionOneofCase.UiPreviewAreaClearGroupsTrigger:
			UiPreviewAreaClearGroupsTrigger = other.UiPreviewAreaClearGroupsTrigger.Clone();
			break;
		case InteractionOneofCase.UiPreviewAreaClearGroupsChanged:
			UiPreviewAreaClearGroupsChanged = other.UiPreviewAreaClearGroupsChanged.Clone();
			break;
		case InteractionOneofCase.UiPlaceholderLink:
			UiPlaceholderLink = other.UiPlaceholderLink.Clone();
			break;
		case InteractionOneofCase.UiPlaceholderUnlink:
			UiPlaceholderUnlink = other.UiPlaceholderUnlink.Clone();
			break;
		case InteractionOneofCase.UiPlanningCenterLive:
			UiPlanningCenterLive = other.UiPlanningCenterLive.Clone();
			break;
		case InteractionOneofCase.UiNetworkgroupAdd:
			UiNetworkgroupAdd = other.UiNetworkgroupAdd.Clone();
			break;
		case InteractionOneofCase.UiNetworkgroupRemove:
			UiNetworkgroupRemove = other.UiNetworkgroupRemove.Clone();
			break;
		case InteractionOneofCase.UiNetworkgroupLeave:
			UiNetworkgroupLeave = other.UiNetworkgroupLeave.Clone();
			break;
		case InteractionOneofCase.UiCcliReportReset:
			UiCcliReportReset = other.UiCcliReportReset.Clone();
			break;
		case InteractionOneofCase.UiCcliReportShown:
			UiCcliReportShown = other.UiCcliReportShown.Clone();
			break;
		case InteractionOneofCase.UiCaptureShown:
			UiCaptureShown = other.UiCaptureShown.Clone();
			break;
		case InteractionOneofCase.UiWelcome:
			UiWelcome = other.UiWelcome.Clone();
			break;
		case InteractionOneofCase.UiWelcomeScreenConfigurationHelp:
			UiWelcomeScreenConfigurationHelp = other.UiWelcomeScreenConfigurationHelp.Clone();
			break;
		case InteractionOneofCase.UiWelcomeDownloadSampleContent:
			UiWelcomeDownloadSampleContent = other.UiWelcomeDownloadSampleContent.Clone();
			break;
		case InteractionOneofCase.UiWelcomeUserGroup:
			UiWelcomeUserGroup = other.UiWelcomeUserGroup.Clone();
			break;
		case InteractionOneofCase.UiWelcomeTutorials:
			UiWelcomeTutorials = other.UiWelcomeTutorials.Clone();
			break;
		case InteractionOneofCase.UiWelcomeKnowlegdeBase:
			UiWelcomeKnowlegdeBase = other.UiWelcomeKnowlegdeBase.Clone();
			break;
		case InteractionOneofCase.UiWelcomeBlog:
			UiWelcomeBlog = other.UiWelcomeBlog.Clone();
			break;
		case InteractionOneofCase.UiWelcomeFacebook:
			UiWelcomeFacebook = other.UiWelcomeFacebook.Clone();
			break;
		case InteractionOneofCase.UiWelcomeInstagram:
			UiWelcomeInstagram = other.UiWelcomeInstagram.Clone();
			break;
		case InteractionOneofCase.UiWelcomeMigration:
			UiWelcomeMigration = other.UiWelcomeMigration.Clone();
			break;
		case InteractionOneofCase.UiTestPatterns:
			UiTestPatterns = other.UiTestPatterns.Clone();
			break;
		case InteractionOneofCase.UiSettingsCustomLogo:
			UiSettingsCustomLogo = other.UiSettingsCustomLogo.Clone();
			break;
		case InteractionOneofCase.UiWindowedOutputCreated:
			UiWindowedOutputCreated = other.UiWindowedOutputCreated.Clone();
			break;
		case InteractionOneofCase.ImportPowerpoint:
			ImportPowerpoint = other.ImportPowerpoint.Clone();
			break;
		case InteractionOneofCase.LibraryUsage:
			LibraryUsage = other.LibraryUsage.Clone();
			break;
		case InteractionOneofCase.FontReplacement:
			FontReplacement = other.FontReplacement.Clone();
			break;
		case InteractionOneofCase.LogDocumentUploaded:
			LogDocumentUploaded = other.LogDocumentUploaded.Clone();
			break;
		case InteractionOneofCase.LogDocumentDownloaded:
			LogDocumentDownloaded = other.LogDocumentDownloaded.Clone();
			break;
		case InteractionOneofCase.LogDiffPushed:
			LogDiffPushed = other.LogDiffPushed.Clone();
			break;
		case InteractionOneofCase.LogDiffReceived:
			LogDiffReceived = other.LogDiffReceived.Clone();
			break;
		case InteractionOneofCase.TriggerExternalPresentation:
			TriggerExternalPresentation = other.TriggerExternalPresentation.Clone();
			break;
		case InteractionOneofCase.WorkspaceCreation:
			WorkspaceCreation = other.WorkspaceCreation.Clone();
			break;
		case InteractionOneofCase.AvailableWorkspace:
			AvailableWorkspace = other.AvailableWorkspace.Clone();
			break;
		case InteractionOneofCase.OnboardingFlowOutcome:
			OnboardingFlowOutcome = other.OnboardingFlowOutcome.Clone();
			break;
		case InteractionOneofCase.LogWorkspacesPublished:
			LogWorkspacesPublished = other.LogWorkspacesPublished.Clone();
			break;
		case InteractionOneofCase.LogCollaboratorsPublished:
			LogCollaboratorsPublished = other.LogCollaboratorsPublished.Clone();
			break;
		case InteractionOneofCase.LogConvertToCloud:
			LogConvertToCloud = other.LogConvertToCloud.Clone();
			break;
		case InteractionOneofCase.LogConvertToLocal:
			LogConvertToLocal = other.LogConvertToLocal.Clone();
			break;
		case InteractionOneofCase.LogSyncingChange:
			LogSyncingChange = other.LogSyncingChange.Clone();
			break;
		case InteractionOneofCase.LogDocumentStored:
			LogDocumentStored = other.LogDocumentStored.Clone();
			break;
		case InteractionOneofCase.LogDocumentCreated:
			LogDocumentCreated = other.LogDocumentCreated.Clone();
			break;
		case InteractionOneofCase.LogDocumentUpdated:
			LogDocumentUpdated = other.LogDocumentUpdated.Clone();
			break;
		case InteractionOneofCase.LogDocumentDeleted:
			LogDocumentDeleted = other.LogDocumentDeleted.Clone();
			break;
		case InteractionOneofCase.LogDocumentConflict:
			LogDocumentConflict = other.LogDocumentConflict.Clone();
			break;
		case InteractionOneofCase.LogWorkspaceResynchronized:
			LogWorkspaceResynchronized = other.LogWorkspaceResynchronized.Clone();
			break;
		case InteractionOneofCase.LogWsConnectionFailed:
			LogWsConnectionFailed = other.LogWsConnectionFailed.Clone();
			break;
		case InteractionOneofCase.LogError:
			LogError = other.LogError.Clone();
			break;
		case InteractionOneofCase.UserWorkspaceTreeModification:
			UserWorkspaceTreeModification = other.UserWorkspaceTreeModification.Clone();
			break;
		case InteractionOneofCase.UiActivationFlowOpened:
			UiActivationFlowOpened = other.UiActivationFlowOpened.Clone();
			break;
		case InteractionOneofCase.LogOpenedWorkspace:
			LogOpenedWorkspace = other.LogOpenedWorkspace.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Event Clone()
	{
		return new Event(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearInteraction()
	{
		interactionCase_ = InteractionOneofCase.None;
		interaction_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Event);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Event other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApiMessageReceived, other.ApiMessageReceived))
		{
			return false;
		}
		if (!object.Equals(CreateLibrary, other.CreateLibrary))
		{
			return false;
		}
		if (!object.Equals(CreatePlaylist, other.CreatePlaylist))
		{
			return false;
		}
		if (!object.Equals(CreatePresentation, other.CreatePresentation))
		{
			return false;
		}
		if (!object.Equals(CreateFromTemplatePlaylist, other.CreateFromTemplatePlaylist))
		{
			return false;
		}
		if (!object.Equals(EditPresentation, other.EditPresentation))
		{
			return false;
		}
		if (!object.Equals(ImportSongselect, other.ImportSongselect))
		{
			return false;
		}
		if (!object.Equals(ImportMultitracks, other.ImportMultitracks))
		{
			return false;
		}
		if (!object.Equals(ProcontentMediabinView, other.ProcontentMediabinView))
		{
			return false;
		}
		if (!object.Equals(ProcontentDownload, other.ProcontentDownload))
		{
			return false;
		}
		if (!object.Equals(ProcontentDownloadRetry, other.ProcontentDownloadRetry))
		{
			return false;
		}
		if (!object.Equals(PlaybackMarker, other.PlaybackMarker))
		{
			return false;
		}
		if (!object.Equals(StartupLooks, other.StartupLooks))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfiguration, other.StartupScreenConfiguration))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfigurationScreen, other.StartupScreenConfigurationScreen))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfigurationSingleScreen, other.StartupScreenConfigurationSingleScreen))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfigurationMirroredScreen, other.StartupScreenConfigurationMirroredScreen))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfigurationEdgeBlendScreen, other.StartupScreenConfigurationEdgeBlendScreen))
		{
			return false;
		}
		if (!object.Equals(StartupScreenConfigurationGroupedScreen, other.StartupScreenConfigurationGroupedScreen))
		{
			return false;
		}
		if (!object.Equals(StartupPreferences, other.StartupPreferences))
		{
			return false;
		}
		if (!object.Equals(StartupSongselect, other.StartupSongselect))
		{
			return false;
		}
		if (!object.Equals(StartupContent, other.StartupContent))
		{
			return false;
		}
		if (!object.Equals(StartupThemes, other.StartupThemes))
		{
			return false;
		}
		if (!object.Equals(StartupMacro, other.StartupMacro))
		{
			return false;
		}
		if (!object.Equals(StartupClearGroup, other.StartupClearGroup))
		{
			return false;
		}
		if (!object.Equals(StartupKeyMapping, other.StartupKeyMapping))
		{
			return false;
		}
		if (!object.Equals(StartupMultitracks, other.StartupMultitracks))
		{
			return false;
		}
		if (!object.Equals(StartupNetworkLink, other.StartupNetworkLink))
		{
			return false;
		}
		if (!object.Equals(StartupCapture, other.StartupCapture))
		{
			return false;
		}
		if (!object.Equals(StartupVersioning, other.StartupVersioning))
		{
			return false;
		}
		if (!object.Equals(StartupDiskUsage, other.StartupDiskUsage))
		{
			return false;
		}
		if (!object.Equals(StartupInterface, other.StartupInterface))
		{
			return false;
		}
		if (!object.Equals(SyncLocal, other.SyncLocal))
		{
			return false;
		}
		if (!object.Equals(TimecodeActivate, other.TimecodeActivate))
		{
			return false;
		}
		if (!object.Equals(TimecodeStartup, other.TimecodeStartup))
		{
			return false;
		}
		if (!object.Equals(TimelineAction, other.TimelineAction))
		{
			return false;
		}
		if (!object.Equals(TimelineRecordCue, other.TimelineRecordCue))
		{
			return false;
		}
		if (!object.Equals(TimelineCueTrigger, other.TimelineCueTrigger))
		{
			return false;
		}
		if (!object.Equals(ApplicationLaunch, other.ApplicationLaunch))
		{
			return false;
		}
		if (!object.Equals(VideoInputTriggered, other.VideoInputTriggered))
		{
			return false;
		}
		if (!object.Equals(VideoInputCustomMap, other.VideoInputCustomMap))
		{
			return false;
		}
		if (!object.Equals(VideoInputStartUp, other.VideoInputStartUp))
		{
			return false;
		}
		if (!object.Equals(VideoInputThumbnailUpdate, other.VideoInputThumbnailUpdate))
		{
			return false;
		}
		if (!object.Equals(AudioInputAutoOnChange, other.AudioInputAutoOnChange))
		{
			return false;
		}
		if (!object.Equals(AudioSettingsSdiNdiActive, other.AudioSettingsSdiNdiActive))
		{
			return false;
		}
		if (!object.Equals(AudioSettingsCustomMap, other.AudioSettingsCustomMap))
		{
			return false;
		}
		if (!object.Equals(AudioInputModeSelection, other.AudioInputModeSelection))
		{
			return false;
		}
		if (!object.Equals(AudioInputAutoOnStartup, other.AudioInputAutoOnStartup))
		{
			return false;
		}
		if (!object.Equals(AudioSettingsSdiNdiState, other.AudioSettingsSdiNdiState))
		{
			return false;
		}
		if (!object.Equals(AudioInputStartUp, other.AudioInputStartUp))
		{
			return false;
		}
		if (!object.Equals(CueTriggered, other.CueTriggered))
		{
			return false;
		}
		if (!object.Equals(InputAudioMonitoring, other.InputAudioMonitoring))
		{
			return false;
		}
		if (!object.Equals(ResiStartUp, other.ResiStartUp))
		{
			return false;
		}
		if (!object.Equals(ResiLoginChange, other.ResiLoginChange))
		{
			return false;
		}
		if (!object.Equals(RemoteStreamStart, other.RemoteStreamStart))
		{
			return false;
		}
		if (!object.Equals(RemoteStreamStop, other.RemoteStreamStop))
		{
			return false;
		}
		if (!object.Equals(StartCaptureDisk, other.StartCaptureDisk))
		{
			return false;
		}
		if (!object.Equals(StartCaptureRtmp, other.StartCaptureRtmp))
		{
			return false;
		}
		if (!object.Equals(StartCaptureResi, other.StartCaptureResi))
		{
			return false;
		}
		if (!object.Equals(StopCapture, other.StopCapture))
		{
			return false;
		}
		if (!object.Equals(AnalyticReset, other.AnalyticReset))
		{
			return false;
		}
		if (!object.Equals(Print, other.Print))
		{
			return false;
		}
		if (!object.Equals(Device, other.Device))
		{
			return false;
		}
		if (!object.Equals(Downgrade, other.Downgrade))
		{
			return false;
		}
		if (!object.Equals(CcliReport, other.CcliReport))
		{
			return false;
		}
		if (!object.Equals(TransitionWindow, other.TransitionWindow))
		{
			return false;
		}
		if (!object.Equals(EditorObjectAdded, other.EditorObjectAdded))
		{
			return false;
		}
		if (!object.Equals(DataIdDuplicated, other.DataIdDuplicated))
		{
			return false;
		}
		if (!object.Equals(ForceQuit, other.ForceQuit))
		{
			return false;
		}
		if (!object.Equals(MediaCleanupSize, other.MediaCleanupSize))
		{
			return false;
		}
		if (!object.Equals(NetworkApp, other.NetworkApp))
		{
			return false;
		}
		if (!object.Equals(LocalWorkspaceStats, other.LocalWorkspaceStats))
		{
			return false;
		}
		if (!object.Equals(SyncingUnpaused, other.SyncingUnpaused))
		{
			return false;
		}
		if (!object.Equals(TriggerActionCaptureStart, other.TriggerActionCaptureStart))
		{
			return false;
		}
		if (!object.Equals(TriggerActionCaptureStop, other.TriggerActionCaptureStop))
		{
			return false;
		}
		if (!object.Equals(TriggerActionClear, other.TriggerActionClear))
		{
			return false;
		}
		if (!object.Equals(TriggerActionClearGroup, other.TriggerActionClearGroup))
		{
			return false;
		}
		if (!object.Equals(TriggerActionCommunications, other.TriggerActionCommunications))
		{
			return false;
		}
		if (!object.Equals(TriggerActionLook, other.TriggerActionLook))
		{
			return false;
		}
		if (!object.Equals(TriggerActionMacro, other.TriggerActionMacro))
		{
			return false;
		}
		if (!object.Equals(TriggerActionMessage, other.TriggerActionMessage))
		{
			return false;
		}
		if (!object.Equals(TriggerActionProp, other.TriggerActionProp))
		{
			return false;
		}
		if (!object.Equals(TriggerActionSlideDestination, other.TriggerActionSlideDestination))
		{
			return false;
		}
		if (!object.Equals(TriggerActionStage, other.TriggerActionStage))
		{
			return false;
		}
		if (!object.Equals(TriggerActionTimer, other.TriggerActionTimer))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaAudio, other.TriggerMediaAudio))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaImage, other.TriggerMediaImage))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaVideoInput, other.TriggerMediaVideoInput))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaVideo, other.TriggerMediaVideo))
		{
			return false;
		}
		if (!object.Equals(TriggerCueSlide, other.TriggerCueSlide))
		{
			return false;
		}
		if (!object.Equals(TriggerCueSlideFileFeedElement, other.TriggerCueSlideFileFeedElement))
		{
			return false;
		}
		if (!object.Equals(TriggerCueSlideRssFeedElement, other.TriggerCueSlideRssFeedElement))
		{
			return false;
		}
		if (!object.Equals(TriggerCueSlideScrollingTextElement, other.TriggerCueSlideScrollingTextElement))
		{
			return false;
		}
		if (!object.Equals(TriggerTestPattern, other.TriggerTestPattern))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaAircastVideo, other.TriggerMediaAircastVideo))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaAircastAudio, other.TriggerMediaAircastAudio))
		{
			return false;
		}
		if (!object.Equals(AircastVideoInputConfigured, other.AircastVideoInputConfigured))
		{
			return false;
		}
		if (!object.Equals(AircastAudioInputConfigured, other.AircastAudioInputConfigured))
		{
			return false;
		}
		if (!object.Equals(MediaManagementInstallationComplete, other.MediaManagementInstallationComplete))
		{
			return false;
		}
		if (!object.Equals(MediaManagementBootstrappingComplete, other.MediaManagementBootstrappingComplete))
		{
			return false;
		}
		if (!object.Equals(MediaManagementMessageFailure, other.MediaManagementMessageFailure))
		{
			return false;
		}
		if (!object.Equals(MediaManagementUnexpectedlyNotRunning, other.MediaManagementUnexpectedlyNotRunning))
		{
			return false;
		}
		if (!object.Equals(MediaManagementConnectionChanged, other.MediaManagementConnectionChanged))
		{
			return false;
		}
		if (!object.Equals(MediaManagementAddedMediaReference, other.MediaManagementAddedMediaReference))
		{
			return false;
		}
		if (!object.Equals(MediaManagementNotResponding, other.MediaManagementNotResponding))
		{
			return false;
		}
		if (!object.Equals(UiQuicksearch, other.UiQuicksearch))
		{
			return false;
		}
		if (!object.Equals(UiQuicksearchSearch, other.UiQuicksearchSearch))
		{
			return false;
		}
		if (!object.Equals(UiQuicksearchOpenitems, other.UiQuicksearchOpenitems))
		{
			return false;
		}
		if (!object.Equals(UiToolbarTheme, other.UiToolbarTheme))
		{
			return false;
		}
		if (!object.Equals(UiToolbarThemeApplication, other.UiToolbarThemeApplication))
		{
			return false;
		}
		if (!object.Equals(UiMainviewShow, other.UiMainviewShow))
		{
			return false;
		}
		if (!object.Equals(UiMainviewPresentationEditor, other.UiMainviewPresentationEditor))
		{
			return false;
		}
		if (!object.Equals(UiMainviewReflow, other.UiMainviewReflow))
		{
			return false;
		}
		if (!object.Equals(UiMainviewBible, other.UiMainviewBible))
		{
			return false;
		}
		if (!object.Equals(BibleTrigger, other.BibleTrigger))
		{
			return false;
		}
		if (!object.Equals(BibleGenerateSlides, other.BibleGenerateSlides))
		{
			return false;
		}
		if (!object.Equals(BibleGenerateNext, other.BibleGenerateNext))
		{
			return false;
		}
		if (!object.Equals(BibleGeneratePrevious, other.BibleGeneratePrevious))
		{
			return false;
		}
		if (!object.Equals(BibleSaveSlides, other.BibleSaveSlides))
		{
			return false;
		}
		if (!object.Equals(BibleLookup, other.BibleLookup))
		{
			return false;
		}
		if (!object.Equals(BibleStartup, other.BibleStartup))
		{
			return false;
		}
		if (!object.Equals(BibleRemove, other.BibleRemove))
		{
			return false;
		}
		if (!object.Equals(BibleInstall, other.BibleInstall))
		{
			return false;
		}
		if (!object.Equals(UiMainviewMaskEditor, other.UiMainviewMaskEditor))
		{
			return false;
		}
		if (!object.Equals(UiMainviewStageEditor, other.UiMainviewStageEditor))
		{
			return false;
		}
		if (!object.Equals(UiMainviewThemeEditor, other.UiMainviewThemeEditor))
		{
			return false;
		}
		if (!object.Equals(UiMainviewCopyrightEditor, other.UiMainviewCopyrightEditor))
		{
			return false;
		}
		if (!object.Equals(UiMainviewPropsEditor, other.UiMainviewPropsEditor))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimers, other.UiLowerrightTimers))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimersCollapse, other.UiLowerrightTimersCollapse))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimersEdit, other.UiLowerrightTimersEdit))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimersState, other.UiLowerrightTimersState))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimersCreate, other.UiLowerrightTimersCreate))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightTimersDelete, other.UiLowerrightTimersDelete))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMessages, other.UiLowerrightMessages))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMessagesEdit, other.UiLowerrightMessagesEdit))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMessagesState, other.UiLowerrightMessagesState))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMessagesCreate, other.UiLowerrightMessagesCreate))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMessagesDelete, other.UiLowerrightMessagesDelete))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightProps, other.UiLowerrightProps))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightPropsTransition, other.UiLowerrightPropsTransition))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightPropsCreate, other.UiLowerrightPropsCreate))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightPropsDelete, other.UiLowerrightPropsDelete))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightPropsState, other.UiLowerrightPropsState))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightStage, other.UiLowerrightStage))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightStageChangelayout, other.UiLowerrightStageChangelayout))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightStageMessagestate, other.UiLowerrightStageMessagestate))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightStageConfigurescreens, other.UiLowerrightStageConfigurescreens))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightStageEditlayouts, other.UiLowerrightStageEditlayouts))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMacros, other.UiLowerrightMacros))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMacrosTrigger, other.UiLowerrightMacrosTrigger))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMacrosCreate, other.UiLowerrightMacrosCreate))
		{
			return false;
		}
		if (!object.Equals(UiLowerrightMacrosDelete, other.UiLowerrightMacrosDelete))
		{
			return false;
		}
		if (!object.Equals(UiTextinspector, other.UiTextinspector))
		{
			return false;
		}
		if (!object.Equals(UiTextinspectorScrollingText, other.UiTextinspectorScrollingText))
		{
			return false;
		}
		if (!object.Equals(UiTextinspectorForeground, other.UiTextinspectorForeground))
		{
			return false;
		}
		if (!object.Equals(UiTextinspectorUnderlineColor, other.UiTextinspectorUnderlineColor))
		{
			return false;
		}
		if (!object.Equals(UiTextinspectorBackgroundColor, other.UiTextinspectorBackgroundColor))
		{
			return false;
		}
		if (!object.Equals(UiTextinspectorLineTransform, other.UiTextinspectorLineTransform))
		{
			return false;
		}
		if (!object.Equals(UiShowSlideLabel, other.UiShowSlideLabel))
		{
			return false;
		}
		if (!object.Equals(UiShowSlideLabelChange, other.UiShowSlideLabelChange))
		{
			return false;
		}
		if (!object.Equals(UiEditorOverlayShown, other.UiEditorOverlayShown))
		{
			return false;
		}
		if (!object.Equals(UiEditorOverlayClosed, other.UiEditorOverlayClosed))
		{
			return false;
		}
		if (!object.Equals(UiWhatsNewViewed, other.UiWhatsNewViewed))
		{
			return false;
		}
		if (!object.Equals(UiClearGroups, other.UiClearGroups))
		{
			return false;
		}
		if (!object.Equals(UiClearGroupsCreate, other.UiClearGroupsCreate))
		{
			return false;
		}
		if (!object.Equals(UiClearGroupsDelete, other.UiClearGroupsDelete))
		{
			return false;
		}
		if (!object.Equals(UiClearGroupsChangeVisibility, other.UiClearGroupsChangeVisibility))
		{
			return false;
		}
		if (!object.Equals(UiClearGroupsChangeIcon, other.UiClearGroupsChangeIcon))
		{
			return false;
		}
		if (!object.Equals(UiPreviewAreaClearGroupsTrigger, other.UiPreviewAreaClearGroupsTrigger))
		{
			return false;
		}
		if (!object.Equals(UiPreviewAreaClearGroupsChanged, other.UiPreviewAreaClearGroupsChanged))
		{
			return false;
		}
		if (!object.Equals(UiPlaceholderLink, other.UiPlaceholderLink))
		{
			return false;
		}
		if (!object.Equals(UiPlaceholderUnlink, other.UiPlaceholderUnlink))
		{
			return false;
		}
		if (!object.Equals(UiPlanningCenterLive, other.UiPlanningCenterLive))
		{
			return false;
		}
		if (!object.Equals(UiNetworkgroupAdd, other.UiNetworkgroupAdd))
		{
			return false;
		}
		if (!object.Equals(UiNetworkgroupRemove, other.UiNetworkgroupRemove))
		{
			return false;
		}
		if (!object.Equals(UiNetworkgroupLeave, other.UiNetworkgroupLeave))
		{
			return false;
		}
		if (!object.Equals(UiCcliReportReset, other.UiCcliReportReset))
		{
			return false;
		}
		if (!object.Equals(UiCcliReportShown, other.UiCcliReportShown))
		{
			return false;
		}
		if (!object.Equals(UiCaptureShown, other.UiCaptureShown))
		{
			return false;
		}
		if (!object.Equals(UiWelcome, other.UiWelcome))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeScreenConfigurationHelp, other.UiWelcomeScreenConfigurationHelp))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeDownloadSampleContent, other.UiWelcomeDownloadSampleContent))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeUserGroup, other.UiWelcomeUserGroup))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeTutorials, other.UiWelcomeTutorials))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeKnowlegdeBase, other.UiWelcomeKnowlegdeBase))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeBlog, other.UiWelcomeBlog))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeFacebook, other.UiWelcomeFacebook))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeInstagram, other.UiWelcomeInstagram))
		{
			return false;
		}
		if (!object.Equals(UiWelcomeMigration, other.UiWelcomeMigration))
		{
			return false;
		}
		if (!object.Equals(UiTestPatterns, other.UiTestPatterns))
		{
			return false;
		}
		if (!object.Equals(UiSettingsCustomLogo, other.UiSettingsCustomLogo))
		{
			return false;
		}
		if (!object.Equals(UiWindowedOutputCreated, other.UiWindowedOutputCreated))
		{
			return false;
		}
		if (!object.Equals(ImportPowerpoint, other.ImportPowerpoint))
		{
			return false;
		}
		if (!object.Equals(LibraryUsage, other.LibraryUsage))
		{
			return false;
		}
		if (!object.Equals(FontReplacement, other.FontReplacement))
		{
			return false;
		}
		if (!object.Equals(LogDocumentUploaded, other.LogDocumentUploaded))
		{
			return false;
		}
		if (!object.Equals(LogDocumentDownloaded, other.LogDocumentDownloaded))
		{
			return false;
		}
		if (!object.Equals(LogDiffPushed, other.LogDiffPushed))
		{
			return false;
		}
		if (!object.Equals(LogDiffReceived, other.LogDiffReceived))
		{
			return false;
		}
		if (!object.Equals(TriggerExternalPresentation, other.TriggerExternalPresentation))
		{
			return false;
		}
		if (!object.Equals(WorkspaceCreation, other.WorkspaceCreation))
		{
			return false;
		}
		if (!object.Equals(AvailableWorkspace, other.AvailableWorkspace))
		{
			return false;
		}
		if (!object.Equals(OnboardingFlowOutcome, other.OnboardingFlowOutcome))
		{
			return false;
		}
		if (!object.Equals(LogWorkspacesPublished, other.LogWorkspacesPublished))
		{
			return false;
		}
		if (!object.Equals(LogCollaboratorsPublished, other.LogCollaboratorsPublished))
		{
			return false;
		}
		if (!object.Equals(LogConvertToCloud, other.LogConvertToCloud))
		{
			return false;
		}
		if (!object.Equals(LogConvertToLocal, other.LogConvertToLocal))
		{
			return false;
		}
		if (!object.Equals(LogSyncingChange, other.LogSyncingChange))
		{
			return false;
		}
		if (!object.Equals(LogDocumentStored, other.LogDocumentStored))
		{
			return false;
		}
		if (!object.Equals(LogDocumentCreated, other.LogDocumentCreated))
		{
			return false;
		}
		if (!object.Equals(LogDocumentUpdated, other.LogDocumentUpdated))
		{
			return false;
		}
		if (!object.Equals(LogDocumentDeleted, other.LogDocumentDeleted))
		{
			return false;
		}
		if (!object.Equals(LogDocumentConflict, other.LogDocumentConflict))
		{
			return false;
		}
		if (!object.Equals(LogWorkspaceResynchronized, other.LogWorkspaceResynchronized))
		{
			return false;
		}
		if (!object.Equals(LogWsConnectionFailed, other.LogWsConnectionFailed))
		{
			return false;
		}
		if (!object.Equals(LogError, other.LogError))
		{
			return false;
		}
		if (!object.Equals(UserWorkspaceTreeModification, other.UserWorkspaceTreeModification))
		{
			return false;
		}
		if (!object.Equals(UiActivationFlowOpened, other.UiActivationFlowOpened))
		{
			return false;
		}
		if (!object.Equals(LogOpenedWorkspace, other.LogOpenedWorkspace))
		{
			return false;
		}
		if (InteractionCase != other.InteractionCase)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (interactionCase_ == InteractionOneofCase.ApiMessageReceived)
		{
			num ^= ApiMessageReceived.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CreateLibrary)
		{
			num ^= CreateLibrary.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CreatePlaylist)
		{
			num ^= CreatePlaylist.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CreatePresentation)
		{
			num ^= CreatePresentation.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CreateFromTemplatePlaylist)
		{
			num ^= CreateFromTemplatePlaylist.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.EditPresentation)
		{
			num ^= EditPresentation.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ImportSongselect)
		{
			num ^= ImportSongselect.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ImportMultitracks)
		{
			num ^= ImportMultitracks.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentMediabinView)
		{
			num ^= ProcontentMediabinView.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownload)
		{
			num ^= ProcontentDownload.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownloadRetry)
		{
			num ^= ProcontentDownloadRetry.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.PlaybackMarker)
		{
			num ^= PlaybackMarker.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupLooks)
		{
			num ^= StartupLooks.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfiguration)
		{
			num ^= StartupScreenConfiguration.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationScreen)
		{
			num ^= StartupScreenConfigurationScreen.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationSingleScreen)
		{
			num ^= StartupScreenConfigurationSingleScreen.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationMirroredScreen)
		{
			num ^= StartupScreenConfigurationMirroredScreen.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen)
		{
			num ^= StartupScreenConfigurationEdgeBlendScreen.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationGroupedScreen)
		{
			num ^= StartupScreenConfigurationGroupedScreen.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupPreferences)
		{
			num ^= StartupPreferences.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupSongselect)
		{
			num ^= StartupSongselect.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupContent)
		{
			num ^= StartupContent.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupThemes)
		{
			num ^= StartupThemes.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupMacro)
		{
			num ^= StartupMacro.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupClearGroup)
		{
			num ^= StartupClearGroup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupKeyMapping)
		{
			num ^= StartupKeyMapping.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupMultitracks)
		{
			num ^= StartupMultitracks.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupNetworkLink)
		{
			num ^= StartupNetworkLink.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupCapture)
		{
			num ^= StartupCapture.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupVersioning)
		{
			num ^= StartupVersioning.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupDiskUsage)
		{
			num ^= StartupDiskUsage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartupInterface)
		{
			num ^= StartupInterface.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.SyncLocal)
		{
			num ^= SyncLocal.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeActivate)
		{
			num ^= TimecodeActivate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeStartup)
		{
			num ^= TimecodeStartup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TimelineAction)
		{
			num ^= TimelineAction.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TimelineRecordCue)
		{
			num ^= TimelineRecordCue.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TimelineCueTrigger)
		{
			num ^= TimelineCueTrigger.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ApplicationLaunch)
		{
			num ^= ApplicationLaunch.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputTriggered)
		{
			num ^= VideoInputTriggered.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputCustomMap)
		{
			num ^= VideoInputCustomMap.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputStartUp)
		{
			num ^= VideoInputStartUp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputThumbnailUpdate)
		{
			num ^= VideoInputThumbnailUpdate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnChange)
		{
			num ^= AudioInputAutoOnChange.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiActive)
		{
			num ^= AudioSettingsSdiNdiActive.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsCustomMap)
		{
			num ^= AudioSettingsCustomMap.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputModeSelection)
		{
			num ^= AudioInputModeSelection.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnStartup)
		{
			num ^= AudioInputAutoOnStartup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiState)
		{
			num ^= AudioSettingsSdiNdiState.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputStartUp)
		{
			num ^= AudioInputStartUp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CueTriggered)
		{
			num ^= CueTriggered.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.InputAudioMonitoring)
		{
			num ^= InputAudioMonitoring.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ResiStartUp)
		{
			num ^= ResiStartUp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ResiLoginChange)
		{
			num ^= ResiLoginChange.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStart)
		{
			num ^= RemoteStreamStart.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStop)
		{
			num ^= RemoteStreamStop.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureDisk)
		{
			num ^= StartCaptureDisk.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureRtmp)
		{
			num ^= StartCaptureRtmp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureResi)
		{
			num ^= StartCaptureResi.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.StopCapture)
		{
			num ^= StopCapture.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AnalyticReset)
		{
			num ^= AnalyticReset.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.Print)
		{
			num ^= Print.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.Device)
		{
			num ^= Device.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.Downgrade)
		{
			num ^= Downgrade.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.CcliReport)
		{
			num ^= CcliReport.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TransitionWindow)
		{
			num ^= TransitionWindow.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.EditorObjectAdded)
		{
			num ^= EditorObjectAdded.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.DataIdDuplicated)
		{
			num ^= DataIdDuplicated.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ForceQuit)
		{
			num ^= ForceQuit.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaCleanupSize)
		{
			num ^= MediaCleanupSize.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.NetworkApp)
		{
			num ^= NetworkApp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LocalWorkspaceStats)
		{
			num ^= LocalWorkspaceStats.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.SyncingUnpaused)
		{
			num ^= SyncingUnpaused.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStart)
		{
			num ^= TriggerActionCaptureStart.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStop)
		{
			num ^= TriggerActionCaptureStop.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClear)
		{
			num ^= TriggerActionClear.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClearGroup)
		{
			num ^= TriggerActionClearGroup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCommunications)
		{
			num ^= TriggerActionCommunications.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionLook)
		{
			num ^= TriggerActionLook.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMacro)
		{
			num ^= TriggerActionMacro.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMessage)
		{
			num ^= TriggerActionMessage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionProp)
		{
			num ^= TriggerActionProp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionSlideDestination)
		{
			num ^= TriggerActionSlideDestination.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionStage)
		{
			num ^= TriggerActionStage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionTimer)
		{
			num ^= TriggerActionTimer.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAudio)
		{
			num ^= TriggerMediaAudio.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaImage)
		{
			num ^= TriggerMediaImage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideoInput)
		{
			num ^= TriggerMediaVideoInput.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideo)
		{
			num ^= TriggerMediaVideo.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlide)
		{
			num ^= TriggerCueSlide.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideFileFeedElement)
		{
			num ^= TriggerCueSlideFileFeedElement.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideRssFeedElement)
		{
			num ^= TriggerCueSlideRssFeedElement.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideScrollingTextElement)
		{
			num ^= TriggerCueSlideScrollingTextElement.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerTestPattern)
		{
			num ^= TriggerTestPattern.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastVideo)
		{
			num ^= TriggerMediaAircastVideo.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastAudio)
		{
			num ^= TriggerMediaAircastAudio.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AircastVideoInputConfigured)
		{
			num ^= AircastVideoInputConfigured.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AircastAudioInputConfigured)
		{
			num ^= AircastAudioInputConfigured.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementInstallationComplete)
		{
			num ^= MediaManagementInstallationComplete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementBootstrappingComplete)
		{
			num ^= MediaManagementBootstrappingComplete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementMessageFailure)
		{
			num ^= MediaManagementMessageFailure.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementUnexpectedlyNotRunning)
		{
			num ^= MediaManagementUnexpectedlyNotRunning.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementConnectionChanged)
		{
			num ^= MediaManagementConnectionChanged.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementAddedMediaReference)
		{
			num ^= MediaManagementAddedMediaReference.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementNotResponding)
		{
			num ^= MediaManagementNotResponding.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearch)
		{
			num ^= UiQuicksearch.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchSearch)
		{
			num ^= UiQuicksearchSearch.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchOpenitems)
		{
			num ^= UiQuicksearchOpenitems.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarTheme)
		{
			num ^= UiToolbarTheme.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarThemeApplication)
		{
			num ^= UiToolbarThemeApplication.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewShow)
		{
			num ^= UiMainviewShow.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPresentationEditor)
		{
			num ^= UiMainviewPresentationEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewReflow)
		{
			num ^= UiMainviewReflow.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewBible)
		{
			num ^= UiMainviewBible.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleTrigger)
		{
			num ^= BibleTrigger.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateSlides)
		{
			num ^= BibleGenerateSlides.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateNext)
		{
			num ^= BibleGenerateNext.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleGeneratePrevious)
		{
			num ^= BibleGeneratePrevious.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleSaveSlides)
		{
			num ^= BibleSaveSlides.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleLookup)
		{
			num ^= BibleLookup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleStartup)
		{
			num ^= BibleStartup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleRemove)
		{
			num ^= BibleRemove.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.BibleInstall)
		{
			num ^= BibleInstall.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewMaskEditor)
		{
			num ^= UiMainviewMaskEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewStageEditor)
		{
			num ^= UiMainviewStageEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewThemeEditor)
		{
			num ^= UiMainviewThemeEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewCopyrightEditor)
		{
			num ^= UiMainviewCopyrightEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPropsEditor)
		{
			num ^= UiMainviewPropsEditor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimers)
		{
			num ^= UiLowerrightTimers.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCollapse)
		{
			num ^= UiLowerrightTimersCollapse.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersEdit)
		{
			num ^= UiLowerrightTimersEdit.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersState)
		{
			num ^= UiLowerrightTimersState.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCreate)
		{
			num ^= UiLowerrightTimersCreate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersDelete)
		{
			num ^= UiLowerrightTimersDelete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessages)
		{
			num ^= UiLowerrightMessages.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesEdit)
		{
			num ^= UiLowerrightMessagesEdit.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesState)
		{
			num ^= UiLowerrightMessagesState.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesCreate)
		{
			num ^= UiLowerrightMessagesCreate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesDelete)
		{
			num ^= UiLowerrightMessagesDelete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightProps)
		{
			num ^= UiLowerrightProps.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsTransition)
		{
			num ^= UiLowerrightPropsTransition.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsCreate)
		{
			num ^= UiLowerrightPropsCreate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsDelete)
		{
			num ^= UiLowerrightPropsDelete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsState)
		{
			num ^= UiLowerrightPropsState.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStage)
		{
			num ^= UiLowerrightStage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageChangelayout)
		{
			num ^= UiLowerrightStageChangelayout.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageMessagestate)
		{
			num ^= UiLowerrightStageMessagestate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageConfigurescreens)
		{
			num ^= UiLowerrightStageConfigurescreens.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageEditlayouts)
		{
			num ^= UiLowerrightStageEditlayouts.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacros)
		{
			num ^= UiLowerrightMacros.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosTrigger)
		{
			num ^= UiLowerrightMacrosTrigger.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosCreate)
		{
			num ^= UiLowerrightMacrosCreate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosDelete)
		{
			num ^= UiLowerrightMacrosDelete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspector)
		{
			num ^= UiTextinspector.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorScrollingText)
		{
			num ^= UiTextinspectorScrollingText.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorForeground)
		{
			num ^= UiTextinspectorForeground.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorUnderlineColor)
		{
			num ^= UiTextinspectorUnderlineColor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorBackgroundColor)
		{
			num ^= UiTextinspectorBackgroundColor.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorLineTransform)
		{
			num ^= UiTextinspectorLineTransform.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabel)
		{
			num ^= UiShowSlideLabel.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabelChange)
		{
			num ^= UiShowSlideLabelChange.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayShown)
		{
			num ^= UiEditorOverlayShown.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayClosed)
		{
			num ^= UiEditorOverlayClosed.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWhatsNewViewed)
		{
			num ^= UiWhatsNewViewed.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroups)
		{
			num ^= UiClearGroups.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsCreate)
		{
			num ^= UiClearGroupsCreate.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsDelete)
		{
			num ^= UiClearGroupsDelete.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeVisibility)
		{
			num ^= UiClearGroupsChangeVisibility.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeIcon)
		{
			num ^= UiClearGroupsChangeIcon.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsTrigger)
		{
			num ^= UiPreviewAreaClearGroupsTrigger.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsChanged)
		{
			num ^= UiPreviewAreaClearGroupsChanged.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderLink)
		{
			num ^= UiPlaceholderLink.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderUnlink)
		{
			num ^= UiPlaceholderUnlink.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiPlanningCenterLive)
		{
			num ^= UiPlanningCenterLive.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupAdd)
		{
			num ^= UiNetworkgroupAdd.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupRemove)
		{
			num ^= UiNetworkgroupRemove.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupLeave)
		{
			num ^= UiNetworkgroupLeave.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportReset)
		{
			num ^= UiCcliReportReset.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportShown)
		{
			num ^= UiCcliReportShown.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiCaptureShown)
		{
			num ^= UiCaptureShown.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcome)
		{
			num ^= UiWelcome.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeScreenConfigurationHelp)
		{
			num ^= UiWelcomeScreenConfigurationHelp.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeDownloadSampleContent)
		{
			num ^= UiWelcomeDownloadSampleContent.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeUserGroup)
		{
			num ^= UiWelcomeUserGroup.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeTutorials)
		{
			num ^= UiWelcomeTutorials.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeKnowlegdeBase)
		{
			num ^= UiWelcomeKnowlegdeBase.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeBlog)
		{
			num ^= UiWelcomeBlog.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeFacebook)
		{
			num ^= UiWelcomeFacebook.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeInstagram)
		{
			num ^= UiWelcomeInstagram.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeMigration)
		{
			num ^= UiWelcomeMigration.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiTestPatterns)
		{
			num ^= UiTestPatterns.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiSettingsCustomLogo)
		{
			num ^= UiSettingsCustomLogo.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiWindowedOutputCreated)
		{
			num ^= UiWindowedOutputCreated.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.ImportPowerpoint)
		{
			num ^= ImportPowerpoint.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LibraryUsage)
		{
			num ^= LibraryUsage.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.FontReplacement)
		{
			num ^= FontReplacement.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUploaded)
		{
			num ^= LogDocumentUploaded.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDownloaded)
		{
			num ^= LogDocumentDownloaded.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffPushed)
		{
			num ^= LogDiffPushed.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffReceived)
		{
			num ^= LogDiffReceived.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.TriggerExternalPresentation)
		{
			num ^= TriggerExternalPresentation.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.WorkspaceCreation)
		{
			num ^= WorkspaceCreation.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.AvailableWorkspace)
		{
			num ^= AvailableWorkspace.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.OnboardingFlowOutcome)
		{
			num ^= OnboardingFlowOutcome.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspacesPublished)
		{
			num ^= LogWorkspacesPublished.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogCollaboratorsPublished)
		{
			num ^= LogCollaboratorsPublished.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToCloud)
		{
			num ^= LogConvertToCloud.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToLocal)
		{
			num ^= LogConvertToLocal.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogSyncingChange)
		{
			num ^= LogSyncingChange.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentStored)
		{
			num ^= LogDocumentStored.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentCreated)
		{
			num ^= LogDocumentCreated.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUpdated)
		{
			num ^= LogDocumentUpdated.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDeleted)
		{
			num ^= LogDocumentDeleted.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentConflict)
		{
			num ^= LogDocumentConflict.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspaceResynchronized)
		{
			num ^= LogWorkspaceResynchronized.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogWsConnectionFailed)
		{
			num ^= LogWsConnectionFailed.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogError)
		{
			num ^= LogError.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UserWorkspaceTreeModification)
		{
			num ^= UserWorkspaceTreeModification.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.UiActivationFlowOpened)
		{
			num ^= UiActivationFlowOpened.GetHashCode();
		}
		if (interactionCase_ == InteractionOneofCase.LogOpenedWorkspace)
		{
			num ^= LogOpenedWorkspace.GetHashCode();
		}
		num ^= (int)interactionCase_;
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (interactionCase_ == InteractionOneofCase.ApiMessageReceived)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApiMessageReceived);
		}
		if (interactionCase_ == InteractionOneofCase.CreateLibrary)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateLibrary);
		}
		if (interactionCase_ == InteractionOneofCase.CreatePlaylist)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CreatePlaylist);
		}
		if (interactionCase_ == InteractionOneofCase.CreatePresentation)
		{
			output.WriteRawTag(34);
			output.WriteMessage(CreatePresentation);
		}
		if (interactionCase_ == InteractionOneofCase.CreateFromTemplatePlaylist)
		{
			output.WriteRawTag(42);
			output.WriteMessage(CreateFromTemplatePlaylist);
		}
		if (interactionCase_ == InteractionOneofCase.EditPresentation)
		{
			output.WriteRawTag(50);
			output.WriteMessage(EditPresentation);
		}
		if (interactionCase_ == InteractionOneofCase.ImportSongselect)
		{
			output.WriteRawTag(58);
			output.WriteMessage(ImportSongselect);
		}
		if (interactionCase_ == InteractionOneofCase.ImportMultitracks)
		{
			output.WriteRawTag(66);
			output.WriteMessage(ImportMultitracks);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentMediabinView)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ProcontentMediabinView);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownload)
		{
			output.WriteRawTag(82);
			output.WriteMessage(ProcontentDownload);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownloadRetry)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ProcontentDownloadRetry);
		}
		if (interactionCase_ == InteractionOneofCase.PlaybackMarker)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PlaybackMarker);
		}
		if (interactionCase_ == InteractionOneofCase.StartupLooks)
		{
			output.WriteRawTag(106);
			output.WriteMessage(StartupLooks);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfiguration)
		{
			output.WriteRawTag(114);
			output.WriteMessage(StartupScreenConfiguration);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationScreen)
		{
			output.WriteRawTag(122);
			output.WriteMessage(StartupScreenConfigurationScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationSingleScreen)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(StartupScreenConfigurationSingleScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationMirroredScreen)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(StartupScreenConfigurationMirroredScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(StartupScreenConfigurationEdgeBlendScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationGroupedScreen)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(StartupScreenConfigurationGroupedScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupPreferences)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(StartupPreferences);
		}
		if (interactionCase_ == InteractionOneofCase.StartupSongselect)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(StartupSongselect);
		}
		if (interactionCase_ == InteractionOneofCase.StartupContent)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(StartupContent);
		}
		if (interactionCase_ == InteractionOneofCase.StartupThemes)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(StartupThemes);
		}
		if (interactionCase_ == InteractionOneofCase.StartupMacro)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(StartupMacro);
		}
		if (interactionCase_ == InteractionOneofCase.StartupClearGroup)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(StartupClearGroup);
		}
		if (interactionCase_ == InteractionOneofCase.StartupKeyMapping)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(StartupKeyMapping);
		}
		if (interactionCase_ == InteractionOneofCase.StartupMultitracks)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(StartupMultitracks);
		}
		if (interactionCase_ == InteractionOneofCase.StartupNetworkLink)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(StartupNetworkLink);
		}
		if (interactionCase_ == InteractionOneofCase.StartupCapture)
		{
			output.WriteRawTag(234, 1);
			output.WriteMessage(StartupCapture);
		}
		if (interactionCase_ == InteractionOneofCase.StartupVersioning)
		{
			output.WriteRawTag(242, 1);
			output.WriteMessage(StartupVersioning);
		}
		if (interactionCase_ == InteractionOneofCase.StartupDiskUsage)
		{
			output.WriteRawTag(250, 1);
			output.WriteMessage(StartupDiskUsage);
		}
		if (interactionCase_ == InteractionOneofCase.StartupInterface)
		{
			output.WriteRawTag(130, 2);
			output.WriteMessage(StartupInterface);
		}
		if (interactionCase_ == InteractionOneofCase.SyncLocal)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(SyncLocal);
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeActivate)
		{
			output.WriteRawTag(146, 2);
			output.WriteMessage(TimecodeActivate);
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeStartup)
		{
			output.WriteRawTag(154, 2);
			output.WriteMessage(TimecodeStartup);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineAction)
		{
			output.WriteRawTag(162, 2);
			output.WriteMessage(TimelineAction);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineRecordCue)
		{
			output.WriteRawTag(170, 2);
			output.WriteMessage(TimelineRecordCue);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineCueTrigger)
		{
			output.WriteRawTag(178, 2);
			output.WriteMessage(TimelineCueTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.ApplicationLaunch)
		{
			output.WriteRawTag(146, 3);
			output.WriteMessage(ApplicationLaunch);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputTriggered)
		{
			output.WriteRawTag(154, 3);
			output.WriteMessage(VideoInputTriggered);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputCustomMap)
		{
			output.WriteRawTag(162, 3);
			output.WriteMessage(VideoInputCustomMap);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputStartUp)
		{
			output.WriteRawTag(170, 3);
			output.WriteMessage(VideoInputStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputThumbnailUpdate)
		{
			output.WriteRawTag(178, 3);
			output.WriteMessage(VideoInputThumbnailUpdate);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnChange)
		{
			output.WriteRawTag(186, 3);
			output.WriteMessage(AudioInputAutoOnChange);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiActive)
		{
			output.WriteRawTag(194, 3);
			output.WriteMessage(AudioSettingsSdiNdiActive);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsCustomMap)
		{
			output.WriteRawTag(202, 3);
			output.WriteMessage(AudioSettingsCustomMap);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputModeSelection)
		{
			output.WriteRawTag(210, 3);
			output.WriteMessage(AudioInputModeSelection);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnStartup)
		{
			output.WriteRawTag(218, 3);
			output.WriteMessage(AudioInputAutoOnStartup);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiState)
		{
			output.WriteRawTag(226, 3);
			output.WriteMessage(AudioSettingsSdiNdiState);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputStartUp)
		{
			output.WriteRawTag(234, 3);
			output.WriteMessage(AudioInputStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.CueTriggered)
		{
			output.WriteRawTag(242, 3);
			output.WriteMessage(CueTriggered);
		}
		if (interactionCase_ == InteractionOneofCase.InputAudioMonitoring)
		{
			output.WriteRawTag(250, 3);
			output.WriteMessage(InputAudioMonitoring);
		}
		if (interactionCase_ == InteractionOneofCase.ResiStartUp)
		{
			output.WriteRawTag(130, 4);
			output.WriteMessage(ResiStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.ResiLoginChange)
		{
			output.WriteRawTag(138, 4);
			output.WriteMessage(ResiLoginChange);
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStart)
		{
			output.WriteRawTag(146, 4);
			output.WriteMessage(RemoteStreamStart);
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStop)
		{
			output.WriteRawTag(154, 4);
			output.WriteMessage(RemoteStreamStop);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureDisk)
		{
			output.WriteRawTag(162, 4);
			output.WriteMessage(StartCaptureDisk);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureRtmp)
		{
			output.WriteRawTag(170, 4);
			output.WriteMessage(StartCaptureRtmp);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureResi)
		{
			output.WriteRawTag(178, 4);
			output.WriteMessage(StartCaptureResi);
		}
		if (interactionCase_ == InteractionOneofCase.StopCapture)
		{
			output.WriteRawTag(186, 4);
			output.WriteMessage(StopCapture);
		}
		if (interactionCase_ == InteractionOneofCase.AnalyticReset)
		{
			output.WriteRawTag(194, 4);
			output.WriteMessage(AnalyticReset);
		}
		if (interactionCase_ == InteractionOneofCase.Print)
		{
			output.WriteRawTag(202, 4);
			output.WriteMessage(Print);
		}
		if (interactionCase_ == InteractionOneofCase.Device)
		{
			output.WriteRawTag(210, 4);
			output.WriteMessage(Device);
		}
		if (interactionCase_ == InteractionOneofCase.Downgrade)
		{
			output.WriteRawTag(218, 4);
			output.WriteMessage(Downgrade);
		}
		if (interactionCase_ == InteractionOneofCase.CcliReport)
		{
			output.WriteRawTag(226, 4);
			output.WriteMessage(CcliReport);
		}
		if (interactionCase_ == InteractionOneofCase.TransitionWindow)
		{
			output.WriteRawTag(234, 4);
			output.WriteMessage(TransitionWindow);
		}
		if (interactionCase_ == InteractionOneofCase.EditorObjectAdded)
		{
			output.WriteRawTag(242, 4);
			output.WriteMessage(EditorObjectAdded);
		}
		if (interactionCase_ == InteractionOneofCase.DataIdDuplicated)
		{
			output.WriteRawTag(250, 4);
			output.WriteMessage(DataIdDuplicated);
		}
		if (interactionCase_ == InteractionOneofCase.ForceQuit)
		{
			output.WriteRawTag(130, 5);
			output.WriteMessage(ForceQuit);
		}
		if (interactionCase_ == InteractionOneofCase.MediaCleanupSize)
		{
			output.WriteRawTag(138, 5);
			output.WriteMessage(MediaCleanupSize);
		}
		if (interactionCase_ == InteractionOneofCase.NetworkApp)
		{
			output.WriteRawTag(146, 5);
			output.WriteMessage(NetworkApp);
		}
		if (interactionCase_ == InteractionOneofCase.LocalWorkspaceStats)
		{
			output.WriteRawTag(154, 5);
			output.WriteMessage(LocalWorkspaceStats);
		}
		if (interactionCase_ == InteractionOneofCase.SyncingUnpaused)
		{
			output.WriteRawTag(162, 5);
			output.WriteMessage(SyncingUnpaused);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStart)
		{
			output.WriteRawTag(162, 6);
			output.WriteMessage(TriggerActionCaptureStart);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStop)
		{
			output.WriteRawTag(170, 6);
			output.WriteMessage(TriggerActionCaptureStop);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClear)
		{
			output.WriteRawTag(178, 6);
			output.WriteMessage(TriggerActionClear);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClearGroup)
		{
			output.WriteRawTag(186, 6);
			output.WriteMessage(TriggerActionClearGroup);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCommunications)
		{
			output.WriteRawTag(194, 6);
			output.WriteMessage(TriggerActionCommunications);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionLook)
		{
			output.WriteRawTag(202, 6);
			output.WriteMessage(TriggerActionLook);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMacro)
		{
			output.WriteRawTag(210, 6);
			output.WriteMessage(TriggerActionMacro);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMessage)
		{
			output.WriteRawTag(218, 6);
			output.WriteMessage(TriggerActionMessage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionProp)
		{
			output.WriteRawTag(226, 6);
			output.WriteMessage(TriggerActionProp);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionSlideDestination)
		{
			output.WriteRawTag(234, 6);
			output.WriteMessage(TriggerActionSlideDestination);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionStage)
		{
			output.WriteRawTag(242, 6);
			output.WriteMessage(TriggerActionStage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionTimer)
		{
			output.WriteRawTag(250, 6);
			output.WriteMessage(TriggerActionTimer);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAudio)
		{
			output.WriteRawTag(130, 7);
			output.WriteMessage(TriggerMediaAudio);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaImage)
		{
			output.WriteRawTag(138, 7);
			output.WriteMessage(TriggerMediaImage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideoInput)
		{
			output.WriteRawTag(146, 7);
			output.WriteMessage(TriggerMediaVideoInput);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideo)
		{
			output.WriteRawTag(154, 7);
			output.WriteMessage(TriggerMediaVideo);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlide)
		{
			output.WriteRawTag(162, 7);
			output.WriteMessage(TriggerCueSlide);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideFileFeedElement)
		{
			output.WriteRawTag(170, 7);
			output.WriteMessage(TriggerCueSlideFileFeedElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideRssFeedElement)
		{
			output.WriteRawTag(178, 7);
			output.WriteMessage(TriggerCueSlideRssFeedElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideScrollingTextElement)
		{
			output.WriteRawTag(186, 7);
			output.WriteMessage(TriggerCueSlideScrollingTextElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerTestPattern)
		{
			output.WriteRawTag(194, 7);
			output.WriteMessage(TriggerTestPattern);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastVideo)
		{
			output.WriteRawTag(202, 7);
			output.WriteMessage(TriggerMediaAircastVideo);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastAudio)
		{
			output.WriteRawTag(210, 7);
			output.WriteMessage(TriggerMediaAircastAudio);
		}
		if (interactionCase_ == InteractionOneofCase.AircastVideoInputConfigured)
		{
			output.WriteRawTag(218, 7);
			output.WriteMessage(AircastVideoInputConfigured);
		}
		if (interactionCase_ == InteractionOneofCase.AircastAudioInputConfigured)
		{
			output.WriteRawTag(226, 7);
			output.WriteMessage(AircastAudioInputConfigured);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementInstallationComplete)
		{
			output.WriteRawTag(226, 8);
			output.WriteMessage(MediaManagementInstallationComplete);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementBootstrappingComplete)
		{
			output.WriteRawTag(234, 8);
			output.WriteMessage(MediaManagementBootstrappingComplete);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementMessageFailure)
		{
			output.WriteRawTag(242, 8);
			output.WriteMessage(MediaManagementMessageFailure);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementUnexpectedlyNotRunning)
		{
			output.WriteRawTag(250, 8);
			output.WriteMessage(MediaManagementUnexpectedlyNotRunning);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementConnectionChanged)
		{
			output.WriteRawTag(130, 9);
			output.WriteMessage(MediaManagementConnectionChanged);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementAddedMediaReference)
		{
			output.WriteRawTag(138, 9);
			output.WriteMessage(MediaManagementAddedMediaReference);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementNotResponding)
		{
			output.WriteRawTag(146, 9);
			output.WriteMessage(MediaManagementNotResponding);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearch)
		{
			output.WriteRawTag(194, 12);
			output.WriteMessage(UiQuicksearch);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchSearch)
		{
			output.WriteRawTag(202, 12);
			output.WriteMessage(UiQuicksearchSearch);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchOpenitems)
		{
			output.WriteRawTag(210, 12);
			output.WriteMessage(UiQuicksearchOpenitems);
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarTheme)
		{
			output.WriteRawTag(218, 12);
			output.WriteMessage(UiToolbarTheme);
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarThemeApplication)
		{
			output.WriteRawTag(226, 12);
			output.WriteMessage(UiToolbarThemeApplication);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewShow)
		{
			output.WriteRawTag(234, 12);
			output.WriteMessage(UiMainviewShow);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPresentationEditor)
		{
			output.WriteRawTag(242, 12);
			output.WriteMessage(UiMainviewPresentationEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewReflow)
		{
			output.WriteRawTag(250, 12);
			output.WriteMessage(UiMainviewReflow);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewBible)
		{
			output.WriteRawTag(130, 13);
			output.WriteMessage(UiMainviewBible);
		}
		if (interactionCase_ == InteractionOneofCase.BibleTrigger)
		{
			output.WriteRawTag(138, 13);
			output.WriteMessage(BibleTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateSlides)
		{
			output.WriteRawTag(146, 13);
			output.WriteMessage(BibleGenerateSlides);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateNext)
		{
			output.WriteRawTag(154, 13);
			output.WriteMessage(BibleGenerateNext);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGeneratePrevious)
		{
			output.WriteRawTag(162, 13);
			output.WriteMessage(BibleGeneratePrevious);
		}
		if (interactionCase_ == InteractionOneofCase.BibleSaveSlides)
		{
			output.WriteRawTag(170, 13);
			output.WriteMessage(BibleSaveSlides);
		}
		if (interactionCase_ == InteractionOneofCase.BibleLookup)
		{
			output.WriteRawTag(178, 13);
			output.WriteMessage(BibleLookup);
		}
		if (interactionCase_ == InteractionOneofCase.BibleStartup)
		{
			output.WriteRawTag(186, 13);
			output.WriteMessage(BibleStartup);
		}
		if (interactionCase_ == InteractionOneofCase.BibleRemove)
		{
			output.WriteRawTag(194, 13);
			output.WriteMessage(BibleRemove);
		}
		if (interactionCase_ == InteractionOneofCase.BibleInstall)
		{
			output.WriteRawTag(202, 13);
			output.WriteMessage(BibleInstall);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewMaskEditor)
		{
			output.WriteRawTag(210, 13);
			output.WriteMessage(UiMainviewMaskEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewStageEditor)
		{
			output.WriteRawTag(218, 13);
			output.WriteMessage(UiMainviewStageEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewThemeEditor)
		{
			output.WriteRawTag(226, 13);
			output.WriteMessage(UiMainviewThemeEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewCopyrightEditor)
		{
			output.WriteRawTag(234, 13);
			output.WriteMessage(UiMainviewCopyrightEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPropsEditor)
		{
			output.WriteRawTag(242, 13);
			output.WriteMessage(UiMainviewPropsEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimers)
		{
			output.WriteRawTag(250, 13);
			output.WriteMessage(UiLowerrightTimers);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCollapse)
		{
			output.WriteRawTag(130, 14);
			output.WriteMessage(UiLowerrightTimersCollapse);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersEdit)
		{
			output.WriteRawTag(138, 14);
			output.WriteMessage(UiLowerrightTimersEdit);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersState)
		{
			output.WriteRawTag(146, 14);
			output.WriteMessage(UiLowerrightTimersState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCreate)
		{
			output.WriteRawTag(154, 14);
			output.WriteMessage(UiLowerrightTimersCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersDelete)
		{
			output.WriteRawTag(162, 14);
			output.WriteMessage(UiLowerrightTimersDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessages)
		{
			output.WriteRawTag(170, 14);
			output.WriteMessage(UiLowerrightMessages);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesEdit)
		{
			output.WriteRawTag(178, 14);
			output.WriteMessage(UiLowerrightMessagesEdit);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesState)
		{
			output.WriteRawTag(186, 14);
			output.WriteMessage(UiLowerrightMessagesState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesCreate)
		{
			output.WriteRawTag(194, 14);
			output.WriteMessage(UiLowerrightMessagesCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesDelete)
		{
			output.WriteRawTag(202, 14);
			output.WriteMessage(UiLowerrightMessagesDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightProps)
		{
			output.WriteRawTag(210, 14);
			output.WriteMessage(UiLowerrightProps);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsTransition)
		{
			output.WriteRawTag(218, 14);
			output.WriteMessage(UiLowerrightPropsTransition);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsCreate)
		{
			output.WriteRawTag(226, 14);
			output.WriteMessage(UiLowerrightPropsCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsDelete)
		{
			output.WriteRawTag(234, 14);
			output.WriteMessage(UiLowerrightPropsDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsState)
		{
			output.WriteRawTag(242, 14);
			output.WriteMessage(UiLowerrightPropsState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStage)
		{
			output.WriteRawTag(250, 14);
			output.WriteMessage(UiLowerrightStage);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageChangelayout)
		{
			output.WriteRawTag(130, 15);
			output.WriteMessage(UiLowerrightStageChangelayout);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageMessagestate)
		{
			output.WriteRawTag(138, 15);
			output.WriteMessage(UiLowerrightStageMessagestate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageConfigurescreens)
		{
			output.WriteRawTag(146, 15);
			output.WriteMessage(UiLowerrightStageConfigurescreens);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageEditlayouts)
		{
			output.WriteRawTag(154, 15);
			output.WriteMessage(UiLowerrightStageEditlayouts);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacros)
		{
			output.WriteRawTag(162, 15);
			output.WriteMessage(UiLowerrightMacros);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosTrigger)
		{
			output.WriteRawTag(170, 15);
			output.WriteMessage(UiLowerrightMacrosTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosCreate)
		{
			output.WriteRawTag(178, 15);
			output.WriteMessage(UiLowerrightMacrosCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosDelete)
		{
			output.WriteRawTag(186, 15);
			output.WriteMessage(UiLowerrightMacrosDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspector)
		{
			output.WriteRawTag(194, 15);
			output.WriteMessage(UiTextinspector);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorScrollingText)
		{
			output.WriteRawTag(202, 15);
			output.WriteMessage(UiTextinspectorScrollingText);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorForeground)
		{
			output.WriteRawTag(210, 15);
			output.WriteMessage(UiTextinspectorForeground);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorUnderlineColor)
		{
			output.WriteRawTag(218, 15);
			output.WriteMessage(UiTextinspectorUnderlineColor);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorBackgroundColor)
		{
			output.WriteRawTag(226, 15);
			output.WriteMessage(UiTextinspectorBackgroundColor);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorLineTransform)
		{
			output.WriteRawTag(234, 15);
			output.WriteMessage(UiTextinspectorLineTransform);
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabel)
		{
			output.WriteRawTag(242, 15);
			output.WriteMessage(UiShowSlideLabel);
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabelChange)
		{
			output.WriteRawTag(250, 15);
			output.WriteMessage(UiShowSlideLabelChange);
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayShown)
		{
			output.WriteRawTag(146, 16);
			output.WriteMessage(UiEditorOverlayShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayClosed)
		{
			output.WriteRawTag(154, 16);
			output.WriteMessage(UiEditorOverlayClosed);
		}
		if (interactionCase_ == InteractionOneofCase.UiWhatsNewViewed)
		{
			output.WriteRawTag(162, 16);
			output.WriteMessage(UiWhatsNewViewed);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroups)
		{
			output.WriteRawTag(170, 16);
			output.WriteMessage(UiClearGroups);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsCreate)
		{
			output.WriteRawTag(178, 16);
			output.WriteMessage(UiClearGroupsCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsDelete)
		{
			output.WriteRawTag(186, 16);
			output.WriteMessage(UiClearGroupsDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeVisibility)
		{
			output.WriteRawTag(194, 16);
			output.WriteMessage(UiClearGroupsChangeVisibility);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeIcon)
		{
			output.WriteRawTag(202, 16);
			output.WriteMessage(UiClearGroupsChangeIcon);
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsTrigger)
		{
			output.WriteRawTag(210, 16);
			output.WriteMessage(UiPreviewAreaClearGroupsTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsChanged)
		{
			output.WriteRawTag(218, 16);
			output.WriteMessage(UiPreviewAreaClearGroupsChanged);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderLink)
		{
			output.WriteRawTag(226, 16);
			output.WriteMessage(UiPlaceholderLink);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderUnlink)
		{
			output.WriteRawTag(234, 16);
			output.WriteMessage(UiPlaceholderUnlink);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlanningCenterLive)
		{
			output.WriteRawTag(242, 16);
			output.WriteMessage(UiPlanningCenterLive);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupAdd)
		{
			output.WriteRawTag(250, 16);
			output.WriteMessage(UiNetworkgroupAdd);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupRemove)
		{
			output.WriteRawTag(130, 17);
			output.WriteMessage(UiNetworkgroupRemove);
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportReset)
		{
			output.WriteRawTag(138, 17);
			output.WriteMessage(UiCcliReportReset);
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportShown)
		{
			output.WriteRawTag(146, 17);
			output.WriteMessage(UiCcliReportShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiCaptureShown)
		{
			output.WriteRawTag(154, 17);
			output.WriteMessage(UiCaptureShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcome)
		{
			output.WriteRawTag(162, 17);
			output.WriteMessage(UiWelcome);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeScreenConfigurationHelp)
		{
			output.WriteRawTag(170, 17);
			output.WriteMessage(UiWelcomeScreenConfigurationHelp);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeDownloadSampleContent)
		{
			output.WriteRawTag(178, 17);
			output.WriteMessage(UiWelcomeDownloadSampleContent);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeUserGroup)
		{
			output.WriteRawTag(186, 17);
			output.WriteMessage(UiWelcomeUserGroup);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeTutorials)
		{
			output.WriteRawTag(194, 17);
			output.WriteMessage(UiWelcomeTutorials);
		}
		if (interactionCase_ == InteractionOneofCase.UiTestPatterns)
		{
			output.WriteRawTag(202, 17);
			output.WriteMessage(UiTestPatterns);
		}
		if (interactionCase_ == InteractionOneofCase.UiSettingsCustomLogo)
		{
			output.WriteRawTag(210, 17);
			output.WriteMessage(UiSettingsCustomLogo);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupLeave)
		{
			output.WriteRawTag(218, 17);
			output.WriteMessage(UiNetworkgroupLeave);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeKnowlegdeBase)
		{
			output.WriteRawTag(226, 17);
			output.WriteMessage(UiWelcomeKnowlegdeBase);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeBlog)
		{
			output.WriteRawTag(234, 17);
			output.WriteMessage(UiWelcomeBlog);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeFacebook)
		{
			output.WriteRawTag(242, 17);
			output.WriteMessage(UiWelcomeFacebook);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeInstagram)
		{
			output.WriteRawTag(250, 17);
			output.WriteMessage(UiWelcomeInstagram);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeMigration)
		{
			output.WriteRawTag(130, 18);
			output.WriteMessage(UiWelcomeMigration);
		}
		if (interactionCase_ == InteractionOneofCase.UiWindowedOutputCreated)
		{
			output.WriteRawTag(138, 18);
			output.WriteMessage(UiWindowedOutputCreated);
		}
		if (interactionCase_ == InteractionOneofCase.ImportPowerpoint)
		{
			output.WriteRawTag(146, 18);
			output.WriteMessage(ImportPowerpoint);
		}
		if (interactionCase_ == InteractionOneofCase.LibraryUsage)
		{
			output.WriteRawTag(154, 18);
			output.WriteMessage(LibraryUsage);
		}
		if (interactionCase_ == InteractionOneofCase.FontReplacement)
		{
			output.WriteRawTag(162, 18);
			output.WriteMessage(FontReplacement);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUploaded)
		{
			output.WriteRawTag(170, 18);
			output.WriteMessage(LogDocumentUploaded);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDownloaded)
		{
			output.WriteRawTag(178, 18);
			output.WriteMessage(LogDocumentDownloaded);
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffPushed)
		{
			output.WriteRawTag(186, 18);
			output.WriteMessage(LogDiffPushed);
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffReceived)
		{
			output.WriteRawTag(194, 18);
			output.WriteMessage(LogDiffReceived);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerExternalPresentation)
		{
			output.WriteRawTag(202, 18);
			output.WriteMessage(TriggerExternalPresentation);
		}
		if (interactionCase_ == InteractionOneofCase.WorkspaceCreation)
		{
			output.WriteRawTag(210, 18);
			output.WriteMessage(WorkspaceCreation);
		}
		if (interactionCase_ == InteractionOneofCase.AvailableWorkspace)
		{
			output.WriteRawTag(218, 18);
			output.WriteMessage(AvailableWorkspace);
		}
		if (interactionCase_ == InteractionOneofCase.OnboardingFlowOutcome)
		{
			output.WriteRawTag(226, 18);
			output.WriteMessage(OnboardingFlowOutcome);
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspacesPublished)
		{
			output.WriteRawTag(234, 18);
			output.WriteMessage(LogWorkspacesPublished);
		}
		if (interactionCase_ == InteractionOneofCase.LogCollaboratorsPublished)
		{
			output.WriteRawTag(242, 18);
			output.WriteMessage(LogCollaboratorsPublished);
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToCloud)
		{
			output.WriteRawTag(250, 18);
			output.WriteMessage(LogConvertToCloud);
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToLocal)
		{
			output.WriteRawTag(130, 19);
			output.WriteMessage(LogConvertToLocal);
		}
		if (interactionCase_ == InteractionOneofCase.LogSyncingChange)
		{
			output.WriteRawTag(138, 19);
			output.WriteMessage(LogSyncingChange);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentStored)
		{
			output.WriteRawTag(146, 19);
			output.WriteMessage(LogDocumentStored);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentCreated)
		{
			output.WriteRawTag(154, 19);
			output.WriteMessage(LogDocumentCreated);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUpdated)
		{
			output.WriteRawTag(162, 19);
			output.WriteMessage(LogDocumentUpdated);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDeleted)
		{
			output.WriteRawTag(170, 19);
			output.WriteMessage(LogDocumentDeleted);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentConflict)
		{
			output.WriteRawTag(178, 19);
			output.WriteMessage(LogDocumentConflict);
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspaceResynchronized)
		{
			output.WriteRawTag(186, 19);
			output.WriteMessage(LogWorkspaceResynchronized);
		}
		if (interactionCase_ == InteractionOneofCase.LogWsConnectionFailed)
		{
			output.WriteRawTag(194, 19);
			output.WriteMessage(LogWsConnectionFailed);
		}
		if (interactionCase_ == InteractionOneofCase.LogError)
		{
			output.WriteRawTag(202, 19);
			output.WriteMessage(LogError);
		}
		if (interactionCase_ == InteractionOneofCase.UserWorkspaceTreeModification)
		{
			output.WriteRawTag(210, 19);
			output.WriteMessage(UserWorkspaceTreeModification);
		}
		if (interactionCase_ == InteractionOneofCase.UiActivationFlowOpened)
		{
			output.WriteRawTag(218, 19);
			output.WriteMessage(UiActivationFlowOpened);
		}
		if (interactionCase_ == InteractionOneofCase.LogOpenedWorkspace)
		{
			output.WriteRawTag(226, 19);
			output.WriteMessage(LogOpenedWorkspace);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (interactionCase_ == InteractionOneofCase.ApiMessageReceived)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApiMessageReceived);
		}
		if (interactionCase_ == InteractionOneofCase.CreateLibrary)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateLibrary);
		}
		if (interactionCase_ == InteractionOneofCase.CreatePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreatePlaylist);
		}
		if (interactionCase_ == InteractionOneofCase.CreatePresentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreatePresentation);
		}
		if (interactionCase_ == InteractionOneofCase.CreateFromTemplatePlaylist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateFromTemplatePlaylist);
		}
		if (interactionCase_ == InteractionOneofCase.EditPresentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(EditPresentation);
		}
		if (interactionCase_ == InteractionOneofCase.ImportSongselect)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ImportSongselect);
		}
		if (interactionCase_ == InteractionOneofCase.ImportMultitracks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ImportMultitracks);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentMediabinView)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ProcontentMediabinView);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownload)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ProcontentDownload);
		}
		if (interactionCase_ == InteractionOneofCase.ProcontentDownloadRetry)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ProcontentDownloadRetry);
		}
		if (interactionCase_ == InteractionOneofCase.PlaybackMarker)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaybackMarker);
		}
		if (interactionCase_ == InteractionOneofCase.StartupLooks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StartupLooks);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfiguration)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StartupScreenConfiguration);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationScreen)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StartupScreenConfigurationScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationSingleScreen)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupScreenConfigurationSingleScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationMirroredScreen)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupScreenConfigurationMirroredScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupScreenConfigurationEdgeBlendScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationGroupedScreen)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupScreenConfigurationGroupedScreen);
		}
		if (interactionCase_ == InteractionOneofCase.StartupPreferences)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupPreferences);
		}
		if (interactionCase_ == InteractionOneofCase.StartupSongselect)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupSongselect);
		}
		if (interactionCase_ == InteractionOneofCase.StartupContent)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupContent);
		}
		if (interactionCase_ == InteractionOneofCase.StartupThemes)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupThemes);
		}
		if (interactionCase_ == InteractionOneofCase.StartupMacro)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupMacro);
		}
		if (interactionCase_ == InteractionOneofCase.StartupClearGroup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupClearGroup);
		}
		if (interactionCase_ == InteractionOneofCase.StartupKeyMapping)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupKeyMapping);
		}
		if (interactionCase_ == InteractionOneofCase.StartupMultitracks)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupMultitracks);
		}
		if (interactionCase_ == InteractionOneofCase.StartupNetworkLink)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupNetworkLink);
		}
		if (interactionCase_ == InteractionOneofCase.StartupCapture)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupCapture);
		}
		if (interactionCase_ == InteractionOneofCase.StartupVersioning)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupVersioning);
		}
		if (interactionCase_ == InteractionOneofCase.StartupDiskUsage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupDiskUsage);
		}
		if (interactionCase_ == InteractionOneofCase.StartupInterface)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupInterface);
		}
		if (interactionCase_ == InteractionOneofCase.SyncLocal)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SyncLocal);
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeActivate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimecodeActivate);
		}
		if (interactionCase_ == InteractionOneofCase.TimecodeStartup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimecodeStartup);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineAction)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimelineAction);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineRecordCue)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimelineRecordCue);
		}
		if (interactionCase_ == InteractionOneofCase.TimelineCueTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TimelineCueTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.ApplicationLaunch)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ApplicationLaunch);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputTriggered)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputTriggered);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputCustomMap)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputCustomMap);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputStartUp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.VideoInputThumbnailUpdate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputThumbnailUpdate);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnChange)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioInputAutoOnChange);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiActive)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioSettingsSdiNdiActive);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsCustomMap)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioSettingsCustomMap);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputModeSelection)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioInputModeSelection);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnStartup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioInputAutoOnStartup);
		}
		if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioSettingsSdiNdiState);
		}
		if (interactionCase_ == InteractionOneofCase.AudioInputStartUp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioInputStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.CueTriggered)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CueTriggered);
		}
		if (interactionCase_ == InteractionOneofCase.InputAudioMonitoring)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(InputAudioMonitoring);
		}
		if (interactionCase_ == InteractionOneofCase.ResiStartUp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ResiStartUp);
		}
		if (interactionCase_ == InteractionOneofCase.ResiLoginChange)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ResiLoginChange);
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStart)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RemoteStreamStart);
		}
		if (interactionCase_ == InteractionOneofCase.RemoteStreamStop)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RemoteStreamStop);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureDisk)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartCaptureDisk);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureRtmp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartCaptureRtmp);
		}
		if (interactionCase_ == InteractionOneofCase.StartCaptureResi)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartCaptureResi);
		}
		if (interactionCase_ == InteractionOneofCase.StopCapture)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StopCapture);
		}
		if (interactionCase_ == InteractionOneofCase.AnalyticReset)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AnalyticReset);
		}
		if (interactionCase_ == InteractionOneofCase.Print)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Print);
		}
		if (interactionCase_ == InteractionOneofCase.Device)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Device);
		}
		if (interactionCase_ == InteractionOneofCase.Downgrade)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Downgrade);
		}
		if (interactionCase_ == InteractionOneofCase.CcliReport)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CcliReport);
		}
		if (interactionCase_ == InteractionOneofCase.TransitionWindow)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TransitionWindow);
		}
		if (interactionCase_ == InteractionOneofCase.EditorObjectAdded)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(EditorObjectAdded);
		}
		if (interactionCase_ == InteractionOneofCase.DataIdDuplicated)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(DataIdDuplicated);
		}
		if (interactionCase_ == InteractionOneofCase.ForceQuit)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ForceQuit);
		}
		if (interactionCase_ == InteractionOneofCase.MediaCleanupSize)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaCleanupSize);
		}
		if (interactionCase_ == InteractionOneofCase.NetworkApp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(NetworkApp);
		}
		if (interactionCase_ == InteractionOneofCase.LocalWorkspaceStats)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LocalWorkspaceStats);
		}
		if (interactionCase_ == InteractionOneofCase.SyncingUnpaused)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SyncingUnpaused);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStart)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionCaptureStart);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStop)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionCaptureStop);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClear)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionClear);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionClearGroup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionClearGroup);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionCommunications)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionCommunications);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionLook)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionLook);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMacro)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionMacro);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionMessage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionMessage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionProp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionProp);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionSlideDestination)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionSlideDestination);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionStage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionStage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerActionTimer)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerActionTimer);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAudio)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaAudio);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaImage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaImage);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideoInput)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaVideoInput);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaVideo)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaVideo);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlide)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerCueSlide);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideFileFeedElement)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerCueSlideFileFeedElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideRssFeedElement)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerCueSlideRssFeedElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerCueSlideScrollingTextElement)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerCueSlideScrollingTextElement);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerTestPattern)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerTestPattern);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastVideo)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaAircastVideo);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastAudio)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerMediaAircastAudio);
		}
		if (interactionCase_ == InteractionOneofCase.AircastVideoInputConfigured)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AircastVideoInputConfigured);
		}
		if (interactionCase_ == InteractionOneofCase.AircastAudioInputConfigured)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AircastAudioInputConfigured);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementInstallationComplete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementInstallationComplete);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementBootstrappingComplete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementBootstrappingComplete);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementMessageFailure)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementMessageFailure);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementUnexpectedlyNotRunning)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementUnexpectedlyNotRunning);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementConnectionChanged)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementConnectionChanged);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementAddedMediaReference)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementAddedMediaReference);
		}
		if (interactionCase_ == InteractionOneofCase.MediaManagementNotResponding)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaManagementNotResponding);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearch)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiQuicksearch);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchSearch)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiQuicksearchSearch);
		}
		if (interactionCase_ == InteractionOneofCase.UiQuicksearchOpenitems)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiQuicksearchOpenitems);
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarTheme)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiToolbarTheme);
		}
		if (interactionCase_ == InteractionOneofCase.UiToolbarThemeApplication)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiToolbarThemeApplication);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewShow)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewShow);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPresentationEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewPresentationEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewReflow)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewReflow);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewBible)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewBible);
		}
		if (interactionCase_ == InteractionOneofCase.BibleTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateSlides)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleGenerateSlides);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGenerateNext)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleGenerateNext);
		}
		if (interactionCase_ == InteractionOneofCase.BibleGeneratePrevious)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleGeneratePrevious);
		}
		if (interactionCase_ == InteractionOneofCase.BibleSaveSlides)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleSaveSlides);
		}
		if (interactionCase_ == InteractionOneofCase.BibleLookup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleLookup);
		}
		if (interactionCase_ == InteractionOneofCase.BibleStartup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleStartup);
		}
		if (interactionCase_ == InteractionOneofCase.BibleRemove)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleRemove);
		}
		if (interactionCase_ == InteractionOneofCase.BibleInstall)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BibleInstall);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewMaskEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewMaskEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewStageEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewStageEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewThemeEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewThemeEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewCopyrightEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewCopyrightEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiMainviewPropsEditor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiMainviewPropsEditor);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimers)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimers);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCollapse)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimersCollapse);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersEdit)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimersEdit);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimersState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCreate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimersCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersDelete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightTimersDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessages)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMessages);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesEdit)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMessagesEdit);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMessagesState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesCreate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMessagesCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesDelete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMessagesDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightProps)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightProps);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightPropsTransition);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsCreate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightPropsCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsDelete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightPropsDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightPropsState);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightStage);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageChangelayout)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightStageChangelayout);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageMessagestate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightStageMessagestate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageConfigurescreens)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightStageConfigurescreens);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightStageEditlayouts)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightStageEditlayouts);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacros)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMacros);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMacrosTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosCreate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMacrosCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosDelete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiLowerrightMacrosDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspector)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspector);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorScrollingText)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspectorScrollingText);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorForeground)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspectorForeground);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorUnderlineColor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspectorUnderlineColor);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorBackgroundColor)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspectorBackgroundColor);
		}
		if (interactionCase_ == InteractionOneofCase.UiTextinspectorLineTransform)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTextinspectorLineTransform);
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabel)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiShowSlideLabel);
		}
		if (interactionCase_ == InteractionOneofCase.UiShowSlideLabelChange)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiShowSlideLabelChange);
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayShown)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiEditorOverlayShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiEditorOverlayClosed)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiEditorOverlayClosed);
		}
		if (interactionCase_ == InteractionOneofCase.UiWhatsNewViewed)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWhatsNewViewed);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroups)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiClearGroups);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsCreate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiClearGroupsCreate);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsDelete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiClearGroupsDelete);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeVisibility)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiClearGroupsChangeVisibility);
		}
		if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeIcon)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiClearGroupsChangeIcon);
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsTrigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiPreviewAreaClearGroupsTrigger);
		}
		if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsChanged)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiPreviewAreaClearGroupsChanged);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderLink)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiPlaceholderLink);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlaceholderUnlink)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiPlaceholderUnlink);
		}
		if (interactionCase_ == InteractionOneofCase.UiPlanningCenterLive)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiPlanningCenterLive);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupAdd)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiNetworkgroupAdd);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupRemove)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiNetworkgroupRemove);
		}
		if (interactionCase_ == InteractionOneofCase.UiNetworkgroupLeave)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiNetworkgroupLeave);
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportReset)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiCcliReportReset);
		}
		if (interactionCase_ == InteractionOneofCase.UiCcliReportShown)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiCcliReportShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiCaptureShown)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiCaptureShown);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcome)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcome);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeScreenConfigurationHelp)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeScreenConfigurationHelp);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeDownloadSampleContent)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeDownloadSampleContent);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeUserGroup)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeUserGroup);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeTutorials)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeTutorials);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeKnowlegdeBase)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeKnowlegdeBase);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeBlog)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeBlog);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeFacebook)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeFacebook);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeInstagram)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeInstagram);
		}
		if (interactionCase_ == InteractionOneofCase.UiWelcomeMigration)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWelcomeMigration);
		}
		if (interactionCase_ == InteractionOneofCase.UiTestPatterns)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiTestPatterns);
		}
		if (interactionCase_ == InteractionOneofCase.UiSettingsCustomLogo)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiSettingsCustomLogo);
		}
		if (interactionCase_ == InteractionOneofCase.UiWindowedOutputCreated)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiWindowedOutputCreated);
		}
		if (interactionCase_ == InteractionOneofCase.ImportPowerpoint)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ImportPowerpoint);
		}
		if (interactionCase_ == InteractionOneofCase.LibraryUsage)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LibraryUsage);
		}
		if (interactionCase_ == InteractionOneofCase.FontReplacement)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(FontReplacement);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUploaded)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentUploaded);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDownloaded)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentDownloaded);
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffPushed)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDiffPushed);
		}
		if (interactionCase_ == InteractionOneofCase.LogDiffReceived)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDiffReceived);
		}
		if (interactionCase_ == InteractionOneofCase.TriggerExternalPresentation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TriggerExternalPresentation);
		}
		if (interactionCase_ == InteractionOneofCase.WorkspaceCreation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(WorkspaceCreation);
		}
		if (interactionCase_ == InteractionOneofCase.AvailableWorkspace)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AvailableWorkspace);
		}
		if (interactionCase_ == InteractionOneofCase.OnboardingFlowOutcome)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(OnboardingFlowOutcome);
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspacesPublished)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogWorkspacesPublished);
		}
		if (interactionCase_ == InteractionOneofCase.LogCollaboratorsPublished)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogCollaboratorsPublished);
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToCloud)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogConvertToCloud);
		}
		if (interactionCase_ == InteractionOneofCase.LogConvertToLocal)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogConvertToLocal);
		}
		if (interactionCase_ == InteractionOneofCase.LogSyncingChange)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogSyncingChange);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentStored)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentStored);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentCreated)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentCreated);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentUpdated)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentUpdated);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentDeleted)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentDeleted);
		}
		if (interactionCase_ == InteractionOneofCase.LogDocumentConflict)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogDocumentConflict);
		}
		if (interactionCase_ == InteractionOneofCase.LogWorkspaceResynchronized)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogWorkspaceResynchronized);
		}
		if (interactionCase_ == InteractionOneofCase.LogWsConnectionFailed)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogWsConnectionFailed);
		}
		if (interactionCase_ == InteractionOneofCase.LogError)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogError);
		}
		if (interactionCase_ == InteractionOneofCase.UserWorkspaceTreeModification)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UserWorkspaceTreeModification);
		}
		if (interactionCase_ == InteractionOneofCase.UiActivationFlowOpened)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UiActivationFlowOpened);
		}
		if (interactionCase_ == InteractionOneofCase.LogOpenedWorkspace)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LogOpenedWorkspace);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Event other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.InteractionCase)
		{
		case InteractionOneofCase.ApiMessageReceived:
			if (ApiMessageReceived == null)
			{
				ApiMessageReceived = new MessageReceived();
			}
			ApiMessageReceived.MergeFrom(other.ApiMessageReceived);
			break;
		case InteractionOneofCase.CreateLibrary:
			if (CreateLibrary == null)
			{
				CreateLibrary = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Library();
			}
			CreateLibrary.MergeFrom(other.CreateLibrary);
			break;
		case InteractionOneofCase.CreatePlaylist:
			if (CreatePlaylist == null)
			{
				CreatePlaylist = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Playlist();
			}
			CreatePlaylist.MergeFrom(other.CreatePlaylist);
			break;
		case InteractionOneofCase.CreatePresentation:
			if (CreatePresentation == null)
			{
				CreatePresentation = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation();
			}
			CreatePresentation.MergeFrom(other.CreatePresentation);
			break;
		case InteractionOneofCase.CreateFromTemplatePlaylist:
			if (CreateFromTemplatePlaylist == null)
			{
				CreateFromTemplatePlaylist = new TemplatePlaylist();
			}
			CreateFromTemplatePlaylist.MergeFrom(other.CreateFromTemplatePlaylist);
			break;
		case InteractionOneofCase.EditPresentation:
			if (EditPresentation == null)
			{
				EditPresentation = new Pro.SerializationInterop.RVProtoData.Analytics.Edit.Presentation();
			}
			EditPresentation.MergeFrom(other.EditPresentation);
			break;
		case InteractionOneofCase.ImportSongselect:
			if (ImportSongselect == null)
			{
				ImportSongselect = new Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect();
			}
			ImportSongselect.MergeFrom(other.ImportSongselect);
			break;
		case InteractionOneofCase.ImportMultitracks:
			if (ImportMultitracks == null)
			{
				ImportMultitracks = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import();
			}
			ImportMultitracks.MergeFrom(other.ImportMultitracks);
			break;
		case InteractionOneofCase.ProcontentMediabinView:
			if (ProcontentMediabinView == null)
			{
				ProcontentMediabinView = new MediaBinView();
			}
			ProcontentMediabinView.MergeFrom(other.ProcontentMediabinView);
			break;
		case InteractionOneofCase.ProcontentDownload:
			if (ProcontentDownload == null)
			{
				ProcontentDownload = new Download();
			}
			ProcontentDownload.MergeFrom(other.ProcontentDownload);
			break;
		case InteractionOneofCase.ProcontentDownloadRetry:
			if (ProcontentDownloadRetry == null)
			{
				ProcontentDownloadRetry = new DownloadRetry();
			}
			ProcontentDownloadRetry.MergeFrom(other.ProcontentDownloadRetry);
			break;
		case InteractionOneofCase.PlaybackMarker:
			if (PlaybackMarker == null)
			{
				PlaybackMarker = new CreateMarker();
			}
			PlaybackMarker.MergeFrom(other.PlaybackMarker);
			break;
		case InteractionOneofCase.StartupLooks:
			if (StartupLooks == null)
			{
				StartupLooks = new Looks();
			}
			StartupLooks.MergeFrom(other.StartupLooks);
			break;
		case InteractionOneofCase.StartupScreenConfiguration:
			if (StartupScreenConfiguration == null)
			{
				StartupScreenConfiguration = new Summary();
			}
			StartupScreenConfiguration.MergeFrom(other.StartupScreenConfiguration);
			break;
		case InteractionOneofCase.StartupScreenConfigurationScreen:
			if (StartupScreenConfigurationScreen == null)
			{
				StartupScreenConfigurationScreen = new Output();
			}
			StartupScreenConfigurationScreen.MergeFrom(other.StartupScreenConfigurationScreen);
			break;
		case InteractionOneofCase.StartupScreenConfigurationSingleScreen:
			if (StartupScreenConfigurationSingleScreen == null)
			{
				StartupScreenConfigurationSingleScreen = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Single();
			}
			StartupScreenConfigurationSingleScreen.MergeFrom(other.StartupScreenConfigurationSingleScreen);
			break;
		case InteractionOneofCase.StartupScreenConfigurationMirroredScreen:
			if (StartupScreenConfigurationMirroredScreen == null)
			{
				StartupScreenConfigurationMirroredScreen = new Mirrored();
			}
			StartupScreenConfigurationMirroredScreen.MergeFrom(other.StartupScreenConfigurationMirroredScreen);
			break;
		case InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen:
			if (StartupScreenConfigurationEdgeBlendScreen == null)
			{
				StartupScreenConfigurationEdgeBlendScreen = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.EdgeBlend();
			}
			StartupScreenConfigurationEdgeBlendScreen.MergeFrom(other.StartupScreenConfigurationEdgeBlendScreen);
			break;
		case InteractionOneofCase.StartupScreenConfigurationGroupedScreen:
			if (StartupScreenConfigurationGroupedScreen == null)
			{
				StartupScreenConfigurationGroupedScreen = new Grouped();
			}
			StartupScreenConfigurationGroupedScreen.MergeFrom(other.StartupScreenConfigurationGroupedScreen);
			break;
		case InteractionOneofCase.StartupPreferences:
			if (StartupPreferences == null)
			{
				StartupPreferences = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Preferences();
			}
			StartupPreferences.MergeFrom(other.StartupPreferences);
			break;
		case InteractionOneofCase.StartupSongselect:
			if (StartupSongselect == null)
			{
				StartupSongselect = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect();
			}
			StartupSongselect.MergeFrom(other.StartupSongselect);
			break;
		case InteractionOneofCase.StartupContent:
			if (StartupContent == null)
			{
				StartupContent = new Content();
			}
			StartupContent.MergeFrom(other.StartupContent);
			break;
		case InteractionOneofCase.StartupThemes:
			if (StartupThemes == null)
			{
				StartupThemes = new Themes();
			}
			StartupThemes.MergeFrom(other.StartupThemes);
			break;
		case InteractionOneofCase.StartupMacro:
			if (StartupMacro == null)
			{
				StartupMacro = new Macro();
			}
			StartupMacro.MergeFrom(other.StartupMacro);
			break;
		case InteractionOneofCase.StartupClearGroup:
			if (StartupClearGroup == null)
			{
				StartupClearGroup = new ClearGroup();
			}
			StartupClearGroup.MergeFrom(other.StartupClearGroup);
			break;
		case InteractionOneofCase.StartupKeyMapping:
			if (StartupKeyMapping == null)
			{
				StartupKeyMapping = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.KeyMapping();
			}
			StartupKeyMapping.MergeFrom(other.StartupKeyMapping);
			break;
		case InteractionOneofCase.StartupMultitracks:
			if (StartupMultitracks == null)
			{
				StartupMultitracks = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Startup();
			}
			StartupMultitracks.MergeFrom(other.StartupMultitracks);
			break;
		case InteractionOneofCase.StartupNetworkLink:
			if (StartupNetworkLink == null)
			{
				StartupNetworkLink = new NetworkLink();
			}
			StartupNetworkLink.MergeFrom(other.StartupNetworkLink);
			break;
		case InteractionOneofCase.StartupCapture:
			if (StartupCapture == null)
			{
				StartupCapture = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture();
			}
			StartupCapture.MergeFrom(other.StartupCapture);
			break;
		case InteractionOneofCase.StartupVersioning:
			if (StartupVersioning == null)
			{
				StartupVersioning = new Versioning();
			}
			StartupVersioning.MergeFrom(other.StartupVersioning);
			break;
		case InteractionOneofCase.StartupDiskUsage:
			if (StartupDiskUsage == null)
			{
				StartupDiskUsage = new DiskUsage();
			}
			StartupDiskUsage.MergeFrom(other.StartupDiskUsage);
			break;
		case InteractionOneofCase.StartupInterface:
			if (StartupInterface == null)
			{
				StartupInterface = new Interface();
			}
			StartupInterface.MergeFrom(other.StartupInterface);
			break;
		case InteractionOneofCase.SyncLocal:
			if (SyncLocal == null)
			{
				SyncLocal = new Local();
			}
			SyncLocal.MergeFrom(other.SyncLocal);
			break;
		case InteractionOneofCase.TimecodeActivate:
			if (TimecodeActivate == null)
			{
				TimecodeActivate = new Activate();
			}
			TimecodeActivate.MergeFrom(other.TimecodeActivate);
			break;
		case InteractionOneofCase.TimecodeStartup:
			if (TimecodeStartup == null)
			{
				TimecodeStartup = new Pro.SerializationInterop.RVProtoData.Analytics.Timecode.Startup();
			}
			TimecodeStartup.MergeFrom(other.TimecodeStartup);
			break;
		case InteractionOneofCase.TimelineAction:
			if (TimelineAction == null)
			{
				TimelineAction = new Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action();
			}
			TimelineAction.MergeFrom(other.TimelineAction);
			break;
		case InteractionOneofCase.TimelineRecordCue:
			if (TimelineRecordCue == null)
			{
				TimelineRecordCue = new RecordCue();
			}
			TimelineRecordCue.MergeFrom(other.TimelineRecordCue);
			break;
		case InteractionOneofCase.TimelineCueTrigger:
			if (TimelineCueTrigger == null)
			{
				TimelineCueTrigger = new CueTrigger();
			}
			TimelineCueTrigger.MergeFrom(other.TimelineCueTrigger);
			break;
		case InteractionOneofCase.ApplicationLaunch:
			if (ApplicationLaunch == null)
			{
				ApplicationLaunch = new ApplicationLaunch();
			}
			ApplicationLaunch.MergeFrom(other.ApplicationLaunch);
			break;
		case InteractionOneofCase.VideoInputTriggered:
			if (VideoInputTriggered == null)
			{
				VideoInputTriggered = new VideoInputTriggered();
			}
			VideoInputTriggered.MergeFrom(other.VideoInputTriggered);
			break;
		case InteractionOneofCase.VideoInputCustomMap:
			if (VideoInputCustomMap == null)
			{
				VideoInputCustomMap = new VideoInputCustomMap();
			}
			VideoInputCustomMap.MergeFrom(other.VideoInputCustomMap);
			break;
		case InteractionOneofCase.VideoInputStartUp:
			if (VideoInputStartUp == null)
			{
				VideoInputStartUp = new VideoInputStartUp();
			}
			VideoInputStartUp.MergeFrom(other.VideoInputStartUp);
			break;
		case InteractionOneofCase.VideoInputThumbnailUpdate:
			if (VideoInputThumbnailUpdate == null)
			{
				VideoInputThumbnailUpdate = new VideoInputThumbnailUpdate();
			}
			VideoInputThumbnailUpdate.MergeFrom(other.VideoInputThumbnailUpdate);
			break;
		case InteractionOneofCase.AudioInputAutoOnChange:
			if (AudioInputAutoOnChange == null)
			{
				AudioInputAutoOnChange = new AudioInputAutoOnChange();
			}
			AudioInputAutoOnChange.MergeFrom(other.AudioInputAutoOnChange);
			break;
		case InteractionOneofCase.AudioSettingsSdiNdiActive:
			if (AudioSettingsSdiNdiActive == null)
			{
				AudioSettingsSdiNdiActive = new AudioSettingsSdiNdiActive();
			}
			AudioSettingsSdiNdiActive.MergeFrom(other.AudioSettingsSdiNdiActive);
			break;
		case InteractionOneofCase.AudioSettingsCustomMap:
			if (AudioSettingsCustomMap == null)
			{
				AudioSettingsCustomMap = new AudioSettingsCustomMap();
			}
			AudioSettingsCustomMap.MergeFrom(other.AudioSettingsCustomMap);
			break;
		case InteractionOneofCase.AudioInputModeSelection:
			if (AudioInputModeSelection == null)
			{
				AudioInputModeSelection = new AudioInputModeSelection();
			}
			AudioInputModeSelection.MergeFrom(other.AudioInputModeSelection);
			break;
		case InteractionOneofCase.AudioInputAutoOnStartup:
			if (AudioInputAutoOnStartup == null)
			{
				AudioInputAutoOnStartup = new AudioInputAutoOnStartup();
			}
			AudioInputAutoOnStartup.MergeFrom(other.AudioInputAutoOnStartup);
			break;
		case InteractionOneofCase.AudioSettingsSdiNdiState:
			if (AudioSettingsSdiNdiState == null)
			{
				AudioSettingsSdiNdiState = new AudioSettingsSdiNdiState();
			}
			AudioSettingsSdiNdiState.MergeFrom(other.AudioSettingsSdiNdiState);
			break;
		case InteractionOneofCase.AudioInputStartUp:
			if (AudioInputStartUp == null)
			{
				AudioInputStartUp = new AudioInputStartUp();
			}
			AudioInputStartUp.MergeFrom(other.AudioInputStartUp);
			break;
		case InteractionOneofCase.CueTriggered:
			if (CueTriggered == null)
			{
				CueTriggered = new CueTriggered();
			}
			CueTriggered.MergeFrom(other.CueTriggered);
			break;
		case InteractionOneofCase.InputAudioMonitoring:
			if (InputAudioMonitoring == null)
			{
				InputAudioMonitoring = new InputAudioMonitoring();
			}
			InputAudioMonitoring.MergeFrom(other.InputAudioMonitoring);
			break;
		case InteractionOneofCase.ResiStartUp:
			if (ResiStartUp == null)
			{
				ResiStartUp = new ResiStartUp();
			}
			ResiStartUp.MergeFrom(other.ResiStartUp);
			break;
		case InteractionOneofCase.ResiLoginChange:
			if (ResiLoginChange == null)
			{
				ResiLoginChange = new ResiLoginChange();
			}
			ResiLoginChange.MergeFrom(other.ResiLoginChange);
			break;
		case InteractionOneofCase.RemoteStreamStart:
			if (RemoteStreamStart == null)
			{
				RemoteStreamStart = new RemoteStreamStart();
			}
			RemoteStreamStart.MergeFrom(other.RemoteStreamStart);
			break;
		case InteractionOneofCase.RemoteStreamStop:
			if (RemoteStreamStop == null)
			{
				RemoteStreamStop = new RemoteStreamStop();
			}
			RemoteStreamStop.MergeFrom(other.RemoteStreamStop);
			break;
		case InteractionOneofCase.StartCaptureDisk:
			if (StartCaptureDisk == null)
			{
				StartCaptureDisk = new StartCaptureDisk();
			}
			StartCaptureDisk.MergeFrom(other.StartCaptureDisk);
			break;
		case InteractionOneofCase.StartCaptureRtmp:
			if (StartCaptureRtmp == null)
			{
				StartCaptureRtmp = new StartCaptureRtmp();
			}
			StartCaptureRtmp.MergeFrom(other.StartCaptureRtmp);
			break;
		case InteractionOneofCase.StartCaptureResi:
			if (StartCaptureResi == null)
			{
				StartCaptureResi = new StartCaptureResi();
			}
			StartCaptureResi.MergeFrom(other.StartCaptureResi);
			break;
		case InteractionOneofCase.StopCapture:
			if (StopCapture == null)
			{
				StopCapture = new StopCapture();
			}
			StopCapture.MergeFrom(other.StopCapture);
			break;
		case InteractionOneofCase.AnalyticReset:
			if (AnalyticReset == null)
			{
				AnalyticReset = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.GenericEvent();
			}
			AnalyticReset.MergeFrom(other.AnalyticReset);
			break;
		case InteractionOneofCase.Print:
			if (Print == null)
			{
				Print = new Print();
			}
			Print.MergeFrom(other.Print);
			break;
		case InteractionOneofCase.Device:
			if (Device == null)
			{
				Device = new Device();
			}
			Device.MergeFrom(other.Device);
			break;
		case InteractionOneofCase.Downgrade:
			if (Downgrade == null)
			{
				Downgrade = new Downgrade();
			}
			Downgrade.MergeFrom(other.Downgrade);
			break;
		case InteractionOneofCase.CcliReport:
			if (CcliReport == null)
			{
				CcliReport = new CCLIReport();
			}
			CcliReport.MergeFrom(other.CcliReport);
			break;
		case InteractionOneofCase.TransitionWindow:
			if (TransitionWindow == null)
			{
				TransitionWindow = new TransitionWindow();
			}
			TransitionWindow.MergeFrom(other.TransitionWindow);
			break;
		case InteractionOneofCase.EditorObjectAdded:
			if (EditorObjectAdded == null)
			{
				EditorObjectAdded = new EditorObjectAdded();
			}
			EditorObjectAdded.MergeFrom(other.EditorObjectAdded);
			break;
		case InteractionOneofCase.DataIdDuplicated:
			if (DataIdDuplicated == null)
			{
				DataIdDuplicated = new DataIdDuplicated();
			}
			DataIdDuplicated.MergeFrom(other.DataIdDuplicated);
			break;
		case InteractionOneofCase.ForceQuit:
			if (ForceQuit == null)
			{
				ForceQuit = new ForceQuit();
			}
			ForceQuit.MergeFrom(other.ForceQuit);
			break;
		case InteractionOneofCase.MediaCleanupSize:
			if (MediaCleanupSize == null)
			{
				MediaCleanupSize = new MediaCleanupSize();
			}
			MediaCleanupSize.MergeFrom(other.MediaCleanupSize);
			break;
		case InteractionOneofCase.NetworkApp:
			if (NetworkApp == null)
			{
				NetworkApp = new NetworkApp();
			}
			NetworkApp.MergeFrom(other.NetworkApp);
			break;
		case InteractionOneofCase.LocalWorkspaceStats:
			if (LocalWorkspaceStats == null)
			{
				LocalWorkspaceStats = new LocalWorkspaceStats();
			}
			LocalWorkspaceStats.MergeFrom(other.LocalWorkspaceStats);
			break;
		case InteractionOneofCase.SyncingUnpaused:
			if (SyncingUnpaused == null)
			{
				SyncingUnpaused = new SyncingUnpaused();
			}
			SyncingUnpaused.MergeFrom(other.SyncingUnpaused);
			break;
		case InteractionOneofCase.TriggerActionCaptureStart:
			if (TriggerActionCaptureStart == null)
			{
				TriggerActionCaptureStart = new ActionCaptureStart();
			}
			TriggerActionCaptureStart.MergeFrom(other.TriggerActionCaptureStart);
			break;
		case InteractionOneofCase.TriggerActionCaptureStop:
			if (TriggerActionCaptureStop == null)
			{
				TriggerActionCaptureStop = new ActionCaptureStop();
			}
			TriggerActionCaptureStop.MergeFrom(other.TriggerActionCaptureStop);
			break;
		case InteractionOneofCase.TriggerActionClear:
			if (TriggerActionClear == null)
			{
				TriggerActionClear = new ActionClear();
			}
			TriggerActionClear.MergeFrom(other.TriggerActionClear);
			break;
		case InteractionOneofCase.TriggerActionClearGroup:
			if (TriggerActionClearGroup == null)
			{
				TriggerActionClearGroup = new ActionClearGroup();
			}
			TriggerActionClearGroup.MergeFrom(other.TriggerActionClearGroup);
			break;
		case InteractionOneofCase.TriggerActionCommunications:
			if (TriggerActionCommunications == null)
			{
				TriggerActionCommunications = new ActionCommunications();
			}
			TriggerActionCommunications.MergeFrom(other.TriggerActionCommunications);
			break;
		case InteractionOneofCase.TriggerActionLook:
			if (TriggerActionLook == null)
			{
				TriggerActionLook = new ActionLook();
			}
			TriggerActionLook.MergeFrom(other.TriggerActionLook);
			break;
		case InteractionOneofCase.TriggerActionMacro:
			if (TriggerActionMacro == null)
			{
				TriggerActionMacro = new ActionMacro();
			}
			TriggerActionMacro.MergeFrom(other.TriggerActionMacro);
			break;
		case InteractionOneofCase.TriggerActionMessage:
			if (TriggerActionMessage == null)
			{
				TriggerActionMessage = new ActionMessage();
			}
			TriggerActionMessage.MergeFrom(other.TriggerActionMessage);
			break;
		case InteractionOneofCase.TriggerActionProp:
			if (TriggerActionProp == null)
			{
				TriggerActionProp = new ActionProp();
			}
			TriggerActionProp.MergeFrom(other.TriggerActionProp);
			break;
		case InteractionOneofCase.TriggerActionSlideDestination:
			if (TriggerActionSlideDestination == null)
			{
				TriggerActionSlideDestination = new ActionSlideDestination();
			}
			TriggerActionSlideDestination.MergeFrom(other.TriggerActionSlideDestination);
			break;
		case InteractionOneofCase.TriggerActionStage:
			if (TriggerActionStage == null)
			{
				TriggerActionStage = new ActionStage();
			}
			TriggerActionStage.MergeFrom(other.TriggerActionStage);
			break;
		case InteractionOneofCase.TriggerActionTimer:
			if (TriggerActionTimer == null)
			{
				TriggerActionTimer = new ActionTimer();
			}
			TriggerActionTimer.MergeFrom(other.TriggerActionTimer);
			break;
		case InteractionOneofCase.TriggerMediaAudio:
			if (TriggerMediaAudio == null)
			{
				TriggerMediaAudio = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.Audio();
			}
			TriggerMediaAudio.MergeFrom(other.TriggerMediaAudio);
			break;
		case InteractionOneofCase.TriggerMediaImage:
			if (TriggerMediaImage == null)
			{
				TriggerMediaImage = new Image();
			}
			TriggerMediaImage.MergeFrom(other.TriggerMediaImage);
			break;
		case InteractionOneofCase.TriggerMediaVideoInput:
			if (TriggerMediaVideoInput == null)
			{
				TriggerMediaVideoInput = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.VideoInput();
			}
			TriggerMediaVideoInput.MergeFrom(other.TriggerMediaVideoInput);
			break;
		case InteractionOneofCase.TriggerMediaVideo:
			if (TriggerMediaVideo == null)
			{
				TriggerMediaVideo = new Video();
			}
			TriggerMediaVideo.MergeFrom(other.TriggerMediaVideo);
			break;
		case InteractionOneofCase.TriggerCueSlide:
			if (TriggerCueSlide == null)
			{
				TriggerCueSlide = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue.Slide();
			}
			TriggerCueSlide.MergeFrom(other.TriggerCueSlide);
			break;
		case InteractionOneofCase.TriggerCueSlideFileFeedElement:
			if (TriggerCueSlideFileFeedElement == null)
			{
				TriggerCueSlideFileFeedElement = new SlideFileFeedElement();
			}
			TriggerCueSlideFileFeedElement.MergeFrom(other.TriggerCueSlideFileFeedElement);
			break;
		case InteractionOneofCase.TriggerCueSlideRssFeedElement:
			if (TriggerCueSlideRssFeedElement == null)
			{
				TriggerCueSlideRssFeedElement = new SlideRssFeedElement();
			}
			TriggerCueSlideRssFeedElement.MergeFrom(other.TriggerCueSlideRssFeedElement);
			break;
		case InteractionOneofCase.TriggerCueSlideScrollingTextElement:
			if (TriggerCueSlideScrollingTextElement == null)
			{
				TriggerCueSlideScrollingTextElement = new SlideScrollingTextElement();
			}
			TriggerCueSlideScrollingTextElement.MergeFrom(other.TriggerCueSlideScrollingTextElement);
			break;
		case InteractionOneofCase.TriggerTestPattern:
			if (TriggerTestPattern == null)
			{
				TriggerTestPattern = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.TestPattern();
			}
			TriggerTestPattern.MergeFrom(other.TriggerTestPattern);
			break;
		case InteractionOneofCase.TriggerMediaAircastVideo:
			if (TriggerMediaAircastVideo == null)
			{
				TriggerMediaAircastVideo = new AirCastVideo();
			}
			TriggerMediaAircastVideo.MergeFrom(other.TriggerMediaAircastVideo);
			break;
		case InteractionOneofCase.TriggerMediaAircastAudio:
			if (TriggerMediaAircastAudio == null)
			{
				TriggerMediaAircastAudio = new AirCastAudio();
			}
			TriggerMediaAircastAudio.MergeFrom(other.TriggerMediaAircastAudio);
			break;
		case InteractionOneofCase.AircastVideoInputConfigured:
			if (AircastVideoInputConfigured == null)
			{
				AircastVideoInputConfigured = new AirCastVideo();
			}
			AircastVideoInputConfigured.MergeFrom(other.AircastVideoInputConfigured);
			break;
		case InteractionOneofCase.AircastAudioInputConfigured:
			if (AircastAudioInputConfigured == null)
			{
				AircastAudioInputConfigured = new AirCastAudio();
			}
			AircastAudioInputConfigured.MergeFrom(other.AircastAudioInputConfigured);
			break;
		case InteractionOneofCase.MediaManagementInstallationComplete:
			if (MediaManagementInstallationComplete == null)
			{
				MediaManagementInstallationComplete = new InstallationComplete();
			}
			MediaManagementInstallationComplete.MergeFrom(other.MediaManagementInstallationComplete);
			break;
		case InteractionOneofCase.MediaManagementBootstrappingComplete:
			if (MediaManagementBootstrappingComplete == null)
			{
				MediaManagementBootstrappingComplete = new BootstrappingComplete();
			}
			MediaManagementBootstrappingComplete.MergeFrom(other.MediaManagementBootstrappingComplete);
			break;
		case InteractionOneofCase.MediaManagementMessageFailure:
			if (MediaManagementMessageFailure == null)
			{
				MediaManagementMessageFailure = new MessageFailure();
			}
			MediaManagementMessageFailure.MergeFrom(other.MediaManagementMessageFailure);
			break;
		case InteractionOneofCase.MediaManagementUnexpectedlyNotRunning:
			if (MediaManagementUnexpectedlyNotRunning == null)
			{
				MediaManagementUnexpectedlyNotRunning = new UnexpectedlyNotRunning();
			}
			MediaManagementUnexpectedlyNotRunning.MergeFrom(other.MediaManagementUnexpectedlyNotRunning);
			break;
		case InteractionOneofCase.MediaManagementConnectionChanged:
			if (MediaManagementConnectionChanged == null)
			{
				MediaManagementConnectionChanged = new ConnectionChanged();
			}
			MediaManagementConnectionChanged.MergeFrom(other.MediaManagementConnectionChanged);
			break;
		case InteractionOneofCase.MediaManagementAddedMediaReference:
			if (MediaManagementAddedMediaReference == null)
			{
				MediaManagementAddedMediaReference = new AddedMediaReference();
			}
			MediaManagementAddedMediaReference.MergeFrom(other.MediaManagementAddedMediaReference);
			break;
		case InteractionOneofCase.MediaManagementNotResponding:
			if (MediaManagementNotResponding == null)
			{
				MediaManagementNotResponding = new NotResponding();
			}
			MediaManagementNotResponding.MergeFrom(other.MediaManagementNotResponding);
			break;
		case InteractionOneofCase.UiQuicksearch:
			if (UiQuicksearch == null)
			{
				UiQuicksearch = new QuickSearchShown();
			}
			UiQuicksearch.MergeFrom(other.UiQuicksearch);
			break;
		case InteractionOneofCase.UiQuicksearchSearch:
			if (UiQuicksearchSearch == null)
			{
				UiQuicksearchSearch = new QuickSearchSearch();
			}
			UiQuicksearchSearch.MergeFrom(other.UiQuicksearchSearch);
			break;
		case InteractionOneofCase.UiQuicksearchOpenitems:
			if (UiQuicksearchOpenitems == null)
			{
				UiQuicksearchOpenitems = new QuickSearchOpenItems();
			}
			UiQuicksearchOpenitems.MergeFrom(other.UiQuicksearchOpenitems);
			break;
		case InteractionOneofCase.UiToolbarTheme:
			if (UiToolbarTheme == null)
			{
				UiToolbarTheme = new ToolbarThemeShown();
			}
			UiToolbarTheme.MergeFrom(other.UiToolbarTheme);
			break;
		case InteractionOneofCase.UiToolbarThemeApplication:
			if (UiToolbarThemeApplication == null)
			{
				UiToolbarThemeApplication = new ToolbarThemeApplication();
			}
			UiToolbarThemeApplication.MergeFrom(other.UiToolbarThemeApplication);
			break;
		case InteractionOneofCase.UiMainviewShow:
			if (UiMainviewShow == null)
			{
				UiMainviewShow = new MainViewShow();
			}
			UiMainviewShow.MergeFrom(other.UiMainviewShow);
			break;
		case InteractionOneofCase.UiMainviewPresentationEditor:
			if (UiMainviewPresentationEditor == null)
			{
				UiMainviewPresentationEditor = new MainViewPresentationEditor();
			}
			UiMainviewPresentationEditor.MergeFrom(other.UiMainviewPresentationEditor);
			break;
		case InteractionOneofCase.UiMainviewReflow:
			if (UiMainviewReflow == null)
			{
				UiMainviewReflow = new MainViewReflowEditor();
			}
			UiMainviewReflow.MergeFrom(other.UiMainviewReflow);
			break;
		case InteractionOneofCase.UiMainviewBible:
			if (UiMainviewBible == null)
			{
				UiMainviewBible = new MainViewBible();
			}
			UiMainviewBible.MergeFrom(other.UiMainviewBible);
			break;
		case InteractionOneofCase.BibleTrigger:
			if (BibleTrigger == null)
			{
				BibleTrigger = new BibleTrigger();
			}
			BibleTrigger.MergeFrom(other.BibleTrigger);
			break;
		case InteractionOneofCase.BibleGenerateSlides:
			if (BibleGenerateSlides == null)
			{
				BibleGenerateSlides = new BibleGenerateSlides();
			}
			BibleGenerateSlides.MergeFrom(other.BibleGenerateSlides);
			break;
		case InteractionOneofCase.BibleGenerateNext:
			if (BibleGenerateNext == null)
			{
				BibleGenerateNext = new BibleGenerateNext();
			}
			BibleGenerateNext.MergeFrom(other.BibleGenerateNext);
			break;
		case InteractionOneofCase.BibleGeneratePrevious:
			if (BibleGeneratePrevious == null)
			{
				BibleGeneratePrevious = new BibleGenerateNext();
			}
			BibleGeneratePrevious.MergeFrom(other.BibleGeneratePrevious);
			break;
		case InteractionOneofCase.BibleSaveSlides:
			if (BibleSaveSlides == null)
			{
				BibleSaveSlides = new BibleSaveSlides();
			}
			BibleSaveSlides.MergeFrom(other.BibleSaveSlides);
			break;
		case InteractionOneofCase.BibleLookup:
			if (BibleLookup == null)
			{
				BibleLookup = new BibleLookup();
			}
			BibleLookup.MergeFrom(other.BibleLookup);
			break;
		case InteractionOneofCase.BibleStartup:
			if (BibleStartup == null)
			{
				BibleStartup = new BibleStartup();
			}
			BibleStartup.MergeFrom(other.BibleStartup);
			break;
		case InteractionOneofCase.BibleRemove:
			if (BibleRemove == null)
			{
				BibleRemove = new BibleRemove();
			}
			BibleRemove.MergeFrom(other.BibleRemove);
			break;
		case InteractionOneofCase.BibleInstall:
			if (BibleInstall == null)
			{
				BibleInstall = new BibleInstall();
			}
			BibleInstall.MergeFrom(other.BibleInstall);
			break;
		case InteractionOneofCase.UiMainviewMaskEditor:
			if (UiMainviewMaskEditor == null)
			{
				UiMainviewMaskEditor = new MainViewMaskEditor();
			}
			UiMainviewMaskEditor.MergeFrom(other.UiMainviewMaskEditor);
			break;
		case InteractionOneofCase.UiMainviewStageEditor:
			if (UiMainviewStageEditor == null)
			{
				UiMainviewStageEditor = new MainViewStageEditor();
			}
			UiMainviewStageEditor.MergeFrom(other.UiMainviewStageEditor);
			break;
		case InteractionOneofCase.UiMainviewThemeEditor:
			if (UiMainviewThemeEditor == null)
			{
				UiMainviewThemeEditor = new MainViewThemeEditor();
			}
			UiMainviewThemeEditor.MergeFrom(other.UiMainviewThemeEditor);
			break;
		case InteractionOneofCase.UiMainviewCopyrightEditor:
			if (UiMainviewCopyrightEditor == null)
			{
				UiMainviewCopyrightEditor = new MainViewCopyrightEditor();
			}
			UiMainviewCopyrightEditor.MergeFrom(other.UiMainviewCopyrightEditor);
			break;
		case InteractionOneofCase.UiMainviewPropsEditor:
			if (UiMainviewPropsEditor == null)
			{
				UiMainviewPropsEditor = new MainViewPropsEditor();
			}
			UiMainviewPropsEditor.MergeFrom(other.UiMainviewPropsEditor);
			break;
		case InteractionOneofCase.UiLowerrightTimers:
			if (UiLowerrightTimers == null)
			{
				UiLowerrightTimers = new LowerRightTimers();
			}
			UiLowerrightTimers.MergeFrom(other.UiLowerrightTimers);
			break;
		case InteractionOneofCase.UiLowerrightTimersCollapse:
			if (UiLowerrightTimersCollapse == null)
			{
				UiLowerrightTimersCollapse = new LowerRightTimersCollapse();
			}
			UiLowerrightTimersCollapse.MergeFrom(other.UiLowerrightTimersCollapse);
			break;
		case InteractionOneofCase.UiLowerrightTimersEdit:
			if (UiLowerrightTimersEdit == null)
			{
				UiLowerrightTimersEdit = new LowerRightTimersEdit();
			}
			UiLowerrightTimersEdit.MergeFrom(other.UiLowerrightTimersEdit);
			break;
		case InteractionOneofCase.UiLowerrightTimersState:
			if (UiLowerrightTimersState == null)
			{
				UiLowerrightTimersState = new LowerRightTimersState();
			}
			UiLowerrightTimersState.MergeFrom(other.UiLowerrightTimersState);
			break;
		case InteractionOneofCase.UiLowerrightTimersCreate:
			if (UiLowerrightTimersCreate == null)
			{
				UiLowerrightTimersCreate = new LowerRightTimersCreate();
			}
			UiLowerrightTimersCreate.MergeFrom(other.UiLowerrightTimersCreate);
			break;
		case InteractionOneofCase.UiLowerrightTimersDelete:
			if (UiLowerrightTimersDelete == null)
			{
				UiLowerrightTimersDelete = new LowerRightTimersDelete();
			}
			UiLowerrightTimersDelete.MergeFrom(other.UiLowerrightTimersDelete);
			break;
		case InteractionOneofCase.UiLowerrightMessages:
			if (UiLowerrightMessages == null)
			{
				UiLowerrightMessages = new LowerRightMessages();
			}
			UiLowerrightMessages.MergeFrom(other.UiLowerrightMessages);
			break;
		case InteractionOneofCase.UiLowerrightMessagesEdit:
			if (UiLowerrightMessagesEdit == null)
			{
				UiLowerrightMessagesEdit = new LowerRightMessagesEdit();
			}
			UiLowerrightMessagesEdit.MergeFrom(other.UiLowerrightMessagesEdit);
			break;
		case InteractionOneofCase.UiLowerrightMessagesState:
			if (UiLowerrightMessagesState == null)
			{
				UiLowerrightMessagesState = new LowerRightMessagesState();
			}
			UiLowerrightMessagesState.MergeFrom(other.UiLowerrightMessagesState);
			break;
		case InteractionOneofCase.UiLowerrightMessagesCreate:
			if (UiLowerrightMessagesCreate == null)
			{
				UiLowerrightMessagesCreate = new LowerRightMessagesCreate();
			}
			UiLowerrightMessagesCreate.MergeFrom(other.UiLowerrightMessagesCreate);
			break;
		case InteractionOneofCase.UiLowerrightMessagesDelete:
			if (UiLowerrightMessagesDelete == null)
			{
				UiLowerrightMessagesDelete = new LowerRightMessagesDelete();
			}
			UiLowerrightMessagesDelete.MergeFrom(other.UiLowerrightMessagesDelete);
			break;
		case InteractionOneofCase.UiLowerrightProps:
			if (UiLowerrightProps == null)
			{
				UiLowerrightProps = new LowerRightProps();
			}
			UiLowerrightProps.MergeFrom(other.UiLowerrightProps);
			break;
		case InteractionOneofCase.UiLowerrightPropsTransition:
			if (UiLowerrightPropsTransition == null)
			{
				UiLowerrightPropsTransition = new LowerRightPropsTransition();
			}
			UiLowerrightPropsTransition.MergeFrom(other.UiLowerrightPropsTransition);
			break;
		case InteractionOneofCase.UiLowerrightPropsCreate:
			if (UiLowerrightPropsCreate == null)
			{
				UiLowerrightPropsCreate = new LowerRightPropsCreate();
			}
			UiLowerrightPropsCreate.MergeFrom(other.UiLowerrightPropsCreate);
			break;
		case InteractionOneofCase.UiLowerrightPropsDelete:
			if (UiLowerrightPropsDelete == null)
			{
				UiLowerrightPropsDelete = new LowerRightPropsDelete();
			}
			UiLowerrightPropsDelete.MergeFrom(other.UiLowerrightPropsDelete);
			break;
		case InteractionOneofCase.UiLowerrightPropsState:
			if (UiLowerrightPropsState == null)
			{
				UiLowerrightPropsState = new LowerRightPropsState();
			}
			UiLowerrightPropsState.MergeFrom(other.UiLowerrightPropsState);
			break;
		case InteractionOneofCase.UiLowerrightStage:
			if (UiLowerrightStage == null)
			{
				UiLowerrightStage = new LowerRightStage();
			}
			UiLowerrightStage.MergeFrom(other.UiLowerrightStage);
			break;
		case InteractionOneofCase.UiLowerrightStageChangelayout:
			if (UiLowerrightStageChangelayout == null)
			{
				UiLowerrightStageChangelayout = new LowerRightStageChangeLayout();
			}
			UiLowerrightStageChangelayout.MergeFrom(other.UiLowerrightStageChangelayout);
			break;
		case InteractionOneofCase.UiLowerrightStageMessagestate:
			if (UiLowerrightStageMessagestate == null)
			{
				UiLowerrightStageMessagestate = new LowerRightStageMessageState();
			}
			UiLowerrightStageMessagestate.MergeFrom(other.UiLowerrightStageMessagestate);
			break;
		case InteractionOneofCase.UiLowerrightStageConfigurescreens:
			if (UiLowerrightStageConfigurescreens == null)
			{
				UiLowerrightStageConfigurescreens = new LowerRightStageConfigureScreens();
			}
			UiLowerrightStageConfigurescreens.MergeFrom(other.UiLowerrightStageConfigurescreens);
			break;
		case InteractionOneofCase.UiLowerrightStageEditlayouts:
			if (UiLowerrightStageEditlayouts == null)
			{
				UiLowerrightStageEditlayouts = new LowerRightStageEditLayouts();
			}
			UiLowerrightStageEditlayouts.MergeFrom(other.UiLowerrightStageEditlayouts);
			break;
		case InteractionOneofCase.UiLowerrightMacros:
			if (UiLowerrightMacros == null)
			{
				UiLowerrightMacros = new LowerRightMacros();
			}
			UiLowerrightMacros.MergeFrom(other.UiLowerrightMacros);
			break;
		case InteractionOneofCase.UiLowerrightMacrosTrigger:
			if (UiLowerrightMacrosTrigger == null)
			{
				UiLowerrightMacrosTrigger = new LowerRightMacrosTrigger();
			}
			UiLowerrightMacrosTrigger.MergeFrom(other.UiLowerrightMacrosTrigger);
			break;
		case InteractionOneofCase.UiLowerrightMacrosCreate:
			if (UiLowerrightMacrosCreate == null)
			{
				UiLowerrightMacrosCreate = new LowerRightMacrosCreate();
			}
			UiLowerrightMacrosCreate.MergeFrom(other.UiLowerrightMacrosCreate);
			break;
		case InteractionOneofCase.UiLowerrightMacrosDelete:
			if (UiLowerrightMacrosDelete == null)
			{
				UiLowerrightMacrosDelete = new LowerRightMacrosDelete();
			}
			UiLowerrightMacrosDelete.MergeFrom(other.UiLowerrightMacrosDelete);
			break;
		case InteractionOneofCase.UiTextinspector:
			if (UiTextinspector == null)
			{
				UiTextinspector = new TextInspector();
			}
			UiTextinspector.MergeFrom(other.UiTextinspector);
			break;
		case InteractionOneofCase.UiTextinspectorScrollingText:
			if (UiTextinspectorScrollingText == null)
			{
				UiTextinspectorScrollingText = new TextInspectorScrollingText();
			}
			UiTextinspectorScrollingText.MergeFrom(other.UiTextinspectorScrollingText);
			break;
		case InteractionOneofCase.UiTextinspectorForeground:
			if (UiTextinspectorForeground == null)
			{
				UiTextinspectorForeground = new TextInspectorForeground();
			}
			UiTextinspectorForeground.MergeFrom(other.UiTextinspectorForeground);
			break;
		case InteractionOneofCase.UiTextinspectorUnderlineColor:
			if (UiTextinspectorUnderlineColor == null)
			{
				UiTextinspectorUnderlineColor = new TextInspectorUnderlineColor();
			}
			UiTextinspectorUnderlineColor.MergeFrom(other.UiTextinspectorUnderlineColor);
			break;
		case InteractionOneofCase.UiTextinspectorBackgroundColor:
			if (UiTextinspectorBackgroundColor == null)
			{
				UiTextinspectorBackgroundColor = new TextInspectorBackgroundColor();
			}
			UiTextinspectorBackgroundColor.MergeFrom(other.UiTextinspectorBackgroundColor);
			break;
		case InteractionOneofCase.UiTextinspectorLineTransform:
			if (UiTextinspectorLineTransform == null)
			{
				UiTextinspectorLineTransform = new TextInspectorLineTransform();
			}
			UiTextinspectorLineTransform.MergeFrom(other.UiTextinspectorLineTransform);
			break;
		case InteractionOneofCase.UiShowSlideLabel:
			if (UiShowSlideLabel == null)
			{
				UiShowSlideLabel = new ShowSlideLabel();
			}
			UiShowSlideLabel.MergeFrom(other.UiShowSlideLabel);
			break;
		case InteractionOneofCase.UiShowSlideLabelChange:
			if (UiShowSlideLabelChange == null)
			{
				UiShowSlideLabelChange = new ShowSlideLabelChange();
			}
			UiShowSlideLabelChange.MergeFrom(other.UiShowSlideLabelChange);
			break;
		case InteractionOneofCase.UiEditorOverlayShown:
			if (UiEditorOverlayShown == null)
			{
				UiEditorOverlayShown = new EditorOverlayShown();
			}
			UiEditorOverlayShown.MergeFrom(other.UiEditorOverlayShown);
			break;
		case InteractionOneofCase.UiEditorOverlayClosed:
			if (UiEditorOverlayClosed == null)
			{
				UiEditorOverlayClosed = new EditorOverlayClosed();
			}
			UiEditorOverlayClosed.MergeFrom(other.UiEditorOverlayClosed);
			break;
		case InteractionOneofCase.UiWhatsNewViewed:
			if (UiWhatsNewViewed == null)
			{
				UiWhatsNewViewed = new WhatsNewViewed();
			}
			UiWhatsNewViewed.MergeFrom(other.UiWhatsNewViewed);
			break;
		case InteractionOneofCase.UiClearGroups:
			if (UiClearGroups == null)
			{
				UiClearGroups = new ClearGroups();
			}
			UiClearGroups.MergeFrom(other.UiClearGroups);
			break;
		case InteractionOneofCase.UiClearGroupsCreate:
			if (UiClearGroupsCreate == null)
			{
				UiClearGroupsCreate = new ClearGroupsCreate();
			}
			UiClearGroupsCreate.MergeFrom(other.UiClearGroupsCreate);
			break;
		case InteractionOneofCase.UiClearGroupsDelete:
			if (UiClearGroupsDelete == null)
			{
				UiClearGroupsDelete = new ClearGroupsDelete();
			}
			UiClearGroupsDelete.MergeFrom(other.UiClearGroupsDelete);
			break;
		case InteractionOneofCase.UiClearGroupsChangeVisibility:
			if (UiClearGroupsChangeVisibility == null)
			{
				UiClearGroupsChangeVisibility = new ClearGroupsChangeVisibility();
			}
			UiClearGroupsChangeVisibility.MergeFrom(other.UiClearGroupsChangeVisibility);
			break;
		case InteractionOneofCase.UiClearGroupsChangeIcon:
			if (UiClearGroupsChangeIcon == null)
			{
				UiClearGroupsChangeIcon = new ClearGroupsChangeIcon();
			}
			UiClearGroupsChangeIcon.MergeFrom(other.UiClearGroupsChangeIcon);
			break;
		case InteractionOneofCase.UiPreviewAreaClearGroupsTrigger:
			if (UiPreviewAreaClearGroupsTrigger == null)
			{
				UiPreviewAreaClearGroupsTrigger = new PreviewAreaClearGroupsTrigger();
			}
			UiPreviewAreaClearGroupsTrigger.MergeFrom(other.UiPreviewAreaClearGroupsTrigger);
			break;
		case InteractionOneofCase.UiPreviewAreaClearGroupsChanged:
			if (UiPreviewAreaClearGroupsChanged == null)
			{
				UiPreviewAreaClearGroupsChanged = new PreviewAreaClearGroupsChanged();
			}
			UiPreviewAreaClearGroupsChanged.MergeFrom(other.UiPreviewAreaClearGroupsChanged);
			break;
		case InteractionOneofCase.UiPlaceholderLink:
			if (UiPlaceholderLink == null)
			{
				UiPlaceholderLink = new PlaceholderLink();
			}
			UiPlaceholderLink.MergeFrom(other.UiPlaceholderLink);
			break;
		case InteractionOneofCase.UiPlaceholderUnlink:
			if (UiPlaceholderUnlink == null)
			{
				UiPlaceholderUnlink = new PlaceholderUnlink();
			}
			UiPlaceholderUnlink.MergeFrom(other.UiPlaceholderUnlink);
			break;
		case InteractionOneofCase.UiPlanningCenterLive:
			if (UiPlanningCenterLive == null)
			{
				UiPlanningCenterLive = new PlanningCenterLive();
			}
			UiPlanningCenterLive.MergeFrom(other.UiPlanningCenterLive);
			break;
		case InteractionOneofCase.UiNetworkgroupAdd:
			if (UiNetworkgroupAdd == null)
			{
				UiNetworkgroupAdd = new NetworkGroupAdd();
			}
			UiNetworkgroupAdd.MergeFrom(other.UiNetworkgroupAdd);
			break;
		case InteractionOneofCase.UiNetworkgroupRemove:
			if (UiNetworkgroupRemove == null)
			{
				UiNetworkgroupRemove = new NetworkGroupRemove();
			}
			UiNetworkgroupRemove.MergeFrom(other.UiNetworkgroupRemove);
			break;
		case InteractionOneofCase.UiNetworkgroupLeave:
			if (UiNetworkgroupLeave == null)
			{
				UiNetworkgroupLeave = new NetworkGroupLeave();
			}
			UiNetworkgroupLeave.MergeFrom(other.UiNetworkgroupLeave);
			break;
		case InteractionOneofCase.UiCcliReportReset:
			if (UiCcliReportReset == null)
			{
				UiCcliReportReset = new CcliReportReset();
			}
			UiCcliReportReset.MergeFrom(other.UiCcliReportReset);
			break;
		case InteractionOneofCase.UiCcliReportShown:
			if (UiCcliReportShown == null)
			{
				UiCcliReportShown = new CcliReportShown();
			}
			UiCcliReportShown.MergeFrom(other.UiCcliReportShown);
			break;
		case InteractionOneofCase.UiCaptureShown:
			if (UiCaptureShown == null)
			{
				UiCaptureShown = new Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture();
			}
			UiCaptureShown.MergeFrom(other.UiCaptureShown);
			break;
		case InteractionOneofCase.UiWelcome:
			if (UiWelcome == null)
			{
				UiWelcome = new Welcome();
			}
			UiWelcome.MergeFrom(other.UiWelcome);
			break;
		case InteractionOneofCase.UiWelcomeScreenConfigurationHelp:
			if (UiWelcomeScreenConfigurationHelp == null)
			{
				UiWelcomeScreenConfigurationHelp = new WelcomeScreenConfigurationHelp();
			}
			UiWelcomeScreenConfigurationHelp.MergeFrom(other.UiWelcomeScreenConfigurationHelp);
			break;
		case InteractionOneofCase.UiWelcomeDownloadSampleContent:
			if (UiWelcomeDownloadSampleContent == null)
			{
				UiWelcomeDownloadSampleContent = new WelcomeDownloadSampleContent();
			}
			UiWelcomeDownloadSampleContent.MergeFrom(other.UiWelcomeDownloadSampleContent);
			break;
		case InteractionOneofCase.UiWelcomeUserGroup:
			if (UiWelcomeUserGroup == null)
			{
				UiWelcomeUserGroup = new WelcomeUserGroup();
			}
			UiWelcomeUserGroup.MergeFrom(other.UiWelcomeUserGroup);
			break;
		case InteractionOneofCase.UiWelcomeTutorials:
			if (UiWelcomeTutorials == null)
			{
				UiWelcomeTutorials = new WelcomeTutorials();
			}
			UiWelcomeTutorials.MergeFrom(other.UiWelcomeTutorials);
			break;
		case InteractionOneofCase.UiWelcomeKnowlegdeBase:
			if (UiWelcomeKnowlegdeBase == null)
			{
				UiWelcomeKnowlegdeBase = new WelcomeKnowledgeBase();
			}
			UiWelcomeKnowlegdeBase.MergeFrom(other.UiWelcomeKnowlegdeBase);
			break;
		case InteractionOneofCase.UiWelcomeBlog:
			if (UiWelcomeBlog == null)
			{
				UiWelcomeBlog = new WelcomeBlog();
			}
			UiWelcomeBlog.MergeFrom(other.UiWelcomeBlog);
			break;
		case InteractionOneofCase.UiWelcomeFacebook:
			if (UiWelcomeFacebook == null)
			{
				UiWelcomeFacebook = new WelcomeFacebook();
			}
			UiWelcomeFacebook.MergeFrom(other.UiWelcomeFacebook);
			break;
		case InteractionOneofCase.UiWelcomeInstagram:
			if (UiWelcomeInstagram == null)
			{
				UiWelcomeInstagram = new WelcomeInstagram();
			}
			UiWelcomeInstagram.MergeFrom(other.UiWelcomeInstagram);
			break;
		case InteractionOneofCase.UiWelcomeMigration:
			if (UiWelcomeMigration == null)
			{
				UiWelcomeMigration = new WelcomeMigration();
			}
			UiWelcomeMigration.MergeFrom(other.UiWelcomeMigration);
			break;
		case InteractionOneofCase.UiTestPatterns:
			if (UiTestPatterns == null)
			{
				UiTestPatterns = new TestPatterns();
			}
			UiTestPatterns.MergeFrom(other.UiTestPatterns);
			break;
		case InteractionOneofCase.UiSettingsCustomLogo:
			if (UiSettingsCustomLogo == null)
			{
				UiSettingsCustomLogo = new SettingsCustomLogo();
			}
			UiSettingsCustomLogo.MergeFrom(other.UiSettingsCustomLogo);
			break;
		case InteractionOneofCase.UiWindowedOutputCreated:
			if (UiWindowedOutputCreated == null)
			{
				UiWindowedOutputCreated = new WindowedOutputCreated();
			}
			UiWindowedOutputCreated.MergeFrom(other.UiWindowedOutputCreated);
			break;
		case InteractionOneofCase.ImportPowerpoint:
			if (ImportPowerpoint == null)
			{
				ImportPowerpoint = new ImportPowerPoint();
			}
			ImportPowerpoint.MergeFrom(other.ImportPowerpoint);
			break;
		case InteractionOneofCase.LibraryUsage:
			if (LibraryUsage == null)
			{
				LibraryUsage = new LibraryUsage();
			}
			LibraryUsage.MergeFrom(other.LibraryUsage);
			break;
		case InteractionOneofCase.FontReplacement:
			if (FontReplacement == null)
			{
				FontReplacement = new FontReplacement();
			}
			FontReplacement.MergeFrom(other.FontReplacement);
			break;
		case InteractionOneofCase.LogDocumentUploaded:
			if (LogDocumentUploaded == null)
			{
				LogDocumentUploaded = new LogDocumentUploaded();
			}
			LogDocumentUploaded.MergeFrom(other.LogDocumentUploaded);
			break;
		case InteractionOneofCase.LogDocumentDownloaded:
			if (LogDocumentDownloaded == null)
			{
				LogDocumentDownloaded = new LogDocumentDownloaded();
			}
			LogDocumentDownloaded.MergeFrom(other.LogDocumentDownloaded);
			break;
		case InteractionOneofCase.LogDiffPushed:
			if (LogDiffPushed == null)
			{
				LogDiffPushed = new LogDiffPushed();
			}
			LogDiffPushed.MergeFrom(other.LogDiffPushed);
			break;
		case InteractionOneofCase.LogDiffReceived:
			if (LogDiffReceived == null)
			{
				LogDiffReceived = new LogDiffReceived();
			}
			LogDiffReceived.MergeFrom(other.LogDiffReceived);
			break;
		case InteractionOneofCase.TriggerExternalPresentation:
			if (TriggerExternalPresentation == null)
			{
				TriggerExternalPresentation = new TriggerExternalPresentation();
			}
			TriggerExternalPresentation.MergeFrom(other.TriggerExternalPresentation);
			break;
		case InteractionOneofCase.WorkspaceCreation:
			if (WorkspaceCreation == null)
			{
				WorkspaceCreation = new WorkspaceCreation();
			}
			WorkspaceCreation.MergeFrom(other.WorkspaceCreation);
			break;
		case InteractionOneofCase.AvailableWorkspace:
			if (AvailableWorkspace == null)
			{
				AvailableWorkspace = new AvailableWorkspace();
			}
			AvailableWorkspace.MergeFrom(other.AvailableWorkspace);
			break;
		case InteractionOneofCase.OnboardingFlowOutcome:
			if (OnboardingFlowOutcome == null)
			{
				OnboardingFlowOutcome = new OnboardingFlowOutcome();
			}
			OnboardingFlowOutcome.MergeFrom(other.OnboardingFlowOutcome);
			break;
		case InteractionOneofCase.LogWorkspacesPublished:
			if (LogWorkspacesPublished == null)
			{
				LogWorkspacesPublished = new LogWorkspacesPublished();
			}
			LogWorkspacesPublished.MergeFrom(other.LogWorkspacesPublished);
			break;
		case InteractionOneofCase.LogCollaboratorsPublished:
			if (LogCollaboratorsPublished == null)
			{
				LogCollaboratorsPublished = new LogCollaboratorsPublished();
			}
			LogCollaboratorsPublished.MergeFrom(other.LogCollaboratorsPublished);
			break;
		case InteractionOneofCase.LogConvertToCloud:
			if (LogConvertToCloud == null)
			{
				LogConvertToCloud = new LogConvertToCloud();
			}
			LogConvertToCloud.MergeFrom(other.LogConvertToCloud);
			break;
		case InteractionOneofCase.LogConvertToLocal:
			if (LogConvertToLocal == null)
			{
				LogConvertToLocal = new LogConvertToLocal();
			}
			LogConvertToLocal.MergeFrom(other.LogConvertToLocal);
			break;
		case InteractionOneofCase.LogSyncingChange:
			if (LogSyncingChange == null)
			{
				LogSyncingChange = new LogSyncingChange();
			}
			LogSyncingChange.MergeFrom(other.LogSyncingChange);
			break;
		case InteractionOneofCase.LogDocumentStored:
			if (LogDocumentStored == null)
			{
				LogDocumentStored = new LogDocumentStored();
			}
			LogDocumentStored.MergeFrom(other.LogDocumentStored);
			break;
		case InteractionOneofCase.LogDocumentCreated:
			if (LogDocumentCreated == null)
			{
				LogDocumentCreated = new LogDocumentCreated();
			}
			LogDocumentCreated.MergeFrom(other.LogDocumentCreated);
			break;
		case InteractionOneofCase.LogDocumentUpdated:
			if (LogDocumentUpdated == null)
			{
				LogDocumentUpdated = new LogDocumentUpdated();
			}
			LogDocumentUpdated.MergeFrom(other.LogDocumentUpdated);
			break;
		case InteractionOneofCase.LogDocumentDeleted:
			if (LogDocumentDeleted == null)
			{
				LogDocumentDeleted = new LogDocumentDeleted();
			}
			LogDocumentDeleted.MergeFrom(other.LogDocumentDeleted);
			break;
		case InteractionOneofCase.LogDocumentConflict:
			if (LogDocumentConflict == null)
			{
				LogDocumentConflict = new LogDocumentConflict();
			}
			LogDocumentConflict.MergeFrom(other.LogDocumentConflict);
			break;
		case InteractionOneofCase.LogWorkspaceResynchronized:
			if (LogWorkspaceResynchronized == null)
			{
				LogWorkspaceResynchronized = new LogWorkspaceResynchronized();
			}
			LogWorkspaceResynchronized.MergeFrom(other.LogWorkspaceResynchronized);
			break;
		case InteractionOneofCase.LogWsConnectionFailed:
			if (LogWsConnectionFailed == null)
			{
				LogWsConnectionFailed = new WebSocketConnectionFailed();
			}
			LogWsConnectionFailed.MergeFrom(other.LogWsConnectionFailed);
			break;
		case InteractionOneofCase.LogError:
			if (LogError == null)
			{
				LogError = new LogError();
			}
			LogError.MergeFrom(other.LogError);
			break;
		case InteractionOneofCase.UserWorkspaceTreeModification:
			if (UserWorkspaceTreeModification == null)
			{
				UserWorkspaceTreeModification = new UserWorkspaceTreeModification();
			}
			UserWorkspaceTreeModification.MergeFrom(other.UserWorkspaceTreeModification);
			break;
		case InteractionOneofCase.UiActivationFlowOpened:
			if (UiActivationFlowOpened == null)
			{
				UiActivationFlowOpened = new ActivationFlowOpened();
			}
			UiActivationFlowOpened.MergeFrom(other.UiActivationFlowOpened);
			break;
		case InteractionOneofCase.LogOpenedWorkspace:
			if (LogOpenedWorkspace == null)
			{
				LogOpenedWorkspace = new LogOpenedWorkspace();
			}
			LogOpenedWorkspace.MergeFrom(other.LogOpenedWorkspace);
			break;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 10u:
			{
				MessageReceived messageReceived = new MessageReceived();
				if (interactionCase_ == InteractionOneofCase.ApiMessageReceived)
				{
					messageReceived.MergeFrom(ApiMessageReceived);
				}
				input.ReadMessage(messageReceived);
				ApiMessageReceived = messageReceived;
				break;
			}
			case 18u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Create.Library library = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Library();
				if (interactionCase_ == InteractionOneofCase.CreateLibrary)
				{
					library.MergeFrom(CreateLibrary);
				}
				input.ReadMessage(library);
				CreateLibrary = library;
				break;
			}
			case 26u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Create.Playlist playlist = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Playlist();
				if (interactionCase_ == InteractionOneofCase.CreatePlaylist)
				{
					playlist.MergeFrom(CreatePlaylist);
				}
				input.ReadMessage(playlist);
				CreatePlaylist = playlist;
				break;
			}
			case 34u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation presentation = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation();
				if (interactionCase_ == InteractionOneofCase.CreatePresentation)
				{
					presentation.MergeFrom(CreatePresentation);
				}
				input.ReadMessage(presentation);
				CreatePresentation = presentation;
				break;
			}
			case 42u:
			{
				TemplatePlaylist templatePlaylist = new TemplatePlaylist();
				if (interactionCase_ == InteractionOneofCase.CreateFromTemplatePlaylist)
				{
					templatePlaylist.MergeFrom(CreateFromTemplatePlaylist);
				}
				input.ReadMessage(templatePlaylist);
				CreateFromTemplatePlaylist = templatePlaylist;
				break;
			}
			case 50u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Edit.Presentation presentation2 = new Pro.SerializationInterop.RVProtoData.Analytics.Edit.Presentation();
				if (interactionCase_ == InteractionOneofCase.EditPresentation)
				{
					presentation2.MergeFrom(EditPresentation);
				}
				input.ReadMessage(presentation2);
				EditPresentation = presentation2;
				break;
			}
			case 58u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect songSelect = new Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect();
				if (interactionCase_ == InteractionOneofCase.ImportSongselect)
				{
					songSelect.MergeFrom(ImportSongselect);
				}
				input.ReadMessage(songSelect);
				ImportSongselect = songSelect;
				break;
			}
			case 66u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import import = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import();
				if (interactionCase_ == InteractionOneofCase.ImportMultitracks)
				{
					import.MergeFrom(ImportMultitracks);
				}
				input.ReadMessage(import);
				ImportMultitracks = import;
				break;
			}
			case 74u:
			{
				MediaBinView mediaBinView = new MediaBinView();
				if (interactionCase_ == InteractionOneofCase.ProcontentMediabinView)
				{
					mediaBinView.MergeFrom(ProcontentMediabinView);
				}
				input.ReadMessage(mediaBinView);
				ProcontentMediabinView = mediaBinView;
				break;
			}
			case 82u:
			{
				Download download = new Download();
				if (interactionCase_ == InteractionOneofCase.ProcontentDownload)
				{
					download.MergeFrom(ProcontentDownload);
				}
				input.ReadMessage(download);
				ProcontentDownload = download;
				break;
			}
			case 90u:
			{
				DownloadRetry downloadRetry = new DownloadRetry();
				if (interactionCase_ == InteractionOneofCase.ProcontentDownloadRetry)
				{
					downloadRetry.MergeFrom(ProcontentDownloadRetry);
				}
				input.ReadMessage(downloadRetry);
				ProcontentDownloadRetry = downloadRetry;
				break;
			}
			case 98u:
			{
				CreateMarker createMarker = new CreateMarker();
				if (interactionCase_ == InteractionOneofCase.PlaybackMarker)
				{
					createMarker.MergeFrom(PlaybackMarker);
				}
				input.ReadMessage(createMarker);
				PlaybackMarker = createMarker;
				break;
			}
			case 106u:
			{
				Looks looks = new Looks();
				if (interactionCase_ == InteractionOneofCase.StartupLooks)
				{
					looks.MergeFrom(StartupLooks);
				}
				input.ReadMessage(looks);
				StartupLooks = looks;
				break;
			}
			case 114u:
			{
				Summary summary = new Summary();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfiguration)
				{
					summary.MergeFrom(StartupScreenConfiguration);
				}
				input.ReadMessage(summary);
				StartupScreenConfiguration = summary;
				break;
			}
			case 122u:
			{
				Output output = new Output();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationScreen)
				{
					output.MergeFrom(StartupScreenConfigurationScreen);
				}
				input.ReadMessage(output);
				StartupScreenConfigurationScreen = output;
				break;
			}
			case 130u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.Single single = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Single();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationSingleScreen)
				{
					single.MergeFrom(StartupScreenConfigurationSingleScreen);
				}
				input.ReadMessage(single);
				StartupScreenConfigurationSingleScreen = single;
				break;
			}
			case 138u:
			{
				Mirrored mirrored = new Mirrored();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationMirroredScreen)
				{
					mirrored.MergeFrom(StartupScreenConfigurationMirroredScreen);
				}
				input.ReadMessage(mirrored);
				StartupScreenConfigurationMirroredScreen = mirrored;
				break;
			}
			case 146u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.EdgeBlend edgeBlend = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.EdgeBlend();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationEdgeBlendScreen)
				{
					edgeBlend.MergeFrom(StartupScreenConfigurationEdgeBlendScreen);
				}
				input.ReadMessage(edgeBlend);
				StartupScreenConfigurationEdgeBlendScreen = edgeBlend;
				break;
			}
			case 154u:
			{
				Grouped grouped = new Grouped();
				if (interactionCase_ == InteractionOneofCase.StartupScreenConfigurationGroupedScreen)
				{
					grouped.MergeFrom(StartupScreenConfigurationGroupedScreen);
				}
				input.ReadMessage(grouped);
				StartupScreenConfigurationGroupedScreen = grouped;
				break;
			}
			case 162u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.Preferences preferences = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Preferences();
				if (interactionCase_ == InteractionOneofCase.StartupPreferences)
				{
					preferences.MergeFrom(StartupPreferences);
				}
				input.ReadMessage(preferences);
				StartupPreferences = preferences;
				break;
			}
			case 170u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect songSelect2 = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.SongSelect();
				if (interactionCase_ == InteractionOneofCase.StartupSongselect)
				{
					songSelect2.MergeFrom(StartupSongselect);
				}
				input.ReadMessage(songSelect2);
				StartupSongselect = songSelect2;
				break;
			}
			case 178u:
			{
				Content content = new Content();
				if (interactionCase_ == InteractionOneofCase.StartupContent)
				{
					content.MergeFrom(StartupContent);
				}
				input.ReadMessage(content);
				StartupContent = content;
				break;
			}
			case 186u:
			{
				Themes themes = new Themes();
				if (interactionCase_ == InteractionOneofCase.StartupThemes)
				{
					themes.MergeFrom(StartupThemes);
				}
				input.ReadMessage(themes);
				StartupThemes = themes;
				break;
			}
			case 194u:
			{
				Macro macro = new Macro();
				if (interactionCase_ == InteractionOneofCase.StartupMacro)
				{
					macro.MergeFrom(StartupMacro);
				}
				input.ReadMessage(macro);
				StartupMacro = macro;
				break;
			}
			case 202u:
			{
				ClearGroup clearGroup = new ClearGroup();
				if (interactionCase_ == InteractionOneofCase.StartupClearGroup)
				{
					clearGroup.MergeFrom(StartupClearGroup);
				}
				input.ReadMessage(clearGroup);
				StartupClearGroup = clearGroup;
				break;
			}
			case 210u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.KeyMapping keyMapping = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.KeyMapping();
				if (interactionCase_ == InteractionOneofCase.StartupKeyMapping)
				{
					keyMapping.MergeFrom(StartupKeyMapping);
				}
				input.ReadMessage(keyMapping);
				StartupKeyMapping = keyMapping;
				break;
			}
			case 218u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Startup startup = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Startup();
				if (interactionCase_ == InteractionOneofCase.StartupMultitracks)
				{
					startup.MergeFrom(StartupMultitracks);
				}
				input.ReadMessage(startup);
				StartupMultitracks = startup;
				break;
			}
			case 226u:
			{
				NetworkLink networkLink = new NetworkLink();
				if (interactionCase_ == InteractionOneofCase.StartupNetworkLink)
				{
					networkLink.MergeFrom(StartupNetworkLink);
				}
				input.ReadMessage(networkLink);
				StartupNetworkLink = networkLink;
				break;
			}
			case 234u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture capture2 = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture();
				if (interactionCase_ == InteractionOneofCase.StartupCapture)
				{
					capture2.MergeFrom(StartupCapture);
				}
				input.ReadMessage(capture2);
				StartupCapture = capture2;
				break;
			}
			case 242u:
			{
				Versioning versioning = new Versioning();
				if (interactionCase_ == InteractionOneofCase.StartupVersioning)
				{
					versioning.MergeFrom(StartupVersioning);
				}
				input.ReadMessage(versioning);
				StartupVersioning = versioning;
				break;
			}
			case 250u:
			{
				DiskUsage diskUsage = new DiskUsage();
				if (interactionCase_ == InteractionOneofCase.StartupDiskUsage)
				{
					diskUsage.MergeFrom(StartupDiskUsage);
				}
				input.ReadMessage(diskUsage);
				StartupDiskUsage = diskUsage;
				break;
			}
			case 258u:
			{
				Interface @interface = new Interface();
				if (interactionCase_ == InteractionOneofCase.StartupInterface)
				{
					@interface.MergeFrom(StartupInterface);
				}
				input.ReadMessage(@interface);
				StartupInterface = @interface;
				break;
			}
			case 266u:
			{
				Local local = new Local();
				if (interactionCase_ == InteractionOneofCase.SyncLocal)
				{
					local.MergeFrom(SyncLocal);
				}
				input.ReadMessage(local);
				SyncLocal = local;
				break;
			}
			case 274u:
			{
				Activate activate = new Activate();
				if (interactionCase_ == InteractionOneofCase.TimecodeActivate)
				{
					activate.MergeFrom(TimecodeActivate);
				}
				input.ReadMessage(activate);
				TimecodeActivate = activate;
				break;
			}
			case 282u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Timecode.Startup startup2 = new Pro.SerializationInterop.RVProtoData.Analytics.Timecode.Startup();
				if (interactionCase_ == InteractionOneofCase.TimecodeStartup)
				{
					startup2.MergeFrom(TimecodeStartup);
				}
				input.ReadMessage(startup2);
				TimecodeStartup = startup2;
				break;
			}
			case 290u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action action = new Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action();
				if (interactionCase_ == InteractionOneofCase.TimelineAction)
				{
					action.MergeFrom(TimelineAction);
				}
				input.ReadMessage(action);
				TimelineAction = action;
				break;
			}
			case 298u:
			{
				RecordCue recordCue = new RecordCue();
				if (interactionCase_ == InteractionOneofCase.TimelineRecordCue)
				{
					recordCue.MergeFrom(TimelineRecordCue);
				}
				input.ReadMessage(recordCue);
				TimelineRecordCue = recordCue;
				break;
			}
			case 306u:
			{
				CueTrigger cueTrigger = new CueTrigger();
				if (interactionCase_ == InteractionOneofCase.TimelineCueTrigger)
				{
					cueTrigger.MergeFrom(TimelineCueTrigger);
				}
				input.ReadMessage(cueTrigger);
				TimelineCueTrigger = cueTrigger;
				break;
			}
			case 402u:
			{
				ApplicationLaunch applicationLaunch = new ApplicationLaunch();
				if (interactionCase_ == InteractionOneofCase.ApplicationLaunch)
				{
					applicationLaunch.MergeFrom(ApplicationLaunch);
				}
				input.ReadMessage(applicationLaunch);
				ApplicationLaunch = applicationLaunch;
				break;
			}
			case 410u:
			{
				VideoInputTriggered videoInputTriggered = new VideoInputTriggered();
				if (interactionCase_ == InteractionOneofCase.VideoInputTriggered)
				{
					videoInputTriggered.MergeFrom(VideoInputTriggered);
				}
				input.ReadMessage(videoInputTriggered);
				VideoInputTriggered = videoInputTriggered;
				break;
			}
			case 418u:
			{
				VideoInputCustomMap videoInputCustomMap = new VideoInputCustomMap();
				if (interactionCase_ == InteractionOneofCase.VideoInputCustomMap)
				{
					videoInputCustomMap.MergeFrom(VideoInputCustomMap);
				}
				input.ReadMessage(videoInputCustomMap);
				VideoInputCustomMap = videoInputCustomMap;
				break;
			}
			case 426u:
			{
				VideoInputStartUp videoInputStartUp = new VideoInputStartUp();
				if (interactionCase_ == InteractionOneofCase.VideoInputStartUp)
				{
					videoInputStartUp.MergeFrom(VideoInputStartUp);
				}
				input.ReadMessage(videoInputStartUp);
				VideoInputStartUp = videoInputStartUp;
				break;
			}
			case 434u:
			{
				VideoInputThumbnailUpdate videoInputThumbnailUpdate = new VideoInputThumbnailUpdate();
				if (interactionCase_ == InteractionOneofCase.VideoInputThumbnailUpdate)
				{
					videoInputThumbnailUpdate.MergeFrom(VideoInputThumbnailUpdate);
				}
				input.ReadMessage(videoInputThumbnailUpdate);
				VideoInputThumbnailUpdate = videoInputThumbnailUpdate;
				break;
			}
			case 442u:
			{
				AudioInputAutoOnChange audioInputAutoOnChange = new AudioInputAutoOnChange();
				if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnChange)
				{
					audioInputAutoOnChange.MergeFrom(AudioInputAutoOnChange);
				}
				input.ReadMessage(audioInputAutoOnChange);
				AudioInputAutoOnChange = audioInputAutoOnChange;
				break;
			}
			case 450u:
			{
				AudioSettingsSdiNdiActive audioSettingsSdiNdiActive = new AudioSettingsSdiNdiActive();
				if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiActive)
				{
					audioSettingsSdiNdiActive.MergeFrom(AudioSettingsSdiNdiActive);
				}
				input.ReadMessage(audioSettingsSdiNdiActive);
				AudioSettingsSdiNdiActive = audioSettingsSdiNdiActive;
				break;
			}
			case 458u:
			{
				AudioSettingsCustomMap audioSettingsCustomMap = new AudioSettingsCustomMap();
				if (interactionCase_ == InteractionOneofCase.AudioSettingsCustomMap)
				{
					audioSettingsCustomMap.MergeFrom(AudioSettingsCustomMap);
				}
				input.ReadMessage(audioSettingsCustomMap);
				AudioSettingsCustomMap = audioSettingsCustomMap;
				break;
			}
			case 466u:
			{
				AudioInputModeSelection audioInputModeSelection = new AudioInputModeSelection();
				if (interactionCase_ == InteractionOneofCase.AudioInputModeSelection)
				{
					audioInputModeSelection.MergeFrom(AudioInputModeSelection);
				}
				input.ReadMessage(audioInputModeSelection);
				AudioInputModeSelection = audioInputModeSelection;
				break;
			}
			case 474u:
			{
				AudioInputAutoOnStartup audioInputAutoOnStartup = new AudioInputAutoOnStartup();
				if (interactionCase_ == InteractionOneofCase.AudioInputAutoOnStartup)
				{
					audioInputAutoOnStartup.MergeFrom(AudioInputAutoOnStartup);
				}
				input.ReadMessage(audioInputAutoOnStartup);
				AudioInputAutoOnStartup = audioInputAutoOnStartup;
				break;
			}
			case 482u:
			{
				AudioSettingsSdiNdiState audioSettingsSdiNdiState = new AudioSettingsSdiNdiState();
				if (interactionCase_ == InteractionOneofCase.AudioSettingsSdiNdiState)
				{
					audioSettingsSdiNdiState.MergeFrom(AudioSettingsSdiNdiState);
				}
				input.ReadMessage(audioSettingsSdiNdiState);
				AudioSettingsSdiNdiState = audioSettingsSdiNdiState;
				break;
			}
			case 490u:
			{
				AudioInputStartUp audioInputStartUp = new AudioInputStartUp();
				if (interactionCase_ == InteractionOneofCase.AudioInputStartUp)
				{
					audioInputStartUp.MergeFrom(AudioInputStartUp);
				}
				input.ReadMessage(audioInputStartUp);
				AudioInputStartUp = audioInputStartUp;
				break;
			}
			case 498u:
			{
				CueTriggered cueTriggered = new CueTriggered();
				if (interactionCase_ == InteractionOneofCase.CueTriggered)
				{
					cueTriggered.MergeFrom(CueTriggered);
				}
				input.ReadMessage(cueTriggered);
				CueTriggered = cueTriggered;
				break;
			}
			case 506u:
			{
				InputAudioMonitoring inputAudioMonitoring = new InputAudioMonitoring();
				if (interactionCase_ == InteractionOneofCase.InputAudioMonitoring)
				{
					inputAudioMonitoring.MergeFrom(InputAudioMonitoring);
				}
				input.ReadMessage(inputAudioMonitoring);
				InputAudioMonitoring = inputAudioMonitoring;
				break;
			}
			case 514u:
			{
				ResiStartUp resiStartUp = new ResiStartUp();
				if (interactionCase_ == InteractionOneofCase.ResiStartUp)
				{
					resiStartUp.MergeFrom(ResiStartUp);
				}
				input.ReadMessage(resiStartUp);
				ResiStartUp = resiStartUp;
				break;
			}
			case 522u:
			{
				ResiLoginChange resiLoginChange = new ResiLoginChange();
				if (interactionCase_ == InteractionOneofCase.ResiLoginChange)
				{
					resiLoginChange.MergeFrom(ResiLoginChange);
				}
				input.ReadMessage(resiLoginChange);
				ResiLoginChange = resiLoginChange;
				break;
			}
			case 530u:
			{
				RemoteStreamStart remoteStreamStart = new RemoteStreamStart();
				if (interactionCase_ == InteractionOneofCase.RemoteStreamStart)
				{
					remoteStreamStart.MergeFrom(RemoteStreamStart);
				}
				input.ReadMessage(remoteStreamStart);
				RemoteStreamStart = remoteStreamStart;
				break;
			}
			case 538u:
			{
				RemoteStreamStop remoteStreamStop = new RemoteStreamStop();
				if (interactionCase_ == InteractionOneofCase.RemoteStreamStop)
				{
					remoteStreamStop.MergeFrom(RemoteStreamStop);
				}
				input.ReadMessage(remoteStreamStop);
				RemoteStreamStop = remoteStreamStop;
				break;
			}
			case 546u:
			{
				StartCaptureDisk startCaptureDisk = new StartCaptureDisk();
				if (interactionCase_ == InteractionOneofCase.StartCaptureDisk)
				{
					startCaptureDisk.MergeFrom(StartCaptureDisk);
				}
				input.ReadMessage(startCaptureDisk);
				StartCaptureDisk = startCaptureDisk;
				break;
			}
			case 554u:
			{
				StartCaptureRtmp startCaptureRtmp = new StartCaptureRtmp();
				if (interactionCase_ == InteractionOneofCase.StartCaptureRtmp)
				{
					startCaptureRtmp.MergeFrom(StartCaptureRtmp);
				}
				input.ReadMessage(startCaptureRtmp);
				StartCaptureRtmp = startCaptureRtmp;
				break;
			}
			case 562u:
			{
				StartCaptureResi startCaptureResi = new StartCaptureResi();
				if (interactionCase_ == InteractionOneofCase.StartCaptureResi)
				{
					startCaptureResi.MergeFrom(StartCaptureResi);
				}
				input.ReadMessage(startCaptureResi);
				StartCaptureResi = startCaptureResi;
				break;
			}
			case 570u:
			{
				StopCapture stopCapture = new StopCapture();
				if (interactionCase_ == InteractionOneofCase.StopCapture)
				{
					stopCapture.MergeFrom(StopCapture);
				}
				input.ReadMessage(stopCapture);
				StopCapture = stopCapture;
				break;
			}
			case 578u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.GenericEvent genericEvent = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.GenericEvent();
				if (interactionCase_ == InteractionOneofCase.AnalyticReset)
				{
					genericEvent.MergeFrom(AnalyticReset);
				}
				input.ReadMessage(genericEvent);
				AnalyticReset = genericEvent;
				break;
			}
			case 586u:
			{
				Print print = new Print();
				if (interactionCase_ == InteractionOneofCase.Print)
				{
					print.MergeFrom(Print);
				}
				input.ReadMessage(print);
				Print = print;
				break;
			}
			case 594u:
			{
				Device device = new Device();
				if (interactionCase_ == InteractionOneofCase.Device)
				{
					device.MergeFrom(Device);
				}
				input.ReadMessage(device);
				Device = device;
				break;
			}
			case 602u:
			{
				Downgrade downgrade = new Downgrade();
				if (interactionCase_ == InteractionOneofCase.Downgrade)
				{
					downgrade.MergeFrom(Downgrade);
				}
				input.ReadMessage(downgrade);
				Downgrade = downgrade;
				break;
			}
			case 610u:
			{
				CCLIReport cCLIReport = new CCLIReport();
				if (interactionCase_ == InteractionOneofCase.CcliReport)
				{
					cCLIReport.MergeFrom(CcliReport);
				}
				input.ReadMessage(cCLIReport);
				CcliReport = cCLIReport;
				break;
			}
			case 618u:
			{
				TransitionWindow transitionWindow = new TransitionWindow();
				if (interactionCase_ == InteractionOneofCase.TransitionWindow)
				{
					transitionWindow.MergeFrom(TransitionWindow);
				}
				input.ReadMessage(transitionWindow);
				TransitionWindow = transitionWindow;
				break;
			}
			case 626u:
			{
				EditorObjectAdded editorObjectAdded = new EditorObjectAdded();
				if (interactionCase_ == InteractionOneofCase.EditorObjectAdded)
				{
					editorObjectAdded.MergeFrom(EditorObjectAdded);
				}
				input.ReadMessage(editorObjectAdded);
				EditorObjectAdded = editorObjectAdded;
				break;
			}
			case 634u:
			{
				DataIdDuplicated dataIdDuplicated = new DataIdDuplicated();
				if (interactionCase_ == InteractionOneofCase.DataIdDuplicated)
				{
					dataIdDuplicated.MergeFrom(DataIdDuplicated);
				}
				input.ReadMessage(dataIdDuplicated);
				DataIdDuplicated = dataIdDuplicated;
				break;
			}
			case 642u:
			{
				ForceQuit forceQuit = new ForceQuit();
				if (interactionCase_ == InteractionOneofCase.ForceQuit)
				{
					forceQuit.MergeFrom(ForceQuit);
				}
				input.ReadMessage(forceQuit);
				ForceQuit = forceQuit;
				break;
			}
			case 650u:
			{
				MediaCleanupSize mediaCleanupSize = new MediaCleanupSize();
				if (interactionCase_ == InteractionOneofCase.MediaCleanupSize)
				{
					mediaCleanupSize.MergeFrom(MediaCleanupSize);
				}
				input.ReadMessage(mediaCleanupSize);
				MediaCleanupSize = mediaCleanupSize;
				break;
			}
			case 658u:
			{
				NetworkApp networkApp = new NetworkApp();
				if (interactionCase_ == InteractionOneofCase.NetworkApp)
				{
					networkApp.MergeFrom(NetworkApp);
				}
				input.ReadMessage(networkApp);
				NetworkApp = networkApp;
				break;
			}
			case 666u:
			{
				LocalWorkspaceStats localWorkspaceStats = new LocalWorkspaceStats();
				if (interactionCase_ == InteractionOneofCase.LocalWorkspaceStats)
				{
					localWorkspaceStats.MergeFrom(LocalWorkspaceStats);
				}
				input.ReadMessage(localWorkspaceStats);
				LocalWorkspaceStats = localWorkspaceStats;
				break;
			}
			case 674u:
			{
				SyncingUnpaused syncingUnpaused = new SyncingUnpaused();
				if (interactionCase_ == InteractionOneofCase.SyncingUnpaused)
				{
					syncingUnpaused.MergeFrom(SyncingUnpaused);
				}
				input.ReadMessage(syncingUnpaused);
				SyncingUnpaused = syncingUnpaused;
				break;
			}
			case 802u:
			{
				ActionCaptureStart actionCaptureStart = new ActionCaptureStart();
				if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStart)
				{
					actionCaptureStart.MergeFrom(TriggerActionCaptureStart);
				}
				input.ReadMessage(actionCaptureStart);
				TriggerActionCaptureStart = actionCaptureStart;
				break;
			}
			case 810u:
			{
				ActionCaptureStop actionCaptureStop = new ActionCaptureStop();
				if (interactionCase_ == InteractionOneofCase.TriggerActionCaptureStop)
				{
					actionCaptureStop.MergeFrom(TriggerActionCaptureStop);
				}
				input.ReadMessage(actionCaptureStop);
				TriggerActionCaptureStop = actionCaptureStop;
				break;
			}
			case 818u:
			{
				ActionClear actionClear = new ActionClear();
				if (interactionCase_ == InteractionOneofCase.TriggerActionClear)
				{
					actionClear.MergeFrom(TriggerActionClear);
				}
				input.ReadMessage(actionClear);
				TriggerActionClear = actionClear;
				break;
			}
			case 826u:
			{
				ActionClearGroup actionClearGroup = new ActionClearGroup();
				if (interactionCase_ == InteractionOneofCase.TriggerActionClearGroup)
				{
					actionClearGroup.MergeFrom(TriggerActionClearGroup);
				}
				input.ReadMessage(actionClearGroup);
				TriggerActionClearGroup = actionClearGroup;
				break;
			}
			case 834u:
			{
				ActionCommunications actionCommunications = new ActionCommunications();
				if (interactionCase_ == InteractionOneofCase.TriggerActionCommunications)
				{
					actionCommunications.MergeFrom(TriggerActionCommunications);
				}
				input.ReadMessage(actionCommunications);
				TriggerActionCommunications = actionCommunications;
				break;
			}
			case 842u:
			{
				ActionLook actionLook = new ActionLook();
				if (interactionCase_ == InteractionOneofCase.TriggerActionLook)
				{
					actionLook.MergeFrom(TriggerActionLook);
				}
				input.ReadMessage(actionLook);
				TriggerActionLook = actionLook;
				break;
			}
			case 850u:
			{
				ActionMacro actionMacro = new ActionMacro();
				if (interactionCase_ == InteractionOneofCase.TriggerActionMacro)
				{
					actionMacro.MergeFrom(TriggerActionMacro);
				}
				input.ReadMessage(actionMacro);
				TriggerActionMacro = actionMacro;
				break;
			}
			case 858u:
			{
				ActionMessage actionMessage = new ActionMessage();
				if (interactionCase_ == InteractionOneofCase.TriggerActionMessage)
				{
					actionMessage.MergeFrom(TriggerActionMessage);
				}
				input.ReadMessage(actionMessage);
				TriggerActionMessage = actionMessage;
				break;
			}
			case 866u:
			{
				ActionProp actionProp = new ActionProp();
				if (interactionCase_ == InteractionOneofCase.TriggerActionProp)
				{
					actionProp.MergeFrom(TriggerActionProp);
				}
				input.ReadMessage(actionProp);
				TriggerActionProp = actionProp;
				break;
			}
			case 874u:
			{
				ActionSlideDestination actionSlideDestination = new ActionSlideDestination();
				if (interactionCase_ == InteractionOneofCase.TriggerActionSlideDestination)
				{
					actionSlideDestination.MergeFrom(TriggerActionSlideDestination);
				}
				input.ReadMessage(actionSlideDestination);
				TriggerActionSlideDestination = actionSlideDestination;
				break;
			}
			case 882u:
			{
				ActionStage actionStage = new ActionStage();
				if (interactionCase_ == InteractionOneofCase.TriggerActionStage)
				{
					actionStage.MergeFrom(TriggerActionStage);
				}
				input.ReadMessage(actionStage);
				TriggerActionStage = actionStage;
				break;
			}
			case 890u:
			{
				ActionTimer actionTimer = new ActionTimer();
				if (interactionCase_ == InteractionOneofCase.TriggerActionTimer)
				{
					actionTimer.MergeFrom(TriggerActionTimer);
				}
				input.ReadMessage(actionTimer);
				TriggerActionTimer = actionTimer;
				break;
			}
			case 898u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.Audio audio = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.Audio();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaAudio)
				{
					audio.MergeFrom(TriggerMediaAudio);
				}
				input.ReadMessage(audio);
				TriggerMediaAudio = audio;
				break;
			}
			case 906u:
			{
				Image image = new Image();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaImage)
				{
					image.MergeFrom(TriggerMediaImage);
				}
				input.ReadMessage(image);
				TriggerMediaImage = image;
				break;
			}
			case 914u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.VideoInput videoInput = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media.VideoInput();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaVideoInput)
				{
					videoInput.MergeFrom(TriggerMediaVideoInput);
				}
				input.ReadMessage(videoInput);
				TriggerMediaVideoInput = videoInput;
				break;
			}
			case 922u:
			{
				Video video = new Video();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaVideo)
				{
					video.MergeFrom(TriggerMediaVideo);
				}
				input.ReadMessage(video);
				TriggerMediaVideo = video;
				break;
			}
			case 930u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue.Slide slide = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue.Slide();
				if (interactionCase_ == InteractionOneofCase.TriggerCueSlide)
				{
					slide.MergeFrom(TriggerCueSlide);
				}
				input.ReadMessage(slide);
				TriggerCueSlide = slide;
				break;
			}
			case 938u:
			{
				SlideFileFeedElement slideFileFeedElement = new SlideFileFeedElement();
				if (interactionCase_ == InteractionOneofCase.TriggerCueSlideFileFeedElement)
				{
					slideFileFeedElement.MergeFrom(TriggerCueSlideFileFeedElement);
				}
				input.ReadMessage(slideFileFeedElement);
				TriggerCueSlideFileFeedElement = slideFileFeedElement;
				break;
			}
			case 946u:
			{
				SlideRssFeedElement slideRssFeedElement = new SlideRssFeedElement();
				if (interactionCase_ == InteractionOneofCase.TriggerCueSlideRssFeedElement)
				{
					slideRssFeedElement.MergeFrom(TriggerCueSlideRssFeedElement);
				}
				input.ReadMessage(slideRssFeedElement);
				TriggerCueSlideRssFeedElement = slideRssFeedElement;
				break;
			}
			case 954u:
			{
				SlideScrollingTextElement slideScrollingTextElement = new SlideScrollingTextElement();
				if (interactionCase_ == InteractionOneofCase.TriggerCueSlideScrollingTextElement)
				{
					slideScrollingTextElement.MergeFrom(TriggerCueSlideScrollingTextElement);
				}
				input.ReadMessage(slideScrollingTextElement);
				TriggerCueSlideScrollingTextElement = slideScrollingTextElement;
				break;
			}
			case 962u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.Trigger.TestPattern testPattern = new Pro.SerializationInterop.RVProtoData.Analytics.Trigger.TestPattern();
				if (interactionCase_ == InteractionOneofCase.TriggerTestPattern)
				{
					testPattern.MergeFrom(TriggerTestPattern);
				}
				input.ReadMessage(testPattern);
				TriggerTestPattern = testPattern;
				break;
			}
			case 970u:
			{
				AirCastVideo airCastVideo2 = new AirCastVideo();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastVideo)
				{
					airCastVideo2.MergeFrom(TriggerMediaAircastVideo);
				}
				input.ReadMessage(airCastVideo2);
				TriggerMediaAircastVideo = airCastVideo2;
				break;
			}
			case 978u:
			{
				AirCastAudio airCastAudio = new AirCastAudio();
				if (interactionCase_ == InteractionOneofCase.TriggerMediaAircastAudio)
				{
					airCastAudio.MergeFrom(TriggerMediaAircastAudio);
				}
				input.ReadMessage(airCastAudio);
				TriggerMediaAircastAudio = airCastAudio;
				break;
			}
			case 986u:
			{
				AirCastVideo airCastVideo = new AirCastVideo();
				if (interactionCase_ == InteractionOneofCase.AircastVideoInputConfigured)
				{
					airCastVideo.MergeFrom(AircastVideoInputConfigured);
				}
				input.ReadMessage(airCastVideo);
				AircastVideoInputConfigured = airCastVideo;
				break;
			}
			case 994u:
			{
				AirCastAudio airCastAudio2 = new AirCastAudio();
				if (interactionCase_ == InteractionOneofCase.AircastAudioInputConfigured)
				{
					airCastAudio2.MergeFrom(AircastAudioInputConfigured);
				}
				input.ReadMessage(airCastAudio2);
				AircastAudioInputConfigured = airCastAudio2;
				break;
			}
			case 1122u:
			{
				InstallationComplete installationComplete = new InstallationComplete();
				if (interactionCase_ == InteractionOneofCase.MediaManagementInstallationComplete)
				{
					installationComplete.MergeFrom(MediaManagementInstallationComplete);
				}
				input.ReadMessage(installationComplete);
				MediaManagementInstallationComplete = installationComplete;
				break;
			}
			case 1130u:
			{
				BootstrappingComplete bootstrappingComplete = new BootstrappingComplete();
				if (interactionCase_ == InteractionOneofCase.MediaManagementBootstrappingComplete)
				{
					bootstrappingComplete.MergeFrom(MediaManagementBootstrappingComplete);
				}
				input.ReadMessage(bootstrappingComplete);
				MediaManagementBootstrappingComplete = bootstrappingComplete;
				break;
			}
			case 1138u:
			{
				MessageFailure messageFailure = new MessageFailure();
				if (interactionCase_ == InteractionOneofCase.MediaManagementMessageFailure)
				{
					messageFailure.MergeFrom(MediaManagementMessageFailure);
				}
				input.ReadMessage(messageFailure);
				MediaManagementMessageFailure = messageFailure;
				break;
			}
			case 1146u:
			{
				UnexpectedlyNotRunning unexpectedlyNotRunning = new UnexpectedlyNotRunning();
				if (interactionCase_ == InteractionOneofCase.MediaManagementUnexpectedlyNotRunning)
				{
					unexpectedlyNotRunning.MergeFrom(MediaManagementUnexpectedlyNotRunning);
				}
				input.ReadMessage(unexpectedlyNotRunning);
				MediaManagementUnexpectedlyNotRunning = unexpectedlyNotRunning;
				break;
			}
			case 1154u:
			{
				ConnectionChanged connectionChanged = new ConnectionChanged();
				if (interactionCase_ == InteractionOneofCase.MediaManagementConnectionChanged)
				{
					connectionChanged.MergeFrom(MediaManagementConnectionChanged);
				}
				input.ReadMessage(connectionChanged);
				MediaManagementConnectionChanged = connectionChanged;
				break;
			}
			case 1162u:
			{
				AddedMediaReference addedMediaReference = new AddedMediaReference();
				if (interactionCase_ == InteractionOneofCase.MediaManagementAddedMediaReference)
				{
					addedMediaReference.MergeFrom(MediaManagementAddedMediaReference);
				}
				input.ReadMessage(addedMediaReference);
				MediaManagementAddedMediaReference = addedMediaReference;
				break;
			}
			case 1170u:
			{
				NotResponding notResponding = new NotResponding();
				if (interactionCase_ == InteractionOneofCase.MediaManagementNotResponding)
				{
					notResponding.MergeFrom(MediaManagementNotResponding);
				}
				input.ReadMessage(notResponding);
				MediaManagementNotResponding = notResponding;
				break;
			}
			case 1602u:
			{
				QuickSearchShown quickSearchShown = new QuickSearchShown();
				if (interactionCase_ == InteractionOneofCase.UiQuicksearch)
				{
					quickSearchShown.MergeFrom(UiQuicksearch);
				}
				input.ReadMessage(quickSearchShown);
				UiQuicksearch = quickSearchShown;
				break;
			}
			case 1610u:
			{
				QuickSearchSearch quickSearchSearch = new QuickSearchSearch();
				if (interactionCase_ == InteractionOneofCase.UiQuicksearchSearch)
				{
					quickSearchSearch.MergeFrom(UiQuicksearchSearch);
				}
				input.ReadMessage(quickSearchSearch);
				UiQuicksearchSearch = quickSearchSearch;
				break;
			}
			case 1618u:
			{
				QuickSearchOpenItems quickSearchOpenItems = new QuickSearchOpenItems();
				if (interactionCase_ == InteractionOneofCase.UiQuicksearchOpenitems)
				{
					quickSearchOpenItems.MergeFrom(UiQuicksearchOpenitems);
				}
				input.ReadMessage(quickSearchOpenItems);
				UiQuicksearchOpenitems = quickSearchOpenItems;
				break;
			}
			case 1626u:
			{
				ToolbarThemeShown toolbarThemeShown = new ToolbarThemeShown();
				if (interactionCase_ == InteractionOneofCase.UiToolbarTheme)
				{
					toolbarThemeShown.MergeFrom(UiToolbarTheme);
				}
				input.ReadMessage(toolbarThemeShown);
				UiToolbarTheme = toolbarThemeShown;
				break;
			}
			case 1634u:
			{
				ToolbarThemeApplication toolbarThemeApplication = new ToolbarThemeApplication();
				if (interactionCase_ == InteractionOneofCase.UiToolbarThemeApplication)
				{
					toolbarThemeApplication.MergeFrom(UiToolbarThemeApplication);
				}
				input.ReadMessage(toolbarThemeApplication);
				UiToolbarThemeApplication = toolbarThemeApplication;
				break;
			}
			case 1642u:
			{
				MainViewShow mainViewShow = new MainViewShow();
				if (interactionCase_ == InteractionOneofCase.UiMainviewShow)
				{
					mainViewShow.MergeFrom(UiMainviewShow);
				}
				input.ReadMessage(mainViewShow);
				UiMainviewShow = mainViewShow;
				break;
			}
			case 1650u:
			{
				MainViewPresentationEditor mainViewPresentationEditor = new MainViewPresentationEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewPresentationEditor)
				{
					mainViewPresentationEditor.MergeFrom(UiMainviewPresentationEditor);
				}
				input.ReadMessage(mainViewPresentationEditor);
				UiMainviewPresentationEditor = mainViewPresentationEditor;
				break;
			}
			case 1658u:
			{
				MainViewReflowEditor mainViewReflowEditor = new MainViewReflowEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewReflow)
				{
					mainViewReflowEditor.MergeFrom(UiMainviewReflow);
				}
				input.ReadMessage(mainViewReflowEditor);
				UiMainviewReflow = mainViewReflowEditor;
				break;
			}
			case 1666u:
			{
				MainViewBible mainViewBible = new MainViewBible();
				if (interactionCase_ == InteractionOneofCase.UiMainviewBible)
				{
					mainViewBible.MergeFrom(UiMainviewBible);
				}
				input.ReadMessage(mainViewBible);
				UiMainviewBible = mainViewBible;
				break;
			}
			case 1674u:
			{
				BibleTrigger bibleTrigger = new BibleTrigger();
				if (interactionCase_ == InteractionOneofCase.BibleTrigger)
				{
					bibleTrigger.MergeFrom(BibleTrigger);
				}
				input.ReadMessage(bibleTrigger);
				BibleTrigger = bibleTrigger;
				break;
			}
			case 1682u:
			{
				BibleGenerateSlides bibleGenerateSlides = new BibleGenerateSlides();
				if (interactionCase_ == InteractionOneofCase.BibleGenerateSlides)
				{
					bibleGenerateSlides.MergeFrom(BibleGenerateSlides);
				}
				input.ReadMessage(bibleGenerateSlides);
				BibleGenerateSlides = bibleGenerateSlides;
				break;
			}
			case 1690u:
			{
				BibleGenerateNext bibleGenerateNext2 = new BibleGenerateNext();
				if (interactionCase_ == InteractionOneofCase.BibleGenerateNext)
				{
					bibleGenerateNext2.MergeFrom(BibleGenerateNext);
				}
				input.ReadMessage(bibleGenerateNext2);
				BibleGenerateNext = bibleGenerateNext2;
				break;
			}
			case 1698u:
			{
				BibleGenerateNext bibleGenerateNext = new BibleGenerateNext();
				if (interactionCase_ == InteractionOneofCase.BibleGeneratePrevious)
				{
					bibleGenerateNext.MergeFrom(BibleGeneratePrevious);
				}
				input.ReadMessage(bibleGenerateNext);
				BibleGeneratePrevious = bibleGenerateNext;
				break;
			}
			case 1706u:
			{
				BibleSaveSlides bibleSaveSlides = new BibleSaveSlides();
				if (interactionCase_ == InteractionOneofCase.BibleSaveSlides)
				{
					bibleSaveSlides.MergeFrom(BibleSaveSlides);
				}
				input.ReadMessage(bibleSaveSlides);
				BibleSaveSlides = bibleSaveSlides;
				break;
			}
			case 1714u:
			{
				BibleLookup bibleLookup = new BibleLookup();
				if (interactionCase_ == InteractionOneofCase.BibleLookup)
				{
					bibleLookup.MergeFrom(BibleLookup);
				}
				input.ReadMessage(bibleLookup);
				BibleLookup = bibleLookup;
				break;
			}
			case 1722u:
			{
				BibleStartup bibleStartup = new BibleStartup();
				if (interactionCase_ == InteractionOneofCase.BibleStartup)
				{
					bibleStartup.MergeFrom(BibleStartup);
				}
				input.ReadMessage(bibleStartup);
				BibleStartup = bibleStartup;
				break;
			}
			case 1730u:
			{
				BibleRemove bibleRemove = new BibleRemove();
				if (interactionCase_ == InteractionOneofCase.BibleRemove)
				{
					bibleRemove.MergeFrom(BibleRemove);
				}
				input.ReadMessage(bibleRemove);
				BibleRemove = bibleRemove;
				break;
			}
			case 1738u:
			{
				BibleInstall bibleInstall = new BibleInstall();
				if (interactionCase_ == InteractionOneofCase.BibleInstall)
				{
					bibleInstall.MergeFrom(BibleInstall);
				}
				input.ReadMessage(bibleInstall);
				BibleInstall = bibleInstall;
				break;
			}
			case 1746u:
			{
				MainViewMaskEditor mainViewMaskEditor = new MainViewMaskEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewMaskEditor)
				{
					mainViewMaskEditor.MergeFrom(UiMainviewMaskEditor);
				}
				input.ReadMessage(mainViewMaskEditor);
				UiMainviewMaskEditor = mainViewMaskEditor;
				break;
			}
			case 1754u:
			{
				MainViewStageEditor mainViewStageEditor = new MainViewStageEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewStageEditor)
				{
					mainViewStageEditor.MergeFrom(UiMainviewStageEditor);
				}
				input.ReadMessage(mainViewStageEditor);
				UiMainviewStageEditor = mainViewStageEditor;
				break;
			}
			case 1762u:
			{
				MainViewThemeEditor mainViewThemeEditor = new MainViewThemeEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewThemeEditor)
				{
					mainViewThemeEditor.MergeFrom(UiMainviewThemeEditor);
				}
				input.ReadMessage(mainViewThemeEditor);
				UiMainviewThemeEditor = mainViewThemeEditor;
				break;
			}
			case 1770u:
			{
				MainViewCopyrightEditor mainViewCopyrightEditor = new MainViewCopyrightEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewCopyrightEditor)
				{
					mainViewCopyrightEditor.MergeFrom(UiMainviewCopyrightEditor);
				}
				input.ReadMessage(mainViewCopyrightEditor);
				UiMainviewCopyrightEditor = mainViewCopyrightEditor;
				break;
			}
			case 1778u:
			{
				MainViewPropsEditor mainViewPropsEditor = new MainViewPropsEditor();
				if (interactionCase_ == InteractionOneofCase.UiMainviewPropsEditor)
				{
					mainViewPropsEditor.MergeFrom(UiMainviewPropsEditor);
				}
				input.ReadMessage(mainViewPropsEditor);
				UiMainviewPropsEditor = mainViewPropsEditor;
				break;
			}
			case 1786u:
			{
				LowerRightTimers lowerRightTimers = new LowerRightTimers();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimers)
				{
					lowerRightTimers.MergeFrom(UiLowerrightTimers);
				}
				input.ReadMessage(lowerRightTimers);
				UiLowerrightTimers = lowerRightTimers;
				break;
			}
			case 1794u:
			{
				LowerRightTimersCollapse lowerRightTimersCollapse = new LowerRightTimersCollapse();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCollapse)
				{
					lowerRightTimersCollapse.MergeFrom(UiLowerrightTimersCollapse);
				}
				input.ReadMessage(lowerRightTimersCollapse);
				UiLowerrightTimersCollapse = lowerRightTimersCollapse;
				break;
			}
			case 1802u:
			{
				LowerRightTimersEdit lowerRightTimersEdit = new LowerRightTimersEdit();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersEdit)
				{
					lowerRightTimersEdit.MergeFrom(UiLowerrightTimersEdit);
				}
				input.ReadMessage(lowerRightTimersEdit);
				UiLowerrightTimersEdit = lowerRightTimersEdit;
				break;
			}
			case 1810u:
			{
				LowerRightTimersState lowerRightTimersState = new LowerRightTimersState();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersState)
				{
					lowerRightTimersState.MergeFrom(UiLowerrightTimersState);
				}
				input.ReadMessage(lowerRightTimersState);
				UiLowerrightTimersState = lowerRightTimersState;
				break;
			}
			case 1818u:
			{
				LowerRightTimersCreate lowerRightTimersCreate = new LowerRightTimersCreate();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersCreate)
				{
					lowerRightTimersCreate.MergeFrom(UiLowerrightTimersCreate);
				}
				input.ReadMessage(lowerRightTimersCreate);
				UiLowerrightTimersCreate = lowerRightTimersCreate;
				break;
			}
			case 1826u:
			{
				LowerRightTimersDelete lowerRightTimersDelete = new LowerRightTimersDelete();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightTimersDelete)
				{
					lowerRightTimersDelete.MergeFrom(UiLowerrightTimersDelete);
				}
				input.ReadMessage(lowerRightTimersDelete);
				UiLowerrightTimersDelete = lowerRightTimersDelete;
				break;
			}
			case 1834u:
			{
				LowerRightMessages lowerRightMessages = new LowerRightMessages();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMessages)
				{
					lowerRightMessages.MergeFrom(UiLowerrightMessages);
				}
				input.ReadMessage(lowerRightMessages);
				UiLowerrightMessages = lowerRightMessages;
				break;
			}
			case 1842u:
			{
				LowerRightMessagesEdit lowerRightMessagesEdit = new LowerRightMessagesEdit();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesEdit)
				{
					lowerRightMessagesEdit.MergeFrom(UiLowerrightMessagesEdit);
				}
				input.ReadMessage(lowerRightMessagesEdit);
				UiLowerrightMessagesEdit = lowerRightMessagesEdit;
				break;
			}
			case 1850u:
			{
				LowerRightMessagesState lowerRightMessagesState = new LowerRightMessagesState();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesState)
				{
					lowerRightMessagesState.MergeFrom(UiLowerrightMessagesState);
				}
				input.ReadMessage(lowerRightMessagesState);
				UiLowerrightMessagesState = lowerRightMessagesState;
				break;
			}
			case 1858u:
			{
				LowerRightMessagesCreate lowerRightMessagesCreate = new LowerRightMessagesCreate();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesCreate)
				{
					lowerRightMessagesCreate.MergeFrom(UiLowerrightMessagesCreate);
				}
				input.ReadMessage(lowerRightMessagesCreate);
				UiLowerrightMessagesCreate = lowerRightMessagesCreate;
				break;
			}
			case 1866u:
			{
				LowerRightMessagesDelete lowerRightMessagesDelete = new LowerRightMessagesDelete();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMessagesDelete)
				{
					lowerRightMessagesDelete.MergeFrom(UiLowerrightMessagesDelete);
				}
				input.ReadMessage(lowerRightMessagesDelete);
				UiLowerrightMessagesDelete = lowerRightMessagesDelete;
				break;
			}
			case 1874u:
			{
				LowerRightProps lowerRightProps = new LowerRightProps();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightProps)
				{
					lowerRightProps.MergeFrom(UiLowerrightProps);
				}
				input.ReadMessage(lowerRightProps);
				UiLowerrightProps = lowerRightProps;
				break;
			}
			case 1882u:
			{
				LowerRightPropsTransition lowerRightPropsTransition = new LowerRightPropsTransition();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsTransition)
				{
					lowerRightPropsTransition.MergeFrom(UiLowerrightPropsTransition);
				}
				input.ReadMessage(lowerRightPropsTransition);
				UiLowerrightPropsTransition = lowerRightPropsTransition;
				break;
			}
			case 1890u:
			{
				LowerRightPropsCreate lowerRightPropsCreate = new LowerRightPropsCreate();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsCreate)
				{
					lowerRightPropsCreate.MergeFrom(UiLowerrightPropsCreate);
				}
				input.ReadMessage(lowerRightPropsCreate);
				UiLowerrightPropsCreate = lowerRightPropsCreate;
				break;
			}
			case 1898u:
			{
				LowerRightPropsDelete lowerRightPropsDelete = new LowerRightPropsDelete();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsDelete)
				{
					lowerRightPropsDelete.MergeFrom(UiLowerrightPropsDelete);
				}
				input.ReadMessage(lowerRightPropsDelete);
				UiLowerrightPropsDelete = lowerRightPropsDelete;
				break;
			}
			case 1906u:
			{
				LowerRightPropsState lowerRightPropsState = new LowerRightPropsState();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightPropsState)
				{
					lowerRightPropsState.MergeFrom(UiLowerrightPropsState);
				}
				input.ReadMessage(lowerRightPropsState);
				UiLowerrightPropsState = lowerRightPropsState;
				break;
			}
			case 1914u:
			{
				LowerRightStage lowerRightStage = new LowerRightStage();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightStage)
				{
					lowerRightStage.MergeFrom(UiLowerrightStage);
				}
				input.ReadMessage(lowerRightStage);
				UiLowerrightStage = lowerRightStage;
				break;
			}
			case 1922u:
			{
				LowerRightStageChangeLayout lowerRightStageChangeLayout = new LowerRightStageChangeLayout();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightStageChangelayout)
				{
					lowerRightStageChangeLayout.MergeFrom(UiLowerrightStageChangelayout);
				}
				input.ReadMessage(lowerRightStageChangeLayout);
				UiLowerrightStageChangelayout = lowerRightStageChangeLayout;
				break;
			}
			case 1930u:
			{
				LowerRightStageMessageState lowerRightStageMessageState = new LowerRightStageMessageState();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightStageMessagestate)
				{
					lowerRightStageMessageState.MergeFrom(UiLowerrightStageMessagestate);
				}
				input.ReadMessage(lowerRightStageMessageState);
				UiLowerrightStageMessagestate = lowerRightStageMessageState;
				break;
			}
			case 1938u:
			{
				LowerRightStageConfigureScreens lowerRightStageConfigureScreens = new LowerRightStageConfigureScreens();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightStageConfigurescreens)
				{
					lowerRightStageConfigureScreens.MergeFrom(UiLowerrightStageConfigurescreens);
				}
				input.ReadMessage(lowerRightStageConfigureScreens);
				UiLowerrightStageConfigurescreens = lowerRightStageConfigureScreens;
				break;
			}
			case 1946u:
			{
				LowerRightStageEditLayouts lowerRightStageEditLayouts = new LowerRightStageEditLayouts();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightStageEditlayouts)
				{
					lowerRightStageEditLayouts.MergeFrom(UiLowerrightStageEditlayouts);
				}
				input.ReadMessage(lowerRightStageEditLayouts);
				UiLowerrightStageEditlayouts = lowerRightStageEditLayouts;
				break;
			}
			case 1954u:
			{
				LowerRightMacros lowerRightMacros = new LowerRightMacros();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMacros)
				{
					lowerRightMacros.MergeFrom(UiLowerrightMacros);
				}
				input.ReadMessage(lowerRightMacros);
				UiLowerrightMacros = lowerRightMacros;
				break;
			}
			case 1962u:
			{
				LowerRightMacrosTrigger lowerRightMacrosTrigger = new LowerRightMacrosTrigger();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosTrigger)
				{
					lowerRightMacrosTrigger.MergeFrom(UiLowerrightMacrosTrigger);
				}
				input.ReadMessage(lowerRightMacrosTrigger);
				UiLowerrightMacrosTrigger = lowerRightMacrosTrigger;
				break;
			}
			case 1970u:
			{
				LowerRightMacrosCreate lowerRightMacrosCreate = new LowerRightMacrosCreate();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosCreate)
				{
					lowerRightMacrosCreate.MergeFrom(UiLowerrightMacrosCreate);
				}
				input.ReadMessage(lowerRightMacrosCreate);
				UiLowerrightMacrosCreate = lowerRightMacrosCreate;
				break;
			}
			case 1978u:
			{
				LowerRightMacrosDelete lowerRightMacrosDelete = new LowerRightMacrosDelete();
				if (interactionCase_ == InteractionOneofCase.UiLowerrightMacrosDelete)
				{
					lowerRightMacrosDelete.MergeFrom(UiLowerrightMacrosDelete);
				}
				input.ReadMessage(lowerRightMacrosDelete);
				UiLowerrightMacrosDelete = lowerRightMacrosDelete;
				break;
			}
			case 1986u:
			{
				TextInspector textInspector = new TextInspector();
				if (interactionCase_ == InteractionOneofCase.UiTextinspector)
				{
					textInspector.MergeFrom(UiTextinspector);
				}
				input.ReadMessage(textInspector);
				UiTextinspector = textInspector;
				break;
			}
			case 1994u:
			{
				TextInspectorScrollingText textInspectorScrollingText = new TextInspectorScrollingText();
				if (interactionCase_ == InteractionOneofCase.UiTextinspectorScrollingText)
				{
					textInspectorScrollingText.MergeFrom(UiTextinspectorScrollingText);
				}
				input.ReadMessage(textInspectorScrollingText);
				UiTextinspectorScrollingText = textInspectorScrollingText;
				break;
			}
			case 2002u:
			{
				TextInspectorForeground textInspectorForeground = new TextInspectorForeground();
				if (interactionCase_ == InteractionOneofCase.UiTextinspectorForeground)
				{
					textInspectorForeground.MergeFrom(UiTextinspectorForeground);
				}
				input.ReadMessage(textInspectorForeground);
				UiTextinspectorForeground = textInspectorForeground;
				break;
			}
			case 2010u:
			{
				TextInspectorUnderlineColor textInspectorUnderlineColor = new TextInspectorUnderlineColor();
				if (interactionCase_ == InteractionOneofCase.UiTextinspectorUnderlineColor)
				{
					textInspectorUnderlineColor.MergeFrom(UiTextinspectorUnderlineColor);
				}
				input.ReadMessage(textInspectorUnderlineColor);
				UiTextinspectorUnderlineColor = textInspectorUnderlineColor;
				break;
			}
			case 2018u:
			{
				TextInspectorBackgroundColor textInspectorBackgroundColor = new TextInspectorBackgroundColor();
				if (interactionCase_ == InteractionOneofCase.UiTextinspectorBackgroundColor)
				{
					textInspectorBackgroundColor.MergeFrom(UiTextinspectorBackgroundColor);
				}
				input.ReadMessage(textInspectorBackgroundColor);
				UiTextinspectorBackgroundColor = textInspectorBackgroundColor;
				break;
			}
			case 2026u:
			{
				TextInspectorLineTransform textInspectorLineTransform = new TextInspectorLineTransform();
				if (interactionCase_ == InteractionOneofCase.UiTextinspectorLineTransform)
				{
					textInspectorLineTransform.MergeFrom(UiTextinspectorLineTransform);
				}
				input.ReadMessage(textInspectorLineTransform);
				UiTextinspectorLineTransform = textInspectorLineTransform;
				break;
			}
			case 2034u:
			{
				ShowSlideLabel showSlideLabel = new ShowSlideLabel();
				if (interactionCase_ == InteractionOneofCase.UiShowSlideLabel)
				{
					showSlideLabel.MergeFrom(UiShowSlideLabel);
				}
				input.ReadMessage(showSlideLabel);
				UiShowSlideLabel = showSlideLabel;
				break;
			}
			case 2042u:
			{
				ShowSlideLabelChange showSlideLabelChange = new ShowSlideLabelChange();
				if (interactionCase_ == InteractionOneofCase.UiShowSlideLabelChange)
				{
					showSlideLabelChange.MergeFrom(UiShowSlideLabelChange);
				}
				input.ReadMessage(showSlideLabelChange);
				UiShowSlideLabelChange = showSlideLabelChange;
				break;
			}
			case 2066u:
			{
				EditorOverlayShown editorOverlayShown = new EditorOverlayShown();
				if (interactionCase_ == InteractionOneofCase.UiEditorOverlayShown)
				{
					editorOverlayShown.MergeFrom(UiEditorOverlayShown);
				}
				input.ReadMessage(editorOverlayShown);
				UiEditorOverlayShown = editorOverlayShown;
				break;
			}
			case 2074u:
			{
				EditorOverlayClosed editorOverlayClosed = new EditorOverlayClosed();
				if (interactionCase_ == InteractionOneofCase.UiEditorOverlayClosed)
				{
					editorOverlayClosed.MergeFrom(UiEditorOverlayClosed);
				}
				input.ReadMessage(editorOverlayClosed);
				UiEditorOverlayClosed = editorOverlayClosed;
				break;
			}
			case 2082u:
			{
				WhatsNewViewed whatsNewViewed = new WhatsNewViewed();
				if (interactionCase_ == InteractionOneofCase.UiWhatsNewViewed)
				{
					whatsNewViewed.MergeFrom(UiWhatsNewViewed);
				}
				input.ReadMessage(whatsNewViewed);
				UiWhatsNewViewed = whatsNewViewed;
				break;
			}
			case 2090u:
			{
				ClearGroups clearGroups = new ClearGroups();
				if (interactionCase_ == InteractionOneofCase.UiClearGroups)
				{
					clearGroups.MergeFrom(UiClearGroups);
				}
				input.ReadMessage(clearGroups);
				UiClearGroups = clearGroups;
				break;
			}
			case 2098u:
			{
				ClearGroupsCreate clearGroupsCreate = new ClearGroupsCreate();
				if (interactionCase_ == InteractionOneofCase.UiClearGroupsCreate)
				{
					clearGroupsCreate.MergeFrom(UiClearGroupsCreate);
				}
				input.ReadMessage(clearGroupsCreate);
				UiClearGroupsCreate = clearGroupsCreate;
				break;
			}
			case 2106u:
			{
				ClearGroupsDelete clearGroupsDelete = new ClearGroupsDelete();
				if (interactionCase_ == InteractionOneofCase.UiClearGroupsDelete)
				{
					clearGroupsDelete.MergeFrom(UiClearGroupsDelete);
				}
				input.ReadMessage(clearGroupsDelete);
				UiClearGroupsDelete = clearGroupsDelete;
				break;
			}
			case 2114u:
			{
				ClearGroupsChangeVisibility clearGroupsChangeVisibility = new ClearGroupsChangeVisibility();
				if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeVisibility)
				{
					clearGroupsChangeVisibility.MergeFrom(UiClearGroupsChangeVisibility);
				}
				input.ReadMessage(clearGroupsChangeVisibility);
				UiClearGroupsChangeVisibility = clearGroupsChangeVisibility;
				break;
			}
			case 2122u:
			{
				ClearGroupsChangeIcon clearGroupsChangeIcon = new ClearGroupsChangeIcon();
				if (interactionCase_ == InteractionOneofCase.UiClearGroupsChangeIcon)
				{
					clearGroupsChangeIcon.MergeFrom(UiClearGroupsChangeIcon);
				}
				input.ReadMessage(clearGroupsChangeIcon);
				UiClearGroupsChangeIcon = clearGroupsChangeIcon;
				break;
			}
			case 2130u:
			{
				PreviewAreaClearGroupsTrigger previewAreaClearGroupsTrigger = new PreviewAreaClearGroupsTrigger();
				if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsTrigger)
				{
					previewAreaClearGroupsTrigger.MergeFrom(UiPreviewAreaClearGroupsTrigger);
				}
				input.ReadMessage(previewAreaClearGroupsTrigger);
				UiPreviewAreaClearGroupsTrigger = previewAreaClearGroupsTrigger;
				break;
			}
			case 2138u:
			{
				PreviewAreaClearGroupsChanged previewAreaClearGroupsChanged = new PreviewAreaClearGroupsChanged();
				if (interactionCase_ == InteractionOneofCase.UiPreviewAreaClearGroupsChanged)
				{
					previewAreaClearGroupsChanged.MergeFrom(UiPreviewAreaClearGroupsChanged);
				}
				input.ReadMessage(previewAreaClearGroupsChanged);
				UiPreviewAreaClearGroupsChanged = previewAreaClearGroupsChanged;
				break;
			}
			case 2146u:
			{
				PlaceholderLink placeholderLink = new PlaceholderLink();
				if (interactionCase_ == InteractionOneofCase.UiPlaceholderLink)
				{
					placeholderLink.MergeFrom(UiPlaceholderLink);
				}
				input.ReadMessage(placeholderLink);
				UiPlaceholderLink = placeholderLink;
				break;
			}
			case 2154u:
			{
				PlaceholderUnlink placeholderUnlink = new PlaceholderUnlink();
				if (interactionCase_ == InteractionOneofCase.UiPlaceholderUnlink)
				{
					placeholderUnlink.MergeFrom(UiPlaceholderUnlink);
				}
				input.ReadMessage(placeholderUnlink);
				UiPlaceholderUnlink = placeholderUnlink;
				break;
			}
			case 2162u:
			{
				PlanningCenterLive planningCenterLive = new PlanningCenterLive();
				if (interactionCase_ == InteractionOneofCase.UiPlanningCenterLive)
				{
					planningCenterLive.MergeFrom(UiPlanningCenterLive);
				}
				input.ReadMessage(planningCenterLive);
				UiPlanningCenterLive = planningCenterLive;
				break;
			}
			case 2170u:
			{
				NetworkGroupAdd networkGroupAdd = new NetworkGroupAdd();
				if (interactionCase_ == InteractionOneofCase.UiNetworkgroupAdd)
				{
					networkGroupAdd.MergeFrom(UiNetworkgroupAdd);
				}
				input.ReadMessage(networkGroupAdd);
				UiNetworkgroupAdd = networkGroupAdd;
				break;
			}
			case 2178u:
			{
				NetworkGroupRemove networkGroupRemove = new NetworkGroupRemove();
				if (interactionCase_ == InteractionOneofCase.UiNetworkgroupRemove)
				{
					networkGroupRemove.MergeFrom(UiNetworkgroupRemove);
				}
				input.ReadMessage(networkGroupRemove);
				UiNetworkgroupRemove = networkGroupRemove;
				break;
			}
			case 2186u:
			{
				CcliReportReset ccliReportReset = new CcliReportReset();
				if (interactionCase_ == InteractionOneofCase.UiCcliReportReset)
				{
					ccliReportReset.MergeFrom(UiCcliReportReset);
				}
				input.ReadMessage(ccliReportReset);
				UiCcliReportReset = ccliReportReset;
				break;
			}
			case 2194u:
			{
				CcliReportShown ccliReportShown = new CcliReportShown();
				if (interactionCase_ == InteractionOneofCase.UiCcliReportShown)
				{
					ccliReportShown.MergeFrom(UiCcliReportShown);
				}
				input.ReadMessage(ccliReportShown);
				UiCcliReportShown = ccliReportShown;
				break;
			}
			case 2202u:
			{
				Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture capture = new Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture();
				if (interactionCase_ == InteractionOneofCase.UiCaptureShown)
				{
					capture.MergeFrom(UiCaptureShown);
				}
				input.ReadMessage(capture);
				UiCaptureShown = capture;
				break;
			}
			case 2210u:
			{
				Welcome welcome = new Welcome();
				if (interactionCase_ == InteractionOneofCase.UiWelcome)
				{
					welcome.MergeFrom(UiWelcome);
				}
				input.ReadMessage(welcome);
				UiWelcome = welcome;
				break;
			}
			case 2218u:
			{
				WelcomeScreenConfigurationHelp welcomeScreenConfigurationHelp = new WelcomeScreenConfigurationHelp();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeScreenConfigurationHelp)
				{
					welcomeScreenConfigurationHelp.MergeFrom(UiWelcomeScreenConfigurationHelp);
				}
				input.ReadMessage(welcomeScreenConfigurationHelp);
				UiWelcomeScreenConfigurationHelp = welcomeScreenConfigurationHelp;
				break;
			}
			case 2226u:
			{
				WelcomeDownloadSampleContent welcomeDownloadSampleContent = new WelcomeDownloadSampleContent();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeDownloadSampleContent)
				{
					welcomeDownloadSampleContent.MergeFrom(UiWelcomeDownloadSampleContent);
				}
				input.ReadMessage(welcomeDownloadSampleContent);
				UiWelcomeDownloadSampleContent = welcomeDownloadSampleContent;
				break;
			}
			case 2234u:
			{
				WelcomeUserGroup welcomeUserGroup = new WelcomeUserGroup();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeUserGroup)
				{
					welcomeUserGroup.MergeFrom(UiWelcomeUserGroup);
				}
				input.ReadMessage(welcomeUserGroup);
				UiWelcomeUserGroup = welcomeUserGroup;
				break;
			}
			case 2242u:
			{
				WelcomeTutorials welcomeTutorials = new WelcomeTutorials();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeTutorials)
				{
					welcomeTutorials.MergeFrom(UiWelcomeTutorials);
				}
				input.ReadMessage(welcomeTutorials);
				UiWelcomeTutorials = welcomeTutorials;
				break;
			}
			case 2250u:
			{
				TestPatterns testPatterns = new TestPatterns();
				if (interactionCase_ == InteractionOneofCase.UiTestPatterns)
				{
					testPatterns.MergeFrom(UiTestPatterns);
				}
				input.ReadMessage(testPatterns);
				UiTestPatterns = testPatterns;
				break;
			}
			case 2258u:
			{
				SettingsCustomLogo settingsCustomLogo = new SettingsCustomLogo();
				if (interactionCase_ == InteractionOneofCase.UiSettingsCustomLogo)
				{
					settingsCustomLogo.MergeFrom(UiSettingsCustomLogo);
				}
				input.ReadMessage(settingsCustomLogo);
				UiSettingsCustomLogo = settingsCustomLogo;
				break;
			}
			case 2266u:
			{
				NetworkGroupLeave networkGroupLeave = new NetworkGroupLeave();
				if (interactionCase_ == InteractionOneofCase.UiNetworkgroupLeave)
				{
					networkGroupLeave.MergeFrom(UiNetworkgroupLeave);
				}
				input.ReadMessage(networkGroupLeave);
				UiNetworkgroupLeave = networkGroupLeave;
				break;
			}
			case 2274u:
			{
				WelcomeKnowledgeBase welcomeKnowledgeBase = new WelcomeKnowledgeBase();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeKnowlegdeBase)
				{
					welcomeKnowledgeBase.MergeFrom(UiWelcomeKnowlegdeBase);
				}
				input.ReadMessage(welcomeKnowledgeBase);
				UiWelcomeKnowlegdeBase = welcomeKnowledgeBase;
				break;
			}
			case 2282u:
			{
				WelcomeBlog welcomeBlog = new WelcomeBlog();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeBlog)
				{
					welcomeBlog.MergeFrom(UiWelcomeBlog);
				}
				input.ReadMessage(welcomeBlog);
				UiWelcomeBlog = welcomeBlog;
				break;
			}
			case 2290u:
			{
				WelcomeFacebook welcomeFacebook = new WelcomeFacebook();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeFacebook)
				{
					welcomeFacebook.MergeFrom(UiWelcomeFacebook);
				}
				input.ReadMessage(welcomeFacebook);
				UiWelcomeFacebook = welcomeFacebook;
				break;
			}
			case 2298u:
			{
				WelcomeInstagram welcomeInstagram = new WelcomeInstagram();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeInstagram)
				{
					welcomeInstagram.MergeFrom(UiWelcomeInstagram);
				}
				input.ReadMessage(welcomeInstagram);
				UiWelcomeInstagram = welcomeInstagram;
				break;
			}
			case 2306u:
			{
				WelcomeMigration welcomeMigration = new WelcomeMigration();
				if (interactionCase_ == InteractionOneofCase.UiWelcomeMigration)
				{
					welcomeMigration.MergeFrom(UiWelcomeMigration);
				}
				input.ReadMessage(welcomeMigration);
				UiWelcomeMigration = welcomeMigration;
				break;
			}
			case 2314u:
			{
				WindowedOutputCreated windowedOutputCreated = new WindowedOutputCreated();
				if (interactionCase_ == InteractionOneofCase.UiWindowedOutputCreated)
				{
					windowedOutputCreated.MergeFrom(UiWindowedOutputCreated);
				}
				input.ReadMessage(windowedOutputCreated);
				UiWindowedOutputCreated = windowedOutputCreated;
				break;
			}
			case 2322u:
			{
				ImportPowerPoint importPowerPoint = new ImportPowerPoint();
				if (interactionCase_ == InteractionOneofCase.ImportPowerpoint)
				{
					importPowerPoint.MergeFrom(ImportPowerpoint);
				}
				input.ReadMessage(importPowerPoint);
				ImportPowerpoint = importPowerPoint;
				break;
			}
			case 2330u:
			{
				LibraryUsage libraryUsage = new LibraryUsage();
				if (interactionCase_ == InteractionOneofCase.LibraryUsage)
				{
					libraryUsage.MergeFrom(LibraryUsage);
				}
				input.ReadMessage(libraryUsage);
				LibraryUsage = libraryUsage;
				break;
			}
			case 2338u:
			{
				FontReplacement fontReplacement = new FontReplacement();
				if (interactionCase_ == InteractionOneofCase.FontReplacement)
				{
					fontReplacement.MergeFrom(FontReplacement);
				}
				input.ReadMessage(fontReplacement);
				FontReplacement = fontReplacement;
				break;
			}
			case 2346u:
			{
				LogDocumentUploaded logDocumentUploaded = new LogDocumentUploaded();
				if (interactionCase_ == InteractionOneofCase.LogDocumentUploaded)
				{
					logDocumentUploaded.MergeFrom(LogDocumentUploaded);
				}
				input.ReadMessage(logDocumentUploaded);
				LogDocumentUploaded = logDocumentUploaded;
				break;
			}
			case 2354u:
			{
				LogDocumentDownloaded logDocumentDownloaded = new LogDocumentDownloaded();
				if (interactionCase_ == InteractionOneofCase.LogDocumentDownloaded)
				{
					logDocumentDownloaded.MergeFrom(LogDocumentDownloaded);
				}
				input.ReadMessage(logDocumentDownloaded);
				LogDocumentDownloaded = logDocumentDownloaded;
				break;
			}
			case 2362u:
			{
				LogDiffPushed logDiffPushed = new LogDiffPushed();
				if (interactionCase_ == InteractionOneofCase.LogDiffPushed)
				{
					logDiffPushed.MergeFrom(LogDiffPushed);
				}
				input.ReadMessage(logDiffPushed);
				LogDiffPushed = logDiffPushed;
				break;
			}
			case 2370u:
			{
				LogDiffReceived logDiffReceived = new LogDiffReceived();
				if (interactionCase_ == InteractionOneofCase.LogDiffReceived)
				{
					logDiffReceived.MergeFrom(LogDiffReceived);
				}
				input.ReadMessage(logDiffReceived);
				LogDiffReceived = logDiffReceived;
				break;
			}
			case 2378u:
			{
				TriggerExternalPresentation triggerExternalPresentation = new TriggerExternalPresentation();
				if (interactionCase_ == InteractionOneofCase.TriggerExternalPresentation)
				{
					triggerExternalPresentation.MergeFrom(TriggerExternalPresentation);
				}
				input.ReadMessage(triggerExternalPresentation);
				TriggerExternalPresentation = triggerExternalPresentation;
				break;
			}
			case 2386u:
			{
				WorkspaceCreation workspaceCreation = new WorkspaceCreation();
				if (interactionCase_ == InteractionOneofCase.WorkspaceCreation)
				{
					workspaceCreation.MergeFrom(WorkspaceCreation);
				}
				input.ReadMessage(workspaceCreation);
				WorkspaceCreation = workspaceCreation;
				break;
			}
			case 2394u:
			{
				AvailableWorkspace availableWorkspace = new AvailableWorkspace();
				if (interactionCase_ == InteractionOneofCase.AvailableWorkspace)
				{
					availableWorkspace.MergeFrom(AvailableWorkspace);
				}
				input.ReadMessage(availableWorkspace);
				AvailableWorkspace = availableWorkspace;
				break;
			}
			case 2402u:
			{
				OnboardingFlowOutcome onboardingFlowOutcome = new OnboardingFlowOutcome();
				if (interactionCase_ == InteractionOneofCase.OnboardingFlowOutcome)
				{
					onboardingFlowOutcome.MergeFrom(OnboardingFlowOutcome);
				}
				input.ReadMessage(onboardingFlowOutcome);
				OnboardingFlowOutcome = onboardingFlowOutcome;
				break;
			}
			case 2410u:
			{
				LogWorkspacesPublished logWorkspacesPublished = new LogWorkspacesPublished();
				if (interactionCase_ == InteractionOneofCase.LogWorkspacesPublished)
				{
					logWorkspacesPublished.MergeFrom(LogWorkspacesPublished);
				}
				input.ReadMessage(logWorkspacesPublished);
				LogWorkspacesPublished = logWorkspacesPublished;
				break;
			}
			case 2418u:
			{
				LogCollaboratorsPublished logCollaboratorsPublished = new LogCollaboratorsPublished();
				if (interactionCase_ == InteractionOneofCase.LogCollaboratorsPublished)
				{
					logCollaboratorsPublished.MergeFrom(LogCollaboratorsPublished);
				}
				input.ReadMessage(logCollaboratorsPublished);
				LogCollaboratorsPublished = logCollaboratorsPublished;
				break;
			}
			case 2426u:
			{
				LogConvertToCloud logConvertToCloud = new LogConvertToCloud();
				if (interactionCase_ == InteractionOneofCase.LogConvertToCloud)
				{
					logConvertToCloud.MergeFrom(LogConvertToCloud);
				}
				input.ReadMessage(logConvertToCloud);
				LogConvertToCloud = logConvertToCloud;
				break;
			}
			case 2434u:
			{
				LogConvertToLocal logConvertToLocal = new LogConvertToLocal();
				if (interactionCase_ == InteractionOneofCase.LogConvertToLocal)
				{
					logConvertToLocal.MergeFrom(LogConvertToLocal);
				}
				input.ReadMessage(logConvertToLocal);
				LogConvertToLocal = logConvertToLocal;
				break;
			}
			case 2442u:
			{
				LogSyncingChange logSyncingChange = new LogSyncingChange();
				if (interactionCase_ == InteractionOneofCase.LogSyncingChange)
				{
					logSyncingChange.MergeFrom(LogSyncingChange);
				}
				input.ReadMessage(logSyncingChange);
				LogSyncingChange = logSyncingChange;
				break;
			}
			case 2450u:
			{
				LogDocumentStored logDocumentStored = new LogDocumentStored();
				if (interactionCase_ == InteractionOneofCase.LogDocumentStored)
				{
					logDocumentStored.MergeFrom(LogDocumentStored);
				}
				input.ReadMessage(logDocumentStored);
				LogDocumentStored = logDocumentStored;
				break;
			}
			case 2458u:
			{
				LogDocumentCreated logDocumentCreated = new LogDocumentCreated();
				if (interactionCase_ == InteractionOneofCase.LogDocumentCreated)
				{
					logDocumentCreated.MergeFrom(LogDocumentCreated);
				}
				input.ReadMessage(logDocumentCreated);
				LogDocumentCreated = logDocumentCreated;
				break;
			}
			case 2466u:
			{
				LogDocumentUpdated logDocumentUpdated = new LogDocumentUpdated();
				if (interactionCase_ == InteractionOneofCase.LogDocumentUpdated)
				{
					logDocumentUpdated.MergeFrom(LogDocumentUpdated);
				}
				input.ReadMessage(logDocumentUpdated);
				LogDocumentUpdated = logDocumentUpdated;
				break;
			}
			case 2474u:
			{
				LogDocumentDeleted logDocumentDeleted = new LogDocumentDeleted();
				if (interactionCase_ == InteractionOneofCase.LogDocumentDeleted)
				{
					logDocumentDeleted.MergeFrom(LogDocumentDeleted);
				}
				input.ReadMessage(logDocumentDeleted);
				LogDocumentDeleted = logDocumentDeleted;
				break;
			}
			case 2482u:
			{
				LogDocumentConflict logDocumentConflict = new LogDocumentConflict();
				if (interactionCase_ == InteractionOneofCase.LogDocumentConflict)
				{
					logDocumentConflict.MergeFrom(LogDocumentConflict);
				}
				input.ReadMessage(logDocumentConflict);
				LogDocumentConflict = logDocumentConflict;
				break;
			}
			case 2490u:
			{
				LogWorkspaceResynchronized logWorkspaceResynchronized = new LogWorkspaceResynchronized();
				if (interactionCase_ == InteractionOneofCase.LogWorkspaceResynchronized)
				{
					logWorkspaceResynchronized.MergeFrom(LogWorkspaceResynchronized);
				}
				input.ReadMessage(logWorkspaceResynchronized);
				LogWorkspaceResynchronized = logWorkspaceResynchronized;
				break;
			}
			case 2498u:
			{
				WebSocketConnectionFailed webSocketConnectionFailed = new WebSocketConnectionFailed();
				if (interactionCase_ == InteractionOneofCase.LogWsConnectionFailed)
				{
					webSocketConnectionFailed.MergeFrom(LogWsConnectionFailed);
				}
				input.ReadMessage(webSocketConnectionFailed);
				LogWsConnectionFailed = webSocketConnectionFailed;
				break;
			}
			case 2506u:
			{
				LogError logError = new LogError();
				if (interactionCase_ == InteractionOneofCase.LogError)
				{
					logError.MergeFrom(LogError);
				}
				input.ReadMessage(logError);
				LogError = logError;
				break;
			}
			case 2514u:
			{
				UserWorkspaceTreeModification userWorkspaceTreeModification = new UserWorkspaceTreeModification();
				if (interactionCase_ == InteractionOneofCase.UserWorkspaceTreeModification)
				{
					userWorkspaceTreeModification.MergeFrom(UserWorkspaceTreeModification);
				}
				input.ReadMessage(userWorkspaceTreeModification);
				UserWorkspaceTreeModification = userWorkspaceTreeModification;
				break;
			}
			case 2522u:
			{
				ActivationFlowOpened activationFlowOpened = new ActivationFlowOpened();
				if (interactionCase_ == InteractionOneofCase.UiActivationFlowOpened)
				{
					activationFlowOpened.MergeFrom(UiActivationFlowOpened);
				}
				input.ReadMessage(activationFlowOpened);
				UiActivationFlowOpened = activationFlowOpened;
				break;
			}
			case 2530u:
			{
				LogOpenedWorkspace logOpenedWorkspace = new LogOpenedWorkspace();
				if (interactionCase_ == InteractionOneofCase.LogOpenedWorkspace)
				{
					logOpenedWorkspace.MergeFrom(LogOpenedWorkspace);
				}
				input.ReadMessage(logOpenedWorkspace);
				LogOpenedWorkspace = logOpenedWorkspace;
				break;
			}
			}
		}
	}
}
