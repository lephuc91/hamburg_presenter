using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.DO.Token;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Settings.CCLIReport;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Web;
using ProPresenter.UI.Commands;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public class CopyrightSettingsVM : ChildPageSettingsVMBase, ICopyrightSettingsVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IProPresenterResourceService _resourceService;

	private bool _editCopyrightLayoutPopupOpen;

	private readonly ICCLIReportAnalyticsEvents _ccliAnalyticEvents;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public bool EnableCopyrightDisplay
	{
		get
		{
			return _resourceService.CCLIPresentation.Display;
		}
		set
		{
			_resourceService.CCLIPresentation.Display = value;
		}
	}

	public CopyrightDisplayType CopyrightDisplayType
	{
		get
		{
			return _resourceService.CCLIPresentation.DisplayType.ToUICopyrightDisplayType();
		}
		set
		{
			_resourceService.CCLIPresentation.DisplayType = value.ToCopyrightDisplayType();
		}
	}

	public string CopyrightLicenseNumber
	{
		get
		{
			return _resourceService.CCLIPresentation.License;
		}
		set
		{
			_resourceService.CCLIPresentation.License = value;
		}
	}

	public string CopyrightLayoutText
	{
		get
		{
			return _resourceService.CCLIPresentation.Layout.Text;
		}
		set
		{
			_resourceService.CCLIPresentation.Layout.Text = value;
		}
	}

	public TokenCollection<CCLIToken> CopyrightTokens => _resourceService.CCLIPresentation.Layout.Tokens;

	public TokenCollection<CCLIToken> AvailableCopyrightTokens { get; } = new TokenCollection<CCLIToken>
	{
		new CCLIToken(CCLITokenType.Artist),
		new CCLIToken(CCLITokenType.Author),
		new CCLIToken(CCLITokenType.CopyrightYear),
		new CCLIToken(CCLITokenType.LicenseNumber),
		new CCLIToken(CCLITokenType.Publisher),
		new CCLIToken(CCLITokenType.SongNumber),
		new CCLIToken(CCLITokenType.Title)
	};

	public bool EditCopyrightLayoutPopupOpen
	{
		get
		{
			return _editCopyrightLayoutPopupOpen;
		}
		set
		{
			SetValue("EditCopyrightLayoutPopupOpen", ref _editCopyrightLayoutPopupOpen, value);
		}
	}

	public ICommand OpenCopyrightLayoutCommand => new RelayCommand(delegate
	{
		EditCopyrightLayoutPopupOpen = true;
	});

	public ICommand EditCopyrightTemplateCommand => new RelayCommand<ShowSource>(EditCopyrightTemplateCommandCommandExecuted);

	public ICommand<bool> DocumentChangeStartedCommand => new RelayCommand<bool>(DocumentChangeStartedCommandExecuted);

	public ICommand<bool> DocumentChangeEndedCommand => new RelayCommand<bool>(DocumentChangeEndedCommandExecuted);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(_resourceService.CCLIPresentation.UndoStack);
	});

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpCopyRight));
	});

	public ICommand CloseCopyrightLayoutCommand => new RelayCommand(delegate
	{
		EditCopyrightLayoutPopupOpen = false;
	});

	public ICCLIReportCollectionVM ReportsVM { get; }

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsCcli);

	public event Action<ICCLIPresentation>? EditCopyrightTemplate;

	public event Action<UndoStack>? StackChanged;

	public CopyrightSettingsVM(IProPresenterResourceService resourceService, ICCLIReportAnalyticsEvents ccliAnalyticEvents, ICCLIReportCollectionVM cCLIReportCollectionVM, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_resourceService = resourceService;
		_ccliAnalyticEvents = ccliAnalyticEvents;
		ReportsVM = cCLIReportCollectionVM;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		LinkProperties("Display", "EnableCopyrightDisplay");
		LinkProperties("DisplayType", "CopyrightDisplayType");
		LinkProperties("License", "CopyrightLicenseNumber");
		LinkProperties("Text", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CopyrightLayoutText", "CopyrightLicenseNumber" }));
		Name = localization.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_PAGE_title");
		_resourceService.CCLIPresentation.PropertyChanged += base.RaiseLinkedValues;
		_resourceService.CCLIPresentation.Layout.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_GENERAL_COPYRIGHT_REPORTING_PAGE_title", this, isComponent: false, PageField);
	}

	private void EditCopyrightTemplateCommandCommandExecuted(ShowSource source)
	{
		EditCopyrightLayoutPopupOpen = false;
		this.EditCopyrightTemplate?.Invoke(_resourceService.CCLIPresentation);
		switch (source)
		{
		case ShowSource.Toolbar:
			_ccliAnalyticEvents.EditTemplate(MainViewSource.Toolbar);
			break;
		case ShowSource.Preference:
			_ccliAnalyticEvents.EditTemplate(MainViewSource.Preference);
			break;
		}
	}

	private void DocumentChangeStartedCommandExecuted(bool isTokens)
	{
		_resourceService.CCLIPresentation.Layout.UndoStack.BeginCommit((isTokens ? UndoActionTypes.CCLILayoutToken : UndoActionTypes.CCLILayoutText).ToAction());
	}

	private void DocumentChangeEndedCommandExecuted(bool autoFinalize)
	{
		_resourceService.CCLIPresentation.Layout.UndoStack.EndCommit(null, null, autoFinalize);
	}
}
