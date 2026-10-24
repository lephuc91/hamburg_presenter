using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Scrollers;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScrollingType), typeof(ISlide.Types.IElement.Types.ITextScroller.Types.Direction), SourceToDestinationMethodName = "ToEntityDirection", DestinationDefaultValue = "Left", DestinationToSourceMethodName = "ToScrollingType", SourceDefaultValue = "Left")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScrollingType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction), SourceToDestinationMethodName = "ToProtoDirection", DestinationDefaultValue = "Left", DestinationToSourceMethodName = "ToScrollingType", SourceDefaultValue = "Left")]
public static class ScrollingTypeExtensions
{
	public static bool IsVertical(this ScrollingType scrollingType)
	{
		return scrollingType.IsAnyOf(ScrollingType.Up, ScrollingType.Down);
	}

	public static ISlide.Types.IElement.Types.ITextScroller.Types.Direction ToEntityDirection(this ScrollingType source)
	{
		return source switch
		{
			ScrollingType.Left => ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Left, 
			ScrollingType.Right => ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Right, 
			ScrollingType.Up => ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Up, 
			ScrollingType.Down => ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Down, 
			_ => ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Left, 
		};
	}

	public static ScrollingType ToScrollingType(this ISlide.Types.IElement.Types.ITextScroller.Types.Direction source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Left => ScrollingType.Left, 
			ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Right => ScrollingType.Right, 
			ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Up => ScrollingType.Up, 
			ISlide.Types.IElement.Types.ITextScroller.Types.Direction.Down => ScrollingType.Down, 
			_ => ScrollingType.Left, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction ToProtoDirection(this ScrollingType source)
	{
		return source switch
		{
			ScrollingType.Left => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Left, 
			ScrollingType.Right => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Right, 
			ScrollingType.Up => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Up, 
			ScrollingType.Down => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Down, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Left, 
		};
	}

	public static ScrollingType ToScrollingType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Left => ScrollingType.Left, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Right => ScrollingType.Right, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Up => ScrollingType.Up, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller.Types.Direction.Down => ScrollingType.Down, 
			_ => ScrollingType.Left, 
		};
	}
}
