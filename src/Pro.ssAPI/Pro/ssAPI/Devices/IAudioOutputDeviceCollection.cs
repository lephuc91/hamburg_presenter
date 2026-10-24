using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public interface IAudioOutputDeviceCollection : INotifyEnumerableChanged<IAudioOutputDevice>, IEnumerable<IAudioOutputDevice>, IEnumerable, INotifyCollectionChanged
{
	IAudioOutputDevice? FindDevice(string uuid);
}
