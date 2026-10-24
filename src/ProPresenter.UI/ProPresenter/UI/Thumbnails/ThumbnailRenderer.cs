using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Media;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;

namespace ProPresenter.UI.Thumbnails;

public static class ThumbnailRenderer
{
	private const double SCREEN_DPI = 96.0;

	private const double PRINT_DPI = 300.0;

	private static readonly PixelFormat PixelFormat = PixelFormats.Pbgra32;

	public static void RenderThumbnails(IEnumerable<ArrangedCue> cues, double availableWidth, Action<IEnumerable<DisposableRenderTargetBitmap>> completedCallback, IApp app)
	{
		ArrangedCue[] cueArray = cues.ToArray();
		DisposableRenderTargetBitmap[] renderedThumbnails = new DisposableRenderTargetBitmap[cueArray.Length];
		int renderedCount = 0;
		for (int i = 0; i < cueArray.Length; i++)
		{
			int index2 = i;
			ArrangedCue arrangedCue = cueArray[i];
			CustomSlide obj = arrangedCue.Source.SlideAction?.Slide as CustomSlide;
			obj.ThrowWhenNull("slide");
			IPresentation parentPresentation = arrangedCue.Source.ParentPresentation;
			MediaAction mediaAction = arrangedCue.Source.Actions.OfType<MediaAction>().FirstOrDefault();
			Color backgroundColor = GetBackgroundColor(obj, mediaAction, parentPresentation);
			double num = ToPrintDpiLength(availableWidth);
			SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(new Vector2<double>(num, num / arrangedCue.ThumbnailAspectRatio).Cast<int>(), parentPresentation?.UseBackgroundColor ?? false, IncludeBackgroundMedia: true, backgroundColor, ElementsRenderOption.None, null, IncludeTextPlaceholder: false, UseFullSizeMedia: false, UseScreenScalar: false);
			SlidePreviewRenderer.RenderSlidePreviewDeferred(obj, renderParams, delegate(CustomSlide customSlide, IBitmapHandle bitmap)
			{
				renderCompleted(index2, bitmap);
			});
		}
		void renderCompleted(int index, IBitmapHandle bitmap)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			Thumbnail thumbnail = new Thumbnail
			{
				Source = cueArray[index],
				Index = index + 1,
				PreviewImage = bitmap,
				ViewSettings = new ThumbnailViewSettings(app)
				{
					ShowScrimItems = false
				},
				ShowBuildProgress = false,
				HideCheckerboard = true
			};
			thumbnail.Measure(new Size(availableWidth, double.PositiveInfinity));
			thumbnail.Arrange(new Rect(thumbnail.DesiredSize));
			thumbnail.UpdateLayout();
			DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)ToPrintDpiLength(thumbnail.ActualWidth), (int)ToPrintDpiLength(thumbnail.ActualHeight), 300.0, 300.0, PixelFormat);
			disposableRenderTargetBitmap.Render(thumbnail);
			disposableRenderTargetBitmap.Freeze();
			renderedThumbnails[index] = disposableRenderTargetBitmap;
			if (++renderedCount == cueArray.Length)
			{
				completedCallback(renderedThumbnails);
			}
			bitmap.Dispose();
		}
	}

	private static double ToPrintDpiLength(double length)
	{
		return length * 300.0 / 96.0;
	}

	private static Color GetBackgroundColor(CustomSlide slide, MediaAction? mediaAction, IPresentation? parentPresentation)
	{
		if (mediaAction != null && mediaAction.TriggerLayer == TriggerLayer.Foreground)
		{
			return Colors.Transparent;
		}
		if (slide.UseBackgroundColor)
		{
			return slide.BackgroundColor;
		}
		if (parentPresentation != null && parentPresentation.UseBackgroundColor)
		{
			return parentPresentation.BackgroundColor;
		}
		return Display.Settings.ScreenColor;
	}
}
