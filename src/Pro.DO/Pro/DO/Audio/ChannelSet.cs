using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Pro.DO.Audio;

public class ChannelSet<T> : IEnumerable<T>, IEnumerable, INotifyCollectionChanged where T : IChannel, new()
{
	private T[] _channels = Array.Empty<T>();

	public T this[int index] => _channels[index];

	public int ChannelCount => _channels.Length;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public void Resize(int size)
	{
		int num = _channels.Length;
		if (num > size)
		{
			T[] changedItems = _channels.Skip(size).ToArray();
			Array.Resize(ref _channels, size);
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems, size));
		}
		else if (num < size)
		{
			Array.Resize(ref _channels, size);
			for (int i = num; i < size; i++)
			{
				_channels[i] = new T
				{
					Index = i
				};
			}
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _channels.Skip(num).ToArray(), num));
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ((IEnumerable<T>)_channels).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<T>)_channels).GetEnumerator();
	}
}
