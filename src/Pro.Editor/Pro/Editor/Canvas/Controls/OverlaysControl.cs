using System;
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
using Pro.Common.Utility;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

internal class OverlaysControl : FixedControl
{
	private const double PopoverOffset = 10.0;

	private readonly Dictionary<ICanvasElement, Dictionary<IHandleData, HandleBase[]>> _customHandles = new Dictionary<ICanvasElement, Dictionary<IHandleData, HandleBase[]>>();

	private readonly Dictionary<ICanvasElement, List<HandleBase>> _handlesMap = new Dictionary<ICanvasElement, List<HandleBase>>();

	private readonly Dictionary<ICanvasElement, PopoverControl> _popoverMap = new Dictionary<ICanvasElement, PopoverControl>();

	private readonly Dictionary<ICanvasElement, SelectionBorder> _borderMap = new Dictionary<ICanvasElement, SelectionBorder>();

	private readonly Dictionary<ICanvasElement, NotifyCollectionChangedEventHandler> _elementCollectionHandlerMap = new Dictionary<ICanvasElement, NotifyCollectionChangedEventHandler>();

	private readonly List<ICanvasElement> _updatedElements = new List<ICanvasElement>();

	private readonly List<HandleBase> _selectedHandles = new List<HandleBase>();

	public static readonly DependencyProperty RootControlProperty = DependencyProperty.Register("RootControl", typeof(CanvasControl), typeof(OverlaysControl), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty SelectedElementsProperty = DependencyProperty.Register("SelectedElements", typeof(ObservableCollection<ICanvasElement>), typeof(OverlaysControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedElementsPropertyChanged)));

	public static readonly DependencyProperty SnapControllerProperty = DependencyProperty.Register("SnapController", typeof(SnapController), typeof(OverlaysControl));

	public static readonly DependencyProperty TooltipSourceProperty = DependencyProperty.Register("TooltipSource", typeof(ITooltipDataSource), typeof(OverlaysControl));

