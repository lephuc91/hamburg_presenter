using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class SelectionBox : FixedControl
{
	private static readonly Brush DefaultFill = new SolidColorBrush(Colors.AliceBlue)
	{
		Opacity = 0.25
	};

	private static readonly Pen DefaultStroke = new Pen(new SolidColorBrush(Colors.LightBlue)
	{
		Opacity = 0.5
	}, 0.5);

	public static DependencyProperty SelectionBoundsProperty = DependencyProperty.Register("SelectionBounds", typeof(Rect<double>), typeof(SelectionBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect<double>.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(Vector2<double>), typeof(SelectionBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(SelectionBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(SelectionBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DefaultFill, FrameworkPropertyMetadataOptions.AffectsRender));

	public static DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Pen), typeof(SelectionBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DefaultStroke, FrameworkPropertyMetadataOptions.AffectsRender));

	public Rect<double> SelectionBounds
	{
		get
		{
			return (Rect<double>)((DependencyObject)this).GetValue(SelectionBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectionBoundsProperty, (object)value);
		}
	}

	public Vector2<double> Offset
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(OffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OffsetProperty, (object)value);
		}
	}

	public double ZoomFactor
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomFactorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomFactorProperty, (object)value);
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

	public Pen Stroke
	{
		get
		{
			return (Pen)((DependencyObject)this).GetValue(StrokeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeProperty, (object)value);
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawRectangle(Fill, Stroke, new Rect<double>(SelectionBounds.Position * ZoomFactor + Offset, SelectionBounds.Size * ZoomFactor).Abs());
	}
}
