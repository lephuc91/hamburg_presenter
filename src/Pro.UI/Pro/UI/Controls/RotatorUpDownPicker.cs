using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public partial class RotatorUpDownPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(Angle<double>), typeof(RotatorUpDownPicker));

	public static readonly DependencyProperty IsCartesianProperty = DependencyProperty.Register("IsCartesian", typeof(bool), typeof(RotatorUpDownPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public Angle<double> Angle
	{
		get
		{
			return (Angle<double>)((DependencyObject)this).GetValue(AngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AngleProperty, (object)value);
		}
	}

	public bool IsCartesian
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCartesianProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCartesianProperty, (object)value);
		}
	}

	public RotatorUpDownPicker()
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
