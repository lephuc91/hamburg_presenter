using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using Pro.Common.Win32;

namespace ProPresenter.UI;

public partial class SplashDialog : Window, IComponentConnector
{
	public static readonly DependencyProperty AppVersionProperty = DependencyProperty.Register("AppVersion", typeof(string), typeof(SplashDialog), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)"7.0"));

	public string AppVersion
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AppVersionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AppVersionProperty, (object)value);
		}
	}

	public SplashDialog()
	{
		InitializeComponent();
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		nint hWnd = new WindowInteropHelper(this).EnsureHandle();
		WindowsFunctions.SetWindowLong(hWnd, GWL.EXSTYLE, (nint)(uint)((int)WindowsFunctions.GetWindowLong(hWnd, GWL.EXSTYLE) | 0x80));
		base.OnSourceInitialized(e);
	}
}
