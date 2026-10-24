using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Feathers;

public static class FeatherHelper
{
	public static IFeather DeserializeFeather(this Graphics.Types.Feather protoFeather)
	{
		IFeather feather = GenerateFeather(protoFeather.Style);
		feather.Deserialize(protoFeather);
		return feather;
	}

	private static IFeather GenerateFeather(Graphics.Types.Feather.Types.Style type)
	{
		if (type == Graphics.Types.Feather.Types.Style.Inside)
		{
			return new Feather();
		}
		throw new NotSupportedException("Unknown or not supported feather type");
	}
}
