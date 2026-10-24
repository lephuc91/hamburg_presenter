using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

[ContentProperty("Items")]
public abstract class FloatingHeaderControl<T, L, HK, IK> : FrameworkElement where T : class where L : class, IEnumerable<T>, INotifyCollectionChanged where HK : notnull where IK : notnull
{
	private sealed class ItemData
	{
		public bool IsVisible { get; set; }

		public bool HasSharedContext { get; }

		public FrameworkElement HeaderControl { get; }

		public FrameworkElement ItemControl { get; }

		public bool IsItemExpanded { get; set; }

		public double HeaderTop { get; set; }

		public double HeaderBottom { get; set; }

		public double ItemTop { get; set; }

		public double ItemBottom { get; set; }

		public ItemData(bool hasSharedContext, FrameworkElement headerControl, FrameworkElement itemControl)
		{
			HasSharedContext = hasSharedContext;
			HeaderControl = headerControl;
			ItemControl = itemControl;
		}
	}

	private const double LineHeight = 18.0;

	private static readonly bool ScrollScreen = SystemParameters.WheelScrollLines <= 0;

	private static readonly double ScrollScale = ((!ScrollScreen) ? ((double)SystemParameters.WheelScrollLines * 18.0) : 0.0);

	private const double MouseWheelBaseValue = 120.0;

	private const double ScrollBarVisibleTolerance = 5.0;

	private const double ScrollBarCollapsedTolerance = 15.0;

	private const double ScrollIntoViewPadding = 4.0;

	private readonly ScrollBar _scrollBar;

	private readonly List<FrameworkElement> _children = new List<FrameworkElement>();

	private readonly Dictionary<T, ItemData> _itemDataMap = new Dictionary<T, ItemData>();

	private bool _scrollBarVisible;

	private double _availableChildrenWidth = -1.0;

	private FrameworkElement? _lastBringIntoViewSource;

	private static readonly Dictionary<HK, Stack<FrameworkElement>> _headerControlCache = new Dictionary<HK, Stack<FrameworkElement>>();

