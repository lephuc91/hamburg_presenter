using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.UI.ErrorHandling;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Thumbnails;

public abstract class UniformViewPanel<TSource, TControl> : FrameworkElement, IVirtualizableControl where TSource : class, IUniformViewSource where TControl : FrameworkElement, IUniformViewControl, new()
{
	protected class ThumbnailData
	{
		public TSource Source { get; }

		[MemberNotNullWhen(true, "Control")]
		public bool HasControl
		{
			[MemberNotNullWhen(true, "Control")]
			get
			{
				return Control != null;
			}
		}

		public TControl? Control { get; private set; }

		public Vector2<double> MeasureSize { get; set; } = Vector2<double>.Zero;

		public Vector2<double> DesiredSize { get; set; } = Vector2<double>.Zero;

		public bool IsControlMeasured { get; set; }

		public Rect<double> Bounds { get; set; } = Rect<double>.Empty;

		public ThumbnailData(TSource source)
		{
			Source = source;
		}

		public void AssignControl(UniformViewPanel<TSource, TControl> panel)
		{
			if (!HasControl)
			{
				Control = panel.SetupThumbnailControl(Source);
				panel.AddChild(Control);
			}
		}

		public void ClearControl(UniformViewPanel<TSource, TControl> panel)
		{
			if (HasControl)
			{
				panel.RemoveChild(Control);
				IsControlMeasured = false;
				Control.TearDown();
				UniformViewPanel<TSource, TControl>._thumbnailCache.Push(Source.ThumbnailAspectRatio, Control);
				Control = null;
			}
		}

		public void ResetLayout()
		{
			MeasureSize = Vector2<double>.Zero;
			DesiredSize = Vector2<double>.Zero;
			IsControlMeasured = false;
			Bounds = Rect<double>.Empty;
		}

		public void ControlMeasure(Vector2<double> availableSize)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			if (!HasControl)
			{
				throw new InvalidOperationException();
			}
			Control.Measure(availableSize);
			MeasureSize = availableSize;
			DesiredSize = (Vector2<double>)Control.DesiredSize;
			IsControlMeasured = true;
		}

		public void SoftMeasure(Vector2<double> availableSize, Vector2<double> desiredSize)
		{
			MeasureSize = availableSize;
			DesiredSize = desiredSize;
		}

