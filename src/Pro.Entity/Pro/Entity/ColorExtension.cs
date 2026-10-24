using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal static class ColorExtension
{
	internal static Color Deserialize(Dictionary<string, LoroValue> map)
	{
		return new Color(map.GetFloat("red__1"), map.GetFloat("green__2"), map.GetFloat("blue__3"), map.GetFloat("alpha__4"));
	}

	internal static Color CreateDefault()
	{
		return new Color(0f, 0f, 0f, 0f);
	}

	public static LoroValue Serialize(Color instance)
	{
		LoroMap loroMap = new LoroMap();
		loroMap.Insert("red__1", instance.Red.ToLoroValueLike());
		loroMap.Insert("green__2", instance.Green.ToLoroValueLike());
		loroMap.Insert("blue__3", instance.Blue.ToLoroValueLike());
		loroMap.Insert("alpha__4", instance.Alpha.ToLoroValueLike());
		return loroMap.GetDeepValue();
	}
}
