using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Background;
using Pro.Common.Downloads;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using ProPresenter.DO;
using ProPresenter.DO.Downloads;

namespace ProPresenter.UI.Web;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_webView" })]
public class WebBrowserView : FrameworkElement, IDisposable
{
	private const string BrowserRootPath = "browser";

	private const string UserBrowserScheme = "umb";

	private const string UserBrowserLinkFormat = "https://{0}{1}";

	private const string ExternalSchema = "external://";

	private const string HTTPSchema = "https://";

	private WebView2? _webView;

	private Uri? _uri;

	private readonly IDownloadManager _downloadManager;

	private readonly IDownloadItemFactory _downloadItemFactory;

	private bool _ignoreUrlChange;

	public static readonly DependencyProperty CurrentHeadersProperty = DependencyProperty.Register("CurrentHeaders", typeof(NameValueCollection), typeof(WebBrowserView));

	public static readonly DependencyProperty URLProperty = DependencyProperty.Register("Url", typeof(string), typeof(WebBrowserView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(URLPropertyChanged)));

	public static readonly DependencyProperty CachePathProperty = DependencyProperty.Register("CachePath", typeof(string), typeof(WebBrowserView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(CachePathPropertyChanged)));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected override int VisualChildrenCount => 1;

	public string? Url
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(URLProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(URLProperty, (object)value);
		}
	}

	public string? CachePath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CachePathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CachePathProperty, (object)value);
		}
	}

	public NameValueCollection? CurrentHeaders
	{
		get
		{
			return (NameValueCollection)((DependencyObject)this).GetValue(CurrentHeadersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentHeadersProperty, (object)value);
		}
	}

	public ICommand GoBackCommand => new RelayCommand(delegate
	{
		_webView.GoBack();
	}, () => _webView?.CanGoBack ?? false);

	public ICommand GoForwardCommand => new RelayCommand(delegate
	{
		_webView.GoForward();
	}, () => _webView?.CanGoForward ?? false);

	public ICommand ReloadCommand => new RelayCommand(delegate
	{
		_webView.Reload();
	}, () => _webView != null);

	public event Action? CloseWebView;

	private static void URLPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		WebBrowserView webBrowserView = (WebBrowserView)(object)callerObject;
		WebView2 webView = webBrowserView._webView;
		string uriString = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (!webBrowserView._ignoreUrlChange && Uri.TryCreate(uriString, UriKind.Absolute, out Uri result))
		{
			if (webView?.CoreWebView2 != null)
			{
				webView.Source = result;
				webBrowserView._uri = null;
			}
			else
			{
				webBrowserView._uri = result;
			}
		}
	}

	private static void CachePathPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((WebBrowserView)(object)callerObject).SetUserDataFolder();
	}

	public WebBrowserView()
	{
		_downloadManager = UIServiceProvider.GetService<IDownloadManager>();
		_downloadItemFactory = UIServiceProvider.GetService<IDownloadItemFactory>();
		SetupWebView();
		if (Application.Current?.MainWindow != null)
		{
			Application.Current.MainWindow.Closing += MainWindow_Closing;
		}
	}

	private void MainWindow_Closing(object? sender, CancelEventArgs e)
	{
		Dispose();
	}

	private void SetupWebView()
	{
		_webView = new WebView2
		{
			HorizontalAlignment = HorizontalAlignment.Stretch,
			VerticalAlignment = VerticalAlignment.Stretch
		};
		string userDataFolder = (string.IsNullOrEmpty(CachePath) ? CommonPaths.WebCache : CachePath);
		_webView.CreationProperties = new CoreWebView2CreationProperties
		{
			UserDataFolder = userDataFolder
		};
		_webView.NavigationStarting += WebView_NavigationStarting;
		_webView.NavigationCompleted += WebView_NavigationCompleted;
		_webView.CoreWebView2InitializationCompleted += WebBrowser_CoreWebView2InitializationCompleted;
		_webView.Loaded += WebView_Loaded;
		AddVisualChild(_webView);
	}

	private void TeardownWebView()
	{
		if (_webView != null)
		{
			_webView.NavigationStarting -= WebView_NavigationStarting;
			_webView.NavigationCompleted -= WebView_NavigationCompleted;
			_webView.CoreWebView2InitializationCompleted -= WebBrowser_CoreWebView2InitializationCompleted;
			_webView.Loaded -= WebView_Loaded;
			if (_webView.CoreWebView2 != null)
			{
				_webView.CoreWebView2.WebResourceResponseReceived -= CoreWebView2_WebResourceResponseReceived;
				_webView.CoreWebView2.DownloadStarting -= CoreWebView2_DownloadStarting;
				_webView.CoreWebView2.NewWindowRequested -= CoreWebView2_NewWindowRequested;
			}
			RemoveVisualChild(_webView);
			_webView.Dispose();
		}
	}

	private void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
	{
		string uri = e.Uri;
		if (uri.StartsWith("external://"))
		{
			e.Cancel = true;
			ProcessHelper.StartProcess(uri.Replace("external://", "https://"));
		}
		else
		{
			_ignoreUrlChange = true;
			Url = e.Uri;
			_ignoreUrlChange = false;
		}
	}

	private void WebBrowser_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
	{
		if (_webView?.CoreWebView2 != null)
		{
			_webView.CoreWebView2.WebResourceResponseReceived += CoreWebView2_WebResourceResponseReceived;
			_webView.CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
			_webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
		}
	}

	private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
	{
		Uri uri = new Uri(e.Uri);
		if (uri.Scheme == "umb")
		{
			e.Handled = true;
			ProcessHelper.StartProcess($"https://{uri.Host}{uri.PathAndQuery}");
			this.CloseWebView?.Invoke();
		}
	}

	private void CoreWebView2_DownloadStarting(object? sender, CoreWebView2DownloadStartingEventArgs e)
	{
		if (!e.Handled || !e.Cancel)
		{
			e.Handled = true;
			e.Cancel = true;
			string text = Path.Combine(CommonPaths.Downloads, "browser");
			Directory.CreateDirectory(text);
			string fileName = Path.GetFileName(e.ResultFilePath);
			string downloadPathAndFile = Path.Combine(text, fileName);
			_downloadManager.GetOrAdd((IDownloadItem item) => item.UrlDownloadItemMatchesActiveDownload(e.DownloadOperation.Uri), () => _downloadItemFactory.Create(e.DownloadOperation.Uri, downloadPathAndFile, fileName)).SubscribeCompletion(delegate
			{
				FileHelper.CopyAll(downloadPathAndFile, Path.Combine(CommonPaths.Downloads, "browser", fileName), overwrite: true);
			});
		}
	}

	private void CoreWebView2_WebResourceResponseReceived(object? sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
	{
		if (!(sender is CoreWebView2 { Source: var source }))
		{
			return;
		}
		NameValueCollection nameValueCollection = new NameValueCollection();
		foreach (KeyValuePair<string, string> header in e.Response.Headers)
		{
			nameValueCollection.Add(header.Key, header.Value);
		}
		string? url = Url;
		if (url != null && url.StartsWith(source))
		{
			((DependencyObject)this).SetCurrentValue(CurrentHeadersProperty, (object)nameValueCollection);
		}
	}

	private void WebView_Loaded(object? sender, RoutedEventArgs e)
	{
		WebView_LoadedAsync(sender, e).ExecuteAsync();
	}

	private async Task WebView_LoadedAsync(object? sender, RoutedEventArgs e)
	{
		if (_webView != null)
		{
			await _webView.EnsureCoreWebView2Async();
			if (_uri != null)
			{
				_webView.Source = _uri;
				_uri = null;
			}
		}
	}

	private void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		if (!(sender is WebView2 webView))
		{
			return;
		}
		if (e.IsSuccess)
		{
			Uri uri = new Uri(webView.Source.ToString());
			if (uri.Scheme == "umb")
			{
				ProcessHelper.StartProcess($"https://{uri.Host}{uri.PathAndQuery}");
				this.CloseWebView?.Invoke();
			}
		}
		else if (e.WebErrorStatus != CoreWebView2WebErrorStatus.ConnectionAborted)
		{
			Log.Error($"Failed to load URL {_webView?.Source.ToString()} with error {e.WebErrorStatus} ({e.HttpStatusCode}).");
		}
	}

	private void SetUserDataFolder()
	{
		TeardownWebView();
		SetupWebView();
	}

	protected override Visual? GetVisualChild(int index)
	{
		return _webView;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		_webView?.Measure(availableSize);
		return availableSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		_webView?.Arrange(new Rect<double>(Vector2<double>.Zero, (Vector2<double>)finalSize));
		return finalSize;
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
			OnDispose();
			_webView?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		if (Application.Current?.MainWindow != null)
		{
			Application.Current.MainWindow.Closing -= MainWindow_Closing;
		}
	}
}
