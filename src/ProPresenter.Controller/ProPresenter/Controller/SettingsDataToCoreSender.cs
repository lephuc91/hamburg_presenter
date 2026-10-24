using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using Pro.Common.Components;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Localization.Services;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Settings;

namespace ProPresenter.Controller;

public class SettingsDataToCoreSender : DisposableBase, ISettingsDataToCoreSender, IDisposable
{
	private readonly IGeneral _general;

	private readonly IDisplay _display;

	private readonly IImport _import;

	private readonly INetwork _network;

	private readonly IAdvanced _advanced;

	private readonly ISync _sync;

	private readonly IApp _app;

	private readonly ICoreManager _coreManager;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ILocalization _localization;

	public SettingsDataToCoreSender(IGeneral general, IDisplay display, IImport import, INetwork network, IAdvanced advanced, ISync sync, IApp app, IProPresenterResourceService resourceService, ILocalization localization, ICoreManager coreManager)
	{
		_general = general;
		_display = display;
		_import = import;
		_network = network;
		_advanced = advanced;
		_sync = sync;
		_app = app;
		_coreManager = coreManager;
		_resourceService = resourceService;
		_localization = localization;
		_general.PropertyChanged += General_PropertyChanged;
		_display.PropertyChanged += Display_PropertyChanged;
		_import.PropertyChanged += Import_PropertyChanged;
		_network.PropertyChanged += Network_PropertyChanged;
		_advanced.PropertyChanged += Advanced_PropertyChanged;
		_sync.PropertyChanged += Sync_PropertyChanged;
		_app.PropertyChanged += App_PropertyChanged;
		_resourceService.GroupLabels.CollectionChanged += OnCollectionChanged;
		_resourceService.GroupLabels.ContentsModified += SendSettingsToCore;
		_resourceService.SlideLabels.CollectionChanged += OnCollectionChanged;
		_resourceService.SlideLabels.ContentsModified += SendSettingsToCore;
	}

