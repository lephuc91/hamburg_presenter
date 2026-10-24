using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VisibilityCriterion), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion), SourceToDestinationMethodName = "ToProtoVisibilityCriterion", DestinationDefaultValue = "All", DestinationToSourceMethodName = "ToVisibilityCriterion", SourceDefaultValue = "All")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VisibilityCriterion), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion), SourceToDestinationMethodName = "ToEntityVisibilityCriterion", DestinationDefaultValue = "All", DestinationToSourceMethodName = "ToVisibilityCriterion", SourceDefaultValue = "All")]
public static class VisibilityCriterionExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion ToProtoVisibilityCriterion(this VisibilityCriterion source)
	{
		return source switch
		{
			VisibilityCriterion.All => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.All, 
			VisibilityCriterion.Any => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.Any, 
			VisibilityCriterion.None => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.None, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.All, 
		};
	}

	public static VisibilityCriterion ToVisibilityCriterion(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.All => VisibilityCriterion.All, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.Any => VisibilityCriterion.Any, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.VisibilityCriterion.None => VisibilityCriterion.None, 
			_ => VisibilityCriterion.All, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion ToEntityVisibilityCriterion(this VisibilityCriterion source)
	{
		return source switch
		{
			VisibilityCriterion.All => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.All, 
			VisibilityCriterion.Any => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.Any, 
			VisibilityCriterion.None => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.None, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.All, 
		};
	}

	public static VisibilityCriterion ToVisibilityCriterion(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.All => VisibilityCriterion.All, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.Any => VisibilityCriterion.Any, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.VisibilityCriterion.None => VisibilityCriterion.None, 
			_ => VisibilityCriterion.All, 
		};
	}
}
