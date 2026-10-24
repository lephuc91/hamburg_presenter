using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Startup;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.TestPattern;
using ProPresenter.DO.Cues;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.TestPattern;
using ProPresenter.UI.AboutProPresenter;
using ProPresenter.UI.ActionPalette;
using ProPresenter.UI.ClearGroups;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.KeyMapping;
using ProPresenter.UI.OutputConfiguration;
using ProPresenter.UI.PCO;
using ProPresenter.UI.Print;
using ProPresenter.UI.Search;
using ProPresenter.UI.Settings;
using ProPresenter.UI.SlideTrigger;
using ProPresenter.UI.TestPattern;
using ProPresenter.UI.Timecode;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.KeyMapping;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.QuickSearch;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.UI.Web;
using ProPresenter.UI.WhatsNew;

namespace ProPresenter.UI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_keyPressService" })]
public partial class MainLayout : UserControl, IComponentConnector, IDisposable
{
	private const double DragCollapseThreshold = 20.0;

	private bool _isMainWindowReady;

	private bool _showRegistration;

	private IMainLayoutVM.CodeInfo? _codeInfo;

	private readonly Lazy<CueInspectorWindow> _mediaCueInspector;

	private readonly Lazy<SettingsWindow> _settingsWindow;

	private readonly Lazy<OutputConfigurationWindow> _outputConfigurationWindow;

	private readonly Lazy<TestPatternWindow> _testPatternWindow;

	private readonly Lazy<ActionPaletteView> _actionPalette;

	private readonly Lazy<PrintOptionDialog> _printOptionDialog;

	private readonly Lazy<WebBrowserView?> _webBrowserView;

	private readonly Lazy<QuickSearchWindow> _quickSearchWindow;

	private readonly Lazy<ClearGroupsWindow> _clearGroupsWindow;

	private readonly Lazy<AttachmentManagerWindow> _attachmentManagerWindow;

	private readonly Lazy<KeyMappingWindow> _keyMappingWindow;

	private readonly Lazy<TimecodeWindow> _timecodeWindow;

	private readonly Lazy<WhatsNewWindow> _whatsNewWindow;

	private KeyPressService? _keyPressService;

	private readonly IApp _app;

	private readonly ITestPatternService _testPatternService;

	private readonly ITestPatternAnalyticEventsPublisher _testPatternAnalyticEventsPublisher;

	private readonly ISettingsVM _settingsVM;

	private readonly string _proLicense;

	private readonly IReadOnlyList<KeyValuePair<string, string>> _licenses;

	private readonly IMessageService _messageService;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	private readonly IWhatsNewV2VM _whatsNewV2VM;

	public static readonly DependencyProperty SelectedViewProperty = DependencyProperty.Register("SelectedView", typeof(PopupType), typeof(MainLayout));

