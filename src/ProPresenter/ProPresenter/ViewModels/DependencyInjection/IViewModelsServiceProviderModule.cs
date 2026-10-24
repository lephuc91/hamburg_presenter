using System.IO.Abstractions;
using Jab;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.CoreApplication.PowerPoint;
using Pro.CoreApplication.PowerPoint.CoreInteraction;
using Pro.Reporting;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Import;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Calendar;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.OutputConfiguration;
using ProPresenter.UI.ViewModels.Presentation;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.Themes;
using ProPresenter.UI.ViewModels.Timeline;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.ViewModels.ActionsMenu;
using ProPresenter.ViewModels.Bibles;
using ProPresenter.ViewModels.Calendar;
using ProPresenter.ViewModels.Capture;
using ProPresenter.ViewModels.Downloads;
using ProPresenter.ViewModels.Editor;
using ProPresenter.ViewModels.FeedbackCrash;
using ProPresenter.ViewModels.Library;
using ProPresenter.ViewModels.Library.Cue;
using ProPresenter.ViewModels.Macros;
using ProPresenter.ViewModels.MediaLibrary;
using ProPresenter.ViewModels.OutputConfiguration;
using ProPresenter.ViewModels.Preview;
using ProPresenter.ViewModels.ProContent.Dialog;
using ProPresenter.ViewModels.Props;
using ProPresenter.ViewModels.Resi;
using ProPresenter.ViewModels.Settings.DependencyInjection;
using ProPresenter.ViewModels.Themes;
using ProPresenter.ViewModels.Timecode;
using ProPresenter.ViewModels.Timeline;
using ProPresenter.ViewModels.UserFeedback;
using ProPresenter.ViewModels.WhatsNew;
using ProPresenter.ViewModels.Workspaces;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Import<ISettingsViewModelsServiceProviderModule>]
[Jab.Transient<ICalendarPrompt, CalendarPrompt>]
[Jab.Transient<IRTMPPrompt, RTMPPrompt>]
[Jab.Transient<IProContentDialogService, ProContentDialogService>]
[Jab.Transient<IProContentDownloadFailedDialogService, ProContentDownloadFailedDialogService>]
[Jab.Transient<IMediaImportDownloadDialogService, MediaImportDownloadDialogService>]
[Jab.Transient<ICapturePrompt, CapturePrompt>]
[Jab.Transient<IDownloadsDialogService, DownloadsDialogService>]
[Jab.Transient<IMediaCueThumbnailOverlayVMFactory, MediaCueThumbnailOverlayVMFactory>]
[Jab.Transient<IDownloadVMsFactory, DownloadVMsFactory>]
[Jab.Transient<IPropPrompts, PropPrompts>]
[Jab.Transient<IHardwareAlphaConfigurationVMFactory, HardwareAlphaConfigurationVMFactory>]
[Jab.Transient<IAlphaKeySettingsVMFactory, AlphaKeySettingsVMFactory>]
[Jab.Singleton<IResiAuthorizationInteractor, ResiAuthorizationInteractor>]
[Jab.Transient<IResiPrompt, ResiPrompt>]
[Jab.Singleton<CaptureController>]
[Jab.Transient<ICaptureController>(Factory = "GetCaptureController")]
[Jab.Transient<ICaptureService>(Factory = "GetCaptureController")]
[Jab.Transient<IResiService>(Factory = "GetCaptureController")]
[Jab.Transient<IUserAttachmentVMFactory, UserAttachmentVMFactory>]
[Jab.Singleton<IFeedbackVM, FeedbackVM>]
[Jab.Singleton<ICrashReportingVM>(Factory = "GetCrashReportingVM")]
[Jab.Singleton<IAttachmentUploadVM, AttachmentUploadVM>]
[Jab.Transient<ICrashReportUserFeedbackDialogProvider, CrashReportUserFeedbackDialogProvider>]
[Jab.Singleton<INetworkLinkPrompt, NetworkLinkPrompt>]
[Jab.Singleton<INetworkLinkVM, NetworkLinkVM>]
[Jab.Singleton<IWhatsNewV2VM, WhatsNewV2VM>]
[Jab.Transient<ITimelineVMFactory, TimelineVMFactory>]
[Jab.Transient<ITimelineItemVMFactory, TimelineVMFactory>]
[Jab.Transient<IWorkspaceItemVMFactory, WorkspaceItemVMFactory>]
[Jab.Transient<IActionsMenuVMFactory, ActionsMenuVMFactory>]
[Jab.Singleton<IScreenSelectorVM, ScreenSelectorVM>]
[Jab.Singleton<IWindowedOutputVM>(Factory = "GetWindowdOutputVM")]
[Jab.Transient<IOutputScreenVMFactory, OutputScreenVMFactory>]
[Jab.Transient<IOutputPreviewVMFactory, OutputPreviewVMFactory>]
[Jab.Singleton<ILibraryService, LibraryService>]
[Jab.Singleton<ICalendarService, CalendarService>]
[Jab.Transient<IEditorService>(Factory = "GetEditorService")]
[Jab.Transient<IClipboardProvider, ClipboardProvider>]
[Jab.Singleton<IPasteStrategy, PasteStrategy>]
[Jab.Singleton<IClipboardProvider, ClipboardProvider>]
[Jab.Transient<IPlaylistTemplatesService, PlaylistTemplatesService>]
[Jab.Transient<PlaylistTemplateCollection>(Factory = "GetPlaylistTemplateCollection")]
[Jab.Transient<ICorePowerPointImportService, CorePowerPointImportService>]
[Jab.Transient<IPowerPointImportService, PowerPointImportService>]
[Jab.Singleton<ISizeProvider, DefaultScreenSizeProvider>]
[Jab.Transient<IProPresenterCueVMFactory>(Factory = "GetProPresenterCueVMFactory")]
[Jab.Singleton<IMainLayoutVM, MainLayoutVM>]
[Jab.Singleton<IMacroPrompt, MacroPrompt>]
[Jab.Transient<IThemeSlideMenuVM, ThemeSlideMenuVM>]
[Jab.Transient<ILegacyPurchaseBiblesDialogService, LegacyPurchaseBiblesDialogService>]
[Jab.Transient<IMediaProvider>(Factory = "GetMediaProvider")]
[Jab.Transient<IMediaValidator, FillMediaValidator>]
[Jab.Transient<IExportService, ExportService>]
[Jab.Transient<IArrangementVM, ArrangementVM>]
[Jab.Transient<ITimecodeItemVMFactory, TimecodeItemVMFactory>]
[Jab.Singleton<ITimecodeVM, TimecodeVM>]
[Jab.Transient<IHeaderContentContextMenuVM, HeaderContentContextMenuVM>]
[Jab.Singleton<IWorkspaceSwitchValidator, WorkspaceSwitchValidator>]
public interface IViewModelsServiceProviderModule
{
	static IProPresenterCueVMFactory GetProPresenterCueVMFactory(IProPresenterResourceService resourceService)
	{
		return new ProPresenterCueVMFactory(resourceService.LibraryCollection);
	}

