using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Themes;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.OutputConfiguration;

public class ScreenGridSelector : UserControl
{
	public enum SelectionMode
	{
		None,
		Screen,
		Blend
	}

	private class RectGroup
	{
		public Rect<double> RenderRect { get; }

		public Rect<double> HitTestRect { get; }

		public RectGroup(Rect<double> renderRect, Rect<double> hitTestRect)
		{
			RenderRect = renderRect;
			HitTestRect = hitTestRect.Pad(1.0);
		}
	}

	private struct RectAdjustment
	{
		public double Left { get; set; }

		public double Right { get; set; }
	}

	private sealed class NamedRectangle
	{
		public Rect<double> Rectangle { get; }

		public string Name { get; }

		public NamedRectangle(Rect<double> rectangle, string name)
		{
			Rectangle = rectangle;
			Name = name;
		}
	}

	private static readonly Vector2<double> RenderPadding = new Vector2<double>(15.0);

	private static readonly Vector2<double> ScreenLabelOffset = new Vector2<double>(0.0, 10.0);

	private const double SubrectOffset = 10.0;

	private const double SubrectScalarRelativeToRect = 0.3;

	private const double MirroredScreenSpacing = 80.0;

	private const double MinEdgeBlendWidth = 20.0;

	private const double RectBorderThickness = 2.0;

	private static readonly Pen RectBorderHighlightPen = new Pen(System.Windows.Media.Brushes.White, 2.0);

	private static readonly Pen RectBorderSelectedPen = new Pen(AppTheme.Active.SECONDARY, 2.0);

	private static readonly Color BlendFillCenterColor = Color.FromArgb(205, 211, 211, 211);

	private static readonly Brush CornerPinFillBrush = new SolidColorBrush(Color.FromArgb(180, 60, 109, 250));

