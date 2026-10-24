using System.Windows;
using System.Windows.Controls;
using Pro.Common.Utility;

namespace Pro.UI.Controls;

public class Icon : Image
{
	public static readonly DependencyProperty IconSizeProperty;

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

	public Icon()
	{
		base.Loaded += delegate
		{
			OnIconSizePropertyChanged(IconSize, IconSize);
			InvalidateVisual();
		};
	}

	static Icon()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		IconSizeProperty = DependencyProperty.Register("IconSize", typeof(IconSize), typeof(Icon), new PropertyMetadata((object)IconSize.XSmall, new PropertyChangedCallback(OnIconSizePropertyChanged)));
		FrameworkElement.MarginProperty.OverrideMetadata(typeof(Icon), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Thickness(2.0)));
	}

	protected virtual void OnIconSizePropertyChanged(IconSize oldValue, IconSize newValue)
	{
		if (IconSize != 0)
		{
			IconSizeAttribute attribute = newValue.GetAttribute<IconSize, IconSizeAttribute>();
			base.Width = attribute?.Width ?? 0.0;
			base.Height = attribute?.Height ?? 0.0;
		}
	}

	private static void OnIconSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Icon)(object)d).OnIconSizePropertyChanged((IconSize)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IconSize)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}
}
