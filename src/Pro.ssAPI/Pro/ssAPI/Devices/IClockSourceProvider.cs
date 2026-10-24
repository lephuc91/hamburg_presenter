using System;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.ssAPI.Devices;

public interface IClockSourceProvider
{
	event System.Action SourceChanged;

	IEnumerable<ProClockSource> Get();

	void RefreshClockSources();
}
