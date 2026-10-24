using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Drawing.Fills;

internal static class FillDrawerHelper
{
	private const FlowDirection TextFlowDirection = FlowDirection.LeftToRight;

	private static readonly Typeface Typeface = new Typeface("Segoe UI");

	private static readonly Brush FontColor = Brushes.White;

	public static void DrawText(this DrawingContext dc, string inputText, Geometry geometry, BezierPath path, TextAlignment alignment = TextAlignment.Left)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		Rect bounds = geometry.Bounds;
		Vector2<double> position = new Vector2<double>(((Rect)(ref bounds)).Height / 2.0);
		bounds = geometry.Bounds;
		double width = ((Rect)(ref bounds)).Width;
		bounds = geometry.Bounds;
		Rect<double> rect = new Rect<double>(position, new Vector2<double>(width, ((Rect)(ref bounds)).Height / 10.0));
		FormattedText formattedText = new FormattedText(inputText ?? string.Empty, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, (Math.Round(rect.Height) != 0.0) ? Math.Round(rect.Height) : 1.0, FontColor, 1.0);
		formattedText.MaxTextWidth = rect.Width;
		formattedText.TextAlignment = TextAlignment.Center;
		dc.DrawText(formattedText, new Rect<double>(Vector2<double>.Zero, path.Size).Abs().LeftCenter - new Vector2<double>(0.0, formattedText.Height / 2.0));
	}
}
