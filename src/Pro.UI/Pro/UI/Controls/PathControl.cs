using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

public partial class PathControl : ContentControl, IComponentConnector
{
	public static readonly DependencyProperty PathTypeProperty = DependencyProperty.Register("PathType", typeof(PathType), typeof(PathControl));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(PathControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black));

	public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(PathControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(PathControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0));

	public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(PathControl));

	public PathType PathType
	{
		get
		{
			return (PathType)((DependencyObject)this).GetValue(PathTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PathTypeProperty, (object)value);
		}
	}

	public Brush Fill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public Brush Stroke
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(StrokeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeProperty, (object)value);
		}
	}

	public double StrokeThickness
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StrokeThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeThicknessProperty, (object)value);
		}
	}

	public Geometry Data
	{
		get
		{
			return (Geometry)((DependencyObject)this).GetValue(DataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DataProperty, (object)value);
		}
	}

	public PathControl()
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
