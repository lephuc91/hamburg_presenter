using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Versioning;
using Pro.DO.Transitions;
using Pro.Data.SQLite;
using Pro.Data.SQLite.Migration;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Web.Cookies;
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

public class App : StoreBase, IApp, INotifyPropertyChanged, ICollaborationPeerIdProvider, IMigrationSource
{
	private const string SettingsFile = "AppPreferences.proPref";

	private const string PCOCookieSessionName = "planning_center_session";

	private const string PCOCookieAccountName = "_account_center_session";

	private const string PCOCookieDomain = ".planningcenteronline.com";

	private bool _migratingForward;

	private readonly ICookieManagerService _cookieManagerService;

	public bool IsFirstLaunch { get; set; }

	public bool HasSeenOnboarding
	{
		get
		{
			return GetValue("HasSeenOnboarding", defaultValue: false);
		}
		set
		{
			SetValue("HasSeenOnboarding", value);
			OnPropertyChanged("HasSeenOnboarding");
		}
	}

	public bool CloudTeaseDismissed
	{
		get
		{
			return GetValue("CloudTeaseDismissed", defaultValue: false);
		}
		set
		{
			SetValue("CloudTeaseDismissed", value);
			OnPropertyChanged("CloudTeaseDismissed");
		}
	}

	public System.Version LastVersion { get; }

	public System.Version? HighestVersion { get; }

	public string[]? ServerEnabledFlags
	{
		get
		{
			return GetValue<string[]>("ServerEnabledFlags");
		}
		set
		{
			SetValue("ServerEnabledFlags", value);
		}
	}

	public string[]? ServerDisabledFlags
	{
		get
		{
			return GetValue<string[]>("ServerDisabledFlags");
		}
		set
		{
			SetValue("ServerDisabledFlags", value);
		}
	}

	public string[] EnabledFeatureFlags
	{
		get
		{
			return GetValue<string[]>("EnabledFeatureFlags") ?? Array.Empty<string>();
		}
		set
		{
			SetValue("EnabledFeatureFlags", value);
		}
	}

	public string[] DisabledFeatureFlags
	{
		get
		{
			return GetValue<string[]>("DisabledFeatureFlags") ?? Array.Empty<string>();
		}
		set
		{
			SetValue("DisabledFeatureFlags", value);
		}
	}

	public bool ShuffleEnabled
	{
		get
		{
			return GetValue("ShuffleEnabled", defaultValue: false);
		}
		set
		{
			SetValue("ShuffleEnabled", value);
			OnPropertyChanged("ShuffleEnabled");
		}
	}

	public AudioSortType AudioSortType
	{
		get
		{
			return GetValue("AudioSortType", AudioSortType.Name);
		}
		set
		{
			SetValue("AudioSortType", value);
			OnPropertyChanged("AudioSortType");
		}
	}

	public TimeSlice AudioFadeInOutDuration
	{
		get
		{
			return GetValue("AudioFadeInOutDuration", TimeSlice.Zero);
		}
		set
		{
			SetValue("AudioFadeInOutDuration", value);
			OnPropertyChanged("AudioFadeInOutDuration");
		}
	}

	public bool IsPlaylistLibraryExpanded
	{
		get
		{
			return GetValue("IsPlaylistLibraryExpanded", defaultValue: false);
		}
		set
		{
			SetValue("IsPlaylistLibraryExpanded", value);
			OnPropertyChanged("IsPlaylistLibraryExpanded");
		}
	}

	public int PresentationRowCapacity
	{
		get
		{
			return GetValue("PresentationRowCapacity", 4);
		}
		set
		{
			SetValue("PresentationRowCapacity", value);
			OnPropertyChanged("PresentationRowCapacity");
		}
	}

	public int ReflowRowCapacity
	{
		get
		{
			return GetValue("ReflowRowCapacity", 3);
		}
		set
		{
			SetValue("ReflowRowCapacity", value);
			OnPropertyChanged("ReflowRowCapacity");
		}
	}

	public double ReflowTextZoomLevel
	{
		get
		{
			return GetValue("ReflowTextZoomLevel", 0.25);
		}
		set
		{
			SetValue("ReflowTextZoomLevel", value);
			OnPropertyChanged("ReflowTextZoomLevel");
		}
	}

	public PanelViewType PresentationPanelViewType
	{
		get
		{
			return GetValue("PresentationPanelViewType", PanelViewType.Thumbnail);
		}
		set
		{
			SetValue("PresentationPanelViewType", value);
			OnPropertyChanged("PresentationPanelViewType");
		}
	}

	public bool ThumbnailViewByGroups
	{
		get
		{
			return GetValue("ThumbnailViewByGroups", defaultValue: false);
		}
		set
		{
			SetValue("ThumbnailViewByGroups", value);
			OnPropertyChanged("ThumbnailViewByGroups");
		}
	}

	public bool ThumbnailViewUseBackgroundColor
	{
		get
		{
			return GetValue("ThumbnailViewUseBackgroundColor", defaultValue: false);
		}
		set
		{
			SetValue("ThumbnailViewUseBackgroundColor", value);
			OnPropertyChanged("ThumbnailViewUseBackgroundColor");
		}
	}

	public System.Windows.Media.Color ThumbnailViewBackgroundColor
	{
		get
		{
			return GetValue("ThumbnailViewBackgroundColor", Colors.Black);
		}
		set
		{
			SetValue("ThumbnailViewBackgroundColor", value);
			OnPropertyChanged("ThumbnailViewBackgroundColor");
		}
	}

	public bool EasyViewByGroups
	{
		get
		{
			return GetValue("EasyViewByGroups", defaultValue: false);
		}
		set
		{
			SetValue("EasyViewByGroups", value);
			OnPropertyChanged("EasyViewByGroups");
		}
	}

	public bool EasyViewShowMediaActions
	{
		get
		{
			return GetValue("EasyViewShowMediaActions", defaultValue: false);
		}
		set
		{
			SetValue("EasyViewShowMediaActions", value);
			OnPropertyChanged("EasyViewShowMediaActions");
		}
	}

