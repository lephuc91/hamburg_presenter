using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTargetSourceMode), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType), SourceToDestinationMethodName = "ToProtoSlideSourceType", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToSlideTargetSourceMode", SourceDefaultValue = "Current", UnmatchedSourceNames = new string[] { "Current", "Next" }, UnmatchedDestinationNames = new string[] { "CurrentSlide", "NextSlide" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTargetSourceMode), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource), SourceToDestinationMethodName = "ToProtoSlideLabelSource", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToSlideTargetSourceMode", SourceDefaultValue = "Current", UnmatchedSourceNames = new string[] { "Current", "Next" }, UnmatchedDestinationNames = new string[] { "CurrentSlide", "NextSlide" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTargetSourceMode), typeof(ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType), SourceToDestinationMethodName = "ToEntitySlideSourceType", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToSlideTargetSourceMode", SourceDefaultValue = "Current", UnmatchedSourceNames = new string[] { "Current", "Next" }, UnmatchedDestinationNames = new string[] { "CurrentSlide", "NextSlide" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTargetSourceMode), typeof(ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource), SourceToDestinationMethodName = "ToEntitySlideLabelSource", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToSlideTargetSourceMode", SourceDefaultValue = "Current", UnmatchedSourceNames = new string[] { "Current", "Next" }, UnmatchedDestinationNames = new string[] { "CurrentSlide", "NextSlide" })]
public static class SlideTargetSourceModeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType ToProtoSlideSourceType(this SlideTargetSourceMode source)
	{
		return source switch
		{
			SlideTargetSourceMode.Current => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType.CurrentSlide, 
			SlideTargetSourceMode.Next => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType.NextSlide, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType.CurrentSlide, 
		};
	}

	public static SlideTargetSourceMode ToSlideTargetSourceMode(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType.CurrentSlide => SlideTargetSourceMode.Current, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideSourceType.NextSlide => SlideTargetSourceMode.Next, 
			_ => SlideTargetSourceMode.Current, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource ToProtoSlideLabelSource(this SlideTargetSourceMode source)
	{
		return source switch
		{
			SlideTargetSourceMode.Current => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource.CurrentSlide, 
			SlideTargetSourceMode.Next => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource.NextSlide, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource.CurrentSlide, 
		};
	}

	public static SlideTargetSourceMode ToSlideTargetSourceMode(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource.CurrentSlide => SlideTargetSourceMode.Current, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelSource.NextSlide => SlideTargetSourceMode.Next, 
			_ => SlideTargetSourceMode.Current, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType ToEntitySlideSourceType(this SlideTargetSourceMode source)
	{
		return source switch
		{
			SlideTargetSourceMode.Current => ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType.CurrentSlide, 
			SlideTargetSourceMode.Next => ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType.NextSlide, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType.CurrentSlide, 
		};
	}

	public static SlideTargetSourceMode ToSlideTargetSourceMode(this ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType.CurrentSlide => SlideTargetSourceMode.Current, 
			ISlide.Types.IElement.Types.IDataLink.Types.SlideSourceType.NextSlide => SlideTargetSourceMode.Next, 
			_ => SlideTargetSourceMode.Current, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource ToEntitySlideLabelSource(this SlideTargetSourceMode source)
	{
		return source switch
		{
			SlideTargetSourceMode.Current => ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource.CurrentSlide, 
			SlideTargetSourceMode.Next => ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource.NextSlide, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource.CurrentSlide, 
		};
	}

	public static SlideTargetSourceMode ToSlideTargetSourceMode(this ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource.CurrentSlide => SlideTargetSourceMode.Current, 
			ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelSource.NextSlide => SlideTargetSourceMode.Next, 
			_ => SlideTargetSourceMode.Current, 
		};
	}
}
