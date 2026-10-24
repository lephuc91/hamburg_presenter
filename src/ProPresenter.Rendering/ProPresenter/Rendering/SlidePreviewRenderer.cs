using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.ssAPI;
using ProPresenter.DO.Export;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.Rendering.Jobs;

namespace ProPresenter.Rendering;

public static class SlidePreviewRenderer
{
	private const int DPI = 96;

	private static readonly PixelFormat PixelFormat;

	private static readonly BitmapCache<SlidePreviewBitmapKey> _bitmapCache;

	private static Func<Vector2<double>>? _getCurrentDPIScalar;

	static SlidePreviewRenderer()
	{
		PixelFormat = PixelFormats.Pbgra32;
		_bitmapCache = new BitmapCache<SlidePreviewBitmapKey>();
		ExportPrompt.SetRenderImage((CustomSlide slide, Color secondaryBackgroundColor, bool includeBackground, bool includeMedia) => RenderSlidePreview(slide, new SlidePreviewRenderParams(slide.Size.Cast<int>(), includeBackground, includeMedia, secondaryBackgroundColor, ElementsRenderOption.None, null, IncludeTextPlaceholder: false, UseFullSizeMedia: true, UseScreenScalar: false))?.BitmapSource);
	}

	public static IBitmapHandle RenderSlidePreview(CustomSlide? slide, SlidePreviewRenderParams renderParams)
	{
		if (slide == null)
		{
			throw new InvalidOperationException();
		}
		if (renderParams.ElementsRenderOption != 0)
		{
			return DrawSlidePreviewToBitmap(slide, renderParams);
		}
		CachedBitmap cachedBitmap = _bitmapCache.Get(new SlidePreviewBitmapKey(slide, renderParams));
		lock (cachedBitmap)
		{
			if (!IsCachedBitmapAcceptable(cachedBitmap, renderParams))
			{
				cachedBitmap.UpdateBitmap(DrawSlidePreviewToBitmap(slide, renderParams));
				cachedBitmap.IsBitmapValid = true;
			}
			if (!cachedBitmap.IsInvalidateAttached)
			{
				slide.VisualInvalidated += delegate
				{
					lock (cachedBitmap)
					{
						cachedBitmap.IsBitmapValid = false;
					}
				};
				cachedBitmap.IsInvalidateAttached = true;
			}
			return cachedBitmap.CreateHandle();
		}
	}

	public static void RenderSlidePreviewDeferred(CustomSlide slide, SlidePreviewRenderParams renderParams, Action<CustomSlide, IBitmapHandle> completedCallback, Dispatcher? callbackDispatcher = null)
	{
		SharedWorkerPool.Queue.AddJob(new SlidePreviewRenderJob(slide, renderParams, completedCallback, callbackDispatcher ?? Dispatcher.CurrentDispatcher));
	}

	public static bool TryGetBitmap(CustomSlide slide, SlidePreviewRenderParams renderParams, [NotNullWhen(true)] out CachedBitmapHandle? bitmap)
	{
		bitmap = null;
		if (_bitmapCache.TryGet(new SlidePreviewBitmapKey(slide, renderParams), out CachedBitmap value) && value != null)
		{
			lock (value)
			{
				if (IsCachedBitmapAcceptable(value, renderParams))
				{
					bitmap = value.CreateHandle();
					return true;
				}
			}
		}
		return false;
	}

	public static void SetGetCurrentDPI(Func<Vector2<double>> getCurrentDPIScalar)
	{
		if (_getCurrentDPIScalar != null)
		{
			throw new NotSupportedException();
		}
		_getCurrentDPIScalar = getCurrentDPIScalar;
	}

	private static bool IsCachedBitmapAcceptable(CachedBitmap cachedBitmap, SlidePreviewRenderParams renderParams)
	{
		if (cachedBitmap.IsBitmapValid && cachedBitmap.CurrentRenderedBitmap?.BitmapSource != null && cachedBitmap.CurrentRenderedBitmap.BitmapSource.Width >= (double)renderParams.PreviewSize.X)
		{
			return cachedBitmap.CurrentRenderedBitmap.BitmapSource.Height >= (double)renderParams.PreviewSize.Y;
		}
		return false;
	}

	private static RenderedBitmapHandle DrawSlidePreviewToBitmap(CustomSlide slide, SlidePreviewRenderParams renderParams)
	{
		if (!DrawSlidePreview(slide, renderParams, out RenderedBitmapHandle renderedSlide))
		{
			throw new InvalidCastException();
		}
		return renderedSlide;
	}