	public static readonly DependencyProperty IsTransformActiveProperty = DependencyProperty.Register("IsTransformActive", typeof(bool), typeof(OverlaysControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty PopoverBackgroundProperty = DependencyProperty.Register("PopoverBackground", typeof(Brush), typeof(OverlaysControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black));

	public static readonly DependencyProperty PopoverForegroundProperty = DependencyProperty.Register("PopoverForeground", typeof(Brush), typeof(OverlaysControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White));

	public IEnumerable<HandleBase> SelectedHandles => _selectedHandles;

	public ObservableCollection<ICanvasElement> SelectedElements
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

	public ITooltipDataSource? TooltipSource
	{
		get
		{
			return (ITooltipDataSource)((DependencyObject)this).GetValue(TooltipSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TooltipSourceProperty, (object)value);
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

	public Brush PopoverBackground
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

	public Brush PopoverForeground
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

	public CanvasControl? RootControl
	{
		get
		{
			return (CanvasControl)((DependencyObject)this).GetValue(RootControlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RootControlProperty, (object)value);
		}
	}

	public event Action<bool, ITransform?>? TransformStateChanged;

	private static void SelectedElementsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((OverlaysControl)(object)d).ReloadHandles(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<ICanvasElement>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<ICanvasElement>);
	}

	private void ReloadHandles(ObservableCollection<ICanvasElement>? oldSelection, ObservableCollection<ICanvasElement>? newSelection)
	{
		_customHandles.Clear();
		_handlesMap.Clear();
		base.Children.Clear();
		if (oldSelection != null)
		{
			oldSelection.CollectionChanged -= SelectedElementsChanged;
		}
		if (newSelection != null)
		{
			newSelection.CollectionChanged += SelectedElementsChanged;
			foreach (ICanvasElement item in newSelection)
			{
				OnElementSelected(item);
			}
		}
		InvalidateVisual();
	}

	private void SelectedElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			ICanvasElement[] array = _handlesMap.Keys.ToArray();
			foreach (ICanvasElement element in array)
			{
				OnElementDeselected(element);
			}
			return;
		}
		if (e.OldItems != null)
		{
			foreach (ICanvasElement oldItem in e.OldItems)
			{
				OnElementDeselected(oldItem);
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (ICanvasElement newItem in e.NewItems)
		{
			OnElementSelected(newItem);
		}
	}

	private void OnElementSelected(ICanvasElement element)
	{
		AddBorder(element);
		AddAllHandles(element);
		AddPopovers(element);
		element.PropertyChanged += Element_PropertyChanged;
		NotifyCollectionChangedEventHandler value = delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			Element_CustomHandlesChanged(e, element);
		};
		_elementCollectionHandlerMap[element] = value;
		if (element.CustomHandles != null)
		{
			element.CustomHandles.CollectionChanged += value;
		}
		ElementUpdated(element);
	}

	private void AddBorder(ICanvasElement element)
	{
		SelectionBorder selectionBorder = new SelectionBorder(element);
		_borderMap[element] = selectionBorder;
		base.Children.Add(selectionBorder);
	}

	private void AddPopovers(ICanvasElement element)
	{
		ImmutableObservableCollection<IPopover>? popovers = element.Popovers;
		if (popovers != null && popovers.Any())
		{
			PopoverControl popoverControl = RootControl?.GeneratePopoverControlFromIPopover(element.Popovers);
			if (popoverControl != null)
			{
				popoverControl.SetBinding(PopoverControl.PopoverForegroundProperty, new Binding("PopoverForeground")
				{
					Source = this
				});
				popoverControl.SetBinding(Panel.BackgroundProperty, new Binding("PopoverBackground")
				{
					Source = this
				});
				_popoverMap[element] = popoverControl;
				base.Children.Add(popoverControl);
			}
		}
	}

	private void AddAllHandles(ICanvasElement? element)
	{
		if (element == null)
		{
			return;
		}
		_handlesMap[element] = new List<HandleBase>();
		if (element.CustomHandles != null)
		{
			_customHandles[element] = new Dictionary<IHandleData, HandleBase[]>();
			foreach (IHandleData customHandle in element.CustomHandles)
			{
				AddCustomHandle(element, customHandle);
			}
		}
		foreach (HandleLocation item in from location in Enum.GetValues<HandleLocation>()
			where location != HandleLocation.All && location != 0 && element.SupportedCanvasHandles.HasFlag(location)
			select location)
		{
			AddHandle(element, new StandardHandle(item, element, SnapController));
		}
	}

	private void RemoveAllHandles(ICanvasElement element)
	{
		HandleBase[] array = _handlesMap[element].ToArray();
		foreach (HandleBase handle in array)
		{
			RemoveHandle(element, handle);
		}
		if (_customHandles.TryGetValue(element, out Dictionary<IHandleData, HandleBase[]> value))
		{
			value.ForEach(delegate(KeyValuePair<IHandleData, HandleBase[]> h)
			{
				RootControl?.OnCleanupHandleControls(h.Key, h.Value);
			});
			value.Clear();
		}
	}

	private void AddHandle(ICanvasElement element, HandleBase handle)
	{
		if (!base.Children.Contains(handle))
		{
			handle.TransformStateChanged += OnTransformStateChanged;
			handle.OnClick += OnHandleClicked;
			if (handle.CanSelect)
			{
				handle.SelectedHandles = _selectedHandles;
			}
			handle.IsSelected = false;
			base.Children.Add(handle);
			_handlesMap[element].Add(handle);
		}
	}

	private void RemoveHandle(ICanvasElement element, HandleBase handle)
	{
		handle.TransformStateChanged -= OnTransformStateChanged;
		handle.OnClick -= OnHandleClicked;
		handle.SelectedHandles = null;
		handle.IsSelected = false;
		base.Children.Remove(handle);
		_selectedHandles.Remove(handle);
		_handlesMap[element].Remove(handle);
	}

	private void Element_CustomHandlesChanged(NotifyCollectionChangedEventArgs e, ICanvasElement? element)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			if (element != null)
			{
				foreach (KeyValuePair<IHandleData, HandleBase[]> item in _customHandles[element])
				{
					RemoveCustomHandle(element, item.Key);
				}
			}
		}
		else
		{
			if (e.OldItems != null)
			{
				foreach (IHandleData item2 in e.OldItems.OfType<IHandleData>())
				{
					RemoveCustomHandle(element, item2);
				}
			}
			if (e.NewItems != null)
			{
				foreach (IHandleData item3 in e.NewItems.OfType<IHandleData>())
				{
					AddCustomHandle(element, item3);
				}
			}
		}
		ElementUpdated(element);
	}

