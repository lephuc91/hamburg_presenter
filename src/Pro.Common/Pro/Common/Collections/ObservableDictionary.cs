using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public class ObservableDictionary<K, V> : NotifyPropertyChangedBase, IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IReadOnlyDictionary<K, V>, IReadOnlyCollection<KeyValuePair<K, V>>, INotifyEnumerableChanged<KeyValuePair<K, V>>, INotifyCollectionChanged, ICloneable<ObservableDictionary<K, V>> where K : notnull
{
	private readonly Dictionary<K, V> _dictionary;

	public V this[K key]
	{
		get
		{
			return _dictionary[key];
		}
		set
		{
			if (!UpdateWithNotification(key, value))
			{
				AddWithNotification(key, value);
			}
		}
	}

	public IEqualityComparer<K> Comparer => _dictionary.Comparer;

	public int Count => _dictionary.Count;

	public Dictionary<K, V>.KeyCollection Keys => _dictionary.Keys;

	public Dictionary<K, V>.ValueCollection Values => _dictionary.Values;

	ICollection<K> IDictionary<K, V>.Keys => _dictionary.Keys;

	ICollection<V> IDictionary<K, V>.Values => _dictionary.Values;

	IEnumerable<K> IReadOnlyDictionary<K, V>.Keys => _dictionary.Keys;

	IEnumerable<V> IReadOnlyDictionary<K, V>.Values => _dictionary.Values;

	public bool IsReadOnly => ((ICollection<KeyValuePair<K, V>>)_dictionary).IsReadOnly;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public ObservableDictionary()
	{
		_dictionary = new Dictionary<K, V>();
	}

	public ObservableDictionary(int capacity)
	{
		_dictionary = new Dictionary<K, V>(capacity);
	}

	public ObservableDictionary(IEqualityComparer<K> comparer)
	{
		_dictionary = new Dictionary<K, V>(comparer);
	}

	public ObservableDictionary(IDictionary<K, V> dictionary)
	{
		_dictionary = new Dictionary<K, V>(dictionary);
	}

	public ObservableDictionary(int capacity, IEqualityComparer<K> comparer)
	{
		_dictionary = new Dictionary<K, V>(capacity, comparer);
	}

	public ObservableDictionary(IDictionary<K, V> dictionary, IEqualityComparer<K> comparer)
	{
		_dictionary = new Dictionary<K, V>(dictionary, comparer);
	}

	public void Add(K key, V value)
	{
		AddWithNotification(key, value);
	}

	public void Clear()
	{
		_dictionary.Clear();
		RaisePropertyChanges();
		this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	public bool ContainsKey(K key)
	{
		return _dictionary.ContainsKey(key);
	}

	public bool ContainsValue(V value)
	{
		return _dictionary.ContainsValue(value);
	}

	public bool Remove(K key)
	{
		return RemoveWithNotification(key);
	}

	public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
	{
		return _dictionary.TryGetValue(key, out value);
	}

	void ICollection<KeyValuePair<K, V>>.Add(KeyValuePair<K, V> item)
	{
		AddWithNotification(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<K, V> item)
	{
		return ((ICollection<KeyValuePair<K, V>>)_dictionary).Contains(item);
	}

	public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
	{
		((ICollection<KeyValuePair<K, V>>)_dictionary).CopyTo(array, arrayIndex);
	}

	bool ICollection<KeyValuePair<K, V>>.Remove(KeyValuePair<K, V> item)
	{
		return RemoveWithNotification(item.Key);
	}

	public Dictionary<K, V>.Enumerator GetEnumerator()
	{
		return _dictionary.GetEnumerator();
	}

	IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
	{
		return _dictionary.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _dictionary.GetEnumerator();
	}

	public ObservableDictionary<K, V> Clone()
	{
		return new ObservableDictionary<K, V>(this);
	}

	private void AddWithNotification(K key, V value)
	{
		_dictionary.Add(key, value);
		RaisePropertyChanges();
		this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<K, V>(key, value)));
	}

	private bool UpdateWithNotification(K key, V value)
	{
		if (_dictionary.TryGetValue(key, out var value2))
		{
			_dictionary[key] = value;
			OnPropertyChanged("Values");
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<K, V>(key, value), new KeyValuePair<K, V>(key, value2)));
			return true;
		}
		return false;
	}

	private bool RemoveWithNotification(K key)
	{
		if (_dictionary.TryGetValue(key, out var value) && _dictionary.Remove(key))
		{
			RaisePropertyChanges();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<K, V>(key, value)));
			return true;
		}
		return false;
	}

	private void RaisePropertyChanges()
	{
		OnPropertyChanged("Count");
		OnPropertyChanged("Keys");
		OnPropertyChanged("Values");
	}
}
