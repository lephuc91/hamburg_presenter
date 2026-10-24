using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Pro.Common.Background;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Updates;

public partial class UpdateViewer : ChromedWindow, IComponentConnector
{
	private static readonly string ReleaseNotesStyle;

	private string? _html;

	private int _navigationRequests;

	private static readonly DependencyProperty ReleaseNotesProperty;

	private string? ReleaseNotes
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ReleaseNotesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReleaseNotesProperty, (object)value);
		}
	}

	private static void OnReleaseNotesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((UpdateViewer)(object)d).UpdateReleaseNotes(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as string);
	}

	public UpdateViewer()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(UpdateViewer_DataContextChanged);
		base.Loaded += UpdateViewer_Loaded;
		if (Application.Current?.MainWindow != null)
		{
			Application.Current.MainWindow.Closing += MainWindow_Closing;
		}
	}

	private void UpdateViewer_Loaded(object? sender, RoutedEventArgs e)
	{
		UpdateViewer_LoadedAsync().ExecuteAsync();
	}

	private async Task UpdateViewer_LoadedAsync()
	{
		webView.CreationProperties = new CoreWebView2CreationProperties
		{
			UserDataFolder = CommonPaths.WebCache
		};
		await webView.EnsureCoreWebView2Async();
		webView.NavigationStarting += NavigationStarting;
		LoadReleaseNotes();
	}

	private void MainWindow_Closing(object? sender, CancelEventArgs e)
	{
		webView.NavigationStarting -= NavigationStarting;
		webView.Dispose();
	}

	private void UpdateReleaseNotes(string? releaseNotes)
	{
		if (!releaseNotes.NullableIsNullOrWhiteSpace())
		{
			_html = "<style>" + ReleaseNotesStyle + "</style>" + releaseNotes;
			LoadReleaseNotes();
		}
	}

	private void LoadReleaseNotes()
	{
		if (webView.CoreWebView2 != null && !_html.NullableIsNullOrEmpty())
		{
			_navigationRequests = 0;
			webView.CoreWebView2.NavigateToString(_html);
			_html = string.Empty;
		}
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
		if (hwndSource?.CompositionTarget != null)
		{
			hwndSource.CompositionTarget.RenderMode = RenderMode.SoftwareOnly;
		}
		base.OnSourceInitialized(e);
	}

	private void UpdateViewer_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		SetBinding(ReleaseNotesProperty, "ReleaseNotes");
	}

	private void CloseDialog_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}

	private void NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
	{
		if (_navigationRequests > 1)
		{
			e.Cancel = true;
			ProcessHelper.StartProcess(e.Uri);
		}
		_navigationRequests++;
	}

	private static string ToCSS(SolidColorBrush brush)
	{
		return ToCSS(brush.Color);
	}

	private static string ToCSS(Color color)
	{
		return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
	}

	static UpdateViewer()
	{
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = UpdateViewer.ToCSS(AppTheme.Active.OUTLINEDETAIL);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = UpdateViewer.ToCSS(AppTheme.Active.CONTENTPRIMARY);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = SystemFonts.MessageFontFamily;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = ToCSS(Colors.CornflowerBlue);
		ReleaseNotesStyle = string.Format("body {{\r\n    background-color: {0};\r\n    color: {1};\r\n    font-family: '{2}', sans-serif;\r\n    /* unvisited link */\r\n    a:link {{\r\n        color: {3};\r\n        text-decoration: none;\r\n    }}\r\n    /* mouse over link */\r\n    a:hover {{\r\n        text-decoration-line: underline;\r\n    }}\r\n}}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
		ReleaseNotesProperty = DependencyProperty.Register("ReleaseNotes", typeof(string), typeof(UpdateViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnReleaseNotesChanged)));
	}
}
