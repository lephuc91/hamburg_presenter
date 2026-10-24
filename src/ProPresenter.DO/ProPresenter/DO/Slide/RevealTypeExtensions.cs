using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RevealType), typeof(ISlide.Types.IElement.Types.TextRevealType), SourceToDestinationMethodName = "ToEntityTextRevealType", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToTextRevealType", SourceDefaultValue = "None")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RevealType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType), SourceToDestinationMethodName = "ToProtoTextRevealType", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToTextRevealType", SourceDefaultValue = "None")]
public static class RevealTypeExtensions
{
	public static ISlide.Types.IElement.Types.TextRevealType ToEntityTextRevealType(this RevealType source)
	{
		return source switch
		{
			RevealType.None => ISlide.Types.IElement.Types.TextRevealType.None, 
			RevealType.Bullet => ISlide.Types.IElement.Types.TextRevealType.Bullet, 
			RevealType.Underline => ISlide.Types.IElement.Types.TextRevealType.Underline, 
			_ => ISlide.Types.IElement.Types.TextRevealType.None, 
		};
	}

	public static RevealType ToTextRevealType(this ISlide.Types.IElement.Types.TextRevealType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.TextRevealType.None => RevealType.None, 
			ISlide.Types.IElement.Types.TextRevealType.Bullet => RevealType.Bullet, 
			ISlide.Types.IElement.Types.TextRevealType.Underline => RevealType.Underline, 
			_ => RevealType.None, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType ToProtoTextRevealType(this RevealType source)
	{
		return source switch
		{
			RevealType.None => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.None, 
			RevealType.Bullet => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.Bullet, 
			RevealType.Underline => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.Underline, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.None, 
		};
	}

	public static RevealType ToTextRevealType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.None => RevealType.None, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.Bullet => RevealType.Bullet, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextRevealType.Underline => RevealType.Underline, 
			_ => RevealType.None, 
		};
	}
}
