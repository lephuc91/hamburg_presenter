using System;
using System.Collections.Generic;
using ProPresenter.DO.Communication;

namespace ProPresenter.DO.Settings;

public interface ICommunicationDeviceProvider
{
	IEnumerable<IDevice>? Devices { get; }

	event Action<IEnumerable<IDevice>?, IEnumerable<IDevice>?>? DevicesChanged;
}
