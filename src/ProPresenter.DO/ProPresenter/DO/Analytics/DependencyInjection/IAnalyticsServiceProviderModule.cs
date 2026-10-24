using Jab;
using Pro.CoreApplication.Media;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Analytics.Events.ForceQuit;
using ProPresenter.DO.Analytics.Events.MediaManagement;
using ProPresenter.DO.Analytics.Events.PowerPoint;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Analytics.Events.Settings.CCLIReport;
using ProPresenter.DO.Analytics.Events.Startup;
using ProPresenter.DO.Analytics.Events.TestPattern;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;
using ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;
using ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;
using ProPresenter.DO.Analytics.Events.UIPreferences;
using ProPresenter.DO.Analytics.Events.Welcome;

namespace ProPresenter.DO.Analytics.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IThemeAnalyiticEvents, ThemeAnalyticEvents>]
[Jab.Transient<IProContentAnalyticEventsPublisher, ProContentAnalyticEventsPublisher>]
[Jab.Transient<IApplicationLaunchEventPublisher, ApplicationLaunchEventPublisher>]
[Jab.Transient<ICaptureAnalyticEventsPublisher, CaptureAnalyticEventsPublisher>]
[Jab.Transient<IStartupSettingsEventsPublisher, StartupSettingsEventsPublisher>]
[Jab.Transient<IUiPreferencesAnalyticEventsPublisher, UiPreferencesAnalyticEventsPublisher>]
[Jab.Transient<ITestPatternAnalyticEventsPublisher, TestPatternAnalyticEventsPublisher>]
[Jab.Transient<IWelcomeAnalyticEventsPublisher, WelcomeAnalyticEventsPublisher>]
[Jab.Transient<ITimecodeAnalyticsEvents, TimecodeAnalyticsEvents>]
[Jab.Transient<IPlaybackMarkerAnalyticsEvents, PlaybackMarkerAnalyticsEvents>]
[Jab.Transient<ITimelineAnalyticsEvents, TimelineAnalyticsEvents>]
[Jab.Transient<ICCLIReportAnalyticsEvents, CCLIReportAnalyticsEvents>]
[Jab.Transient<IForceQuitEventPublisher, ForceQuitEventPublisher>]
[Jab.Transient<IMediaCleanupSizeEventPublisher, MediaCleanupSizeEventPublisher>]
[Jab.Transient<IAudioSettingsAnalyticsEventPublisher, AudioSettingsAnalyticsEventPublisher>]
[Jab.Transient<IMediaAnalyticsSender, MediaAnalyticsSender>]
[Jab.Transient<IPowerPointEvents, PowerPointEvents>]
[Jab.Transient<ILocalWorkspaceStatsEventPublisher, LocalWorkspaceStatsEventPublisher>]
[Jab.Transient<IFontReplacementEventPublisher, FontReplacementEventPublisher>]
[Jab.Transient<IWorkspaceAnalyticsEventPublisher, WorkspaceAnalyticsEventPublisher>]
[Jab.Transient<ICloudOnboardingAnalyticsEventPublisher, CloudOnboardingAnalyticsEventPublisher>]
internal interface IAnalyticsServiceProviderModule
{
}
