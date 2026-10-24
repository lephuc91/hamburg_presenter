using System;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Controls;

namespace ProPresenter.UI.Input;

public class LevelFillMeter : FillMeter<double>
{
	private const double MinimumRange = -60.0;

	private const double MaximumRange = 0.0;

	private static readonly Brush BackgroundBrush;

	private static readonly Brush FillBrush;

	static LevelFillMeter()
	{
		GradientStopCollection obj = new GradientStopCollection
		{
			new GradientStop(Color.FromRgb(27, 66, 11), DecibelsToOffset(-60.0)),
			new GradientStop(Color.FromRgb(69, 183, 25), DecibelsToOffset(-20.0)),
			new GradientStop(Colors.Yellow, DecibelsToOffset(-14.0)),
			new GradientStop(Colors.Yellow, DecibelsToOffset(-10.0)),
			new GradientStop(Colors.Red, DecibelsToOffset(0.0))
		};
		((Freezable)obj).Freeze();
		BackgroundBrush = new LinearGradientBrush(obj, 0.0)
		{
			Opacity = 0.12
		};
		FillBrush = new LinearGradientBrush(obj, 0.0);
		((Freezable)BackgroundBrush).Freeze();
		((Freezable)FillBrush).Freeze();
	}

	public LevelFillMeter()
	{
		base.Minimum = -60.0;
		base.Maximum = 0.0;
		base.MeterBackground = BackgroundBrush;
		base.MeterFill = FillBrush;
	}

	private static double DecibelsToOffset(double decibels)
	{
		return Math.Pow(decibels.Clamp(-60.0, 0.0).ToFeatureRange(-60.0, 0.0), 2.0);
	}

	protected override double ScaleValue(double value)
	{
		return DecibelsToOffset(value);
	}
}
