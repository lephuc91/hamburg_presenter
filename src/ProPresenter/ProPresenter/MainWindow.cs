using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.Reflection;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Startup;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Interprocess;
using Pro.Localization;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.UI.Commands;
using Pro.UI.Controls;
using Pro.UI.Controls.Windowing;
using Pro.UI.DialogService;
using Pro.UI.InputActions;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Analytics.Events.TestPattern;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.InputActionMap.OutputScreen;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.Communication;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.Web;
using ProPresenter.Data;
using ProPresenter.Rendering;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.KeyMapping;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.SlideTrigger;
using ProPresenter.UI.TestPattern;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.QuickSearch;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.UI.Welcome;
using ProPresenter.ViewModels.FeedbackCrash;
using ProPresenter.ViewModels.Props;

namespace ProPresenter;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_mainLayout" })]
public partial class MainWindow : ChromedWindow, IComponentConnector, IDisposable
{
	private readonly IMessages<AppMessages> _messages;

	private readonly SplashDialog? _splash;

	private readonly ssAPIOutput _outputController;

	private readonly MainLayout _mainLayout;

	private readonly IApp _app;

	private readonly IAttachmentsUploader _attachmentsUploader;

	private readonly ICrashReportUserFeedbackDialogProvider _crashReportUserFeedbackDialogProvider;

	private readonly IScreenSelectorVM _screenSelectorVM;

	private readonly IWindowedOutputVM _windowedOutputVM;

	private readonly INetwork _network;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IInputActions _inputActions;

	private readonly IWorkspaceInfoDumper _workspaceInfoDumper;

	private bool _showCloseConfirmation = true;

	private bool _isClosing;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private IMainLayoutVM? MainLayoutVM { get; set; }

