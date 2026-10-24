using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;

namespace Pro.UI.Controls;

public class ImageMask : FrameworkElement
{
	public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageMask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(ImageMask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(ImageMask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(ImageMask), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public ImageSource? ImageSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(ImageSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageSourceProperty, (object)value);
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

	public ImageMask()
	{
		((DependencyObject)this).SetCurrentValue(RenderOptions.BitmapScalingModeProperty, (object)BitmapScalingMode.HighQuality);
		((DependencyObject)this).SetCurrentValue(FrameworkElement.HorizontalAlignmentProperty, (object)HorizontalAlignment.Center);
		((DependencyObject)this).SetCurrentValue(FrameworkElement.VerticalAlignmentProperty, (object)VerticalAlignment.Center);
		((DependencyObject)this).SetCurrentValue(FrameworkElement.UseLayoutRoundingProperty, (object)true);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		if (ImageSource == null)
		{
			return base.MeasureOverride(availableSize);
		}
		Vector2<double> originalSize = new Vector2<double>(ImageSource.Width, ImageSource.Height);
		Vector2<double> targetSize = new Vector2<double>(((Size)(ref availableSize)).Width.IsReal() ? ((Size)(ref availableSize)).Width : originalSize.X, ((Size)(ref availableSize)).Height.IsReal() ? ((Size)(ref availableSize)).Height : originalSize.Y);
		return originalSize.ScaleToFitSize(targetSize);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (ImageSource != null)
		{
			drawingContext.PushOpacityMask(new ImageBrush(ImageSource)
			{
				Stretch = Stretch.Uniform
			});
			drawingContext.DrawRectangle(Fill, new Pen(Stroke, StrokeThickness), new Rect<double>((Vector2<double>)base.RenderSize));
		}
	}
}
