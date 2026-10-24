using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaSettingsVM : LinkedNotifyPropertyChangedBase, IMediaSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IAdvanced _advanced;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; }

	public string Name { get; }

	public bool ManageMediaAutomatically
	{
		get
		{
			return _advanced.ManageMediaAutomatically;
		}
		set
		{
			_advanced.ManageMediaAutomatically = value;
		}
	}

	public bool AutoRelink
	{
		get
		{
			return _advanced.EnableSearchRoots;
		}
		set
		{
			_advanced.EnableSearchRoots = value;
		}
	}

	public IMediaSearchPathsSettingsVM SearchPathsSettingsVM { get; }

	public IMediaCleanupVM MediaCleanupVM { get; }

	public bool SuppressVideoStart
	{
		get
		{
			return _advanced.SuppressVideoStart;
		}
		set
		{
			_advanced.SuppressVideoStart = value;
		}
	}

	public ForegroundMediaAudioBehaviorInternal PresentationForegroundMediaAudioBehavior
	{
		get
		{
			return _advanced.PresentationForegroundMediaAudioBehavior.ToBehaviorInternal();
		}
		set
		{
			_advanced.PresentationForegroundMediaAudioBehavior = value.ToBehavior();
		}
	}

	public ForegroundMediaAudioBehaviorInternal AnnouncementForegroundMediaAudioBehavior
	{
		get
		{
			return _advanced.AnnouncementForegroundMediaAudioBehavior.ToBehaviorInternal();
		}
		set
		{
			_advanced.AnnouncementForegroundMediaAudioBehavior = value.ToBehavior();
		}
	}

	public ISettingsItemVM? Parent => null;

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpMediaManagement));
	});

	public Brush Background => SettingsListItemConstants.Green;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsMedia);

	public bool IsNavigable => true;

	public bool CanExit => true;

	public MediaSettingsVM(IMediaSearchPathsSettingsVM searchPathsSettingsVM, IAdvanced advanced, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory, IMediaCleanupVM mediaCleanupVM)
	{
		SearchPathsSettingsVM = searchPathsSettingsVM;
		_advanced = advanced;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = localization.Get("SETTINGS_MEDIA_PAGE_title");
		searchPathsSettingsVM.SetParent(this);
		LinkProperties("ManageMediaAutomatically", "ManageMediaAutomatically");
		LinkProperties("EnableSearchRoots", "AutoRelink");
		LinkProperties("SuppressVideoStart", "SuppressVideoStart");
		LinkProperties("PresentationForegroundMediaAudioBehavior", "PresentationForegroundMediaAudioBehavior");
		LinkProperties("AnnouncementForegroundMediaAudioBehavior", "AnnouncementForegroundMediaAudioBehavior");
		_advanced.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		SubPages = SearchPathsSettingsVM.ToEnumerable();
		Fields = settingsSearchFactory.GetFields("SETTINGS_MEDIA_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_MEDIA_MANAGEMENT_SECTION_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_MANAGE_MEDIA_AUTOMATICALLY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_MISSING_MEDIA_AUTO_RELINK_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_VIDEO_PLAYBACK_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_SUPPRESS_AUTO_START_VIDEO_windows_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_FOREGROUND_MEDIA_BEHAVIOR_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_PRESENTATION_MEDIA_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_ANNOUNCEMENT_MEDIA_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_MEDIA_CLEANUP_UNLINKED_MEDIA_title", this, isComponent: true));
		MediaCleanupVM = mediaCleanupVM;
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
