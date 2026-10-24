using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.TabStop;
using Pro.UI.Utility;

namespace Pro.Editor.Canvas.Controls;

public class TabStopsControl : FrameworkElement
{
	private readonly ContextMenu _tabStopMenu;

	private readonly MenuItem _deleteMenu;

	private readonly List<TabStopControlBase> _tabStops = new List<TabStopControlBase>();

	private Vector2<double> _mousePos = Vector2<double>.Zero;

	private double _startDragValue;

	private TabStopControlBase? _activeStop;

	public static readonly DependencyProperty CanvasOriginProperty = DependencyProperty.Register("CanvasOrigin", typeof(Vector2<double>), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty OriginOffsetProperty = DependencyProperty.Register("OriginOffset", typeof(double), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ScrollOffSetProperty = DependencyProperty.Register("ScrollOffSet", typeof(double), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty TabStopsProperty = DependencyProperty.Register("TabStops", typeof(TabStopControlCollection), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TabStopsPropertyChanged)));

	public static readonly DependencyProperty TabStopColorProperty = DependencyProperty.Register("TabStopColor", typeof(Brush), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DarkGray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty TabStopLineColorProperty = DependencyProperty.Register("TabStopLineColor", typeof(Brush), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DarkGray, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty DeleteMenuHeaderProperty = DependencyProperty.Register("DeleteMenuHeader", typeof(string), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(DeleteMenuHeaderPropertyChanged)));

	public static readonly DependencyProperty RulerHeightProperty = DependencyProperty.Register("RulerHeight", typeof(double), typeof(TabStopsControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0));

	protected override int VisualChildrenCount => _tabStops.Count;

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

	public double OriginOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OriginOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginOffsetProperty, (object)value);
		}
	}

	public double RulerHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RulerHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RulerHeightProperty, (object)value);
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

	public double ScrollOffSet
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScrollOffSetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollOffSetProperty, (object)value);
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

	public Brush TabStopColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TabStopColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabStopColorProperty, (object)value);
		}
	}

	public Brush TabStopLineColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TabStopLineColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabStopLineColorProperty, (object)value);
		}
	}

	public string DeleteMenuHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DeleteMenuHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteMenuHeaderProperty, (object)value);
		}
	}

	private static void TabStopsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TabStopsControl)(object)d).ReloadTabStops(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TabStopControlCollection, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TabStopControlCollection);
	}

	private static void DeleteMenuHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TabStopsControl)(object)d)._deleteMenu.Header = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	public TabStopsControl()
	{
		_tabStopMenu = new ContextMenu();
		_deleteMenu = new MenuItem();
		_deleteMenu.Click += DeleteMenu_Click;
		_tabStopMenu.Items.Add(_deleteMenu);
		base.Visibility = Visibility.Hidden;
	}

	protected override Visual? GetVisualChild(int index)
	{
		return _tabStops.ElementAtOrDefault(index);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		TabStopControlCollection? tabStops = TabStops;
		if (tabStops == null || !tabStops.IsEditing)
		{
			return;
		}
		foreach (TabStopControlBase tabStop in _tabStops)
		{
			tabStop.RenderTabStop(CanvasOrigin, ZoomFactor, ScrollOffSet, OriginOffset, new Vector2<double>(base.ActualWidth, base.ActualHeight), new Pen(TabStopColor, 1.0));
		}
		if (_activeStop != null)
		{
			drawingContext.DrawLine(new Pen(TabStopLineColor, 0.25), new Vector2<double>(_activeStop.XOrigin, 0.0), new Vector2<double>(_activeStop.XOrigin, base.ActualHeight));
			drawingContext.DrawRectangle(new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)), null, new Rect<double>(new Vector2<double>(_activeStop.XOrigin, -20.0), new Vector2<double>(55.0, 20.0)));
			FormattedText formattedText = new FormattedText($"{_activeStop.CalculatePosition():0.00} px", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), 10.0, Brushes.White, 1.0);
			drawingContext.DrawText(formattedText, new Vector2<double>(_activeStop.XOrigin + 5.0, -18.0));
		}
	}

	private void ReloadTabStops(TabStopControlCollection? oldValue, TabStopControlCollection? newValue)
	{
		_tabStops.ForEach(RemoveTabStop);
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= TabStops_CollectionChanged;
			oldValue.VisualInvalidated -= base.InvalidateVisual;
			oldValue.PropertyChanged -= TabStops_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += TabStops_CollectionChanged;
			newValue.VisualInvalidated += base.InvalidateVisual;
			newValue.PropertyChanged += TabStops_PropertyChanged;
			newValue.ForEach(AddTabStop);
		}
		InvalidateVisual();
	}

	private void TabStops_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsEditing")
		{
			TabStopControlCollection? tabStops = TabStops;
			base.Visibility = ((tabStops == null || !tabStops.IsEditing) ? Visibility.Hidden : Visibility.Visible);
		}
	}

	private void TabStops_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<TabStopControlBase>().ForEach(RemoveTabStop);
		e.NewItems?.OfType<TabStopControlBase>().ForEach(AddTabStop);
	}

	private void AddTabStop(TabStopControlBase tabStop)
	{
		if (tabStop != null && !_tabStops.Contains(tabStop))
		{
			_tabStops.Add(tabStop);
			AddVisualChild(tabStop);
		}
	}

	private void RemoveTabStop(TabStopControlBase tabStop)
	{
		if (tabStop != null && _tabStops.Contains(tabStop))
		{
			_tabStops.Remove(tabStop);
			RemoveVisualChild(tabStop);
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton != 0)
		{
			return;
		}
		_mousePos = (Vector2<double>)e.GetPosition(this);
		_activeStop = e.FindHitElement<TabStopControlBase>(this);
		_startDragValue = _activeStop?.Position ?? 0.0;
		if (_activeStop != null)
		{
			if (e.ClickCount == 2)
			{
				TabStops?.ChangeTabStopType(_activeStop);
			}
			InvalidateVisual();
		}
		CaptureMouse();
		e.Handled = true;
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left)
		{
			if (_activeStop != null)
			{
				Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
				if (_activeStop.CanRemove && (vector.Y < 0.0 || vector.Y > RulerHeight))
				{
					TabStops?.RemoveTabStopData(_activeStop);
				}
			}
		}
		else if (e.ChangedButton == MouseButton.Right)
		{
			TabStopControlBase tabStopControlBase = e.FindHitElement<TabStopControlBase>(this);
			if (tabStopControlBase != null && tabStopControlBase.CanRemove)
			{
				_deleteMenu.Tag = tabStopControlBase;
				_tabStopMenu.IsOpen = true;
			}
		}
		ReleaseMouseCapture();
		e.Handled = true;
		_mousePos = Vector2<double>.Zero;
		_activeStop = null;
		InvalidateVisual();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> movePos = (Vector2<double>)e.GetPosition(this);
		TabStopControlBase tabStopControlBase = e.FindHitElement<TabStopControlBase>(this);
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			DragActiveStop(movePos, _mousePos);
		}
		else
		{
			base.Cursor = ((tabStopControlBase != null) ? Cursors.SizeWE : null);
		}
		e.Handled = true;
	}

	private void DeleteMenu_Click(object? sender, RoutedEventArgs e)
	{
		if (_deleteMenu.Tag is TabStopControlBase tabStop)
		{
			TabStops?.RemoveTabStopData(tabStop);
		}
		_deleteMenu.Tag = null;
	}

	internal void AddStopFromRuler(Vector2<double> pos)
	{
		TabStops?.AddTabStop(pos);
		_activeStop = TabStops?.LastOrDefault();
		_startDragValue = _activeStop?.Position ?? 0.0;
		base.IsHitTestVisible = false;
	}

	internal void Reset()
	{
		_activeStop = null;
		base.IsHitTestVisible = true;
		InvalidateVisual();
	}

	internal void DragActiveStop(Vector2<double> movePos, Vector2<double> startPos)
	{
		if (_activeStop != null && movePos.X.IsInRange(0.0, base.ActualWidth))
		{
			double dragPosition = (movePos.X - startPos.X) / ZoomFactor;
			_activeStop.Drag(_startDragValue, dragPosition);
		}
	}
}