	private void AddCustomHandle(ICanvasElement? element, IHandleData? handle)
	{
		if (element != null && handle != null)
		{
			if (handle is ControlHandleData controlHandleData)
			{
				HandleBase[] handleControls = new ControlHandle[1]
				{
					new ControlHandle(element, controlHandleData.GetLocation, controlHandleData.HandleDragged, controlHandleData.DidCornerRadiusHandleMove, controlHandleData.ToolTip)
				};
				OnAddCustomHandleControls(element, handle, handleControls);
			}
			else
			{
				OnAddCustomHandleControls(element, handle, RootControl?.OnGetHandleControls(handle));
			}
		}
	}

	private void OnAddCustomHandleControls(ICanvasElement element, IHandleData handle, HandleBase[]? handleControls)
	{
		if (handleControls != null)
		{
			_customHandles[element].Add(handle, handleControls);
			handleControls.ForEach(delegate(HandleBase h)
			{
				AddHandle(element, h);
			});
		}
	}

	private void RemoveCustomHandle(ICanvasElement? element, IHandleData? handle)
	{
		if (element != null && handle != null && _customHandles.TryGetValue(element, out Dictionary<IHandleData, HandleBase[]> value) && value.TryGetValue(handle, out var value2))
		{
			RootControl?.OnCleanupHandleControls(handle, value2);
			value2.ForEach(delegate(HandleBase h)
			{
				RemoveHandle(element, h);
			});
			value.Remove(handle);
		}
	}

	private void OnElementDeselected(ICanvasElement element)
	{
		if (element != null)
		{
			RemoveAllHandles(element);
			if (_popoverMap.TryGetValue(element, out PopoverControl value))
			{
				value.CleanupPopovers();
				base.Children.Remove(value);
			}
			if (_borderMap.TryGetValue(element, out SelectionBorder value2))
			{
				base.Children.Remove(value2);
			}
			element.PropertyChanged -= Element_PropertyChanged;
			if (element.CustomHandles != null)
			{
				element.CustomHandles.CollectionChanged -= _elementCollectionHandlerMap[element];
			}
			_updatedElements.Remove(element);
			_customHandles.Remove(element);
			_handlesMap.Remove(element);
			_popoverMap.Remove(element);
			_borderMap.Remove(element);
			_elementCollectionHandlerMap.Remove(element);
			InvalidateVisual();
		}
	}

	public void OnTransformStateChanged(bool isTransformActive, ITransform? activeTransform, ITooltipDataSource? tooltipSource = null)
	{
		IsTransformActive = isTransformActive;
		TooltipSource = tooltipSource ?? activeTransform;
		InvalidateVisual();
		this.TransformStateChanged?.Invoke(IsTransformActive, activeTransform);
	}

