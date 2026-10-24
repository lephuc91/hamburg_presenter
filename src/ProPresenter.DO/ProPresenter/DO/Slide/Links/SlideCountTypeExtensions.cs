using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideCountType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType), SourceToDestinationMethodName = "ToProtoSlideCountSourceType", DestinationDefaultValue = "Current", DestinationToSourceMethodName = "ToSlideCountType", SourceDefaultValue = "Current")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideCountType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType), SourceToDestinationMethodName = "ToEntitySlideCountSourceType", DestinationDefaultValue = "Current", DestinationToSourceMethodName = "ToSlideCountType", SourceDefaultValue = "Current")]
public static class SlideCountTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType ToProtoSlideCountSourceType(this SlideCountType source)
	{
		return source switch
		{
			SlideCountType.Current => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Current, 
			SlideCountType.Remaining => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Remaining, 
			SlideCountType.Total => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Total, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Current, 
		};
	}

	public static SlideCountType ToSlideCountType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Current => SlideCountType.Current, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Remaining => SlideCountType.Remaining, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount.Types.SlideCountSourceType.Total => SlideCountType.Total, 
			_ => SlideCountType.Current, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType ToEntitySlideCountSourceType(this SlideCountType source)
	{
		return source switch
		{
			SlideCountType.Current => ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Current, 
			SlideCountType.Remaining => ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Remaining, 
			SlideCountType.Total => ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Total, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Current, 
		};
	}

	public static SlideCountType ToSlideCountType(this ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Current => SlideCountType.Current, 
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Remaining => SlideCountType.Remaining, 
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount.Types.SlideCountSourceType.Total => SlideCountType.Total, 
			_ => SlideCountType.Current, 
		};
	}
}
