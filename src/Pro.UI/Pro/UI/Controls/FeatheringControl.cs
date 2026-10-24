using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class FeatheringControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty LowerValueLabelProperty = DependencyProperty.Register("LowerValueLabel", typeof(string), typeof(FeatheringControl));

	public static readonly DependencyProperty HigherValueLabelProperty = DependencyProperty.Register("HigherValueLabel", typeof(string), typeof(FeatheringControl));

	public static readonly DependencyProperty LowerValueProperty = RangeSlider.LowerValueProperty.AddOwner(typeof(FeatheringControl));

	public static readonly DependencyProperty HigherValueProperty = RangeSlider.HigherValueProperty.AddOwner(typeof(FeatheringControl));

	public static readonly DependencyProperty MinimumProperty = RangeSlider.MinimumProperty.AddOwner(typeof(FeatheringControl));

	public static readonly DependencyProperty MaximumProperty = RangeSlider.MaximumProperty.AddOwner(typeof(FeatheringControl));

	public static readonly DependencyProperty ValueLinkedProperty = DependencyProperty.Register("ValueLinked", typeof(bool), typeof(FeatheringControl));

	public double LowerValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LowerValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerValueProperty, (object)value);
		}
	}

	public string LowerValueLabel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LowerValueLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerValueLabelProperty, (object)value);
		}
	}

	public double HigherValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HigherValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherValueProperty, (object)value);
		}
	}

	public string HigherValueLabel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HigherValueLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherValueLabelProperty, (object)value);
		}
	}

	public double Minimum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public double Maximum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public bool ValueLinked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ValueLinkedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueLinkedProperty, (object)value);
		}
	}

	public FeatheringControl()
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
