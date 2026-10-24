using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using SharpVectors.Runtime;

namespace Pro.UI.Utility;

public static class DrawingContextExtensions
{
	private static readonly Typeface TextTypeface = new Typeface("Segoe UI");

	public static void DrawText(this DrawingContext dc, string text, Vector2<double> origin, double fontSize = 14.0, Brush? foreground = null, Vector2<double>? maxSize = null, TextAlignment alignment = TextAlignment.Left, TextTrimming trimming = TextTrimming.None)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> maxSize2 = GetMaxSize(maxSize);
		double pixelsPerDip = DpiUtilities.GetSystemScale().PixelsPerDip;
		dc.DrawText(new FormattedText(text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, TextTypeface, fontSize, foreground ?? Brushes.White, pixelsPerDip)
		{
			MaxTextWidth = maxSize2.X,
			MaxTextHeight = maxSize2.Y,
			TextAlignment = alignment,
			Trimming = trimming
		}, origin);
	}

	private static Vector2<double> GetMaxSize(Vector2<double>? maxSize)
	{
		if (!maxSize.HasValue)
		{
			return new Vector2<double>(1.0, 1.0);
		}
		double x = (double.IsNaN(maxSize.Value.X) ? 1.0 : Math.Max(maxSize.Value.X, 1.0));
		double y = (double.IsNaN(maxSize.Value.Y) ? 1.0 : Math.Max(maxSize.Value.Y, 1.0));
		return new Vector2<double>(x, y);
	}
}