		public void HardMeasure()
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			if (!HasControl)
			{
				throw new InvalidOperationException();
			}
			Control.Measure(MeasureSize);
			IsControlMeasured = true;
		}
	}

	private sealed class ThumbnailCache
	{
		private readonly Dictionary<double, Stack<TControl>> _segregatedCaches = new Dictionary<double, Stack<TControl>>();

		public void Push(double aspectRatio, TControl thumbnail)
		{
			if (_segregatedCaches.TryGetValue(aspectRatio, out Stack<TControl> value))
			{
				value.Push(thumbnail);
				return;
			}
			Stack<TControl> stack = new Stack<TControl>();
			stack.Push(thumbnail);
			_segregatedCaches.Add(aspectRatio, stack);
		}

		public TControl Pop(double aspectRatio)
		{
			if (!_segregatedCaches.TryGetValue(aspectRatio, out Stack<TControl> value) || !value.Any())
			{
				return new TControl();
			}
			return value.Pop();
		}
	}

	private const double MinimumPanelHeight = 150.0;

	private const double ListViewMargin = 5.0;

	private bool _ignoreSelectionChanges;

	private readonly List<FrameworkElement> _children = new List<FrameworkElement>();

	private readonly ModificationWhileEnumerationReportingList<ThumbnailData> _thumbnails = new ModificationWhileEnumerationReportingList<ThumbnailData>();

	private Vector2<double>? _mouseDownPos;

	private bool _selectDragging;

	private readonly SelectionBox _selectionBox = new SelectionBox();

	private static readonly ThumbnailCache _thumbnailCache = new ThumbnailCache();

	private bool _inView;

	private Rect<double> _viewPort = Rect<double>.Empty;

	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable<TSource>), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ItemsPropertyChanged)));

	public static readonly DependencyProperty ViewSettingsProperty = DependencyProperty.Register("ViewSettings", typeof(IPanelViewSettings), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(ViewSettingsPropertyChanged)));

	public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(TSource), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedItemPropertyChanged)));

	public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<TSource>), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedItemsPropertyChanged)));

	public static readonly DependencyProperty ActiveItemProperty = DependencyProperty.Register("ActiveItem", typeof(TSource), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ActiveItemPropertyChanged)));

	public static readonly DependencyProperty ActiveItemsProperty = DependencyProperty.Register("ActiveItems", typeof(IEnumerable<TSource>), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ActiveItemsPropertyChanged)));

	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)4, new PropertyChangedCallback(RowCapacityPropertyChanged)));

	public static readonly DependencyProperty MinimumListViewHeightProperty = DependencyProperty.Register("MinimumListViewHeight", typeof(double), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)35.0));

	public static readonly DependencyProperty ListViewHeightIncrementProperty = DependencyProperty.Register("ListViewHeightIncrement", typeof(double), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)550.0));

	public static readonly DependencyProperty ClearSelectionOnActivationProperty = DependencyProperty.Register("ClearSelectionOnActivation", typeof(bool), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowIndexProperty = DependencyProperty.Register("ShowIndex", typeof(bool), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ThumbnailContextMenuProperty = DependencyProperty.Register("ThumbnailContextMenu", typeof(ContextMenu), typeof(UniformViewPanel<TSource, TControl>));

	public static readonly DependencyProperty ActiveBrushProperty = DependencyProperty.Register("ActiveBrush", typeof(Brush), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(Brush)AppTheme.Active.THUMBNAILPRESENTATION, new PropertyChangedCallback(ActiveBrushPropertyChanged)));

	public static readonly DependencyProperty ActiveListBrushProperty = DependencyProperty.Register("ActiveListBrush", typeof(Brush), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(Brush)AppTheme.Active.THUMBNAILLISTPRESENTATION, new PropertyChangedCallback(ActiveBrushPropertyChanged)));

	public static readonly DependencyProperty ActiveBorderBrushProperty = DependencyProperty.Register("ActiveBorderBrush", typeof(Brush), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(Brush)AppTheme.Active.THUMBNAILPRESENTATIONBORDER, new PropertyChangedCallback(ActiveBrushPropertyChanged)));

	public static readonly DependencyProperty ItemActivatedCommandProperty = DependencyProperty.Register("ItemActivatedCommand", typeof(ICommand<TSource>), typeof(UniformViewPanel<TSource, TControl>));

	public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(DisplayMode), typeof(UniformViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DisplayMode.Label));

	protected override int VisualChildrenCount => _children.Count;

	public bool InView
	{
		get
		{
			return _inView;
		}
		set
		{
			if (_inView != value)
			{
				_inView = value;
				InvalidateArrange();
			}
		}
	}

	public Rect<double> Viewport
	{
		get
		{
			return _viewPort;
		}
		set
		{
			if (_viewPort != value)
			{
				_viewPort = value;
				InvalidateArrange();
			}
		}
	}

	protected IEnumerable<ThumbnailData> Thumbnails => _thumbnails;

	protected bool IsThumbnailMode
	{
		get
		{
			IPanelViewSettings? viewSettings = ViewSettings;
			if (viewSettings == null || viewSettings.ViewType != 0)
			{
				IPanelViewSettings? viewSettings2 = ViewSettings;
				if (viewSettings2 == null)
				{
					return false;
				}
				return viewSettings2.ViewType == PanelViewType.EasyView;
			}
			return true;
		}
	}

	protected bool IsListMode
	{
		get
		{
			IPanelViewSettings? viewSettings = ViewSettings;
			if (viewSettings == null)
			{
				return false;
			}
			return viewSettings.ViewType == PanelViewType.List;
		}
	}

	public IEnumerable<TSource>? Items
	{
		get
		{
			return (IEnumerable<TSource>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public IPanelViewSettings? ViewSettings
	{
		get
		{
			return (IPanelViewSettings)((DependencyObject)this).GetValue(ViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewSettingsProperty, (object)value);
		}
	}

	public TSource? SelectedItem
	{
		get
		{
			return (TSource)((DependencyObject)this).GetValue(SelectedItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemProperty, (object)value);
		}
	}

	public ObservableCollection<TSource>? SelectedItems
	{
		get
		{
			return (ObservableCollection<TSource>)((DependencyObject)this).GetValue(SelectedItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemsProperty, (object)value);
		}
	}

	public TSource? ActiveItem
	{
		get
		{
			return (TSource)((DependencyObject)this).GetValue(ActiveItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveItemProperty, (object)value);
		}
	}

	public IEnumerable<TSource>? ActiveItems
	{
		get
		{
			return (IEnumerable<TSource>)((DependencyObject)this).GetValue(ActiveItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveItemsProperty, (object)value);
		}
	}

	public int RowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowCapacityProperty, (object)value);
		}
	}

	public double MinimumListViewHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumListViewHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumListViewHeightProperty, (object)value);
		}
	}

	public double ListViewHeightIncrement
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ListViewHeightIncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListViewHeightIncrementProperty, (object)value);
		}
	}

	public bool ClearSelectionOnActivation
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClearSelectionOnActivationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearSelectionOnActivationProperty, (object)value);
		}
	}

	public bool ShowIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIndexProperty, (object)value);
		}
	}

	public ContextMenu? ThumbnailContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(ThumbnailContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailContextMenuProperty, (object)value);
		}
	}

	public Brush? ActiveBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveBrushProperty, (object)value);
		}
	}

	public Brush? ActiveListBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveListBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveListBrushProperty, (object)value);
		}
	}

	public Brush? ActiveBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveBorderBrushProperty, (object)value);
		}
	}

	public ICommand<TSource>? ItemActivatedCommand
	{
		get
		{
			return (ICommand<TSource>)((DependencyObject)this).GetValue(ItemActivatedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemActivatedCommandProperty, (object)value);
		}
	}

	public DisplayMode DisplayMode
	{
		get
		{
			return (DisplayMode)((DependencyObject)this).GetValue(DisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayModeProperty, (object)value);
		}
	}

	protected TSource? WasActiveItem { get; private set; }

	public event Action<UniformViewPanel<TSource, TControl>>? ViewSettingsChanged;

	private static void ItemsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).ReloadItems((IEnumerable<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IEnumerable<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void ViewSettingsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).UpdateViewSettings((IPanelViewSettings)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IPanelViewSettings)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void SelectedItemPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).UpdateSelectedItem((TSource)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RowCapacityPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).InvalidateLayout();
	}

	private static void SelectedItemsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).ReloadSelectedItems((ObservableCollection<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ObservableCollection<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void ActiveItemPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).UpdateActiveItem((TSource)((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
	}

	private static void ActiveItemsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).ReloadActiveItems((IEnumerable<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IEnumerable<TSource>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void ActiveBrushPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((UniformViewPanel<TSource, TControl>)(object)callerObject).UpdateActiveItems();
	}

	protected UniformViewPanel()
	{
		AppTheme.ThemeChanged += base.InvalidateVisual;
		ViewSettings = UIServiceProvider.GetService<ThumbnailViewSettings>();
		SelectedItems = new ObservableCollection<TSource>();
		base.Focusable = true;
		AddChild(_selectionBox);
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, delegate
		{
			SelectItems(Items ?? Enumerable.Empty<TSource>());
		});
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, ClearSelectedItems);
	}

	protected virtual void OnInvalidateParentMeasure()
	{
		(base.Parent as UIElement)?.InvalidateMeasure();
	}

	protected virtual void OnThumbnailDragged(TControl thumbnail, MouseEventArgs mouseArgs)
	{
	}

	protected void AddChild(FrameworkElement child)
	{
		_children.Add(child);
		AddLogicalChild(child);
		AddVisualChild(child);
	}

	protected void RemoveChild(FrameworkElement child)
	{
		_children.Remove(child);
		RemoveLogicalChild(child);
		RemoveVisualChild(child);
	}

	protected override Visual GetVisualChild(int index)
	{
		return _children[_children.Count - index - 1];
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(new Size(base.ActualWidth, base.ActualHeight)));
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		_thumbnails.ForEach(delegate(ThumbnailData t)
		{
			t.ResetLayout();
		});
		double availableWidth = (IsThumbnailMode ? (((Size)(ref availableSize)).Width / (double)RowCapacity) : ((Size)(ref availableSize)).Width);
		double y = Math.Max(OnMeasureHeight(_thumbnails, availableWidth), 150.0);
		return new Vector2<double>(((Size)(ref availableSize)).Width, y);
	}

	protected virtual double OnMeasureHeight(IEnumerable<ThumbnailData> thumbnails, double availableWidth)
	{
		return MeasureThumbnailVerticalExtent(thumbnails, availableWidth);
	}

	protected double MeasureThumbnailVerticalExtent(IEnumerable<ThumbnailData> thumbnails, double availableWidth)
	{
		if (thumbnails.Empty())
		{
			return 0.0;
		}
		Vector2<double> measureSize = new Vector2<double>(availableWidth, IsThumbnailMode ? double.PositiveInfinity : (MinimumListViewHeight + ListViewHeightIncrement / (double)RowCapacity));
		if (thumbnails.AllAreEqual((ThumbnailData t) => t.Source.ThumbnailAspectRatio))
		{
			ThumbnailData thumbnail = thumbnails.First();
			thumbnail.AssignControl(this);
			thumbnail.ControlMeasure(measureSize);
			thumbnails.Skip(1).ForEach(delegate(ThumbnailData t)
			{
				t.SoftMeasure(measureSize, thumbnail.DesiredSize);
			});
			if (!IsListMode)
			{
				return thumbnail.DesiredSize.Y * Math.Ceiling((double)thumbnails.Count() / (double)RowCapacity);
			}
			return thumbnail.DesiredSize.Y * (double)thumbnails.Count();
		}
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		foreach (ThumbnailData thumbnail2 in thumbnails)
		{
			if (num3 % RowCapacity == 0 || IsListMode)
			{
				num += num2;
				num2 = 0.0;
			}
			thumbnail2.AssignControl(this);
			thumbnail2.ControlMeasure(measureSize);
			num2 = Math.Max(thumbnail2.DesiredSize.Y, num2);
			num3++;
		}
		return num + num2;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		_selectionBox.Arrange(new Rect<double>(Vector2<double>.Zero, (Vector2<double>)finalSize));
		OnArrangeThumbnails(_thumbnails);
		return finalSize;
	}

	protected virtual void UpdateThumbnails()
	{
		OnArrangeThumbnails(_thumbnails);
	}

	protected virtual void OnArrangeThumbnails(IEnumerable<ThumbnailData> thumbnails)
	{
		ArrangeThumbnails(thumbnails, -Viewport.Position);
	}

	protected double ArrangeThumbnails(IEnumerable<ThumbnailData> inputThumbnails, Vector2<double> startPos)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		ThumbnailData[] array = inputThumbnails.ToArray();
		if (array.Length == 0)
		{
			return 0.0;
		}
		double num = 0.0;
		int num2 = 0;
		Vector2<double> vector = startPos;
		Rect<double> sourceRect = new Rect<double>(Vector2<double>.Zero, (Viewport == Rect<double>.Empty) ? ((Vector2<double>)base.DesiredSize) : Viewport.Size);
		ThumbnailData[] array2 = array;
		foreach (ThumbnailData thumbnailData in array2)
		{
			if (num2 % RowCapacity == 0 || IsListMode)
			{
				vector = new Vector2<double>(0.0, vector.Y + num);
				num = 0.0;
			}
			num2++;
			Vector2<double> position = vector;
			Vector2<double> size;
			if (!IsListMode)
			{
				size = thumbnailData.DesiredSize;
			}
			else
			{
				Size desiredSize = base.DesiredSize;
				size = new Vector2<double>(((Size)(ref desiredSize)).Width - 5.0, thumbnailData.DesiredSize.Y);
			}
			thumbnailData.Bounds = new Rect<double>(position, size);
			vector.X += thumbnailData.DesiredSize.X;
			num = Math.Max(num, thumbnailData.DesiredSize.Y);
			if (InView && sourceRect.Intersects(thumbnailData.Bounds))
			{
				thumbnailData.AssignControl(this);
				thumbnailData.Control.ThrowWhenNull("thumbnail.Control");
				thumbnailData.Control.Index = thumbnailData.Source.Index;
				if (!thumbnailData.IsControlMeasured || !thumbnailData.Control.IsMeasureValid)
				{
					thumbnailData.HardMeasure();
				}
				thumbnailData.Control.Arrange(thumbnailData.Bounds);
			}
			else
			{
				thumbnailData.ClearControl(this);
			}
		}
		return vector.Y - startPos.Y + num;
	}

	protected ThumbnailData? FindThumbnail(TSource item)
	{
		return _thumbnails.FirstOrDefault((ThumbnailData t) => t.Source == item);
	}

	protected ThumbnailData? FindThumbnail(DragEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return FindThumbnail((Vector2<double>)e.GetPosition(this));
	}

	protected ThumbnailData? FindThumbnail(Vector2<double> position)
	{
		return _thumbnails.FirstMatchOrLastOrDefault((ThumbnailData t) => t.Bounds.Contains(position));
	}

	public Rect<double> GetThumbnailBounds(TSource item)
	{
		ThumbnailData thumbnailData = _thumbnails.FirstOrDefault((ThumbnailData t) => t.Source == item);
		if (thumbnailData != null)
		{
			return new Rect<double>(thumbnailData.Bounds.Position + Viewport.Position, thumbnailData.Bounds.Size);
		}
		return Rect<double>.Empty;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Focus();
		if (e.ChangedButton == MouseButton.Left && !(e.Source is TControl))
		{
			CaptureMouse();
			_mouseDownPos = (Vector2<double>)e.GetPosition(this);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left && e.FindHitElement<TControl>(this) == null && !_selectDragging)
		{
			ClearSelectedItems();
		}
		_mouseDownPos = null;
		_selectDragging = false;
		ReleaseMouseCapture();
		HideSelectionBox();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!_mouseDownPos.HasValue)
		{
			return;
		}
		_selectDragging = true;
		if ((int)Keyboard.Modifiers == 2)
		{
			HideSelectionBox();
			ThumbnailData? thumbnailData = FindThumbnail((Vector2<double>)e.GetPosition(this));
			TSource val = ((thumbnailData != null) ? thumbnailData.Source : null);
			if (val != null && SelectedItems != null && !SelectedItems.Contains(val))
			{
				SelectedItems.Add(val);
			}
		}
		else
		{
			Rect<double> selectionBounds = GetSelectionBounds(_mouseDownPos.Value, (Vector2<double>)e.GetPosition(this));
			UpdateSelectionBounds(selectionBounds);
			SelectItemsInBounds(selectionBounds);
		}
	}

	private void UpdateSelectionBounds(Rect<double> bounds)
	{
		_selectionBox.Visibility = Visibility.Visible;
		_selectionBox.SelectionBounds = bounds;
	}

	private void HideSelectionBox()
	{
		_selectionBox.Visibility = Visibility.Hidden;
	}

	private void SelectItemsInBounds(Rect<double> selectionBounds)
	{
		if (SelectedItems != null)
		{
			IEnumerable<TSource> enumerable = from t in _thumbnails
				where selectionBounds.Intersects(t.Bounds)
				select t.Source;
			if (!SelectedItems.ContentsMatch(enumerable))
			{
				ClearSelectedItems();
				SelectItems(enumerable);
			}
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
		if ((int)Keyboard.Modifiers == 2)
		{
			HideSelectionBox();
		}
	}

	protected override void OnPreviewKeyUp(KeyEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		if (_selectDragging && _mouseDownPos.HasValue && ((int)e.Key == 118 || (int)e.Key == 119))
		{
			Rect<double> selectionBounds = GetSelectionBounds(_mouseDownPos.Value, (Vector2<double>)Mouse.GetPosition(this));
			UpdateSelectionBounds(selectionBounds);
			SelectItemsInBounds(selectionBounds);
		}
	}

	private Rect<double> GetSelectionBounds(Vector2<double> start, Vector2<double> current)
	{
		return new Rect<double>(start, new Vector2<double>(current.X.Clamp(0.0, base.ActualWidth), current.Y.Clamp(0.0, base.ActualHeight)) - start).Abs();
	}

	protected void ReloadItems(IEnumerable<TSource> oldItems, IEnumerable<TSource> newItems)
	{
		if (oldItems != null)
		{
			if (oldItems is INotifyCollectionChanged notifyCollectionChanged)
			{
				notifyCollectionChanged.CollectionChanged -= OnItemsCollectionChanged;
			}
			RemoveItems(oldItems);
		}
		if (newItems != null)
		{
			if (newItems is INotifyCollectionChanged notifyCollectionChanged2)
			{
				notifyCollectionChanged2.CollectionChanged += OnItemsCollectionChanged;
			}
			InsertItems(0, newItems);
		}
		UpdateActiveItems();
		InvalidateLayout();
	}

	private void OnItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			ThumbnailData[] array = _thumbnails.ToArray();
			foreach (ThumbnailData thumbnail in array)
			{
				RemoveItem(thumbnail);
			}
			InsertItems(0, Items ?? Enumerable.Empty<TSource>());
		}
		else
		{
			RemoveItems(e.OldItems?.Cast<TSource>());
			if (e.NewItems != null)
			{
				InsertItems(e.NewStartingIndex, e.NewItems.Cast<TSource>());
			}
		}
		InvalidateLayout();
	}

	private void InvalidateLayout()
	{
		InvalidateMeasure();
		OnInvalidateParentMeasure();
	}

	private void UpdateSelectedItem(TSource item)
	{
		if (!_ignoreSelectionChanges && item != null)
		{
			_ignoreSelectionChanges = true;
			if (SelectedItems != null && !SelectedItems.Contains(item))
			{
				ClearSelectedItems();
				SelectedItems.Add(item);
			}
			UpdateSelectedItems();
			_ignoreSelectionChanges = false;
		}
	}

	private void ReloadSelectedItems(ObservableCollection<TSource> oldItems, ObservableCollection<TSource> newItems)
	{
		if (oldItems != null)
		{
			oldItems.CollectionChanged -= OnSelectedItemsCollectionChanged;
		}
		if (newItems != null)
		{
			newItems.CollectionChanged += OnSelectedItemsCollectionChanged;
		}
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedItemProperty, (object)((newItems != null) ? newItems.FirstOrDefault() : null));
		_ignoreSelectionChanges = false;
		UpdateSelectedItems();
	}

	private void OnSelectedItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_ignoreSelectionChanges)
		{
			_ignoreSelectionChanges = true;
			DependencyProperty selectedItemProperty = SelectedItemProperty;
			ObservableCollection<TSource>? selectedItems = SelectedItems;
			((DependencyObject)this).SetCurrentValue(selectedItemProperty, (object)((selectedItems != null) ? selectedItems.FirstOrDefault() : null));
			_ignoreSelectionChanges = false;
			UpdateSelectedItems();
		}
	}

	private void UpdateSelectedItems()
	{
		_thumbnails.Where((ThumbnailData t) => t.HasControl).ForEach(delegate(ThumbnailData t)
		{
			t.Control.IsSelected = CanSelect(t.Source);
		});
	}

	private void UpdateActiveItem(TSource oldValue)
	{
		UpdateWasActiveItem(oldValue);
		UpdateActiveItems();
	}

	protected void ReloadActiveItems(IEnumerable<TSource>? oldItems, IEnumerable<TSource>? newItems)
	{
		if (oldItems is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged -= OnActiveItemsCollectionChanged;
		}
		if (newItems is INotifyCollectionChanged notifyCollectionChanged2)
		{
			notifyCollectionChanged2.CollectionChanged += OnActiveItemsCollectionChanged;
		}
		UpdateActiveItems();
	}

	private void OnActiveItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateActiveItems();
	}

	public void UpdateActiveItems()
	{
		foreach (ThumbnailData item in _thumbnails.Where((ThumbnailData t) => t.HasControl))
		{
			OnUpdateActiveItem(item);
		}
		if (ClearSelectionOnActivation)
		{
			ClearSelectedItems();
		}
	}

	protected virtual void OnUpdateActiveItem(ThumbnailData thumbnail)
	{
	}

	private void UpdateWasActiveItem(TSource newItem)
	{
		WasActiveItem = newItem;
	}

	protected virtual bool CanSelect(TSource item)
	{
		return SelectedItems?.Contains(item) ?? (SelectedItem == item);
	}

	protected virtual bool CanActivate(TSource item)
	{
		return ActiveItems?.Contains(item) ?? false;
	}

	protected virtual bool IsPanelActive(TSource item)
	{
		return true;
	}

	private void InsertItems(int index, IEnumerable<TSource> items)
	{
		items.ForEach(delegate(TSource i)
		{
			InsertItem(index++, i);
		});
	}

	private void InsertItem(int index, TSource item)
	{
		_thumbnails.Insert(index, new ThumbnailData(item));
		OnItemInserted(index, item);
	}

	protected virtual void OnItemInserted(int index, TSource item)
	{
	}

	private void RemoveItems(IEnumerable<TSource>? items)
	{
		items?.ToArray().ForEach(RemoveItem);
		SelectedItems?.RemoveRangeAndNotifyOnCompletion(items ?? Enumerable.Empty<TSource>());
	}

	private void RemoveItem(TSource item)
	{
		int index = _thumbnails.FindIndex((ThumbnailData t) => t.Source == item);
		ThumbnailData thumbnailData = _thumbnails[index];
		_thumbnails.RemoveAt(index);
		thumbnailData.ClearControl(this);
		OnItemRemoved(item);
	}

	private void RemoveItem(ThumbnailData thumbnail)
	{
		if (thumbnail != null)
		{
			_thumbnails.Remove(thumbnail);
			thumbnail.ClearControl(this);
			OnItemRemoved(thumbnail.Source);
			SelectedItems?.Remove(thumbnail.Source);
		}
	}

	protected virtual void OnItemRemoved(TSource item)
	{
	}

	private TControl SetupThumbnailControl(TSource item)
	{
		TControl val = _thumbnailCache.Pop(item.ThumbnailAspectRatio);
		OnSetupThumbnailControl(val, item);
		val.Source = item;
		val.DataContext = item;
		return val;
	}

	protected virtual void OnSetupThumbnailControl(TControl thumbnailControl, TSource item)
	{
	}

	protected virtual void UpdateViewSettings(IPanelViewSettings oldSettings, IPanelViewSettings newSettings)
	{
		_thumbnails.Where((ThumbnailData t) => t.HasControl).ForEach(delegate(ThumbnailData t)
		{
			t.Control.ViewSettings = newSettings;
		});
		InvalidateLayout();
		this.ViewSettingsChanged?.Invoke(this);
	}

	protected void OnThumbnailMenuOpening(TControl thumbnail, ModifierKeys modifiers)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		Focus();
		if (ThumbnailContextMenu != null)
		{
			ThumbnailContextMenu.PlacementTarget = thumbnail;
		}
		bool flag = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		if (!(thumbnail.Source is TSource val))
		{
			return;
		}
		bool flag2 = SelectedItem == val || (SelectedItems?.Contains(val) ?? false);
		if (!((flag && SelectedItem != null) || flag2))
		{
			((DependencyObject)this).SetCurrentValue(SelectedItemProperty, (object)val);
			if (SelectedItems != null)
			{
				ClearSelectedItems();
				SelectedItems.Add(val);
			}
		}
	}

	protected void OnThumbnailClicked(TControl thumbnail, ModifierKeys modifiers)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		Focus();
		bool flag = !modifiers.AnyFlags<ModifierKeys>((ModifierKeys)6);
		if (!(thumbnail.Source is TSource val))
		{
			return;
		}
		_ignoreSelectionChanges = true;
		if (!flag || ItemActivatedCommand == null)
		{
			if (SelectedItems != null && SelectedItems.Empty() && modifiers.AnyFlags<ModifierKeys>((ModifierKeys)4) && ActiveItem != null)
			{
				SelectedItems.Add(ActiveItem);
			}
			IEnumerable<TSource>? sourceCollection = Items ?? Enumerable.Empty<TSource>();
			IEnumerable<TSource> selectedItems = SelectedItems;
			TSource[] array = SelectionHelper<TSource>.FindSelectedItems(sourceCollection, selectedItems ?? Enumerable.Empty<TSource>(), val, modifiers).ToArray();
			if (SelectedItems != null)
			{
				TSource[] array2 = SelectedItems.Except(array).ToArray();
				TSource[] items = array.Except(array2).ToArray();
				SelectedItems.RemoveRangeAndNotifyOnCompletion(array2);
				SelectItems(items);
			}
			((DependencyObject)this).SetCurrentValue(SelectedItemProperty, (object)array.FirstOrDefault());
			UpdateSelectedItems();
		}
		_ignoreSelectionChanges = false;
		if (flag && ItemActivatedCommand != null)
		{
			ItemActivatedCommand?.Invoke(val);
			ClearSelectedItems();
		}
	}

	private void SelectItems(IEnumerable<TSource> items)
	{
		SelectedItems?.AddRangeAndNotifyOnCompletion(items);
	}

	private void ClearSelectedItems()
	{
		SelectedItems?.ClearAndNotifyOnCompletion();
	}
}
