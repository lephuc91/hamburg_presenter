using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public abstract class DeviceCollection<T> : ImmutableObservableCollection<T> where T : IDevice
{
	private bool _suppressCollectionChanged;

	protected void SetDevices(IEnumerable<T> devices)
	{
		_suppressCollectionChanged = true;
		try
		{
			base.Collection.Clear();
			base.Collection.AddRange(devices);
		}
		finally
		{
			_suppressCollectionChanged = false;
		}
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (!_suppressCollectionChanged)
		{
			base.OnCollectionChanged(e);
		}
	}

	internal void Remove(T device)
	{
		base.Collection.Remove(device);
	}

	internal void Remove(string uuid)
	{
		base.Collection.Where((T d) => d.UUID == uuid).ToArray().ForEach(Remove);
	}

	public T? FindDevice(string uuid)
	{
		if (!string.IsNullOrEmpty(uuid))
		{
			return base.Collection.FirstOrDefault((T d) => d.UUID == uuid);
		}
		return default(T);
	}
}
