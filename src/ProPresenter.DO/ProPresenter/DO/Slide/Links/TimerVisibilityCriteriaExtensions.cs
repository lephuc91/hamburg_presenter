using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion), SourceToDestinationMethodName = "ToProtoTimerVisibilityCriterion", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToTimerVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion), SourceToDestinationMethodName = "ToEntityTimerVisibilityCriteria", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToTimerVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining")]
public static class TimerVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion ToProtoTimerVisibilityCriterion(this TimerVisibilityCriteria source)
	{
		return source switch
		{
			TimerVisibilityCriteria.HasTimeRemaining => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining, 
			TimerVisibilityCriteria.HasExpired => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.HasExpired, 
			TimerVisibilityCriteria.IsRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.IsRunning, 
			TimerVisibilityCriteria.NotRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.NotRunning, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static TimerVisibilityCriteria ToTimerVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining => TimerVisibilityCriteria.HasTimeRemaining, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.HasExpired => TimerVisibilityCriteria.HasExpired, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.IsRunning => TimerVisibilityCriteria.IsRunning, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility.Types.TimerVisibilityCriterion.NotRunning => TimerVisibilityCriteria.NotRunning, 
			_ => TimerVisibilityCriteria.HasTimeRemaining, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion ToEntityTimerVisibilityCriteria(this TimerVisibilityCriteria source)
	{
		return source switch
		{
			TimerVisibilityCriteria.HasTimeRemaining => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining, 
			TimerVisibilityCriteria.HasExpired => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.HasExpired, 
			TimerVisibilityCriteria.IsRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.IsRunning, 
			TimerVisibilityCriteria.NotRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.NotRunning, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static TimerVisibilityCriteria ToTimerVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.HasTimeRemaining => TimerVisibilityCriteria.HasTimeRemaining, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.HasExpired => TimerVisibilityCriteria.HasExpired, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.IsRunning => TimerVisibilityCriteria.IsRunning, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility.Types.TimerVisibilityCriterion.NotRunning => TimerVisibilityCriteria.NotRunning, 
			_ => TimerVisibilityCriteria.HasTimeRemaining, 
		};
	}
}
