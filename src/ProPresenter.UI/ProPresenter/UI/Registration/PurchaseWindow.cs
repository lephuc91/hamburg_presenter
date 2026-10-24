using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Web;

namespace ProPresenter.UI.Registration;

public partial class PurchaseWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty InAppLinkProperty = DependencyProperty.Register("InAppLink", typeof(string), typeof(PurchaseWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnInAppLinkChanged)));

	public static readonly DependencyProperty StoreTypeProperty = DependencyProperty.Register("StoreType", typeof(InAppStoreType), typeof(PurchaseWindow));

	public string? InAppLink
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(InAppLinkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InAppLinkProperty, (object)value);
		}
	}

	public InAppStoreType StoreType
	{
		get
		{
			return (InAppStoreType)((DependencyObject)this).GetValue(StoreTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StoreTypeProperty, (object)value);
		}
	}

	private static void OnInAppLinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PurchaseWindow)(object)d).InAppLinkChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as string);
	}

	public PurchaseWindow()
	{
		InitializeComponent();
		webBrowser.CloseWebView += base.Close;
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		webBrowser.Dispose();
	}

	private void InAppLinkChanged(string? newValue)
	{
		webBrowser.Url = newValue ?? string.Empty;
	}

	private void Button_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
