using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Background;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.Rendering.Web;

namespace ProPresenter.UI.Web;

public sealed class WebFillBrowser : IWebFillBrowser, IDisposable
{
	private enum RenderState
	{
		Idle,
		Navigating,
		Rendering
	}

	private readonly WebView2 _webView;

	private readonly Action<WebView2> _releaseCallback;

	private readonly Dispatcher _dispatcher;

	private BitmapSource? _cachedBitmap;

	private CancellationTokenSource? _currentRenderCancellation;

	private RenderState _renderState;

	private string? _script;

	private IEnumerable<Cookie>? _cookies;

	public bool IsDisposed { get; private set; }

	public WebFillBrowser(WebView2 webView, Action<WebView2> releaseCallback)
	{
		_dispatcher = Dispatcher.CurrentDispatcher;
		_webView = webView;
		_releaseCallback = releaseCallback;
		_webView.NavigationCompleted += WebView_NavigationCompleted;
	}

	private void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		RenderNextBitmap();
	}

	public void Dispose()
	{
		if (!IsDisposed)
		{
			IsDisposed = true;
			_releaseCallback?.Invoke(_webView);
			_cachedBitmap = null;
			_currentRenderCancellation?.Dispose();
			_webView.NavigationCompleted -= WebView_NavigationCompleted;
		}
	}

	private async Task RenderAsBitmapAsync(CancellationToken token)
	{
		await ExecuteWebViewInUIThreadAsync(async delegate
		{
			if (!string.IsNullOrEmpty(_script) && _renderState != RenderState.Navigating)
			{
				await _webView.CoreWebView2.ExecuteScriptAsync(_script);
				_script = string.Empty;
			}
			using (MemoryStream stream = new MemoryStream())
			{
				await _webView.CoreWebView2.CapturePreviewAsync(CoreWebView2CapturePreviewImageFormat.Png, stream);
				if (IsDisposed)
				{
					_cachedBitmap = null;
				}
				else
				{
					BitmapSource cachedBitmap = stream.ToArray().ToBitmapSource();
					if (!token.IsCancellationRequested)
					{
						_cachedBitmap = cachedBitmap;
					}
				}
			}
			_renderState = RenderState.Idle;
		});
	}

	public BitmapSource? GetCurrentBitmap()
	{
		if (_renderState == RenderState.Idle)
		{
			RenderNextBitmap();
		}
		if (IsDisposed)
		{
			_cachedBitmap = null;
		}
		return _cachedBitmap;
	}

	public string GetUrl()
	{
		return ExecuteWebViewInUIThread(() => _webView.CoreWebView2?.Source ?? string.Empty) ?? string.Empty;
	}

	public async Task GotoUrlAsync(string url, IEnumerable<Cookie>? cookies = null, string? script = null)
	{
		_currentRenderCancellation?.Cancel();
		_cachedBitmap = null;
		if (cookies != null)
		{
			_cookies = cookies;
		}
		_renderState = RenderState.Navigating;
		await ExecuteWebViewInUIThreadAsync(delegate
		{
			if (_webView.CoreWebView2 != null && !string.IsNullOrEmpty(url))
			{
				if (_cookies != null)
				{
					_webView.CoreWebView2?.CookieManager.DeleteAllCookies();
					foreach (Cookie cookie in _cookies)
					{
						CoreWebView2Cookie coreWebView2Cookie = _webView.CoreWebView2?.CookieManager.CreateCookie(cookie.Name, cookie.Value, cookie.Domain, null);
						if (coreWebView2Cookie != null)
						{
							coreWebView2Cookie.Expires = cookie.Expiration;
							_webView.CoreWebView2.CookieManager.AddOrUpdateCookie(coreWebView2Cookie);
						}
					}
					_script = script;
					_webView.CoreWebView2?.Navigate(url);
					_cookies = null;
				}
				else if (_webView.CoreWebView2?.Source != url)
				{
					_script = script;
					_webView.CoreWebView2.Navigate(url);
				}
				else
				{
					RenderNextBitmap();
				}
			}
		});
	}

	public void SetSize(Vector2<double> size)
	{
		_webView.Width = size.X;
		_webView.Height = size.Y;
	}

	private async Task ExecuteWebViewInUIThreadAsync(Func<Task> action)
	{
		if (CanExecuteInDispatcher() && !IsDisposed)
		{
			await (await _dispatcher.InvokeAsync<Task>(action));
		}
	}

	private async Task ExecuteWebViewInUIThreadAsync(Action action)
	{
		if (CanExecuteInDispatcher() && !IsDisposed)
		{
			await _dispatcher.InvokeAsync(action);
		}
	}

	private T? ExecuteWebViewInUIThread<T>(Func<T> action)
	{
		if (!CanExecuteInDispatcher() || IsDisposed)
		{
			return default(T);
		}
		return _dispatcher.Invoke<T>(action);
	}

	private bool CanExecuteInDispatcher()
	{
		if (!_dispatcher.HasShutdownStarted)
		{
			return !_dispatcher.HasShutdownFinished;
		}
		return false;
	}

	private void RenderNextBitmap()
	{
		_renderState = RenderState.Rendering;
		_currentRenderCancellation?.Cancel();
		_currentRenderCancellation?.Dispose();
		_currentRenderCancellation = new CancellationTokenSource();
		RenderAsBitmapAsync(_currentRenderCancellation.Token).ExecuteAsync();
	}
}
