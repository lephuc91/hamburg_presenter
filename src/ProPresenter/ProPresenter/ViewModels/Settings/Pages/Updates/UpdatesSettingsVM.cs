using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Common.Versioning;
using Pro.Localization.Services;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Themes;
using Pro.Web.Services;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Updates;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Updates;

public class UpdatesSettingsVM : LinkedNotifyPropertyChangedBase, IUpdatesSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private const string PurchaseSubscriptionButtonTitleKey = "UPDATES_PURCHASE_SUBSCRIPTION_title";

	private const string UpdateNowButtonTitleKey = "SETTINGS_UPDATES_UPDATE_NOW_BUTTON_title";

	private ProPresenter.UI.ViewModels.UpdateChannel _channelSelected;

	private readonly IAppUpdateService _appUpdateService;

	private readonly IGeneral _general;

	private readonly IApp _app;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly Uri _purchaseSubscriptionUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? checkUpdatesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showInstalledReleaseNotesCommand;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public string Name { get; }

	public string InstalledVersion => _versionInfoProvider.FullDisplayAppVersion;

	public string UpdateDate => _localization.Get("SETTINGS_UPDATES_DATE_LAST_UPDATED_format", new object[2]
	{
		_versionInfoProvider.InstallDate.ToString("D"),
		_versionInfoProvider.InstallDate.ToString("t")
	});

	public IReadOnlyCollection<IAvailableUpdateVM> AvailableUpdates => GenerateAvailableUpdatesVMs();

	public bool NotifyUpdatesAvailable
	{
		get
		{
			return _app.NotifyUpdates;
		}
		set
		{
			_app.NotifyUpdates = value;
		}
	}

	public ProPresenter.UI.ViewModels.UpdateChannel ChannelSelected
	{
		get
		{
			return _channelSelected;
		}
		set
		{
			SetValue("ChannelSelected", ref _channelSelected, value, (Action<ProPresenter.UI.ViewModels.UpdateChannel, ProPresenter.UI.ViewModels.UpdateChannel>?)delegate
			{
				_app.UpdateChannel = value.ToDoUpdateChannel();
				OnPropertyChanged("BetaChannelSelected");
			}, (Predicate<ProPresenter.UI.ViewModels.UpdateChannel>?)null, referenceComparison: false);
		}
	}

	public bool BetaChannelSelected
	{
		get
		{
			return ChannelSelected == ProPresenter.UI.ViewModels.UpdateChannel.Beta;
		}
		set
		{
			ChannelSelected = ((!value) ? ProPresenter.UI.ViewModels.UpdateChannel.Production : ProPresenter.UI.ViewModels.UpdateChannel.Beta);
		}
	}

	public ISettingsItemVM? Parent => null;

	public Brush? Background => SettingsListItemConstants.Gray;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsUpdates);

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CheckUpdatesCommand => checkUpdatesCommand ?? (checkUpdatesCommand = new RelayCommand(CheckUpdates));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowInstalledReleaseNotesCommand => showInstalledReleaseNotesCommand ?? (showInstalledReleaseNotesCommand = new RelayCommand(ShowInstalledReleaseNotes));

	[RelayCommand]
	private void CheckUpdates()
	{
		_appUpdateService.InitiateCheckForUpgrades();
	}

	[RelayCommand]
	private void ShowInstalledReleaseNotes()
	{
		Uri releaseNotes = _webSourceProvider.GetReleaseNotes();
		_hyperlinkService.Open(releaseNotes);
	}

	public UpdatesSettingsVM(IAppUpdateService appUpdateService, IApp app, IGeneral general, IVersionInfoProvider versionInfoProvider, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory, IRegistrationWebResourceService registrationWebResourceService)
	{
		_appUpdateService = appUpdateService;
		_app = app;
		_channelSelected = _app.UpdateChannel.ToVmUpdateChannel();
		_general = general;
		_purchaseSubscriptionUri = new Uri(registrationWebResourceService.GetUpgradeToSubscription());
		LinkProperties("NotifyUpdates", "NotifyUpdatesAvailable");
		LinkProperties(new string[4] { "ReleaseBuildAvailable", "BetaBuildAvailable", "ReleaseBuildAvailableForPurchase", "BetaBuildAvailableForPurchase" }, new string[1] { "AvailableUpdates" });
		_general.PropertyChanged += base.RaiseLinkedValues;
		_appUpdateService.PropertyChanged += base.RaiseLinkedValues;
		_app.PropertyChanged += base.RaiseLinkedValues;
		base.PropertyChanged += base.RaiseLinkedValues;
		_versionInfoProvider = versionInfoProvider;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = _localization.Get("SETTINGS_UPDATES_PAGE_title");
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_UPDATES_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_UPDATE_CHANNEL_SECTION_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_AVAILABLE_UPDATES_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_RELEASE_NOTES_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_INSTALLED_VERSION_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_DATE_LAST_UPDATED_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_CHECK_FOR_UPDATES_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_BETA_UPDATES_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_NOTIFIY_WHEN_UPDATES_AVAILABLE_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_UPDATE_NOW_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_UPDATES_AVAILABLE_UPDATES_LATEST_RELEASE_label", this, isComponent: true));
	}

	public Pro.SerializationInterop.RVProtoData.Preferences.Types.Updates Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Preferences.Types.Updates
		{
			NotifyWhenAvailable = NotifyUpdatesAvailable,
			UpdateChannel = ((ChannelSelected == ProPresenter.UI.ViewModels.UpdateChannel.Beta) ? Pro.SerializationInterop.RVProtoData.Preferences.Types.Updates.Types.Channel.Beta : Pro.SerializationInterop.RVProtoData.Preferences.Types.Updates.Types.Channel.Production)
		};
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}

	private IReadOnlyCollection<IAvailableUpdateVM> GenerateAvailableUpdatesVMs()
	{
		List<IAvailableUpdateVM> list = new List<IAvailableUpdateVM>();
		if (BetaChannelSelected)
		{
			if (_appUpdateService.BetaBuildAvailableForPurchase != null)
			{
				BuildInformation build = _appUpdateService.BetaBuildAvailableForPurchase;
				list.Add(new AvailableUpdateVM(_localization.Get("SETTINGS_UPDATES_AVAILABLE_UPDATES_LATEST_BETA_label"), $"{build.Version} ({build.BuildNumber})", _localization.Get("UPDATES_PURCHASE_SUBSCRIPTION_title"), delegate
				{
					_hyperlinkService.Open(_purchaseSubscriptionUri);
				}, delegate
				{
					_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes(build.Version));
				}));
			}
			else if (_appUpdateService.BetaBuildAvailable != null)
			{
				BuildInformation build2 = _appUpdateService.BetaBuildAvailable;
				list.Add(new AvailableUpdateVM(_localization.Get("SETTINGS_UPDATES_AVAILABLE_UPDATES_LATEST_BETA_label"), $"{build2.Version} ({build2.BuildNumber})", _localization.Get("SETTINGS_UPDATES_UPDATE_NOW_BUTTON_title"), delegate
				{
					_appUpdateService.InstallVersion(build2);
				}, delegate
				{
					_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes(build2.Version));
				}));
			}
		}
		if (_appUpdateService.ReleaseBuildAvailableForPurchase != null)
		{
			BuildInformation build3 = _appUpdateService.ReleaseBuildAvailableForPurchase;
			list.Insert(0, new AvailableUpdateVM(_localization.Get("SETTINGS_UPDATES_AVAILABLE_UPDATES_LATEST_RELEASE_label"), $"{build3.Version} ({build3.BuildNumber})", _localization.Get("UPDATES_PURCHASE_SUBSCRIPTION_title"), delegate
			{
				_hyperlinkService.Open(_purchaseSubscriptionUri);
			}, delegate
			{
				_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes(build3.Version));
			}));
			if ((object)_appUpdateService.ReleaseBuildAvailable != null)
			{
				BuildInformation availableBuild = _appUpdateService.ReleaseBuildAvailable;
				list.Add(new AvailableUpdateVM(_localization.Get("SETTINGS_UPDATES_AVAILABLE_UPDATES_LAST_AVAILABLE_VERSION_label"), $"{availableBuild.Version} ({availableBuild.BuildNumber})", _localization.Get("SETTINGS_UPDATES_UPDATE_NOW_BUTTON_title"), delegate
				{
					_appUpdateService.InstallVersion(availableBuild);
				}, delegate
				{
					_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes(availableBuild.Version));
				}));
			}
		}
		else if (_appUpdateService.ReleaseBuildAvailable != null)
		{
			BuildInformation build4 = _appUpdateService.ReleaseBuildAvailable;
			list.Insert(0, new AvailableUpdateVM(_localization.Get("SETTINGS_UPDATES_AVAILABLE_UPDATES_LATEST_RELEASE_label"), $"{build4.Version} ({build4.BuildNumber})", _localization.Get("SETTINGS_UPDATES_UPDATE_NOW_BUTTON_title"), delegate
			{
				_appUpdateService.InstallVersion(build4);
			}, delegate
			{
				_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes(build4.Version));
			}));
		}
		return list;
	}
}
