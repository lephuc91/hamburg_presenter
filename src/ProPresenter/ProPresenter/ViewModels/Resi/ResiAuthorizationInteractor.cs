using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.OAuth;
using Pro.Common.Utility;
using Pro.UI.Factories.LoginDialog;
using Pro.Web.Cookies;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Resi;

namespace ProPresenter.ViewModels.Resi;

public class ResiAuthorizationInteractor : LinkedNotifyPropertyChangedBase, IResiAuthorizationInteractor, INotifyPropertyChanged
{
	private const string DeauthorizationSuccess = "/unregisteruploader/success";

	private readonly IResiWebClient _webClient;

	private readonly IResiPlugin _plugin;

	private readonly ILoginDialogFactory _loginDialogFactory;

	private readonly IResiPrompt _resiPrompt;

	private readonly IInternetAccess _internetAccess;

	public bool CanExecute => _plugin.CurrentStatus.IsAnyOf(ResiStreamStatus.Unknown, ResiStreamStatus.Stopped);

	public ResiAuthorizationInteractor(IResiWebClient webClient, IResiPlugin plugin, ILoginDialogFactory loginDialogFactory, IResiPrompt resiPrompt, IMessageService messageService, IInternetAccess internetAccess)
	{
		_webClient = webClient;
		_plugin = plugin;
		_loginDialogFactory = loginDialogFactory;
		_resiPrompt = resiPrompt;
		_internetAccess = internetAccess;
		LinkAction("AccountStatus", delegate
		{
			if (_plugin.AccountStatus == AccountStatus.Invalid)
			{
				Deauthorize();
			}
		});
		LinkProperties("CurrentStatus", "CanExecute");
		_plugin.PropertyChanged += base.RaiseLinkedValues;
		messageService?.SubscribeToMessage<MainWindowContentRenderedMessage>(delegate
		{
			if (_webClient.UsesCustomEndpoints)
			{
				_resiPrompt.ShowCustomEndpointsWarning();
			}
		});
	}

	public async Task ExecuteLoginAsync()
	{
		if (_internetAccess.CheckIfInternetAvailableThenShowPrompt())
		{
			string initialLoginUrl = await _webClient.BeginAuthorizationAsync();
			_loginDialogFactory.CreateDialogForMainWindow(CommonPaths.WebCache, CookieSession.Resi, initialLoginUrl, _webClient.TryCompleteAuthorization, string.Empty, null, 700.0, 700.0).ShowDialog();
			TrackChange();
		}
	}

	public async Task ExecuteLogoutAsync()
	{
		if (!_internetAccess.CheckIfInternetAvailableThenShowPrompt())
		{
			return;
		}
		if (await PromptForLogoutConfirmationAsync())
		{
			if (_plugin.PluginStatus != PluginStatus.Stopped)
			{
				_plugin.Stop();
			}
			Deauthorize();
			RemovePlugin();
		}
		TrackChange();
	}

	private void Deauthorize()
	{
		_webClient.Deauthorize();
	}

	private void RemovePlugin()
	{
		_plugin.Remove();
	}

	private async Task<bool> PromptForLogoutConfirmationAsync()
	{
		bool success = false;
		WebView2 webView = CreateWebViewControl();
		Window window = new Window
		{
			Content = webView,
			Height = 700.0,
			Width = 700.0,
			Owner = Application.Current.MainWindow,
			WindowStartupLocation = WindowStartupLocation.CenterOwner,
			Title = " "
		};
		string url = await _webClient.GetDeauthorizationResourceAsync();
		webView.Source = new Uri(url);
		webView.NavigationStarting += delegate(object? s, CoreWebView2NavigationStartingEventArgs e)
		{
			url = e.Uri;
		};
		window.Closing += delegate
		{
			webView.Dispose();
		};
		webView.NavigationCompleted += delegate
		{
			if (url.Contains("/unregisteruploader/success"))
			{
				success = true;
				window.Close();
			}
		};
		window.ShowDialog();
		return success;
	}

	private WebView2 CreateWebViewControl()
	{
		WebView2 webView = new WebView2();
		webView.CreationProperties = new CoreWebView2CreationProperties
		{
			UserDataFolder = CommonPaths.WebCache
		};
		webView.EnsureCoreWebView2Async();
		return webView;
	}

	private void TrackChange()
	{
		ResiLoginChangeEvent.Publish(_webClient.AuthorizationState == CredentialState.Authorized);
	}
}
