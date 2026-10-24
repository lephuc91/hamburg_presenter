using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Localization.Services;
using Pro.UI.Themes;
using Pro.UI.Utility;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics.Events.UIPreferences;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public class GeneralSettingsVM : LinkedNotifyPropertyChangedBase, IGeneralSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IGeneral _general;

	private readonly IApp _app;

	private readonly IOutputRepository _outputRepository;

	private readonly ICoreManager _manager;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly IUiPreferencesAnalyticEventsPublisher _uiPreferencesAnalyticEventsPublisher;

	private readonly IProcessHelper _processHelper;

	private readonly RelayCommand _removeLogoCommand;

	private readonly RelayCommand _openFileLocationCommand;

	private readonly ILogger _logger;

	private readonly IMediaFactory _mediaFactory;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly ICloudOnboardingService _cloudOnboardingService;

	private RelativePath _supportFolder = new RelativePath(CommonPaths.Base);

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; }

	public string Name { get; }

	public bool EnableHoW
	{
		get
		{
			return _general.ShowHoW;
		}
		set
		{
			_general.ShowHoW = value;
		}
	}

	public bool EnableCrashReporting
	{
		get
		{
			return _general.EnableCrashReporting;
		}
		set
		{
			_general.EnableCrashReporting = value;
		}
	}

	public bool EnableAnalytics
	{
		get
		{
			return _general.EnableAnalytics;
		}
		set
		{
			_general.EnableAnalytics = value;
		}
	}

	public BitmapSource? LogoImageSource => _manager.Logo?.VisualMedia?.Drawing.PreviewImage;

	public CultureInfo SelectedLanguage
	{
		get
		{
			return _general.SelectedLanguage;
		}
		set
		{
			_general.SelectedLanguage = value;
		}
	}

	public IReadOnlyCollection<CultureInfo> AvailableLanguages => _general.AvailableLanguages;

	public ICommand AddLogoCommand => new RelayCommand(AddLogoCommandExecuted);

	public ICommand RemoveLogoCommand => _removeLogoCommand;

	public ICommand OpenFileLocationCommand => _openFileLocationCommand;

	public ICopyrightSettingsVM CopyrightSettingsVM { get; }

	public ISettingsItemVM? Parent => null;

	public Brush Background => SettingsListItemConstants.Gray;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsGeneral);

	public bool IsNavigable => true;

	public bool CanExit => true;

	public bool ShouldShowCloudTease => _cloudOnboardingService.ShouldShowCloudTease();

	public ICommand LearnMoreCloudCommand => new RelayCommand(LearnMoreCloud);

	public ICommand SignUpForEarlyAccessCommand => new RelayCommand(SignUpForEarlyAccess);

	public GeneralSettingsVM(IGeneral general, IApp app, ICopyrightSettingsVM copyrightSettingsVM, ICoreManager manager, IFileSelectorService fileSelectorService, IUiPreferencesAnalyticEventsPublisher uiPreferencesAnalyticEventsPublisher, IProcessHelper processHelper, ILocalization localization, ISettingsSearchFactory settingsSearchFactory, ILogger logger, IMediaFactory mediaFactory, IImportProcessFactory importProcessFactory, IOutputRepository outputRepository, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ICloudOnboardingService cloudOnboardingService)
	{
		_general = general;
		_app = app;
		CopyrightSettingsVM = copyrightSettingsVM;
		CopyrightSettingsVM.SetParent(this);
		_manager = manager;
		_fileSelectorService = fileSelectorService;
		_uiPreferencesAnalyticEventsPublisher = uiPreferencesAnalyticEventsPublisher;
		_processHelper = processHelper;
		_logger = logger;
		_mediaFactory = mediaFactory;
		_importProcessFactory = importProcessFactory;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_cloudOnboardingService = cloudOnboardingService;
		_removeLogoCommand = new RelayCommand(RemoveLogoCommandExecuted, () => LogoImageSource != null);
		_openFileLocationCommand = new RelayCommand(delegate
		{
			_processHelper.OpenFileInExplorer(_general.LogoFilename);
		}, () => LogoImageSource != null);
		LinkAction("Logo", delegate
		{
			OnPropertyChanged("LogoImageSource");
			_removeLogoCommand.NotifyCanExecuteChanged();
			_openFileLocationCommand.NotifyCanExecuteChanged();
		});
		Name = localization.Get("SETTINGS_GENERAL_PAGE_title");
		LinkProperties("ShowHoW", "EnableHoW");
		LinkProperties("EnableCrashReporting", "EnableCrashReporting");
		LinkProperties("EnableAnalytics", "EnableAnalytics");
		LinkProperties("SelectedLanguage", "SelectedLanguage");
		LinkAction("LogoFilename", SetLogo);
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		SubPages = CopyrightSettingsVM.ToEnumerable();
		Fields = settingsSearchFactory.GetFields("SETTINGS_GENERAL_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_HOUSE_OF_WORSHIP_INTEGRATIONS_BUTTON_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_SHARE_CRASH_REPORTS_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_SHARE_ANALYTICS_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_HEADER_SUPPORT_FILES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_SUPPORT_FILES_PATH_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_LOGO_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_LANGUAGE_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_LANGUAGE_SELECTOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_COPYRIGHT_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_ENABLE_COPYRIGHT_DISPLAY_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_COPYRIGHT_DISPLAY_LOCATION_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_CCLI_LICENSE_NUMBER_LABEL_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_COPYRIGHT_LAYOUT_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_LOCALWORKSPACE_WORKSPACE_HEADER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_GENERAL_LOCALWORKSPACE_ACTIVE_WORKSPACE_title", this, isComponent: true));
		if (ShouldShowCloudTease)
		{
			Fields = Fields.Concat(settingsSearchFactory.GetFields("CLOUD_COMING_SOON_CLOUD_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("CLOUD_COMING_SOON_SIGN_UP_BUTTON_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("CLOUD_COMING_SOON_SETTINGS_title", this, isComponent: true))
				.Concat(settingsSearchFactory.GetFields("CLOUD_COMING_SOON_LEARN_MORE_BUTTON_title", this, isComponent: true));
		}
		_general.PropertyChanged += base.RaiseLinkedValues;
		_manager.PropertyChanged += base.RaiseLinkedValues;
		SetLogo();
		_outputRepository = outputRepository;
	}

	private void AddLogoCommandExecuted()
	{
		if (!_fileSelectorService.SelectFile(out string selectedFile, FileFilters.ImageFilter))
		{
			return;
		}
		if (selectedFile != _general.LogoFilename)
		{
			_uiPreferencesAnalyticEventsPublisher.HasLogo(hasLogo: true);
		}
		_importProcessFactory.Create(new string[1] { selectedFile }.Select((string file) => new FileImportRequest(file, delegate(string _, string n, FileMediaBase? _)
		{
			_general.LogoFilename = n;
		}))).StartImport();
	}

	private void RemoveLogoCommandExecuted()
	{
		if (!string.IsNullOrEmpty(_general.LogoFilename))
		{
			_uiPreferencesAnalyticEventsPublisher.HasLogo(hasLogo: false);
		}
		_general.LogoFilename = string.Empty;
	}

	private void SetLogo()
	{
		if (string.IsNullOrWhiteSpace(_general.LogoFilename))
		{
			_manager.Logo = null;
			return;
		}
		if (!_general.LogoFilename.IsImageFile())
		{
			_manager.Logo = null;
			_logger.Warning("Unable to create logo for file - " + _general.LogoFilename);
			return;
		}
		string logoFilename = _general.LogoFilename;
		FileMediaBase fileMediaBase = _mediaFactory.CreateEmptyFileMedia(logoFilename, "", null);
		fileMediaBase.MetadataLoadSuccessful += LogoMetadataLoaded;
		fileMediaBase.MetadataLoadFailed += LogoMetadataLoadFailed;
		fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)logoFilename);
	}

	private void LogoMetadataLoadFailed(FileMediaBase media)
	{
		media.MetadataLoadFailed -= LogoMetadataLoadFailed;
		media.MetadataLoadSuccessful -= LogoMetadataLoaded;
		RemoveLogoCommandExecuted();
	}

	private void LogoMetadataLoaded(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= LogoMetadataLoaded;
		media.MetadataLoadFailed -= LogoMetadataLoadFailed;
		UpdateLogoThumbnail(media);
	}

	private void UpdateLogoThumbnail(MediaBase media)
	{
		VisualMedia visualMedia = (VisualMedia)media;
		visualMedia.MetadataLoadSuccessful -= LogoMetadataLoaded;
		visualMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFit;
		_manager.Logo = new MediaAction(visualMedia, _app, _outputRepository.AvailableTransitions)
		{
			TriggerLayer = TriggerLayer.Foreground
		};
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}

	private void LearnMoreCloud()
	{
		_hyperlinkService.Open(_webSourceProvider.DiscoverCloud);
	}

	private void SignUpForEarlyAccess()
	{
		_hyperlinkService.Open(_webSourceProvider.CloudEarlyAccess);
	}
}
