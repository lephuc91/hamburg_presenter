using System;
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
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

internal class CanvasElement : FixedControl
{
	private readonly DrawingVisual _drawingTarget = new DrawingVisual();

	private static readonly BitmapCache _lowScaleBitmapCache = new BitmapCache(0.75);

	private static readonly BitmapCache _mediumScaleBitmapCache = new BitmapCache(1.0);

	private static readonly BitmapCache _highScaleBitmapCache = new BitmapCache(1.25);

	public static readonly DependencyProperty SourceElementProperty = DependencyProperty.Register("SourceElement", typeof(ICanvasElement), typeof(CanvasElement), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(SourceElementPropertyChanged)));

	public static readonly DependencyProperty RootControlProperty = DependencyProperty.Register("RootControl", typeof(CanvasControl), typeof(CanvasElement), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RootControlPropertyChanged)));

	public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(CanvasElement), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ZoomFactorPropertyChanged)));

	public SSLayer? SSLayer { get; private set; }

	public ICanvasElement? SourceElement
	{
		get
		{
			return (ICanvasElement)((DependencyObject)this).GetValue(SourceElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceElementProperty, (object)value);
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

	protected override int VisualChildrenCount => base.VisualChildrenCount + 1;

	public event Action<ICanvasElement?>? ElementSelected;

	public event Action<Vector2<double>, ICanvasElement?>? ElementEdited;

	public event Action<ICanvasElement?>? ChildElementSelected;

	public event Action<ICanvasElement?>? ChildElementDeselected;

	private static void SourceElementPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasElement)?.ReloadElementChildren(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ICanvasElement, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICanvasElement);
	}

	private static void RootControlPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasElement)?.UpdateChildrenRootControl(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as CanvasControl);
	}

	private static void ZoomFactorPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as CanvasElement)?.OnZoomFactorChanged();
	}

	public CanvasElement()
	{
		AddVisualChild(_drawingTarget);
		base.ClickOnRightMouseDown = true;
	}

	private void ReloadElementChildren(ICanvasElement? oldElement, ICanvasElement? newElement)
	{
		foreach (CanvasElement item in base.Children.OfType<CanvasElement>())
		{
			item.SourceElement = null;
			item.ElementSelected -= OnElementSelected;
			item.ChildElementSelected -= OnChildElementSelected;
		}
		base.Children.Clear();
		SSLayer?.DetachFromSource();
		SSLayer = null;
		if (oldElement != null)
		{
			oldElement.PropertyChanged -= ElementPropertyChanged;
			oldElement.VisualInvalidated -= ElementVisualInvalidated;
			if (oldElement.CanvasChildren != null)
			{
				oldElement.CanvasChildren.CollectionChanged -= ElementCanvasChildrenChanged;
			}
			if (oldElement.CustomChildren != null)
			{
				oldElement.CustomChildren.CollectionChanged -= ElementCustomChildrenChanged;
			}
		}
		if (newElement != null)
		{
			newElement.PropertyChanged += ElementPropertyChanged;
			newElement.VisualInvalidated += ElementVisualInvalidated;
			if (newElement.CanvasChildren != null)
			{
				newElement.CanvasChildren.CollectionChanged += ElementCanvasChildrenChanged;
				if (SourceElement == null)
				{
					throw new MemberAccessException("SourceElement");
				}
				SSLayer = new SSLayer(SourceElement);
				foreach (ICanvasElement canvasChild in newElement.CanvasChildren)
				{
					AddCanvasChild(new CanvasElement
					{
						SourceElement = canvasChild,
						RootControl = RootControl
					});
				}
			}
			if (newElement.CustomChildren != null)
			{
				newElement.CustomChildren.CollectionChanged += ElementCustomChildrenChanged;
				newElement.CustomChildren.ForEach(delegate(UIElement c)
				{
					base.Children.Add(c);
				});
			}
		}
		UpdateLocation(newElement);
		UpdateZIndex(newElement);
		UpdateVisibility(newElement);
		UpdateCacheMode(newElement);
	}

	private void UpdateChildrenRootControl(CanvasControl? newRoot)
	{
		SetBinding(ZoomFactorProperty, new Binding("ZoomFactor")
		{
			Source = newRoot
		});
		foreach (CanvasElement item in base.Children.OfType<CanvasElement>())
		{
			item.RootControl = newRoot;
		}
	}

	private void ElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Position":
		case "Size":
		case "Rotation":
			UpdateLocation(SourceElement);
			break;
		case "ZOrder":
			UpdateZIndex(SourceElement);
			break;
		case "IsHidden":
			UpdateVisibility(SourceElement);
			break;
		case "UseBitmapCache":
			UpdateCacheMode(SourceElement);
			break;
		}
	}

	private void ElementVisualInvalidated()
	{
		UpdateCacheMode(SourceElement);
		InvalidateVisual();
	}

	private void ElementCanvasChildrenChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			base.Children.OfType<CanvasElement>().ToArray().ForEach(RemoveCanvasChild);
			return;
		}
		if (e.OldItems != null)
		{
			foreach (ICanvasElement element in e.OldItems)
			{
				RemoveCanvasChild(base.Children.OfType<CanvasElement>().FirstOrDefault((CanvasElement c) => c.SourceElement == element));
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (ICanvasElement newItem in e.NewItems)
		{
			AddCanvasChild(new CanvasElement
			{
				SourceElement = newItem,
				RootControl = RootControl
			});
		}
	}

	private void ElementCustomChildrenChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			base.Children.RemoveIf((object? c) => !(c is CanvasElement));
			return;
		}
		e.OldItems?.OfType<UIElement>().ForEach(delegate(UIElement c)
		{
			base.Children.Remove(c);
		});
		e.NewItems?.OfType<UIElement>().ForEach(delegate(UIElement c)
		{
			base.Children.Add(c);
			c.Focus();
		});
	}

	private void AddCanvasChild(CanvasElement child)
	{
		if (SourceElement != null)
		{
			if (SourceElement.ChildVisibilityMode == ChildVisibilityMode.HiddenUntilActivated)
			{
				child.Visibility = Visibility.Hidden;
			}
			base.Children.Add(child);
			child.ElementSelected += OnElementSelected;
			child.ElementEdited += OnElementEdited;
			child.ChildElementSelected += OnChildElementSelected;
			child.ChildElementDeselected += OnChildElementDeselected;
		}
	}

	private void RemoveCanvasChild(CanvasElement? child)
	{
		if (child != null)
		{
			base.Children.Remove(child);
			child.ElementSelected -= OnElementSelected;
			child.ElementEdited -= OnElementEdited;
			child.ChildElementSelected -= OnChildElementSelected;
			child.ChildElementDeselected -= OnChildElementDeselected;
			this.ChildElementDeselected?.Invoke(child.SourceElement);
			child.SourceElement = null;
		}
	}

	private void OnElementSelected(ICanvasElement? element)
	{
		this.ElementSelected?.Invoke(element);
	}

	private void OnElementEdited(Vector2<double> point, ICanvasElement? element)
	{
		this.ElementEdited?.Invoke(point, element);
	}

	private void OnChildElementSelected(ICanvasElement? element)
	{
		this.ChildElementSelected?.Invoke(element);
	}

	private void OnChildElementDeselected(ICanvasElement? element)
	{
		this.ChildElementDeselected?.Invoke(element);
	}

	protected override Visual? GetVisualChild(int index)
	{
		if (index != 0)
		{
			return base.GetVisualChild(index - 1);
		}
		return _drawingTarget;
	}

	protected override Vector2<double> OnMeasure(Size availableSize)
	{
		return SourceElement?.Size.Abs() ?? Vector2<double>.Zero;
	}

	private void OnZoomFactorChanged()
	{
		UpdateCacheMode(SourceElement);
	}

	private void UpdateLocation(ICanvasElement? sourceElement)
	{
		Vector2<double> vector = (sourceElement?.Size ?? Vector2<double>.Zero) / 2.0;
		base.Location = sourceElement?.Position ?? Vector2<double>.Zero;
		base.RenderTransform = new RotateTransform(sourceElement?.Rotation.InvertedCartesianValue ?? 0.0, vector.X, vector.Y);
	}

	private void UpdateZIndex(ICanvasElement? sourceElement)
	{
		((DependencyObject)this).SetValue(Panel.ZIndexProperty, (object)(sourceElement?.ZOrder ?? 0));
	}

	private void UpdateVisibility(ICanvasElement? sourceElement)
	{
		if (sourceElement == null || sourceElement.IsHidden)
		{
			base.Visibility = Visibility.Hidden;
		}
		else
		{
			base.Visibility = Visibility.Visible;
		}
		InvalidateVisual();
	}

	private void UpdateCacheMode(ICanvasElement? sourceElement)
	{
		double num = Math.Round(ZoomFactor);
		BitmapCache bitmapCache = ((num < 1.0) ? _lowScaleBitmapCache : ((num == 1.0) ? _mediumScaleBitmapCache : _highScaleBitmapCache));
		if (base.CacheMode != bitmapCache)
		{
			base.CacheMode = ((sourceElement != null && sourceElement.UseBitmapCache) ? bitmapCache : null);
			InvalidateVisual();
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		RootControl?.OnRenderElement(SourceElement, _drawingTarget);
	}

	protected override void OnMouseClick(MouseButtonEventArgs e)
	{
		this.ElementSelected?.Invoke(SourceElement);
	}

	protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (SourceElement == null)
		{
			return;
		}
		if (SourceElement.SupportsEditMode)
		{
			this.ElementEdited?.Invoke((Vector2<double>)e.GetPosition(this), SourceElement);
		}
		ImmutableObservableCollection<ICanvasElement>? canvasChildren = SourceElement.CanvasChildren;
		if (canvasChildren == null || !canvasChildren.Any())
		{
			return;
		}
		if (SourceElement.ChildVisibilityMode == ChildVisibilityMode.HiddenUntilActivated)
		{
			base.Children.OfType<CanvasElement>().ForEach(delegate(CanvasElement c)
			{
				c.Visibility = Visibility.Visible;
			});
			this.ChildElementSelected?.Invoke(SourceElement.CanvasChildren?.FirstOrDefault() ?? SourceElement);
		}
		else
		{
			this.ChildElementSelected?.Invoke(SourceElement);
		}
	}
}
