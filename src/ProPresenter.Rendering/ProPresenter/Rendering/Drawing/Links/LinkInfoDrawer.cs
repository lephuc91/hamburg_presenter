using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Localization;
using Pro.UI.Themes;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Rendering.Drawing.Links;

internal class LinkInfoDrawer : IDrawer<MiscellaneousDrawerType>
{
	private const double VerticalMargin = 10.0;

	private const double TextMargin = 5.0;

	private const double FontSize = 22.0;

	private static readonly Typeface Typeface;

	internal static readonly Brush Brush;

	private static readonly Pen BorderPen;

	private static readonly ImageSource? LinkIcon;

	private static readonly Vector2<double> LinkIconSize;

	private static ImageSource? EffectsIcon;

	private static Vector2<double> EffectsIconSize;

	static LinkInfoDrawer()
	{
		Typeface = new Typeface("Segoe UI");
		Brush = new SolidColorBrush(Color.FromRgb(131, 132, 37));
		BorderPen = new Pen
		{
			Thickness = 2.0,
			Brush = Brush
		};
		LinkIconSize = new Vector2<double>(25.0, 12.0);
		EffectsIconSize = new Vector2<double>(21.0);
		try
		{
			LinkIcon = Icons.GetIcon(Icons.LinkIcon);
			EffectsIcon = Icons.GetIcon(Icons.BackgroundEffects);
		}
		catch (Exception value)
		{
			Log.Error($"Unable to set fill/link info icons with error - {value}");
		}
		((Freezable)BorderPen).Freeze();
		ImageSource? linkIcon = LinkIcon;
		if (linkIcon != null)
		{
			((Freezable)linkIcon).Freeze();
		}
		ImageSource? effectsIcon = EffectsIcon;
		if (effectsIcon != null)
		{
			((Freezable)effectsIcon).Freeze();
		}
	}

	public void Draw(DrawingContext dc, RenderingMode renderMode, MiscellaneousDrawerType data, DrawingParams drawingParams)
	{
		if (dc == null || drawingParams == null || renderMode.IsOutputMode())
		{
			return;
		}
		BezierPath path = drawingParams.Path;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		bool flag = false;
		if (path is ClosedBezierPath closedBezierPath)
		{
			flag = closedBezierPath.Fill.IsEnabled && closedBezierPath.Fill.Type.IsAnyOf(FillType.BackgroundEffectInvert, FillType.BackgroundEffectBlur) && (closedBezierPath.FillLink.LinkedObject == null || closedBezierPath.FillLink.LinkedObject.LinkedFillType == LinkedFillType.None);
			text = (flag ? LocalizedStrings.Get("EDITOR_SHAPE_FILL_LINK_label", new object[1] { closedBezierPath.Fill.DisplayName }) : string.Empty);
			text2 = closedBezierPath.FillLink.DisplayText;
			text3 = closedBezierPath.TextLink.DisplayText;
			text4 = closedBezierPath.VisibilityLink?.DisplayText;
			text5 = (closedBezierPath.Fill as HTMLFill)?.DisplayText;
			if (closedBezierPath.FillLink.LinkedObject != null)
			{
				text5 = null;
			}
			if (closedBezierPath.Fill is LiveVideoFill liveVideoFill && string.IsNullOrEmpty(text2))
			{
				text2 = LocalizedStrings.Get("EDITOR_SHAPE_VIDEO_INPUT_LINK_label", new object[1] { liveVideoFill.LiveVideo?.LiveVideo.Input?.DefaultDescription ?? string.Empty });
			}
		}
		string text6 = string.Join(", ", new string[4] { text2, text3, text4, text5 }.Where((string s) => !string.IsNullOrEmpty(s)));
		string value = string.Join(", ", text);
		bool flag2 = !string.IsNullOrEmpty(text6);
		if (string.IsNullOrEmpty(text6) && string.IsNullOrEmpty(value))
		{
			return;
		}
		dc.DrawGeometry(System.Windows.Media.Brushes.Transparent, BorderPen, drawingParams.FillGeometry);
		if (drawingParams.RenderingMode == RenderingMode.Preview)
		{
			return;
		}
		Vector2<double> position = new Rect<double>(path.Size).Abs().Position - new Vector2<double>(0.0, 10.0);
		double num = path.Size.X.Abs();
		if (flag)
		{
			if (flag2)
			{
				text += ",";
			}
			position = DrawInfo(dc, EffectsIcon, EffectsIconSize, text, position, num);
			if (flag2)
			{
				position = new Vector2<double>(position.X + 10.0, position.Y);
			}
			num -= position.X;
		}
		if (flag2)
		{
			DrawInfo(dc, LinkIcon, LinkIconSize, text6, position, num);
		}
	}

	protected Vector2<double> DrawInfo(DrawingContext dc, ImageSource? img, Vector2<double> imgSize, string infoText, Vector2<double> position, double availableWidth)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		if (img != null)
		{
			if (availableWidth - imgSize.X <= 0.0)
			{
				return position;
			}
			FormattedText formattedText = new FormattedText(infoText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, 22.0, Brush, 1.0);
			formattedText.MaxTextHeight = formattedText.Height;
			formattedText.MaxTextWidth = Math.Max(1.0, availableWidth - imgSize.X);
			formattedText.Trimming = TextTrimming.CharacterEllipsis;
			double y = (position.Y - (formattedText.Height + imgSize.Y)) / 2.0;
			dc.DrawImage(img, new Rect<double>(new Vector2<double>(position.X, y), imgSize));
			Vector2<double> vector = new Vector2<double>(position.X + imgSize.X + 5.0, position.Y - formattedText.Height + 2.5);
			dc.DrawText(formattedText, vector);
			return new Vector2<double>(vector.X + formattedText.Width + 5.0, position.Y);
		}
		OnDrawInfo();
		return Vector2<double>.Zero;
	}

	protected virtual void OnDrawInfo()
	{
	}
}
