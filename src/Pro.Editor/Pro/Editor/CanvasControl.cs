using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Controls;
using Pro.Editor.Canvas.Guidelines;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources;
using Pro.Editor.Canvas.TabStop;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Controls;
using Pro.UI.Utility;

namespace Pro.Editor;

public abstract class CanvasControl : FrameworkElement
{
	private const double DefaultPasteboardMultiplier = 1.2;

	private const double MaxZoomScale = 32.0;

	private const double MinZoomScale = 0.1;

	private const double MouseWheelBaseValue = 120.0;

	private const double ZoomScaleFactor = 1.05;

	private const double SmallMoveOffset = 1.0;

	private const double LargeMoveOffset = 10.0;

	private const double ScaleToFitMargin = 100.0;

	private static Color ParentGuidelineColor = Colors.Yellow;

	private readonly CanvasParent _parent;

	private readonly StaticSS _staticSS = new StaticSS();

	private bool _shouldAutoCenter = true;

	private SSLayer? _activeSSLayer;

	private ITransform? _currentTransform;

	private Matrix<double> _transformMatrix = Matrix<double>.Identity;

	private Vector2<double> _startDragPosition = Vector2<double>.Zero;

	private Vector2<double> _lastDragPosition = Vector2<double>.Zero;

	private ICanvasElement[]? _previousSelection;

	private ICanvasElement? _previousLevel;

	private bool _isPanning;

	private Vector2<double> _startMousePosition;

