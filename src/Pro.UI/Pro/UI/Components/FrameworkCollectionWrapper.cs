using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using Pro.Common.Collections;

namespace Pro.UI.Components;

public class FrameworkCollectionWrapper : FrameworkCollection
{
	public static readonly DependencyProperty BoundDataTemplateProperty = DependencyProperty.Register("BoundDataTemplate", typeof(DataTemplate), typeof(FrameworkCollectionWrapper));

	public static readonly DependencyProperty BoundCollectionProperty = DependencyProperty.Register("BoundCollection", typeof(IEnumerable), typeof(FrameworkCollectionWrapper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCollectionPropertyChanged)));

	public DataTemplate BoundDataTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(BoundDataTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BoundDataTemplateProperty, (object)value);
		}
	}

	public IEnumerable? BoundCollection
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(BoundCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BoundCollectionProperty, (object)value);
		}
	}

	private static void OnCollectionPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as FrameworkCollectionWrapper)?.OnCollectionChanged((IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void OnCollectionChanged(IEnumerable? oldCollection, IEnumerable? newCollection)
	{
		if (oldCollection is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged -= OnNotifyCollectionChanged;
		}
		if (newCollection != null)
		{
			if (newCollection is INotifyCollectionChanged notifyCollectionChanged2)
			{
				notifyCollectionChanged2.CollectionChanged += OnNotifyCollectionChanged;
			}
			base.Collection?.Clear();
			AddTemplatedItems(newCollection);
		}
	}

	private void SubitemCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyCollectionChanged();
	}

	private void OnNotifyCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			base.Collection?.Clear();
			AddTemplatedItems(BoundCollection);
			return;
		}
		if (e.OldItems != null)
		{
			foreach (object oldItem in e.OldItems)
			{
				if (oldItem is FrameworkCollection frameworkCollection)
				{
					frameworkCollection.CollectionChanged -= SubitemCollectionChanged;
				}
				RemoveTemplatedItem(oldItem);
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		int newStartingIndex = e.NewStartingIndex;
		foreach (object newItem in e.NewItems)
		{
			InsertTemplatedItem(newStartingIndex++, newItem);
			if (newItem is FrameworkCollection frameworkCollection2)
			{
				frameworkCollection2.CollectionChanged += SubitemCollectionChanged;
			}
		}
	}

	private void AddTemplatedItem(object item)
	{
		InsertTemplatedItem(base.Collection?.Count ?? (-1), item);
	}

	private void AddTemplatedItems(IEnumerable? collection)
	{
		if (collection == null)
		{
			return;
		}
		foreach (object item in collection)
		{
			AddTemplatedItem(item);
		}
	}

	private void InsertTemplatedItem(int index, object item)
	{
		object obj = (BoundDataTemplate?.LoadContent() as FrameworkElement) ?? item;
		if (obj is FrameworkElement frameworkElement && BoundDataTemplate != null)
		{
			frameworkElement.DataContext = item;
		}
		base.Collection?.Insert(index, obj);
	}

	private void RemoveTemplatedItem(object item)
	{
		base.Collection?.Remove(base.Collection.FirstOrDefaultOf((FrameworkElement v) => v.DataContext.Equals(item)) ?? item);
	}
}
