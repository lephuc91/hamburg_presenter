using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTextSourceMode), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption), SourceToDestinationMethodName = "ToProtoSlideTextSourceOption", DestinationDefaultValue = "Text", DestinationToSourceMethodName = "ToSlideTextSourceMode", SourceDefaultValue = "TextOnly", UnmatchedSourceNames = new string[] { "TextOnly", "ElementMatch" }, UnmatchedDestinationNames = new string[] { "Text", "ElementMatchingName" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideTextSourceMode), typeof(ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption), SourceToDestinationMethodName = "ToEntitySlideTextSourceOption", DestinationDefaultValue = "Text", DestinationToSourceMethodName = "ToSlideTextSourceMode", SourceDefaultValue = "TextOnly", UnmatchedSourceNames = new string[] { "TextOnly", "ElementMatch" }, UnmatchedDestinationNames = new string[] { "Text", "ElementMatchingName" })]
public static class SlideTextSourceModeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption ToProtoSlideTextSourceOption(this SlideTextSourceMode source)
	{
		return source switch
		{
			SlideTextSourceMode.TextOnly => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.Text, 
			SlideTextSourceMode.Notes => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.Notes, 
			SlideTextSourceMode.ElementMatch => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.ElementMatchingName, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.Text, 
		};
	}

	public static SlideTextSourceMode ToSlideTextSourceMode(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.Text => SlideTextSourceMode.TextOnly, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.Notes => SlideTextSourceMode.Notes, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText.Types.TextSourceOption.ElementMatchingName => SlideTextSourceMode.ElementMatch, 
			_ => SlideTextSourceMode.TextOnly, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption ToEntitySlideTextSourceOption(this SlideTextSourceMode source)
	{
		return source switch
		{
			SlideTextSourceMode.TextOnly => ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.Text, 
			SlideTextSourceMode.Notes => ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.Notes, 
			SlideTextSourceMode.ElementMatch => ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.ElementMatchingName, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.Text, 
		};
	}

	public static SlideTextSourceMode ToSlideTextSourceMode(this ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.Text => SlideTextSourceMode.TextOnly, 
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.Notes => SlideTextSourceMode.Notes, 
			ISlide.Types.IElement.Types.IDataLink.Types.ISlideText.Types.TextSourceOption.ElementMatchingName => SlideTextSourceMode.ElementMatch, 
			_ => SlideTextSourceMode.TextOnly, 
		};
	}
}
