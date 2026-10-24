using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Guidelines;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.UI.Utility;

namespace Pro.Editor.Canvas.Controls;

internal class GuidelinesControl : FrameworkElement
{
	private readonly List<GuidelineBase> _guidelines = new List<GuidelineBase>();

	private readonly List<StaticGuideline> _activeGuidelines = new List<StaticGuideline>();

	private readonly ContextMenu _guidelineMenu = new ContextMenu();

	private CanvasControl? _canvas;

	public static readonly DependencyProperty CanvasOriginProperty = DependencyProperty.Register("CanvasOrigin", typeof(Vector2<double>), typeof(GuidelinesControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(GuidelinesControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ScrollHorizontalOffsetProperty = DependencyProperty.Register("ScrollHorizontalOffset", typeof(double), typeof(GuidelinesControl));

	public static readonly DependencyProperty ScrollVerticalOffsetProperty = DependencyProperty.Register("ScrollVerticalOffset", typeof(double), typeof(GuidelinesControl));

	public static readonly DependencyProperty SnapControllerProperty = DependencyProperty.Register("SnapController", typeof(SnapController), typeof(GuidelinesControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SnapControllerChanged)));

	public static readonly DependencyProperty StaticGuidelinesProperty = DependencyProperty.Register("StaticGuidelines", typeof(StaticSLCollection), typeof(GuidelinesControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(StaticGuidelinesChanged)));

	public static readonly DependencyProperty DeleteGuidelineLocaleStringProperty = DependencyProperty.Register("DeleteGuidelineLocaleString", typeof(string), typeof(GuidelinesControl));

	public static readonly DependencyProperty DeleteGuidelinesLocaleStringProperty = DependencyProperty.Register("DeleteGuidelinesLocaleString", typeof(string), typeof(GuidelinesControl));

	private CanvasControl? CanvasControl
	{
		get
		{
			if (_canvas == null)
			{
				_canvas = ((DependencyObject)(object)this).FindVisualParent<CanvasControl>();
			}
			return _canvas;
		}
	}

	protected override int VisualChildrenCount => _guidelines.Count;

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

	public double ScrollHorizontalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollHorizontalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollHorizontalOffsetProperty, (object)value);
		}
	}

	public double ScrollVerticalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollVerticalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollVerticalOffsetProperty, (object)value);
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

	public StaticSLCollection StaticGuidelines
	{
		get
		{
			return (StaticSLCollection)((DependencyObject)this).GetValue(StaticGuidelinesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StaticGuidelinesProperty, (object)value);
		}
	}

	public string DeleteGuidelineLocaleString
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

	public string DeleteGuidelinesLocaleString
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

	private static void SnapControllerChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((GuidelinesControl)(object)callerObject).ReloadSnapController(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as SnapController, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as SnapController);
	}

	private static void StaticGuidelinesChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((GuidelinesControl)(object)callerObject).ReloadStaticGuidelines(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as StaticSLCollection, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as StaticSLCollection);
	}

	protected override Visual GetVisualChild(int index)
	{
		return _guidelines[index];
	}

	private void AddGuideline(GuidelineBase guideline)
	{
		AddVisualChild(guideline);
		_guidelines.Add(guideline);
	}

	private void RemoveGuidelines(IEnumerable<GuidelineBase?> guidelines)
	{
		guidelines.NonNull().ForEach(delegate(GuidelineBase g)
		{
			RemoveVisualChild(g);
			_guidelines.Remove(g);
			if (g is StaticGuideline item)
			{
				_activeGuidelines.Remove(item);
			}
		});
	}

	private void RemoveGuideline(GuidelineBase? guideline)
	{
		RemoveGuidelines(new global::_003C_003Ez__ReadOnlySingleElementList<GuidelineBase>(guideline));
	}

	private void ReloadSnapController(SnapController? oldController, SnapController? newController)
	{
		if (oldController != null)
		{
			oldController.FinalBoundsChanged -= FinalSnappingBoundsChanged;
		}
		if (newController != null)
		{
			newController.FinalBoundsChanged += FinalSnappingBoundsChanged;
		}
	}

	private void ReloadStaticGuidelines(StaticSLCollection? oldValue, StaticSLCollection? newValue)
	{
		if (oldValue != null)
		{
			oldValue.ForEach(delegate(StaticSL g)
			{
				RemoveGuideline(_guidelines.OfType<StaticGuideline>().FirstOrDefault((StaticGuideline l) => l.Guide == g));
			});
			oldValue.CollectionChanged -= StaticGuidesChanged;
			oldValue.GuidelinesInvalidated -= base.InvalidateVisual;
		}
		if (newValue != null)
		{
			foreach (StaticSL item in newValue)
			{
				AddGuideline(new StaticGuideline(item));
			}
			newValue.CollectionChanged += StaticGuidesChanged;
			newValue.GuidelinesInvalidated += base.InvalidateVisual;
		}
		InvalidateVisual();
	}

	private void StaticGuidesChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		if (e.Action.HasFlag(NotifyCollectionChangedAction.Reset))
		{
			RemoveGuidelines(_guidelines.OfType<StaticGuideline>().ToArray());
			return;
		}
		if (e.OldItems != null)
		{
			e.OldItems.Cast<StaticSL>().ForEach(delegate(StaticSL g)
			{
				RemoveGuideline(_guidelines.OfType<StaticGuideline>().FirstOrDefault((StaticGuideline l) => l.Guide == g));
			});
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (StaticSL newItem in e.NewItems)
		{
			StaticGuideline staticGuideline = new StaticGuideline(newItem);
			if (newItem.IsEditable && newItem.UpdatePosition)
			{
				Vector2<double> vector = (Vector2<double>)Mouse.GetPosition(this) - CanvasOrigin;
				newItem.Position = (newItem.IsHorizontal ? vector.Y : vector.X) / ZoomFactor;
				_activeGuidelines.Add(staticGuideline);
				UpdateCursor(new global::_003C_003Ez__ReadOnlySingleElementList<StaticGuideline>(staticGuideline));
				newItem.UpdatePosition = false;
			}
			AddGuideline(staticGuideline);
		}
		CaptureMouse();
		InvalidateVisual();
	}

	private void PopulateGuidelineContextMenu(IEnumerable<GuidelineBase> guidelines)
	{
		_guidelineMenu.Items.Clear();
		MenuItem menuItem = new MenuItem();
		menuItem.Header = (guidelines.Skip(1).Any() ? DeleteGuidelinesLocaleString : DeleteGuidelineLocaleString);
		menuItem.Click += delegate
		{
			StaticGuidelines.RemoveStaticSLs((from StaticGuideline g in guidelines
				select g.Guide).ToArray());
		};
		_guidelineMenu.Items.Add(menuItem);
	}

	private void FinalSnappingBoundsChanged(SnapController controller)
	{
		RemoveGuidelines(_guidelines.OfType<SnapGuidelineBase>().ToArray());
		foreach (ISnapLine snapLine5 in controller.LatestResult.SnapLines)
		{
			if (snapLine5 is ElementSL snapLine)
			{
				AddGuideline(new ElementGuideline(snapLine, controller.FinalBounds));
			}
			else if (snapLine5 is EqualSizingSL snapLine2)
			{
				AddGuideline(new SizingGuideline(snapLine2, controller.FinalBounds));
			}
			else if (snapLine5 is EqualSpacingSL snapLine3)
			{
				AddGuideline(new EqualSpacingGuideline(snapLine3, controller.FinalBounds));
			}
			else if (snapLine5 is CenterSpacingSL snapLine4)
			{
				AddGuideline(new CenterSpacingGuideline(snapLine4, controller.FinalBounds));
			}
		}
		InvalidateVisual();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		foreach (GuidelineBase guideline in _guidelines)
		{
			guideline.RenderGuideline(CanvasOrigin, Vector2<double>.Zero, ZoomFactor, CanvasControl?.GetGuidelineColor(guideline) ?? Colors.Transparent);
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (e.ChangedButton != 0)
		{
			return;
		}
		Vector2<double> mousePosition = GetMousePosition(e);
		IEnumerable<StaticGuideline> collection = FindMousedOverGuidelines(mousePosition);
		_activeGuidelines.AddRange(collection);
		if (_activeGuidelines.Any())
		{
			StaticGuidelines.OnDragStart(_activeGuidelines.Select((StaticGuideline s) => s.Guide).Distinct());
		}
		CaptureMouse();
		e.Handled = true;
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (_activeGuidelines.Any() && e.ChangedButton == MouseButton.Left)
		{
			Vector2<double> thresholdPoint = (Vector2<double>)e.GetPosition(this) - new Vector2<double>(ScrollHorizontalOffset, ScrollVerticalOffset);
			IEnumerable<StaticSL> enumerable = (from s in _activeGuidelines.ToArray()
				select s.Guide).Distinct();
			StaticSL[] guidelines = enumerable.Where((StaticSL g) => (g.IsHorizontal ? thresholdPoint.Y : thresholdPoint.X) < 0.0).ToArray();
			StaticGuidelines.RemoveStaticSLs(guidelines);
			StaticGuidelines.OnDragEnd(enumerable);
		}
		else if (e.ChangedButton == MouseButton.Right)
		{
			PopulateGuidelineContextMenu(FindMousedOverGuidelines(GetMousePosition(e)).ToArray());
			_guidelineMenu.IsOpen = true;
		}
		_activeGuidelines.Clear();
		ReleaseMouseCapture();
		e.Handled = true;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Vector2<double> mousePosition = GetMousePosition(e);
		IEnumerable<StaticGuideline> guidelines = FindMousedOverGuidelines(mousePosition);
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			if (_activeGuidelines.Count > 0)
			{
				foreach (StaticGuideline activeGuideline in _activeGuidelines)
				{
					activeGuideline.Guide.Position = (activeGuideline.Guide.IsHorizontal ? mousePosition.Y : mousePosition.X) / ZoomFactor;
				}
				InvalidateVisual();
			}
			else
			{
				UpdateCursor(_activeGuidelines);
			}
		}
		else
		{
			UpdateCursor(guidelines);
		}
		e.Handled = true;
	}

	private Vector2<double> GetMousePosition(MouseEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2<double>)e.GetPosition(this) - CanvasOrigin;
	}

	private void UpdateCursor(IEnumerable<StaticGuideline> guidelines)
	{
		SetCursor(guidelines.Any((StaticGuideline g) => g.Guide.IsHorizontal), guidelines.Any((StaticGuideline g) => !g.Guide.IsHorizontal));
	}

	private void SetCursor(bool hasHorizontal, bool hasVertical)
	{
		if (hasHorizontal && hasVertical)
		{
			base.Cursor = Cursors.SizeAll;
		}
		else if (hasHorizontal)
		{
			base.Cursor = Cursors.SizeNS;
		}
		else if (hasVertical)
		{
			base.Cursor = Cursors.SizeWE;
		}
		else
		{
			base.Cursor = null;
		}
	}

	private static bool IsGuidelineEditable(GuidelineBase guideline)
	{
		if (guideline is StaticGuideline staticGuideline)
		{
			return staticGuideline.Guide.IsEditable;
		}
		return false;
	}

	private IEnumerable<StaticGuideline> FindMousedOverGuidelines(Vector2<double> mousePosition)
	{
		IEnumerable<StaticGuideline> mousedOverGuidelines = from g in _guidelines.OfType<StaticGuideline>()
			where IsGuidelineEditable(g) && g.Bounds.Contains(mousePosition)
			select g;
		return mousedOverGuidelines.Where((StaticGuideline g) => g == mousedOverGuidelines.FirstOrDefault((StaticGuideline s) => s.Guide.IsHorizontal) || g == mousedOverGuidelines.FirstOrDefault((StaticGuideline s) => !s.Guide.IsHorizontal));
	}
}