	private void General_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SelectedLanguage" || e.PropertyName == "ShowHoW" || e.PropertyName == "EnableCrashReporting" || e.PropertyName == "EnableAnalytics" || e.PropertyName == "LogoFilename" || e.PropertyName == "ShowOutputAtLaunch")
		{
			SendSettingsToCore();
		}
	}

	private void Display_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SelectedClockSource")
		{
			SendSettingsToCore();
		}
	}

	private void Import_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ImportDurationType" || e.PropertyName == "ImageDurationTime" || e.PropertyName == "RandomMinTime" || e.PropertyName == "RandomMaxTime" || e.PropertyName == "ForegroundScaleBehavior" || e.PropertyName == "BackgroundScaleBehavior" || e.PropertyName == "ImageLayer" || e.PropertyName == "ImageNextBehavior" || e.PropertyName == "VideoLayer" || e.PropertyName == "VideoPlaybackBehavior" || e.PropertyName == "VideoEndBehavior" || e.PropertyName == "VideoNextBehavior" || e.PropertyName == "AudioPlaybackBehavior")
		{
			SendSettingsToCore();
		}
	}

	private void Network_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "EnableNetwork" || e.PropertyName == "NetworkName" || e.PropertyName == "NetworkPort" || e.PropertyName == "EnableRemoteStageDisplay" || e.PropertyName == "RemoteStageDisplayPassword" || e.PropertyName == "EnableLink" || e.PropertyName == "LinkGroup")
		{
			SendSettingsToCore();
		}
	}

	private void Advanced_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ShowScreenStats" || e.PropertyName == "IgnoreBackgroundColors" || e.PropertyName == "SuppressVideoStart" || e.PropertyName == "PresentationForegroundMediaAudioBehavior" || e.PropertyName == "AnnouncementForegroundMediaAudioBehavior" || e.PropertyName == "NDIShowLocalSources" || e.PropertyName == "NDIInputGroups" || e.PropertyName == "NDIExtraIPs" || e.PropertyName == "ManageMediaAutomatically" || e.PropertyName == "EnableSearchRoots" || e.PropertyName == "SearchRoots")
		{
			SendSettingsToCore();
		}
	}

	private void Sync_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "LocalSyncSource" || e.PropertyName == "LocalSyncIncludeLibraryDoc" || e.PropertyName == "LocalSyncIncludeMedia" || e.PropertyName == "LocalSyncIncludePlaylists" || e.PropertyName == "LocalSyncIncludeTemplates" || e.PropertyName == "LocalSyncIncludeUserData" || e.PropertyName == "LocalSyncUp" || e.PropertyName == "ReplaceFiles")
		{
			SendSettingsToCore();
		}
	}

	private void App_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "NotifyUpdates" || e.PropertyName == "UpdateChannel")
		{
			SendSettingsToCore();
		}
	}

	private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SendSettingsToCore();
	}

	public void SendSettingsToCore()
	{
		_coreManager.SendPreferencesData(Serialize());
	}

	private Preferences Serialize()
	{
		return new Preferences
		{
			General = SerializeGeneral(),
			Screens = SerializeScreens(),
			Import = SerializeImport(),
			Groups = SerializeGroups(),
			Network = SerializeNetwork(),
			Sync = SerializeSync(),
			Advanced = SerializeAdvanced(),
			Updates = SerializeUpdates()
		};
	}

	protected override void OnDispose(bool disposeObjects)
	{
		_general.PropertyChanged -= General_PropertyChanged;
		_display.PropertyChanged -= Display_PropertyChanged;
		_import.PropertyChanged -= Import_PropertyChanged;
		_network.PropertyChanged -= Network_PropertyChanged;
		_advanced.PropertyChanged -= Advanced_PropertyChanged;
		_sync.PropertyChanged -= Sync_PropertyChanged;
		_app.PropertyChanged -= App_PropertyChanged;
		_resourceService.GroupLabels.CollectionChanged -= OnCollectionChanged;
		_resourceService.GroupLabels.ContentsModified -= SendSettingsToCore;
		_resourceService.SlideLabels.CollectionChanged -= OnCollectionChanged;
		_resourceService.SlideLabels.ContentsModified -= SendSettingsToCore;
		base.OnDispose(disposeObjects);
	}

	private Preferences.Types.General SerializeGeneral()
	{
		string text = _general.SelectedLanguage?.Name ?? string.Empty;
		if (text.Length == 0)
		{
			text = CultureInfo.CurrentCulture.Name;
		}
		return new Preferences.Types.General
		{
			HouseOfWorshipIntegrations = _general.ShowHoW,
			CrashReports = _general.EnableCrashReporting,
			Analytics = _general.EnableAnalytics,
			LogoPath = _general.LogoFilename,
			Language = text
		};
	}

	public Preferences.Types.Screens SerializeScreens()
	{
		return new Preferences.Types.Screens
		{
			EnableAtLaunch = _general.ShowOutputAtLaunch,
			ShowPerformanceStats = _advanced.ShowScreenStats,
			IgnoreBackgroundColors = _advanced.IgnoreBackgroundColors,
			ClockSource = _display.SelectedClockSource,
			UseDirectxRendering = true
		};
	}

	public Preferences.Types.Import SerializeImport()
	{
		Preferences.Types.Import.Types.Image.Types.Duration duration = new Preferences.Types.Import.Types.Image.Types.Duration();
		switch (_import.ImportDurationType)
		{
		case ImportDurationType.None:
			duration.None = new Preferences.Types.Import.Types.Image.Types.Duration.Types.None();
			break;
		case ImportDurationType.Time:
			duration.Time = new Preferences.Types.Import.Types.Image.Types.Duration.Types.Time
			{
				Time_ = _import.ImageDurationTime.TotalSeconds
			};
			break;
		case ImportDurationType.Random:
			duration.Random = new Preferences.Types.Import.Types.Image.Types.Duration.Types.Random
			{
				MinimumTime = _import.RandomMinTime,
				MaximumTime = _import.RandomMaxTime
			};
			break;
		}
		bool isBlurred;
		bool isBlurred2;
		return new Preferences.Types.Import
		{
			ForegroundScaling = _import.ForegroundScaleBehavior.ToProtoScaleBehavior(out isBlurred),
			ForegroundIsBlurred = isBlurred,
			BackgroundScaling = _import.BackgroundScaleBehavior.ToProtoScaleBehavior(out isBlurred2),
			BackgroundIsBlurred = isBlurred2,
			Image = new Preferences.Types.Import.Types.Image
			{
				LayerType = _import.ImageLayer.ToProtoImportLayer(),
				Duration = duration,
				NextBehavior = _import.ImageNextBehavior.ToProtoCompletionTargetType()
			},
			Video = new Preferences.Types.Import.Types.Video
			{
				LayerType = _import.VideoLayer.ToProtoImportLayer(),
				PlaybackBehavior = _import.VideoPlaybackBehavior.ToProtoPlaybackBehavior(),
				EndBehavior = _import.VideoEndBehavior.GetProtoEndBehavior(),
				NextBehavior = _import.VideoNextBehavior.ToProtoCompletionTargetType()
			},
			Audio = new Preferences.Types.Import.Types.Audio
			{
				PlaybackBehavior = ((_import.AudioPlaybackBehavior == AudioBehaviorType.Loop) ? Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Loop : Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Stop),
				NextBehavior = ((_import.AudioPlaybackBehavior == AudioBehaviorType.Next) ? Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next : Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None)
			}
		};
	}

	public Preferences.Types.Groups SerializeGroups()
	{
		return new Preferences.Types.Groups
		{
			Groups_ = _resourceService.GroupLabels.Serialize(),
			Labels = _resourceService.SlideLabels.Serialize()
		};
	}

	public Preferences.Types.Network SerializeNetwork()
	{
		return new Preferences.Types.Network
		{
			Network_ = new Preferences.Types.Network.Types.Network
			{
				Enable = _network.EnableNetwork,
				Name = _network.NetworkName,
				Port = (uint)_network.NetworkPort
			},
			Remotes = new Preferences.Types.Network.Types.Remotes
			{
				StageApp = new Preferences.Types.Network.Types.Remotes.Types.StageApp
				{
					Enable = _network.EnableRemoteStageDisplay,
					Password = _network.RemoteStageDisplayPassword
				}
			},
			Link = new Preferences.Types.Network.Types.Link
			{
				Enable = _network.EnableLink,
				LinkGroup = (_network.LinkGroup?.Name ?? string.Empty)
			}
		};
	}

	public Preferences.Types.Sync SerializeSync()
	{
		return new Preferences.Types.Sync
		{
			Repository = _sync.LocalSyncSource,
			IncludeLibraries = _sync.LocalSyncIncludeLibraryDoc,
			IncludeMedia = _sync.LocalSyncIncludeMedia,
			IncludePlaylists = _sync.LocalSyncIncludePlaylists,
			IncludeThemes = _sync.LocalSyncIncludeTemplates,
			IncludeSupportFiles = _sync.LocalSyncIncludeUserData,
			Direction = (_sync.LocalSyncUp ? Preferences.Types.Sync.Types.SyncDirection.SyncUp : Preferences.Types.Sync.Types.SyncDirection.SyncDown),
			ReplaceDestinationFiles = _sync.ReplaceFiles
		};
	}

	public Preferences.Types.Advanced SerializeAdvanced()
	{
		Preferences.Types.Advanced advanced = new Preferences.Types.Advanced
		{
			SuppressAutoStart = _advanced.SuppressVideoStart,
			PresentationAudioBehavior = _advanced.PresentationForegroundMediaAudioBehavior.ToProtoBehavior(),
			AnnouncementsAudioBehavior = _advanced.AnnouncementForegroundMediaAudioBehavior.ToProtoBehavior(),
			NdiDiscovery = new Preferences.Types.Advanced.Types.NDIDiscovery
			{
				ShowLocalSources = _advanced.NDIShowLocalSources,
				ReceiveGroups = _advanced.NDIInputGroups,
				AdditionalSearchIps = _advanced.NDIExtraIPs
			},
			SupportFilesPath = CommonPaths.Base,
			ManageMediaAutomatically = _advanced.ManageMediaAutomatically,
			SearchPaths = new Preferences.Types.Advanced.Types.SearchPaths
			{
				AutomaticallyRelink = _advanced.EnableSearchRoots
			}
		};
		foreach (ISearchRoot searchRoot in _advanced.SearchRoots)
		{
			advanced.SearchPaths.Paths.Add(new Preferences.Types.Advanced.Types.SearchPaths.Types.Path
			{
				Enable = searchRoot.IsActive,
				Name = _localization.Get(searchRoot.Type),
				Path_ = RelativePath.GetSearchRootPath(searchRoot),
				UrlRoot = searchRoot.Type.ToProtoLocalRoot()
			});
		}
		return advanced;
	}

	public Preferences.Types.Updates SerializeUpdates()
	{
		return new Preferences.Types.Updates
		{
			NotifyWhenAvailable = _app.NotifyUpdates,
			UpdateChannel = ((_app.UpdateChannel == UpdateChannel.Beta) ? Preferences.Types.Updates.Types.Channel.Beta : Preferences.Types.Updates.Types.Channel.Production)
		};
	}
}