	public System.Windows.Media.Color EasyViewBackgroundColor
	{
		get
		{
			return GetValue("EasyViewBackgroundColor", Colors.Black);
		}
		set
		{
			SetValue("EasyViewBackgroundColor", value);
			OnPropertyChanged("EasyViewBackgroundColor");
		}
	}

	public FontInfo EasyViewFont
	{
		get
		{
			return GetValue("EasyViewFont", RunSettings.DefaultFont);
		}
		set
		{
			SetValue("EasyViewFont", value);
			OnPropertyChanged("EasyViewFont");
		}
	}

	public int EasyViewCharacterSize
	{
		get
		{
			return GetValue("EasyViewCharacterSize", 14);
		}
		set
		{
			SetValue("EasyViewCharacterSize", value);
			OnPropertyChanged("EasyViewCharacterSize");
		}
	}

	public System.Windows.Media.Color EasyViewTextColor
	{
		get
		{
			return GetValue("EasyViewTextColor", Colors.White);
		}
		set
		{
			SetValue("EasyViewTextColor", value);
			OnPropertyChanged("EasyViewTextColor");
		}
	}

	public ParagraphAlignment EasyViewHorizontalAlignment
	{
		get
		{
			return GetValue("EasyViewHorizontalAlignment", ParagraphAlignment.Justified);
		}
		set
		{
			SetValue("EasyViewHorizontalAlignment", value);
			OnPropertyChanged("EasyViewHorizontalAlignment");
		}
	}

	public DocumentAlignment EasyViewVerticalAlignment
	{
		get
		{
			return GetValue("EasyViewVerticalAlignment", DocumentAlignment.Top);
		}
		set
		{
			SetValue("EasyViewVerticalAlignment", value);
			OnPropertyChanged("EasyViewVerticalAlignment");
		}
	}

	public TruncatingMode EasyViewTruncatingMode
	{
		get
		{
			return GetValue("EasyViewTruncatingMode", TruncatingMode.Middle);
		}
		set
		{
			SetValue("EasyViewTruncatingMode", value);
			OnPropertyChanged("EasyViewTruncatingMode");
		}
	}

	public bool ListViewByGroups
	{
		get
		{
			return GetValue("ListViewByGroups", defaultValue: false);
		}
		set
		{
			SetValue("ListViewByGroups", value);
			OnPropertyChanged("ListViewByGroups");
		}
	}

	public bool ListViewUseBackgroundColor
	{
		get
		{
			return GetValue("ListViewUseBackgroundColor", defaultValue: false);
		}
		set
		{
			SetValue("ListViewUseBackgroundColor", value);
			OnPropertyChanged("ListViewUseBackgroundColor");
		}
	}

	public System.Windows.Media.Color ListViewBackgroundColor
	{
		get
		{
			return GetValue("ListViewBackgroundColor", Colors.Black);
		}
		set
		{
			SetValue("ListViewBackgroundColor", value);
			OnPropertyChanged("ListViewBackgroundColor");
		}
	}

	public System.Windows.Media.Color ListViewControlBackgroundColor
	{
		get
		{
			return GetValue("ListViewControlBackgroundColor", (System.Windows.Media.Color)ColorConverter.ConvertFromString("#FF232323"));
		}
		set
		{
			SetValue("ListViewControlBackgroundColor", value);
			OnPropertyChanged("ListViewControlBackgroundColor");
		}
	}

	public FontInfo ListViewFont
	{
		get
		{
			return GetValue("ListViewFont", RunSettings.DefaultFont);
		}
		set
		{
			SetValue("ListViewFont", value);
			OnPropertyChanged("ListViewFont");
		}
	}

	public int ListViewCharacterSize
	{
		get
		{
			return GetValue("ListViewCharacterSize", 14);
		}
		set
		{
			SetValue("ListViewCharacterSize", value);
			OnPropertyChanged("ListViewCharacterSize");
		}
	}

	public System.Windows.Media.Color ListViewTextColor
	{
		get
		{
			return GetValue("ListViewTextColor", Colors.White);
		}
		set
		{
			SetValue("ListViewTextColor", value);
			OnPropertyChanged("ListViewTextColor");
		}
	}

	public ParagraphAlignment ListViewHorizontalAlignment
	{
		get
		{
			return GetValue("ListViewHorizontalAlignment", ParagraphAlignment.Justified);
		}
		set
		{
			SetValue("ListViewHorizontalAlignment", value);
			OnPropertyChanged("ListViewHorizontalAlignment");
		}
	}

	public DocumentAlignment ListViewVerticalAlignment
	{
		get
		{
			return GetValue("ListViewVerticalAlignment", DocumentAlignment.Top);
		}
		set
		{
			SetValue("ListViewVerticalAlignment", value);
			OnPropertyChanged("ListViewVerticalAlignment");
		}
	}

	public TruncatingMode ListViewTruncatingMode
	{
		get
		{
			return GetValue("ListViewTruncatingMode", TruncatingMode.Middle);
		}
		set
		{
			SetValue("ListViewTruncatingMode", value);
			OnPropertyChanged("ListViewTruncatingMode");
		}
	}

