using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.Controller.Outputs.Communication;

namespace ProPresenter.UI.ActionPalette;

public partial class ActionPaletteView : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty DevicesProperty = DependencyProperty.Register("Devices", typeof(DeviceCollection), typeof(ActionPaletteView));

	public DeviceCollection? Devices
	{
		get
		{
			return (DeviceCollection)((DependencyObject)this).GetValue(DevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DevicesProperty, (object)value);
		}
	}

	public ActionPaletteView()
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
