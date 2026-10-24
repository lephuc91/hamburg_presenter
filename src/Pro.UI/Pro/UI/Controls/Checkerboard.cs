using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class Checkerboard : FrameworkElement
{
	private DrawingVisual? _checkerboardVisual;

	public static readonly DependencyProperty ScaleFactorProperty = DependencyProperty.Register("ScaleFactor", typeof(double), typeof(Checkerboard), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty PrimaryBrushProperty = DependencyProperty.Register("PrimaryBrush", typeof(Brush), typeof(Checkerboard), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(InvalidateCheckerboardVisual)));

	public static readonly DependencyProperty SecondaryBrushProperty = DependencyProperty.Register("SecondaryBrush", typeof(Brush), typeof(Checkerboard), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Brushes.LightGray, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(InvalidateCheckerboardVisual)));

	public static readonly DependencyProperty SquareSizeProperty = DependencyProperty.Register("SquareSize", typeof(double), typeof(Checkerboard), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)10.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public double ScaleFactor
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScaleFactorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScaleFactorProperty, (object)value);
		}
	}

	public Brush PrimaryBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PrimaryBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrimaryBrushProperty, (object)value);
		}
	}

	public Brush SecondaryBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(SecondaryBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryBrushProperty, (object)value);
		}
	}

	public double SquareSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SquareSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SquareSizeProperty, (object)value);
		}
	}

	private static void InvalidateCheckerboardVisual(object callerObject, DependencyPropertyChangedEventArgs e)
	{
		((Checkerboard)callerObject)._checkerboardVisual = null;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		return new Vector2<double>((base.HorizontalAlignment == HorizontalAlignment.Stretch && ((Size)(ref availableSize)).Width.IsReal()) ? ((Size)(ref availableSize)).Width : (base.Width.IsReal() ? base.Width : 0.0), (base.VerticalAlignment == VerticalAlignment.Stretch && ((Size)(ref availableSize)).Height.IsReal()) ? ((Size)(ref availableSize)).Height : (base.Height.IsReal() ? base.Height : 0.0));
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (_checkerboardVisual == null)
		{
			_checkerboardVisual = new DrawingVisual();
			using DrawingContext drawingContext2 = _checkerboardVisual.RenderOpen();
			drawingContext2.DrawRectangle(PrimaryBrush, null, new Rect<double>(0.0, 0.0, 2.0, 2.0));
			drawingContext2.DrawRectangle(SecondaryBrush, null, new Rect<double>(1.0, 0.0, 1.0, 1.0));
			drawingContext2.DrawRectangle(SecondaryBrush, null, new Rect<double>(0.0, 1.0, 1.0, 1.0));
		}
		drawingContext.DrawRectangle(GetCheckerboardBrush(), null, new Rect<double>(new Vector2<double>(base.ActualWidth, base.ActualHeight)));
	}

	private Brush GetCheckerboardBrush()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		return new VisualBrush
		{
			Visual = _checkerboardVisual,
			TileMode = TileMode.Tile,
			Viewport = new Rect<double>(new Vector2<double>(SquareSize * 2.0 / ScaleFactor)),
			ViewportUnits = BrushMappingMode.Absolute
		};
	}
}
