using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Logging;
using Pro.Common.Operations;

namespace Pro.Common.Collections;

public class ImmutableObservableCollection<T> : ReadOnlyCollection<T>, IImmutableObservableCollection<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, INotifyEnumerableChanged<T>, INotifyCollectionChanged, INotifyPropertyChanged
{
	private readonly ObservableCollection<T> _collection;

	private int _dispatchDepth;

	protected ObservableCollection<T> Collection => _collection;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public event PropertyChangedEventHandler? PropertyChanged;

	public ImmutableObservableCollection()
		: this(new ObservableCollection<T>())
	{
	}

	public ImmutableObservableCollection(IEnumerable<T> items)
		: this(new ObservableCollection<T>(items))
	{
	}

	public ImmutableObservableCollection(ObservableCollection<T> collection)
		: base((IList<T>)collection)
	{
		_collection = collection;
		_collection.CollectionChanged += InternalCollectionChanged;
	}

	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
	}

	protected void OnPropertyChanged(string name)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	protected void SetValue<V>(string propertyName, ref V storageVariable, V value, Action changedCallback)
	{
		SetValue(propertyName, ref storageVariable, value, (Action<V, V>?)delegate
		{
			changedCallback?.Invoke();
		});
	}

	protected void SetValue<V>(string propertyName, ref V storageVariable, V value, Action<V, V>? changedCallback = null)
	{
		if (!storageVariable.Equal(value))
		{
			V arg = storageVariable;
			storageVariable = value;
			OnPropertyChanged(propertyName);
			changedCallback?.Invoke(arg, value);
		}
	}

	private void InternalCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (_dispatchDepth > 0)
		{
			Log.Error("ImmutableObservableCollection<{0}> was modified ({1}) by a subscriber while a change was still being raised; subscribers will observe changes out of order. Stack:\n{2}", typeof(T).Name, e.Action, Environment.StackTrace);
		}
		_dispatchDepth++;
		try
		{
			this.CollectionChanged?.Invoke(this, e);
			OnCollectionChanged(e);
			OnPropertyChanged("Count");
		}
		finally
		{
			_dispatchDepth--;
		}
	}
}
