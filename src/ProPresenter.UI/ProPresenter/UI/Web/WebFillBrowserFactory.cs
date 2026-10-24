using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO;
using ProPresenter.Rendering.Web;

namespace ProPresenter.UI.Web;

public class WebFillBrowserFactory : IWebFillBrowserFactory
{
	[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_webView" })]
	private sealed class WebViewInitializer : IDisposable
	{
		private readonly WebView2 _webView;

		private readonly TaskCompletionSource<WebView2> _initializationCompleteFuture = new TaskCompletionSource<WebView2>();

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private bool _disposed;

		public WebViewInitializer(Grid browserContainer)
		{
			_webView = new WebView2
			{
				CreationProperties = new CoreWebView2CreationProperties
				{
					UserDataFolder = Path.Combine(CommonPaths.WebCache, Guid.NewGuid().ToString())
				}
			};
			_webView.Loaded += WebView_Loaded;
			_webView.CoreWebView2InitializationCompleted += CoreWebView2_InitializationCompleted;
			browserContainer.Children.Add(_webView);
		}

		private void WebView_Loaded(object? sender, RoutedEventArgs e)
		{
			_webView.Loaded -= WebView_Loaded;
			_webView.EnsureCoreWebView2Async();
		}

		private void CoreWebView2_InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
		{
			_webView.CoreWebView2InitializationCompleted -= CoreWebView2_InitializationCompleted;
			_initializationCompleteFuture.SetResult(_webView);
			_webView.CoreWebView2.MemoryUsageTargetLevel = CoreWebView2MemoryUsageTargetLevel.Low;
		}

		public TaskAwaiter<WebView2> GetAwaiter()
		{
			return _initializationCompleteFuture.Task.GetAwaiter();
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				_disposed = true;
				_webView.Dispose();
			}
		}
	}

	private readonly IUiDispatcher _dispatcher;

	private readonly TaskCompletionSource<Window> _hiddenWindowPromise = new TaskCompletionSource<Window>();

	private readonly ConcurrentStack<WebView2> _cachedWebViews = new ConcurrentStack<WebView2>();

	public WebFillBrowserFactory(IUiDispatcher uiDispatcher)
	{
		_dispatcher = uiDispatcher;
	}

	public void InitializeWindow(Window owner)
	{
		_hiddenWindowPromise.SetResult(CreateAndShowHiddenWindow(owner));
	}

	private Window CreateAndShowHiddenWindow(Window owner)
	{
		return _dispatcher.Invoke(delegate
		{
			Window obj = new Window
			{
				Width = 0.0,
				Height = 0.0,
				WindowStyle = WindowStyle.None,
				ShowInTaskbar = false,
				ShowActivated = false,
				ResizeMode = ResizeMode.NoResize,
				Background = System.Windows.Media.Brushes.Transparent,
				Opacity = 0.0,
				Title = "HIDDEN_WINDOW",
				Top = 0.0,
				Left = 0.0,
				Owner = owner
			};
			owner.Closing += DummyWindowOwner_Closing;
			Grid content = new Grid();
			obj.Content = content;
			obj.Show();
			return obj;
		});
	}

	private void DummyWindowOwner_Closing(object? sender, CancelEventArgs e)
	{
		Window result = _hiddenWindowPromise.Task.Result;
		try
		{
			if (sender is Window window)
			{
				window.Closing -= DummyWindowOwner_Closing;
			}
			result.Close();
		}
		catch (Exception value)
		{
			Log.Error($"Failed to dispose WebView2 browsers with error - {value}");
		}
	}

	public async Task<IWebFillBrowser?> CreateBrowserAsync(Vector2<double> windowSize)
	{
		Window window = await _hiddenWindowPromise.Task;
		Task<IWebFillBrowser> task = _dispatcher.Invoke(async () => (window.Content is Grid browserContainer) ? (await InitializeNewWebFillRenderer(windowSize, browserContainer)) : null);
		if (task != null)
		{
			return await task;
		}
		return null;
	}

	private async Task<IWebFillBrowser?> InitializeNewWebFillRenderer(Vector2<double> windowSize, Grid browserContainer)
	{
		Task<WebFillBrowser> task = _dispatcher.Invoke(async delegate
		{
			WebView2 result;
			WebView2 webView = ((!_cachedWebViews.TryPop(out result)) ? (await new WebViewInitializer(browserContainer)) : result);
			webView.DefaultBackgroundColor = System.Drawing.Color.Transparent;
			WebFillBrowser webFillBrowser = new WebFillBrowser(webView, ReleaseBrowser);
			webFillBrowser.SetSize(windowSize);
			return webFillBrowser;
		});
		if (task != null)
		{
			return await task;
		}
		return null;
	}

	private void ReleaseBrowser(WebView2 webView)
	{
		_cachedWebViews.Push(webView);
	}
}
