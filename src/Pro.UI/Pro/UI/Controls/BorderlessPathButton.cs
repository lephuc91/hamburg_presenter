using System.Windows;
using System.Windows.Data;
using Pro.UI.Themes;

namespace Pro.UI.Controls;

public class BorderlessPathButton : BorderlessButton
{
	public static readonly DependencyProperty PathTypeProperty = DependencyProperty.Register("PathType", typeof(PathType), typeof(BorderlessPathButton));

	public static readonly DependencyProperty PathWidthProperty = DependencyProperty.Register("PathWidth", typeof(double), typeof(BorderlessPathButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPathWidthPropertyChanged)));

	public static readonly DependencyProperty PathHeightProperty = DependencyProperty.Register("PathHeight", typeof(double), typeof(BorderlessPathButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPathHeightPropertyChanged)));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(BorderlessPathButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)2.0));

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

	public double PathWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PathWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PathWidthProperty, (object)value);
		}
	}

	public double PathHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PathHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PathHeightProperty, (object)value);
		}
	}

	private PathControl? Path => base.Content as PathControl;

	private static void OnPathWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PathControl? path = ((BorderlessPathButton)(object)d).Path;
		if (path != null)
		{
			((DependencyObject)path).SetCurrentValue(FrameworkElement.WidthProperty, (object)(double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnPathHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PathControl? path = ((BorderlessPathButton)(object)d).Path;
		if (path != null)
		{
			((DependencyObject)path).SetCurrentValue(FrameworkElement.HeightProperty, (object)(double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	public BorderlessPathButton()
	{
		base.Content = new PathControl();
		Bind(PathControl.PathTypeProperty, "PathType");
		Bind(PathControl.FillProperty, "Foreground");
		Bind(PathControl.StrokeProperty, "Foreground");
		Bind(PathControl.StrokeThicknessProperty, "StrokeThickness");
		PathControl? path = Path;
		if (path != null)
		{
			((DependencyObject)path).SetCurrentValue(FrameworkElement.WidthProperty, (object)(double)Application.Current.TryFindResource(Constants.BorderlessPathButtonPathDefaultSize));
		}
		PathControl? path2 = Path;
		if (path2 != null)
		{
			((DependencyObject)path2).SetCurrentValue(FrameworkElement.HeightProperty, (object)(double)Application.Current.TryFindResource(Constants.BorderlessPathButtonPathDefaultSize));
		}
	}

	private void Bind(DependencyProperty target, string property)
	{
		Path?.SetBinding(target, new Binding(property)
		{
			Source = this
		});
	}
}
