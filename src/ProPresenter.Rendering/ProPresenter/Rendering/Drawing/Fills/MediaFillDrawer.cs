using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using Pro.UI.Themes;
using Pro.ssAPI;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.Rendering.Drawing.Links;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class MediaFillDrawer : IDrawer<IFill>
{
	private readonly LinearGradientBrush? _placeholderBackgroundBrush;

	private readonly ImageSource? _placeholderImage;

	public MediaFillDrawer()
	{
		_placeholderBackgroundBrush = (LinearGradientBrush)Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.PendingMediaBackgroundGradient);
		_placeholderImage = Icons.GetIcon(Icons.MediaPendingPlaceholder);
	}

	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		System.Windows.Media.Geometry fillGeometry = drawingParams.FillGeometry;
		if (renderMode == RenderingMode.Editor)
		{
			dc.DrawGeometry(System.Windows.Media.Brushes.Transparent, null, fillGeometry);
		}
		if (renderMode == RenderingMode.OutputContentMask)
		{
			dc.DrawGeometry(System.Windows.Media.Brushes.White, null, fillGeometry);
		}
		else
		{
			if (renderMode.IsOutputMode())
			{
				return;
			}
			MediaFill mediaFill = (MediaFill)fill;
			BitmapSource bitmapSource = mediaFill.Media?.Drawing.PreviewImage;
			if (mediaFill.ScaleType == ScaleBehavior.ScaleAndBlur)
			{
				dc.DrawGeometry(LinkFillDrawerBase.NonresolvedContentBrush, null, fillGeometry);
			}
			if (mediaFill.IsPending || bitmapSource != null)
			{
				Vector2<double> vector = mediaFill.CropPosition + mediaFill.CropSize * 0.5;
				RotateTransform transform = new RotateTransform(mediaFill.CropRotation.InvertedCartesianValue, vector.X, vector.Y);
				dc.PushClip(fillGeometry);
				dc.PushTransform(BezierPathHelper.GenerateFlipTransform(drawingParams.Path, drawingParams.Path.Size * 0.5));
				dc.PushTransform(transform);
				if (mediaFill.IsPending)
				{
					dc.DrawGeometry(_placeholderBackgroundBrush, null, fillGeometry);
					Rect bounds = fillGeometry.Bounds;
					double val = ((Rect)(ref bounds)).Height * 0.4;
					bounds = fillGeometry.Bounds;
					double val2 = Math.Min(val, ((Rect)(ref bounds)).Width * 0.4);
					val2 = Math.Max(val2, 32.0);
					bounds = fillGeometry.Bounds;
					double x = ((Rect)(ref bounds)).Width / 2.0 - val2 / 2.0;
					bounds = fillGeometry.Bounds;
					double y = ((Rect)(ref bounds)).Height / 2.0 - val2 / 2.0;
					dc.DrawImage(_placeholderImage, new Rect<double>(x, y, val2, val2));
				}
				else
				{
					dc.DrawImage(bitmapSource, new Rect<double>(mediaFill.CropPosition, mediaFill.CropSize));
				}
				dc.Pop();
				dc.Pop();
				dc.Pop();
			}
		}
	}
}