	public static readonly DependencyProperty ActiveInlineViewProperty = DependencyProperty.Register("ActiveInlineView", typeof(InlineType), typeof(MainLayout), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)InlineType.Presentation, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as MainLayout)?.OnActiveInlineViewChanged((InlineType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty IsPlaylistLibraryExpandedProperty = DependencyProperty.Register("IsPlaylistLibraryExpanded", typeof(bool), typeof(MainLayout));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private IMainLayoutVM MainLayoutVM => (base.DataContext as IMainLayoutVM) ?? throw new InvalidOperationException();

	public PopupType SelectedView
	{
		get
		{
			return (PopupType)((DependencyObject)this).GetValue(SelectedViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedViewProperty, (object)value);
		}
	}

	public InlineType ActiveInlineView
	{
		get
		{
			return (InlineType)((DependencyObject)this).GetValue(ActiveInlineViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveInlineViewProperty, (object)value);
		}
	}

	public ssAPIOutput OutputController { get; }

	private WebBrowserView? WebBrowserView => _webBrowserView.Value;

	public bool IsPlaylistLibraryExpanded
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPlaylistLibraryExpandedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPlaylistLibraryExpandedProperty, (object)value);
		}
	}

	public SlideTriggerControl SlideTriggerControl => slideTriggerControl;

	public MainLayout(ssAPIOutput outputController, IApp app, ITestPatternService testPatternService, ITestPatternAnalyticEventsPublisher testPatternAnalyticEventsPublisher, ISettingsVM settingsVM, IReadOnlyList<KeyValuePair<string, string>> licenses, string proLicense, IMessageService messageService, IAfterStartupCompleteQueue afterStartupCompleteQueue, IWhatsNewV2VM whatsNewV2VM)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		_app = app;
		_testPatternService = testPatternService;
		_testPatternAnalyticEventsPublisher = testPatternAnalyticEventsPublisher;
		_settingsVM = settingsVM;
		_licenses = licenses;
		_proLicense = proLicense;
		_messageService = messageService;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		_whatsNewV2VM = whatsNewV2VM;
		OutputController = outputController;
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MainLayout_DataContextChanged);
		base.Loaded += MainLayout_Loaded;
		base.Unloaded += delegate
		{
			_keyPressService?.Dispose();
		};
		_mediaCueInspector = new Lazy<CueInspectorWindow>(delegate
		{
			return setupWindow<CueInspectorWindow>(new CueInspectorWindow(), MainLayoutVM.CueInspectorVM);
			T setupWindow<T>(T value, object? dataContext) where T : notnull, Window
			{
				value.DataContext = dataContext;
				value.Deactivated += Window_Deactivated;
				return value;
			}
		});
		_settingsWindow = new Lazy<SettingsWindow>(() => new SettingsWindow());
		_whatsNewWindow = new Lazy<WhatsNewWindow>(() => new WhatsNewWindow());
		_outputConfigurationWindow = new Lazy<OutputConfigurationWindow>(delegate
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			OutputConfigurationWindow value2 = _003C_002Ector_003Eg__setupWindow_007C48_14<OutputConfigurationWindow>(new OutputConfigurationWindow(), (object?)MainLayoutVM.ScreenConfigVM);
			value2.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
			{
				if (!value2.IsVisible)
				{
					MainLayoutVM.ScreenConfigVM.IdentifyScreensActive = false;
				}
			};
			return value2;
		});
		_testPatternWindow = new Lazy<TestPatternWindow>(delegate
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			TestPatternWindow value3 = _003C_002Ector_003Eg__setupWindow_007C48_14<TestPatternWindow>(new TestPatternWindow(), (object?)MainLayoutVM.TestPatternVM);
			value3.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
			{
				if (!value3.IsVisible)
				{
					MainLayoutVM.TestPatternVM.CurrentState.HidePatternCommand?.Invoke();
				}
			};
			return value3;
		});
		_actionPalette = new Lazy<ActionPaletteView>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<ActionPaletteView>(new ActionPaletteView
		{
			Devices = MainLayoutVM.CommunicationOutput.Devices
		}, (object?)null));
		_printOptionDialog = new Lazy<PrintOptionDialog>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<PrintOptionDialog>(new PrintOptionDialog
		{
			PrintOptions = MainLayoutVM.PrintVM.PrintOptions,
			OpenPrintSettingCommand = MainLayoutVM.PrintVM.OpenPrintSettingCommand,
			OpenPreviewCommand = MainLayoutVM.PrintVM.OpenPreviewCommand
		}, (object?)null));
		_webBrowserView = new Lazy<WebBrowserView>(() => base.Resources["WebBrowserView"] as WebBrowserView);
		_quickSearchWindow = new Lazy<QuickSearchWindow>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<QuickSearchWindow>(new QuickSearchWindow(), (object?)MainLayoutVM.QuickSearchVM));
		_clearGroupsWindow = new Lazy<ClearGroupsWindow>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<ClearGroupsWindow>(new ClearGroupsWindow(), (object?)MainLayoutVM.ClearGroupsVM));
		_keyMappingWindow = new Lazy<KeyMappingWindow>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<KeyMappingWindow>(new KeyMappingWindow(), (object?)MainLayoutVM.KeyMappingVM));
		_timecodeWindow = new Lazy<TimecodeWindow>(() => new TimecodeWindow());
		_attachmentManagerWindow = new Lazy<AttachmentManagerWindow>(() => _003C_002Ector_003Eg__setupWindow_007C48_14<AttachmentManagerWindow>(new AttachmentManagerWindow(), (object?)MainLayoutVM.PCOAttachmentManagerVM));
	}

	private void MainLayout_Loaded(object? sender, RoutedEventArgs e)
	{
		MainLayoutVM.OutputVM.ShowScreensOnStartup();
		_keyPressService = new KeyPressService((Key[])(object)new Key[1] { (Key)146 });
		_keyPressService.OnKeyHeldDown += delegate
		{
			((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
			{
				MainLayoutVM.PresentationVM.ForceFlipView = true;
			});
		};
		_keyPressService.OnKeyReleased += delegate
		{
			((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
			{
				MainLayoutVM.PresentationVM.ForceFlipView = false;
			});
		};
	}

	private void MainLayout_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IMainLayoutVM)
		{
			throw new InvalidOperationException();
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IMainLayoutVM mainLayoutVM)
		{
			SetBinding(ActiveInlineViewProperty, new Binding("ActiveInlineView")
			{
				Mode = BindingMode.TwoWay
			});
			SetBinding(IsPlaylistLibraryExpandedProperty, new Binding("IsPlaylistLibraryExpanded")
			{
				Source = mainLayoutVM.Settings
			});
			mainLayoutVM.SetSelectedView += OnSetSelectedView;
			mainLayoutVM.ShowRegistration += OnShowRegistration;
			mainLayoutVM.ShowSettingsPage += OnOpenSettingsByIndexCommand;
		}
	}

	public void OnOpenMediaInspectorCommand(InspectorParameter param)
	{
		param.ActiveInlineView = ActiveInlineView;
		MainLayoutVM?.CueInspectorVM?.InspectCuesCommand?.Invoke(param);
		if (param.Options.HasFlag(InspectorOptions.SwitchToMarkerTab))
		{
			IMainLayoutVM mainLayoutVM = MainLayoutVM;
			if (mainLayoutVM != null && mainLayoutVM.CueInspectorVM != null)
			{
				MainLayoutVM.CueInspectorVM.ActiveTab = 5;
			}
		}
		_mediaCueInspector.Value.Show();
		_mediaCueInspector.Value.Focus();
	}

	public void OnNewCommand()
	{
		OnSetSelectedView(PopupType.NewPresentation);
	}

	public void OnFindCommand(bool isHotkey, SearchContext? context = null)
	{
		ShowQuickSearch(context ?? new SearchContext());
		if (isHotkey)
		{
			QuickSearchShownEvent.Publish(QuickSearchShownSource.ApplicationMenu);
		}
	}

	public void OnOpenSongSelectCommand()
	{
		ShowQuickSearch(new SearchContext());
		IQuickSearchPageVM quickSearchPageVM = MainLayoutVM.QuickSearchVM.AvailablePages.FirstOrDefault((IQuickSearchPageVM p) => p.SearchType == QuickSearchType.SongSelect);
		if (quickSearchPageVM != null)
		{
			MainLayoutVM.QuickSearchVM.SelectPageCommand.Invoke(quickSearchPageVM);
		}
	}

	public void OnOpenMultiTracksCommand()
	{
		ShowQuickSearch(new SearchContext());
		IQuickSearchPageVM quickSearchPageVM = MainLayoutVM.QuickSearchVM.AvailablePages.FirstOrDefault((IQuickSearchPageVM p) => p.SearchType == QuickSearchType.MultiTracks);
		if (quickSearchPageVM != null)
		{
			MainLayoutVM.QuickSearchVM.SelectPageCommand.Invoke(quickSearchPageVM);
		}
	}

	private void ShowQuickSearch(SearchContext context)
	{
		MainLayoutVM.QuickSearchVM.Context = context;
		_quickSearchWindow.Value.Show();
	}

	public void OnPrintCommand(object? parameter)
	{
		ICommand<IEnumerable<IDocumentCue>> setPrintTargetCommmand = MainLayoutVM.PrintVM.SetPrintTargetCommmand;
		if (setPrintTargetCommmand != null && setPrintTargetCommmand.Invoke<IEnumerable<IDocumentCue>>(GetPrintableDocuments(parameter as IEnumerable<ProPresenterCue>)))
		{
			_printOptionDialog.Value.ShowDialog();
		}
	}

	public bool CanPrint(object? parameter)
	{
		return !GetPrintableDocuments(parameter as IEnumerable<ProPresenterCue>).Empty();
	}

	private IEnumerable<IDocumentCue> GetPrintableDocuments(IEnumerable<ProPresenterCue>? cues)
	{
		if (cues != null && !cues.Empty())
		{
			return cues.OfType<IDocumentCue>().ToArray();
		}
		IEnumerable<IDocumentCue> enumerable = null;
		ILibraryVM libraryVM = MainLayoutVM.LibraryVM;
		if (!libraryVM.SelectedPlaylists.Empty())
		{
			enumerable = libraryVM.SelectedPlaylists.OfType<Playlist<ProPresenterCue>>().SelectMany((Playlist<ProPresenterCue> p) => p).OfType<IDocumentCue>()
				.ToArray();
		}
		if (!libraryVM.SelectedCues.Empty())
		{
			List<IDocumentCue> list = new List<IDocumentCue>();
			list.AddRange(from d in libraryVM.SelectedCues.OfType<IDocumentCueVM>()
				select d.Document);
			enumerable = new global::_003C_003Ez__ReadOnlyList<IDocumentCue>(list);
		}
		if (!libraryVM.SelectedLibraries.Empty() || enumerable == null)
		{
			enumerable = Array.Empty<IDocumentCue>();
		}
		return enumerable;
	}

	public void OnShowBibleViewCommand()
	{
		SwitchInlineView(InlineType.Bible);
		MainViewBibleEvent.Publish(MainViewSource.Toolbar);
	}

	public void OnToggleBibleViewCommand()
	{
		ToggleView(InlineType.Bible);
		MainViewBibleEvent.Publish(MainViewSource.ApplicationMenu);
	}

	private void ToggleView(InlineType viewType)
	{
		SwitchInlineView((ActiveInlineView == viewType) ? InlineType.Presentation : viewType);
	}

	public void OnOpenTimersCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Timers;
	}

	public void OnOpenMessagesCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Messages;
	}

	public void OnOpenPropsCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Props;
	}

	public void OnOpenStageDisplayControlCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Stage;
	}

	public void OnOpenAudioCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Audio;
	}

	public void OnOpenMacrosCommand()
	{
		MainLayoutVM.SelectedUtilityView = UtilityViewType.Macros;
	}

	public void OpenTimecode()
	{
		_timecodeWindow.Value.Show();
	}

	public void OnOpenPCOLiveCommand()
	{
		MainLayoutVM.PCOLiveVM.EnsureAuthorized(OnPCOAuthorized).ExecuteAsync();
	}

	public void OnOpenPCOAttachmentManagerCommand()
	{
		MainLayoutVM.PCOLiveVM.EnsureAuthorized(delegate(bool isAuthorized)
		{
			if (isAuthorized)
			{
				MainLayoutVM.PCOAttachmentManagerVM.ActivePlan = ((MainLayoutVM.LibraryVM.SelectedPlaylists.FirstOrDefault() ?? MainLayoutVM.LibraryVM.ActivePlaylist) as PCOPlaylist)?.PCOPlan;
				_attachmentManagerWindow.Value.ShowWindow();
			}
		}).ExecuteAsync();
	}

	public void OnOpenTestPatternsCommand(TestPatternUIShownSource source)
	{
		if (_testPatternWindow.Value.IsVisible)
		{
			_testPatternWindow.Value.Visibility = Visibility.Hidden;
			return;
		}
		_testPatternWindow.Value.Visibility = Visibility.Visible;
		_testPatternAnalyticEventsPublisher.Shown(source.ToShownSource());
		_testPatternService.GetCurrentStateAsync().ExecuteAsync();
	}

	public void OnOpenActionPaletteCommand()
	{
		_actionPalette.Value.Visibility = (_actionPalette.Value.IsVisible ? Visibility.Hidden : Visibility.Visible);
	}

	public void OnOpenSettingsCommand()
	{
		_settingsWindow.Value.ShowWindow();
	}

	public void OnOpenSettingsByIndexCommand(SettingsPage tab)
	{
		OnOpenSettingsCommand();
		_settingsVM.SetActivePage(tab);
	}

	public void OpenClearGroupWindow(ClearGroupShownSource source)
	{
		_clearGroupsWindow.Value.ShowWindow();
		ClearGroupShownEvent.Publish(source);
	}

	public void OpenKeyMappingWindow()
	{
		_keyMappingWindow.Value.ShowWindow();
	}

	public void ConfigureGroupLabelHotkey()
	{
		OpenKeyMappingWindow();
		IInputActionGroupVM inputActionGroupVM = MainLayoutVM.KeyMappingVM.InputActionGroups.FirstOrDefault((IInputActionGroupVM v) => v.Group is GroupLabelGroup);
		if (inputActionGroupVM != null)
		{
			_keyMappingWindow.Value.commandsTable.ScrollIntoView(inputActionGroupVM, 0.0, null);
		}
	}

	public void OnOpenOutputConfigurationCommand()
	{
		_outputConfigurationWindow.Value.Visibility = Visibility.Visible;
		_outputConfigurationWindow.Value.Activate();
	}

	public void OnToggleMediaBinCommand()
	{
		if (!Layout.Settings.MediaLibraryCollapsed && MainLayoutVM.MediaLibraryVM.PlaylistVM.ActivePlaylist == null)
		{
			MainLayoutVM.ActivateMediaBin();
			return;
		}
		Layout.Settings.MediaLibraryCollapsed = !Layout.Settings.MediaLibraryCollapsed;
		MainLayoutVM.ActivateMediaBin();
	}

	public void OnShowProContentViewCommand()
	{
		Layout.Settings.ProContentOutlineVisible = true;
		if (!Layout.Settings.MediaLibraryCollapsed && MainLayoutVM.MediaLibraryVM.ProContentVM.CurrentGroup == null)
		{
			MainLayoutVM.ActivateProContent();
			return;
		}
		Layout.Settings.MediaLibraryCollapsed = !Layout.Settings.MediaLibraryCollapsed;
		MainLayoutVM.ActivateProContent();
	}

	public void OnFindMyMouseCommand()
	{
		ProPresenter.Controller.Utility.FindMyMouse();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		_keyPressService?.OnKeyDown(e);
		SetHiddenOptionsVisibility(KeyboardHelper.IsModifierPressed((ModifierKeys)1));
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		_keyPressService?.OnKeyUp(e);
		SetHiddenOptionsVisibility(isVisible: false);
	}

	private void SetHiddenOptionsVisibility(bool isVisible)
	{
		MainLayoutVM.MenuLayoutVM.HiddenOptionsVisible = isVisible;
		MainLayoutVM.PresentationVM.HideBackgroundImage = isVisible;
	}

	public void ReleaseHotkey(KeyEventArgs e)
	{
		SetBackgroundImageVisibility(e, isVisible: false);
	}

	private void SwitchInlineView(InlineType viewType)
	{
		ActiveInlineView = viewType;
	}

	private void OnActiveInlineViewChanged(InlineType inlineType)
	{
		OnSetSelectedView(PopupType.None);
		ScreenPreview.Visibility = (inlineType.IsAnyOf(InlineType.SlideEditor, InlineType.MaskEditor, InlineType.TemplateEditor, InlineType.StageEditor, InlineType.PropsEditor, InlineType.CCLITemplateEditor) ? Visibility.Collapsed : Visibility.Visible);
		Focus();
	}

	private void ResetInlineView()
	{
		SwitchInlineView(InlineType.Presentation);
	}

	private void OnPCOAuthorized(bool isAuthorized)
	{
		if (isAuthorized)
		{
			OnSetSelectedView(PopupType.PCOLive);
			PCOLiveShownEvent.Publish((!pcoLivePopup.IsDocked) ? PCOLiveShownWindowMode.Floating : PCOLiveShownWindowMode.Docked);
		}
		else
		{
			OnSetSelectedView(PopupType.None);
		}
	}

	public void NavigateTargetURL(string? url)
	{
		if (WebBrowserView != null)
		{
			WebBrowserView.Url = url;
		}
		SwitchInlineView(InlineType.Web);
	}

	private void MediaRowSplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (e.VerticalChange >= BottomRow.ActualHeight - 20.0)
		{
			Layout.Settings.MediaLibraryCollapsed = true;
		}
		else if (e.VerticalChange <= 0.0 - BottomRow.MinHeight)
		{
			Layout.Settings.MediaLibraryCollapsed = false;
		}
	}

	private void OnSetSelectedView(PopupType popupType)
	{
		if (popupType == PopupType.None)
		{
			((DependencyObject)this).SetCurrentValue(SelectedViewProperty, (object)(SelectedView & popupType));
		}
		else if (SelectedView.HasFlag(popupType))
		{
			((DependencyObject)this).SetCurrentValue(SelectedViewProperty, (object)(SelectedView & ~popupType));
		}
		else
		{
			((DependencyObject)this).SetCurrentValue(SelectedViewProperty, (object)(SelectedView | popupType));
		}
	}

	private void PCOLiveViewer_Accept()
	{
		OnSetSelectedView(PopupType.PCOLive);
	}

	private void PCOLiveViewer_Close()
	{
		((DependencyObject)this).SetCurrentValue(SelectedViewProperty, (object)(SelectedView & ~PopupType.PCOLive));
	}

	private void PCOLiveViewer_ToggleDock()
	{
		PCOLiveShownEvent.Publish((!pcoLivePopup.IsDocked) ? PCOLiveShownWindowMode.Floating : PCOLiveShownWindowMode.Docked);
	}

	private void OnShowRegistration(IMainLayoutVM.CodeInfo? codeInfo = null)
	{
		if (!_isMainWindowReady)
		{
			_showRegistration = true;
			_codeInfo = codeInfo;
		}
		else
		{
			ShowRegistrationUI(codeInfo);
		}
	}

	public void OnMainWindowContentRendered()
	{
		if (_isMainWindowReady)
		{
			return;
		}
		_isMainWindowReady = true;
		if (_showRegistration)
		{
			ShowRegistrationUI(_codeInfo);
		}
		if (_whatsNewV2VM.ShouldAutoShowWhatsNew)
		{
			_afterStartupCompleteQueue.Enqueue(delegate
			{
				((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
				{
					_whatsNewWindow.Value.ShowWindow();
				});
			});
		}
		MainLayoutVM.MacroGroupsVM.TriggerStartupMacro();
		_messageService.PublishMessage(new MainWindowContentRenderedMessage());
	}

	private void ShowRegistrationUI(IMainLayoutVM.CodeInfo? codeInfo = null)
	{
		OnOpenSettingsByIndexCommand(SettingsPage.Account);
		IRegistrationUnlockCodeVM registrationUnlockCodeVM = (_settingsVM.ActivePage as IRegistrationMainPageVM)?.ProPresenter.UnlockCodeVM;
		if ((object)codeInfo != null && registrationUnlockCodeVM != null)
		{
			registrationUnlockCodeVM.UnlockCode = codeInfo.Code;
			registrationUnlockCodeVM.RegistrationName = codeInfo.RegistrationName;
			registrationUnlockCodeVM.IsVisible = true;
		}
	}

	private void SetBackgroundImageVisibility(KeyEventArgs e, bool isVisible)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!Advanced.Settings.SuppressVideoStart)
		{
			if ((int)e.SystemKey == 120 || (int)e.SystemKey == 121)
			{
				MainLayoutVM.PresentationVM.HideBackgroundImage = isVisible;
			}
			else if ((int)e.SystemKey == 0)
			{
				MainLayoutVM.PresentationVM.HideBackgroundImage = false;
			}
		}
	}

	public void OnOpenAboutCommand()
	{
		AboutProPresenterDialog aboutProPresenterDialog = new AboutProPresenterDialog(_proLicense, _licenses);
		aboutProPresenterDialog.AssemblyVersionDescription = VersionInfo.FullDisplayAppVersion;
		aboutProPresenterDialog.BuildYear = VersionInfo.BuildDate.Year.ToString();
		aboutProPresenterDialog.ShowDialog();
	}

	public void OnOpenWhatsNewCommand()
	{
		_afterStartupCompleteQueue.Enqueue(delegate
		{
			((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
			{
				_whatsNewWindow.Value.ShowWindow();
			});
		});
	}

	private void Window_Deactivated(object? sender, EventArgs e)
	{
		MainLayoutVM.PresentationVM.HideBackgroundImage = false;
		MainLayoutVM.PresentationVM.ForceFlipView = false;
	}

	private void Start_PopupTimer(object? sender, EventArgs e)
	{
		SlideTriggerControl.StartPopupTimer();
	}

	public void Cleanup()
	{
		if (_mediaCueInspector.IsValueCreated)
		{
			_mediaCueInspector.Value.HideOnClose = false;
			_mediaCueInspector.Value.Close();
		}
		if (_settingsWindow.IsValueCreated)
		{
			_settingsWindow.Value.HideOnClose = false;
			_settingsWindow.Value.Close();
		}
		_messageService.PublishMessage(new MainWindowClosingMessage());
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_keyPressService?.Dispose();
		}
	}
}
