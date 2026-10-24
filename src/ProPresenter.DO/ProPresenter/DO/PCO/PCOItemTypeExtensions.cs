using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOItemType), typeof(PlanningCenterPlan.Types.PlanItem.Types.PlanItemType), SourceToDestinationMethodName = "ToProtoPlanItemType", DestinationToSourceMethodName = "ToPCOItemType", UnmatchedSourceNames = new string[] { "Plan" }, UnmatchedDestinationNames = new string[] { "Item" }, ExcludeSourceNames = new string[] { "Arrangement", "Key" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOItemType), typeof(IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType), SourceToDestinationMethodName = "ToEntityPlanItemType", DestinationToSourceMethodName = "ToPCOItemType", UnmatchedSourceNames = new string[] { "Plan" }, UnmatchedDestinationNames = new string[] { "Item" }, ExcludeSourceNames = new string[] { "Arrangement", "Key" })]
public static class PCOItemTypeExtensions
{
	public static PlanningCenterPlan.Types.PlanItem.Types.PlanItemType ToProtoPlanItemType(this PCOItemType source)
	{
		return source switch
		{
			PCOItemType.Plan => PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Item, 
			PCOItemType.Header => PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Header, 
			PCOItemType.Song => PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Song, 
			PCOItemType.Media => PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Media, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static PCOItemType ToPCOItemType(this PlanningCenterPlan.Types.PlanItem.Types.PlanItemType source)
	{
		return source switch
		{
			PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Item => PCOItemType.Plan, 
			PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Song => PCOItemType.Song, 
			PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Media => PCOItemType.Media, 
			PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Header => PCOItemType.Header, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType ToEntityPlanItemType(this PCOItemType source)
	{
		return source switch
		{
			PCOItemType.Plan => IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Item, 
			PCOItemType.Header => IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Header, 
			PCOItemType.Song => IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Song, 
			PCOItemType.Media => IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Media, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static PCOItemType ToPCOItemType(this IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType source)
	{
		return source switch
		{
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Item => PCOItemType.Plan, 
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Song => PCOItemType.Song, 
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Media => PCOItemType.Media, 
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Header => PCOItemType.Header, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
