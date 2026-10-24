using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.Editor.Canvas.Controls;

internal partial class CanvasParent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CanvasBrushProperty = DependencyProperty.Register("CanvasBrush", typeof(Brush), typeof(CanvasParent), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DarkGray));

	public static readonly DependencyProperty RulerBackgroundProperty = DependencyProperty.Register("RulerBackground", typeof(Brush), typeof(CanvasParent));

	public static readonly DependencyProperty RulerBrushProperty = DependencyProperty.Register("RulerBrush", typeof(Brush), typeof(CanvasParent));

	public static readonly DependencyProperty MouseTrackerColorProperty = DependencyProperty.Register("MouseTrackerColor", typeof(Color), typeof(CanvasParent));

	public static readonly DependencyProperty ObjectBoundsColorProperty = DependencyProperty.Register("ObjectBoundsColor", typeof(Color), typeof(CanvasParent));

	public static readonly DependencyProperty PopoverBackgroundProperty = DependencyProperty.Register("PopoverBackground", typeof(Brush), typeof(CanvasParent));

	public static readonly DependencyProperty PopoverForegroundProperty = DependencyProperty.Register("PopoverForeground", typeof(Brush), typeof(CanvasParent));

	public static readonly DependencyProperty DeleteGuidelineLocaleStringProperty = DependencyProperty.Register("DeleteGuidelineLocaleString", typeof(string), typeof(CanvasParent));

	public static readonly DependencyProperty DeleteGuidelinesLocaleStringProperty = DependencyProperty.Register("DeleteGuidelinesLocaleString", typeof(string), typeof(CanvasParent));

	public Brush CanvasBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CanvasBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanvasBrushProperty, (object)value);
		}
	}

	public Brush RulerBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RulerBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerBackgroundProperty, (object)value);
		}
	}

	public Brush RulerBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RulerBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerBrushProperty, (object)value);
		}
	}

	public Color MouseTrackerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(MouseTrackerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseTrackerColorProperty, (object)value);
		}
	}

	public Color ObjectBoundsColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ObjectBoundsColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ObjectBoundsColorProperty, (object)value);
		}
	}

	public Brush PopoverBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PopoverBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopoverBackgroundProperty, (object)value);
		}
	}

	public Brush PopoverForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PopoverForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopoverForegroundProperty, (object)value);
		}
	}

	public string DeleteGuidelineLocaleString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DeleteGuidelineLocaleStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteGuidelineLocaleStringProperty, (object)value);
		}
	}

	public string DeleteGuidelinesLocaleString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DeleteGuidelinesLocaleStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteGuidelinesLocaleStringProperty, (object)value);
		}
	}

	public CanvasParent()
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
