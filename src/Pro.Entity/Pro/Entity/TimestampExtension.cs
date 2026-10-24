using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal static class TimestampExtension
{
	internal static Timestamp Deserialize(Dictionary<string, LoroValue> map)
	{
		return new Timestamp(map.GetLong("seconds__1"), map.GetInt("nanos__2"));
	}

	internal static Timestamp CreateDefault()
	{
		return new Timestamp(0L, 0);
	}

	public static LoroValue Serialize(Timestamp instance)
	{
		LoroMap loroMap = new LoroMap();
		loroMap.Insert("seconds__1", instance.Seconds.ToLoroValueLike());
		loroMap.Insert("nanos__2", instance.Nanos.ToLoroValueLike());
		return loroMap.GetDeepValue();
	}
}
