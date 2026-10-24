using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CaptureSessionVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion), SourceToDestinationMethodName = "ToProtoCaptureSessionVisibilityCriteria", DestinationDefaultValue = "Active", DestinationToSourceMethodName = "ToCaptureSessionVisibilityCriteria", SourceDefaultValue = "Active")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CaptureSessionVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion), SourceToDestinationMethodName = "ToEntityCaptureSessionVisibilityCriteria", DestinationDefaultValue = "Active", DestinationToSourceMethodName = "ToCaptureSessionVisibilityCriteria", SourceDefaultValue = "Active")]
public static class CaptureSessionVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion ToProtoCaptureSessionVisibilityCriteria(this CaptureSessionVisibilityCriteria source)
	{
		return source switch
		{
			CaptureSessionVisibilityCriteria.Active => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active, 
			CaptureSessionVisibilityCriteria.Inactive => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Inactive, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active, 
		};
	}

	public static CaptureSessionVisibilityCriteria ToCaptureSessionVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active => CaptureSessionVisibilityCriteria.Active, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Inactive => CaptureSessionVisibilityCriteria.Inactive, 
			_ => CaptureSessionVisibilityCriteria.Active, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion ToEntityCaptureSessionVisibilityCriteria(this CaptureSessionVisibilityCriteria source)
	{
		return source switch
		{
			CaptureSessionVisibilityCriteria.Active => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active, 
			CaptureSessionVisibilityCriteria.Inactive => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Inactive, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active, 
		};
	}

	public static CaptureSessionVisibilityCriteria ToCaptureSessionVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Active => CaptureSessionVisibilityCriteria.Active, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility.Types.CaptureSessionVisibilityCriterion.Inactive => CaptureSessionVisibilityCriteria.Inactive, 
			_ => CaptureSessionVisibilityCriteria.Active, 
		};
	}
}
