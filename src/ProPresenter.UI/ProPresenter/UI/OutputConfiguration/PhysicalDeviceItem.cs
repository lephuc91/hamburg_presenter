using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class PhysicalDeviceItem : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TargetScreenProperty = DependencyProperty.Register("TargetScreen", typeof(PhysicalDevice), typeof(PhysicalDeviceItem));

	public static readonly DependencyProperty IdentifyScreenCommandProperty = DependencyProperty.Register("IdentifyScreenCommand", typeof(ICommand<PhysicalDevice>), typeof(PhysicalDeviceItem));

	public PhysicalDevice? TargetScreen
	{
		get
		{
			return (PhysicalDevice)((DependencyObject)this).GetValue(TargetScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetScreenProperty, (object)value);
		}
	}

	public ICommand<PhysicalDevice>? IdentifyScreenCommand
	{
		get
		{
			return (ICommand<PhysicalDevice>)((DependencyObject)this).GetValue(IdentifyScreenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IdentifyScreenCommandProperty, (object)value);
		}
	}

	public PhysicalDeviceItem()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
