using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class Ruler : FrameworkElement
{
	private const int BasePixelsPerSegment = 100;

	private const int MinPixelsPerSegment = 50;

	private const int MaxPixelsPerSegment = 500;

	private const int SmallTicksPerSegment = 9;

	private const double RulerThickness = 18.0;

	private const double LargeTickSize = 10.0;

	private const double SmallTickSize = 5.0;

	private const double UnitScaleFactor = 10.0;

	private const double LabelBaseOffset = 5.0;

	private const double LabelSideOffset = 3.0;

	private const string LabelFont = "Arial";

	private const double LabelSize = 10.0;

	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(double), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty OriginOffsetProperty = DependencyProperty.Register("OriginOffset", typeof(double), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ScrollOffsetProperty = DependencyProperty.Register("ScrollOffset", typeof(double), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty IsHorizontalProperty = DependencyProperty.Register("IsHorizontal", typeof(bool), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightGray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty RulerBrushProperty = DependencyProperty.Register("RulerBrush", typeof(Brush), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty RulerEdgeBrushProperty = DependencyProperty.Register("RulerEdgeBrush", typeof(Brush), typeof(Ruler), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DarkGray, FrameworkPropertyMetadataOptions.AffectsRender));

	public double Origin
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginProperty, (object)value);
		}
	}

	public double OriginOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OriginOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginOffsetProperty, (object)value);
		}
	}

	public double ScrollOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollOffsetProperty, (object)value);
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

	public bool IsHorizontal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsHorizontalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsHorizontalProperty, (object)value);
		}
	}

	public Brush Background
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundProperty, (object)value);
		}
	}

	public Brush RulerBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RulerBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerBrushProperty, (object)value);
		}
	}

	public Brush RulerEdgeBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RulerEdgeBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerEdgeBrushProperty, (object)value);
		}
	}

	public Ruler()
	{
		base.ClipToBounds = true;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		return IsHorizontal ? new Vector2<double>(((Size)(ref availableSize)).Width, 18.0) : new Vector2<double>(18.0, ((Size)(ref availableSize)).Height);
	}

	protected override void OnRender(DrawingContext dc)
	{
		DrawRuler(dc, IsHorizontal);
	}

	protected virtual string FormatLabel(double position)
	{
		return Math.Floor(position + 0.05).ToString("N0", CultureInfo.CurrentUICulture);
	}

	private void DrawRuler(DrawingContext dc, bool isHorizontal)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		Pen pen = new Pen(RulerEdgeBrush, 1.0);
		Pen pen2 = new Pen(RulerBrush, 1.0);
		double num = (isHorizontal ? base.ActualWidth : base.ActualHeight);
		double num2 = 1.0;
		double num3 = 100.0 * ZoomFactor;
		dc.DrawRectangle(Background, null, new Rect<double>(Vector2<double>.Zero, isHorizontal.Orient(18.0, num)));
		dc.DrawLine(pen, isHorizontal.Orient(17.0, 0.0), isHorizontal.Orient(17.0, num));
		while (num3 < 50.0)
		{
			num3 *= 10.0;
			num2 *= 10.0;
		}
		while (num3 > 500.0)
		{
			num3 /= 10.0;
			num2 /= 10.0;
		}
		double num4 = num3 / 10.0;
		double num5 = 100.0 * num2;
		double num6 = OriginOffset - (ScrollOffset - Origin) % num3;
		double num7 = (ScrollOffset - Origin) / ZoomFactor;
		int num8 = (int)(num7 - num7 % num5);
		if (num6 > 0.0)
		{
			int num9 = (int)Math.Ceiling(num6 / num3);
			num6 -= num3 * (double)num9;
			num8 -= (int)num5 * num9;
		}
		for (double num10 = num6; num10 < num; num10 += num3)
		{
			dc.DrawLine(pen2, isHorizontal.Orient(0.0, num10), isHorizontal.Orient(10.0, num10));
			DrawLabel(dc, isHorizontal, num8, num10);
			num8 += (int)num5;
			for (int i = 1; i <= 9; i++)
			{
				dc.DrawLine(pen2, isHorizontal.Orient(0.0, num10 + num4 * (double)i), isHorizontal.Orient(5.0, num10 + num4 * (double)i));
			}
		}
	}

	private void DrawLabel(DrawingContext dc, bool isHorizontal, int labelValue, double position)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		FormattedText formattedText = new FormattedText(FormatLabel(labelValue), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10.0, RulerBrush);
		Vector2<double> vector = isHorizontal.Orient(5.0, position + 3.0 + ((!isHorizontal) ? formattedText.Width : 0.0));
		Geometry geometry = formattedText.BuildGeometry(Vector2<double>.Zero);
		TransformGroup transformGroup = new TransformGroup();
		if (!isHorizontal)
		{
			transformGroup.Children.Add(new RotateTransform(-90.0));
		}
		transformGroup.Children.Add(new TranslateTransform(vector.X, vector.Y));
		geometry.Transform = transformGroup;
		dc.DrawGeometry(RulerBrush, null, geometry);
	}
}
