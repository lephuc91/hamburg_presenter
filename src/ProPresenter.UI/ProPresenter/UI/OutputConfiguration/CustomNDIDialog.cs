using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class CustomNDIDialog : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty DeviceModeFrameRateProperty = DependencyProperty.Register("DeviceModeFrameRate", typeof(double), typeof(CustomNDIDialog));

	public static readonly DependencyProperty DeviceModeHeightProperty = DependencyProperty.Register("DeviceModeHeight", typeof(int), typeof(CustomNDIDialog));

	public static readonly DependencyProperty DeviceModeWidthProperty = DependencyProperty.Register("DeviceModeWidth", typeof(int), typeof(CustomNDIDialog));

	public static readonly DependencyProperty IsInterlacedProperty = DependencyProperty.Register("IsInterlaced", typeof(bool), typeof(CustomNDIDialog));

	public double DeviceModeFrameRate
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DeviceModeFrameRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceModeFrameRateProperty, (object)value);
		}
	}

	public int DeviceModeHeight
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(DeviceModeHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceModeHeightProperty, (object)value);
		}
	}

	public int DeviceModeWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(DeviceModeWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceModeWidthProperty, (object)value);
		}
	}

	public bool IsInterlaced
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsInterlacedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsInterlacedProperty, (object)value);
		}
	}

	public CustomNDIDialog(IDeviceMode? mode)
	{
		InitializeComponent();
		DeviceModeWidth = mode?.Size.X ?? 1920;
		DeviceModeHeight = mode?.Size.Y ?? 1080;
		DeviceModeFrameRate = mode?.RefreshRate ?? 30.0;
		IsInterlaced = mode?.Interlaced ?? false;
	}

	private void OkButton_OnClick(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
