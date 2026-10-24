using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal static class IntRangeExtension
{
	internal static IntRange Deserialize(Dictionary<string, LoroValue> map)
	{
		return new IntRange(map.GetInt("start__1"), map.GetInt("end__2"));
	}

	internal static IntRange CreateDefault()
	{
		return new IntRange(0, 0);
	}

	public static LoroValue Serialize(IntRange instance)
	{
		LoroMap loroMap = new LoroMap();
		loroMap.Insert("start__1", instance.Start.ToLoroValueLike());
		loroMap.Insert("end__2", instance.End.ToLoroValueLike());
		return loroMap.GetDeepValue();
	}
}