	public MainWindow(IMessages<AppMessages> messages, SplashDialog? splash, ssAPIOutput outputController, IApp app, ITestPatternService testPatternService, ITestPatternAnalyticEventsPublisher testPatternAnalyticEventsPublisher, IAttachmentsUploader attachmentsUploader, ICrashReportUserFeedbackDialogProvider crashReportUserFeedbackDialogProvider, ProPresenter.UI.ViewModels.Settings.ISettingsVM settingsVM, IMessageService messageService, IAfterStartupCompleteQueue afterStartupCompleteQueue, IScreenSelectorVM screenSelectorVM, IWindowedOutputVM windowedOutputVM, INetwork network, IWebSourceProvider webSourceProvider, IHyperlinkService hyperlinkService, IInputActions inputActions, IWhatsNewV2VM whatsNewV2VM, IFlagService flagService, IWorkspaceInfoDumper workspaceInfoDumper)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		Application.Current.MainWindow = this;
		_messages = messages;
		_splash = splash;
		_outputController = outputController;
		_app = app;
		_attachmentsUploader = attachmentsUploader;
		_crashReportUserFeedbackDialogProvider = crashReportUserFeedbackDialogProvider;
		_screenSelectorVM = screenSelectorVM;
		_windowedOutputVM = windowedOutputVM;
		_network = network;
		_webSourceProvider = webSourceProvider;
		_hyperlinkService = hyperlinkService;
		_inputActions = inputActions;
		_workspaceInfoDumper = workspaceInfoDumper;
		Log.Info("Building the main layout...");
		_mainLayout = new MainLayout(_outputController, app, testPatternService, testPatternAnalyticEventsPublisher, settingsVM, Licenses.All, "Renewed Vision, LLC. Software End User License Agreement\r\n\r\nNOTICE TO USER:  THIS SOFTWARE END USER LICENSE AGREEMENT (\"EULA\") IS A LEGAL AGREEMENT BETWEEN YOU (“YOU” OR “END USER”) AND RENEWED VISION. READ IT CAREFULLY BEFORE COMPLETING THE INSTALLATION PROCESS AND USING THE SOFTWARE. IT PROVIDES A LICENSE TO USE THE SOFTWARE AND CONTAINS WARRANTY INFORMATION AND LIABILITY DISCLAIMERS. BY INSTALLING AND USING THE SOFTWARE, YOU ARE CONFIRMING YOUR ACCEPTANCE OF THE SOFTWARE AND AGREEING TO BECOME BOUND BY THE TERMS OF THIS AGREEMENT. IF YOU DO NOT AGREE TO THE TERMS OF THE LICENSE, YOU MUST NOT DOWNLOAD, INSTALL OR USE THE SOFTWARE, AND YOU MUST DELETE OR RETURN THE SOFTWARE TO THE PLACE WHERE YOU OBTAINED IT WITHIN THIRTY (30) DAYS AND MAY REQUEST A REFUND OF THE LICENSE FEE, IF ANY. FOR SOFTWARE INCLUDED WITH YOUR PURCHASE OF HARDWARE, YOU MUST RETURN THE ENTIRE HARDWARE/SOFTWARE PACKAGE IN ORDER TO OBTAIN A REFUND. IF YOU ARE ACCESSING THE SOFTWARE ELECTRONICALLY, SIGNIFY YOUR AGREEMENT TO BE BOUND BY THE TERMS OF THIS LICENSE BY CLICKING THE \"ACCEPT\" BUTTON. IF YOU DO NOT AGREE TO THE TERMS OF THIS LICENSE, CLICK “QUIT\".\r\n\r\nTHIS EULA CONTAINS A MANDATORY ARBITRATION PROVISION AND A CLASS ACTION WAIVER THAT REQUIRE THE USE OF ARBITRATION ON AN INDIVIDUAL BASIS TO RESOLVE DISPUTES.\r\n\r\nTHIS EULA SHALL APPLY ONLY TO THE SOFTWARE SUPPLIED BY RENEWED VISION HEREWITH REGARDLESS OF WHETHER OTHER SOFTWARE IS REFERRED TO OR DESCRIBED HEREIN.\r\n\r\n1. Definitions\r\n(a) \"Renewed Vision\" means Renewed Vision, LLC, its affiliates and its licensors, if any.\r\n\r\n(b) \"Software\" means only the Renewed Vision Software program(s) and third party software programs, in each case, supplied by Renewed Vision herewith, and corresponding documentation, associated media, printed materials, and online or electronic documentation.\r\n\r\n(c) \"Demo Version\" means a version or mode of the Software, so identified, to be used only to review, demonstrate and evaluate the Software for a limited time period. The Demo Version may have limited features, may display a watermark, and may cease operating after a predetermined amount of time due to an internal mechanism within the Demo Version.\r\n\r\n2. License\r\nRenewed Vision grants you a non-exclusive, non-transferable license to use the Software for the duration set forth in your order and for the purpose permitted under your order (the “License”). \r\n\r\n\r\n3. Ownership\r\nThe Software and documentation accompanying this License whether on disk, in read only memory, on any other media or in any other form are licensed, not sold, to you by Renewed Vision for use only under the terms of this License, and Renewed Vision reserves all rights not expressly granted to you. Title, copyright, and intellectual property rights (including the look and feel of the Software) and the distribution rights of the Software remain with Renewed Vision. Use of some third party materials included in the Software may be subject to other terms and conditions typically found in a separate license agreement or \"Read Me\" file located near such materials. Title, copyright, and intellectual property rights in and to any content displayed by or accessed through the Software belong to the respective content owner. Such content may be protected by copyright or other intellectual property laws and treaties, and may be subject to terms of use of the third party providing such content. This License does not grant you any rights to use such content.\r\n\r\n4. Permitted License Uses and Restrictions\r\nOther than with respect to a Demo Version or License, this License allows you to install and use one copy of the Software on a single computer at a time.  Except as and only to the extent expressly permitted in this License or by applicable law, you may not (a) copy, decompile, reverse engineer, disassemble, modify, translate, enhance, attempt to derive the source code of, or  create derivative works of the Software or any part thereof, (b) make available the Software to anyone other than employees or volunteers in your organization, (c) transfer or sublicense the Software to any third party, unless expressly permitted by the written reseller agreement between you and Renewed Vision (if applicable), or (d) remove any copyright or other proprietary notices on or in any copies of the Software.\r\n\r\n\r\n4. Upgrades\r\nIf this copy of the Software is an upgrade from an earlier version of the Software, you may continue to use the previous version only on the same machine as that registered with your upgraded license.\r\n\r\n5. Redistribution\r\nYou may NOT redistribute this Software or any component thereof to any third party, including via a public server of any kind, including but not limited to http (web) servers on the Internet.\r\n\r\n6. THIRD PARTY INTEGRATIONS: \"Third Party\" here refers to service providers with which Renewed Vision has integrated functionality into their software, with or without third-party supplied APIs (Application Programming Interfaces) and includes, but is not limited to, CCLI SongSelect, MultiTracks.com, Worship House Media, Planning Center Online, and Resi. Regarding content accessed via third party integrations (“Content”): All Content and the integration are provided solely and exclusively for End Users who are active subscribers to these third-party services.  All Content is the intellectual property of a third party, is protected by law, and no ownership, distribution rights, or other proprietary rights in the Content are transferred to the Renewed Vision and/or any End User. Content owners may remove Content from the integration from time-to-time without notice;  Any content that is stored locally on your computer will not be affected. End Users must agree to comply with all license terms of the third-party and all applicable laws, including copyright law in their use of the Content and shall protect the third-party and the Content owners' rights; The usage rights granted to End User are nonexclusive, are subject to revocation or termination at any time, and may not be transferred, assigned, sublicensed, distributed, or conveyed in any manner whatsoever.  Third Parties and the Content owners reserve the right to modify the provisions contained in the EULA at any time.  NEITHER THIRD PARTIES NOR CONTENT OWNERS WILL BE LIABLE TO END USER FOR ANY INDIRECT, PUNITIVE, INCIDENTAL, CONSEQUENTIAL, OR SPECIAL DAMAGES OF ANY KIND RESULTING FROM THE USE OF THE THIRD PARTY SERVICES, THE THIRD PARTY API, OR FROM CONTENT MADE AVAILABLE THROUGH THE THIRD PARTY API, OR FOR ANY OTHER DAMAGES OF ANY TYPE, NATURE OR DESCRIPTION ARISING OUT OF ANY LEGAL THEORY, AND END USER HEREBY FOREVER RELEASES AND DISCHARGES THIRD PARTIES AND CONTENT OWNERS FROM ANY AND ALL LIABILITY RELATED TO END USER'S USE OF OR ACCESS TO THIRD PARTY SERVICES, THIRD PARTY APIs, OR CONTENT MADE AVAILABLE THROUGH THE THIRD PARTY API. RENEWED VISION AND THIRD PARTIES DISCLAIM ANY AND ALL EXPRESS OR IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION ANY IMPLIED WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.\r\n\r\n7. Termination\r\n\r\nThe term of this EULA begins on the delivery of the Software and continues until this EULA is terminated in accordance with this Section 7. \r\n\r\nRenewed Vision may terminate this EULA effectively immediately upon written notice to you if (i) you fail to comply with this EULA and fail to cure within thirty (30) days after receipt of Renewed Vision’s written notice thereof, or (ii) you fail to pay any portion of the fees under your applicable order within ten (10) days after receiving written notice from Renewed Vision that payment is past due.  Renewed Vision may terminate this EULA for convenience with fifteen (15) days prior written notice to you.  If Renewed Visions terminates this EULA for convenience, Renewed Vision shall issue a pro-rata refund of any pre-paid unused fees for the Software. Upon Renewed Vision’s termination of this EULA for any reason, all Licensed rights to all Software granted under this EULA will immediately cease and you must return or destroy all copies of the Software (with all other rights of both parties and all other provisions of this EULA surviving any such termination).\r\n\r\n8. Disclaimer of Warranties\r\nYOU EXPRESSLY ACKNOWLEDGE AND AGREE THAT USE OF THE SOFTWARE IS AT YOUR SOLE RISK AND THAT THE ENTIRE RISK AS TO SATISFACTORY QUALITY, PERFORMANCE, ACCURACY AND EFFORT IS WITH YOU. TO THE MAXIMUM EXTENT PERMITTED BY APPLICABLE LAW, THE SOFTWARE IS PROVIDED \"AS IS\", WITH ALL FAULTS AND WITHOUT WARRANTY OF ANY KIND, AND RENEWED VISION HEREBY DISCLAIM ALL WARRANTIES AND CONDITIONS WITH RESPECT TO THE SOFTWARE, EITHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES AND/OR CONDITIONS OF MERCHANTABILITY, OF SATISFACTORY QUALITY, OF FITNESS FOR A PARTICULAR PURPOSE, OF ACCURACY, OF QUIET ENJOYMENT, AND NON-INFRINGEMENT OF THIRD PARTY RIGHTS. RENEWED VISION DOES NOT WARRANT AGAINST INTERFERENCE WITH YOUR ENJOYMENT OF THE SOFTWARE, THAT THE FUNCTIONS CONTAINED IN THE SOFTWARE WILL MEET YOUR REQUIREMENTS, THAT THE OPERATION OF THE SOFTWARE WILL BE UNINTERRUPTED OR ERROR-FREE, THAT THE SOFTWARE WILL BE COMPATIBLE WITH THIRD PARTY SOFTWARE, OR THAT DEFECTS IN THE SOFTWARE WILL BE CORRECTED. NO ORAL OR WRITTEN INFORMATION OR ADVICE GIVEN BY RENEWED VISION OR A RENEWED VISION AUTHORIZED REPRESENTATIVE SHALL CREATE A WARRANTY. \r\n\r\n9. LIMITATION OF LIABILITY\r\n\r\nTO THE MAXIMUM EXTENT MANDATED BY LAW, IN NO EVENT WILL RENEWED VISION BE LIABLE FOR ANY, DAMAGE TO THE USER'S COMPUTER SYSTEM OR DATA,  LOST PROFITS OR BUSINESS OPPORTUNITIES, LOSS OF USE, LOSS OF REVENUE, LOSS OF GOODWILL, BUSINESS INTERRUPTION, LOSS OF DATA, OR ANY INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES UNDER ANY THEORY OF LIABILITY, WHETHER BASED IN CONTRACT, TORT, NEGLIGENCE, PRODUCT LIABILITY, OR OTHERWISE. RENEWED VISIONS’ LIABILITY UNDER THIS EULA WILL NOT, IN ANY EVENT, REGARDLESS OF WHETHER THE CLAIM IS BASED IN CONTRACT, TORT, STRICT LIABILITY, OR OTHERWISE, EXCEED THE LICENSE FEES YOU PAID FOR THE SOFTWARE GIVING RISE TO THE CLAIM. THE FOREGOING LIMITATIONS SHALL APPLY REGARDLESS OF WHETHER RENEWED VISION HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES AND REGARDLESS OF WHETHER ANY REMEDY FAILS OF ITS ESSENTIAL PURPOSE.  SOME STATES DO NOT ALLOW THE LIMITATION OR EXCLUSION OF LIABILITY FOR INCIDENTAL OF CONSEQUENTIAL DAMAGES, SO THE ABOVE LIMITATION OR EXCLUSION MAY NOT APPLY TO YOU AND YOU MAY ALSO HAVE OTHER LEGAL RIGHTS THAT VARY FROM STATE TO STATE. THE FOREGOING LIMITATIONS ON LIABILITY ARE INTENDED TO APPLY TO THE WARRANTIES AND DISCLAIMERS ABOVE AND ALL OTHER ASPECTS OF THIS EULA.\r\n\r\n10. Miscellaneous \r\n\r\nIf any term, covenant, condition or provision of this EULA is held by a court of competent jurisdiction to be invalid, void or unenforceable, it is the parties' intent that such provision be reduced in scope by the court only to the extent deemed necessary by that court to render the provision reasonable and enforceable and the remainder of the provisions of this EULA will in no way be affected, impaired or invalidated as a result.\r\n\r\nWe do not require members to sign a contract meaning members are free to cancel at any time. Refunds will not be given for time still on the membership or after a charge goes through. This is in place so that people cannot sign up to download content and ask for money back after downloading.\r\n\r\nMembers are responsible for canceling accounts. Emailing requests or declarations does not terminate an account. If you would like assistance canceling an account that only be done by contacting us at support@renewedvision.com. Accounts can be canceled directly in your account settings directly on the website.\r\n\r\nRenewed Vision LLC / ProContent content is only licensed for active members under its membership model. Once a membership has been deactivated so is the content license. Items purchased a-la-carte are granted an ongoing license. Membership content licensing ends when the membership ends.\r\n\r\nAny member that signs up for a membership and cancels within 24 hours may be subject to an account suspension.\r\n\r\nAll notices to Renewed Vision under this EULA are to be provided at the following: support@renewedvision.com.\r\n\r\nThis EULA may be updated any time by Renewed Vision and you are responsible for being in compliance with the terms of this EULA as found on this page.\r\n\r\n\r\nProPresenter is Copyright ©2005-2023 by Renewed Vision Software, Inc. \"ProPresenter\", \"Renewed Vision\", the ProPresenter Logo, and the Renewed Vision Logo are trademarks of Renewed Vision LLC.\r\n\r\nUnless explicitly stated in writing, Renewed Vision, LLC. does not grant permission to distribute the software for profit or Not for profit in any form, including but not limited to, electronic information service distribution, bulletin board distribution, and magnetic or optical medium distribution.\r\n\r\n11. Arbitration; Class Action Waiver; Governing Law, Claims Limitation\r\n\r\nEXCEPT FOR DISPUTES, CLAIMS, OR CONTROVERSIES THAT QUALIFY FOR SMALL CLAIMS COURT, ALL DISPUTES, CLAIMS, OR CONTROVERSIES ARISING OUT OF OR RELATED TO THIS EULA OR ANY ASPECT OF THE RELATIONSHIP BETWEEN YOU AND RENEWED VISION (WHETHER BASED IN CONTRACT, TORT, STATUTE, FRAUD, MISREPRESENTATION, OR ANY OTHER LEGAL THEORY) WILL BE RESOLVED THROUGH FINAL AND BINDING ARBITRATION BEFORE A NEUTRAL ARBITRATOR INSTEAD OF A COURT. YOU AND RENEWED VISION EACH WAIVE THE RIGHT TO SUE IN COURT AND TO HAVE A JURY TRIAL. YOU AGREE THAT ANY ARBITRATION UNDER THIS EULA WILL TAKE PLACE ON AN INDIVIDUAL BASIS. CLASS ARBITRATIONS AND CLASS ACTIONS ARE NOT PERMITTED, AND YOU ARE AGREEING TO GIVE UP THE ABILITY TO PARTICIPATE IN A CLASS ACTION. \r\n\r\nPrior to initiating the arbitration, the initiating party will give written notice to the other party of its claim, and the parties will have sixty (60) days to negotiate and attempt to resolve the dispute, after which time unresolved claims may proceed to arbitration in accordance with this section. \r\n\r\nThe arbitration will be conducted in Atlanta, Georgia before one arbitrator. The arbitration will be administered by JAMS pursuant to its Comprehensive Arbitration Rules and Procedures then in effect. The arbitrator, and not any federal or state court, shall have exclusive authority to resolve any dispute, claim, or controversy arising out of or relating to the interpretation, applicability, arbitrability, enforceability, or formation of this EULA. To the extent that the arbitrator deems reasonable, the arbitrator will conduct hearings, if any, by teleconference or videoconference, rather than by personal appearances. Arbitration proceedings will be conducted in English and in a manner that preserves confidentiality. Unless you and Renewed Vision agree otherwise, any decision or award will consist of a written statement stating the disposition of each claim and including a concise written statement of the essential findings and conclusions on which the award is based. The arbitrator’s decision will follow the plain meaning of the relevant documents and will be final and binding and may be entered thereafter by any court of competent jurisdiction. The arbitrator shall not be empowered to award punitive or exemplary damages to any party, except where permitted by statute, and the parties waive any right to recover such damages. Nothing in this section shall prohibit the discovery or exchange of non-privileged information relevant to the dispute, claim, or controversy. \r\n\r\nYou and Renewed Vision will share the costs of arbitration equally with respect to JAMS fees; provided that each party will be solely responsible for its own attorneys’ fees and costs. Notwithstanding the foregoing, if you are an individual consumer, as defined by JAMS, then you will have the right to an in-person arbitration hearing in your hometown area, and Renewed Vision will be responsible for 100% of the costs and fees of the arbitration charged by JAMS after you pay a filing fee similar to the fee for filing a lawsuit in court (but each party will be solely responsible for its own attorneys’ fees and costs).  \r\n\r\nNotwithstanding the foregoing, nothing in this EULA will preclude Renewed Vision from seeking any injunctive relief or other provisional remedy in a court of law. You agree to exclusive jurisdiction of the state and federal courts located in Atlanta, Georgia for such claims, and you expressly consent to personal jurisdiction there and waive any claims that venue is improper for any reason in these courts. \r\n\r\nThis EULA shall be governed by and construed under the laws of the State of Georgia, without regard to conflicts of laws, principles, or rules, and regardless of your location. Any dispute, claim, controversy, or other legal action brought by you that arises out of or relates to this EULA must be commenced within one year after the cause of action arises. \r\n\r\n12. Contact Us\r\nAll questions concerning this EULA shall be directed to: support@renewedvision.com\r\n\r\nRenewed Vision, LLC\r\nhttps://renewedvision.com\r\n\r\nLast Updated December 14, 2023\r\n\r\n", messageService, afterStartupCompleteQueue, whatsNewV2VM);
		base.ContentRendered += OnContentRendered;
		Log.Info("Initialize components...");
		InitializeComponent();
		Log.Info("Showing the main layout...");
		base.Content = _mainLayout;
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(OnDataContextChanged);
		base.Deactivated += MainWindow_Deactivated;
		base.LostFocus += MainWindow_LostFocus;
		WindowMenuGroup windowMenu = _inputActions.WindowMenu;
		base.CommandBindings.Add(windowMenu.Minimize.BindCommand, delegate
		{
			base.WindowState = WindowState.Minimized;
		});
		base.CommandBindings.Add(windowMenu.Maximize.BindCommand, delegate
		{
			base.WindowState = WindowState.Maximized;
		}, () => base.WindowState != WindowState.Maximized);
		base.CommandBindings.Add(windowMenu.Restore.BindCommand, delegate
		{
			base.WindowState = WindowState.Normal;
		}, () => base.WindowState != WindowState.Normal);
		SlidePreviewRenderer.SetGetCurrentDPI(() => base.Scalar);
		InitializeCommandBindings();
	}

	private void InitializeCommandBindings()
	{
		CommonInputActionGroup commonInputActions = _inputActions.CommonInputActions;
		CommandManager.RegisterClassCommandBinding(typeof(ListBox), new CommandBinding(commonInputActions.DeselectAll.BindCommand, delegate(object s, ExecutedRoutedEventArgs e)
		{
			((ListBox)s).SelectedItems.Clear();
		}, delegate(object s, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((ListBox)s).SelectedItems.Count != 0 && ((ListBox)s).SelectionMode != SelectionMode.Single;
		}));
		CommandManager.RegisterClassCommandBinding(typeof(DataGrid), new CommandBinding(commonInputActions.DeselectAll.BindCommand, delegate(object s, ExecutedRoutedEventArgs e)
		{
			((DataGrid)s).SelectedItems.Clear();
		}, delegate(object s, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((DataGrid)s).SelectedItems.Count != 0;
		}));
		CommandManager.RegisterClassCommandBinding(typeof(UIElement), new CommandBinding(commonInputActions.Rename.BindCommand, delegate(object s, ExecutedRoutedEventArgs e)
		{
			if (s is Pro.UI.Controls.DataGridRow dataGridRow)
			{
				MediaCueListView mediaCueListView = ((DependencyObject)(object)dataGridRow).FindVisualParent<MediaCueListView>();
				if (mediaCueListView != null)
				{
					mediaCueListView.RenameCue(dataGridRow);
					return;
				}
			}
			((DependencyObject)(object)(s as UIElement))?.FindVisualChild((EditableTextBlock t) => t.IsVisible)?.EnterEditMode();
		}));
	}

	protected override void OnMouseTilt(int tilt)
	{
		if (!(Mouse.DirectlyOver is UIElement depObj))
		{
			return;
		}
		ScrollViewer scrollViewer = ((DependencyObject)(object)depObj).FindVisualParent<ScrollViewer>();
		if (scrollViewer != null && PropertyGetterCache.GetGetter<ScrollViewer>("ScrollInfo")?.Invoke(scrollViewer) is IScrollInfo scrollInfo)
		{
			if (tilt < 0)
			{
				scrollInfo.MouseWheelLeft();
			}
			else
			{
				scrollInfo.MouseWheelRight();
			}
		}
	}

	public void CloseWithoutConfirmation()
	{
		if (!_isClosing)
		{
			_showCloseConfirmation = false;
			Close();
		}
	}

	protected override nint WndProc(nint hWnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		handled = _messages.TryHandleMessage(msg);
		if (!handled)
		{
			return base.WndProc(hWnd, msg, wParam, lParam, ref handled);
		}
		return IntPtr.Zero;
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		_mainLayout.ReleaseHotkey(e);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		bool flag = !_showCloseConfirmation;
		bool flag2 = !_showCloseConfirmation;
		if (_showCloseConfirmation)
		{
			IMainLayoutVM? mainLayoutVM = MainLayoutVM;
			if (mainLayoutVM != null && mainLayoutVM.CaptureVM.ResiVM.ResiStreaming)
			{
				flag = MainLayoutVM.CaptureVM.ResiVM.QuitResiStreaming();
				flag2 = true;
			}
		}
		if (_showCloseConfirmation && _attachmentsUploader.IsBusy)
		{
			flag = MessageDialogService.ShowSimpleContent(LocalizedStrings.Get(_attachmentsUploader.InProgressMessageTitleStringKey), LocalizedStrings.Get(_attachmentsUploader.InProgressMessageMessageStringKey));
			if (flag)
			{
				_attachmentsUploader.Stop();
			}
			flag2 = true;
		}
		if (!flag2)
		{
			flag = MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("APP_QUIT_CONFIRMATION_title"));
		}
		if (flag)
		{
			_isClosing = true;
			SaveAllSettings();
			_mainLayout.Cleanup();
			base.OnClosing(e);
		}
		else
		{
			e.Cancel = true;
		}
	}

	private void OnContentRendered(object? sender, EventArgs e)
	{
		base.ContentRendered -= OnContentRendered;
		Log.Info("Final prep...");
		_mainLayout?.OnMainWindowContentRendered();
		MainLayoutVM.ThrowWhenNull("MainLayoutVM");
		MainLayoutVM.ImportPendingFile();
		MainLayoutVM.CaptureVM.CheckResumeCapture();
		MainLayoutVM.CaptureVM.ResiVM.QuitImmediately += CloseWithoutConfirmation;
		MainLayoutVM.TestPatternVM.LoadPatterns();
		if (_splash != null)
		{
			Log.Info("Closing the splash dialog...");
			((DispatcherObject)_splash).Dispatcher.Invoke((Action)_splash.Close);
		}
		Log.Info("Activating the window...");
		Activate();
	}

	private void SaveAllSettings()
	{
		Log.Info("Saving all settings...");
		Advanced.Settings.UpdateSettingsFile();
		_app.UpdateSettingsFile();
		BibleSettings.Settings.UpdateSettingsFile();
		Communications.Settings.UpdateSettingsFile();
		Display.Settings.UpdateSettingsFile();
		EditorPreferences.Settings.UpdateSettingsFile();
		General.Settings.UpdateSettingsFile();
		Import.Settings.UpdateSettingsFile();
		Layout.Settings.UpdateSettingsFile();
		MessagesPreferences.Settings.UpdateSettingsFile();
		_network.UpdateSettingsFile();
		StoredPcoOptions.Settings.UpdateSettingsFile();
		Sync.Settings.UpdateSettingsFile();
		TelestratorPreferences.Settings.UpdateSettingsFile();
		MainLayoutVM?.CaptureVM.RemoveLastCaptureInfo();
		MainLayoutVM?.CommitWriteQueue();
		CommonPaths.UpdateSettingsFile();
		Log.Info("Done saving all settings");
	}

	private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IMainLayoutVM mainLayoutVM)
		{
			MainLayoutVM = mainLayoutVM;
			Log.Info("Updating hotkeys...");
			ProMenuBindings(mainLayoutVM);
			FileMenuBindings(mainLayoutVM);
			EditMenuBindings(mainLayoutVM);
			PresentationMenuBindings(mainLayoutVM);
			EditorMenuBindings(mainLayoutVM);
			CalendarMenuBindings(mainLayoutVM);
			ScreensMenuBindings(mainLayoutVM);
			ViewMenuBindings(mainLayoutVM);
			WindowMenuBindings(mainLayoutVM);
			HelpMenuBindings(mainLayoutVM);
			ClearGroupBindings(mainLayoutVM);
			GroupLabelBindings(mainLayoutVM);
			MacrosBindings(mainLayoutVM);
			PropsBindings(mainLayoutVM);
			CommonCommandBindings(mainLayoutVM);
			WindowedOutputScreensBinding(_screenSelectorVM, _windowedOutputVM, _inputActions.WindowMenu);
			Log.Info("Done updating hotkeys");
		}
	}

	private void ProMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		ProMenuGroup proMenu = _inputActions.ProMenu;
		base.CommandBindings.Add(proMenu.About.BindCommand, _mainLayout.OnOpenAboutCommand);
		base.CommandBindings.Add(proMenu.OpenSettings.BindCommand, _mainLayout.OnOpenSettingsCommand);
		base.CommandBindings.Add(proMenu.Account.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Account);
		});
		base.CommandBindings.Add(proMenu.General.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.General);
		});
		base.CommandBindings.Add(proMenu.Updates.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Updates);
		});
		base.CommandBindings.Add(proMenu.Screens.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Screens);
		});
		base.CommandBindings.Add(proMenu.Network.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Network);
		});
		base.CommandBindings.Add(proMenu.Input.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Input);
		});
		base.CommandBindings.Add(proMenu.Devices.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Devices);
		});
		base.CommandBindings.Add(proMenu.Media.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Media);
		});
		base.CommandBindings.Add(proMenu.Audio.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Audio);
		});
		base.CommandBindings.Add(proMenu.Import.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Import);
		});
		base.CommandBindings.Add(proMenu.Integrations.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Integrations);
		});
		base.CommandBindings.Add(proMenu.Groups.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Groups);
		});
		base.CommandBindings.Add(proMenu.SlideLabels.BindCommand, delegate
		{
			_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.SlideLabels);
		});
		if (proMenu.Sync != null)
		{
			base.CommandBindings.Add(proMenu.Sync.BindCommand, delegate
			{
				_mainLayout.OnOpenSettingsByIndexCommand(ProPresenter.UI.ViewModels.Settings.Pages.SettingsPage.Sync);
			});
		}
		base.CommandBindings.Add(proMenu.CheckForUpdates.BindCommand, mainLayoutVM.CheckForUpdatesCommand);
		base.CommandBindings.Add(proMenu.Quit.BindCommand, mainLayoutVM.ShutdownCommand);
	}

	private void FileMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		FileMenuGroup fileMenu = _inputActions.FileMenu;
		base.CommandBindings.Add(fileMenu.NewPresentation.BindCommand, _mainLayout.OnNewCommand);
		base.CommandBindings.Add(fileMenu.NewPlaylist.BindCommand, mainLayoutVM.LibraryVM.NewPlaylistCommand);
		base.CommandBindings.Add(fileMenu.NewLibrary.BindCommand, mainLayoutVM.LibraryVM.NewLibraryCommand);
		base.CommandBindings.Add(fileMenu.ImportFile.BindCommand, mainLayoutVM.MigrationVM.ImportPresentationCommand);
		base.CommandBindings.Add(fileMenu.ImportTextFromClipboard.BindCommand, mainLayoutVM.MigrationVM.ImportFromClipboardCommand);
		base.CommandBindings.Add(fileMenu.ImportPowerPoint.BindCommand, mainLayoutVM.MigrationVM.ImportPowerPointCommand);
		base.CommandBindings.Add(fileMenu.ImportPowerPointLegacy.BindCommand, mainLayoutVM.MigrationVM.ImportPowerPointLegacyCommand);
		base.CommandBindings.Add(fileMenu.ImportMultiTracks.BindCommand, _mainLayout.OnOpenMultiTracksCommand);
		base.CommandBindings.Add(fileMenu.ImportSongSelect.BindCommand, _mainLayout.OnOpenSongSelectCommand);
		base.CommandBindings.Add(fileMenu.ImportMedia.BindCommand, mainLayoutVM.MigrationVM.ImportMediaCommand);
		base.CommandBindings.Add(fileMenu.ImportProLibrary.BindCommand, mainLayoutVM.MigrationVM.ImportFromPreviousVersionCommand);
		base.CommandBindings.Add(fileMenu.ExportPresentation.BindCommand, mainLayoutVM.LibraryVM.ExportToPro7Command);
		base.CommandBindings.Add(fileMenu.ExportPresentationBundle.BindCommand, mainLayoutVM.LibraryVM.ExportToBundleCommand);
		base.CommandBindings.Add(fileMenu.ExportText.BindCommand, mainLayoutVM.LibraryVM.ExportToTextCommand);
		base.CommandBindings.Add(fileMenu.ExportSlideImages.BindCommand, mainLayoutVM.ExportVM.ExportToImagesCommand);
		base.CommandBindings.Add(fileMenu.ExportPlaylist.BindCommand, mainLayoutVM.LibraryVM.ExportPlaylistCommand);
		base.CommandBindings.Add(fileMenu.ExportThemes.BindCommand, mainLayoutVM.TemplateVM.ExportThemeCommand);
		base.CommandBindings.Add<object>(fileMenu.Print.BindCommand, _mainLayout.OnPrintCommand, _mainLayout.CanPrint);
	}

	private void EditMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		EditMenuGroup editMenu = _inputActions.EditMenu;
		base.CommandBindings.Add(editMenu.CopyTextStyle.BindCommand, mainLayoutVM.TextStyleVM.CopyTextStyleCommand);
		base.CommandBindings.Add(editMenu.PasteTextStyle.BindCommand, mainLayoutVM.TextStyleVM.PasteTextStyleCommand);
		base.CommandBindings.Add(editMenu.KeyMapping.BindCommand, delegate
		{
			_mainLayout.OpenKeyMappingWindow();
		});
	}

	private void PresentationMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		PresentationMenuGroup presentationMenu = _inputActions.PresentationMenu;
		base.CommandBindings.Add(presentationMenu.NewSlide.BindCommand, mainLayoutVM.AddSlideCommand);
		base.CommandBindings.Add(presentationMenu.NextSlide.BindCommand, mainLayoutVM.TriggerNextSlideCommand);
		base.CommandBindings.Add(presentationMenu.PreviousSlide.BindCommand, mainLayoutVM.TriggerPreviousSlideCommand);
		base.CommandBindings.Add(presentationMenu.NextBackground.BindCommand, mainLayoutVM.MediaLibraryVM.TriggerNextBackgroundCommand);
		base.CommandBindings.Add(presentationMenu.PreviousBackground.BindCommand, mainLayoutVM.MediaLibraryVM.TriggerPreviousBackgroundCommand);
		base.CommandBindings.Add(presentationMenu.OpenClearGroups.BindCommand, delegate(object s, ClearGroupShownSource e)
		{
			_mainLayout.OpenClearGroupWindow(e);
		});
		base.CommandBindings.Add(presentationMenu.ClearSlide.BindCommand, mainLayoutVM.OutputVM.ClearSlideCommand);
		base.CommandBindings.Add(presentationMenu.ClearMedia.BindCommand, mainLayoutVM.OutputVM.ClearBackgroundCommand);
		base.CommandBindings.Add(presentationMenu.ClearProps.BindCommand, mainLayoutVM.OutputVM.ClearPropsCommand);
		base.CommandBindings.Add(presentationMenu.ClearAudio.BindCommand, mainLayoutVM.OutputVM.ClearAudioCommand);
		base.CommandBindings.Add(presentationMenu.ClearMessages.BindCommand, mainLayoutVM.OutputVM.ClearMessagesCommand);
		base.CommandBindings.Add(presentationMenu.ClearAnnouncements.BindCommand, mainLayoutVM.OutputVM.ClearAnnouncementCommand);
		base.CommandBindings.Add(presentationMenu.ClearToLogo.BindCommand, mainLayoutVM.OutputVM.DisplayLogoCommand);
		base.CommandBindings.Add(presentationMenu.ShowTriggeredPresentation.BindCommand, mainLayoutVM.LibraryVM.ShowTriggeredPresentationCommand);
		base.CommandBindings.Add(presentationMenu.ShowTriggeredAnnouncement.BindCommand, mainLayoutVM.LibraryVM.ShowTriggeredAnnouncementCommand);
		base.CommandBindings.Add(presentationMenu.RevealInLibrary.BindCommand, mainLayoutVM.LibraryVM.RevealInLibraryCommand);
		base.CommandBindings.Add(presentationMenu.SlideOnStageScreen.BindCommand, mainLayoutVM.OutputVM.ToggleSlideOnStageDisplayOnlyCommand);
	}

	private void EditorMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		EditorMenuGroup editorMenu = _inputActions.EditorMenu;
		base.CommandBindings.Add(editorMenu.TextApplyTextStyleToAllSlides.BindCommand, mainLayoutVM.TextStyleVM.ApplyTextStyleToAllSlidesCommand);
		base.CommandBindings.Add(editorMenu.ShowRulers.BindCommand, delegate
		{
			mainLayoutVM.MenuLayoutVM.IsRulerVisible = !mainLayoutVM.MenuLayoutVM.IsRulerVisible;
		});
		base.CommandBindings.Add(editorMenu.ShowTemplateGuides.BindCommand, delegate
		{
			mainLayoutVM.MenuLayoutVM.ShowTemplateGuides = !mainLayoutVM.MenuLayoutVM.ShowTemplateGuides;
		});
		base.CommandBindings.Add(editorMenu.ShowSlideGuides.BindCommand, delegate
		{
			mainLayoutVM.MenuLayoutVM.ShowSlidesGuides = !mainLayoutVM.MenuLayoutVM.ShowSlidesGuides;
		});
	}

	private void CalendarMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		CalendarMenuGroup calendarMenu = _inputActions.CalendarMenu;
		base.CommandBindings.Add(calendarMenu.Enable.BindCommand, mainLayoutVM.CalendarVM.ToggleCalendarEnabledCommand);
		base.CommandBindings.Add(calendarMenu.NewEvent.BindCommand, mainLayoutVM.CalendarVM.AddEventCommand);
	}

	private void ScreensMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		ScreensMenuGroup screensMenu = _inputActions.ScreensMenu;
		base.CommandBindings.Add(screensMenu.AudienceEnable.BindCommand, mainLayoutVM.OutputVM.ToggleAudienceScreensCommand);
		base.CommandBindings.Add(screensMenu.EditLooks.BindCommand, mainLayoutVM.AudienceLookVM.EditLooksCommand);
		base.CommandBindings.Add(screensMenu.StageEnable.BindCommand, mainLayoutVM.OutputVM.ToggleStageScreensCommand);
		base.CommandBindings.Add(screensMenu.EditLayouts.BindCommand, delegate
		{
			mainLayoutVM.EditStagePresentationCommand.Execute(new EditStageLayoutCommandParameter(ShowSource.ApplicationMenu));
		});
		base.CommandBindings.Add(screensMenu.ConfigureScreens.BindCommand, _mainLayout.OnOpenOutputConfigurationCommand);
		base.CommandBindings.Add(screensMenu.StartCapture.BindCommand, mainLayoutVM.ScreenPreviewVM.CaptureVM.StartCaptureCommand);
		base.CommandBindings.Add(screensMenu.StopCapture.BindCommand, mainLayoutVM.ScreenPreviewVM.CaptureVM.StopCaptureCommand);
		base.CommandBindings.Add(screensMenu.CaptureSettings.BindCommand, delegate(object s, CaptureShownSource e)
		{
			mainLayoutVM.ScreenPreviewVM.CaptureVM.OpenCaptureSettingsCommand.Execute(e);
		});
		base.CommandBindings.Add(screensMenu.EditSelectedLayout.BindCommand, delegate(object s, EditStageLayoutCommandParameter? e)
		{
			mainLayoutVM.EditStagePresentationCommand.Execute(e ?? new EditStageLayoutCommandParameter(ShowSource.ApplicationMenu));
		});
	}

	private void ViewMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		ViewMenuGroup viewMenu = _inputActions.ViewMenu;
		base.CommandBindings.Add(viewMenu.Show.BindCommand, mainLayoutVM.ShowMainViewCommand);
		base.CommandBindings.Add(viewMenu.ShowPresentationEditor.BindCommand, mainLayoutVM.ShowEditorCommand);
		base.CommandBindings.Add(viewMenu.ShowReflowEditor.BindCommand, mainLayoutVM.ShowReflowEditorCommand);
		base.CommandBindings.Add(viewMenu.ShowBibles.BindCommand, _mainLayout.OnShowBibleViewCommand);
		base.CommandBindings.Add(viewMenu.TogglePresentationEditor.BindCommand, mainLayoutVM.ToggleEditorCommand);
		base.CommandBindings.Add(viewMenu.ToggleReflowEditor.BindCommand, mainLayoutVM.ToggleReflowEditorCommand);
		base.CommandBindings.Add(viewMenu.ToggleBibles.BindCommand, _mainLayout.OnToggleBibleViewCommand);
		base.CommandBindings.Add(viewMenu.ContinuousPlaylist.BindCommand, delegate
		{
			General.Settings.ContiguousViewEnabled = !General.Settings.ContiguousViewEnabled;
		});
		base.CommandBindings.Add(viewMenu.GridView.BindCommand, delegate
		{
			mainLayoutVM.PresentationVM.PresentationViewSettings = new ThumbnailViewSettings(_app);
		});
		base.CommandBindings.Add(viewMenu.EasyView.BindCommand, delegate
		{
			mainLayoutVM.PresentationVM.PresentationViewSettings = new EasyViewSettings(_app);
		});
		base.CommandBindings.Add(viewMenu.TableView.BindCommand, delegate
		{
			mainLayoutVM.PresentationVM.PresentationViewSettings = new ListViewSettings(_app);
		});
		base.CommandBindings.Add(viewMenu.AudioBin.BindCommand, _mainLayout.OnOpenAudioCommand);
		base.CommandBindings.Add(viewMenu.Stage.BindCommand, _mainLayout.OnOpenStageDisplayControlCommand);
		base.CommandBindings.Add(viewMenu.Timers.BindCommand, _mainLayout.OnOpenTimersCommand);
		base.CommandBindings.Add(viewMenu.Messages.BindCommand, _mainLayout.OnOpenMessagesCommand);
		base.CommandBindings.Add(viewMenu.Props.BindCommand, _mainLayout.OnOpenPropsCommand);
		base.CommandBindings.Add(viewMenu.Macros.BindCommand, _mainLayout.OnOpenMacrosCommand);
		base.CommandBindings.Add(viewMenu.Timecode.BindCommand, _mainLayout.OpenTimecode);
		base.CommandBindings.Add(viewMenu.PlanningCenter.BindCommand, _mainLayout.OnOpenPCOLiveCommand);
		base.CommandBindings.Add(viewMenu.ToggleMediaBin.BindCommand, _mainLayout.OnToggleMediaBinCommand);
		base.CommandBindings.Add(viewMenu.ProContent.BindCommand, _mainLayout.OnShowProContentViewCommand);
		base.CommandBindings.Add(viewMenu.Calendar.BindCommand, mainLayoutVM.CalendarVM.ShowCalendarCommand);
		base.CommandBindings.Add(viewMenu.ActionPalette.BindCommand, _mainLayout.OnOpenActionPaletteCommand);
		base.CommandBindings.Add(viewMenu.TestPatterns.BindCommand, delegate(object s, TestPatternUIShownSource e)
		{
			_mainLayout.OnOpenTestPatternsCommand(e);
		});
		base.CommandBindings.Add(viewMenu.Downloads.BindCommand, mainLayoutVM.DownloadsVM.TogglePopoverCommand);
		base.CommandBindings.Add(viewMenu.OpenProPresenterControl.BindCommand, delegate
		{
			_hyperlinkService.Open(_webSourceProvider.ProPresenterControlLink(_network.NetworkPort));
		}, () => _network.EnableNetwork);
	}

	private void WindowMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		WindowMenuGroup windowMenu = _inputActions.WindowMenu;
		base.CommandBindings.Add(windowMenu.WelcomeToPro.BindCommand, delegate
		{
			mainLayoutVM.WelcomeVM.ShowWelcomeDialog(this, isFirstLaunch: false);
		});
	}

	private void HelpMenuBindings(IMainLayoutVM mainLayoutVM)
	{
		HelpMenuGroup helpMenu = _inputActions.HelpMenu;
		base.CommandBindings.Add(helpMenu.ReportIssue.BindCommand, delegate
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			if ((Keyboard.Modifiers & 1) == 1)
			{
				_crashReportUserFeedbackDialogProvider.ShowInternalFeedback(this).ExecuteAsync();
			}
			else
			{
				_crashReportUserFeedbackDialogProvider.ShowUserFeedback(this, isReportingIssue: true).ExecuteAsync();
			}
		});
		base.CommandBindings.Add(helpMenu.SubmitFeedback.BindCommand, delegate
		{
			_crashReportUserFeedbackDialogProvider.ShowUserFeedback(this, isReportingIssue: false).ExecuteAsync();
		});
		base.CommandBindings.Add(helpMenu.ContactSupport.BindCommand, delegate
		{
			_hyperlinkService.Open(_webSourceProvider.ContactSupport);
		});
		base.CommandBindings.Add(helpMenu.KnowledgeBase.BindCommand, delegate
		{
			_hyperlinkService.Open(_webSourceProvider.KnowledgeBase);
		});
		base.CommandBindings.Add(helpMenu.VideoTutorials.BindCommand, delegate
		{
			_hyperlinkService.Open(_webSourceProvider.VideoTutorials);
		});
		base.CommandBindings.Add(helpMenu.DownloadSampleContent.BindCommand, delegate
		{
			OnDownloadSampleContentCommand(mainLayoutVM);
		});
		base.CommandBindings.Add(helpMenu.ReleaseNotes.BindCommand, delegate
		{
			_hyperlinkService.Open(_webSourceProvider.GetReleaseNotes());
		});
		base.CommandBindings.Add(helpMenu.CrashReport.BindCommand, delegate
		{
			_crashReportUserFeedbackDialogProvider.ShowCrashReport(this, hasCrashed: false).ExecuteAsync();
		});
		base.CommandBindings.Add(helpMenu.WhatsNew.BindCommand, _mainLayout.OnOpenWhatsNewCommand);
		base.CommandBindings.Add(helpMenu.FindMyMouse.BindCommand, _mainLayout.OnFindMyMouseCommand);
		base.CommandBindings.Add(helpMenu.AdvancedOnScreenStats.BindCommand, delegate
		{
			_app.ShowAdvancedOnScreenStats = !_app.ShowAdvancedOnScreenStats;
		});
		base.CommandBindings.Add(helpMenu.DumpWorkspaceInfo.BindCommand, delegate
		{
			_workspaceInfoDumper.DumpWorkspaceInfoAsync().ExecuteAsync();
		});
	}

	private void OnDownloadSampleContentCommand(IMainLayoutVM mainLayoutVM)
	{
		ISampleContentVM sampleContentVM = mainLayoutVM.WelcomeVM.SampleContentVM;
		if (!sampleContentVM.IsDownloading)
		{
			sampleContentVM.GetSampleContentCommand.Execute(null);
			if (sampleContentVM.IsDownloading)
			{
				SampleContentDownloadDialog sampleContentDownloadDialog = new SampleContentDownloadDialog(sampleContentVM);
				sampleContentDownloadDialog.Owner = this;
				sampleContentDownloadDialog.Show();
			}
		}
	}

	private void ClearGroupBindings(IMainLayoutVM mainLayoutVM)
	{
		_inputActions.ClearGroups.SetupCollection<ClearGroupInputAction>(delegate(InputAction i)
		{
			ClearGroupInputAction clearGroupAction = i as ClearGroupInputAction;
			if (clearGroupAction != null)
			{
				ClearGroup parameter = mainLayoutVM.ClearGroupsVM.ClearGroupCollection.FirstOrDefaultBy(delegate(ClearGroup c)
				{
					Guid iD = c.ID;
					Guid? obj = clearGroupAction.ClearGroupId?.ID;
					return iD == obj;
				}, (ClearGroup c) => c.Name == clearGroupAction.ClearGroupId?.Name);
				mainLayoutVM.OutputVM.TriggerClearGroupCommand.Invoke<ClearGroup>(parameter);
			}
		}, base.CommandBindings);
	}

	private void WindowedOutputScreensBinding(IScreenSelectorVM screenSelectorVM, IWindowedOutputVM windowedOutputVM, WindowMenuGroup windowMenuGroup)
	{
		windowMenuGroup.SetupCollection<OutputScreenInputAction>(delegate(InputAction i)
		{
			OutputScreenInputAction outputScreenInputAction = i as OutputScreenInputAction;
			if (outputScreenInputAction != null)
			{
				IOutputScreenVM parameter = screenSelectorVM.AudienceScreens.FirstOrDefault(delegate(IOutputScreenVM c)
				{
					Guid id = c.Id;
					Guid? obj = outputScreenInputAction.Screen?.ID;
					return id == obj;
				}) ?? screenSelectorVM.StageScreens.FirstOrDefault(delegate(IOutputScreenVM c)
				{
					Guid id2 = c.Id;
					Guid? obj2 = outputScreenInputAction.Screen?.ID;
					return id2 == obj2;
				});
				windowedOutputVM.CreateOutputWindowCommand.Execute(parameter);
			}
		}, base.CommandBindings);
	}

	private void GroupLabelBindings(IMainLayoutVM mainLayoutVM)
	{
		_inputActions.GroupLabels.SetupCollection<GroupLabelInputAction>(delegate(InputAction i)
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			int valueOrDefault = ((mainLayoutVM.PresentationVM.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.ActiveArrangement?.ArrangedCues.Count).GetValueOrDefault();
			SlideTriggerControl slideTriggerControl = _mainLayout.SlideTriggerControl;
			VirtualKeyGesture? keyboardGesture = i.KeyboardGesture;
			slideTriggerControl.UpdateSlideHotkey((Key)(((object)keyboardGesture != null) ? ((int)keyboardGesture.Key.GetData().Key) : 0), valueOrDefault);
			mainLayoutVM.PresentationVM.TriggerHotkeyCommand?.Invoke(_mainLayout.SlideTriggerControl.SlideHotkey);
		}, base.CommandBindings, (InputActionGroupBase? _) => _mainLayout.ActiveInlineView != InlineType.Presentation);
	}

	private void MacrosBindings(IMainLayoutVM mainLayoutVM)
	{
		_inputActions.MacroGroups.Children?.SetupCollection<MacroGroup, MacroInputAction>(delegate(InputAction i)
		{
			MacroInputAction macroInputAction = i as MacroInputAction;
			if (macroInputAction != null)
			{
				foreach (IMacroGroupVM macroGroup in mainLayoutVM.MacroGroupsVM.MacroGroups)
				{
					if ((object)macroInputAction.MacroId != null)
					{
						IMacroItemVM macroItemVM = macroGroup.SourceMacros.FirstOrDefaultBy((IMacroItemVM m) => m.Macro.ID == macroInputAction.MacroId.ID, (IMacroItemVM m) => m.Macro.Name == macroInputAction.MacroId.Name);
						if (macroItemVM != null)
						{
							macroGroup.TriggerMacroCommand.Invoke(macroItemVM);
							break;
						}
					}
				}
			}
		}, base.CommandBindings);
	}

	private void PropsBindings(IMainLayoutVM mainLayoutVM)
	{
		PropsGroupsGroup propGroups = _inputActions.PropGroups;
		if (propGroups?.Children == null)
		{
			return;
		}
		propGroups.Children.SetupCollection<PropGroup, PropInputAction>(delegate(InputAction i)
		{
			PropInputAction propInputAction = i as PropInputAction;
			if (propInputAction != null)
			{
				IPropCueVM propCueVM = mainLayoutVM.PropGroupCollectionVM.PropGroups.SelectMany((IPropGroupVM g) => g.PropCues).FirstOrDefaultBy(delegate(IPropCueVM m)
				{
					Guid iD = ((IPropCueVMInternal)m).Source.ID;
					Guid? obj = propInputAction.PropId?.ID;
					return iD == obj;
				}, (IPropCueVM m) => ((IPropCueVMInternal)m).Source.Name == propInputAction.PropId?.Name);
				propCueVM?.Parent.TogglePropCommand.Invoke<IPropCueVM>(propCueVM);
			}
		}, base.CommandBindings);
	}

	private void CommonCommandBindings(IMainLayoutVM mainLayoutVM)
	{
		CommonInputActionGroup commonInputActions = _inputActions.CommonInputActions;
		ProPresenterGroup proCommon = _inputActions.ProCommon;
		base.CommandBindings.Add(proCommon.ConfigureGroupHotkey.BindCommand, delegate
		{
			_mainLayout.ConfigureGroupLabelHotkey();
		}, () => true);
		base.CommandBindings.Add(commonInputActions.Open.BindCommand, delegate(IFileResource? f)
		{
			ProcessHelper.ShowFileInExplorer(f.Path);
		}, (IFileResource? f) => f != null && File.Exists(f.Path));
		base.CommandBindings.Add(commonInputActions.Find.BindCommand, delegate(object s, SearchContext? e)
		{
			_mainLayout.OnFindCommand(s == this, e);
		}, (object e) => true);
		base.CommandBindings.Add(commonInputActions.Undo.BindCommand, mainLayoutVM.MenuLayoutVM.UndoCommand);
		base.CommandBindings.Add(commonInputActions.Redo.BindCommand, mainLayoutVM.MenuLayoutVM.RedoCommand);
		base.CommandBindings.Add(proCommon.NextSlideWithSuppression.BindCommand, mainLayoutVM.TriggerNextSlideWithSuppressionCommand);
		base.CommandBindings.Add(proCommon.RefreshPCOPlaylist.BindCommand, mainLayoutVM.LibraryVM.RefreshPCOPlaylistCommand);
		base.CommandBindings.Add(proCommon.ConvertPCOPlaylist.BindCommand, mainLayoutVM.LibraryVM.ConvertPCOPlaylistCommand);
		base.CommandBindings.Add(proCommon.NewPCOPlaylist.BindCommand, mainLayoutVM.PCOLiveVM.ShowPlanBrowserCommand);
		base.CommandBindings.Add(proCommon.OpenPCOAttachmentManager.BindCommand, _mainLayout.OnOpenPCOAttachmentManagerCommand);
		base.CommandBindings.Add(commonInputActions.NavigateDown.BindCommand, mainLayoutVM.PresentationVM.GoToNextPresentationCommand);
		base.CommandBindings.Add(commonInputActions.NavigateUp.BindCommand, mainLayoutVM.PresentationVM.GoToPreviousPresentationCommand);
		base.CommandBindings.Add(proCommon.NewTheme.BindCommand, mainLayoutVM.TemplateVM.NewThemeCommand);
		base.CommandBindings.Add(proCommon.EditTheme.BindCommand, mainLayoutVM.TemplateVM.EditThemeCommand);
		base.CommandBindings.Add(proCommon.DeleteTheme.BindCommand, mainLayoutVM.TemplateVM.DeleteThemeCommand);
		base.CommandBindings.Add(proCommon.AddSelectionToNewTheme.BindCommand, mainLayoutVM.TemplateVM.AddSelectionToNewThemeCommand);
		base.CommandBindings.Add(proCommon.AddSelectionToTheme.BindCommand, mainLayoutVM.TemplateVM.AddSelectionToThemeCommand);
		base.CommandBindings.Add(proCommon.OpenMediaInspector.BindCommand, delegate(InspectorParameter? p)
		{
			_mainLayout.OnOpenMediaInspectorCommand(p);
		}, (InspectorParameter? i) => i?.Cues != null && !i.Cues.Empty());
	}

	private void MainWindow_Deactivated(object? sender, EventArgs e)
	{
		ResetKeyStates();
	}

	private void MainWindow_LostFocus(object? sender, RoutedEventArgs e)
	{
		ResetKeyStates();
	}

	private void ResetKeyStates()
	{
		if (MainLayoutVM != null)
		{
			MainLayoutVM.PresentationVM.HideBackgroundImage = false;
			MainLayoutVM.PresentationVM.ForceFlipView = false;
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Invalid comparison between Unknown and I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected I4, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		if (_mainLayout.ActiveInlineView != InlineType.Presentation)
		{
			return;
		}
		ModifierKeys[] array = new ModifierKeys[3];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		if (KeyboardHelper.IsModifierPressed((ModifierKeys[])(object)array) || e.IsInputRestricted())
		{
			return;
		}
		Key key = e.Key;
		int valueOrDefault = ((MainLayoutVM?.PresentationVM.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.ActiveArrangement?.ArrangedCues.Count).GetValueOrDefault();
		if (((int)key >= 34 && (int)key <= 43) || ((int)key >= 74 && (int)key <= 83))
		{
			int value = (((int)key >= 74) ? (key - 74) : (key - 34));
			_mainLayout.SlideTriggerControl.UpdateSlideNumber(value, valueOrDefault);
		}
		else if ((int)key >= 44 && (int)key <= 69)
		{
			_mainLayout.SlideTriggerControl.UpdateSlideHotkey(key, valueOrDefault);
			MainLayoutVM?.PresentationVM.TriggerHotkeyCommand?.Invoke(_mainLayout.SlideTriggerControl.SlideHotkey);
		}
		else if ((int)key == 6 && _mainLayout.SlideTriggerControl.CanShowPopup)
		{
			if (int.TryParse(_mainLayout.SlideTriggerControl.SlideNumber, out var result))
			{
				MainLayoutVM?.PresentationVM.TriggerNumberCommand?.Invoke(result);
			}
			_mainLayout.SlideTriggerControl.CanShowPopup = false;
		}
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
			_mainLayout.Dispose();
		}
	}
}
