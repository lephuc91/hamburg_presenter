using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public interface IAudioInputDeviceCollection : INotifyEnumerableChanged<IAudioInputDevice>, IEnumerable<IAudioInputDevice>, IEnumerable, INotifyCollectionChanged
{
	IAudioInputDevice? FindDevice(string uuid);
}
