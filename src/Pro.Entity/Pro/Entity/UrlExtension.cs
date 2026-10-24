using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

internal static class UrlExtension
{
	internal static Url Deserialize(Dictionary<string, LoroValue> map)
	{
		return new Url(map.GetEnum<Url.Types.Platform>("platform__3"), Url.Types.StorageExtension.Deserialize(map.GetMap("Storage__union")), Url.Types.RelativeFilePathExtension.Deserialize(map.GetMap("RelativeFilePath__union")));
	}

	internal static Url CreateDefault()
	{
		return new Url(Url.Types.Platform.Unknown, Url.Types.StorageExtension.CreateDefault(), Url.Types.RelativeFilePathExtension.CreateDefault());
	}

	public static LoroValue Serialize(Url instance)
	{
		LoroMap loroMap = new LoroMap();
		loroMap.Insert("platform__3", instance.Platform.ToLoroValueLike());
		loroMap.Insert("Storage__union", Url.Types.StorageExtension.Serialize(instance.Storage).AsValueLike());
		loroMap.Insert("RelativeFilePath__union", Url.Types.RelativeFilePathExtension.Serialize(instance.RelativeFilePath).AsValueLike());
		return loroMap.GetDeepValue();
	}
}
