using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class ToolBarButton : Button
{
	public static readonly DependencyProperty ButtonHeightProperty;

	public static readonly DependencyProperty ButtonWidthProperty;

	public static readonly DependencyProperty IconProperty;

	public static readonly DependencyProperty IconSizeProperty;

	public static readonly DependencyProperty LabelProperty;

	public static readonly DependencyProperty MaxButtonHeightProperty;

	public static readonly DependencyProperty MaxButtonWidthProperty;

	public static readonly DependencyProperty MinButtonHeightProperty;

	public static readonly DependencyProperty MinButtonWidthProperty;

	[TypeConverter(typeof(LengthConverter))]
	public double ButtonHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonHeightProperty, (object)value);
		}
	}

	[TypeConverter(typeof(LengthConverter))]
	public double ButtonWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonWidthProperty, (object)value);
		}
	}

	public ImageSource Icon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public IconSize IconSize
	{
		get
		{
			return (IconSize)((DependencyObject)this).GetValue(IconSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconSizeProperty, (object)value);
		}
	}

	public string Label
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelProperty, (object)value);
		}
	}

	public double MaxButtonHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxButtonHeightProperty, (object)value);
		}
	}

	public double MaxButtonWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxButtonWidthProperty, (object)value);
		}
	}

	public double MinButtonHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinButtonHeightProperty, (object)value);
		}
	}

	public double MinButtonWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinButtonWidthProperty, (object)value);
		}
	}

	static ToolBarButton()
	{
		ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure));
		ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure));
		IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ToolBarButton));
		IconSizeProperty = DependencyProperty.Register("IconSize", typeof(IconSize), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IconSize.MediumSmall));
		LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(ToolBarButton));
		MaxButtonHeightProperty = DependencyProperty.Register("MaxButtonHeight", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MaxButtonWidthProperty = DependencyProperty.Register("MaxButtonWidth", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MinButtonHeightProperty = DependencyProperty.Register("MinButtonHeight", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MinButtonWidthProperty = DependencyProperty.Register("MinButtonWidth", typeof(double), typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ToolBarButton)));
	}
}
