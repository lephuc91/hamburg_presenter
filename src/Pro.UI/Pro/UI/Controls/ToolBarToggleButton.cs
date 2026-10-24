using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class ToolBarToggleButton : ToggleButton
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

	public static readonly DependencyProperty ShowNotificationBadgeProperty;

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

	public bool ShowNotificationBadge
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowNotificationBadgeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowNotificationBadgeProperty, (object)value);
		}
	}

	static ToolBarToggleButton()
	{
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure));
		ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure));
		IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ToolBarToggleButton));
		IconSizeProperty = DependencyProperty.Register("IconSize", typeof(IconSize), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IconSize.MediumSmall));
		LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(ToolBarToggleButton));
		MaxButtonHeightProperty = DependencyProperty.Register("MaxButtonHeight", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MaxButtonWidthProperty = DependencyProperty.Register("MaxButtonWidth", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MinButtonHeightProperty = DependencyProperty.Register("MinButtonHeight", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		MinButtonWidthProperty = DependencyProperty.Register("MinButtonWidth", typeof(double), typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		ShowNotificationBadgeProperty = DependencyProperty.Register("ShowNotificationBadge", typeof(bool), typeof(ToolBarToggleButton), new PropertyMetadata((object)false));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ToolBarToggleButton)));
	}
}
