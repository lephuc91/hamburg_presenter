using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Feathers;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FeatherType), typeof(Graphics.Types.Feather.Types.Style), SourceToDestinationMethodName = "ToProtoFeatherType", DestinationDefaultValue = "Inside", DestinationToSourceMethodName = "ToFeatherType", SourceDefaultValue = "Inside")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FeatherType), typeof(IGraphics.Types.IFeather.Types.Style), SourceToDestinationMethodName = "ToEntityFeatherType", DestinationDefaultValue = "Inside", DestinationToSourceMethodName = "ToFeatherType", SourceDefaultValue = "Inside")]
public static class FeatherTypeExtensions
{
	public static Graphics.Types.Feather.Types.Style ToProtoFeatherType(this FeatherType source)
	{
		return source switch
		{
			FeatherType.Inside => Graphics.Types.Feather.Types.Style.Inside, 
			FeatherType.Center => Graphics.Types.Feather.Types.Style.Center, 
			FeatherType.Outside => Graphics.Types.Feather.Types.Style.Outside, 
			_ => Graphics.Types.Feather.Types.Style.Inside, 
		};
	}

	public static FeatherType ToFeatherType(this Graphics.Types.Feather.Types.Style source)
	{
		return source switch
		{
			Graphics.Types.Feather.Types.Style.Inside => FeatherType.Inside, 
			Graphics.Types.Feather.Types.Style.Center => FeatherType.Center, 
			Graphics.Types.Feather.Types.Style.Outside => FeatherType.Outside, 
			_ => FeatherType.Inside, 
		};
	}

	public static IGraphics.Types.IFeather.Types.Style ToEntityFeatherType(this FeatherType source)
	{
		return source switch
		{
			FeatherType.Inside => IGraphics.Types.IFeather.Types.Style.Inside, 
			FeatherType.Center => IGraphics.Types.IFeather.Types.Style.Center, 
			FeatherType.Outside => IGraphics.Types.IFeather.Types.Style.Outside, 
			_ => IGraphics.Types.IFeather.Types.Style.Inside, 
		};
	}

	public static FeatherType ToFeatherType(this IGraphics.Types.IFeather.Types.Style source)
	{
		return source switch
		{
			IGraphics.Types.IFeather.Types.Style.Inside => FeatherType.Inside, 
			IGraphics.Types.IFeather.Types.Style.Center => FeatherType.Center, 
			IGraphics.Types.IFeather.Types.Style.Outside => FeatherType.Outside, 
			_ => FeatherType.Inside, 
		};
	}
}