	private Vector2<double> _startScrollOffset;

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ZoomFactorPropertyChanged)));

	public static readonly DependencyProperty IsScaleToFitActiveProperty = DependencyProperty.Register("IsScaleToFitActive", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(IsScaleToFitActivePropertyChanged)));

	public static readonly DependencyProperty RenderTransparencyCheckerboardProperty = DependencyProperty.Register("RenderTransparencyCheckerboard", typeof(bool), typeof(CanvasControl));

	public static readonly DependencyProperty CheckerboardPrimaryBrushProperty = DependencyProperty.Register("CheckerboardPrimaryBrush", typeof(Brush), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White));

	public static readonly DependencyProperty CheckerboardSecondaryBrushProperty = DependencyProperty.Register("CheckerboardSecondaryBrush", typeof(Brush), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightGray));

	public static readonly DependencyProperty CanvasOriginProperty = DependencyProperty.Register("CanvasOrigin", typeof(Vector2<double>), typeof(CanvasControl));

	public static readonly DependencyProperty CanvasBrushProperty = DependencyProperty.Register("CanvasBrush", typeof(Brush), typeof(CanvasControl));

	public static readonly DependencyProperty RulerBackgroundProperty = DependencyProperty.Register("RulerBackground", typeof(Brush), typeof(CanvasControl));

	public static readonly DependencyProperty RulerBrushProperty = DependencyProperty.Register("RulerBrush", typeof(Brush), typeof(CanvasControl));

	public static readonly DependencyProperty MouseTrackerColorProperty = DependencyProperty.Register("MouseTrackerColor", typeof(Color), typeof(CanvasControl));

	public static readonly DependencyProperty ObjectBoundsColorProperty = DependencyProperty.Register("ObjectBoundsColor", typeof(Color), typeof(CanvasControl));

	public static readonly DependencyProperty PopoverBackgroundProperty = DependencyProperty.Register("PopoverBackground", typeof(Brush), typeof(CanvasControl));

	public static readonly DependencyProperty PopoverForegroundProperty = DependencyProperty.Register("PopoverForeground", typeof(Brush), typeof(CanvasControl));

	public static readonly DependencyProperty PasteboardMultiplierProperty = DependencyProperty.Register("PasteboardMultiplier", typeof(double), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.2, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty RootElementProperty = DependencyProperty.Register("RootElement", typeof(ICanvasElement), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RootElementPropertyChanged)));

	public static readonly DependencyProperty ActiveSelectionLevelProperty = DependencyProperty.Register("ActiveSelectionLevel", typeof(ICanvasElement), typeof(CanvasControl));

	public static readonly DependencyProperty SelectedElementsProperty = DependencyProperty.Register("SelectedElements", typeof(ObservableCollection<ICanvasElement>), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedElementsChanged)));

	public static readonly DependencyProperty SnapControllerProperty = DependencyProperty.Register("SnapController", typeof(SnapController), typeof(CanvasControl));

	public static readonly DependencyProperty SelectedElementsBoundsProperty = DependencyProperty.Register("SelectedElementsBounds", typeof(Rect<double>), typeof(CanvasControl));

	public static readonly DependencyProperty IsSelectionActiveProperty = DependencyProperty.Register("IsSelectionActive", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty IsRulerVisibleProperty = DependencyProperty.Register("IsRulerVisible", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectionBoundsProperty = DependencyProperty.Register("SelectionBounds", typeof(Rect<double>), typeof(CanvasControl));

	public static readonly DependencyProperty IsGridVisibleProperty = DependencyProperty.Register("IsGridVisible", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty GridColorProperty = DependencyProperty.Register("GridColor", typeof(Color), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Gray));

	public static readonly DependencyProperty GridSpacingProperty = DependencyProperty.Register("GridSpacing", typeof(double), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)120.0));

	public static readonly DependencyProperty GridSubdivisionsProperty = DependencyProperty.Register("GridSubdivisions", typeof(int), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)3));

	public static readonly DependencyProperty AlignmentGuidelineColorProperty = DependencyProperty.Register("AlignmentGuidelineColor", typeof(Color), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Cyan));

	public static readonly DependencyProperty StaticGuidelineColorProperty = DependencyProperty.Register("StaticGuidelineColor", typeof(Color), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Cyan, new PropertyChangedCallback(StaticGuidelineColorChanged)));

	public static readonly DependencyProperty StaticGuidesProperty = DependencyProperty.Register("StaticGuides", typeof(StaticSLCollection), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(StaticGuidesPropertyChanged)));

	public static readonly DependencyProperty IsStaticGuidelineVisibleProperty = DependencyProperty.Register("IsStaticGuidelineVisible", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(StaticGuidelineVisibilityChanged)));

	public static readonly DependencyProperty SnapSpacingEnabledProperty = DependencyProperty.Register("SnapSpacingEnabled", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(SnapPropertyChanged)));

	public static readonly DependencyProperty SnapSizingEnabledProperty = DependencyProperty.Register("SnapSizingEnabled", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(SnapPropertyChanged)));

	public static readonly DependencyProperty SnapCenterEnabledProperty = DependencyProperty.Register("SnapCenterEnabled", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(SnapPropertyChanged)));

	public static readonly DependencyProperty SnapEdgeEnabledProperty = DependencyProperty.Register("SnapEdgeEnabled", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(SnapPropertyChanged)));

	public static readonly DependencyProperty MousePositionProperty = DependencyProperty.Register("MousePosition", typeof(Vector2<double>), typeof(CanvasControl));

	public static readonly DependencyProperty IsMouseInCanvasProperty = DependencyProperty.Register("IsMouseInCanvas", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty IsTransformActiveProperty = DependencyProperty.Register("IsTransformActive", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty ActivePenProperty = DependencyProperty.Register("ActivePen", typeof(IPenTool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ActivePenChanged)));

	public static readonly DependencyProperty RulerContextMenuProperty = DependencyProperty.Register("RulerContextMenu", typeof(ContextMenu), typeof(CanvasControl));

	public static readonly DependencyProperty AddTabStopMenuProperty = DependencyProperty.Register("AddTabStopMenu", typeof(ContextMenu), typeof(CanvasControl));

	public static readonly DependencyProperty DeleteGuidelineLocaleStringProperty = DependencyProperty.Register("DeleteGuidelineLocaleString", typeof(string), typeof(CanvasControl));

	public static readonly DependencyProperty DeleteGuidelinesLocaleStringProperty = DependencyProperty.Register("DeleteGuidelinesLocaleString", typeof(string), typeof(CanvasControl));

	public static readonly DependencyProperty LowerOverlayProperty = DependencyProperty.Register("LowerOverlay", typeof(object), typeof(CanvasControl));

	private static readonly DependencyProperty MaskElementProperty = DependencyProperty.Register("MaskElement", typeof(ICanvasElement), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(MaskElementChanged)));

	private static readonly DependencyProperty ElementMaskOriginProperty = DependencyProperty.Register("ElementMaskOrigin", typeof(Vector2<double>), typeof(CanvasControl));

	public static readonly DependencyProperty TabStopsProperty = DependencyProperty.Register("TabStops", typeof(TabStopControlCollection), typeof(CanvasControl));

	protected override int VisualChildrenCount => 1;

	protected override IEnumerator LogicalChildren => new CanvasParent[1] { _parent }.GetEnumerator();

	protected IEnumerable<HandleBase> SelectedHandles => _parent.Overlays.SelectedHandles;

	private Vector2<double> ViewportSize => new Vector2<double>(_parent.CanvasScrollViewer.ViewportWidth, _parent.CanvasScrollViewer.ViewportHeight);

	public Rect<double> CanvasViewport => new Rect<double>((new Vector2<double>(_parent.CanvasScrollViewer.HorizontalOffset, _parent.CanvasScrollViewer.VerticalOffset) - CanvasOrigin) / ZoomFactor, ViewportSize / ZoomFactor);

	public Brush? CanvasBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CanvasBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanvasBrushProperty, (object)value);
		}
	}

	public Brush? RulerBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RulerBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerBackgroundProperty, (object)value);
		}
	}

	public Brush? RulerBrush
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

	public Color MouseTrackerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(MouseTrackerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseTrackerColorProperty, (object)value);
		}
	}

	public Color ObjectBoundsColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ObjectBoundsColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ObjectBoundsColorProperty, (object)value);
		}
	}

	public Brush? PopoverBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PopoverBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopoverBackgroundProperty, (object)value);
		}
	}

	public Brush? PopoverForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PopoverForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopoverForegroundProperty, (object)value);
		}
	}

	public Vector2<double> MousePosition
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(MousePositionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MousePositionProperty, (object)value);
		}
	}

	public bool IsMouseInCanvas
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMouseInCanvasProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMouseInCanvasProperty, (object)value);
		}
	}

	public bool HasMouse { get; private set; }

	public bool IsRulerVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsRulerVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsRulerVisibleProperty, (object)value);
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

	public bool IsScaleToFitActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsScaleToFitActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsScaleToFitActiveProperty, (object)value);
		}
	}

	public bool RenderTransparencyCheckerboard
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderTransparencyCheckerboardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderTransparencyCheckerboardProperty, (object)value);
		}
	}

	public Brush? CheckerboardPrimaryBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CheckerboardPrimaryBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CheckerboardPrimaryBrushProperty, (object)value);
		}
	}

	public Brush? CheckerboardSecondaryBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CheckerboardSecondaryBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CheckerboardSecondaryBrushProperty, (object)value);
		}
	}

	public Vector2<double> CanvasOrigin
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(CanvasOriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanvasOriginProperty, (object)value);
		}
	}

	public double PasteboardMultiplier
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PasteboardMultiplierProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PasteboardMultiplierProperty, (object)value);
		}
	}

	public ICanvasElement? RootElement
	{
		get
		{
			return (ICanvasElement)((DependencyObject)this).GetValue(RootElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RootElementProperty, (object)value);
		}
	}

	public ICanvasElement? ActiveSelectionLevel
	{
		get
		{
			return (ICanvasElement)((DependencyObject)this).GetValue(ActiveSelectionLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveSelectionLevelProperty, (object)value);
		}
	}

	public ObservableCollection<ICanvasElement>? SelectedElements
	{
		get
		{
			return (ObservableCollection<ICanvasElement>)((DependencyObject)this).GetValue(SelectedElementsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedElementsProperty, (object)value);
		}
	}

	public SnapController SnapController
	{
		get
		{
			return (SnapController)((DependencyObject)this).GetValue(SnapControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SnapControllerProperty, (object)value);
		}
	}

	public Rect<double> SelectedElementsBounds
	{
		get
		{
			return (Rect<double>)((DependencyObject)this).GetValue(SelectedElementsBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedElementsBoundsProperty, (object)value);
		}
	}

	public bool IsSelectionActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectionActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectionActiveProperty, (object)value);
		}
	}

	public Rect<double> SelectionBounds
	{
		get
		{
			return (Rect<double>)((DependencyObject)this).GetValue(SelectionBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectionBoundsProperty, (object)value);
		}
	}

	public bool IsGridVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsGridVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsGridVisibleProperty, (object)value);
		}
	}

	public Color GridColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(GridColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridColorProperty, (object)value);
		}
	}

	public double GridSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(GridSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridSpacingProperty, (object)value);
		}
	}

	public int GridSubdivisions
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(GridSubdivisionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridSubdivisionsProperty, (object)value);
		}
	}

	public Color AlignmentGuidelineColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(AlignmentGuidelineColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AlignmentGuidelineColorProperty, (object)value);
		}
	}

	public Color StaticGuidelineColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(StaticGuidelineColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StaticGuidelineColorProperty, (object)value);
		}
	}

	public StaticSLCollection? StaticGuides
	{
		get
		{
			return (StaticSLCollection)((DependencyObject)this).GetValue(StaticGuidesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StaticGuidesProperty, (object)value);
		}
	}

	public bool IsStaticGuidelineVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsStaticGuidelineVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsStaticGuidelineVisibleProperty, (object)value);
		}
	}

	public bool SnapSpacingEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SnapSpacingEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SnapSpacingEnabledProperty, (object)value);
		}
	}

	public bool SnapSizingEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SnapSizingEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SnapSizingEnabledProperty, (object)value);
		}
	}

	public bool SnapCenterEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SnapCenterEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SnapCenterEnabledProperty, (object)value);
		}
	}

	public bool SnapEdgeEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SnapEdgeEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SnapEdgeEnabledProperty, (object)value);
		}
	}

	public bool IsTransformActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTransformActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTransformActiveProperty, (object)value);
		}
	}

	public IPenTool? ActivePen
	{
		get
		{
			return (IPenTool)((DependencyObject)this).GetValue(ActivePenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivePenProperty, (object)value);
		}
	}

	public ContextMenu? RulerContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(RulerContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerContextMenuProperty, (object)value);
		}
	}

	public ContextMenu? AddTabStopMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(RulerContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerContextMenuProperty, (object)value);
		}
	}

	public string? DeleteGuidelineLocaleString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DeleteGuidelineLocaleStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteGuidelineLocaleStringProperty, (object)value);
		}
	}

	public string? DeleteGuidelinesLocaleString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DeleteGuidelinesLocaleStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteGuidelinesLocaleStringProperty, (object)value);
		}
	}

	public object? LowerOverlay
	{
		get
		{
			return ((DependencyObject)this).GetValue(LowerOverlayProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerOverlayProperty, value);
		}
	}

	private ICanvasElement? MaskElement
	{
		get
		{
			return (ICanvasElement)((DependencyObject)this).GetValue(MaskElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaskElementProperty, (object)value);
		}
	}

	private Vector2<double> ElementMaskOrigin
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(ElementMaskOriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ElementMaskOriginProperty, (object)value);
		}
	}

	public TabStopControlCollection? TabStops
	{
		get
		{
			return (TabStopControlCollection)((DependencyObject)this).GetValue(TabStopsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabStopsProperty, (object)value);
		}
	}

	private static void ZoomFactorPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.OnZoomFactorPropertyChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void IsScaleToFitActivePropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue && callerObject is CanvasControl canvasControl)
		{
			canvasControl._shouldAutoCenter = true;
		}
	}

	private static void RootElementPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.RootElementChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ICanvasElement, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICanvasElement);
	}

	private static void OnSelectedElementsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as CanvasControl)?.SelectedElementsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<ICanvasElement>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<ICanvasElement>);
	}

	private static void SnapPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.UpdateEnabledSnapTypes();
	}

	private static void StaticGuidesPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.StaticGuidesChanged((StaticSLCollection)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (StaticSLCollection)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void StaticGuidelineColorChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.InvalidateGuidelines();
	}

	private static void StaticGuidelineVisibilityChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.OnStaticGuidelineVisibilityChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void ActivePenChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.OnActivePenChanged((IPenTool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IPenTool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void MaskElementChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasControl)?.OnMaskElementChanged((ICanvasElement)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ICanvasElement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected CanvasControl()
	{
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		base.Focusable = true;
		SelectedElements = new ObservableCollection<ICanvasElement>();
		SnapController = new SnapController();
		SnapController.SnappingTargets.Add(_staticSS);
		_parent = new CanvasParent
		{
			DataContext = this
		};
		_parent.SetBinding(CanvasParent.CanvasBrushProperty, new Binding("CanvasBrush"));
		_parent.SetBinding(CanvasParent.RulerBackgroundProperty, new Binding("RulerBackground"));
		_parent.SetBinding(CanvasParent.RulerBrushProperty, new Binding("RulerBrush"));
		_parent.SetBinding(CanvasParent.MouseTrackerColorProperty, new Binding("MouseTrackerColor"));
		_parent.SetBinding(CanvasParent.ObjectBoundsColorProperty, new Binding("ObjectBoundsColor"));
		_parent.SetBinding(CanvasParent.PopoverBackgroundProperty, new Binding("PopoverBackground"));
		_parent.SetBinding(CanvasParent.PopoverForegroundProperty, new Binding("PopoverForeground"));
		_parent.SetBinding(CanvasParent.DeleteGuidelineLocaleStringProperty, new Binding("DeleteGuidelineLocaleString"));
		_parent.SetBinding(CanvasParent.DeleteGuidelinesLocaleStringProperty, new Binding("DeleteGuidelinesLocaleString"));
		AddVisualChild(_parent);
		AddLogicalChild(_parent);
		base.LayoutUpdated += OnLayoutUpdated;
		_parent.Canvas.LayoutUpdated += Canvas_LayoutUpdated;
		_parent.Canvas.ElementSelected += ElementSelected;
		_parent.Canvas.ElementEdited += ElementEdited;
		_parent.Canvas.ChildElementSelected += ChildElementSelected;
		_parent.Canvas.ChildElementDeselected += ChildElementDeselected;
		_parent.CanvasContainer.SizeChanged += CanvasContainer_SizeChanged;
		_parent.CanvasContainer.MouseDown += CanvasContainer_MouseDown;
		_parent.CanvasScrollViewer.SizeChanged += CanvasContainer_SizeChanged;
		_parent.Overlays.TransformStateChanged += delegate(bool a, ITransform? t)
		{
			if (a)
			{
				OnTransformStart(t);
			}
			else
			{
				OnTransformEnd();
			}
		};
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(CanvasControl_IsVisibleChanged);
	}

	private void OnZoomFactorPropertyChanged(double oldValue, double newValue)
	{
		SnapController.SnappingThreshold = 6.0 / newValue;
		if (MaskElement != null)
		{
			ElementMaskOrigin *= newValue / oldValue;
		}
		OnZoomFactorChanged(newValue);
	}

	private void CanvasControl_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			Focus();
		}
	}

	protected internal abstract void OnRenderElement(ICanvasElement? element, DrawingVisual target);

	protected internal virtual PopoverControl? GeneratePopoverControlFromIPopover(IEnumerable<IPopover> popover)
	{
		return null;
	}

	protected internal virtual HandleBase[] OnGetHandleControls(IHandleData handle)
	{
		return Array.Empty<HandleBase>();
	}

	protected internal virtual void OnCleanupHandleControls(IHandleData handle, HandleBase[] handleControls)
	{
	}

	protected virtual void SelectedElementsChanged(ObservableCollection<ICanvasElement>? oldCollection, ObservableCollection<ICanvasElement>? newCollection)
	{
	}

	protected virtual void OnElementEdited(Vector2<double> point, ICanvasElement element)
	{
	}

	protected virtual void OnElementSelected(ICanvasElement? element)
	{
	}

	protected virtual void OnElementDeselected(ICanvasElement element)
	{
	}

	protected virtual void OnZoomFactorChanged(double newValue)
	{
	}

	protected internal virtual void OnDragFromRuler(bool isRulerHorizontal)
	{
	}

	protected virtual void OnTransformStart(ITransform? transform)
	{
	}

	protected virtual void OnTransformEnd()
	{
	}

	protected virtual void OnCanvasLayoutUpdated()
	{
	}

	protected virtual void OnMouseMove(Vector2<double> position)
	{
	}

	protected virtual void OnPenActivated()
	{
	}

	protected virtual void OnPenDeactivated()
	{
	}

	protected virtual void OnStaticGuidesChanged(StaticSLCollection? guides)
	{
	}

	protected virtual void OnStaticGuidelineVisibilityChanged(bool isVisible)
	{
		StaticGuides?.ForEach(delegate(StaticSL g)
		{
			g.IsEnabled = isVisible;
		});
		InvalidateGuidelines();
	}

	protected internal virtual Color GetGuidelineColor(GuidelineBase guideline)
	{
		if (guideline.IsParent)
		{
			return ParentGuidelineColor;
		}
		if (guideline is StaticGuideline)
		{
			return StaticGuidelineColor;
		}
		return AlignmentGuidelineColor;
	}

	private void StaticGuidesChanged(StaticSLCollection oldGuides, StaticSLCollection newGuides)
	{
		if (oldGuides != null)
		{
			oldGuides.CollectionChanged -= StaticeGuideCollectionChanged;
		}
		if (newGuides != null)
		{
			newGuides.CollectionChanged += StaticeGuideCollectionChanged;
		}
		_staticSS.SlideGuides = newGuides;
		OnStaticGuidesChanged(newGuides);
	}

	private void StaticeGuideCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		_staticSS.SlideGuides = StaticGuides;
		OnStaticGuidesChanged(StaticGuides);
	}

	protected void InvalidateGuidelines()
	{
		_parent.GuidelinesControl.InvalidateVisual();
	}

	protected override Visual GetVisualChild(int index)
	{
		return _parent;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_parent.Measure(availableSize);
		return availableSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		_parent.Arrange(new Rect(_parent.DesiredSize));
		return finalSize;
	}

	protected void InvalidateRootVisual()
	{
		_parent.Canvas.InvalidateVisual();
	}

	private void RootElementChanged(ICanvasElement? oldRoot, ICanvasElement? newRoot)
	{
		ChangeActiveSelectionLevel(null);
		if (oldRoot != null)
		{
			oldRoot.PropertyChanged -= RootElementPropertyChanged;
			oldRoot.CanvasChildren?.ForEach(DeselectElement);
		}
		if (newRoot != null)
		{
			newRoot.PropertyChanged += RootElementPropertyChanged;
			if (oldRoot == null)
			{
				CenterCanvas();
			}
			else if (oldRoot.Size != newRoot.Size)
			{
				IsScaleToFitActive = true;
			}
		}
		_previousSelection = null;
	}

	private void RootElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Size")
		{
			IsScaleToFitActive = true;
		}
	}

	private void OnLayoutUpdated(object? sender, EventArgs e)
	{
		Window window = Application.Current?.MainWindow;
		if (window != null)
		{
			base.LayoutUpdated -= OnLayoutUpdated;
			window.PreviewKeyDown += delegate
			{
				OnPreviewKeyStateChanged();
			};
			window.PreviewKeyUp += delegate
			{
				OnPreviewKeyStateChanged();
			};
		}
	}

	private void Canvas_LayoutUpdated(object? sender, EventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		CanvasOrigin = (Vector2<double>)_parent.Canvas.TranslatePoint(Vector2<double>.Zero, _parent.CanvasContainer);
		if (IsScaleToFitActive)
		{
			Vector2<double> vector = (ViewportSize - new Vector2<double>(100.0)).ComponentwiseQuotient(RootElement?.Size ?? Vector2<double>.One);
			ZoomFactor = Math.Min(vector.X, vector.Y).Clamp(0.1, 32.0);
			if (_shouldAutoCenter)
			{
				OnCenterCanvas();
			}
		}
		else if (_shouldAutoCenter && (_parent.CanvasScrollViewer.ScrollableWidth > 0.0 || _parent.CanvasScrollViewer.ScrollableHeight > 0.0))
		{
			OnCenterCanvas();
		}
		OnCanvasLayoutUpdated();
	}

	private void CanvasContainer_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		if (IsScaleToFitActive)
		{
			_shouldAutoCenter = true;
		}
	}

	protected void ScaleToFitContent()
	{
		IsScaleToFitActive = false;
		if (RootElement?.CanvasChildren != null)
		{
			Rect<double> boundingBox = (from e in RootElement.CanvasChildren.Append<ICanvasElement>(RootElement)
				select e.SnapBounds).GetBoundingBox();
			Vector2<double> vector = ViewportSize.ComponentwiseQuotient(boundingBox.Size);
			ZoomFactor = Math.Min(vector.X, vector.Y).Clamp(0.1, 32.0);
			UpdateLayout();
			Vector2<double> vector2 = boundingBox.Position * ZoomFactor;
			Vector2<double> vector3 = boundingBox.Size * ZoomFactor;
			Vector2<double> vector4 = CanvasOrigin + vector2 - (ViewportSize - vector3) / 2.0;
			_parent.CanvasScrollViewer.ScrollToHorizontalOffset(vector4.X);
			_parent.CanvasScrollViewer.ScrollToVerticalOffset(vector4.Y);
		}
	}

	protected void CenterCanvas()
	{
		_shouldAutoCenter = true;
	}

	private void OnCenterCanvas()
	{
		_parent.CanvasScrollViewer.ScrollToHorizontalOffset(_parent.CanvasScrollViewer.ScrollableWidth / 2.0);
		_parent.CanvasScrollViewer.ScrollToVerticalOffset(_parent.CanvasScrollViewer.ScrollableHeight / 2.0);
		_shouldAutoCenter = false;
	}

	private void ChangeZoomFactor(double factor)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (RootElement != null)
		{
			IsScaleToFitActive = false;
			_shouldAutoCenter = false;
			double zoomFactor = ZoomFactor;
			ZoomFactor = Math.Max(Math.Min(ZoomFactor * Math.Pow(1.05, factor), 32.0), 0.1);
			double num = ZoomFactor / zoomFactor;
			Vector2<double> vector = (Vector2<double>)Mouse.GetPosition(_parent.CanvasContainer) * num - (Vector2<double>)Mouse.GetPosition(_parent.CanvasScrollViewer);
			_parent.CanvasScrollViewer.ScrollToHorizontalOffset(vector.X);
			_parent.CanvasScrollViewer.ScrollToVerticalOffset(vector.Y);
		}
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2))
		{
			ChangeZoomFactor((double)e.Delta / 120.0);
			e.Handled = true;
		}
	}

	private void CanvasContainer_MouseDown(object? sender, MouseButtonEventArgs e)
	{
		ElementSelected(RootElement);
	}

	private bool ShouldMultiSelect()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		ModifierKeys modifiers = Keyboard.Modifiers;
		if (!((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4))
		{
			return ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		}
		return true;
	}

	private void SelectElement(ICanvasElement? element)
	{
		if (element != null)
		{
			element.OnSelected();
			SelectedElements?.Add(element);
		}
	}

	private void DeselectElement(ICanvasElement? element)
	{
		if (element != null)
		{
			element.OnDeselected();
			SelectedElements?.Remove(element);
			if (element == MaskElement)
			{
				MaskElement = null;
			}
			element.PropertyChanged -= MaskElement_PropertyChanged;
			OnElementDeselected(element);
		}
	}

	private void ClearSelected()
	{
		SelectedElements?.ToArray().ForEach(DeselectElement);
	}

	protected void ElementSelected(ICanvasElement? element)
	{
		ElementSelected(element, multiSelectOverride: false);
	}

	protected void ElementSelected(ICanvasElement? element, bool multiSelectOverride)
	{
		if (SelectedElements == null || RootElement == null || element == null || element.IsLocked)
		{
			return;
		}
		bool flag = ShouldMultiSelect() || multiSelectOverride;
		ICanvasElement canvasElement = FindValidElement(element, (ICanvasElement e) => e);
		_previousSelection = SelectedElements.ToArray();
		if (canvasElement != RootElement && canvasElement != null)
		{
			if (!SelectedElements.Contains(canvasElement))
			{
				if (!flag)
				{
					ClearSelected();
				}
				SelectElement(canvasElement);
			}
			else if (flag)
			{
				DeselectElement(canvasElement);
			}
		}
		else if (!flag)
		{
			ClearSelected();
			ChangeActiveSelectionLevel(null);
		}
		UpdateSelectedElementsBounds();
		Focus();
		OnElementSelected(canvasElement);
	}

	protected void ElementDeselected(ICanvasElement? element)
	{
		DeselectElement(element);
	}

	protected void ElementEdited(Vector2<double> point, ICanvasElement? element)
	{
		ElementEdited(point, element, forceMask: false);
	}

	protected void ElementEdited(Vector2<double> point, ICanvasElement? element, bool forceMask)
	{
		if (element != null)
		{
			element.OnEnterEditMode(point, ZoomFactor, forceMask);
			if (forceMask || element.MaskWhileEditing)
			{
				MaskElement = element;
			}
			OnElementEdited(point, element);
		}
	}

	private void OnMaskElementChanged(ICanvasElement oldValue, ICanvasElement newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= MaskElement_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += MaskElement_PropertyChanged;
			ElementMaskOrigin = CanvasOrigin + newValue.Position * ZoomFactor;
		}
	}

	private void MaskElement_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(sender is ICanvasElement canvasElement))
		{
			return;
		}
		string propertyName = e.PropertyName;
		if (!(propertyName == "Position"))
		{
			if (propertyName == "IsEditModeActive" && !canvasElement.IsEditModeActive)
			{
				ElementDeselected(canvasElement);
			}
		}
		else
		{
			ElementMaskOrigin = CanvasOrigin + canvasElement.Position * ZoomFactor;
		}
	}

	protected void ChildElementSelected(ICanvasElement? element)
	{
		if (!ShouldMultiSelect())
		{
			ICanvasElement validElement = FindValidElement(element, (ICanvasElement e) => e.CanvasParent ?? element);
			if (validElement != null)
			{
				ClearSelected();
				ChangeActiveSelectionLevel(validElement.CanvasParent);
				ElementSelected(validElement);
				CanvasElement canvasElement = ((DependencyObject)(object)_parent.CanvasContainer)?.FindVisualChild((CanvasElement e) => e.SourceElement == validElement);
				if (canvasElement != null)
				{
					canvasElement.Visibility = Visibility.Visible;
				}
			}
		}
		else
		{
			ElementSelected(element);
		}
	}

	private void ChildElementDeselected(ICanvasElement? element)
	{
		DeselectElement(element);
	}

	private ICanvasElement? FindValidElement(ICanvasElement? element, Func<ICanvasElement, ICanvasElement?> elementPredicate)
	{
		if (ActiveSelectionLevel == null)
		{
			ChangeActiveSelectionLevel(RootElement);
		}
		if (element == null)
		{
			return null;
		}
		ICanvasElement canvasElement = elementPredicate(element);
		while (canvasElement != null)
		{
			ICanvasElement? activeSelectionLevel = ActiveSelectionLevel;
			bool? obj;
			if (activeSelectionLevel == null)
			{
				obj = null;
			}
			else
			{
				ImmutableObservableCollection<ICanvasElement>? canvasChildren = activeSelectionLevel.CanvasChildren;
				obj = ((canvasChildren != null) ? new bool?(!canvasChildren.Contains(canvasElement)) : ((bool?)null));
			}
			bool? flag = obj;
			if (flag != true)
			{
				break;
			}
			element = element.CanvasParent;
			if (element == null)
			{
				break;
			}
		}
		return element;
	}

	private void ChangeActiveSelectionLevel(ICanvasElement? selectionLevel)
	{
		CanvasElement[] source = ((DependencyObject)(object)_parent.CanvasContainer).FindVisualChildren<CanvasElement>().ToArray();
		SSLayer sSLayer = ((selectionLevel == null) ? null : source.FirstOrDefault((CanvasElement e) => e.SourceElement == selectionLevel)?.SSLayer);
		if (sSLayer == _activeSSLayer)
		{
			return;
		}
		_activeSSLayer?.Deactivate(SnapController);
		sSLayer?.Activate(SnapController);
		_activeSSLayer = sSLayer;
		ActiveSelectionLevel = selectionLevel;
		UpdateEnabledSnapTypes();
		ICanvasElement? previousLevel = _previousLevel;
		if (previousLevel != null && previousLevel.ChildVisibilityMode == ChildVisibilityMode.HiddenUntilActivated)
		{
			source.Where((CanvasElement e) => e.SourceElement == null || _previousLevel?.CanvasChildren?.Contains(e.SourceElement) == true).ForEach(delegate(CanvasElement e)
			{
				e.Visibility = Visibility.Hidden;
			});
		}
		_previousLevel = selectionLevel;
	}

	protected Vector2<double> GetMousePosition(Func<IInputElement, Point> getPosition)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2<double>)getPosition(_parent.Canvas);
	}

	protected virtual IEnumerable<ICanvasElement> DuplicateSelectedElements()
	{
		return Enumerable.Empty<ICanvasElement>();
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		MousePosition = GetMousePosition(e.GetPosition);
		if (ActivePen != null && CanOverrideMouseEvent(e, includeCanvasElements: true))
		{
			ActivePen.MouseMove(MousePosition, e);
			e.Handled = true;
			return;
		}
		CanvasElement canvasElement = e.OriginalSource as CanvasElement;
		ICanvasElement element = canvasElement?.SourceElement;
		if (element != null)
		{
			element = FindValidElement(element, (ICanvasElement x) => x);
		}
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			if (element != null && SelectedElements != null && SelectedElements.Contains(element) && !element.IsLocked)
			{
				if (_currentTransform == null)
				{
					if (((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2))
					{
						List<ICanvasElement> list = DuplicateSelectedElements().ToList();
						for (int i = 0; i < SelectedElements.Count; i++)
						{
							ICanvasElement canvasElement2 = list[i];
							if (canvasElement2 == null)
							{
								continue;
							}
							if (element == SelectedElements[i])
							{
								element = canvasElement2;
								canvasElement = ((DependencyObject)(object)this).FindVisualChildren<CanvasElement>().First((CanvasElement v) => v.SourceElement == element);
							}
							SelectedElements[i] = canvasElement2;
						}
					}
					_currentTransform = new PositionTransform();
					_currentTransform.StartTransform(SelectedElements, SnapController);
					SetupDrag(element.CanvasParent);
					EnableEqualSizingSS(isEnabled: false);
					_parent.Overlays.OnTransformStateChanged(isTransformActive: true, _currentTransform);
				}
				Vector2<double> vector = MousePosition * _transformMatrix;
				_currentTransform.TransformElements(_startDragPosition, _lastDragPosition, vector, Keyboard.Modifiers);
				_lastDragPosition = vector;
				e.Handled = true;
				canvasElement?.CaptureMouse();
			}
			else if (CanOverrideMouseEvent(e, includeCanvasElements: false))
			{
				CaptureMouse();
				if (_isPanning)
				{
					Vector val = (Vector)_startScrollOffset + ((Point)_startMousePosition - e.GetPosition(this));
					_parent.CanvasScrollViewer.ScrollToHorizontalOffset(((Vector)(ref val)).X);
					_parent.CanvasScrollViewer.ScrollToVerticalOffset(((Vector)(ref val)).Y);
				}
				else
				{
					if (!IsSelectionActive)
					{
						IsSelectionActive = true;
						SetupDrag(ActiveSelectionLevel ?? RootElement);
					}
					_lastDragPosition = MousePosition * _transformMatrix;
					e.Handled = true;
					UpdateSelectionFromBounds();
				}
			}
		}
		UpdateSelectedElementsBounds();
		OnMouseMove(MousePosition);
	}

	private bool CanOverrideMouseEvent(MouseEventArgs e, bool includeCanvasElements)
	{
		if (!object.Equals(e.OriginalSource, this) && !object.Equals(e.OriginalSource, _parent.Canvas) && !object.Equals(e.OriginalSource, _parent.PasteboardArea) && !object.Equals(e.OriginalSource, _parent.ElementMask) && !object.Equals(e.OriginalSource, _parent.CanvasContainer))
		{
			if (includeCanvasElements)
			{
				return e.OriginalSource.GetType() == typeof(CanvasElement);
			}
			return false;
		}
		return true;
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		HasMouse = true;
		IsMouseInCanvas = true;
		OnMouseEnter();
	}

	protected virtual void OnMouseEnter()
	{
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		HasMouse = false;
		IsMouseInCanvas = false;
		OnMouseLeave();
	}

	protected virtual void OnMouseLeave()
	{
	}

	protected void SelectAll(IEnumerable<ICanvasElement?>? elements)
	{
		DeselectAll();
		foreach (ICanvasElement item in elements?.NonNull() ?? Enumerable.Empty<ICanvasElement>())
		{
			SelectElement(FindValidElement(item, (ICanvasElement e) => e));
		}
	}

	public void DeselectAll()
	{
		ClearSelected();
		ChangeActiveSelectionLevel(null);
	}

	private void SetupDrag(ICanvasElement? element)
	{
		_transformMatrix = element.GetGlobalTransformMatrix().Inverse();
		UpdateDragPositions();
	}

	private void UpdateDragPositions()
	{
		_startDragPosition = MousePosition * _transformMatrix;
		_lastDragPosition = MousePosition * _transformMatrix;
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		if (CanOverrideMouseEvent(e, includeCanvasElements: true))
		{
			if (ActivePen != null)
			{
				Focus();
				ActivePen.MouseDown(MousePosition, e);
				e.Handled = true;
			}
			else if (_isPanning)
			{
				_startScrollOffset = new Vector2<double>(_parent.CanvasScrollViewer.HorizontalOffset, _parent.CanvasScrollViewer.VerticalOffset);
				_startMousePosition = (Vector2<double>)e.GetPosition(this);
				CaptureMouse();
			}
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		if (ActivePen != null && CanOverrideMouseEvent(e, includeCanvasElements: true))
		{
			ActivePen.MouseUp(MousePosition, e);
			e.Handled = true;
		}
		else if (_currentTransform != null || IsSelectionActive)
		{
			(e.OriginalSource as IInputElement)?.ReleaseMouseCapture();
			if (_currentTransform != null)
			{
				_currentTransform.CompleteTransform();
				_currentTransform = null;
				EnableEqualSizingSS(isEnabled: true);
				_parent.Overlays.OnTransformStateChanged(isTransformActive: false, null);
			}
			else if (IsSelectionActive)
			{
				IsSelectionActive = false;
				_previousSelection = null;
			}
			e.Handled = true;
		}
		ReleaseMouseCapture();
		SetIsPanning(value: false);
	}

	private void EnableEqualSizingSS(bool isEnabled)
	{
		foreach (EqualSizingSS item in SnapController.SnappingTargets.OfType<EqualSizingSS>())
		{
			item.IsEnabled = isEnabled;
		}
	}

	private void OnPreviewKeyStateChanged()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		_parent.Overlays.UpdateHandles();
		_currentTransform?.TransformElements(_startDragPosition, _lastDragPosition, _lastDragPosition, Keyboard.Modifiers);
		if (IsSelectionActive)
		{
			UpdateSelectionFromBounds();
		}
		bool flag = _isPanning && Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed;
		SetIsPanning((Keyboard.IsKeyDown((Key)18) || flag) && !IsTransformActive && !IsSelectionActive && ActivePen == null);
	}

	private void SetIsPanning(bool value)
	{
		_isPanning = value;
		base.Cursor = (value ? Cursors.ScrollAll : null);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Key key = e.Key;
		Key key2 = e.Key;
		if ((int)key2 <= 26)
		{
			if ((int)key2 != 13)
			{
				if (key2 - 23 <= 3 && !(e.OriginalSource is FormattedTextBox))
				{
					double num = (((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4) ? 10.0 : 1.0);
					Vector2<double> offset = Vector2<double>.Zero;
					if (Keyboard.IsKeyDown((Key)25))
					{
						offset.X = num;
					}
					else if (Keyboard.IsKeyDown((Key)23))
					{
						offset.X = 0.0 - num;
					}
					if (Keyboard.IsKeyDown((Key)26))
					{
						offset.Y = num;
					}
					else if (Keyboard.IsKeyDown((Key)24))
					{
						offset.Y = 0.0 - num;
					}
					SelectedElements?.ForEach(delegate(ICanvasElement i)
					{
						i.Position += offset;
					});
					e.Handled = true;
				}
			}
			else if (ActivePen != null)
			{
				OnDeactivatePen();
				e.Handled = true;
			}
		}
		else if (((int)key2 == 85 || (int)key2 == 87) && ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2))
		{
			ChangeZoomFactor(((int)key == 85) ? 1.0 : (-1.0));
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	private void UpdateSelectionFromBounds()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		ICanvasElement canvasElement = ActiveSelectionLevel ?? RootElement;
		bool flag = ShouldMultiSelect();
		bool flag2 = ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		Rect<double> selectionBounds = new Rect<double>(_lastDragPosition, (_startDragPosition - _lastDragPosition) * (flag2 ? 2.0 : 1.0));
		if (canvasElement == null)
		{
			return;
		}
		if (canvasElement.CanvasChildren != null)
		{
			foreach (ICanvasElement item in canvasElement.CanvasChildren.Where((ICanvasElement e) => e.IsSelectable))
			{
				bool flag3 = item.DoesSelectionIntersect(selectionBounds);
				bool flag4 = _previousSelection?.Contains(item) ?? false;
				if ((flag3 && !(flag && flag4)) || (!flag3 && flag && flag4))
				{
					if (SelectedElements != null && !SelectedElements.Contains(item) && !item.IsLocked)
					{
						SelectElement(item);
					}
				}
				else
				{
					DeselectElement(item);
				}
			}
		}
		SelectionBounds = selectionBounds;
		UpdateSelectedElementsBounds();
	}

	private void UpdateSelectedElementsBounds()
	{
		SelectedElementsBounds = SelectedElements?.Select((ICanvasElement e) => e.SnapBounds).GetBoundingBox() ?? Rect<double>.Empty;
	}

	private void UpdateEnabledSnapTypes()
	{
		_activeSSLayer?.EnableSnapTypes(SnapSpacingEnabled, SnapSizingEnabled, SnapCenterEnabled, SnapEdgeEnabled);
	}

	private void OnActivePenChanged(IPenTool oldValue, IPenTool newValue)
	{
		if (oldValue != null)
		{
			oldValue.DeactivatePen -= OnDeactivatePen;
		}
		if (newValue != null)
		{
			Focus();
			newValue.DeactivatePen += OnDeactivatePen;
			OnPenActivated();
		}
		base.Cursor = newValue?.MouseCursor;
	}

	private void OnDeactivatePen()
	{
		OnPenDeactivated();
		((DependencyObject)this).SetCurrentValue(ActivePenProperty, (object)null);
	}
}
