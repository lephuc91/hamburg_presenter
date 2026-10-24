using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal static class FontExtension
{
	internal static Font Deserialize(Dictionary<string, LoroValue> map)
	{
		return new Font(map.GetNullableString("name__1"), map.GetDouble("size__2"), map.GetBool("italic__4"), map.GetBool("bold__8"), map.GetNullableString("family__9"), map.GetNullableString("face__10"));
	}

	internal static Font CreateDefault()
	{
		return new Font(null, 0.0, Italic: false, Bold: false, null, null);
	}

	public static LoroValue Serialize(Font instance)
	{
		LoroMap loroMap = new LoroMap();
		loroMap.Insert("name__1", instance.Name.ToLoroValueLike());
		loroMap.Insert("size__2", instance.Size.ToLoroValueLike());
		loroMap.Insert("italic__4", instance.Italic.ToLoroValueLike());
		loroMap.Insert("bold__8", instance.Bold.ToLoroValueLike());
		loroMap.Insert("family__9", instance.Family.ToLoroValueLike());
		loroMap.Insert("face__10", instance.Face.ToLoroValueLike());
		return loroMap.GetDeepValue();
	}
}
