using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Effects;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.Text;
using Pro.UI.Themes;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;
using ProPresenter.DO.Slide.Links;
using ProPresenter.Rendering.Drawing;
using ProPresenter.Rendering.Drawing.Links;
using ProPresenter.Rendering.Jobs;

namespace ProPresenter.Rendering;

public static class BezierPathRenderer
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int pixelWidth;

		public int segmentSize;

		public Vector2<double> mainOffset;

		public DrawingVisual target;

		public int pixelHeight;
	}

	private const int PaddingSize = 2;

	private const int DPI = 96;

	private static readonly PixelFormat PixelFormat = PixelFormats.Pbgra32;

	private static readonly Brush HighlightBrush = System.Windows.Media.Brushes.Yellow;

	private static readonly Brush? NonOutputTextMaskBrush = Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.SpecialTextFill);

	private const int ScrollingSegmentSize = 512;

	private const double ConstantSizeSnapIncrement = 5.0;

	private static readonly BitmapCache<BezierPathBitmapKey> _bitmapCache = new BitmapCache<BezierPathBitmapKey>();

	private static readonly ArrangedTextCache _arrangedTextCache = new ArrangedTextCache();

	private static readonly TextLayersCache _textLayersCache = new TextLayersCache();

	private static readonly DrawerSet _drawers = new DrawerSet();

	public static IBitmapHandle RenderBezierPath(BezierPath path, RenderingMode renderMode)
	{
		if (path.PathType == BezierPathType.Closed && path is ClosedBezierPath closedBezierPath && (closedBezierPath.TextLink.IsEnabled || closedBezierPath.FillLink.IsEnabled))
		{
			return DrawBezierPath(path, renderMode);
		}
		CachedBitmap cachedBitmap = _bitmapCache.Get(new BezierPathBitmapKey(path, renderMode));
		lock (cachedBitmap)
		{
			if (!cachedBitmap.IsBitmapValid || cachedBitmap.CurrentRenderedBitmap == null)
			{
				cachedBitmap.UpdateBitmap(DrawBezierPath(path, renderMode));
				cachedBitmap.IsBitmapValid = true;
			}
			if (!cachedBitmap.IsInvalidateAttached)
			{
				path.VisualInvalidated += delegate
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

	public static void RenderBezierPathDeferred(BezierPath path, RenderingMode renderMode, Action<BezierPath, RenderingMode, IBitmapHandle> completedCallback, Dispatcher? callbackDispatcher = null)
	{
		RenderBezierPathsDeferred(new BezierPath[1] { path }, renderMode, completedCallback, callbackDispatcher);
	}

	public static void RenderBezierPathsDeferred(IEnumerable<BezierPath> paths, RenderingMode renderMode, Action<BezierPath, RenderingMode, IBitmapHandle> completedCallback, Dispatcher? callbackDispatcher = null)
	{
		SharedWorkerPool.Queue.AddJobs(paths.Collect((BezierPath p) => new BezierPathRenderJob(p, renderMode, completedCallback, callbackDispatcher ?? Dispatcher.CurrentDispatcher)));
	}

	public static void DrawBezierPath(BezierPath path, DrawingVisual target, BezierPathRenderParams renderParams)
	{
		using DrawingContext dc = target.RenderOpen();
		DrawBezierPath(path, dc, renderParams);
	}

	public static void DrawBezierPath(BezierPath path, DrawingContext dc, BezierPathRenderParams renderParams)
	{
		Rect<double> rect = new Rect<double>(Vector2<double>.Zero, path.Size);
		bool flag = !renderParams.RenderingMode.IsOutputMode();
		if (flag)
		{
			dc.PushOpacity(path.Opacity);
		}
		dc.PushTransform(new ScaleTransform(renderParams.Scale, renderParams.Scale));
		if (renderParams.IncludePosition)
		{
			dc.PushTransform(new TranslateTransform(path.Position.X, path.Position.Y));
		}
		if (renderParams.IncludeRotation)
		{
			dc.PushTransform(new RotateTransform(path.Rotation.InvertedCartesianValue, rect.Center.X, rect.Center.Y));
		}
		switch (path.PathType)
		{
		case BezierPathType.Closed:
			DrawClosedPath((ClosedBezierPath)path, dc, renderParams);
			break;
		case BezierPathType.Open:
			DrawOpenPath(path, dc, renderParams);
			break;
		default:
			throw new NotImplementedException(path.PathType.ToString() + " path type is not supported");
		}
		if (renderParams.IncludeRotation)
		{
			dc.Pop();
		}
		if (renderParams.IncludePosition)
		{
			dc.Pop();
		}
		dc.Pop();
		if (flag)
		{
			dc.Pop();
		}
	}

	public static RenderedBitmapHandle DrawBezierPath(BezierPath path, BezierPathRenderParams renderParams)
	{
		DrawingVisual target = new DrawingVisual();
		DrawBezierPath(path, target, renderParams);
		return ToBitmap(target, renderParams);
	}

	public static RenderedBitmapHandle[] DrawBezierPathSegmented(BezierPath path, BezierPathRenderParams renderParams)
	{
		DrawingVisual drawingVisual = new DrawingVisual();
		bool flag = false;
		if (path is ClosedBezierPath closedBezierPath)
		{
			flag = closedBezierPath.TextScroller.ScrollDirection.IsVertical();
			using DrawingContext dc = drawingVisual.RenderOpen();
			Vector2<double>? textSize = null;
			if (flag)
			{
				textSize = new Vector2<double>(closedBezierPath.Size.X, double.PositiveInfinity);
			}
			else if (closedBezierPath.DisplayText.Settings.Transform.TransformsLineReturns())
			{
				textSize = new Vector2<double>(double.PositiveInfinity, closedBezierPath.Size.Y);
			}
			DrawText(dc, closedBezierPath, closedBezierPath.DisplayText, renderParams, textSize, constantSize: true);
		}
		return drawingVisual.ToSegments(flag);
	}

	private static RenderedBitmapHandle DrawBezierPath(BezierPath path, RenderingMode renderMode)
	{
		DrawingVisual target = new DrawingVisual();
		BezierPathRenderParams renderParams = new BezierPathRenderParams(includeText: true, highlight: false, includeRotation: false, includePosition: false, includeTextPlaceholder: false, 1.0, useFullsizeMedia: false, renderMode);
		DrawBezierPath(path, target, renderParams);
		return ToBitmap(target, renderParams);
	}

	private static RenderedBitmapHandle ToBitmap(DrawingVisual target, BezierPathRenderParams renderParams)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int num2 = 0;
		Vector2<double> vector = new Vector2<double>(-2.0);
		Rect contentBounds = target.ContentBounds;
		if (!((Rect)(ref contentBounds)).IsEmpty)
		{
			num = (int)Math.Ceiling(((Rect)(ref contentBounds)).Width);
			num2 = (int)Math.Ceiling(((Rect)(ref contentBounds)).Height);
			vector += (Vector2<double>)((Rect)(ref contentBounds)).TopLeft;
		}
		DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap(num + 4, num2 + 4, 96.0, 96.0, PixelFormat);
		Vector offset = target.Offset;
		target.Offset = -vector;
		disposableRenderTargetBitmap.Render(target);
		disposableRenderTargetBitmap.Freeze();
		target.Offset = offset;
		return new RenderedBitmapHandle(vector, new Vector2<double>(num + 2, num2 + 2), disposableRenderTargetBitmap);
	}

	private static RenderedBitmapHandle[] ToSegments(this DrawingVisual target, bool isVertical)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals13.target = target;
		CS_0024_003C_003E8__locals13.pixelWidth = 0;
		CS_0024_003C_003E8__locals13.pixelHeight = 0;
		CS_0024_003C_003E8__locals13.segmentSize = 512;
		CS_0024_003C_003E8__locals13.mainOffset = Vector2<double>.Zero;
		Rect contentBounds = CS_0024_003C_003E8__locals13.target.ContentBounds;
		if (!((Rect)(ref contentBounds)).IsEmpty)
		{
			CS_0024_003C_003E8__locals13.pixelWidth = (int)Math.Ceiling(((Rect)(ref contentBounds)).Width);
			CS_0024_003C_003E8__locals13.pixelHeight = (int)Math.Ceiling(((Rect)(ref contentBounds)).Height);
			CS_0024_003C_003E8__locals13.mainOffset += (Vector2<double>)((Rect)(ref contentBounds)).TopLeft;
		}
		CS_0024_003C_003E8__locals13.target.Offset = CS_0024_003C_003E8__locals13.mainOffset;
		return (isVertical ? GetVerticalSegments() : GetHorizontalSegments()).ToArray();
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass20_0._003C_003CToSegments_003Eg__GetHorizontalSegments_007C0_003Ed))]
		IEnumerable<RenderedBitmapHandle> GetHorizontalSegments()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass20_0._003C_003CToSegments_003Eg__GetHorizontalSegments_007C0_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals13
			};
		}
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass20_0._003C_003CToSegments_003Eg__GetVerticalSegments_007C1_003Ed))]
		IEnumerable<RenderedBitmapHandle> GetVerticalSegments()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass20_0._003C_003CToSegments_003Eg__GetVerticalSegments_007C1_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals13
			};
		}
	}

	private static RenderedBitmapHandle GetSegmentBitmap(DrawingVisual target, Vector2<double> offset, int segmentWidth, int segmentHeight)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap(segmentWidth, segmentHeight, 96.0, 96.0, PixelFormat);
		target.Offset = -offset;
		disposableRenderTargetBitmap.Render(target);
		disposableRenderTargetBitmap.Freeze();
		return new RenderedBitmapHandle(offset, new Vector2<double>(segmentWidth, segmentHeight), disposableRenderTargetBitmap);
	}

	private static void DrawClosedPath(ClosedBezierPath path, DrawingContext dc, BezierPathRenderParams renderParams)
	{
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		bool hasText = path.DisplayText.HasText;
		bool flag = hasText && renderParams.IncludeText;
		bool flag2 = !flag && !hasText && renderParams.IncludeTextPlaceholder && !path.IsInlineEditActive && (path.AdditionalInfo.HasFlag(AdditionalInfo.Text) || (path.TextLink.LinkedObject?.SupportsPlaceholderText ?? false));
		Brush brush = null;
		TextDocument textDocument = path.DisplayText;
		if (flag)
		{
			if (renderParams.RenderingMode.IsOutputMode() && path.RevealType != 0)
			{
				textDocument = path.Text;
			}
		}
		else if (flag2)
		{
			textDocument = textDocument.Clone();
			textDocument.InsertText(0, LocalizedStrings.Get("EDITOR_SHAPE_DEFAULT_TEXT_placeholder"));
		}
		if (hasText && renderParams.RenderingMode.IsOutputMode() && !renderParams.RenderingMode.IsTextOnlyMode())
		{
			TextLayerInfo[] textLayers = GetTextLayers(textDocument, path.Size, path.RevealType, path.ChildBuilds.Select((ChildBuild b) => b.Range).ToArray(), !DoesPathRequireLayers(path));
			if (textLayers.Any(delegate(TextLayerInfo l)
			{
				TextFillBase? fill = l.Fill;
				return (object)fill != null && fill.TextFillType == TextFillType.CutOut;
			}))
			{
				ArrangedText cachedArrangedText = GetCachedArrangedText(textDocument, path.Size);
				if (cachedArrangedText != null)
				{
					DrawingVisual drawingVisual = new DrawingVisual();
					using (DrawingContext drawingContext = drawingVisual.RenderOpen())
					{
						drawingContext.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, new Rect<double>(path.Size));
						TextLayerInfo[] array = textLayers;
						foreach (TextLayerInfo textLayerInfo in array)
						{
							TextFillBase? fill2 = textLayerInfo.Fill;
							if ((object)fill2 == null || fill2.TextFillType != TextFillType.CutOut || textLayerInfo.Type != TextLayerType.Mask)
							{
								continue;
							}
							foreach (KeyValuePair<TextRenderOptions, Pro.Text.Range[]> range2 in textLayerInfo.Ranges)
							{
								range2.Deconstruct(out var key, out var value);
								TextRenderOptions textRenderOptions = key;
								value = value;
								foreach (Pro.Text.Range range in value)
								{
									cachedArrangedText.RenderText(drawingContext, new TextRenderParams(TextRenderOptions.MaskOnly | textRenderOptions, range, renderShadow: false, renderFill: true, renderStroke: true, renderLines: true, useStandardMaskBrush: true));
								}
							}
						}
					}
					drawingVisual.Effect = new InvertEffect
					{
						InvertRGB = false,
						InvertTransparency = true
					};
					brush = new VisualBrush(drawingVisual)
					{
						Stretch = Stretch.None
					};
				}
				else
				{
					Log.Warning("Failed to generate an element fill mask due to failure in getting arranged text");
				}
			}
		}
		System.Windows.Media.Geometry geometry = BezierPathHelper.GenerateClosedPathGeometry(path);
		CombinedGeometry maskGeometry = GetMaskGeometry(path, textDocument, geometry);
		DrawingParams drawingParams = new DrawingParams(geometry, maskGeometry, brush, path, _drawers, renderParams.UseFullSizeMedia, renderParams.RenderingMode);
		if (renderParams.RenderingMode == RenderingMode.OutputStageFlash)
		{
			ILinkedTextObject linkedObject = path.TextLink.LinkedObject;
			if (linkedObject != null)
			{
				((path.TextLink.LinkedObject != null) ? (_drawers.GetTextLinkDrawer(path.TextLink.LinkedObject.LinkedTextType) as StageMessageDrawer) : null)?.Draw(dc, renderParams.RenderingMode, linkedObject, drawingParams);
				return;
			}
		}
		if (renderParams.Highlight)
		{
			dc.DrawGeometry(HighlightBrush, null, geometry);
		}
		else if (!renderParams.RenderingMode.IsTextOnlyMode())
		{
			IFill fill3 = path.Fill;
			IShadow shadow = path.Shadow;
			IStroke stroke = path.Stroke;
			IFeather feather = path.Feather;
			TextLink textLink = path.TextLink;
			FillLink fillLink = path.FillLink;
			IDrawer<IFill> fillDrawer = _drawers.GetFillDrawer(fill3.Type);
			IDrawer<IShadow> shadowDrawer = _drawers.GetShadowDrawer(shadow.Type);
			IDrawer<IStroke> strokeDrawer = _drawers.GetStrokeDrawer(stroke.Type);
			IDrawer<IFeather> featherDrawer = _drawers.GetFeatherDrawer(feather.Type);
			IDrawer<ILinkedTextObject> drawer = ((textLink.LinkedObject != null) ? _drawers.GetTextLinkDrawer(textLink.LinkedObject.LinkedTextType) : null);
			IDrawer<ILinkedFillObject> drawer2 = ((fillLink.LinkedObject != null) ? _drawers.GetFillLinkDrawer(fillLink.LinkedObject.LinkedFillType) : null);
			IDrawer<MiscellaneousDrawerType> miscellaneousDrawer = _drawers.GetMiscellaneousDrawer(MiscellaneousDrawerType.LinkInfo);
			bool flag3 = featherDrawer != null && feather.IsEnabled && feather.Radius > 0.0;
			if (shadowDrawer != null && shadow.IsEnabled && (fill3.Type != FillType.HTML || renderParams.RenderingMode != RenderingMode.Preview))
			{
				shadowDrawer.Draw(dc, renderParams.RenderingMode, shadow, drawingParams);
			}
			if (flag3)
			{
				featherDrawer.Draw(dc, renderParams.RenderingMode, feather, drawingParams);
			}
			if (renderParams.RenderingMode == RenderingMode.Editor || flag3)
			{
				dc.DrawGeometry(System.Windows.Media.Brushes.Transparent, null, geometry);
			}
			if (maskGeometry != null)
			{
				dc.PushClip(maskGeometry);
			}
			if (brush != null)
			{
				dc.PushOpacityMask(brush);
			}
			if (drawer2 != null && fill3.IsEnabled && !path.IsLinkedDataResolved && fillLink.LinkedObject != null)
			{
				drawer2.Draw(dc, renderParams.RenderingMode, fillLink.LinkedObject, drawingParams);
			}
			else if (fillDrawer != null && fill3.IsEnabled)
			{
				fillDrawer.Draw(dc, renderParams.RenderingMode, fill3, drawingParams);
			}
			if (brush != null)
			{
				dc.Pop();
			}
			if (strokeDrawer != null && stroke.IsEnabled)
			{
				strokeDrawer.Draw(dc, renderParams.RenderingMode, stroke, drawingParams);
			}
			if (maskGeometry != null)
			{
				dc.Pop();
				if (renderParams.RenderingMode == RenderingMode.OutputContentMask)
				{
					dc.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, geometry.Bounds);
				}
			}
			if (flag3)
			{
				dc.Pop();
			}
			if (miscellaneousDrawer != null && renderParams.IncludeLinkIndicator)
			{
				miscellaneousDrawer.Draw(dc, renderParams.RenderingMode, MiscellaneousDrawerType.LinkInfo, drawingParams);
			}
			if (drawer != null && textLink.IsEnabled && !path.IsLinkedDataResolved && textLink.LinkedObject != null)
			{
				drawer.Draw(dc, renderParams.RenderingMode, textLink.LinkedObject, drawingParams);
			}
		}
		Vector2<double>? textSize;
		int num;
		if (flag)
		{
			if (!renderParams.RenderingMode.IsOutputMode() || !path.TextScroller.ShouldScrollText || renderParams.RenderingMode == RenderingMode.OutputSegment)
			{
				textSize = null;
				if (path.TextScroller.ShouldScrollText)
				{
					if (!path.TextScroller.ScrollDirection.IsVertical())
					{
						num = (path.DisplayText.Settings.Transform.TransformsLineReturns() ? 1 : 0);
						if (num == 0)
						{
							goto IL_06c4;
						}
					}
					else
					{
						num = 1;
					}
					dc.PushClip(new RectangleGeometry(new Rect<double>(path.Size)));
					if (!path.TextScroller.ScrollDirection.IsVertical() && path.DisplayText.Settings.Transform.TransformsLineReturns())
					{
						textSize = new Vector2<double>(double.PositiveInfinity, path.Size.Y);
					}
				}
				else
				{
					num = 0;
				}
				goto IL_06c4;
			}
		}
		else if (flag2)
		{
			DrawText(dc, path, textDocument, renderParams, null);
		}
		goto IL_06f3;
		IL_06f3:
		if (path.TextLink.IsEnabled && renderParams.RenderingMode == RenderingMode.OutputTextLayer)
		{
			dc.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, new Rect<double>(Vector2<double>.Zero, path.Size));
		}
		return;
		IL_06c4:
		DrawText(dc, path, textDocument, renderParams, textSize);
		if (num != 0)
		{
			dc.Pop();
		}
		goto IL_06f3;
	}

	private static CombinedGeometry? GetMaskGeometry(ClosedBezierPath path, TextDocument renderTextDocument, System.Windows.Media.Geometry geometry)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		LineFillMask lineFillMask = path.LineFillMask;
		if (!lineFillMask.IsEnabled)
		{
			return null;
		}
		ArrangedText cachedArrangedText = GetCachedArrangedText(renderTextDocument, path.Size.Abs());
		if (cachedArrangedText == null)
		{
			Log.Warning("Failed to generate mask geometry for an element due to failure in getting arranged text");
			return null;
		}
		GeometryGroup lineGroup = new GeometryGroup
		{
			FillRule = FillRule.Nonzero
		};
		if (lineFillMask.MaskStyle != LineMaskStyle.MaxLineWidth)
		{
			Rect bounds2 = geometry.Bounds;
			double maxWidth = ((Rect)(ref bounds2)).Width;
			cachedArrangedText.IterateLines(delegate(ParagraphAlignment alignment, Rect<double> bounds, bool hasNonWhitespaceCharacters)
			{
				if (hasNonWhitespaceCharacters)
				{
					if (lineFillMask.MaskStyle == LineMaskStyle.FullWidth)
					{
						bounds.Left = 0.0;
						bounds.Width = maxWidth;
					}
					addLineMask(bounds);
				}
			});
		}
		else
		{
			double maxLineWidth = 0.0;
			cachedArrangedText.IterateLines(delegate(ParagraphAlignment alignment, Rect<double> bounds, bool hasNonWhitespaceCharacters)
			{
				if (hasNonWhitespaceCharacters)
				{
					maxLineWidth = Math.Max(maxLineWidth, bounds.Width);
				}
			});
			cachedArrangedText.IterateLines(delegate(ParagraphAlignment alignment, Rect<double> bounds, bool hasNonWhitespaceCharacters)
			{
				if (hasNonWhitespaceCharacters)
				{
					if (bounds.Width < maxLineWidth)
					{
						switch (alignment)
						{
						case ParagraphAlignment.Right:
							bounds.Left -= maxLineWidth - bounds.Width;
							break;
						case ParagraphAlignment.Center:
						case ParagraphAlignment.Justified:
							bounds.Left -= (maxLineWidth - bounds.Width) / 2.0;
							break;
						}
						bounds.Width = maxLineWidth;
					}
					addLineMask(bounds);
				}
			});
		}
		return new CombinedGeometry(GeometryCombineMode.Intersect, geometry, lineGroup);
		void addLineMask(Rect<double> bounds)
		{
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			bounds.Top += lineFillMask.VerticalOffset - lineFillMask.HeightOffset / 2.0;
			bounds.Height += lineFillMask.HeightOffset;
			if (lineFillMask.MaskStyle != 0)
			{
				bounds.Left += lineFillMask.HorizontalOffset - lineFillMask.WidthOffset / 2.0;
				bounds.Width += lineFillMask.WidthOffset;
			}
			lineGroup.Children.Add(new RectangleGeometry(bounds));
		}
	}

	private static void DrawOpenPath(BezierPath path, DrawingContext dc, BezierPathRenderParams renderParams)
	{
		if (path.Points.Length != 0)
		{
			DrawingParams drawingParams = new DrawingParams(BezierPathHelper.GenerateOpenPathGeometry(path), null, null, path, _drawers, useFullSizeMedia: false, renderParams.RenderingMode);
			IDrawer<IShadow> shadowDrawer = _drawers.GetShadowDrawer(path.Shadow.Type);
			IDrawer<IStroke> strokeDrawer = _drawers.GetStrokeDrawer(path.Stroke.Type);
			if (shadowDrawer != null && path.Shadow.IsEnabled)
			{
				shadowDrawer.Draw(dc, renderParams.RenderingMode, path.Shadow, drawingParams);
			}
			if (strokeDrawer != null && path.Stroke.IsEnabled)
			{
				strokeDrawer.Draw(dc, renderParams.RenderingMode, path.Stroke, drawingParams);
			}
		}
	}

	private static void DrawText(DrawingContext dc, ClosedBezierPath path, TextDocument document, BezierPathRenderParams renderParams, Vector2<double>? textSize = null, bool constantSize = false)
	{
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> rect = new Rect<double>(Vector2<double>.Zero, textSize ?? path.Size).Abs();
		TextLayerInfo[] array = null;
		if (renderParams.RenderingMode.IsOutputMode())
		{
			if (renderParams.RenderingMode != 0 && renderParams.RenderingMode != RenderingMode.OutputOver && renderParams.RenderingMode != RenderingMode.OutputUnder && renderParams.RenderingMode != RenderingMode.OutputSegment && renderParams.RenderingMode != RenderingMode.OutputTextLayer)
			{
				return;
			}
			array = GetTextLayers(document, rect.Size, path.RevealType, path.ChildBuilds.Select((ChildBuild b) => b.Range).ToArray(), !DoesPathRequireLayers(path));
		}
		dc.PushTransform(new TranslateTransform(rect.Left, rect.Top));
		ArrangedText cachedArrangedText = GetCachedArrangedText(document, rect.Size);
		if (cachedArrangedText == null)
		{
			Log.Warning("Failed to draw text for an element due to failure in getting arranged text");
			return;
		}
		if (constantSize)
		{
			Rect<double> rect2 = new Rect<double>(cachedArrangedText.RenderBounds.Position.Floor(), cachedArrangedText.RenderBounds.Size.Ceiling());
			Vector2<double> position = rect2.Position - rect2.Position.Mod(5.0);
			Vector2<double> size = rect2.Size + rect2.Size.Mod(5.0);
			dc.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, new Rect<double>(position, size));
		}
		if (renderParams.RenderingMode == RenderingMode.OutputTextLayer && array != null && array.Any())
		{
			TextLayerInfo textLayerInfo = array?.ElementAtOrDefault(renderParams.TextIndex) ?? new TextLayerInfo(Pro.Text.Range.All, TextLayerType.Composite, null, -1);
			TextFillBase? fill2 = textLayerInfo.Fill;
			if ((object)fill2 != null && fill2.TextFillType == TextFillType.CutOut)
			{
				dc.Pop();
				return;
			}
			foreach (KeyValuePair<TextRenderOptions, Pro.Text.Range[]> range2 in textLayerInfo.Ranges)
			{
				range2.Deconstruct(out var key, out var value);
				TextRenderOptions textRenderOptions = key;
				value = value;
				foreach (Pro.Text.Range range in value)
				{
					cachedArrangedText.RenderText(dc, textLayerInfo.Type switch
					{
						TextLayerType.Composite => new TextRenderParams(textRenderOptions, range), 
						TextLayerType.Mask => new TextRenderParams(TextRenderOptions.MaskOnly | textRenderOptions, range, renderShadow: false, renderFill: true, renderStroke: true, renderLines: true, useStandardMaskBrush: true), 
						TextLayerType.Over => new TextRenderParams(TextRenderOptions.NoMask | textRenderOptions, range, renderShadow: false, renderFill: false), 
						TextLayerType.Under => new TextRenderParams(TextRenderOptions.None | textRenderOptions, range), 
						_ => TextRenderParams.Default, 
					});
				}
			}
		}
		else if (!renderParams.RenderingMode.IsOutputMode() || renderParams.RenderingMode == RenderingMode.OutputSegment || (renderParams.RenderingMode.IsAnyOf(RenderingMode.OutputComposite, RenderingMode.OutputUnder) && array != null && !array.Any() && document.HasText))
		{
			List<(Pro.Text.Range range, bool renderFill)> ranges = new List<(Pro.Text.Range, bool)>();
			bool hasNonShadowCastingRanges = false;
			cachedArrangedText.FindCharacterFillRanges(Pro.Text.Range.All, delegate(Pro.Text.Range subRange, bool isMask, TextFillBase fill)
			{
				bool flag = fill.TextFillType != TextFillType.CutOut;
				ranges.Add((subRange, flag));
				if (!flag)
				{
					hasNonShadowCastingRanges = true;
				}
			});
			if (hasNonShadowCastingRanges)
			{
				foreach (var item in ranges)
				{
					cachedArrangedText.RenderText(dc, new TextRenderParams(TextRenderOptions.None, item.range, renderShadow: true, item.renderFill));
				}
				cachedArrangedText.RenderText(dc, new TextRenderParams(null, null, null, null, renderShadow: false, renderFill: true, useStandardMaskBrush: false, NonOutputTextMaskBrush, translateOverrideMaskBrush: true, null));
			}
			else
			{
				Brush? nonOutputTextMaskBrush = NonOutputTextMaskBrush;
				bool useFullSizeMedia = renderParams.UseFullSizeMedia;
				cachedArrangedText.RenderText(dc, new TextRenderParams(null, null, null, null, renderShadow: true, renderFill: true, useStandardMaskBrush: false, nonOutputTextMaskBrush, translateOverrideMaskBrush: true, null, useFullSizeMedia));
			}
		}
		dc.Pop();
	}

	public static bool DoesPathRequireLayers(ClosedBezierPath path)
	{
		if (!(path?.TextLink?.LinkedObject is StageMessageLinkedObject { ShouldFlash: not false }))
		{
			return DoesFillRequireLayers(path?.Fill);
		}
		return true;
	}

	public static bool DoesFillRequireLayers(IFill? fill)
	{
		if ((fill == null || fill.IsEnabled) && (fill == null || fill.Type != FillType.Media) && (fill == null || fill.Type != FillType.Live) && (fill == null || fill.Type != FillType.OutputScreen) && (fill == null || fill.Type != FillType.BackgroundEffectBlur))
		{
			if (fill == null)
			{
				return false;
			}
			return fill.Type == FillType.BackgroundEffectInvert;
		}
		return true;
	}

	public static TextLayerInfo[] GetTextLayers(TextDocument document, Vector2<double> size, RevealType revealType, Pro.Text.Range[] buildRanges, bool skipIfCompositingIsPossible)
	{
		CachedTextLayers cachedTextLayers = _textLayersCache.Get(new TextDocumentKey(document, size, revealType, buildRanges, skipIfCompositingIsPossible));
		lock (cachedTextLayers)
		{
			TextLayerInfo[] textLayers = cachedTextLayers.TextLayers;
			if (!cachedTextLayers.IsValid || textLayers == null)
			{
				textLayers = BuildTextLayers(cachedTextLayers.Document, size, revealType, buildRanges);
				if (skipIfCompositingIsPossible && textLayers != null && !textLayers.Any((TextLayerInfo l) => l.BuildIndex >= 0 || (l.Type == TextLayerType.Mask && l.Fill != null)))
				{
					textLayers = Array.Empty<TextLayerInfo>();
				}
				cachedTextLayers.Document = null;
				cachedTextLayers.TextLayers = textLayers;
				cachedTextLayers.IsValid = true;
			}
			return cachedTextLayers.TextLayers ?? Array.Empty<TextLayerInfo>();
		}
	}

	private static TextLayerInfo[] BuildTextLayers(TextDocument? document, Vector2<double> size, RevealType revealType, Pro.Text.Range[] buildRanges)
	{
		if ((object)document == null || !document.HasText)
		{
			return Array.Empty<TextLayerInfo>();
		}
		ArrangedText cachedArrangedText = GetCachedArrangedText(document, size);
		if (cachedArrangedText == null)
		{
			Log.Warning("Failed to build text layers for a document due to failure in getting arranged text");
			return Array.Empty<TextLayerInfo>();
		}
		return CleanupTextLayers(GenerateTextLayers(cachedArrangedText, document.LastCharacterIndex, revealType, buildRanges));
	}

	private static List<TextLayerInfo> GenerateTextLayers(ArrangedText arrangedText, int lastCharacterIndex, RevealType revealType, Pro.Text.Range[] buildRanges)
	{
		List<TextLayerInfo> layers = new List<TextLayerInfo>();
		if (revealType == RevealType.None || buildRanges == null || buildRanges.Empty())
		{
			if (!arrangedText.HasMaskRanges())
			{
				layers.Add(new TextLayerInfo(new Pro.Text.Range(0, lastCharacterIndex), TextLayerType.Composite, null, -1));
			}
			else
			{
				breakRangeIntoLayers(new Pro.Text.Range(0, lastCharacterIndex));
			}
		}
		else
		{
			switch (revealType)
			{
			case RevealType.Bullet:
			{
				int num3 = 0;
				breakRangeIntoLayers(new Pro.Text.Range(0, buildRanges[0].Start));
				foreach (Pro.Text.Range item in buildRanges.Distinct())
				{
					breakRangeIntoLayers(item, num3++);
				}
				break;
			}
			case RevealType.Underline:
			{
				int num = 0;
				int num2 = 0;
				foreach (Pro.Text.Range item2 in buildRanges.Distinct())
				{
					breakRangeIntoLayers(new Pro.Text.Range(num2, item2.Start));
					breakRangeIntoLayers(item2, -1, TextRenderOptions.UnderlineOnly);
					breakRangeIntoLayers(item2, num++, TextRenderOptions.NoUnderline);
					num2 = item2.End;
				}
				if (num2 != lastCharacterIndex)
				{
					breakRangeIntoLayers(new Pro.Text.Range(num2, lastCharacterIndex));
				}
				break;
			}
			}
		}
		return layers;
		void breakRangeIntoLayers(Pro.Text.Range range, int buildIndex = -1, TextRenderOptions flags = TextRenderOptions.None)
		{
			if (!flags.HasFlag(TextRenderOptions.UnderlineOnly))
			{
				bool hasShadow = arrangedText.HasShadow;
				if (hasShadow)
				{
					layers.Add(new TextLayerInfo(range, flags, TextLayerType.Under, null, buildIndex));
				}
				arrangedText.FindCharacterFillRanges(range, delegate(Pro.Text.Range subRange, bool isMask, TextFillBase fill)
				{
					rangeHandler(subRange, isMask, fill, TextLayerType.Under, hasShadow);
				});
				arrangedText.FindStrikethroughFillRanges(range, delegate(Pro.Text.Range subRange, bool isMask, TextFillBase fill)
				{
					rangeHandler(subRange, isMask, fill, TextLayerType.Over);
				});
				if (!hasShadow)
				{
					arrangedText.FindHighlightColorRanges(range, delegate(Pro.Text.Range subRange, Color color)
					{
						layers.Add(new TextLayerInfo(subRange, flags, TextLayerType.Under, null, buildIndex));
					});
				}
				arrangedText.FindStrokeColorRanges(range, delegate(Pro.Text.Range subRange, Color color)
				{
					layers.Add(new TextLayerInfo(subRange, flags, TextLayerType.Over, null, buildIndex));
				});
			}
			if (!flags.HasFlag(TextRenderOptions.NoUnderline))
			{
				arrangedText.FindUnderlineFillRanges(range, delegate(Pro.Text.Range subRange, bool isMask, TextFillBase fill)
				{
					rangeHandler(subRange, isMask, fill, TextLayerType.Over);
					if (arrangedText.HasShadow)
					{
						rangeHandler(subRange, isMask: false, fill, TextLayerType.Under);
					}
				});
			}
			void rangeHandler(Pro.Text.Range subRange, bool isMask, TextFillBase fill, TextLayerType nonMaskLayerType, bool skipNonMaskLayer = false)
			{
				if (isMask)
				{
					layers.Add(new TextLayerInfo(subRange, flags, TextLayerType.Mask, fill, buildIndex));
				}
				else if (!skipNonMaskLayer)
				{
					layers.Add(new TextLayerInfo(subRange, flags, nonMaskLayerType, null, buildIndex));
				}
			}
		}
	}

	private static TextLayerInfo[] CleanupTextLayers(List<TextLayerInfo> layers)
	{
		for (int i = 0; i < layers.Count; i++)
		{
			TextLayerInfo textLayerInfo = layers[i];
			Dictionary<TextRenderOptions, List<Pro.Text.Range>> combinedRanges = null;
			int num = i + 1;
			while (num < layers.Count)
			{
				TextLayerInfo textLayerInfo2 = layers[num];
				if (textLayerInfo.Type == textLayerInfo2.Type && textLayerInfo.Fill == textLayerInfo2.Fill && textLayerInfo.BuildIndex == textLayerInfo2.BuildIndex)
				{
					layers.RemoveAt(num);
					if (combinedRanges == null)
					{
						combinedRanges = new Dictionary<TextRenderOptions, List<Pro.Text.Range>>();
					}
					storeRanges(textLayerInfo2);
				}
				else
				{
					num++;
				}
			}
			if (combinedRanges != null)
			{
				storeRanges(textLayerInfo);
				layers[i] = new TextLayerInfo(combinedRanges.ToDictionary<KeyValuePair<TextRenderOptions, List<Pro.Text.Range>>, TextRenderOptions, Pro.Text.Range[]>((KeyValuePair<TextRenderOptions, List<Pro.Text.Range>> kvp) => kvp.Key, (KeyValuePair<TextRenderOptions, List<Pro.Text.Range>> kvp) => kvp.Value.ToArray().Compact()), textLayerInfo.Type, textLayerInfo.Fill, textLayerInfo.BuildIndex);
			}
			void storeRanges(TextLayerInfo layer)
			{
				foreach (TextRenderOptions key in layer.Ranges.Keys)
				{
					if (!combinedRanges.TryGetValue(key, out List<Pro.Text.Range> value))
					{
						combinedRanges.Add(key, value = new List<Pro.Text.Range>());
					}
					value.AddRange(layer.Ranges[key]);
				}
			}
		}
		layers.Sort((TextLayerInfo a, TextLayerInfo b) => a.Type.CompareTo(b.Type));
		return layers.ToArray();
	}

	private static ArrangedText? GetCachedArrangedText(TextDocument document, Vector2<double> size)
	{
		if ((object)document == null)
		{
			Log.Warning("Attempted to retrieve arranged text for a null document");
			return null;
		}
		CachedArrangedText cachedArrangedText = _arrangedTextCache.Get(new TextDocumentKey(document, size, RevealType.None, null, skipIfCompositingIsPossible: false));
		if (cachedArrangedText == null)
		{
			Log.Warning("Failed to get an arranged text cache entry for a document");
			return null;
		}
		lock (cachedArrangedText)
		{
			ArrangedText arrangedText = cachedArrangedText.ArrangedText;
			if (!cachedArrangedText.IsValid || arrangedText == null)
			{
				arrangedText = new ArrangedText(SharedTypefaceLibrary.Library)
				{
					Document = cachedArrangedText.Document,
					MaxSize = size,
					RenderAnnotations = (cachedArrangedText.Document?.Settings.ChordPro.Enabled ?? false)
				};
				cachedArrangedText.Document = null;
				arrangedText.Freeze();
				cachedArrangedText.ArrangedText = arrangedText;
				cachedArrangedText.IsValid = true;
			}
			return cachedArrangedText.ArrangedText;
		}
	}
}
