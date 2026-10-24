using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Controls;

internal class Mask : FrameworkElement
{
	private static readonly SolidColorBrush DefaultFillBrush = new SolidColorBrush(Color.FromArgb(200, 119, 136, 153));

	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(Vector2<double>), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(Vector2<double>), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty RotationProperty = DependencyProperty.Register("Rotation", typeof(Angle<double>), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Angle<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty MultiplierProperty = DependencyProperty.Register("Multiplier", typeof(double), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty FillBrushProperty = DependencyProperty.Register("FillBrush", typeof(Brush), typeof(Mask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DefaultFillBrush, FrameworkPropertyMetadataOptions.AffectsRender));

	public Vector2<double> Origin
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(OriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginProperty, (object)value);
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

	public Vector2<double> Size
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(SizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SizeProperty, (object)value);
		}
	}

	public Angle<double> Rotation
	{
		get
		{
			return (Angle<double>)((DependencyObject)this).GetValue(RotationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RotationProperty, (object)value);
		}
	}

	public double Multiplier
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MultiplierProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MultiplierProperty, (object)value);
		}
	}

	public Brush FillBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(FillBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillBrushProperty, (object)value);
		}
	}

	public Mask()
	{
		base.IsHitTestVisible = false;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		return (Size + Size * Multiplier * 2.0) * ZoomFactor;
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> position = Origin - (Vector2<double>)TranslatePoint(Vector2<double>.Zero, base.Parent as UIElement);
		Rect<double> rect = new Rect<double>((Vector2<double>)base.RenderSize);
		Rect<double> rect2 = new Rect<double>(position, Size * ZoomFactor);
		RectangleGeometry geometry = new RectangleGeometry(rect2)
		{
			Transform = new RotateTransform(Rotation.InvertedCartesianValue, rect2.Center.X, rect2.Center.Y)
		};
		dc.PushClip(new CombinedGeometry(GeometryCombineMode.Exclude, new RectangleGeometry(rect), geometry));
		dc.DrawRectangle(FillBrush, null, rect);
	}
}
