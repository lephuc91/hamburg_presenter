using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Dispatcher;

namespace Pro.Common.Collections;

public class UpdatingFilteredObservableCollection<T> : FilteredObservableCollection<T> where T : INotifyPropertyChanged
{
	private sealed class Comparer : IEqualityComparer<T>
	{
		public bool Equals(T? x, T? y)
		{
			return ReferenceEqualityComparer.Instance.Equals(x, y);
		}

		public int GetHashCode(T obj)
		{
			return ReferenceEqualityComparer.Instance.GetHashCode(obj);
		}
	}

	private readonly IUiDispatcher _dispatcher;

	private readonly IReadOnlyCollection<string> _observedProperties;

	private readonly HashSet<T> _subscribedItems = new HashSet<T>(new Comparer());

	public UpdatingFilteredObservableCollection(INotifyEnumerableChanged<T>? collection, Predicate<T> filterPredicate, IUiDispatcher dispatcher, [ParamCollection] IReadOnlyCollection<string> observedProperties)
		: base(collection, filterPredicate)
	{
		_dispatcher = dispatcher;
		_observedProperties = observedProperties;
		if (collection == null)
		{
			return;
		}
		foreach (T item in collection)
		{
			T current = item;
			ref T reference = ref current;
			T val = default(T);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			reference.PropertyChanged += OnItemPropertyChanged;
			_subscribedItems.Add(current);
		}
	}

	protected override void OnSourceCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		T val;
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			foreach (T subscribedItem in _subscribedItems)
			{
				T current = subscribedItem;
				ref T reference = ref current;
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				reference.PropertyChanged -= OnItemPropertyChanged;
			}
			_subscribedItems.Clear();
			if (base.Collection != null)
			{
				foreach (T item3 in base.Collection)
				{
					T current2 = item3;
					ref T reference2 = ref current2;
					val = default(T);
					if (val == null)
					{
						val = reference2;
						reference2 = ref val;
					}
					reference2.PropertyChanged += OnItemPropertyChanged;
					_subscribedItems.Add(current2);
				}
			}
		}
		else
		{
			if (e.OldItems != null)
			{
				foreach (T oldItem in e.OldItems)
				{
					T item = oldItem;
					ref T reference3 = ref item;
					val = default(T);
					if (val == null)
					{
						val = reference3;
						reference3 = ref val;
					}
					reference3.PropertyChanged -= OnItemPropertyChanged;
					_subscribedItems.Remove(item);
				}
			}
			if (e.NewItems != null)
			{
				foreach (T newItem in e.NewItems)
				{
					T item2 = newItem;
					ref T reference4 = ref item2;
					val = default(T);
					if (val == null)
					{
						val = reference4;
						reference4 = ref val;
					}
					reference4.PropertyChanged += OnItemPropertyChanged;
					_subscribedItems.Add(item2);
				}
			}
		}
		base.OnSourceCollectionChanged(e);
	}

	private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(e.PropertyName) || _observedProperties.Contains<string>(e.PropertyName))
		{
			_dispatcher.Invoke(base.Refresh);
		}
	}
}
