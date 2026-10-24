using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Time;

namespace Pro.UI.Controls;

public class LoadingIndicator : FrameworkElement
{
	public enum IndicatorType
	{
		Bar,
		Spinner
	}

	private static readonly TimeSlice UpdateTime = TimeSlice.FromSeconds(1.0 / 60.0);

	private static readonly TimeSlice LoopTime = TimeSlice.FromSeconds(4.0);

	private const int DotCount = 7;

	private const double DotSpacing = 0.095;

	private const double BarDotScale = 0.25;

	private const double SpinnerDotScale = 0.1;

	private readonly Clock _clock = new Clock(autoStart: true);

	private TimeSlice _elapsed = TimeSlice.Zero;

	public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(IndicatorType), typeof(LoadingIndicator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IndicatorType.Bar));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(LoadingIndicator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DodgerBlue));

	public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(double), typeof(LoadingIndicator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0));

	public IndicatorType DisplayMode
	{
		get
		{
			return (IndicatorType)((DependencyObject)this).GetValue(DisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayModeProperty, (object)value);
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

	public double Speed
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SpeedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpeedProperty, (object)value);
		}
	}

	public LoadingIndicator()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		new DispatcherTimer((DispatcherPriority)10)
		{
			Interval = UpdateTime,
			IsEnabled = true
		}.Tick += delegate
		{
			if (base.Visibility == Visibility.Visible)
			{
				InvalidateVisual();
			}
			else
			{
				_clock.Restart();
				_elapsed = TimeSlice.Zero;
			}
		};
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		_elapsed += _clock.Restart() * Speed;
		Vector2<double> vector = new Vector2<double>(base.ActualWidth, base.ActualHeight);
		Vector2<double> vector2 = vector / 2.0;
		double num = _elapsed.TotalSeconds / LoopTime.TotalSeconds;
		double num2 = Math.Min(vector.X, vector.Y) / 2.0;
		Vector2<double> point = vector2 + new Vector2<double>(0.0, num2 * 0.6);
		double num3 = 0.0;
		switch (DisplayMode)
		{
		case IndicatorType.Bar:
			num3 = vector.Y * 0.25;
			break;
		case IndicatorType.Spinner:
			num3 = num2 * 0.1;
			break;
		}
		double num4 = num3 * 2.0;
		Vector2<double> vector3 = new Vector2<double>(0.0 - num4, vector2.Y);
		double num5 = vector.X + num4 * 2.0;
		drawingContext.PushClip(new RectangleGeometry(new Rect((Size)vector)));
		for (int i = 1; i <= 7; i++)
		{
			double num6 = (num * 2.0 - (double)i * 0.095).Mod(2.0);
			double num7 = Math.Sin(num6 / 2.0 * Math.PI);
			if (num6 >= 1.0)
			{
				num7 *= -1.0;
			}
			Vector2<double> vector4 = Vector2<double>.Zero;
			switch (DisplayMode)
			{
			case IndicatorType.Bar:
				vector4 = vector3 + new Vector2<double>((num5 * num7 + vector2.X).Mod(num5), 0.0);
				break;
			case IndicatorType.Spinner:
				vector4 = point.Rotate(vector2, num7 * 360.0);
				break;
			}
			drawingContext.DrawEllipse(Fill, null, vector4, num3, num3);
		}
	}
}
