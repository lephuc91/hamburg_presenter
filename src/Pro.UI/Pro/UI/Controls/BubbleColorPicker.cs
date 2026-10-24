using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

[ContentProperty("DefaultColors")]
public partial class BubbleColorPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DefaultColorsProperty;

	public static readonly DependencyProperty SelectedColorProperty;

	public static readonly DependencyProperty AllowAlphaProperty;

	public static readonly DependencyProperty BubbleWidthProperty;

	public static readonly DependencyProperty BubbleHeightProperty;

	public static readonly DependencyProperty ShowMoreColorsProperty;

	public static readonly DependencyProperty IsCustomColorProperty;

	public IList DefaultColors
	{
		get
		{
			return (IList)((DependencyObject)this).GetValue(DefaultColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultColorsProperty, (object)value);
		}
	}

	public Color? SelectedColor
	{
		get
		{
			return (Color?)((DependencyObject)this).GetValue(SelectedColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedColorProperty, (object)value);
		}
	}

	public bool AllowAlpha
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowAlphaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowAlphaProperty, (object)value);
		}
	}

	public double BubbleWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BubbleWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BubbleWidthProperty, (object)value);
		}
	}

	public double BubbleHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BubbleHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BubbleHeightProperty, (object)value);
		}
	}

	public bool ShowMoreColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMoreColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMoreColorsProperty, (object)value);
		}
	}

	private bool IsCustomColor
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCustomColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCustomColorProperty, (object)value);
		}
	}

	public BubbleColorPicker()
	{
		InitializeComponent();
	}

	private void DefaultColor_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is BorderlessButton { DataContext: var dataContext } && dataContext is Color color)
		{
			((DependencyObject)this).SetCurrentValue(SelectedColorProperty, (object)color);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	static BubbleColorPicker()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_009d: Expected O, but got Unknown
		Type? typeFromHandle = typeof(IList);
		Type? typeFromHandle2 = typeof(BubbleColorPicker);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata((object)new List<Color>
		{
			Colors.Red,
			Colors.Green,
			Colors.Blue
		});
		((PropertyMetadata)frameworkPropertyMetadata).CoerceValueCallback = (CoerceValueCallback)((DependencyObject d, object e) => (e is IEnumerable<Color>) ? e : Array.Empty<Color>());
		DefaultColorsProperty = DependencyProperty.Register("DefaultColors", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color?), typeof(BubbleColorPicker), new PropertyMetadata
		{
			PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				if (d is BubbleColorPicker bubbleColorPicker)
				{
					bool flag = !bubbleColorPicker.DefaultColors.Contains((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
					((DependencyObject)bubbleColorPicker).SetCurrentValue(IsCustomColorProperty, (object)flag);
				}
			}
		});
		AllowAlphaProperty = DependencyProperty.Register("AllowAlpha", typeof(bool), typeof(BubbleColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		BubbleWidthProperty = DependencyProperty.Register("BubbleWidth", typeof(double), typeof(BubbleColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)16.0));
		BubbleHeightProperty = DependencyProperty.Register("BubbleHeight", typeof(double), typeof(BubbleColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)16.0));
		ShowMoreColorsProperty = DependencyProperty.Register("ShowMoreColors", typeof(bool), typeof(BubbleColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsCustomColorProperty = DependencyProperty.Register("IsCustomColor", typeof(bool), typeof(BubbleColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}
}