	private static bool DrawSlidePreview(CustomSlide slide, SlidePreviewRenderParams renderParams, [NotNullWhen(true)] out RenderedBitmapHandle? renderedSlide)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			if (renderParams.IncludeBackground && renderParams.ElementsRenderOption == ElementsRenderOption.ExclusiveHighlight)
			{
				drawingContext.DrawRectangle(Brushes.Black, null, new Rect<double>(Vector2<double>.Zero, renderParams.PreviewSize.Cast<double>()));
			}
			if (renderParams.IncludeBackgroundMedia)
			{
				SampleMediaInfo sampleMediaInfo = slide.BackgroundMediaSampler?.Invoke();
				Vector2<double> vector = renderParams.PreviewSize.Cast<double>();
				if (sampleMediaInfo?.Source != null)
				{
					Vector2<double> vector2 = new Vector2<double>(sampleMediaInfo.Source.Width, sampleMediaInfo.Source.Height);
					switch (sampleMediaInfo.ScaleBehavior)
					{
					case ScaleBehavior.ScaleToFit:
					case ScaleBehavior.ScaleAndBlur:
						vector2 = vector2.ScaleToFitSize(vector);
						break;
					case ScaleBehavior.ScaleToFill:
						vector2 = vector2.ScaleToFillSize(vector);
						break;
					case ScaleBehavior.StretchToFill:
						vector2 = vector;
						break;
					}
					Vector2<double> vector3 = vector - vector2;
					ScaleBehavior scaleBehavior = sampleMediaInfo.ScaleBehavior;
					if (scaleBehavior == ScaleBehavior.ScaleToFit || scaleBehavior == ScaleBehavior.ScaleToFill || scaleBehavior == ScaleBehavior.ScaleAndBlur)
					{
						vector3 = ScaleAlignmentHelper.GetAlignedPosition((scaleBehavior == ScaleBehavior.ScaleAndBlur) ? ScaleAlignment.MiddleCenter : sampleMediaInfo.ScaleAlignment, sampleMediaInfo.FlipHorizontally, sampleMediaInfo.FlipVertically, vector3);
					}
					drawingContext.DrawImage(sampleMediaInfo.Source, new Rect<double>(vector3, vector2));
				}
			}
			bool flag = !Advanced.Settings.IgnoreBackgroundColors || renderParams.ForceBackgroundColorDraw;
			if (renderParams.IncludeBackground && renderParams.ElementsRenderOption != ElementsRenderOption.ExclusiveHighlight && flag)
			{
				Color color = (slide.UseBackgroundColor ? slide.BackgroundColor : renderParams.SecondaryBackground);
				drawingContext.DrawRectangle(new SolidColorBrush(color), null, new Rect<double>(Vector2<double>.Zero, renderParams.PreviewSize.Cast<double>()));
			}
			foreach (BezierPath item in from e in slide.Elements.OfType<BezierPath>()
				orderby e.ZOrder
				select e)
			{
				bool flag2 = renderParams.SlideElements?.Contains(item) ?? false;
				bool flag3 = renderParams.ElementsRenderOption == ElementsRenderOption.ExclusiveHighlight;
				bool includeText = !flag3 && !(renderParams.ElementsRenderOption == ElementsRenderOption.ExcludeText && flag2);
				if (!flag3 || (flag3 && flag2))
				{
					BezierPathRenderer.DrawBezierPath(item, drawingContext, new BezierPathRenderParams(includeText, flag3, includeRotation: true, includePosition: true, renderParams.IncludeTextPlaceholder, (double)renderParams.PreviewSize.X / slide.Size.X, renderParams.UseFullSizeMedia, RenderingMode.Preview, 0, renderParams.IncludeLinkIndicator));
				}
			}
		}
		Vector2<double> vector4 = ((renderParams.UseScreenScalar && _getCurrentDPIScalar != null) ? _getCurrentDPIScalar() : Vector2<double>.One);
		Vector2<int> vector5 = renderParams.PreviewSize.Cast<double>().ComponentwiseProduct(vector4).Ceiling()
			.Cast<int>();
		Vector2<double> vector6 = vector4 * 96.0;
		if (vector5.X > 0 && vector5.Y > 0)
		{
			DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap(vector5.X, vector5.Y, vector6.X, vector6.Y, PixelFormat);
			disposableRenderTargetBitmap.Render(drawingVisual);
			disposableRenderTargetBitmap.Freeze();
			renderedSlide = new RenderedBitmapHandle(Vector2<double>.Zero, new Vector2<double>(disposableRenderTargetBitmap.Width, disposableRenderTargetBitmap.Height), disposableRenderTargetBitmap);
			return true;
		}
		Log.Error("Attempted to render an image with size:({0}, {1}). Height and Width must be a positive integer.\nOrigin Values:\n\tPreviewSize = {2}\n\tScalar = {3}", vector5.X, vector5.Y, renderParams.PreviewSize, vector4);
		renderedSlide = null;
		return false;
	}
}
