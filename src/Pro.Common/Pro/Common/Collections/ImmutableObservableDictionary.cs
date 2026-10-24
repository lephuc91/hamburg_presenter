using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Pro.Common.Collections;

public class ImmutableObservableDictionary<K, V> : ReadOnlyDictionary<K, V>, INotifyEnumerableChanged<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged where K : notnull
{
	private readonly ObservableDictionary<K, V> _dictionary;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public event PropertyChangedEventHandler? PropertyChanged;

	public ImmutableObservableDictionary()
		: this(new ObservableDictionary<K, V>())
	{
	}

	public ImmutableObservableDictionary(ObservableDictionary<K, V> dictionary)
		: base((IDictionary<K, V>)dictionary)
	{
		_dictionary = dictionary;
		_dictionary.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			this.PropertyChanged?.Invoke(this, e);
		};
		_dictionary.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			this.CollectionChanged?.Invoke(this, e);
		};
	}
}
