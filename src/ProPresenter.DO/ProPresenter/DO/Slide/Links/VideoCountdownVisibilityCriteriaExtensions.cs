using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VideoCountdownVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion), SourceToDestinationMethodName = "ToProtoVideoCountdownVisibilityCriterion", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToVideoCountdownVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining", UnmatchedSourceNames = new string[] { "IsNotLooping", "IsLooping" }, UnmatchedDestinationNames = new string[] { "NotLooping", "Looping" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(VideoCountdownVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion), SourceToDestinationMethodName = "ToEntityVideoCountdownVisibilityCriterion", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToVideoCountdownVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining", UnmatchedSourceNames = new string[] { "IsNotLooping", "IsLooping" }, UnmatchedDestinationNames = new string[] { "NotLooping", "Looping" })]
public static class VideoCountdownVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion ToProtoVideoCountdownVisibilityCriterion(this VideoCountdownVisibilityCriteria source)
	{
		return source switch
		{
			VideoCountdownVisibilityCriteria.HasTimeRemaining => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining, 
			VideoCountdownVisibilityCriteria.HasExpired => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasExpired, 
			VideoCountdownVisibilityCriteria.IsRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.IsRunning, 
			VideoCountdownVisibilityCriteria.NotRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotRunning, 
			VideoCountdownVisibilityCriteria.IsLooping => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.Looping, 
			VideoCountdownVisibilityCriteria.IsNotLooping => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotLooping, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static VideoCountdownVisibilityCriteria ToVideoCountdownVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining => VideoCountdownVisibilityCriteria.HasTimeRemaining, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasExpired => VideoCountdownVisibilityCriteria.HasExpired, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.IsRunning => VideoCountdownVisibilityCriteria.IsRunning, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotRunning => VideoCountdownVisibilityCriteria.NotRunning, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.Looping => VideoCountdownVisibilityCriteria.IsLooping, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotLooping => VideoCountdownVisibilityCriteria.IsNotLooping, 
			_ => VideoCountdownVisibilityCriteria.HasTimeRemaining, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion ToEntityVideoCountdownVisibilityCriterion(this VideoCountdownVisibilityCriteria source)
	{
		return source switch
		{
			VideoCountdownVisibilityCriteria.HasTimeRemaining => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining, 
			VideoCountdownVisibilityCriteria.HasExpired => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasExpired, 
			VideoCountdownVisibilityCriteria.IsRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.IsRunning, 
			VideoCountdownVisibilityCriteria.NotRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotRunning, 
			VideoCountdownVisibilityCriteria.IsLooping => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.Looping, 
			VideoCountdownVisibilityCriteria.IsNotLooping => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotLooping, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static VideoCountdownVisibilityCriteria ToVideoCountdownVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasTimeRemaining => VideoCountdownVisibilityCriteria.HasTimeRemaining, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.HasExpired => VideoCountdownVisibilityCriteria.HasExpired, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.IsRunning => VideoCountdownVisibilityCriteria.IsRunning, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotRunning => VideoCountdownVisibilityCriteria.NotRunning, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.Looping => VideoCountdownVisibilityCriteria.IsLooping, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility.Types.VideoCountdownVisibilityCriterion.NotLooping => VideoCountdownVisibilityCriteria.IsNotLooping, 
			_ => VideoCountdownVisibilityCriteria.HasTimeRemaining, 
		};
	}
}