	private static readonly Dictionary<IK, Stack<FrameworkElement>> _itemControlCache = new Dictionary<IK, Stack<FrameworkElement>>();

	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(L), typeof(FloatingHeaderControl<T, L, HK, IK>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ItemsPropertyChanged)));

	public static readonly DependencyProperty HeaderTemplatesProperty = DependencyProperty.Register("HeaderTemplates", typeof(List<DataTemplate>), typeof(FloatingHeaderControl<T, L, HK, IK>));

	public static readonly DependencyProperty ItemTemplatesProperty = DependencyProperty.Register("ItemTemplates", typeof(List<DataTemplate>), typeof(FloatingHeaderControl<T, L, HK, IK>));

	public static readonly DependencyProperty FillAvailableSpaceProperty = DependencyProperty.Register("FillAvailableSpace", typeof(bool), typeof(FloatingHeaderControl<T, L, HK, IK>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

	public static readonly DependencyProperty ExpandLastItemProperty = DependencyProperty.Register("ExpandLastItem", typeof(bool), typeof(FloatingHeaderControl<T, L, HK, IK>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

	public static readonly DependencyProperty CollapseScrollbarProperty = DependencyProperty.Register("CollapseScrollbar", typeof(bool), typeof(FloatingHeaderControl<T, L, HK, IK>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ScrollBarMarginProperty = DependencyProperty.Register("ScrollBarMargin", typeof(Thickness), typeof(FloatingHeaderControl<T, L, HK, IK>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Thickness(0.0), new PropertyChangedCallback(ScrollBarMarginChanged)));

	protected override int VisualChildrenCount => _children.Count;

	public L? Items
	{
		get
		{
			return (L)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public List<DataTemplate>? HeaderTemplates
	{
		get
		{
			return (List<DataTemplate>)((DependencyObject)this).GetValue(HeaderTemplatesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderTemplatesProperty, (object)value);
		}
	}

	public List<DataTemplate>? ItemTemplates
	{
		get
		{
			return (List<DataTemplate>)((DependencyObject)this).GetValue(ItemTemplatesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemTemplatesProperty, (object)value);
		}
	}

	public bool FillAvailableSpace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FillAvailableSpaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillAvailableSpaceProperty, (object)value);
		}
	}

	public bool ExpandLastItem
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ExpandLastItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExpandLastItemProperty, (object)value);
		}
	}

	public bool CollapseScrollbar
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CollapseScrollbarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollapseScrollbarProperty, (object)value);
		}
	}

	public Thickness ScrollBarMargin
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(ScrollBarMarginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollBarMarginProperty, (object)value);
		}
	}

	protected virtual bool ResetScrollOnItemsLoaded => false;

	private static void ItemsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((FloatingHeaderControl<T, L, HK, IK>)(object)callerObject).ReloadItems(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as L, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as L);
	}

	private static void ScrollBarMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((FloatingHeaderControl<T, L, HK, IK>)(object)d).SetMargin((Thickness)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected FloatingHeaderControl()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		base.ClipToBounds = true;
		HeaderTemplates = new List<DataTemplate>();
		ItemTemplates = new List<DataTemplate>();
		_scrollBar = new ScrollBar
		{
			Orientation = Orientation.Vertical,
			Minimum = 0.0,
			SmallChange = 36.0,
			LargeChange = 108.0,
			Visibility = Visibility.Hidden
		};
		_scrollBar.Scroll += delegate
		{
			InvalidateArrange();
		};
		_scrollBar.ValueChanged += delegate
		{
			InvalidateArrange();
		};
		AddChild(_scrollBar);
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(OnDataContextChanged);
		ScrollDropTarget scrollDropTarget = new ScrollDropTarget(this);
		scrollDropTarget.ScrollUp += delegate(double v)
		{
			_scrollBar.Value -= v;
		};
		scrollDropTarget.ScrollDown += delegate(double v)
		{
			_scrollBar.Value += v;
		};
	}

	protected override Visual GetVisualChild(int index)
	{
		return _children[index];
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(new Size(base.ActualWidth, base.ActualHeight)));
	}

	private void AddChild(FrameworkElement child)
	{
		_children.Add(child);
		AddLogicalChild(child);
		AddVisualChild(child);
	}

	private void RemoveChild(FrameworkElement child)
	{
		_children.Remove(child);
		RemoveLogicalChild(child);
		RemoveVisualChild(child);
	}

	private void AddItemChildren(ItemData itemData)
	{
		if (!itemData.IsVisible)
		{
			itemData.IsVisible = true;
			AddChild(itemData.ItemControl);
			AddChild(itemData.HeaderControl);
		}
	}

	private void RemoveItemChildren(ItemData itemData)
	{
		if (itemData.IsVisible)
		{
			itemData.IsVisible = false;
			RemoveChild(itemData.ItemControl);
			RemoveChild(itemData.HeaderControl);
			itemData.ItemControl.PropagateResumeLayout(null);
			itemData.HeaderControl.PropagateResumeLayout(null);
		}
	}

	private void ReloadItems(L? oldItems, L? newItems)
	{
		if (oldItems != null)
		{
			if (oldItems != null)
			{
				oldItems.CollectionChanged -= ItemsCollectionChanged;
			}
			RemoveItems(oldItems);
		}
		if (newItems != null)
		{
			if (newItems != null)
			{
				newItems.CollectionChanged += ItemsCollectionChanged;
			}
			AddItems(newItems);
		}
		InvalidateMeasure();
		InvalidateArrange();
		if (ResetScrollOnItemsLoaded)
		{
			_scrollBar.Value = 0.0;
		}
	}

	private void ItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			RemoveItems(_itemDataMap.Keys.ToArray());
			AddItems(Items);
		}
		else
		{
			if (e.OldItems != null)
			{
				RemoveItems(e.OldItems.Cast<T>());
			}
			if (e.NewItems != null)
			{
				AddItems(e.NewItems.Cast<T>());
			}
		}
		InvalidateMeasure();
		InvalidateArrange();
	}

	protected virtual void RemoveItems(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			if (!_itemDataMap.TryGetValue(item, out ItemData value))
			{
				Log.Warning("Failed to find item in item map during remove items, skipping");
				continue;
			}
			RemoveItemChildren(value);
			value.HeaderControl.DataContext = null;
			value.ItemControl.DataContext = null;
			if (value.IsItemExpanded)
			{
				value.ItemControl.Height = double.NaN;
			}
			StoreControlInCache(GetHeaderKey(item), _headerControlCache, value.HeaderControl);
			StoreControlInCache(GetItemKey(item), _itemControlCache, value.ItemControl);
			_itemDataMap.Remove(item);
		}
	}

	protected virtual void AddItems(IEnumerable<T>? items)
	{
		foreach (T item in items ?? Enumerable.Empty<T>())
		{
			bool hasSharedContext = false;
			FrameworkElement frameworkElement = item as FrameworkElement;
			if (frameworkElement != null)
			{
				hasSharedContext = true;
				frameworkElement.DataContext = base.DataContext;
				frameworkElement.RequestBringIntoView += BringChildIntoView;
			}
			else
			{
				frameworkElement = LoadItemControl(item);
				frameworkElement.DataContext = item;
			}
			FrameworkElement frameworkElement2 = LoadHeaderControl(item);
			frameworkElement2.DataContext = frameworkElement.DataContext;
			_itemDataMap.Add(item, new ItemData(hasSharedContext, frameworkElement2, frameworkElement));
		}
	}

	protected FrameworkElement? GetHeaderControl(T? item)
	{
		if (item == null || !_itemDataMap.TryGetValue(item, out ItemData value))
		{
			return null;
		}
		return value.HeaderControl;
	}

	protected FrameworkElement? GetItemControl(T? item)
	{
		if (item == null || !_itemDataMap.TryGetValue(item, out ItemData value))
		{
			return null;
		}
		return value.ItemControl;
	}

	protected abstract HK GetHeaderKey(T item);

	protected abstract IK GetItemKey(T item);

	protected abstract DataTemplate? FindHeaderTemplate(HK key);

	protected abstract DataTemplate? FindItemTemplate(IK key);

	private FrameworkElement LoadHeaderControl(T item)
	{
		HK headerKey = GetHeaderKey(item);
		object obj;
		if (!TryGetControlFromCache(headerKey, _headerControlCache, out FrameworkElement control))
		{
			obj = FindHeaderTemplate(headerKey)?.LoadContent() as FrameworkElement;
			if (obj == null)
			{
				return new FrameworkElement();
			}
		}
		else
		{
			obj = control;
		}
		return (FrameworkElement)obj;
	}

	private FrameworkElement LoadItemControl(T item)
	{
		IK itemKey = GetItemKey(item);
		if (TryGetControlFromCache(itemKey, _itemControlCache, out FrameworkElement control))
		{
			return control;
		}
		control = (FindItemTemplate(itemKey)?.LoadContent() as FrameworkElement) ?? new FrameworkElement();
		control.RequestBringIntoView += BringChildIntoView;
		return control;
	}

	private static bool TryGetControlFromCache<TK>(TK key, Dictionary<TK, Stack<FrameworkElement>> cache, [NotNullWhen(true)] out FrameworkElement? control) where TK : notnull
	{
		control = null;
		if (cache.TryGetValue(key, out Stack<FrameworkElement> value) && value.Any())
		{
			control = value.Pop();
			return true;
		}
		return false;
	}

	private static void StoreControlInCache<TK>(TK key, Dictionary<TK, Stack<FrameworkElement>> cache, FrameworkElement control) where TK : notnull
	{
		if (!cache.TryGetValue(key, out Stack<FrameworkElement> value))
		{
			value = new Stack<FrameworkElement>();
			cache.Add(key, value);
		}
		value.Push(control);
	}

	private void OnDataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		foreach (ItemData item in _itemDataMap.Values.Where((ItemData d) => d.HasSharedContext))
		{
			item.ItemControl.DataContext = newValue;
			item.HeaderControl.DataContext = newValue;
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		double num = MeasureItems(availableSize);
		double num2 = ((Size)(ref availableSize)).Height - num;
		bool flag = _scrollBarVisible;
		if (FillAvailableSpace)
		{
			num2 += 15.0;
		}
		if (num2 < 5.0)
		{
			flag = true;
		}
		else if (num2 >= 15.0)
		{
			flag = false;
		}
		_scrollBar.Measure(availableSize);
		if (_scrollBarVisible != flag)
		{
			_scrollBarVisible = flag;
			_scrollBar.Visibility = ((!_scrollBarVisible) ? Visibility.Hidden : Visibility.Visible);
			num = MeasureItems(availableSize);
		}
		_scrollBar.Maximum = Math.Max(num - ((Size)(ref availableSize)).Height, 0.0);
		_scrollBar.ViewportSize = ((Size)(ref availableSize)).Height;
		return availableSize;
	}

	private void SetMargin(Thickness margin)
	{
		_scrollBar.Margin = margin;
	}

	private double MeasureItems(Size availableSize)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		double width = ((Size)(ref availableSize)).Width;
		double num;
		Size desiredSize;
		if (!_scrollBarVisible && CollapseScrollbar)
		{
			num = 0.0;
		}
		else
		{
			desiredSize = _scrollBar.DesiredSize;
			num = Math.Max(0.0, ((Size)(ref desiredSize)).Width);
		}
		double x = Math.Max(0.0, width - num);
		Vector2<double> vector = new Vector2<double>(x, double.PositiveInfinity);
		double num2 = 0.0;
		if (Items != null)
		{
			foreach (T item in Items)
			{
				if (!_itemDataMap.TryGetValue(item, out ItemData value))
				{
					Log.Warning("Failed to find item in item map during measure, skipping");
					continue;
				}
				FrameworkElement itemControl = value.ItemControl;
				FrameworkElement headerControl = value.HeaderControl;
				if (value.IsItemExpanded)
				{
					itemControl.Height = double.NaN;
					value.IsItemExpanded = false;
				}
				itemControl.Measure(vector);
				headerControl.Measure(vector);
				if (FillAvailableSpace && item == Items.Last())
				{
					desiredSize = itemControl.DesiredSize;
					double height = ((Size)(ref desiredSize)).Height;
					double height2 = ((Size)(ref availableSize)).Height;
					desiredSize = headerControl.DesiredSize;
					double num3 = Math.Max(height, height2 - ((Size)(ref desiredSize)).Height - (ExpandLastItem ? 0.0 : num2));
					if (height < num3)
					{
						value.IsItemExpanded = true;
						itemControl.Height = num3;
						itemControl.Measure(vector);
					}
				}
				double num4 = num2;
				desiredSize = headerControl.DesiredSize;
				double height3 = ((Size)(ref desiredSize)).Height;
				desiredSize = itemControl.DesiredSize;
				num2 = num4 + (height3 + ((Size)(ref desiredSize)).Height);
			}
		}
		return num2;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		double width = ((Size)(ref finalSize)).Width;
		double num;
		Size desiredSize;
		if (!_scrollBarVisible)
		{
			num = 0.0;
		}
		else
		{
			desiredSize = _scrollBar.DesiredSize;
			num = ((Size)(ref desiredSize)).Width;
		}
		_availableChildrenWidth = width - num;
		double num2 = 0.0 - _scrollBar.Value;
		double viewportSize = _scrollBar.ViewportSize;
		if (Items != null)
		{
			foreach (T item in Items)
			{
				if (!_itemDataMap.TryGetValue(item, out ItemData value))
				{
					Log.Warning("Failed to find item in item map during arrange, skipping");
					continue;
				}
				FrameworkElement headerControl = value.HeaderControl;
				double num3 = num2;
				desiredSize = headerControl.DesiredSize;
				double height = ((Size)(ref desiredSize)).Height;
				double num4 = num3 + height;
				FrameworkElement itemControl = value.ItemControl;
				double num5 = num4;
				desiredSize = itemControl.DesiredSize;
				double height2 = ((Size)(ref desiredSize)).Height;
				double num6 = num5 + height2;
				value.HeaderTop = num3;
				value.HeaderBottom = num4;
				value.ItemTop = num5;
				value.ItemBottom = num6;
				if (num3 <= 0.0 && num6 >= 0.0)
				{
					num3 = Math.Min(num6 - height, 0.0);
				}
				bool flag = (num4 >= 0.0 && num3 <= viewportSize) || (num6 >= 0.0 && num5 <= viewportSize);
				if (flag)
				{
					AddItemChildren(value);
				}
				else
				{
					RemoveItemChildren(value);
				}
				if (itemControl is IVirtualizableControl virtualizableControl)
				{
					double num7 = Math.Max(0.0 - num5, 0.0);
					Rect<double> viewport = new Rect<double>(0.0, num7, _availableChildrenWidth, Math.Min(height2 - num7, viewportSize - num5));
					double y = Math.Max(num5, 0.0);
					virtualizableControl.InView = flag;
					virtualizableControl.Viewport = viewport;
					if (flag)
					{
						itemControl.Arrange(new Rect<double>(new Vector2<double>(0.0, y), new Vector2<double>(_availableChildrenWidth, viewport.Height)));
						headerControl.Arrange(new Rect<double>(new Vector2<double>(0.0, num3), new Vector2<double>(_availableChildrenWidth, height)));
					}
				}
				else if (flag)
				{
					itemControl.Arrange(new Rect<double>(new Vector2<double>(0.0, num5), new Vector2<double>(_availableChildrenWidth, height2)));
					headerControl.Arrange(new Rect<double>(new Vector2<double>(0.0, num3), new Vector2<double>(_availableChildrenWidth, height)));
				}
				num2 += height + height2;
			}
		}
		ScrollBar scrollBar = _scrollBar;
		double width2 = ((Size)(ref finalSize)).Width;
		desiredSize = _scrollBar.DesiredSize;
		Point val = new Point(width2 - ((Size)(ref desiredSize)).Width, 0.0);
		desiredSize = _scrollBar.DesiredSize;
		scrollBar.Arrange(new Rect(val, new Size(((Size)(ref desiredSize)).Width, ((Size)(ref finalSize)).Height)));
		return base.ArrangeOverride(new Size(((Size)(ref finalSize)).Width, _scrollBar.ViewportSize));
	}

	public void ScrollIntoView(T? item, double additionalOffset = 0.0, double? itemHeight = null, bool scrollToTop = false)
	{
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			OnScrollIntoView(item, additionalOffset, itemHeight, scrollToTop);
		});
	}

	protected void OnScrollIntoView(T? item, double additionalOffset = 0.0, double? itemHeight = null, bool scrollToTop = false)
	{
		UpdateLayout();
		if (item == null || !_itemDataMap.TryGetValue(item, out ItemData itemData))
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			double num = getOffset();
			double num2 = Math.Round(_scrollBar.Value + num);
			bool flag = num2 - 4.0 <= Math.Ceiling(_scrollBar.Maximum);
			if ((!(num < -1.0) && !(num > 4.0)) || !(num2 >= Math.Floor(_scrollBar.Minimum)))
			{
				break;
			}
			_scrollBar.Value = (flag ? num2 : _scrollBar.Maximum);
			InvalidateArrange();
			UpdateLayout();
		}
		OnPostScrollIntoView();
		double getOffset()
		{
			double viewportSize = _scrollBar.ViewportSize;
			double num3 = (itemHeight ?? (itemData.ItemBottom - itemData.ItemTop)) + 4.0;
			double num4 = itemData.ItemTop + additionalOffset;
			double num5 = num4 + num3;
			num4 -= itemData.HeaderBottom - itemData.HeaderTop;
			if (scrollToTop || num4 < 0.0 || num3 > viewportSize)
			{
				return num4;
			}
			if (num5 > viewportSize)
			{
				return num5 - viewportSize;
			}
			return 0.0;
		}
	}

	protected void ScrollToEnd()
	{
		_scrollBar.Value = _scrollBar.Maximum;
	}

	protected virtual void OnPostScrollIntoView()
	{
	}

	private void BringChildIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (Mouse.LeftButton != MouseButtonState.Pressed && Mouse.RightButton != MouseButtonState.Pressed && sender is FrameworkElement frameworkElement && frameworkElement is T item)
		{
			FrameworkElement frameworkElement2 = (FrameworkElement)e.OriginalSource;
			if (_lastBringIntoViewSource != frameworkElement2)
			{
				_lastBringIntoViewSource = frameworkElement2;
				Point val = frameworkElement2.TranslatePoint(Vector2<double>.Zero, frameworkElement);
				ScrollIntoView(item, ((Point)(ref val)).Y, frameworkElement2.ActualHeight);
				e.Handled = true;
			}
		}
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		if (base.IsMouseOver && CanScroll(e))
		{
			e.Handled = true;
			_scrollBar.Value += (double)(-e.Delta) / 120.0 * ((!ScrollScreen) ? ScrollScale : _scrollBar.ViewportSize);
			InvalidateArrange();
		}
	}

	protected virtual bool CanScroll(MouseWheelEventArgs e)
	{
		return true;
	}

	protected void CalculateOffsets(T item, Rect<double> bounds, out double topOffset, out double heightOffset)
	{
		double? num = base.ActualHeight - GetHeaderControl(item)?.ActualHeight;
		topOffset = Math.Max(0.0, bounds.Top - bounds.Height);
		heightOffset = bounds.Height * 3.0;
		if (heightOffset > num)
		{
			topOffset = bounds.Top;
			heightOffset = bounds.Height * 2.0;
		}
		if (heightOffset > num)
		{
			heightOffset = bounds.Height;
		}
	}
}
public class FloatingHeaderControl<T, L> : FloatingHeaderControl<T, L, Type, Type> where T : class where L : class, IEnumerable<T>, INotifyCollectionChanged
{
	protected override Type GetHeaderKey(T item)
	{
		return GetKey(item);
	}

	protected override Type GetItemKey(T item)
	{
		return GetKey(item);
	}

	private static Type GetKey(T item)
	{
		return item?.GetType() ?? typeof(T);
	}

	protected override DataTemplate? FindHeaderTemplate(Type key)
	{
		return FindTemplate(base.HeaderTemplates, key);
	}

	protected override DataTemplate? FindItemTemplate(Type key)
	{
		return FindTemplate(base.ItemTemplates, key);
	}

	private static DataTemplate? FindTemplate(List<DataTemplate>? templates, Type key)
	{
		object obj = templates?.FirstOrDefault((DataTemplate t) => (t.DataType as Type)?.IsAssignableFrom(key) ?? false);
		if (obj == null)
		{
			if (templates == null)
			{
				return null;
			}
			obj = templates.FirstOrDefault();
		}
		return (DataTemplate?)obj;
	}
}
