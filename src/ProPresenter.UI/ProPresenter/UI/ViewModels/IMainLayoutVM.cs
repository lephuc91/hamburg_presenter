using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.UI.Commands;
using ProPresenter.UI.ViewModels.Bibles;
using ProPresenter.UI.ViewModels.Downloads;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.KeyMapping;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.LooksDialog;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.PCO;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.QuickSearch;
using ProPresenter.UI.ViewModels.Registration.Banners;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.TestPattern;
using ProPresenter.UI.ViewModels.TransportStatus;

namespace ProPresenter.UI.ViewModels;

public interface IMainLayoutVM : INotifyPropertyChanged
{
	public record CodeInfo(string RegistrationName, string Code);

	IApp Settings { get; }

	ssAPIOutput OutputController { get; }

	ICommunicationOutput CommunicationOutput { get; }

	UtilityViewType SelectedUtilityView { get; set; }

	IWelcomeVM WelcomeVM { get; }

	IFeedbackVM FeedbackVM { get; }

	ICrashReportingVM CrashReportingVM { get; }

	IPlaylistTemplateCollectionVM PlaylistTemplatesVM { get; }

	ILibraryVM LibraryVM { get; }

	IExportVM ExportVM { get; }

	IAudioLibraryVM AudioLibraryVM { get; }

	IMediaLibraryVM MediaLibraryVM { get; }

	IPresentationVM PresentationVM { get; }

	IMigrationVM MigrationVM { get; }

	IMenuLayoutVM MenuLayoutVM { get; }

	IPresentationEditorVM PresentationEditorVM { get; }

	ITemplateEditorVM TemplateEditorVM { get; }

	IPropsEditorVM PropsEditorVM { get; }

	IMaskEditorVM MaskEditorVM { get; }

	IBiblesVM BibleVM { get; }

	IMessagesVM MessagesVM { get; }

	IAttachmentManagerVM PCOAttachmentManagerVM { get; }

	IPCOLiveVM PCOLiveVM { get; }

	ICalendarVM CalendarVM { get; }

	IStageVM StageVM { get; }

	IOutputVM OutputVM { get; }

	ITemplateVM TemplateVM { get; }

	ITimerCollectionVM TimerVM { get; }

	IScreenConfigVM ScreenConfigVM { get; }

	IPropsVM PropsVM { get; }

	IPropGroupCollectionVM PropGroupCollectionVM { get; }

	IPrintVM PrintVM { get; }

	IQuickEditVM QuickEditVM { get; }

	InlineType ActiveInlineView { get; set; }

	ITelestratorVM TelestratorVM { get; }

	ICueInspectorVM CueInspectorVM { get; }

	ITextStyleVM TextStyleVM { get; }

	ITestPatternVM TestPatternVM { get; }

	ILooksDialogVM AudienceLookVM { get; }

	IScreenPreviewVM ScreenPreviewVM { get; }

	ITransportStatusVM TransportStatusVM { get; }

	IQuickSearchVM QuickSearchVM { get; }

	ICaptureVM CaptureVM { get; }

	IMacroGroupCollectionVM MacroGroupsVM { get; }

	IUtilityViewVM UtilityViewVM { get; }

	IClearGroupCollectionVM ClearGroupsVM { get; }

	IKeyMappingVM KeyMappingVM { get; }

	IDownloadsVM DownloadsVM { get; }

	IBannersVM BannersVM { get; }

	bool ShowFeedbackButton { get; }

	IImmutableObservableCollection<IPropCue> Props { get; }

	IEnumerable<SlideCue> StageLayouts { get; }

	MessageCollection Messages { get; }

	TimerCollection Timers { get; }

	ICommand ShutdownCommand { get; }

	ICommand<EditStageLayoutCommandParameter> EditStagePresentationCommand { get; }

	ICommand<ShowSource> ShowEditorCommand { get; }

	ICommand<ShowSource> ShowReflowEditorCommand { get; }

	ICommand ToggleEditorCommand { get; }

	ICommand ToggleReflowEditorCommand { get; }

	ICommand<CustomPresentation?> EditPresentationCommand { get; }

	ICommand<PopupType> SetSelectedViewCommand { get; }

	ICommand ShowRegistrationCommand { get; }

	ICommand TriggerNextSlideCommand { get; }

	ICommand TriggerNextSlideWithSuppressionCommand { get; }

	ICommand TriggerPreviousSlideCommand { get; }

	ICommand AddSlideCommand { get; }

	ICommand<ShowSource> ShowMainViewCommand { get; }

	ICommand CheckForUpdatesCommand { get; }

	ICommand<ShowSource> EditCopyrightTemplateCommand { get; }

	bool ShowHouseOfWorshipIntegration { get; }

	event Action<PopupType>? SetSelectedView;

	event Action<CodeInfo?> ShowRegistration;

	event Action<SettingsPage>? ShowSettingsPage;

	void ActivateRegistrationUI(CodeInfo? codeInfo = null);

	void ImportPendingFile(string file = "");

	void CommitWriteQueue();

	void ActivateProContent();

	void ActivateMediaBin();

	void SetupSettingsStackChanged(IGeneralSettingsVM generalSettings, IGroupsSettingsVM groupsSettings, ILabelsSettingsVM labelsSettings, IDevicesSettingsVM devicesSettings, IInputsSettingsVM inputsSettings);

	IActionDialogService GetActionDialogService();
}
