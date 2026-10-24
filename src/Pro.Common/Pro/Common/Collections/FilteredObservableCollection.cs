using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public class FilteredObservableCollection<C, T> : NotifyPropertyChangedBase, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>, INotifyEnumerableChanged<T>, INotifyCollectionChanged where C : INotifyEnumerableChanged<T>
{
	private C? _collection;

	private Predicate<T>? _filterPredicate;

	private int _filteredCount;

	private readonly Dictionary<int, int> _filteredIndexMap = new Dictionary<int, int>();

	protected C? Collection
	{
		get
		{
			return _collection;
		}
		set
		{
			SetValue<C>("Collection", ref _collection, value, delegate(C o, C n)
			{
				C val;
				if (o != null)
				{
					ref C reference = ref o;
					val = default(C);
					if (val == null)
					{
						val = reference;
						reference = ref val;
					}
					reference.CollectionChanged -= InternalCollectionChanged;
				}
				if (n != null)
				{
					ref C reference2 = ref n;
					val = default(C);
					if (val == null)
					{
						val = reference2;
						reference2 = ref val;
					}
					reference2.CollectionChanged += InternalCollectionChanged;
				}
				OnSourceCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
				ApplyFilter();
			});
		}
	}

	protected Predicate<T>? FilterPredicate
	{
		get
		{
			return _filterPredicate;
		}
		set
		{
			_filterPredicate = value;
			ApplyFilter();
		}
	}

	protected IEnumerable<T> FilteredItems
	{
		get
		{
			C collection = Collection;
			return ((collection != null) ? collection.Where(ExecuteFilterPredicate) : null) ?? Array.Empty<T>();
		}
	}

	public T this[int index]
	{
		get
		{
			return FilteredItems.ElementAt(index);
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	object? IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public int Count => _filteredCount;

	public bool IsReadOnly => true;

	public bool IsFixedSize => false;

	object ICollection.SyncRoot
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public bool IsSynchronized => false;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public FilteredObservableCollection(C? collection, Predicate<T> filterPredicate)
	{
		_collection = collection;
		FilterPredicate = filterPredicate;
		if (collection != null)
		{
			ref C reference = ref collection;
			C val = default(C);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			reference.CollectionChanged += InternalCollectionChanged;
		}
	}

	public void UpdateSourceCollection(C? collection)
	{
		Collection = collection;
	}

	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
	}

	protected virtual void OnSourceCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
	}

	public void Refresh()
	{
		ApplyFilter();
	}

	private bool ExecuteFilterPredicate(T item)
	{
		return FilterPredicate?.Invoke(item) ?? true;
	}

	private void ApplyFilter()
	{
		_filteredCount = FilteredItems.Count();
		UpdateFilteredIndexMap();
		NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	private void UpdateFilteredIndexMap()
	{
		_filteredIndexMap.Clear();
		C collection = Collection;
		int num = ((collection != null) ? collection.Count() : 0);
		int num2 = 0;
		for (int i = 0; i <= num; i++)
		{
			if (i == num || ExecuteFilterPredicate(Collection.ElementAt(i)))
			{
				_filteredIndexMap[i] = num2++;
			}
		}
	}

	private int CalculateFilteredIndex(int unfilteredIndex)
	{
		foreach (KeyValuePair<int, int> item in _filteredIndexMap)
		{
			if (item.Key >= unfilteredIndex)
			{
				return item.Value;
			}
		}
		return -1;
	}

	private void InternalCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnSourceCollectionChanged(e);
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			UpdateFilteredIndexMap();
			int num3 = CalculateFilteredIndex(e.NewStartingIndex);
			int num4 = CalculateFilteredIndex(e.NewStartingIndex + (e.NewItems?.Count ?? 0));
			if (num3 < num4)
			{
				T[] array = e.NewItems.Cast<T>().Where(ExecuteFilterPredicate).ToArray();
				_filteredCount += array.Length;
				NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, array, num3));
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			int num5 = CalculateFilteredIndex(e.OldStartingIndex);
			int num6 = CalculateFilteredIndex(e.OldStartingIndex + (e.OldItems?.Count ?? 0));
			if (num5 < num6)
			{
				T[] array2 = e.OldItems.Cast<T>().Where(ExecuteFilterPredicate).ToArray();
				UpdateFilteredIndexMap();
				_filteredCount -= array2.Length;
				NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, array2, num5));
			}
			else
			{
				UpdateFilteredIndexMap();
			}
			break;
		}
		case NotifyCollectionChangedAction.Move:
		{
			int num = CalculateFilteredIndex(e.OldStartingIndex);
			int num2 = CalculateFilteredIndex(e.OldStartingIndex + (e.OldItems?.Count ?? 0));
			if (num < num2)
			{
				T[] changedItems = e.OldItems?.Cast<T>().Where(ExecuteFilterPredicate).ToArray();
				UpdateFilteredIndexMap();
				int index = CalculateFilteredIndex(e.NewStartingIndex);
				NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, changedItems, index, num));
			}
			else
			{
				UpdateFilteredIndexMap();
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Reset:
			_filteredCount = FilteredItems.Count();
			UpdateFilteredIndexMap();
			NotifyCollectionChanged(e);
			break;
		default:
			throw new NotSupportedException();
		}
	}

	private void NotifyCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnCollectionChanged(e);
		this.CollectionChanged?.Invoke(this, e);
		OnPropertyChanged("Count");
	}

	public bool Contains(T item)
	{
		return FilteredItems.Contains(item);
	}

	bool IList.Contains(object? value)
	{
		if (value is T item)
		{
			return Contains(item);
		}
		return false;
	}

	public int IndexOf(T item)
	{
		return FilteredItems.IndexOf(item);
	}

	int IList.IndexOf(object? value)
	{
		if (!(value is T item))
		{
			return -1;
		}
		return IndexOf(item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return FilteredItems.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		FilteredItems.ForEach(delegate(T i)
		{
			array[arrayIndex++] = i;
		});
	}

	void ICollection.CopyTo(Array array, int index)
	{
		CopyTo((T[])array, index);
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	int IList.Add(object? value)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList.Insert(int index, object? value)
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object? value)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}
}
public class FilteredObservableCollection<T> : FilteredObservableCollection<INotifyEnumerableChanged<T>, T>
{
	public FilteredObservableCollection(INotifyEnumerableChanged<T>? collection, Predicate<T> filterPredicate)
		: base(collection, filterPredicate)
	{
	}
}
