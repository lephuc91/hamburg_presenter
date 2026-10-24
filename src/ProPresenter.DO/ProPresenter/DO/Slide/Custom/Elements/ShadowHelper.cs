using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Shadows;

namespace ProPresenter.DO.Slide.Custom.Elements;

public static class ShadowHelper
{
	public static IShadow GenerateShadow(this ShadowType type)
	{
		if (type == ShadowType.Drop)
		{
			return new DropShadow();
		}
		throw new NotSupportedException();
	}

	private static IShadow GenerateShadow(Graphics.Types.Shadow.Types.Style type)
	{
		if (type == Graphics.Types.Shadow.Types.Style.Drop)
		{
			return new DropShadow();
		}
		throw new NotSupportedException("Unknown shadow type");
	}

	public static IShadow DeserializeShadow(this Graphics.Types.Shadow protoShadow)
	{
		IShadow shadow = GenerateShadow(protoShadow.Style);
		shadow.Deserialize(protoShadow);
		return shadow;
	}

	public static Graphics.Types.Shadow.Types.Style GetProtoShadowType(ShadowType type)
	{
		if (type == ShadowType.Drop)
		{
			return Graphics.Types.Shadow.Types.Style.Drop;
		}
		throw new NotSupportedException("Unknown shadow type");
	}
}
