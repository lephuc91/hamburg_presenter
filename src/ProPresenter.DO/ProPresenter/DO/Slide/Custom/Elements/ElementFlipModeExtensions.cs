using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace ProPresenter.DO.Slide.Custom.Elements;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ElementFlipMode), typeof(IGraphics.Types.IElement.Types.FlipMode), SourceToDestinationMethodName = "ToEntityFlipMode", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToFlipMode", SourceDefaultValue = "None")]
public static class ElementFlipModeExtensions
{
	public static IGraphics.Types.IElement.Types.FlipMode ToEntityFlipMode(this ElementFlipMode source)
	{
		return source switch
		{
			ElementFlipMode.None => IGraphics.Types.IElement.Types.FlipMode.None, 
			ElementFlipMode.Horizontal => IGraphics.Types.IElement.Types.FlipMode.Horizontal, 
			ElementFlipMode.Vertical => IGraphics.Types.IElement.Types.FlipMode.Vertical, 
			ElementFlipMode.Both => IGraphics.Types.IElement.Types.FlipMode.Both, 
			_ => IGraphics.Types.IElement.Types.FlipMode.None, 
		};
	}

	public static ElementFlipMode ToFlipMode(this IGraphics.Types.IElement.Types.FlipMode source)
	{
		return source switch
		{
			IGraphics.Types.IElement.Types.FlipMode.None => ElementFlipMode.None, 
			IGraphics.Types.IElement.Types.FlipMode.Vertical => ElementFlipMode.Vertical, 
			IGraphics.Types.IElement.Types.FlipMode.Horizontal => ElementFlipMode.Horizontal, 
			IGraphics.Types.IElement.Types.FlipMode.Both => ElementFlipMode.Both, 
			_ => ElementFlipMode.None, 
		};
	}
}
