using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

public class CanvasElementViewer<T> : DragDropListBox<T> where T : class, ICanvasElement
{
	public static readonly DependencyProperty ElementsProperty = DependencyProperty.Register("Elements", typeof(IDragDropEnumerableCollection<T>), typeof(CanvasElementViewer<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ElementsChanged)));

	public IDragDropEnumerableCollection<T>? Elements
	{
		get
		{
			return (IDragDropEnumerableCollection<T>)((DependencyObject)this).GetValue(ElementsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ElementsProperty, (object)value);
		}
	}

	protected override IDragDropCollection<T>? SourceCollection => Elements;

	private static void ElementsChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((CanvasElementViewer<T>)(object)callerObject).OnElementsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IDragDropEnumerableCollection<T>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IDragDropEnumerableCollection<T>);
	}

	public CanvasElementViewer()
	{
		AddDropType(null, null, null, (DraggedItems<T> _, DragEventArgs _) => true);
	}

	private void OnElementsChanged(IDragDropEnumerableCollection<T>? oldElements, IDragDropEnumerableCollection<T>? newElements)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		if (oldElements is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged -= Elements_CollectionChanged;
		}
		if (newElements is INotifyCollectionChanged notifyCollectionChanged2)
		{
			notifyCollectionChanged2.CollectionChanged += Elements_CollectionChanged;
		}
		oldElements?.ForEach(delegate(T i)
		{
			i.PropertyChanged -= RefreshItems;
		});
		newElements?.ForEach(delegate(T i)
		{
			i.PropertyChanged += RefreshItems;
		});
		ICollectionView defaultView = CollectionViewSource.GetDefaultView(newElements);
		if (defaultView != null)
		{
			((Collection<SortDescription>)(object)defaultView.SortDescriptions).Add(new SortDescription("ZOrder", base.CollectionDirection));
		}
		((DependencyObject)this).SetValue(ItemsControl.ItemsSourceProperty, (object)defaultView);
	}

	private void Elements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<T>().ForEach(delegate(T i)
		{
			i.PropertyChanged -= RefreshItems;
		});
		e.NewItems?.Cast<T>().ForEach(delegate(T i)
		{
			i.PropertyChanged += RefreshItems;
		});
	}

	private void RefreshItems(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ZOrder")
		{
			ICollectionView defaultView = CollectionViewSource.GetDefaultView(Elements);
			if (defaultView != null)
			{
				defaultView.Refresh();
			}
		}
	}
}
