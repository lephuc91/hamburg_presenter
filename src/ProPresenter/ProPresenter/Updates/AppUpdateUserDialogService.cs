using System;
using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Startup;
using Pro.Common.Versioning;
using Pro.Localization;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using Pro.Web.Services;
using ProPresenter.DO.Updates;
using ProPresenter.UI.Updates;
using ProPresenter.ViewModels.Updates;

namespace ProPresenter.Updates;

public class AppUpdateUserDialogService : IAppUpdateUserDialogService
{
	private sealed class PerformActionOnDispose : IDisposable
	{
		private readonly Action _disposeAction;

		public PerformActionOnDispose(Action disposeAction)
		{
			_disposeAction = disposeAction;
		}

		public void Dispose()
		{
			_disposeAction();
		}
	}

	private sealed class EmptyDisposable : IDisposable
	{
		public void Dispose()
		{
		}
	}

	private readonly IUiDispatcher _dispatcher;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	private readonly Lazy<UpdateViewer> _updateViewer = new Lazy<UpdateViewer>();

	public AppUpdateUserDialogService(IUiDispatcher dispatcher, IVersionInfoProvider versionInfoProvider, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IAfterStartupCompleteQueue afterStartupCompleteQueue)
	{
		_dispatcher = dispatcher;
		_versionInfoProvider = versionInfoProvider;
		_hyperlinkService = hyperlinkService;
		_registrationWebResourceService = registrationWebResourceService;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
	}

	public bool CheckIfUserReallyWantsToDowngrade()
	{
		return _dispatcher.Invoke(() => MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("UPDATES_DOWNGRADE_ALERT_message")));
	}

	public void EnsureUpdateViewerIsShown(IAppUpdateService appUpdateService)
	{
		_afterStartupCompleteQueue.Enqueue(delegate
		{
			_dispatcher.Invoke(delegate
			{
				if (_updateViewer.Value.Visibility != 0)
				{
					if (_updateViewer.Value.DataContext is UpdatesViewerVM updatesViewerVM)
					{
						updatesViewerVM.Dispose();
					}
					_updateViewer.Value.DataContext = new UpdatesViewerVM(appUpdateService, _versionInfoProvider);
					_updateViewer.Value.Visibility = Visibility.Visible;
				}
			});
		});
	}

	public IDisposable ShowCheckingForUpdates()
	{
		return _dispatcher.Invoke((Func<IDisposable>)delegate
		{
			Window progressWindow = MessageDialogService.ShowDialogNonBlocking(string.Empty, (DependencyObject)(object)new CheckingUpdate(), DefaultButtons.CANCEL, DefaultButtons.CANCEL, delegate
			{
				progressWindow = null;
			});
			return new PerformActionOnDispose(delegate
			{
				_dispatcher.Invoke(delegate
				{
					if (progressWindow != null)
					{
						WindowHelper.SetChildOf(progressWindow, WindowAttachedTo.NotSet);
						progressWindow.Close();
					}
				});
			});
		}) ?? new EmptyDisposable();
	}

	public void ShowInternetUnavailable()
	{
		_dispatcher.Invoke(delegate
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"));
		});
	}

	public void ShowNoUpdatesAvailable()
	{
		_dispatcher.Invoke(() => MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)new UpdateToDate(LocalizedStrings.Get("UPDATES_UP_TO_DATE_VERSION_label", new object[1] { VersionInfo.FullDisplayAppVersion })), DefaultButtons.OK, DefaultButtons.OK));
	}

	public void ShowRevertToProduction()
	{
		_dispatcher.Invoke(delegate
		{
			MessageContent content = new MessageContent
			{
				Heading = LocalizedStrings.Get("UPDATE_CHANNEL_DIALOG_SWITCH_CHANNEL_title"),
				Message = LocalizedStrings.Get("UPDATE_CHANNEL_DIALOG_SWITCH_CHANNEL_EXPLANATION_title")
			};
			ProductionRestoreButtons? productionRestoreButtons = MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)content, ProductionRestoreButtons.ContinueBeta | ProductionRestoreButtons.DownloadPreviosVersion, ProductionRestoreButtons.DownloadPreviosVersion);
			if (productionRestoreButtons.HasValue && productionRestoreButtons == ProductionRestoreButtons.DownloadPreviosVersion)
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetDownloadProPresenterVersions()));
			}
		});
	}

	public void ShowUpdateProgress(IAppDownload appDownload)
	{
		_dispatcher.Invoke(delegate
		{
			DownloadUpdate downloadUpdate = new DownloadUpdate();
			downloadUpdate.DataContext = new AppDownloadVM(appDownload);
			downloadUpdate.Show();
		});
	}

	public void ShowLicenseDoesNotCoverCurrentVersion()
	{
		_dispatcher.Invoke(delegate
		{
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_message", new object[1] { _versionInfoProvider.ShortDisplayAppVersion }),
				Message = LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_info")
			}, new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[3]
			{
				new ButtonDescriptor(LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_SUBSCRIPTION_BUTTIN_title"), IsDefault: true, IsCancel: false, delegate
				{
					_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetUpgradeToSubscription()));
				}),
				new ButtonDescriptor(LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_DOWNLOAD_PREVIOUS_VERSION_BUTTON_title"), IsDefault: false, IsCancel: false, delegate
				{
					_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetDownloadProPresenterVersions()));
				}),
				new ButtonDescriptor(LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_CONTINUE_BUTTON_title"))
			}), null, 600.0);
		});
	}

	public bool ShowNotAllLicesnesAvailableForLicense(string latestAvailableVersion, int availableUpdates)
	{
		return _dispatcher.Invoke(delegate
		{
			bool shouldUpgrade = false;
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = LocalizedStrings.Get("UPDATES_PURCHASE_SUBSCRIPTION_AVAILABLE_message", new object[1] { availableUpdates }),
				Message = LocalizedStrings.Get("UPDATES_PURCHASE_SUBSCRIPTION_UNAVAILABLE_info")
			}, new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[3]
			{
				new ButtonDescriptor(LocalizedStrings.Get("UPDATES_RENEW_LICENSE_DOWNLOAD_UPDATES_title", new object[1] { availableUpdates }), IsDefault: true, IsCancel: false, delegate
				{
					shouldUpgrade = true;
				}),
				new ButtonDescriptor(LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_SUBSCRIPTION_BUTTIN_title"), IsDefault: false, IsCancel: false, delegate
				{
					_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetUpgradeToSubscription()));
				}),
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"))
			}), null, null, canClose: true);
			return shouldUpgrade;
		});
	}

	public void ShowOnlyLicensesNotCoveredByLicenseAvailable()
	{
		_dispatcher.Invoke(delegate
		{
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = LocalizedStrings.Get("UPDATES_PURCHASE_SUBSCRIPTION_UNAVAILABLE_message"),
				Message = LocalizedStrings.Get("UPDATES_PURCHASE_SUBSCRIPTION_UNAVAILABLE_info")
			}, new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("REGISTRATION_LICENSE_VERSION_SUBSCRIPTION_BUTTIN_title"), IsDefault: false, IsCancel: false, delegate
				{
					_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetUpgradeToSubscription()));
				}),
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"))
			}), null, null, canClose: true);
		});
	}
}
