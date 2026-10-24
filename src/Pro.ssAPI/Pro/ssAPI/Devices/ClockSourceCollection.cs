using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.ssAPI.Devices;

public class ClockSourceCollection : ImmutableObservableCollection<ClockSource>
{
	private readonly IClockSourceProvider _provider;

	public ClockSourceCollection(IClockSourceProvider provider)
	{
		_provider = provider;
		_provider.SourceChanged += LoadClockSources;
		LoadClockSources();
	}

	private ClockSource Add()
	{
		ClockSource clockSource = new ClockSource();
		base.Collection.Add(clockSource);
		return clockSource;
	}

	private void Remove(ClockSource clockSource)
	{
		base.Collection.Remove(clockSource);
	}

	private void LoadClockSources()
	{
		List<ClockSource> list = new List<ClockSource>(base.Collection);
		ProClockSource[] array = _provider.Get().ToArray();
		foreach (ProClockSource protoClockSource in array)
		{
			ClockSource clockSource = list.FirstOrDefault((ClockSource i) => i.UUID == protoClockSource.Uuid);
			if (clockSource == null)
			{
				clockSource = Add();
			}
			else
			{
				list.Remove(clockSource);
			}
			clockSource.Deserialize(protoClockSource);
		}
		list.ForEach(Remove);
	}
}
