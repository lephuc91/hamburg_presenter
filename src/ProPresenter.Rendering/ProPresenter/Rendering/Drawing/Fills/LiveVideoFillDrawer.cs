using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.ssAPI;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.Rendering.Drawing.Links;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class LiveVideoFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		LiveVideoFill liveVideoFill = (LiveVideoFill)fill;
		Geometry fillGeometry = drawingParams.FillGeometry;
		_ = drawingParams.Path;
		switch (renderMode)
		{
		case RenderingMode.OutputContentMask:
			dc.DrawGeometry(Brushes.White, null, fillGeometry);
			break;
		case RenderingMode.ShadowContents:
			if (liveVideoFill.LiveVideo != null)
			{
				LiveVideoMedia liveVideo = liveVideoFill.LiveVideo;
				Rect<double> rect = default(Rect<double>);
				if (liveVideo.LiveVideo.Input?.VideoMode != null)
				{
					Vector2<double> originalSize = liveVideo.LiveVideo.Input.VideoMode.Size.Cast<double>();
					Rect bounds = fillGeometry.Bounds;
					Vector2<double> vector = (Vector2<double>)((Rect)(ref bounds)).Size;
					rect.Size = MediaScaleHelper.Scale(originalSize, vector, liveVideo.Drawing.ScaleBehavior);
					ScaleBehavior scaleBehavior = liveVideo.Drawing.ScaleBehavior;
					if (scaleBehavior == ScaleBehavior.ScaleToFill || scaleBehavior == ScaleBehavior.ScaleToFit || scaleBehavior == ScaleBehavior.ScaleAndBlur)
					{
						rect.Position = (vector.Abs() - rect.Size) * 0.5;
					}
					dc.PushClip(fillGeometry);
					dc.DrawRectangle(Brushes.White, null, rect);
					dc.Pop();
				}
				break;
			}
			goto default;
		default:
			if (!renderMode.IsOutputMode())
			{
				dc.DrawGeometry(LinkFillDrawerBase.NonresolvedContentBrush, null, drawingParams.FillGeometry);
			}
			break;
		}
	}
}
