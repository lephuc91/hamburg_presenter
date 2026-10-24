using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ElementVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion), SourceToDestinationMethodName = "ToProtoElementVisibilityCriterion", DestinationDefaultValue = "HasText", DestinationToSourceMethodName = "ToElementVisibilityCriteria", SourceDefaultValue = "HasText")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ElementVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion), SourceToDestinationMethodName = "ToEntityCaptureSessionVisibilityCriteria", DestinationDefaultValue = "HasText", DestinationToSourceMethodName = "ToElementVisibilityCriteria", SourceDefaultValue = "HasText")]
public static class ElementVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion ToProtoElementVisibilityCriterion(this ElementVisibilityCriteria source)
	{
		return source switch
		{
			ElementVisibilityCriteria.HasText => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion.HasText, 
			ElementVisibilityCriteria.HasNoText => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion.HasNoText, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion.HasText, 
		};
	}

	public static ElementVisibilityCriteria ToElementVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion.HasText => ElementVisibilityCriteria.HasText, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility.Types.ElementVisibilityCriterion.HasNoText => ElementVisibilityCriteria.HasNoText, 
			_ => ElementVisibilityCriteria.HasText, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion ToEntityCaptureSessionVisibilityCriteria(this ElementVisibilityCriteria source)
	{
		return source switch
		{
			ElementVisibilityCriteria.HasText => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion.HasText, 
			ElementVisibilityCriteria.HasNoText => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion.HasNoText, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion.HasText, 
		};
	}

	public static ElementVisibilityCriteria ToElementVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion.HasText => ElementVisibilityCriteria.HasText, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility.Types.ElementVisibilityCriterion.HasNoText => ElementVisibilityCriteria.HasNoText, 
			_ => ElementVisibilityCriteria.HasText, 
		};
	}
}
