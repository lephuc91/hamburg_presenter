using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class Pill : FrameworkElement
{
	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(Pill), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(Pill), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(Pill), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(double), typeof(Pill), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

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

	public double CornerRadius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CornerRadiusProperty, (object)value);
		}
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		RectangleGeometry rectangleGeometry = new RectangleGeometry
		{
			RadiusX = CornerRadius,
			RadiusY = CornerRadius,
			Rect = (Rect<double>)base.RenderSize
		};
		drawingContext.PushClip(rectangleGeometry);
		drawingContext.DrawGeometry(Fill, new Pen(Stroke, StrokeThickness * 2.0), rectangleGeometry);
		drawingContext.Pop();
	}
}