	private void OnHandleClicked(HandleBase handle)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (!handle.CanSelect)
		{
			return;
		}
		if (Keyboard.Modifiers.AnyFlags<ModifierKeys>((ModifierKeys)6))
		{
			if (!handle.IsSelected)
			{
				_selectedHandles.Add(handle);
			}
			else
			{
				_selectedHandles.Remove(handle);
			}
			handle.IsSelected = !handle.IsSelected;
		}
		else if (!handle.IsSelected)
		{
			_selectedHandles.ForEach(delegate(HandleBase h)
			{
				h.IsSelected = false;
			});
			_selectedHandles.Clear();
			handle.IsSelected = true;
			_selectedHandles.Add(handle);
		}
	}

	private void Element_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(sender is ICanvasElement canvasElement))
		{
			return;
		}
		if (e.PropertyName == "SupportedCanvasHandles")
		{
			RemoveAllHandles(canvasElement);
			AddAllHandles(canvasElement);
			ElementUpdated(canvasElement);
		}
		else
		{
			bool flag = false;
			if (_handlesMap.TryGetValue(canvasElement, out List<HandleBase> value))
			{
				foreach (HandleBase item in value)
				{
					item.InvalidateVisual();
					if (!flag && item.DidHandleMove(e))
					{
						ElementUpdated(canvasElement);
						flag = true;
					}
				}
			}
		}
		InvalidateVisual();
	}

	protected override void OnLocationScaleChanged(double scale)
	{
		foreach (ICanvasElement key in _handlesMap.Keys)
		{
			ElementUpdated(key);
		}
	}

	private void ElementUpdated(ICanvasElement? element)
	{
		if (element != null && !_updatedElements.Contains(element))
		{
			_updatedElements.Add(element);
			InvalidateVisual();
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		_handlesMap.Values.ForEach(delegate(List<HandleBase> hl)
		{
			hl.ForEach(delegate(HandleBase h)
			{
				h.LayoutScale = base.LocationScale;
			});
		});
		foreach (ICanvasElement updatedElement in _updatedElements)
		{
			Angle<double> globalRotation = updatedElement.GetGlobalRotation();
			Matrix<double> globalTransformMatrix = updatedElement.CanvasParent.GetGlobalTransformMatrix();
			Rect<double> rect = new Rect<double>(updatedElement.Position, updatedElement.Size).Rotate(updatedElement.Rotation.InvertedCartesianValue);
			foreach (HandleBase item in _handlesMap[updatedElement])
			{
				item.Rotation = globalRotation.InvertedCartesianValue;
				item.UpdateLocation(globalTransformMatrix);
			}
			if (_popoverMap.TryGetValue(updatedElement, out PopoverControl value))
			{
				value.Location = new Vector2<double>(rect.Center.X - value.ActualWidth / 2.0 / base.LocationScale, rect.Bottom + 10.0 / base.LocationScale);
			}
			if (_borderMap.TryGetValue(updatedElement, out SelectionBorder value2))
			{
				value2.Rotation = globalRotation.InvertedCartesianValue;
				value2.LocationScale = base.LocationScale;
				value2.UpdateLocation(globalTransformMatrix);
			}
		}
		_updatedElements.Clear();
		bool isTransformActive = IsTransformActive;
		foreach (KeyValuePair<ICanvasElement, List<HandleBase>> item2 in _handlesMap)
		{
			foreach (HandleBase item3 in item2.Value)
			{
				item3.Visibility = ((item2.Key.IsHidden || (item2.Key.IsLocked && !(item3 is StandardHandle))) ? Visibility.Hidden : Visibility.Visible);
			}
		}
		foreach (KeyValuePair<ICanvasElement, PopoverControl> item4 in _popoverMap)
		{
			item4.Value.Visibility = ((isTransformActive || item4.Key.IsLocked || SelectedElements.Count > 1) ? Visibility.Hidden : Visibility.Visible);
		}
	}

	public void UpdateHandles()
	{
		foreach (HandleBase item in _handlesMap.Values.SelectMany((List<HandleBase> h) => h))
		{
			item.UpdateState();
		}
	}
}
