using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.UI.Controls;

public class FillMeter<T> : FrameworkElement where T : notnull
{
	private const double PeakMarkThickness = 2.0;

	private const double ClipMarkGap = 2.0;

	private const double ClipMarkThickness = 4.0;

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(T), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Constants<T>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(T), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Constants<T>.One, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(T), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(T), FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty PeakValueProperty = DependencyProperty.Register("PeakValue", typeof(T), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(T), FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ShowClipMarkProperty = DependencyProperty.Register("ShowClipMark", typeof(bool), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty MeterBackgroundProperty = DependencyProperty.Register("MeterBackground", typeof(Brush), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty MeterFillProperty = DependencyProperty.Register("MeterFill", typeof(Brush), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Blue, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ClipMarkFillProperty = DependencyProperty.Register("ClipMarkFill", typeof(Brush), typeof(FillMeter<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Green, FrameworkPropertyMetadataOptions.AffectsRender));

	public T Minimum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public T Maximum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public T Value
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public T PeakValue
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(PeakValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PeakValueProperty, (object)value);
		}
	}

	public bool ShowClipMark
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowClipMarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowClipMarkProperty, (object)value);
		}
	}

	public Brush MeterBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MeterBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MeterBackgroundProperty, (object)value);
		}
	}

	public Brush MeterFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MeterFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MeterFillProperty, (object)value);
		}
	}

	public Brush ClipMarkFill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ClipMarkFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipMarkFillProperty, (object)value);
		}
	}

	protected virtual double ScaleValue(T value)
	{
		return value.ToFeatureRange(Minimum, Maximum).Cast<double, T>();
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		double num = base.ActualWidth - 6.0;
		double num2 = ScaleValue(PeakValue).Clamp(0.0, 1.0);
		Rect<double> rect = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(num, base.ActualHeight));
		Rect<double> rect2 = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(num * ScaleValue(Value).Clamp(0.0, 1.0), base.ActualHeight));
		Rect<double> rect3 = new Rect<double>(new Vector2<double>(num * num2 - 2.0, 0.0), new Vector2<double>(2.0, base.ActualHeight));
		Rect<double> rect4 = new Rect<double>(new Vector2<double>(base.ActualWidth - 4.0, 0.0), new Vector2<double>(4.0, base.ActualHeight));
		dc.DrawRectangle(MeterBackground, null, rect);
		dc.PushClip(new RectangleGeometry(rect2));
		dc.DrawRectangle(MeterFill, null, rect);
		dc.Pop();
		dc.PushClip(new RectangleGeometry(rect3));
		dc.DrawRectangle(MeterFill, null, rect);
		dc.Pop();
		if (ShowClipMark)
		{
			dc.DrawRectangle(ClipMarkFill, null, rect4);
		}
	}
}
