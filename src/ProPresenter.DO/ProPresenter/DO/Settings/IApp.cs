using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Export;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Settings.AppSettings;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timecode;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Settings;

public interface IApp : INotifyPropertyChanged, ICollaborationPeerIdProvider
{
	string[]? ServerEnabledFlags { get; set; }

	string[]? ServerDisabledFlags { get; set; }

	string[] EnabledFeatureFlags { get; set; }

	string[] DisabledFeatureFlags { get; set; }

	ColorTheme ActiveTheme { get; set; }

	TimeSlice AudioFadeInOutDuration { get; set; }

	AudioSortType AudioSortType { get; set; }

	BreakMode BreakMode { get; set; }

	string CustomDelimiter { get; set; }

	FormatLength DefaultClockDateFormatLength { get; set; }

	FormatLength DefaultClockTimeFormatLength { get; set; }

	bool DefaultClockUse24HourMode { get; set; }

	ColorTriggerCollection DefaultColorTriggers { get; set; }

	System.Windows.Media.Color EasyViewBackgroundColor { get; set; }

	bool EasyViewByGroups { get; set; }

	int EasyViewCharacterSize { get; set; }

	FontInfo EasyViewFont { get; set; }

	ParagraphAlignment EasyViewHorizontalAlignment { get; set; }

	bool EasyViewShowMediaActions { get; set; }

	System.Windows.Media.Color EasyViewTextColor { get; set; }

	TruncatingMode EasyViewTruncatingMode { get; set; }

	DocumentAlignment EasyViewVerticalAlignment { get; set; }

	string ExportDirectory { get; set; }

	ImageExportExtension ExportImageExtension { get; set; }

	bool ExportIncludeMedia { get; set; }

	List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset> FavoriteTransitions { get; set; }

	Pro.SerializationInterop.RVProtoData.Transition? GlobalBackgroundAdvancedTransition { get; set; }

	TimeSlice GlobalBackgroundAutoTransitionDuration { get; set; }

	TransitionStoreType GlobalBackgroundTransitionType { get; set; }

	Pro.SerializationInterop.RVProtoData.Transition? GlobalBibleAdvancedTransition { get; set; }

	TimeSlice GlobalBibleAutoTransitionDuration { get; set; }

	TransitionStoreType GlobalBibleTransitionType { get; set; }

	Pro.SerializationInterop.RVProtoData.Transition? GlobalForegroundAdvancedTransition { get; set; }

	TimeSlice GlobalForegroundAutoTransitionDuration { get; set; }

	TransitionStoreType GlobalForegroundTransitionType { get; set; }

	Pro.SerializationInterop.RVProtoData.Transition? GlobalMessageTransition { get; set; }

	ObservableDictionary<Guid, PresentationHeaderViewType> HeaderStates { get; }

	System.Version? HighestVersion { get; }

	bool IsFirstLaunch { get; set; }

	bool HasSeenOnboarding { get; set; }

	bool IsMultiTracksAuthorized { get; set; }

	bool IsPlaylistLibraryExpanded { get; set; }

	System.Version? LastVersion { get; }

	int LibrarySearchPreviewRowCapacity { get; set; }

	int LinesPerSlide { get; set; }

	System.Windows.Media.Color ListViewBackgroundColor { get; set; }

	bool ListViewByGroups { get; set; }

	int ListViewCharacterSize { get; set; }

	System.Windows.Media.Color ListViewControlBackgroundColor { get; set; }

	FontInfo ListViewFont { get; set; }

	ParagraphAlignment ListViewHorizontalAlignment { get; set; }

	System.Windows.Media.Color ListViewTextColor { get; set; }

	TruncatingMode ListViewTruncatingMode { get; set; }

	bool ListViewUseBackgroundColor { get; set; }

	DocumentAlignment ListViewVerticalAlignment { get; set; }

	int MediaBinRowCapacity { get; set; }

	PanelViewType MediaBinViewType { get; set; }

	string MultiTracksAccessToken { get; set; }

	DateTime? MultiTracksAccessTokenExpiration { get; set; }

	MultiTracksSubscriptionStatus MultiTracksChartProStatus { get; set; }

	System.Windows.Media.Color MultiTracksChordNotationTextColor { get; set; }

	string MultiTracksCustomerID { get; set; }

	string MultiTracksFirstName { get; set; }

	string MultiTracksLastName { get; set; }

	string MultiTracksOrganizationName { get; set; }

	string MultiTracksRefreshToken { get; set; }

