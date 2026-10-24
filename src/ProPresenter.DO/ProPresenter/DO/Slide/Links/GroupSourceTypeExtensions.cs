using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(GroupSourceType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType), SourceToDestinationMethodName = "ToProtoGroupSource", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToGroupSourceType", SourceDefaultValue = "CurrentSlide")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(GroupSourceType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType), SourceToDestinationMethodName = "ToEntityGroupSource", DestinationDefaultValue = "CurrentSlide", DestinationToSourceMethodName = "ToGroupSourceType", SourceDefaultValue = "CurrentSlide")]
public static class GroupSourceTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType ToProtoGroupSource(this GroupSourceType source)
	{
		return source switch
		{
			GroupSourceType.CurrentSlide => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.CurrentSlide, 
			GroupSourceType.NextSlide => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.NextSlide, 
			GroupSourceType.NextGroup => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.NextGroup, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.CurrentSlide, 
		};
	}

	public static GroupSourceType ToGroupSourceType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.CurrentSlide => GroupSourceType.CurrentSlide, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.NextSlide => GroupSourceType.NextSlide, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupSourceType.NextGroup => GroupSourceType.NextGroup, 
			_ => GroupSourceType.CurrentSlide, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType ToEntityGroupSource(this GroupSourceType source)
	{
		return source switch
		{
			GroupSourceType.CurrentSlide => ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.CurrentSlide, 
			GroupSourceType.NextSlide => ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.NextSlide, 
			GroupSourceType.NextGroup => ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.NextGroup, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.CurrentSlide, 
		};
	}

	public static GroupSourceType ToGroupSourceType(this ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.CurrentSlide => GroupSourceType.CurrentSlide, 
			ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.NextSlide => GroupSourceType.NextSlide, 
			ISlide.Types.IElement.Types.IDataLink.Types.GroupSourceType.NextGroup => GroupSourceType.NextGroup, 
			_ => GroupSourceType.CurrentSlide, 
		};
	}
}
