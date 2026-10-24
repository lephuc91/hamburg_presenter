using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Web.WebView2.Core;
using Pro.Common.Background;
using Pro.Common.OAuth;
using Pro.UI.DependencyInjection;
using Pro.Web.Cookies;
using ProPresenter.DO;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.PCOLive;

public partial class PCOLiveViewer : UserControl, IComponentConnector
{
	private bool _applicationClosed;

	private readonly ICookieManagerService _cookieManager;

	public static readonly DependencyProperty CredentialStateProperty = DependencyProperty.Register("CredentialState", typeof(CredentialState), typeof(PCOLiveViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PCOLiveViewer)(object)s).OnCredentialStateChanged((CredentialState)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty LivePlanProperty = DependencyProperty.Register("LivePlan", typeof(PCOObject), typeof(PCOLiveViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PCOLiveViewer)(object)s).SetUrl((PCOObject)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public CredentialState CredentialState
	{
		get
		{
			return (CredentialState)((DependencyObject)this).GetValue(CredentialStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CredentialStateProperty, (object)value);
		}
	}

	public PCOObject LivePlan
	{
		get
		{
			return (PCOObject)((DependencyObject)this).GetValue(LivePlanProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LivePlanProperty, (object)value);
		}
	}

	public string UserDataFolder { get; } = Path.Combine(CommonPaths.WebCache, "pco");

	public event Action? Close;

	public PCOLiveViewer()
	{
		_cookieManager = UIServiceProvider.GetService<ICookieManagerService>();
		InitializeComponent();
		base.Loaded += PCOLiveViewer_Loaded;
		if (Application.Current.MainWindow != null)
		{
			Application.Current.MainWindow.Closing += OnApplicationWindowClosing;
		}
		PCOWebView.NavigationCompleted += PCOWebView_NavigationCompleted;
	}

	private void PCOLiveViewer_Loaded(object? sender, RoutedEventArgs e)
	{
		PCOLiveViewer_LoadedAsync(sender, e).ExecuteAsync();
	}

	private async Task PCOLiveViewer_LoadedAsync(object? sender, RoutedEventArgs e)
	{
		if (_applicationClosed)
		{
			return;
		}
		await PCOWebView.EnsureCoreWebView2Async();
		foreach (CookieModel cookie in _cookieManager.GetCookies(CookieSession.PCO))
		{
			if (!string.IsNullOrEmpty(cookie.Value))
			{
				CoreWebView2Cookie coreWebView2Cookie = PCOWebView.CoreWebView2.CookieManager.CreateCookie(cookie.Name, cookie.Value, cookie.Domain, null);
				coreWebView2Cookie.Expires = cookie.Expiration;
				PCOWebView.CoreWebView2.CookieManager.AddOrUpdateCookie(coreWebView2Cookie);
			}
		}
	}

	private void OnApplicationWindowClosing(object? sender, CancelEventArgs e)
	{
		PCOWebView.Dispose();
		_applicationClosed = true;
	}

	private void OnCredentialStateChanged(CredentialState credentialState)
	{
		if (credentialState == CredentialState.Unauthorized)
		{
			this.Close?.Invoke();
		}
	}

	private void SetUrl(PCOObject pcoObject)
	{
		if (pcoObject is PCOPlan plan)
		{
			PCOWebView.Source = new Uri(GenerateUrl(plan));
		}
	}

	private static string GenerateUrl(PCOPlan plan)
	{
		return PCOLiveLinkGenerator.Generate(plan.ID, PCOLiveLayout.Mobile, PCOLiveCountdownType.FullItemLength, PCOLiveTheme.Light);
	}

	private void PCOWebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		UpdateCookieStorageAsync().ExecuteAsync();
	}

	private async Task UpdateCookieStorageAsync()
	{
		foreach (CoreWebView2Cookie item in (await PCOWebView.CoreWebView2.CookieManager.GetCookiesAsync(string.Empty)).Where((CoreWebView2Cookie c) => c.Domain.Contains(CookieSession.PCO.Filter)))
		{
			_cookieManager.CreateOrUpdate(item.Name, item.Value, item.Domain, item.Expires);
		}
	}
}
