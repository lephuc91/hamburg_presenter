using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public interface IVideoInputDeviceCollection : INotifyEnumerableChanged<IVideoInputDevice>, IEnumerable<IVideoInputDevice>, IEnumerable, INotifyCollectionChanged
{
	IVideoInputDevice? FindDevice(string uuid);

	IAirCastVideoInputDevice? GetOrAddAirCastVideoInputDevice();
}