	public string SelectedPCOLiveServiceTypeID
	{
		get
		{
			return GetValue("SelectedPCOLiveServiceTypeID", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SelectedPCOLiveServiceTypeID", value);
			OnPropertyChanged("SelectedPCOLiveServiceTypeID");
		}
	}

	public string SelectedPCOLivePlanID
	{
		get
		{
			return GetValue("SelectedPCOLivePlanID", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SelectedPCOLivePlanID", value);
			OnPropertyChanged("SelectedPCOLivePlanID");
		}
	}

	public PanelViewType MediaBinViewType
	{
		get
		{
			return GetValue("MediaBinViewType", PanelViewType.Thumbnail);
		}
		set
		{
			SetValue("MediaBinViewType", value);
			OnPropertyChanged("MediaBinViewType");
		}
	}

	public int MediaBinRowCapacity
	{
		get
		{
			return GetValue("MediaBinRowCapacity", 6);
		}
		set
		{
			SetValue("MediaBinRowCapacity", value);
			OnPropertyChanged("MediaBinRowCapacity");
		}
	}

	public int PropsViewerRowCapacity
	{
		get
		{
			return GetValue("PropsViewerRowCapacity", 4);
		}
		set
		{
			SetValue("PropsViewerRowCapacity", value);
			OnPropertyChanged("PropsViewerRowCapacity");
		}
	}

	public string SongSelectApiV2AccessToken
	{
		get
		{
			return GetValue("SongSelectApiV2AccessToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SongSelectApiV2AccessToken", value);
			OnPropertyChanged("SongSelectApiV2AccessToken");
		}
	}

	public string SongSelectApiV2RefreshToken
	{
		get
		{
			return GetValue("SongSelectApiV2RefreshToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SongSelectApiV2RefreshToken", value);
			OnPropertyChanged("SongSelectApiV2RefreshToken");
		}
	}

	public DateTimeOffset? SongSelectApiV2AccessTokenExpiration
	{
		get
		{
			return GetValue<DateTimeOffset?>("SongSelectApiV2AccessTokenExpiration", null);
		}
		set
		{
			SetValue("SongSelectApiV2AccessTokenExpiration", value);
			OnPropertyChanged("SongSelectApiV2AccessTokenExpiration");
		}
	}

	public string SongSelectOrganization
	{
		get
		{
			return GetValue("SongSelectOrganization", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SongSelectOrganization", value);
			OnPropertyChanged("SongSelectOrganization");
		}
	}

	public bool IsMultiTracksAuthorized
	{
		get
		{
			return GetValue("IsMultiTracksAuthorized", defaultValue: false);
		}
		set
		{
			SetValue("IsMultiTracksAuthorized", value);
			OnPropertyChanged("IsMultiTracksAuthorized");
		}
	}

	public string MultiTracksAccessToken
	{
		get
		{
			return GetValue("MultiTracksAccessToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksAccessToken", value);
			OnPropertyChanged("MultiTracksAccessToken");
		}
	}

	public string MultiTracksRefreshToken
	{
		get
		{
			return GetValue("MultiTracksRefreshToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksRefreshToken", value);
			OnPropertyChanged("MultiTracksRefreshToken");
		}
	}

	public DateTime? MultiTracksAccessTokenExpiration
	{
		get
		{
			return GetValue<DateTime?>("MultiTracksAccessTokenExpiration", null);
		}
		set
		{
			SetValue("MultiTracksAccessTokenExpiration", value);
			OnPropertyChanged("MultiTracksAccessTokenExpiration");
		}
	}

	public string MultiTracksCustomerID
	{
		get
		{
			return GetValue("MultiTracksCustomerID", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksCustomerID", value);
			OnPropertyChanged("MultiTracksCustomerID");
		}
	}

	public string MultiTracksFirstName
	{
		get
		{
			return GetValue("MultiTracksFirstName", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksFirstName", value);
			OnPropertyChanged("MultiTracksFirstName");
		}
	}

	public string MultiTracksLastName
	{
		get
		{
			return GetValue("MultiTracksLastName", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksLastName", value);
			OnPropertyChanged("MultiTracksLastName");
		}
	}

	public string MultiTracksOrganizationName
	{
		get
		{
			return GetValue("MultiTracksOrganizationName", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("MultiTracksOrganizationName", value);
			OnPropertyChanged("MultiTracksOrganizationName");
		}
	}

	public MultiTracksSubscriptionStatus MultiTracksChartProStatus
	{
		get
		{
			return GetValue("MultiTracksChartProStatus", MultiTracksSubscriptionStatus.Disabled);
		}
		set
		{
			SetValue("MultiTracksChartProStatus", value);
			OnPropertyChanged("MultiTracksChartProStatus");
		}
	}

	public MultiTracksSubscriptionStatus MultiTracksSlideProStatus
	{
		get
		{
			return GetValue("MultiTracksSlideProStatus", MultiTracksSubscriptionStatus.Disabled);
		}
		set
		{
			SetValue("MultiTracksSlideProStatus", value);
			OnPropertyChanged("MultiTracksSlideProStatus");
		}
	}

	public MultiTracksSubscriptionLevel MultiTracksSubscriptionLevel
	{
		get
		{
			return GetValue("MultiTracksSubscriptionLevel", MultiTracksSubscriptionLevel.Unknown);
		}
		set
		{
			SetValue("MultiTracksSubscriptionLevel", value);
			OnPropertyChanged("MultiTracksSubscriptionLevel");
		}
	}

	public bool MultiTracksSimulateExpired
	{
		get
		{
			return GetValue("MultiTracksSimulateExpired", defaultValue: false);
		}
		set
		{
			SetValue("MultiTracksSimulateExpired", value);
			OnPropertyChanged("MultiTracksSimulateExpired");
		}
	}

	public bool MultiTracksSimulateNonOwned
	{
		get
		{
			return GetValue("MultiTracksSimulateNonOwned", defaultValue: false);
		}
		set
		{
			SetValue("MultiTracksSimulateNonOwned", value);
			OnPropertyChanged("MultiTracksSimulateNonOwned");
		}
	}

	public System.Windows.Media.Color MultiTracksChordNotationTextColor
	{
		get
		{
			return GetValue("MultiTracksChordNotationTextColor", ChordPro.DefaultColor);
		}
		set
		{
			SetValue("MultiTracksChordNotationTextColor", value);
			OnPropertyChanged("MultiTracksChordNotationTextColor");
		}
	}

	public string PCOAccessToken
	{
		get
		{
			return GetValue("PCOAccessToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("PCOAccessToken", value);
			OnPropertyChanged("PCOAccessToken");
		}
	}

	public string PCORefreshToken
	{
		get
		{
			return GetValue("PCORefreshToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("PCORefreshToken", value);
			OnPropertyChanged("PCORefreshToken");
		}
	}

	public DateTimeOffset? PCOAccessTokenExpiry
	{
		get
		{
			return GetValue<DateTimeOffset?>("PCOAccessTokenExpiry", null);
		}
		set
		{
			SetValue("PCOAccessTokenExpiry", value);
			OnPropertyChanged("PCOAccessTokenExpiry");
		}
	}

	[Obsolete("Setting migrated to database.")]
	public string PCOSessionCookie
	{
		get
		{
			return GetValue("PCOSessionCookie", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("PCOSessionCookie", value);
			OnPropertyChanged("PCOSessionCookie");
		}
	}

	[Obsolete("Setting migrated to database.")]
	public DateTime? PCOSessionCookieExpiration
	{
		get
		{
			return GetValue<DateTime?>("PCOSessionCookieExpiration", null);
		}
		set
		{
			SetValue("PCOSessionCookieExpiration", value);
			OnPropertyChanged("PCOSessionCookieExpiration");
		}
	}

	[Obsolete("Setting migrated to database.")]
	public string PCOPlanningSessionCookie
	{
		get
		{
			return GetValue("PCOPlanningSessionCookie", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("PCOPlanningSessionCookie", value);
			OnPropertyChanged("PCOPlanningSessionCookie");
		}
	}

	[Obsolete("Setting migrated to database.")]
	public DateTime? PCOPlanningSessionCookieExpiration
	{
		get
		{
			return GetValue<DateTime?>("PCOPlanningSessionCookieExpiration", null);
		}
		set
		{
			SetValue("PCOPlanningSessionCookieExpiration", value);
			OnPropertyChanged("PCOPlanningSessionCookieExpiration");
		}
	}

	public string ResiToken
	{
		get
		{
			return GetValue("ResiToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ResiToken", value);
			OnPropertyChanged("ResiToken");
		}
	}

	public Guid SelectedAudioPlaylist
	{
		get
		{
			return GetValue("SelectedAudioPlaylist", Guid.Empty);
		}
		set
		{
			SetValue("SelectedAudioPlaylist", value);
			OnPropertyChanged("SelectedAudioPlaylist");
		}
	}

	public Guid SelectedMediaPlaylist
	{
		get
		{
			return GetValue("SelectedMediaPlaylist", Guid.Empty);
		}
		set
		{
			SetValue("SelectedMediaPlaylist", value);
			OnPropertyChanged("SelectedMediaPlaylist");
		}
	}

	public string? SelectedProContentRootGroup
	{
		get
		{
			return GetValue("SelectedProContentRootGroup", string.Empty);
		}
		set
		{
			SetValue("SelectedProContentRootGroup", value);
			OnPropertyChanged("SelectedProContentRootGroup");
		}
	}

	public Guid SelectedMediaDownloadPlaylist
	{
		get
		{
			return GetValue("SelectedMediaDownloadPlaylist", Guid.Empty);
		}
		set
		{
			SetValue("SelectedMediaDownloadPlaylist", value);
			OnPropertyChanged("SelectedMediaDownloadPlaylist");
		}
	}

	public Guid SelectedPlaylistID
	{
		get
		{
			return GetValue("SelectedPlaylistID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedPlaylistID", value);
			OnPropertyChanged("SelectedPlaylistID");
		}
	}

	public string SelectedLibraryName
	{
		get
		{
			return GetValue("SelectedLibraryName", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SelectedLibraryName", value);
			OnPropertyChanged("SelectedLibraryName");
		}
	}

	public Guid SelectedCueID
	{
		get
		{
			return GetValue("SelectedCueID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedCueID", value);
			OnPropertyChanged("SelectedCueID");
		}
	}

	public Guid SelectedNewPresentationTemplateID
	{
		get
		{
			return GetValue("SelectedNewPresentationTemplateID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedNewPresentationTemplateID", value);
			OnPropertyChanged("SelectedNewPresentationTemplateID");
		}
	}

	public bool NotifyUpdates
	{
		get
		{
			return GetValue("NotifyUpdates", defaultValue: true);
		}
		set
		{
			SetValue("NotifyUpdates", value);
			OnPropertyChanged("NotifyUpdates");
		}
	}

	public string SkippedVersion
	{
		get
		{
			return GetValue("SkippedVersion", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("SkippedVersion", value);
			OnPropertyChanged("SkippedVersion");
		}
	}

	public ColorTheme ActiveTheme
	{
		get
		{
			return GetValue("ActiveTheme", ColorTheme.Dark);
		}
		set
		{
			SetValue("ActiveTheme", value);
			OnPropertyChanged("ActiveTheme");
		}
	}

	public ColorTriggerCollection DefaultColorTriggers
	{
		get
		{
			return GetValue("DefaultColorTriggers", new ColorTriggerCollection()) ?? new ColorTriggerCollection();
		}
		set
		{
			SetValue("DefaultColorTriggers", value);
			OnPropertyChanged("DefaultColorTriggers");
		}
	}

	public FormatLength DefaultClockDateFormatLength
	{
		get
		{
			return GetValue("DefaultClockDateFormatLength", FormatLength.None);
		}
		set
		{
			SetValue("DefaultClockDateFormatLength", value);
			OnPropertyChanged("DefaultClockDateFormatLength");
		}
	}

	public FormatLength DefaultClockTimeFormatLength
	{
		get
		{
			return GetValue("DefaultClockTimeFormatLength", FormatLength.Medium);
		}
		set
		{
			SetValue("DefaultClockTimeFormatLength", value);
			OnPropertyChanged("DefaultClockTimeFormatLength");
		}
	}

	public bool DefaultClockUse24HourMode
	{
		get
		{
			return GetValue("DefaultClockUse24HourMode", defaultValue: false);
		}
		set
		{
			SetValue("DefaultClockUse24HourMode", value);
			OnPropertyChanged("DefaultClockUse24HourMode");
		}
	}

	public BreakMode BreakMode
	{
		get
		{
			return GetValue("BreakMode", BreakMode.BlankLine);
		}
		set
		{
			SetValue("BreakMode", value);
			OnPropertyChanged("BreakMode");
		}
	}

	public string CustomDelimiter
	{
		get
		{
			return GetValue("CustomDelimiter", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("CustomDelimiter", value);
			OnPropertyChanged("CustomDelimiter");
		}
	}

	public int LinesPerSlide
	{
		get
		{
			return GetValue("LinesPerSlide", 1);
		}
		set
		{
			SetValue("LinesPerSlide", value);
			OnPropertyChanged("LinesPerSlide");
		}
	}

	public Guid SelectedImportTemplateID
	{
		get
		{
			return GetValue("SelectedImportTemplateID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedImportTemplateID", value);
			OnPropertyChanged("SelectedImportTemplateID");
		}
	}

	public List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset> FavoriteTransitions
	{
		get
		{
			return GetValue("FavoriteTransitions", new List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>()) ?? new List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>();
		}
		set
		{
			SetValue("FavoriteTransitions", value);
			OnPropertyChanged("FavoriteTransitions");
		}
	}

	public List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset> RecentTransitions
	{
		get
		{
			return GetValue("RecentTransitions", new List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>()) ?? new List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>();
		}
		set
		{
			SetValue("RecentTransitions", value);
			OnPropertyChanged("RecentTransitions");
		}
	}

	public TransitionStoreType GlobalForegroundTransitionType
	{
		get
		{
			return GetValue("GlobalForegroundTransitionType", TransitionStoreType.Cut);
		}
		set
		{
			SetValue("GlobalForegroundTransitionType", value);
			OnPropertyChanged("GlobalForegroundTransitionType");
		}
	}

	public TimeSlice GlobalForegroundAutoTransitionDuration
	{
		get
		{
			return GetValue("GlobalForegroundAutoTransitionDuration", TimeSlice.FromSeconds(0.6));
		}
		set
		{
			SetValue("GlobalForegroundAutoTransitionDuration", value);
			OnPropertyChanged("GlobalForegroundAutoTransitionDuration");
		}
	}

	public Pro.SerializationInterop.RVProtoData.Transition? GlobalForegroundAdvancedTransition
	{
		get
		{
			return GetValue<Pro.SerializationInterop.RVProtoData.Transition>("GlobalForegroundAdvancedTransition");
		}
		set
		{
			SetValue("GlobalForegroundAdvancedTransition", value);
			OnPropertyChanged("GlobalForegroundAdvancedTransition");
		}
	}

	public Pro.SerializationInterop.RVProtoData.Transition? GlobalBackgroundAdvancedTransition
	{
		get
		{
			return GetValue<Pro.SerializationInterop.RVProtoData.Transition>("GlobalBackgroundAdvancedTransition");
		}
		set
		{
			SetValue("GlobalBackgroundAdvancedTransition", value);
			OnPropertyChanged("GlobalBackgroundAdvancedTransition");
		}
	}

	public TimeSlice GlobalBackgroundAutoTransitionDuration
	{
		get
		{
			return GetValue("GlobalBackgroundAutoTransitionDuration", TimeSlice.FromSeconds(0.6));
		}
		set
		{
			SetValue("GlobalBackgroundAutoTransitionDuration", value);
			OnPropertyChanged("GlobalBackgroundAutoTransitionDuration");
		}
	}

	public TransitionStoreType GlobalBackgroundTransitionType
	{
		get
		{
			return GetValue("GlobalBackgroundTransitionType", TransitionStoreType.Cut);
		}
		set
		{
			SetValue("GlobalBackgroundTransitionType", value);
			OnPropertyChanged("GlobalBackgroundTransitionType");
		}
	}

	public Pro.SerializationInterop.RVProtoData.Transition? GlobalBibleAdvancedTransition
	{
		get
		{
			return GetValue<Pro.SerializationInterop.RVProtoData.Transition>("GlobalBibleAdvancedTransition");
		}
		set
		{
			SetValue("GlobalBibleAdvancedTransition", value);
			OnPropertyChanged("GlobalBibleAdvancedTransition");
		}
	}

	public TimeSlice GlobalBibleAutoTransitionDuration
	{
		get
		{
			return GetValue("GlobalBibleAutoTransitionDuration", TimeSlice.FromSeconds(0.6));
		}
		set
		{
			SetValue("GlobalBibleAutoTransitionDuration", value);
			OnPropertyChanged("GlobalBibleAutoTransitionDuration");
		}
	}

	public TransitionStoreType GlobalBibleTransitionType
	{
		get
		{
			return GetValue("GlobalBibleTransitionType", TransitionStoreType.Cut);
		}
		set
		{
			SetValue("GlobalBibleTransitionType", value);
			OnPropertyChanged("GlobalBibleTransitionType");
		}
	}

	public Pro.SerializationInterop.RVProtoData.Transition? GlobalMessageTransition
	{
		get
		{
			return GetValue<Pro.SerializationInterop.RVProtoData.Transition>("GlobalMessageTransition");
		}
		set
		{
			SetValue("GlobalMessageTransition", value);
			OnPropertyChanged("GlobalMessageTransition");
		}
	}

	public Guid SelectedPreviewScreenID
	{
		get
		{
			return GetValue("SelectedPreviewScreenID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedPreviewScreenID", value);
			OnPropertyChanged("SelectedPreviewScreenID");
		}
	}

	public UpdateChannel UpdateChannel
	{
		get
		{
			return GetValue("UpdateChannel", UpdateChannel.Production);
		}
		set
		{
			SetValue("UpdateChannel", value);
			OnPropertyChanged("UpdateChannel");
		}
	}

	public ObservableDictionary<Guid, PresentationHeaderViewType> HeaderStates => GetValue("HeaderStates", new ObservableDictionary<Guid, PresentationHeaderViewType>()) ?? new ObservableDictionary<Guid, PresentationHeaderViewType>();

	public bool Print_IsThumbnail
	{
		get
		{
			return GetValue("Print_IsThumbnail", defaultValue: true);
		}
		set
		{
			SetValue("Print_IsThumbnail", value);
			OnPropertyChanged("Print_IsThumbnail");
		}
	}

	public bool Print_IsOutline
	{
		get
		{
			return GetValue("Print_IsOutline", defaultValue: false);
		}
		set
		{
			SetValue("Print_IsOutline", value);
			OnPropertyChanged("Print_IsOutline");
		}
	}

	public bool Print_DisableSlides
	{
		get
		{
			return GetValue("Print_DisableSlides", defaultValue: true);
		}
		set
		{
			SetValue("Print_DisableSlides", value);
			OnPropertyChanged("Print_DisableSlides");
		}
	}

	public bool Print_ShowCurrentDate
	{
		get
		{
			return GetValue("Print_ShowCurrentDate", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowCurrentDate", value);
			OnPropertyChanged("Print_ShowCurrentDate");
		}
	}

	public bool Print_ShowNotes
	{
		get
		{
			return GetValue("Print_ShowNotes", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowNotes", value);
			OnPropertyChanged("Print_ShowNotes");
		}
	}

	public bool Print_ShowMetaData
	{
		get
		{
			return GetValue("Print_ShowMetaData", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowMetaData", value);
			OnPropertyChanged("Print_ShowMetaData");
		}
	}

	public bool Print_ShowSlideLabels
	{
		get
		{
			return GetValue("Print_ShowSlideLabels", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowSlideLabels", value);
			OnPropertyChanged("Print_ShowSlideLabels");
		}
	}

	public bool Print_ShowSlideNotes
	{
		get
		{
			return GetValue("Print_ShowSlideNotes", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowSlideNotes", value);
			OnPropertyChanged("Print_ShowSlideNotes");
		}
	}

	public bool Print_ShowSlideNumbers
	{
		get
		{
			return GetValue("Print_ShowSlideNumbers", defaultValue: true);
		}
		set
		{
			SetValue("Print_ShowSlideNumbers", value);
			OnPropertyChanged("Print_ShowSlideNumbers");
		}
	}

	public int Print_ColumnCount
	{
		get
		{
			return GetValue("Print_ColumnCount", 4);
		}
		set
		{
			SetValue("Print_ColumnCount", value);
			OnPropertyChanged("Print_ColumnCount");
		}
	}

	public ImageExportExtension ExportImageExtension
	{
		get
		{
			return GetValue("ExportImageExtension", ImageExportExtension.JPG);
		}
		set
		{
			SetValue("ExportImageExtension", value);
			OnPropertyChanged("ExportImageExtension");
		}
	}

	public string ExportDirectory
	{
		get
		{
			return GetValue("ExportDirectory", CommonPaths.DocumentsFolder) ?? string.Empty;
		}
		set
		{
			SetValue("ExportDirectory", value);
			OnPropertyChanged("ExportDirectory");
		}
	}

	public bool ExportIncludeMedia
	{
		get
		{
			return GetValue("ExportIncludeMedia", defaultValue: false);
		}
		set
		{
			SetValue("ExportIncludeMedia", value);
			OnPropertyChanged("ExportIncludeMedia");
		}
	}

	public bool ShowAdvancedOnScreenStats
	{
		get
		{
			return GetValue("ShowAdvancedOnScreenStats", defaultValue: false);
		}
		set
		{
			SetValue("ShowAdvancedOnScreenStats", value);
			OnPropertyChanged("ShowAdvancedOnScreenStats");
		}
	}

	public UtilityViewType SelectedUtilityView
	{
		get
		{
			return GetValue("SelectedUtilityView", UtilityViewType.Audio);
		}
		set
		{
			SetValue("SelectedUtilityView", value);
			OnPropertyChanged("SelectedUtilityView");
		}
	}

	public QuickSearchType SelectedSearchPage
	{
		get
		{
			return GetValue("SelectedSearchPage", QuickSearchType.Library);
		}
		set
		{
			SetValue("SelectedSearchPage", value);
			OnPropertyChanged("SelectedSearchPage");
		}
	}

	public QuickSearchPreviewType SelectedLibrarySearchPreview
	{
		get
		{
			return GetValue("SelectedLibrarySearchPreview", QuickSearchPreviewType.Text);
		}
		set
		{
			SetValue("SelectedLibrarySearchPreview", value);
			OnPropertyChanged("SelectedLibrarySearchPreview");
		}
	}

	public int LibrarySearchPreviewRowCapacity
	{
		get
		{
			return GetValue("LibrarySearchPreviewRowCapacity", 3);
		}
		set
		{
			SetValue("LibrarySearchPreviewRowCapacity", value);
			OnPropertyChanged("LibrarySearchPreviewRowCapacity");
		}
	}

	public string StageMessage
	{
		get
		{
			return GetValue("StageMessage", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("StageMessage", value);
			OnPropertyChanged("StageMessage");
		}
	}

	public ObservableDictionary<Guid, bool> TimerViewStates => GetValue("TimerViewStates", new ObservableDictionary<Guid, bool>()) ?? new ObservableDictionary<Guid, bool>();

	public List<UtilityViewType> UtilityViewTabs
	{
		get
		{
			return GetValue("UtilityViewTabs", Enum.GetValues<UtilityViewType>().ToList()) ?? Enum.GetValues<UtilityViewType>().ToList();
		}
		set
		{
			SetValue("UtilityViewTabs", value);
			OnPropertyChanged("UtilityViewTabs");
		}
	}

	public ProPresenter.DO.Timecode.TimecodeSettings Timecode { get; } = new ProPresenter.DO.Timecode.TimecodeSettings();

	public ObservableDictionary<Guid, double> TimelineZoomValue => GetValue("TimelineZoomValue", new ObservableDictionary<Guid, double>()) ?? new ObservableDictionary<Guid, double>();

	private Pro.SerializationInterop.RVProtoData.TimecodeSettings? ProtoTimecodeSettings
	{
		get
		{
			return GetValue<Pro.SerializationInterop.RVProtoData.TimecodeSettings>("ProtoTimecodeSettings");
		}
		set
		{
			SetValue("ProtoTimecodeSettings", value);
			OnPropertyChanged("ProtoTimecodeSettings");
		}
	}

	private int MacroColorLastIndex
	{
		get
		{
			return GetValue("MacroColorLastIndex", 0);
		}
		set
		{
			SetValue("MacroColorLastIndex", value);
			OnPropertyChanged("MacroColorLastIndex");
		}
	}

	private int PlaybackMarkerColorLastIndex
	{
		get
		{
			return GetValue("PlaybackMarkerColorLastIndex", 0);
		}
		set
		{
			SetValue("PlaybackMarkerColorLastIndex", value);
			OnPropertyChanged("PlaybackMarkerColorLastIndex");
		}
	}

	public bool SongSelectAutoReportSongUsage
	{
		get
		{
			return GetValue("SongSelectAutoReportSongUsage", defaultValue: false);
		}
		set
		{
			SetValue("SongSelectAutoReportSongUsage", value);
			OnPropertyChanged("SongSelectAutoReportSongUsage");
		}
	}

	public string ProContentAccessToken
	{
		get
		{
			return GetValue("ProContentAccessToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ProContentAccessToken", value);
			OnPropertyChanged("ProContentAccessToken");
		}
	}

	public string ProContentRefreshToken
	{
		get
		{
			return GetValue("ProContentRefreshToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ProContentRefreshToken", value);
			OnPropertyChanged("ProContentRefreshToken");
		}
	}

	public DateTimeOffset? ProContentAccessTokenExpiration
	{
		get
		{
			return GetValue<DateTimeOffset?>("ProContentAccessTokenExpiration", null);
		}
		set
		{
			SetValue("ProContentAccessTokenExpiration", value);
			OnPropertyChanged("ProContentAccessTokenExpiration");
		}
	}

	public string? ProContentUserName
	{
		get
		{
			return GetValue("ProContentUserName", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ProContentUserName", value);
			OnPropertyChanged("ProContentUserName");
		}
	}

	public string? ProContentUserEmail
	{
		get
		{
			return GetValue("ProContentUserEmail", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("ProContentUserEmail", value);
			OnPropertyChanged("ProContentUserEmail");
		}
	}

	public string SelectedProContentFormat
	{
		get
		{
			return GetValue<string>("SelectedProContentFormat") ?? string.Empty;
		}
		set
		{
			SetValue("SelectedProContentFormat", value);
			OnPropertyChanged("SelectedProContentFormat");
		}
	}

	public ushort ProContentCachingPolicyGroupTimeToLive
	{
		get
		{
			return GetValue("ProContentCachingPolicyGroupTimeToLive", (ushort)30);
		}
		set
		{
			SetValue("ProContentCachingPolicyGroupTimeToLive", value);
			OnPropertyChanged("ProContentCachingPolicyGroupTimeToLive");
		}
	}

	public ushort ProContentRefreshPolicyRefreshOutline
	{
		get
		{
			return GetValue("ProContentRefreshPolicyRefreshOutline", (ushort)1440);
		}
		set
		{
			SetValue("ProContentRefreshPolicyRefreshOutline", value);
			OnPropertyChanged("ProContentRefreshPolicyRefreshOutline");
		}
	}

	public int ConcurrentDownloadLimit
	{
		get
		{
			return GetValue("ConcurrentDownloadLimit", int.MaxValue);
		}
		set
		{
			SetValue("ConcurrentDownloadLimit", value);
			OnPropertyChanged("ConcurrentDownloadLimit");
		}
	}

	public int ProContentPackDownloadPreferences
	{
		get
		{
			return GetValue("ProContentPackDownloadPreferences", 1);
		}
		set
		{
			SetValue("ProContentPackDownloadPreferences", value);
			OnPropertyChanged("ProContentPackDownloadPreferences");
		}
	}

	public PanelViewType MacroViewPanelType
	{
		get
		{
			return GetValue("MacroViewPanelType", PanelViewType.List);
		}
		set
		{
			SetValue("MacroViewPanelType", value);
		}
	}

	public PanelViewType PropsViewPanelType
	{
		get
		{
			return GetValue("PropsViewPanelType", PanelViewType.Thumbnail);
		}
		set
		{
			SetValue("PropsViewPanelType", value);
		}
	}

	public int PropViewRowCapacity
	{
		get
		{
			return GetValue("PropViewRowCapacity", 4);
		}
		set
		{
			SetValue("PropViewRowCapacity", value);
			OnPropertyChanged("PropViewRowCapacity");
		}
	}

	public Guid SelectedPropGroupId
	{
		get
		{
			return GetValue("SelectedPropGroupId", Guid.Empty);
		}
		set
		{
			SetValue("SelectedPropGroupId", value);
		}
	}

	public Guid SelectedMacroGroupId
	{
		get
		{
			return GetValue("SelectedMacroGroupId", Guid.Empty);
		}
		set
		{
			SetValue("SelectedMacroGroupId", value);
		}
	}

	public BitDepth RenderBitDepth
	{
		get
		{
			return GetValue("RenderBitDepth", BitDepth.Normal);
		}
		set
		{
			SetValue("RenderBitDepth", value);
			OnPropertyChanged("RenderBitDepth");
		}
	}

	public ulong CollaborationPeerId { get; }

	public App(ICookieManagerService cookieManagerService)
		: base(Path.Combine(CommonPaths.Preferences, "AppPreferences.proPref"))
	{
		_cookieManagerService = cookieManagerService;
		RegisterArrayType<string>();
		RegisterEnumType<ColorTheme>();
		RegisterEnumType<AudioSortType>();
		RegisterEnumType<PanelViewType>();
		RegisterEnumType<BreakMode>();
		RegisterEnumType<FormatLength>();
		RegisterEnumType<ParagraphAlignment>();
		RegisterEnumType<DocumentAlignment>();
		RegisterEnumType<TruncatingMode>();
		RegisterEnumType<ImageExportExtension>();
		RegisterEnumType<UtilityViewType>();
		RegisterEnumType<QuickSearchType>();
		RegisterEnumType<QuickSearchPreviewType>();
		RegisterEnumType<MultiTracksSubscriptionStatus>();
		RegisterEnumType<MultiTracksSubscriptionLevel>();
		RegisterEnumType<BitDepth>();
		RegisterCustomType((IColorTrigger v) => v.Encode(), ColorTrigger.Decode);
		RegisterListType(delegate(IColorTrigger i, ColorTriggerCollection l)
		{
			if (i != null)
			{
				l.Add(i);
			}
		});
		RegisterEnumType<TransitionStoreType>();
		RegisterCustomType(ProtoHelper.EncodeBase64, ProtoHelper.DecodeBase64<Pro.SerializationInterop.RVProtoData.Transition>);
		RegisterCustomType(ProtoHelper.EncodeBase64, ProtoHelper.DecodeBase64<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>);
		RegisterCustomType(FontInfoExtensions.Encode, FontInfoExtensions.Decode);
		RegisterListType<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset, List<Pro.SerializationInterop.RVProtoData.Transition.Types.Preset>>();
		RegisterListType<string, ObservableCollection<string>>();
		RegisterCustomType(ProtoHelper.EncodeBase64, ProtoHelper.DecodeBase64<Pro.SerializationInterop.RVProtoData.TimecodeSettings>);
		RegisterEnumType<PresentationHeaderViewType>();
		RegisterDictionaryType<Guid, PresentationHeaderViewType, ObservableDictionary<Guid, PresentationHeaderViewType>>();
		RegisterDictionaryType<Guid, double, ObservableDictionary<Guid, double>>();
		RegisterDictionaryType<Guid, bool, ObservableDictionary<Guid, bool>>();
		RegisterListType<UtilityViewType>();
		RegisterCustomType((System.Version v) => (v != null) ? v.ToString() : string.Empty, System.Version.Parse);
		RegisterEnumType<UpdateChannel>();
		RegisterCustomType((bool? v) => v?.ToString() ?? string.Empty, (string s) => (!bool.TryParse(s, out var result)) ? ((bool?)null) : new bool?(result));
		RegisterCustomType((ulong? u) => u?.ToString() ?? string.Empty, (string s) => (!ulong.TryParse(s, out var result2)) ? ((ulong?)null) : new ulong?(result2));
		if (HeaderStates != null)
		{
			HeaderStates.CollectionChanged += delegate
			{
				SetValue("HeaderStates", HeaderStates);
			};
		}
		if (TimerViewStates != null)
		{
			TimerViewStates.CollectionChanged += delegate
			{
				SetValue("TimerViewStates", TimerViewStates);
			};
		}
		if (TimelineZoomValue != null)
		{
			TimelineZoomValue.CollectionChanged += delegate
			{
				SetValue("TimelineZoomValue", TimelineZoomValue);
			};
		}
		DefaultColorTriggers.CollectionChanged += delegate
		{
			SetValue("DefaultColorTriggers", DefaultColorTriggers);
		};
		IsFirstLaunch = GetValue("IsFirstLaunch", defaultValue: true);
		System.Version value = GetValue("LastVersion", new System.Version());
		value.ThrowWhenNull("lastVersion");
		LastVersion = value;
		System.Version appVersion = VersionInfo.AppVersion;
		HighestVersion = GetValue("HighestVersion", appVersion);
		SetValue("IsFirstLaunch", value: false);
		SetValue("LastVersion", appVersion);
		SetValue("HighestVersion", (appVersion > HighestVersion) ? appVersion : HighestVersion);
		Timecode.Deserialize(GetValue<Pro.SerializationInterop.RVProtoData.TimecodeSettings>("ProtoTimecodeSettings"));
		Timecode.DataModified += delegate
		{
			ProtoTimecodeSettings = Timecode.Serialize();
		};
		ulong? value2 = GetValue<ulong?>("CollaborationPeerId", null);
		if (!value2.HasValue)
		{
			byte[] array = new byte[8];
			RandomNumberGenerator.Fill(array);
			value2 = BitConverter.ToUInt64(array, 0);
			SetValue("CollaborationPeerId", value2);
		}
		CollaborationPeerId = value2.Value;
	}

	public System.Windows.Media.Color GetNextMacroColor()
	{
		int num = MacroColorLastIndex % DefaultColors.ColorPalette.Length;
		MacroColorLastIndex++;
		return DefaultColors.ColorPalette[num];
	}

	public System.Windows.Media.Color GetNextPlaybackMarkerColor()
	{
		int num = PlaybackMarkerColorLastIndex % NeonColors.ColorPalette.Length;
		PlaybackMarkerColorLastIndex++;
		return NeonColors.ColorPalette[num];
	}

	public void MigrateForward(IDatabaseService databaseService)
	{
		_migratingForward = true;
		databaseService.PerformDatabaseOperationWithLogging(delegate
		{
			_cookieManagerService.CreateOrUpdate("planning_center_session", PCOPlanningSessionCookie, ".planningcenteronline.com", PCOPlanningSessionCookieExpiration ?? DateTime.MinValue);
			_cookieManagerService.CreateOrUpdate("_account_center_session", PCOSessionCookie, ".planningcenteronline.com", PCOSessionCookieExpiration ?? DateTime.MinValue);
		});
		_migratingForward = false;
	}

	public void MigrateBackward(IDatabaseService databaseService, MigrationTypes types)
	{
		if (!_migratingForward && (uint)types <= 1u)
		{
			MigrateCookies();
		}
	}

	private void MigrateCookies()
	{
		CookieModel cookie = _cookieManagerService.GetCookie(".planningcenteronline.com", "planning_center_session");
		if ((object)cookie != null)
		{
			PCOPlanningSessionCookie = cookie.Value;
			PCOPlanningSessionCookieExpiration = cookie.Expiration;
			CookieModel cookie2 = _cookieManagerService.GetCookie(".planningcenteronline.com", "_account_center_session");
			if ((object)cookie2 != null)
			{
				PCOSessionCookie = cookie2.Value;
				PCOSessionCookieExpiration = cookie2.Expiration;
			}
		}
	}

	public void SaveClockData(ClockData? value)
	{
		DefaultClockDateFormatLength = value?.DateFormatLength ?? FormatLength.None;
		DefaultClockTimeFormatLength = value?.TimeFormatLength ?? FormatLength.None;
		DefaultClockUse24HourMode = value?.Use24HourFormat ?? false;
	}

	void IApp.UpdateSettingsFile()
	{
		UpdateSettingsFile();
	}
}
