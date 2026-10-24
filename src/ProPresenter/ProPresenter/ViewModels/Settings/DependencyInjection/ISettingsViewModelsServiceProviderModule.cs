using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Jab;
using ProPresenter.DO.Import;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.UI.CloudOnboarding;
using ProPresenter.UI.ViewModels.AccountCenter;
using ProPresenter.UI.ViewModels.CloudOnboarding;
using ProPresenter.UI.ViewModels.Import;
using ProPresenter.UI.ViewModels.Notification;
using ProPresenter.UI.ViewModels.Resi;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;
using ProPresenter.UI.ViewModels.Settings.Pages.Sync;
using ProPresenter.UI.ViewModels.Settings.Pages.Updates;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.AccountCenter;
using ProPresenter.ViewModels.CloudOnboarding;
using ProPresenter.ViewModels.Import;
using ProPresenter.ViewModels.Notification;
using ProPresenter.ViewModels.Resi;
using ProPresenter.ViewModels.Settings.Pages;
using ProPresenter.ViewModels.Settings.Pages.Devices;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.Settings.Pages.Groups;
using ProPresenter.ViewModels.Settings.Pages.Import;
using ProPresenter.ViewModels.Settings.Pages.Inputs;
using ProPresenter.ViewModels.Settings.Pages.Inputs.Video;
using ProPresenter.ViewModels.Settings.Pages.Integrations;
using ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.ViewModels.Settings.Pages.Labels;
using ProPresenter.ViewModels.Settings.Pages.Media;
using ProPresenter.ViewModels.Settings.Pages.Network;
using ProPresenter.ViewModels.Settings.Pages.Registration;
using ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.ViewModels.Settings.Pages.Screens;
using ProPresenter.ViewModels.Settings.Pages.Updates;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ISettingsSearchFactory, SettingsSearchFactory>]
[Jab.Transient<INetworkDialogService, NetworkDialogService>]
[Jab.Transient<IMediaCleanupPrompt, MediaCleanupPrompt>]
[Jab.Singleton<IMidiDeviceSettingsVM, MidiDeviceSettingsVM>]
[Jab.Singleton<IMidiWindowProvider, MidiWindowProvider>]
[Jab.Transient<ICCLIReportPrompt, CCLIReportPrompt>]
[Jab.Transient<INdiInputsSettingsDialogService, NdiInputsSettingsDialogService>]
[Jab.Transient<IAirCastPrompt, AirCastPrompt>]
[Jab.Transient<IAirCastPluginDownload, AirCastPluginDownload>]
[Jab.Singleton<ICCLIReportCollectionVM, CCLIReportCollectionVM>]
[Jab.Singleton<ICopyrightSettingsVM, CopyrightSettingsVM>]
[Jab.Singleton<IGeneralSettingsVM, GeneralSettingsVM>]
[Jab.Singleton<INetworkSettingsVM, NetworkSettingsVM>]
[Jab.Transient<IRegistrationSubpageVMFactory, RegistrationSubpageVMFactory>]
[Jab.Singleton<IRegistrationMainPageVM, RegistrationMainPageVM>]
[Jab.Singleton<IAccountCenterVM, AccountCenterVM>]
[Jab.Singleton<IUpdatesSettingsVM, UpdatesSettingsVM>]
[Jab.Singleton<IScreenSettingsVM, ScreenSettingsVM>]
[Jab.Transient<IInputsSettingsService, InputsSettingsService>]
[Jab.Singleton<IVideoInputsSettingsVM, VideoInputsSettingsVM>]
[Jab.Singleton<IAudioInputsSettingsVM, AudioInputsSettingsVM>]
[Jab.Singleton<INdiInputsSettingsVM, NdiInputsSettingsVM>]
[Jab.Singleton<IInputsSettingsVM, InputsSettingsVM>]
[Jab.Singleton<IDevicesSettingsVM, DevicesSettingsVM>]
[Jab.Singleton<IMediaSearchPathsSettingsVM, MediaSearchPathsSettingsVM>]
[Jab.Singleton<IMediaCleanupVM, MediaCleanupVM>]
[Jab.Singleton<IMediaCleanupService, MediaCleanupService>]
[Jab.Transient<IMediaFilesProvider, MediaFilesProvider>]
[Jab.Singleton<IMediaSettingsVM, MediaSettingsVM>]
[Jab.Singleton<IAudioSettingsVM, AudioSettingsVM>]
[Jab.Singleton<IImportSettingsVM, ImportSettingsVM>]
[Jab.Singleton<IPlanningCenterSettingsVM, PlanningCenterSettingsVM>]
[Jab.Singleton<IMultiTracksSettingsVM, MultiTracksSettingsVM>]
[Jab.Singleton<ISongSelectSettingsVM, SongSelectSettingsVM>]
[Jab.Transient<IAutoReportDialogPrompt, AutoReportDialogPrompt>]
[Jab.Singleton<IResiUpdateVM, ResiUpdateVM>]
[Jab.Singleton<IResiSettingsVM, ResiSettingsVM>]
[Jab.Singleton<IIntegrationsSettingsVM, IntegrationsSettingsVM>]
[Jab.Singleton<IGroupsSettingsVM, GroupsSettingsVM>]
[Jab.Singleton<ILabelsSettingsVM, LabelsSettingsVM>]
[Jab.Singleton<ISyncSettingsVM, SyncSettingsVM>]
[Jab.Singleton<ISettingsSearchVM, SettingsSearchVM>]
[Jab.Singleton<ISettingsNavigationVM, SettingsNavigationVM>]
[Jab.Singleton<ISettingsVM, SettingsVM>]
[Jab.Singleton<INotificationVMFactory, NotificationVMFactory>]
[Jab.Singleton<INotificationService, NotificationService>]
[Jab.Singleton<INotificationCollectionVM, NotificationCollectionVM>]
[Jab.Transient<IChangeDirectoryProcessFactory, ChangeDirectoryProcessFactory>]
[Jab.Singleton<IChangeWorkspaceHandler, ChangeWorkspaceHandler>]
[Jab.Singleton<IVideoInputItemVMFactory, VideoInputItemVMFactory>]
[Jab.Singleton<IClockSourceVM, ClockSourceVM>]
[Jab.Transient<IMediaSettingsVMFactory, MediaSettingsVMFactory>]
[Jab.Transient<IGroupLabelItemVMFactory, GroupLabelItemVMFactory>]
[Jab.Transient<ILabelItemVMFactory, LabelItemVMFactory>]
[Jab.Singleton<CloudOnboardingVM>]
[Jab.Transient<ICloudOnboardingVM>(Factory = "GetCloudOnboardingVM")]
[Jab.Transient<ICloudOnboardingShellNavigator>(Factory = "GetCloudOnboardingVM")]
[Jab.Transient<ICloudOnboardingEligibilityVM, CloudOnboardingEligibilityVM>]
[Jab.Transient<ICloudOnboardingManageMediaVM, CloudOnboardingManageMediaVM>]
[Jab.Transient<ICloudOnboardingPricingVM, CloudOnboardingPricingVM>]
[Jab.Transient<ICloudOnboardingDoneVM, CloudOnboardingDoneVM>]
[Jab.Transient<ICloudOnboardingLocalWorkspacesVM, CloudOnboardingLocalWorkspacesVM>]
[Jab.Transient<ICloudTeaseVM, CloudTeaseVM>]
[Jab.Transient<ICloudTeaseWindowProvider, CloudTeaseWindowProvider>]
[Jab.Singleton<IRegistrationUnlockCodeVM>(Factory = "GetRegistrationUnlockCodeVM")]
[Jab.Singleton<ISettingsSearchEngine>(Factory = "GetSettingsSearchEngine")]
[Jab.Singleton<IManageWorkspacesWindowProvider, ManageWorkspacesWindowProvider>]
[Jab.Transient<IMissingFontVM, MissingFontVM>]
[Jab.Transient<IMissingFontWindowProvider, MissingFontWindowProvider>]
public interface ISettingsViewModelsServiceProviderModule
{
	static ISettingsSearchEngine GetSettingsSearchEngine(IEnumerable<ISettingsListItem> settingsItems, IFileSystem fileSystem)
	{
		return new SettingsSearchEngine(settingsItems.OfType<ISettingsSearchPage>().GetAllPages(), fileSystem);
	}

	static IRegistrationUnlockCodeVM GetRegistrationUnlockCodeVM(IRegistrationOperationFactory registrationOperationFactory)
	{
		return new RegistrationUnlockCodeVM(registrationOperationFactory, Environment.MachineName);
	}

	static CloudOnboardingVM GetCloudOnboardingVM(CloudOnboardingVM vm)
	{
		return vm;
	}
}
