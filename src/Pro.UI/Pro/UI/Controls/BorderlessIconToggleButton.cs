using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class BorderlessIconToggleButton : BorderlessButton
{
	public static readonly DependencyProperty IconGeometryProperty;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty ActiveBrushProperty;

	public static readonly DependencyProperty InactiveBrushProperty;

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public Brush InactiveBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(InactiveBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InactiveBrushProperty, (object)value);
		}
	}

	public Brush ActiveBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveBrushProperty, (object)value);
		}
	}

	public Geometry IconGeometry
	{
		get
		{
			return (Geometry)((DependencyObject)this).GetValue(IconGeometryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconGeometryProperty, (object)value);
		}
	}

	static BorderlessIconToggleButton()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		IconGeometryProperty = DependencyProperty.Register("IconGeometry", typeof(Geometry), typeof(BorderlessIconToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(BorderlessIconToggleButton), new PropertyMetadata((object)false));
		ActiveBrushProperty = DependencyProperty.Register("ActiveBrush", typeof(Brush), typeof(BorderlessIconToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
		InactiveBrushProperty = DependencyProperty.Register("InactiveBrush", typeof(Brush), typeof(BorderlessIconToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderlessIconToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(BorderlessIconToggleButton)));
	}
}
