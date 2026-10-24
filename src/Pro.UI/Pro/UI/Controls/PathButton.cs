using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Pro.UI.Controls;

public class PathButton : Button
{
	public static readonly DependencyProperty PathTypeProperty = DependencyProperty.Register("PathType", typeof(PathType), typeof(PathButton));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(PathButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)2.0));

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

	public PathButton()
	{
		PathControl pathControl = new PathControl();
		pathControl.SetBinding(PathControl.PathTypeProperty, new Binding("PathType")
		{
			Source = this
		});
		pathControl.SetBinding(PathControl.FillProperty, new Binding("Foreground")
		{
			Source = this
		});
		pathControl.SetBinding(PathControl.StrokeProperty, new Binding("Foreground")
		{
			Source = this
		});
		pathControl.SetBinding(PathControl.StrokeThicknessProperty, new Binding("StrokeThickness")
		{
			Source = this
		});
		((DependencyObject)this).SetCurrentValue(FrameworkElement.WidthProperty, (object)18.0);
		((DependencyObject)this).SetCurrentValue(FrameworkElement.HeightProperty, (object)18.0);
		base.Content = pathControl;
	}
}