	private static readonly Brush SubrectOutputFillBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 70, 70, 70));

	private static readonly Brush SubrectSubFillBrush = System.Windows.Media.Brushes.LightGray;

	private static readonly Pen SubrectBorderPen = new Pen(System.Windows.Media.Brushes.Black, 1.0);

	private bool _updateInProgress;

	private readonly Dictionary<Screen, RectGroup> _screenRects = new Dictionary<Screen, RectGroup>();

	private readonly Dictionary<EdgeBlendOptions, RectGroup> _blendRects = new Dictionary<EdgeBlendOptions, RectGroup>();

	private Rect<double>? _highlightedRect;

	public static readonly DependencyProperty ScreenArrangementProperty = DependencyProperty.Register("ScreenArrangement", typeof(ScreenArrangementBase), typeof(ScreenGridSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ScreenArrangementPropertyChanged)));

	public static readonly DependencyProperty ActiveSelectionModeProperty = DependencyProperty.Register("ActiveSelectionMode", typeof(SelectionMode), typeof(ScreenGridSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SelectionMode.None, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty SelectedScreenProperty = DependencyProperty.Register("SelectedScreen", typeof(Screen), typeof(ScreenGridSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SelectedScreenPropertyChanged)));

	public static readonly DependencyProperty SelectedBlendProperty = DependencyProperty.Register("SelectedBlend", typeof(EdgeBlendOptions), typeof(ScreenGridSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SelectedBlendPropertyChanged)));

	public static readonly DependencyProperty ShowCornerPinningProperty = DependencyProperty.Register("ShowCornerPinning", typeof(bool), typeof(ScreenGridSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(ScreenGridSelector), new PropertyMetadata((object)default(Color)));

	public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Color), typeof(ScreenGridSelector), new PropertyMetadata((object)default(Color)));

	public static readonly DependencyProperty TextBrushProperty = DependencyProperty.Register("TextColor", typeof(Color), typeof(ScreenGridSelector), new PropertyMetadata((object)default(Color)));

	public static readonly DependencyProperty RectFillColorProperty = DependencyProperty.Register("RectFillColor", typeof(Color), typeof(ScreenGridSelector), new PropertyMetadata((object)default(Color)));

	private Rect<double>? HighlightedRect
	{
		get
		{
			return _highlightedRect;
		}
		set
		{
			if (_highlightedRect != value)
			{
				_highlightedRect = value;
				InvalidateVisual();
			}
		}
	}

	public ScreenArrangementBase? ScreenArrangement
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(ScreenArrangementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenArrangementProperty, (object)value);
		}
	}

	public SelectionMode ActiveSelectionMode
	{
		get
		{
			return (SelectionMode)((DependencyObject)this).GetValue(ActiveSelectionModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveSelectionModeProperty, (object)value);
		}
	}

	public Screen? SelectedScreen
	{
		get
		{
			return (Screen)((DependencyObject)this).GetValue(SelectedScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedScreenProperty, (object)value);
		}
	}

	public EdgeBlendOptions? SelectedBlend
	{
		get
		{
			return (EdgeBlendOptions)((DependencyObject)this).GetValue(SelectedBlendProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedBlendProperty, (object)value);
		}
	}

	public bool ShowCornerPinning
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowCornerPinningProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowCornerPinningProperty, (object)value);
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(BackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundColorProperty, (object)value);
		}
	}

	public Color BorderColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(BorderColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderColorProperty, (object)value);
		}
	}

	public Color TextColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(TextBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextBrushProperty, (object)value);
		}
	}

	public Color RectFillColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(RectFillColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RectFillColorProperty, (object)value);
		}
	}

	private static void ScreenArrangementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ScreenGridSelector)(object)d).OnScreenArrangementChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ScreenArrangementBase, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ScreenArrangementBase);
	}

	private static void SelectedScreenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ScreenGridSelector)(object)d).OnSelectedScreenChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as Screen, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Screen);
	}

	private static void SelectedBlendPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ScreenGridSelector)(object)d).OnSelectedBlendChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as EdgeBlendOptions, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as EdgeBlendOptions);
	}

	private void OnScreenArrangementChanged(ScreenArrangementBase? oldArrangement, ScreenArrangementBase? newArrangement)
	{
		if (oldArrangement != null)
		{
			oldArrangement.ArrangementChanged -= OnArrangementChanged;
			Screen[] screens = oldArrangement.Screens;
			for (int i = 0; i < screens.Length; i++)
			{
				screens[i].PropertyChanged -= OnActiveScreenPropertyChanged;
			}
		}
		if (newArrangement != null)
		{
			newArrangement.ArrangementChanged += OnArrangementChanged;
			Screen[] screens = newArrangement.Screens;
			for (int i = 0; i < screens.Length; i++)
			{
				screens[i].PropertyChanged += OnActiveScreenPropertyChanged;
			}
		}
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			if (newArrangement != null)
			{
				ActiveSelectionMode = SelectionMode.Screen;
				SelectedScreen = newArrangement.Screens.First();
				SelectedBlend = null;
				HighlightedRect = null;
			}
			else
			{
				ActiveSelectionMode = SelectionMode.None;
				SelectedScreen = null;
				SelectedBlend = null;
				HighlightedRect = null;
			}
			_updateInProgress = false;
		}
	}

	private void OnSelectedScreenChanged(Screen? oldScreen, Screen? newScreen)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			SelectedBlend = null;
			ActiveSelectionMode = SelectionMode.Screen;
			HighlightedRect = null;
			_updateInProgress = false;
		}
	}

	private void OnActiveScreenPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "OutputName" || e.PropertyName == "IsConfigured")
		{
			InvalidateVisual();
		}
	}

	private void OnSelectedBlendChanged(EdgeBlendOptions? oldBlend, EdgeBlendOptions? newBlend)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			SelectedScreen = null;
			ActiveSelectionMode = SelectionMode.Blend;
			HighlightedRect = null;
			_updateInProgress = false;
		}
	}

	private void OnArrangementChanged(ScreenArrangementBase arrangement)
	{
		InvalidateVisual();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		_screenRects.Clear();
		_blendRects.Clear();
		Rect<double> rect = new Rect<double>(0.0, 0.0, base.ActualWidth, base.ActualHeight);
		drawingContext.PushClip(new RectangleGeometry(rect));
		drawingContext.DrawRectangle(new SolidColorBrush(BackgroundColor), null, rect);
		if (ScreenArrangement == null)
		{
			return;
		}
		drawingContext.PushTransform(new TranslateTransform(RenderPadding.X, RenderPadding.Y));
		if (SelectedScreen != null && !ScreenArrangement.Screens.Contains<Screen>(SelectedScreen))
		{
			SelectedScreen = ScreenArrangement.Screens.Last();
		}
		IEnumerable<NamedRectangle> enumerable = Enumerable.Empty<NamedRectangle>();
		switch (ScreenArrangement.ArrangementType)
		{
		case ScreenArrangementType.Single:
		case ScreenArrangementType.Mirror:
			enumerable = DrawSingleArrangement(drawingContext, (SingleScreenArrangement)ScreenArrangement);
			break;
		case ScreenArrangementType.Group:
			enumerable = DrawCombinedArrangement(drawingContext, (CombinedScreenArrangement)ScreenArrangement);
			break;
		case ScreenArrangementType.EdgeBlend:
			enumerable = DrawBlendedArrangement(drawingContext, (EdgeBlendScreenArrangement)ScreenArrangement);
			break;
		}
		foreach (NamedRectangle item in enumerable)
		{
			drawingContext.DrawText(item.Name, item.Rectangle.TopLeft + ScreenLabelOffset, 14.0, new SolidColorBrush(TextColor), item.Rectangle.Size, TextAlignment.Center);
		}
		if (HighlightedRect.HasValue)
		{
			DrawRect(drawingContext, HighlightedRect.Value, null, RectBorderHighlightPen);
		}
	}

	private IEnumerable<NamedRectangle> DrawSingleArrangement(DrawingContext dc, SingleScreenArrangement arrangement)
	{
		Vector2<double> size = arrangement.Screens[0].Bounds.Size;
		int num = arrangement.Screens.Length;
		Vector2<double> size2 = new Vector2<double>(size.X * (double)num + 80.0 * (double)(num - 1), size.Y);
		Vector2<double> alignmentOffset;
		double renderTransform = GetRenderTransform(size2, out alignmentOffset);
		IEnumerable<NamedRectangle> enumerable = Enumerable.Empty<NamedRectangle>();
		for (int i = 0; i < num; i++)
		{
			Screen screen = arrangement.Screens[i];
			enumerable = enumerable.Concat(DrawScreen(dc, screen, new Rect<double>(new Vector2<double>(size.X * (double)i, 0.0), size), renderTransform, new Vector2<double>(80.0 * (double)i, 0.0), alignmentOffset));
		}
		DrawSelectedItem(dc);
		return enumerable;
	}

	private IEnumerable<NamedRectangle> DrawCombinedArrangement(DrawingContext dc, CombinedScreenArrangement arrangement)
	{
		return DrawArrangement(dc, arrangement);
	}

	private IEnumerable<NamedRectangle> DrawBlendedArrangement(DrawingContext dc, EdgeBlendScreenArrangement arrangement)
	{
		if (SelectedBlend != null && !arrangement.EdgeBlends.Contains<EdgeBlendOptions>(SelectedBlend))
		{
			SelectedBlend = arrangement.EdgeBlends.Last();
		}
		return DrawArrangement(dc, arrangement, delegate(int index, Screen screen)
		{
			getBlends(index, out var leftBlend2, out var rightBlend2);
			RectAdjustment result = default(RectAdjustment);
			result.Left = getHitTestInset(leftBlend2);
			result.Right = getHitTestInset(rightBlend2);
			return result;
		}, delegate(int index, Screen screen, double scalar)
		{
			getBlends(index, out var leftBlend3, out var rightBlend3);
			RectAdjustment result2 = default(RectAdjustment);
			result2.Left = getRenderOffset(leftBlend3);
			result2.Right = getRenderOffset(rightBlend3);
			return result2;
			double getRenderOffset(EdgeBlendOptions? blend)
			{
				if (blend != null)
				{
					return Math.Max(20.0 - blend.Width * scalar, 0.0) / 2.0;
				}
				return 0.0;
			}
		}, delegate(double scalar, Vector2<double> alignmentOffset)
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			LinearGradientBrush brush = new LinearGradientBrush
			{
				GradientStops = 
				{
					new GradientStop(RectFillColor, 0.0),
					new GradientStop(RectFillColor.Blend(BlendFillCenterColor), 0.5),
					new GradientStop(RectFillColor, 1.0)
				},
				StartPoint = Vector2<double>.Zero,
				EndPoint = new Vector2<double>(1.0, 0.0)
			};
			EdgeBlendOptions[] edgeBlends = arrangement.EdgeBlends;
			foreach (EdgeBlendOptions edgeBlendOptions in edgeBlends)
			{
				Rect<double> bounds = edgeBlendOptions.FirstScreen.Screen.Bounds;
				Rect<double> transformedRect = GetTransformedRect(new Rect<double>(bounds.Right - edgeBlendOptions.Width, 0.0, edgeBlendOptions.Width, bounds.Height), scalar, alignmentOffset);
				double num = Math.Max(20.0 - transformedRect.Width, 0.0);
				transformedRect.Width += num;
				transformedRect.Left -= num / 2.0;
				dc.DrawRectangle(brush, new Pen(new SolidColorBrush(BorderColor), 2.0), transformedRect.Pad(-1.0));
				_blendRects.Add(edgeBlendOptions, new RectGroup(transformedRect, transformedRect));
			}
		});
		void getBlends(int index, out EdgeBlendOptions? leftBlend, out EdgeBlendOptions? rightBlend)
		{
			leftBlend = ((index <= 0) ? null : arrangement.EdgeBlends[index - 1]);
			rightBlend = ((index >= arrangement.EdgeBlends.Length) ? null : arrangement.EdgeBlends[index]);
		}
		static double getHitTestInset(EdgeBlendOptions? blend)
		{
			if (blend == null)
			{
				return 0.0;
			}
			return blend.Width / 2.0;
		}
	}

	private IEnumerable<NamedRectangle> DrawArrangement(DrawingContext dc, ScreenArrangementBase arrangement, Func<int, Screen, RectAdjustment>? getHitTestInset = null, Func<int, Screen, double, RectAdjustment>? getRenderOffset = null, Action<double, Vector2<double>>? drawAdditional = null)
	{
		Vector2<double> alignmentOffset;
		double renderTransform = GetRenderTransform(arrangement.Screens.Select((Screen s) => s.Bounds).GetBoundingBox().Size, out alignmentOffset);
		IEnumerable<NamedRectangle> enumerable = Enumerable.Empty<NamedRectangle>();
		for (int i = 0; i < arrangement.Screens.Length; i++)
		{
			Screen screen = arrangement.Screens[i];
			enumerable = enumerable.Concat(DrawScreen(dc, screen, screen.Bounds, renderTransform, Vector2<double>.Zero, alignmentOffset, getHitTestInset?.Invoke(i, screen) ?? default(RectAdjustment), getRenderOffset?.Invoke(i, screen, renderTransform) ?? default(RectAdjustment)));
		}
		drawAdditional?.Invoke(renderTransform, alignmentOffset);
		DrawSelectedItem(dc);
		return enumerable;
	}

	private void DrawSelectedItem(DrawingContext dc)
	{
		if (ActiveSelectionMode == SelectionMode.Screen && SelectedScreen != null)
		{
			Rect<double> renderRect = _screenRects[SelectedScreen].RenderRect;
			ScreenArrangementBase? screenArrangement = ScreenArrangement;
			DrawRect(dc, renderRect, null, (screenArrangement != null && screenArrangement.Screens.Length == 1) ? null : RectBorderSelectedPen);
		}
		else if (ActiveSelectionMode == SelectionMode.Blend && SelectedBlend != null)
		{
			Rect<double> renderRect2 = _blendRects[SelectedBlend].RenderRect;
			ScreenArrangementBase? screenArrangement2 = ScreenArrangement;
			DrawRect(dc, renderRect2, null, (screenArrangement2 != null && screenArrangement2.Screens.Length == 1) ? null : RectBorderSelectedPen);
		}
	}

	private IEnumerable<NamedRectangle> DrawScreen(DrawingContext dc, Screen screen, Rect<double> bounds, double scalar, Vector2<double> screenOffset, Vector2<double> alignmentOffset, RectAdjustment hitTestInset = default(RectAdjustment), RectAdjustment renderOffset = default(RectAdjustment))
	{
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		hitTestInset.Left *= scalar;
		hitTestInset.Right *= scalar;
		Rect<double> screenRect = GetScreenRect(bounds, scalar, screenOffset, alignmentOffset);
		Rect<double> hitTestRect = new Rect<double>(screenRect.Position + new Vector2<double>(hitTestInset.Left, 0.0), screenRect.Size - new Vector2<double>(hitTestInset.Left + hitTestInset.Right, 0.0));
		Rect<double> rect = new Rect<double>(screenRect.Position - new Vector2<double>(renderOffset.Left, 0.0), screenRect.Size + new Vector2<double>(renderOffset.Left + renderOffset.Right, 0.0));
		NamedRectangle[] result;
		if (screen.GetAlphaKeyOutputDevice() == AlphaKeyOutputDevice.Other)
		{
			Vector2<double> size = new Vector2<double>(rect.Width / 2.0, rect.Height);
			Rect<double> rect2 = new Rect<double>(rect.TopLeft, size);
			Rect<double> rect3 = new Rect<double>(rect.TopCenter, size);
			Brush brush = ((Brush)FindResource(Pro.UI.Themes.Brushes.Checkerboard)).Clone();
			brush.Transform = new ScaleTransform(2.0, 2.0);
			DrawHardwareRectangle(dc, screen.MainOutput, rect2, new SolidColorBrush(RectFillColor));
			DrawHardwareRectangle(dc, screen.AlphaOutput, rect3, brush);
			result = new NamedRectangle[2]
			{
				new NamedRectangle(rect2, LocalizedStrings.Get("SCREEN_CONFIGURATION_PREVIEW_THUMBNAIL_FILL_NAME_label", new object[1] { screen.MainOutput.OutputName })),
				new NamedRectangle(rect3, LocalizedStrings.Get("SCREEN_CONFIGURATION_PREVIEW_THUMBNAIL_KEY_NAME_label", new object[1] { screen.AlphaOutput.OutputName }))
			};
		}
		else
		{
			DrawHardwareRectangle(dc, screen.MainOutput, rect, new SolidColorBrush(RectFillColor));
			result = new NamedRectangle[1]
			{
				new NamedRectangle(rect, screen.MainOutput.OutputName)
			};
		}
		if (ShowCornerPinning && screen.CornerPinning.IsEnabled && screen == SelectedScreen)
		{
			CornerPinningOptions cornerPinning = screen.CornerPinning;
			Vector2<double> vector = hitTestRect.TopLeft - cornerPinning.TopLeft * scalar;
			Vector2<double> vector2 = hitTestRect.TopRight - cornerPinning.TopRight.NegateX() * scalar;
			Vector2<double> vector3 = hitTestRect.BottomLeft - cornerPinning.BottomLeft.NegateY() * scalar;
			Vector2<double> vector4 = hitTestRect.BottomRight + cornerPinning.BottomRight * scalar;
			PathGeometry geometry = new PathGeometry(new PathFigure[1]
			{
				new PathFigure(vector, new LineSegment[3]
				{
					new LineSegment(vector2, isStroked: true),
					new LineSegment(vector4, isStroked: true),
					new LineSegment(vector3, isStroked: true)
				}, closed: true)
			});
			dc.DrawGeometry(CornerPinFillBrush, null, geometry);
		}
		DrawRect(dc, rect, null, new Pen(new SolidColorBrush(BorderColor), 2.0));
		_screenRects.Add(screen, new RectGroup(rect, hitTestRect));
		return result;
	}

	private void DrawHardwareRectangle(DrawingContext dc, HardwareScreenRectangleOptions rectangle, Rect<double> renderRect, Brush fillBrush)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		DrawRect(dc, renderRect, fillBrush, null);
		if (rectangle.SubrectTargetMode != 0)
		{
			Vector2<double> outputSize = rectangle.OutputSize;
			double num = GetScalar(renderRect.Size, outputSize) * 0.3;
			Rect<double> rect = new Rect<double>(Vector2<double>.Zero, outputSize * num);
			rect.Position = new Vector2<double>(renderRect.Center.X - rect.Center.X, renderRect.Bottom - rect.Height - 10.0);
			Rect<double> rect2 = new Rect<double>(rect.Position + rectangle.Subrect.Position * num, rectangle.Subrect.Size * num);
			dc.DrawRectangle(SubrectOutputFillBrush, SubrectBorderPen, rect);
			dc.PushClip(new RectangleGeometry(rect));
			dc.DrawRectangle(SubrectSubFillBrush, SubrectBorderPen, rect2);
			dc.Pop();
		}
	}

	private void DrawRect(DrawingContext dc, Rect<double> bounds, Brush? brush, Pen? pen)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		bounds = bounds.Pad(-1.0);
		dc.DrawRectangle(brush, pen, bounds);
	}

	private Rect<double> GetScreenRect(Rect<double> bounds, double scalar, Vector2<double> screenOffset, Vector2<double> alignmentOffset)
	{
		Rect<double> rect = bounds;
		rect.Position += screenOffset;
		return GetTransformedRect(rect, scalar, alignmentOffset);
	}

	private double GetRenderTransform(Vector2<double> size, out Vector2<double> alignmentOffset)
	{
		Vector2<double> vector = new Vector2<double>(base.ActualWidth - RenderPadding.X * 2.0, base.ActualHeight - RenderPadding.Y * 2.0);
		double scalar = GetScalar(vector, size);
		alignmentOffset = (vector - size * scalar) / 2.0;
		return scalar;
	}

	private double GetScalar(Vector2<double> parentSize, Vector2<double> childSize)
	{
		Vector2<double> vector = parentSize.ComponentwiseQuotient(childSize);
		return Math.Min(vector.X, vector.Y);
	}

	private Rect<double> GetTransformedRect(Rect<double> rect, double scalar, Vector2<double> alignmentOffset)
	{
		rect.Position = rect.Position * scalar + alignmentOffset;
		rect.Size *= scalar;
		return rect;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left)
		{
			UpdateSelectedItem((Vector2<double>)e.GetPosition(this));
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		UpdateHighlightedRect((Vector2<double>)e.GetPosition(this));
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		HighlightedRect = null;
	}

	private void UpdateSelectedItem(Vector2<double> mousePosition)
	{
		HitTestRects(mousePosition, delegate(Screen s, RectGroup r)
		{
			SelectedScreen = s;
		}, delegate(EdgeBlendOptions b, RectGroup r)
		{
			SelectedBlend = b;
		});
	}

	private void UpdateHighlightedRect(Vector2<double> mousePosition)
	{
		HighlightedRect = null;
		HitTestRects(mousePosition, delegate(Screen s, RectGroup r)
		{
			HighlightedRect = r.RenderRect;
		}, delegate(EdgeBlendOptions b, RectGroup r)
		{
			HighlightedRect = r.RenderRect;
		});
	}

	private void HitTestRects(Vector2<double> point, Action<Screen, RectGroup> screenHit, Action<EdgeBlendOptions, RectGroup> blendHit)
	{
		point -= RenderPadding;
		using (IEnumerator<KeyValuePair<EdgeBlendOptions, RectGroup>> enumerator = _blendRects.Where<KeyValuePair<EdgeBlendOptions, RectGroup>>((KeyValuePair<EdgeBlendOptions, RectGroup> bs) => bs.Key != SelectedBlend && bs.Value.HitTestRect.Contains(point)).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<EdgeBlendOptions, RectGroup> current = enumerator.Current;
				blendHit(current.Key, current.Value);
				return;
			}
		}
		using IEnumerator<KeyValuePair<Screen, RectGroup>> enumerator2 = _screenRects.Where<KeyValuePair<Screen, RectGroup>>((KeyValuePair<Screen, RectGroup> ss) => ss.Key != SelectedScreen && ss.Value.HitTestRect.Contains(point)).GetEnumerator();
		if (enumerator2.MoveNext())
		{
			KeyValuePair<Screen, RectGroup> current2 = enumerator2.Current;
			screenHit(current2.Key, current2.Value);
		}
	}
}
