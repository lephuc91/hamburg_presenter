using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls.Audio;

public partial class RouterMasterControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty MutedProperty = DependencyProperty.Register("Muted", typeof(bool), typeof(RouterMasterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SoloActiveProperty = DependencyProperty.Register("SoloActive", typeof(bool), typeof(RouterMasterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty ShowMuteAndSoloButtonsProperty = DependencyProperty.Register("ShowMuteAndSoloButtons", typeof(bool), typeof(RouterMasterControl));

	public static readonly DependencyProperty AutoOnlyProperty = DependencyProperty.Register("AutoOnly", typeof(bool), typeof(RouterMasterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public bool Muted
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(MutedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MutedProperty, (object)value);
		}
	}

	public bool SoloActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SoloActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SoloActiveProperty, (object)value);
		}
	}

	public bool ShowMuteAndSoloButtons
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMuteAndSoloButtonsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMuteAndSoloButtonsProperty, (object)value);
		}
	}

	public bool AutoOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoOnlyProperty, (object)value);
		}
	}

	public event Action? AutoMap;

	public event Action? ClearMap;

	public RouterMasterControl()
	{
		InitializeComponent();
	}

	private void AutoMapClicked(object? sender, RoutedEventArgs e)
	{
		this.AutoMap?.Invoke();
	}

	private void ClearMapClicked(object? sender, RoutedEventArgs e)
	{
		this.ClearMap?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
