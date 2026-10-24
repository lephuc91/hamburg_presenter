using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VideoInputVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion), SourceToDestinationMethodName = "ToProtoVideoInputVisibilityCriteria", DestinationDefaultValue = "Active", DestinationToSourceMethodName = "ToVideoInputVisibilityCriteria", SourceDefaultValue = "Active")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VideoInputVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion), SourceToDestinationMethodName = "ToEntityVideoInputVisibilityCriterion", DestinationDefaultValue = "Active", DestinationToSourceMethodName = "ToVideoInputVisibilityCriteria", SourceDefaultValue = "Active")]
public static class VideoInputVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion ToProtoVideoInputVisibilityCriteria(this VideoInputVisibilityCriteria source)
	{
		return source switch
		{
			VideoInputVisibilityCriteria.Active => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion.Active, 
			VideoInputVisibilityCriteria.Inactive => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion.Inactive, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion.Active, 
		};
	}

	public static VideoInputVisibilityCriteria ToVideoInputVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion.Active => VideoInputVisibilityCriteria.Active, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility.Types.VideoInputVisibilityCriterion.Inactive => VideoInputVisibilityCriteria.Inactive, 
			_ => VideoInputVisibilityCriteria.Active, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion ToEntityVideoInputVisibilityCriterion(this VideoInputVisibilityCriteria source)
	{
		return source switch
		{
			VideoInputVisibilityCriteria.Active => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion.Active, 
			VideoInputVisibilityCriteria.Inactive => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion.Inactive, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion.Active, 
		};
	}

	public static VideoInputVisibilityCriteria ToVideoInputVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion.Active => VideoInputVisibilityCriteria.Active, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility.Types.VideoInputVisibilityCriterion.Inactive => VideoInputVisibilityCriteria.Inactive, 
			_ => VideoInputVisibilityCriteria.Active, 
		};
	}
}