	bool MultiTracksSimulateExpired { get; set; }

	bool MultiTracksSimulateNonOwned { get; set; }

	MultiTracksSubscriptionStatus MultiTracksSlideProStatus { get; set; }

	MultiTracksSubscriptionLevel MultiTracksSubscriptionLevel { get; set; }

	bool NotifyUpdates { get; set; }

	string PCOAccessToken { get; set; }

	DateTimeOffset? PCOAccessTokenExpiry { get; set; }

	string PCORefreshToken { get; set; }

	PanelViewType PresentationPanelViewType { get; set; }

	int PresentationRowCapacity { get; set; }

	int Print_ColumnCount { get; set; }

	bool Print_DisableSlides { get; set; }

	bool Print_IsOutline { get; set; }

	bool Print_IsThumbnail { get; set; }

	bool Print_ShowCurrentDate { get; set; }

	bool Print_ShowMetaData { get; set; }

	bool Print_ShowNotes { get; set; }

	bool Print_ShowSlideLabels { get; set; }

	bool Print_ShowSlideNotes { get; set; }

	bool Print_ShowSlideNumbers { get; set; }

	int PropsViewerRowCapacity { get; set; }

	List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset> RecentTransitions { get; set; }

	int ReflowRowCapacity { get; set; }

	double ReflowTextZoomLevel { get; set; }

	UpdateChannel UpdateChannel { get; set; }

	string ResiToken { get; set; }

	Guid SelectedAudioPlaylist { get; set; }

	Guid SelectedCueID { get; set; }

	Guid SelectedImportTemplateID { get; set; }

	string SelectedLibraryName { get; set; }

	QuickSearchPreviewType SelectedLibrarySearchPreview { get; set; }

	Guid SelectedMediaPlaylist { get; set; }

	string? SelectedProContentRootGroup { get; set; }

	Guid SelectedMediaDownloadPlaylist { get; set; }

	Guid SelectedNewPresentationTemplateID { get; set; }

	string SelectedPCOLivePlanID { get; set; }

	string SelectedPCOLiveServiceTypeID { get; set; }

	Guid SelectedPlaylistID { get; set; }

	Guid SelectedPreviewScreenID { get; set; }

	QuickSearchType SelectedSearchPage { get; set; }

	UtilityViewType SelectedUtilityView { get; set; }

	bool ShowAdvancedOnScreenStats { get; set; }

	bool ShuffleEnabled { get; set; }

	string SkippedVersion { get; set; }

	string SongSelectApiV2AccessToken { get; set; }

	string SongSelectApiV2RefreshToken { get; set; }

	DateTimeOffset? SongSelectApiV2AccessTokenExpiration { get; set; }

	string SongSelectOrganization { get; set; }

	string ProContentAccessToken { get; set; }

	string ProContentRefreshToken { get; set; }

	DateTimeOffset? ProContentAccessTokenExpiration { get; set; }

	string? ProContentUserName { get; set; }

	string? ProContentUserEmail { get; set; }

	string StageMessage { get; set; }

	System.Windows.Media.Color ThumbnailViewBackgroundColor { get; set; }

	bool ThumbnailViewByGroups { get; set; }

	bool ThumbnailViewUseBackgroundColor { get; set; }

	ProPresenter.DO.Timecode.TimecodeSettings Timecode { get; }

	ObservableDictionary<Guid, double> TimelineZoomValue { get; }

	ObservableDictionary<Guid, bool> TimerViewStates { get; }

	List<UtilityViewType> UtilityViewTabs { get; set; }

	bool SongSelectAutoReportSongUsage { get; set; }

	string SelectedProContentFormat { get; set; }

	ushort ProContentCachingPolicyGroupTimeToLive { get; }

	ushort ProContentRefreshPolicyRefreshOutline { get; }

	int ProContentPackDownloadPreferences { get; set; }

	int ConcurrentDownloadLimit { get; set; }

	PanelViewType MacroViewPanelType { get; set; }

	PanelViewType PropsViewPanelType { get; set; }

	int PropViewRowCapacity { get; set; }

	Guid SelectedPropGroupId { get; set; }

	Guid SelectedMacroGroupId { get; set; }

	BitDepth RenderBitDepth { get; set; }

	bool CloudTeaseDismissed { get; set; }

	System.Windows.Media.Color GetNextMacroColor();

	System.Windows.Media.Color GetNextPlaybackMarkerColor();

	void SaveClockData(ClockData? value);

	void UpdateSettingsFile();
}