	static CaptureController GetCaptureController(CaptureController controller)
	{
		return controller;
	}

	static ICrashReportingVM GetCrashReportingVM(ILogger logger, IUserFeedbackConsumer apiConsumer, IRegistrationStateProvider registrationStateProvider, IFileSystem fileSystem, IUserAttachmentVMFactory userAttachmentVMFactory, IInternetAccessCheck internetAccessCheck, IAttachmentsUploader attachmentsUploader, IAttachmentUploadJobFactory attachmentUploadJobFactory, IGeneral general, IHyperlinkService hyperlinkService, IMessageDialogService messageDialogService)
	{
		return new CrashReportingVM(logger, apiConsumer, registrationStateProvider, Stargazer.LastCrashOutputFolder, fileSystem, userAttachmentVMFactory, internetAccessCheck, attachmentsUploader, attachmentUploadJobFactory, general, hyperlinkService, messageDialogService);
	}

	static IWindowedOutputVM GetWindowdOutputVM(IProCoreInstance proCore, IOutputScreenVMFactory factory, IInputActions inputActions)
	{
		return new WindowedOutputVM(proCore, inputActions.WindowMenu, factory);
	}

	static IEditorService GetEditorService(IInternalCoreManager coreManager, IOutputService outputService, IPasteStrategy pasteStrategy, IMetadataLoader metadataLoader, IUiDispatcher uiDispatcher, ITriggeringFactory triggeringFactory)
	{
		return new EditorService(coreManager, outputService.OutputController, outputService.OutputRepository, pasteStrategy, metadataLoader, uiDispatcher, triggeringFactory);
	}

	static IMediaProvider GetMediaProvider(IMediaValidator mediaValidator, IAdvanced advanced, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory)
	{
		return new FillMediaProvider(mediaValidator, importProcessFactory, mediaFactory, () => FileFilters.VisualFilter, () => (!advanced.ManageMediaAutomatically) ? null : CommonPaths.MediaAssets);
	}

	static PlaylistTemplateCollection GetPlaylistTemplateCollection()
	{
		return DataVault.PlaylistTemplates;
	}
}
