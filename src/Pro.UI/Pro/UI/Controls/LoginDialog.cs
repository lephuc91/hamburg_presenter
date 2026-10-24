using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Background;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Controls.Windowing;
using Pro.UI.Factories.LoginDialog;
using Pro.Web.Cookies;

namespace Pro.UI.Controls;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_webView" })]
public partial class LoginDialog : ChromedWindow, ILoginDialog, IComponentConnector, IDisposable
{
	private const string VISIBILITY_CONVERTER = "ValuetoVisibilityConverter";

	private const string DefaultCacheSession = "cookies-login";

	private readonly string _cachePath;

	private readonly ICookieManagerService _cookieManagerService;

	private WebView2? _webView;

	private CookieSession _cookieSession;

	private readonly string _initialLoginUrl;

	private readonly Func<string, bool> _isValidLoginUrl;

	public static readonly DependencyProperty CacheSessionProperty = DependencyProperty.Register("CacheSession", typeof(string), typeof(LoginDialog), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, new PropertyChangedCallback(OnCacheSessionPropertyChanged)));

	public static readonly DependencyProperty ShowBrowserProperty = DependencyProperty.Register("ShowBrowser", typeof(bool), typeof(LoginDialog), new PropertyMetadata((object)false));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string CacheSession
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CacheSessionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CacheSessionProperty, (object)value);
		}
	}

	public bool ShowBrowser
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowBrowserProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowBrowserProperty, (object)value);
		}
	}

	public string FinalLoginUrl { get; private set; } = string.Empty;

	public Predicate<string>? CanContinueBrowseUrl { get; set; }

	private static void OnCacheSessionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LoginDialog)(object)d).OnCacheSessionChangedAsync((string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue).ExecuteAsync();
	}

	public LoginDialog(string cachePath, ICookieManagerService cookieManagerService, CookieSession cookieSession, string initialLoginUrl, Func<string, bool> isValidLoginUrl)
	{
		_initialLoginUrl = initialLoginUrl;
		_isValidLoginUrl = isValidLoginUrl;
		_cachePath = cachePath;
		_cookieManagerService = cookieManagerService;
		_cookieSession = cookieSession;
		InitializeComponent();
		CacheSession = "cookies-login";
		base.Closing += delegate
		{
			_webView?.Dispose();
		};
	}

	private async Task OnCacheSessionChangedAsync(string newValue)
	{
		ShowBrowser = false;
		WebViewContentPresenter.Content = null;
		_webView?.CoreWebView2?.CookieManager?.DeleteAllCookies();
		_webView?.Dispose();
		_webView = new WebView2
		{
			CreationProperties = new CoreWebView2CreationProperties
			{
				UserDataFolder = Path.Combine(_cachePath, newValue, _cookieSession.Filter.GetHashCode().ToString())
			}
		};
		_webView.SetBinding(UIElement.VisibilityProperty, new Binding
		{
			Source = this,
			Path = new PropertyPath("ShowBrowser"),
			Converter = (base.Resources["ValuetoVisibilityConverter"] as IValueConverter)
		});
		WebViewContentPresenter.Content = _webView;
		await _webView.EnsureCoreWebView2Async();
		_webView.CoreWebView2.NavigationStarting += LoginWebView_OnNavigationStarting;
		_webView.CoreWebView2.NavigationCompleted += LoginWebView_OnNavigationCompleted;
		_webView.CoreWebView2.NewWindowRequested += LoginWebView_OnNewWindowRequested;
		_webView.CoreWebView2.CookieManager?.DeleteAllCookies();
		_webView.CoreWebView2.Navigate(_initialLoginUrl ?? string.Empty);
	}

	private void LoginWebView_OnNewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
	{
		e.Handled = true;
		_webView.CoreWebView2.Navigate(e.Uri);
	}

	private void LoginWebView_OnNavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
	{
		EvaluateNavigation(e.Uri).ExecuteAsync();
	}

	private void LoginWebView_OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		ShowBrowser = true;
	}

	private async Task EvaluateNavigation(string url)
	{
		if (_isValidLoginUrl(url))
		{
			FinalLoginUrl = url;
			foreach (CoreWebView2Cookie item in (await _webView.CoreWebView2.CookieManager.GetCookiesAsync(string.Empty)).Where((CoreWebView2Cookie c) => c.Domain.Contains(_cookieSession.Filter)))
			{
				_cookieManagerService.CreateOrUpdate(item.Name, item.Value, item.Domain, item.Expires);
			}
			Close();
		}
		if (CanContinueBrowseUrl != null && !CanContinueBrowseUrl(_webView.Source.ToString()))
		{
			Close();
		}
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
			_webView?.Dispose();
		}
	}

	bool? ILoginDialog.ShowDialog()
	{
		return ShowDialog();
	}
}
